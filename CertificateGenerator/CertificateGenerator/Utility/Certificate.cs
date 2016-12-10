using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.Utilities;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Pkix;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

namespace CertificateGenerator.Utility
{
    public enum HashType {
        SHA1withDSA,        //-- DSA
        SHA1withECDSA,      //
        SHA224withECDSA,    // ECDSA with SHA1 and SHA2 support
        SHA256withECDSA,    //
        SHA384withECDSA,    //
        SHA512withECDSA,    //
        MD2withRSA,         // --
        MD5withRSA,         // --
        SHA1withRSA,        // --
        SHA224withRSA,      // -- RSA with MD2, MD5, SHA1, SHA2 and RIPEMD
        SHA256withRSA,      // --
        SHA384withRSA,      // --
        SHA512withRSA,      // --
        RIPEMD160withRSA,   // --
        RIPEMD128withRSA,   // --
        RIPEMD256withRSA,   // --
    }

    public enum ContainerType{
        PKCS7,
        PKCS12,
        PEM,
        DER
    }

    public static class Certificate
    {
        /// <summary>
        /// Returns a Certificate with the specified parameters. ContainerType determines how the data is formatted
        /// </summary>
        /// <param name="certCN"></param>
        /// <param name="signerCN"></param>
        /// <param name="bitStrength"></param>
        /// <param name="hType"></param>
        /// <param name="cType"></param>
        /// <param name="validFrom"></param>
        /// <param name="validTo"></param>
        /// <returns></returns>
        public static byte[] Generate(string certCN, string signerCN, int bitStrength, HashType hType, ContainerType cType, DateTime validFrom, DateTime validTo, string password){

            // Keypair Generator
            var kpGenerator = new RsaKeyPairGenerator();
            kpGenerator.Init(new KeyGenerationParameters(new SecureRandom(), bitStrength));

            // Create a keypair
            var kp = kpGenerator.GenerateKeyPair();

            // Certificate Generator
            var cGenerator = new X509V3CertificateGenerator();

            // Create a certificate
            var cCN = new X509Name("CN=" + certCN);
            var sCN = new X509Name("CN=" + signerCN);
            var serial = BigInteger.ProbablePrime(120, new Random());

            cGenerator.SetSerialNumber(serial);
            cGenerator.SetSubjectDN(cCN);
            cGenerator.SetIssuerDN(sCN);
            cGenerator.SetNotBefore(validFrom);
            cGenerator.SetNotAfter(validTo);
            cGenerator.SetSignatureAlgorithm(hType.ToString());
            cGenerator.SetPublicKey(kp.Public);

            var cert = cGenerator.Generate(kp.Private);                         // Self-signed for now. Can refactor later

            // Return the certificate byte array in the container specified:
            return PackageCertificate(cert, cType, kp.Private, password);
        }

        /// <summary>
        /// Packages the certificate in the specified container
        /// </summary>
        /// <param name="cert"></param>
        /// <param name="cType"></param>
        /// <param name="privateKey"></param>
        /// <returns>Byte array of the container + contents</returns>
        private static byte[] PackageCertificate(X509Certificate cert, ContainerType cType, AsymmetricKeyParameter privateKey, string password) {
            byte[] encoded = null;
            switch (cType){
                case ContainerType.DER:
                    encoded = cert.GetEncoded();
                    break;
                case ContainerType.PKCS12:
                    // Create the PKCS12 store
                    var store = new Pkcs12StoreBuilder().Build();

                    // Add a Certificate entry
                    X509CertificateEntry certEntry = new X509CertificateEntry(cert);
                    store.SetCertificateEntry(cert.SubjectDN.ToString(), certEntry);

                    // Add a key entry
                    AsymmetricKeyEntry keyEntry = new AsymmetricKeyEntry(privateKey);
                    store.SetKeyEntry(cert.SubjectDN.ToString() + "_key", keyEntry, new X509CertificateEntry[] { certEntry });

                    // Extract the byte equivalent form of the PKCS12 store to the output byte array
                    using(var stream = new MemoryStream() ){
                        // Save the pkcs12 to a memory stream
                        store.Save(stream, password.ToCharArray(), new SecureRandom());

                        // Pull the bytes out of the stream
                        stream.Position = 0;                                    // make sure we're at the beginning of the stream before reading
                        encoded = new byte[stream.Length];
                        stream.Read(encoded, 0, (int)stream.Length);
                    }
                    
                    break;
            }

            return encoded;
        }

        /// <summary>
        /// Write out the byte stream to the file system
        /// </summary>
        /// <param name="savePath"></param>
        /// <param name="certBytes"></param>
        public static void Save(string savePath, byte[] certBytes) {
            using (FileStream outStream = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite)) {
                outStream.Write(certBytes, 0, certBytes.Length);
            }
        }
    }

}

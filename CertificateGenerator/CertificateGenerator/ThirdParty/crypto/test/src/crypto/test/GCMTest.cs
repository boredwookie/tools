using System;
using System.Text;

using NUnit.Framework;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Modes.Gcm;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.Utilities.Test;

namespace Org.BouncyCastle.Crypto.Tests
{
	/// <summary>
	/// Test vectors from "The Galois/Counter Mode of Operation (GCM)", McGrew/Viega, Appendix B
	/// </summary>
	[TestFixture]
	public class GcmTest
		: SimpleTest
	{
		private static readonly string[][] TestVectors = new string[][]
		{
			new string[]
			{
				"Test Case 1",
				"00000000000000000000000000000000",
				"",
				"",
				"000000000000000000000000",
				"",
				"58e2fccefa7e3061367f1d57a4e7455a",
			},
			new string[]
			{
				"Test Case 2",
				"00000000000000000000000000000000",
				"00000000000000000000000000000000",
				"",
				"000000000000000000000000",
				"0388dace60b6a392f328c2b971b2fe78",
				"ab6e47d42cec13bdf53a67b21257bddf",
			},
			new string[]
			{
				"Test Case 3",
				"feffe9928665731c6d6a8f9467308308",
				"d9313225f88406e5a55909c5aff5269a"
				+ "86a7a9531534f7da2e4c303d8a318a72"
				+ "1c3c0c95956809532fcf0e2449a6b525"
				+ "b16aedf5aa0de657ba637b391aafd255",
				"",
				"cafebabefacedbaddecaf888",
				"42831ec2217774244b7221b784d0d49c"
				+ "e3aa212f2c02a4e035c17e2329aca12e"
				+ "21d514b25466931c7d8f6a5aac84aa05"
				+ "1ba30b396a0aac973d58e091473f5985",
				"4d5c2af327cd64a62cf35abd2ba6fab4",
			},
			new string[]
			{
				"Test Case 4",
				"feffe9928665731c6d6a8f9467308308",
				"d9313225f88406e5a55909c5aff5269a"
				+ "86a7a9531534f7da2e4c303d8a318a72"
				+ "1c3c0c95956809532fcf0e2449a6b525"
				+ "b16aedf5aa0de657ba637b39",
				"feedfacedeadbeeffeedfacedeadbeef"
				+ "abaddad2",
				"cafebabefacedbaddecaf888",
				"42831ec2217774244b7221b784d0d49c"
				+ "e3aa212f2c02a4e035c17e2329aca12e"
				+ "21d514b25466931c7d8f6a5aac84aa05"
				+ "1ba30b396a0aac973d58e091",
				"5bc94fbc3221a5db94fae95ae7121a47",
			},
			new string[]
			{
				"Test Case 5",
				"feffe9928665731c6d6a8f9467308308",
				"d9313225f88406e5a55909c5aff5269a"
				+ "86a7a9531534f7da2e4c303d8a318a72"
				+ "1c3c0c95956809532fcf0e2449a6b525"
				+ "b16aedf5aa0de657ba637b39",
				"feedfacedeadbeeffeedfacedeadbeef"
				+ "abaddad2",
				"cafebabefacedbad",
				"61353b4c2806934a777ff51fa22a4755"
				+ "699b2a714fcdc6f83766e5f97b6c7423"
				+ "73806900e49f24b22b097544d4896b42"
				+ "4989b5e1ebac0f07c23f4598",
				"3612d2e79e3b0785561be14aaca2fccb",
			},
			new string[]
			{
				"Test Case 6",
				"feffe9928665731c6d6a8f9467308308",
				"d9313225f88406e5a55909c5aff5269a"
				+ "86a7a9531534f7da2e4c303d8a318a72"
				+ "1c3c0c95956809532fcf0e2449a6b525"
				+ "b16aedf5aa0de657ba637b39",
				"feedfacedeadbeeffeedfacedeadbeef"
				+ "abaddad2",
				"9313225df88406e555909c5aff5269aa"
				+ "6a7a9538534f7da1e4c303d2a318a728"
				+ "c3c0c95156809539fcf0e2429a6b5254"
				+ "16aedbf5a0de6a57a637b39b",
				"8ce24998625615b603a033aca13fb894"
				+ "be9112a5c3a211a8ba262a3cca7e2ca7"
				+ "01e4a9a4fba43c90ccdcb281d48c7c6f"
				+ "d62875d2aca417034c34aee5",
				"619cc5aefffe0bfa462af43c1699d050",
			},
			new string[]
			{
				"Test Case 7",
				"00000000000000000000000000000000"
				+ "0000000000000000",
				"",
				"",
				"000000000000000000000000",
				"",
				"cd33b28ac773f74ba00ed1f312572435",
			},
			new string[]
			{
				"Test Case 8",
				"00000000000000000000000000000000"
				+ "0000000000000000",
				"00000000000000000000000000000000",
				"",
				"000000000000000000000000",
				"98e7247c07f0fe411c267e4384b0f600",
				"2ff58d80033927ab8ef4d4587514f0fb",
			},
			new string[]
			{
				"Test Case 9",
				"feffe9928665731c6d6a8f9467308308"
				+ "feffe9928665731c",
				"d9313225f88406e5a55909c5aff5269a"
				+ "86a7a9531534f7da2e4c303d8a318a72"
				+ "1c3c0c95956809532fcf0e2449a6b525"
				+ "b16aedf5aa0de657ba637b391aafd255",
				"",
				"cafebabefacedbaddecaf888",
				"3980ca0b3c00e841eb06fac4872a2757"
				+ "859e1ceaa6efd984628593b40ca1e19c"
				+ "7d773d00c144c525ac619d18c84a3f47"
				+ "18e2448b2fe324d9ccda2710acade256",
				"9924a7c8587336bfb118024db8674a14",
			},
			new string[]
			{
				"Test Case 10",
				"feffe9928665731c6d6a8f9467308308"
				+ "feffe9928665731c",
				"d9313225f88406e5a55909c5aff5269a"
				+ "86a7a9531534f7da2e4c303d8a318a72"
				+ "1c3c0c95956809532fcf0e2449a6b525"
				+ "b16aedf5aa0de657ba637b39",
				"feedfacedeadbeeffeedfacedeadbeef"
				+ "abaddad2",
				"cafebabefacedbaddecaf888",
				"3980ca0b3c00e841eb06fac4872a2757"
				+ "859e1ceaa6efd984628593b40ca1e19c"
				+ "7d773d00c144c525ac619d18c84a3f47"
				+ "18e2448b2fe324d9ccda2710",
				"2519498e80f1478f37ba55bd6d27618c",
			},
			new string[]
			{
				"Test Case 11",
				"feffe9928665731c6d6a8f9467308308"
				+ "feffe9928665731c",
				"d9313225f88406e5a55909c5aff5269a"
				+ "86a7a9531534f7da2e4c303d8a318a72"
				+ "1c3c0c95956809532fcf0e2449a6b525"
				+ "b16aedf5aa0de657ba637b39",
				"feedfacedeadbeeffeedfacedeadbeef"
				+ "abaddad2",
				"cafebabefacedbad",
				"0f10f599ae14a154ed24b36e25324db8"
				+ "c566632ef2bbb34f8347280fc4507057"
				+ "fddc29df9a471f75c66541d4d4dad1c9"
				+ "e93a19a58e8b473fa0f062f7",
				"65dcc57fcf623a24094fcca40d3533f8",
			},
			new string[]
			{
				"Test Case 12",
				"feffe9928665731c6d6a8f9467308308"
				+ "feffe9928665731c",
				"d9313225f88406e5a55909c5aff5269a"
				+ "86a7a9531534f7da2e4c303d8a318a72"
				+ "1c3c0c95956809532fcf0e2449a6b525"
				+ "b16aedf5aa0de657ba637b39",
				"feedfacedeadbeeffeedfacedeadbeef"
				+ "abaddad2",
				"9313225df88406e555909c5aff5269aa"
				+ "6a7a9538534f7da1e4c303d2a318a728"
				+ "c3c0c95156809539fcf0e2429a6b5254"
				+ "16aedbf5a0de6a57a637b39b",
				"d27e88681ce3243c4830165a8fdcf9ff"
				+ "1de9a1d8e6b447ef6ef7b79828666e45"
				+ "81e79012af34ddd9e2f037589b292db3"
				+ "e67c036745fa22e7e9b7373b",
				"dcf566ff291c25bbb8568fc3d376a6d9",
			},
			new string[]
			{
				"Test Case 13",
				"00000000000000000000000000000000"
				+ "00000000000000000000000000000000",
				"",
				"",
				"000000000000000000000000",
				"",
				"530f8afbc74536b9a963b4f1c4cb738b",
			},
			new string[]
			{
				"Test Case 14",
				"00000000000000000000000000000000"
				+ "00000000000000000000000000000000",
				"00000000000000000000000000000000",
				"",
				"000000000000000000000000",
				"cea7403d4d606b6e074ec5d3baf39d18",
				"d0d1c8a799996bf0265b98b5d48ab919",
			},
			new string[]
			{
				"Test Case 15",
				"feffe9928665731c6d6a8f9467308308"
				+ "feffe9928665731c6d6a8f9467308308",
				"d9313225f88406e5a55909c5aff5269a"
				+ "86a7a9531534f7da2e4c303d8a318a72"
				+ "1c3c0c95956809532fcf0e2449a6b525"
				+ "b16aedf5aa0de657ba637b391aafd255",
				"",
				"cafebabefacedbaddecaf888",
				"522dc1f099567d07f47f37a32a84427d"
				+ "643a8cdcbfe5c0c97598a2bd2555d1aa"
				+ "8cb08e48590dbb3da7b08b1056828838"
				+ "c5f61e6393ba7a0abcc9f662898015ad",
				"b094dac5d93471bdec1a502270e3cc6c",
			},
			new string[]
			{
				"Test Case 16",
				"feffe9928665731c6d6a8f9467308308"
				+ "feffe9928665731c6d6a8f9467308308",
				"d9313225f88406e5a55909c5aff5269a"
				+ "86a7a9531534f7da2e4c303d8a318a72"
				+ "1c3c0c95956809532fcf0e2449a6b525"
				+ "b16aedf5aa0de657ba637b39",
				"feedfacedeadbeeffeedfacedeadbeef"
				+ "abaddad2",
				"cafebabefacedbaddecaf888",
				"522dc1f099567d07f47f37a32a84427d"
				+ "643a8cdcbfe5c0c97598a2bd2555d1aa"
				+ "8cb08e48590dbb3da7b08b1056828838"
				+ "c5f61e6393ba7a0abcc9f662",
				"76fc6ece0f4e1768cddf8853bb2d551b",
			},
			new string[]
			{
				"Test Case 17",
				"feffe9928665731c6d6a8f9467308308"
				+ "feffe9928665731c6d6a8f9467308308",
				"d9313225f88406e5a55909c5aff5269a"
				+ "86a7a9531534f7da2e4c303d8a318a72"
				+ "1c3c0c95956809532fcf0e2449a6b525"
				+ "b16aedf5aa0de657ba637b39",
				"feedfacedeadbeeffeedfacedeadbeef"
				+ "abaddad2",
				"cafebabefacedbad",
				"c3762df1ca787d32ae47c13bf19844cb"
				+ "af1ae14d0b976afac52ff7d79bba9de0"
				+ "feb582d33934a4f0954cc2363bc73f78"
				+ "62ac430e64abe499f47c9b1f",
				"3a337dbf46a792c45e454913fe2ea8f2",
			},
			new string[]
			{
				"Test Case 18",
				"feffe9928665731c6d6a8f9467308308"
				+ "feffe9928665731c6d6a8f9467308308",
				"d9313225f88406e5a55909c5aff5269a"
				+ "86a7a9531534f7da2e4c303d8a318a72"
				+ "1c3c0c95956809532fcf0e2449a6b525"
				+ "b16aedf5aa0de657ba637b39",
				"feedfacedeadbeeffeedfacedeadbeef"
				+ "abaddad2",
				"9313225df88406e555909c5aff5269aa"
				+ "6a7a9538534f7da1e4c303d2a318a728"
				+ "c3c0c95156809539fcf0e2429a6b5254"
				+ "16aedbf5a0de6a57a637b39b",
				"5a8def2f0c9e53f1f75d7853659e2a20"
				+ "eeb2b22aafde6419a058ab4f6f746bf4"
				+ "0fc0c3b780f244452da3ebf1c5d82cde"
				+ "a2418997200ef82e44ae7e3f",
				"a44a8266ee1c8eb0c8b5d4cf5ae9f19a",
			},
		};

		public override string Name
		{
			get { return "GCM"; }
		}

		public override void PerformTest()
		{
			for (int i = 0; i < TestVectors.Length; ++i)
			{
				runTestCase(TestVectors[i]);
			}

			randomTests();
		}    

		private void runTestCase(
			string[] testVector)
		{
			for (int macLength = 12; macLength <= 16; ++macLength)
			{
				runTestCase(testVector, macLength);
			}
		}

		private void runTestCase(
			string[]	testVector,
			int			macLength)
		{
			int pos = 0;
			string testName = testVector[pos++];
			byte[] K = Hex.Decode(testVector[pos++]);
			byte[] P = Hex.Decode(testVector[pos++]);
			byte[] A = Hex.Decode(testVector[pos++]);
			byte[] IV = Hex.Decode(testVector[pos++]);
			byte[] C = Hex.Decode(testVector[pos++]);

			// For short MAC, take leading bytes
			byte[] t = Hex.Decode(testVector[pos++]);
			byte[] T = new byte[macLength];
			Array.Copy(t, T, T.Length);

			AeadParameters parameters = new AeadParameters(new KeyParameter(K), T.Length * 8, IV, A);

			// Default multiplier
			runTestCase(null, null, parameters, testName, P, C, T);

			runTestCase(new BasicGcmMultiplier(), new BasicGcmMultiplier(), parameters, testName, P, C, T);
			runTestCase(new Tables8kGcmMultiplier(), new Tables8kGcmMultiplier(), parameters, testName, P, C, T);
			runTestCase(new Tables64kGcmMultiplier(), new Tables64kGcmMultiplier(), parameters, testName, P, C, T);
		}

		private void runTestCase(
			IGcmMultiplier	encM,
			IGcmMultiplier	decM,
			AeadParameters	parameters,
			string			testName,
			byte[]			P,
			byte[]			C,
			byte[]			T)
		{
			GcmBlockCipher encCipher = initCipher(encM, true, parameters);
			GcmBlockCipher decCipher = initCipher(decM, false, parameters);
			checkTestCase(encCipher, decCipher, testName, P, C, T);
			checkTestCase(encCipher, decCipher, testName + " (reused)", P, C, T);
		}

		private GcmBlockCipher initCipher(
			IGcmMultiplier	m,
			bool			forEncryption,
			AeadParameters	parameters)
		{
			GcmBlockCipher c = new GcmBlockCipher(new AesFastEngine(), m);
			c.Init(forEncryption, parameters);
			return c;
		}

		private void checkTestCase(
			GcmBlockCipher	encCipher,
			GcmBlockCipher	decCipher,
			string			testName,
			byte[]			P,
			byte[]			C,
			byte[]			T)
		{
			byte[] enc = new byte[encCipher.GetOutputSize(P.Length)];
			int len = encCipher.ProcessBytes(P, 0, P.Length, enc, 0);
			len += encCipher.DoFinal(enc, len);

			if (enc.Length != len)
			{
//				Console.WriteLine("" + enc.Length + "/" + len);
				Fail("encryption reported incorrect length: " + testName);
			}

			byte[] mac = encCipher.GetMac();

			byte[] data = new byte[P.Length];
			Array.Copy(enc, data, data.Length);
			byte[] tail = new byte[enc.Length - P.Length];
			Array.Copy(enc, P.Length, tail, 0, tail.Length);

			if (!AreEqual(C, data))
			{
				Fail("incorrect encrypt in: " + testName);
			}

			if (!AreEqual(T, mac))
			{
				Fail("GetMac() returned wrong mac in: " + testName);
			}

			if (!AreEqual(T, tail))
			{
				Fail("stream contained wrong mac in: " + testName);
			}

			byte[] dec = new byte[decCipher.GetOutputSize(enc.Length)];
			len = decCipher.ProcessBytes(enc, 0, enc.Length, dec, 0);
			len += decCipher.DoFinal(dec, len);
			mac = decCipher.GetMac();

			data = new byte[C.Length];
			Array.Copy(dec, data, data.Length);

			if (!AreEqual(P, data))
			{
				Fail("incorrect decrypt in: " + testName);
			}
		}

		private void randomTests()
		{
			SecureRandom srng = new SecureRandom();
			for (int i = 0; i < 10; ++i)
			{
				randomTest(srng, null); 
				randomTest(srng, new BasicGcmMultiplier()); 
				randomTest(srng, new Tables8kGcmMultiplier()); 
				randomTest(srng, new Tables64kGcmMultiplier()); 
			}
		}

		private void randomTest(
			SecureRandom	srng,
			IGcmMultiplier	m)
		{
			int kLength = 16 + 8 * srng.Next(3);
			byte[] K = new byte[kLength];
			srng.NextBytes(K);

			int pLength = srng.Next(1024);
			byte[] P = new byte[pLength];
			srng.NextBytes(P);

			int aLength = srng.Next(1024);
			byte[] A = new byte[aLength];
			srng.NextBytes(A);

			int ivLength = 1 + srng.Next(1024);
			byte[] IV = new byte[ivLength];
			srng.NextBytes(IV);

			GcmBlockCipher cipher = new GcmBlockCipher(new AesFastEngine(), m);
			AeadParameters parameters = new AeadParameters(new KeyParameter(K), 16 * 8, IV, A);
			cipher.Init(true, parameters);
			byte[] C = new byte[cipher.GetOutputSize(P.Length)];
			int len = cipher.ProcessBytes(P, 0, P.Length, C, 0);
			len += cipher.DoFinal(C, len);

			if (C.Length != len)
			{
//				Console.WriteLine("" + C.Length + "/" + len);
				Fail("encryption reported incorrect length in randomised test");
			}

			byte[] encT = cipher.GetMac();
			byte[] tail = new byte[C.Length - P.Length];
			Array.Copy(C, P.Length, tail, 0, tail.Length);

			if (!AreEqual(encT, tail))
			{
				Fail("stream contained wrong mac in randomised test");
			}

			cipher.Init(false, parameters);
			byte[] decP = new byte[cipher.GetOutputSize(C.Length)];
			len = cipher.ProcessBytes(C, 0, C.Length, decP, 0);
			len += cipher.DoFinal(decP, len);

			if (!AreEqual(P, decP))
			{
				Fail("incorrect decrypt in randomised test");
			}

			byte[] decT = cipher.GetMac();
			if (!AreEqual(encT, decT))
			{
				Fail("decryption produced different mac from encryption");
			}
		}

		public static void Main(
			string[] args)
		{
			RunTest(new GcmTest());
		}

		[Test]
		public void TestFunction()
		{
			string resultText = Perform().ToString();

			Assert.AreEqual(Name + ": Okay", resultText);
		}
	}
}

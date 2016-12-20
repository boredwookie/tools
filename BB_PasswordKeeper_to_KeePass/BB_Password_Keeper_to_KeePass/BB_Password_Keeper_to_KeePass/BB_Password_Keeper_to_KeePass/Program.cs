/*
 * Copyright 2016 Rion Carter
 * 
 * Made available to the public under the GNU GPLv3 license
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BB_Password_Keeper_to_KeePass
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BB_PK_to_KP_FormMain());
        }
    }
}

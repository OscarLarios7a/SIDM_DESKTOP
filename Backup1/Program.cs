using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace gsBuscar_cs
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
            Application.Run(new FRM_KIBIXcs());
        }
    }
}
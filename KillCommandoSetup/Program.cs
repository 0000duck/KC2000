using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KillCommandoSetup
{
    static class Program
    {
        //private static string _configLocation = "..\\..\\..\\OpenTKPortation\\OpenTKPortation\\bin\\Debug\\KillCommando.exe.config";
        //private static string _gameLocation = "..\\..\\..\\OpenTKPortation\\OpenTKPortation\\bin\\Debug\\KillCommando.exe";
        private static string _configLocation = "KillCommando.exe.config";
        private static string _gameLocation = "KillCommando.exe";

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(_configLocation, _gameLocation));
        }
    }
}

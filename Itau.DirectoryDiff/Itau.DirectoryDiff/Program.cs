using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Itau.DirectoryDiff
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            string fileA ="";
            string fileB = "";
            int cont = 0;
            foreach (string str in args)
            {
                if (cont == 0)
                    fileA = str;
                if (cont == 1)
                    fileB = str;
                cont++;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormDiffTree(fileA,fileB));
        }
    }
}

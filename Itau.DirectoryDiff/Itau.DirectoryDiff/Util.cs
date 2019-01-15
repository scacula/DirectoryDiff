using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using Itau.TreeFileViewer;


namespace Itau.DirectoryDiff
{

    public static class Util
    {
        public static ConfigDiff Config { get; set; }

        public static void ToolCompare(string file1, string file2)
        {
            if (Config.CompareTool.ToUpper() == "W")
            {
                Itau.TreeFileViewer.Util.WinMergeCompare(file1, file2);
            }
            else
            {
                Itau.TreeFileViewer.Util.ClearCaseCompare(file1, file2);
            }

        }
    }
}

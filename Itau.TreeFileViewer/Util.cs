using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Linq;

namespace Itau.TreeFileViewer
{
    public enum FileNodeType
    {
        File = 1,
        Folder = 2,
        LeftOnly = 4,
        RightOnly = 8,
        Different = 16,
        Equal = 32,
        Version = 64,
        Checkout = 128,
        ViewPrivate = 256,
        Hijacked = 512
    }

    public static class Util
    {

        public static bool FileCompare(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            // Determine if the same file was referenced two times.
            if (file1 == file2)
            {
                // Return true to indicate that the files are the same.
                return true;
            }

            // Open the two files.
            fs1 = new FileStream(file1, FileMode.Open, FileAccess.Read);
            fs2 = new FileStream(file2, FileMode.Open, FileAccess.Read);

            // Check the file sizes. If they are not the same, the files 
            // are not the same.
            if (fs1.Length != fs2.Length)
            {
                // Close the file
                fs1.Close();
                fs2.Close();

                // Return false to indicate files are different
                return false;
            }

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do
            {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            // Close the files.
            fs1.Close();
            fs2.Close();

            // Return the success of the comparison. "file1byte" is 
            // equal to "file2byte" at this point only if the files are 
            // the same.
            return ((file1byte - file2byte) == 0);
        }

        public static void WinMergeCompare(string file1, string file2)
        {

            Process.Start("winmergeU.exe", "\"" + file1 + "\"" + " " + "\"" + file2 + "\"" + " /e");
        }

        public static void ClearCaseCompare(string file1, string file2)
        {

            Process.Start("cleartool.exe", "diff -graphical " + "\"" + file1 + "\"" + " " + "\"" + file2 + "\"");
            //Process.Start("notepad.exe", "c:\\teste2.txt");



            //System.Diagnostics.ProcessStartInfo psi =new System.Diagnostics.ProcessStartInfo(@"cleartool");
            //psi.RedirectStandardOutput = true;
            //psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            ////psi.Arguments = "cleardiffmrg "  " -b";
            //psi.Arguments = "diff -graphical" + file1 + " " + file2 ;
            //psi.UseShellExecute = false;
            //System.Diagnostics.Process monProcess;
            //monProcess = System.Diagnostics.Process.Start(psi);
            //System.IO.StreamReader myOutput = monProcess.StandardOutput;

            //monProcess.WaitForExit();
            //if (monProcess.HasExited)
            //{
            //    string output = myOutput.ReadToEnd();                
            //}
        }

        public static void ClearCaseHistory(string file)
        {
            Process.Start("cleartool.exe", "lshistory -graphical " + file);
        }

        public static int NodeTypeToImageIndex(int nodeType, ImageList imgList)
        {
            int imgIndex = 0;
            if ((nodeType & (int)FileNodeType.File) > 0)
            {
                imgIndex = imgList.Images.IndexOfKey("file.ico");

                if ((nodeType & (int)FileNodeType.LeftOnly) > 0)
                {
                    imgIndex = imgList.Images.IndexOfKey("fileleft.ico");
                }
                if ((nodeType & (int)FileNodeType.RightOnly) > 0)
                {
                    imgIndex = imgList.Images.IndexOfKey("fileright.ico");
                }
                if ((nodeType & (int)FileNodeType.Different) > 0)
                {
                    imgIndex = imgList.Images.IndexOfKey("fileerror.ico");
                }
            }
            if ((nodeType & (int)FileNodeType.Folder) > 0)
            {
                imgIndex = imgList.Images.IndexOfKey("folder.ico");


                if ((nodeType & (int)FileNodeType.LeftOnly) > 0)
                {
                    imgIndex = imgList.Images.IndexOfKey("folderleft.ico");
                }
                if ((nodeType & (int)FileNodeType.RightOnly) > 0)
                {
                    imgIndex = imgList.Images.IndexOfKey("folderright.ico");
                }
                if ((nodeType & (int)FileNodeType.Different) > 0)
                {
                    imgIndex = imgList.Images.IndexOfKey("folderdiff.ico");
                }
            }

            return imgIndex;
        }

        public static void ClearCaseFind(string file)
        {

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(@"cleartool");
            psi.RedirectStandardOutput = true;
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //psi.Arguments = "cleardiffmrg "  " -b";
            psi.Arguments = "find " + file + " -print";
            psi.UseShellExecute = false;
            System.Diagnostics.Process monProcess;
            monProcess = System.Diagnostics.Process.Start(psi);
            System.IO.StreamReader myOutput = monProcess.StandardOutput;

            //monProcess.WaitForExit();
            if (monProcess.HasExited)
            {
                string output = myOutput.ReadToEnd();
            }
        }

        public static bool IsInList(string value, List<string> list)
        {

            foreach (string item in list)
            {
                if (item.ToLower().Trim() == value.ToLower().Trim())
                    return true;
            }

            return false;
        }

        public static bool FilterNodes(string name, int type, ConfigSystem config)
        {

            bool filter = false;

            //Se é File e não está na lista de extensões bloqueadas
            if (((int)FileNodeType.File & (int)type) > 0)
            {
                string extensao = "";

                if (name.LastIndexOf('.') >= 0)
                {
                    if (name.IndexOf(".keep.") > 0)
                    {
                        extensao = ".keep";
                    }
                    else
                    {
                        extensao = name.Substring(name.LastIndexOf('.'), name.Length - name.LastIndexOf('.'));
                    }
                }

                if (!Util.IsInList(extensao, config.IgnoreExtensions))
                {
                    filter = true;
                }

                if (name.ToLower() == "view.dat")
                {
                    filter = false;
                }

            }
            //Se é Folder e não está na lista de diretorios bloqueadas
            else if ((((int)FileNodeType.Folder & (int)type) > 0))
            {
                if (!Util.IsInList(name, config.IgnorePaths))
                {
                    filter = true;
                }
                if (name.ToLower() == "lost+found")
                {
                    filter = false;
                }
            }

            return filter;

        }

        public static bool FilterNodes(TreeNode treenode, ConfigSystem config)
        {
            return FilterNodes(treenode.Text.Trim().ToLower(), (int)treenode.Tag, config);
        }

        public static List<string> DefaultIgnoreFiles()
        {
            List<string> list = new List<string>();
            list.Add(".pdb");
            list.Add(".user");
            list.Add(".gpState");
            list.Add(".suo");
            list.Add(".keep");
            list.Add(".ccexclude");
            return list;
        }

        public static List<string> DefaultIgnoreFolders()
        {
            List<string> list = new List<string>();
            list.Add("bin");
            list.Add("obj");
            return list;
        }

        public static string ListToString(List<string> list)
        {
            string retorno = "";
            int index = 1;
            foreach (string item in list)
            {
                retorno = retorno + item;
                if (list.Count > index)
                {
                    retorno = retorno + ",";
                }
                index++;
            }

            return retorno;
        }


        public static List<KeyValuePair<string, string>> ClearCaseFiles(string path)
        {

            try
            {
                string output = "";

                path = path + System.IO.Path.DirectorySeparatorChar;
                path = System.IO.Path.GetFullPath(path);
             


                output = @"
                
                C:\Temp2\A\txtA.txt
                C:\Temp2\A\aB
                C:\Temp2\A\AA\txt1.txt@@\main\PO_an_Integration\1
                C:\Temp2\A\aB\txtAB.txt@@\main\PO_an_Integration\CHECKEDOUT
                C:\Temp2\txtx.txt@@
                C:\Temp2\B\u.txt@@\main\1 [hijacked]
                C:\Temp2\A\aB\cccc\ops.txt@@\main\PO_an_Integration\CHECKEDOUT
                ";


                //System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(@"cleartool");
                //psi.RedirectStandardOutput = true;
                //psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;

                ////psi.Arguments = "ls -view_only -r -s " + path;
                //psi.Arguments = "ls -view_only -r -s " + path;
                //psi.UseShellExecute = false;
                //System.Diagnostics.Process monProcess;
                //monProcess = System.Diagnostics.Process.Start(psi);
                //System.IO.StreamReader myOutput = monProcess.StandardOutput;

                ////monProcess.WaitForExit();

                ////if (monProcess.HasExited)
                ////{
                //output = myOutput.ReadToEnd();
                ////}


                List<string> listFiles = new List<string>();
                if (!string.IsNullOrEmpty(output))
                    listFiles = (output.Split((char)10)).ToList<string>();


                List<KeyValuePair<string, string>> listNewFiles = new List<KeyValuePair<string, string>>();
                foreach (string strFile in listFiles)
                {

                    string strNewFile = "";
                    string tipo = "";

                    if (!string.IsNullOrEmpty(strFile.Trim()))
                    {
                        if (strFile.IndexOf("@@") < 0)
                        {
                            //ViewPrivate
                            strNewFile = strFile;
                            tipo = "P";
                        }
                        else
                        {
                            if ((strFile.IndexOf("[hijacked]") == (strFile.Length - 11)))
                            {
                                //Hijacked
                                strNewFile = strFile.Substring(0, strFile.IndexOf("@@"));
                                tipo = "H";
                            }
                            else if (((strFile.IndexOf("@@") == (strFile.Length - 3))) || ((strFile.IndexOf("CHECKEDOUT") == (strFile.Length - 11))))
                            {
                                //Checkouted
                                strNewFile = strFile.Substring(0, strFile.IndexOf("@@"));
                                tipo = "C";
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(strNewFile))
                    {
                        strNewFile = strNewFile.Trim();

                        string pathFile = strNewFile.Substring(strNewFile.IndexOf(path) + path.Length, strNewFile.Length - (strNewFile.IndexOf(path) + path.Length));

                        if (pathFile.IndexOf("\\") == 0)
                            pathFile = pathFile.Substring(1, pathFile.Length - 1);

                        //string pathFile = strNewFile.Trim();

                        listNewFiles.Add(new KeyValuePair<string, string>(pathFile.Trim().ToLower(), tipo));
                    }
                }

                return listNewFiles;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<string> ClearCaseViewPrivate2(string path)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(@"cleartool");
                psi.RedirectStandardOutput = true;
                psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;

                //psi.Arguments = "ls -view_only -r -s " + path;
                psi.Arguments = "ls -vob_only -r -s " + path;
                psi.UseShellExecute = false;
                System.Diagnostics.Process monProcess;
                monProcess = System.Diagnostics.Process.Start(psi);
                System.IO.StreamReader myOutput = monProcess.StandardOutput;

                //monProcess.WaitForExit();
                string output = "";
                //if (monProcess.HasExited)
                //{
                output = myOutput.ReadToEnd();
                //}
                List<string> listFiles = new List<string>();
                if (!string.IsNullOrEmpty(output))
                    listFiles = (output.Split((char)10)).ToList<string>();



                return listFiles;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

   

    }
}

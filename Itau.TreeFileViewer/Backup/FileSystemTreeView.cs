using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace Itau.TreeFileViewer
{
    public partial class FileSystemTreeView : TreeView
    {
        public ConfigSystem Config { get; set; }

        #region Construtor
        public FileSystemTreeView(ImageList imageList)
        {

            this.ImageList = imageList;

            this.MouseDown += new MouseEventHandler(FileSystemTreeView_MouseDown);

        }

        public FileSystemTreeView()
        {

            this.MouseDown += new MouseEventHandler(FileSystemTreeView_MouseDown);

        }
        #endregion

        #region Eventos
        void FileSystemTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = this.GetNodeAt(e.X, e.Y);

            if (node == null)
                return;

            this.SelectedNode = node; //Seleciona o Node 
        }
        #endregion

        #region Load
        public void Load(string directoryPath)
        {
            if (Directory.Exists(directoryPath) == false)
                throw new DirectoryNotFoundException("Directory Not Found");

            DirectoryNode node = new DirectoryNode(this, null, new DirectoryInfo(directoryPath), this.ImageList.Images.IndexOfKey("folder.ico"));


            this.Load(node);
        }

        public void Load(DirectoryNode directoryNode)
        {

            this.Nodes.Clear();
            this.Nodes.Add(directoryNode);
            directoryNode.Expand();
        }
        #endregion


        #region CopyTree
        public List<FileReference> GetCopy(string directoryPath1, string directoryPath2, int typeValue)
        {
            List<FileReference> listFiles = new List<FileReference>();
            listFiles = CopyTree(this.Nodes[0], listFiles, typeValue);

            return listFiles;
        }

        public List<FileReference> CopyTree(TreeNode nodeMain, List<FileReference> listFiles, int typeValue)
        {

            foreach (TreeNode node in nodeMain.Nodes)
            {
                listFiles = CopyTree(node, listFiles, typeValue);

                //Só relacionar Nodes Extemos
                if (node.Nodes.Count == 0)
                {
                    //Só obter tipos solicitados
                    int nodeTypeValue = (int)node.Tag;


                    //Desconsiderando atributo File
                    if ((nodeTypeValue & (int)FileNodeType.File) > 0)
                    {
                        nodeTypeValue = nodeTypeValue - (int)FileNodeType.File;
                    }

                    //Desconsiderando atributo Folder
                    if ((nodeTypeValue & (int)FileNodeType.Folder) > 0)
                    {
                        nodeTypeValue = nodeTypeValue - (int)FileNodeType.Folder;
                    }

                    //Opção 'Todos'
                    if (((nodeTypeValue & typeValue) > 0) || ((typeValue & (int)FileNodeType.Equal) > 0))
                    {
                        string nodeFile = node.FullPath.Substring(node.FullPath.IndexOf("\\") + 1, node.FullPath.Length - node.FullPath.IndexOf("\\") - 1);
                        listFiles.Add(new FileReference((int)node.Tag, nodeFile));
                    }


                }

            }

            return listFiles;
        }
        #endregion



        #region Validate
        public void ValidateDir(string directoryPath)
        {
            if (Directory.Exists(directoryPath) == false)
                throw new DirectoryNotFoundException("Diretório não encontrado");

        }

        public void ValidateDir(string directoryPath1, string directoryPath2)
        {
            if (Directory.Exists(directoryPath1) == false)
                throw new DirectoryNotFoundException("Diretório 'A' não encontrado");
            if (Directory.Exists(directoryPath2) == false)
                throw new DirectoryNotFoundException("Diretório 'B' não encontrado");

        }

        #endregion

        #region Compare Files

        public void Compare(string directoryPath1, string directoryPath2)
        {
            ValidateDir(directoryPath1, directoryPath2);

            //Arvore do Node A
            DirectoryNode node1 = new DirectoryNode(this, new DirectoryInfo(directoryPath1), this.ImageList.Images.IndexOfKey("folder.ico"));

            //Arvore do Node B
            DirectoryNode node2 = new DirectoryNode(this, new DirectoryInfo(directoryPath2), this.ImageList.Images.IndexOfKey("folder.ico"));

            DirectoryNode nodecompare = this.Compare(this, node1, node2);

            this.Nodes.Clear();
            this.Nodes.Add(nodecompare);

            this.SortTree();

            nodecompare.Expand();

        }


        private DirectoryNode Compare(FileSystemTreeView treeview, DirectoryNode node1, DirectoryNode node2)
        {

            DirectoryNode node = new DirectoryNode(treeview, "Compare", this.ImageList.Images.IndexOfKey("star.ico"));


            return GetCompareNodes(treeview, node, node1, node2);
        }

        private DirectoryNode GetCompareNodes(FileSystemTreeView treeview, DirectoryNode CurrentNode, DirectoryNode node1, DirectoryNode node2)
        {
            List<string> listDir = new List<string>();
            foreach (TreeNode treeNode in node1.Nodes)
            {

                TreeNode newNode;
                listDir.Add(treeNode.Text);

                if (treeNode.GetType() == typeof(DirectoryNode))
                {
                    newNode = treeNode;

                    if (CurrentNode.Nodes.Find(((DirectoryNode)newNode).DirectoryInfo.Name, false).Length == 0)
                    {
                        this.SetDefaultIcon(newNode);

                        //if (Util.FilterNodes(newNode))
                        //{
                        CurrentNode.Nodes.Add(newNode);
                        //}

                    }
                }
                else if (treeNode.GetType() == typeof(FileNode))
                {
                    newNode = treeNode;
                    if (CurrentNode.Nodes.Find(((FileNode)newNode).FileInfo.Name, false).Length == 0)
                    {
                        this.SetDefaultIcon(newNode);

                        //if (Util.FilterNodes(newNode))
                        //{
                        CurrentNode.Nodes.Add(newNode);
                        //}
                    }
                }
            }


            foreach (TreeNode treeNode in node2.Nodes)
            {
                TreeNode newNode;

                if (treeNode.GetType() == typeof(DirectoryNode))
                {

                    if (CurrentNode.Nodes.Find(((DirectoryNode)treeNode).DirectoryInfo.Name, false).Length == 0)
                    {
                        //if (Util.FilterNodes(treeNode))
                        //{
                        CurrentNode.Nodes.Add(treeNode);
                        //}

                        this.SetRightOnly(treeNode);
                    }
                    else
                    {
                        listDir.Remove(treeNode.Text);

                        TreeNode thisNode = CurrentNode.Nodes.Find(((DirectoryNode)treeNode).DirectoryInfo.Name, false).ToList()[0];

                        this.SetDefaultIcon(thisNode);

                        this.GetCompareNodes(treeview, (DirectoryNode)thisNode, (DirectoryNode)node1.Nodes.Find(((DirectoryNode)treeNode).DirectoryInfo.Name, false).ToList()[0], (DirectoryNode)node2.Nodes.Find(((DirectoryNode)treeNode).DirectoryInfo.Name, false).ToList()[0]);


                    }

                }
                else if (treeNode.GetType() == typeof(FileNode))
                {

                    if (CurrentNode.Nodes.Find(((FileNode)treeNode).FileInfo.Name, false).Length == 0)
                    {
                        newNode = new FileNode(((FileNode)treeNode).FileInfo);

                        //if (Util.FilterNodes(newNode))
                        //{
                        CurrentNode.Nodes.Add(newNode);
                        //}

                        this.SetDefaultIcon(newNode);
                        this.SetRightOnly(newNode);

                    }
                    else
                    {
                        FileNode file1 = (FileNode)node1.Nodes.Find(((FileNode)treeNode).FileInfo.Name, false).ToList()[0];
                        FileNode file2 = (FileNode)node2.Nodes.Find(((FileNode)treeNode).FileInfo.Name, false).ToList()[0];

                        if (!Util.FileCompare(file1.FileInfo.FullName, file2.FileInfo.FullName))
                        {
                            listDir.Remove(treeNode.Text);

                            this.SetDifferentIcon(CurrentNode.Nodes.Find(((FileNode)treeNode).FileInfo.Name, false).ToList()[0]);
                        }
                        else
                        {
                            listDir.Remove(treeNode.Text);

                            this.SetDefaultIcon(CurrentNode.Nodes.Find(((FileNode)treeNode).FileInfo.Name, false).ToList()[0]);
                        }
                    }
                }
            }


            foreach (string item in listDir)
            {
                TreeNode node = node1.Nodes.Find(item, false).ToList()[0];
                SetLeftOnly(node);
            }

            return CurrentNode;


        }
        #endregion

        #region List Files


        public void ListFiles(string directoryPath)
        {
            ValidateDir(directoryPath);

            List<KeyValuePair<string, string>> listClearCase = Util.ClearCaseFiles(directoryPath);

            DirectoryNode node = new DirectoryNode(this, new DirectoryInfo(directoryPath), this.ImageList.Images.IndexOfKey("folder.ico"));

            DirectoryNode nodeFiles = this.ListFiles(this, node, listClearCase);

            this.Nodes.Clear();
            this.Nodes.Add(nodeFiles);

            this.SortTree();

            nodeFiles.Expand();

        }

        private DirectoryNode ListFiles(FileSystemTreeView treeview, DirectoryNode node, List<KeyValuePair<string, string>> listClearCase)
        {

            DirectoryNode nodeNew = new DirectoryNode(treeview, "Search", this.ImageList.Images.IndexOfKey("star.ico"));


            return GetListNodes(treeview, nodeNew, node, listClearCase);
        }

        private DirectoryNode GetListNodes(FileSystemTreeView treeview, DirectoryNode CurrentNode, DirectoryNode nodeMain, List<KeyValuePair<string, string>> listClearCase)
        {

            List<string> listDir = new List<string>();





            foreach (TreeNode treeNode in nodeMain.Nodes)
            {

                TreeNode newNode;
                listDir.Add(treeNode.Text);

                if (treeNode.GetType() == typeof(DirectoryNode))
                {
                    //newNode = new DirectoryNode(treeview, ((DirectoryNode)treeNode).DirectoryInfo, this.ImageList.Images.IndexOfKey("folderleft.ico"), false);
                    newNode = treeNode;

                    if (CurrentNode.Nodes.Find(((DirectoryNode)newNode).DirectoryInfo.Name, false).Length == 0)
                    {
                        //this.DefineNode(newNode, listClearCase);
                        this.SetNodeClearType(newNode, listClearCase);

                        //if (!Util.IsInList(((DirectoryNode)newNode).DirectoryInfo.Name, Util.Config.IgnorePaths))
                        //{
                            CurrentNode.Nodes.Add(newNode);
                        //}
                    }


                }
                else if (treeNode.GetType() == typeof(FileNode))
                {
                    newNode = treeNode;
                    if (CurrentNode.Nodes.Find(((FileNode)newNode).FileInfo.Name, false).Length == 0)
                    {
                        //this.DefineNode(newNode, listClearCase);
                        this.SetNodeClearType(newNode, listClearCase);

                        CurrentNode.Nodes.Add(newNode);


                    }
                }


            }



            //foreach (string item in listDir)
            //{
            //    TreeNode node = nodeMain.Nodes.Find(item, false).ToList()[0];
            //    SetLeftOnly(node);
            //}

            return CurrentNode;


        }
        #endregion

        #region Sort
        public void SortTree()
        {

            FileSystemTreeView treeNew = new FileSystemTreeView(this.ImageList);

            treeNew.Nodes.Add(SortTree(this.Nodes[0], treeNew));


            treeNew.Nodes[0].Text = this.Nodes[0].Text;

            this.Nodes.Clear();
            TreeNode tn = (TreeNode)treeNew.Nodes[0].Clone();
            tn.Expand();
            this.Nodes.Add(tn);

        }

        private TreeNode SortTree(TreeNode treenode, FileSystemTreeView TreeViewSorter)
        {

            TreeNode newNode = new TreeNode();
            newNode.Text = treenode.Text;
            newNode.ImageIndex = treenode.ImageIndex;
            newNode.Tag = treenode.Tag;
            newNode.SelectedImageIndex = newNode.ImageIndex;

            ArrayList list = new ArrayList(treenode.Nodes.Count);
            foreach (TreeNode childNode in treenode.Nodes)
            {
                string nodeID = "";
                if (childNode.GetType() == typeof(DirectoryNode))
                {
                    nodeID = "[@]" + childNode.Text;
                }
                else
                {
                    nodeID = "[F]" + childNode.Text;
                }
                list.Add(nodeID);
            }
            list.Sort();


            foreach (string idNode in list)
            {
                TreeNode treeNodeNew = (TreeNode)treenode.Nodes.Find(idNode.Replace("[@]", "").Replace("[F]", ""), false).ToList()[0];

                treeNodeNew = SortTree(treeNodeNew, TreeViewSorter);

                //Adicionando Identicos 
                if ((((int)FileNodeType.File == (int)treeNodeNew.Tag) || ((int)FileNodeType.Folder == (int)treeNodeNew.Tag)) && (Util.IsInList(((int)FileNodeType.Equal).ToString(), this.Config.NodeTypes)))
                {
                    newNode.Nodes.Add(treeNodeNew);
                }
                //Adicionando ClearCase- Versionados
                if ((((int)FileNodeType.File == (int)treeNodeNew.Tag) || ((int)FileNodeType.Folder == (int)treeNodeNew.Tag)) && (Util.IsInList(((int)FileNodeType.Version).ToString(), this.Config.NodeTypes)))
                {
                    newNode.Nodes.Add(treeNodeNew);
                }
                else if (((int)FileNodeType.File != (int)treeNodeNew.Tag) && ((int)FileNodeType.Folder != (int)treeNodeNew.Tag))
                {

                    if ((((int)treeNodeNew.Tag & (int)FileNodeType.Different) > 0) && (((int)treeNodeNew.Tag & (int)FileNodeType.File) > 0))
                    {
                        if (Util.IsInList(((int)FileNodeType.Different).ToString(), this.Config.NodeTypes))
                        {
                            newNode.Nodes.Add(treeNodeNew);
                            this.SetParentAlert(treeNodeNew);
                        }
                    }
                    else if ((((int)treeNodeNew.Tag & (int)FileNodeType.Different) > 0) && (((int)treeNodeNew.Tag & (int)FileNodeType.Folder) > 0))
                    {
                        newNode.Nodes.Add(treeNodeNew);
                        this.SetParentAlert(treeNodeNew);
                    }
                    else if (((int)treeNodeNew.Tag & (int)FileNodeType.LeftOnly) > 0)
                    {
                        if (Util.IsInList(((int)FileNodeType.LeftOnly).ToString(), this.Config.NodeTypes))
                        {
                            newNode.Nodes.Add(treeNodeNew);
                            this.SetParentAlert(treeNodeNew);
                        }
                    }
                    else if (((int)treeNodeNew.Tag & (int)FileNodeType.RightOnly) > 0)
                    {
                        if (Util.IsInList(((int)FileNodeType.RightOnly).ToString(), this.Config.NodeTypes))
                        {
                            newNode.Nodes.Add(treeNodeNew);
                            this.SetParentAlert(treeNodeNew);
                        }
                    }
                    else if (((int)treeNodeNew.Tag & (int)FileNodeType.Checkout) > 0)
                    {
                        if (Util.IsInList(((int)FileNodeType.Checkout).ToString(), this.Config.NodeTypes))
                        {
                            newNode.Nodes.Add(treeNodeNew);
                            this.SetParentAlert(treeNodeNew);
                        }
                    }
                    else if (((int)treeNodeNew.Tag & (int)FileNodeType.Hijacked) > 0)
                    {
                        if (Util.IsInList(((int)FileNodeType.Hijacked).ToString(), this.Config.NodeTypes))
                        {
                            newNode.Nodes.Add(treeNodeNew);
                            this.SetParentAlert(treeNodeNew);
                        }
                    }
                    else if (((int)treeNodeNew.Tag & (int)FileNodeType.ViewPrivate) > 0)
                    {
                        if (Util.IsInList(((int)FileNodeType.ViewPrivate).ToString(), this.Config.NodeTypes))
                        {
                            newNode.Nodes.Add(treeNodeNew);
                            this.SetParentAlert(treeNodeNew);
                        }
                    }
                }

            }



            return newNode;
        }
        #endregion


        #region Set Icons

        private void SetDefaultIcon(TreeNode node)
        {
            if (node.GetType() == typeof(DirectoryNode))
            {
                if (node.ImageIndex != this.ImageList.Images.IndexOfKey("folderdenied.ico"))
                {
                    node.ImageIndex = this.ImageList.Images.IndexOfKey("folder.ico");
                }
                node.Tag = FileNodeType.Folder;
            }
            else if (node.GetType() == typeof(FileNode))
            {
                node.ImageIndex = this.ImageList.Images.IndexOfKey("file.ico");
                node.Tag = FileNodeType.File;
            }

            node.SelectedImageIndex = node.ImageIndex;
        }

        private void SetDifferentIcon(TreeNode node)
        {
            if (node.GetType() == typeof(FileNode))
            {
                node.ImageIndex = this.ImageList.Images.IndexOfKey("fileerror.ico");
                node.Tag = (int)FileNodeType.File + (int)FileNodeType.Different;
            }

            node.SelectedImageIndex = node.ImageIndex;
        }

        private void SetLeftOnly(TreeNode node)
        {

            if (node.GetType() == typeof(DirectoryNode))
            {
                node.ImageIndex = this.ImageList.Images.IndexOfKey("folderleft.ico");
                node.Tag = (int)FileNodeType.Folder + (int)FileNodeType.LeftOnly;

            }
            else if (node.GetType() == typeof(FileNode))
            {
                node.ImageIndex = this.ImageList.Images.IndexOfKey("fileleft.ico");
                node.Tag = (int)FileNodeType.File + (int)FileNodeType.LeftOnly;

            }

            node.SelectedImageIndex = node.ImageIndex;

            foreach (TreeNode treeNode in node.Nodes)
            {
                if (treeNode.GetType() == typeof(DirectoryNode))
                {
                    SetLeftOnly(treeNode);
                    treeNode.ImageIndex = this.ImageList.Images.IndexOfKey("folderleft.ico");
                    treeNode.Tag = (int)FileNodeType.Folder + (int)FileNodeType.LeftOnly;
                }
                else if (treeNode.GetType() == typeof(FileNode))
                {
                    treeNode.ImageIndex = this.ImageList.Images.IndexOfKey("fileleft.ico");
                    treeNode.Tag = (int)FileNodeType.File + (int)FileNodeType.LeftOnly;

                }
                treeNode.SelectedImageIndex = treeNode.ImageIndex;
            }


        }

        private void SetRightOnly(TreeNode node)
        {
            if (node.GetType() == typeof(DirectoryNode))
            {
                node.ImageIndex = this.ImageList.Images.IndexOfKey("folderright.ico");
                node.Tag = (int)FileNodeType.Folder + (int)FileNodeType.RightOnly;
            }
            else if (node.GetType() == typeof(FileNode))
            {
                node.ImageIndex = this.ImageList.Images.IndexOfKey("fileright.ico");
                node.Tag = (int)FileNodeType.File + (int)FileNodeType.RightOnly;
            }

            node.SelectedImageIndex = node.ImageIndex;

            foreach (TreeNode treeNode in node.Nodes)
            {
                if (treeNode.GetType() == typeof(DirectoryNode))
                {
                    SetRightOnly(treeNode);
                    treeNode.ImageIndex = this.ImageList.Images.IndexOfKey("folderright.ico");
                    treeNode.Tag = (int)FileNodeType.Folder + (int)FileNodeType.RightOnly;
                }
                else if (treeNode.GetType() == typeof(FileNode))
                {
                    treeNode.ImageIndex = this.ImageList.Images.IndexOfKey("fileright.ico");
                    treeNode.Tag = (int)FileNodeType.File + (int)FileNodeType.RightOnly;
                }
                treeNode.SelectedImageIndex = treeNode.ImageIndex;
            }


        }


        private void SetParentAlert(TreeNode node)
        {
            if (node.Parent != null)
            {

                if (node.Parent.ImageIndex == this.ImageList.Images.IndexOfKey("folder.ico"))
                {
                    node.Parent.ImageIndex = this.ImageList.Images.IndexOfKey("folderdiff.ico");
                    node.Parent.Tag = (int)FileNodeType.Folder + (int)FileNodeType.Different;
                    node.Parent.SelectedImageIndex = node.Parent.ImageIndex;
                }

                this.SetParentAlert(node.Parent);
            }
        }
        private void SetNodeClearType(TreeNode node, List<KeyValuePair<string, string>> listClearCase)
        {

            foreach (KeyValuePair<string, string> item in listClearCase)
            {
                if (item.Key == this.GetNodePath(node).Trim().ToLower())
                {

                    if (node.GetType() == typeof(DirectoryNode))
                    {

                        if (item.Value == "P")
                        {
                            node.ImageIndex = this.ImageList.Images.IndexOfKey("folderstar.ico");
                            node.Tag = (int)FileNodeType.Folder + (int)FileNodeType.ViewPrivate;
                        }
                        else if (item.Value == "C")
                        {
                            node.ImageIndex = this.ImageList.Images.IndexOfKey("foldercheckout.ico");
                            node.Tag = (int)FileNodeType.Folder + (int)FileNodeType.Checkout;
                        }
                    }
                    else if (node.GetType() == typeof(FileNode))
                    {

                        if (item.Value == "P")
                        {
                            node.ImageIndex = this.ImageList.Images.IndexOfKey("filestar.ico");
                            node.Tag = (int)FileNodeType.File + (int)FileNodeType.ViewPrivate;
                        }
                        else if (item.Value == "C")
                        {
                            node.ImageIndex = this.ImageList.Images.IndexOfKey("filecheckout.ico");
                            node.Tag = (int)FileNodeType.File + (int)FileNodeType.Checkout;
                        }
                        else if (item.Value == "H")
                        {
                            node.ImageIndex = this.ImageList.Images.IndexOfKey("filehijacked.ico");
                            node.Tag = (int)FileNodeType.File + (int)FileNodeType.Hijacked;
                        }
                    }

                    break;
                }
            }

            node.SelectedImageIndex = node.ImageIndex;

            foreach (TreeNode treeNode in node.Nodes)
            {
                SetNodeClearType(treeNode, listClearCase);
            }


        }


        #endregion

        #region Tools

        private string GetNodePath(TreeNode node)
        {
            string strpath = node.Text;

            if (node.Parent.Parent != null)
            {
                strpath = GetNodePath(node.Parent) + "\\" + strpath;
            }

            return strpath;
        }

        #endregion

    }
}

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
    public class DirectoryNode : TreeNode
    {
        private DirectoryInfo _directoryInfo;
        private FileSystemTreeView _treeViewDir;
        


        public DirectoryNode()
        {
        }

        public DirectoryNode(FileSystemTreeView treeView,  DirectoryNode parent, DirectoryInfo directoryInfo, int imgIndex, bool recursivo)
            : base(directoryInfo.Name)
        {
            this.Name = this.Text;
            this._directoryInfo = directoryInfo;
            this.ImageIndex = imgIndex;
            this.Tag = FileNodeType.Folder;
            this.SelectedImageIndex = this.ImageIndex;
            this._treeViewDir = treeView;

            parent.Nodes.Add(this);

            if (recursivo)
                Virtualize(treeView);
        }

        public DirectoryNode(FileSystemTreeView treeView,  DirectoryNode parent, DirectoryInfo directoryInfo, int imgIndex)
            : base(directoryInfo.Name)
        {
            this.Name = this.Text;
            this._directoryInfo = directoryInfo;
            this.ImageIndex = imgIndex;
            this.Tag = FileNodeType.Folder;
            this.SelectedImageIndex = this.ImageIndex;
            this._treeViewDir = treeView;


            parent.Nodes.Add(this);

            Virtualize(treeView);
        }

        public DirectoryNode(FileSystemTreeView treeView, string name, int imgIndex)
            : base(name)
        {
            this.Name = this.Text;
            this.ImageIndex = imgIndex;
            this.Tag = FileNodeType.Folder;
            this.SelectedImageIndex = this.ImageIndex;
            this._treeViewDir = treeView;
        }

        public DirectoryNode(FileSystemTreeView treeView,  DirectoryInfo directoryInfo, int imgIndex, bool recursivo)
            : base(directoryInfo.Name)
        {
            this.Name = this.Text;
            this._directoryInfo = directoryInfo;
            this.ImageIndex = imgIndex;
            this.Tag = FileNodeType.Folder;
            this.SelectedImageIndex = this.ImageIndex;
            this._treeViewDir = treeView;

            if (recursivo)
                Virtualize(treeView);

        }
        public DirectoryNode(FileSystemTreeView treeView, DirectoryInfo directoryInfo, int imgIndex)
            : base(directoryInfo.Name)
        {
            this.Name = this.Text;
            this._directoryInfo = directoryInfo;
            this.ImageIndex = imgIndex;
            this.Tag = FileNodeType.Folder;
            this.SelectedImageIndex = this.ImageIndex;
            this._treeViewDir = treeView;

            Virtualize(treeView);

        }

        void Virtualize(FileSystemTreeView treeView)
        {
            int fileCount = 0;
            DirectoryNode node = (DirectoryNode)this;
            Exception exception = null;

            try
            {


                fileCount = this._directoryInfo.GetFiles().Length;

                if ((fileCount + this._directoryInfo.GetDirectories().Length) > 0)
                {
                    node.LoadDirectory(treeView.ImageList);
                    node.LoadFiles();
                }
            }
            catch (System.Security.SecurityException)
            {
                this.ImageIndex = treeView.ImageList.Images.IndexOfKey("folderdenied.ico");
                this.Tag = FileNodeType.Folder;
                this.SelectedImageIndex = this.ImageIndex;
            }
            catch (System.UnauthorizedAccessException)
            {
                this.ImageIndex = treeView.ImageList.Images.IndexOfKey("folderdenied.ico");
                this.Tag = FileNodeType.Folder;
                this.SelectedImageIndex = this.ImageIndex;
            }
            catch (Exception ex)
            {

                exception = new Exception(string.Format("{0} \n Path:{1}", ex.Message, node.Text));
            }


            if (exception != null)
                throw exception;
        }



        public void LoadDirectory(ImageList imgList)
        {
            foreach (DirectoryInfo directoryInfo in _directoryInfo.GetDirectories())
            {
                bool isBin = false;

                if (directoryInfo.Name == "bin")
                {
                    if (directoryInfo.Parent != null)
                    {

                        if ((directoryInfo.Parent.Name.ToLower().LastIndexOf("fluir") == 2) && (directoryInfo.Parent.Name.Length == 7))
                        {
                            isBin = true;
                            new DirectoryNode((FileSystemTreeView)_treeViewDir, this, directoryInfo, imgList.Images.IndexOfKey("folder.ico"));
                        }
                    }

                }

                if(!isBin)
                {
                    if (Util.FilterNodes(directoryInfo.Name, (int)FileNodeType.Folder, _treeViewDir.Config))
                        new DirectoryNode((FileSystemTreeView)_treeViewDir, this, directoryInfo, imgList.Images.IndexOfKey("folder.ico"));
                }
            }
        }

        public void LoadFiles()
        {
            foreach (FileInfo file in _directoryInfo.GetFiles())
            {
                if (Util.FilterNodes(file.Name, (int)FileNodeType.File, _treeViewDir.Config))
                    new FileNode(this, file, 0);
            }
        }


        public new FileSystemTreeView TreeView
        {
            get { return (FileSystemTreeView)base.TreeView; }
        }

        public DirectoryInfo DirectoryInfo
        {
            get { return this._directoryInfo; }
        }
    }

    public class FileNode : TreeNode
    {
        private FileInfo _fileInfo;
        private DirectoryNode _directoryNode;

        public FileNode(DirectoryNode directoryNode, FileInfo fileInfo, int imgIndex)
            : base(fileInfo.Name)
        {
            this.Name = this.Text;
            this._directoryNode = directoryNode;
            this._fileInfo = fileInfo;
            this.Tag = FileNodeType.File;

            this.ImageIndex = imgIndex;
            this.SelectedImageIndex = this.ImageIndex;

            _directoryNode.Nodes.Add(this);
        }

        public FileNode(FileInfo fileInfo)
            : base(fileInfo.Name)
        {
            this.Name = this.Text;
            this._fileInfo = fileInfo;
            this.Tag = FileNodeType.File;

        }

        public FileInfo FileInfo
        {
            get { return this._fileInfo; }
        }
    }

    public class FileReference
    {
        public int NodeType { get; set; }
        public string Path { get; set; }

        public FileReference()
        {
        }

        public FileReference(int nodeType, string path)
        {
            this.NodeType = nodeType;
            this.Path = path;
        }
    }
}

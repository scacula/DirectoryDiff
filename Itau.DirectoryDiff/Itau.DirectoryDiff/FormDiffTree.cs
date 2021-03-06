﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Itau.DirectoryDiff
{
    public partial class FormDiffTree : Form
    {

        string pathDefaultA = "";
        string pathDefaultB = "";

        public FormDiffTree()
        {
            InitializeComponent();
        }

        public FormDiffTree(string fileA, string fileB)
        {

            if(System.IO.Directory.Exists(fileA))
                pathDefaultA = fileA;
            if(System.IO.Directory.Exists(fileB))
                pathDefaultB = fileB;

            InitializeComponent();
        }

        private void FormDiffTree_Load(object sender, EventArgs e)
        {
            this.SetStatusItemIcons();

            this.treeViewDiff.ImageList = this.imageListIcons;
            this.treeViewDiff.MouseUp += new MouseEventHandler(treeViewDiff_MouseUp);

            this.toolbtnCopy.Enabled = false;

            if (Util.Config == null)
            {
                ConfigDiff configDiff = new ConfigDiff();
                configDiff.Load();
                Util.Config = configDiff;


                treeViewDiff.Config = Util.Config;

                if (string.IsNullOrEmpty(pathDefaultA))
                    this.txtDirectoryA.Text = Util.Config.LastDirA;
                else
                    this.txtDirectoryA.Text = pathDefaultA;


                if (string.IsNullOrEmpty(pathDefaultB))
                    this.txtDirectoryB.Text = Util.Config.LastDirB;
                else
                    this.txtDirectoryB.Text = pathDefaultB;
            }

            this.toolStripVersao.Text = "Versão:" + Application.ProductVersion.ToString();

        }

        private TreeNode m_OldSelectNode;

        private void treeViewDiff_MouseUp(object sender, MouseEventArgs e)
        {
            // Show menu only if the right mouse button is clicked.
            if (e.Button == MouseButtons.Right)
            {

                // Point where the mouse is clicked.
                Point p = new Point(e.X, e.Y);

                // Get the node that the user has clicked.
                TreeNode node = treeViewDiff.GetNodeAt(p);
                if (node != null)
                {

                    // Select the node the user has clicked.
                    // The node appears selected until the menu is displayed on the screen.
                    m_OldSelectNode = treeViewDiff.SelectedNode;
                    treeViewDiff.SelectedNode = node;


                    if (node.Parent == null)
                        return;

                    mnuTreeView.Show(treeViewDiff, p);


                    // Highlight the selected node.
                    treeViewDiff.SelectedNode = m_OldSelectNode;
                    m_OldSelectNode = null;
                }
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (CompararDiretorios())
            {
                //this.btnCompare.Enabled = false;
                this.txtDirectoryA.Enabled = false;
                this.txtDirectoryB.Enabled = false;

                this.btnDirectoryA.Enabled = false;
                this.btnDirectoryB.Enabled = false;

                this.toolbtnCopy.Enabled = true;
                this.picInvert.Enabled = false;

            }
            else
            {
                toolbtnNovo_Click(sender, e);
            }
        }

        private bool CompararDiretorios()
        {

            try
            {

                Cursor.Current = Cursors.WaitCursor;
                this.SetStatusItemIcons();

                treeViewDiff.Compare(txtDirectoryA.Text, txtDirectoryB.Text, Util.Config.PublishFolders, (Util.Config.NotContent == "S"));

                BuildStatus();

                Util.Config.LastDirA = this.txtDirectoryA.Text;
                Util.Config.LastDirB = this.txtDirectoryB.Text;

                Util.Config.SaveLastDiff();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Cursor.Current = Cursors.Default;
            return true;
        }

        private void btnDirectoryA_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = txtDirectoryA.Text;
            dlg.ShowNewFolderButton = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtDirectoryA.Text = dlg.SelectedPath;
            }
        }

        private void btnDirectoryB_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = txtDirectoryB.Text;
            dlg.ShowNewFolderButton = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtDirectoryB.Text = dlg.SelectedPath;
            }
        }

        private void toolbtnNovo_Click(object sender, EventArgs e)
        {
            this.toolbtnCopy.Enabled = false;

            //this.txtDirectoryA.Text = "";
            //this.txtDirectoryB.Text = "";
            this.txtDirectoryA.Enabled = true;
            this.txtDirectoryB.Enabled = true;

            this.btnDirectoryA.Enabled = true;
            this.btnDirectoryB.Enabled = true;

            this.picInvert.Enabled = true;

            //this.btnCompare.Enabled = true;
            this.treeViewDiff.Nodes.Clear();


            this.SetStatusItemIcons();
        }

        private void mnuCopyPathA_Click(object sender, EventArgs e)
        {
            CopyPathNode(txtDirectoryA.Text);
        }

        private void mnuCopyPathB_Click(object sender, EventArgs e)
        {
            CopyPathNode(txtDirectoryB.Text);
        }

        private void mnuOpenA_Click(object sender, EventArgs e)
        {
            OpenNode(txtDirectoryA.Text);
        }

        private void mnuOpenB_Click(object sender, EventArgs e)
        {
            OpenNode(txtDirectoryB.Text);
        }

        private void HistoryNode(string directory)
        {

            directory = directory.Trim();

            string nodeFile = this.treeViewDiff.SelectedNode.FullPath.Substring(this.treeViewDiff.SelectedNode.FullPath.IndexOf("\\") + 1, this.treeViewDiff.SelectedNode.FullPath.Length - this.treeViewDiff.SelectedNode.FullPath.IndexOf("\\") - 1);
            string pathFile = System.IO.Path.Combine(directory, nodeFile);

            if (((int)this.treeViewDiff.SelectedNode.Tag & (int)Itau.TreeFileViewer.FileNodeType.File) > 0)
            {
                if (System.IO.File.Exists(pathFile))
                {

                    try
                    {
                        Itau.TreeFileViewer.Util.ClearCaseHistory(pathFile);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Erro ao Exibir Histórico. Arquivo Inexistente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (((int)this.treeViewDiff.SelectedNode.Tag & (int)Itau.TreeFileViewer.FileNodeType.Folder) > 0)
            {
                if (System.IO.Directory.Exists(pathFile))
                {
                    try
                    {
                        Itau.TreeFileViewer.Util.ClearCaseHistory(pathFile);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }  
                }
                else
                {
                    MessageBox.Show("Erro ao Exibir Histórico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 



        }

        private void CopyPathNode(string directory)
        {

            directory = directory.Trim();

            string nodeFile = this.treeViewDiff.SelectedNode.FullPath.Substring(this.treeViewDiff.SelectedNode.FullPath.IndexOf("\\") + 1, this.treeViewDiff.SelectedNode.FullPath.Length - this.treeViewDiff.SelectedNode.FullPath.IndexOf("\\") - 1);
            string pathFile = System.IO.Path.Combine(directory, nodeFile);

            Clipboard.SetText(pathFile);
        }

        private void OpenNode(string directory)
        {

            directory = directory.Trim();

            string nodeFile = this.treeViewDiff.SelectedNode.FullPath.Substring(this.treeViewDiff.SelectedNode.FullPath.IndexOf("\\") + 1, this.treeViewDiff.SelectedNode.FullPath.Length - this.treeViewDiff.SelectedNode.FullPath.IndexOf("\\") - 1);
            string pathFile = System.IO.Path.Combine(directory, nodeFile);

            if (((int)this.treeViewDiff.SelectedNode.Tag & (int)Itau.TreeFileViewer.FileNodeType.File) > 0)
            {
                if (System.IO.File.Exists(pathFile))
                {                    
                    if (System.IO.Path.GetExtension(pathFile).ToLower().Contains("doc")||
                        System.IO.Path.GetExtension(pathFile).ToLower().Contains("xls")||
                        System.IO.Path.GetExtension(pathFile).ToLower().Contains("pdf")||
                        System.IO.Path.GetExtension(pathFile).ToLower().Contains("vsd")||
                        System.IO.Path.GetExtension(pathFile).ToLower().Contains("ppt"))
                    {
                        //OpenMicrosoftWord(pathFile);
                        Process.Start(pathFile);
                    }
                    else
                    {
                        Process.Start("notepad", pathFile);
                    }
                }
                else
                {
                    MessageBox.Show("Arquivo não existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (((int)this.treeViewDiff.SelectedNode.Tag & (int)Itau.TreeFileViewer.FileNodeType.Folder) > 0)
            {
                if (System.IO.Directory.Exists(pathFile))
                {
                    Process.Start(pathFile);
                }
                else
                {
                    MessageBox.Show("Diretório não existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            

        }

        /// <summary>
        /// Open specified word document.
        /// </summary>
        static void OpenMicrosoftWord(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "WINWORD.EXE";
            startInfo.Arguments = f;
            Process.Start(startInfo);
        }


        private bool DeleteNode(string directory)
        {

            directory = directory.Trim();

            string nodeFile = this.treeViewDiff.SelectedNode.FullPath.Substring(this.treeViewDiff.SelectedNode.FullPath.IndexOf("\\") + 1, this.treeViewDiff.SelectedNode.FullPath.Length - this.treeViewDiff.SelectedNode.FullPath.IndexOf("\\") - 1);
            string pathFile = System.IO.Path.Combine(directory, nodeFile);            

            if (((int)this.treeViewDiff.SelectedNode.Tag & (int)Itau.TreeFileViewer.FileNodeType.File) > 0)
            {
                if (System.IO.File.Exists(pathFile))
                {
                    if (MessageBox.Show("Deseja Excluir o Arquivo?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {

                        try
                        {
                            //removendo atributo somente leitura
                            System.IO.File.SetAttributes(pathFile, System.IO.File.GetAttributes(pathFile) & ~System.IO.FileAttributes.ReadOnly);

                            System.IO.File.Delete(pathFile);
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }
                    else
                    {
                        return false;
                    }

                    
                }
                else
                {
                    MessageBox.Show("Arquivo não existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            else if (((int)this.treeViewDiff.SelectedNode.Tag & (int)Itau.TreeFileViewer.FileNodeType.Folder) > 0)
            {
                if (System.IO.Directory.Exists(pathFile))
                {

                    if (MessageBox.Show("Deseja Excluir o Diretório?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {

                        try
                        {
                            System.IO.Directory.Delete(pathFile, true);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Diretório não existe!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;

        }

        private void toolbtnCopy_Click(object sender, EventArgs e)
        {
            FormSelectType formSelectType = new FormSelectType();
            formSelectType.ShowDialog();
            int valueType = formSelectType.OptionValue;
            formSelectType.Close();

            if (valueType > 0)
            {

                List<Itau.TreeFileViewer.FileReference> listFiles = treeViewDiff.GetCopy(this.txtDirectoryA.Text, this.txtDirectoryB.Text, valueType);

                if (listFiles.Count == 0)
                {
                    MessageBox.Show("Nenhum arquivo para o filtro selecionado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                FormFileCopy formFileCopy = new FormFileCopy();
                formFileCopy.ListFiles = listFiles;
                formFileCopy.ImageList = this.imageListIcons;
                formFileCopy.PathA = this.txtDirectoryA.Text;
                formFileCopy.PathB = this.txtDirectoryB.Text;
                formFileCopy.ShowDialog();

                if (MessageBox.Show("Deseja atualizar a consulta?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.CompararDiretorios();
                }
            }
        }

        private void toolbtnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Sair da Aplicação?",Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void mnuDiferencas_Click(object sender, EventArgs e)
        {
            if (this.treeViewDiff.SelectedNode.Parent != null)
            {

                try
                {
                    string file1 = this.txtDirectoryA.Text + this.treeViewDiff.SelectedNode.FullPath.Substring(this.treeViewDiff.SelectedNode.FullPath.IndexOf("\\", 0), this.treeViewDiff.SelectedNode.FullPath.Length - this.treeViewDiff.SelectedNode.FullPath.IndexOf("\\", 0));
                    string file2 = this.txtDirectoryB.Text + this.treeViewDiff.SelectedNode.FullPath.Substring(this.treeViewDiff.SelectedNode.FullPath.IndexOf("\\", 0), this.treeViewDiff.SelectedNode.FullPath.Length - this.treeViewDiff.SelectedNode.FullPath.IndexOf("\\", 0));

                    if (System.IO.File.Exists(file1) && System.IO.File.Exists(file2))
                    {

                        Util.ToolCompare(file1, file2);
                    }
                    else if (System.IO.Directory.Exists(file1) && System.IO.Directory.Exists(file2))
                    {
                        Util.ToolCompare(file1, file2);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro ao executar aplicativo de comparação de arquivos: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void mnuTreeView_Opening(object sender, CancelEventArgs e)
        {
            mnuDiferencas.Enabled = false;

            mnuExcluir.Enabled = true;
            mnuExcluirA.Enabled = mnuExcluir.Enabled;
            mnuExcluirB.Enabled = mnuExcluir.Enabled;

            mnuHistorico.Enabled = true;
            mnuHistoricoA.Enabled = mnuHistorico.Enabled;
            mnuHistoricoB.Enabled = mnuHistorico.Enabled;

            mnuOpen.Enabled = true;
            mnuOpenA.Enabled = mnuOpen.Enabled;
            mnuOpenB.Enabled = mnuOpen.Enabled;

            mnuCopyPathA.Enabled = true;
            mnuCopyPathA.Enabled = false;
            mnuCopyPathB.Enabled = false;

            if (((int)this.treeViewDiff.SelectedNode.Tag & (int)Itau.TreeFileViewer.FileNodeType.File) > 0)
            {

            }
            else if (((int)this.treeViewDiff.SelectedNode.Tag & (int)Itau.TreeFileViewer.FileNodeType.Folder) > 0)
            {

            }

            mnuCopyPathA.Enabled = true;
            mnuCopyPathB.Enabled = true;

            mnuOpenA.Enabled = true;
            mnuOpenB.Enabled = true;

            if (((int)this.treeViewDiff.SelectedNode.Tag & (int)Itau.TreeFileViewer.FileNodeType.LeftOnly) > 0)
            {
                mnuCopyPathA.Enabled = true;
                mnuCopyPathB.Enabled = false;

                mnuOpenA.Enabled = true;
                mnuOpenB.Enabled = false;

                mnuExcluirA.Enabled = true;
                mnuExcluirB.Enabled = false;

            }
            else if (((int)this.treeViewDiff.SelectedNode.Tag & (int)Itau.TreeFileViewer.FileNodeType.RightOnly) > 0)
            {
                mnuCopyPathA.Enabled = false;
                mnuCopyPathB.Enabled = true;

                mnuOpenA.Enabled = false;
                mnuOpenB.Enabled = true;

                mnuExcluirA.Enabled = false;
                mnuExcluirB.Enabled = true;
            }

            if (((int)this.treeViewDiff.SelectedNode.Tag & (int)Itau.TreeFileViewer.FileNodeType.Different) > 0)
            {
                mnuDiferencas.Enabled = true;
            }

        }

        private void mnuExcluirA_Click(object sender, EventArgs e)
        {
            if(DeleteNode(txtDirectoryA.Text))
                if (MessageBox.Show("Deseja atualizar a consulta?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.CompararDiretorios();
                }
        }

        private void mnuExcluirB_Click(object sender, EventArgs e)
        {
            if(DeleteNode(txtDirectoryB.Text))
                if (MessageBox.Show("Deseja atualizar a consulta?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.CompararDiretorios();
                }
        }

        private void mnuHistoricoA_Click(object sender, EventArgs e)
        {
            HistoryNode(txtDirectoryA.Text);
        }

        private void mnuHistoricoB_Click(object sender, EventArgs e)
        {
            HistoryNode(txtDirectoryB.Text);
        }

        private void toolbtnFiltro_Click(object sender, EventArgs e)
        {
            FormFiltros formFiltros = new FormFiltros();
            formFiltros.ShowDialog();

            if (formFiltros.Atualizado && this.toolbtnCopy.Enabled)
            {
                if (MessageBox.Show("Deseja atualizar a consulta?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {                    
                    this.CompararDiretorios();
                }
            }


        }

        private void toolbtnPrint_Click(object sender, EventArgs e)
        {
            if (treeViewDiff.Nodes.Count > 0)
            {
                if (MessageBox.Show("Expandir Itens do TreeView?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.treeViewDiff.ExpandAll();
                }
                Itau.TreeFileViewer.PrintHelper print = new Itau.TreeFileViewer.PrintHelper();
                print.PrintPreviewTree(this.treeViewDiff, Application.ProductName);
            }
            else
            {
                MessageBox.Show("Diretório não carregado. Não é possivel realizar a impressão", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        private void BuildStatus()
        {
            foreach(Itau.TreeFileViewer.FileNodeTypeCounter fnode in this.treeViewDiff.FNodeTypeCounter)
            {
                if (fnode.NodeType == Itau.TreeFileViewer.FileNodeType.Different)
                {
                    if (fnode.IsFolder)
                    {
                        //toolStripStatusDifferent.Text = "Divergentes: " + fnode.Count.ToString();
                        //if (fnode.Count > 0)
                        //    toolStripStatusDifferent.ForeColor = Color.Red;
                    }
                    else
                    {
                        toolStripStatusDifferent.Text = "Divergentes: " + fnode.Count.ToString();
                        if (fnode.Count > 0)
                            toolStripStatusDifferent.ForeColor = Color.Red;
                    }
                }
                else if (fnode.NodeType == Itau.TreeFileViewer.FileNodeType.Equal)
                {
                    if (fnode.IsFolder)
                    {
                        //toolStripStatusEqual.Text = "Idênticos: " + fnode.Count.ToString();
                        //if (fnode.Count > 0)
                        //    toolStripStatusEqual.ForeColor = Color.DarkBlue;
                    }
                    else
                    {
                        toolStripStatusEqual.Text = "Idênticos: " + fnode.Count.ToString();
                        if (fnode.Count > 0)
                            toolStripStatusEqual.ForeColor = Color.DarkBlue;
                    }
                }
                else if (fnode.NodeType == Itau.TreeFileViewer.FileNodeType.LeftOnly)
                {
                    if (fnode.IsFolder)
                    {
                        toolStripStatusLeftOnlyFolder.Text = "Somente em A: " + fnode.Count.ToString();
                        if (fnode.Count > 0)
                            toolStripStatusLeftOnlyFolder.ForeColor = Color.Red;
                    }
                    else
                    {
                        toolStripStatusLeftOnly.Text = "Somente em A: " + fnode.Count.ToString();
                        if (fnode.Count > 0)
                            toolStripStatusLeftOnly.ForeColor = Color.Red;
                    }

                }
                else if (fnode.NodeType == Itau.TreeFileViewer.FileNodeType.RightOnly)
                {

                    if (fnode.IsFolder)
                    {
                        toolStripStatusRightOnlyFolder.Text = "Somente em B: " + fnode.Count.ToString();
                        if (fnode.Count > 0)
                            toolStripStatusRightOnlyFolder.ForeColor = Color.Red;
                    }
                    else
                    {
                        toolStripStatusRightOnly.Text = "Somente em B: " + fnode.Count.ToString();
                        if (fnode.Count > 0)
                            toolStripStatusRightOnly.ForeColor = Color.Red;
                    }

                }
            }
        }

        private void SetStatusItemIcons()
        {

            this.toolStripStatusLeftOnlyFolder.Image = this.imageListIcons.Images["folderleft.ico"];
            this.toolStripStatusLeftOnlyFolder.Text = "Somente em A: 0";
            this.toolStripStatusLeftOnlyFolder.ForeColor = Color.Gray;

            this.toolStripStatusRightOnlyFolder.Image = this.imageListIcons.Images["folderright.ico"];
            this.toolStripStatusRightOnlyFolder.Text = "Somente em B: 0";
            this.toolStripStatusRightOnlyFolder.ForeColor = Color.Gray;


            this.toolStripStatusEqual.Image = this.imageListIcons.Images["file.ico"];
            this.toolStripStatusEqual.Text = "Idênticos: 0";
            this.toolStripStatusEqual.ForeColor = Color.Gray;


            this.toolStripStatusDifferent.Image = this.imageListIcons.Images["fileerror.ico"];
            this.toolStripStatusDifferent.Text = "Divergentes: 0";
            this.toolStripStatusDifferent.ForeColor = Color.Gray;

            this.toolStripStatusLeftOnly.Image = this.imageListIcons.Images["fileleft.ico"];
            this.toolStripStatusLeftOnly.Text = "Somente em A: 0";
            this.toolStripStatusLeftOnly.ForeColor = Color.Gray;

            this.toolStripStatusRightOnly.Image = this.imageListIcons.Images["fileright.ico"];
            this.toolStripStatusRightOnly.Text = "Somente em B: 0";
            this.toolStripStatusRightOnly.ForeColor = Color.Gray;

        }

        private void chkShowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.treeViewDiff.CheckBoxes = (this.chkShowCheckBox.Checked);
            if (this.treeViewDiff.Nodes.Count > 0)
                this.treeViewDiff.Nodes[0].Expand();


        }

        private void txtDirectoryA_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void txtDirectoryB_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void picInvert_Click(object sender, EventArgs e)
        {
            string stringA = txtDirectoryA.Text;
            txtDirectoryA.Text = txtDirectoryB.Text;
            txtDirectoryB.Text = stringA;
        }




    }
}

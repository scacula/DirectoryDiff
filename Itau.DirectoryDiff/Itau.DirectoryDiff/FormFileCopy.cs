using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Itau.TreeFileViewer;

namespace Itau.DirectoryDiff
{
    public partial class FormFileCopy : Form
    {

        #region Propriedades

        List<FileReference> _listFiles = new List<FileReference>();
        public List<FileReference> ListFiles
        {
            set { _listFiles = value; }
        }

        ImageList _imageList;
        public ImageList ImageList
        {
            set { _imageList = value; }
        }

        string _pathA;
        public string PathA
        {
            set { _pathA = value; }
        }


        string _pathB;
        public string PathB
        {
            set { _pathB = value; }
        }

        #endregion

        public FormFileCopy()
        {
            InitializeComponent();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listViewFiles.Items)
            {
                item.Checked = true;
            }
        }

        private void btnCheckNone_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listViewFiles.Items)
            {
                item.Checked = false;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            int countCopy = 0;
            Cursor.Current = Cursors.WaitCursor;
            
            List<ListViewItem> listNew = new List<ListViewItem>();
            foreach (ListViewItem item in this.listViewFiles.Items)
            {

                if (item.Checked)
                {
                    string origemPath = System.IO.Path.Combine(_pathA, item.SubItems[2].Text);
                    string destinoPath = System.IO.Path.Combine(_pathB, item.SubItems[2].Text);

                    
                    try
                    {
                        if (System.IO.Directory.Exists(origemPath))
                        {
                            FullCreateFolder(destinoPath);
                        }
                        else if (System.IO.File.Exists(origemPath))
                        {

                            if (System.IO.File.Exists(destinoPath))
                            {
                                //removendo atributo somente leitura
                                System.IO.File.SetAttributes(destinoPath, System.IO.File.GetAttributes(destinoPath) & ~System.IO.FileAttributes.ReadOnly);
                            }
                            else
                            {
                                FullCreateFileDir(destinoPath);
                            }
                            System.IO.File.Copy(origemPath, destinoPath, true);
                        }
                        countCopy++;
                    }
                    catch (Exception ex)
                    {
                        item.SubItems[3].Text = "Falha na cópia:" + ex.Message;
                        listNew.Add(item);
                    }

                }
                else
                {
                    listNew.Add(item);
                }

            }

            listViewFiles.Items.Clear();

            Cursor.Current = Cursors.Default;
            if (listNew.Count == 0)
            {
                MessageBox.Show("Arquivos copiados com sucesso!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                if (countCopy > 0)
                {
                    MessageBox.Show(string.Format("Copiados {0} itens com sucesso!",countCopy.ToString()), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //else
            //{
            //    MessageBox.Show(String.Format("Erro ao copiar {0} arquivos!",listNew.Count.ToString()));
            //}
            Cursor.Current = Cursors.WaitCursor;
            foreach (ListViewItem newItemList in listNew)
            {
                this.listViewFiles.Items.Add(newItemList);
            }
            Cursor.Current = Cursors.Default;
        }

        private void FullCreateFileDir(string file)
        {
            List<string> listSplit = file.Split('\\').ToList<string>();


            int count = 1;
            string pathCurrent = "";
            foreach (string folder in listSplit)
            {
                if (count < listSplit.Count)
                {
                    pathCurrent = pathCurrent + folder + "\\";
                    if (!System.IO.Directory.Exists(pathCurrent))
                    {
                        System.IO.Directory.CreateDirectory(pathCurrent);
                    }
                }

                count++;

            }
        }

        private void FullCreateFolder(string file)
        {
            List<string> listSplit = file.Split('\\').ToList<string>();

            string pathCurrent = "";
            foreach (string folder in listSplit)
            {

                pathCurrent = pathCurrent + folder + "\\";
                if (!System.IO.Directory.Exists(pathCurrent))
                {
                    System.IO.Directory.CreateDirectory(pathCurrent);
                }

            }
        }

        private void FormFileCopy_Load(object sender, EventArgs e)
        {

            //limpa o listview
            listViewFiles.Columns.Clear();
            listViewFiles.Items.Clear();

            listViewFiles.SmallImageList = _imageList;

            ColumnHeader colIcon = new ColumnHeader();
            ColumnHeader colCopyStatus = new ColumnHeader();
            ColumnHeader colFile = new ColumnHeader();
            ColumnHeader colStatus = new ColumnHeader();


            colIcon.Text = "Tipo";
            colCopyStatus.Text = "";
            colFile.Text = "Arquivo";
            colStatus.Text = "Status";

            colIcon.Width = 40;
            colCopyStatus.Width = 0;
            colFile.Width = listViewFiles.Width - colIcon.Width - 10;
            colStatus.Width = listViewFiles.Width / 2;

            listViewFiles.Columns.Add(colIcon);
            listViewFiles.Columns.Add(colCopyStatus);
            listViewFiles.Columns.Add(colFile);
            listViewFiles.Columns.Add(colStatus);

            foreach (FileReference file in this._listFiles)
            {

                ListViewItem listItem = new ListViewItem();
                listItem.ImageIndex = Itau.TreeFileViewer.Util.NodeTypeToImageIndex(file.NodeType, _imageList);
                listItem.Checked = true;
                listItem.SubItems.Add("");
                listItem.SubItems.Add(file.Path);
                listItem.SubItems.Add("Pronto para Copiar");
 
                this.listViewFiles.Items.Add(listItem);

            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (msg.WParam.ToInt32() == (int)Keys.Escape)
                {
                    this.Close();
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            catch (Exception)
            {

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            int countCheckout = 0;
            Cursor.Current = Cursors.WaitCursor;

            
            List<string> filesCheckout = new List<string>();

            foreach (ListViewItem item in this.listViewFiles.Items)
            {
                

                if (item.Checked)
                {
                    string destinoPath = System.IO.Path.Combine(_pathB, item.SubItems[2].Text);

                    

                    if (System.IO.File.Exists(destinoPath))
                    {
                        filesCheckout.Add(destinoPath);
                        countCheckout++;
                    }

                }

            }

            try
            {
                //Itau.TreeFileViewer.Util.ClearCaseCheckoutMulti(filesCheckout);

                MessageBox.Show("Processo de Checkout Concluído!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Falha no checkout : {0}!", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Itau.DirectoryDiff
{
    public partial class FormFiltros : Form
    {


        #region Propriedades

        bool _atualizado = false;
        public bool Atualizado
        {
            get { return _atualizado; }
        }
        #endregion

        public FormFiltros()
        {
            InitializeComponent();
        }

        private void FormFiltros_Load(object sender, EventArgs e)
        {

            listDiretorios.Items.Clear();
            listExtensoes.Items.Clear();
            listPublish.Items.Clear();
            chkSomenteA.Checked = false;
            chkSomenteB.Checked = false;
            chkTipoDivergentes.Checked = false;
            chkTipoIdenticos.Checked = false;

            foreach (string ext in Util.Config.IgnoreExtensions)
            {
                listExtensoes.Items.Add(ext);
            }

            foreach (string dir in Util.Config.IgnorePaths)
            {
                listDiretorios.Items.Add(dir);
            }

            //foreach (string folder in Util.Config.PublishFolders)
            //{
            //    listPublish.Items.Add(folder);
            //}

            foreach (string type in Util.Config.NodeTypes)
            {
                if (int.Parse(type) == (int)Itau.TreeFileViewer.FileNodeType.Equal)
                    chkTipoIdenticos.Checked = true;
                else if (int.Parse(type) == (int)Itau.TreeFileViewer.FileNodeType.Different)
                    chkTipoDivergentes.Checked = true;
                else if (int.Parse(type) == (int)Itau.TreeFileViewer.FileNodeType.LeftOnly)
                    chkSomenteA.Checked = true;
                else if (int.Parse(type) == (int)Itau.TreeFileViewer.FileNodeType.RightOnly)
                    chkSomenteB.Checked = true;
            }

            if (Util.Config.CompareTool.ToUpper() == "W")
            {
                rbtWinMerge.Checked = true;
            }
            else
            {
                rbtClearCase.Checked = true;
            }

            if (Util.Config.NotContent.ToUpper() == "S")
            {
                chkValidateExist.Checked = true;
            }
            else
            {
                chkValidateExist.Checked = false;
            }


        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {


            try
            {
                Util.Config.IgnoreExtensions.Clear();
                foreach (string item in listExtensoes.Items)
                {
                    Util.Config.IgnoreExtensions.Add(item);
                }

                if (rbtWinMerge.Checked)
                {
                    Util.Config.CompareTool = "W";
                }
                else
                {
                    Util.Config.CompareTool = "C";
                }

                if (chkValidateExist.Checked)
                    Util.Config.NotContent = "S";
                else
                    Util.Config.NotContent = "N";

                Util.Config.IgnorePaths.Clear();
                foreach (string item in listDiretorios.Items)
                {
                    Util.Config.IgnorePaths.Add(item);
                }

                //Util.Config.PublishFolders.Clear();
                //foreach (string item in listPublish.Items)
                //{
                //    Util.Config.PublishFolders.Add(item);
                //}

                Util.Config.NodeTypes.Clear();

                if (chkTipoIdenticos.Checked)
                    Util.Config.NodeTypes.Add(((int)Itau.TreeFileViewer.FileNodeType.Equal).ToString());
                if (chkTipoDivergentes.Checked)
                    Util.Config.NodeTypes.Add(((int)Itau.TreeFileViewer.FileNodeType.Different).ToString());
                if (chkSomenteA.Checked)
                    Util.Config.NodeTypes.Add(((int)Itau.TreeFileViewer.FileNodeType.LeftOnly).ToString());
                if (chkSomenteB.Checked)
                    Util.Config.NodeTypes.Add(((int)Itau.TreeFileViewer.FileNodeType.RightOnly).ToString());

                Util.Config.Save();

                _atualizado = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
            this.Close();
        }

        private void btnRemoverExtensao_Click(object sender, EventArgs e)
        {
            if (listExtensoes.SelectedIndex >= 0)
                listExtensoes.Items.RemoveAt(listExtensoes.SelectedIndex);
        }

        private void btnRemoverDiretorios_Click(object sender, EventArgs e)
        {
            if (listDiretorios.SelectedIndex >= 0)
                listDiretorios.Items.RemoveAt(listDiretorios.SelectedIndex);
        }

        private void btnAdicionarExtensao_Click(object sender, EventArgs e)
        {
            FormInput formInput = new FormInput();
            formInput.ShowDialog();
            string value = formInput.Value;
            formInput.Close();

            if (!string.IsNullOrEmpty(value))
            {
                if (value.Substring(0, 1) != ".")
                    value = "." + value;

                this.listExtensoes.Items.Add(value.Trim().ToLower());
            }


        }

        private void btnAdicionarDiretorio_Click(object sender, EventArgs e)
        {
            FormInput formInput = new FormInput();
            formInput.ShowDialog();
            string value = formInput.Value;
            formInput.Close();

            if (!string.IsNullOrEmpty(value))
            {
                this.listDiretorios.Items.Add(value.Trim().ToLower());
            }

 
        }

        private void btnRestaurarDefault_Click(object sender, EventArgs e)
        {
            listExtensoes.Items.Clear();
            foreach (string item in Itau.TreeFileViewer.Util.DefaultIgnoreFiles())
            {
                listExtensoes.Items.Add(item);
            }

            listDiretorios.Items.Clear();
            foreach (string item in Itau.TreeFileViewer.Util.DefaultIgnoreFolders())
            {
                listDiretorios.Items.Add(item);
            }

            listPublish.Items.Clear();
            //foreach (string item in Itau.TreeFileViewer.Util.DefaultPublishFolders())
            //{
            //    listPublish.Items.Add(item);
            //}

            chkTipoIdenticos.Checked = true;
            chkTipoDivergentes.Checked = true;
            chkSomenteA.Checked = true;
            chkSomenteB.Checked = true;

            rbtClearCase.Checked = true;

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

        private void btnRemoverPublish_Click(object sender, EventArgs e)
        {
            if (listPublish.SelectedIndex >= 0)
                listPublish.Items.RemoveAt(listPublish.SelectedIndex);
        }

        private void btnAdicionarPublish_Click(object sender, EventArgs e)
        {
            FormInput formInput = new FormInput();
            formInput.ShowDialog();
            string value = formInput.Value;
            formInput.Close();

            if (!string.IsNullOrEmpty(value))
            {
                this.listPublish.Items.Add(value.Trim().ToLower());
            }
        }
    }
}

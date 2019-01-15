using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Itau.DirectoryDiff
{
    public partial class FormSelectType : Form
    {

        #region Propriedades

        int _optionValue = 0;
        public int OptionValue
        {
            get { return  _optionValue; }
        }
        #endregion

        public FormSelectType()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (chkTipoIdenticos.Checked)
                _optionValue = _optionValue + (int)Itau.TreeFileViewer.FileNodeType.Equal;
            if (chkTipoDivergentes.Checked)
                _optionValue = _optionValue + (int)Itau.TreeFileViewer.FileNodeType.Different;
            if (chkSomenteA.Checked)
                _optionValue = _optionValue + (int)Itau.TreeFileViewer.FileNodeType.LeftOnly;

            this.Hide();

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
    }
}

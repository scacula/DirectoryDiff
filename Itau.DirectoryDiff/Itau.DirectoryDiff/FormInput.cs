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
    public partial class FormInput : Form
    {

        #region Propriedades

        string _value = "";
        public string Value
        {
            get { return _value; }
        }
        #endregion

        public FormInput()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _value = this.txtValue.Text.Trim();
            if(!string.IsNullOrEmpty(_value))
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

namespace Itau.DirectoryDiff
{
    partial class FormSelectType
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.chkSomenteA = new System.Windows.Forms.CheckBox();
            this.lblCopia = new System.Windows.Forms.Label();
            this.grpTipo = new System.Windows.Forms.GroupBox();
            this.chkTipoDivergentes = new System.Windows.Forms.CheckBox();
            this.chkTipoIdenticos = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picFileA = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFileA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(3, 123);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(158, 23);
            this.btnOk.TabIndex = 17;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkSomenteA
            // 
            this.chkSomenteA.AutoSize = true;
            this.chkSomenteA.Checked = true;
            this.chkSomenteA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSomenteA.Location = new System.Drawing.Point(16, 68);
            this.chkSomenteA.Name = "chkSomenteA";
            this.chkSomenteA.Size = new System.Drawing.Size(88, 17);
            this.chkSomenteA.TabIndex = 3;
            this.chkSomenteA.Text = "Somente em ";
            this.chkSomenteA.UseVisualStyleBackColor = true;
            // 
            // lblCopia
            // 
            this.lblCopia.AutoSize = true;
            this.lblCopia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopia.Location = new System.Drawing.Point(6, 3);
            this.lblCopia.Name = "lblCopia";
            this.lblCopia.Size = new System.Drawing.Size(138, 13);
            this.lblCopia.TabIndex = 19;
            this.lblCopia.Text = "Cópia de         para     ";
            // 
            // grpTipo
            // 
            this.grpTipo.Controls.Add(this.picFileA);
            this.grpTipo.Controls.Add(this.chkSomenteA);
            this.grpTipo.Controls.Add(this.chkTipoDivergentes);
            this.grpTipo.Controls.Add(this.chkTipoIdenticos);
            this.grpTipo.Location = new System.Drawing.Point(3, 25);
            this.grpTipo.Name = "grpTipo";
            this.grpTipo.Size = new System.Drawing.Size(158, 92);
            this.grpTipo.TabIndex = 16;
            this.grpTipo.TabStop = false;
            this.grpTipo.Text = "Tipos de Arquivos";
            // 
            // chkTipoDivergentes
            // 
            this.chkTipoDivergentes.AutoSize = true;
            this.chkTipoDivergentes.Checked = true;
            this.chkTipoDivergentes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTipoDivergentes.Location = new System.Drawing.Point(16, 45);
            this.chkTipoDivergentes.Name = "chkTipoDivergentes";
            this.chkTipoDivergentes.Size = new System.Drawing.Size(83, 17);
            this.chkTipoDivergentes.TabIndex = 2;
            this.chkTipoDivergentes.Text = "Divergentes";
            this.chkTipoDivergentes.UseVisualStyleBackColor = true;
            // 
            // chkTipoIdenticos
            // 
            this.chkTipoIdenticos.AutoSize = true;
            this.chkTipoIdenticos.Location = new System.Drawing.Point(16, 22);
            this.chkTipoIdenticos.Name = "chkTipoIdenticos";
            this.chkTipoIdenticos.Size = new System.Drawing.Size(69, 17);
            this.chkTipoIdenticos.TabIndex = 1;
            this.chkTipoIdenticos.Text = "Idênticos";
            this.chkTipoIdenticos.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Itau.DirectoryDiff.Properties.Resources.fileB;
            this.pictureBox2.Location = new System.Drawing.Point(131, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // picFileA
            // 
            this.picFileA.Image = global::Itau.DirectoryDiff.Properties.Resources.fileA;
            this.picFileA.Location = new System.Drawing.Point(99, 68);
            this.picFileA.Name = "picFileA";
            this.picFileA.Size = new System.Drawing.Size(16, 16);
            this.picFileA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFileA.TabIndex = 9;
            this.picFileA.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Itau.DirectoryDiff.Properties.Resources.fileA;
            this.pictureBox1.Location = new System.Drawing.Point(69, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // FormSelectType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(165, 150);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.grpTipo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCopia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSelectType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grpTipo.ResumeLayout(false);
            this.grpTipo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFileA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFileA;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox chkSomenteA;
        private System.Windows.Forms.Label lblCopia;
        private System.Windows.Forms.GroupBox grpTipo;
        private System.Windows.Forms.CheckBox chkTipoDivergentes;
        private System.Windows.Forms.CheckBox chkTipoIdenticos;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
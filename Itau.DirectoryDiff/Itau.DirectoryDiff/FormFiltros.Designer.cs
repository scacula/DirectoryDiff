namespace Itau.DirectoryDiff
{
    partial class FormFiltros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFiltros));
            this.btnAdicionarDiretorio = new System.Windows.Forms.Button();
            this.btnRemoverDiretorios = new System.Windows.Forms.Button();
            this.chkSomenteB = new System.Windows.Forms.CheckBox();
            this.grpTipo = new System.Windows.Forms.GroupBox();
            this.picFileB = new System.Windows.Forms.PictureBox();
            this.picFileA = new System.Windows.Forms.PictureBox();
            this.chkSomenteA = new System.Windows.Forms.CheckBox();
            this.chkTipoDivergentes = new System.Windows.Forms.CheckBox();
            this.chkTipoIdenticos = new System.Windows.Forms.CheckBox();
            this.btnRestaurarDefault = new System.Windows.Forms.Button();
            this.btnAdicionarExtensao = new System.Windows.Forms.Button();
            this.btnRemoverExtensao = new System.Windows.Forms.Button();
            this.grpDesconsiderarExtensoes = new System.Windows.Forms.GroupBox();
            this.listExtensoes = new System.Windows.Forms.ListBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.listDiretorios = new System.Windows.Forms.ListBox();
            this.grpDesconsiderarDiretorios = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtWinMerge = new System.Windows.Forms.RadioButton();
            this.rbtClearCase = new System.Windows.Forms.RadioButton();
            this.grpPublishFolders = new System.Windows.Forms.GroupBox();
            this.btnAdicionarPublish = new System.Windows.Forms.Button();
            this.btnRemoverPublish = new System.Windows.Forms.Button();
            this.listPublish = new System.Windows.Forms.ListBox();
            this.chkValidateExist = new System.Windows.Forms.CheckBox();
            this.grpTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFileB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFileA)).BeginInit();
            this.grpDesconsiderarExtensoes.SuspendLayout();
            this.grpDesconsiderarDiretorios.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpPublishFolders.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdicionarDiretorio
            // 
            this.btnAdicionarDiretorio.Location = new System.Drawing.Point(174, 50);
            this.btnAdicionarDiretorio.Name = "btnAdicionarDiretorio";
            this.btnAdicionarDiretorio.Size = new System.Drawing.Size(76, 25);
            this.btnAdicionarDiretorio.TabIndex = 9;
            this.btnAdicionarDiretorio.Text = "Adicionar";
            this.btnAdicionarDiretorio.UseVisualStyleBackColor = true;
            this.btnAdicionarDiretorio.Click += new System.EventHandler(this.btnAdicionarDiretorio_Click);
            // 
            // btnRemoverDiretorios
            // 
            this.btnRemoverDiretorios.Location = new System.Drawing.Point(174, 19);
            this.btnRemoverDiretorios.Name = "btnRemoverDiretorios";
            this.btnRemoverDiretorios.Size = new System.Drawing.Size(76, 25);
            this.btnRemoverDiretorios.TabIndex = 8;
            this.btnRemoverDiretorios.Text = "Remover";
            this.btnRemoverDiretorios.UseVisualStyleBackColor = true;
            this.btnRemoverDiretorios.Click += new System.EventHandler(this.btnRemoverDiretorios_Click);
            // 
            // chkSomenteB
            // 
            this.chkSomenteB.AutoSize = true;
            this.chkSomenteB.Checked = true;
            this.chkSomenteB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSomenteB.Location = new System.Drawing.Point(115, 44);
            this.chkSomenteB.Name = "chkSomenteB";
            this.chkSomenteB.Size = new System.Drawing.Size(88, 17);
            this.chkSomenteB.TabIndex = 16;
            this.chkSomenteB.Text = "Somente em ";
            this.chkSomenteB.UseVisualStyleBackColor = true;
            // 
            // grpTipo
            // 
            this.grpTipo.Controls.Add(this.picFileB);
            this.grpTipo.Controls.Add(this.chkSomenteB);
            this.grpTipo.Controls.Add(this.picFileA);
            this.grpTipo.Controls.Add(this.chkSomenteA);
            this.grpTipo.Controls.Add(this.chkTipoDivergentes);
            this.grpTipo.Controls.Add(this.chkTipoIdenticos);
            this.grpTipo.Location = new System.Drawing.Point(8, 264);
            this.grpTipo.Name = "grpTipo";
            this.grpTipo.Size = new System.Drawing.Size(257, 72);
            this.grpTipo.TabIndex = 8;
            this.grpTipo.TabStop = false;
            this.grpTipo.Text = "Tipos de Arquivos";
            // 
            // picFileB
            // 
            this.picFileB.Image = global::Itau.DirectoryDiff.Properties.Resources.fileB;
            this.picFileB.Location = new System.Drawing.Point(198, 44);
            this.picFileB.Name = "picFileB";
            this.picFileB.Size = new System.Drawing.Size(16, 16);
            this.picFileB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFileB.TabIndex = 12;
            this.picFileB.TabStop = false;
            // 
            // picFileA
            // 
            this.picFileA.Image = global::Itau.DirectoryDiff.Properties.Resources.fileA;
            this.picFileA.Location = new System.Drawing.Point(198, 22);
            this.picFileA.Name = "picFileA";
            this.picFileA.Size = new System.Drawing.Size(16, 16);
            this.picFileA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFileA.TabIndex = 9;
            this.picFileA.TabStop = false;
            // 
            // chkSomenteA
            // 
            this.chkSomenteA.AutoSize = true;
            this.chkSomenteA.Checked = true;
            this.chkSomenteA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSomenteA.Location = new System.Drawing.Point(115, 22);
            this.chkSomenteA.Name = "chkSomenteA";
            this.chkSomenteA.Size = new System.Drawing.Size(88, 17);
            this.chkSomenteA.TabIndex = 15;
            this.chkSomenteA.Text = "Somente em ";
            this.chkSomenteA.UseVisualStyleBackColor = true;
            // 
            // chkTipoDivergentes
            // 
            this.chkTipoDivergentes.AutoSize = true;
            this.chkTipoDivergentes.Checked = true;
            this.chkTipoDivergentes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTipoDivergentes.Location = new System.Drawing.Point(16, 45);
            this.chkTipoDivergentes.Name = "chkTipoDivergentes";
            this.chkTipoDivergentes.Size = new System.Drawing.Size(83, 17);
            this.chkTipoDivergentes.TabIndex = 14;
            this.chkTipoDivergentes.Text = "Divergentes";
            this.chkTipoDivergentes.UseVisualStyleBackColor = true;
            // 
            // chkTipoIdenticos
            // 
            this.chkTipoIdenticos.AutoSize = true;
            this.chkTipoIdenticos.Checked = true;
            this.chkTipoIdenticos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTipoIdenticos.Location = new System.Drawing.Point(16, 22);
            this.chkTipoIdenticos.Name = "chkTipoIdenticos";
            this.chkTipoIdenticos.Size = new System.Drawing.Size(69, 17);
            this.chkTipoIdenticos.TabIndex = 13;
            this.chkTipoIdenticos.Text = "Idênticos";
            this.chkTipoIdenticos.UseVisualStyleBackColor = true;
            // 
            // btnRestaurarDefault
            // 
            this.btnRestaurarDefault.Location = new System.Drawing.Point(33, 409);
            this.btnRestaurarDefault.Name = "btnRestaurarDefault";
            this.btnRestaurarDefault.Size = new System.Drawing.Size(119, 23);
            this.btnRestaurarDefault.TabIndex = 19;
            this.btnRestaurarDefault.Text = "Configuração Padrão";
            this.btnRestaurarDefault.UseVisualStyleBackColor = true;
            this.btnRestaurarDefault.Click += new System.EventHandler(this.btnRestaurarDefault_Click);
            // 
            // btnAdicionarExtensao
            // 
            this.btnAdicionarExtensao.Location = new System.Drawing.Point(176, 46);
            this.btnAdicionarExtensao.Name = "btnAdicionarExtensao";
            this.btnAdicionarExtensao.Size = new System.Drawing.Size(76, 25);
            this.btnAdicionarExtensao.TabIndex = 5;
            this.btnAdicionarExtensao.Text = "Adicionar";
            this.btnAdicionarExtensao.UseVisualStyleBackColor = true;
            this.btnAdicionarExtensao.Click += new System.EventHandler(this.btnAdicionarExtensao_Click);
            // 
            // btnRemoverExtensao
            // 
            this.btnRemoverExtensao.Location = new System.Drawing.Point(176, 15);
            this.btnRemoverExtensao.Name = "btnRemoverExtensao";
            this.btnRemoverExtensao.Size = new System.Drawing.Size(76, 25);
            this.btnRemoverExtensao.TabIndex = 4;
            this.btnRemoverExtensao.Text = "Remover";
            this.btnRemoverExtensao.UseVisualStyleBackColor = true;
            this.btnRemoverExtensao.Click += new System.EventHandler(this.btnRemoverExtensao_Click);
            // 
            // grpDesconsiderarExtensoes
            // 
            this.grpDesconsiderarExtensoes.Controls.Add(this.btnAdicionarExtensao);
            this.grpDesconsiderarExtensoes.Controls.Add(this.btnRemoverExtensao);
            this.grpDesconsiderarExtensoes.Controls.Add(this.listExtensoes);
            this.grpDesconsiderarExtensoes.Location = new System.Drawing.Point(6, 5);
            this.grpDesconsiderarExtensoes.Name = "grpDesconsiderarExtensoes";
            this.grpDesconsiderarExtensoes.Size = new System.Drawing.Size(259, 79);
            this.grpDesconsiderarExtensoes.TabIndex = 6;
            this.grpDesconsiderarExtensoes.TabStop = false;
            this.grpDesconsiderarExtensoes.Text = "Desconsiderar Extensões";
            // 
            // listExtensoes
            // 
            this.listExtensoes.FormattingEnabled = true;
            this.listExtensoes.Location = new System.Drawing.Point(9, 15);
            this.listExtensoes.Name = "listExtensoes";
            this.listExtensoes.Size = new System.Drawing.Size(161, 56);
            this.listExtensoes.TabIndex = 2;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(158, 409);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(107, 23);
            this.btnAplicar.TabIndex = 20;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // listDiretorios
            // 
            this.listDiretorios.FormattingEnabled = true;
            this.listDiretorios.Location = new System.Drawing.Point(7, 19);
            this.listDiretorios.Name = "listDiretorios";
            this.listDiretorios.Size = new System.Drawing.Size(161, 56);
            this.listDiretorios.TabIndex = 6;
            // 
            // grpDesconsiderarDiretorios
            // 
            this.grpDesconsiderarDiretorios.Controls.Add(this.btnAdicionarDiretorio);
            this.grpDesconsiderarDiretorios.Controls.Add(this.btnRemoverDiretorios);
            this.grpDesconsiderarDiretorios.Controls.Add(this.listDiretorios);
            this.grpDesconsiderarDiretorios.Location = new System.Drawing.Point(8, 91);
            this.grpDesconsiderarDiretorios.Name = "grpDesconsiderarDiretorios";
            this.grpDesconsiderarDiretorios.Size = new System.Drawing.Size(257, 83);
            this.grpDesconsiderarDiretorios.TabIndex = 7;
            this.grpDesconsiderarDiretorios.TabStop = false;
            this.grpDesconsiderarDiretorios.Text = "Desconsiderar Diretórios";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtWinMerge);
            this.groupBox1.Controls.Add(this.rbtClearCase);
            this.groupBox1.Location = new System.Drawing.Point(8, 342);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 39);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ferramenta de Comparação";
            // 
            // rbtWinMerge
            // 
            this.rbtWinMerge.AutoSize = true;
            this.rbtWinMerge.Location = new System.Drawing.Point(150, 16);
            this.rbtWinMerge.Name = "rbtWinMerge";
            this.rbtWinMerge.Size = new System.Drawing.Size(74, 17);
            this.rbtWinMerge.TabIndex = 18;
            this.rbtWinMerge.Text = "WinMerge";
            this.rbtWinMerge.UseVisualStyleBackColor = true;
            // 
            // rbtClearCase
            // 
            this.rbtClearCase.AutoSize = true;
            this.rbtClearCase.Checked = true;
            this.rbtClearCase.Location = new System.Drawing.Point(9, 16);
            this.rbtClearCase.Name = "rbtClearCase";
            this.rbtClearCase.Size = new System.Drawing.Size(76, 17);
            this.rbtClearCase.TabIndex = 17;
            this.rbtClearCase.TabStop = true;
            this.rbtClearCase.Text = "Clear Case";
            this.rbtClearCase.UseVisualStyleBackColor = true;
            // 
            // grpPublishFolders
            // 
            this.grpPublishFolders.Controls.Add(this.btnAdicionarPublish);
            this.grpPublishFolders.Controls.Add(this.btnRemoverPublish);
            this.grpPublishFolders.Controls.Add(this.listPublish);
            this.grpPublishFolders.Location = new System.Drawing.Point(8, 178);
            this.grpPublishFolders.Name = "grpPublishFolders";
            this.grpPublishFolders.Size = new System.Drawing.Size(257, 83);
            this.grpPublishFolders.TabIndex = 13;
            this.grpPublishFolders.TabStop = false;
            this.grpPublishFolders.Text = "Publish Folders";
            // 
            // btnAdicionarPublish
            // 
            this.btnAdicionarPublish.Location = new System.Drawing.Point(174, 50);
            this.btnAdicionarPublish.Name = "btnAdicionarPublish";
            this.btnAdicionarPublish.Size = new System.Drawing.Size(76, 25);
            this.btnAdicionarPublish.TabIndex = 12;
            this.btnAdicionarPublish.Text = "Adicionar";
            this.btnAdicionarPublish.UseVisualStyleBackColor = true;
            this.btnAdicionarPublish.Click += new System.EventHandler(this.btnAdicionarPublish_Click);
            // 
            // btnRemoverPublish
            // 
            this.btnRemoverPublish.Location = new System.Drawing.Point(174, 19);
            this.btnRemoverPublish.Name = "btnRemoverPublish";
            this.btnRemoverPublish.Size = new System.Drawing.Size(76, 25);
            this.btnRemoverPublish.TabIndex = 11;
            this.btnRemoverPublish.Text = "Remover";
            this.btnRemoverPublish.UseVisualStyleBackColor = true;
            this.btnRemoverPublish.Click += new System.EventHandler(this.btnRemoverPublish_Click);
            // 
            // listPublish
            // 
            this.listPublish.FormattingEnabled = true;
            this.listPublish.Location = new System.Drawing.Point(7, 19);
            this.listPublish.Name = "listPublish";
            this.listPublish.Size = new System.Drawing.Size(161, 56);
            this.listPublish.TabIndex = 6;
            // 
            // chkValidateExist
            // 
            this.chkValidateExist.AutoSize = true;
            this.chkValidateExist.Location = new System.Drawing.Point(10, 387);
            this.chkValidateExist.Name = "chkValidateExist";
            this.chkValidateExist.Size = new System.Drawing.Size(221, 17);
            this.chkValidateExist.TabIndex = 21;
            this.chkValidateExist.Text = "Desconsiderar Comparação de Conteúdo";
            this.chkValidateExist.UseVisualStyleBackColor = true;
            // 
            // FormFiltros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 437);
            this.Controls.Add(this.chkValidateExist);
            this.Controls.Add(this.grpPublishFolders);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpTipo);
            this.Controls.Add(this.btnRestaurarDefault);
            this.Controls.Add(this.grpDesconsiderarExtensoes);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.grpDesconsiderarDiretorios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormFiltros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtros";
            this.Load += new System.EventHandler(this.FormFiltros_Load);
            this.grpTipo.ResumeLayout(false);
            this.grpTipo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFileB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFileA)).EndInit();
            this.grpDesconsiderarExtensoes.ResumeLayout(false);
            this.grpDesconsiderarDiretorios.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpPublishFolders.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdicionarDiretorio;
        private System.Windows.Forms.PictureBox picFileB;
        private System.Windows.Forms.PictureBox picFileA;
        private System.Windows.Forms.Button btnRemoverDiretorios;
        private System.Windows.Forms.CheckBox chkSomenteB;
        private System.Windows.Forms.GroupBox grpTipo;
        private System.Windows.Forms.CheckBox chkSomenteA;
        private System.Windows.Forms.CheckBox chkTipoDivergentes;
        private System.Windows.Forms.CheckBox chkTipoIdenticos;
        private System.Windows.Forms.Button btnRestaurarDefault;
        private System.Windows.Forms.Button btnAdicionarExtensao;
        private System.Windows.Forms.Button btnRemoverExtensao;
        private System.Windows.Forms.GroupBox grpDesconsiderarExtensoes;
        private System.Windows.Forms.ListBox listExtensoes;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.ListBox listDiretorios;
        private System.Windows.Forms.GroupBox grpDesconsiderarDiretorios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtWinMerge;
        private System.Windows.Forms.RadioButton rbtClearCase;
        private System.Windows.Forms.GroupBox grpPublishFolders;
        private System.Windows.Forms.Button btnAdicionarPublish;
        private System.Windows.Forms.Button btnRemoverPublish;
        private System.Windows.Forms.ListBox listPublish;
        private System.Windows.Forms.CheckBox chkValidateExist;

    }
}
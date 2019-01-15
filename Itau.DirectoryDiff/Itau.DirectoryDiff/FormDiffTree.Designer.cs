namespace Itau.DirectoryDiff
{
    partial class FormDiffTree
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDiffTree));
            this.mnuExcluirA = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDiferencas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopyPath = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyPathA = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyPathB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExcluir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExcluirB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenA = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHistorico = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHistoricoA = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHistoricoB = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.treePanel = new System.Windows.Forms.Panel();
            this.chkShowCheckBox = new System.Windows.Forms.CheckBox();
            this.treeViewDiff = new Itau.TreeFileViewer.FileSystemTreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picInvert = new System.Windows.Forms.PictureBox();
            this.picFileB = new System.Windows.Forms.PictureBox();
            this.picFileA = new System.Windows.Forms.PictureBox();
            this.toolMenu = new System.Windows.Forms.ToolStrip();
            this.toolbtnNovo = new System.Windows.Forms.ToolStripButton();
            this.toolbtnCopy = new System.Windows.Forms.ToolStripButton();
            this.toolbtnFiltro = new System.Windows.Forms.ToolStripButton();
            this.toolbtnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolbtnSair = new System.Windows.Forms.ToolStripButton();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnDirectoryB = new System.Windows.Forms.Button();
            this.txtDirectoryB = new System.Windows.Forms.TextBox();
            this.btnDirectoryA = new System.Windows.Forms.Button();
            this.txtDirectoryA = new System.Windows.Forms.TextBox();
            this.statusFiles = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusDifferent = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLeftOnlyFolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLeftOnly = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusRightOnlyFolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusRightOnly = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusEqual = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripVersao = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuTreeView.SuspendLayout();
            this.treePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInvert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFileB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFileA)).BeginInit();
            this.toolMenu.SuspendLayout();
            this.statusFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuExcluirA
            // 
            this.mnuExcluirA.Name = "mnuExcluirA";
            this.mnuExcluirA.Size = new System.Drawing.Size(108, 22);
            this.mnuExcluirA.Text = "De A";
            this.mnuExcluirA.Click += new System.EventHandler(this.mnuExcluirA_Click);
            // 
            // mnuDiferencas
            // 
            this.mnuDiferencas.Name = "mnuDiferencas";
            this.mnuDiferencas.Size = new System.Drawing.Size(176, 22);
            this.mnuDiferencas.Text = "Mostrar Diferenças";
            this.mnuDiferencas.Click += new System.EventHandler(this.mnuDiferencas_Click);
            // 
            // mnuTreeView
            // 
            this.mnuTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDiferencas,
            this.mnuCopyPath,
            this.mnuExcluir,
            this.mnuOpen,
            this.toolStripSeparator1,
            this.mnuHistorico});
            this.mnuTreeView.Name = "mnuTreeView";
            this.mnuTreeView.Size = new System.Drawing.Size(177, 120);
            this.mnuTreeView.Opening += new System.ComponentModel.CancelEventHandler(this.mnuTreeView_Opening);
            // 
            // mnuCopyPath
            // 
            this.mnuCopyPath.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopyPathA,
            this.mnuCopyPathB});
            this.mnuCopyPath.Name = "mnuCopyPath";
            this.mnuCopyPath.Size = new System.Drawing.Size(176, 22);
            this.mnuCopyPath.Text = "Copiar Path";
            // 
            // mnuCopyPathA
            // 
            this.mnuCopyPathA.Name = "mnuCopyPathA";
            this.mnuCopyPathA.Size = new System.Drawing.Size(117, 22);
            this.mnuCopyPathA.Text = "Path A";
            this.mnuCopyPathA.Click += new System.EventHandler(this.mnuCopyPathA_Click);
            // 
            // mnuCopyPathB
            // 
            this.mnuCopyPathB.Name = "mnuCopyPathB";
            this.mnuCopyPathB.Size = new System.Drawing.Size(117, 22);
            this.mnuCopyPathB.Text = "Path B";
            this.mnuCopyPathB.Click += new System.EventHandler(this.mnuCopyPathB_Click);
            // 
            // mnuExcluir
            // 
            this.mnuExcluir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExcluirA,
            this.mnuExcluirB});
            this.mnuExcluir.Name = "mnuExcluir";
            this.mnuExcluir.Size = new System.Drawing.Size(176, 22);
            this.mnuExcluir.Text = "Excluir";
            // 
            // mnuExcluirB
            // 
            this.mnuExcluirB.Name = "mnuExcluirB";
            this.mnuExcluirB.Size = new System.Drawing.Size(108, 22);
            this.mnuExcluirB.Text = "De B";
            this.mnuExcluirB.Click += new System.EventHandler(this.mnuExcluirB_Click);
            // 
            // mnuOpen
            // 
            this.mnuOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenA,
            this.mnuOpenB});
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(176, 22);
            this.mnuOpen.Text = "Abrir";
            // 
            // mnuOpenA
            // 
            this.mnuOpenA.Name = "mnuOpenA";
            this.mnuOpenA.Size = new System.Drawing.Size(136, 22);
            this.mnuOpenA.Text = "Diretório A";
            this.mnuOpenA.Click += new System.EventHandler(this.mnuOpenA_Click);
            // 
            // mnuOpenB
            // 
            this.mnuOpenB.Name = "mnuOpenB";
            this.mnuOpenB.Size = new System.Drawing.Size(136, 22);
            this.mnuOpenB.Text = "Diretório B";
            this.mnuOpenB.Click += new System.EventHandler(this.mnuOpenB_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // mnuHistorico
            // 
            this.mnuHistorico.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHistoricoA,
            this.mnuHistoricoB});
            this.mnuHistorico.Name = "mnuHistorico";
            this.mnuHistorico.Size = new System.Drawing.Size(176, 22);
            this.mnuHistorico.Text = "Histórico";
            // 
            // mnuHistoricoA
            // 
            this.mnuHistoricoA.Name = "mnuHistoricoA";
            this.mnuHistoricoA.Size = new System.Drawing.Size(136, 22);
            this.mnuHistoricoA.Text = "Histórico A";
            this.mnuHistoricoA.Click += new System.EventHandler(this.mnuHistoricoA_Click);
            // 
            // mnuHistoricoB
            // 
            this.mnuHistoricoB.Name = "mnuHistoricoB";
            this.mnuHistoricoB.Size = new System.Drawing.Size(136, 22);
            this.mnuHistoricoB.Text = "Histórico B";
            this.mnuHistoricoB.Click += new System.EventHandler(this.mnuHistoricoB_Click);
            // 
            // imageListIcons
            // 
            this.imageListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIcons.ImageStream")));
            this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListIcons.Images.SetKeyName(0, "file.ico");
            this.imageListIcons.Images.SetKeyName(1, "fileleet.ico");
            this.imageListIcons.Images.SetKeyName(2, "FileStar.ico");
            this.imageListIcons.Images.SetKeyName(3, "fileerror.ico");
            this.imageListIcons.Images.SetKeyName(4, "fileok.ico");
            this.imageListIcons.Images.SetKeyName(5, "folder.ico");
            this.imageListIcons.Images.SetKeyName(6, "foldercheckout.ico");
            this.imageListIcons.Images.SetKeyName(7, "filecheckout.ico");
            this.imageListIcons.Images.SetKeyName(8, "filehijacked.ico");
            this.imageListIcons.Images.SetKeyName(9, "folderleft.ico");
            this.imageListIcons.Images.SetKeyName(10, "folderright.ico");
            this.imageListIcons.Images.SetKeyName(11, "folderdiff.ico");
            this.imageListIcons.Images.SetKeyName(12, "fileright.ico");
            this.imageListIcons.Images.SetKeyName(13, "fileleft.ico");
            this.imageListIcons.Images.SetKeyName(14, "star.ico");
            this.imageListIcons.Images.SetKeyName(15, "folderdenied.ico");
            // 
            // treePanel
            // 
            this.treePanel.Controls.Add(this.chkShowCheckBox);
            this.treePanel.Controls.Add(this.treeViewDiff);
            this.treePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePanel.Location = new System.Drawing.Point(0, 81);
            this.treePanel.Name = "treePanel";
            this.treePanel.Size = new System.Drawing.Size(668, 368);
            this.treePanel.TabIndex = 3;
            // 
            // chkShowCheckBox
            // 
            this.chkShowCheckBox.AutoSize = true;
            this.chkShowCheckBox.Location = new System.Drawing.Point(12, 5);
            this.chkShowCheckBox.Name = "chkShowCheckBox";
            this.chkShowCheckBox.Size = new System.Drawing.Size(211, 17);
            this.chkShowCheckBox.TabIndex = 1;
            this.chkShowCheckBox.Text = "Permitir Selecionar Arquivos para Cópia";
            this.chkShowCheckBox.UseVisualStyleBackColor = true;
            this.chkShowCheckBox.CheckedChanged += new System.EventHandler(this.chkShowCheckBox_CheckedChanged);
            // 
            // treeViewDiff
            // 
            this.treeViewDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewDiff.Config = null;
            //this.treeViewDiff.FNodeTypeCounter = null;
            this.treeViewDiff.Location = new System.Drawing.Point(10, 28);
            this.treeViewDiff.Name = "treeViewDiff";
            this.treeViewDiff.Size = new System.Drawing.Size(648, 306);
            this.treeViewDiff.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picInvert);
            this.panel1.Controls.Add(this.picFileB);
            this.panel1.Controls.Add(this.picFileA);
            this.panel1.Controls.Add(this.toolMenu);
            this.panel1.Controls.Add(this.btnCompare);
            this.panel1.Controls.Add(this.btnDirectoryB);
            this.panel1.Controls.Add(this.txtDirectoryB);
            this.panel1.Controls.Add(this.btnDirectoryA);
            this.panel1.Controls.Add(this.txtDirectoryA);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 81);
            this.panel1.TabIndex = 2;
            // 
            // picInvert
            // 
            this.picInvert.Image = global::Itau.DirectoryDiff.Properties.Resources.imginvert;
            this.picInvert.Location = new System.Drawing.Point(3, 39);
            this.picInvert.Name = "picInvert";
            this.picInvert.Size = new System.Drawing.Size(18, 18);
            this.picInvert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picInvert.TabIndex = 9;
            this.picInvert.TabStop = false;
            this.picInvert.Click += new System.EventHandler(this.picInvert_Click);
            // 
            // picFileB
            // 
            this.picFileB.Image = global::Itau.DirectoryDiff.Properties.Resources.fileB;
            this.picFileB.Location = new System.Drawing.Point(24, 53);
            this.picFileB.Name = "picFileB";
            this.picFileB.Size = new System.Drawing.Size(16, 16);
            this.picFileB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFileB.TabIndex = 8;
            this.picFileB.TabStop = false;
            // 
            // picFileA
            // 
            this.picFileA.Image = global::Itau.DirectoryDiff.Properties.Resources.fileA;
            this.picFileA.Location = new System.Drawing.Point(24, 28);
            this.picFileA.Name = "picFileA";
            this.picFileA.Size = new System.Drawing.Size(16, 16);
            this.picFileA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFileA.TabIndex = 7;
            this.picFileA.TabStop = false;
            // 
            // toolMenu
            // 
            this.toolMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnNovo,
            this.toolbtnCopy,
            this.toolbtnFiltro,
            this.toolbtnPrint,
            this.toolbtnSair});
            this.toolMenu.Location = new System.Drawing.Point(0, 0);
            this.toolMenu.Name = "toolMenu";
            this.toolMenu.Size = new System.Drawing.Size(668, 25);
            this.toolMenu.TabIndex = 6;
            this.toolMenu.Text = "toolStrip1";
            // 
            // toolbtnNovo
            // 
            this.toolbtnNovo.Image = global::Itau.DirectoryDiff.Properties.Resources._new;
            this.toolbtnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnNovo.Name = "toolbtnNovo";
            this.toolbtnNovo.Size = new System.Drawing.Size(52, 22);
            this.toolbtnNovo.Text = "Novo";
            this.toolbtnNovo.Click += new System.EventHandler(this.toolbtnNovo_Click);
            // 
            // toolbtnCopy
            // 
            this.toolbtnCopy.Image = global::Itau.DirectoryDiff.Properties.Resources.copy;
            this.toolbtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnCopy.Name = "toolbtnCopy";
            this.toolbtnCopy.Size = new System.Drawing.Size(103, 22);
            this.toolbtnCopy.Text = "Copiar Arquivos";
            this.toolbtnCopy.Click += new System.EventHandler(this.toolbtnCopy_Click);
            // 
            // toolbtnFiltro
            // 
            this.toolbtnFiltro.Image = global::Itau.DirectoryDiff.Properties.Resources.filter;
            this.toolbtnFiltro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnFiltro.Name = "toolbtnFiltro";
            this.toolbtnFiltro.Size = new System.Drawing.Size(56, 22);
            this.toolbtnFiltro.Text = "Filtros";
            this.toolbtnFiltro.Click += new System.EventHandler(this.toolbtnFiltro_Click);
            // 
            // toolbtnPrint
            // 
            this.toolbtnPrint.Image = global::Itau.DirectoryDiff.Properties.Resources.print;
            this.toolbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnPrint.Name = "toolbtnPrint";
            this.toolbtnPrint.Size = new System.Drawing.Size(65, 22);
            this.toolbtnPrint.Text = "Imprimir";
            this.toolbtnPrint.Click += new System.EventHandler(this.toolbtnPrint_Click);
            // 
            // toolbtnSair
            // 
            this.toolbtnSair.Image = global::Itau.DirectoryDiff.Properties.Resources.close;
            this.toolbtnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnSair.Name = "toolbtnSair";
            this.toolbtnSair.Size = new System.Drawing.Size(45, 22);
            this.toolbtnSair.Text = "Sair";
            this.toolbtnSair.Click += new System.EventHandler(this.toolbtnSair_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompare.Image = global::Itau.DirectoryDiff.Properties.Resources.Sync;
            this.btnCompare.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCompare.Location = new System.Drawing.Point(583, 25);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(73, 53);
            this.btnCompare.TabIndex = 5;
            this.btnCompare.Text = "Comparar";
            this.btnCompare.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnDirectoryB
            // 
            this.btnDirectoryB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirectoryB.Location = new System.Drawing.Point(547, 52);
            this.btnDirectoryB.Name = "btnDirectoryB";
            this.btnDirectoryB.Size = new System.Drawing.Size(30, 21);
            this.btnDirectoryB.TabIndex = 4;
            this.btnDirectoryB.Text = "...";
            this.btnDirectoryB.Click += new System.EventHandler(this.btnDirectoryB_Click);
            // 
            // txtDirectoryB
            // 
            this.txtDirectoryB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectoryB.Location = new System.Drawing.Point(43, 53);
            this.txtDirectoryB.Name = "txtDirectoryB";
            this.txtDirectoryB.Size = new System.Drawing.Size(498, 20);
            this.txtDirectoryB.TabIndex = 3;
            this.txtDirectoryB.Enter += new System.EventHandler(this.txtDirectoryB_Enter);
            // 
            // btnDirectoryA
            // 
            this.btnDirectoryA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirectoryA.Location = new System.Drawing.Point(547, 27);
            this.btnDirectoryA.Name = "btnDirectoryA";
            this.btnDirectoryA.Size = new System.Drawing.Size(30, 21);
            this.btnDirectoryA.TabIndex = 2;
            this.btnDirectoryA.Text = "...";
            this.btnDirectoryA.Click += new System.EventHandler(this.btnDirectoryA_Click);
            // 
            // txtDirectoryA
            // 
            this.txtDirectoryA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectoryA.Location = new System.Drawing.Point(43, 27);
            this.txtDirectoryA.Name = "txtDirectoryA";
            this.txtDirectoryA.Size = new System.Drawing.Size(498, 20);
            this.txtDirectoryA.TabIndex = 0;
            this.txtDirectoryA.Enter += new System.EventHandler(this.txtDirectoryA_Enter);
            // 
            // statusFiles
            // 
            this.statusFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusDifferent,
            this.toolStripStatusLeftOnlyFolder,
            this.toolStripStatusLeftOnly,
            this.toolStripStatusRightOnlyFolder,
            this.toolStripStatusRightOnly,
            this.toolStripStatusEqual,
            this.toolStripVersao});
            this.statusFiles.Location = new System.Drawing.Point(0, 427);
            this.statusFiles.Name = "statusFiles";
            this.statusFiles.Size = new System.Drawing.Size(668, 22);
            this.statusFiles.TabIndex = 10;
            // 
            // toolStripStatusDifferent
            // 
            this.toolStripStatusDifferent.Image = global::Itau.DirectoryDiff.Properties.Resources._new;
            this.toolStripStatusDifferent.Name = "toolStripStatusDifferent";
            this.toolStripStatusDifferent.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusDifferent.Text = "Divergentes";
            // 
            // toolStripStatusLeftOnlyFolder
            // 
            this.toolStripStatusLeftOnlyFolder.Image = global::Itau.DirectoryDiff.Properties.Resources._new;
            this.toolStripStatusLeftOnlyFolder.Name = "toolStripStatusLeftOnlyFolder";
            this.toolStripStatusLeftOnlyFolder.Size = new System.Drawing.Size(92, 17);
            this.toolStripStatusLeftOnlyFolder.Text = "Somente em A";
            // 
            // toolStripStatusLeftOnly
            // 
            this.toolStripStatusLeftOnly.Image = global::Itau.DirectoryDiff.Properties.Resources._new;
            this.toolStripStatusLeftOnly.Name = "toolStripStatusLeftOnly";
            this.toolStripStatusLeftOnly.Size = new System.Drawing.Size(92, 17);
            this.toolStripStatusLeftOnly.Text = "Somente em A";
            // 
            // toolStripStatusRightOnlyFolder
            // 
            this.toolStripStatusRightOnlyFolder.Image = global::Itau.DirectoryDiff.Properties.Resources._new;
            this.toolStripStatusRightOnlyFolder.Name = "toolStripStatusRightOnlyFolder";
            this.toolStripStatusRightOnlyFolder.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusRightOnlyFolder.Text = "Somente em B";
            // 
            // toolStripStatusRightOnly
            // 
            this.toolStripStatusRightOnly.Image = global::Itau.DirectoryDiff.Properties.Resources._new;
            this.toolStripStatusRightOnly.Name = "toolStripStatusRightOnly";
            this.toolStripStatusRightOnly.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusRightOnly.Text = "Somente em B";
            // 
            // toolStripStatusEqual
            // 
            this.toolStripStatusEqual.Image = global::Itau.DirectoryDiff.Properties.Resources._new;
            this.toolStripStatusEqual.Name = "toolStripStatusEqual";
            this.toolStripStatusEqual.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusEqual.Text = "Idênticos";
            // 
            // toolStripVersao
            // 
            this.toolStripVersao.Name = "toolStripVersao";
            this.toolStripVersao.Size = new System.Drawing.Size(44, 17);
            this.toolStripVersao.Text = "Versão:";
            // 
            // FormDiffTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 449);
            this.Controls.Add(this.statusFiles);
            this.Controls.Add(this.treePanel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDiffTree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Directory Diff";
            this.Load += new System.EventHandler(this.FormDiffTree_Load);
            this.mnuTreeView.ResumeLayout(false);
            this.treePanel.ResumeLayout(false);
            this.treePanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInvert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFileB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFileA)).EndInit();
            this.toolMenu.ResumeLayout(false);
            this.toolMenu.PerformLayout();
            this.statusFiles.ResumeLayout(false);
            this.statusFiles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mnuExcluirA;
        private System.Windows.Forms.ToolStripMenuItem mnuDiferencas;
        private System.Windows.Forms.ContextMenuStrip mnuTreeView;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyPath;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyPathA;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyPathB;
        private System.Windows.Forms.ToolStripMenuItem mnuHistorico;
        private System.Windows.Forms.ToolStripMenuItem mnuHistoricoA;
        private System.Windows.Forms.ToolStripMenuItem mnuHistoricoB;
        private System.Windows.Forms.ToolStripMenuItem mnuExcluir;
        private System.Windows.Forms.ToolStripMenuItem mnuExcluirB;
        private System.Windows.Forms.ImageList imageListIcons;
        private System.Windows.Forms.Panel treePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picFileB;
        private System.Windows.Forms.PictureBox picFileA;
        private System.Windows.Forms.ToolStrip toolMenu;
        private System.Windows.Forms.ToolStripButton toolbtnCopy;
        private System.Windows.Forms.ToolStripButton toolbtnFiltro;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnDirectoryB;
        private System.Windows.Forms.TextBox txtDirectoryB;
        private System.Windows.Forms.Button btnDirectoryA;
        private System.Windows.Forms.TextBox txtDirectoryA;
        private Itau.TreeFileViewer.FileSystemTreeView treeViewDiff;
        private System.Windows.Forms.ToolStripButton toolbtnSair;
        private System.Windows.Forms.ToolStripButton toolbtnNovo;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenA;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenB;
        private System.Windows.Forms.ToolStripButton toolbtnPrint;
        private System.Windows.Forms.StatusStrip statusFiles;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusDifferent;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusEqual;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLeftOnly;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusRightOnly;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLeftOnlyFolder;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusRightOnlyFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.CheckBox chkShowCheckBox;
        private System.Windows.Forms.PictureBox picInvert;
        private System.Windows.Forms.ToolStripStatusLabel toolStripVersao;
    }
}


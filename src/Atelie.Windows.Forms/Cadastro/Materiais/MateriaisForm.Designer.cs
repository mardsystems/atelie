namespace Atelie.Cadastro.Materiais
{
    partial class MateriaisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MateriaisForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recortarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.selecionarTudoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barraDeFerramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barraDeStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialDataGridView = new System.Windows.Forms.DataGridView();
            this.componentesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mainToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.materiaisToolStrip = new System.Windows.Forms.ToolStrip();
            this.novoMaterialToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editModeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusBarTimer = new System.Windows.Forms.Timer(this.components);
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.componenteUnidadePadraoSigla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.componenteDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Cor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tamanho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadeSigla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.componenteDataGridViewLinkColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.fabricanteDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.fabricanteDataGridViewLinkColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fabricanteSiteDataGridViewLinkColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialBindingSource)).BeginInit();
            this.mainStatusStrip.SuspendLayout();
            this.materiaisToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.visualizarToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(784, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoMaterialToolStripMenuItem,
            this.toolStripSeparator1,
            this.fecharToolStripMenuItem});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // novoMaterialToolStripMenuItem
            // 
            this.novoMaterialToolStripMenuItem.Name = "novoMaterialToolStripMenuItem";
            this.novoMaterialToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.novoMaterialToolStripMenuItem.Text = "Novo Material ...";
            this.novoMaterialToolStripMenuItem.Click += new System.EventHandler(this.NovoMaterialToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.fecharToolStripMenuItem.Text = "Fechar";
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recortarToolStripMenuItem,
            this.copiarToolStripMenuItem,
            this.colarToolStripMenuItem,
            this.excluirToolStripMenuItem,
            this.toolStripMenuItem1,
            this.selecionarTudoToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // recortarToolStripMenuItem
            // 
            this.recortarToolStripMenuItem.Name = "recortarToolStripMenuItem";
            this.recortarToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.recortarToolStripMenuItem.Text = "Recortar";
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.copiarToolStripMenuItem.Text = "Copiar";
            // 
            // colarToolStripMenuItem
            // 
            this.colarToolStripMenuItem.Name = "colarToolStripMenuItem";
            this.colarToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.colarToolStripMenuItem.Text = "Colar";
            // 
            // excluirToolStripMenuItem
            // 
            this.excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            this.excluirToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.excluirToolStripMenuItem.Text = "Excluir";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(156, 6);
            // 
            // selecionarTudoToolStripMenuItem
            // 
            this.selecionarTudoToolStripMenuItem.Name = "selecionarTudoToolStripMenuItem";
            this.selecionarTudoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.selecionarTudoToolStripMenuItem.Text = "Selecionar Tudo";
            // 
            // visualizarToolStripMenuItem
            // 
            this.visualizarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barraDeFerramentasToolStripMenuItem,
            this.barraDeStatusToolStripMenuItem});
            this.visualizarToolStripMenuItem.Name = "visualizarToolStripMenuItem";
            this.visualizarToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.visualizarToolStripMenuItem.Text = "Visualizar";
            // 
            // barraDeFerramentasToolStripMenuItem
            // 
            this.barraDeFerramentasToolStripMenuItem.CheckOnClick = true;
            this.barraDeFerramentasToolStripMenuItem.Name = "barraDeFerramentasToolStripMenuItem";
            this.barraDeFerramentasToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.barraDeFerramentasToolStripMenuItem.Text = "Barra de Ferramentas";
            // 
            // barraDeStatusToolStripMenuItem
            // 
            this.barraDeStatusToolStripMenuItem.CheckOnClick = true;
            this.barraDeStatusToolStripMenuItem.Name = "barraDeStatusToolStripMenuItem";
            this.barraDeStatusToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.barraDeStatusToolStripMenuItem.Text = "Barra de Status";
            // 
            // materialDataGridView
            // 
            this.materialDataGridView.AllowUserToOrderColumns = true;
            this.materialDataGridView.AutoGenerateColumns = false;
            this.materialDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.state,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.componenteUnidadePadraoSigla,
            this.componenteDataGridViewComboBoxColumn,
            this.Cor,
            this.Tamanho,
            this.UnidadeSigla,
            this.componenteDataGridViewLinkColumn,
            this.fabricanteDataGridViewComboBoxColumn,
            this.fabricanteDataGridViewLinkColumn,
            this.dataGridViewTextBoxColumn11,
            this.fabricanteSiteDataGridViewLinkColumn});
            this.materialDataGridView.DataSource = this.materialBindingSource;
            this.materialDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialDataGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.materialDataGridView.Location = new System.Drawing.Point(0, 49);
            this.materialDataGridView.Name = "materialDataGridView";
            this.materialDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(220)))), ((int)(((byte)(244)))));
            this.materialDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.materialDataGridView.Size = new System.Drawing.Size(784, 490);
            this.materialDataGridView.TabIndex = 0;
            this.materialDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MaterialDataGridView_CellClick);
            this.materialDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MaterialDataGridView_CellContentClick);
            this.materialDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MaterialDataGridView_CellMouseDoubleClick);
            this.materialDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.MaterialDataGridView_DataError);
            this.materialDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.MaterialDataGridView_RowsAdded);
            // 
            // componentesBindingSource
            // 
            this.componentesBindingSource.DataSource = typeof(Atelie.Cadastro.Materiais.Componentes.ComponenteViewModel);
            // 
            // materialBindingSource
            // 
            this.materialBindingSource.AllowNew = true;
            this.materialBindingSource.DataSource = typeof(Atelie.Cadastro.Materiais.MaterialViewModel);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripStatusLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 539);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(784, 22);
            this.mainStatusStrip.TabIndex = 2;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // mainToolStripStatusLabel
            // 
            this.mainToolStripStatusLabel.Name = "mainToolStripStatusLabel";
            this.mainToolStripStatusLabel.Size = new System.Drawing.Size(46, 17);
            this.mainToolStripStatusLabel.Text = "Pronto.";
            // 
            // materiaisToolStrip
            // 
            this.materiaisToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoMaterialToolStripButton,
            this.toolStripSeparator2,
            this.editModeToolStripButton,
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator3,
            this.helpToolStripButton,
            this.toolStripButton1});
            this.materiaisToolStrip.Location = new System.Drawing.Point(0, 24);
            this.materiaisToolStrip.Name = "materiaisToolStrip";
            this.materiaisToolStrip.Size = new System.Drawing.Size(784, 25);
            this.materiaisToolStrip.TabIndex = 3;
            this.materiaisToolStrip.Text = "toolStrip1";
            // 
            // novoMaterialToolStripButton
            // 
            this.novoMaterialToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("novoMaterialToolStripButton.Image")));
            this.novoMaterialToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.novoMaterialToolStripButton.Name = "novoMaterialToolStripButton";
            this.novoMaterialToolStripButton.Size = new System.Drawing.Size(102, 22);
            this.novoMaterialToolStripButton.Text = "Novo Material";
            this.novoMaterialToolStripButton.Click += new System.EventHandler(this.NovoMaterialToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // editModeToolStripButton
            // 
            this.editModeToolStripButton.CheckOnClick = true;
            this.editModeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editModeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("editModeToolStripButton.Image")));
            this.editModeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editModeToolStripButton.Name = "editModeToolStripButton";
            this.editModeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.editModeToolStripButton.Text = "toolStripButton2";
            this.editModeToolStripButton.CheckedChanged += new System.EventHandler(this.EditModeToolStripButton_CheckedChanged);
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButton_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Print";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton.Text = "C&ut";
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "&Copy";
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "&Paste";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "deleteToolStripButton";
            this.toolStripButton1.Click += new System.EventHandler(this.DeleteToolStripButton_Click);
            // 
            // statusBarTimer
            // 
            this.statusBarTimer.Interval = 5000;
            this.statusBarTimer.Tick += new System.EventHandler(this.StatusBarTimer_Tick);
            // 
            // state
            // 
            this.state.DataPropertyName = "State";
            this.state.HeaderText = "State";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nome";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nome";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // componenteUnidadePadraoSigla
            // 
            this.componenteUnidadePadraoSigla.DataPropertyName = "ComponenteUnidadePadraoSigla";
            this.componenteUnidadePadraoSigla.HeaderText = "Unid. Padrão";
            this.componenteUnidadePadraoSigla.Name = "componenteUnidadePadraoSigla";
            // 
            // componenteDataGridViewComboBoxColumn
            // 
            this.componenteDataGridViewComboBoxColumn.DataPropertyName = "ComponenteId";
            this.componenteDataGridViewComboBoxColumn.DataSource = this.componentesBindingSource;
            this.componenteDataGridViewComboBoxColumn.DisplayMember = "Nome";
            this.componenteDataGridViewComboBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.componenteDataGridViewComboBoxColumn.DisplayStyleForCurrentCellOnly = true;
            this.componenteDataGridViewComboBoxColumn.HeaderText = "Componente";
            this.componenteDataGridViewComboBoxColumn.Name = "componenteDataGridViewComboBoxColumn";
            this.componenteDataGridViewComboBoxColumn.ValueMember = "Id";
            this.componenteDataGridViewComboBoxColumn.Width = 120;
            // 
            // Cor
            // 
            this.Cor.DataPropertyName = "Cor";
            this.Cor.HeaderText = "Cor";
            this.Cor.Name = "Cor";
            // 
            // Tamanho
            // 
            this.Tamanho.DataPropertyName = "Tamanho";
            this.Tamanho.HeaderText = "Tamanho";
            this.Tamanho.Name = "Tamanho";
            // 
            // UnidadeSigla
            // 
            this.UnidadeSigla.DataPropertyName = "UnidadeSigla";
            this.UnidadeSigla.HeaderText = "Unidade";
            this.UnidadeSigla.Name = "UnidadeSigla";
            // 
            // componenteDataGridViewLinkColumn
            // 
            this.componenteDataGridViewLinkColumn.DataPropertyName = "ComponenteNome";
            this.componenteDataGridViewLinkColumn.HeaderText = "Componente";
            this.componenteDataGridViewLinkColumn.Name = "componenteDataGridViewLinkColumn";
            this.componenteDataGridViewLinkColumn.ReadOnly = true;
            this.componenteDataGridViewLinkColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.componenteDataGridViewLinkColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.componenteDataGridViewLinkColumn.Width = 120;
            // 
            // fabricanteDataGridViewComboBoxColumn
            // 
            this.fabricanteDataGridViewComboBoxColumn.DataPropertyName = "FabricanteId";
            this.fabricanteDataGridViewComboBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.fabricanteDataGridViewComboBoxColumn.DisplayStyleForCurrentCellOnly = true;
            this.fabricanteDataGridViewComboBoxColumn.HeaderText = "Fabricante";
            this.fabricanteDataGridViewComboBoxColumn.Name = "fabricanteDataGridViewComboBoxColumn";
            this.fabricanteDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fabricanteDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fabricanteDataGridViewComboBoxColumn.Width = 120;
            // 
            // fabricanteDataGridViewLinkColumn
            // 
            this.fabricanteDataGridViewLinkColumn.DataPropertyName = "FabricanteNome";
            this.fabricanteDataGridViewLinkColumn.HeaderText = "Fabricante";
            this.fabricanteDataGridViewLinkColumn.Name = "fabricanteDataGridViewLinkColumn";
            this.fabricanteDataGridViewLinkColumn.ReadOnly = true;
            this.fabricanteDataGridViewLinkColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fabricanteDataGridViewLinkColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fabricanteDataGridViewLinkColumn.Width = 120;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "FabricanteMarca";
            this.dataGridViewTextBoxColumn11.HeaderText = "Marca";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // fabricanteSiteDataGridViewLinkColumn
            // 
            this.fabricanteSiteDataGridViewLinkColumn.DataPropertyName = "FabricanteSite";
            this.fabricanteSiteDataGridViewLinkColumn.HeaderText = "Site do Fabricante";
            this.fabricanteSiteDataGridViewLinkColumn.Name = "fabricanteSiteDataGridViewLinkColumn";
            this.fabricanteSiteDataGridViewLinkColumn.ReadOnly = true;
            this.fabricanteSiteDataGridViewLinkColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fabricanteSiteDataGridViewLinkColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fabricanteSiteDataGridViewLinkColumn.Width = 200;
            // 
            // MateriaisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.materialDataGridView);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.materiaisToolStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MateriaisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Materiais";
            this.Load += new System.EventHandler(this.MateriaisForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialBindingSource)).EndInit();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.materiaisToolStrip.ResumeLayout(false);
            this.materiaisToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.DataGridView materialDataGridView;
        private System.Windows.Forms.BindingSource materialBindingSource;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoMaterialToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel mainToolStripStatusLabel;
        private System.Windows.Forms.ToolStrip materiaisToolStrip;
        private System.Windows.Forms.ToolStripButton novoMaterialToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton editModeToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem recortarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selecionarTudoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barraDeFerramentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barraDeStatusToolStripMenuItem;
        private System.Windows.Forms.Timer statusBarTimer;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.BindingSource componentesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn componenteUnidadePadraoSigla;
        private System.Windows.Forms.DataGridViewComboBoxColumn componenteDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tamanho;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadeSigla;
        private System.Windows.Forms.DataGridViewLinkColumn componenteDataGridViewLinkColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn fabricanteDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn fabricanteDataGridViewLinkColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewLinkColumn fabricanteSiteDataGridViewLinkColumn;
    }
}
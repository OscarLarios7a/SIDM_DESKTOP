namespace gsBuscar_cs
{
    partial class Form1
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
            if(disposing && (components != null))
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
            this.chkIgnorarError = new System.Windows.Forms.CheckBox();
            this.LabelInfo = new System.Windows.Forms.Label();
            this.lvFics = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.chkConSubDir = new System.Windows.Forms.CheckBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnAbrirDir = new System.Windows.Forms.Button();
            this.btnAbrirFic = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.familia_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entrevis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario_captura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_captura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtes_entr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.archivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CVE_MUN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CVE_LOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aVANCESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rECERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEEVAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vPCSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEEVALUACIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // chkIgnorarError
            // 
            this.chkIgnorarError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIgnorarError.AutoSize = true;
            this.chkIgnorarError.Checked = true;
            this.chkIgnorarError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnorarError.Location = new System.Drawing.Point(546, 66);
            this.chkIgnorarError.Name = "chkIgnorarError";
            this.chkIgnorarError.Size = new System.Drawing.Size(147, 17);
            this.chkIgnorarError.TabIndex = 6;
            this.chkIgnorarError.Text = "Ignorar los avisos de error";
            this.chkIgnorarError.UseVisualStyleBackColor = true;
            // 
            // LabelInfo
            // 
            this.LabelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelInfo.Location = new System.Drawing.Point(15, 584);
            this.LabelInfo.Margin = new System.Windows.Forms.Padding(3);
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Size = new System.Drawing.Size(864, 20);
            this.LabelInfo.TabIndex = 11;
            this.LabelInfo.Text = "LableInfo";
            // 
            // lvFics
            // 
            this.lvFics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lvFics.Enabled = false;
            this.lvFics.FullRowSelect = true;
            this.lvFics.GridLines = true;
            this.lvFics.HideSelection = false;
            this.lvFics.Location = new System.Drawing.Point(32, 74);
            this.lvFics.Name = "lvFics";
            this.lvFics.Size = new System.Drawing.Size(18, 12);
            this.lvFics.TabIndex = 8;
            this.lvFics.UseCompatibleStateImageBehavior = false;
            this.lvFics.View = System.Windows.Forms.View.Details;
            this.lvFics.Visible = false;
            this.lvFics.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvFics_MouseDoubleClick);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Nombre";
            this.ColumnHeader1.Width = 210;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Directorio";
            this.ColumnHeader2.Width = 180;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Location = new System.Drawing.Point(699, 37);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // chkConSubDir
            // 
            this.chkConSubDir.AutoSize = true;
            this.chkConSubDir.Checked = true;
            this.chkConSubDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConSubDir.Location = new System.Drawing.Point(109, 66);
            this.chkConSubDir.Name = "chkConSubDir";
            this.chkConSubDir.Size = new System.Drawing.Size(122, 17);
            this.chkConSubDir.TabIndex = 5;
            this.chkConSubDir.Text = "Incluir subdirectorios";
            this.toolTip1.SetToolTip(this.chkConSubDir, "Si se debe buscar también en los directorios que haya en el directorio indicado");
            this.chkConSubDir.UseVisualStyleBackColor = true;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltro.Enabled = false;
            this.txtFiltro.Location = new System.Drawing.Point(109, 11);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(584, 20);
            this.txtFiltro.TabIndex = 1;
            this.txtFiltro.Text = "*.SDF";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(3, 14);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(100, 16);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Filtro búsqueda:";
            this.toolTip1.SetToolTip(this.Label2, "Filtro o especificación para la búsqueda (por ej. *.txt)");
            // 
            // btnExaminar
            // 
            this.btnExaminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExaminar.Location = new System.Drawing.Point(699, 11);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(75, 23);
            this.btnExaminar.TabIndex = 4;
            this.btnExaminar.Text = "Examinar...";
            this.toolTip1.SetToolTip(this.btnExaminar, "Seleccionar el directorio en el que se empezará la búsqueda");
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // txtDir
            // 
            this.txtDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDir.Enabled = false;
            this.txtDir.Location = new System.Drawing.Point(109, 37);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(584, 20);
            this.txtDir.TabIndex = 3;
            this.txtDir.Text = "C:\\";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(3, 40);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 16);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Directorio:";
            this.toolTip1.SetToolTip(this.Label1, "Directorio en el que se iniciará la búsqueda");
            // 
            // btnAbrirDir
            // 
            this.btnAbrirDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbrirDir.Enabled = false;
            this.btnAbrirDir.Location = new System.Drawing.Point(112, 581);
            this.btnAbrirDir.Name = "btnAbrirDir";
            this.btnAbrirDir.Size = new System.Drawing.Size(90, 23);
            this.btnAbrirDir.TabIndex = 10;
            this.btnAbrirDir.Text = "Abrir directorio";
            this.toolTip1.SetToolTip(this.btnAbrirDir, "Abrir la carpeta del fichero seleccionado");
            this.btnAbrirDir.UseVisualStyleBackColor = true;
            this.btnAbrirDir.Visible = false;
            this.btnAbrirDir.Click += new System.EventHandler(this.btnAbrirDir_Click);
            // 
            // btnAbrirFic
            // 
            this.btnAbrirFic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbrirFic.Enabled = false;
            this.btnAbrirFic.Location = new System.Drawing.Point(16, 580);
            this.btnAbrirFic.Name = "btnAbrirFic";
            this.btnAbrirFic.Size = new System.Drawing.Size(90, 23);
            this.btnAbrirFic.TabIndex = 9;
            this.btnAbrirFic.Text = "Abrir fichero";
            this.toolTip1.SetToolTip(this.btnAbrirFic, "Abrir el fichero seleccionado con el programa que tenga asociado");
            this.btnAbrirFic.UseVisualStyleBackColor = true;
            this.btnAbrirFic.Visible = false;
            this.btnAbrirFic.Click += new System.EventHandler(this.btnAbrirFic_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(699, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Respaldar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(11, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(15, 12);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.familia_id,
            this.num_folio,
            this.entrevis,
            this.usuario_captura,
            this.fecha_captura,
            this.rtes_entr,
            this.archivo,
            this.CVE_MUN,
            this.CVE_LOC});
            this.dataGridView2.Enabled = false;
            this.dataGridView2.Location = new System.Drawing.Point(0, 312);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(867, 203);
            this.dataGridView2.TabIndex = 31;
            // 
            // familia_id
            // 
            this.familia_id.HeaderText = "FAMILIA_ID";
            this.familia_id.Name = "familia_id";
            // 
            // num_folio
            // 
            this.num_folio.HeaderText = "NUM_FOLIO";
            this.num_folio.Name = "num_folio";
            // 
            // entrevis
            // 
            this.entrevis.HeaderText = "ENTREVIS";
            this.entrevis.Name = "entrevis";
            // 
            // usuario_captura
            // 
            this.usuario_captura.HeaderText = "USUARIO_CAPTURA";
            this.usuario_captura.Name = "usuario_captura";
            // 
            // fecha_captura
            // 
            this.fecha_captura.HeaderText = "FECHA_CAPTURA";
            this.fecha_captura.Name = "fecha_captura";
            // 
            // rtes_entr
            // 
            this.rtes_entr.HeaderText = "RES_ENTR";
            this.rtes_entr.Name = "rtes_entr";
            // 
            // archivo
            // 
            this.archivo.HeaderText = "ARCHIVO";
            this.archivo.Name = "archivo";
            // 
            // CVE_MUN
            // 
            this.CVE_MUN.HeaderText = "CVE_MUN";
            this.CVE_MUN.Name = "CVE_MUN";
            // 
            // CVE_LOC
            // 
            this.CVE_LOC.HeaderText = "CVE_LOC";
            this.CVE_LOC.Name = "CVE_LOC";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(715, 540);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 32;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(634, 537);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 33;
            this.button4.Text = "UNIR BD";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFiltro);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.txtDir);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Controls.Add(this.chkConSubDir);
            this.panel1.Controls.Add(this.lvFics);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.chkIgnorarError);
            this.panel1.Controls.Add(this.btnExaminar);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Location = new System.Drawing.Point(29, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 106);
            this.panel1.TabIndex = 34;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aVANCESToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(902, 24);
            this.menuStrip1.TabIndex = 35;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aVANCESToolStripMenuItem
            // 
            this.aVANCESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rECERToolStripMenuItem,
            this.rEEVAToolStripMenuItem,
            this.vPCSToolStripMenuItem,
            this.rEEVALUACIONToolStripMenuItem});
            this.aVANCESToolStripMenuItem.Name = "aVANCESToolStripMenuItem";
            this.aVANCESToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.aVANCESToolStripMenuItem.Text = "AVANCES";
            // 
            // rECERToolStripMenuItem
            // 
            this.rECERToolStripMenuItem.Name = "rECERToolStripMenuItem";
            this.rECERToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.rECERToolStripMenuItem.Text = "IDENTIFICACION";
            this.rECERToolStripMenuItem.Click += new System.EventHandler(this.rECERToolStripMenuItem_Click);
            // 
            // rEEVAToolStripMenuItem
            // 
            this.rEEVAToolStripMenuItem.Name = "rEEVAToolStripMenuItem";
            this.rEEVAToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.rEEVAToolStripMenuItem.Text = "RECERTIFICACIÓN";
            this.rEEVAToolStripMenuItem.Click += new System.EventHandler(this.rEEVAToolStripMenuItem_Click);
            // 
            // vPCSToolStripMenuItem
            // 
            this.vPCSToolStripMenuItem.Name = "vPCSToolStripMenuItem";
            this.vPCSToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.vPCSToolStripMenuItem.Text = "VPCS";
            this.vPCSToolStripMenuItem.Click += new System.EventHandler(this.vPCSToolStripMenuItem_Click);
            // 
            // rEEVALUACIONToolStripMenuItem
            // 
            this.rEEVALUACIONToolStripMenuItem.Name = "rEEVALUACIONToolStripMenuItem";
            this.rEEVALUACIONToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.rEEVALUACIONToolStripMenuItem.Text = "REEVALUACION";
            this.rEEVALUACIONToolStripMenuItem.Click += new System.EventHandler(this.rEEVALUACIONToolStripMenuItem_Click);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = global::gsBuscar_cs.Properties.Resources.Excel;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.Location = new System.Drawing.Point(460, 508);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(63, 64);
            this.button5.TabIndex = 36;
            this.button5.Text = "I";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(15, 584);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(864, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "LableInfo";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(16, 581);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Abrir fichero";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.btnAbrirFic_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(112, 581);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Abrir directorio";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.btnAbrirDir_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dataGridView3.Enabled = false;
            this.dataGridView3.Location = new System.Drawing.Point(56, 74);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(17, 18);
            this.dataGridView3.TabIndex = 31;
            this.dataGridView3.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "FAMILIA_ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "NUM_FOLIO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ENTREVIS";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "USUARIO_CAPTURA";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "FECHA_CAPTURA";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "RES_ENTR";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "ARCHIVO";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(715, 510);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Controls.Add(this.dataGridView4);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.dataGridView3);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Location = new System.Drawing.Point(29, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 105);
            this.panel2.TabIndex = 34;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(109, 11);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(584, 20);
            this.textBox3.TabIndex = 1;
            this.textBox3.Text = "*.S3DB";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Directorio:";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(109, 39);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(584, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.Text = "C:\\";
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(699, 63);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "Respaldar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Filtro búsqueda:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(109, 66);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(122, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Incluir subdirectorios";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Enabled = false;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(32, 74);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(18, 11);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvFics_MouseDoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nombre";
            this.columnHeader3.Width = 210;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Directorio";
            this.columnHeader4.Width = 180;
            // 
            // dataGridView4
            // 
            this.dataGridView4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Enabled = false;
            this.dataGridView4.Location = new System.Drawing.Point(11, 74);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(15, 11);
            this.dataGridView4.TabIndex = 21;
            this.dataGridView4.Visible = false;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(546, 66);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(147, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Ignorar los avisos de error";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(699, 9);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 4;
            this.button7.Text = "Examinar...";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(699, 37);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 7;
            this.button8.Text = "Buscar";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(634, 508);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 33;
            this.button9.Text = "UNIR BD";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button4_Click);
            // 
            // button10
            // 
            this.button10.Enabled = false;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Image = global::gsBuscar_cs.Properties.Resources.Excel;
            this.button10.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button10.Location = new System.Drawing.Point(391, 508);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(63, 64);
            this.button10.TabIndex = 36;
            this.button10.Text = "I";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 615);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAbrirDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAbrirFic);
            this.Controls.Add(this.LabelInfo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Respaldar BD (SDF)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIgnorarError;
        private System.Windows.Forms.Label LabelInfo;
        private System.Windows.Forms.ListView lvFics;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.CheckBox chkConSubDir;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btnAbrirDir;
        private System.Windows.Forms.Button btnAbrirFic;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn familia_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn entrevis;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario_captura;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_captura;
        private System.Windows.Forms.DataGridViewTextBoxColumn rtes_entr;
        private System.Windows.Forms.DataGridViewTextBoxColumn archivo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aVANCESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rECERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEEVAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vPCSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEEVALUACIONToolStripMenuItem;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DataGridViewTextBoxColumn CVE_MUN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CVE_LOC;
    }
}


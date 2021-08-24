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
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
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
            this.SuspendLayout();
            // 
            // chkIgnorarError
            // 
            this.chkIgnorarError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIgnorarError.AutoSize = true;
            this.chkIgnorarError.Checked = true;
            this.chkIgnorarError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnorarError.Location = new System.Drawing.Point(279, 69);
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
            this.LabelInfo.Location = new System.Drawing.Point(12, 304);
            this.LabelInfo.Margin = new System.Windows.Forms.Padding(3);
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Size = new System.Drawing.Size(495, 20);
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
            this.lvFics.FullRowSelect = true;
            this.lvFics.GridLines = true;
            this.lvFics.HideSelection = false;
            this.lvFics.Location = new System.Drawing.Point(12, 94);
            this.lvFics.Name = "lvFics";
            this.lvFics.Size = new System.Drawing.Size(495, 175);
            this.lvFics.TabIndex = 8;
            this.lvFics.UseCompatibleStateImageBehavior = false;
            this.lvFics.View = System.Windows.Forms.View.Details;
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
            this.btnBuscar.Location = new System.Drawing.Point(432, 65);
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
            this.chkConSubDir.Location = new System.Drawing.Point(118, 69);
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
            this.txtFiltro.Location = new System.Drawing.Point(118, 12);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(308, 20);
            this.txtFiltro.TabIndex = 1;
            this.txtFiltro.Text = "*.*";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(12, 15);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(100, 16);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Filtro búsqueda:";
            this.toolTip1.SetToolTip(this.Label2, "Filtro o especificación para la búsqueda (por ej. *.txt)");
            // 
            // btnExaminar
            // 
            this.btnExaminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExaminar.Location = new System.Drawing.Point(432, 36);
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
            this.txtDir.Location = new System.Drawing.Point(118, 38);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(308, 20);
            this.txtDir.TabIndex = 3;
            this.txtDir.Text = "C:\\";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(12, 41);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 16);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Directorio:";
            this.toolTip1.SetToolTip(this.Label1, "Directorio en el que se iniciará la búsqueda");
            // 
            // btnAbrirDir
            // 
            this.btnAbrirDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbrirDir.Location = new System.Drawing.Point(108, 275);
            this.btnAbrirDir.Name = "btnAbrirDir";
            this.btnAbrirDir.Size = new System.Drawing.Size(90, 23);
            this.btnAbrirDir.TabIndex = 10;
            this.btnAbrirDir.Text = "Abrir directorio";
            this.toolTip1.SetToolTip(this.btnAbrirDir, "Abrir la carpeta del fichero seleccionado");
            this.btnAbrirDir.UseVisualStyleBackColor = true;
            this.btnAbrirDir.Click += new System.EventHandler(this.btnAbrirDir_Click);
            // 
            // btnAbrirFic
            // 
            this.btnAbrirFic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbrirFic.Location = new System.Drawing.Point(12, 275);
            this.btnAbrirFic.Name = "btnAbrirFic";
            this.btnAbrirFic.Size = new System.Drawing.Size(90, 23);
            this.btnAbrirFic.TabIndex = 9;
            this.btnAbrirFic.Text = "Abrir fichero";
            this.toolTip1.SetToolTip(this.btnAbrirFic, "Abrir el fichero seleccionado con el programa que tenga asociado");
            this.btnAbrirFic.UseVisualStyleBackColor = true;
            this.btnAbrirFic.Click += new System.EventHandler(this.btnAbrirFic_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 335);
            this.Controls.Add(this.btnAbrirDir);
            this.Controls.Add(this.btnAbrirFic);
            this.Controls.Add(this.chkIgnorarError);
            this.Controls.Add(this.LabelInfo);
            this.Controls.Add(this.lvFics);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.chkConSubDir);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.Label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Buscar ficheros en el directorio indicado (C#)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}


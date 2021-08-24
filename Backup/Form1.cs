
using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

namespace gsBuscar_cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        // Para simular la variable Static de VB
        private bool yaEstoy__1;

        private bool cancelar = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            if(My.Settings.Location.X > -1)
            {
                this.Location = My.Settings.Location;
                this.Size = My.Settings.Size;
            }
            this.txtDir.Text = My.Settings.Directorio;
            this.txtFiltro.Text = My.Settings.Filtro;
            this.chkConSubDir.Checked = My.Settings.conSubDir;
            this.chkIgnorarError.Checked = My.Settings.IgnorarError;
            this.LabelInfo.Text = My.Application.Info.Title + 
                                  " v" + My.Application.Info.Version.ToString() + 
                                  " - " + My.Application.Info.Copyright;

            this.btnAbrirDir.Enabled = false;
            this.btnAbrirFic.Enabled = false;
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog oFD = new FolderBrowserDialog();
            oFD.Description = "Seleccionar el directorio de búsqueda";
            oFD.RootFolder = Environment.SpecialFolder.MyComputer;
            oFD.SelectedPath = this.txtDir.Text;
            if(oFD.ShowDialog() == DialogResult.OK)
            {
                this.txtDir.Text = oFD.SelectedPath;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            // Buscar de forma recursiva (si es necesario)
            //*** era Static *** yaEstoy__1;

            if(yaEstoy__1)
            {
                cancelar = true;
                this.btnBuscar.Text = "Cancelando...";
                Application.DoEvents();
                return;
            }
            yaEstoy__1 = true;

            My.Settings.Location = this.Location;
            My.Settings.Size = this.Size;
            My.Settings.Directorio = this.txtDir.Text;
            My.Settings.Filtro = this.txtFiltro.Text;
            My.Settings.conSubDir = this.chkConSubDir.Checked;
            My.Settings.IgnorarError = this.chkIgnorarError.Checked;
            My.Settings.Save();

            DirectoryInfo di = new DirectoryInfo(My.Settings.Directorio);

            this.lvFics.Items.Clear();
            this.LabelInfo.Text = "Buscando los ficheros...";
            this.Cursor = Cursors.AppStarting;
            this.btnBuscar.Text = "Buscando...";
            this.Refresh();

            recorrerDir(di);

            this.Cursor = Cursors.Default;
            this.LabelInfo.Text = "Se han hallado " + this.lvFics.Items.Count + " ficheros";
            this.btnBuscar.Text = "Buscar";

            if(this.lvFics.Items.Count > 0)
            {
                this.btnAbrirDir.Enabled = true;
                this.btnAbrirFic.Enabled = true;
            }
            this.Refresh();

            cancelar = false;

            yaEstoy__1 = false;
        }

        private void recorrerDir(DirectoryInfo di)
        {
            // Recorrer los ficheros de este directorio
            // añadir al listview si se encuentra alguno
            FileInfo[] fics;
            DirectoryInfo[] dirs;

            Application.DoEvents();
            if(cancelar)
                return;

            this.LabelInfo.Text = di.FullName + "...";
            this.LabelInfo.Refresh();

            try
            {
                fics = di.GetFiles(My.Settings.Filtro, SearchOption.TopDirectoryOnly);
                foreach(FileInfo fi in fics)
                {
                    ListViewItem lvi = this.lvFics.Items.Add(fi.Name);
                    lvi.SubItems.Add(fi.DirectoryName);
                }
                //this.lvFics.Refresh();
                if(My.Settings.conSubDir)
                {
                    dirs = di.GetDirectories();
                    foreach(DirectoryInfo dir in dirs)
                    {
                        recorrerDir(dir);
                    }
                }
            }
            catch(Exception ex)
            {
                if(My.Settings.IgnorarError)
                {
                    return;
                }
                if(MessageBox.Show("Error: " + ex.Message + "\n" + 
                                   "¿Quieres cancelar o continuar?", 
                                   "Buscar en directorios", 
                                   MessageBoxButtons.OKCancel, 
                                   MessageBoxIcon.Exclamation
                                   ) == DialogResult.Cancel)
                {
                    cancelar = true;
                    Application.DoEvents();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                My.Settings.Location = this.Location;
                My.Settings.Size = this.Size;
            }
            else
            {
                My.Settings.Location = this.RestoreBounds.Location;
                My.Settings.Size = this.RestoreBounds.Size;
            }
            My.Settings.Save();
        }

        //private void lvFics_DoubleClick(object sender, EventArgs e)
        //{
        //    if(lvFics.SelectedIndices.Count > 0)
        //    {
        //        // Abrir la ventana con el directorio del fichero indicado
        //        string dir = lvFics.SelectedItems[0].SubItems[1].Text;
        //        Process.Start("explorer.exe", dir);
        //    }
        //}

        private void lvFics_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(lvFics.SelectedIndices.Count == 0)
            {
                return;
            }
            // Comprobar en que columna se ha hecho doble clic
            // El valor de e.X es relativo al control,
            // por tanto, no hace falta añadir nada más.
            if(e.X < lvFics.Columns[0].Width)
            {
                // El nombre

                // Abrir el fichero indicado
                // Combinar los paths para que se agregue el separador de directorio
                // si así hiciera falta
                string fic = Path.Combine(lvFics.SelectedItems[0].SubItems[1].Text, 
                                          lvFics.SelectedItems[0].SubItems[0].Text);
                Process.Start(fic);
            }
            else
            {
                // El directorio

                // Abrir la ventana con el directorio del fichero indicado
                string dir = lvFics.SelectedItems[0].SubItems[1].Text;
                Process.Start("explorer.exe", dir);
            }
        }

        private void btnAbrirFic_Click(object sender, EventArgs e)
        {
            if(lvFics.SelectedIndices.Count == 0)
            {
                return;
            }

            // Abrir el fichero indicado
            // Combinar los paths para que se agregue el separador de directorio
            // si así hiciera falta
            string fic = Path.Combine(lvFics.SelectedItems[0].SubItems[1].Text,
                                      lvFics.SelectedItems[0].SubItems[0].Text);
            Process.Start(fic);
        }

        private void btnAbrirDir_Click(object sender, EventArgs e)
        {
            if(lvFics.SelectedIndices.Count == 0)
            {
                return;
            }

            // Abrir la ventana con el directorio del fichero indicado
            string dir = lvFics.SelectedItems[0].SubItems[1].Text;
            Process.Start("explorer.exe", dir);
        }
    }

    // Simular (en parte) el objeto My de Visual Basic 2005
    // My.Settings y My.Application.Info
    static class My
    {
        public static Properties.Settings Settings
        {
            get
            {
                return Properties.Settings.Default;
            }
        }

        // My.Application.Info
        public static class Application
        {
            public static class Info
            {
                static System.Diagnostics.FileVersionInfo fvi;
                static System.Reflection.Assembly ensamblado;

                static Info()
                {
                    ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
                    fvi = FileVersionInfo.GetVersionInfo(ensamblado.Location);
                }
                public static Version Version
                {
                    get
                    {
                        return new Version(fvi.FileVersion);
                    }
                }
                public static string Title
                {
                    get
                    {
                        return fvi.ProductName;
                    }
                }
                public static string Copyright
                {
                    get
                    {
                        return fvi.LegalCopyright;
                    }
                }
            }
        }
    }
}
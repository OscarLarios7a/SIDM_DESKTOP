
using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Text;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Collections;




using nmExcel = Microsoft.Office.Interop.Excel;

namespace gsBuscar_cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SIDM clssidm = new SIDM();
            clssidm.inicia_MySqlConfig("localhost");

        }
        
      

        public string ruta = "", consulta = "";

        // Para simular la variable Static de VB
        private bool yaEstoy__1;

        private bool cancelar = false;
        public string fecha_visita_1;
        public string fecha_visita_2;
        public string nombre_archivo;

        private void Form1_Load(object sender, EventArgs e)
        {
            //textBox3.Text = "*.S3DB";
            if (My.Settings.Location.X > -1)
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
            btnExaminar.Enabled = true;
            textBox3.Text = "*.S3DB";
            FolderBrowserDialog oFD = new FolderBrowserDialog();
            oFD.Description = "Seleccionar el directorio de búsqueda";
            oFD.RootFolder = Environment.SpecialFolder.MyComputer;
            oFD.SelectedPath = this.txtDir.Text;
            if (oFD.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = "*.S3DB";
                this.txtDir.Text = oFD.SelectedPath;
                btnExaminar.Enabled = false;
                btnBuscar.Enabled = true;
            }
            else
            {
                txtDir.Text = "";
                
            }

            if (this.txtDir.Text != "")
                buscar();
            else
            {
                MessageBox.Show("Seleccione un Directorio");
                btnExaminar.Enabled = true;
                btnBuscar.Enabled = false;
                button3.Enabled = false;
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        { 
            /*this.txtDir.Text = " \\\\29.23.48.196\\Operativo\\DMS";
            buscar();
            this.txtDir.Text = " F:\\";
            buscar();
            this.txtDir.Text = "d:\\";
            buscar();
            this.txtDir.Text = "c:\\";*/
            buscar();
            btnBuscar.Enabled = false;
            if (btnExaminar.Enabled == true)
                MessageBox.Show("No existen datos que respaldar");
           
        }

        public void buscar()
        {  // Buscar de forma recursiva (si es necesario)
            //*** era Static *** yaEstoy__1;

            if (yaEstoy__1)
            {
                cancelar = true;

                btnExaminar.Enabled = true;
                btnBuscar.Enabled = false;
                button3.Enabled = false;

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

            if (this.lvFics.Items.Count > 0)
            {

                button3.Enabled = true;

                this.btnAbrirDir.Enabled = true;
                this.btnAbrirFic.Enabled = true;
            }
            else
            {
                btnExaminar.Enabled = true;
                btnBuscar.Enabled = false;
                button3.Enabled = false;
            }
            this.Refresh();

            cancelar = false;

            yaEstoy__1 = false;

           // respaldar();
        }



        private void recorrerDir(DirectoryInfo di)
        {
            // Recorrer los ficheros de este directorio
            // añadir al listview si se encuentra alguno
            FileInfo[] fics;
            DirectoryInfo[] dirs;

            Application.DoEvents();
            if (cancelar)
                return;

            this.LabelInfo.Text = di.FullName + "...";
            this.LabelInfo.Refresh();

            try
            {
                fics = di.GetFiles(My.Settings.Filtro, SearchOption.TopDirectoryOnly);
                foreach (FileInfo fi in fics)
                {
                    ListViewItem lvi = this.lvFics.Items.Add(fi.Name);
                    lvi.SubItems.Add(fi.DirectoryName);
                }
                //this.lvFics.Refresh();
                if (My.Settings.conSubDir)
                {
                    dirs = di.GetDirectories();
                    foreach (DirectoryInfo dir in dirs)
                    {
                        recorrerDir(dir);
                    }
                }
            }
            catch (Exception ex)
            {
                if (My.Settings.IgnorarError)
                {
                    return;
                }
                if (MessageBox.Show("Error: " + ex.Message + "\n" +
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
            if (this.WindowState == FormWindowState.Normal)
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
            if (lvFics.SelectedIndices.Count == 0)
            {
                return;
            }
            // Comprobar en que columna se ha hecho doble clic
            // El valor de e.X es relativo al control,
            // por tanto, no hace falta añadir nada más.
            if (e.X < lvFics.Columns[0].Width)
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
            if (lvFics.SelectedIndices.Count == 0)
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
            if (lvFics.SelectedIndices.Count == 0)
            {
                return;
            }

            // Abrir la ventana con el directorio del fichero indicado
            string dir = lvFics.SelectedItems[0].SubItems[1].Text;
            Process.Start("explorer.exe", dir);
        }


        public Boolean buscar(DataGridView dgv, string valor)
        {
            Boolean bandera = false;
            string variable = "";
            for (int i = 0; i < dgv.Rows.Count - 1; i++)
            {
                variable = dgv.Rows[i].Cells[0].Value.ToString();
                if (variable == valor)
                {
                    bandera = true;
                    dgv.Rows[i].Cells[2].Value = (Convert.ToInt16(dgv.Rows[i].Cells[2].Value.ToString())) + 1;
                }
            }
            return bandera;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            respaldar();
            button3.Enabled = false;
            btnExaminar.Enabled = true;
            
        }

        public void respaldar()
        {
            consulta = "SELECT folio_encuesta, id_proceso, num_folio, familia_id, folio_prog, folio, entrevis, usuario_captura, hora_ini, hora_fin, fecha_captura, ent_fed, munici, locali, " +
                          "loc_id, ageb, ageb_id, colonia_id, res_entr, total_registros, dm_imei, dm_sim, dm_modelo, dm_fabricante, gps_Latitud, gps_Longitud, gps_Hora, gps_satelite" +
                          " FROM RESUMEN;";

            ruta = "";

            if (lvFics.Items.Count != 0)
            {
                for (int i = 0; i < lvFics.Items.Count; i++)
                {
                    Respaldar resp = new Respaldar();
                    //resp.Generar_Consulta_Recer(dataGridView1,consulta);
                    ruta = lvFics.Items[i].SubItems[1].Text.ToString();
                    ruta += @"\" + lvFics.Items[i].SubItems[0].Text.ToString();
                    resp.RellenarGrid_CompaqSQL(consulta, ruta, dataGridView1, dataGridView2);
                    ruta = compon_ruta(ruta);
                    resp.Generar_Consulta(dataGridView1, ruta);
                }
                //Buscar.Items.Clear();//limpia el listado de archivos a cargar
                // Mostrar_datos();
            }
            MessageBox.Show("Se Respaldaron "+lvFics.Items.Count +" Archivos de Base de Datos");
        
        }


        public string compon_ruta(string ruta_base)
        {
            string ruta = "";
            string[] words = ruta_base.Split('\\');

            for (int i = 0; i < words.Length; i++)
            {
                //MessageBox.Show(words[i].ToString());
                ruta += "\\\\" + words[i].ToString();
            }

           // MessageBox.Show(ruta);
            return ruta.Substring(1,ruta.Length-1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
                      
        }       

        public void Buscarv()
        {
            int acumulador = 0;
            string valor_a_buscar="";
            string valor_a_comparar="";
            DateTime fecha_a_buscar;
            DateTime fecha_a_comparar;
            //string ruta = "";
            bool bandera = false;

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                
                valor_a_buscar=dataGridView1.Rows[i].Cells[0].Value.ToString();
                fecha_a_buscar=Convert.ToDateTime(dataGridView1.Rows[i].Cells[4].Value.ToString());
                for (int j = acumulador; j < dataGridView2.Rows.Count-1; j++)
                {
                    valor_a_comparar=dataGridView2.Rows[j].Cells[0].Value.ToString();
                    fecha_a_comparar=Convert.ToDateTime(dataGridView2.Rows[j].Cells[4].Value.ToString());
                    
                    
                    if (valor_a_buscar == valor_a_comparar)
                    { 
                        bandera = true;
                        if (fecha_a_buscar > fecha_a_comparar)
                        {
                            
                            dataGridView2.Rows[j].Cells[2].Value = dataGridView1.Rows[i].Cells[2].Value;
                            dataGridView2.Rows[j].Cells[3].Value = dataGridView1.Rows[i].Cells[3].Value;
                            dataGridView2.Rows[j].Cells[4].Value = dataGridView1.Rows[i].Cells[4].Value;
                            dataGridView2.Rows[j].Cells[5].Value = dataGridView1.Rows[i].Cells[5].Value;
                            dataGridView2.Rows[j].Cells[6].Value = dataGridView1.Rows[i].Cells[6].Value;
                           
                            
                        }
                    }
                    //else
                        //dataGridView2.Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[4].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString(), dataGridView1.Rows[i].Cells[6].Value.ToString());
                }
                if (bandera == false)
                {
                    dataGridView2.Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[4].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString(), dataGridView1.Rows[i].Cells[6].Value.ToString());
                    acumulador=dataGridView2.Rows.Count-2;
                    bandera = false;
                }
                else
                    bandera = false;
            }
           
            textBox1.Text = (dataGridView2.Rows.Count - 1).ToString();


            if (dataGridView2.Rows.Count != 0)
            {
                button5.Enabled = true;
                dataGridView2.Enabled = true;
            }
        }



        private void Pasar_Grid1_a_Grid2()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView2.Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[4].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString(), dataGridView1.Rows[i].Cells[6].Value.ToString(), dataGridView1.Rows[i].Cells[7].Value.ToString(), dataGridView1.Rows[i].Cells[8].Value.ToString(), dataGridView1.Rows[i].Cells[9].Value.ToString(), dataGridView1.Rows[i].Cells[10].Value.ToString(), dataGridView1.Rows[i].Cells[11].Value.ToString(), dataGridView1.Rows[i].Cells[12].Value.ToString(), dataGridView1.Rows[i].Cells[13].Value.ToString(), dataGridView1.Rows[i].Cells[14].Value.ToString());

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
             if (lvFics.Items.Count != 0)
            {
                for (int i = 0; i < lvFics.Items.Count; i++)
                {
                    Respaldar resp = new Respaldar();
                    //resp.Generar_Consulta_Recer(dataGridView1,consulta);
                    ruta = lvFics.Items[i].SubItems[1].Text.ToString();
                    ruta += @"\" + lvFics.Items[i].SubItems[0].Text.ToString();
                    
                    consulta = "SELECT * FROM RESUMEN;";
                    resp.RellenarGrid_CompaqSQL(consulta, ruta, dataGridView1, dataGridView2);
                    ruta = compon_ruta(ruta); 
                    resp.Generar_Consulta_Resumen(dataGridView1, ruta, @"D:\\AT_Oaxaca\\sincronizar\\1\\ENCU_RECE_vacia.sdf");

                   // dataGridView1.Rows.Clear();

                    ruta = lvFics.Items[i].SubItems[1].Text.ToString();
                    ruta += @"\" + lvFics.Items[i].SubItems[0].Text.ToString();
                    consulta = "SELECT * FROM CAPTURA;";
                    resp.RellenarGrid_CompaqSQL(consulta, ruta, dataGridView1, dataGridView2);
                    ruta = compon_ruta(ruta); 
                    resp.Generar_Consulta_Captura(dataGridView1, ruta, @"D:\\AT_Oaxaca\\sincronizar\\1\\ENCU_RECE_vacia.sdf");
                }
                //Buscar.Items.Clear();//limpia el listado de archivos a cargar
                // Mostrar_datos();
            }
           
        }

        private void rECERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "IDENTIFICACION_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            
            dataGridView2.Rows.Clear();
            SIDM clssidm = new SIDM();
            //consulta = "SELECT familia_id,num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=4 order by familia_id ;";
            consulta = "SELECT num_folio as familia_id,familia_id as num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=60 order by familia_id ;";
            clssidm.RellenarDatagrid_MySql(consulta, dataGridView1);

            Buscarv();
        }

        private void rEEVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "RECERTIFICACION_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView2.Rows.Clear();
            SIDM clssidm = new SIDM();
            consulta = "SELECT familia_id,num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo,MUNICI,LOCALI FROM KIBIX WHERE id_proceso=2 order by familia_id ;";
            //consulta = "SELECT num_folio as familia_id,familia_id as num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=1 order by familia_id ;";
            clssidm.RellenarDatagrid_MySql(consulta, dataGridView1);

            Buscarv();
        }

        private void vPCSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "VPCS_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView2.Rows.Clear();
            SIDM clssidm = new SIDM();
            consulta = "SELECT familia_id,num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo,MUNICI,LOCALI FROM KIBIX WHERE id_proceso=3 order by familia_id ;";
            //consulta = "SELECT num_folio as familia_id,familia_id as num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=1 order by familia_id ;";
            clssidm.RellenarDatagrid_MySql(consulta, dataGridView1);

            Buscarv();
        }

        private void rEEVALUACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "REEVALUACION_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView2.Rows.Clear();
            SIDM clssidm = new SIDM();
            consulta = "SELECT familia_id,num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo,MUNICI,LOCALI FROM KIBIX WHERE id_proceso=4 order by familia_id ;";
            //consulta = "SELECT num_folio as familia_id,familia_id as num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=1 order by familia_id ;";
            clssidm.RellenarDatagrid_MySql(consulta, dataGridView1);

            Buscarv();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Exportar_archivo clsexport = new Exportar_archivo();
            clsexport.Exportar_to_cvs(dataGridView2,nombre_archivo);
            MessageBox.Show("EL AVANCE SE HA GENERADO EN C:\\");
            button5.Enabled = false;
            dataGridView2.Enabled = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    
                    btnExaminar.Enabled = true;
                    btnBuscar.Enabled = false;
                    button3.Enabled = false;
                    //buscar();
                    break;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }
    // Simular (en parte) el objeto My de Visual Basic 2005
    // My.Settings y My.Application.Info
    static class MyX
    {
        public static Properties.Settings Settings
        {
            get
            {
                return Properties.Settings.Default;
            }
        }

        // My.Application.Info
        public static class ApplicationX
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
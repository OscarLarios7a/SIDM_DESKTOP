
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
using System.Runtime.InteropServices;
using OpenNETCF.Desktop.Communication;




namespace gsBuscar_cs
{
    public partial class FRM_KIBIXcs : Form
    {
        public FRM_KIBIXcs()
        {
            InitializeComponent();
            SIDM clssidm = new SIDM();
            clssidm.inicia_MySqlConfig("localhost");



            //SE EJECUTA EN LA INCIALIZACIÓN DE COMPONENTES ANTES EN EL FROM LOAD


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

            //this.btnAbrirDir.Enabled = false;
            //this.btnAbrirFic.Enabled = false;

        }

        [DllImport("rapi.dll")]
        public static extern void CeRapiInitEx(ref RAPIINIT pRapiInit);
        [DllImport("rapi.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CeRapiUninit();
        [StructLayout(LayoutKind.Sequential)]
        public struct RAPIINIT
        {
            public int cbsize;
            public IntPtr heRapiInit;
            public UInt32 hrRapiInit;
        };

        public string ruta = "", consulta = "", consulta2 = "", consulta3 = "";

        // Para simular la variable Static de VB
        private bool yaEstoy__1;

        private bool cancelar = false;
        public string fecha_visita_1;
        public string fecha_visita_2;
        public string nombre_archivo;

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "*.S3DB";
            btnExaminar.Enabled = true;
            FolderBrowserDialog oFD = new FolderBrowserDialog();
            oFD.Description = "Seleccionar el directorio de búsqueda";
            oFD.RootFolder = Environment.SpecialFolder.MyComputer;
            oFD.SelectedPath = this.txtDir.Text;
            if (oFD.ShowDialog() == DialogResult.OK)
            {
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
            //checkBox1.Checked = false;
        }
        public void buscar()
        {  // Buscar de forma recursiva (si es necesario)
            //*** era Static *** yaEstoy__1;

            if (yaEstoy__1)
            {
                cancelar = true;

                btnExaminar.Enabled = true;
                //checkBox1.Checked = false;
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

                //this.btnAbrirDir.Enabled = true;
                //this.btnAbrirFic.Enabled = true;
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

        private void button3_Click(object sender, EventArgs e)
        {
            respaldar();
            respaldarCaptura();
            respaldarCapturaCerm();
           // checkBox1.Checked = false;
            button3.Enabled = false;
            btnExaminar.Enabled = true;
            
        }

        public void respaldar()
        {
            /*consulta = "SELECT folio_encuesta, id_proceso, num_folio, familia_id, folio_prog, folio, entrevis, usuario_captura, hora_ini, hora_fin, fecha_captura, ent_fed, munici, locali, " +
                          "loc_id, ageb, ageb_id, colonia_id, res_entr, total_registros, dm_imei, dm_sim, dm_modelo, dm_fabricante, gps_Latitud, gps_Longitud, gps_Hora, gps_satelite" +
                          " FROM RESUMEN;";
            */
            consulta = "SELECT folio_encuesta, id_proceso, FOLIO_ENCASEH AS num_folio, familia_id, FOLIO_PROGRAMA AS folio_prog,folio_encuesta as folio, " +
                        "CUPO AS entrevis, USUARIO_CAPTURA_DM AS usuario_captura,hora_inicio as hora_ini, hora_fin, fecha_captura,estado_id as ent_fed, " +
                        "municipio_id as munici,clave_localidad as locali,localidad_id as loc_id,clave_ageb as ageb, ageb_id, " +
                        "asentamiento_id as colonia_id, resultado_entrevista as res_entr, total_registros, dm_imei, " +
                        "dm_sim, dm_modelo, dm_fabricante, gps_Latitud, gps_Longitud, gps_hora_global as gps_Hora, gps_satelite,FOLIO_CRIS " +
                        "FROM apdm_resumen_encuesta;";

            ruta = "";

            if (lvFics.Items.Count != 0)
            {
                for (int i = 0; i < lvFics.Items.Count; i++)
                {
                    respaldar_s3db resp = new respaldar_s3db();
                    //resp.Generar_Consulta_Recer(dataGridView1,consulta);
                    ruta = lvFics.Items[i].SubItems[1].Text.ToString();
                    ruta += @"\" + lvFics.Items[i].SubItems[0].Text.ToString();
                    resp.RellenarGrid_CompaqSQL(consulta, ruta, dataGridView1);
                    ruta = compon_ruta(ruta);
                    resp.Generar_Consulta(dataGridView1, ruta);

                }
                //Buscar.Items.Clear();//limpia el listado de archivos a cargar
                // Mostrar_datos();
            }
            MessageBox.Show("Se Respaldaron " + lvFics.Items.Count + " Archivos de Base de Datos");

           
           


        }

        public void respaldarCaptura()
        {
            /*consulta = "SELECT folio_encuesta, id_proceso, num_folio, familia_id, folio_prog, folio, entrevis, usuario_captura, hora_ini, hora_fin, fecha_captura, ent_fed, munici, locali, " +
                          "loc_id, ageb, ageb_id, colonia_id, res_entr, total_registros, dm_imei, dm_sim, dm_modelo, dm_fabricante, gps_Latitud, gps_Longitud, gps_Hora, gps_satelite" +
                          " FROM RESUMEN;";
            */
    

            consulta2 = "select A.id_pregunta,B.texto_pregunta,A.id_codigo_respuesta,A.respuesta,A.folio_encuesta from apdm_captura  as A , apdm_preguntas as B where A.id_codigo_respuesta in (174738,174719,174720,174772,176074,177894,177895,177896,179713,179714,175565) and A.id_Pregunta = B.id_pregunta;";
        
            ruta = "";

            if (lvFics.Items.Count != 0)
            {
                MessageBox.Show("Inicianado Carga de Informacion");
                for (int i = 0; i < lvFics.Items.Count; i++)
                {
                    respaldar_s3db resp = new respaldar_s3db();
                    //resp.Generar_Consulta_Recer(dataGridView1,consulta);
                    ruta = lvFics.Items[i].SubItems[1].Text.ToString();
                    ruta += @"\" + lvFics.Items[i].SubItems[0].Text.ToString();
                    resp.RellenarGrid_CompaqSQLCaptura(consulta2, ruta, dtgvCisbebien);
                    ruta = compon_ruta(ruta);
                    resp.Generar_ConsultaCaptura(dtgvCisbebien, ruta);
                }
                MessageBox.Show("Finalizo Carga de Informacion");
                //Buscar.Items.Clear();//limpia el listado de archivos a cargar
                // Mostrar_datos();
            }
            MessageBox.Show("Se Respaldaron " + lvFics.Items.Count + " Archivos de Base de Datos");
            
        }

        public void respaldarCapturaCerm()
        {
            /*consulta = "SELECT folio_encuesta, id_proceso, num_folio, familia_id, folio_prog, folio, entrevis, usuario_captura, hora_ini, hora_fin, fecha_captura, ent_fed, munici, locali, " +
                          "loc_id, ageb, ageb_id, colonia_id, res_entr, total_registros, dm_imei, dm_sim, dm_modelo, dm_fabricante, gps_Latitud, gps_Longitud, gps_Hora, gps_satelite" +
                          " FROM RESUMEN;";
            */


            consulta3 = "select A.id_pregunta,B.texto_pregunta,A.id_codigo_respuesta,A.respuesta,A.folio_encuesta from apdm_captura  as A , apdm_preguntas as B where A.id_codigo_respuesta in (170830,170757,170832,170833,170857,170883) and A.id_Pregunta = B.id_pregunta; ";
           
            ruta = "";

            if (lvFics.Items.Count != 0)
            {
                MessageBox.Show("Inicianado Carga de Informacion");
                for (int i = 0; i < lvFics.Items.Count; i++)
                {
                    respaldar_s3db resp = new respaldar_s3db();
                    //resp.Generar_Consulta_Recer(dataGridView1,consulta);
                    ruta = lvFics.Items[i].SubItems[1].Text.ToString();
                    ruta += @"\" + lvFics.Items[i].SubItems[0].Text;
                    resp.RellenarGrid_CompaqSQLCapturaCerm(consulta3, ruta, dtgvCerm);
                    ruta = compon_ruta(ruta);
                    resp.Generar_ConsultaCapturaCerm(dtgvCerm, ruta);
                }
                //Buscar.Items.Clear();//limpia el listado de archivos a cargar
                // Mostrar_datos();
                MessageBox.Show("Finalizo Carga de Informacion");
            }
            MessageBox.Show("Se Respaldaron " + lvFics.Items.Count + " Archivos de Base de Datos");

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
            return ruta.Substring(1, ruta.Length - 1);
        }
        public void Buscarv()
        {
            int acumulador = 0;
            int repetidos = 1;
            //int repetidos_registros=0;
            string valor_a_buscar = "";
            string valor_a_comparar = "";
            DateTime fecha_a_buscar;
            DateTime fecha_a_comparar;

            string res_buscar;
            string res_comparar;
            //string ruta = "";
            bool bandera = false;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                valor_a_buscar = dataGridView1.Rows[i].Cells[0].Value.ToString();
                fecha_a_buscar = Convert.ToDateTime(dataGridView1.Rows[i].Cells[4].Value.ToString());
                res_buscar = dataGridView1.Rows[i].Cells[5].Value.ToString();

                for (int j = acumulador; j < dataGridView2.Rows.Count - 1; j++)
                {
                    valor_a_comparar = dataGridView2.Rows[j].Cells[0].Value.ToString();
                    fecha_a_comparar = Convert.ToDateTime(dataGridView2.Rows[j].Cells[4].Value.ToString());
                    res_comparar = dataGridView2.Rows[j].Cells[5].Value.ToString();

                   // if (valor_a_buscar == "8485619")
                   //     MessageBox.Show("8485619");


                    //compara si en el data grid view 2 existe la familia id que se esta extrallendo en el datagridview 1
                    if (valor_a_buscar == valor_a_comparar)
                    {
                        repetidos++;
                        bandera = true;


                        //esta opcion sirve cuando es un codigo definitivo y se levanto mas de 1 encuesta, se toma la primera encuesta levantada
                        if (res_buscar == "1" || res_buscar == "3" || res_buscar == "12")
                        {
                            if (fecha_a_buscar < fecha_a_comparar)//actualiza los valores, solo si la fecha cambia a una mas actual
                            {
                                if (res_comparar != "1" || res_comparar != "3" || res_comparar != "12")
                                {
                                    dataGridView2.Rows[j].Cells[2].Value = dataGridView1.Rows[i].Cells[2].Value;
                                    dataGridView2.Rows[j].Cells[3].Value = dataGridView1.Rows[i].Cells[3].Value;
                                    dataGridView2.Rows[j].Cells[4].Value = dataGridView1.Rows[i].Cells[4].Value;
                                    dataGridView2.Rows[j].Cells[5].Value = dataGridView1.Rows[i].Cells[5].Value;
                                    dataGridView2.Rows[j].Cells[6].Value = dataGridView1.Rows[i].Cells[6].Value;
                                    dataGridView2.Rows[j].Cells[7].Value = acompletar_ceros(3, dataGridView1.Rows[i].Cells[7].Value.ToString());//rellena ceros del municipio
                                    dataGridView2.Rows[j].Cells[8].Value = acompletar_ceros(4, dataGridView1.Rows[i].Cells[8].Value.ToString());//rellena ceros de la localidad
                                    dataGridView2.Rows[j].Cells[9].Value = repetidos.ToString();
                                    dataGridView2.Rows[j].Cells[10].Value = ("20" + acompletar_ceros(3, dataGridView1.Rows[i].Cells[7].Value.ToString()) + acompletar_ceros(4, dataGridView1.Rows[i].Cells[8].Value.ToString()));
                                    dataGridView2.Rows[j].Cells[11].Value = dataGridView1.Rows[i].Cells[9].Value;
                                    // dataGridView2.Rows[j].Cells[11].Value = repetidos_registros.ToString();
                                }
                            }
                            else
                            {
                                if (fecha_a_buscar > fecha_a_comparar)//actualiza los valores, solo si la fecha cambia a una mas actual
                                {
                                    if (res_comparar == "0" || res_comparar == "4" || res_comparar == "5" || res_comparar == "6" || res_comparar == "7" || res_comparar == "8" || res_comparar == "9" || res_comparar == "10" || res_comparar == "11" || res_comparar == "13")
                                    {
                                        dataGridView2.Rows[j].Cells[2].Value = dataGridView1.Rows[i].Cells[2].Value;
                                        dataGridView2.Rows[j].Cells[3].Value = dataGridView1.Rows[i].Cells[3].Value;
                                        dataGridView2.Rows[j].Cells[4].Value = dataGridView1.Rows[i].Cells[4].Value;
                                        dataGridView2.Rows[j].Cells[5].Value = dataGridView1.Rows[i].Cells[5].Value;
                                        dataGridView2.Rows[j].Cells[6].Value = dataGridView1.Rows[i].Cells[6].Value;
                                        dataGridView2.Rows[j].Cells[7].Value = acompletar_ceros(3, dataGridView1.Rows[i].Cells[7].Value.ToString());//rellena ceros del municipio
                                        dataGridView2.Rows[j].Cells[8].Value = acompletar_ceros(4, dataGridView1.Rows[i].Cells[8].Value.ToString());//rellena ceros de la localidad
                                        dataGridView2.Rows[j].Cells[9].Value = repetidos.ToString();
                                        dataGridView2.Rows[j].Cells[10].Value = ("20" + acompletar_ceros(3, dataGridView1.Rows[i].Cells[7].Value.ToString()) + acompletar_ceros(4, dataGridView1.Rows[i].Cells[8].Value.ToString()));
                                        dataGridView2.Rows[j].Cells[11].Value = dataGridView1.Rows[i].Cells[9].Value;
                                        
                                        // dataGridView2.Rows[j].Cells[11].Value = repetidos_registros.ToString();
                                    }
                                }
                                else
                                    dataGridView2.Rows[j].Cells[9].Value = repetidos.ToString();

                            }
                        }
                        //esta opcion sirve cuando no es un codigo definitivo y levantaron mas de 1 encuesta, para este caso, se toma la ultima encuesta aplicada
                        else
                        {
                            if (fecha_a_buscar > fecha_a_comparar)//actualiza los valores, solo si la fecha cambia a una mas actual
                            {

                                dataGridView2.Rows[j].Cells[2].Value = dataGridView1.Rows[i].Cells[2].Value;
                                dataGridView2.Rows[j].Cells[3].Value = dataGridView1.Rows[i].Cells[3].Value;
                                dataGridView2.Rows[j].Cells[4].Value = dataGridView1.Rows[i].Cells[4].Value;
                                dataGridView2.Rows[j].Cells[5].Value = dataGridView1.Rows[i].Cells[5].Value;
                                dataGridView2.Rows[j].Cells[6].Value = dataGridView1.Rows[i].Cells[6].Value;
                                dataGridView2.Rows[j].Cells[7].Value = acompletar_ceros(3, dataGridView1.Rows[i].Cells[7].Value.ToString());//rellena ceros del municipio
                                dataGridView2.Rows[j].Cells[8].Value = acompletar_ceros(4, dataGridView1.Rows[i].Cells[8].Value.ToString());//rellena ceros de la localidad
                                dataGridView2.Rows[j].Cells[9].Value = repetidos.ToString();
                                dataGridView2.Rows[j].Cells[10].Value = ("20" + acompletar_ceros(3, dataGridView1.Rows[i].Cells[7].Value.ToString()) + acompletar_ceros(4, dataGridView1.Rows[i].Cells[8].Value.ToString()));
                                dataGridView2.Rows[j].Cells[11].Value = dataGridView1.Rows[i].Cells[9].Value;
                                // dataGridView2.Rows[j].Cells[11].Value = repetidos_registros.ToString();
                            }
                            else
                                dataGridView2.Rows[j].Cells[9].Value = repetidos.ToString();
                        }
                    }
                    else
                        {
                        repetidos = 1;
                     
                        }
                   
                  
                   
                    //else
                    //dataGridView2.Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[4].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString(), dataGridView1.Rows[i].Cells[6].Value.ToString());
                }
                if (bandera == false)
                {
                    dataGridView2.Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[4].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString(), dataGridView1.Rows[i].Cells[6].Value.ToString(), acompletar_ceros(3, dataGridView1.Rows[i].Cells[7].Value.ToString()), acompletar_ceros(4, dataGridView1.Rows[i].Cells[8].Value.ToString()), repetidos.ToString(), ("20" + acompletar_ceros(3, dataGridView1.Rows[i].Cells[7].Value.ToString()) + acompletar_ceros(4, dataGridView1.Rows[i].Cells[8].Value.ToString())),dataGridView1.Rows[i].Cells[9].Value);
                    acumulador = dataGridView2.Rows.Count - 2;
                    bandera = false;
                }
                else
                    bandera = false;
            }

            textBox1.Text = (dataGridView2.Rows.Count - 1).ToString();


            if (dataGridView2.Rows.Count != 0)
            {
                button5.Enabled = true;
                //dataGridView2.Enabled = true;
            }
        }

        private string acompletar_ceros(int i,string campo)
        {
            for (;;)
            {
                if (campo.Length < i)
                    campo = "0" + campo;
                else
                    break;
            }

            return (campo);
        }

        private void Pasar_Grid1_a_Grid2()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView2.Rows.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[4].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString(), dataGridView1.Rows[i].Cells[6].Value.ToString(), dataGridView1.Rows[i].Cells[7].Value.ToString(), dataGridView1.Rows[i].Cells[8].Value.ToString(), dataGridView1.Rows[i].Cells[9].Value.ToString(), dataGridView1.Rows[i].Cells[10].Value.ToString(), dataGridView1.Rows[i].Cells[11].Value.ToString(), dataGridView1.Rows[i].Cells[12].Value.ToString(), dataGridView1.Rows[i].Cells[13].Value.ToString(), dataGridView1.Rows[i].Cells[14].Value.ToString());

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            Exportar_archivo clsexport = new Exportar_archivo();
            clsexport.Exportar_to_cvs(dataGridView2, nombre_archivo);
            MessageBox.Show("EL AVANCE SE HA GENERADO EN E:\\");
            button5.Enabled = false;
            //dataGridView2.Enabled = false;
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

        private void iDENTIFICACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*nombre_archivo = "IDENTIFICACION_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();

            dataGridView2.Rows.Clear();
            SIDM clssidm = new SIDM();
            //consulta = "SELECT familia_id,num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=4 order by familia_id ;";
            consulta = "SELECT num_folio as familia_id,familia_id as num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=1 order by familia_id ;";
            clssidm.RellenarDatagrid_MySql(consulta, dataGridView1);

            Buscarv();*/
        }

        private void rECERTIFICACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "RECERTIFICACION_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView2.Rows.Clear();
            SIDM clssidm = new SIDM();
            consulta = "SELECT familia_id,num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo,MUNICI,LOCALI,gps_satelite as repetidos FROM KIBIX WHERE id_proceso=2 GROUP BY familia_id,fecha_captura order by familia_id ;";
            //consulta = "SELECT num_folio as familia_id,familia_id as num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=1 order by familia_id ;";
            clssidm.RellenarDatagrid_MySql(consulta, dataGridView1);

            Buscarv();
        }

        private void vPCSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "VPCS_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView2.Rows.Clear();
            SIDM clssidm = new SIDM();
            consulta = "SELECT familia_id,num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo,MUNICI,LOCALI,gps_satelite as repetidos FROM KIBIX WHERE id_proceso=3 group by familia_id,fecha_captura order by familia_id ;";
            //consulta = "SELECT num_folio as familia_id,familia_id as num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=1 order by familia_id ;";
            clssidm.RellenarDatagrid_MySql(consulta, dataGridView1);

            Buscarv();
        }

        private void rEEVALUACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "REEVALUACION_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView2.Rows.Clear();
            SIDM clssidm = new SIDM();
            consulta = "SELECT familia_id,num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo,MUNICI,LOCALI,gps_satelite as repetidos FROM KIBIX WHERE id_proceso=4 group by familia_id,fecha_captura order by familia_id ;";
            //consulta = "SELECT num_folio as familia_id,familia_id as num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=1 order by familia_id ;";
            clssidm.RellenarDatagrid_MySql(consulta, dataGridView1);

            Buscarv();
        }

        private void FRM_KIBIXcs_Load(object sender, EventArgs e)
        {
            
            this.Width=862;
            this.Height = 631;
            txtFiltro.Text = "*.S3DB";
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
       
       

        private void button1_Click(object sender, EventArgs e)
        {
           
        
        }

       /* private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acerca_de frm = new acerca_de();
            frm.Show();
        }*/

        private void encuestasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "IDENTIFICACION_CUBEBIEN" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();

            dataGridView2.Rows.Clear();
            SIDM clssidm = new SIDM();
            //consulta = "SELECT familia_id,num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=4 order by familia_id ;";

            consulta = "SELECT folio_encuesta as familia_id,familia_id as num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo,MUNICI,LOCALI,ageb FROM KIBIX WHERE id_proceso=50  GROUP BY folio_encuesta,fecha_captura order by familia_id;";
            clssidm.RellenarDatagrid_MySql(consulta, dataGridView1);

            Buscarv();
        }

        private void avanceDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "AVANCE_DIARIO_POR_PS_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            crear_datagrid();
            consulta = "SELECT ENTREVIS as CUPO,DM_IMEI,CONCAT(SUBSTR(FECHA_CAPTURA,1,2),'_',SUBSTR(FECHA_CAPTURA,4,2) ,'_',SUBSTR(FECHA_CAPTURA,7,4))AS FECHA,COUNT(DISTINCT folio_encuesta)AS TOTAL FROM KIBIX GROUP BY ENTREVIS, FECHA ORDER BY substr(FECHA,1,7) ; ";
           
            SIDM CLSSIDM = new SIDM();
            CLSSIDM.RellenarDatagrid_MySql(consulta, dataGridView1);
            productividad(dataGridView1);
            
            //EXPORTA EN ARCHIVO CSV
            Exportar_archivo clsexport = new Exportar_archivo();
            clsexport.Exportar_to_cvs(dataGridView3, nombre_archivo);
            MessageBox.Show("EL AVANCE SE HA GENERADO EN D:\\");
            button5.Enabled = false;
           
            
        }

        private void crear_datagrid()
        {            
            int contador=3;
            string mes="", dia ="";

            DataGridViewTextBoxColumn COL_CUPO = new DataGridViewTextBoxColumn();
            COL_CUPO.Name = "CUPO";
            COL_CUPO.HeaderText = "CUPO";
            dataGridView3.Columns.Insert(0, COL_CUPO);
            //crear_datagrid();
            DataGridViewTextBoxColumn COL_NOMBRE = new DataGridViewTextBoxColumn();
            COL_NOMBRE.Name = "NOMBRE";
            COL_NOMBRE.HeaderText = "NOMBRE";
            dataGridView3.Columns.Insert(1, COL_NOMBRE);

            DataGridViewTextBoxColumn COL_IMEI = new DataGridViewTextBoxColumn();
            COL_IMEI.Name = "IMEI";
            COL_IMEI.HeaderText="IMEI";
            dataGridView3.Columns.Insert(2,COL_IMEI);
               

            for (int i = 1; i < 13; i++)//mes (SE TOMAN 5 MESES DADO QUE EL PROCESO DE INCORPORACIÓN SE ACABA EN MAYO)
            {
                if ((i + 1).ToString().Length == 1)
                    mes = "0" + (i + 1);
                else
                    mes = (i+1).ToString();

                for (int j = 0; j < 31; j++)//dia
                {
                    if ((j + 1).ToString().Length == 1)
                        dia = "0" + (j + 1);
                    else
                        dia = (j + 1).ToString();

                    DataGridViewTextBoxColumn Column = new DataGridViewTextBoxColumn();
                    Column.Name = "_"+ dia +"_"+ mes +"_2020";
                    Column.HeaderText = dia + "/" + mes + "/2020";
                    dataGridView3.Columns.Insert(contador, Column);
                    contador++;
                }
            
            }
        }



        private void productividad(DataGridView dg)
        {

            string fecha = "";
            int bandera = 999999;//99999 indica si crear fila


            for (int i = 0; i <= dg.Rows.Count - 2; i++)
            {
                //MessageBox.Show(dg.Rows[i].Cells["fecha"].Value.ToString());
                fecha = "_" + dg.Rows[i].Cells["fecha"].Value.ToString();

                for (int J = 0; J <= dataGridView3.RowCount - 1; J++)
                {
                    int cupo_a = 0;
                    int cupo_b = 0;
                    try
                    {

                        cupo_a = Convert.ToInt32(dataGridView1.Rows[i].Cells["cupo"].Value);
                    }
                    catch (Exception ex) { }
                    try
                    {

                        cupo_b = Convert.ToInt32(dataGridView3.Rows[J].Cells["cupo"].Value);
                    }
                    catch (Exception ex) { }

                    if (cupo_b == cupo_a)
                    {
                        bandera = J;
                        J = dataGridView3.RowCount;

                    }
                    
                }

                if (bandera == 999999)
                {
                    dataGridView3.Rows.Insert(dataGridView3.RowCount - 1, 1);//incerta fila en datagrid
                    bandera = dataGridView3.RowCount - 2;

                    for (int k = 0; k < dataGridView3.ColumnCount; k++)
                    {
                        dataGridView3[k, dataGridView3.RowCount - 2].Value = "0";

                    }

                }
                try
                {
                    dataGridView3.Rows[bandera].Cells[fecha].Value = dg.Rows[i].Cells["total"].Value.ToString();
                    dataGridView3.Rows[bandera].Cells["CUPO"].Value = dg.Rows[i].Cells["CUPO"].Value.ToString();
                    dataGridView3.Rows[bandera].Cells["IMEI"].Value = dg.Rows[i].Cells["DM_IMEI"].Value.ToString();
                }
                catch (Exception ex)
                {

                    try
                    {

                        //INCERTA COLUMNA NO EXISTENTE
                        DataGridViewTextBoxColumn COL_FECHA = new DataGridViewTextBoxColumn();
                        COL_FECHA.Name = fecha;
                        COL_FECHA.HeaderText = fecha.Substring(1, 2) + "/" + fecha.Substring(4, 2) + "/" + fecha.Substring(7, 4);

                        dataGridView3.Columns.Insert(dataGridView3.Columns.Count - 1, COL_FECHA);
                        for (int j = 0; j < dataGridView3.Rows.Count - 1; j++)
                        {
                            dataGridView3.Rows[j].Cells[fecha].Value = "0";
                        }

                        dataGridView3.Rows[bandera].Cells[fecha].Value = dg.Rows[i].Cells["total"].Value.ToString();
                        dataGridView3.Rows[bandera].Cells["CUPO"].Value = dg.Rows[i].Cells["CUPO"].Value.ToString();
                        dataGridView3.Rows[bandera].Cells["IMEI"].Value = dg.Rows[i].Cells["DM_IMEI"].Value.ToString();

                    }
                    catch (Exception EX_2)
                    {
                        MessageBox.Show(EX_2.Message);
                    }

                }
                // dataGridView2.Rows[bandera].Cells["ZA"].Value = dg.Rows[i].Cells["ZA"].Value.ToString();
                bandera = 999999;
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("La fecha de corte "+dateTimePicker1.Text+" es la correcta?", "Confirma corte de sincro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("Ya realizaste la sincronizacion del dispositivo?", "Confirma la sincro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MessageBox.Show("Respalda ZIP y TXT");
                }
                else
                {

                    if (txtCupo.Text != "")
                    {
                        pda_a_pc cls_pda = new pda_a_pc();
                        string ruta_respaldo = "";
                        string ruta_base="";

                        
                        //ruta_respaldo = @"c:\respaldo\bd\" + txtCupo.Text;
                        //COPIA BASES DE DATOS
                        ruta_base = "BD";
                        ruta_respaldo = @"c:\respaldo\" + dateTimePicker1.Text.Substring(0, 2) + "_" + dateTimePicker1.Text.Substring(3, 2) + "_" + dateTimePicker1.Text.Substring(6, 4) + @"\" + ruta_base + @"\" + txtCupo.Text + @"\";
                        cls_pda.CopyFilesFromDevice(@ruta_respaldo, @"Storage Card\Operativo_DM\Bases de Datos\", "sdf", false, true, 1);

                        
                        MessageBox.Show("NO OLVIDE RESPALDAR ZIP Y TXT DESPUES DE SINCRONIZAR");
                    }
                    else
                        MessageBox.Show("Debe de rellenar el campo CUPO");
                }
            }
            else
            {
                MessageBox.Show("Corrige la fecha de corte");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("La fecha de corte " + dateTimePicker1.Text + " es la correcta?", "Confirma corte de sincro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("Ya respaldaste BD y Sincronizaste?", "Confirma Respaldo de BD y Sincro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (txtCupo.Text != "")
                    {
                        pda_a_pc cls_pda = new pda_a_pc();
                        string ruta_respaldo = "";
                        string ruta_base = "";


                        //copia ZIP
                        ruta_base = "ZIP";
                        ruta_respaldo = @"c:\respaldo\" + dateTimePicker1.Text.Substring(0, 2) + "_" + dateTimePicker1.Text.Substring(3, 2) + "_" + dateTimePicker1.Text.Substring(6, 4) + @"\" + ruta_base + @"\" + txtCupo.Text + @"\";
                        cls_pda.CopyFilesFromDevice(@ruta_respaldo, @"respaldos\", "zip", false, true, 2);

                        //vacia ZIP
                        cls_pda.DeleteFilesFromDevice(@"respaldos\", "ZIP", true);




                        //COPIA TXT
                        ruta_base = "TXT";
                        ruta_respaldo = @"c:\respaldo\" + dateTimePicker1.Text.Substring(0, 2) + "_" + dateTimePicker1.Text.Substring(3, 2) + "_" + dateTimePicker1.Text.Substring(6, 4) + @"\" + ruta_base + @"\" + txtCupo.Text + @"\";
                        cls_pda.CopyFilesFromDevice(@ruta_respaldo, @"Storage Card\", "txt", false, true, 3);





                        MessageBox.Show("SE RESPALDO LOS ZIP Y TXT CON EXITO");
                        textBox3.Text = (Convert.ToInt16(textBox3.Text) + 1).ToString();

                    }
                    else
                        MessageBox.Show("Debe de rellenar el campo CUPO");
                }
                else
                    MessageBox.Show("Primero Realiza el Respaldo de la BD y la Sincronización");
            }
            else
            {
                MessageBox.Show("Puedes corregir la fecha");
            }
        }

        private void FRM_KIBIXcs_FormClosed(object sender, FormClosedEventArgs e)
        {


        }

        private void FRM_KIBIXcs_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            btnExaminar.Enabled = !btnExaminar.Enabled;
            btnBuscar.Enabled = !btnBuscar.Enabled;
            button3.Enabled = !button3.Enabled;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void avanceDiarioIdentificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "AVANCE_DIARIO_POR_PS_IDENTIFICACION" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            crear_datagrid();
            consulta = "SELECT ENTREVIS as CUPO,DM_IMEI,CONCAT(SUBSTR(FECHA_CAPTURA,1,2),'_',SUBSTR(FECHA_CAPTURA,4,2) ,'_',SUBSTR(FECHA_CAPTURA,7,4))AS FECHA,COUNT(DISTINCT folio_encuesta)AS TOTAL FROM KIBIX where id_proceso=50 GROUP BY ENTREVIS, FECHA ORDER BY substr(FECHA,1,7) ; ";

            SIDM CLSSIDM = new SIDM();
            CLSSIDM.RellenarDatagrid_MySql(consulta, dataGridView1);
            productividad(dataGridView1);

            //EXPORTA EN ARCHIVO CSV
            Exportar_archivo clsexport = new Exportar_archivo();
            clsexport.Exportar_to_cvs(dataGridView3, nombre_archivo);
            MessageBox.Show("EL AVANCE SE HA GENERADO EN D:\\");
            button5.Enabled = false;
        }

        private void avanceDiarioReevaluacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "AVANCE_DIARIO_POR_PS_REEVALUACION" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            crear_datagrid();
            consulta = "SELECT ENTREVIS as CUPO,DM_IMEI,CONCAT(SUBSTR(FECHA_CAPTURA,1,2),'_',SUBSTR(FECHA_CAPTURA,4,2) ,'_',SUBSTR(FECHA_CAPTURA,7,4))AS FECHA,COUNT(DISTINCT folio_encuesta)AS TOTAL FROM KIBIX where id_proceso=4 GROUP BY ENTREVIS, FECHA ORDER BY substr(FECHA,1,7) ; ";

            SIDM CLSSIDM = new SIDM();
            CLSSIDM.RellenarDatagrid_MySql(consulta, dataGridView1);
            productividad(dataGridView1);

            //EXPORTA EN ARCHIVO CSV
            Exportar_archivo clsexport = new Exportar_archivo();
            clsexport.Exportar_to_cvs(dataGridView3, nombre_archivo);
            MessageBox.Show("EL AVANCE SE HA GENERADO EN D:\\");
            button5.Enabled = false;
        }

        private void avanceDiarioVPCSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "AVANCE_DIARIO_POR_PS_VPCS" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            crear_datagrid();
            consulta = "SELECT ENTREVIS as CUPO,DM_IMEI,CONCAT(SUBSTR(FECHA_CAPTURA,1,2),'_',SUBSTR(FECHA_CAPTURA,4,2) ,'_',SUBSTR(FECHA_CAPTURA,7,4))AS FECHA,COUNT(DISTINCT folio_encuesta)AS TOTAL FROM KIBIX where id_proceso=3 GROUP BY ENTREVIS, FECHA ORDER BY substr(FECHA,1,7) ; ";

            SIDM CLSSIDM = new SIDM();
            CLSSIDM.RellenarDatagrid_MySql(consulta, dataGridView1);
            productividad(dataGridView1);

            //EXPORTA EN ARCHIVO CSV
            Exportar_archivo clsexport = new Exportar_archivo();
            clsexport.Exportar_to_cvs(dataGridView3, nombre_archivo);
            MessageBox.Show("EL AVANCE SE HA GENERADO EN D:\\");
            button5.Enabled = false;
        }

        private void avanceDiarioRecertificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "AVANCE_DIARIO_POR_PS_RECERTIFICACION" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            crear_datagrid();
            consulta = "SELECT ENTREVIS as CUPO,DM_IMEI,CONCAT(SUBSTR(FECHA_CAPTURA,1,2),'_',SUBSTR(FECHA_CAPTURA,4,2) ,'_',SUBSTR(FECHA_CAPTURA,7,4))AS FECHA,COUNT(DISTINCT folio_encuesta)AS TOTAL FROM KIBIX where id_proceso=2 GROUP BY ENTREVIS, FECHA ORDER BY substr(FECHA,1,7) ; ";

            SIDM CLSSIDM = new SIDM();
            CLSSIDM.RellenarDatagrid_MySql(consulta, dataGridView1);
            productividad(dataGridView1);

            //EXPORTA EN ARCHIVO CSV
            Exportar_archivo clsexport = new Exportar_archivo();
            clsexport.Exportar_to_cvs(dataGridView3, nombre_archivo);
            MessageBox.Show("EL AVANCE SE HA GENERADO EN D:\\");
            button5.Enabled = false;
        }

        private void bITACORAMACToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "BITACORA_MAC_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView2.Rows.Clear();
            SIDM clssidm = new SIDM();
            consulta = "SELECT familia_id,num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo,MUNICI,LOCALI,gps_satelite,ageb,ageb_id as repetidos FROM KIBIX WHERE id_proceso=17 group by familia_id,fecha_captura order by familia_id ;";
            //consulta = "SELECT num_folio as familia_id,familia_id as num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=1 order by familia_id ;";
            clssidm.RellenarDatagrid_MySql(consulta, dataGridView1);

            Buscarv();
        }

        private void LabelInfo_Click(object sender, EventArgs e)
        {

        }

        private void avanceDiarioMasivoToolStripMenuItem_Click(object sender, EventArgs e)
  
        {
            nombre_archivo = "AVANCE_DIARIO_POR_PS_Masivo" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            crear_datagrid();
            consulta = "SELECT ENTREVIS as CUPO,DM_IMEI,CONCAT(SUBSTR(FECHA_CAPTURA,1,2),'_',SUBSTR(FECHA_CAPTURA,4,2) ,'_',SUBSTR(FECHA_CAPTURA,7,4))AS FECHA,COUNT(DISTINCT folio_encuesta)AS TOTAL FROM KIBIX where id_proceso in (2,3,4) GROUP BY ENTREVIS, FECHA ORDER BY substr(FECHA,1,7) ; ";

            SIDM CLSSIDM = new SIDM();
            CLSSIDM.RellenarDatagrid_MySql(consulta, dataGridView1);
            productividad(dataGridView1);

            //EXPORTA EN ARCHIVO CSV
            Exportar_archivo clsexport = new Exportar_archivo();
            clsexport.Exportar_to_cvs(dataGridView3, nombre_archivo);
            MessageBox.Show("EL AVANCE SE HA GENERADO EN D:\\");
            button5.Enabled = false;
        
        }

        private void mIGRACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "MIGRACION_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView2.Rows.Clear();
            SIDM clssidm = new SIDM();
            consulta = "SELECT familia_id,num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo,MUNICI,LOCALI,gps_satelite as repetidos FROM KIBIX WHERE id_proceso=43 group by familia_id,fecha_captura order by familia_id ;";
            //consulta = "SELECT num_folio as familia_id,familia_id as num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=1 order by familia_id ;";
            clssidm.RellenarDatagrid_MySql(consulta, dataGridView1);

            Buscarv();
        }

        private void avanceDeEncuestasDM4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "IDENTIFICACION_DM4" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();

            dataGridView2.Rows.Clear();
            SIDM clssidm = new SIDM();
            //consulta = "SELECT familia_id,num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=4 order by familia_id ;";
            consulta = "SELECT num_folio as familia_id,familia_id as num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo,MUNICI,LOCALI,ageb FROM KIBIX WHERE id_proceso=45  GROUP BY num_folio,fecha_captura order by familia_id;";
            clssidm.RellenarDatagrid_MySql(consulta, dataGridView1);

            Buscarv();
        }

        private void aVISOSDECOBROEMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "AC_EMS_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView2.Rows.Clear();
            SIDM clssidm = new SIDM();
            consulta = "SELECT folio_encuesta as familia_id,familia_id as num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo,MUNICI,LOCALI,ageb FROM KIBIX WHERE id_proceso=61  GROUP BY folio_encuesta,fecha_captura order by familia_id;";
            //consulta = "SELECT num_folio as familia_id,familia_id as num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=1 order by familia_id ;";
            clssidm.RellenarDatagrid_MySql(consulta, dataGridView1);

            Buscarv();
        }

        private void avanceDiarioACEMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "AVANCE_DIARIO_POR_PS_AVISOS_COBRO_EMS" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            crear_datagrid();
            consulta = "SELECT ENTREVIS as CUPO,DM_IMEI,CONCAT(SUBSTR(FECHA_CAPTURA,1,2),'_',SUBSTR(FECHA_CAPTURA,4,2) ,'_',SUBSTR(FECHA_CAPTURA,7,4))AS FECHA,COUNT(DISTINCT folio_encuesta)AS TOTAL FROM KIBIX where id_proceso=61 GROUP BY ENTREVIS, FECHA ORDER BY substr(FECHA,1,7) ; ";

            SIDM CLSSIDM = new SIDM();
            CLSSIDM.RellenarDatagrid_MySql(consulta, dataGridView1);
            productividad(dataGridView1);

            //EXPORTA EN ARCHIVO CSV
            Exportar_archivo clsexport = new Exportar_archivo();
            clsexport.Exportar_to_cvs(dataGridView3, nombre_archivo);
            MessageBox.Show("EL AVANCE SE HA GENERADO EN D:\\");
            button5.Enabled = false;
        }

        private void avanceEncuestasBasicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "IDENTIFICACION_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();

            dataGridView2.Rows.Clear();
            SIDM clssidm = new SIDM();
            //consulta = "SELECT familia_id,num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=4 order by familia_id ;";
            consulta = "SELECT folio_encuesta as familia_id,familia_id as num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo,MUNICI,LOCALI,ageb FROM KIBIX WHERE id_proceso=62  GROUP BY folio_encuesta,fecha_captura order by familia_id;";
            clssidm.RellenarDatagrid_MySql(consulta, dataGridView1);

            Buscarv();
        }

        private void avanceDiarioBasicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "AVANCE_DIARIO_POR_PS_BASICA" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            crear_datagrid();
            consulta = "SELECT ENTREVIS as CUPO,DM_IMEI,CONCAT(SUBSTR(FECHA_CAPTURA,1,2),'_',SUBSTR(FECHA_CAPTURA,4,2) ,'_',SUBSTR(FECHA_CAPTURA,7,4))AS FECHA,COUNT(DISTINCT folio_encuesta)AS TOTAL FROM KIBIX where id_proceso=62 GROUP BY ENTREVIS, FECHA ORDER BY substr(FECHA,1,7) ; ";

            SIDM CLSSIDM = new SIDM();
            CLSSIDM.RellenarDatagrid_MySql(consulta, dataGridView1);
            productividad(dataGridView1);

            //EXPORTA EN ARCHIVO CSV
            Exportar_archivo clsexport = new Exportar_archivo();
            clsexport.Exportar_to_cvs(dataGridView3, nombre_archivo);
            MessageBox.Show("EL AVANCE SE HA GENERADO EN G:\\");
            button5.Enabled = false;
        }

        private void iDENTIFICACIONCISBEBIENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nombre_archivo = "IDENTIFICACION_CISBEBIEN" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();

            dataGridView2.Rows.Clear();
            SIDM clssidm = new SIDM();
            //consulta = "SELECT familia_id,num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo FROM KIBIX WHERE id_proceso=4 order by familia_id ;";

            consulta = "SELECT folio_encuesta as familia_id,familia_id as num_folio,entrevis,usuario_captura,fecha_captura,res_entr,archivo,MUNICI,LOCALI,ageb FROM KIBIX WHERE id_proceso=60  GROUP BY folio_encuesta,fecha_captura order by familia_id;";
            clssidm.RellenarDatagrid_MySql(consulta, dataGridView1);

            Buscarv();
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

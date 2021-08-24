using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlServerCe;

namespace gsBuscar_cs
{
    class Respaldar
    {

        public void RellenarGrid_CompaqSQL(string consulta, string ruta, DataGridView Grid, DataGridView dataGridView2)
        {
            try
            {
                string SqlCeConfig = @"Data Source=" + ruta;
                //MessageBox.Show(SqlCeConfig.ToString());
                SqlCeConnection SqlCeCnn = new SqlCeConnection(SqlCeConfig);
                SqlCeCnn.Open();
                //MessageBox.Show("conectado");
                String strConnectionString = consulta;
                SqlCeCommand SqlCecmd = new SqlCeCommand(strConnectionString, SqlCeCnn);
                SqlCecmd.ExecuteNonQuery();
                //MessageBox.Show("query ejecutado");
                SqlCeDataAdapter da = new SqlCeDataAdapter(SqlCecmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Grid.DataSource = ds.Tables[0];//agrega los campos al data grid view
                SqlCeCnn.Close();
            }
            catch (SqlCeException ex2)
            {
                if (Convert.ToInt16(ex2.NativeError) == 25028)//si la BD tiene contraseña crea una nueva conexion para eso 
                {
                    try
                    {
                        string SqlCeConfig = @"Data Source=" + ruta + "; password=oportunidades";
                        //MessageBox.Show(SqlCeConfig.ToString());
                        SqlCeConnection SqlCeCnn = new SqlCeConnection(SqlCeConfig);
                        SqlCeCnn.Open();
                        //MessageBox.Show("conectado");
                        String strConnectionString = consulta;
                        SqlCeCommand SqlCecmd = new SqlCeCommand(strConnectionString, SqlCeCnn);
                        SqlCecmd.ExecuteNonQuery();
                        //MessageBox.Show("query ejecutado");
                        SqlCeDataAdapter da = new SqlCeDataAdapter(SqlCecmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        Grid.DataSource = ds.Tables[0];//agrega los campos al data grid view
                        SqlCeCnn.Close();
                    }
                    catch (SqlCeException ex3)
                    {
                        if (Convert.ToInt16(ex3.NativeError) == 25028)//si la BD tiene contraseña crea una nueva conexion para eso 
                        {
                            try
                            {
                                string SqlCeConfig = @"Data Source=" + ruta + "; password=0p3r2oii";
                                //MessageBox.Show(SqlCeConfig.ToString());
                                SqlCeConnection SqlCeCnn = new SqlCeConnection(SqlCeConfig);
                                SqlCeCnn.Open();
                                //MessageBox.Show("conectado");
                                String strConnectionString = consulta;
                                SqlCeCommand SqlCecmd = new SqlCeCommand(strConnectionString, SqlCeCnn);
                                SqlCecmd.ExecuteNonQuery();
                                //MessageBox.Show("query ejecutado");
                                SqlCeDataAdapter da = new SqlCeDataAdapter(SqlCecmd);
                                DataSet ds = new DataSet();
                                da.Fill(ds);
                                Grid.DataSource = ds.Tables[0];//agrega los campos al data grid view
                                SqlCeCnn.Close();
                            }
                            catch (SqlCeException ex4)
                            {
                               /* string mensaje = ex4.Message.ToString().Substring(0, 65);
                                if (mensaje != "La contraseña especificada no coincide con la de la base de datos")
                                    MessageBox.Show("Error:" + ex4.Message.ToString());
                                else
                                {*/
                                    dataGridView2.Rows.Insert(dataGridView2.RowCount - 1, 1);//incerta fila en datagrid
                                    dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[0].Value = ex4.Message.ToString();
                                    dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[1].Value = ruta;
                               // }

                            }
                            //MessageBox.Show("Error:" + ex.ToString());
                        }
                        else
                        {
                            //MessageBox.Show(ex3.Message.ToString());
                            dataGridView2.Rows.Insert(dataGridView2.RowCount - 1, 1);//incerta fila en datagrid
                            dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[0].Value = ex3.Message.ToString();
                            dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[1].Value = ruta;
                        }
                    }
                    //MessageBox.Show("Error:" + ex.ToString());
                }
                else
                {
                    /*if (ex2.Message.ToString() != "La tabla especificada no existe. [ RESUMEN ]")
                        MessageBox.Show(ex2.Message.ToString());
                    else
                    {*/
                        dataGridView2.Rows.Insert(dataGridView2.RowCount - 1, 1);//incerta fila en datagrid
                        dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[0].Value = ex2.Message.ToString();
                        dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[1].Value = ruta;
                   // }
                }
            }

        }


        public void Generar_Consulta(DataGridView dgv, string archivo)
        {
            string folio_encuesta = "", id_proceso = "", num_folio = "", familia_id = "", folio_prog = "", folio = "", entrevis = "", usuario_captura = "", hora_ini = "", hora_fin = "",  ent_fed = "", munici = "", locali = "";
            string loc_id = "", ageb = "", ageb_id = "", colonia_id = "", res_entr = "", total_registros = "", dm_imei = "", dm_sim = "", dm_modelo = "", dm_fabricante = "", gps_Latitud = "", gps_Longitud = "", gps_Hora = "", gps_satelite = "";
            string consulta = "";
            string fecha_captura;
  
            SIDM sidm = new SIDM();

            for (int i = 0; i <= dgv.Rows.Count - 2; i++)
            {

                
                id_proceso = dgv.Rows[i].Cells["id_proceso"].Value.ToString();
                folio_encuesta = dgv.Rows[i].Cells["folio_encuesta"].Value.ToString();
                num_folio = dgv.Rows[i].Cells["num_folio"].Value.ToString();
                familia_id = dgv.Rows[i].Cells["familia_id"].Value.ToString();
                folio_prog = dgv.Rows[i].Cells["folio_prog"].Value.ToString();
                entrevis = dgv.Rows[i].Cells["entrevis"].Value.ToString();
                usuario_captura = dgv.Rows[i].Cells["usuario_captura"].Value.ToString();
                hora_ini = dgv.Rows[i].Cells["hora_ini"].Value.ToString();
                hora_fin = dgv.Rows[i].Cells["hora_fin"].Value.ToString();
                fecha_captura = dgv.Rows[i].Cells["fecha_captura"].Value.ToString();
                ent_fed = dgv.Rows[i].Cells["ent_fed"].Value.ToString();
                munici = dgv.Rows[i].Cells["munici"].Value.ToString();
                locali = dgv.Rows[i].Cells["locali"].Value.ToString();
                loc_id = dgv.Rows[i].Cells["loc_id"].Value.ToString();
                ageb = dgv.Rows[i].Cells["ageb"].Value.ToString();
                ageb_id = dgv.Rows[i].Cells["ageb_id"].Value.ToString();
                colonia_id = dgv.Rows[i].Cells["colonia_id"].Value.ToString();
                res_entr = dgv.Rows[i].Cells["res_entr"].Value.ToString();
                total_registros = dgv.Rows[i].Cells["total_registros"].Value.ToString();
                dm_imei = dgv.Rows[i].Cells["dm_imei"].Value.ToString();
                dm_sim = dgv.Rows[i].Cells["dm_sim"].Value.ToString();
                dm_modelo = dgv.Rows[i].Cells["dm_modelo"].Value.ToString();
                dm_fabricante = dgv.Rows[i].Cells["dm_fabricante"].Value.ToString();
                gps_Latitud = dgv.Rows[i].Cells["gps_Latitud"].Value.ToString();
                gps_Longitud = dgv.Rows[i].Cells["gps_Longitud"].Value.ToString();


              
                //fecha_captura=Convert.ToDateTime(fecha.Substring(6,3) + "-" + fecha.Substring(3,2)+ "-" + fecha.Substring(0,2));
               /* if (semestre == 0)28/11/2011 01:08:56 p.m.
                {*/
                    gps_Hora = dgv.Rows[i].Cells["gps_Hora"].Value.ToString();
                    gps_satelite = dgv.Rows[i].Cells["gps_satelite"].Value.ToString();
                    folio = dgv.Rows[i].Cells["folio"].Value.ToString();


                    consulta = "INSERT INTO KIBIX(id_proceso,folio_encuesta,num_folio,familia_id,folio_prog,entrevis,usuario_captura,hora_ini,hora_fin,fecha_captura,ent_fed,munici,locali,loc_id,ageb,ageb_id,colonia_id,res_entr,total_registros,dm_imei,dm_sim,dm_modelo,dm_fabricante,gps_Latitud,gps_Longitud,gps_Hora,gps_satelite,folio,archivo) " +
                                "VALUES('" + id_proceso + "','" + folio_encuesta + "','" + num_folio + "','" + familia_id + "','" + folio_prog + "','" + entrevis + "','" + usuario_captura + "','" + hora_ini + "','" + hora_fin + "','" + fecha_captura + "','" + ent_fed + "','" + munici + "','" + locali + "','" + loc_id + "','" + ageb + "','" + ageb_id + "','" + colonia_id + "','" + res_entr + "','" + total_registros +
                                "','" + dm_imei + "','" + dm_sim + "','" + dm_modelo + "','" + dm_fabricante + "','" + gps_Latitud + "','" + gps_Longitud + "','" + gps_Hora + "','" + gps_satelite + "','" + folio + "','"+@archivo+"');";
                                
                             /*   
                                consulta = "INSERT INTO(za,folio_encuesta, id_proceso, num_folio, familia_id, folio_prog, folio, entrevis, usuario_captura, hora_ini, hora_fin, fecha_captura, ent_fed, munici, locali,loc_id, ageb, ageb_id, colonia_id, res_entr, total_registros, dm_imei, dm_sim, dm_modelo, dm_fabricante, gps_Latitud, gps_Longitud, gps_Hora,gps_satelite, VISITA) VALUES" +
                    "('" + semestre + "','" + za + "','" + folio_encuesta + "','" + id_proceso + "','" + num_folio + "','" + familia_id + "','" + folio_prog + "','" + folio + "','" + entrevis + "','" + usuario_captura + "','" + hora_ini + "','" + hora_fin + "','" + fecha_captura + "','" + ent_fed + "','" + munici + "','" + locali + "','" + loc_id + "','" + ageb + "','" + ageb_id + "','" + colonia_id + "','" + res_entr + "','" + total_registros + "','" + dm_imei + "','" + dm_sim + "','" + dm_modelo + "','" + dm_fabricante + "','" + gps_Latitud + "','" + gps_Longitud + "','" + gps_Hora + "','" + gps_satelite;
                // "('" + folio_encuesta + "','" + id_proceso + "','"+ num_folio+ "','"+ familia_id+ "','"+ folio_prog+ "','"+ folio+ "','"+ entrevis+ "','"+ usuario_captura+ "','"+ hora_ini+ "','"+ hora_fin+ "','"+ fecha_captura+ "','"+ ent_fed+ "','"+ munici+ "','"+ locali+ "','"+loc_id+ "','"+ ageb+ "','"+ ageb_id+ "','"+ colonia_id+ "','"+ res_entr+ "','"+ total_registros+ "','"+ dm_imei+ "','"+ dm_sim+ "','"+ dm_modelo+ "','"+ dm_fabricante+ "','"+ gps_Latitud+ "','"+ gps_Longitud+ "','"+ gps_Hora+ "','"+gps_satelite ;
                consulta_1 = "(semestre,za,folio_encuesta, id_proceso, num_folio, familia_id, folio_prog, folio, entrevis, usuario_captura, hora_ini, hora_fin, fecha_captura, ent_fed, munici, locali,loc_id, ageb, ageb_id, colonia_id, res_entr, total_registros, dm_imei, dm_sim, dm_modelo, dm_fabricante, gps_Latitud, gps_Longitud, gps_Hora,gps_satelite, VISITA,ARCHIVO) VALUES" +
                    "('" + semestre + "','" + za + "','" + folio_encuesta + "','" + id_proceso + "','" + num_folio + "','" + familia_id + "','" + folio_prog + "','" + folio + "','" + entrevis + "','" + usuario_captura + "','" + hora_ini + "','" + hora_fin + "','" + fecha_captura + "','" + ent_fed + "','" + munici + "','" + locali + "','" + loc_id + "','" + ageb + "','" + ageb_id + "','" + colonia_id + "','" + res_entr + "','" + total_registros + "','" + dm_imei + "','" + dm_sim + "','" + dm_modelo + "','" + dm_fabricante + "','" + gps_Latitud + "','" + gps_Longitud + "','" + gps_Hora + "','" + gps_satelite;
                */

                SIDM CLSSIDM = new SIDM();
                CLSSIDM.Respaldo_Recer(consulta);
            }
        }


        public void Generar_Consulta_Resumen(DataGridView dgv, string archivo,string ruta_guarda)
        {
            string folio_encuesta=" ",id_proceso="",num_folio=" ",familia_id=" ",folio_prog=" ",folio=" ",entrevis=" ",usuario_captura=" ";
            string hora_ini="",hora_fin="",fecha_captura=" ",ent_fed=" ",munici=" ",locali=" ",loc_id=" ",ageb=" ",ageb_id=" ",colonia_id=" ";
            string res_entr="",total_registros="",dm_imei=" ",dm_sim=" ",dm_modelo=" ",dm_fabricante=" ",gps_Latitud=" ",gps_Longitud=" ",gps_Hora=" ";
            string gps_satelite=" ", consulta = "";
            
            
            SIDM sidm = new SIDM();

            for (int i = 0; i <= dgv.Rows.Count - 2; i++)
            {

                folio_encuesta = dgv.Rows[i].Cells["folio_encuesta"].Value.ToString();
                id_proceso = dgv.Rows[i].Cells["id_proceso"].Value.ToString();
                num_folio = dgv.Rows[i].Cells["num_folio"].Value.ToString();
                familia_id = dgv.Rows[i].Cells["familia_id"].Value.ToString();
                folio_prog = dgv.Rows[i].Cells["folio_prog"].Value.ToString();
                folio = dgv.Rows[i].Cells["folio"].Value.ToString();
                entrevis = dgv.Rows[i].Cells["entrevis"].Value.ToString();
                usuario_captura = dgv.Rows[i].Cells["usuario_captura"].Value.ToString();
                hora_ini = dgv.Rows[i].Cells["hora_ini"].Value.ToString();
                hora_fin = dgv.Rows[i].Cells["hora_fin"].Value.ToString();
                fecha_captura = dgv.Rows[i].Cells["fecha_captura"].Value.ToString();
                ent_fed =dgv.Rows[i].Cells["ent_fed"].Value.ToString();
                munici = dgv.Rows[i].Cells["munici"].Value.ToString();
                locali = dgv.Rows[i].Cells["locali"].Value.ToString();
                loc_id = dgv.Rows[i].Cells["loc_id"].Value.ToString();
                ageb = dgv.Rows[i].Cells["ageb"].Value.ToString();
                ageb_id = dgv.Rows[i].Cells["ageb_id"].Value.ToString();
                colonia_id = dgv.Rows[i].Cells["colonia_id"].Value.ToString();
                res_entr = dgv.Rows[i].Cells["res_entr"].Value.ToString();
                total_registros = dgv.Rows[i].Cells["total_registros"].Value.ToString();
                dm_imei = dgv.Rows[i].Cells["dm_imei"].Value.ToString();
                dm_sim = dgv.Rows[i].Cells["dm_sim"].Value.ToString();
                dm_modelo = dgv.Rows[i].Cells["dm_modelo"].Value.ToString();
                dm_fabricante = dgv.Rows[i].Cells["dm_fabricante"].Value.ToString();
                gps_Latitud = dgv.Rows[i].Cells["gps_Latitud"].Value.ToString();
                gps_Longitud = dgv.Rows[i].Cells["gps_Longitud"].Value.ToString();
                gps_Hora = dgv.Rows[i].Cells["gps_Hora"].Value.ToString();
                gps_satelite = dgv.Rows[i].Cells["gps_satelite"].Value.ToString();


                if (num_folio == "")
                    num_folio = "NULL";
                if (ent_fed == "")
                    ent_fed = "NULL";
                if (munici == "")
                    munici = "NULL";
                if (locali == "")
                    locali = "NULL";
                if (loc_id == "")
                    loc_id = "NULL";
                if (ageb_id == "")
                    ageb_id = "NULL";
                if (ageb == "")
                    ageb = "NULL";
                if (colonia_id == "")
                    colonia_id = "NULL";
                if (dm_sim == "")
                    dm_sim = "000000 00000 0000 0000";
                if (gps_Latitud == "")
                    gps_Latitud = "NULL";
                if (gps_Longitud == "")
                    gps_Longitud = "NULL";
                if (gps_Hora == "")
                    gps_Hora = "NULL";
                if (gps_satelite == "")
                    gps_satelite = "NULL";

                fecha_captura= fecha_captura.Substring(0,fecha_captura.Length-5);
                hora_fin=hora_fin.Substring(0,hora_fin.Length-5);

                consulta = "INSERT INTO RESUMEN(folio_encuesta,id_proceso,num_folio,familia_id,folio_prog,folio,entrevis,usuario_captura,hora_ini,hora_fin,fecha_captura,ent_fed,munici,locali,loc_id,ageb,ageb_id,colonia_id,res_entr,total_registros,dm_imei,dm_sim,dm_modelo,dm_fabricante,gps_Latitud,gps_Longitud,gps_Hora,gps_satelite) " +
                           "VALUES("+ folio_encuesta + " , " + id_proceso + " , " + num_folio + " , " + familia_id + " , " + folio_prog + " , " + folio + " , " + entrevis + " , " + usuario_captura + " , '" + hora_ini + "' , '" + hora_fin + "' , '" + fecha_captura + "' , " + ent_fed + " , " + munici + " , " + locali + " , " + loc_id + " , " + ageb + " , " + ageb_id + " , " + colonia_id + " , " + res_entr + " , " + total_registros + " , '" + dm_imei + "' , '" + dm_sim + "' ,'" + dm_modelo + "' , '" + dm_fabricante + "', " + gps_Latitud + " , " + gps_Longitud + " , " + gps_Hora + " , " + gps_satelite + ");";                
                /* "VALUES(' " + folio_encuesta + " ',' " + id_proceso + " ',' " + num_folio + " ',' " + familia_id + " ',' " + folio_prog + " ',' " + folio + " ',' " + entrevis + " ',' " + usuario_captura + " ',' " + hora_ini + " ',' " + hora_fin + " ',' " + fecha_captura + " ',' " + ent_fed + " ',' " + munici + " ',' " + locali + 
                                     " ',' " + loc_id + " ',' " + ageb + " ',' " + ageb_id + " ',' " + colonia_id + " ',' " + res_entr + " ',' " + total_registros + " ',' " + dm_imei + " ',' " + dm_sim + " ',' " + dm_modelo + " ',' " + dm_fabricante + " ',' " + gps_Latitud + " ',' " + gps_Longitud + " ',' " + gps_Hora + " ',' " + gps_satelite + "')";
*/
                  
                Ejecuta_Consulta_SQLCE(consulta,ruta_guarda);

            }
        }

        public void Generar_Consulta_Captura(DataGridView dgv, string archivo, string ruta_guarda)
        {
            string folio_encuesta=" ",id_pregunta=" ",iteracion=" ",iteracion_anidada=" ",indice_respuesta=" ",valor=" ", id_pregunta_anterior = "",consulta="";

            SIDM sidm = new SIDM();

            for (int i = 0; i <= dgv.Rows.Count - 2; i++)
            {

                folio_encuesta = dgv.Rows[i].Cells["folio_encuesta"].Value.ToString();
                id_pregunta = dgv.Rows[i].Cells["id_pregunta"].Value.ToString();
                iteracion = dgv.Rows[i].Cells["iteracion"].Value.ToString();
                iteracion_anidada = dgv.Rows[i].Cells["iteracion_anidada"].Value.ToString();
                indice_respuesta = dgv.Rows[i].Cells["indice_respuesta"].Value.ToString();
                valor = dgv.Rows[i].Cells["valor"].Value.ToString();
                id_pregunta_anterior = dgv.Rows[i].Cells["id_pregunta_anterior"].Value.ToString();



                consulta = "INSERT INTO CAPTURA(folio_encuesta,id_pregunta,iteracion,iteracion_anidada,indice_respuesta,valor,id_pregunta_anterior) " +
                           "VALUES( " + folio_encuesta + " , " + id_pregunta + " , " + iteracion + " , " + iteracion_anidada + " , " + indice_respuesta + " ,' " + valor + "'," + id_pregunta_anterior + ");";
                /* "VALUES(' " + folio_encuesta + " ',' " + id_proceso + " ',' " + num_folio + " ',' " + familia_id + " ',' " + folio_prog + " ',' " + folio + " ',' " + entrevis + " ',' " + usuario_captura + " ',' " + hora_ini + " ',' " + hora_fin + " ',' " + fecha_captura + " ',' " + ent_fed + " ',' " + munici + " ',' " + locali + 
                                     " ',' " + loc_id + " ',' " + ageb + " ',' " + ageb_id + " ',' " + colonia_id + " ',' " + res_entr + " ',' " + total_registros + " ',' " + dm_imei + " ',' " + dm_sim + " ',' " + dm_modelo + " ',' " + dm_fabricante + " ',' " + gps_Latitud + " ',' " + gps_Longitud + " ',' " + gps_Hora + " ',' " + gps_satelite + "')";
*/
                Ejecuta_Consulta_SQLCE(consulta, ruta_guarda);

            }
        }


        public void Ejecuta_Consulta_SQLCE(string consulta, string ruta_guarda)
        {
            try
            {
                string SqlCeConfig = @"Data Source=" + ruta_guarda + "; password=0p3r2oii"; ;
                SqlCeConnection SqlCeCnn = new SqlCeConnection(SqlCeConfig);
                SqlCeCnn.Open();

                String strConnectionString = consulta;
                SqlCeCommand SqlCecmd = new SqlCeCommand(strConnectionString, SqlCeCnn);
                SqlCecmd.ExecuteNonQuery();
                //MessageBox.Show("Los Datos han sido Guardados");
                SqlCeCnn.Close();
            }
            catch (SqlCeException ex)
            {
                //SqlCeCnn.Close();
                MessageBox.Show(ex.Message.ToString());
            }

        }


        public void RellenarGrid_CompaqSQL(string consulta, string ruta, DataGridView Grid)
        {
            try
            {
                string SqlCeConfig = @"Data Source=" + ruta + "; password=0p3r2oii";
                //MessageBox.Show(SqlCeConfig.ToString());
                SqlCeConnection SqlCeCnn = new SqlCeConnection(SqlCeConfig);
                SqlCeCnn.Open();
                //MessageBox.Show("conectado");
                String strConnectionString = consulta;
                SqlCeCommand SqlCecmd = new SqlCeCommand(strConnectionString, SqlCeCnn);
                SqlCecmd.ExecuteNonQuery();
                //MessageBox.Show("query ejecutado");
                SqlCeDataAdapter da = new SqlCeDataAdapter(SqlCecmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Grid.DataSource = ds.Tables[0];//agrega los campos al data grid view
                SqlCeCnn.Close();
            }
            catch (SqlCeException ex2)
            {
                if (Convert.ToInt16(ex2.NativeError) == 25028)//si la BD tiene contraseña crea una nueva conexion para eso 
                {
                    try
                    {
                        string SqlCeConfig = @"Data Source=" + ruta + "; password=r33v47"; ;
                        //MessageBox.Show(SqlCeConfig.ToString());
                        SqlCeConnection SqlCeCnn = new SqlCeConnection(SqlCeConfig);
                        SqlCeCnn.Open();
                        //MessageBox.Show("conectado");
                        String strConnectionString = consulta;
                        SqlCeCommand SqlCecmd = new SqlCeCommand(strConnectionString, SqlCeCnn);
                        SqlCecmd.ExecuteNonQuery();
                        //MessageBox.Show("query ejecutado");
                        SqlCeDataAdapter da = new SqlCeDataAdapter(SqlCecmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        Grid.DataSource = ds.Tables[0];//agrega los campos al data grid view
                        SqlCeCnn.Close();
                    }
                    catch (SqlCeException ex3)
                    {
                        if (Convert.ToInt16(ex3.NativeError) == 25028)//si la BD tiene contraseña crea una nueva conexion para eso 
                        {
                            try
                            {
                                string SqlCeConfig = @"Data Source=" + ruta;
                                //MessageBox.Show(SqlCeConfig.ToString());
                                SqlCeConnection SqlCeCnn = new SqlCeConnection(SqlCeConfig);
                                SqlCeCnn.Open();
                                //MessageBox.Show("conectado");
                                String strConnectionString = consulta;
                                SqlCeCommand SqlCecmd = new SqlCeCommand(strConnectionString, SqlCeCnn);
                                SqlCecmd.ExecuteNonQuery();
                                //MessageBox.Show("query ejecutado");
                                SqlCeDataAdapter da = new SqlCeDataAdapter(SqlCecmd);
                                DataSet ds = new DataSet();
                                da.Fill(ds);
                                Grid.DataSource = ds.Tables[0];//agrega los campos al data grid view
                                SqlCeCnn.Close();
                            }
                            catch (SqlCeException ex4)
                            {
                                /* string mensaje = ex4.Message.ToString().Substring(0, 65);
                                 if (mensaje != "La contraseña especificada no coincide con la de la base de datos")
                                    */
                                //MessageBox.Show("Error:" + ex4.Message.ToString());
                                /*else
                                {*/
                                /* dataGridView2.Rows.Insert(dataGridView2.RowCount - 1, 1);//incerta fila en datagrid
                                 dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[0].Value = ex4.Message.ToString();
                                 dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[1].Value = ruta;*/
                                // }
                                //MessageBox.Show("Error:" + ex4.Message.ToString());
                            }

                        }
                        else
                        {
                            // MessageBox.Show(ex3.Message.ToString());
                            /*dataGridView2.Rows.Insert(dataGridView2.RowCount - 1, 1);//incerta fila en datagrid
                            dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[0].Value = ex3.Message.ToString();
                            dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[1].Value = ruta;*/
                        }
                    }
                    //MessageBox.Show("Error:" + ex3.ToString());
                }
                else
                {
                    // if (ex2.Message.ToString() != "La tabla especificada no existe. [ RESUMEN ]")
                    //MessageBox.Show(ex2.Message.ToString());
                    /*else
                    {
                    /*dataGridView2.Rows.Insert(dataGridView2.RowCount - 1, 1);//incerta fila en datagrid
                    dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[0].Value = ex2.Message.ToString();
                    dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[1].Value = ruta;*/
                    // }
                }
            }

        }
    }
}

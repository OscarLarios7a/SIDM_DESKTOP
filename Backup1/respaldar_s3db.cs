using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace gsBuscar_cs
{
    class respaldar_s3db
    {

        public void RellenarGrid_CompaqSQL(string consulta, string ruta, DataGridView Grid, DataGridView dataGridView2)
        {
            try
            {
                string SqlCeConfig = @"Data Source=" + ruta;
                //MessageBox.Show(SqlCeConfig.ToString());
                SQLiteConnection SQLiteCnn = new SQLiteConnection(SqlCeConfig);
                SQLiteCnn.Open();
                //MessageBox.Show("conectado");
                String strConnectionString = consulta;
                SQLiteCommand SQLitecmd = new SQLiteCommand(strConnectionString, SQLiteCnn);
                SQLitecmd.ExecuteNonQuery();
                //MessageBox.Show("query ejecutado");
                SQLiteDataAdapter da = new SQLiteDataAdapter(SQLitecmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Grid.DataSource = ds.Tables[0];//agrega los campos al data grid view
                SQLiteCnn.Close();
            }
            catch (SQLiteException ex2) { }


        }


        public void Generar_Consulta(DataGridView dgv, string archivo)
        {
            string folio_encuesta = "", id_proceso = "", num_folio = "", familia_id = "", folio_prog = "", folio = "", entrevis = "", usuario_captura = "", hora_ini = "", hora_fin = "", ent_fed = "", munici = "", locali = "";
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


                gps_Hora = dgv.Rows[i].Cells["gps_Hora"].Value.ToString();
                gps_satelite = dgv.Rows[i].Cells["gps_satelite"].Value.ToString();
                folio = dgv.Rows[i].Cells["folio"].Value.ToString();


                consulta = "INSERT INTO KIBIX(id_proceso,folio_encuesta,num_folio,familia_id,folio_prog,entrevis,usuario_captura,hora_ini,hora_fin,fecha_captura,ent_fed,munici,locali,loc_id,ageb,ageb_id,colonia_id,res_entr,total_registros,dm_imei,dm_sim,dm_modelo,dm_fabricante,gps_Latitud,gps_Longitud,gps_Hora,gps_satelite,folio,archivo) " +
                            "VALUES('" + id_proceso + "','" + folio_encuesta + "','" + num_folio + "','" + familia_id + "','" + folio_prog + "','" + entrevis + "','" + usuario_captura + "','" + hora_ini + "','" + hora_fin + "','" + fecha_captura + "','" + ent_fed + "','" + munici + "','" + locali + "','" + loc_id + "','" + ageb + "','" + ageb_id + "','" + colonia_id + "','" + res_entr + "','" + total_registros +
                            "','" + dm_imei + "','" + dm_sim + "','" + dm_modelo + "','" + dm_fabricante + "','" + gps_Latitud + "','" + gps_Longitud + "','" + gps_Hora + "','" + gps_satelite + "','" + folio + "','" + @archivo + "');";

                SIDM CLSSIDM = new SIDM();
                CLSSIDM.Respaldo_Recer(consulta);
            }
        }

    }
}

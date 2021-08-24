using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace gsBuscar_cs
{
    class unir_bd
    {
        public void respaldar_encuesta(DataGridView dgv, string archivo, string ruta_guarda, Label lbl, string consulta_resumen, string consulta_captura)
        {
            // string consulta="";
            Respaldar clscompaqsql = new Respaldar();

            // consulta = "SELECT * FROM RESUMEN";
            clscompaqsql.RellenarGrid_CompaqSQL(consulta_resumen, archivo, dgv);
            //lbl.Text = "RESPALDANDO RESUMEN DE RUTA:"+ archivo;
            Generar_Consulta_Resumen(dgv, archivo, ruta_guarda, lbl);


            // consulta = "SELECT * FROM CAPTURA;";
            clscompaqsql.RellenarGrid_CompaqSQL(consulta_captura, archivo, dgv);
            lbl.Text = "RESPALDANDO CAPTURA DE RUTA:" + archivo;
            Generar_Consulta_Captura(dgv, archivo, ruta_guarda, lbl);

        }



        private void Generar_Consulta_Resumen(DataGridView dgv, string archivo, string ruta_guarda, Label lbl)
        {
            try
            {
                string folio_encuesta = " ", id_proceso = "", num_folio = " ", familia_id = " ", folio_prog = " ", folio = " ", entrevis = " ", usuario_captura = " ";
                string hora_ini = "", hora_fin = "", fecha_captura = " ", ent_fed = " ", munici = " ", locali = " ", loc_id = " ", ageb = " ", ageb_id = " ", colonia_id = " ";
                string res_entr = "", total_registros = "", dm_imei = " ", dm_sim = " ", dm_modelo = " ", dm_fabricante = " ", gps_Latitud = " ", gps_Longitud = " ", gps_Hora = " ";
                string gps_satelite = " ", consulta = "";
                Respaldar clscompaqsql = new Respaldar();


                //SIDM sidm = new SIDM();

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


                    lbl.Text = "RESPALDANDO RESUMEN  DE RUTA:  " + archivo + "  FOLIO  " + i + " DE " + dgv.Rows.Count;

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

                    // fecha_captura = fecha_captura.Substring(0, fecha_captura.Length - 5);
                    //hora_fin = hora_fin.Substring(0, hora_fin.Length - 5);

                    consulta = "INSERT INTO RESUMEN(folio_encuesta,id_proceso,num_folio,familia_id,folio_prog,folio,entrevis,usuario_captura,hora_ini,hora_fin,fecha_captura,ent_fed,munici,locali,loc_id,ageb,ageb_id,colonia_id,res_entr,total_registros,dm_imei,dm_sim,dm_modelo,dm_fabricante,gps_Latitud,gps_Longitud,gps_Hora,gps_satelite) " +
                               "VALUES(" + folio_encuesta + " , " + id_proceso + " , " + num_folio + " , " + familia_id + " , " + folio_prog + " , " + folio + " , " + entrevis + " , " + usuario_captura + " , '" + hora_ini + "' , '" + hora_fin + "' , '" + fecha_captura + "' , " + ent_fed + " , " + munici + " , " + locali + " , " + loc_id + " ,' " + ageb + " ', " + ageb_id + " , " + colonia_id + " , " + res_entr + " , " + total_registros + " , '" + dm_imei + "' , '" + dm_sim + "' ,'" + dm_modelo + "' , '" + dm_fabricante + "', " + gps_Latitud + " , " + gps_Longitud + " , " + gps_Hora + " , " + gps_satelite + ");";
                    /* "VALUES(' " + folio_encuesta + " ',' " + id_proceso + " ',' " + num_folio + " ',' " + familia_id + " ',' " + folio_prog + " ',' " + folio + " ',' " + entrevis + " ',' " + usuario_captura + " ',' " + hora_ini + " ',' " + hora_fin + " ',' " + fecha_captura + " ',' " + ent_fed + " ',' " + munici + " ',' " + locali + 
                                         " ',' " + loc_id + " ',' " + ageb + " ',' " + ageb_id + " ',' " + colonia_id + " ',' " + res_entr + " ',' " + total_registros + " ',' " + dm_imei + " ',' " + dm_sim + " ',' " + dm_modelo + " ',' " + dm_fabricante + " ',' " + gps_Latitud + " ',' " + gps_Longitud + " ',' " + gps_Hora + " ',' " + gps_satelite + "')";
    */
                    clscompaqsql.Ejecuta_Consulta_SQLCE(consulta, ruta_guarda);

                }
            }
            catch (Exception ex) { }
        }

        private void Generar_Consulta_Captura(DataGridView dgv, string archivo, string ruta_guarda, Label lbl)
        {
            try
            {
                string folio_encuesta = " ", id_pregunta = " ", iteracion = " ", iteracion_anidada = " ", indice_respuesta = " ", valor = " ", id_pregunta_anterior = "", consulta = "";
                Respaldar clscompaqsql = new Respaldar();
                //SIDM sidm = new SIDM();

                for (int i = 0; i <= dgv.Rows.Count - 2; i++)
                {

                    folio_encuesta = dgv.Rows[i].Cells["folio_encuesta"].Value.ToString();
                    id_pregunta = dgv.Rows[i].Cells["id_pregunta"].Value.ToString();
                    iteracion = dgv.Rows[i].Cells["iteracion"].Value.ToString();
                    iteracion_anidada = dgv.Rows[i].Cells["iteracion_anidada"].Value.ToString();
                    indice_respuesta = dgv.Rows[i].Cells["indice_respuesta"].Value.ToString();
                    valor = dgv.Rows[i].Cells["valor"].Value.ToString();
                    id_pregunta_anterior = dgv.Rows[i].Cells["id_pregunta_anterior"].Value.ToString();

                    lbl.Text = "RESPALDANDO  CAPTURA  DE RUTA:  " + archivo + "  FOLIO  " + i + " DE " + dgv.Rows.Count;


                    consulta = "INSERT INTO CAPTURA(folio_encuesta,id_pregunta,iteracion,iteracion_anidada,indice_respuesta,valor,id_pregunta_anterior) " +
                               "VALUES( " + folio_encuesta + " , " + id_pregunta + " , " + iteracion + " , " + iteracion_anidada + " , " + indice_respuesta + " ,' " + valor + "'," + id_pregunta_anterior + ");";
                    /* "VALUES(' " + folio_encuesta + " ',' " + id_proceso + " ',' " + num_folio + " ',' " + familia_id + " ',' " + folio_prog + " ',' " + folio + " ',' " + entrevis + " ',' " + usuario_captura + " ',' " + hora_ini + " ',' " + hora_fin + " ',' " + fecha_captura + " ',' " + ent_fed + " ',' " + munici + " ',' " + locali + 
                                         " ',' " + loc_id + " ',' " + ageb + " ',' " + ageb_id + " ',' " + colonia_id + " ',' " + res_entr + " ',' " + total_registros + " ',' " + dm_imei + " ',' " + dm_sim + " ',' " + dm_modelo + " ',' " + dm_fabricante + " ',' " + gps_Latitud + " ',' " + gps_Longitud + " ',' " + gps_Hora + " ',' " + gps_satelite + "')";
    */
                    clscompaqsql.Ejecuta_Consulta_SQLCE(consulta, ruta_guarda);

                }
            }
            catch (Exception ex) { }
        }

    }
}

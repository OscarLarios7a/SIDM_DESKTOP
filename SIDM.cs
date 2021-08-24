using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;


namespace gsBuscar_cs
{
    class SIDM
    {
        public static string MysqlConfig;// "Database=sidm;Data Source=localhost;User Id=Root;Password=12345;";
        public static MySqlConnection MySqlCnn;
        public static string fecha, visitax, cupo, codigo, arch;

        public void inicia_MySqlConfig(string server)
        {

            MysqlConfig = "SERVER=" + server + ";Database=sidm;UID=root;password=oportunidades";
            MySqlCnn = new MySqlConnection(MysqlConfig);
        }


        public void Respaldo_Recer(string consulta)
        {
            try
            {
                MySqlCnn.Open();
                MySqlCommand MySqlcmd = new MySqlCommand(consulta, MySqlCnn);
                MySqlcmd.ExecuteNonQuery();

                //MessageBox.Show("Los Datos han sido Guardados");
                MySqlCnn.Close();
            }
            catch (MySqlException ex)
            {
                MySqlCnn.Close();
                MessageBox.Show(ex.Message.ToString());
            }
        }


        public void Respaldo_Recer(string consulta, string consulta_1, string familia_id, string id_proceso, string archivo, string tabla, string num_folio, int periodo)
        {

            int contador = 0;
            string consulta_update = "";
           /* switch (periodo)
            {
                case 0:
                    {*/
                        if (id_proceso == "1")
                            contador = Convert.ToInt16(obten_valor("select visita from " + tabla + " where num_folio='" + num_folio + "' and id_proceso='" + id_proceso + "'", "visita"));
                        else
                            contador = Convert.ToInt16(obten_valor("select visita from " + tabla + " where familia_id='" + familia_id + "' and id_proceso='" + id_proceso + "'", "visita"));


                        consulta_update = "INSERT INTO " + tabla + "_DETALLE" + consulta_1;
                        consulta = "INSERT INTO " + tabla + consulta;

                        if (contador == 0)
                        {
                            contador = 1;
                            consulta += "','" + contador + "');";
                        }
                        else
                        {
                            contador++;
                            if (id_proceso == "1")
                                consulta = "update " + tabla + " SET visita='" + contador + "' where num_folio='" + num_folio + "' and id_proceso='" + id_proceso + "';";
                            else
                                consulta = "update " + tabla + " SET visita='" + contador + "' where familia_id='" + familia_id + "' and id_proceso='" + id_proceso + "';";

                        }
                        consulta_update += "','" + contador + "','" + archivo + "');";
                        consulta += consulta_update;
/*
                        break;
                    }
                case 1:
                    {
                        if (id_proceso == "3")
                            contador = Convert.ToInt16(obten_valor("select visita from " + tabla + " where num_folio='" + num_folio + "' and id_proceso='" + id_proceso + "'", "visita"));
                        else
                            contador = Convert.ToInt16(obten_valor("select visita from " + tabla + " where familia_id='" + familia_id + "' and id_proceso='" + id_proceso + "'", "visita"));


                        consulta_update = "INSERT INTO " + tabla + "_DETALLE" + consulta_1;
                        consulta = "INSERT INTO " + tabla + consulta;

                        if (contador == 0)
                        {
                            contador = 1;
                            consulta += "','" + contador + "');";
                        }
                        else
                        {
                            contador++;
                            if (id_proceso == "3")
                                consulta = "update " + tabla + " SET visita='" + contador + "' where num_folio='" + num_folio + "' and id_proceso='" + id_proceso + "';";
                            else
                                consulta = "update " + tabla + " SET visita='" + contador + "' where familia_id='" + familia_id + "' and id_proceso='" + id_proceso + "';";

                        }
                        consulta_update += "','" + contador + "','" + archivo + "');";
                        consulta += consulta_update;

                        break;
                    }
            }
            */


            try
            {
                MySqlCnn.Open();
                MySqlCommand MySqlcmd = new MySqlCommand(consulta, MySqlCnn);
                MySqlcmd.ExecuteNonQuery();

                //MessageBox.Show("Los Datos han sido Guardados");
                MySqlCnn.Close();
            }
            catch (MySqlException ex)
            {
                MySqlCnn.Close();
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void RellenarDatagrid_MySql(string consulta, DataGridView Grid)
        {
            try
            {
                MySqlConnection MySqlCnn = new MySqlConnection(MysqlConfig);
                MySqlCnn.Open();
                String strConnectionString = consulta;
                MySqlCommand MySqlcmd = new MySqlCommand(strConnectionString, MySqlCnn);
                MySqlcmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(MySqlcmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Grid.DataSource = ds.Tables[0];//agrega los campos al data grid view
                MySqlCnn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
        }

        public string obten_valor(string consulta, string valor)
        {
            string variable = "0";
            MySqlCommand MySqlcmd = new MySqlCommand(consulta, MySqlCnn);

            try
            {
                MySqlCnn.Open();

                MySqlDataReader MySqlDr = MySqlcmd.ExecuteReader();
                int i = 1;
                if (MySqlDr.Read())
                {
                    i++;

                    variable = (string)MySqlDr[valor].ToString();

                    MySqlDr.Close();
                    // MySqlDr.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
            finally
            {
                MySqlCnn.Close();
                MySqlCnn.Dispose();
                MySqlcmd.Dispose();
            }
            return variable;
        }//fin del metodo rellenar cajas


        public void obten_valor_x(string consulta)
        {
            MySqlCommand MySqlcmd = new MySqlCommand(consulta, MySqlCnn);

            try
            {
                MySqlCnn.Open();

                MySqlDataReader MySqlDr = MySqlcmd.ExecuteReader();
                int i = 1;
                if (MySqlDr.Read())
                {
                    i++;

                    //variable = (string)MySqlDr[].ToString();
                    fecha= (string)MySqlDr["FECHA"].ToString();
                    visitax = (string)MySqlDr["VISITAS"].ToString();
                    cupo = (string)MySqlDr["CUPO"].ToString();
                    codigo = (string)MySqlDr["CR"].ToString();
                    arch = (string)MySqlDr["ARCHIVO"].ToString();


                    MySqlDr.Close();
                    // MySqlDr.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
            finally
            {
                MySqlCnn.Close();
                MySqlCnn.Dispose();
                MySqlcmd.Dispose();
            }
          
        }//fin del metodo rellenar cajas


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using nmExcel = Microsoft.Office.Interop.Excel;
using System.Collections;
using System.Data;



namespace gsBuscar_cs
{
    class Exportar_archivo
    {

        /*public void Exportar_to_doc(DataGridView dgv)
        { 
        
            try
            {

                ArrayList titulos = new ArrayList();

                DataTable datosTabla = new DataTable();

                //Especificar ruta del archivo con extensión de WORD.

                OtrosFormatos OF = new OtrosFormatos(Application.StartupPath+ @"c:\test.doc");

                //obtenemos los titulos del grid y creamos las columnas de la tabla

                foreach (DataGridViewColumn item in dataGridView1.Columns)

                {

                titulos.Add(item.HeaderText);

                datosTabla.Columns.Add();

                }

                //se crean los renglones de la tabla

                foreach (DataGridViewRow item in dataGridView1.Rows)

                {

                DataRow rowx = datosTabla.NewRow();

                datosTabla.Rows.Add(rowx);

                }

                //se pasan los datos del dataGridView a la tabla

                foreach (DataGridViewColumn item in dataGridView1.Columns)

                {

                foreach (DataGridViewRow itemx in dataGridView1.Rows)

                {

                datosTabla.Rows[itemx.Index][item.Index] =

                dataGridView1[item.Index, itemx.Index].Value;

                }

                }

                OF.Export(titulos, datosTabla);

                Process.Start(OF.xpath);

                MessageBox.Show("Proceso Completo");

            }

            catch(Exception ex)

            {

            MessageBox.Show(ex.Message);

            }
        }*/


        public void Exportar_to_Otro_formato(DataGridView dgv, string ruta)
        {

            try
            {
                //Obtiene encabezados

                ArrayList titulos = new ArrayList(); ;
                foreach (DataGridViewColumn item in dgv.Columns)
                {
                    titulos.Add(item.HeaderText);
                }


                // FileStream fs = new FileStream(@"c\TTT.htm", FileMode.Create,FileAccess.ReadWrite);
                FileStream fs = new FileStream(ruta, FileMode.Create, FileAccess.ReadWrite);
                StreamWriter w = new StreamWriter(fs);
                string comillas = char.ConvertFromUtf32(34);
                StringBuilder html = new StringBuilder();

                html.Append(@"<!DOCTYPE html PUBLIC" + comillas + "-//W3C//DTD XHTML 1.0 Transitional//EN" + comillas + " " + comillas

                /*+ http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd

                + comillas */
                             + ">");

                html.Append(@"<html xmlns=" + comillas

                /*+ http://www.w3.org/1999/xhtml

                + comillas */
                             + ">");

                html.Append(@"<head>");

                html.Append(@"<meta http-equiv=" + comillas + "Content-Type"

                + comillas + "content=" + comillas

                + "text/html; charset=utf-8" + comillas + "/>");

                html.Append(@"<title>Untitled Document</title>");

                html.Append(@"</head>");

                html.Append(@"<body>");



                //Generando encabezados del archivo

                //(aquí podemos dar el formato como a una tabla de HTML)

                html.Append(@"<table WIDTH=730 CELLSPACING=0 CELLPADDING=10

                border=8 BORDERCOLOR=" + comillas + "#333366"

                + comillas + " bgcolor=" + comillas + "#FFFFFF"

                + comillas + ">");

                html.Append(@"<tr> <b>");


                foreach (object item in titulos)
                {
                    try
                    {
                        html.Append(@"<th>" + item.ToString() + "</th>");
                    }
                    catch (Exception EX) { }
                }

                html.Append(@"</b> </tr>");




                //Generando datos del archivo

                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    try
                    {
                        html.Append(@"<tr>");
                        DataGridViewRow Fila = dgv.Rows[i];

                        for (int j = 0; j < Fila.Cells.Count; j++)
                        {
                            try
                            {
                                html.Append(@"<td>" + dgv[j, i].Value.ToString() + "</td>");
                            }
                            catch (Exception EX) { }
                        }
                        html.Append(@"</tr>");
                    }
                    catch (Exception EX) { }

                }

                html.Append(@"</body>");

                html.Append(@"</html>");

                w.Write(html.ToString());

                w.Close();

            }

            catch (Exception ex)
            {

                throw ex;

            }
        }



        public void Exportar_to_cvs(DataGridView datos,string nombre_archivo)
        {
            try
            {

                //Obtiene encabezados

                ArrayList titulos = new ArrayList(); ;
                foreach (DataGridViewColumn item in datos.Columns)
                {
                    titulos.Add(item.HeaderText);
                }



                FileStream fs = new FileStream(@"e:\"+nombre_archivo+".csv", FileMode.Create, FileAccess.ReadWrite);

                StreamWriter w = new StreamWriter(fs);

                string comillas = char.ConvertFromUtf32(34);

                StringBuilder CSV = new StringBuilder();


                //Incerta Encabezados

                for (int i = 0; i < titulos.Count; i++)
                {

                    if (i != (titulos.Count - 1))

                        CSV.Append(comillas + titulos[i].ToString() + comillas + ",");

                    else

                        CSV.Append(comillas + titulos[i].ToString() + comillas + Environment.NewLine);

                }

                // se generan datos


                for (int i = 0; i < datos.Rows.Count - 1; i++)
                {
                    DataGridViewRow Fila = datos.Rows[i];
                    for (int j = 0; j < Fila.Cells.Count; j++)
                    {

                        if (j != (titulos.Count - 1))

                            CSV.Append(comillas + datos[j, i].Value.ToString() + comillas + ",");

                        else

                            CSV.Append(comillas + datos[j, i].Value.ToString() + comillas + Environment.NewLine);

                    }

                }

                w.Write(CSV.ToString());

                w.Close();

            }

            catch (Exception ex)
            {

                throw ex;

            }

        }



        public void Exportar_to_xls(DataGridView dgv)
        {
            ArrayList titulos = new ArrayList();
            foreach (DataGridViewColumn item in dgv.Columns)
            {

                titulos.Add(item.HeaderText);

                //MessageBox.Show(item.HeaderText.ToString());
            }



            nmExcel.ApplicationClass ExcelApp = new nmExcel.ApplicationClass();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 12;


            for (int i = 0; i < titulos.Count; i++)
            {
                //checar filas y columnas
                ExcelApp.Cells[1, i + 2] = titulos[i].ToString();

            }


            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataGridViewRow Fila = dgv.Rows[i];
                for (int j = 0; j < Fila.Cells.Count; j++)
                {
                    if (i + 1 == 1)
                        ExcelApp.Cells[i + 2, j + 2] = Fila.Cells[j].Value;
                    else
                        ExcelApp.Cells[i + 2, j + 2] = Fila.Cells[j].Value;
                }
            }

            // ---------- cuadro de dialogo para Guardar
            SaveFileDialog CuadroDialogo = new SaveFileDialog();
            CuadroDialogo.DefaultExt = "xls";
            CuadroDialogo.Filter = "xls file(*.xls)|*.xls";
            CuadroDialogo.AddExtension = true;
            CuadroDialogo.RestoreDirectory = true;
            CuadroDialogo.Title = "Guardar";
            CuadroDialogo.InitialDirectory = @"e:\";
            if (CuadroDialogo.ShowDialog() == DialogResult.OK)
            {
                ExcelApp.ActiveWorkbook.SaveCopyAs(CuadroDialogo.FileName);
                ExcelApp.ActiveWorkbook.Saved = true;
                CuadroDialogo.Dispose();
                CuadroDialogo = null;
                ExcelApp.Quit();
            }
            else
            {
                MessageBox.Show("No se pudo guardar Datos .. ");
            }

        }


        public void Exportar_pdf(DataGridView dg)
        {
            try
            {
                Document doc = new Document(PageSize.A0.Rotate(), 10, 10, 10, 10);

                string filename = @"e:\DataGridViewTest.pdf";

                FileStream file = new FileStream(filename,

                FileMode.OpenOrCreate,

                FileAccess.ReadWrite,

                FileShare.ReadWrite);

                PdfWriter.GetInstance(doc, file);

                doc.Open();

                GenerarDocumento(doc, dg);

                doc.Close();

                Process.Start(filename);
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

        //Función que genera el documento Pdf

        public void GenerarDocumento(Document document, DataGridView dataGridView1)
        {
            //se crea un objeto PdfTable con el numero de columnas del

            //dataGridView

            PdfPTable datatable = new PdfPTable(dataGridView1.ColumnCount);

            //asignamos algunas propiedades para el diseño del pdf
            datatable.DefaultCell.Padding = 3;

            float[] headerwidths = GetTamañoColumnas(dataGridView1);

            datatable.SetWidths(headerwidths);

            datatable.WidthPercentage = 100;

            datatable.DefaultCell.BorderWidth = 2;

            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;


            //SE GENERA EL ENCABEZADO DE LA TABLA EN EL PDF

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {

                datatable.AddCell(dataGridView1.Columns[i].HeaderText);

            }


            datatable.HeaderRows = 1;

            datatable.DefaultCell.BorderWidth = 1;


            //SE GENERA EL CUERPO DEL PDF

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {

                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    datatable.AddCell(dataGridView1[j, i].Value.ToString());

                }

                datatable.CompleteRow();

            }


            //SE AGREGAR LA PDFPTABLE AL DOCUMENTO

            document.Add(datatable);

        }



        //Función que obtiene los tamaños de las columnas del grid

        public float[] GetTamañoColumnas(DataGridView dg)
        {

            float[] values = new float[dg.ColumnCount];

            for (int i = 0; i < dg.ColumnCount; i++)
            {

                values[i] = (float)dg.Columns[i].Width;

            }

            return values;

        }

    }
}

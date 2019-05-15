using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ceriv.Formularios
{
    public partial class FR_Dinamico : Form
    {
        string cadenaConexion = "Server=192.168.1.97; port = 5432 ;User Id=postgres;Password=root;Database=Ceriv";
        public FR_Dinamico()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(txt_Consulta.Text, cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);

                dgv_Reporte.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la accion", ex);
            }
            finally
            {
                cnn.Close();
            }
        }
        private void CargarTodoDataGridView()
        {
            dgv_Reporte.SelectAll();
            DataObject dataObj = dgv_Reporte.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void btn_importar_Click(object sender, EventArgs e)
        {
            if (dgv_Reporte.Rows.Count > 0)
            {
                CargarTodoDataGridView();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
            }
            else
            {
                MessageBox.Show("No hay Registros Para Exportar");
                return;
            }
        }
    }
}

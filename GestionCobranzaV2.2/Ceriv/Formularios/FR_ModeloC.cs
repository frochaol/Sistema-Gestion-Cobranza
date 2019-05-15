using System;
using System.Collections.Generic;
using System.ComponentModel;
using Ceriv.Clases;
using Ceriv.Conexion;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ceriv.Formularios
{
    public partial class FR_ModeloC : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public FR_ModeloC()
        {
            InitializeComponent();
            Atajo();
            CargarDataGridView();
        }
        public void Atajo()
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(this.CrearModificar_KeyDown);
        }
        private void CrearModificar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.B)
            {
                Buscar();
            }
        }
        public void Buscar()
        {
            E_NombreTitular obj1 = new E_NombreTitular();
            obj1.ShowDialog();
            txt_CuentaBT.Text = obj1.Nuevo;
            if (obj1.Nuevo != String.Empty)
            {
                CargarDataGridViewCuentaBT(obj1.Nuevo);
            }
        }

        public void CargarDataGridView()
        {
            dgv_Reporte.DataSource = null;
            dgv_Reporte.AutoGenerateColumns = false;
            dgv_Reporte.DataSource = _ceriv.ReporteSCIModeloC();
        }

        public void CargarDataGridViewCuentaBT(string codigo)
        {
            dgv_Reporte.DataSource = null;
            dgv_Reporte.AutoGenerateColumns = false;
            dgv_Reporte.DataSource = _ceriv.ReporteSCIModeloCCuentaBT(codigo);
        }

        private void btn_Exportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }
        public void Exportar()
        {
            if (dgv_Reporte.Rows.Count > 0)
            {
                CopiarTodoDataGridView();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[2, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                //desde aca pones los encabezados
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Value = " BT ";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 2];
                CR.Value = "DOI";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 3];
                CR.Value = "CLIENTE";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 4];
                CR.Value = "DEMANDADOS";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 5];
                CR.Value = "CARTERA";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 6];
                CR.Value = "MODELO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 7];
                CR.Value = "SECTORISTA";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 8];
                CR.Value = "ESTUDIO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 9];
                CR.Value = "REGION";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 10];
                CR.Value = "CIUDAD";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 11];
                CR.Value = "TIPO DE PROCESO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 12];
                CR.Value = "JUZGADO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 13];
                CR.Value = "EXPEDIENTE";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 14];
                CR.Value = "OPERACION";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 15];
                CR.Value = "(US$ o S/.)";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 16];
                CR.Value = "MONTO ADMITIDO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 17];
                CR.Value = "RESUMEN DEL PROCESO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 18];
                CR.Value = "MARCA";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 19];
                CR.Value = "MODELO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 20];
                CR.Value = "PLACA";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 21];
                CR.Value = "MONEDA";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 22];
                CR.Value = "GRAVAMEN";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 23];
                CR.Value = "VALOR COMERCIAL";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 24];
                CR.Value = "FECHA DEMANDA";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 24];
                CR.Value = "FECHA ORDEN DE INCAUTACION ";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 25];
                CR.Value = "FECHA DE ORDEN DE CAPTURA";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 26];
                CR.Value = "FECHA DE CAPTURA";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 27];
                CR.Value = "ESTADO PROCESAL";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 28];
                CR.Value = "FECHA ESTADO PROCESAL";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 29];
                CR.Value = "TAREA JUDICIAL";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";

                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
            }
        }
        private void CopiarTodoDataGridView()
        {
            dgv_Reporte.SelectAll();
            DataObject dataObj = dgv_Reporte.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txt_CuentaBT.Clear();
            CargarDataGridView();
        }
    }
}

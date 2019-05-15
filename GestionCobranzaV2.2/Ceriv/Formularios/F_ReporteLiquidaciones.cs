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
    public partial class F_ReporteLiquidaciones : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public F_ReporteLiquidaciones()
        {
            InitializeComponent();
            CargarDgvLiquidaciones();
            CargarCartera();
        }
        public void CargarCartera() 
        {
            cmb_cartera.DisplayMember = "NombreCartera";
            cmb_cartera.ValueMember = "CodigoCartera";
            cmb_cartera.DataSource = _ceriv.CarteraMostrar();
        }
        public void CopiarTodoDataGridView()
        {
            dgv_Liquidaciones.SelectAll();
            DataObject dataObj = dgv_Liquidaciones.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void btn_Exportar_Click(object sender, EventArgs e)
        {
            if (dgv_Liquidaciones.Rows.Count > 0)
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
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                //desde aca pones los encabezados
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                //    CR.Value = "AGENCIA";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 2];
                //  CR.Value = "TIPO PROCESO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 3];
                //  CR.Value = "NOMBRE CLIENTE";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 4];
                //    CR.Value = "OPERACION";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 5];
                //    CR.Value = "TIPO DE GASTO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 6];
                //  CR.Value = "DETALLE DE GASTO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 7];
                //CR.Value = "FECHA";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 8];
                //CR.Value = "NÚMERO RECIBO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 9];
                //   CR.Value = "CANTIDAD";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 10];
                //    CR.Value = "MONTO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";

                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
            }
        }

        public void CargarDgvLiquidaciones()
        {
                dgv_Liquidaciones.AutoGenerateColumns = false;
                dgv_Liquidaciones.DataSource = _ceriv.LiquidacionesReporte();
            
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {

            dgv_Liquidaciones.DataSource = null;
            dgv_Liquidaciones.AutoGenerateColumns = false;
            dgv_Liquidaciones.DataSource = _ceriv.LiquidacionesReporteCartera(Int32.Parse(cmb_cartera.SelectedValue.ToString()));
            
        }
    }
}

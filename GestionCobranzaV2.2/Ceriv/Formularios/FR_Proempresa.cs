using Ceriv.Clases;
using Ceriv.Conexion;
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
    public partial class FR_Proempresa : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public FR_Proempresa()
        {
            InitializeComponent();
            CargarDataGridView();
            Atajo();
        }
        public void CargarDataGridView()
        {
            dgv_Proempresa.DataSource = null;
            dgv_Proempresa.AutoGenerateColumns = false;
            dgv_Proempresa.DataSource = _ceriv.RerporteProempresa();
        }
        public void CargarDataGridViewCuentaBT(string codigo)
        {
            dgv_Proempresa.DataSource = null;
            dgv_Proempresa.AutoGenerateColumns = false;
            dgv_Proempresa.DataSource = _ceriv.ReporteProempresaCuentaBT(codigo);
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
            if (txt_CuentaBT.Text != String.Empty)
            {
                CargarDataGridViewCuentaBT(txt_CuentaBT.Text);
            }
        }
        private void CopiarTodoDataGridView()
        {
            dgv_Proempresa.SelectAll();
            DataObject dataObj = dgv_Proempresa.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void btn_Exportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }
        public void Exportar()
        {
            if (dgv_Proempresa.Rows.Count > 0)
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
                CR.Value = " código de cliente";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 2];
                CR.Value = "código de credito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 3];
                CR.Value = "nombre de cliente";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 4];
                CR.Value = "código de moneda";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 5];
                CR.Value = "saldo capital";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 6];
                CR.Value = "saldo cuota";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 7];
                CR.Value = "Tipo de Cambio";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 8];
                CR.Value = "capital soles";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 9];
                CR.Value = "total soles";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 10];
                CR.Value = "Estudio de Abogados";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 11];
                CR.Value = "des_ejecutivo";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 12];
                CR.Value = "des_situacion";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 13];
                CR.Value = "nom_agencia";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 14];
                CR.Value = "des_moneda";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 15];
                CR.Value = "dias_mora";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 16];
                CR.Value = "ind_prelacion";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 17];
                CR.Value = "PROCESO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 18];
                CR.Value = "Fecha de la presentacion de la demanda de ODSD/ EGH";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 19];
                CR.Value = "Fecha de presentación de la solicitud  de Medida Cautelar (MC)";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 20];
                CR.Value = "Fecha de Admision de Demanda ODSD/ EGH o Medida Cautelar";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 21];
                CR.Value = "Fecha de Inscripcion de MC (Medida Cautelar)";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 22];
                CR.Value = "Fecha Formalización de la demanda (solo MC)";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 23];
                CR.Value = "Fecha de Sentencia // Auto final";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 24];
                CR.Value = "Juzgado";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 25];
                CR.Value = "Lugar Juzgado";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 26];
                CR.Value = "N° De Expediente";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 27];
                CR.Value = "Codigo Cautelar";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 28];
                CR.Value = "Especialista";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 29];
                CR.Value = "Estado Procesal";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 30];
                CR.Value = "Rango Garantia";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 31];
                CR.Value = "Transados Si/No";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 32];
                CR.Value = "Observacion";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 33];
                CR.Value = "Bien";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";


                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
            }
        }
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txt_CuentaBT.Clear();
            CargarDataGridView();
        }

    }
}

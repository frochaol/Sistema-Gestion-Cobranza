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
    public partial class FR_SolicitudAdelanto : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public FR_SolicitudAdelanto()
        {
            InitializeComponent();
            CargarDataGridView();
            Atajo();
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
        private void CargarDataGridView()
        {
            dgv_Reporte.AutoGenerateColumns = false;
            dgv_Reporte.DataSource = _ceriv.ReporteSolicitudAdelantoTodo();
        }
        public void CargarDataGridView2()
        {
            dgv_Reporte.AutoGenerateColumns = false;
            List<C_SolicitudAdelanto> listaBase = (List<C_SolicitudAdelanto>)dgv_Reporte.DataSource;
            List<C_SolicitudAdelanto> listaUnion = _ceriv.ReporteSolicitudAdelanto(txt_CuentaBT.Text);
            if (listaBase != null)
            {
                foreach (C_SolicitudAdelanto elemento in listaUnion)
                {
                    listaBase.Add(elemento);
                }
                dgv_Reporte.DataSource = null;
                dgv_Reporte.DataSource = listaBase;
            }
            else
            {
                dgv_Reporte.DataSource = _ceriv.ReporteSolicitudAdelanto(txt_CuentaBT.Text);
            }
        }

        public void Buscar()
        {
            E_NombreTitular obj1 = new E_NombreTitular();
            obj1.ShowDialog();
            txt_CuentaBT.Text = obj1.Nuevo;
            CargarDataGridView2();
            /*if (_ceriv.CuentaBTExiste(txt_CuentaBT.Text))
            {
                CargarDataGridView2();
            }
            else
            {
                MessageBox.Show("La Cuenta BT no Existe Ingrese los Datos Correctamente");
                txt_CuentaBT.Clear();
                return;
            }*/
        }
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void CargarTodoDataGridView()
        {
            dgv_Reporte.SelectAll();
            DataObject dataObj = dgv_Reporte.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        public void Exportar()
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
                CR.Value = "Estudio";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 2];
                CR.Value = "Ciudad";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 3];
                CR.Value = "Cliente";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 4];
                CR.Value = "DOI Cliente";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 5];
                CR.Value = "Monto";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 6];
                CR.Value = "Concepto";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 7];
                CR.Value = "Juzgado/Proveedor";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 8];
                CR.Value = "Numero de Expediente";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 9];
                CR.Value = "Cartera";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 10];
                CR.Value = "Demandante";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 11];
                CR.Value = "Demandado";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 12];
                CR.Value = "Nombre Juzgado";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 13];
                CR.Value = "Motivo Juicio";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();

            }
            else
            {
                MessageBox.Show("No hay Registros Para Exportar");
                return;
            }
        }
        private void btn_Exportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txt_CuentaBT.Clear();
            //CargarDataGridView();
            dgv_Reporte.DataSource = null;
        }


    }
}

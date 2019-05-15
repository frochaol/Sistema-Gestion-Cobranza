using System;
using Ceriv.Clases;
using Ceriv.Conexion;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office;

namespace Ceriv.Formularios
{
    public partial class FR_CreditosEliminados : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public FR_CreditosEliminados()
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
        public void CargarDataGridView()
        {
            dgv_CreditosEliminados.AutoGenerateColumns = false;
            dgv_CreditosEliminados.DataSource = _ceriv.ReporteCreditoElimnadoTodo();
        }
        public void CargarDataGridView2()
        {
            dgv_CreditosEliminados.AutoGenerateColumns = false;
            dgv_CreditosEliminados.DataSource = _ceriv.ReporteCreditoEliminado(txt_CuentaBT.Text);
            List<C_Credito> listaBase = (List<C_Credito>)dgv_CreditosEliminados.DataSource;
            List<C_Credito> listaUnion = _ceriv.ReporteCreditoEliminado(txt_CuentaBT.Text);
            if (listaBase != null)
            {
                foreach (C_Credito elemento in listaUnion)
                {
                    listaBase.Add(elemento);
                }
                dgv_CreditosEliminados.DataSource = null;
                dgv_CreditosEliminados.DataSource = listaBase;
            }
            else
            {
                dgv_CreditosEliminados.DataSource = _ceriv.ReporteCreditoEliminado(txt_CuentaBT.Text);
            }
        }

        public void Buscar()
        {
            if (_ceriv.CuentaBTExiste(txt_CuentaBT.Text))
            {
                CargarDataGridView2();
            }
            else
            {
                MessageBox.Show("La Cuenta BT no Existe Ingrese los Datos Correctamente");
                txt_CuentaBT.Clear();
                return;
            }
        }
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        public void Exportar()
        {
            if (dgv_CreditosEliminados.Rows.Count > 0)
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
                CR.Value = "CUENTA BT";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 2];
                CR.Value = "FECHA ELIMINACION";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 3];
                CR.Value = "NOMBRE TITULAR";
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
        private void CargarTodoDataGridView()
        {
            dgv_CreditosEliminados.SelectAll();
            DataObject dataObj = dgv_CreditosEliminados.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txt_CuentaBT.Clear();
            CargarDataGridView();
            dgv_CreditosEliminados.DataSource = null;
        }



    }
}

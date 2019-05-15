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

namespace Ceriv.Formularios
{
    public partial class FR_InformeJudicial : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public FR_InformeJudicial()
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
            dgv_InformeJudicial.AutoGenerateColumns = false;
            dgv_InformeJudicial.DataSource = _ceriv.ReporteInformeJudicialTodo();
        }
        public void CargarDataGridView2()
        {
            dgv_InformeJudicial.AutoGenerateColumns = false;
            List<C_InformeJudicial> listaBase = (List<C_InformeJudicial>)dgv_InformeJudicial.DataSource;
            List<C_InformeJudicial> listaUnion = _ceriv.ReporteInformeJudicial(txt_CuentaBT.Text);
            if (listaBase != null)
            {
                foreach (C_InformeJudicial elemento in listaUnion)
                {
                    listaBase.Add(elemento);
                }
                dgv_InformeJudicial.DataSource = null;
                dgv_InformeJudicial.DataSource = listaBase;
            }
            else
            {
                dgv_InformeJudicial.DataSource = _ceriv.ReporteInformeJudicial(txt_CuentaBT.Text);
            }
        }
        private void CargarTodoDataGridView()
        {
            dgv_InformeJudicial.SelectAll();
            DataObject dataObj = dgv_InformeJudicial.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        public void Exportar()
        {
            if (dgv_InformeJudicial.Rows.Count > 0)
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
                CR.Value = "Cuenta BT";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 2];
                CR.Value = "Nombre Titular";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 3];
                CR.Value = "DNI/DOI";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 4];
                CR.Value = "Num. de Expediente";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 5];
                CR.Value = "Juzgado";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 6];
                CR.Value = "Descripcion del Bien";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 7];
                CR.Value = "Tipo de Proceso";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 8];
                CR.Value = "Descripcion del Bien";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 9];
                CR.Value = "Fecha de Protesto";
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
            dgv_InformeJudicial.DataSource = null;
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
    }
}

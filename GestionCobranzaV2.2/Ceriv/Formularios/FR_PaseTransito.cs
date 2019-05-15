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
    public partial class FR_PaseTransito : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public FR_PaseTransito()
        {
            InitializeComponent();
            CargarDataGridView2();
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
            dgv_PaseAtransito.AutoGenerateColumns = false;
            List<C_PaseTransito> listaBase = (List<C_PaseTransito>)dgv_PaseAtransito.DataSource;
            List<C_PaseTransito> listaUnion = _ceriv.ReportePaseTransito(txt_cuentaBt.Text);
            if (listaBase != null)
            {
                foreach (C_PaseTransito elemento in listaUnion)
                {
                    listaBase.Add(elemento);
                }
                dgv_PaseAtransito.DataSource = null;
                dgv_PaseAtransito.DataSource = listaBase;
            }
            else
            {
                dgv_PaseAtransito.DataSource = null;
                dgv_PaseAtransito.DataSource = _ceriv.ReportePaseTransito(txt_cuentaBt.Text);
            }
        }
        public void CargarDataGridView2()
        {
            dgv_PaseAtransito.AutoGenerateColumns = false;
            dgv_PaseAtransito.DataSource = _ceriv.ReportePaseTranistoTodo();
        }
        public void Exportar()
        {
            if (dgv_PaseAtransito.Rows.Count > 0)
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
                CR.Value = "NOMBRE TITULAR";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 2];
                CR.Value = "CUENTA BT";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 3];
                CR.Value = "NUM DE CAJA";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 4];
                CR.Value = "NOMBRE RESPONSABLE";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 5];
                CR.Value = "FECHA TRAMITE/CAMBIO";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 6];
                CR.Value = "OBSERVACION MOTIVO ARCHIVO";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 7];
                CR.Value = "CUENTA BT";
                CR.Font.Bold = "TRUE";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 8];
                CR.Value = "CARTERA";
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
            dgv_PaseAtransito.SelectAll();
            DataObject dataObj = dgv_PaseAtransito.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        public void Buscar()
        {
            E_NombreTitular obj1 = new E_NombreTitular();
            obj1.ShowDialog();
            txt_cuentaBt.Text = obj1.Nuevo;
            CargarDataGridView();
            /*if (_ceriv.CuentaBTExiste(txt_cuentaBt.Text))
            {
                CargarDataGridView();
            }
            else
            {
                MessageBox.Show("La Cuenta BT no Existe Ingrese los Datos Correctamente");
                txt_cuentaBt.Clear();
                return;
            }*/
        }
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txt_cuentaBt.Clear();
            //CargarDataGridView2();
            dgv_PaseAtransito.DataSource = null;
        }

    }
}

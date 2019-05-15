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
    public partial class FR_GerenciaSBP : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public FR_GerenciaSBP()
        {
            InitializeComponent();
            //CargarDataGridView();
            CargarDataGridViewTodo();
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
        private void CargarDataGridViewTodo()
        {
            dgv_Reporte.DataSource = null;
            dgv_Reporte.AutoGenerateColumns = false;
            dgv_Reporte.DataSource = _ceriv.ReporteSBPepitoTodo();
        }
        private void CargarDataGridView(string cuenta)
        {
            dgv_Reporte.AutoGenerateColumns = false;
            
            List<C_SBPFinal> listaBase = (List<C_SBPFinal>)dgv_Reporte.DataSource;
            List<C_SBPFinal> listaUnion = _ceriv.ReporteSBPepito(cuenta);
            if (listaBase != null)
            {
                foreach (C_SBPFinal elemento in listaUnion)
                {
                    listaBase.Add(elemento);
                }
                dgv_Reporte.DataSource = null;
                dgv_Reporte.DataSource = listaBase;
            }
            else
            {
                dgv_Reporte.DataSource = null;
                dgv_Reporte.DataSource = _ceriv.ReporteSBPepito(cuenta);
            }

        }
        public void Buscar()
        {
            E_NombreTitular obj1 = new E_NombreTitular();
            obj1.ShowDialog();
            txt_CuentaBt.Text = obj1.Nuevo;
            if (txt_CuentaBt.Text != String.Empty)
            {
                CargarDataGridView(obj1.Nuevo);
            }
        }
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txt_CuentaBt.Clear();
            CargarDataGridViewTodo();
            cmb_gestion.Text = "";
            dtp_hasta.ResetText();
            dtp_de.ResetText();
            dgv_Reporte.DataSource = null;
            //CargarDataGridView();
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
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                //desde aca pones los encabezados
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Value = " CUENTA BT ";
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
                CR.Value = "MONEDA";
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
                CR.Value = "FECHA DE MEDIDA CAUTELAR";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 19];
                CR.Value = "FECHA DEMANDA";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 20];
                CR.Value = "FECHA DE MANDATO DE EJECUCION";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 21];
                CR.Value = "FECHA DE CONTRADICCION Y/O APELACION";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 22];
                CR.Value = "FECHA ORDEN DE REMATE";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 23];
                CR.Value = "FECHA DE REMATE";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 24];
                CR.Value = "FECHA DE ADJUDICACION";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 25];
                CR.Value = "FECHA DE GESTION LLAMADA";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 26];
                CR.Value = "TELEFONO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 27];
                CR.Value = "RESULTADO LLAMADA";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 28];
                CR.Value = "DETALLE RESULTADO LLAMADA";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 29];
                CR.Value = "FECHA DE GESTION CAMPO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 30];
                CR.Value = "DIRECCION";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 31];
                CR.Value = "RESULTADO CAMPO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 32];
                CR.Value = "DETALLE RESULTADO CAMPO";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";

                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private void CopiarTodoDataGridView()
        {
            dgv_Reporte.SelectAll();
            DataObject dataObj = dgv_Reporte.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void btn_fecha_Click(object sender, EventArgs e)
        {
            if (cmb_gestion.SelectedIndex != -1)
            {
                if (cmb_gestion.SelectedIndex == 2)
                {
                    dgv_Reporte.DataSource = null;
                    dgv_Reporte.DataSource = _ceriv.ReporteSBPFechas(dtp_de.Value, dtp_hasta.Value);
                }
                else if (cmb_gestion.SelectedIndex == 1)
                {
                    dgv_Reporte.DataSource = null;
                    dgv_Reporte.DataSource = _ceriv.ReporteSBPFechasCampo(dtp_de.Value, dtp_hasta.Value);
                }
                else if (cmb_gestion.SelectedIndex == 0)
                {
                    dgv_Reporte.DataSource = null;
                    dgv_Reporte.DataSource = _ceriv.ReporteSBPFechasLlamada(dtp_de.Value, dtp_hasta.Value);
                }
            }
            else
            {
                MessageBox.Show("Ingrese una fecha de gestion a buscar");
            }
        }


    }
}

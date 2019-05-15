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
    public partial class FR_ReporteTodo : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public FR_ReporteTodo()
        {
            InitializeComponent();
            CargarDataGridView();
            CargarComboBox();
            Atajo();
        }
        public void CargarComboBox()
        {
            cmb_cartera.DisplayMember = "NombreCartera";
            cmb_cartera.ValueMember = "CodigoCartera";
            cmb_cartera.DataSource = _ceriv.CarteraMostrar();

            cmb_tramite.DisplayMember = "NombreTramite";
            cmb_tramite.ValueMember = "CodigoTramite";
            cmb_tramite.DataSource = _ceriv.TramiteMostrar();
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
            dgv_General.DataSource = null;
            dgv_General.AutoGenerateColumns = false;
            dgv_General.DataSource = _ceriv.ReporteCompletoAbogados();
        }
        public void CargarDataGridViewCuentaBT(string codigo)
        {
            dgv_General.DataSource = null;
            dgv_General.AutoGenerateColumns = false;
            dgv_General.DataSource = _ceriv.ReporteCompletoAbogadosCuentaBT(codigo);
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

        private void dgv_General_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txt_CuentaBT.Clear();
            CargarDataGridView();
        }

        private void btn_Exportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }
        private void CopiarTodoDataGridView()
        {
            dgv_General.SelectAll();
            DataObject dataObj = dgv_General.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        public void Exportar()
        {
            if (dgv_General.Rows.Count > 0)
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
                CR.Value = "Nombre - Titular";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 2];
                CR.Value = "DOI - Titular";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 3];
                CR.Value = "Conyuge - Titular";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 4];
                CR.Value = "Representante - Titular";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 5];
                CR.Value = "Distrito - Titular";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 6];
                CR.Value = "Domicilio - Titular";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 7];
                CR.Value = "Dirección Alterna - Titular";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 8];
                CR.Value = "Telefono - Titular";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 9];
                CR.Value = "Convenio - Titular";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 10];
                CR.Value = "BT - Titular";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 11];
                CR.Value = "Operacion - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 12];
                CR.Value = "Cartera - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 13];
                CR.Value = "Castigos / Situación - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 14];
                CR.Value = "Modelo - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 15];
                CR.Value = "Agencia - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 16];
                CR.Value = "CDR - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 17];
                CR.Value = "Producto o Módulo - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 18];
                CR.Value = "Pagaré / Capital  - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 19];
                CR.Value = "Moneda - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 20];
                CR.Value = "Ejecutivo - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 21];
                CR.Value = "Ciudad del Estudio - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 22];
                CR.Value = "Estudio - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 23];
                CR.Value = "Monto Admitido - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 24];
                CR.Value = "Fecha Protesto  - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 25];
                CR.Value = "Fecha Asignación  - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 26];
                CR.Value = "Tipo de Trámite  - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 27];
                CR.Value = "Observación Trámite - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 28];
                CR.Value = "Fecha de Trámite - Crédito";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 29];
                CR.Value = "Nombre - Garante";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 30];
                CR.Value = "Conyuge - Garante";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 31];
                CR.Value = "Distrito - Garante";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 32];
                CR.Value = "Domicilio - Garante";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 33];
                CR.Value = "N° Expediente - Expediente";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 34];
                CR.Value = "N° Expediente 22 Digitos";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 35];
                CR.Value = "N° Juzgado  - Expediente";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 36];
                CR.Value = "Juzgado  - Expediente";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 37];
                CR.Value = "Responsable  - Expediente";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 38];
                CR.Value = "Abogado  - Expediente";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 39];
                CR.Value = "Nombre Proceso  - Expediente";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 40];
                CR.Value = "Secretario  - Expediente";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 41];
                CR.Value = "Código Cautelar  - Expediente";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 42];
                CR.Value = "Macro Etapa - Proceso";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 43];
                CR.Value = "Micro Etapa - Proceso";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 44];
                CR.Value = "Incidencia - Sullana  - Proceso";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 45];
                CR.Value = "Fecha Etapa  - Proceso";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 46];
                CR.Value = "Medida Cautelar  - Proceso";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 47];
                CR.Value = "Fecha Inscripción  - Proceso";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 48];
                CR.Value = "Estado Cautelar / Incautación  - Proceso";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 49];
                CR.Value = "Fecha Medida Cautelar  - Proceso";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 50];
                CR.Value = "Fecha Actuado Cautelar  - Proceso";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 51];
                CR.Value = "Vigencia Medida Cautelar  - Proceso";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 52];
                CR.Value = "Devolución de Cédula  - Proceso";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 53];
                CR.Value = "Fecha de Demanda - Fechas";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 54];
                CR.Value = "Fecha Mandato de Ejecución - Fechas";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 55];
                CR.Value = "Fecha Contradicción - Fechas";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 56];
                CR.Value = "Fecha Sentencia (Auto Final) - Fechas";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 57];
                CR.Value = "Fecha de Apelación - Fechas";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 58];
                CR.Value = "Fecha Orden Remate (Modelo A) / Fecha Orden Incautación (Modelo C) - Fechas";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 59];
                CR.Value = "Fecha Remate (Modelo A) / Fecha Orden Captura(Modelo C) - Fechas";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 60];
                CR.Value = "Fecha Adjudicación (Modelo A) / Fecha Captura(Modelo C) - Fechas";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 61];
                CR.Value = "Tipo - Bien";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 62];
                CR.Value = "Nombre - Bien";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 63];
                CR.Value = "Monto Garantia / Embargo - Bien";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 64];
                CR.Value = "Ciudad - Bien";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 65];
                CR.Value = "Distrito - Bien";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 66];
                CR.Value = "Monto Tasación - Bien";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 67];
                CR.Value = "Fecha de Tasación - Bien";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 68];
                CR.Value = "Valor Comercial - Bien";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 69];
                CR.Value = "Marca - Bien";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 70];
                CR.Value = "Rango Hipoteca/Embargo - Bien";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 71];
                CR.Value = "Partida/Placa - Bien";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 72];
                CR.Value = "Porcentaje Derechos - Bien";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 73];
                CR.Value = "Modelo - Bien";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 74];
                CR.Value = "Descripción - Bien";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 75];
                CR.Value = "Estado Procesal - Seguimiento";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 76];
                CR.Value = "Fecha de Estado Procesal - Seguimiento";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 77];
                CR.Value = "Tarea Judicial - Seguimiento";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 78];
                CR.Value = "Tarea Administrativa - Seguimiento";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 79];
                CR.Value = "Fecha Tarea Administrativa - Seguimiento";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 80];
                CR.Value = "Detalle Incidencia - Seguimiento";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 81];
                CR.Value = "Fecha y Detalle de Gestion Extrajudicial - Seguimiento";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 82];
                CR.Value = "Tipo Solución - Pagos";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 83];
                CR.Value = "Saldo - Pagos";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 84];
                CR.Value = "Comisión - Pagos";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 85];
                CR.Value = "Fecha de Pago - Pagos";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 86];
                CR.Value = "Fecha Estimada - Proyección";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 87];
                CR.Value = "Devuelto - Proyección";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 88];
                CR.Value = "Motivo Devolución - Proyección";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 89];
                CR.Value = "Telefono - Proyección";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 90];
                CR.Value = "Historico Proceso";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 91];
                CR.Value = "Historico Llamada";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 92];
                CR.Value = "Historico Campo";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";
                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 93];
                CR.Value = "Inubicable - Gestión Campo";
                CR.Font.Bold = "True";
                CR.Font.Size = "14";



                CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_General.DataSource = null;
                dgv_General.AutoGenerateColumns = false;
                dgv_General.DataSource = _ceriv.ReporteCompletoAbogadosTramiteCartera((Int32.Parse(cmb_cartera.SelectedValue.ToString())), (Int32.Parse(cmb_tramite.SelectedValue.ToString())));
            }
            catch
            {
                Exception ex;
            }

        }
    }
}

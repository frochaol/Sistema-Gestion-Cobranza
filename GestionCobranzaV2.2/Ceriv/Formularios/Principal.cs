using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ceriv.Conexion;
using Ceriv.Clases;

namespace Ceriv.Formularios
{
    public partial class Principal : Form
    {
        int _dniTrabajador;
        S_Ceriv _ceriv = new S_Ceriv();

        public Principal(int dni)
        {
            InitializeComponent();
            _dniTrabajador = dni;
            if(PermisoAdministrador())
            {
                CargarUsuario();
                lbl_Usuario.Visible = true;
                chb_Colores.Visible = true;
                cmb_Usuario.Visible = true;
                btn_Buscar.Visible = true;
            }
            CargarComboBox();
            CargarDataGridViewInicial(_dniTrabajador);
            
            dgv_Alerta.RowHeadersVisible = false;
            //CargarDataGridView();
        }
        private void CargarUsuario()
        {
            cmb_Usuario.DisplayMember = "NombreCompleto";
            cmb_Usuario.ValueMember = "DniTrabajador";
            cmb_Usuario.DataSource = _ceriv.TrabajadorMostrar();
        }
        // CARGAR

        private void CargarComboBox()
        {
            CargarComboBoxEstadoProcesal();
            CargarComboBoxTareas();
        }
        private void CargarComboBoxEstadoProcesal()
        {
            cmb_EstadoProcesal.DisplayMember = "Nombre";
            cmb_EstadoProcesal.ValueMember = "Codigo";
            cmb_EstadoProcesal.DataSource = _ceriv.EstadoProcesalMostrar();
            cmb_EstadoProcesal.SelectedIndex = -1;
        }
        private void CargarComboBoxTareas()
        {
            cmb_Tareas.Items.Add("Tarea Administrativa");
            cmb_Tareas.Items.Add("Tarea Juridica");
            cmb_Tareas.Items.Add("Tareas Cumplidas");
            cmb_Tareas.SelectedIndex = -1;
        }
        public void CargarDataGridViewInicial(int codigo)
        {
            dgv_Alerta.AutoGenerateColumns = false;
            dgv_Alerta.DataSource = _ceriv.SeguimientoProcesoInicioDNI(codigo);
        }
        private void CargarDataGridView(string order = "where flag = 1 and codigo_tramite = 4 and (estadotareajudicial != 1 or estadotareaadministrativa != 1 ) order by  fechaestadoprocesal asc")
        {
            dgv_Alerta.AutoGenerateColumns = false;
            dgv_Alerta.DataSource = _ceriv.SeguimientoProcesoMostrar(order);
        }
        private void CargarDataGridViewCBT()
        {
            dgv_Alerta.AutoGenerateColumns = false;
            dgv_Alerta.DataSource = _ceriv.SeguimientoProcesoMostrarCBT(txt_CuentaBT.Text);
        }


        // OTROS

        private void maestrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PermisoAdministrador())
            {
                Trabajador objetoTrabajador = new Trabajador();
                objetoTrabajador.ShowDialog();
            }
            else
            {
                MessageBox.Show("Permiso Denegado");
            }
        }
        private bool PermisoAdministrador()
        {
            //codigo administrador en la bd es de 1
            C_Trabajador objetoTrabajador = _ceriv.TrabajadorMostrar1(_dniTrabajador);
            if (objetoTrabajador.CodigoTipoTrabajador == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void operacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*List<string> list = new List<string>();
            foreach (DataGridViewRow row in dgv_Alerta.Rows)
            {
                list.Add(row.Cells["cuentabt"].Value.ToString());
            }
            string[] array = list.ToArray();
            SeleccionEstudio objetoCrearModificar = new SeleccionEstudio(_dniTrabajador, array);*/
            CrearModificar Obj = new CrearModificar(_dniTrabajador);
            Obj.ShowDialog();
          /*  objetoCrearModificar.ShowDialog();*/
            CargarDataGridViewInicial(_dniTrabajador);
            cmb_Tareas.SelectedIndex = -1;
            cmb_EstadoProcesal.SelectedIndex = -1;
           // this.Close();
        }

        private void resumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PermisoAdministrador())
            {
                EliminarCuentaBT objetoEliminarExpediente = new EliminarCuentaBT(_dniTrabajador);
                objetoEliminarExpediente.ShowDialog();
            }
            else
            {
                MessageBox.Show("Permiso denegado");
            }
        }

        private void resumenToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio objInicio = new Inicio();
            objInicio.ShowDialog();
            Application.Exit();
            /*
           Permisos objetoPermisos = new Permisos();
            objetoPermisos.ShowDialog();*/
        }

        private void btn_detalle_Click(object sender, EventArgs e)
        {
            if (_ceriv.CuentaBTExiste(txt_CuentaBT.Text))
            {
                CrearModificar objetoCrearModificar = new CrearModificar(_dniTrabajador, txt_CuentaBT.Text);
                objetoCrearModificar.ShowDialog();
                CargarDataGridViewInicial(_dniTrabajador);
                cmb_Tareas.SelectedIndex = -1;
                cmb_EstadoProcesal.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("   *La cuentaBT no Existe. Revise los datos por favor");
                return;
            }
        }

        private void dgv_Alerta_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_Alerta.SuspendLayout();
            if (cmb_Tareas.SelectedIndex != 2)
            {
                foreach (DataGridViewRow row in dgv_Alerta.Rows)
                {
                    DateTime fechaProcesal = DateTime.Parse(row.Cells["FechaEstadoProcesa"].Value.ToString());
                    DateTime fechaAdministrativa = DateTime.Parse(row.Cells["FechaAdministrativa"].Value.ToString());
                    string stringEtj = row.Cells["tareaJudicialCumplida"].Value.ToString();
                    bool etj;
                    if (stringEtj == "No")
                        etj = false;
                    else
                        etj = true;
                    string stringEta = row.Cells["tareaAdministrativaCumplida"].Value.ToString();
                    bool eta;
                    if (stringEta == "No")
                        eta = false;
                    else
                        eta = true;
                    if (chb_Colores.Checked)
                    {
                        if ((fechaProcesal.Date == DateTime.Now.Date && !etj) || (fechaAdministrativa.Date == DateTime.Now.Date && !eta))
                        {
                            row.DefaultCellStyle.BackColor = Color.Wheat;
                        }
                        else if ((fechaProcesal.Date < DateTime.Now.Date && !etj) || (fechaAdministrativa.Date < DateTime.Now.Date && !eta))
                        {
                            row.DefaultCellStyle.BackColor = Color.Tomato;
                        }
                    }
                }
            }
            dgv_Alerta.ResumeLayout();
            dgv_Alerta.ClearSelection();
        }

        private void dgv_Alerta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                ActualizarSeguimientoProceso(e.RowIndex);
            }
        }

        private void ActualizarSeguimientoProceso(int rowActual)
        {
            string stringEtj = dgv_Alerta.Rows[rowActual].Cells["tareaJudicialCumplida"].Value.ToString();
            bool etj;
            bool eta;
            string stringEta = dgv_Alerta.Rows[rowActual].Cells["tareaAdministrativaCumplida"].Value.ToString();
            string tareaAdministrativa = dgv_Alerta.Rows[rowActual].Cells["TareaAdministrativa"].Value.ToString();
            string tareaJudicial = dgv_Alerta.Rows[rowActual].Cells["TareaJudicial"].Value.ToString();
            string cuenta_bt = dgv_Alerta.Rows[rowActual].Cells["cuentabt"].Value.ToString();
            int codigo = Int32.Parse(dgv_Alerta.Rows[rowActual].Cells["Codigo"].Value.ToString());
            DateTime fechaProcesal = DateTime.Parse(dgv_Alerta.Rows[rowActual].Cells["FechaEstadoProcesa"].Value.ToString());
            DateTime fechaAdministrativa = DateTime.Parse(dgv_Alerta.Rows[rowActual].Cells["FechaAdministrativa"].Value.ToString());
            int accion = 0;
            C_SeguimientoProceso objetoSeguimiento = new C_SeguimientoProceso();
            objetoSeguimiento.CuentaBT = cuenta_bt;
            objetoSeguimiento.EstadoProcesal = 1;
            objetoSeguimiento.FechaEstadoProcesal = fechaProcesal;
            objetoSeguimiento.FechaTareaAdministrativa = fechaAdministrativa;
            objetoSeguimiento.TareaAdministrativa = tareaAdministrativa;
            objetoSeguimiento.TareaJudicial = tareaJudicial;
            objetoSeguimiento.Codigo = codigo;
            if (stringEta == "No")
                eta = false;
            else
                eta = true;
            if (stringEtj == "No")
                etj = false;
            else
                etj = true;

            if (eta && etj)
            {
                accion = 5;
            }
            else
            {
                if (!eta && !etj)
                {
                    accion = 2;
                }
                else
                {
                    if (etj)
                    {
                        accion = 3;
                    }
                    else
                    {
                        if (eta)
                        {
                            accion = 4;
                        }
                    }
                }
            }
            if (_ceriv.SeguimientoProceso(accion, objetoSeguimiento))
            {
                C_AuditoriaCeriv objetoAuditoria = new C_AuditoriaCeriv();
                objetoAuditoria.CuentaBT = cuenta_bt;
                objetoAuditoria.DniTrabajador = _dniTrabajador;
                objetoAuditoria.Campo = "Seguimiento Proceso";
                objetoAuditoria.Observacion = "|CuentaBT= " + cuenta_bt + "\n FechaEstadoProcesal " + fechaProcesal.ToShortDateString() + "\nFechaTareaAdministrativa " + fechaAdministrativa.ToShortDateString() + "\nTareaAdministrativa " + tareaAdministrativa + "\nTareaJudicial " + tareaJudicial + "\naccion " + accion;
                if (_ceriv.Auditoria(1, objetoAuditoria))
                {
                }
                MessageBox.Show("Se actualizo Correctamente");
                CargarDataGridViewInicial(_dniTrabajador);
                //CargarDataGridView();
            }

        }

        private void btn_TipoProceso_Click(object sender, EventArgs e)
        {
            CargarComboBoxEstadoProcesal();
            CargarDataGridView();
        }

        private void btn_TipoTarea_Click(object sender, EventArgs e)
        {
            CargarComboBoxTareas();
        }

        private void cmb_EstadoProcesal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_EstadoProcesal.SelectedIndex > -1)
            {
                string order = "where  estadoprocesal = " + cmb_EstadoProcesal.SelectedValue + " and flag = 1  and codigo_tramite = 4 and (estadotareajudicial != 1 or estadotareaadministrativa != 1 )  order by fechaestadoprocesal asc";
                CargarDataGridView(order);
            }
            cmb_Tareas.SelectedIndex = -1;
        }

        private void cmb_Tareas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string order = "where flag = 1 and  codigo_tramite = 4 and  ";
            if (cmb_EstadoProcesal.SelectedIndex > -1)
            {
                order = order + "estadoprocesal = " + cmb_EstadoProcesal.SelectedValue + " and ";
            }
            if (cmb_Tareas.SelectedIndex == 1)
            {
                order = order + "etj = 'No' order by fechaestadoprocesal asc";
                CargarDataGridView(order);
            }
            if (cmb_Tareas.SelectedIndex == 0)
            {
                order = order + "eta = 'No' order by fechatareaadministrativa asc";
                CargarDataGridView(order);
            }
            if (cmb_Tareas.SelectedIndex == 2)
            {
                order = order + "eta = 'Si' and etj = 'Si' order by fechatareaadministrativa asc";
                CargarDataGridView(order);
            }
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dgv_Alerta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row=e.RowIndex;
            int col = e.ColumnIndex;
            if (dgv_Alerta.Rows[row].Cells[col].Value != null)
            {
                MessageBox.Show(dgv_Alerta.Rows[row].Cells[col].Value.ToString());
            }
        }

        private void informeJudicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_InformeJudicial obj = new FR_InformeJudicial();
            obj.ShowDialog();
        }


        //REPORTES
        private void creditosEliminadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_CreditosEliminados obj = new FR_CreditosEliminados();
            obj.ShowDialog();
        }
        private void liquidacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_Liquidacion objeto = new FR_Liquidacion();
            objeto.ShowDialog();

        }
        private void cambioDeModeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_CambioModelo objeto = new FR_CambioModelo();
            objeto.ShowDialog();
        }
        private void paseATransitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_PaseTransito objeto = new FR_PaseTransito();
            objeto.ShowDialog();
        }
        private void gerenciaSBPToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FR_GerenciaSBP objeto = new FR_GerenciaSBP();
            objeto.ShowDialog();
        }
        private void solicitudDeAdelantoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_SolicitudAdelanto objeto = new FR_SolicitudAdelanto();
            objeto.ShowDialog();
        }
        private void reporteDeCartasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_ReporteCartas objeto = new FR_ReporteCartas();
            objeto.ShowDialog();

        }
        private void gestionDeLlamadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_GestionLlamada objeto = new FR_GestionLlamada();
            objeto.ShowDialog();
        }
        private void gestionDeCampoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_GestionCampo objeto = new FR_GestionCampo();
            objeto.ShowDialog();

        }
        private void auditoriaCerivToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FR_AuditoriaCeriv objeto = new FR_AuditoriaCeriv();
            objeto.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_CuentaBT.Text == string.Empty)
            {
                MessageBox.Show("Ingrese una Cuenta BT a buscar");
            }
            else
            {
                CargarDataGridViewCBT();
            }
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            CargarComboBoxEstadoProcesal();
            CargarDataGridViewInicial(_dniTrabajador);
            txt_CuentaBT.Clear();
        }

        private void reporteDinamicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_Llamada objeto = new FR_Llamada();
            objeto.ShowDialog();
        }

        //MODELO A
        private void mODELOAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_ModeloA objeto = new FR_ModeloA();
            objeto.ShowDialog();
        }
        //MODELO B
        private void mODELOBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_ModeloB objeto = new FR_ModeloB();
            objeto.ShowDialog();

        }
        //MODELO C
        private void mODELOCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_ModeloC objeto = new FR_ModeloC();
            objeto.ShowDialog();
        }

        private void proempresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_Proempresa objeto = new FR_Proempresa();
            objeto.ShowDialog();
        }

        private void sullanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_Sullana objeto = new FR_Sullana();
            objeto.ShowDialog();
        }

        private void gestionLlamadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_GestionLlamada objeto = new FR_GestionLlamada();
            objeto.ShowDialog();
        }

        private void gestionCampoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_GestionCampo objeto = new FR_GestionCampo();
            objeto.ShowDialog();
        }

        private void reporteGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FR_ReporteTodo objeto = new FR_ReporteTodo();
            objeto.ShowDialog();
        }

        private void documentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            if (chb_Colores.Checked)
            {
                dgv_Alerta.SuspendLayout();
            }
            else
            {
                dgv_Alerta.ResumeLayout();
            }
            dgv_Alerta.AutoGenerateColumns = false;
            dgv_Alerta.DataSource = _ceriv.SeguimientoProcesoInicioDNIDesc(Int32.Parse(cmb_Usuario.SelectedValue.ToString()));
        }

        private void expedienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FD_Expediente obj = new FD_Expediente();
            obj.ShowDialog();
        }

        private void reporteLiquidacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_ReporteLiquidaciones obj = new F_ReporteLiquidaciones();
            obj.ShowDialog();
        }


    }
}

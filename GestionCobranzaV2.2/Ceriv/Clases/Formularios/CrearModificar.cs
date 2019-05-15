using System;
using Ceriv.Conexion;
using Ceriv.Clases;
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
    public partial class CrearModificar : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        int _dniAntiguo;
        int _codGarante;
        public CrearModificar()
        {
            InitializeComponent();
            CargarComboBox();

        }

        private void btn_Ciudad_Click(object sender, EventArgs e)
        {
            AbrirCiudad();
        }
        private void btn_Abogado_Click(object sender, EventArgs e)
        {
            AbrirAbogado();
        }
        private void btn_Cartera_Click(object sender, EventArgs e)
        {
            AbrirCartera();

        }
        private void btn_Estudio_Click(object sender, EventArgs e)
        {
            AbrirEstudio();
        }
        private void btn_Juzgado_Click(object sender, EventArgs e)
        {
            AbrirJuzgado();
        }
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            GuardarPersona();
        }
        private void CrearModificar_Load(object sender, EventArgs e)
        {
            _dniAntiguo = 1;
        }
        private void btn_Responsable_Click(object sender, EventArgs e)
        {
            AbrirResponsable();
        }
        private void btn_Tipo_Proceso_Click(object sender, EventArgs e)
        {
            AbrirProceso();
        }
        private void btn_IA_Expediente_Click(object sender, EventArgs e)
        {
            GuardarExpediente();
        }
        private void btn_Guardar_Credito_Click(object sender, EventArgs e)
        {
            GuardarCredito();
        }
        private void btn_RangoHipoteca_Click(object sender, EventArgs e)
        {
            AbrirRangoHipoteca();
        }
        private void btn_BienHipotecado_Click(object sender, EventArgs e)
        {
            AbrirBienHipotecado();
        }
        private void btn_FormaMedidaCautelar_Click(object sender, EventArgs e)
        {
            AbrirFormaMedidaCautelar();
        }
        private void btn_BienEmbargado_Click(object sender, EventArgs e)
        {
            AbrirBienEmbargado();
        }
        private void btn_Guardar_Proceso_Click(object sender, EventArgs e)
        {
            GuardarProceso();
        }


        public void CargarComboBox()
        {
            CargarComboBoxAbogado();            
            CargarComboBoxProceso();
            CargarComboBoxCartera();
            CargarComboBoxCiudad();
            CargarComboBoxEstudio();
            CargarComboBoxJuzgado();
            CargarComboBoxMoneda();
            CargarComboBoxDOIcliente();
            CargarComboBoxResponsable();
            CargarComboBoxDistritoTitular();
            CargarComboBoxDistritoGarante();
            CargarComboBoxRangoHipotecado();
            CargarComboBoxBienHipotecado();
            CargarComboBoxFormaMedidaCautelar();
            CargarComboBoxBienEmbargado();
            CargarComboBoxUltimoEstadoProcesal();
        }
        public void CargarComboBoxUltimoEstadoProcesal()
        {
            cmb_UltimoEstadoProcesal.DisplayMember = "Nombre";
            cmb_UltimoEstadoProcesal.ValueMember = "Codigo";
            cmb_UltimoEstadoProcesal.DataSource = _ceriv.EstadoProcesalMostrar();
        }
        public void CargarComboBoxCartera()
        {
            cmb_Cartera.DisplayMember = "NombreCartera";
            cmb_Cartera.ValueMember = "CodigoCartera";
            cmb_Cartera.DataSource = _ceriv.CarteraMostrar();
        }
        public void CargarComboBoxProceso()
        {
            cmb_Tipo_Proceso.DisplayMember = "NombreProceso";
            cmb_Tipo_Proceso.ValueMember = "CodigoProceso";
            cmb_Tipo_Proceso.DataSource = _ceriv.ProcesoMostrar();

        }
        public void CargarComboBoxAbogado()
        {
            cmb_Abogado.DisplayMember = "NombreCompleto";
            cmb_Abogado.ValueMember = "DniTrabajador";
            cmb_Abogado.DataSource = _ceriv.AbogadoMostrar();
        }
        public void CargarComboBoxCiudad()
        {
            cmb_Ciudad.DisplayMember = "NombreCiudad";
            cmb_Ciudad.ValueMember = "CodigoCiudad";
            cmb_Ciudad.DataSource = _ceriv.CiudadMostrar();
        }
        public void CargarComboBoxEstudio()
        {
            cmb_Estudio.DisplayMember = "NombreEstudio";
            cmb_Estudio.ValueMember = "CodigoEstudio";
            cmb_Estudio.DataSource = _ceriv.EstudioMostrar();
 
        }
        public void CargarComboBoxJuzgado() 
        {
            cmb_Juzgado.DisplayMember = "NombreJuzgado";
            cmb_Juzgado.ValueMember = "CodigoJuzgado";
            cmb_Juzgado.DataSource = _ceriv.JuzgadoMostrar();
        }
        public void CargarComboBoxDOIcliente()
        {
            cmb_I_DOItitular.DisplayMember = "DoiCliente";
            cmb_I_DOItitular.ValueMember = "CodigoPersona";
            cmb_I_DOItitular.DataSource = _ceriv.DOIMostrar();
        }
        public void CargarComboBoxResponsable()
        {
            cmb_Responsable.DisplayMember = "NombreCompleto";
            cmb_Responsable.ValueMember = "DniTrabajador";
            cmb_Responsable.DataSource = _ceriv.ResponsableMostrar();
        }
        public void CargarComboBoxMoneda()
        {
            cmb_Moneda.DisplayMember = "NombreMoneda";
            cmb_Moneda.ValueMember = "CodigoMoneda";
            cmb_Moneda.DataSource = _ceriv.MonedaMostrar();
        }
        public void CargarComboBoxRangoHipotecado()
        {
            cmb_Rango_Hipoteca.DisplayMember = "NombreRangoHipotecado";
            cmb_Rango_Hipoteca.ValueMember = "CodigoRangoHipotecado";
            cmb_Rango_Hipoteca.DataSource = _ceriv.RangoHipotecadoMostrar();
        }
        public void CargarComboBoxDistritoTitular()
        {
            cmb_Distrito_Titular.DisplayMember = "NombreDistrito";
            cmb_Distrito_Titular.ValueMember = "CodigoDistrito";
            cmb_Distrito_Titular.DataSource = _ceriv.DistritoMostrar();
        }
        public void CargarComboBoxDistritoGarante()
        {
            cmb_Distrito_Garante.DisplayMember = "NombreDistrito";
            cmb_Distrito_Garante.ValueMember = "CodigoDistrito";
            cmb_Distrito_Garante.DataSource = _ceriv.DistritoMostrar();
        }
        public void CargarComboBoxBienHipotecado()
        {
            cmb_BienHipotecado.DisplayMember = "Nombre";
            cmb_BienHipotecado.ValueMember = "Codigo";
            cmb_BienHipotecado.DataSource = _ceriv.BienHipotecadoMostrar();
        }
        public void CargarComboBoxFormaMedidaCautelar()
        {
            cmb_FMedCautelar.DisplayMember = "Nombre";
            cmb_FMedCautelar.ValueMember = "Codigo";
            cmb_FMedCautelar.DataSource = _ceriv.FormaMedidaCautelarMostrar();
        }
        public void CargarComboBoxBienEmbargado()
        {
            cmb_BienEmbargado.DisplayMember = "Nombre";
            cmb_BienEmbargado.ValueMember = "Codigo";
            cmb_BienEmbargado.DataSource = _ceriv.BienEmbargadoMostrar();
        }

        private void cmb_I_DOItitular_SelectedIndexChanged(object sender, EventArgs e)
        {
            C_Persona obj = _ceriv.DOIMostrar1(Int32.Parse(cmb_I_DOItitular.SelectedValue.ToString()));
            txt_IA_NomCliente.Text = obj.NombreCompleto;
            _dniAntiguo = Int32.Parse(cmb_I_DOItitular.Text);
        }

        private void GuardarExpediente()
        {
            C_Expediente objetoExpediente = new C_Expediente();
            objetoExpediente.NumExpediente = txt_IA_NumExpediente.Text;
            if (txt_IA_NumExp22.Text == string.Empty)
                txt_IA_NumExp22.Text = " ";
            objetoExpediente.NumExpediente22Digitos = txt_IA_NumExp22.Text;
            objetoExpediente.DniTrabajador = Int32.Parse(cmb_I_DOItitular.Text);
            objetoExpediente.CodigoPersona = Int32.Parse(cmb_I_DOItitular.SelectedValue.ToString());
            objetoExpediente.TrabajadorAbogado = Int32.Parse(cmb_Abogado.SelectedValue.ToString());
            objetoExpediente.TrabajadorResponsable = Int32.Parse(cmb_Responsable.SelectedValue.ToString());
            objetoExpediente.TrabajadorSecretario = txt_IA_Secretario.Text;
            objetoExpediente.CodigoProceso = Int32.Parse(cmb_Tipo_Proceso.SelectedValue.ToString());
            objetoExpediente.NumJuzgados = txt_Juzgado.Text;
            if (txt_IA_CodCautelar.Text == string.Empty)
                txt_IA_CodCautelar.Text = " ";
            objetoExpediente.CodigoCautelar = txt_IA_CodCautelar.Text;
            objetoExpediente.FechaAsignacion = DateTime.Parse(dtp_Asignacion.Text);
            if (_ceriv.Expediente(1, objetoExpediente))
            {
                MessageBox.Show("Ingreso el Expediente Correctamente");
                txt_IA_NumExp22.Clear();
                txt_IA_Secretario.Clear();
                txt_Juzgado.Clear();
                txt_IA_CodCautelar.Clear();
            }
            else
            {
                MessageBox.Show("Revise los Datos");
            }
        }
        private void GuardarPersona()
        {
            C_Persona objetoPersona = new C_Persona();
            objetoPersona.NombrePersona = txt_NombreTitular.Text;
            objetoPersona.ApellidoPaterno = txt_APtitular.Text;
            objetoPersona.ApellidoMaterno = txt_APmaterno.Text;
            if (txt_NombreConyuge.Text == string.Empty)
                txt_NombreConyuge.Text = " ";
            objetoPersona.NombreConyuge = txt_NombreConyuge.Text;
            if (txt_APC.Text == string.Empty)
                txt_APC.Text = " ";
            objetoPersona.ApellidoPaternoConyuge = txt_APC.Text;
            if (txt_AMC.Text == string.Empty)
                txt_AMC.Text = " ";
            objetoPersona.ApellidoMaternoConyuge = txt_AMC.Text;
            objetoPersona.DoiCliente = Int32.Parse(txt_Doi.Text);
            objetoPersona.CodigoDistrito = Int32.Parse(cmb_Distrito_Titular.SelectedValue.ToString());
            objetoPersona.DomicilioPersona = txt_Domicilio.Text;
            objetoPersona.Representante = txt_Representante.Text;
            if (txt_Direccion.Text == string.Empty)
                txt_Direccion.Text = " ";
            objetoPersona.DireccionAlterna = txt_Direccion.Text;
            if (_ceriv.PersonaTitular(1, objetoPersona))
            {
                MessageBox.Show("Se ingreso Correctamente al Cliente");
                cmb_Distrito_Titular.SelectedIndex = -1;
                txt_NombreTitular.Clear();
                txt_APtitular.Clear();
                txt_APmaterno.Clear();
                txt_NombreConyuge.Clear();
                txt_APC.Clear();
                txt_AMC.Clear();
                txt_Doi.Clear();
                txt_Domicilio.Clear();
                txt_Representante.Clear();
                txt_Direccion.Clear();
            }
            else
            {
                MessageBox.Show("Revise los Datos");
            }
            objetoPersona.CodigoPersona = _codGarante;
            objetoPersona.NombrePersona = txt_Nombre_Garante.Text;
            objetoPersona.ApellidoPaterno = txt_AP_Garante.Text;
            objetoPersona.ApellidoMaterno = txt_AM_Garante.Text;
            if (txt_Nombre_Conyuge.Text == string.Empty)
                txt_Nombre_Conyuge.Text = " ";
            objetoPersona.NombreConyuge = txt_Nombre_Conyuge.Text;
            if (txt_AP_Gconyuge.Text == string.Empty)
                txt_AP_Gconyuge.Text = " ";
            objetoPersona.ApellidoPaternoConyuge = txt_AP_Gconyuge.Text;
            if (txt_AM_Cgarante.Text == string.Empty)
                txt_AM_Cgarante.Text = " ";
            objetoPersona.ApellidoMaternoConyuge = txt_AM_Cgarante.Text;
            objetoPersona.CodigoDistritoGarante = Int32.Parse(cmb_Distrito_Garante.SelectedValue.ToString());
            objetoPersona.DomicilioPersona = txt_Domicilio_Garante.Text;
            objetoPersona.Operacion = txt_Operacion.Text;
            if (_ceriv.PersonaGarante(1, objetoPersona))
            {
                MessageBox.Show("Se ingreso Correctamente al Cliente");
                CargarComboBoxDOIcliente();
                txt_Nombre_Garante.Clear();
                txt_AP_Garante.Clear();
                txt_AM_Garante.Clear();
                txt_Nombre_Conyuge.Clear();
                txt_AP_Gconyuge.Clear();
                txt_AM_Cgarante.Clear();
                txt_Domicilio_Garante.Clear();
                txt_Operacion.Clear();
            }
            else
            {
                MessageBox.Show("Revise los Datos");
            }
           
        }
        private void GuardarCredito()
        {
            C_Credito objetoCredito = new C_Credito();
            objetoCredito.Num_Expediente = txt_IA_NumExpediente.Text;
            objetoCredito.CodigoCredito = txt_IA_NumExpediente.Text;
            objetoCredito.CodigoCartera = Int32.Parse(cmb_Cartera.SelectedValue.ToString());
            objetoCredito.CodigoMoneda = Int32.Parse(cmb_Moneda.SelectedValue.ToString());
            objetoCredito.CodigoCiudad = Int32.Parse(cmb_Ciudad.SelectedValue.ToString());
            objetoCredito.CodigoEstudio = Int32.Parse(cmb_Estudio.SelectedValue.ToString());
            objetoCredito.CodigoJuzgado = Int32.Parse(cmb_Juzgado.SelectedValue.ToString());
            objetoCredito.Castigos = txt_I_Castigos.Text;
            if (txt_I_Castigos.Text == string.Empty)
                objetoCredito.Castigos = " ";
            objetoCredito.Modelo = txt_I_Modelo.Text;
            if (txt_I_Modelo.Text == string.Empty)
                objetoCredito.Modelo = " ";
            objetoCredito.ProductoModulo = txt_I_ProductooModulo.Text;
            if (txt_I_ProductooModulo.Text == string.Empty)
                objetoCredito.ProductoModulo = " ";
            objetoCredito.Cdr = txt_Cdr.Text;
            if (txt_Cdr.Text == string.Empty)
                objetoCredito.Cdr = " ";           
            objetoCredito.CuentaBT = txt_Cbt.Text;
            if (txt_Cbt.Text == string.Empty)
                objetoCredito.CuentaBT = " ";
            objetoCredito.Capital = txt_Capital.Text;
            objetoCredito.FechaProtesto = DateTime.Parse(dtp_Protesto.Text);
            if (chk_Transito.Checked)
            {
                objetoCredito.TramiteDevolucion = "Pase a Transito";
                objetoCredito.ObservacionDevolucion = " ";
                objetoCredito.FechaTramiteDevolucion = DateTime.Parse(dtp_Cambio.Text);
            }
            else if (chk_Otros.Checked)
            {
                objetoCredito.TramiteDevolucion = "Otros";
                objetoCredito.ObservacionDevolucion = txt_Otro.Text;
                objetoCredito.FechaTramiteDevolucion = DateTime.Parse(dtp_Cambio.Text);
            }
            else if (chk_Canal.Checked)
            {
                objetoCredito.TramiteDevolucion = "Cambio de Canal";
                objetoCredito.ObservacionDevolucion = " ";
                objetoCredito.FechaTramiteDevolucion = DateTime.Parse(dtp_Cambio.Text);
            }
            else
            {
                objetoCredito.TramiteDevolucion = " ";
                objetoCredito.ObservacionDevolucion = " ";
                if(dtp_Cambio.Visible == false)
                    objetoCredito.FechaTramiteDevolucion = dtp_Cambio.Value;
            }
            if (_ceriv.Credito(1, objetoCredito))
            {
                MessageBox.Show("Se ingreso el Credito Correctamente");
            }
            else
            {
                MessageBox.Show("No se Ingreso el Credito");
            }
        }
        private void GuardarProceso()
        {
            C_Proceso objetoProceso = new C_Proceso();
            objetoProceso.NumExpediente = txt_IA_NumExpediente.Text;
            objetoProceso.CodigoBienHipotecado = Int32.Parse(cmb_BienHipotecado.SelectedValue.ToString());
            objetoProceso.CodigoRangoHipoteca = Int32.Parse(cmb_Rango_Hipoteca.SelectedValue.ToString());
            objetoProceso.CodigoFormaCautelar = Int32.Parse(cmb_FMedCautelar.SelectedValue.ToString());
            objetoProceso.CodigoBienEmbargado = Int32.Parse(cmb_BienEmbargado.SelectedValue.ToString());
            objetoProceso.MontoDemandado = Double.Parse(txt_MontoDemandado.Text);
            objetoProceso.MontoHipotecado = Double.Parse(txt_Monto_Hipotecado.Text);
            objetoProceso.FechaDemanda = DateTime.Parse(dtp_Demanda.Text);
            objetoProceso.FechaPresMc = DateTime.Parse(dtp_PresMC.Text);
            objetoProceso.PartidaPlaca = txt_Placa.Text;
            objetoProceso.UbicacionBien = txt_Ubicacion_bien.Text;
            objetoProceso.FechaEmbargo = DateTime.Parse(dtp_EmbargoRRPP.Text);
            objetoProceso.CodigoProceso = txt_IA_NumExpediente.Text;
            if (_ceriv.ProcesoPrincipal(1, objetoProceso))
            {
                MessageBox.Show("Se Ingreso Correctamente el Proceso");
                CargarComboBox();
                cmb_BienHipotecado.SelectedIndex = -1;
                cmb_Rango_Hipoteca.SelectedIndex = -1;
                cmb_FMedCautelar.SelectedIndex = -1;
                cmb_BienEmbargado.SelectedIndex = -1;
                txt_MontoDemandado.Clear();
                txt_Monto_Hipotecado.Clear();
                txt_Placa.Clear();
                txt_Ubicacion_bien.Clear();
            }
            else
            {
                MessageBox.Show("No se pudo Ingresar el Proceso");
            }

        }

        private void AbrirCiudad()
        {
            Ciudad obj = new Ciudad();
            obj.ShowDialog();
            CargarComboBoxCiudad();
        }
        private void AbrirAbogado()
        {
            Trabajador obj = new Trabajador();
            obj.ShowDialog();
            CargarComboBoxAbogado();
        }
        private void AbrirProceso()
        {
            TipoProceso obj = new TipoProceso();
            obj.ShowDialog();
            CargarComboBoxProceso();

        }
        private void AbrirCartera()
        {
            Cartera obj = new Cartera();
            obj.ShowDialog();
            CargarComboBoxCartera();
        }
        private void AbrirEstudio() 
        {
            Estudio obj = new Estudio();
            obj.ShowDialog();
            CargarComboBoxEstudio();
        }
        private void AbrirJuzgado()
        {
            Juzgado obj = new Juzgado();
            obj.ShowDialog();
            CargarComboBoxJuzgado();
        }
        private void AbrirResponsable()
        {
            Trabajador obj = new Trabajador();
            obj.ShowDialog();
            CargarComboBoxResponsable();
        }
        private void AbrirRangoHipoteca()
        {
            RangoHipoteca obj = new RangoHipoteca();
            obj.ShowDialog();
            CargarComboBoxRangoHipotecado();
        }
        private void AbrirBienHipotecado()
        {
            BienHipotecado obj = new BienHipotecado();
            obj.ShowDialog();
            CargarComboBoxBienHipotecado();

        }
        private void AbrirFormaMedidaCautelar()
        {
            FormaMedidaCautelar obj = new FormaMedidaCautelar();
            obj.ShowDialog();
            CargarComboBoxFormaMedidaCautelar();

        }
        private void AbrirBienEmbargado()
        {
            BienEmbargado obj = new BienEmbargado();
            obj.ShowDialog();
            CargarComboBoxBienEmbargado();
        }


        private void cmb_Medida_Cautelar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Medida_Cautelar.Text == "SI")
            {
                lbl_CodigoCautelar.Visible = true;
                txt_IA_CodCautelar.Visible= true;
            }
            if (cmb_Medida_Cautelar.Text == "NO")
            {
                lbl_CodigoCautelar.Visible = false;
                txt_IA_CodCautelar.Visible = false;
            }
        }
        private void chk_Otros_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_Otros.Checked)
            {
                txt_Otro.Visible = true;
                dtp_Cambio.Visible = true;
            }
        }
        private void chk_Transito_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Transito.Checked)
            {
                dtp_Cambio.Visible = true;
            }
        }
        private void chk_Canal_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Canal.Checked)
            {
                dtp_Cambio.Visible = true;
            }
        }

        private void Btn_EstadoProcesal_Click(object sender, EventArgs e)
        {
            EstadoProcesal objetoEstadoProcesal = new EstadoProcesal();
            objetoEstadoProcesal.ShowDialog();
        }

        private void btn_Guardar_Seguimiento_Click(object sender, EventArgs e)
        {
            C_SeguimientoProceso objetoSeguimiento = new C_SeguimientoProceso();
            objetoSeguimiento.NumeroExpediente = txt_IA_NumExpediente.Text;
            objetoSeguimiento.EstadoProcesal = Int32.Parse(cmb_UltimoEstadoProcesal.SelectedValue.ToString());
            objetoSeguimiento.FechaEstadoProcesal = dtp_Fecha_Procesal.Value;
            objetoSeguimiento.FechaTareaAdministrativa = dtp_Tarea_Administrativa.Value;
            objetoSeguimiento.TareaAdministrativa = txt_UltTarAdministrativa.Text;
            objetoSeguimiento.TareaJudicial = txt_UltTarJudicial.Text;
            if (_ceriv.SeguimientoProceso(1, objetoSeguimiento))
            {
                MessageBox.Show("Ingreso Correcto");
                txt_UltTarAdministrativa.Clear();
                txt_UltTarJudicial.Clear();
                CargarDataGridView();
            }
            else
            {
                MessageBox.Show("Error al ingresar");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (tabControl1.SelectedIndex == 3)
                CargarDataGridView();
        }
        private void CargarDataGridView()
        {
            DGV_procesos.AutoGenerateColumns = false;
            DGV_procesos.DataSource = _ceriv.SeguimientoProcesoMostrarFechaProcesal(txt_IA_NumExpediente.Text);
        }






    }
}

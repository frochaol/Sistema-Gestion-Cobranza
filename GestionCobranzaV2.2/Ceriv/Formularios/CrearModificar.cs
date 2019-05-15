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
using System.IO;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
//using Microsoft.Office.Interop.Word;
using System.Text;
using System.Globalization;
using Microsoft.Office.Interop.Word;

namespace Ceriv.Formularios
{
    public partial class CrearModificar : Form
    {
        //CONEXION AL SERVICE

        S_Ceriv _ceriv = new S_Ceriv();
        
        //VARIABLES GLOBALES

        int _dniTrabajador;
        string[] _array;
        int _recorrerArray;
        bool _bandera = false;
        bool _banderaImagen = false;
        string _dniAntiguo;
        string _cuentaBtAntiguo;
        string _operacionAntiguo;
        int _codigoTipoProceso = 0;
        byte[] _imagenGlobal;
        // CONSTRUCTOR
        /*public CrearModificar()
        {
            InitializeComponent();
            CargarComboBox();
            DesactivarBotonesModificar();
            InicioComboBox();
            Atajo();
        }*/

        public CrearModificar(int dni)
        {
            _dniTrabajador = dni;
            InitializeComponent();
            CargarComboBox();
            LimpiarCredito();
            limpiarExpediente();
            DesactivarBotonesModificar();
            DesactivarBotonesEliminar();
            Atajo();
            FormatearFecha();
            _bandera = false;
            
            
        }
        public CrearModificar(int dni, string [] array,int estudio)
        {
            _dniTrabajador = dni;
            InitializeComponent();
            CargarComboBox();
            DesactivarBotonesModificar();
            DesactivarBotonesEliminar();
            _array = array;
            _recorrerArray = -1;
            Atajo();
            FormatearFecha();
            SeleccionarEstudio(estudio);
        }
        public CrearModificar(int dni, string cuentaBT)
        {
            _dniTrabajador = dni;
            InitializeComponent();
            CargarComboBox();
            DesactivarBotonesModificar();
            DesactivarBotonesEliminar();
            txt_CuentaBT.Text = cuentaBT;
            FormatearFecha();
            CargarTitularPorCuentaBT();
            BloquearTitular();
            CargarComboBoxOperacion();
            tab_Global.SelectedIndex = 0;
            btn_GuardarTitular.Enabled = false;
            btn_ModificarTitular.Enabled = true;
            _bandera = false;
            Atajo();

            // CargarTitularPorCuentaBT();
            //CargarTodo();
            //btn_Retroceder.Enabled = false;
            //btn_Avanzar.Enabled = false;
            
        }

        private void SeleccionarEstudio(int x = 0)
        {
            if(x == 2)
            {
                lbl_cuentabt.Text = "Operacion";
                lbl_operacion.Text = "Cuenta BT";
            }
            if (x == 1)
            {
                lbl_cuentabt.Text = "Cuenta BT";
                lbl_operacion.Text = "Operacion";
            }
            else
            {
                if (txt_CuentaBT.Text != string.Empty)
                {
                    if (!_ceriv.CuentaBTExiste(txt_CuentaBT.Text))
                    {
                        C_Credito objeto = _ceriv.CreditoMostrar1(txt_CuentaBT.Text);
                        if (objeto.CodigoEstudio == 3)
                        {
                            lbl_cuentabt.Text = "Operacion";
                            lbl_operacion.Text = "Cuenta BT";
                        }
                        else 
                        {
                            lbl_cuentabt.Text = "Cuenta BT";
                            lbl_operacion.Text = "Operacion";
                        }
                    }
                }
                
                
            }
        }
        // ATAJO DE TECLAS

        public void Atajo()
        {
            this.KeyPreview = true;
            this.KeyDown +=new KeyEventHandler(this.CrearModificar_KeyDown);
        }
        private void CrearModificar_KeyDown(object sender,KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.B)
            {
                AbrirBuscarClienteNombre();
            }
        }

        // CARGAR FORMATO FECHAS AL INICIO

        public void FormatearFecha2()
        {
            dtp_Tasacion.Value = DateTime.Parse("01-01-1990");
            dtp_Fecha_Procesal.Value = DateTime.Parse("01-01-1990");
            dtp_Pago.Value = DateTime.Parse("01-01-1990");
            dtp_Fecha_Visita.Value = DateTime.Parse("01-01-1990");
            dtp_Fecha_Pago.Value = DateTime.Parse("01-01-1990");
            dtp_Pago.Value = DateTime.Parse("01-01-1990");
            dtp_Gestion_Campo.Value = DateTime.Parse("01-01-1990");
            dtp_Tarea_Administrativa.Value = DateTime.Parse("01-01-1990"); ;

            dtp_Tasacion.CustomFormat = " ";
            dtp_Tasacion.Format = DateTimePickerFormat.Custom;
            dtp_Fecha_Procesal.CustomFormat = " ";
            dtp_Fecha_Procesal.Format = DateTimePickerFormat.Custom;
            dtp_Pago.CustomFormat = " ";
            dtp_Pago.Format = DateTimePickerFormat.Custom;
            dtp_Fecha_Visita.CustomFormat = " ";
            dtp_Fecha_Visita.Format = DateTimePickerFormat.Custom;
            dtp_Fecha_Pago.CustomFormat = " ";
            dtp_Fecha_Pago.Format = DateTimePickerFormat.Custom;
            dtp_Pago.CustomFormat = " ";
            dtp_Pago.Format = DateTimePickerFormat.Custom;
            dtp_Gestion_Campo.CustomFormat = " ";
            dtp_Gestion_Campo.Format = DateTimePickerFormat.Custom;
            dtp_Tarea_Administrativa.CustomFormat = " ";
            dtp_Tarea_Administrativa.Format = DateTimePickerFormat.Custom;

        }
        public void FormatearFecha()
        {
            dtp_ActuadoCautelar.Value = DateTime.Parse("01-01-1990");
            dtp_Asignacion.Value = DateTime.Parse("01-01-1990");
            dtp_Cambio.Value = DateTime.Parse("01-01-1990");
            //dtp_Demanda.Value = DateTime.Parse("01-01-1990");
            dtp_Fecha_Pago.Value = DateTime.Parse("01-01-1990");
            dtp_Fecha_Procesal.Value = DateTime.Parse("01-01-1990");
            dtp_Fecha_Visita.Value = DateTime.Parse("01-01-1990");
            dtp_FechaEtapa.Value = DateTime.Parse("01-01-1990");
            dtp_Gestion_Campo.Value = DateTime.Parse("01-01-1990");
            dtp_Inscripcion.Value = DateTime.Parse("01-01-1990");
            dtp_MedidaCautelar.Value = DateTime.Parse("01-01-1990");
            dtp_Pago.Value = DateTime.Parse("01-01-1990");
            dtp_Pagos.Value = DateTime.Parse("01-01-1990");
            dtp_Protesto.Value = DateTime.Parse("01-01-1990");
            dtp_Tarea_Administrativa.Value = DateTime.Parse("01-01-1990");
            dtp_Tasacion.Value = DateTime.Parse("01-01-1990");
            dtp_FechaMandato.Value = DateTime.Parse("01-01-1990");
            dtp_Contradiccion.Value = DateTime.Parse("01-01-1990");
            dtp_fechaOrden.Value = DateTime.Parse("01-01-1990");
            dtp_RemateCaptura.Value = DateTime.Parse("01-01-1990");
            dtp_AdjuCaptura.Value = DateTime.Parse("01-01-1990");
            dtp_FechaEstimada.Value = DateTime.Parse("01-01-1900");
            dtp_FechaAutoFinal.Value = DateTime.Parse("01-01-1900");
            dtp_FechaDemanda.Value = DateTime.Parse("01-01-1900");
            dtp_Apelacion.Value = DateTime.Parse("01-01-1900");

            dtp_Apelacion.CustomFormat = " ";
            dtp_Apelacion.Format = DateTimePickerFormat.Custom;
            dtp_FechaDemanda.CustomFormat = " ";
            dtp_FechaDemanda.Format = DateTimePickerFormat.Custom;
            dtp_FechaAutoFinal.CustomFormat = " ";
            dtp_FechaAutoFinal.Format = DateTimePickerFormat.Custom;
            dtp_FechaEstimada.CustomFormat = " ";
            dtp_FechaEstimada.Format = DateTimePickerFormat.Custom;
            dtp_FechaMandato.CustomFormat = " ";
            dtp_FechaMandato.Format = DateTimePickerFormat.Custom;
            dtp_Contradiccion.CustomFormat = " ";
            dtp_Contradiccion.Format = DateTimePickerFormat.Custom;
            dtp_fechaOrden.CustomFormat = " ";
            dtp_fechaOrden.Format = DateTimePickerFormat.Custom;
            dtp_RemateCaptura.CustomFormat = " ";
            dtp_RemateCaptura.Format = DateTimePickerFormat.Custom;
            dtp_AdjuCaptura.CustomFormat = " ";
            dtp_AdjuCaptura.Format = DateTimePickerFormat.Custom;
            dtp_ActuadoCautelar.CustomFormat = " ";
            dtp_ActuadoCautelar.Format = DateTimePickerFormat.Custom;
            dtp_Asignacion.CustomFormat = " ";
            dtp_Asignacion.Format = DateTimePickerFormat.Custom;
            dtp_Cambio.CustomFormat = " ";
            dtp_Cambio.Format = DateTimePickerFormat.Custom;
          //  dtp_Demanda.CustomFormat = " ";
           // dtp_Demanda.Format = DateTimePickerFormat.Custom;
            dtp_Fecha_Pago.CustomFormat = " ";
            dtp_Fecha_Pago.Format = DateTimePickerFormat.Custom;
            dtp_Fecha_Procesal.CustomFormat = " ";
            dtp_Fecha_Procesal.Format = DateTimePickerFormat.Custom;
            dtp_Fecha_Visita.CustomFormat = " ";
            dtp_Fecha_Visita.Format = DateTimePickerFormat.Custom;
            dtp_FechaEtapa.CustomFormat = " ";
            dtp_FechaEtapa.Format = DateTimePickerFormat.Custom;
            dtp_Gestion_Campo.CustomFormat = " ";
            dtp_Gestion_Campo.Format = DateTimePickerFormat.Custom;
            dtp_Inscripcion.CustomFormat = " ";
            dtp_Inscripcion.Format = DateTimePickerFormat.Custom;
            dtp_MedidaCautelar.CustomFormat = " ";
            dtp_MedidaCautelar.Format = DateTimePickerFormat.Custom;
            dtp_Pago.CustomFormat = " ";
            dtp_Pago.Format = DateTimePickerFormat.Custom;
            dtp_Pagos.CustomFormat = " ";
            dtp_Pagos.Format = DateTimePickerFormat.Custom;
            dtp_Protesto.CustomFormat = " ";
            dtp_Protesto.Format = DateTimePickerFormat.Custom;
            dtp_Tarea_Administrativa.CustomFormat = " ";
            dtp_Tarea_Administrativa.Format = DateTimePickerFormat.Custom;
            dtp_Tasacion.CustomFormat = " ";
            dtp_Tasacion.Format = DateTimePickerFormat.Custom;
            
            
        }

        //CARGAR COMBO BOX EN EL FORMULARIO

        public void CargarComboBox()
        {
            CargarComboBoxTipoBien();
            CargarComboBoxAbogado();            
            CargarComboBoxProceso();
            CargarComboBoxCartera();
            CargarComboBoxCiudad();
            CargarComboBoxEstudio();
            CargarComboBoxMoneda();
            CargarComboBoxResponsable();
            CargarComboBoxDistrito();
            CargarComboBoxRangoHipotecado();
            CargarComboBoxFormaMedidaCautelar();
            CargarComboBoxUltimoEstadoProcesal();
            CargarComboBoxTrabajador();
            CargarComboBoxModelo();
            CargarComboBoxMacro();
            CargarComboBoxMicro();
            CargarComboBoxEtapaProcesal();
            CargarTodoProceso();
            CargarTodoExpedientes();
        }

        //COMBO BOX QUE APARECEN EN VARIAS PESTAÑAS

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
        public void CargarComboBoxTrabajador()
        {
            CargarComboBoxLlamadas();
            CargarComboBoxCampo();
        }

        //AUDITORIA DE CAMBIOS

        public void AuditoriaTitular()
        {
            string observacion = "\n TITULAR \n NombreTitular/Empresa =" + txt_NombreTitular.Text + "\n NombreConyuge =" + txt_NombreConyuge.Text + "\n DOI_TITULAR =" + txt_Doi.Text + "\n  CUENTA_BT =" + lbl_cuentabt.Text + "  = " + txt_CuentaBT.Text + "\n Representante = " + txt_Representante.Text + "\n DomicilioTitular =" + txt_DomicilioTitular.Text + "\n DireccionTitular =" + txt_DireccionTitular.Text + "\n CodigoDistrito = " + cmb_DistritoTitular.SelectedValue + "\n NombreDistrito = " + cmb_DistritoTitular.Text + "\n Numero = " + txt_NumeroTitular.Text;
            Auditoria_Ceriv(observacion, "Titular");
        }
        public void AuditoriaCredito()
        {
            string observacion = "\n CREDITO \n Cuenta BT= " + txt_CuentaBT.Text + "\n Cartera =" + cmb_Cartera.SelectedValue + "\n NombreCartera = " + cmb_Cartera.Text + "\n Castigos = " + txt_Castigos.Text + "\n Modelo = " + cmb_Modelo.SelectedValue + "\n NombreModelo = " + cmb_Modelo.Text + "\n  ProductoModulo =" + txt_ProductoModulo.Text + "\n CDR = " + txt_Cdr.Text + "\n Agencia = " + txt_Agencia.Text + "\n Operacion =" + txt_Operacion.Text + "\n Capital =" + txt_Capital.Text + "\n Moneda = " + cmb_Moneda.SelectedValue + "\n NombreMoneda =" + cmb_Moneda.Text + "\n FechaProtesto =" + dtp_Protesto.Value.Date + "\n FechaAsignacion = " + dtp_Asignacion.Value.Date + "\n Ciudad =" + cmb_Ciudad.SelectedValue + "\n NombreCiudad =" + cmb_Ciudad.Text + "\n Estudio =" + cmb_Estudio.SelectedValue + "\n NombreEstudio =" + cmb_Estudio.Text + "\n PaseTransito =" + chk_Transito.CheckState + "\n CambioCanal =" + chk_Canal.CheckState + "\n Observacion =" + txt_Otro.Text + "\n FechaTramiteCambio = " + dtp_Cambio.Value.Date + "\n MontoAdmitido = " +txt_MontoAdmitido.Text + "\n Ejecutivo = " + txt_Ejecutivo.Text ;
            Auditoria_Ceriv(observacion, "Credito");
        }
        public void AuditoriaGarante()
        {
            string observacion = "\n GARANTE \n NombreGarante = " + txt_Nombre_Garante.Text + "\n ConyugeGarante = " + txt_Nombre_Conyuge.Text + "\n codigo_distrito = " + cmb_Distrito_Garante.SelectedValue + "\n NombreDistrito =" + cmb_Distrito_Garante.Text + "\n DomicilioGarante =" + txt_Domicilio_Garante.Text + "\n Operacion =" + cmb_OperacionGarante.Text ;
            Auditoria_Ceriv(observacion, "Garante");
        }
        public void AuditoriaProceso()
        {
         //   string observacion = "\n PROCESO \n MacroEtapa =" + cmb_Macro.SelectedValue + "\n NombreMacroEtapa =" + cmb_Macro.Text + "\n MicroEtapa =" + cmb_Micro.SelectedValue + "\n NombreMicro =" + cmb_Micro.Text + "\n EtapaProcesal = "+cmb_EtapaProcesal.SelectedValue + "\n NombreEtapaProcesal ="+ cmb_EtapaProcesal.Text+"\n Tiempo ="+ txt_tiempo.Text +"\n FechaEtapa ="+ dtp_FechaEtapa.Value.Date + "\n FormaMedidaCautelar ="+cmb_FMedCautelar.SelectedValue+ "\n NombreFormaMedidaCautelar ="+cmb_FMedCautelar.Text +"\n FechaDemanda ="+dtp_Demanda.Value.Date +"\n FechaInscripcion ="+ dtp_Inscripcion.Value.Date +"\n EstadoCautelar ="+ txt_EstadoCautelar.Text +"\n FechaMedidaCautelar ="+dtp_MedidaCautelar.Value.Date +"\n VigenciaMC ="+cmb_VigenciaMc.Text + "\n FechaActuado ="+dtp_ActuadoCautelar.Value.Date +"\n DevolucionCedula ="+ cmb_Devolucion.Text;
         //   Auditoria_Ceriv(observacion, "Proceso");
        }
        public void AuditoriaFechas()
        {
            string observacion = "\n Fecha Mandato de Ejecucion=" + dtp_FechaMandato.Value.Date + "\n Fecha Contradiccion/Apelacion=" + dtp_Contradiccion.Value.Date + "\n Fecha Orden de remate(Modelo A)=" + dtp_fechaOrden.Value.Date + "\n Fecha de Orden de Incautacion (Modelo C)=" + dtp_fechaOrden.Value.Date + "\n Fecha de Remate(Modelo A)=" + dtp_RemateCaptura.Value.Date + "\n Fecha de Orden de Captura(Modelo C)=" + dtp_RemateCaptura.Value.Date + "\n Fecha de Adjudicacion(Modelo A)=" + dtp_AdjuCaptura.Value.Date + "\n Fecha de Captura (Modelo C)=" + dtp_AdjuCaptura.Value.Date;
            Auditoria_Ceriv(observacion, "Fechas Proceso");
        }
        public void AuditoriaExpediente()
        {
            string observacion = "\n EXPEDIENTE \n NumExpediente =" + txt_NumExpediente.Text + "\n NumExpediente22 =" + txt_NumExpediente22.Text + "\n Responsable=" + cmb_Responsable.SelectedValue + "\n NombreResponsable =" + cmb_Responsable.Text + "\n Abogado=" + cmb_Abogado.SelectedValue + "\n NombreAbogado =" + cmb_Abogado.Text + "\n Secretario =" + txt_Secretario.Text + "\n TipoProceso =" + cmb_Tipo_Proceso.SelectedValue + "\n NombreTipoProceso =" + cmb_Tipo_Proceso.Text + "\n Juzgado=" + cmb_Juzgado.Text + "\n MedidaCautelar =" + cmb_Medida_Cautelar.Text + "\n CodigoCautelar =" + txt_codigoCautelar.Text + "\n NUMERO JUZGADO ="+ cmb_NumJuzgado.Text;
            Auditoria_Ceriv(observacion, "Expediente"); 
        }
        public void AuditoriaBien()
        {
            string observacion = "\n BIEN \n TipoBien =" + cmb_TipoBien.SelectedValue+ "\n NombreTipoBien =" +cmb_TipoBien.Text + "\n NombreDelBien =" +txt_NombreTipoBien.Text + "\n MontoDemandado =" +txt_MontoDemandado.Text +"\n MontoGarantia =" +txt_MontoGarantia.Text +"\n MontoTasacion =" + txt_Monto_Tasacion.Text +"\n FechaTasacion =" +dtp_Tasacion.Value.Date +"\n Partida/Placa =" +txt_Placa.Text + "\n RangoHipoteca =" + cmb_Rango_Hipoteca.SelectedValue +"\n NombreRangoHipoteca =" +cmb_Rango_Hipoteca.Text +"\n PorcentajeDerechos =" +txt_Porcentaje_Embargo.Text + "\n DescripcionBien =" +txt_DescripcionBien.Text+"\n ValorComercial =" +txt_ValorComercial.Text;
            Auditoria_Ceriv(observacion, "Bien");
        }
        public void AuditoriaOtrasCargas()
        {
            string observacion = "\n OTRAS CARGAS \n BienSeleccionado =" + cmb_BienOtrasCargas.SelectedValue + "\n DescripcionBienSeleccionado =" + txt_DescripcionOtrasCargas.Text + "\n Acreedor =" + txt_Acreedor.Text + "\n Rango =" + txt_RangoDatos.Text + "\n MontoGarantia/Embargo =" + txt_MontoGaEmbargo.Text + "\n MontoAdeudado =" + txt_MontoAdeudado.Text;
            Auditoria_Ceriv(observacion, "OtrasCargas");
        }
        public void AuditoriaSeguimientoProceso()
        {
            string observacion = "\n SEGUIMIENTO PROCESO \n EstadoProcesal=" +cmb_UltimoEstadoProcesal.SelectedValue+ "\n NombreEstadoProcesal=" +cmb_UltimoEstadoProcesal.Text +"\n FechaEstadoProcesal =" +dtp_Fecha_Procesal.Value.Date + "\n UltimaTareaJudicial =" +txt_UltTarJudicial.Text + "\n UltimaTareaAdministrativa =" +txt_UltTarAdministrativa.Text +"\n FechaUltimaTareaAdministrativa =" +dtp_Tarea_Administrativa.Value.Date;
            Auditoria_Ceriv(observacion, "SeguimientoProceso");
        }
        public void AuditoriaPagos()
        {
            string observacion = "\n PAGOS \n NombreTitularPago =" + txt_NombreTitularPagos.Text + "\n TipoSolucion =" + txt_TipoSolucionPagos.Text + "\n Moneda =" + txt_MonedaPagos.Text + "\n Cartera =" + txt_CarteraPagos.Text + "\n Pago=" + txt_PagoPagos.Text + "\n Comision =" + txt_ComisionPagos.Text + "\n FechaPago =" + dtp_Pago.Value.Date;
            Auditoria_Ceriv(observacion, "Pagos");
        }
        public void AuditoriaGestionLlamada()
        {
            string observacion = "\n GESTION LLAMADA \n TelefonoContacto =" + txt_Telefono.Text + "\n ContactoCliente =" +cmb_ContactoCliente.Text + "\n ContactoPariente =" +cmb_ContactoPariente.Text +"\n NombrePariente =" +txt_Nombre_Pariente.Text + "\n TelefonoNoCorresponde =" + txt_Telefono_Corresponde.Text + "\n FechaVisitaEstudio =" + dtp_Fecha_Visita.Value.Date +"\n FechaPago =" + dtp_Fecha_Pago.Value.Date +"\n MontoPago =" +txt_Monto_Pago.Text +"\n DueñoDelBien =" + txt_DueñoBien.Text +"\n NiegaPago =" +cmb_NiegaPago.Text +"\n GestorDeCall =" + cmb_TrabajadorLlamada.SelectedValue+"\n NombreGestor =" +cmb_TrabajadorLlamada.Text +"\n HoraLlamada =" + DateTime.Now.ToShortDateString() +" " + dtp_HoraLlamada.Text+"\n DescripcionResultado =" +txt_descripcion_resultado.Text +"\n NroDeGestion =" +txt_Gestion.Text +"\n TipoSolucion =" + txt_TipoSolucionLlamada.Text;
            Auditoria_Ceriv(observacion, "GestionLlamada");
        }
        public void AuditoriaGestionCampo()
        {
            string observacion = "\n GESTION DE CAMPO \n GestionCampo =" + cmb_Gestion.Text + "\n ContactoPariente =" + cmb_ContactoParienteCampo.Text + "\n NombrePariente =" + txt_Pariente_Campo.Text + "\n NuevoDomTele =" + cmb_NuevoDomCampo.Text + "\n Detalle =" + txt_Detalle_Campo.Text + "\n FechaPago =" + dtp_Pago.Value.Date + "\n MontoPago =" + txt_Monto_Campo.Text + "\n FechaGestion =" + dtp_Gestion_Campo.Value.Date + "\n NiegaPago =" + cmb_NiegaPagoCampo.Text + "\n HoraVisita =" + DateTime.Now.ToShortDateString() + " / " + dtp_HoraVisita.Text + "\n GestorDeCampo =" + cmb_TrabajadorCampo.SelectedValue + "\n NombreGestorCampo =" + cmb_TrabajadorCampo.Text + "\n DetalleResultado =" + txt_Detalle_Resultado.Text + "\n Inubicable =" + cmb_Inubicable.Text+ "\n NumGestion =" + txt_Num_Gestion.Text + "\n DescripcionInmueble =" + txt_Descrp_Campo.Text + "\n DueñoBien =" + txt_DuenoBienCampo.Text + "\n TipoSolucionCampo =" + txt_TipoSolucionCampo.Text;
            Auditoria_Ceriv(observacion, "Gestion Campo");
            
        }
        public void Auditoria_Ceriv(string observacionTemporal, string campoTemporal)
        {
            C_AuditoriaCeriv objetoAuditoriaCeriv = new C_AuditoriaCeriv();
            objetoAuditoriaCeriv.CuentaBT = txt_CuentaBT.Text;
            objetoAuditoriaCeriv.DniTrabajador = _dniTrabajador;
            objetoAuditoriaCeriv.Observacion = observacionTemporal;
            objetoAuditoriaCeriv.Campo = campoTemporal;
            if (_ceriv.Auditoria(1, objetoAuditoriaCeriv))
            {
                // MessageBox.Show("Registro Guardado");
            }
            else
            {
                return;
            }
        }

        //PERMISOS DEL PROGRAMA
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
        private bool PermisoAdministradorAbogado()
        {
            //codigo administrador en la bd es de 
            C_Trabajador objetoTrabajador = _ceriv.TrabajadorMostrar1(_dniTrabajador);
            if (objetoTrabajador.CodigoTipoTrabajador < 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool PermisoAdministradorAbogadoGestor()
        {
            //codigo administrador en la bd es de 
            C_Trabajador objetoTrabajador = _ceriv.TrabajadorMostrar1(_dniTrabajador);
            if (objetoTrabajador.CodigoTipoTrabajador < 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*INGRESO PROGRAMA*/

            private void btn_Limpiar_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogadoGestor())
                {
                    limpiartodo();
                    LimpiarDGV();
                    CargarPagos();
                    LimpiarFecha();
                    CargarComboBoxOperacion();
                    txt_NombreTitularPagos.Clear();
                    txt_CarteraPagos.Clear();
                    txt_MonedaPagos.Clear();
                    _bandera = false;
                    tab_Global.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Permiso Denegado");
                }
            }
            public void limpiartodo()
            {
                DesactivarBotonesModificar();
                DesactivarBotonesEliminar();
                ActivarBotonesGuardar();
                btn_GuardarProyeccion.Enabled = true;
                FormatearFecha();
                limpiarPersona();
                ActivarTitular();
                LimpiarCredito();
                ActivarCredito();
                LimpiarGarante();
                ActivarGarante();
                LimpiarProceso();
                ActivarProceso();
                LimpiarFecha();
                ActivarFecha();
                limpiarExpediente();
                ActivarExpediente();
                LimpiarBien();
                ActivarBien();
                LimpiarOtrasCargas();
                ActivarOtrasCargas();
                LimpiarSeguimientoProceso();
                ActivarSeguimiento();
                LimpiarPagos();
                ActivarPagos();
                LimpiarGestionLlamada();
                ActivarGestionLlamadas();
                LimpiarGestionCampo();
                ActivarGestionCampo();
                limpiarProyeccion();
                ActivarProyeccion();
                limpiarhistorico();
                LimpiarUbicacion();
                LimpiarLiquidaciones();
                ActivarLiquidaciones();
            }
            public void LimpiarDGV()
            {
                dgv_Garante.DataSource = null;
                dgv_bien.DataSource = null;
                dgv_OtrasCargas.DataSource = null;
                dgv_Procesos.DataSource = null;
                dgv_Pagos.DataSource = null;
                dgv_GestionLlamada.DataSource = null;
                dgv_GestionCampo.DataSource = null;
            }



       // -------------------------------------------------
                  //
        //        

        /*TITULAR*/

            //BOTONES EN TITULAR

            private void btn_AgregarDistritoTitular_Click(object sender, EventArgs e)
            {
                if (PermisoAdministrador())
                {
                    AbrirDistrito();
                }
                else
                {
                    MessageBox.Show("Permiso Denegado");
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                AbrirBuscarCliente();
            }
            private void button2_Click(object sender, EventArgs e)
            {
                AbrirBuscarCuentaBT();
            }
            private void btn_GuardarTitular_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogadoGestor())
                {
                    if (txt_CuentaBT.Text != string.Empty)
                    {
                        if (txt_Doi.Text != string.Empty)
                        {
                            GuardarCuentaBT();
                            GuardarPersona();
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un Número de DNI, Por Favor");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese una Cuenta BT, Por Favor");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Permiso Denegado");
                    return;
                }
            }
            private void btn_ModificarTitular_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogadoGestor())
                {
                    btn_GuardarTitular.Enabled = true;
                    btn_ModificarTitular.Enabled = false;
                    ActivarTitular();
                    _bandera = true;
                    _cuentaBtAntiguo = txt_CuentaBT.Text;
                    _dniAntiguo = txt_Doi.Text;
                }
                else
                {
                    MessageBox.Show("Permiso Denegado");
                }
            }
            private void btn_BuscarPersona_Click(object sender, EventArgs e)
            {
                AbrirBuscarClienteNombre();
            }
       

            //FUNCIONES EN TITULAR

            private void GuardarPersona()
            {
                int accion = 1;
                C_Persona objetoPersona = new C_Persona();
                objetoPersona.Cuenta_bt = txt_CuentaBT.Text;
                //
                objetoPersona.Doi_cliente = txt_Doi.Text;
                //
                if (cmb_DistritoTitular.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese un Distrito al Titular");
                    return;
                }
                objetoPersona.CodigoDistrito = Int32.Parse(cmb_DistritoTitular.SelectedValue.ToString());
                //
                if (txt_NombreTitular.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese un Nombre del Titular");
                    return;
                }
                objetoPersona.NombreCompleto = txt_NombreTitular.Text;
                //
                if (txt_NombreConyuge.Text == string.Empty)
                    objetoPersona.NombreConyuge = " ";
                objetoPersona.NombreConyuge = txt_NombreConyuge.Text;
                //

                if (txt_DomicilioTitular.Text == string.Empty)
                    objetoPersona.DomicilioPersona = " ";
                objetoPersona.DomicilioPersona = txt_DomicilioTitular.Text;
                //
                if (txt_DireccionTitular.Text == string.Empty)
                    objetoPersona.DireccionAlterna = " ";
                objetoPersona.DireccionAlterna = txt_DireccionTitular.Text;
                //
                if (txt_Representante.Text == string.Empty)
                    objetoPersona.Representante = " ";
                objetoPersona.Representante = txt_Representante.Text;
                //

                //
                if (_bandera && txt_Doi.Text != _dniAntiguo)
                {
                    accion = 2;
                    objetoPersona.Doi_cliente = _dniAntiguo;
                }
                //
                if (txt_NumeroTitular.Text == string.Empty)
                    objetoPersona.Numero = " ";
                objetoPersona.Numero = txt_NumeroTitular.Text;
                //
                if(cmb_Convenio.Text == "NO")
                {
                    objetoPersona.Convenio = "NO";
                }
                else if(cmb_Convenio.Text == "")
                {
                    objetoPersona.Convenio = "NO";
                }
                else if (cmb_Convenio.Text == "SI")
                {
                    objetoPersona.Convenio = "SI";
                }
                //
                objetoPersona.NuevoDoi = txt_Doi.Text;

                if (_ceriv.Persona(accion, objetoPersona))
                {
                    MessageBox.Show("Se ingreso un Cliente Correctamente");
                    _bandera = false;
                    AuditoriaTitular();          
                    btn_GuardarTitular.Enabled = false;
                    btn_ModificarTitular.Enabled = true;
                    BloquearTitular();
                
                }
                else
                {
                    MessageBox.Show("Revise el DNI");
                }

            }
            private void GuardarCuentaBT()
            {
                int accion = 1;
                C_Credito objetoCredito = new C_Credito();
                objetoCredito.CuentaBT = txt_CuentaBT.Text;
                if (_bandera && txt_CuentaBT.Text!= _cuentaBtAntiguo)
                {
                    accion = 2;
                    objetoCredito.CuentaBT = _cuentaBtAntiguo;
                }
                objetoCredito.CuentabtNueva = txt_CuentaBT.Text;
                if (_ceriv.CuentaBT(accion, objetoCredito))
                {
                  //  MessageBox.Show("Ingreso la Cuenta BT Correctamente");
                }
                else
                {
                    //MessageBox.Show("Error");
                }

            }

            public void ActivarTitular()
            {
                txt_NombreTitular.Enabled = true;
                txt_NombreConyuge.Enabled = true;
                txt_NumeroTitular.Enabled = true;
                txt_Doi.Enabled = true;
                txt_Representante.Enabled = true;
                txt_DomicilioTitular.Enabled = true;
                txt_DireccionTitular.Enabled = true;
                cmb_DistritoTitular.Enabled = true;
                txt_CuentaBT.Enabled = true;
                txt_NumeroTitular.Enabled = true;
                cmb_Convenio.Enabled = true;

            }
            public void BloquearTitular()
            {
                txt_NombreTitular.Enabled = false;
                txt_NombreConyuge.Enabled = false;
                txt_NumeroTitular.Enabled = false;
                txt_Doi.Enabled = false;
                txt_Representante.Enabled = false;
                txt_DomicilioTitular.Enabled = false;
                txt_DireccionTitular.Enabled = false;
                cmb_DistritoTitular.Enabled = false;
                txt_CuentaBT.Enabled = false;
                txt_NumeroTitular.Enabled = false;
                cmb_Convenio.Enabled = false;
            }
            public void limpiarPersona()
            {
                txt_NombreTitular.Clear();
                txt_NombreConyuge.Clear();
                txt_Doi.Clear();
                txt_CuentaBT.Clear();
                txt_Representante.Clear();
                txt_DomicilioTitular.Clear();
                txt_DireccionTitular.Clear();
                cmb_DistritoTitular.SelectedIndex = -1;
                txt_NumeroTitular.Clear();
                cmb_Convenio.Text = "";
            }

            public void AbrirDistrito()
            {
                F_Distrito obj = new F_Distrito();
                obj.ShowDialog();
                CargarComboBoxDistrito();
            }
            private void AbrirBuscarCliente()
            {
                if (txt_Doi.Text != string.Empty)
                {
                    if (_ceriv.DoiExiste(txt_Doi.Text))
                    {
                        CargarTitularPorDoi();
                        CargarComboBoxOperacion();
                        btn_GuardarTitular.Enabled = false;
                        btn_ModificarTitular.Enabled = true;
                        BloquearTitular();
                        _bandera = false;
                    }
                    else
                    {
                        MessageBox.Show("El DOI ingresado no Existe");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un DOI para Buscar");
                    return;
                }

            }
            private void AbrirBuscarCuentaBT()
            {
                if (txt_CuentaBT.Text != string.Empty)
                {
                    if (_ceriv.CuentaBTExiste(txt_CuentaBT.Text))
                    {
                        CargarTitularPorCuentaBT();
                        CargarComboBoxOperacion();
                        btn_GuardarTitular.Enabled = false;
                        btn_ModificarTitular.Enabled = true;
                        BloquearTitular();
                        _bandera = false;
                    }
                    else
                    {
                        MessageBox.Show("La Cuenta BT ingresada no Existe");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese una Cuenta BT para Buscar");
                    return;
                }
            }

            public void CargarTitularPorCuentaBT()
            {
                C_Persona objPersona = _ceriv.PersonaMostrar1(txt_CuentaBT.Text);
                txt_NombreTitular.Text = objPersona.NombreCompleto;
                txt_NombreConyuge.Text = objPersona.NombreConyuge;
                txt_Doi.Text = objPersona.Doi_cliente;
                txt_CuentaBT.Text = objPersona.Cuenta_bt;
                txt_Representante.Text = objPersona.Representante;
                txt_DomicilioTitular.Text = objPersona.DomicilioPersona;
                txt_DireccionTitular.Text = objPersona.DireccionAlterna;
                cmb_DistritoTitular.SelectedValue = objPersona.CodigoDistrito;
                txt_NumeroTitular.Text = objPersona.Numero;
                if (cmb_Convenio.Text == null)
                {
                    cmb_Convenio.Text = "NO";
                }
                else {
                    cmb_Convenio.Text = objPersona.Convenio;
                }

            }
            public void CargarTitularPorDoi()
            {
                {
                    C_Persona objPersona = _ceriv.PersonaMostrar1PorDoi(txt_Doi.Text);
                    txt_NombreTitular.Text = objPersona.NombreCompleto;
                    txt_NombreConyuge.Text = objPersona.NombreConyuge;
                    txt_Doi.Text = objPersona.Doi_cliente;
                    txt_CuentaBT.Text = objPersona.Cuenta_bt;
                    txt_Representante.Text = objPersona.Representante;
                    txt_DomicilioTitular.Text = objPersona.DomicilioPersona;
                    txt_DireccionTitular.Text = objPersona.DireccionAlterna;
                    cmb_DistritoTitular.SelectedValue = objPersona.CodigoDistrito;
                    txt_NumeroTitular.Text = objPersona.Numero;
                    cmb_Convenio.Text = objPersona.Convenio;

                }
 
            }

            public void AbrirBuscarClienteNombre()
            {
                E_NombreTitular obj1 = new E_NombreTitular();
                obj1.ShowDialog();
                if (obj1.Nuevo == string.Empty)
                {
                    MessageBox.Show("Seleccione un Cliente");
                }
                else
                {
                    txt_CuentaBT.Text = obj1.Nuevo;
                    CargarTitularPorCuentaBT();
                    BloquearTitular();
                    LimpiarCredito();
                    limpiarExpediente();
                    LimpiarDGV();
                    CargarComboBoxOperacion();
                    tab_Global.SelectedIndex = 0;
                    btn_GuardarTitular.Enabled = false;
                    btn_ModificarTitular.Enabled = true;
                    _bandera = false;
                }
            }

       

            //COMBO BOX EN TITULAR

            public void CargarComboBoxDistrito()
            {
                cmb_DistritoTitular.DisplayMember = "NombreDistrito";
                cmb_DistritoTitular.ValueMember = "CodigoDistrito";
                cmb_DistritoTitular.DataSource = _ceriv.DistritoMostrar();

                cmb_Distrito_Garante.DisplayMember = "NombreDistrito";
                cmb_Distrito_Garante.ValueMember = "CodigoDistrito";
                cmb_Distrito_Garante.DataSource = _ceriv.DistritoMostrar();

                cmb_DistritoBien.DisplayMember = "NombreDistrito";
                cmb_DistritoBien.ValueMember = "CodigoDistrito";
                cmb_DistritoBien.DataSource = _ceriv.DistritoMostrar();
            }
            public void CargarComboBoxOperacion()
            {
                cmb_Operacion.DisplayMember = "Operacion";
                cmb_Operacion.ValueMember = "Operacion";
                cmb_Operacion.DataSource = _ceriv.OperacionMostrar(txt_CuentaBT.Text);
            }


            //EVENTOS DE TITULAR
            private void txt_CuentaBT_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    AbrirBuscarCuentaBT();
                }
            }
            private void txt_Doi_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    AbrirBuscarCliente();
                }
            }


            // -------------------------------------------------
            //
            //        

        /*CREDITO*/

            //BOTONES DEL CREDITO 

            private void button3_Click(object sender, EventArgs e)
            {//BOTON LIMPIAR
                _bandera = false;
                LimpiarCredito();
                btn_ModificarCredito.Enabled = false;
                btn_GuardarCredito.Enabled = true;
                ActivarCredito();
                txt_Otro.Enabled = false;
                dtp_Cambio.Enabled = false;
            }
            private void btn_GuardarCredito_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    GuardarCredito();
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void btn_ModificarCredito_Click_1(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    ModificarCredito();
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void btn_Ciudad_Click_1(object sender, EventArgs e)
            {
                if (PermisoAdministrador())
                {
                    AbrirCiudad();
                }
                else
                {
                    MessageBox.Show("Permiso Denegado");
                }
            }
            private void btn_Estudio_Click_1(object sender, EventArgs e)
            {
                if (PermisoAdministrador())
                {
                    AbrirEstudio();
                }
                else
                {
                    MessageBox.Show("Permiso Denegado");
                }
            }
            private void btn_Cartera_Click_1(object sender, EventArgs e)
            {
                if (PermisoAdministrador())
                {
                    AbrirCartera();
                }
                else
                {
                    MessageBox.Show("Permiso Denegado");
                }
            }

            //FUNCIONES DEL CREDITO

            public void CargarTodoProceso()
            {
                cmb_TodoProceso.DisplayMember = "Operacion";
                cmb_TodoProceso.ValueMember = "Operacion";
                cmb_TodoProceso.DataSource = _ceriv.OperacionTodoMostrar();
            }

            public void LimpiarCredito()
            {
                cmb_Operacion.SelectedIndex = -1;
                cmb_Cartera.SelectedIndex = -1;
                txt_Castigos.Clear();
                cmb_Modelo.SelectedIndex = -1;
                txt_Agencia.Clear();
                txt_Cdr.Clear();
                txt_ProductoModulo.Clear();
                txt_Operacion.Clear();
                txt_Capital.Clear();
                cmb_Moneda.SelectedIndex = -1;
                txt_Ejecutivo.Clear();
                cmb_Ciudad.SelectedIndex = -1;
                cmb_Estudio.SelectedIndex = -1;
                txt_MontoAdmitido.Clear();
                chk_Transito.Checked = false;
                chk_Canal.Checked = false;
                txt_Otro.Clear();
                txt_Otro.Enabled = false;
                dtp_Cambio.Enabled = false;
                dtp_Cambio.Value = DateTime.Parse("01-01-1990");
                dtp_Cambio.CustomFormat = " ";
                dtp_Cambio.Format = DateTimePickerFormat.Custom;
                dtp_Protesto.Value = DateTime.Parse("01-01-1990");
                dtp_Protesto.CustomFormat = " ";
                dtp_Protesto.Format = DateTimePickerFormat.Custom;
                dtp_Asignacion.Value = DateTime.Parse("01-01-1990");
                dtp_Asignacion.CustomFormat = " ";
                dtp_Asignacion.Format = DateTimePickerFormat.Custom;
            }
            public void ActivarCredito()
            {
                cmb_Cartera.Enabled = true;
                txt_Castigos.Enabled = true;
                cmb_Modelo.Enabled = true;
                txt_ProductoModulo.Enabled = true;
                txt_Cdr.Enabled = true;
                txt_Agencia.Enabled = true;
                txt_Operacion.Enabled = true;
                txt_Capital.Enabled = true;
                cmb_Moneda.Enabled = true;
                dtp_Protesto.Enabled = true;
                dtp_Asignacion.Enabled = true;
                cmb_Ciudad.Enabled = true;
                cmb_Estudio.Enabled = true;
                chk_Transito.Enabled = true;
                chk_Canal.Enabled = true;
                dtp_Cambio.Enabled = true;
                txt_Otro.Enabled = true;
                txt_Ejecutivo.Enabled = true;
                txt_MontoAdmitido.Enabled = true;
            }
            private void GuardarCredito()
            {
                int accion = 1;
                C_Credito objetoCredito = new C_Credito();
                if (txt_Operacion.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese un Número de Operacion");
                    return;
                }
                else
                {
                    objetoCredito.Operacion = txt_Operacion.Text;
                }
                //
                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese Una  " + lbl_cuentabt.Text + " ");
                    return;
                }
                objetoCredito.CuentaBT = txt_CuentaBT.Text;
                //
                if (cmb_Cartera.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingresar un Tipo de Cartera");
                    return;
                }
                objetoCredito.CodigoCartera = Int32.Parse(cmb_Cartera.SelectedValue.ToString());
                //
                if (cmb_Moneda.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingresar un Tipo de Moneda");
                    return;
                }
                objetoCredito.CodigoMoneda = Int32.Parse(cmb_Moneda.SelectedValue.ToString());
                //
                if (cmb_Ciudad.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingresar una Ciudad");
                    return;
                }
                objetoCredito.CodigoCiudad = Int32.Parse(cmb_Ciudad.SelectedValue.ToString());
                //
                if (cmb_Estudio.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingresar un Estudio");
                    return;
                }
                objetoCredito.CodigoEstudio = Int32.Parse(cmb_Estudio.SelectedValue.ToString());
                // Se verifica el estado de los checkbox, en la pestaña credito para ingresar los datos correspondientes.
                if (chk_Transito.Checked == true)
                {
                    objetoCredito.CodigoTramite = 1;
                    objetoCredito.ObservacionTramite = txt_Otro.Text;
                    objetoCredito.FechaTramite = dtp_Cambio.Value.Date;
                }
                else if (chk_Canal.Checked == true)
                {
                    objetoCredito.CodigoTramite = 3;
                    objetoCredito.ObservacionTramite = txt_Otro.Text;
                    objetoCredito.FechaTramite = dtp_Cambio.Value.Date;
                }
                else
                {
                    objetoCredito.CodigoTramite = 4;
                    if (txt_Otro.Text == string.Empty)
                    {
                        objetoCredito.ObservacionTramite = " ";
                        dtp_Cambio.Value = DateTime.Parse("01-01-1990");
                        dtp_Cambio.CustomFormat = " ";
                        dtp_Cambio.Format = DateTimePickerFormat.Custom;
                        objetoCredito.FechaTramite = dtp_Cambio.Value.Date;

                    }
                    else
                    {
                        txt_Otro.Clear();
                        objetoCredito.ObservacionTramite = " ";
                        dtp_Cambio.Value = DateTime.Parse("01-01-1990");
                        dtp_Cambio.CustomFormat = " ";
                        dtp_Cambio.Format = DateTimePickerFormat.Custom;
                        objetoCredito.FechaTramite = dtp_Cambio.Value.Date;
                    }
                }
                //
                if (cmb_Modelo.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingresar un Modelo");
                    return;
                }
                objetoCredito.Modelo = Int32.Parse(cmb_Modelo.SelectedValue.ToString());
                //
                if (txt_Castigos.Text == string.Empty)
                    objetoCredito.Castigos = " ";
                objetoCredito.Castigos = txt_Castigos.Text;
                //
                if (txt_Cdr.Text == string.Empty)
                    objetoCredito.Cdr = " ";
                objetoCredito.Cdr = txt_Cdr.Text;
                //
                if (txt_Capital.Text == string.Empty)
                    objetoCredito.Capital = " ";
                objetoCredito.Capital = txt_Capital.Text;
                //
                objetoCredito.FechaProtesto = dtp_Protesto.Value.Date;
                //
                if (txt_Agencia.Text == string.Empty)
                    objetoCredito.Agencia = " ";
                objetoCredito.Agencia = txt_Agencia.Text;
                //
                objetoCredito.FechaAsignacion = dtp_Asignacion.Value.Date;
                //
                if (txt_MontoAdmitido.Text == string.Empty)
                    objetoCredito.MontoAdmitido = " ";
                objetoCredito.MontoAdmitido = txt_MontoAdmitido.Text;
                //
                if (txt_ProductoModulo.Text == string.Empty)
                    objetoCredito.ProductoModulo = " ";
                objetoCredito.ProductoModulo = txt_ProductoModulo.Text;
                //
                if (txt_Ejecutivo.Text == string.Empty)
                    objetoCredito.Ejecutivo = " ";
                objetoCredito.Ejecutivo = txt_Ejecutivo.Text;
                //
                if (_bandera == true && txt_Operacion.Text != _operacionAntiguo)
                {
                    accion = 2;
                    objetoCredito.Operacion = _operacionAntiguo;
                }
                //
                objetoCredito.CuentabtNueva = txt_Operacion.Text;
                //
                if (_ceriv.Credito(accion, objetoCredito))
                {
                    btn_GuardarCredito.Enabled = false;
                    ValidarModelo();
                    BloquearCredito();
                    btn_ModificarCredito.Enabled = true;
                    MessageBox.Show("Se ingreso Correctamente el Credito");
                    AuditoriaCredito();
                    CargarComboBoxOperacion();
                    _bandera = false;
                    if (objetoCredito.CodigoTramite != 4)
                    {
                        
                    }

                    /*if (objetoCredito.CodigoTramite == 4)
                    {
                        btn_GuardarCredito.Enabled = false;
                        ValidarModelo();
                        BloquearCredito();
                        btn_ModificarCredito.Enabled = true;
                        MessageBox.Show("Se ingreso Correctamente el Credito");
                        AuditoriaCredito();
                        CargarComboBoxOperacion();
                        _bandera = false;
                        //VisibleGuardar();
                        //VisibleModificar();
                        //VisibleEliminar();
                        if (_recorrerArray > 0)
                        {
                            _array[_recorrerArray] = txt_CuentaBT.Text;
                        }
                        //DesbloqueoPorTramite();
                        //ActivarDataGridView();
                        //BloquearTitular();

                        if (txt_EstadoCautelar.Enabled == true)
                        {
                            DesbloquearTodo();
                            btn_GuardarCredito.Enabled = false;
                            //MessageBox.Show("Se ingreso Correctamente el Credito");
                        };
                    }
                    else if (objetoCredito.CodigoTramite == 1 || objetoCredito.CodigoTramite == 3)
                    {
                        btn_GuardarCredito.Enabled = false;
                        ValidarModelo();
                        //InvisibleModificar();
                        //InvisibleGuardar();
                        //InvisibleEliminar();
                        //DesactivarDataGridView();
                        //BloquearTodo();
                        //BloqueoPorTramite();
                        BloquearCredito();
                        btn_ModificarCredito.Enabled = true;
                        AuditoriaCredito();
                        CargarComboBoxOperacion();
                        _bandera = false;
                        MessageBox.Show("Se ingreso Correctamente el Credito");
                        if (objetoCredito.CodigoTramite == 1)
                        {
                            chk_Transito.Checked = true;
                        }
                        else if (objetoCredito.CodigoTramite == 3)
                        {
                            chk_Canal.Checked = true;
                        };
                    }*/
                }
                else
                {
                    MessageBox.Show("Revise los Datos");
                }
            }
            private void ModificarCredito()
            {
                btn_GuardarCredito.Enabled = true;
                btn_ModificarCredito.Enabled = false;
                ActivarCredito();
                _bandera = true;
                _operacionAntiguo = txt_Operacion.Text;
            }
            public void CargarCredito()
            {
                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_Operacion.Text);
                txt_Operacion.Text = objCredito.Operacion;
                cmb_Cartera.SelectedValue = objCredito.CodigoCartera;
                cmb_Moneda.SelectedValue = objCredito.CodigoMoneda;
                cmb_Ciudad.SelectedValue = objCredito.CodigoCiudad;
                cmb_Estudio.SelectedValue = objCredito.CodigoEstudio;
                if (objCredito.CodigoTramite == 4)
                {
                    chk_Canal.Checked = false;
                    chk_Transito.Checked = false;
                    txt_Otro.Clear();
                    txt_Otro.Enabled = false;
                    dtp_Cambio.Value = DateTime.Parse("01-01-1990");
                    dtp_Cambio.CustomFormat = " ";
                    dtp_Cambio.Format = DateTimePickerFormat.Custom;
                }
                else if (objCredito.CodigoTramite == 1)
                {
                    chk_Canal.Checked = false;
                    chk_Transito.Checked = true;
                    if (objCredito.FechaTramite == DateTime.Parse("01-01-1990"))
                    {
                        dtp_Cambio.Value = DateTime.Parse("01-01-1990");
                        dtp_Cambio.CustomFormat = " ";
                        dtp_Cambio.Format = DateTimePickerFormat.Custom;
                    }
                    else
                    {
                        dtp_Cambio.Value = objCredito.FechaTramite;
                    }
                    txt_Otro.Text = objCredito.ObservacionTramite;
                }
                else if (objCredito.CodigoTramite == 3)
                {
                    chk_Transito.Checked = false;
                    chk_Canal.Checked = true;
                    if (objCredito.FechaTramite == DateTime.Parse("01-01-1990"))
                    {
                        dtp_Cambio.Value = DateTime.Parse("01-01-1990");
                        dtp_Cambio.CustomFormat = " ";
                        dtp_Cambio.Format = DateTimePickerFormat.Custom;
                    }
                    else
                    {
                        dtp_Cambio.Value = objCredito.FechaTramite;
                    }
                    txt_Otro.Text = objCredito.ObservacionTramite;
                }
                cmb_Modelo.SelectedValue = objCredito.Modelo;
                txt_Castigos.Text = objCredito.Castigos;
                txt_Cdr.Text = objCredito.Cdr;
                txt_Capital.Text = objCredito.Capital;
                if (objCredito.FechaProtesto == DateTime.Parse("01-01-1990"))
                {
                    dtp_Protesto.CustomFormat = " ";
                    dtp_Protesto.Format = DateTimePickerFormat.Custom;
                }
                else if (objCredito.FechaProtesto != DateTime.MinValue)
                {
                    dtp_Protesto.Value = objCredito.FechaProtesto;
                }
                else
                {
                    dtp_Protesto.Value = DateTime.Parse("01-01-1990");
                    dtp_Protesto.CustomFormat = " ";
                    dtp_Protesto.Format = DateTimePickerFormat.Custom;
                }
                txt_Agencia.Text = objCredito.Agencia;
                if (objCredito.FechaAsignacion == DateTime.Parse("01-01-1990"))
                {
                    dtp_Asignacion.CustomFormat = " ";
                    dtp_Asignacion.Format = DateTimePickerFormat.Custom;
                }
                else if (objCredito.FechaAsignacion != DateTime.MinValue)
                {
                    dtp_Asignacion.Value = objCredito.FechaAsignacion;
                }
                else
                {
                    dtp_Asignacion.Value = DateTime.Parse("01-01-1990");
                    dtp_Asignacion.CustomFormat = " ";
                    dtp_Asignacion.Format = DateTimePickerFormat.Custom;
                }
                txt_MontoAdmitido.Text = objCredito.MontoAdmitido;
                txt_ProductoModulo.Text = objCredito.ProductoModulo;
                txt_Ejecutivo.Text = objCredito.Ejecutivo;
                //
                BloquearCredito();
                btn_GuardarCredito.Enabled = false;
                btn_ModificarCredito.Enabled = true;
                btn_LimpiarCredito.Enabled = true;
            }
            public void CargarCreditoTodo()
            {
                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_TodoProceso.Text);
                txt_Operacion.Text = objCredito.Operacion;
                cmb_Cartera.SelectedValue = objCredito.CodigoCartera;
                cmb_Moneda.SelectedValue = objCredito.CodigoMoneda;
                cmb_Ciudad.SelectedValue = objCredito.CodigoCiudad;
                cmb_Estudio.SelectedValue = objCredito.CodigoEstudio;
                if (objCredito.CodigoTramite == 4)
                {
                    chk_Canal.Checked = false;
                    chk_Transito.Checked = false;
                    txt_Otro.Clear();
                    txt_Otro.Enabled = false;
                    dtp_Cambio.Value = DateTime.Parse("01-01-1990");
                    dtp_Cambio.CustomFormat = " ";
                    dtp_Cambio.Format = DateTimePickerFormat.Custom;
                }
                else if (objCredito.CodigoTramite == 1)
                {
                    chk_Canal.Checked = false;
                    chk_Transito.Checked = true;
                    if (objCredito.FechaTramite == DateTime.Parse("01-01-1990"))
                    {
                        dtp_Cambio.Value = DateTime.Parse("01-01-1990");
                        dtp_Cambio.CustomFormat = " ";
                        dtp_Cambio.Format = DateTimePickerFormat.Custom;
                    }
                    else
                    {
                        dtp_Cambio.Value = objCredito.FechaTramite;
                    }
                    txt_Otro.Text = objCredito.ObservacionTramite;
                }
                else if (objCredito.CodigoTramite == 3)
                {
                    chk_Transito.Checked = false;
                    chk_Canal.Checked = true;
                    if (objCredito.FechaTramite == DateTime.Parse("01-01-1990"))
                    {
                        dtp_Cambio.Value = DateTime.Parse("01-01-1990");
                        dtp_Cambio.CustomFormat = " ";
                        dtp_Cambio.Format = DateTimePickerFormat.Custom;
                    }
                    else
                    {
                        dtp_Cambio.Value = objCredito.FechaTramite;
                    }
                    txt_Otro.Text = objCredito.ObservacionTramite;
                }
                cmb_Modelo.SelectedValue = objCredito.Modelo;
                txt_Castigos.Text = objCredito.Castigos;
                txt_Cdr.Text = objCredito.Cdr;
                txt_Capital.Text = objCredito.Capital;
                if (objCredito.FechaProtesto == DateTime.Parse("01-01-1990"))
                {
                    dtp_Protesto.CustomFormat = " ";
                    dtp_Protesto.Format = DateTimePickerFormat.Custom;
                }
                else if (objCredito.FechaProtesto != DateTime.MinValue)
                {
                    dtp_Protesto.Value = objCredito.FechaProtesto;
                }
                else
                {
                    dtp_Protesto.Value = DateTime.Parse("01-01-1990");
                    dtp_Protesto.CustomFormat = " ";
                    dtp_Protesto.Format = DateTimePickerFormat.Custom;
                }
                txt_Agencia.Text = objCredito.Agencia;
                if (objCredito.FechaAsignacion == DateTime.Parse("01-01-1990"))
                {
                    dtp_Asignacion.CustomFormat = " ";
                    dtp_Asignacion.Format = DateTimePickerFormat.Custom;
                }
                else if (objCredito.FechaAsignacion != DateTime.MinValue)
                {
                    dtp_Asignacion.Value = objCredito.FechaAsignacion;
                }
                else
                {
                    dtp_Asignacion.Value = DateTime.Parse("01-01-1990");
                    dtp_Asignacion.CustomFormat = " ";
                    dtp_Asignacion.Format = DateTimePickerFormat.Custom;
                }
                txt_MontoAdmitido.Text = objCredito.MontoAdmitido;
                txt_ProductoModulo.Text = objCredito.ProductoModulo;
                txt_Ejecutivo.Text = objCredito.Ejecutivo;
                //
            }
            public void BloquearCredito()
            {
                cmb_Cartera.Enabled = false;
                txt_Castigos.Enabled = false;
                cmb_Modelo.Enabled = false;
                txt_ProductoModulo.Enabled = false;
                txt_Cdr.Enabled = false;
                txt_Agencia.Enabled = false;
                txt_Operacion.Enabled = false;
                txt_Capital.Enabled = false;
                cmb_Moneda.Enabled = false;
                dtp_Protesto.Enabled = false;
                dtp_Asignacion.Enabled = false;
                cmb_Ciudad.Enabled = false;
                cmb_Estudio.Enabled = false;
                chk_Transito.Enabled = false;
                chk_Canal.Enabled = false;
                dtp_Cambio.Enabled = false;
                txt_Otro.Enabled = false;
                txt_MontoAdmitido.Enabled = false;
                txt_Ejecutivo.Enabled = false;
            }
            private void AbrirCartera()
            {
                Cartera obj = new Cartera();
                obj.ShowDialog();
                CargarComboBoxCartera();
            }
            private void AbrirCiudad()
            {
                Ciudad obj = new Ciudad();
                obj.ShowDialog();
                CargarComboBoxCiudad();
            }
            private void AbrirEstudio()
            {
                Estudio obj = new Estudio();
                obj.ShowDialog();
                CargarComboBoxEstudio();
            }
            public void ValidarModelo()
            {
                if (cmb_Modelo.Text == "MODELO AB")
                {
                    BloquearBien();
                    bloquearOtrasCargas();
                    btn_GuardarBien.Visible = false;
                    btn_ModificarBien.Visible = false;
                    btn_GuardarOtrasCargas.Visible = false;
                    btn_ModificarOtrasCargas.Visible = false;
                    cmb_BienOtrasCargas.Enabled = true;
                }
                else if (cmb_Modelo.Text == "MODELO A" || cmb_Modelo.Text == "MODELO B" || cmb_Modelo.Text == "MODELO C" || cmb_Modelo.Text == "No")
                {
                    ActivarBien();
                    ActivarOtrasCargas();
                    btn_GuardarBien.Visible = true;
                    btn_ModificarBien.Visible = true;
                    btn_GuardarOtrasCargas.Visible = true;
                    btn_ModificarOtrasCargas.Visible = true;
                }
            }

            //COMBO BOX CON LOS CREDITOS DE LA CUENTA_BT

            public void CargarComboBoxCartera()
            {
                cmb_Cartera.DisplayMember = "NombreCartera";
                cmb_Cartera.ValueMember = "CodigoCartera";
                cmb_Cartera.DataSource = _ceriv.CarteraMostrar();
            }
            public void CargarComboBoxCiudad()
            {
                cmb_Ciudad.DisplayMember = "NombreCiudad";
                cmb_Ciudad.ValueMember = "CodigoCiudad";
                cmb_Ciudad.DataSource = _ceriv.CiudadMostrar();

                cmb_CiudadBien.DisplayMember = "NombreCiudad";
                cmb_CiudadBien.ValueMember = "CodigoCiudad";
                cmb_CiudadBien.DataSource = _ceriv.CiudadMostrar();
            }
            public void CargarComboBoxEstudio()
            {
                cmb_Estudio.DisplayMember = "NombreEstudio";
                cmb_Estudio.ValueMember = "CodigoEstudio";
                cmb_Estudio.DataSource = _ceriv.EstudioMostrar();
            }
            public void CargarComboBoxModelo()
            {
                cmb_Modelo.DisplayMember = "Nombre";
                cmb_Modelo.ValueMember = "Codigo";
                cmb_Modelo.DataSource = _ceriv.ModeloMostrar();
            }
            public void EliminarCredito()
            {
                int accion = 1;
                C_Credito objetoCredito = new C_Credito();
               /* if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("No selecciono una Persona");
                    return;
                }
                else
                {
                    objetoCredito.CuentaBT = txt_CuentaBT.Text;
                }*/
                if(txt_Operacion.Text == string.Empty)
                {
                    MessageBox.Show("No selecciono una Operacion");
                    return;
                }
                else
                {
                    objetoCredito.Operacion = txt_Operacion.Text;
                }
                if (_ceriv.CreditoEliminar(accion, objetoCredito))
                {
                    MessageBox.Show("Se Elimino el Credito para esta Cuenta BT");

                }
                else
                {
                    MessageBox.Show("Error al Eliminar la Operacion para la Cuenta BT");
                    return;
                }
            }
        
            //EVENTOS DEL CREDITO

            private void cmb_Operacion_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_Operacion.SelectedIndex != -1)
                {
                    CargarCredito();
                }
            }
            private void cmb_Modelo_TextChanged(object sender, EventArgs e)
            {
                if (cmb_Modelo.Text == "MODELO AB")
                {
                    BloquearBien();
                    bloquearOtrasCargas();
                }

            }
            private void chk_Transito_CheckedChanged_1(object sender, EventArgs e)
            {
                if (chk_Transito.Checked == true)
                {
                    txt_Otro.Enabled = true;
                    dtp_Cambio.Enabled = true;
                    chk_Canal.Enabled = false;
                }
                else
                {
                    chk_Canal.Enabled = true;
                    txt_Otro.Enabled = false;
                    dtp_Cambio.Enabled = false;
                }

            }
            private void chk_Canal_CheckedChanged_1(object sender, EventArgs e)
            {
                if (chk_Canal.Checked)
                {
                    dtp_Cambio.Enabled = true;
                    txt_Otro.Enabled = true;
                    chk_Transito.Enabled = false;
                    chk_Transito.Checked = false;
                }
                else
                {
                    chk_Transito.Enabled = true;
                    txt_Otro.Enabled = false;
                    dtp_Cambio.Enabled = false;
                    txt_Otro.Clear();
                    dtp_Cambio.Value = DateTime.Parse("01-01-1990");
                    dtp_Cambio.CustomFormat = " ";
                    dtp_Cambio.Format = DateTimePickerFormat.Custom;

                    
                }
            }
            private void cmb_TodoProceso_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_Operacion.SelectedIndex == -1)
                {
                    CargarCreditoTodo();
                }
            }

            private void btn_EliminarCredito_Click(object sender, EventArgs e)
            {
                if (txt_Operacion.Text != string.Empty)
                {
                    if (txt_CuentaBT.Text != string.Empty)
                    {
                        EliminarCredito();
                        LimpiarCredito();
                        CargarComboBoxOperacion();

                    }
                }
            }
            private void cmb_Cartera_TextChanged(object sender, EventArgs e)
            {
                if (cmb_Cartera.Text == "CMAC SULLANA")
                {
                    label15.Text = "Situacion";
                }
                else if (cmb_Cartera.Text == "PROEMPRESA")
                {
                    label15.Text = "Situacion";
                }
                else
                {
                    label15.Text = "Castigos";
                }


            }

            // -------------------------------------------------
            //
            //        

        /*GARANTE*/

            //BOTONES DEL GARANTE

            private void btn_GuardarGarante_Click_1(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    GuardarGarante();
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void btn_EliminarGarante_Click(object sender, EventArgs e)
            {
                EliminarGarante();
                // LimpiarGarante();
                btn_EliminarGarante.Enabled = false;
                btn_ModificarGarante.Enabled = false;
                btn_GuardarGarante.Enabled = true;
            }
            private void btn_ModificarTiltular_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    ActivarGarante();
                    btn_GuardarGarante.Enabled = true;
                    btn_ModificarGarante.Enabled = false;
                    btn_EliminarGarante.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void btn_AgregarDistritoAval_Click(object sender, EventArgs e)
            {
                if (PermisoAdministrador())
                {
                    AbrirDistrito();
                }
                else
                {
                    MessageBox.Show("Permiso Denegado");
                }
            }

            //FUNCIONES DEL GARANTE

            public void EliminarGarante()
            {
                C_Garante objetoGarante = new C_Garante();
                objetoGarante.Codigo = Int32.Parse(lblGarante.Text);
                if (objetoGarante.Codigo != 0)
                {
                    if (_ceriv.GaranteEliminar(1, objetoGarante))
                    {
                        MessageBox.Show("Se elimino correctamente el Garante");
                        LimpiarGarante();
                        CargarDataGridViewGarante();
                        ActivarGarante();
                    }
                }
                else
                {
                    MessageBox.Show("No se puede eliminar al Garante");
                    return;
                }
            }
            private void GuardarGarante()
            {
                C_Garante objetoGarante = new C_Garante();
                //
                if (cmb_OperacionGarante.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese un número de operacion");
                    return;
                }
                else
                {
                    objetoGarante.Operacion = cmb_OperacionGarante.SelectedValue.ToString();
                }
                //
                if (txt_Nombre_Garante.Text == string.Empty)
                    txt_Nombre_Garante.Text = " ";
                objetoGarante.NombreCompleto = txt_Nombre_Garante.Text;
                //
                if (txt_Nombre_Conyuge.Text == string.Empty)
                    objetoGarante.NombreConyuge = " ";
                objetoGarante.NombreConyuge = txt_Nombre_Conyuge.Text;
                //
                if (cmb_Distrito_Garante.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese Un Distrito");
                    return;
                }
                objetoGarante.CodigoDistrito = Int32.Parse(cmb_Distrito_Garante.SelectedValue.ToString());
                //
                if (txt_Domicilio_Garante.Text == string.Empty)
                    objetoGarante.DomicilioGarante = " ";
                objetoGarante.DomicilioGarante = txt_Domicilio_Garante.Text;
                //
                objetoGarante.Codigo = Int32.Parse(lblGarante.Text);
                //
                if (_ceriv.Garante(1, objetoGarante))
                {
                    MessageBox.Show("Se ingreso Correctamente al Garante");
                    LimpiarGarante();
                    CargarDataGridViewGarante();
                   // CargarOperacionGarante();
                    AuditoriaGarante();
                }
                else
                {
                    MessageBox.Show("No se pudo Ingresar al Garante");
                }

            }
            private void LimpiarGarante()
            {
                txt_Nombre_Garante.Clear();
                txt_Nombre_Conyuge.Clear();
                cmb_Distrito_Garante.SelectedIndex = -1;
                txt_Domicilio_Garante.Clear();
                lblGarante.Text = "0";
            }
            private void BloquearGarante()
            {
                txt_Nombre_Garante.Enabled = false;
                txt_Nombre_Conyuge.Enabled = false;
                cmb_Distrito_Garante.Enabled = false;
                txt_Domicilio_Garante.Enabled = false;
            }
            private void ActivarGarante()
            {
                txt_Nombre_Garante.Enabled = true;
                txt_Nombre_Conyuge.Enabled = true;
                cmb_Distrito_Garante.Enabled = true;
                txt_Domicilio_Garante.Enabled = true;
            }
            public void CargarDataGridViewGarante()
            {
                dgv_Garante.AutoGenerateColumns = false;
                dgv_Garante.DataSource = _ceriv.GaranteMostrar(cmb_OperacionGarante.SelectedValue.ToString());
            }
            public void CargarOperacionGarante()
            {
                cmb_OperacionGarante.DisplayMember = "Operacion";
                cmb_OperacionGarante.ValueMember = "Operacion";
                cmb_OperacionGarante.DataSource = _ceriv.OperacionMostrar(txt_CuentaBT.Text);
            }

            //EVENTOS DEL GARANTE

            private void cmb_OperacionGarante_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_OperacionGarante.SelectedIndex != -1)
                {
                    CargarDataGridViewGarante();
                    LimpiarGarante();
                    ActivarGarante();
                    btn_GuardarGarante.Enabled = true;
                    btn_ModificarGarante.Enabled = false;
                    btn_EliminarGarante.Enabled = false;
                }
            }
            private void dgv_Garante_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                int row = e.RowIndex;
                if (e.RowIndex > -1)
                {
                    txt_Nombre_Garante.Text = dgv_Garante.Rows[row].Cells["NombreCompleto"].Value.ToString();
                    txt_Nombre_Conyuge.Text = dgv_Garante.Rows[row].Cells["NombreConyuge"].Value.ToString();
                    cmb_Distrito_Garante.SelectedValue = Int32.Parse(dgv_Garante.Rows[row].Cells["CodigoDistrito"].Value.ToString());
                    txt_Domicilio_Garante.Text = dgv_Garante.Rows[row].Cells["DomicilioGarante"].Value.ToString();
                    lblGarante.Text = dgv_Garante.Rows[row].Cells["CodigoGarante"].Value.ToString();
                    BloquearGarante();
                    btn_GuardarGarante.Enabled = false;
                    btn_ModificarGarante.Enabled = true;
                    btn_EliminarGarante.Enabled = true;
                }
            }


            /*LIQUIDACIONES*/

            //FUNCIONES LIQUIDACIONES
            public void EliminarLiquidaciones()
            {
                C_Liquidaciones objLiquidaciones = new C_Liquidaciones();
                objLiquidaciones.Codigo_Detalle_liquidacion = Int32.Parse(lbl_liquidaciones.Text);
                if (objLiquidaciones.Codigo_Detalle_liquidacion != 0)
                {
                    if (_ceriv.LiquidacionEliminar(1,objLiquidaciones))
                    {
                        MessageBox.Show("Se eliminó la liquidación correctamente.");
                        LimpiarLiquidaciones();
                        CargarDgvLiquidaciones();
                        ActivarLiquidaciones();

                    }
                }
                else 
                {
                    MessageBox.Show("No se puede eliminar la liquidación");
                    return;
                }
            }
            public void GuardarLiquidacion()
            {
                int entero;
                float flotante;
                C_Liquidaciones objLiquidaciones = new C_Liquidaciones();
                //
                if (cmb_Operacion.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione una Operación válida para ingresar");
                    return;
                }
                else
                    objLiquidaciones.Operacion = cmb_OperacionLiquidaciones.SelectedValue.ToString();
                //
                if (txt_NumRecibo.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese un Número de Recibo");
                    return;
                }
                else
                    objLiquidaciones.Nro_recibo = txt_NumRecibo.Text;
                //
                if (txt_Cantidad.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese una Cantidad");
                    return;
                }
                else
                {
                    try
                    {
                        entero = Int32.Parse(txt_Cantidad.Text);
                        objLiquidaciones.Cantidad = txt_Cantidad.Text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ingrese una Cantidad en Números");
                        return;
                    }
                }
                //

                if (txt_Monto.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese un Monto");
                    return;
                }
                else
                {
                    try
                    {
                        flotante = float.Parse(txt_Monto.Text);
                        objLiquidaciones.Monto = txt_Monto.Text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ingrese un Monto en Números");
                        return;
                    }
                }
                //
                if (txt_NombreTitular.Text == string.Empty)
                {
                    MessageBox.Show("El nombre del titular no es válido");
                    return;
                }
                else
                    objLiquidaciones.Nombre_cliente = txt_NombreTitular.Text;
                //
                try
                {
                    objLiquidaciones.Fecha_liquidacion = dtp_FechaLiquidaciones.Value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ingrese una fecha válida");
                    return;
                }
                //
                if (cmb_ExpedientesLiquidaciones.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Expediente válido para ingresar");
                    return;
                }
                else
                    objLiquidaciones.Num_expediente = cmb_ExpedientesLiquidaciones.SelectedValue.ToString();
                //
                if (cmb_TipoGasto.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Tipo de Gasto");
                    return;
                }
                else
                    objLiquidaciones.Codigo_tipogasto = Int32.Parse(cmb_TipoGasto.SelectedValue.ToString());
                //
                if (cmb_DetalleTipoGasto.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Detalle del Gasto");
                    return;
                }
                else
                    objLiquidaciones.Codigo_detalle = Int32.Parse(cmb_DetalleTipoGasto.SelectedValue.ToString());
                //
                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese una CuentaBT válida");
                    return;
                }
                else
                    objLiquidaciones.Cuenta_bt = txt_CuentaBT.Text;
                //CODIGO
                objLiquidaciones.Codigo_Detalle_liquidacion = Int32.Parse(lbl_liquidaciones.Text);

                if (_ceriv.Liquidacion(1, objLiquidaciones))
                {
                    MessageBox.Show("Se ingreso el gasto correctamente");
                    CargarDgvLiquidaciones();
                    LimpiarLiquidaciones();
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar el gasto, revisar los datos");
                    return;
                }

              /*  if (objLiquidaciones.Codigo_Detalle_liquidacion == 0)
                {
                    if (_ceriv.Liquidaciones(objLiquidaciones))
                    {
                        MessageBox.Show("Se ingreso el gasto correctamente");
                        CargarDgvLiquidaciones();
                        LimpiarLiquidaciones();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo ingresar el gasto, revisar los datos");
                        return;
                    }
                }
                else 
                {
                    if (_ceriv.LiquidacionesModificar(objLiquidaciones))
                    {
                        MessageBox.Show("Se modificó el gasto correctamente");
                        CargarDgvLiquidaciones();
                        LimpiarLiquidaciones();
                    }
                    else 
                    {
                        MessageBox.Show("No se pudo modificar el gasto correctamente");
                        return;
                    }
                }*/
                
            }
            public void LimpiarLiquidaciones()
            {
                cmb_TipoGasto.SelectedIndex = -1;
                cmb_DetalleTipoGasto.SelectedIndex = -1;
                txt_NumRecibo.Clear();
                txt_Cantidad.Clear();
                txt_Monto.Clear();
                dtp_FechaLiquidaciones.Value = DateTime.Today;
                lbl_liquidaciones.Text = "0";
            }
            public void BloquearLiquidaciones() 
            {
                cmb_TipoGasto.Enabled = false;
                cmb_DetalleTipoGasto.Enabled = false;
                txt_NumRecibo.Enabled = false;
                txt_Cantidad.Enabled = false;
                txt_Monto.Enabled = false;
                dtp_FechaLiquidaciones.Enabled = false;     
            }
            public void ActivarLiquidaciones()
            {
                cmb_TipoGasto.Enabled = true;
                cmb_DetalleTipoGasto.Enabled = true;
                txt_NumRecibo.Enabled = true;
                txt_Cantidad.Enabled = true;
                txt_Monto.Enabled = true;
                dtp_FechaLiquidaciones.Enabled = true;
            }

            public void CargarOperacionLiquidaciones()
            {
                cmb_OperacionLiquidaciones.DisplayMember = "Operacion";
                cmb_OperacionLiquidaciones.ValueMember = "Operacion";
                cmb_OperacionLiquidaciones.DataSource = _ceriv.OperacionMostrar(txt_CuentaBT.Text);

            }
            public void CargarExpedienteLiquidaciones()
            {
                cmb_ExpedientesLiquidaciones.DisplayMember = "NumExpediente";
                cmb_ExpedientesLiquidaciones.ValueMember = "NumExpediente";
                cmb_ExpedientesLiquidaciones.DataSource = _ceriv.ExpedienteCreditoMostrar(cmb_OperacionLiquidaciones.SelectedValue.ToString());
            }
            public void CargarTipoGasto()
            {
                cmb_TipoGasto.DisplayMember = "Nombre";
                cmb_TipoGasto.ValueMember = "Codigo";
                cmb_TipoGasto.DataSource = _ceriv.TipoGastoMostrar();
            }
            public void CargarDetalleTipoGasto()
            {
                cmb_DetalleTipoGasto.DisplayMember = "Nombre_detalle";
                cmb_DetalleTipoGasto.ValueMember = "Codigo_detalle";
                cmb_DetalleTipoGasto.DataSource = _ceriv.DetalleTipoGastoMostrar(Int32.Parse(cmb_TipoGasto.SelectedValue.ToString()));
            }
            public void CargarDgvLiquidaciones()
            {
                if (cmb_ExpedientesLiquidaciones.SelectedIndex != -1 || cmb_OperacionLiquidaciones.SelectedIndex != -1)
                {
                    dgv_Liquidaciones.AutoGenerateColumns = false;
                    dgv_Liquidaciones.DataSource = _ceriv.LiquidacionesMostrar(cmb_OperacionLiquidaciones.SelectedValue.ToString(), cmb_ExpedientesLiquidaciones.SelectedValue.ToString(), txt_NombreTitular.Text, txt_CuentaBT.Text);
                }
            }
            public void CopiarTodoDataGridView() 
            {
                dgv_Liquidaciones.SelectAll();
                DataObject dataObj = dgv_Liquidaciones.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);
            }

            //EVENTOS LIQUIDACIONES

            private void dgv_Liquidaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                int row = e.RowIndex;
                if (e.RowIndex > -1) 
                {
                    cmb_TipoGasto.SelectedValue = Int32.Parse(dgv_Liquidaciones.Rows[row].Cells["codigo_tipogasto"].Value.ToString());
                    cmb_DetalleTipoGasto.SelectedValue = Int32.Parse(dgv_Liquidaciones.Rows[row].Cells["codigo_detalle"].Value.ToString());
                    txt_NumRecibo.Text = dgv_Liquidaciones.Rows[row].Cells["nrorecibo"].Value.ToString();
                    txt_Cantidad.Text = dgv_Liquidaciones.Rows[row].Cells["Cantidad"].Value.ToString();
                    txt_Monto.Text = dgv_Liquidaciones.Rows[row].Cells["Monto"].Value.ToString();
                    dtp_FechaLiquidaciones.Value = DateTime.Parse(dgv_Liquidaciones.Rows[row].Cells["Fecha"].Value.ToString());
                    lbl_liquidaciones.Text = dgv_Liquidaciones.Rows[row].Cells["Codigo_Detalle_liquidacion"].Value.ToString();
                    BloquearLiquidaciones();
                    btn_GuardarLiquidaciones.Enabled = false;
                    btn_ModificarLiquidaciones.Enabled = true;
                    btn_EliminarLiquidacion.Enabled = true;
                }
            }
            private void cmb_OperacionLiquidaciones_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_OperacionLiquidaciones.SelectedIndex != -1)
                {
                    cmb_ExpedientesLiquidaciones.SelectedIndex = -1;
                    cmb_ExpedientesLiquidaciones.Text = "";
                    CargarExpedienteLiquidaciones();

                }
            }
            private void cmb_TipoGasto_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_TipoGasto.SelectedIndex != -1)
                {
                    cmb_DetalleTipoGasto.SelectedIndex = -1;
                    cmb_DetalleTipoGasto.Text = "";
                    CargarDetalleTipoGasto();

                }
            }
            private void cmb_ExpedientesLiquidaciones_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_ExpedientesLiquidaciones.SelectedIndex != -1)
                {
                    LimpiarLiquidaciones();
                    ActivarLiquidaciones();
                    btn_GuardarLiquidaciones.Enabled = true;
                    btn_ModificarLiquidaciones.Enabled = false;
                    btn_EliminarLiquidacion.Enabled = false;
                    CargarDgvLiquidaciones();
                }
            }



            //BOTONES LIQUIDACIONES
            private void btn_EliminarLiquidacion_Click(object sender, EventArgs e)
            {
                EliminarLiquidaciones();
            }
            private void btn_GuardarLiquidaciones_Click(object sender, EventArgs e)
            {
                GuardarLiquidacion();
            }
            private void btn_ModificarLiquidaciones_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    ActivarLiquidaciones();
                    btn_GuardarLiquidaciones.Enabled = true;
                    btn_ModificarLiquidaciones.Enabled = false;
                    btn_EliminarLiquidacion.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void btn_ExportarLiquidacion_Click(object sender, EventArgs e)
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
            
        /*EXPEDIENTE*/

            // BOTONES DEL EXPEDIENTE

            private void btn_GuardarExpediente_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    if (_bandera != true)
                    {
                        GuardarExpediente();
                        GuardarExpedienteCredito();
                    }
                    else
                    {
                        GuardarExpediente();
                    }
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void btn_Responsable_Click_1(object sender, EventArgs e)
            {
                if (PermisoAdministrador())
                {
                    AbrirResponsable();
                }
                else
                {
                    MessageBox.Show("Permiso Denegado");
                }
            }
            private void btn_Abogado_Click_1(object sender, EventArgs e)
            {
                if (PermisoAdministrador())
                {
                    AbrirAbogado();
                }
                else
                {
                    MessageBox.Show("Permiso Denegado");
                }
            }
            private void btn_Tipo_Proceso_Click_1(object sender, EventArgs e)
            {
                if (PermisoAdministrador())
                {
                    AbrirTipoProceso();
                }
                else
                {
                    MessageBox.Show("Permiso Denegado");
                }
            }
            private void btn_ModificarExpediente_Click_1(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    _bandera = true;
                    _operacionAntiguo = txt_NumExpediente.Text;
                    ActivarExpediente();
                    btn_ModificarExpediente.Enabled = false;
                    btn_GuardarExpediente.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void btn_LimpiarExpediente_Click(object sender, EventArgs e)
            {
                limpiarExpediente();
                _bandera = false;
                btn_ModificarExpediente.Enabled = false;
                btn_GuardarExpediente.Enabled = true;
            }
            private void btn_Eliminar_Click(object sender, EventArgs e)
            {
                EliminarExpedienteCredito();
                CargarComboBoxOperacion();
               // CargarComboBoxExpedienteCredito();
            }

            //FUNCIONES DEL EXPEDIENTE

            public void CargarComboBoxExpedienteCredito()
            {
                    cmb_ExpCredito.DisplayMember = "NumExpediente";
                    cmb_ExpCredito.ValueMember = "NumExpediente";
                    cmb_ExpCredito.DataSource = _ceriv.ExpedienteCreditoMostrar(cmb_OperacionExpediente.SelectedValue.ToString());
                
            }
            public void CargarTodoExpedientes()
            {
                cmb_TodoExpediente.DisplayMember = "NumExpediente";
                cmb_TodoExpediente.ValueMember = "NumExpediente";
                cmb_TodoExpediente.DataSource = _ceriv.ExpedienteTodoMostrar();

            }
            public void CargarComboBoxResponsable()
            {
                cmb_Responsable.DisplayMember = "NombreCompleto";
                cmb_Responsable.ValueMember = "DniTrabajador";
                cmb_Responsable.DataSource = _ceriv.ResponsableMostrar();
            }
            public void CargarComboBoxAbogado()
            {
                cmb_Abogado.DisplayMember = "NombreCompleto";
                cmb_Abogado.ValueMember = "DniTrabajador";
                cmb_Abogado.DataSource = _ceriv.AbogadoMostrar();
            }
            public void CargarComboBoxProceso()
            {
                cmb_Tipo_Proceso.DisplayMember = "NombreProceso";
                cmb_Tipo_Proceso.ValueMember = "CodigoProceso";
                cmb_Tipo_Proceso.DataSource = _ceriv.ProcesoMostrar();

            }
            public void GuardarExpedienteCredito()
            {
                int accion = 1;
                C_Expediente objetoExpediente = new C_Expediente();
                if (cmb_OperacionExpediente.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese Un Número de Crédito Por Favor");
                    return;
                }
                else
                {
                    objetoExpediente.Operacion = cmb_OperacionExpediente.SelectedValue.ToString();
                }
                //
                if (txt_NumExpediente.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese un Número de Expediente Por Favor");
                    return;
                }
                else
                {
                    objetoExpediente.NumExpediente = txt_NumExpediente.Text;
                }
                //
                if (_ceriv.ExpedienteCredito(accion, objetoExpediente))
                {
                    CargarComboBoxExpedienteCredito();
                }
                else
                {
                    MessageBox.Show("No se pudo ligar el Expediente a la Operacion");

                }

            }
            private void GuardarExpediente()
            {
                int accion = 1;
                C_Expediente objetoExpediente = new C_Expediente();
                if (txt_NumExpediente.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese un Numero de Expediente");
                    return;
                }
                objetoExpediente.NumExpediente = txt_NumExpediente.Text;
                //
                if (cmb_Tipo_Proceso.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese un Tipo de Proceso");
                    return;
                }
                objetoExpediente.CodigoTipoProceso = Int32.Parse(cmb_Tipo_Proceso.SelectedValue.ToString());
                //
                if (cmb_Abogado.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese un Abogado");
                    return;
                }
                objetoExpediente.TrabajadorAbogado = Int32.Parse(cmb_Abogado.SelectedValue.ToString());
                //
                if (cmb_Responsable.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese un Responsable");
                    return;
                }
                objetoExpediente.TrabajadoResponsable = Int32.Parse(cmb_Responsable.SelectedValue.ToString());
                //
                if (txt_Secretario.Text == string.Empty)
                    objetoExpediente.TrabajadorSecretario = " ";
                objetoExpediente.TrabajadorSecretario = txt_Secretario.Text;
                //
                if (txt_NumExpediente22.Text == string.Empty)
                    objetoExpediente.NumExpediente22Digitos = " ";
                objetoExpediente.NumExpediente22Digitos = txt_NumExpediente22.Text;
                //
                if (cmb_Juzgado.Text == string.Empty)
                    objetoExpediente.Juzgado = " ";
                objetoExpediente.Juzgado = cmb_Juzgado.Text;
                //
                if (txt_codigoCautelar.Text == string.Empty)
                    objetoExpediente.CodigoCautelar = " ";
                objetoExpediente.CodigoCautelar = txt_codigoCautelar.Text;
                //
                if (cmb_NumJuzgado.Text == string.Empty)
                    objetoExpediente.NumJuzgado = " ";
                objetoExpediente.NumJuzgado = cmb_NumJuzgado.Text;
                //
                if (_bandera == true && txt_NumExpediente.Text != _operacionAntiguo)
                {
                    accion = 2;
                    objetoExpediente.NumExpediente = _operacionAntiguo;
                }
                //
                objetoExpediente.ExpedienteNuevo = txt_NumExpediente.Text;

                if (_ceriv.Expediente(accion, objetoExpediente))
                {
                    MessageBox.Show("Se Ingreso Corretamente el Expediente");
                    BloquearExpediente();
                    btn_GuardarExpediente.Enabled = false;
                    btn_ModificarExpediente.Enabled = true;
                    AuditoriaExpediente();
                    if (_bandera == true)
                    {
                        CargarComboBoxExpedienteCredito();
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo Ingresar Correctamente");
                }

            }
            public void BloquearExpediente()
            {
                txt_NumExpediente.Enabled = false;
                txt_NumExpediente22.Enabled = false;
                cmb_Responsable.Enabled = false;
                cmb_Abogado.Enabled = false;
                txt_Secretario.Enabled = false;
                cmb_Tipo_Proceso.Enabled = false;
                cmb_Juzgado.Enabled = false;
                cmb_Medida_Cautelar.Enabled = false;
                txt_codigoCautelar.Enabled = false;
                cmb_NumJuzgado.Enabled = false;
            }
            public void ActivarExpediente()
            {
                txt_NumExpediente.Enabled = true;
                txt_NumExpediente22.Enabled = true;
                cmb_Responsable.Enabled = true;
                cmb_Abogado.Enabled = true;
                txt_Secretario.Enabled = true;
                cmb_Tipo_Proceso.Enabled = true;
                cmb_Juzgado.Enabled = true;
                cmb_Medida_Cautelar.Enabled = true;
                txt_codigoCautelar.Enabled = true;
                cmb_NumJuzgado.Enabled = true;
            }
            public void limpiarExpediente()
            {
                cmb_ExpCredito.SelectedIndex = -1;
                txt_NumExpediente.Clear();
                txt_NumExpediente22.Clear();
                cmb_Responsable.SelectedIndex = -1;
                cmb_Abogado.SelectedIndex = -1;
                txt_Secretario.Clear();
                cmb_Tipo_Proceso.SelectedIndex = -1;
                cmb_Juzgado.SelectedIndex = -1;
                cmb_Juzgado.Text = "";
                txt_codigoCautelar.Clear();
                txt_codigoCautelar.Enabled = false;
                cmb_NumJuzgado.SelectedIndex = -1;
                cmb_NumJuzgado.Text = "";
                //cmb_OperacionExpediente.SelectedIndex = -1;
            }
            private void AbrirResponsable()
            {
                Trabajador obj = new Trabajador();
                obj.ShowDialog();
                CargarComboBoxResponsable();
            }
            private void AbrirAbogado()
            {
                Trabajador obj = new Trabajador();
                obj.ShowDialog();
                CargarComboBoxAbogado();
            }
            private void AbrirTipoProceso()
            {
                TipoProceso obj = new TipoProceso();
                obj.ShowDialog();
                CargarComboBoxProceso();

            }
            public void EliminarExpedienteCredito()
            {
                int accion = 1;
                C_Expediente objetoExpediente = new C_Expediente();
                if (cmb_ExpCredito.SelectedIndex != -1)
                {
                    objetoExpediente.NumExpediente = cmb_ExpCredito.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Seleccione un Expediente a Eliminar");
                }
                //
                if (cmb_OperacionExpediente.SelectedIndex != -1)
                {
                    objetoExpediente.Operacion = cmb_OperacionExpediente.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Seleccione una Operacion donde se Borrará el Expediente");
                }
                //
                if (_ceriv.ExpedienteCreditoEliminar(accion, objetoExpediente))
                {
                    MessageBox.Show("Se Borró Correctamente el Expediente de la Operacion");
                    limpiarExpediente();
                    CargarComboBoxExpedienteCredito();

                    btn_GuardarExpediente.Enabled = true;
                    btn_ModificarExpediente.Enabled = false;
                    _bandera = false;
                }
                else
                {
                    MessageBox.Show("No se pudo Borrar el Expediente de la Operacion");
                }
            }
            public void CargarOperacionExpediente()
            {
                cmb_OperacionExpediente.DisplayMember = "Operacion";
                cmb_OperacionExpediente.ValueMember = "Operacion";
                cmb_OperacionExpediente.DataSource = _ceriv.OperacionMostrar(txt_CuentaBT.Text);
            }

            //EVENTOS DEL EXPEDIENTE    

            private void cmb_OperacionExpediente_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_OperacionExpediente.SelectedIndex != -1)
                {
                    limpiarExpediente();
                    CargarComboBoxExpedienteCredito();
                }
            }            
            private void cmb_ExpCredito_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_ExpCredito.SelectedIndex != -1)
                {
                    C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpCredito.Text);
                    txt_NumExpediente.Text = objExpediente.NumExpediente;
                    txt_NumExpediente22.Text = objExpediente.NumExpediente22Digitos;
                    cmb_Juzgado.Text = objExpediente.Juzgado;
                    txt_Secretario.Text = objExpediente.TrabajadorSecretario;
                    cmb_Responsable.SelectedValue = objExpediente.TrabajadoResponsable;
                    cmb_Abogado.SelectedValue = objExpediente.TrabajadorAbogado;
                    cmb_Tipo_Proceso.SelectedValue = objExpediente.CodigoTipoProceso;
                    txt_codigoCautelar.Text = objExpediente.CodigoCautelar;
                    cmb_NumJuzgado.Text = objExpediente.NumJuzgado;
                    BloquearExpediente();
                    btn_ModificarExpediente.Enabled = true;
                    btn_GuardarExpediente.Enabled = false;
                }
                else
                {
                    ActivarExpediente();

                }
            }
            private void cmb_Tipo_Proceso_TextChanged(object sender, EventArgs e)
            {
                if (cmb_Tipo_Proceso.Text == "ODSA")
                {
                    cmb_Medida_Cautelar.Text = "SI";
                    txt_codigoCautelar.Enabled = true;
                }
                else
                {
                    cmb_Medida_Cautelar.Text = " ";
                    txt_codigoCautelar.Enabled = false;
                }
                //
               
            }
            private void cmb_Medida_Cautelar_TextChanged(object sender, EventArgs e)
            {
                if (cmb_Medida_Cautelar.Text == "NO")
                {
                    txt_codigoCautelar.Enabled = false;
                }
                if (cmb_Medida_Cautelar.Text == " ")
                {
                    txt_codigoCautelar.Enabled = false;
                }
                if (cmb_Medida_Cautelar.Text == "SI")
                {
                    txt_codigoCautelar.Enabled = true;
                }
            }
            private void cmb_TodoExpediente_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_ExpCredito.SelectedIndex == -1)
                {
                    if (cmb_TodoExpediente.SelectedIndex != -1)
                    {
                        C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_TodoExpediente.Text);
                        txt_NumExpediente.Text = objExpediente.NumExpediente;
                        txt_NumExpediente22.Text = objExpediente.NumExpediente22Digitos;
                        cmb_Juzgado.Text = objExpediente.Juzgado;
                        txt_Secretario.Text = objExpediente.TrabajadorSecretario;
                        cmb_Responsable.SelectedValue = objExpediente.TrabajadoResponsable;
                        cmb_Abogado.SelectedValue = objExpediente.TrabajadorAbogado;
                        cmb_Tipo_Proceso.SelectedValue = objExpediente.CodigoTipoProceso;
                        txt_codigoCautelar.Text = objExpediente.CodigoCautelar;
                        cmb_NumJuzgado.Text = objExpediente.NumJuzgado;
                        /*BloquearExpediente();
                        btn_ModificarExpediente.Enabled = true;
                        btn_GuardarExpediente.Enabled = false;*/
                    }
                    else
                    {
                        ActivarExpediente();

                    }
                }
            }

            // -------------------------------------------------
            //
            //        

        /*PROCESO*/
            
            //BOTONES DEL PROCESO
            private void btn_GuardarProceso_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    GuardarProceso();
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void btn_LimpiarProceso_Click(object sender, EventArgs e)
            {
                ActivarProceso();
                LimpiarProceso();
                btn_GuardarProceso.Enabled = true;
                btn_ModificarProceso.Enabled = false;
            }
            private void btn_MedidaCautelar_Click(object sender, EventArgs e)
            {
                if (PermisoAdministrador())
                {
                    AbrirFormaMedidaCautelar();
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }

            }
            private void btn_ModificarProceso_Click_1(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    ActivarProceso();
                  //  LimpiarProceso();
                    btn_GuardarProceso.Enabled = true;
                    btn_ModificarProceso.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void btn_Macro_Click(object sender, EventArgs e)
            {
                if (PermisoAdministrador())
                {
                    AbrirMacroEtapa();
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void btn_Micro_Click(object sender, EventArgs e)
            {
                if (PermisoAdministrador())
                {
                    AbrirMicroEtapa();
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }


            //FUNCIONES DEL PROCESO
            public void CargarProceso()
            {
                C_Proceso objProceso = _ceriv.ProcesoMostrar1(cmb_ExpedienteProceso.SelectedValue.ToString());
                //
                if (objProceso.CodigoMacro == -1)
                {
                    cmb_Macro.SelectedIndex = -1;
                }
                else
                {
                    cmb_Macro.SelectedValue = objProceso.CodigoMacro;
                }
                //
                if (objProceso.CodigoMicro == -1)
                {
                    cmb_Micro.SelectedIndex = -1;
                }
                else
                {
                    cmb_Micro.SelectedValue = objProceso.CodigoMicro;
                }
                /*
                if (objProceso.CodigoEtapa == -1)
                    cmb_EtapaProcesal.SelectedIndex = -1;
                else
                    cmb_EtapaProcesal.SelectedValue = objProceso.CodigoEtapa;
                */
                cmb_Tiempo.Text = objProceso.Tiempo;
                //
                if (objProceso.FechaEtapa == DateTime.Parse("01-01-1990"))
                {
                    dtp_FechaEtapa.CustomFormat = " ";
                    dtp_FechaEtapa.Format = DateTimePickerFormat.Custom;
                }
                else if (objProceso.FechaEtapa != DateTime.MinValue)
                {
                    dtp_FechaEtapa.Value = objProceso.FechaEtapa;
                }
                else
                {
                    dtp_FechaEtapa.Value = DateTime.Parse("01-01-1990");
                    dtp_FechaEtapa.CustomFormat = " ";
                    dtp_FechaEtapa.Format = DateTimePickerFormat.Custom;
                }
                //
                cmb_FMedCautelar.SelectedValue = objProceso.CodigoMedida;
                //
                if (objProceso.FechaInscripcion == DateTime.Parse("01-01-1990"))
                {
                    dtp_Inscripcion.CustomFormat = " ";
                    dtp_Inscripcion.Format = DateTimePickerFormat.Custom;
                }
                else if (objProceso.FechaInscripcion != DateTime.MinValue)
                {
                    dtp_Inscripcion.Value = objProceso.FechaInscripcion;
                }
                else
                {
                    dtp_Inscripcion.Value = DateTime.Parse("01-01-1990");
                    dtp_Inscripcion.CustomFormat = " ";
                    dtp_Inscripcion.Format = DateTimePickerFormat.Custom;
                }
                //
                txt_EstadoCautelar.Text = objProceso.EstadoCautelar;
                //
                if (objProceso.FechaMedidaCautelar == DateTime.Parse("01-01-1990"))
                {
                    dtp_MedidaCautelar.CustomFormat = " ";
                    dtp_MedidaCautelar.Format = DateTimePickerFormat.Custom;
                }
                else if (objProceso.FechaMedidaCautelar != DateTime.MinValue)
                {
                    dtp_MedidaCautelar.Value = objProceso.FechaMedidaCautelar;
                }
                else
                {
                    dtp_MedidaCautelar.Value = DateTime.Parse("01-01-1990");
                    dtp_MedidaCautelar.CustomFormat = " ";
                    dtp_MedidaCautelar.Format = DateTimePickerFormat.Custom;
                }
                //
                cmb_VigenciaMc.Text = objProceso.VigenciaMC;
                //
                if (objProceso.FechaActuadoCautelar == DateTime.Parse("01-01-1990"))
                {
                    dtp_ActuadoCautelar.CustomFormat = " ";
                    dtp_ActuadoCautelar.Format = DateTimePickerFormat.Custom;
                }
                else if (objProceso.FechaActuadoCautelar != DateTime.MinValue)
                {
                    dtp_ActuadoCautelar.Value = objProceso.FechaActuadoCautelar;
                }
                else
                {
                    dtp_ActuadoCautelar.Value = DateTime.Parse("01-01-1990");
                    dtp_ActuadoCautelar.CustomFormat = " ";
                    dtp_ActuadoCautelar.Format = DateTimePickerFormat.Custom;
                }
                //
                cmb_Devolucion.Text = objProceso.DevolucionCedula;
            }
            public void LimpiarProceso()
            {
                //cmb_EtapaProcesal.SelectedIndex = -1;
                cmb_Macro.SelectedIndex = -1;
                cmb_Micro.SelectedIndex = -1;
                cmb_Tiempo.Text = "";
                cmb_Tiempo.SelectedIndex = -1;
                cmb_FMedCautelar.SelectedIndex = -1;
                txt_EstadoCautelar.Clear();
                dtp_FechaEtapa.Value = DateTime.Parse("01-01-1990");
                dtp_FechaEtapa.CustomFormat = " ";
                dtp_FechaEtapa.Format = DateTimePickerFormat.Custom;
                dtp_Inscripcion.Value = DateTime.Parse("01-01-1990");
                dtp_Inscripcion.CustomFormat = " ";
                dtp_Inscripcion.Format = DateTimePickerFormat.Custom;
                dtp_MedidaCautelar.Value = DateTime.Parse("01-01-1990");
                dtp_MedidaCautelar.CustomFormat = " ";
                dtp_MedidaCautelar.Format = DateTimePickerFormat.Custom;
                dtp_ActuadoCautelar.Value = DateTime.Parse("01-01-1990");
                dtp_ActuadoCautelar.CustomFormat = " ";
                dtp_ActuadoCautelar.Format = DateTimePickerFormat.Custom;
                cmb_VigenciaMc.SelectedIndex = -1;
                cmb_Devolucion.SelectedIndex = -1;


            }
            public void GuardarProceso()
            {
                C_Proceso objetoProceso = new C_Proceso();
                //
                if (cmb_ExpedienteProceso.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Expediente para Asignar el Proceso");
                    return;
                }
                else
                {
                    objetoProceso.Num_expediente = cmb_ExpedienteProceso.SelectedValue.ToString();
                }
                //
                if (cmb_Macro.SelectedIndex == -1)
                    objetoProceso.CodigoMacro = -1;
                else
                    objetoProceso.CodigoMacro = Int32.Parse(cmb_Macro.SelectedValue.ToString());
                //
                if (cmb_Micro.SelectedIndex == -1)
                    objetoProceso.CodigoMicro = -1;
                else
                    objetoProceso.CodigoMicro = Int32.Parse(cmb_Micro.SelectedValue.ToString());
                /*
                if (cmb_EtapaProcesal.SelectedIndex == -1)
                    objetoProceso.CodigoEtapa = -1;
                else
                    objetoProceso.CodigoEtapa = Int32.Parse(cmb_EtapaProcesal.SelectedValue.ToString());
                */
                if (cmb_FMedCautelar.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese una Forma de Medida Cautelar");
                    return;
                }
                objetoProceso.CodigoMedida = Int32.Parse(cmb_FMedCautelar.SelectedValue.ToString());
                //
                if (cmb_Tiempo.Text == string.Empty)
                    objetoProceso.Tiempo = " ";
                objetoProceso.Tiempo = cmb_Tiempo.Text;
                //
                objetoProceso.FechaEtapa = dtp_FechaEtapa.Value.Date;
                //
                objetoProceso.FechaInscripcion = dtp_Inscripcion.Value.Date;
                //
                if (txt_EstadoCautelar.Text == string.Empty)
                    objetoProceso.EstadoCautelar = " ";
                objetoProceso.EstadoCautelar = txt_EstadoCautelar.Text;
                //
                objetoProceso.FechaMedidaCautelar = dtp_MedidaCautelar.Value.Date;
                //
                if (cmb_VigenciaMc.Text == "SI")
                    objetoProceso.VigenciaMC = "SI";
                if (cmb_VigenciaMc.Text == "NO")
                    objetoProceso.VigenciaMC = "NO";
                if (cmb_VigenciaMc.Text == string.Empty)
                {
                    MessageBox.Show("Seleccione si Tiene Vigencia de Medida Cautelar");
                    return;
                }
                //
                objetoProceso.FechaActuadoCautelar = dtp_ActuadoCautelar.Value.Date;
                //
                if (cmb_Devolucion.Text == "SI")
                    objetoProceso.DevolucionCedula = "SI";
                if (cmb_Devolucion.Text == "NO")
                    objetoProceso.DevolucionCedula = "NO";
                if (cmb_Devolucion.Text == string.Empty)
                {
                    MessageBox.Show("Seleccione si hay Devolucion de Cedula");
                    return;
                }
                //
                objetoProceso.Funcion = cmb_ExpedienteProceso.SelectedValue.ToString();
                if (_ceriv.ProcesoPrincipal(1, objetoProceso))
                {
                    MessageBox.Show("Se ingresaron los Datos de proceso Correctamente");
                    //lbl_Proceso.Text = "0";
                    BloquearProceso();
                    btn_GuardarProceso.Enabled = false;
                    btn_ModificarProceso.Enabled = true;
                    //AuditoriaProceso();
                }
                else
                {
                    MessageBox.Show("Revisar los Datos");
                }
            }
            public void CargarComboBoxMacro()
            {
                cmb_Macro.DisplayMember = "Nombre";
                cmb_Macro.ValueMember = "Codigo";
                cmb_Macro.DataSource = _ceriv.MacroEtapaMostrarTipoProceso(_codigoTipoProceso);
            }
            public void CargarComboBoxMicro()
            {

                if (cmb_Macro.SelectedItem != null)
                {
                    cmb_Micro.DataSource = null;
                    cmb_Micro.DisplayMember = "Nombre";
                    cmb_Micro.ValueMember = "Codigo";
                    int codigoMacro = int.Parse(cmb_Macro.SelectedValue.ToString());
                    cmb_Micro.DataSource = _ceriv.MicroMostrarByMacro(codigoMacro);
                }
            }
            public void CargarComboBoxEtapaProcesal()
            {
              /*cmb_EtapaProcesal.DisplayMember = "Nombre";
                cmb_EtapaProcesal.ValueMember = "Codigo";
                cmb_EtapaProcesal.DataSource = _ceriv.EtapaMostrar();*/
            }
            public void CargarComboBoxFormaMedidaCautelar()
            {
                cmb_FMedCautelar.DisplayMember = "Nombre";
                cmb_FMedCautelar.ValueMember = "Codigo";
                cmb_FMedCautelar.DataSource = _ceriv.FormaMedidaCautelarMostrar();
                
            }
            public void CargarComboBoxMacroEtapa()
            {
              /*  cmb_Macro.DisplayMember = "Nombre";
                cmb_Macro.ValueMember = "Codigo";
                if (cmb_Macro.SelectedItem != null)
                {
                    cmb_Micro.DataSource = null;
                    int codigoMacro = int.Parse(cmb_Macro.SelectedValue.ToString());
                    cmb_Micro.DataSource = _ceriv.MicroMostrarByMacro(codigoMacro);
                }*/

            }
            public void CargarComboBoxMicroEtapa() {

                /*cmb_Micro.DisplayMember = "Nombre";
                cmb_Micro.ValueMember = "Codigo";
                if (cmb_Macro.SelectedItem != null)
                {
                    cmb_Micro.DataSource = null;
                    int codigoMacro = int.Parse(cmb_Macro.SelectedValue.ToString());

                    cmb_Micro.DataSource = _ceriv.MicroMostrarByMacro(codigoMacro);
                }*/
                
            }
            private void AbrirFormaMedidaCautelar()
            {
                FormaMedidaCautelar obj = new FormaMedidaCautelar();
                obj.ShowDialog();
                CargarComboBoxFormaMedidaCautelar();
            }
            private void AbrirMacroEtapa() {
                MacroEtapa obj = new MacroEtapa();
                obj.ShowDialog();
                CargarComboBoxMacroEtapa();
            }
            private void AbrirMicroEtapa() {
                MicroEtapa obj = new MicroEtapa();
                obj.ShowDialog();
                CargarComboBoxMicroEtapa();
            }
            public void BloquearProceso()
            {
                cmb_Macro.Enabled = false;
                cmb_Micro.Enabled = false;
                //cmb_EtapaProcesal.Enabled = false;
                cmb_FMedCautelar.Enabled = false;
                cmb_Tiempo.Enabled = false;
                txt_EstadoCautelar.Enabled = false;
                dtp_FechaEtapa.Enabled = false;
                dtp_Inscripcion.Enabled = false;
                dtp_MedidaCautelar.Enabled = false;
                cmb_VigenciaMc.Enabled = false;
                dtp_ActuadoCautelar.Enabled = false;
                cmb_Devolucion.Enabled = false;
            }
            public void ActivarProceso()
            {
                cmb_Macro.Enabled = true;
                cmb_Micro.Enabled = true;
                cmb_FMedCautelar.Enabled = true;
                cmb_Tiempo.Enabled = true;
                txt_EstadoCautelar.Enabled = true;
                dtp_FechaEtapa.Enabled = true;
                dtp_Inscripcion.Enabled = true;
                dtp_MedidaCautelar.Enabled = true;
                cmb_VigenciaMc.Enabled = true;
                dtp_ActuadoCautelar.Enabled = true;
                cmb_Devolucion.Enabled = true;
               //cmb_EtapaProcesal.Enabled = true;

            }
            public void CargarTipoProceso()
            {
                if (cmb_ExpedienteProceso.SelectedIndex != -1)
                {
                    C_Expediente objetoExpediente = _ceriv.CargarTipoProcesoAProceso(cmb_ExpedienteProceso.Text);
                    _codigoTipoProceso = objetoExpediente.CodigoTipoProceso;
                    txt_ProcesoMuestraTipoProceso.Text = objetoExpediente.NombreTipoProceso;
                    CargarComboBoxMacro();
                }
                else
                {
                    txt_ProcesoMuestraTipoProceso.Text = "";
                }
            }
            public void CargarExpedienteProceso()
            {
                cmb_ExpedienteProceso.DisplayMember = "NumExpediente";
                cmb_ExpedienteProceso.ValueMember = "NumExpediente";
                cmb_ExpedienteProceso.DataSource = _ceriv.ExpedienteCreditoMostrar(cmb_OperacionProceso.SelectedValue.ToString());
            }
            public void CargarOperacionProceso()
            {
                cmb_OperacionProceso.DisplayMember = "Operacion";
                cmb_OperacionProceso.ValueMember = "Operacion";
                cmb_OperacionProceso.DataSource = _ceriv.OperacionMostrar(txt_CuentaBT.Text);
            }

            //EVENTOS DEL PROCESO

            private void cmb_ExpedienteProceso_SelectedIndexChanged(object sender, EventArgs e)
            {
                if(cmb_ExpedienteProceso.SelectedIndex != -1)
                {
                    CargarTipoProceso();
                    CargarProceso();
                    BloquearProceso();
                    btn_GuardarProceso.Enabled = false;
                    btn_ModificarProceso.Enabled = true;
                }
            }
            private void cmb_EtapaProcesal_SelectedIndexChanged(object sender, EventArgs e)
            {


            }
            private void txt_ProcesoMuestraTipoProceso_TextChanged(object sender, EventArgs e)
            {
                //CargarTipoProceso();
              //  cmb_Macro.DisplayMember = "Nombre";
              //  cmb_Macro.ValueMember = "Codigo";
              //  cmb_Macro.DataSource = _ceriv.MacroEtapaMostrarTipoProceso(_codigoTipoProceso);
                CargarComboBoxMacro();
            }
            private void cmb_OperacionProceso_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_OperacionProceso.SelectedIndex != -1)
                {
                    LimpiarProceso();
                    CargarExpedienteProceso();
                }
            }
            private void cmb_Macro_SelectedIndexChanged(object sender, EventArgs e)
            {
                CargarComboBoxMicro();
            }


            // -------------------------------------------------
            //
            //        

        /*FECHAS PROCESO*/

            //BOTONES DE FECHAS PROCESO
            private void btn_Guardar_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    GuardarFechas();
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void btn_Modificar_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    ActivarFecha();
                    btn_Guardar.Enabled = true;
                    btn_Modificar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void cmb_NuevoFechas_Click(object sender, EventArgs e)
            {
                ActivarFecha();
                LimpiarProceso();
                btn_Guardar.Enabled = true;
                btn_Modificar.Enabled = false;
                CargarModelo();
            }

            //FUNCIONES DE FECHAS PROCESO
            public void CargarModelo()
            {
                if (cmb_OperacionFechas.SelectedIndex != -1)
                {
                    C_Credito objetoCredito = _ceriv.CreditoMostrarModelo(cmb_OperacionFechas.SelectedValue.ToString());
                    txt_Modelito.Text = objetoCredito.NombreModelo;
                }
            }
            public void CargarFechas()
            {
                C_Fechas objFechas = _ceriv.FechasMostrar1(cmb_ExpedienteFechas.SelectedValue.ToString());
                //
                if (objFechas.FechaMando == DateTime.Parse("01-01-1990"))
                {
                    dtp_FechaMandato.CustomFormat = " ";
                    dtp_FechaMandato.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaMando != DateTime.MinValue)
                {
                    dtp_FechaMandato.Value = objFechas.FechaMando;
                }
                else
                {
                    dtp_FechaMandato.Value = DateTime.Parse("01-01-1990");
                    dtp_FechaMandato.CustomFormat = " ";
                    dtp_FechaMandato.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objFechas.FechaContradiccion == DateTime.Parse("01-01-1990"))
                {
                    dtp_Contradiccion.CustomFormat = " ";
                    dtp_Contradiccion.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaContradiccion != DateTime.MinValue)
                {
                    dtp_Contradiccion.Value = objFechas.FechaContradiccion;
                }
                else
                {
                    dtp_Contradiccion.Value = DateTime.Parse("01-01-1990");
                    dtp_Contradiccion.CustomFormat = " ";
                    dtp_Contradiccion.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objFechas.FechaOrden == DateTime.Parse("01-01-1990"))
                {
                    dtp_fechaOrden.CustomFormat = " ";
                    dtp_fechaOrden.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaOrden != DateTime.MinValue)
                {
                    dtp_fechaOrden.Value = objFechas.FechaOrden;
                }
                else
                {
                    dtp_fechaOrden.Value = DateTime.Parse("01-01-1990");
                    dtp_fechaOrden.CustomFormat = " ";
                    dtp_fechaOrden.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objFechas.FechaRematecaptura == DateTime.Parse("01-01-1990"))
                {
                    dtp_RemateCaptura.CustomFormat = " ";
                    dtp_RemateCaptura.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaRematecaptura != DateTime.MinValue)
                {
                    dtp_RemateCaptura.Value = objFechas.FechaRematecaptura;
                }
                else
                {
                    dtp_RemateCaptura.Value = DateTime.Parse("01-01-1990");
                    dtp_RemateCaptura.CustomFormat = " ";
                    dtp_RemateCaptura.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objFechas.FechaAdjucaptura == DateTime.Parse("01-01-1990"))
                {
                    dtp_AdjuCaptura.CustomFormat = " ";
                    dtp_AdjuCaptura.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaAdjucaptura != DateTime.MinValue)
                {
                    dtp_AdjuCaptura.Value = objFechas.FechaAdjucaptura;
                }
                else
                {
                    dtp_AdjuCaptura.Value = DateTime.Parse("01-01-1990");
                    dtp_AdjuCaptura.CustomFormat = " ";
                    dtp_AdjuCaptura.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objFechas.FechaDemanda == DateTime.Parse("01-01-1990"))
                {
                    dtp_FechaDemanda.CustomFormat = " ";
                    dtp_FechaDemanda.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaDemanda != DateTime.MinValue)
                {
                    dtp_FechaDemanda.Value = objFechas.FechaDemanda;
                }
                else
                {
                    dtp_FechaDemanda.Value = DateTime.Parse("01-01-1990");
                    dtp_FechaDemanda.CustomFormat = " ";
                    dtp_FechaDemanda.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objFechas.FechaAutoFinal == DateTime.Parse("01-01-1990"))
                {
                    dtp_FechaAutoFinal.CustomFormat = " ";
                    dtp_FechaAutoFinal.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaAutoFinal != DateTime.MinValue)
                {
                    dtp_FechaAutoFinal.Value = objFechas.FechaAutoFinal;
                }
                else
                {
                    dtp_FechaAutoFinal.Value = DateTime.Parse("01-01-1990");
                    dtp_FechaAutoFinal.CustomFormat = " ";
                    dtp_FechaAutoFinal.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objFechas.FechaApelacion == DateTime.Parse("01-01-1990"))
                {
                    dtp_Apelacion.CustomFormat = " ";
                    dtp_Apelacion.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaApelacion != DateTime.MinValue)
                {
                    dtp_Apelacion.Value = objFechas.FechaApelacion;
                }
                else
                {
                    dtp_Apelacion.Value = DateTime.Parse("01-01-1990");
                    dtp_Apelacion.CustomFormat = " ";
                    dtp_Apelacion.Format = DateTimePickerFormat.Custom;
                }
                //
            }
            public void GuardarFechas()
            {
                C_Fechas objetoFechas = new C_Fechas();
                //
                if (cmb_ExpedienteFechas.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Expediente");
                    return;
                }
                else
                {
                    objetoFechas.Num_Expediente = cmb_ExpedienteFechas.SelectedValue.ToString();
                }
                //
                objetoFechas.FechaMando = dtp_FechaMandato.Value;
                //
                objetoFechas.FechaContradiccion = dtp_Contradiccion.Value;
                //
                objetoFechas.FechaOrden = dtp_fechaOrden.Value;
                //
                objetoFechas.FechaRematecaptura = dtp_RemateCaptura.Value;
                //
                objetoFechas.FechaAdjucaptura = dtp_AdjuCaptura.Value;
                //
                objetoFechas.FechaDemanda = dtp_FechaDemanda.Value;
                //
                objetoFechas.FechaAutoFinal = dtp_FechaAutoFinal.Value;
                //
                objetoFechas.FechaApelacion = dtp_Apelacion.Value;
                //
                objetoFechas.Funcion = cmb_ExpedienteFechas.SelectedValue.ToString();
                if (_ceriv.Fechas(1, objetoFechas))
                {
                    MessageBox.Show("Las fechas se ingresaron correctamente.");
                    BloquearFecha();
                    btn_Guardar.Enabled = false;
                    btn_Modificar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se pudo Ingresar Las Fechas, Revise los Datos");
                    return;
                }
            }
            public void LimpiarFecha()
            {
                dtp_AdjuCaptura.Value = DateTime.Parse("01-01-1990");
                dtp_AdjuCaptura.CustomFormat = " ";
                dtp_AdjuCaptura.Format = DateTimePickerFormat.Custom;
                dtp_FechaMandato.Value = DateTime.Parse("01-01-1990");
                dtp_FechaMandato.CustomFormat = " ";
                dtp_FechaMandato.Format = DateTimePickerFormat.Custom;
                dtp_Contradiccion.Value = DateTime.Parse("01-01-1990");
                dtp_Contradiccion.CustomFormat = " ";
                dtp_Contradiccion.Format = DateTimePickerFormat.Custom;
                dtp_fechaOrden.Value = DateTime.Parse("01-01-1990");
                dtp_fechaOrden.CustomFormat = " ";
                dtp_fechaOrden.Format = DateTimePickerFormat.Custom;
                dtp_RemateCaptura.Value = DateTime.Parse("01-01-1990");
                dtp_RemateCaptura.CustomFormat = " ";
                dtp_RemateCaptura.Format = DateTimePickerFormat.Custom;
                dtp_FechaDemanda.Value = DateTime.Parse("01-01-1990");
                dtp_FechaDemanda.CustomFormat = " ";
                dtp_FechaDemanda.Format = DateTimePickerFormat.Custom;
                dtp_FechaAutoFinal.Value = DateTime.Parse("01-01-1990");
                dtp_FechaAutoFinal.CustomFormat = " ";
                dtp_FechaAutoFinal.Format = DateTimePickerFormat.Custom;
                dtp_Apelacion.Value = DateTime.Parse("01-01-1990");
                dtp_Apelacion.CustomFormat = " ";
                dtp_Apelacion.Format = DateTimePickerFormat.Custom;
                //lbl_fecha.Text = "0";
            }
            public void BloquearFecha()
            {
                dtp_AdjuCaptura.Enabled = false;
                dtp_FechaMandato.Enabled = false;
                dtp_Contradiccion.Enabled = false;
                dtp_fechaOrden.Enabled = false;
                dtp_RemateCaptura.Enabled = false;
                dtp_FechaDemanda.Enabled = false;
                dtp_FechaAutoFinal.Enabled = false;
                dtp_Apelacion.Enabled = false;
            }
            public void ActivarFecha()
            {
                dtp_AdjuCaptura.Enabled = true;
                dtp_FechaMandato.Enabled = true;
                dtp_Contradiccion.Enabled = true;
                dtp_fechaOrden.Enabled = true;
                dtp_RemateCaptura.Enabled = true;
                dtp_FechaDemanda.Enabled = true;
                dtp_FechaAutoFinal.Enabled = true;
                dtp_Apelacion.Enabled = true;
            }
            public void CargarExpedienteFechas()
            {
                cmb_ExpedienteFechas.DisplayMember = "NumExpediente";
                cmb_ExpedienteFechas.ValueMember = "NumExpediente";
                cmb_ExpedienteFechas.DataSource = _ceriv.ExpedienteCreditoMostrar(cmb_OperacionFechas.SelectedValue.ToString());
            }
            public void CargarOperacionFechas()
            {
                cmb_OperacionFechas.DisplayMember = "Operacion";
                cmb_OperacionFechas.ValueMember = "Operacion";
                cmb_OperacionFechas.DataSource = _ceriv.OperacionMostrar(txt_CuentaBT.Text);
            }

            //EVENTOS DE FECHAS PROCESO
            private void cmb_ExpedienteFechas_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_ExpedienteFechas.SelectedIndex != -1)
                {
                    CargarFechas();
                    BloquearFecha();
                    btn_Guardar.Enabled = false;
                    btn_Modificar.Enabled = true;
                }
            }
            private void txt_Modelito_TextChanged(object sender, EventArgs e)
            {
                if (txt_Modelito.Text == "MODELO A")
                {
                    lbl_fechaOrden.Text = "Fecha Orden de Remate";
                    lbl_RemateCaptura.Text = "Fecha de Remate";
                    lbl_AdjuCaptura.Text = "Fecha de Adjudicacion";
                    dtp_fechaOrden.Visible = true;
                    dtp_RemateCaptura.Visible = true;
                    dtp_AdjuCaptura.Visible = true;
                }
                else if (txt_Modelito.Text == "MODELO C")
                {
                    lbl_fechaOrden.Text = "Fecha de Orden de Incautacion";
                    lbl_RemateCaptura.Text = "Fecha de Orden de Captura";
                    lbl_AdjuCaptura.Text = "Fecha de Captura";
                    dtp_fechaOrden.Visible = true;
                    dtp_RemateCaptura.Visible = true;
                    dtp_AdjuCaptura.Visible = true;
                }
                else if (txt_Modelito.Text == "MODELO B")
                {
                    lbl_fechaOrden.Text = "";
                    lbl_RemateCaptura.Text = "";
                    lbl_AdjuCaptura.Text = "";
                    dtp_fechaOrden.Visible = false;
                    dtp_RemateCaptura.Visible = false;
                    dtp_AdjuCaptura.Visible = false;
                }
                else if (txt_Modelito.Text == "LEASING")
                {
                    lbl_fechaOrden.Text = "Fecha de Orden de Incautacion";
                    lbl_RemateCaptura.Text = "Fecha de Orden de Captura";
                    lbl_AdjuCaptura.Text = "Fecha de Captura";
                    dtp_fechaOrden.Visible = true;
                    dtp_RemateCaptura.Visible = true;
                    dtp_AdjuCaptura.Visible = true;
                }
            }
            private void cmb_OperacionFechas_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_OperacionFechas.SelectedIndex != -1)
                {
                    LimpiarFecha();
                    CargarModelo();
                    CargarExpedienteFechas();
                }
            }


            // -------------------------------------------------
            //
            //        

        /*BIEN*/

            //BOTONES DEL BIEN
            private void btn_GuardarBien_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    GuardarBien();
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void btn_ModificarBien_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    ActivarBien();
                    btn_ModificarBien.Enabled = false;
                    btn_GuardarBien.Enabled = true;
                    btn_EliminarBien.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void btn_EliminarBien_Click(object sender, EventArgs e)
            {
                EliminarBien();
                //LimpiarBien();
                btn_EliminarBien.Enabled = false;
                btn_ModificarBien.Enabled = false;
                btn_GuardarBien.Enabled = true;
            }
            private void btn_RangoHipoteca_Click_1(object sender, EventArgs e)
            {
                if (PermisoAdministrador())
                {
                    AbrirRangoHipoteca();
                }
                else
                {
                    MessageBox.Show("Permiso Denegado");
                }
            }
            private void btn_CiudadBien_Click(object sender, EventArgs e)
            {
                if (PermisoAdministrador())
                {
                    AbrirCiudad();
                }
                else
                {
                    MessageBox.Show("Permiso Denegado");
                }
            }
            private void btn_DistritoBien_Click(object sender, EventArgs e)
            {
                if (PermisoAdministrador())
                {
                    AbrirDistrito();
                }
                else
                {
                    MessageBox.Show("Permiso Denegado");
                }
            }

            //FUNCIONES DEL BIEN

            public void CargarDataGridViewBien()
            {
                dgv_bien.AutoGenerateColumns = false;
                dgv_bien.DataSource = _ceriv.BienDGV(cmb_ExpedienteBien.SelectedValue.ToString());
            }
            public void CargarComboBoxTipoBien()
            {
                cmb_TipoBien.DisplayMember = "Nombre";
                cmb_TipoBien.ValueMember = "Codigo";
                cmb_TipoBien.DataSource = _ceriv.TipoBienMostrar();
            }
            public void CargarMonto()
            {
                if (cmb_Operacion.SelectedIndex != -1)
                {
                    C_Bien objetoBien = _ceriv.CargarMontoAdmitido(cmb_OperacionBien.SelectedValue.ToString());
                    txt_MontoDemandado.Text = objetoBien.MontoDemandado;
                }
                else
                {
                    txt_MontoDemandado.Text = " ";
                }
            }
            public void GuardarBien()
            {
                C_Bien objetoBien = new C_Bien();
                //
                if (cmb_ExpedienteBien.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Expediente para Ingresar el Bien");
                    return;
                }
                objetoBien.Num_expediente = cmb_ExpedienteBien.SelectedValue.ToString();
                //
                if (cmb_TipoBien.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese un Tipo de Bien");
                    return;
                }
                objetoBien.TipoBien = Int32.Parse(cmb_TipoBien.SelectedValue.ToString());
                //
                if (cmb_Rango_Hipoteca.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese un Rango de Hipoteca");
                    return;
                }
                objetoBien.CodigoRango = Int32.Parse(cmb_Rango_Hipoteca.SelectedValue.ToString());
                //
                if (txt_NombreTipoBien.Text == string.Empty)
                    objetoBien.NombreBien = " ";
                objetoBien.NombreBien = txt_NombreTipoBien.Text;
                //
                if (txt_MontoGarantia.Text == string.Empty)
                    objetoBien.MontoGarantia = " ";
                objetoBien.MontoGarantia = txt_MontoGarantia.Text;
                //
                if (txt_Monto_Tasacion.Text == string.Empty)
                    objetoBien.MontoTasacion = " ";
                objetoBien.MontoTasacion = txt_Monto_Tasacion.Text;
                //
                objetoBien.FechaTasacion = dtp_Tasacion.Value.Date;
                //
                if (txt_Placa.Text == string.Empty)
                    objetoBien.PartidaPlaca = " ";
                objetoBien.PartidaPlaca = txt_Placa.Text;
                //
                if (txt_Porcentaje_Embargo.Text == string.Empty)
                    objetoBien.PorcentajeDerechos = " ";
                objetoBien.PorcentajeDerechos = txt_Porcentaje_Embargo.Text;
                //
                if (txt_DescripcionBien.Text == string.Empty)
                    objetoBien.Descripcion = " ";
                objetoBien.Descripcion = txt_DescripcionBien.Text;
                //            
                if (txt_ValorComercial.Text == string.Empty)
                    objetoBien.ValorComercial = " ";
                objetoBien.ValorComercial = txt_ValorComercial.Text;
                //
                if (cmb_CiudadBien.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione una Ciudad del Bien");
                    return;
                }
                else
                {
                    objetoBien.Codigo_ciudad = Int32.Parse(cmb_CiudadBien.SelectedValue.ToString());
                }
                //
                if (cmb_DistritoBien.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Distrito del Bien");
                    return;
                }
                else
                {
                    objetoBien.Codigo_distrito = Int32.Parse(cmb_DistritoBien.SelectedValue.ToString());
                }
                //
                if (txt_ModeloBien.Text == string.Empty)
                    objetoBien.Modelo = " ";
                objetoBien.Modelo = txt_ModeloBien.Text;
                //
                if (txt_MarcaBien.Text == string.Empty)
                    objetoBien.Marca = " ";
                objetoBien.Marca = txt_MarcaBien.Text;
                //
                objetoBien.Codigo = Int32.Parse(lbl_codigo.Text);
                if (_ceriv.Bien(1, objetoBien))
                {
                    MessageBox.Show("Se ingresaron correctamente los datos del Bien");
                    LimpiarBien();
                    CargarDataGridViewBien();
                    AuditoriaBien();
                }
                else
                {
                    MessageBox.Show("No se pudieron Ingresar los Datos Correctamente");
                }
            }
            public void EliminarBien()
            {
                C_Bien objetoBien = new C_Bien();
                objetoBien.Codigo = Int32.Parse(lbl_codigo.Text);
                if (objetoBien.Codigo != 0)
                {
                    if (_ceriv.BienEliminar(1, objetoBien))
                    {
                        MessageBox.Show("Se elimino el Bien Correctamente");
                        LimpiarBien();
                        CargarDataGridViewBien();
                        ActivarBien();
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo Eliminar el Bien");
                }
            }
            public void LimpiarBien()
            {
                cmb_TipoBien.SelectedIndex = -1;
                cmb_Rango_Hipoteca.SelectedIndex = -1;
                txt_NombreTipoBien.Clear();
                txt_Placa.Clear();
                txt_MontoGarantia.Clear();
                txt_Monto_Tasacion.Clear();
                dtp_Tasacion.Value = DateTime.Parse("01-01-1990");
                dtp_Tasacion.CustomFormat = " ";
                dtp_Tasacion.Format = DateTimePickerFormat.Custom;
                txt_Porcentaje_Embargo.Clear();
                txt_DescripcionBien.Clear();
                lbl_codigo.Text = "0";
                txt_ValorComercial.Clear();
                cmb_CiudadBien.SelectedIndex = -1;
                cmb_DistritoBien.SelectedIndex = -1;
                txt_MarcaBien.Clear();
                txt_ModeloBien.Clear();

            }
            public void ActivarBien()
            {
                cmb_TipoBien.Enabled = true;
                cmb_Rango_Hipoteca.Enabled = true;
                txt_NombreTipoBien.Enabled = true;
                txt_Placa.Enabled = true;
                txt_MontoGarantia.Enabled = true;
                txt_Monto_Tasacion.Enabled = true;
                dtp_Tasacion.Enabled = true;
                txt_Porcentaje_Embargo.Enabled = true;
                txt_DescripcionBien.Enabled = true;
                txt_ValorComercial.Enabled = true;
                cmb_CiudadBien.Enabled = true;
                cmb_DistritoBien.Enabled = true;
                txt_MarcaBien.Enabled = true;
                txt_ModeloBien.Enabled = true;

            }
            public void BloquearBien()
            {
                cmb_TipoBien.Enabled = false;
                cmb_Rango_Hipoteca.Enabled = false;
                txt_NombreTipoBien.Enabled = false;
                txt_MontoDemandado.Enabled = false;
                txt_Placa.Enabled = false;
                txt_MontoGarantia.Enabled = false;
                txt_Monto_Tasacion.Enabled = false;
                dtp_Tasacion.Enabled = false;
                txt_Porcentaje_Embargo.Enabled = false;
                txt_DescripcionBien.Enabled = false;
                txt_ValorComercial.Enabled = false;
                cmb_CiudadBien.Enabled = false;
                cmb_DistritoBien.Enabled = false;
                txt_MarcaBien.Enabled = false;
                txt_ModeloBien.Enabled = false;
            }
            private void AbrirRangoHipoteca()
            {
                RangoHipoteca obj = new RangoHipoteca();
                obj.ShowDialog();
                CargarComboBoxRangoHipotecado();
            }
            public void CargarOperacionBien()
            {
                cmb_OperacionBien.DisplayMember = "Operacion";
                cmb_OperacionBien.ValueMember = "Operacion";
                cmb_OperacionBien.DataSource = _ceriv.OperacionMostrar(txt_CuentaBT.Text);
            }
            public void CargarExpedienteBien()
            {

                cmb_ExpedienteBien.DisplayMember = "NumExpediente";
                cmb_ExpedienteBien.ValueMember = "NumExpediente";
                cmb_ExpedienteBien.DataSource = _ceriv.ExpedienteCreditoMostrar(cmb_OperacionBien.SelectedValue.ToString());

            }

            //EVENTOS DEL BIEN

            private void cmb_ExpedienteBien_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_ExpedienteBien.SelectedIndex != -1)
                {
                    ActivarBien();
                    LimpiarBien();
                    btn_GuardarBien.Enabled = true;
                    btn_ModificarBien.Enabled = false;
                    btn_EliminarBien.Enabled = false;
                    CargarDataGridViewBien();
                }
            }
            private void dgv_bien_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (cmb_ExpedienteBien.SelectedIndex != -1)
                {
                    int row = e.RowIndex;
                    if (e.RowIndex > -1)
                    {
                        cmb_TipoBien.SelectedValue = Int32.Parse(dgv_bien.Rows[row].Cells["cdgTB"].Value.ToString());
                        cmb_Rango_Hipoteca.SelectedValue = Int32.Parse(dgv_bien.Rows[row].Cells["cdgR"].Value.ToString());
                        txt_NombreTipoBien.Text = dgv_bien.Rows[row].Cells["NombreBien"].Value.ToString();
                        txt_MontoGarantia.Text = dgv_bien.Rows[row].Cells["MontoGarantia"].Value.ToString();
                        txt_Monto_Tasacion.Text = dgv_bien.Rows[row].Cells["MontoTasacion"].Value.ToString();
                        dtp_Tasacion.Text = dgv_bien.Rows[row].Cells["FECHATASACIONDATE"].Value.ToString();
                        txt_Placa.Text = dgv_bien.Rows[row].Cells["PartidaPlaca"].Value.ToString();
                        txt_Porcentaje_Embargo.Text = dgv_bien.Rows[row].Cells["PorcentajeDerechos"].Value.ToString();
                        txt_DescripcionBien.Text = dgv_bien.Rows[row].Cells["Descripcion"].Value.ToString();
                        lbl_codigo.Text = dgv_bien.Rows[row].Cells["Codigo"].Value.ToString();
                        txt_ValorComercial.Text = dgv_bien.Rows[row].Cells["ValorComercial"].Value.ToString();
                        cmb_CiudadBien.Text = dgv_bien.Rows[row].Cells["Ciudad"].Value.ToString();
                        cmb_DistritoBien.Text = dgv_bien.Rows[row].Cells["Distrito"].Value.ToString();
                        txt_MarcaBien.Text = dgv_bien.Rows[row].Cells["Marca"].Value.ToString();
                        txt_ModeloBien.Text = dgv_bien.Rows[row].Cells["Modelo"].Value.ToString();
                        btn_ModificarBien.Enabled = true;
                        btn_GuardarBien.Enabled = false;
                        btn_EliminarBien.Enabled = true;
                        BloquearBien();
                    }
                }
            }
            private void cmb_OperacionBien_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_OperacionBien.SelectedIndex != -1)
                {
                    dgv_bien.DataSource = null;
                    cmb_ExpedienteBien.SelectedIndex = -1;
                    cmb_ExpedienteBien.Text = "";
                    LimpiarBien();
                    ActivarBien();
                    btn_GuardarBien.Enabled = true;
                    btn_ModificarBien.Enabled = false;
                    btn_EliminarBien.Enabled = false;
                    CargarMonto();
                    CargarExpedienteBien();
                }

            }

            // -------------------------------------------------
            //
            //        


        /*OTRAS CARGAS DEL BIEN*/

            //BOTONES DE OTRAS CARGAS

            private void btn_GuardarOtrasCargas_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    GuardarOtrasCargas();
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void btn_ModificarOtrasCargas_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    ActivarOtrasCargas();
                    btn_ModificarOtrasCargas.Enabled = false;
                    btn_GuardarOtrasCargas.Enabled = true;
                    btn_EliminarOtrasCargas.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void btn_EliminarOtrasCargas_Click(object sender, EventArgs e)
            {

                if (PermisoAdministradorAbogado())
                {
                    EliminarOtrasCargas();
                    btn_EliminarOtrasCargas.Enabled = false;
                    btn_ModificarOtrasCargas.Enabled = false;
                    btn_GuardarOtrasCargas.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }


            //FUNCIONES DE OTRAS CARGAS

            public void CargarDataGridViewOtrasCargas()            
            {
                if (cmb_BienOtrasCargas.SelectedIndex != -1)
                {
                    dgv_OtrasCargas.AutoGenerateColumns = false;
                    dgv_OtrasCargas.DataSource = _ceriv.OtrasCargasDGV(Int32.Parse(cmb_BienOtrasCargas.SelectedValue.ToString()));
                }
                else
                {
                    dgv_OtrasCargas.DataSource = null;
                    cmb_BienOtrasCargas.Text = "";
                    txt_DescripcionOtrasCargas.Clear();
                }
            }
            public void CargarComboBoxBien()
            {
                if (cmb_ExpedienteOtrasCargas.SelectedIndex != -1)
                {
                    cmb_BienOtrasCargas.DisplayMember = "NombreBien";
                    cmb_BienOtrasCargas.ValueMember = "Codigo";
                    cmb_BienOtrasCargas.DataSource = _ceriv.BienMostrar(cmb_ExpedienteOtrasCargas.SelectedValue.ToString());
                }
                else if(cmb_ExpedienteOtrasCargas.SelectedIndex == -1)
                {
                    cmb_BienOtrasCargas.DisplayMember = "NombreBien";
                    cmb_BienOtrasCargas.ValueMember = "Codigo";
                    cmb_BienOtrasCargas.DataSource = _ceriv.BienMostrar("0");
                }
            }
            public void GuardarOtrasCargas()
            {
                C_OtrasCargas objetoOtrasCargas = new C_OtrasCargas();
                if (cmb_BienOtrasCargas.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese un Bien");
                    return;
                }
                objetoOtrasCargas.CodigoBien = Int32.Parse(cmb_BienOtrasCargas.SelectedValue.ToString());
                //
                if (txt_DescripcionOtrasCargas.Text == string.Empty)
                    objetoOtrasCargas.DescripcionBien = " ";
                objetoOtrasCargas.DescripcionBien = txt_DescripcionOtrasCargas.Text;
                //
                if (txt_Acreedor.Text == string.Empty)
                    objetoOtrasCargas.Acreedor = " ";
                objetoOtrasCargas.Acreedor = txt_Acreedor.Text;
                //
                if (txt_RangoDatos.Text == string.Empty)
                    objetoOtrasCargas.Rango = " ";
                objetoOtrasCargas.Rango = txt_RangoDatos.Text;
                //
                if (txt_MontoGaEmbargo.Text == string.Empty)
                    objetoOtrasCargas.MontoGarantia = " ";
                objetoOtrasCargas.MontoGarantia = txt_MontoGaEmbargo.Text;
                //
                if (txt_MontoAdeudado.Text == string.Empty)
                    objetoOtrasCargas.MontoAdeudado = " ";
                objetoOtrasCargas.MontoAdeudado = txt_MontoAdeudado.Text;
                //
                objetoOtrasCargas.Codigo = Int32.Parse(lbl_otrascargas.Text);
                if (_ceriv.OtrasCargas(1, objetoOtrasCargas))
                {
                    MessageBox.Show("Se ingreso Correctamente Otra Carga al Bien");
                    LimpiarOtrasCargas();
                    btn_ModificarOtrasCargas.Enabled = false;
                    CargarDataGridViewOtrasCargas();
                    AuditoriaOtrasCargas();
                }
                else
                {
                    MessageBox.Show("Revise los Datos");
                }
            }
            public void EliminarOtrasCargas()
            {
                C_OtrasCargas objetoOtrasCargas = new C_OtrasCargas();
                objetoOtrasCargas.Codigo = Int32.Parse(lbl_otrascargas.Text);
                if (objetoOtrasCargas.Codigo != 0)
                {
                    if (_ceriv.OtrasCargasEliminar(1, objetoOtrasCargas))
                    {
                        MessageBox.Show("Se Elimino Otras Cargas del Bien Correctamente");
                        LimpiarOtrasCargas();
                        CargarDataGridViewOtrasCargas();
                        ActivarOtrasCargas();
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo Eliminar Otras Cargas del Bien");
                }

            }
            public void LimpiarOtrasCargas()
            {
                //cmb_BienOtrasCargas.SelectedIndex = -1;
                txt_DescripcionBien.Clear();
                lbl_otrascargas.Text = "0";
                txt_Acreedor.Clear();
                txt_RangoDatos.Clear();
                txt_MontoGaEmbargo.Clear();
                txt_MontoAdeudado.Clear();

            }
            public void bloquearOtrasCargas()
            {
                cmb_BienOtrasCargas.Enabled = false;
                txt_DescripcionBien.Enabled = false;

                txt_Acreedor.Enabled = false;
                txt_RangoDatos.Enabled = false;
                txt_MontoGaEmbargo.Enabled = false;
                txt_MontoAdeudado.Enabled = false;
            }
            public void ActivarOtrasCargas()
            {
                cmb_BienOtrasCargas.Enabled = true;
                txt_DescripcionBien.Enabled = true;
                txt_Acreedor.Enabled = true;
                txt_RangoDatos.Enabled = true;
                txt_MontoGaEmbargo.Enabled = true;
                txt_MontoAdeudado.Enabled = true;
            }
            public void CargarOperacionOtrasCargas()
            {
                cmb_OperacionOtrasCargas.DisplayMember = "Operacion";
                cmb_OperacionOtrasCargas.ValueMember = "Operacion";
                cmb_OperacionOtrasCargas.DataSource = _ceriv.OperacionMostrar(txt_CuentaBT.Text);
            }
            public void CargarExpedienteOtrasCargas()
            {
                cmb_ExpedienteOtrasCargas.DisplayMember = "NumExpediente";
                cmb_ExpedienteOtrasCargas.ValueMember = "NumExpediente";
                cmb_ExpedienteOtrasCargas.DataSource = _ceriv.ExpedienteCreditoMostrar(cmb_OperacionOtrasCargas.SelectedValue.ToString());                
            }

            //EVENTOS DE OTRAS CARGAS

            private void cmb_ExpedienteOtrasCargas_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_ExpedienteOtrasCargas.SelectedIndex != -1)
                {
                    ActivarOtrasCargas();
                    LimpiarOtrasCargas();
                    btn_GuardarOtrasCargas.Enabled = true;
                    btn_ModificarOtrasCargas.Enabled = false;
                    btn_EliminarOtrasCargas.Enabled = false;
                    CargarComboBoxBien();
                    CargarDataGridViewOtrasCargas();
                }
            }
            private void cmb_BienOtrasCargas_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_BienOtrasCargas.SelectedIndex != -1)
                {
                    C_OtrasCargas obj = _ceriv.OtrasCargasMostrar1(Int32.Parse(cmb_BienOtrasCargas.SelectedValue.ToString()));
                    txt_DescripcionOtrasCargas.Text = obj.DescripcionBien;
                    CargarDataGridViewOtrasCargas();
                    LimpiarOtrasCargas();
                }
            }
            private void dgv_OtrasCargas_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (cmb_ExpedienteOtrasCargas.SelectedIndex != -1)
                {
                    int row = e.RowIndex;
                    if (e.RowIndex > -1)
                    {
                        if (cmb_BienOtrasCargas.SelectedIndex != -1)
                        {
                            cmb_BienOtrasCargas.SelectedValue = Int32.Parse(dgv_OtrasCargas.Rows[row].Cells["CodigoBien"].Value.ToString());
                            txt_DescripcionOtrasCargas.Text = dgv_OtrasCargas.Rows[row].Cells["DescripcionAntigua"].Value.ToString();
                            lbl_otrascargas.Text = dgv_OtrasCargas.Rows[row].Cells["cdg"].Value.ToString();
                            txt_Acreedor.Text = dgv_OtrasCargas.Rows[row].Cells["Acreedor"].Value.ToString();
                            txt_RangoDatos.Text = dgv_OtrasCargas.Rows[row].Cells["RangoAcreedor"].Value.ToString();
                            txt_MontoGaEmbargo.Text = dgv_OtrasCargas.Rows[row].Cells["MontoEmbargoAcreedo"].Value.ToString();
                            txt_MontoAdeudado.Text = dgv_OtrasCargas.Rows[row].Cells["MontoAdeudado"].Value.ToString();
                            bloquearOtrasCargas();
                            btn_GuardarOtrasCargas.Enabled = false;
                            btn_ModificarOtrasCargas.Enabled = true;
                            btn_EliminarOtrasCargas.Enabled = true;
                        }
                    }
                }
            }
            private void cmb_OperacionOtrasCargas_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_OperacionOtrasCargas.SelectedIndex != -1)
                {
                    dgv_OtrasCargas.DataSource = null;
                    cmb_ExpedienteOtrasCargas.SelectedIndex = -1;
                    cmb_ExpedienteOtrasCargas.Text = "";
                    cmb_BienOtrasCargas.SelectedIndex = -1;
                    cmb_BienOtrasCargas.Text = "";
                    txt_DescripcionOtrasCargas.Clear();
                    LimpiarOtrasCargas();
                    ActivarOtrasCargas();
                    btn_GuardarOtrasCargas.Enabled = true;
                    btn_ModificarOtrasCargas.Enabled = false;
                    btn_EliminarOtrasCargas.Enabled = false;
                    CargarExpedienteOtrasCargas();
                    CargarComboBoxBien();
                }

            }

            // -------------------------------------------------
            //
            //        

        /*SEGUIMIENTO DEL PROCESO*/

            //BOTONES DEL SEGUIMIENTO DEL PROCESO

            private void btn_Modificar_Seguimiento_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    ActivarSeguimiento();
                    btn_Guardar_Seguimiento.Enabled = true;
                    btn_Modificar_Seguimiento.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void Btn_EstadoProcesal_Click(object sender, EventArgs e)
            {
                if (PermisoAdministrador())
                {
                    AbrirEstadoProcesal();
                }
                else
                {
                    MessageBox.Show("Permiso Denegado");
                }
            }
            private void btn_Guardar_Seguimiento_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    GuardarSeguimientoProceso();
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }

            //FUNCIONES DEL SEGUIMIENTO DEL PROCESO

            public void AbrirConexionExpediente() 
            {
                //SE ABRE UNA VENTANA PARA ACTUALIZAR LA MACRO ETAPA Y MICRO ETAPA SEGUN SEA NECESARIO
                string _textoExpediente = cmb_ExpedienteSeguimiento.Text;
                F_Seguimiento obj1 = new F_Seguimiento(_textoExpediente);
                obj1.ShowDialog();
            }
            public void CargarComboBoxUltimoEstadoProcesal()
            {
                cmb_UltimoEstadoProcesal.DisplayMember = "Nombre";
                cmb_UltimoEstadoProcesal.ValueMember = "Codigo";
                cmb_UltimoEstadoProcesal.DataSource = _ceriv.EstadoProcesalMostrar();
            }
            public void CargarEstadoProcesalVersionMostrarMicro() 
            {
                cmb_UltimoEstadoProcesal.DisplayMember = "Nombre";
                cmb_UltimoEstadoProcesal.ValueMember = "Codigo";
                cmb_UltimoEstadoProcesal.DataSource = _ceriv.EstadoProcesalMostarComoMicro(cmb_ExpedienteSeguimiento.Text);
                cmb_UltimoEstadoProcesal.SelectedIndex = -1;

            }
            public void GuardarReporteSeguimiento()
            {
                C_ReporteSeguimiento objetoReporteSeguimiento = new C_ReporteSeguimiento();
                //EXPEDIENTE
                if (cmb_ExpedienteSeguimiento.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Expediente Para ingresar los Datos del Seguimiento");
                    return;
                }
                objetoReporteSeguimiento.Num_Expediente1 = cmb_ExpedienteSeguimiento.SelectedValue.ToString();

                //ESTADO PROCESAL
                if (cmb_UltimoEstadoProcesal.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese un Estado Procesal");
                    return;
                }
                objetoReporteSeguimiento.EstadoProcesal = cmb_UltimoEstadoProcesal.Text;

                //FECHA ESTADO PROCESAL
                objetoReporteSeguimiento.Fecha_EstadoProcesal = dtp_Fecha_Procesal.Value;
                
                //TAREA JUDICIAL
                if (txt_UltTarJudicial.Text == string.Empty)
                {
                    objetoReporteSeguimiento.Tarea_Judicial = " ";
                }
                else
                {
                    objetoReporteSeguimiento.Tarea_Judicial = txt_UltTarJudicial.Text;
                }

                //FECHA TAREA ADMINISTRATIVA
                objetoReporteSeguimiento.Fecha_TarejaAdministrativa = dtp_Tarea_Administrativa.Value;

                //TAREA ADMINISTRATIVA
                if (txt_UltTarAdministrativa.Text == string.Empty)
                {
                    objetoReporteSeguimiento.TareaAdministrativa = " ";
                }
                else
                {
                    objetoReporteSeguimiento.TareaAdministrativa = txt_UltTarAdministrativa.Text;
                }

                //INCIDENCIA
                if (txt_Incidencia.Text == string.Empty)
                {
                    objetoReporteSeguimiento.Incidencia = " ";
                }
                else
                {
                    objetoReporteSeguimiento.Incidencia = txt_Incidencia.Text;
                }

                //DETALLE INCIDENCIA
                if (txt_DetalleIncidencia.Text == string.Empty)
                {
                    objetoReporteSeguimiento.DetalleIncidencia = " ";
                }
                else
                {
                    objetoReporteSeguimiento.DetalleIncidencia = txt_DetalleIncidencia.Text;
                }
                if (_ceriv.ReporteSeguimiento(1, objetoReporteSeguimiento))
                {
                    //MessageBox.Show("")
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el Seguimiento como Ultimo, Anotar el Error");
                }
            }
            public void GuardarSeguimientoProceso()
            {
                C_SeguimientoProceso objetoSeguimiento = new C_SeguimientoProceso();
                //EXPEDIENTE
                if (cmb_ExpedienteSeguimiento.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Expediente Para ingresar los Datos del Seguimiento");
                    return;
                }
                objetoSeguimiento.Num_expediente = cmb_ExpedienteSeguimiento.SelectedValue.ToString();
                //ESTADO PROCESAL
                if (cmb_UltimoEstadoProcesal.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese un Estado Procesal");
                    return;
                }
                objetoSeguimiento.EstadoProcesal = Int32.Parse(cmb_UltimoEstadoProcesal.SelectedValue.ToString());
                //FECHA ESTADO PROCESAL
                objetoSeguimiento.FechaEstadoProcesal = dtp_Fecha_Procesal.Value;
                //
                if (txt_UltTarJudicial.Text == string.Empty)
                {
                    objetoSeguimiento.TareaJudicial = " ";
                }
                else
                {
                    objetoSeguimiento.TareaJudicial = txt_UltTarJudicial.Text;
                }
                //
                objetoSeguimiento.FechaTareaAdministrativa = dtp_Tarea_Administrativa.Value;
                //
                if (txt_UltTarAdministrativa.Text == string.Empty)
                {
                    objetoSeguimiento.TareaAdministrativa = " ";
                }
                else
                {
                    objetoSeguimiento.TareaAdministrativa = txt_UltTarAdministrativa.Text;
                }
                //
                if (chk_ETJ.Checked == true)
                {
                    objetoSeguimiento.EstadoTareaJudicial = 1;
                }
                else if (chk_ETJ.Checked == false)
                {
                    objetoSeguimiento.EstadoTareaJudicial = 0;
                }
                //
                if (chk_ETA.Checked == true)
                {
                    objetoSeguimiento.EstadoTareaAdministrativa = 1;
                }
                else if (chk_ETA.Checked == false)
                {
                    objetoSeguimiento.EstadoTareaAdministrativa = 0;
                }
                //
                if (chk_Convenio.Checked == true)
                {
                    objetoSeguimiento.Convenio = "SI";
                }
                else
                {
                    objetoSeguimiento.Convenio = "NO";
                }
                //
                if (txt_DetalleIncidencia.Text == string.Empty)
                {
                    objetoSeguimiento.DetalleIncidencia = " ";
                }
                else
                {
                    objetoSeguimiento.DetalleIncidencia = txt_DetalleIncidencia.Text;
                }
                //
                if (txt_Incidencia.Text == string.Empty)
                {
                    objetoSeguimiento.Incidencia = " ";
                }
                else
                {
                    objetoSeguimiento.Incidencia = txt_Incidencia.Text;
                }
                //
                if (txt_DetalleConvenio.Text == string.Empty)
                {
                    objetoSeguimiento.DetalleConvenio = " ";
                }
                else
                {
                    objetoSeguimiento.DetalleConvenio = txt_DetalleConvenio.Text;
                }
                //
                objetoSeguimiento.Codigo = Int32.Parse(lbl_seguimiento.Text);
                if (_ceriv.SeguimientoProceso(1, objetoSeguimiento))
                {
                    if (MessageBox.Show("¿Desea Ingresar el Seguimiento como Ultimo Seguimiento Procesal?", "SEGUIMIENTO PROCESAL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        GuardarReporteSeguimiento();
                        //MessageBox.Show("JAJA LMAO");
                    }
                    MessageBox.Show("Se Ingreso el Seguimiento Procesal");
                    AuditoriaSeguimientoProceso();
                    CargarDataGridView();
                    ActualizarHistoricoTexto();
                    AbrirConexionExpediente();
                    LimpiarSeguimientoProceso();
                }
                else
                {
                    MessageBox.Show("No se pudo Ingresar El Seguimiento, Revise los Datos Por Favor");
                }
            }
            public void LimpiarSeguimientoProceso()
            {
                cmb_UltimoEstadoProcesal.SelectedIndex = -1;
                dtp_Fecha_Procesal.Value = DateTime.Parse("01-01-1990");
                dtp_Fecha_Procesal.CustomFormat = " ";
                dtp_Fecha_Procesal.Format = DateTimePickerFormat.Custom;
                dtp_Tarea_Administrativa.Value = DateTime.Parse("01-01-1990");
                dtp_Tarea_Administrativa.CustomFormat = " ";
                dtp_Tarea_Administrativa.Format = DateTimePickerFormat.Custom;
                txt_UltTarAdministrativa.Clear();
                txt_UltTarJudicial.Clear();
                lbl_seguimiento.Text = "0";
                chk_Convenio.Checked = false;
                txt_DetalleConvenio.Clear();
                chk_ETJ.Checked = false;
                txt_Incidencia.Clear();
                chk_ETA.Checked = false;
                txt_DetalleIncidencia.Clear();
            }
            private void CargarDataGridView()
            {
                dgv_Procesos.AutoGenerateColumns = false;
                dgv_Procesos.DataSource = _ceriv.SeguimientoProcesoMostrarFechaProcesal(cmb_ExpedienteSeguimiento.SelectedValue.ToString());
                CargarEstadoProcesalVersionMostrarMicro();
            }
            public void ActivarSeguimiento()
            {
                cmb_UltimoEstadoProcesal.Enabled = true;
                dtp_Fecha_Procesal.Enabled = true;
                dtp_Tarea_Administrativa.Enabled = true;
                txt_UltTarAdministrativa.Enabled = true;
                txt_UltTarJudicial.Enabled = true;
                chk_Convenio.Enabled = true;
                txt_DetalleConvenio.Enabled = true;
                txt_Incidencia.Enabled = true;
                chk_ETJ.Enabled = true;
                chk_ETA.Enabled = true;
                txt_DetalleIncidencia.Enabled = true;
            }
            public void BloquearSeguimiento()
            {
                cmb_UltimoEstadoProcesal.Enabled = false;
                dtp_Fecha_Procesal.Enabled = false;
                dtp_Tarea_Administrativa.Enabled = false;
                txt_UltTarAdministrativa.Enabled = false;
                txt_UltTarJudicial.Enabled = false;
                //lbl_seguimiento.Text = "0";
                chk_Convenio.Enabled = false;
                txt_DetalleConvenio.Enabled = false;
                txt_Incidencia.Enabled = false;
                chk_ETJ.Enabled = false;
                chk_ETA.Enabled = false;
                txt_DetalleIncidencia.Enabled = false;

            }
            private void AbrirEstadoProcesal()
            {
                EstadoProcesal objetoEstadoProcesal = new EstadoProcesal();
                objetoEstadoProcesal.ShowDialog();
                CargarComboBoxUltimoEstadoProcesal();
            }
            public void EliminarSeguimiento()
            {
                C_SeguimientoProceso objetoSeguimiento = new C_SeguimientoProceso();
                objetoSeguimiento.Codigo = Int32.Parse(lbl_seguimiento.Text);
                if (objetoSeguimiento.Codigo != 0)
                {
                    if (_ceriv.SeguimientoProcesoEliminar(1, objetoSeguimiento))
                    {
                        MessageBox.Show("Se Elimino el Seguimiento Correctamente");
                        LimpiarSeguimientoProceso();
                        CargarDataGridView();
                        ActivarSeguimiento();
                        btn_Guardar_Seguimiento.Enabled = true;
                        btn_Modificar_Seguimiento.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Seguimiento");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un Seguimiento a Eliminar");
                    return;
                }
            }
            public void CargarExpedienteSeguimiento()
            {
                cmb_ExpedienteSeguimiento.DisplayMember = "NumExpediente";
                cmb_ExpedienteSeguimiento.ValueMember = "NumExpediente";
                cmb_ExpedienteSeguimiento.DataSource = _ceriv.ExpedienteCreditoMostrar(cmb_OperacionSeguimiento.SelectedValue.ToString());
            }
            public void CargarOperacionSeguimiento()
            {
                cmb_OperacionSeguimiento.DisplayMember = "Operacion";
                cmb_OperacionSeguimiento.ValueMember = "Operacion";
                cmb_OperacionSeguimiento.DataSource = _ceriv.OperacionMostrar(txt_CuentaBT.Text);
            }

            //EVENTOS DEL SEGUIMIENTO DEL PROCESO

            private void chk_Convenio_CheckedChanged(object sender, EventArgs e)
            {
                if (chk_Convenio.Checked == true)
                {
                    txt_DetalleConvenio.Enabled = true;
                }
                else if(chk_Convenio.Checked == false)
                {
                    txt_DetalleConvenio.Enabled = false;
                }
            }
            private void cmb_ExpedienteSeguimiento_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_ExpedienteSeguimiento.SelectedIndex != -1)
                {
                    ActivarSeguimiento();
                    LimpiarSeguimientoProceso();
                    btn_Guardar_Seguimiento.Enabled = true;
                    btn_Modificar_Seguimiento.Enabled = false;
                    CargarDataGridView();
                }
            }
            private void dgv_Procesos_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                int row = e.RowIndex;
                if (e.RowIndex > -1)
                {
                    BloquearSeguimiento();
                    btn_Guardar_Seguimiento.Enabled = false;
                    btn_Modificar_Seguimiento.Enabled = true;
                    btn_EliminarSeguimiento.Enabled = true;
                    cmb_UltimoEstadoProcesal.SelectedValue = Int32.Parse(dgv_Procesos.Rows[row].Cells["EstadoProcesal"].Value.ToString());
                    dtp_Fecha_Procesal.Value = DateTime.Parse(dgv_Procesos.Rows[row].Cells["FechaEstadoProcesal"].Value.ToString());
                    dtp_Tarea_Administrativa.Value = DateTime.Parse(dgv_Procesos.Rows[row].Cells["FechaTareaAdministrativa"].Value.ToString());
                    txt_UltTarAdministrativa.Text = dgv_Procesos.Rows[row].Cells["Tarea_Administrativa"].Value.ToString();
                    txt_UltTarJudicial.Text = dgv_Procesos.Rows[row].Cells["Tarea_Judicial"].Value.ToString();
                    //
                    if (dgv_Procesos.Rows[row].Cells["Convenio"].Value.ToString() == "SI")
                    {
                        chk_Convenio.Checked = true;
                    }
                    else if (dgv_Procesos.Rows[row].Cells["Convenio"].Value.ToString() == "NO")
                    {
                        chk_Convenio.Checked = false;
                    }
                    //
                    txt_Incidencia.Text = dgv_Procesos.Rows[row].Cells["Incidencia"].Value.ToString();
                    txt_DetalleIncidencia.Text = dgv_Procesos.Rows[row].Cells["DetalleConvenio"].Value.ToString();
                    
                    if ((Int32.Parse(dgv_Procesos.Rows[row].Cells["EstadoTareaJudicial"].Value.ToString())) == 0)
                    {
                        chk_ETJ.Checked = false;
                    }
                    else if ((Int32.Parse(dgv_Procesos.Rows[row].Cells["EstadoTareaJudicial"].Value.ToString())) == 1)
                    {
                        chk_ETJ.Checked = true;
                    }
                    //
                    if ((Int32.Parse(dgv_Procesos.Rows[row].Cells["EstadoTareaAdministrativa"].Value.ToString())) == 0)
                    {
                        chk_ETA.Checked = false;
                    }
                    else if ((Int32.Parse(dgv_Procesos.Rows[row].Cells["EstadoTareaAdministrativa"].Value.ToString())) == 1)
                    {
                        chk_ETA.Checked = true;
                    }
                    
                    txt_DetalleConvenio.Text = dgv_Procesos.Rows[row].Cells["DetalleConvenio"].Value.ToString();
                    txt_Incidencia.Text = dgv_Procesos.Rows[row].Cells["Incidencia"].Value.ToString();
                    txt_DetalleIncidencia.Text = dgv_Procesos.Rows[row].Cells["DetalleIncidencia"].Value.ToString();
                    lbl_seguimiento.Text = dgv_Procesos.Rows[row].Cells["CodigoProceso"].Value.ToString();
                }

            }
            private void btn_EliminarSeguimiento_Click(object sender, EventArgs e)
            {
                EliminarSeguimiento();
            }
            private void cmb_OperacionSeguimiento_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_OperacionSeguimiento.SelectedIndex != -1)
                {
                    dgv_Procesos.DataSource = null;
                    cmb_ExpedienteSeguimiento.SelectedIndex = -1;
                    cmb_ExpedienteSeguimiento.Text = "";
                    LimpiarSeguimientoProceso();
                    ActivarSeguimiento();
                    btn_Guardar_Seguimiento.Enabled = true;
                    btn_Modificar_Seguimiento.Enabled = false;
                    btn_EliminarSeguimiento.Enabled = false;
                    CargarExpedienteSeguimiento();
                }
            }

            // ACTUALIZAR EL HISTORICO 

            private void ActualizarHistoricoTexto()
            {
                C_Historico objeto = new C_Historico();
                //
                objeto.Expediente = cmb_ExpedienteSeguimiento.SelectedValue.ToString();
                //
                
                objeto.Texto = dtp_Fecha_Procesal.Value.ToShortDateString() + " " + txt_UltTarJudicial.Text + ". ";
                //
                objeto.Llamada = " ";
                //
                objeto.Campo = " ";
                //
                if (_ceriv.Historico(2, objeto))
                {
                }
                else
                {
                    MessageBox.Show("GIL");
                }
            }

            // -------------------------------------------------
            //
            //        

        /*PAGOS*/
            
            //BOTONES DE PAGOS

            private void btn_GuardarPagos_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    GuardarPago();
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }

            }
            private void btn_ModificarPagos_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    ActivarPagos();
                    btn_ModificarPagos.Enabled = false;
                    btn_GuardarPagos.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }

            //FUNCIONES DE PAGOS

            public void CargarDataGridViewPagos()
            {
                if (cmb_ExpedientePagos.SelectedIndex != -1)
                {
                    dgv_Pagos.AutoGenerateColumns = false;
                    dgv_Pagos.DataSource = _ceriv.PagosDGV(cmb_ExpedientePagos.SelectedValue.ToString());
                }
            }
            public void CargarExpedientePago()
            {
                cmb_ExpedientePagos.DisplayMember = "NumExpediente";
                cmb_ExpedientePagos.ValueMember = "NumExpediente";
                cmb_ExpedientePagos.DataSource = _ceriv.ExpedienteCreditoMostrar(cmb_OperacionPagos.SelectedValue.ToString());
            }
            public void BloquearPagos()
            {
                txt_TipoSolucionPagos.Enabled = false;
                txt_PagoPagos.Enabled = false;
                txt_ComisionPagos.Enabled = false;
                dtp_Pagos.Enabled = false;

            }
            public void ActivarPagos()
            {
                txt_TipoSolucionPagos.Enabled = true;
                txt_PagoPagos.Enabled = true;
                txt_ComisionPagos.Enabled = true;
                dtp_Pagos.Enabled = true;
            }
            public void LimpiarPagos()
            {
                txt_TipoSolucionPagos.Clear();
                txt_PagoPagos.Clear();
                txt_ComisionPagos.Clear();
                dtp_Pagos.Value = DateTime.Parse("01-01-1990");
                dtp_Pagos.CustomFormat = " ";
                dtp_Pagos.Format = DateTimePickerFormat.Custom;
                lbl_Pagos.Text = "0";
            }
            public void GuardarPago()
            {
                C_Pagos objetoPagos = new C_Pagos();
                //
                if (cmb_ExpedientePagos.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Expediente");
                    return;
                }
                objetoPagos.Num_expediente = cmb_ExpedientePagos.SelectedValue.ToString();
                //
                if (txt_TipoSolucionPagos.Text == string.Empty)
                    objetoPagos.TipoSolucion = " ";
                objetoPagos.TipoSolucion = txt_TipoSolucionPagos.Text;
                //
                if (txt_PagoPagos.Text == string.Empty)
                    objetoPagos.Pago = " ";
                objetoPagos.Pago = txt_PagoPagos.Text;
                //
                if (txt_ComisionPagos.Text == string.Empty)
                    objetoPagos.Comision = " ";
                objetoPagos.Comision = txt_ComisionPagos.Text;
                //
                objetoPagos.FechaPago = dtp_Pagos.Value.Date;
                //
                objetoPagos.Codigo = Int32.Parse(lbl_Pagos.Text);
                if (_ceriv.Pagos(1, objetoPagos))
                {
                    MessageBox.Show("Se ingreso el Pago Correctamente");
                    LimpiarPagos();
                    btn_GuardarPagos.Enabled = true;
                    btn_ModificarPagos.Enabled = false;
                    CargarDataGridViewPagos();
                    AuditoriaPagos();
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar el Pago, Revise los datos Por Favor");
                }
            }
            public void CargarPagos()
            {
                if (cmb_OperacionPagos.SelectedIndex != -1)
                {
                    C_Pagos objetoPagos = _ceriv.PagosMotrar1(cmb_OperacionPagos.SelectedValue.ToString());
                    txt_NombreTitularPagos.Text = objetoPagos.NombrePersona;
                    txt_CarteraPagos.Text = objetoPagos.NombreCartera;
                    txt_MonedaPagos.Text = objetoPagos.NombreMoneda;
                }
            }
            public void CargarOperacionPagos()
            {
                cmb_OperacionPagos.DisplayMember = "Operacion";
                cmb_OperacionPagos.ValueMember = "Operacion";
                cmb_OperacionPagos.DataSource = _ceriv.OperacionMostrar(txt_CuentaBT.Text);
            }

            //EVENTOS DE PAGOS

            private void cmb_OperacionPagos_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_OperacionPagos.SelectedIndex != -1)
                {
                    cmb_ExpedientePagos.SelectedIndex = -1;
                    ActivarPagos();
                    LimpiarPagos();
                    btn_GuardarPagos.Enabled = true;
                    btn_ModificarPagos.Enabled = false;
                    CargarPagos();
                    CargarExpedientePago();
                    if (cmb_ExpedientePagos.SelectedIndex == -1)
                    {
                        dgv_Pagos.DataSource = null;
                    }
                }

            }
            private void cmb_ExpedientePagos_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_ExpedientePagos.SelectedIndex != -1)
                {
                    ActivarPagos();
                    LimpiarPagos();
                    btn_GuardarPagos.Enabled = true;
                    btn_ModificarPagos.Enabled = false;
                    CargarDataGridViewPagos();
                }
            }
            private void dgv_Pagos_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                int row = e.RowIndex;
                if (cmb_ExpedientePagos.SelectedIndex != -1)
                {
                    if (e.RowIndex > -1)
                    {
                        btn_GuardarPagos.Enabled = false;
                        btn_ModificarPagos.Enabled = true;
                        BloquearPagos();
                        txt_NombreTitularPagos.Text = dgv_Pagos.Rows[row].Cells["NombreTitular"].Value.ToString();
                        txt_TipoSolucionPagos.Text = dgv_Pagos.Rows[row].Cells["TipoSolucion"].Value.ToString();
                        txt_MonedaPagos.Text = dgv_Pagos.Rows[row].Cells["Moneda"].Value.ToString();
                        txt_CarteraPagos.Text = dgv_Pagos.Rows[row].Cells["Cartera"].Value.ToString();
                        txt_PagoPagos.Text = dgv_Pagos.Rows[row].Cells["Pago"].Value.ToString();
                        txt_ComisionPagos.Text = dgv_Pagos.Rows[row].Cells["Comision"].Value.ToString();
                        dtp_Pagos.Value = DateTime.Parse(dgv_Pagos.Rows[row].Cells["FechaPagoDate"].Value.ToString());
                        lbl_Pagos.Text = dgv_Pagos.Rows[row].Cells["CodigoPagos"].Value.ToString();
                    }
                }
            }

            // -------------------------------------------------
            //
            //        

        /*GESTION LLAMADAS FECHA DE VISITA ES IGUAL A FECHA DE PROX LLAMADA*/

            //BOTONES DE GESTION LLAMADA

            private void btn_Gestion_Llamadas_Click_1(object sender, EventArgs e)
            {
                AgregarGestionCall();
            }
            private void btn_ModificarGestionLlamadas_Click(object sender, EventArgs e)
            {
                ActivarGestionLlamadas();
                btn_AgregarGestionLlamadas.Enabled = true;
                btn_ModificarGestionLlamadas.Enabled = false;
            }
            private void btn_Limpiar_Llamada_Click(object sender, EventArgs e)
            {
                CargarDataGridViewGestionLlamada();

                LimpiarGestionLlamada2();
                txt_Gestion.Text = "" + (dgv_GestionLlamada.RowCount + 1);
                ActivarGestionLlamadas();

            }

            //FUNCIONES DE GESTION LLAMADA

            public void CargarDataGridViewGestionLlamada()
            {
                if (cmb_ExpedienteLlamada.SelectedIndex != -1 || cmb_OperacionCall.SelectedIndex != -1)
                {
                    dgv_GestionLlamada.AutoGenerateColumns = false;
                    dgv_GestionLlamada.DataSource = _ceriv.GestionLlamadaMostrar(cmb_ExpedienteLlamada.SelectedValue.ToString(), cmb_OperacionCall.SelectedValue.ToString());
                }
            }
            public void ActivarGestionLlamadas()
            {
                txt_Telefono.Enabled = true;
                cmb_ContactoCliente.Enabled = true;
                cmb_ContactoPariente.Enabled = true;
                txt_Nombre_Pariente.Enabled = true;
                dtp_Fecha_Visita.Enabled = true;
                dtp_Fecha_Pago.Enabled = true; ;
                txt_Telefono_Corresponde.Enabled = true;
                txt_Monto_Pago.Enabled = true;
                txt_DueñoBien.Enabled = true;
                cmb_NiegaPago.Enabled = true;
                cmb_TrabajadorLlamada.Enabled = true;
                dtp_HoraLlamada.Enabled = true;// txt_HoraLlamada.Enabled = true;
                txt_descripcion_resultado.Enabled = true;
                //txt_Gestion.Enabled = true;
                txt_TipoSolucionLlamada.Enabled = true;
                btn_AgregarGestionLlamadas.Enabled = true;
                cmb_ReporteLlamada.Enabled = true;
            }
            public void AgregarGestionCall()
            {
                C_GestionLlamadas objetoGestionLlamada = new C_GestionLlamadas();
                //
                if (cmb_ExpedienteLlamada.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingrese un Expediente ");
                    return;
                }
                objetoGestionLlamada.Num_expediente = cmb_ExpedienteLlamada.SelectedValue.ToString();
                //
                if (txt_Telefono.Text == string.Empty)
                    objetoGestionLlamada.TelefonoContacto = " ";
                objetoGestionLlamada.TelefonoContacto = txt_Telefono.Text;
                //
                if (cmb_ContactoCliente.Text == string.Empty)
                    objetoGestionLlamada.ContactoPariente = " ";
                else
                {
                    objetoGestionLlamada.ContactoCliente = cmb_ContactoCliente.Text;
                }
                //
                if (cmb_ContactoPariente.Text == "SI")
                {
                    objetoGestionLlamada.ContactoPariente = "SI";
                    if (txt_Nombre_Pariente.Text == string.Empty)
                        objetoGestionLlamada.NombrePariente = " ";
                    objetoGestionLlamada.NombrePariente = txt_Nombre_Pariente.Text;
                }
                if (cmb_ContactoPariente.Text == "NO")
                {
                    objetoGestionLlamada.ContactoPariente = "NO";
                    objetoGestionLlamada.NombrePariente = " ";
                }
                if (cmb_ContactoPariente.Text == string.Empty)
                    objetoGestionLlamada.ContactoPariente = " ";
                //
                if (txt_Telefono_Corresponde.Text == string.Empty)
                    objetoGestionLlamada.TelefonoNoCorresponde = " ";
                objetoGestionLlamada.TelefonoNoCorresponde = txt_Telefono_Corresponde.Text;
                //FECHA PROXIMA LLAMADA
                objetoGestionLlamada.FechaVisitaEstudio = dtp_Fecha_Visita.Value.Date;
                //
                objetoGestionLlamada.FechaPago = dtp_Fecha_Pago.Value.Date;
                //
                if (txt_Monto_Pago.Text == string.Empty)
                    objetoGestionLlamada.MontoPago = " ";
                objetoGestionLlamada.MontoPago = txt_Monto_Pago.Text;
                //
                if (txt_DueñoBien.Text == string.Empty)
                    objetoGestionLlamada.DuenoBien = " ";
                objetoGestionLlamada.DuenoBien = txt_DueñoBien.Text;
                //
                if (cmb_NiegaPago.Text == string.Empty)
                    objetoGestionLlamada.NiegaPago = " ";
                objetoGestionLlamada.NiegaPago = cmb_NiegaPago.Text;
                //
                if (cmb_TrabajadorLlamada.SelectedIndex == -1)
                {
                    MessageBox.Show("Ingresar un Gestor de Call");
                    return;
                }
                objetoGestionLlamada.DniTrabajador = Int32.Parse(cmb_TrabajadorLlamada.SelectedValue.ToString());
                //
                objetoGestionLlamada.HoraLlamada = DateTime.Now.ToShortDateString() + " " + dtp_HoraLlamada.Text;
                //
                if (txt_descripcion_resultado.Text == string.Empty)
                    objetoGestionLlamada.DetalleResultado = " ";
                objetoGestionLlamada.DetalleResultado = txt_descripcion_resultado.Text;
                //
                if (txt_Gestion.Text == string.Empty)
                    objetoGestionLlamada.NumGestion = " ";
                objetoGestionLlamada.NumGestion = txt_Gestion.Text;
                //
                if (txt_TipoSolucionLlamada.Text == string.Empty)
                    objetoGestionLlamada.TipoSolucion = " ";
                objetoGestionLlamada.TipoSolucion = txt_TipoSolucionLlamada.Text;
                //
                if (cmb_ReporteLlamada.Text == string.Empty)
                {
                    objetoGestionLlamada.Reporte = " ";
                }
                else
                {
                    objetoGestionLlamada.Reporte = cmb_ReporteLlamada.Text;
                }
                //
                objetoGestionLlamada.CodigoGestionLlamada = Int32.Parse(lbl_llamadas.Text);
                if (_ceriv.GestionLlamada(1, objetoGestionLlamada))
                {
                    ActualizarHistoricoLlamada();
                    MessageBox.Show("Se ingreso La gestion de Llamada Correctamente");
                    LimpiarGestionLlamada();
                    CargarDataGridViewGestionLlamada();
                    txt_Gestion.Text = "" + (dgv_GestionLlamada.RowCount + 1);
                    btn_AgregarGestionLlamadas.Enabled = true;
                    btn_ModificarGestionLlamadas.Enabled = false;
                    AuditoriaGestionLlamada();
                }
                else
                {
                    MessageBox.Show("Revise los datos");
                }
            }
            public void CargarComboBoxLlamadas()
            {
                cmb_TrabajadorLlamada.DisplayMember = "NombreCompleto";
                cmb_TrabajadorLlamada.ValueMember = "DniTrabajador";
                cmb_TrabajadorLlamada.DataSource = _ceriv.TrabajadorMostrar();
            }
            public void BloquearGestionLlamadas()
            {
                txt_Telefono.Enabled = false;
                cmb_ContactoCliente.Enabled = false;
                cmb_ContactoPariente.Enabled = false;
                txt_Nombre_Pariente.Enabled = false;
                dtp_Fecha_Visita.Enabled = false;
                dtp_Fecha_Pago.Enabled = false;
                txt_Telefono_Corresponde.Enabled = false;
                txt_Monto_Pago.Enabled = false;
                txt_DueñoBien.Enabled = false;
                cmb_NiegaPago.Enabled = false;
                cmb_TrabajadorLlamada.Enabled = false;
                dtp_HoraLlamada.Enabled = false; // txt_HoraLlamada.Enabled = false;
                txt_descripcion_resultado.Enabled = false;
                txt_Gestion.Enabled = false;
                txt_TipoSolucionLlamada.Enabled = false;
                cmb_ReporteLlamada.Enabled = false;
            }
            public void LimpiarGestionLlamada()
            {
                txt_Telefono.Clear();
                cmb_ContactoCliente.SelectedIndex = -1;
                cmb_ContactoPariente.SelectedIndex = -1;
                txt_Nombre_Pariente.Clear();
                dtp_Fecha_Visita.Value = DateTime.Parse("01-01-1990");
                dtp_Fecha_Visita.CustomFormat = " ";
                dtp_Fecha_Visita.Format = DateTimePickerFormat.Custom;
                dtp_Fecha_Pago.Value = DateTime.Parse("01-01-1990");
                dtp_Fecha_Pago.CustomFormat = " ";
                dtp_Fecha_Pago.Format = DateTimePickerFormat.Custom;
                txt_Telefono_Corresponde.Clear();
                txt_Monto_Pago.Clear();
                txt_DueñoBien.Clear();
                cmb_NiegaPago.Text = "";
                cmb_TrabajadorLlamada.SelectedIndex = -1;
                dtp_HoraLlamada.Value = DateTime.Now; //txt_HoraLlamada.Clear();
                txt_descripcion_resultado.Clear();
               // txt_Gestion.Clear();
                txt_TipoSolucionLlamada.Clear();
                cmb_ReporteLlamada.Text = "";
                lbl_llamadas.Text = "0";

            }
            public void LimpiarGestionLlamada2()
            {
                //txt_Telefono.Clear();
                cmb_ContactoCliente.SelectedIndex = -1;
                cmb_ContactoPariente.SelectedIndex = -1;
                txt_Nombre_Pariente.Clear();
                dtp_Fecha_Visita.Value = DateTime.Parse("01-01-1990");
                dtp_Fecha_Visita.CustomFormat = " ";
                dtp_Fecha_Visita.Format = DateTimePickerFormat.Custom;
                dtp_Fecha_Pago.Value = DateTime.Parse("01-01-1990");
                dtp_Fecha_Pago.CustomFormat = " ";
                dtp_Fecha_Pago.Format = DateTimePickerFormat.Custom;
                txt_Telefono_Corresponde.Clear();
                txt_Monto_Pago.Clear();
                txt_DueñoBien.Clear();
                cmb_NiegaPago.Text = "";
                cmb_TrabajadorLlamada.SelectedIndex = -1;
                dtp_HoraLlamada.Value = DateTime.Now; //txt_HoraLlamada.Clear();
                txt_descripcion_resultado.Clear();
                //txt_Gestion.Clear();
                txt_TipoSolucionLlamada.Clear();
                cmb_ReporteLlamada.Text = "";
                lbl_llamadas.Text = "0";
            }
            public void ClickDataGridView(int row)
            {
                if (cmb_ExpedienteLlamada.SelectedIndex != -1)
                {
                    btn_AgregarGestionLlamadas.Enabled = false;
                    btn_ModificarGestionLlamadas.Enabled = true;
                    BloquearGestionLlamadas();
                    txt_Telefono.Text = dgv_GestionLlamada.Rows[row].Cells["TelefContacto"].Value.ToString();
                    cmb_ContactoCliente.Text = dgv_GestionLlamada.Rows[row].Cells["ContactoCliente"].Value.ToString();
                    cmb_ContactoPariente.Text = dgv_GestionLlamada.Rows[row].Cells["ContactoPariente"].Value.ToString();
                    txt_Nombre_Pariente.Text = dgv_GestionLlamada.Rows[row].Cells["NombrePariente"].Value.ToString();
                    txt_Telefono_Corresponde.Text = dgv_GestionLlamada.Rows[row].Cells["TelefonoNoCorresponde"].Value.ToString();
                    dtp_Fecha_Visita.Value = DateTime.Parse(dgv_GestionLlamada.Rows[row].Cells["FechaVisitaEstudioDate"].Value.ToString());
                    dtp_Fecha_Pago.Value = DateTime.Parse(dgv_GestionLlamada.Rows[row].Cells["FechaPagoDatee"].Value.ToString());
                    txt_Monto_Pago.Text = dgv_GestionLlamada.Rows[row].Cells["MontoPago"].Value.ToString();
                    txt_DueñoBien.Text = dgv_GestionLlamada.Rows[row].Cells["DueñoBienLlamada"].Value.ToString();
                    cmb_NiegaPago.Text = dgv_GestionLlamada.Rows[row].Cells["NiegaPago"].Value.ToString();
                    cmb_TrabajadorLlamada.SelectedValue = Int32.Parse(dgv_GestionLlamada.Rows[row].Cells["DNI"].Value.ToString());
                    try
                    {
                        dtp_HoraLlamada.Value /*txt_HoraLlamada.Text*/ = DateTime.Parse(dgv_GestionLlamada.Rows[row].Cells["HoraLlamada"].Value.ToString());
                    }
                    catch
                    {
                        dtp_HoraLlamada.Value = DateTime.Now;
                    }
                    txt_descripcion_resultado.Text = dgv_GestionLlamada.Rows[row].Cells["DetalleResultado"].Value.ToString();
                    txt_Gestion.Text = dgv_GestionLlamada.Rows[row].Cells["NroGestion"].Value.ToString();
                    txt_TipoSolucionLlamada.Text = dgv_GestionLlamada.Rows[row].Cells["Solucion"].Value.ToString();
                    cmb_ReporteLlamada.Text = dgv_GestionLlamada.Rows[row].Cells["Reporte"].Value.ToString();
                    lbl_llamadas.Text = dgv_GestionLlamada.Rows[row].Cells["cdgGLL"].Value.ToString();
                }
            }
            public void CargarOperacionCall()
            {
                cmb_OperacionCall.DisplayMember = "Operacion";
                cmb_OperacionCall.ValueMember = "Operacion";
                cmb_OperacionCall.DataSource = _ceriv.OperacionMostrar(txt_CuentaBT.Text);

            }
            public void CargarExpedienteCall()
            {
                cmb_ExpedienteLlamada.DisplayMember = "NumExpediente";
                cmb_ExpedienteLlamada.ValueMember = "NumExpediente";
                cmb_ExpedienteLlamada.DataSource = _ceriv.ExpedienteCreditoMostrar(cmb_OperacionCall.SelectedValue.ToString());
                    
            }

            //EVENTOS DE GESTION LLAMADA

            private void cmb_ExpedienteLlamada_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_ExpedienteLlamada.SelectedIndex != -1)
                {
                    ActivarGestionLlamadas();
                    LimpiarGestionLlamada();
                    btn_AgregarGestionLlamadas.Enabled = true;
                    btn_ModificarGestionLlamadas.Enabled = false;
                    CargarDataGridViewGestionLlamada();
                    txt_Gestion.Text = "" + (dgv_GestionLlamada.RowCount + 1);
                }
            }
            private void dgv_GestionLlamada_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                int row = e.RowIndex;
                if (e.RowIndex > -1)
                {
                    ClickDataGridView(row);
                }
            }
            private void cmb_ContactoPariente_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_ContactoPariente.Text == string.Empty)
                {
                    txt_Nombre_Pariente.Enabled = false;
                }
                if (cmb_ContactoPariente.Text == "SI")
                {
                    if (cmb_ContactoPariente.Enabled == false)
                        txt_Nombre_Pariente.Enabled = false;
                    else
                        txt_Nombre_Pariente.Enabled = true;
                }
                if (cmb_ContactoPariente.Text == "NO")
                {
                    txt_Nombre_Pariente.Text = string.Empty;
                    txt_Nombre_Pariente.Enabled = false;
                }
            }
            private void cmb_OperacionCall_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_OperacionCall.SelectedIndex != -1)
                {
                    dgv_GestionLlamada.DataSource = null;
                    cmb_ExpedienteLlamada.SelectedIndex = -1;
                    cmb_ExpedienteLlamada.Text = "";
                    LimpiarGestionLlamada();
                    ActivarGestionLlamadas();
                    btn_AgregarGestionLlamadas.Enabled = true;
                    btn_ModificarGestionLlamadas.Enabled = false;
                    //btn_Limpiar_Llamada.Enabled = false;
                    CargarExpedienteCall();

                }
            }

            //HISTORICO GESTION LLAMADA

            private void ActualizarHistoricoLlamada()
            {
                C_Historico objeto = new C_Historico();
                //
                objeto.Expediente = cmb_ExpedienteLlamada.SelectedValue.ToString();
                //
                objeto.Texto = " ";
                //
                if (dtp_Fecha_Pago.Value.Date != DateTime.Parse("01-01-1990"))
                    objeto.Llamada = txt_Telefono.Text + "|" + DateTime.Now.ToShortDateString() + "|" + txt_descripcion_resultado.Text + "|" + dtp_Fecha_Pago.Value.ToShortDateString() + ".";
                else
                    objeto.Llamada = txt_Telefono.Text + "|" + DateTime.Now.ToShortDateString() + "|" + txt_descripcion_resultado.Text + ".";
                //
                objeto.Campo = " ";
                //
                if (_ceriv.Historico(2, objeto))
                {
                }
                else
                {
                }
            }

            // -------------------------------------------------
            //
            //        

        /*GESTION CAMPO */

            //BOTONES GESTION CAMPO

            private void btn_Guardar_Campo_Click_1(object sender, EventArgs e)
            {
                GuardarGestionCampo();
            }
            private void btn_ModificarCampo_Click(object sender, EventArgs e)
            {
                ActivarGestionCampo();
                btn_ModificarCampo.Enabled = false;
                btn_GuardarCampo.Enabled = true;
            }

            //FUNCIONES GESTION CAMPO

            public void CargarDataGridViewGestionCampo()
            {
                if (cmb_ExpedienteCampo.SelectedIndex != -1 || cmb_OperacionCampo.SelectedIndex != -1)
                {
                    dgv_GestionCampo.AutoGenerateColumns = false;
                    dgv_GestionCampo.DataSource = _ceriv.GestionCampoMostrar(cmb_ExpedienteCampo.SelectedValue.ToString(), cmb_OperacionCampo.SelectedValue.ToString());
                }
            }
            public void BloquearGestionCampo()
            {
                cmb_Gestion.Enabled = false;
                cmb_ContactoParienteCampo.Enabled = false;
                cmb_NuevoDomCampo.Enabled = false;
                cmb_TrabajadorCampo.Enabled = false;
                dtp_Pago.Enabled = false;
                dtp_Gestion_Campo.Enabled = false;
                txt_Pariente_Campo.Enabled = false;
                txt_Detalle_Campo.Enabled = false;
                txt_Monto_Campo.Enabled = false;
                cmb_NiegaPagoCampo.Enabled = false;
                dtp_HoraVisita.Enabled = false;
                txt_Detalle_Resultado.Enabled = false;
                cmb_Inubicable.Enabled = false;
               // txt_Num_Gestion.Enabled = false;
                txt_Descrp_Campo.Enabled = false;
                txt_DuenoBienCampo.Enabled = false;
                txt_TipoSolucionCampo.Enabled = false;
                cmb_ReporteCampo.Enabled = false;
            }
            public void LimpiarGestionCampo()
            {
                cmb_Gestion.SelectedIndex = -1;
                cmb_ContactoParienteCampo.SelectedIndex = -1;
                cmb_NuevoDomCampo.SelectedIndex = -1;
                cmb_TrabajadorCampo.SelectedIndex = -1;
                dtp_Pago.Value = DateTime.Parse("01-01-1990");
                dtp_Pago.CustomFormat = " ";
                dtp_Pago.Format = DateTimePickerFormat.Custom;
                dtp_Gestion_Campo.Value = DateTime.Parse("01-01-1990");
                dtp_Gestion_Campo.CustomFormat = " ";
                dtp_Gestion_Campo.Format = DateTimePickerFormat.Custom;
                txt_Pariente_Campo.Clear();
                txt_Detalle_Campo.Clear();
                txt_Monto_Campo.Clear();
                cmb_NiegaPagoCampo.SelectedIndex = -1;
                cmb_NiegaPagoCampo.Text = "";
                dtp_HoraVisita.Value = DateTime.Now; // txt_HoraVisita.Clear();
                txt_Detalle_Resultado.Clear();
                cmb_Inubicable.SelectedIndex = -1;
                cmb_Inubicable.Text = "";
                //txt_Num_Gestion.Clear();
                txt_Descrp_Campo.Clear();
                txt_DuenoBienCampo.Clear();
                txt_TipoSolucionCampo.Clear();
                lbl_GestionCampo.Text = "0";
                cmb_ReporteCampo.SelectedIndex = -1;
                cmb_ReporteCampo.Text = "";
            }
            public void ActivarGestionCampo()
            {
                cmb_Gestion.Enabled = true;
                cmb_ContactoParienteCampo.Enabled = true;
                cmb_NuevoDomCampo.Enabled = true;
                cmb_TrabajadorCampo.Enabled = true;
                dtp_Pago.Enabled = true;
                dtp_Gestion_Campo.Enabled = true;
                txt_Pariente_Campo.Enabled = true;
                txt_Detalle_Campo.Enabled = true;
                txt_Monto_Campo.Enabled = true;
                cmb_NiegaPagoCampo.Enabled = true;
                dtp_HoraVisita.Enabled = true;
                txt_Detalle_Resultado.Enabled = true;
                cmb_Inubicable.Enabled = true;
               // txt_Num_Gestion.Enabled = true;
                txt_Descrp_Campo.Enabled = true;
                txt_DuenoBienCampo.Enabled = true;
                txt_TipoSolucionCampo.Enabled = true;
                cmb_ReporteCampo.Enabled = true;
            }
            public void CargarComboBoxCampo()
            {
                cmb_TrabajadorCampo.DisplayMember = "NombreCompleto";
                cmb_TrabajadorCampo.ValueMember = "DniTrabajador";
                cmb_TrabajadorCampo.DataSource = _ceriv.TrabajadorMostrar();
            }
            private void GuardarGestionCampo()
            {
                C_GestionCampo objetoGestionCampo = new C_GestionCampo();
                //
                if (cmb_ExpedienteCampo.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Expediente Por Favor");
                    return;
                }
                objetoGestionCampo.Num_expediente = cmb_ExpedienteCampo.SelectedValue.ToString();
                //
                if (cmb_Gestion.Text == "NO")
                    objetoGestionCampo.GestionCampo = "NO";
                if (cmb_Gestion.Text == "SI")
                    objetoGestionCampo.GestionCampo = "SI";
                if (cmb_Gestion.Text == string.Empty)
                    objetoGestionCampo.GestionCampo = " ";
                //
                if (cmb_ContactoParienteCampo.Text == string.Empty)
                {
                    objetoGestionCampo.ContactoPariente = " ";
                }
                else
                {
                    objetoGestionCampo.ContactoPariente = cmb_ContactoParienteCampo.Text;
                }
                //
                if (txt_Pariente_Campo.Text == string.Empty)
                {
                    objetoGestionCampo.NombrePariente = " ";
                }
                else
                {
                    objetoGestionCampo.NombrePariente = txt_Pariente_Campo.Text;
                }
                //
                if (cmb_NuevoDomCampo.Text == "NO")
                    objetoGestionCampo.NuevoDomTele = "NO";
                if (cmb_NuevoDomCampo.Text == "SI")
                    objetoGestionCampo.NuevoDomTele = "SI";
                //
                if (txt_Detalle_Campo.Text == string.Empty)
                    objetoGestionCampo.Detalle = " ";
                objetoGestionCampo.Detalle = txt_Detalle_Campo.Text;
                //
                objetoGestionCampo.FechaPago = dtp_Pago.Value.Date;
                //
                if (txt_Monto_Campo.Text == string.Empty)
                    objetoGestionCampo.MontoPago = " ";
                objetoGestionCampo.MontoPago = txt_Monto_Campo.Text;
                //
                if (dtp_Gestion_Campo.Value == DateTime.Parse("01-01-1990"))
                {
                    MessageBox.Show("Ingrese la fecha de la Gestion Campo, Por Favor");
                    return;
                }
                else
                {
                    objetoGestionCampo.FechaGestion = dtp_Gestion_Campo.Value.Date;
                }
                //
                if (cmb_NiegaPagoCampo.Text == string.Empty)
                    objetoGestionCampo.NiegaPago = " ";
                objetoGestionCampo.NiegaPago = cmb_NiegaPagoCampo.Text;
                //
                objetoGestionCampo.HoraGestion = DateTime.Now.ToShortDateString() + " " + dtp_HoraVisita.Text;
                //
                if (cmb_TrabajadorCampo.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Gestor de Campo, Por Favor");
                    return;
                }
                objetoGestionCampo.DniTrabajador = Int32.Parse(cmb_TrabajadorCampo.SelectedValue.ToString());
                //
                if (txt_Detalle_Resultado.Text == string.Empty)
                    objetoGestionCampo.DetalleResultado = " ";
                objetoGestionCampo.DetalleResultado = txt_Detalle_Resultado.Text;
                //
                if (cmb_Inubicable.Text == string.Empty)
                    objetoGestionCampo.Inubicable = " ";
                objetoGestionCampo.Inubicable = cmb_Inubicable.Text;
                //
                if (txt_Num_Gestion.Text == string.Empty)
                    objetoGestionCampo.NumGestion = " ";
                objetoGestionCampo.NumGestion = txt_Num_Gestion.Text;
                //
                if (txt_Descrp_Campo.Text == string.Empty)
                    objetoGestionCampo.DescripcionInmueble = " ";
                objetoGestionCampo.DescripcionInmueble = txt_Descrp_Campo.Text;
                //
                if (txt_DuenoBienCampo.Text == string.Empty)
                    objetoGestionCampo.DuenoBien = " ";
                objetoGestionCampo.DuenoBien = txt_DuenoBienCampo.Text;
                //
                if (txt_TipoSolucionCampo.Text == string.Empty)
                    objetoGestionCampo.TipoSolucion = " ";
                objetoGestionCampo.TipoSolucion = txt_TipoSolucionCampo.Text;
                //
                if (cmb_ReporteCampo.Text == string.Empty)
                {
                    objetoGestionCampo.Reporte = " ";
                }
                else
                {
                    objetoGestionCampo.Reporte = cmb_ReporteCampo.Text;
                }
                //
                objetoGestionCampo.Codigo = Int32.Parse(lbl_GestionCampo.Text);
                //
                if (_ceriv.GestionCampo(1, objetoGestionCampo))
                {
                    MessageBox.Show("Se ingreso la Gestion de Campo Correctamente");
                    ActualizarHistoricoCampo();
                    LimpiarGestionCampo();
                    txt_Num_Gestion.Text = ""+ (dgv_GestionCampo.RowCount + 1);
                    CargarDataGridViewGestionCampo();
                    AuditoriaGestionCampo();
                }
                else
                {
                    MessageBox.Show("Revise Los Datos");
                }
            }
            public void CargarOperacionCampo()
            {
                cmb_OperacionCampo.DisplayMember = "Operacion";
                cmb_OperacionCampo.ValueMember = "Operacion";
                cmb_OperacionCampo.DataSource = _ceriv.OperacionMostrar(txt_CuentaBT.Text);
            }
            public void CargarExpedienteCampo()
            {
                cmb_ExpedienteCampo.DisplayMember = "NumExpediente";
                cmb_ExpedienteCampo.ValueMember = "NumExpediente";
                cmb_ExpedienteCampo.DataSource = _ceriv.ExpedienteCreditoMostrar(cmb_OperacionCampo.SelectedValue.ToString());
            }

            //EVENTOS GESTION CAMPO
        
            private void cmb_ExpedienteCampo_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_ExpedienteCampo.SelectedIndex != -1)
                {
                    ActivarGestionCampo();
                    LimpiarGestionCampo();
                    btn_GuardarCampo.Enabled = true;
                    btn_ModificarCampo.Enabled = false;
                    CargarDataGridViewGestionCampo();
                    txt_Num_Gestion.Text = "" + (dgv_GestionCampo.RowCount + 1);
                }
            }
            private void dgv_GestionCampo_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                int row = e.RowIndex;
                if (cmb_ExpedienteCampo.SelectedIndex != -1)
                {
                    if (e.RowIndex > -1)
                    {
                        btn_GuardarCampo.Enabled = false;
                        btn_ModificarCampo.Enabled = true;
                        BloquearGestionCampo();
                        cmb_Gestion.Text = dgv_GestionCampo.Rows[row].Cells["gestionCampo"].Value.ToString();
                        cmb_ContactoParienteCampo.Text = dgv_GestionCampo.Rows[row].Cells["CampoContactoPar"].Value.ToString();
                        cmb_NuevoDomCampo.Text = dgv_GestionCampo.Rows[row].Cells["nuevoDomici"].Value.ToString();
                        cmb_TrabajadorCampo.SelectedValue = Int32.Parse(dgv_GestionCampo.Rows[row].Cells["DniCampo"].Value.ToString());
                        dtp_Pago.Value = DateTime.Parse(dgv_GestionCampo.Rows[row].Cells["FechaPagoDateee"].Value.ToString());
                        dtp_Gestion_Campo.Value = DateTime.Parse(dgv_GestionCampo.Rows[row].Cells["FechaGestion"].Value.ToString());
                        txt_Pariente_Campo.Text = dgv_GestionCampo.Rows[row].Cells["NombreCampoPari"].Value.ToString();
                        txt_Detalle_Campo.Text = dgv_GestionCampo.Rows[row].Cells["Detalle"].Value.ToString();
                        txt_Monto_Campo.Text = dgv_GestionCampo.Rows[row].Cells["monto_pago"].Value.ToString();
                        cmb_NiegaPagoCampo.Text = dgv_GestionCampo.Rows[row].Cells["Niega_Pago"].Value.ToString();
                        try
                        {
                            dtp_HoraVisita.Value/*txt_HoraVisita.Text*/ = DateTime.Parse(dgv_GestionCampo.Rows[row].Cells["HoraVisita"].Value.ToString());
                        }
                        catch
                        {
                            dtp_HoraVisita.Value = DateTime.Now;
                        }
                        txt_Detalle_Resultado.Text = dgv_GestionCampo.Rows[row].Cells["Detalle_Resultado"].Value.ToString();
                        cmb_Inubicable.Text = dgv_GestionCampo.Rows[row].Cells["Inubicable"].Value.ToString();
                        txt_Num_Gestion.Text = dgv_GestionCampo.Rows[row].Cells["nro_Gestion"].Value.ToString();
                        txt_Descrp_Campo.Text = dgv_GestionCampo.Rows[row].Cells["Descripcion_Inmueble"].Value.ToString();
                        txt_DuenoBienCampo.Text = dgv_GestionCampo.Rows[row].Cells["DueñoDelBien"].Value.ToString();
                        lbl_GestionCampo.Text = dgv_GestionCampo.Rows[row].Cells["CodigoCampo"].Value.ToString();
                        txt_TipoSolucionCampo.Text = dgv_GestionCampo.Rows[row].Cells["SolucionCampo"].Value.ToString();
                        cmb_ReporteCampo.Text = dgv_GestionCampo.Rows[row].Cells["ReporteCampo"].Value.ToString();

                    }
                }

            }
            private void cmb_OperacionCampo_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_OperacionCampo.SelectedIndex != -1)
                {
                    dgv_GestionCampo.DataSource = null;
                    cmb_ExpedienteCampo.SelectedIndex = -1;
                    cmb_ExpedienteCampo.Text = "";
                    LimpiarGestionCampo();
                    ActivarGestionCampo();
                    btn_GuardarCampo.Enabled = true;
                    btn_ModificarCampo.Enabled = false;
                    CargarExpedienteCampo();
                }
            }

            //HISTORICO GESTION CAMPO

            private void ActualizarHistoricoCampo()
            {
                C_Historico objeto = new C_Historico();
                //
                objeto.Expediente = cmb_ExpedienteCampo.SelectedValue.ToString();
                //
                objeto.Texto = " ";
                //
                objeto.Llamada = " ";
                //
                if (dtp_Pago.Value.Date != DateTime.Parse("01-01-1990"))
                    objeto.Campo = dtp_Gestion_Campo.Value.ToShortDateString() + " " + txt_Detalle_Resultado.Text + " " + dtp_Pago.Value.ToShortDateString() + ". ";
                else
                    objeto.Campo = dtp_Gestion_Campo.Value.ToShortDateString() + " " + txt_Detalle_Resultado.Text + ".";
                //
                if (_ceriv.Historico(2, objeto))
                {
                }
                else
                {
                }
            }

            // -------------------------------------------------
            //
            //                

        /*PROYECCION*/

            //BOTONES DE PROYECCION

            private void btn_GuardarProyeccion_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    GuardarProyeccion();
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                } 
            }
            private void btn_ModificarProyeccion_Click(object sender, EventArgs e)
            {
                if (PermisoAdministradorAbogado())
                {
                    ModificarProyeccion();
                }
                else
                {
                    MessageBox.Show("Permiso denegado");
                }
            }
            private void btn_NuevoProyeccion_Click(object sender, EventArgs e)
            {
                limpiarProyeccion();
                ActivarProyeccion();
                btn_GuardarProyeccion.Enabled = true;
                btn_ModificarProyeccion.Enabled = false;
            }

            //FUNCIONES DE PROYECCION
        
            public void GuardarProyeccion()
            {
                C_Proyeccion objetoProyeccion = new C_Proyeccion();
                //
                if (cmb_ExpedienteProyeccion.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Expediente Por Favor");
                    return;
                }
                else
                {
                    objetoProyeccion.Expediente = cmb_ExpedienteProyeccion.SelectedValue.ToString();
                }
                //
                objetoProyeccion.FechaEstimada = dtp_FechaEstimada.Value;
                //
                if (txt_Devuelto.Text == string.Empty)
                {
                    objetoProyeccion.Devuelto = " ";
                }
                else
                {
                    objetoProyeccion.Devuelto = txt_Devuelto.Text;
                }
                //
                if (txt_MotivoDevolucion.Text == string.Empty)
                    objetoProyeccion.MotivoDevolucion = " ";
                objetoProyeccion.MotivoDevolucion = txt_MotivoDevolucion.Text;
                //
                if (txt_TelefonoProyeccion.Text == string.Empty)
                    objetoProyeccion.Telefono = " ";
                objetoProyeccion.Telefono = txt_TelefonoProyeccion.Text;
                //
                objetoProyeccion.Funcion = cmb_ExpedienteProyeccion.SelectedValue.ToString();
                if (_ceriv.Proyeccion(1, objetoProyeccion))
                {
                    MessageBox.Show("Se ingreso Correctamente la Proyeccion");
                    BloquearProyeccion();
                    btn_GuardarProyeccion.Enabled = false;
                    btn_ModificarProyeccion.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar correctamente la Proyeccion");
                }

            }
            public void BloquearProyeccion()
            {
                dtp_FechaEstimada.Enabled = false;
                txt_Devuelto.Enabled = false;
                txt_MotivoDevolucion.Enabled = false;
                txt_TelefonoProyeccion.Enabled = false;
            }
            public void ActivarProyeccion()
            {
                dtp_FechaEstimada.Enabled = true;
                txt_Devuelto.Enabled = true;
                txt_MotivoDevolucion.Enabled = true;
                txt_TelefonoProyeccion.Enabled = true;
            }
            public void ModificarProyeccion()
            {
                ActivarProyeccion();
                btn_GuardarProyeccion.Enabled = true;
                btn_ModificarProyeccion.Enabled = false;
            }
            public void limpiarProyeccion()
            {
                dtp_FechaEstimada.Value = DateTime.Parse("01-01-1990");
                dtp_FechaEstimada.CustomFormat = " ";
                dtp_FechaEstimada.Format = DateTimePickerFormat.Custom;
                txt_Devuelto.Clear();
                txt_MotivoDevolucion.Clear();
                txt_TelefonoProyeccion.Clear();
            }
            public void CargarProyeccion()
            {
                C_Proyeccion objProyeccion = _ceriv.ProyeccionMostrar1(cmb_ExpedienteProyeccion.SelectedValue.ToString());
                txt_MotivoDevolucion.Text = objProyeccion.MotivoDevolucion;
                txt_Devuelto.Text = objProyeccion.Devuelto;
                if (objProyeccion.FechaEstimada == DateTime.Parse("01-01-1990"))
                {
                    dtp_FechaEstimada.CustomFormat = " ";
                    dtp_FechaEstimada.Format = DateTimePickerFormat.Custom;
                }
                else if (objProyeccion.FechaEstimada != DateTime.MinValue)
                {
                    dtp_FechaEstimada.Value = objProyeccion.FechaEstimada;
                }
                else
                {
                    dtp_FechaEstimada.Value = DateTime.Parse("01-01-1900");
                    dtp_FechaEstimada.CustomFormat = " ";
                    dtp_FechaEstimada.Format = DateTimePickerFormat.Custom;
                }
                txt_TelefonoProyeccion.Text = objProyeccion.Telefono;

            }
            public void CargarOperacionProyeccion()
            {
                cmb_OperacionProyeccion.DisplayMember = "Operacion";
                cmb_OperacionProyeccion.ValueMember = "Operacion";
                cmb_OperacionProyeccion.DataSource = _ceriv.OperacionMostrar(txt_CuentaBT.Text);
            }
            public void CargarExpedienteProyeccion()
            {
                cmb_ExpedienteProyeccion.DisplayMember = "NumExpediente";
                cmb_ExpedienteProyeccion.ValueMember = "NumExpediente";
                cmb_ExpedienteProyeccion.DataSource = _ceriv.ExpedienteCreditoMostrar(cmb_OperacionProyeccion.SelectedValue.ToString());
                    
            }

            //EVENTOS DE PROYECCION

            private void cmb_ExpedienteProyeccion_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_ExpedienteProyeccion.SelectedIndex != -1)
                {
                    CargarProyeccion();
                    BloquearProyeccion();
                    btn_ModificarProyeccion.Enabled = true;
                    btn_GuardarProyeccion.Enabled = false;
                }
            }
            private void cmb_OperacionProyeccion_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_OperacionProyeccion.SelectedIndex != -1)
                {
                    cmb_ExpedienteProyeccion.SelectedIndex = -1;
                    cmb_ExpedienteProyeccion.Text = "";
                    limpiarProyeccion();
                    ActivarProyeccion();
                    btn_GuardarProyeccion.Enabled = true;
                    btn_ModificarProyeccion.Enabled = false;
                    CargarExpedienteProyeccion();
                }

            }

            // -------------------------------------------------
            //
            //        

        /*HISTORICO*/

            //BOTONES DE HISTORICO

            private void btn_Historico_Click(object sender, EventArgs e)
            {
                C_Historico objeto = new C_Historico();
                //
                if (cmb_ExpedientesHistorico.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Expediente, Por Favor");
                    return;
                }
                else
                {
                    objeto.Expediente = cmb_ExpedientesHistorico.SelectedValue.ToString();
                }
                //
                if (txt_Historico.Text == string.Empty)
                    objeto.Texto = " ";
                objeto.Texto = txt_Historico.Text;
                //
                if (txt_Llamada.Text == string.Empty)
                    objeto.Llamada = " ";
                objeto.Llamada = txt_Llamada.Text;
                //
                if (txt_Campo.Text == string.Empty)
                    objeto.Campo = " ";
                objeto.Campo = txt_Campo.Text;
                //
                if (_ceriv.Historico(1, objeto))
                {
                    MessageBox.Show("Se ingreso Historico Correctamente");
                    CargarHistorico();
                    //CargarComboBoxExpedienteCredito();
                    
                }
                else
                {
                    MessageBox.Show("Revise los Datos, Por Favor");
                }
            }

            //FUNCIONES DE HISTORICO

            public void CargarHistorico()
            {
                if (cmb_ExpedientesHistorico.SelectedIndex != -1)
                {
                    C_Historico objetoHistorico = _ceriv.HistoricoMostrar1(cmb_ExpedientesHistorico.SelectedValue.ToString());
                    txt_Historico.Text = objetoHistorico.Texto;
                    txt_Llamada.Text = objetoHistorico.Llamada;
                    txt_Campo.Text = objetoHistorico.Campo;
                }
            }
            public void limpiarhistorico()
            {
                txt_Historico.Clear();
                txt_Llamada.Clear();
                txt_Campo.Clear();
            }
            public void CargarExpedienteHistorico()
            {
                cmb_ExpedientesHistorico.DisplayMember = "NumExpediente";
                cmb_ExpedientesHistorico.ValueMember = "NumExpediente";
                cmb_ExpedientesHistorico.DataSource = _ceriv.ExpedienteCreditoMostrar(cmb_OperacionHistorico.SelectedValue.ToString()); 
            }
            public void CargarOperacionHistorico()
            {
                cmb_OperacionHistorico.DisplayMember = "Operacion";
                cmb_OperacionHistorico.ValueMember = "Operacion";
                cmb_OperacionHistorico.DataSource = _ceriv.OperacionMostrar(txt_CuentaBT.Text);
            }

            //EVENTOS DE HISTORICO
            private void cmb_ExpedientesHistorico_SelectedIndexChanged(object sender, EventArgs e)
            {
                limpiarhistorico();
                btn_GuardarHistorico.Enabled = true;
                CargarHistorico();
            }
            private void cmb_OperacionHistorico_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_OperacionHistorico.SelectedIndex != -1)
                {
                    cmb_ExpedientesHistorico.SelectedIndex = -1;
                    cmb_ExpedientesHistorico.Text = "";
                    limpiarhistorico();
                    
                    CargarExpedienteHistorico();
                }
            }

            // -------------------------------------------------
            //
            //        


        /*UBICACION*/

            //BOTONES UBICACION

            private void btn_GuardarUbicacion_Click(object sender, EventArgs e)
            {
                C_Ubicacion ubicacion = new C_Ubicacion();
                //
                if (_banderaImagen)
                {
                    ubicacion.Imagen = Image2Bytes(pic_Imagen.Image);
                    _banderaImagen = false;
                }
                else
                {
                    ubicacion.Imagen = _imagenGlobal;
                }
                //
                ubicacion.Url = txt_direccion.Text;
                //
                ubicacion.NumExpediente = cmb_ExpedienteUbicacion.SelectedValue.ToString();
                //
                ubicacion.Codigo = Int32.Parse(lbl_CodigoUbicacion.Text);
                //
                ubicacion.Id_tipoUbicacion = Int32.Parse(cmb_TipoUbicacion.SelectedValue.ToString());
                //
                if (chk_Ubicacion.Checked == true)
                {
                    ubicacion.Visita = 1;
                }
                else {
                    ubicacion.Visita = 0;
                }
                if (_ceriv.Ubicacion(1, ubicacion))
                {
                    MessageBox.Show("Ingreso correctamente");
                }
                else
                {
                    MessageBox.Show("Error al ingresar");
                }
            }
            private void button1_Click_1(object sender, EventArgs e)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Archivo JPG|*.jpg";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    _banderaImagen = true;
                    pic_Imagen.Image = Image.FromFile(fileDialog.FileName);
                }
            }
            private void btn_TipoUbicacion_Click(object sender, EventArgs e)
            {

            }

            //FUNCIONES UBICACION

            private void CargarUbicacion()
            {
                _banderaImagen = false;
                if (cmb_ExpedienteUbicacion.SelectedIndex != -1)
                {
                    C_Ubicacion objeto = (_ceriv.UbicacionMostrar1(cmb_ExpedienteUbicacion.SelectedValue.ToString()));
                    lbl_CodigoUbicacion.Text = objeto.Codigo.ToString();
                    txt_direccion.Text = objeto.Url;
                    cmb_TipoUbicacion.SelectedValue = objeto.Id_tipoUbicacion;
                    _imagenGlobal = objeto.Imagen;
                    pic_Imagen.Image = Bytes2Image(objeto.Imagen);
                    try
                    {
                        webBrowser1.Navigate(txt_direccion.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error");
                    }

                }
            }
            public void CargarUbicacionPorTipoUbicacion()
            {
                if (cmb_TipoUbicacion.SelectedIndex != -1)
                {
                    if (cmb_ExpedienteUbicacion.SelectedValue != null)
                    {
                        C_Ubicacion objeto = (_ceriv.UbicacionMostrar2(cmb_ExpedienteUbicacion.SelectedValue.ToString(), Int32.Parse(cmb_TipoUbicacion.SelectedValue.ToString())));
                        lbl_CodigoUbicacion.Text = objeto.Codigo.ToString();
                        txt_direccion.Text = objeto.Url;

                        if (objeto.Visita == 1)
                        {
                            chk_Ubicacion.Checked = true;
                        }
                        else
                        {
                            chk_Ubicacion.Checked = false;
                        }
                        _imagenGlobal = objeto.Imagen;
                        pic_Imagen.Image = Bytes2Image(objeto.Imagen);
                        try
                        {
                            webBrowser1.Navigate(txt_direccion.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Error");
                        }
                    }
                    else
                    {
                        btn_GuardarUbicacion.Enabled = false;
                    }
                }
            }
            public void LimpiarUbicacion()
            {
                pic_Imagen.Image = null;
                webBrowser1.Refresh();
                txt_direccion.Clear();
                txt_imgUrl.Clear();
                lbl_CodigoUbicacion.Text = "0";
                chk_Ubicacion.Checked = false;
            }
            public void CargarOperacionUbicacion()
            {
                cmb_OperacionUbicacion.DisplayMember = "Operacion";
                cmb_OperacionUbicacion.ValueMember = "Operacion";
                cmb_OperacionUbicacion.DataSource = _ceriv.OperacionMostrar(txt_CuentaBT.Text);
            }

            public void CargarTipoUbicacion() {
                cmb_TipoUbicacion.DisplayMember = "NombreTipoUbicacion";
                cmb_TipoUbicacion.ValueMember = "IdTipoUbicacion";
                cmb_TipoUbicacion.DataSource = _ceriv.TipoUbicacionMostrar();
            }

            public void CargarExpedienteUbicacion()
            {
                cmb_ExpedienteUbicacion.DisplayMember = "NumExpediente";
                cmb_ExpedienteUbicacion.ValueMember = "NumExpediente";
                cmb_ExpedienteUbicacion.DataSource = _ceriv.ExpedienteCreditoMostrar(cmb_OperacionUbicacion.SelectedValue.ToString());

            }


            public static byte[] Image2Bytes(Image pImagen)
            {
                ImageConverter converter = new ImageConverter();
                return (byte[])converter.ConvertTo(pImagen, typeof(byte[]));
            }
            public static Image Bytes2Image(byte[] bytes)
            {
                if (bytes == null) return null;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    Bitmap bm = null;
                    try
                    {
                        bm = new Bitmap(ms);
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                    return bm;
                }
            }

            //EVENTOS UBICACION

            private void cmb_TipoUbicacion_SelectedIndexChanged(object sender, EventArgs e)
            {
                _banderaImagen = false;
                if (cmb_TipoUbicacion.SelectedIndex != -1)
                {
                   // LimpiarUbicacion();
                    CargarUbicacionPorTipoUbicacion();
                    
                }
            }
            private void cmb_ExpedienteUbicacion_SelectedIndexChanged(object sender, EventArgs e)
            {
                //             if (cmb_ExpedienteUbicacion.SelectedIndex != -1)
                //             {
                //                 LimpiarUbicacion();
                //                 CargarUbicacion();
                //             }
            }
            private void cmb_OperacionUbicacion_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_OperacionUbicacion.SelectedIndex != -1)
                {
                    cmb_ExpedienteUbicacion.SelectedIndex = -1;
                    cmb_ExpedienteUbicacion.Text = "";
                    LimpiarUbicacion();
                    CargarExpedienteUbicacion();
                }
            }
            private void txt_direccion_TextChanged(object sender, EventArgs e)
            {
                try
                {
                    webBrowser1.Navigate(txt_direccion.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error");
                }
            }


        /*ESCRITOS*/
            
            //FUNCIONES ESCRITOS

            public void CargarOperacionEscritos() 
            {
                cmb_OperacionEscritos.DisplayMember = "Operacion";
                cmb_OperacionEscritos.ValueMember = "Operacion";
                cmb_OperacionEscritos.DataSource = _ceriv.OperacionMostrar(txt_CuentaBT.Text);
            }
            public void CargarExpedienteEscritos()
            {
                cmb_ExpedientesEscritos.DisplayMember = "NumExpediente";
                cmb_ExpedientesEscritos.ValueMember = "NumExpediente";
                cmb_ExpedientesEscritos.DataSource = _ceriv.ExpedienteCreditoMostrar(cmb_OperacionEscritos.SelectedValue.ToString());
            }


            public void WordAbDePr( ) 
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\ABSDEVPRI.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //Variables
                string num_expediente, secretario, num_juzgado, lugar_juzgado,nom_cartera, tipo_proceso, nom_garante, domicilio_garante, distrito_garante,
                    nom_titular, dir_titular, dis_titular, ciu_titular, fecha;
                string georeferencia_garante, georeferencia_titular;
                int codigo_ciudad, codigo_cartera, codigo_proceso, codigo_distritoG;
                byte[] imagen_garante, imagen_titular;

                //definición de variables
                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                codigo_ciudad = objCredito.CodigoCiudad;
                codigo_cartera = objCredito.CodigoCartera;
                C_Ciudad objCiudad = _ceriv.CiudadMostrar1(codigo_ciudad);
                C_Cartera objCartera = _ceriv.CarteraMostrar1(codigo_cartera);
                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
                codigo_proceso = objExpediente.CodigoTipoProceso;
                C_TipoProceso objProceso = _ceriv.ProcesoMostrar1(codigo_proceso);
                C_Garante objGarante = _ceriv.CargarDatosGaranteEscritos(cmb_OperacionEscritos.Text);
                codigo_distritoG = objGarante.CodigoDistrito;
                C_Distrito objDistrito = _ceriv.DistritoMostrar1(codigo_distritoG);
                C_Ubicacion objUbicacion = _ceriv.UbicacionMostrar2(cmb_ExpedientesEscritos.Text, 1);
                C_Ubicacion objUbicacion2 = _ceriv.UbicacionMostrar2(cmb_ExpedientesEscritos.Text, 3);

                num_expediente = cmb_ExpedientesEscritos.Text;
                secretario = objExpediente.TrabajadorSecretario;
                num_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nom_cartera = objCartera.NombreCartera;
                tipo_proceso = objProceso.NombreProceso;
                nom_garante = objGarante.NombreCompleto;
                domicilio_garante = objGarante.DomicilioGarante;
                distrito_garante = objDistrito.NombreDistrito; 
                nom_titular = txt_NombreTitular.Text;
                dir_titular = txt_DomicilioTitular.Text;
                dis_titular = cmb_DistritoTitular.Text;
                ciu_titular = objCiudad.NombreCiudad;
                fecha = DateTime.Now.ToString("dd De MMMM Del yyyy");
                georeferencia_garante = objUbicacion.Url;
                imagen_garante = objUbicacion.Imagen;
                georeferencia_titular = objUbicacion2.Url;
                imagen_titular = objUbicacion2.Imagen;

                //
                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);

                        fieldName = fieldName.Trim();
                        if (fieldName == "num_expediente")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_expediente);
                        }
                        else if (fieldName == "secretario")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(secretario);
                        }
                        else if (fieldName == "num_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_juzgado);
                        }
                        else if (fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if (fieldName == "nom_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_cartera);
                        }
                        else if (fieldName == "tipo_proceso")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(tipo_proceso);
                        }
                        else if (fieldName == "nom_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_garante);
                        }
                        else if (fieldName == "domicilio_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(domicilio_garante);
                        }
                        else if (fieldName == "distrito_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(distrito_garante);
                        }
                        else if (fieldName == "nom_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_titular);
                        }
                        else if (fieldName == "dir_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(dir_titular);
                        }
                        else if (fieldName == "dis_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(dis_titular);
                        }
                        else if (fieldName == "ciu_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(ciu_titular);
                        }
                        else if (fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha);
                        }
                        else if (fieldName == "georeferencia_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(georeferencia_garante);
                        }
                        else if (fieldName == "georeferencia_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(georeferencia_titular);
                        }

                    }
                }

                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e) 
                {
                }

                //wordDoc.SaveAs("Absuelto-devolución-principal-"+nom_titular+".docx");
                //objWord.Documents.Open("Absuelto-devolución-principal-" + nom_titular + ".docx");
               
            }
            public void WordAdInOt( ) 
            {

                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\ADJINSOTR.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);


                //Variables
                string cod_cautelar, num_expediente,secretario, num_juzgado, lugar_juzgado, nom_cartera, nom_titular, tipo_proceso, fecha1;
                Int32 codigo_cartera, codigo_proceso;

                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
                codigo_proceso = objExpediente.CodigoTipoProceso;
                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                codigo_cartera = objCredito.CodigoCartera;
                C_Cartera objCartera = _ceriv.CarteraMostrar1(codigo_cartera);
                C_TipoProceso objTProceso = _ceriv.ProcesoMostrar1(codigo_proceso);

                cod_cautelar = objExpediente.CodigoCautelar;
                num_expediente = cmb_ExpedientesEscritos.Text;
                secretario = objExpediente.TrabajadorSecretario;
                num_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nom_cartera = objCartera.NombreCartera;
                nom_titular = txt_NombreTitular.Text;
                tipo_proceso = objTProceso.NombreProceso;                
                fecha1 = DateTime.Now.ToString("dd De MMMM Del yyyy");

                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "cod_cautelar")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(cod_cautelar);
                        }
                        else if (fieldName == "num_expediente")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_expediente);
                        }
                        else if (fieldName == "secretario")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(secretario);
                        }
                        else if (fieldName == "num_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_juzgado);
                        }
                        else if (fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if (fieldName == "nom_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_cartera);
                        }
                        else if (fieldName == "nom_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_titular);
                        }
                        else if (fieldName == "tipo_proceso")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(tipo_proceso);
                        }
                        else if (fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha1);
                        }
                    }
                }

                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }
                //wordDoc.SaveAs("Adjunto-Inscripción-y-Otros-" + nom_titular + ".docx");
                //objWord.Documents.Open("Adjunti-Inscripción-y-Otros-" + nom_titular + ".docx");

            }
            public void WordAuFi( ) 
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\AUTFIN.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //variables
                string num_expediente, secretario, num_juzgado, lugar_juzgado, nom_cartera, tipo_proceso, nom_titular, fecha;
                Int32 codigo_cartera, codigo_proceso;

                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
                codigo_proceso = objExpediente.CodigoTipoProceso;
                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                codigo_cartera = objCredito.CodigoCartera;
                C_Cartera objCartera = _ceriv.CarteraMostrar1(codigo_cartera);
                C_TipoProceso objProceso = _ceriv.ProcesoMostrar1(codigo_proceso);
                
                num_expediente = cmb_ExpedientesEscritos.Text;
                secretario = objExpediente.TrabajadorSecretario;
                num_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nom_cartera = objCartera.NombreCartera;
                tipo_proceso = objProceso.NombreProceso;
                nom_titular = txt_NombreTitular.Text;
                fecha = DateTime.Now.ToString("dd De MMMM Del yyyy");


                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "num_expediente")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_expediente);
                        }
                        else if(fieldName == "secretario")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(secretario);
                        }
                        else if (fieldName == "num_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_juzgado);
                        }
                        else if (fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if (fieldName == "nom_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_cartera);
                        }
                        else if (fieldName == "tipo_proceso")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(tipo_proceso);
                        }
                        else if (fieldName == "nom_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_titular);
                        }
                        else if (fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha);
                        }
                    }
                }

                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }
                //wordDoc.SaveAs("Auto-Final-" + nom_titular + ".docx");
                //objWord.Documents.Open("Auto-Final-" + nom_titular + ".docx");

            }
            public void WordConPro( ) 
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\CONPRO.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //variables
                string num_expediente, secretario, num_juzgado, lugar_juzgado, nombre_cartera, tipo_proceso, nom_titular, fecha;
                Int32 codigo_cartera, codigo_proceso;

                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
                codigo_proceso = objExpediente.CodigoTipoProceso;
                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                codigo_cartera = objCredito.CodigoCartera;
                C_Cartera objCartera = _ceriv.CarteraMostrar1(codigo_cartera);
                C_TipoProceso objProceso = _ceriv.ProcesoMostrar1(codigo_proceso);


                num_expediente = cmb_ExpedientesEscritos.Text;
                secretario = objExpediente.TrabajadorSecretario;
                num_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nombre_cartera = objCartera.NombreCartera;
                tipo_proceso = objProceso.NombreProceso;
                nom_titular = txt_NombreTitular.Text;
                fecha = DateTime.Now.ToString("dd De MMMM Del yyyy");

                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "num_expediente")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_expediente);
                        }
                        else if(fieldName == "secretario")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(secretario);
                        }
                        else if (fieldName == "num_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_juzgado);
                        }
                        else if (fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if (fieldName == "nombre_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_cartera);
                        }
                        else if (fieldName == "tipo_proceso")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(tipo_proceso);
                        }
                        else if (fieldName == "NOM_TITULAR")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_titular);
                        }
                        else if (fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha);
                        }
                    }
                }

                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }
                //wordDoc.SaveAs("Conclusión-De-Proceso-" + nom_titular + ".docx");
                //objWord.Documents.Open("Conclusión-De-Proceso-" + nom_titular + ".docx");
            }
            public void WordDeEjGa( ) 
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\DEMEJEGAR.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //Variables
                string num_juzgado, lugar_juzgado, nom_cartera, nomtitu, dirtitu, distitu, deptitu, tipo_proceso, descripcion, ciudad_bien, partidaplaca, 
                    signo_moneda, montodemandado, nombre_moneda, valor_comercial, mongaran, fecha, nombre_garante, domicilio_garante, distrito_garante, nombre_cony, cony_garante;
                Int32 codtitu, codigo_moneda, codigo_cartera, codigo_proceso;

                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
                codigo_proceso = objExpediente.CodigoTipoProceso;
                C_TipoProceso objProceso = _ceriv.ProcesoMostrar1(codigo_proceso);
                C_Bien objBien = _ceriv.CargarDatosEscritos(cmb_ExpedientesEscritos.Text);
                C_Bien objeBien = _ceriv.CargarMontoAdmitido(cmb_OperacionEscritos.Text);
                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                codtitu = objCredito.CodigoCiudad;
                codigo_moneda = objCredito.CodigoMoneda;
                codigo_cartera = objCredito.CodigoCartera;
                C_Ciudad objCiudad = _ceriv.CiudadMostrar1(codtitu);
                C_Cartera objCartera = _ceriv.CarteraMostrar1(codigo_cartera);
                C_Moneda objMoneda = _ceriv.MonedaMostrar1(codigo_moneda);
                C_Garante objGarante = _ceriv.CargarDatosGaranteEscritos(cmb_OperacionEscritos.Text);
                C_Distrito objDistrito = _ceriv.DistritoMostrar1(objGarante.CodigoDistrito);

                signo_moneda = objMoneda.NombreMoneda;
                if(signo_moneda == "Soles")
                {
                    signo_moneda = "S/.";
                }
                else if (signo_moneda == "Dolares") 
                {
                    signo_moneda = "$/.";
                }

                //
                num_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nom_cartera = objCartera.NombreCartera;
                nomtitu = txt_NombreTitular.Text;
                dirtitu = txt_DomicilioTitular.Text;
                distitu = cmb_DistritoTitular.Text;
                deptitu = objCiudad.NombreCiudad;
                nombre_cony = txt_NombreConyuge.Text;
                nombre_garante = objGarante.NombreCompleto;
                cony_garante = objGarante.NombreConyuge;
                domicilio_garante = objGarante.DomicilioGarante;
                distrito_garante = objDistrito.NombreDistrito;
                tipo_proceso = objProceso.NombreProceso;
                descripcion = objBien.Descripcion;
                ciudad_bien = objCiudad.NombreCiudad;
                partidaplaca = objBien.PartidaPlaca;
                //signo moneda
                montodemandado = objeBien.MontoDemandado;
                nombre_moneda = objMoneda.NombreMoneda;
                valor_comercial = objBien.ValorComercial;
                mongaran = objBien.MontoGarantia;
                fecha = DateTime.Now.ToString("dd De MMMM Del yyyy");

                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "num_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_juzgado);
                        }
                        else if (fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if (fieldName == "nom_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_cartera);
                        } 
                        else if (fieldName == "nom_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nomtitu);
                        }
                        else if (fieldName == "dire_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(dirtitu);
                        }
                        else if (fieldName == "dis_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(distitu);
                        }
                        else if(fieldName == "dep_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(deptitu);
                        }
                        else if (fieldName == "nombre_cony") 
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_cony);
                        }
                        else if (fieldName == "nombre_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_garante);
                        }
                        else if (fieldName == "cony_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(cony_garante);
                        }
                        else if (fieldName == "domicilio_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(domicilio_garante);
                        }
                        else if (fieldName == "distrito_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(distrito_garante);
                        }
                        else if (fieldName == "tipo_proceso")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(tipo_proceso);
                        }
                        else if (fieldName == "dir_bien")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(descripcion);
                        }
                        else if (fieldName == "ciudad_bien")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(ciudad_bien);
                        }
                        else if (fieldName == "par_placa")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(partidaplaca);
                        }
                        else if (fieldName == "signo_moneda")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(signo_moneda);
                        }
                        else if (fieldName == "monto_demandado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(montodemandado);
                        }
                        else if (fieldName == "nombre_moneda")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_moneda);
                        }
                        else if (fieldName == "valor_comercial")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(valor_comercial);
                        }
                        else if (fieldName == "monto_garantia")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(mongaran);
                        }
                        else if (fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha);
                        }                        
                    }
                }
                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }
                //wordDoc.SaveAs("Demanda-Ejecución-De-Garantías-" + nomtitu + ".docx");
                //objWord.Documents.Open("Demanda-Ejecución-De-Garantías-" + nomtitu + ".docx");

            }
            public void WordDeMiNi( )
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\DEMIINC.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //variables
                string num_juzgado, lugar_juzgado, nombre_cartera, nom_titular, dir_titular, dis_titular, ciu_titular, cony_titular,
                    desc_bien, moneda_signo, monto_admitido, nombre_moneda, num_operacion, partida_placa, fecha, nombre_garante, domicilio_garante, distrito_garante, cony_garante;
                Int32 codigo_ciudad, codigo_moneda, codigo_cartera;

                //Asignación de variables


                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                codigo_ciudad = objCredito.CodigoCiudad;
                codigo_moneda = objCredito.CodigoMoneda;
                codigo_cartera = objCredito.CodigoCartera;
                C_Cartera objCartera = _ceriv.CarteraMostrar1(codigo_cartera);
                C_Ciudad objCiudad = _ceriv.CiudadMostrar1(codigo_ciudad);
                C_Moneda objMoneda = _ceriv.MonedaMostrar1(codigo_moneda);
                C_Bien objBien = _ceriv.CargarDatosEscritos(cmb_ExpedientesEscritos.Text);
                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
                C_Garante objGarante = _ceriv.CargarDatosGaranteEscritos(cmb_OperacionEscritos.Text);
                C_Distrito objDistrito = _ceriv.DistritoMostrar1(objGarante.CodigoDistrito);

                moneda_signo = objMoneda.NombreMoneda;
                if (moneda_signo == "Soles")
                    moneda_signo = "S/.";
                else if (moneda_signo == "Dolares")
                    moneda_signo = "$/.";

                //
                num_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nombre_cartera = objCartera.NombreCartera;
                nom_titular = txt_NombreTitular.Text;
                dir_titular = txt_DomicilioTitular.Text;
                dis_titular = cmb_DistritoTitular.Text;
                ciu_titular = objCiudad.NombreCiudad;
                cony_titular = txt_NombreConyuge.Text;
                nombre_garante = objGarante.NombreCompleto;
                domicilio_garante = objGarante.DomicilioGarante;
                distrito_garante = objDistrito.NombreDistrito;
                cony_garante = objGarante.NombreConyuge;
                desc_bien = objBien.Descripcion;
                //moneda signo
                monto_admitido = objCredito.MontoAdmitido;
                nombre_moneda = objMoneda.NombreMoneda;
                num_operacion = cmb_OperacionEscritos.Text;
                partida_placa = objBien.PartidaPlaca;
                fecha = DateTime.Now.ToString("dd De MMMM Del yyyy");


                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "num_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_juzgado);
                        }
                        else if (fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if (fieldName == "nombre_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_cartera);
                        }
                        else if (fieldName == "nom_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_titular);
                        }
                        else if (fieldName == "dir_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(dir_titular);
                        }
                        else if (fieldName == "dis_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(dis_titular);
                        }
                        else if (fieldName == "ciu_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(ciu_titular);
                        }
                        else if (fieldName == "cony_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(cony_titular);
                        }
                        else if (fieldName == "nombre_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_garante);
                        }
                        else if (fieldName == "domicilio_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(domicilio_garante);
                        }
                        else if (fieldName == "distrito_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(distrito_garante);
                        }
                        else if(fieldName == "cony_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(cony_garante);
                        }
                        else if (fieldName == "desc_bien")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(desc_bien);
                        }
                        else if (fieldName == "moneda_signo")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(moneda_signo);
                        }
                        else if (fieldName == "monto_admitido")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(monto_admitido);
                        }
                        else if (fieldName == "nombre_moneda")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_moneda);
                        }
                        else if (fieldName == "num_operacion")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_operacion);
                        }
                        else if (fieldName == "partida_placa")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(partida_placa);
                        }
                        else if (fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha);
                        }

                    }
                }

                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }
                //wordDoc.SaveAs("Demanda-Incautación-" + nom_titular + ".docx");
                //objWord.Documents.Open("Demanda-Incautación-" + nom_titular + ".docx");


            }
            public void WordDeODSDPu( ) 
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\DEMODSDPUR.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //variables
                string num_juzgado, lugar_juzgado, nom_cartera,  nom_titular, dir_titular, dis_titular, ciu_titular, cony_titular, moneda_signo, monto_admitido, 
                    nombre_moneda, num_operacion, fecha, nombre_garante, domicilio_garante, distrito_garante, cony_garante;
                Int32 codigo_ciudad, codigo_moneda, codigo_cartera;

                //Asignación de variables


                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                codigo_ciudad = objCredito.CodigoCiudad;
                codigo_moneda = objCredito.CodigoMoneda;
                codigo_cartera = objCredito.CodigoCartera;
                C_Ciudad objCiudad = _ceriv.CiudadMostrar1(codigo_ciudad);
                C_Moneda objMoneda = _ceriv.MonedaMostrar1(codigo_moneda);
                C_Bien objBien = _ceriv.CargarDatosEscritos(cmb_ExpedientesEscritos.Text);
                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
                C_Cartera objCartera = _ceriv.CarteraMostrar1(codigo_cartera);
                C_Garante objGarante = _ceriv.CargarDatosGaranteEscritos(cmb_OperacionEscritos.Text);
                C_Distrito objDistrito = _ceriv.DistritoMostrar1(objGarante.CodigoDistrito);
                
                moneda_signo = objMoneda.NombreMoneda;
                if (moneda_signo == "Soles")
                    moneda_signo = "S/.";
                else if (moneda_signo == "Dolares")
                    moneda_signo = "$/.";

                num_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nom_cartera = objCartera.NombreCartera;
                nom_titular = txt_NombreTitular.Text;
                dir_titular = txt_DomicilioTitular.Text;
                dis_titular = cmb_DistritoTitular.Text;
                ciu_titular = objCiudad.NombreCiudad;
                nombre_garante = objGarante.NombreCompleto;
                domicilio_garante = objGarante.DomicilioGarante;
                distrito_garante = objDistrito.NombreDistrito;
                cony_garante = objGarante.NombreConyuge;
                cony_titular = txt_NombreConyuge.Text;
                //moneda_signo
                monto_admitido = objCredito.MontoAdmitido;
                nombre_moneda = objMoneda.NombreMoneda;
                num_operacion = cmb_OperacionEscritos.Text;
                fecha = DateTime.Now.ToString("dd De MMMM Del yyyy");
                
                
                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if(fieldName == "num_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_juzgado);
                        }
                        else if (fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if (fieldName == "nom_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_cartera);
                        }
                        else if (fieldName == "nom_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_titular);
                        }
                        else if (fieldName == "dir_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(dir_titular);
                        }
                        else if (fieldName == "dis_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(dis_titular);
                        }
                        else if (fieldName == "ciu_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(ciu_titular);
                        }
                        else if(fieldName == "nombre_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_garante);
                        }
                        else if (fieldName == "domicilio_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(domicilio_garante);
                        }
                        else if (fieldName == "distrito_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(distrito_garante);
                        }
                        else if(fieldName == "cony_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(cony_garante);
                        }
                        else if (fieldName == "cony_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(cony_titular);
                        }
                        else if (fieldName == "moneda_signo")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(moneda_signo);
                        }
                        else if (fieldName == "monto_admitido")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(monto_admitido);
                        }
                        else if (fieldName == "nombre_moneda")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_moneda);
                        }
                        else if (fieldName == "num_operacion")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_operacion);
                        }
                        else if (fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha);
                        }

                    }
                }

                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }
                //wordDoc.SaveAs("Demanda-ODSD-Pura-" + nom_titular + ".docx");
                //objWord.Documents.Open("Demanda-ODSD-Pura-" + nom_titular + ".docx");

            }
            public void WordInDePr( ) 
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\INTDEMPRI.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //variables
                string cod_cautelar, num_expediente,nombre_secretario, num_juzgado, lugar_juzgado, nombre_cartera, nom_titular, dir_titular, dis_titular, ciu_titular, 
                    cony_titular, moneda_logo, monto_admitido, nombre_moneda, num_operacion, fecha, nombre_garante, domicilio_garante, distrito_garante, cony_garante;
                Int32 codigo_ciudad, codigo_moneda, codigo_cartera;

                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);               
                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                codigo_ciudad = objCredito.CodigoCiudad;
                codigo_moneda = objCredito.CodigoMoneda;
                codigo_cartera = objCredito.CodigoCartera;
                C_Ciudad objCiudad = _ceriv.CiudadMostrar1(codigo_ciudad);
                C_Moneda objMoneda = _ceriv.MonedaMostrar1(codigo_moneda);
                C_Cartera objCartera = _ceriv.CarteraMostrar1(codigo_cartera);
                C_Garante objGarante = _ceriv.CargarDatosGaranteEscritos(cmb_OperacionEscritos.Text);
                C_Distrito objDistrito = _ceriv.DistritoMostrar1(objGarante.CodigoDistrito);

                //Asignación variables 

                cod_cautelar = objExpediente.CodigoCautelar;           
                num_expediente = cmb_ExpedientesEscritos.Text;
                nombre_secretario = objExpediente.TrabajadorSecretario;
                num_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nombre_cartera = objCartera.NombreCartera;
                nom_titular = txt_NombreTitular.Text;
                dir_titular = txt_DomicilioTitular.Text;
                dis_titular = cmb_DistritoTitular.Text;
                ciu_titular = objCiudad.NombreCiudad;
                nombre_garante = objGarante.NombreCompleto;
                domicilio_garante = objGarante.DomicilioGarante;
                distrito_garante = objDistrito.NombreDistrito;
                cony_garante = objGarante.NombreConyuge;
                cony_titular = txt_NombreConyuge.Text;
                moneda_logo = objMoneda.NombreMoneda;
                if (moneda_logo == "Soles")
                    moneda_logo = "S/.";
                else if (moneda_logo == "Dolares")
                    moneda_logo = "$/.";
                monto_admitido = objCredito.MontoAdmitido;
                nombre_moneda = objMoneda.NombreMoneda;
                num_operacion = cmb_OperacionEscritos.Text;
                fecha = DateTime.Now.ToString("dd De MMMM Del yyyy");

                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "cod_cautelar")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(cod_cautelar);
                        }
                        else if (fieldName == "num_expediente")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_expediente);
                        }
                        else if (fieldName == "nombre_secretario")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_secretario);
                        }
                        else if (fieldName == "num_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_juzgado);
                        }
                        else if (fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if (fieldName == "nombre_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_cartera);
                        }
                        else if (fieldName == "nom_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_titular);
                        }
                        else if (fieldName == "dir_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(dir_titular);
                        }
                        else if (fieldName == "dis_titular") 
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(dis_titular);
                        }
                        else if (fieldName == "ciu_titular") 
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(ciu_titular);
                        }
                        else if(fieldName == "nombre_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_garante);
                        }
                        else if (fieldName == "domicilio_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(domicilio_garante);
                        }
                        else if (fieldName == "distrito_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(distrito_garante);
                        }
                        else if (fieldName == "cony_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(cony_garante);
                        }
                        else if (fieldName == "cony_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(cony_titular);
                        }
                        else if (fieldName == "moneda_logo")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(moneda_logo);
                        }
                        else if (fieldName == "monto_admitido")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(monto_admitido);
                        }
                        else if (fieldName == "nombre_moneda")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_moneda);
                        }
                        else if (fieldName == "num_operacion")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_operacion);
                        }
                        else if (fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha);
                        }

                    }
                }

                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }
               // wordDoc.SaveAs("Interpone-Demanda-Principal-" + nom_titular + ".docx");
               // objWord.Documents.Open("Interpone-Demanda-Principal-" + nom_titular + ".docx");

            }
            public void WordMeCaFuPr()
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\MEDCAUFUEPRO.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //Variables
                string numero_juzgado, lugar_juzgado, nombre_cartera, nom_titular, dir_titular, dis_titular, ciu_titular, monto_garantia_embargo, descripcion_bien, ciudad_bien,
                    partida_placa, num_operacion, moneda_logo, monto_admitido, nombre_moneda, fecha, nombre_garante, domicilio_garante, distrito_garante, nombre_cony, cony_garante;
                Int32 codigo_cartera, codigo_ciudad, codigo_ciudad_bien, codigo_moneda;

                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                codigo_cartera = objCredito.CodigoCartera;
                codigo_ciudad = objCredito.CodigoCiudad;
                codigo_moneda = objCredito.CodigoMoneda;
                C_Moneda objMoneda = _ceriv.MonedaMostrar1(codigo_moneda);
                C_Ciudad objCiudad = _ceriv.CiudadMostrar1(codigo_ciudad);
                C_Cartera objCartera = _ceriv.CarteraMostrar1(codigo_cartera);
                C_Bien objBien = _ceriv.CargarDatosEscritos(cmb_ExpedientesEscritos.Text);
                codigo_ciudad_bien = objBien.Codigo_ciudad;
                C_Ciudad obj1Ciudad = _ceriv.CiudadMostrar1(codigo_ciudad_bien);
                C_Garante objGarante = _ceriv.CargarDatosGaranteEscritos(cmb_Operacion.Text);
                C_Distrito objDistrito = _ceriv.DistritoMostrar1(objGarante.CodigoDistrito);


                numero_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nombre_cartera = objCartera.NombreCartera;
                nom_titular = txt_NombreTitular.Text;
                dir_titular = txt_DomicilioTitular.Text;
                dis_titular = cmb_DistritoTitular.Text;
                ciu_titular = objCiudad.NombreCiudad;
                nombre_cony = txt_NombreConyuge.Text;
                nombre_garante = objGarante.NombreCompleto;
                domicilio_garante = objGarante.DomicilioGarante;
                distrito_garante = objDistrito.NombreDistrito;
                cony_garante = objGarante.NombreConyuge;
                monto_garantia_embargo = objBien.MontoGarantia;
                descripcion_bien = objBien.Descripcion;
                ciudad_bien = obj1Ciudad.NombreCiudad;
                partida_placa = objBien.PartidaPlaca;
                num_operacion = cmb_OperacionEscritos.Text;
                moneda_logo = objMoneda.NombreMoneda;
                if (moneda_logo == "Soles")
                    moneda_logo = "S/.";
                else if (moneda_logo == "Dolares")
                    moneda_logo = "$/.";
                monto_admitido = objCredito.MontoAdmitido;
                nombre_moneda = objMoneda.NombreMoneda;
                fecha = DateTime.Now.ToString("dd De MMMM Del yyyy");

                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "numero_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(numero_juzgado);
                        }
                        else if (fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if (fieldName == "nombre_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_cartera);
                        }
                        else if (fieldName == "nom_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_titular);
                        }
                        else if (fieldName == "dir_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(dir_titular);
                        }
                        else if (fieldName == "dis_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(dis_titular);
                        }
                        else if (fieldName == "ciu_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(ciu_titular);
                        }
                        else if (fieldName == "nombre_cony")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_cony);
                        }
                        else if (fieldName == "nombre_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_garante);
                        }
                        else if (fieldName == "domicilio_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(domicilio_garante);
                        }
                        else if (fieldName == "distrito_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(distrito_garante);
                        }
                        else if(fieldName == "cony_garante")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(cony_garante);
                        }
                        else if (fieldName == "monto_garantia_embargo")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(monto_garantia_embargo);
                        }
                        else if (fieldName == "descripcion_bien")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(descripcion_bien);
                        }
                        else if (fieldName == "ciudad_bien")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(ciudad_bien);
                        }
                        else if (fieldName == "partida_placa")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(partida_placa);
                        }
                        else if (fieldName == "num_operacion")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_operacion);
                        }
                        else if (fieldName == "moneda_logo")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(moneda_logo);
                        }
                        else if (fieldName == "monto_admitido")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(monto_admitido);
                        }
                        else if (fieldName == "nombre_moneda")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_moneda);
                        }
                        else if (fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha);
                        }
                    }
                }
                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }
                //wordDoc.SaveAs("Medida-Cautelar-Fuera-De-Proceso-" + nom_titular + ".docx");
                //objWord.Documents.Open("Medida-Cautelar-Fuera-De-Proceso-" + nom_titular + ".docx");

            }
            public void WordLan( ) 
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\LAN.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //Variables
                string num_expediente, nombre_secretario, numero_juzgado, lugar_juzgado, nombre_cartera, tipo_proceso, nom_titular, partida_placa, fecha;
                Int32 codigo_cartera, codigo_proceso;

                C_Bien objBien = _ceriv.CargarDatosEscritos(cmb_ExpedientesEscritos.Text);
                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
                codigo_proceso = objExpediente.CodigoTipoProceso;
                C_TipoProceso objProceso = _ceriv.ProcesoMostrar1(codigo_proceso);
                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                codigo_cartera = objCredito.CodigoCartera;
                C_Cartera objCartera = _ceriv.CarteraMostrar1(codigo_cartera);
                //Asignación de Variables

                num_expediente = cmb_ExpedientesEscritos.Text;
                nombre_secretario = objExpediente.TrabajadorSecretario;
                numero_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nombre_cartera = objCartera.NombreCartera;
                tipo_proceso = objProceso.NombreProceso;
                nom_titular = txt_NombreTitular.Text;
                partida_placa = objBien.PartidaPlaca;
                fecha = DateTime.Now.ToString("dd De MMMM Del yyyy");

                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "num_expediente")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_expediente);
                        }
                        else if(fieldName == "nombre_secretario")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_secretario);
                        }
                        else if(fieldName == "numero_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(numero_juzgado);
                        }
                        else if(fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if(fieldName == "nombre_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_cartera);
                        }
                        else if (fieldName == "tipo_proceso")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(tipo_proceso);
                        }
                        else if (fieldName == "nom_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_titular);
                        }
                        else if (fieldName == "partida_placa")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(partida_placa);
                        }
                        else if (fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha);
                        }

                    }
                }
                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }
                //wordDoc.SaveAs("Lanzamiento-" + nom_titular + ".docx");
                //objWord.Documents.Open("Lanzamiento-" + nom_titular + ".docx");


            }
            public void WordLeMeCa( ) 
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\LEVMEDCAU.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //Variables
                string cod_cautelar, num_expediente, nombre_secretario, numero_juzgado, lugar_juzgado, nombre_cartera, tipo_proceso, nom_titular, partida_placa, fecha;
                Int32 codigo_cartera, codigo_proceso;

                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
                codigo_proceso = objExpediente.CodigoTipoProceso;
                C_TipoProceso objProceso = _ceriv.ProcesoMostrar1(codigo_proceso);
                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                codigo_cartera = objCredito.CodigoCartera;
                C_Cartera objCartera = _ceriv.CarteraMostrar1(codigo_cartera);
                C_Bien objBien = _ceriv.CargarDatosEscritos(cmb_ExpedientesEscritos.Text);


                cod_cautelar = objExpediente.CodigoCautelar;
                num_expediente = objExpediente.NumExpediente;
                nombre_secretario = objExpediente.TrabajadorSecretario;
                numero_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nombre_cartera = objCartera.NombreCartera;
                tipo_proceso = objProceso.NombreProceso;
                nom_titular = txt_NombreTitular.Text;
                partida_placa = objBien.PartidaPlaca;
                fecha = DateTime.Now.ToString("dd De MMMM Del yyyy");

                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "cod_cautelar")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(cod_cautelar);
                        }
                        else if(fieldName == "num_expediente")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_expediente);
                        }
                        else if (fieldName == "nombre_secretario")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_secretario);
                        }
                        else if (fieldName == "numero_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(numero_juzgado);
                        }
                        else if (fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if (fieldName == "nombre_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_cartera);
                        }
                        else if (fieldName == "tipo_proceso")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(tipo_proceso);
                        }
                        else if (fieldName == "nom_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_titular);
                        }
                        else if (fieldName == "partida_placa")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(partida_placa);
                        }
                        else if (fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha);
                        }
                    }
                }
                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }
                //wordDoc.SaveAs("Levantamiento-De-Medida-Cautelar-" + nom_titular + ".docx");
                //objWord.Documents.Open("Levantamiento-De-Medida-Cautelar-" + nom_titular + ".docx");

            }
            public void WordSoLiEx( ) 
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\SOLLIBEXH.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //Variables
                string num_expediente, nombre_secretario, numero_juzgado, lugar_juzgado, nombre_cartera, tipo_proceso, nom_titular, fecha;
                Int32 codigo_cartera, codigo_proceso;

                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
                codigo_proceso = objExpediente.CodigoTipoProceso;
                C_TipoProceso objProceso = _ceriv.ProcesoMostrar1(codigo_proceso);
                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                codigo_cartera = objCredito.CodigoCartera;
                C_Cartera objCartera = _ceriv.CarteraMostrar1(codigo_cartera);

                num_expediente = objExpediente.NumExpediente;
                nombre_secretario = objExpediente.TrabajadorSecretario;
                numero_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nombre_cartera = objCartera.NombreCartera;
                tipo_proceso = objProceso.NombreProceso;
                nom_titular = txt_NombreTitular.Text;
                fecha = fecha = DateTime.Now.ToString("dd De MMMM Del yyyy");

                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "num_expediente")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_expediente);
                        }
                        else if(fieldName == "nombre_secretario")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_secretario);
                        }
                        else if(fieldName == "numero_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(numero_juzgado);
                        }
                        else if (fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if (fieldName == "nombre_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_cartera);
                        }
                        else if (fieldName == "tipo_proceso")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(tipo_proceso);
                        }
                        else if (fieldName == "nom_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_titular);
                        }
                        else if (fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha);
                        }
                    }
                }
                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }
                //wordDoc.SaveAs("Solicito-Libre-Exhorto-" + nom_titular + ".docx");
                //objWord.Documents.Open("Solicito-Libre-Exhorto-" + nom_titular + ".docx");

            }
            public void WordSoOfCa( ) 
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\SOLOFICAP.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //Variables
                string num_expediente, nombre_secretario, numero_juzgado, lugar_juzgado, nombre_cartera, tipo_proceso, nom_titular, fecha;
                Int32 codigo_cartera, codigo_proceso;

                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
                codigo_proceso = objExpediente.CodigoTipoProceso;
                C_TipoProceso objProceso = _ceriv.ProcesoMostrar1(codigo_proceso);
                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                codigo_cartera = objCredito.CodigoCartera;
                C_Cartera objCartera = _ceriv.CarteraMostrar1(codigo_cartera);

                num_expediente = objExpediente.NumExpediente;
                nombre_secretario = objExpediente.TrabajadorSecretario;
                numero_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nombre_cartera = objCartera.NombreCartera;
                tipo_proceso = objProceso.NombreProceso;
                nom_titular = txt_NombreTitular.Text;
                fecha = fecha = DateTime.Now.ToString("dd De MMMM Del yyyy");

                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "num_expediente")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_expediente);
                        }
                        else if(fieldName == "nombre_secretario")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_secretario);
                        }
                        else if(fieldName == "numero_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(numero_juzgado);
                        }
                        else if(fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if(fieldName == "nombre_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_cartera);
                        }
                        else if( fieldName == "tipo_proceso")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(tipo_proceso);
                        }
                        else if(fieldName == "nom_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_titular);
                        }
                        else if(fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha);
                        }
                    }
                }
                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }
                //wordDoc.SaveAs("Solicito-Oficios-De-Captura-" + nom_titular + ".docx");
                //objWord.Documents.Open("Solicito-Oficios-De-Captura-" + nom_titular + ".docx");
            }
            public void WordSoOrRe( ) 
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\SOLORDREM.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //Variables
                string num_expediente, nombre_secretario, numero_juzgado, lugar_juzgado, nombre_cartera, tipo_proceso, nom_titular, fecha;
                Int32 codigo_cartera;

                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
                C_TipoProceso objProceso = _ceriv.ProcesoMostrar1(objExpediente.CodigoTipoProceso);
                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                codigo_cartera = objCredito.CodigoCartera;
                C_Cartera objCartera = _ceriv.CarteraMostrar1(codigo_cartera);

                num_expediente = objExpediente.NumExpediente;
                nombre_secretario = objExpediente.TrabajadorSecretario;
                numero_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nombre_cartera = objCartera.NombreCartera;
                tipo_proceso = objProceso.NombreProceso;
                nom_titular = txt_NombreTitular.Text;
                fecha = fecha = DateTime.Now.ToString("dd De MMMM Del yyyy");

                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "num_expediente")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_expediente);
                        }
                        else if(fieldName == "nombre_secretario")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_secretario);
                        }
                        else if (fieldName == "numero_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(numero_juzgado);
                        }
                        else if (fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if (fieldName == "nombre_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_cartera);
                        }
                        else if (fieldName == "tipo_proceso")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(tipo_proceso);
                        }
                        else if (fieldName == "nom_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_titular);
                        }
                        else if (fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha);
                        }
                    }
                }
                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }
               // wordDoc.SaveAs("Solicito-Orden-De-Remate-" + nom_titular + ".docx");
                //objWord.Documents.Open("Solicito-Orden-De-Remate-" + nom_titular + ".docx");
                
            }
            public void WordSoSeRe( ) 
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\SOLREQ.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //VARIABLES

                string num_expediente, nombre_secretario, numero_juzgado, lugar_juzgado, nombre_cartera, tipo_proceso, nom_titular, descripcion_bien, fecha;

                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
                C_TipoProceso objProceso = _ceriv.ProcesoMostrar1(objExpediente.CodigoTipoProceso);
                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                C_Cartera objCartera = _ceriv.CarteraMostrar1(objCredito.CodigoCartera);
                C_Bien objBien = _ceriv.CargarDatosEscritos(objExpediente.NumExpediente);

                num_expediente = objExpediente.NumExpediente;
                nombre_secretario = objExpediente.TrabajadorSecretario;
                numero_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nombre_cartera = objCartera.NombreCartera;
                tipo_proceso = objProceso.NombreProceso;
                nom_titular = txt_NombreTitular.Text;
                descripcion_bien = objBien.Descripcion;
                fecha = DateTime.Now.ToString("dd De MMMM Del yyyy");

                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "num_expediente")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_expediente);
                        }
                        else if(fieldName == "nombre_secretario")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_secretario);
                        }
                        else if (fieldName == "numero_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(numero_juzgado);
                        }
                        else if (fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if (fieldName == "nombre_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_cartera);
                        }
                        else if (fieldName == "tipo_proceso")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(tipo_proceso);
                        }
                        else if (fieldName == "nom_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_titular);
                        }
                        else if (fieldName == "descripcion_bien")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(descripcion_bien);
                        }
                        else if (fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha);
                        }

                    }
                }
                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }
                //wordDoc.SaveAs("Solicito-Se-Requiera-" + nom_titular + ".docx");
                //objWord.Documents.Open("Solicito-Se-Requiera-" + nom_titular + ".docx");          

            }
            public void WordSoTa( ) 
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\SOLTAS.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //variables
                string num_expediente, nombre_secretario, numero_juzgado, lugar_juzgado, nombre_cartera, tipo_proceso, nom_titular, fecha;

                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
                C_TipoProceso objProceso = _ceriv.ProcesoMostrar1(objExpediente.CodigoTipoProceso);
                C_Credito objCredito = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                C_Cartera objCartera = _ceriv.CarteraMostrar1(objCredito.CodigoCartera);

                num_expediente = objExpediente.NumExpediente;
                nombre_secretario = objExpediente.TrabajadorSecretario;
                numero_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nombre_cartera = objCartera.NombreCartera;
                tipo_proceso = objProceso.NombreProceso;
                nom_titular = txt_NombreTitular.Text;
                fecha = DateTime.Now.ToString("dd De MMMM Del yyyy");

                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "num_expediente")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_expediente);
                        }
                        else if(fieldName == "nombre_secretario")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_secretario);
                        }
                        else if (fieldName == "numero_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(numero_juzgado);
                        }
                        else if (fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if (fieldName == "nombre_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_cartera);
                        }
                        else if (fieldName == "tipo_proceso")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(tipo_proceso);
                        }
                        else if (fieldName == "nom_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_titular);
                        }
                        else if (fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha);
                        }


                    }
                }
                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }
//                wordDoc.SaveAs("Solicito-Tasación-" + nom_titular + ".docx");
 //               objWord.Documents.Open("Solicito-Tasación-" + nom_titular + ".docx");  

            }
            public void WordSuPe( ) 
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\SUBPER.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //VARIABLES
                string num_expediente, nombre_secretario, num_juzgado, lugar_juzgado, nombre_cartera, tipo_proceso, nom_titular, fecha;

                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
                C_TipoProceso objProceso = _ceriv.ProcesoMostrar1(objExpediente.CodigoTipoProceso);
                C_Credito objCretio = _ceriv.CreditoMostrar1(cmb_OperacionEscritos.Text);
                C_Cartera objCartera = _ceriv.CarteraMostrar1(objCretio.CodigoCartera);

                num_expediente = objExpediente.NumExpediente;
                nombre_secretario = objExpediente.TrabajadorSecretario;
                num_juzgado = objExpediente.NumJuzgado;
                lugar_juzgado = objExpediente.Juzgado;
                nombre_cartera = objCartera.NombreCartera;
                tipo_proceso = objProceso.NombreProceso;
                nom_titular = txt_NombreTitular.Text;
                fecha = DateTime.Now.ToString("dd De MMMM Del yyyy");

                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "num_expediente")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_expediente);
                        }
                        else if(fieldName == "nombre_secretario")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_secretario);
                        }
                        else if (fieldName == "num_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_juzgado);
                        }
                        else if (fieldName == "lugar_juzgado")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(lugar_juzgado);
                        }
                        else if (fieldName == "nombre_cartera")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nombre_cartera);
                        }
                        else if (fieldName == "tipo_proceso")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(tipo_proceso);
                        }
                        else if (fieldName == "nom_titular")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(nom_titular);
                        }
                        else if (fieldName == "fecha")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(fecha);
                        }


                    }
                }
                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }
                //wordDoc.SaveAs("Subrogación-De-Peritos-" + nom_titular + ".docx");
                //objWord.Documents.Open("Subrogación-De-Peritos-" + nom_titular + ".docx");

            }

            public void test() 
            {
                object objMiss = System.Reflection.Missing.Value;
                object oTemplatePath = "D:\\PLANTILLAS ESCRITOS\\TEST.dotx";
                Word.Application objWord = new Word.Application();
                Document wordDoc = new Document();
                wordDoc = objWord.Documents.Add(ref oTemplatePath, ref objMiss, ref objMiss, ref objMiss);

                //variables
                string num_expediente, secretario;
                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(cmb_ExpedientesEscritos.Text);
               

                num_expediente = cmb_ExpedientesEscritos.Text;
                secretario = objExpediente.TrabajadorSecretario;
                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "num_expediente")
                        {
                            myMergeField.Select();
                            objWord.Selection.TypeText(num_expediente);
                        }
                      
                        
                    }
                }

                try
                {
                    wordDoc.Save();
                    objWord.Visible = true;
                }
                catch (Exception e)
                {
                }

            }

            //EVENTOS ESCRITOS

            private void cmb_OperacionEscritos_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmb_OperacionEscritos.SelectedIndex != -1)
                {
                    cmb_ExpedientesEscritos.SelectedIndex = -1;
                    cmb_ExpedientesEscritos.Text = "";
                    CargarExpedienteEscritos();
                }
            }
            private void button2_Click_1(object sender, EventArgs e)
            {
                if (cmb_TipoEscritos.Text == "ABSUELTO DEVOLUCIÓN PRINCIPAL")
                    WordAbDePr();
                else if (cmb_TipoEscritos.Text == "ADJUNTO INSCRIPCIÓN Y OTROS")
                    WordAdInOt();
                else if (cmb_TipoEscritos.Text == "AUTO FINAL")
                    WordAuFi();
                else if (cmb_TipoEscritos.Text == "CONCLUSIÓN DE PROCESO")
                    WordConPro();
                else if (cmb_TipoEscritos.Text == "DEMANDA DE EJECUCIÓN DE GARANTIAS")
                    WordDeEjGa();
                else if (cmb_TipoEscritos.Text == "DEMANDA DE INCAUTACIÓN")
                    WordDeMiNi();
                else if (cmb_TipoEscritos.Text == "DEMANDA ODSD PURA")
                    WordDeODSDPu();
                else if (cmb_TipoEscritos.Text == "INTERPONE DEMANDA PRINCIPAL")
                    WordInDePr();
                else if (cmb_TipoEscritos.Text == "LANZAMIENTO")
                    WordLan();
                else if (cmb_TipoEscritos.Text == "LEVANTAMIENTO MEDIDA CAUTELAR")
                    WordLeMeCa();
                else if (cmb_TipoEscritos.Text == "MEDIDA CAUTELAR FUERA DEL PROCESO")
                    WordMeCaFuPr();
                else if (cmb_TipoEscritos.Text == "SOLICITO SE LIBRE EXHORTO")
                    WordSoLiEx();
                else if (cmb_TipoEscritos.Text == "SOLICITO OFICIOS DE CAPTURA")
                    WordSoOfCa();
                else if (cmb_TipoEscritos.Text == "SOLICITO ORDEN DE REMATE")
                    WordSoOrRe();
                else if (cmb_TipoEscritos.Text == "SOLICITO SE REQUIERA")
                    WordSoSeRe();
                else if (cmb_TipoEscritos.Text == "SOLICITO TASACIÓN")
                    WordSoTa();
                else if (cmb_TipoEscritos.Text == "SUBRROGACIÓN DE PERITOS")
                    WordSuPe();
                else if (cmb_TipoEscritos.Text == "TEST")
                    test();
            }
        

                
        //VALIDACIONES INICIALES

        public void InicioComboBox()
        {
            // PROCESO
            cmb_Macro.SelectedIndex = -1;
            cmb_Micro.SelectedIndex = -1;
            /*cmb_EtapaProcesal.SelectedIndex = -1;*/

            // OTRO_BIEN
            cmb_BienOtrasCargas.SelectedIndex = -1;
        }
        private void tab_Global_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTabIndex();

        }
        private void CargarTabIndex()
        {
            // GARANTE -
            if (tab_Global.SelectedIndex == 1)
            {
                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("No Seleccionó Ningun Crédito");
                    tab_Global.SelectedIndex = 0;
                }
                else
                {
                    CargarOperacionGarante();
                }
              
            }
            // EXPEDIENTE - 
            if (tab_Global.SelectedIndex == 2)
            {
                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("No Seleccionó Ningun Crédito");
                    tab_Global.SelectedIndex = 0;
                }
                else
                {
                    CargarOperacionExpediente();
                }
            }
            //PROCESO
            if (tab_Global.SelectedIndex == 3)
            {

                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("No Seleccionó Ningun Crédito ");
                    tab_Global.SelectedIndex = 0;
                }
                else
                {
                    CargarOperacionProceso();
                }
               
            }
            // FECHAS
            if (tab_Global.SelectedIndex == 4)
            {
                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("No Seleccionó Ningun Crédito ");
                    tab_Global.SelectedIndex = 0;
                }
                else
                {
                    //CargarExpedienteFechas();
                    CargarOperacionFechas();
                  //  CargarModelo();
                }
            }
            // BIEN
            if (tab_Global.SelectedIndex == 5)
            {

                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("No Seleccionó Ningun Crédito");
                    tab_Global.SelectedIndex = 0;
                }
                else
                {
                    CargarOperacionBien();
                    //CargarMonto();
                }
            }
            //OTRAS CARGAS
            if (tab_Global.SelectedIndex == 6)
            {
                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("No Seleccionó Ningun Crédito");
                    tab_Global.SelectedIndex = 0;
                }
                else
                {
                    CargarOperacionOtrasCargas(); 
                }
            }
            //SEGUIMIENTO
            if (tab_Global.SelectedIndex == 7)
            {
                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("No Seleccionó Ningun Crédito");
                    tab_Global.SelectedIndex = 0;
                }
                else
                {
                    CargarOperacionSeguimiento();
                }
            }
            //PAGOS
            if (tab_Global.SelectedIndex == 8)
            {
                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("No Seleccionó Ningun Crédito");
                    tab_Global.SelectedIndex = 0;
                }
                else
                {
                    CargarOperacionPagos();
                }
            }
            //GESTION CALL
            if (tab_Global.SelectedIndex == 9)
            {
                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("No Seleccionó Ningun Crédito");
                    tab_Global.SelectedIndex = 0;
                }

                else
                {
                    CargarOperacionCall();
                    //txt_Gestion.Text = "" + (dgv_GestionLlamada.RowCount + 1);
                }
            }
            //GESTION CAMPO
            if (tab_Global.SelectedIndex == 10)
            {
                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("No Seleccionó Ningun Crédito");
                    tab_Global.SelectedIndex = 0;
                }
                else
                {
                    CargarOperacionCampo();
                }
            }
            //PROYECCION
            if (tab_Global.SelectedIndex == 11)
            {
                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("No Seleccionó Ningun Crédito");
                    tab_Global.SelectedIndex = 0;
                }
                else
                {
                    CargarOperacionProyeccion();
                }
            }
            //HISTORICO
            if (tab_Global.SelectedIndex == 12)
            {
                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("No Seleccionó Ningun Crédito");
                    tab_Global.SelectedIndex = 0;
                }
                else
                {
                    CargarOperacionHistorico();
                }
            }
            //UBICACION
            if (tab_Global.SelectedIndex == 13)
            {
                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("No Seleccionó Ningun Crédito");
                    tab_Global.SelectedIndex = 0;
                }
                else
                {
                    CargarOperacionUbicacion();
                    CargarTipoUbicacion();
                }
            }
            //ESCRITOS
            if (tab_Global.SelectedIndex == 14)
            {
                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("No Seleccionó Ningun Crédito");
                    tab_Global.SelectedIndex = 0;
                }
                else 
                {
                    CargarOperacionEscritos();
                }
            }
            //LIQUIDACIONES
            if (tab_Global.SelectedIndex == 15) 
            {
                               
                if (txt_CuentaBT.Text == string.Empty)
                {
                    MessageBox.Show("No seleccionó un Crédito");
                    tab_Global.SelectedIndex = 0;
                }
                else 
                {
                    CargarOperacionLiquidaciones();
                    CargarTipoGasto();
                    
                }
            }
        }



        //CARGAR FORMULARIO
        private void CargarTodo2()
        {
            if (_ceriv.CuentaBTExiste(txt_CuentaBT.Text))
            {
                BloquearTodo();
                BloquearCredito();
                ActivarBotonesGuardar2();
                DesactivarBotonesModificar2();
                DesactivarBotonesGuardar2();
                ActivarBotonesModificar2();
                //DesactivarBotonesGuardar();
                //ActivarBotonesModificar();
                //BloqueoPorTramite();
                //TITULAR
                C_Persona objPersona = _ceriv.PersonaMostrar1(txt_CuentaBT.Text);
                txt_NombreTitular.Text = objPersona.NombreCompleto;
                txt_NombreConyuge.Text = objPersona.NombreConyuge;
                txt_Doi.Text = objPersona.Doi_cliente;
                txt_CuentaBT.Text = objPersona.Cuenta_bt;
                txt_Representante.Text = objPersona.Representante;
                txt_DomicilioTitular.Text = objPersona.DomicilioPersona;
                txt_DireccionTitular.Text = objPersona.DireccionAlterna;
                cmb_DistritoTitular.SelectedValue = objPersona.CodigoDistrito;
                txt_NumeroTitular.Text = objPersona.Numero;
                
                //CREDITO
                C_Credito objCredito = _ceriv.CreditoMostrar1(txt_Operacion.Text);
                cmb_Cartera.SelectedValue = objCredito.CodigoCartera;
                txt_Castigos.Text = objCredito.Castigos;
                cmb_Modelo.SelectedValue = objCredito.Modelo;
                txt_ProductoModulo.Text = objCredito.ProductoModulo;
                txt_Cdr.Text = objCredito.Cdr;
                txt_Agencia.Text = objCredito.Agencia;
                txt_Operacion.Text = objCredito.Operacion;
                txt_Capital.Text = objCredito.Capital;
                cmb_Moneda.SelectedValue = objCredito.CodigoMoneda;
                //
                if (objCredito.FechaProtesto == DateTime.Parse("01-01-1990"))
                {
                    dtp_Protesto.CustomFormat = " ";
                    dtp_Protesto.Format = DateTimePickerFormat.Custom;
                }
                else if (objCredito.FechaProtesto != DateTime.MinValue)
                {
                    dtp_Protesto.Value = objCredito.FechaProtesto;
                }
                else
                {
                    dtp_Protesto.Value = DateTime.Parse("01-01-1990");
                    dtp_Protesto.CustomFormat = " ";
                    dtp_Protesto.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objCredito.FechaAsignacion == DateTime.Parse("01-01-1990"))
                {
                    dtp_Asignacion.CustomFormat = " ";
                    dtp_Asignacion.Format = DateTimePickerFormat.Custom;
                }
                else if (objCredito.FechaAsignacion != DateTime.MinValue)
                {
                    dtp_Asignacion.Value = objCredito.FechaAsignacion;
                }
                else
                {
                    dtp_Asignacion.Value = DateTime.Parse("01-01-1990");
                    dtp_Asignacion.CustomFormat = " ";
                    dtp_Asignacion.Format = DateTimePickerFormat.Custom;
                }
                //  
                cmb_Ciudad.SelectedValue = objCredito.CodigoCiudad;
                cmb_Estudio.SelectedValue = objCredito.CodigoEstudio;
                if (objCredito.CodigoTramite == 1)
                {
                    DesactivarBotonesModificar();
                    DesactivarBotonesGuardar();
                    DesactivarDataGridView();
                    BloquearTodo();
                    BloqueoPorTramite();
                    btn_ModificarCredito.Enabled = true;
                    cmb_BienOtrasCargas.Enabled = true;
                    chk_Transito.Checked = true;
                }
                if (objCredito.CodigoTramite == 3)
                {
                    DesactivarBotonesModificar();
                    DesactivarBotonesGuardar();
                    DesactivarDataGridView();
                    BloquearTodo();
                    BloqueoPorTramite();
                    btn_ModificarCredito.Enabled = true;
                    cmb_BienOtrasCargas.Enabled = true;
                    chk_Canal.Checked = true;
                }
                if (objCredito.CodigoTramite == 4)
                {
                    ActivarOtrasCargas();
                    ActivarBien();
                    chk_Canal.Checked = false;
                    chk_Transito.Checked = false;
                }
                txt_Otro.Text = objCredito.ObservacionTramite;
                //
                if (objCredito.FechaTramite == DateTime.Parse("01-01-1990"))
                {
                    dtp_Cambio.CustomFormat = " ";
                    dtp_Cambio.Format = DateTimePickerFormat.Custom;
                }
                else if (objCredito.FechaTramite != DateTime.MinValue)
                {
                    dtp_Cambio.Value = objCredito.FechaTramite;
                }
                else
                {
                    dtp_Cambio.Value = DateTime.Parse("01-01-1990");
                    dtp_Cambio.CustomFormat = " ";
                    dtp_Cambio.Format = DateTimePickerFormat.Custom;
                }
                if (cmb_Modelo.Text == "MODELO AB")
                {
                    BloquearBien();
                    dgv_bien.Enabled = false;
                    bloquearOtrasCargas();
                    dgv_OtrasCargas.Enabled = false;
                    cmb_BienOtrasCargas.Enabled = true;
                }
                else
                {
                    dgv_bien.Enabled = true;
                    dgv_OtrasCargas.Enabled = true;
                    
                }
                //
                //EXPEDIENTE
                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(txt_NumExpediente.Text);
                txt_NumExpediente.Text = objExpediente.NumExpediente;
                txt_NumExpediente22.Text = objExpediente.NumExpediente22Digitos;
                cmb_Responsable.SelectedValue = objExpediente.TrabajadoResponsable;
                cmb_Abogado.SelectedValue = objExpediente.TrabajadorAbogado;
                txt_Secretario.Text = objExpediente.TrabajadorSecretario;
                cmb_Tipo_Proceso.SelectedValue = objExpediente.CodigoTipoProceso;
                //txt_Juzgado.Text = objExpediente.Juzgado;
                if (txt_codigoCautelar.Text != string.Empty)
                    cmb_Medida_Cautelar.Text = "SI";
                if (txt_codigoCautelar.Text == string.Empty)
                    cmb_Medida_Cautelar.Text = "NO";
                txt_codigoCautelar.Text = objExpediente.CodigoCautelar;

                //PROCESO
                C_Proceso objProceso = _ceriv.ProcesoMostrar1(txt_NumExpediente.Text);
                if (objProceso.CodigoMacro == -1)
                    cmb_Macro.SelectedIndex = -1;
                else
                    cmb_Macro.SelectedValue = objProceso.CodigoMacro;
                if (objProceso.CodigoMicro == -1)
                    cmb_Micro.SelectedIndex = -1;
                else
                    cmb_Micro.SelectedValue = objProceso.CodigoMicro;
               /* if (objProceso.CodigoEtapa == -1)
                    cmb_EtapaProcesal.SelectedIndex = -1;
                else
                    cmb_EtapaProcesal.SelectedValue = objProceso.CodigoEtapa;*/
                cmb_Tiempo.Text = objProceso.Tiempo;
                //
                if (objProceso.FechaEtapa == DateTime.Parse("01-01-1990"))
                {
                    dtp_FechaEtapa.CustomFormat = " ";
                    dtp_FechaEtapa.Format = DateTimePickerFormat.Custom;
                }
                else if (objProceso.FechaEtapa != DateTime.MinValue)
                {
                    dtp_FechaEtapa.Value = objProceso.FechaEtapa;
                }
                else
                {
                    dtp_FechaEtapa.Value = DateTime.Parse("01-01-1990");
                    dtp_FechaEtapa.CustomFormat = " ";
                    dtp_FechaEtapa.Format = DateTimePickerFormat.Custom;
                }
                //
                cmb_FMedCautelar.SelectedValue = objProceso.CodigoMedida;
                //
                if (objProceso.FechaInscripcion == DateTime.Parse("01-01-1990"))
                {
                    dtp_Inscripcion.CustomFormat = " ";
                    dtp_Inscripcion.Format = DateTimePickerFormat.Custom;
                }
                else if (objProceso.FechaInscripcion != DateTime.MinValue)
                {
                    dtp_Inscripcion.Value = objProceso.FechaInscripcion;
                }
                else
                {
                    dtp_Inscripcion.Value = DateTime.Parse("01-01-1990");
                    dtp_Inscripcion.CustomFormat = " ";
                    dtp_Inscripcion.Format = DateTimePickerFormat.Custom;
                }
                //
                txt_EstadoCautelar.Text = objProceso.EstadoCautelar;
                //
                if (objProceso.FechaMedidaCautelar == DateTime.Parse("01-01-1990"))
                {
                    dtp_MedidaCautelar.CustomFormat = " ";
                    dtp_MedidaCautelar.Format = DateTimePickerFormat.Custom;
                }
                else if (objProceso.FechaMedidaCautelar != DateTime.MinValue)
                {
                    dtp_MedidaCautelar.Value = objProceso.FechaMedidaCautelar;
                }
                else
                {
                    dtp_MedidaCautelar.Value = DateTime.Parse("01-01-1990");
                    dtp_MedidaCautelar.CustomFormat = " ";
                    dtp_MedidaCautelar.Format = DateTimePickerFormat.Custom;
                }
                //
                cmb_VigenciaMc.Text = objProceso.VigenciaMC;
                //
                if (objProceso.FechaActuadoCautelar == DateTime.Parse("01-01-1990"))
                {
                    dtp_ActuadoCautelar.CustomFormat = " ";
                    dtp_ActuadoCautelar.Format = DateTimePickerFormat.Custom;
                }
                else if (objProceso.FechaActuadoCautelar != DateTime.MinValue)
                {
                    dtp_ActuadoCautelar.Value = objProceso.FechaActuadoCautelar;
                }
                else
                {
                    dtp_ActuadoCautelar.Value = DateTime.Parse("01-01-1990");
                    dtp_ActuadoCautelar.CustomFormat = " ";
                    dtp_ActuadoCautelar.Format = DateTimePickerFormat.Custom;
                }
                //
                cmb_Devolucion.Text = objProceso.DevolucionCedula;

                //PROCESO FECHAS
                C_Fechas objFechas = _ceriv.FechasMostrar1(txt_Operacion.Text);
                if (objFechas.FechaAdjucaptura == DateTime.Parse("01-01-1990"))
                {
                    dtp_AdjuCaptura.CustomFormat = " ";
                    dtp_AdjuCaptura.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaAdjucaptura != DateTime.MinValue)
                {
                    dtp_AdjuCaptura.Value = objFechas.FechaAdjucaptura;
                }
                else
                {
                    dtp_AdjuCaptura.Value = DateTime.Parse("01-01-1990");
                    dtp_AdjuCaptura.CustomFormat = " ";
                    dtp_AdjuCaptura.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objFechas.FechaContradiccion == DateTime.Parse("01-01-1990"))
                {
                    dtp_Contradiccion.CustomFormat = " ";
                    dtp_Contradiccion.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaContradiccion != DateTime.MinValue)
                {
                    dtp_Contradiccion.Value = objFechas.FechaContradiccion;
                }
                else
                {
                    dtp_Contradiccion.Value = DateTime.Parse("01-01-1990");
                    dtp_Contradiccion.CustomFormat = " ";
                    dtp_Contradiccion.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objFechas.FechaMando == DateTime.Parse("01-01-1990"))
                {
                    dtp_FechaMandato.CustomFormat = " ";
                    dtp_FechaMandato.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaMando != DateTime.MinValue)
                {
                    dtp_FechaMandato.Value = objFechas.FechaMando;
                }
                else
                {
                    dtp_FechaMandato.Value = DateTime.Parse("01-01-1990");
                    dtp_FechaMandato.CustomFormat = " ";
                    dtp_FechaMandato.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objFechas.FechaOrden == DateTime.Parse("01-01-1990"))
                {
                    dtp_fechaOrden.CustomFormat = " ";
                    dtp_fechaOrden.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaOrden != DateTime.MinValue)
                {
                    dtp_fechaOrden.Value = objFechas.FechaOrden;
                }
                else
                {
                    dtp_fechaOrden.Value = DateTime.Parse("01-01-1990");
                    dtp_fechaOrden.CustomFormat = " ";
                    dtp_fechaOrden.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objFechas.FechaRematecaptura == DateTime.Parse("01-01-1990"))
                {
                    dtp_RemateCaptura.CustomFormat = " ";
                    dtp_RemateCaptura.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaRematecaptura != DateTime.MinValue)
                {
                    dtp_RemateCaptura.Value = objFechas.FechaRematecaptura;
                }
                else
                {
                    dtp_RemateCaptura.Value = DateTime.Parse("01-01-1990");
                    dtp_RemateCaptura.CustomFormat = " ";
                    dtp_RemateCaptura.Format = DateTimePickerFormat.Custom;
                }

                //
               

                //PROYECCION

              /*  C_Proyeccion objProyeccion = _ceriv.ProyeccionMostrar1(txt_CuentaBT.Text);
                txt_MotivoDevolucion.Text = objProyeccion.MotivoDevolucion;
                txt_Devuelto.Text = objProyeccion.Devuelto;
                if (objProyeccion.FechaEstimada == DateTime.Parse("01-01-1990"))
                {
                    dtp_FechaEstimada.CustomFormat = " ";
                    dtp_FechaEstimada.Format = DateTimePickerFormat.Custom;
                }
                else if (objProyeccion.FechaEstimada != DateTime.MinValue)
                {
                    dtp_FechaEstimada.Value = objProyeccion.FechaEstimada;
                }
                else
                {
                    dtp_FechaEstimada.Value = DateTime.Parse("01-01-1900");
                    dtp_FechaEstimada.CustomFormat = " ";
                    dtp_FechaEstimada.Format = DateTimePickerFormat.Custom;
                }
                txt_TelefonoProyeccion.Text = objProyeccion.Telefono;
                */
                //
            }
        }
        private void CargarTodo()
        {
            if (_ceriv.CuentaBTExiste(txt_CuentaBT.Text))
            {
                BloquearTodo();
                DesactivarBotonesGuardar2();
                ActivarBotonesModificar2();
                BloquearCredito();
                //BloqueoPorTramite();
                //TITULAR
                C_Persona objPersona = _ceriv.PersonaMostrar1(txt_CuentaBT.Text);
                txt_NombreTitular.Text = objPersona.NombreCompleto;
                txt_NombreConyuge.Text = objPersona.NombreConyuge;
                txt_Doi.Text = objPersona.Doi_cliente;
                txt_CuentaBT.Text = objPersona.Cuenta_bt;
                txt_Representante.Text = objPersona.Representante;
                txt_DomicilioTitular.Text = objPersona.DomicilioPersona;
                txt_DireccionTitular.Text = objPersona.DireccionAlterna;
                cmb_DistritoTitular.SelectedValue = objPersona.CodigoDistrito;
                txt_NumeroTitular.Text = objPersona.Numero;
                //CREDITO
                C_Credito objCredito = _ceriv.CreditoMostrar1(txt_Operacion.Text);
                cmb_Cartera.SelectedValue = objCredito.CodigoCartera;
                txt_Castigos.Text = objCredito.Castigos;
                cmb_Modelo.SelectedValue = objCredito.Modelo;

                txt_ProductoModulo.Text = objCredito.ProductoModulo;
                txt_Cdr.Text = objCredito.Cdr;
                txt_Agencia.Text = objCredito.Agencia;
                txt_Operacion.Text = objCredito.Operacion;
                txt_Capital.Text = objCredito.Capital;
                cmb_Moneda.SelectedValue = objCredito.CodigoMoneda;
                //
                if (objCredito.FechaProtesto == DateTime.Parse("01-01-1990"))
                {
                    dtp_Protesto.CustomFormat = " ";
                    dtp_Protesto.Format = DateTimePickerFormat.Custom;
                }
                else if (objCredito.FechaProtesto != DateTime.MinValue)
                {
                    dtp_Protesto.Value = objCredito.FechaProtesto;
                }
                else
                {
                    dtp_Protesto.Value = DateTime.Parse("01-01-1990");
                    dtp_Protesto.CustomFormat = " ";
                    dtp_Protesto.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objCredito.FechaAsignacion == DateTime.Parse("01-01-1990"))
                {
                    dtp_Asignacion.CustomFormat = " ";
                    dtp_Asignacion.Format = DateTimePickerFormat.Custom;
                }
                else if (objCredito.FechaAsignacion != DateTime.MinValue)
                {
                    dtp_Asignacion.Value = objCredito.FechaAsignacion;
                }
                else
                {
                    dtp_Asignacion.Value = DateTime.Parse("01-01-1990");
                    dtp_Asignacion.CustomFormat = " ";
                    dtp_Asignacion.Format = DateTimePickerFormat.Custom;
                }
                //
                cmb_Ciudad.SelectedValue = objCredito.CodigoCiudad;
                cmb_Estudio.SelectedValue = objCredito.CodigoEstudio;
                if (objCredito.CodigoTramite == 1)
                {
                    //DesactivarBotonesModificar();
                    InvisibleModificar();
                    InvisibleGuardar();
                    InvisibleEliminar();
                    //DesactivarBotonesGuardar();
                    DesactivarDataGridView();
                    BloquearTodo();
                    BloqueoPorTramite();
                    btn_ModificarCredito.Enabled = true;
                    cmb_BienOtrasCargas.Enabled = true;
                    chk_Transito.Checked = true;
                }
                if (objCredito.CodigoTramite == 3)
                {
                    //DesactivarBotonesModificar();
                    //DesactivarBotonesGuardar();
                    InvisibleGuardar();
                    InvisibleModificar();
                    InvisibleEliminar();
                    DesactivarDataGridView();
                    BloquearTodo();
                    BloqueoPorTramite();
                    btn_ModificarCredito.Enabled = true;
                    cmb_BienOtrasCargas.Enabled = true;
                    chk_Canal.Checked = true;
                }
                if (objCredito.CodigoTramite == 4)
                {
                    ActivarBien();
                    ActivarOtrasCargas();
                    chk_Canal.Checked = false;
                    chk_Transito.Checked = false;

                }
                txt_Otro.Text = objCredito.ObservacionTramite;
                //
                if (objCredito.FechaTramite == DateTime.Parse("01-01-1990"))
                {
                    dtp_Cambio.CustomFormat = " ";
                    dtp_Cambio.Format = DateTimePickerFormat.Custom;
                }
                else if (objCredito.FechaTramite != DateTime.MinValue)
                {
                    dtp_Cambio.Value = objCredito.FechaTramite;
                }
                else
                {
                    dtp_Cambio.Value = DateTime.Parse("01-01-1990");
                    dtp_Cambio.CustomFormat = " ";
                    dtp_Cambio.Format = DateTimePickerFormat.Custom;
                }
                if (cmb_Modelo.Text == "MODELO AB")
                {
                    BloquearBien();
                    dgv_bien.Enabled = false;
                    bloquearOtrasCargas();
                    dgv_OtrasCargas.Enabled = false;
                    cmb_BienOtrasCargas.Enabled = true;
                }
                //
                //PROCESO
                C_Proceso objProceso = _ceriv.ProcesoMostrar1( txt_NumExpediente.Text);
                cmb_Macro.SelectedValue = objProceso.CodigoMacro;
                cmb_Micro.SelectedValue = objProceso.CodigoMicro;
                //cmb_EtapaProcesal.SelectedValue = objProceso.CodigoEtapa;
                cmb_Tiempo.Text = objProceso.Tiempo;
                //
                if (objProceso.FechaEtapa == DateTime.Parse("01-01-1990"))
                {
                    dtp_FechaEtapa.CustomFormat = " ";
                    dtp_FechaEtapa.Format = DateTimePickerFormat.Custom;
                }
                else if (objProceso.FechaEtapa != DateTime.MinValue)
                {
                    dtp_FechaEtapa.Value = objProceso.FechaEtapa;
                }
                else
                {
                    dtp_FechaEtapa.Value = DateTime.Parse("01-01-1990");
                    dtp_FechaEtapa.CustomFormat = " ";
                    dtp_FechaEtapa.Format = DateTimePickerFormat.Custom;

                }
                //
                cmb_FMedCautelar.SelectedValue = objProceso.CodigoMedida;
                
              /*  if (objProceso.FechaDemanda == DateTime.Parse("01-01-1990"))
                {
                    dtp_Demanda.CustomFormat = " ";
                    dtp_Demanda.Format = DateTimePickerFormat.Custom;
                }
                else if (objProceso.FechaDemanda != DateTime.MinValue)
                {
                    dtp_Demanda.Value = objProceso.FechaDemanda;
                }
                else
                {
                    dtp_Demanda.Value = DateTime.Parse("01-01-1990");
                    dtp_Demanda.CustomFormat = " ";
                    dtp_Demanda.Format = DateTimePickerFormat.Custom;
                }*/
                
                if (objProceso.FechaInscripcion == DateTime.Parse("01-01-1990"))
                {
                    dtp_Inscripcion.CustomFormat = " ";
                    dtp_Inscripcion.Format = DateTimePickerFormat.Custom;
                }
                else if (objProceso.FechaInscripcion != DateTime.MinValue)
                {
                    dtp_Inscripcion.Value = objProceso.FechaInscripcion;
                }
                else
                {
                    dtp_Inscripcion.Value = DateTime.Parse("01-01-1990");
                    dtp_Inscripcion.CustomFormat = " ";
                    dtp_Inscripcion.Format = DateTimePickerFormat.Custom;
                }
                //
                txt_EstadoCautelar.Text = objProceso.EstadoCautelar;
                //
                if (objProceso.FechaMedidaCautelar == DateTime.Parse("01-01-1990"))
                {
                    dtp_MedidaCautelar.CustomFormat = " ";
                    dtp_MedidaCautelar.Format = DateTimePickerFormat.Custom;
                }
                else if (objProceso.FechaMedidaCautelar != DateTime.MinValue)
                {
                    dtp_MedidaCautelar.Value = objProceso.FechaMedidaCautelar;
                }
                else
                {
                    dtp_MedidaCautelar.Value = DateTime.Parse("01-01-1990");
                    dtp_MedidaCautelar.CustomFormat = " ";
                    dtp_MedidaCautelar.Format = DateTimePickerFormat.Custom;
                }
                //
                cmb_VigenciaMc.Text = objProceso.VigenciaMC;
                //
                if (objProceso.FechaActuadoCautelar == DateTime.Parse("01-01-1990"))
                {
                    dtp_ActuadoCautelar.CustomFormat = " ";
                    dtp_ActuadoCautelar.Format = DateTimePickerFormat.Custom;
                }
                else if (objProceso.FechaActuadoCautelar != DateTime.MinValue)
                {
                    dtp_ActuadoCautelar.Value = objProceso.FechaActuadoCautelar;
                }
                else
                {
                    dtp_ActuadoCautelar.Value = DateTime.Parse("01-01-1990");
                    dtp_ActuadoCautelar.CustomFormat = " ";
                    dtp_ActuadoCautelar.Format = DateTimePickerFormat.Custom;
                }
                //
                cmb_Devolucion.Text = objProceso.DevolucionCedula;


                //PROCESO FECHAS
                C_Fechas objFechas = _ceriv.FechasMostrar1(txt_Operacion.Text);
                if (objFechas.FechaAdjucaptura == DateTime.Parse("01-01-1990"))
                {
                    dtp_AdjuCaptura.CustomFormat = " ";
                    dtp_AdjuCaptura.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaAdjucaptura != DateTime.MinValue)
                {
                    dtp_AdjuCaptura.Value = objFechas.FechaAdjucaptura;
                }
                else
                {
                    dtp_AdjuCaptura.Value = DateTime.Parse("01-01-1990");
                    dtp_AdjuCaptura.CustomFormat = " ";
                    dtp_AdjuCaptura.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objFechas.FechaContradiccion == DateTime.Parse("01-01-1990"))
                {
                    dtp_Contradiccion.CustomFormat = " ";
                    dtp_Contradiccion.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaContradiccion != DateTime.MinValue)
                {
                    dtp_Contradiccion.Value = objFechas.FechaContradiccion;
                }
                else
                {
                    dtp_Contradiccion.Value = DateTime.Parse("01-01-1990");
                    dtp_Contradiccion.CustomFormat = " ";
                    dtp_Contradiccion.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objFechas.FechaMando == DateTime.Parse("01-01-1990"))
                {
                    dtp_FechaMandato.CustomFormat = " ";
                    dtp_FechaMandato.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaMando != DateTime.MinValue)
                {
                    dtp_FechaMandato.Value = objFechas.FechaMando;
                }
                else
                {
                    dtp_FechaMandato.Value = DateTime.Parse("01-01-1990");
                    dtp_FechaMandato.CustomFormat = " ";
                    dtp_FechaMandato.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objFechas.FechaOrden == DateTime.Parse("01-01-1990"))
                {
                    dtp_fechaOrden.CustomFormat = " ";
                    dtp_fechaOrden.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaOrden != DateTime.MinValue)
                {
                    dtp_fechaOrden.Value = objFechas.FechaOrden;
                }
                else
                {
                    dtp_fechaOrden.Value = DateTime.Parse("01-01-1990");
                    dtp_fechaOrden.CustomFormat = " ";
                    dtp_fechaOrden.Format = DateTimePickerFormat.Custom;
                }
                //
                if (objFechas.FechaRematecaptura == DateTime.Parse("01-01-1990"))
                {
                    dtp_RemateCaptura.CustomFormat = " ";
                    dtp_RemateCaptura.Format = DateTimePickerFormat.Custom;
                }
                else if (objFechas.FechaRematecaptura != DateTime.MinValue)
                {
                    dtp_RemateCaptura.Value = objFechas.FechaRematecaptura;
                }
                else
                {
                    dtp_RemateCaptura.Value = DateTime.Parse("01-01-1990");
                    dtp_RemateCaptura.CustomFormat = " ";
                    dtp_RemateCaptura.Format = DateTimePickerFormat.Custom;
                }
                
                //
                //EXPEDIENTE
                C_Expediente objExpediente = _ceriv.ExpedienteMostrar1(txt_NumExpediente.Text);
                txt_NumExpediente.Text = objExpediente.NumExpediente;
                txt_NumExpediente22.Text = objExpediente.NumExpediente22Digitos;
                cmb_Responsable.SelectedValue = objExpediente.TrabajadoResponsable;
                cmb_Abogado.SelectedValue = objExpediente.TrabajadorAbogado;
                txt_Secretario.Text = objExpediente.TrabajadorSecretario;
                cmb_Tipo_Proceso.SelectedValue = objExpediente.CodigoTipoProceso;
                //txt_Juzgado.Text = objExpediente.Juzgado;
                if (txt_codigoCautelar.Text != string.Empty)
                    cmb_Medida_Cautelar.Text = "SI";
                if (txt_codigoCautelar.Text == string.Empty)
                    cmb_Medida_Cautelar.Text = "NO";
                txt_codigoCautelar.Text = objExpediente.CodigoCautelar;

                //PROYECCION
                /*C_Proyeccion objProyeccion = _ceriv.ProyeccionMostrar1(txt_CuentaBT.Text);
                txt_MotivoDevolucion.Text = objProyeccion.MotivoDevolucion;
                txt_Devuelto.Text = objProyeccion.Devuelto;
                if(objProyeccion.FechaEstimada == DateTime.Parse("01-01-1990"))
                {
                    dtp_FechaEstimada.CustomFormat = " ";
                    dtp_FechaEstimada.Format = DateTimePickerFormat.Custom;
                }
                else if (objProyeccion.FechaEstimada != DateTime.MinValue)
                {
                    dtp_FechaEstimada.Value = objProyeccion.FechaEstimada;
                }
                else
                {
                    dtp_FechaEstimada.Value = DateTime.Parse("01-01-1900");
                    dtp_FechaEstimada.CustomFormat = " ";
                    dtp_FechaEstimada.Format = DateTimePickerFormat.Custom;
                }
                txt_TelefonoProyeccion.Text = objProyeccion.Telefono;*/
            }
            else
            {
                MessageBox.Show("No Existe la  " + lbl_cuentabt.Text + " ");
                txt_CuentaBT.Clear();
                return;
            }
        }

        //BLOQUEOS/DESACTIVAR

        public void BloquearTodo()
        {
            BloquearTitular();
            //BloquearCredito();
            BloquearProceso();
            BloquearExpediente();
            BloquearFecha();
            BloquearProyeccion();
        }
        public void BloqueoPorTramite()
        {
            BloquearGarante();
            BloquearBien();
            bloquearOtrasCargas();
            BloquearSeguimiento();
            BloquearPagos();
            BloquearGestionLlamadas();
            BloquearGestionCampo();
        }
        public void DesactivarBotonesModificar()
        {
            btn_ModificarProyeccion.Enabled = false;
            btn_Modificar.Enabled = false;
            btn_ModificarTitular.Enabled = false;
            btn_ModificarCredito.Enabled = false;
            btn_ModificarGarante.Enabled = false;
            btn_ModificarProceso.Enabled = false;
            btn_ModificarExpediente.Enabled = false;
            btn_ModificarBien.Enabled = false;
            btn_ModificarOtrasCargas.Enabled = false;
            btn_Modificar_Seguimiento.Enabled = false;
            btn_ModificarPagos.Enabled = false;
            btn_ModificarGestionLlamadas.Enabled = false;
            btn_ModificarCampo.Enabled = false;
        }
        public void DesactivarBotonesModificar2()
        {
            btn_ModificarGarante.Enabled = false;
            btn_ModificarBien.Enabled = false;
            btn_ModificarOtrasCargas.Enabled = false;
            btn_Modificar_Seguimiento.Enabled = false;
            btn_ModificarPagos.Enabled = false;
            btn_ModificarGestionLlamadas.Enabled = false;
            btn_ModificarCampo.Enabled = false;
            btn_ModificarProyeccion.Enabled = false;
        }
        public void DesactivarBotonesEliminar()
        {
            btn_EliminarGarante.Enabled = false;
            btn_EliminarBien.Enabled = false;
            btn_EliminarOtrasCargas.Enabled = false;
            /*btn_EliminarCredito.Enabled = false;
            btn_Eliminar.Enabled = false;*/
        }
        public void DesactivarBotonesGuardar()
        {
            btn_Guardar.Enabled = false;
            btn_GuardarTitular.Enabled = false;
            btn_GuardarCredito.Enabled = false;
            btn_GuardarGarante.Enabled = false;
            btn_GuardarProceso.Enabled = false;
            btn_GuardarExpediente.Enabled = false;
            btn_GuardarBien.Enabled = false;
            btn_GuardarOtrasCargas.Enabled = false;
            btn_Guardar_Seguimiento.Enabled = false;
            btn_GuardarPagos.Enabled = false;
            btn_AgregarGestionLlamadas.Enabled = false;
            btn_GuardarCampo.Enabled = false;
        }
        public void DesactivarBotonesGuardar2()
        {
            btn_Guardar.Enabled = false;
            btn_GuardarTitular.Enabled = false;
            btn_GuardarCredito.Enabled = false;
            btn_GuardarProceso.Enabled = false;
            btn_GuardarExpediente.Enabled = false;
            btn_GuardarProyeccion.Enabled = false;

        }
        public void DesactivarDataGridView()
        {
            dgv_Garante.Enabled = false;
            dgv_bien.Enabled = false;
            dgv_OtrasCargas.Enabled = false;
            dgv_Procesos.Enabled = false;
            dgv_Pagos.Enabled = false;
            dgv_GestionLlamada.Enabled = false;
            dgv_GestionCampo.Enabled = false;

        }
        public void BloquearBotones()
        {
            btn_GuardarTitular.Visible = false;
            btn_ModificarTitular.Visible = false;
            btn_GuardarGarante.Visible = false;
            btn_ModificarGarante.Visible = false;
            btn_EliminarGarante.Visible = false;
            btn_GuardarExpediente.Visible = false;
            btn_ModificarExpediente.Visible = false;
            btn_LimpiarExpediente.Visible = false;
            btn_Eliminar.Visible = false;
            btn_GuardarProceso.Visible = false;
            btn_ModificarProceso.Visible = false;
            btn_LimpiarProceso.Visible = false;

        }
        public void BloquearDataGridView()
        {
            dgv_Garante.Enabled = false;
        }


        //DESBLOQUEOS/ACTIVAR

        public void DesbloqueoPorTramite()
        {
            ActivarGarante();
            ActivarBien();
            ActivarOtrasCargas();
            ActivarSeguimiento();
            ActivarPagos();
            ActivarGestionLlamadas();
            ActivarGestionCampo();
            ActivarLiquidaciones();
        }
        public void ActivarBotonesModificar()
        {
            btn_Modificar.Enabled = true;
            btn_ModificarTitular.Enabled = true;
            btn_ModificarCredito.Enabled = true;
            btn_ModificarGarante.Enabled = true;
            btn_ModificarProceso.Enabled = true;
            btn_ModificarExpediente.Enabled = true;
            btn_ModificarBien.Enabled = true;
            btn_ModificarOtrasCargas.Enabled = true;
            btn_Modificar_Seguimiento.Enabled = true;
            btn_ModificarPagos.Enabled = true;
            btn_ModificarGestionLlamadas.Enabled = true;
            btn_ModificarCampo.Enabled = true;

        }
        public void ActivarBotonesModificar2()
        {
            btn_Modificar.Enabled = true;
            btn_ModificarTitular.Enabled = true;
            btn_ModificarCredito.Enabled = true;
            btn_ModificarProceso.Enabled = true;
            btn_ModificarExpediente.Enabled = true;
            btn_ModificarProyeccion.Enabled = true;
 
        }
        public void DesbloquearTodo()
        {
            //ActivarTitular();
            //ActivarCredito();
            ActivarProceso();
            ActivarExpediente();
            ActivarFecha();
        }
        public void ActivarBotonesGuardar2()
        {
            btn_GuardarGarante.Enabled = true;
            btn_GuardarBien.Enabled = true;
            btn_GuardarOtrasCargas.Enabled = true;
            btn_Guardar_Seguimiento.Enabled = true;
            btn_GuardarPagos.Enabled = true;
            btn_AgregarGestionLlamadas.Enabled = true;
            btn_GuardarCampo.Enabled = true;
            btn_GuardarProyeccion.Enabled = true;
        }
        public void ActivarBotonesGuardar()
        {
            btn_Guardar.Enabled = true;
            btn_GuardarTitular.Enabled = true;
            btn_GuardarCredito.Enabled = true;
            btn_GuardarGarante.Enabled = true;
            btn_GuardarProceso.Enabled = true;
            btn_GuardarExpediente.Enabled = true;
            btn_GuardarBien.Enabled = true;
            btn_GuardarOtrasCargas.Enabled = true;
            btn_Guardar_Seguimiento.Enabled = true;
            btn_GuardarPagos.Enabled = true;
            btn_AgregarGestionLlamadas.Enabled = true;
            btn_GuardarCampo.Enabled = true;
        }
        public void ActivarDataGridView()
        {
            dgv_Garante.Enabled = true;
            dgv_bien.Enabled = true;
            dgv_OtrasCargas.Enabled = true;
            dgv_Procesos.Enabled = true;
            dgv_Pagos.Enabled = true;
            dgv_GestionLlamada.Enabled = true;
            dgv_GestionCampo.Enabled = true;
        }

        // BOTONES VISIBLE
        
        public void VisibleEliminar()
        {
            btn_EliminarGarante.Visible = true;
            btn_EliminarBien.Visible = true;
            btn_EliminarOtrasCargas.Visible = true;
        }

        public void VisibleGuardar()
        {
            btn_Guardar.Visible = true;
            btn_GuardarTitular.Visible = true;
            btn_GuardarCredito.Visible = true;
            btn_GuardarGarante.Visible = true;
            btn_GuardarProceso.Visible = true;
            btn_GuardarExpediente.Visible = true;
            btn_GuardarBien.Visible = true;
            btn_GuardarOtrasCargas.Visible = true;
            btn_Guardar_Seguimiento.Visible = true;
            btn_GuardarPagos.Visible = true;
            btn_AgregarGestionLlamadas.Visible = true;
            btn_GuardarCampo.Visible = true;
            btn_GuardarProyeccion.Visible = true;
        }

        public void VisibleModificar()
        {
            btn_Modificar.Visible = true;
            btn_ModificarTitular.Visible = true;
            //btn_ModificarCredito.Visible = true;
            btn_ModificarGarante.Visible = true;
            btn_ModificarProceso.Visible = true;
            btn_ModificarExpediente.Visible = true;
            btn_ModificarBien.Visible = true;
            btn_ModificarOtrasCargas.Visible = true;
            btn_Modificar_Seguimiento.Visible = true;
            btn_ModificarPagos.Visible = true;
            btn_ModificarGestionLlamadas.Visible = true;
            btn_ModificarCampo.Visible = true;
            btn_ModificarProyeccion.Visible = true;
        }
        
        // BOTONES INVISIBLE

        public void InvisibleEliminar()
        {
            btn_EliminarGarante.Visible = false;
            btn_EliminarBien.Visible = false;
            btn_EliminarOtrasCargas.Visible = false;
        }

        public void InvisibleGuardar()
        {
            btn_Guardar.Visible = false;
            btn_GuardarTitular.Visible = false;
            //btn_GuardarCredito.Visible = false;
            btn_GuardarGarante.Visible = false;
            btn_GuardarProceso.Visible = false;
            btn_GuardarExpediente.Visible = false;
            btn_GuardarBien.Visible = false;
            btn_GuardarOtrasCargas.Visible = false;
            btn_Guardar_Seguimiento.Visible = false;
            btn_GuardarPagos.Visible = false;
            btn_AgregarGestionLlamadas.Visible = false;
            btn_GuardarCampo.Visible = false;
            btn_GuardarProyeccion.Visible = false;
        }

        public void InvisibleModificar()
        {
            btn_Modificar.Visible = false;
            btn_ModificarTitular.Visible = false;
            //btn_ModificarCredito.Visible = false;
            btn_ModificarGarante.Visible = false;
            btn_ModificarProceso.Visible = false;
            btn_ModificarExpediente.Visible = false;
            btn_ModificarBien.Visible = false;
            btn_ModificarOtrasCargas.Visible = false;
            btn_Modificar_Seguimiento.Visible = false;
            btn_ModificarPagos.Visible = false;
            btn_ModificarGestionLlamadas.Visible = false;
            btn_ModificarCampo.Visible = false;
            btn_ModificarProyeccion.Visible = false;
        }

        // BOTONES AVANZAR/RETROCEDER

        private void btn_Retroceder_Click(object sender, EventArgs e)
        {
            if (_array.Length > 0)
            {
                _recorrerArray--;
                FormatearFecha();
                if (_recorrerArray < 0)
                {
                    _recorrerArray = _array.Length - 1;
                }
                txt_CuentaBT.Text = _array[_recorrerArray];
                CargarTodo2();
                CargarTabIndex();
            }
            _bandera = false;
        }

        private void btn_Avanzar_Click(object sender, EventArgs e)
        {
            if (_array.Length > 0)
            {
                _recorrerArray++;
                FormatearFecha();
                if (_recorrerArray >= _array.Length)
                {
                    _recorrerArray = 0;
                }
                txt_CuentaBT.Text = _array[_recorrerArray];
                CargarTodo2();
                CargarTabIndex();
                _bandera = false;
            }
        }

        //FORMATO DE FECHAS
        private void dtp_Protesto_ValueChanged(object sender, EventArgs e)
        {
            dtp_Protesto.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy"; 
        }
        private void dtp_ActuadoCautelar_ValueChanged(object sender, EventArgs e)
        {
            dtp_ActuadoCautelar.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy"; 
        }
        private void dtp_Asignacion_ValueChanged(object sender, EventArgs e)
        {
            dtp_Asignacion.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy"; 
        }
        private void dtp_Cambio_ValueChanged(object sender, EventArgs e)
        {
            dtp_Cambio.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy"; 
        }
        private void dtp_FechaEtapa_ValueChanged(object sender, EventArgs e)
        {
            dtp_FechaEtapa.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy"; 
        }
        private void dtp_Demanda_ValueChanged(object sender, EventArgs e)
        {
         //   dtp_Demanda.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy"; 
        }
        private void dtp_Inscripcion_ValueChanged(object sender, EventArgs e)
        {
            dtp_Inscripcion.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy"; 
        }
        private void dtp_MedidaCautelar_ValueChanged(object sender, EventArgs e)
        {
            dtp_MedidaCautelar.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy"; 
        }
        private void dtp_Tasacion_ValueChanged(object sender, EventArgs e)
        {
            dtp_Tasacion.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy"; 
        }
        private void dtp_Fecha_Procesal_ValueChanged(object sender, EventArgs e)
        {
            dtp_Fecha_Procesal.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy"; 
        }
        private void dtp_Tarea_Administrativa_ValueChanged(object sender, EventArgs e)
        {
            dtp_Tarea_Administrativa.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy";  
        }
        private void dtp_Pagos_ValueChanged(object sender, EventArgs e)
        {
            dtp_Pagos.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy"; 
        }
        private void dtp_Fecha_Visita_ValueChanged(object sender, EventArgs e)
        {
            dtp_Fecha_Visita.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy"; 
        }
        private void dtp_Fecha_Pago_ValueChanged(object sender, EventArgs e)
        {
            dtp_Fecha_Pago.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy"; 
        }
        private void dtp_Pago_ValueChanged(object sender, EventArgs e)
        {
            dtp_Pago.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy"; 
        }
        private void dtp_Gestion_Campo_ValueChanged(object sender, EventArgs e)
        {
            dtp_Gestion_Campo.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy";  
        }
        private void dtp_FechaMandato_ValueChanged(object sender, EventArgs e)
        {
            dtp_FechaMandato.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy";
        }
        private void dtp_Contradiccion_ValueChanged(object sender, EventArgs e)
        {
            dtp_Contradiccion.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy";
        }
        private void dtp_fechaOrden_ValueChanged(object sender, EventArgs e)
        {
            dtp_fechaOrden.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy";
        }
        private void dtp_RemateCaptura_ValueChanged(object sender, EventArgs e)
        {
            dtp_RemateCaptura.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy";
        }
        private void dtp_AdjuCaptura_ValueChanged(object sender, EventArgs e)
        {
            dtp_AdjuCaptura.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy";
        }
        private void dtp_FechaEstimada_ValueChanged(object sender, EventArgs e)
        {

        }
        private void dtp_FechaDemanda_ValueChanged(object sender, EventArgs e)
        {
            dtp_FechaDemanda.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy";

        }
        private void dtp_FechaAutoFinal_ValueChanged(object sender, EventArgs e)
        {
            dtp_FechaAutoFinal.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy";

        }
        private void dtp_FechaEstimada_ValueChanged_1(object sender, EventArgs e)
        {
            dtp_FechaEstimada.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy";
        }
        private void dtp_Apelacion_ValueChanged(object sender, EventArgs e)
        {
            dtp_Apelacion.CustomFormat = "dddd,' 'dd ' de 'MMMM' de 'yyyy";

        }


        // VALIDAR FECHAS AL DIA ACTUAL
        private void dtp_Protesto_Enter(object sender, EventArgs e)
        {
            if (dtp_Protesto.Value == DateTime.Parse("01-01-1990"))
            {
                dtp_Protesto.Value = DateTime.Now;
                //txt_Otro.Text = "" + DateTime.Now.ToShortTimeString();
            }
        }
        private void dtp_Asignacion_Enter(object sender, EventArgs e)
        {
            if (dtp_Asignacion.Value == DateTime.Parse("01-01-1990"))
            {
                dtp_Asignacion.Value = DateTime.Now;
                //txt_Otro.Text = "" + DateTime.Now.ToShortTimeString();
            }
        }
        private void dtp_Cambio_Enter(object sender, EventArgs e)
        {
            if(dtp_Cambio.Value == DateTime.Parse("01-01-1990"))
            {
                dtp_Cambio.Value = DateTime.Now;
            }
        }
        private void dtp_FechaEtapa_Enter(object sender, EventArgs e)
        {
            if(dtp_FechaEtapa.Value == DateTime.Parse("01-01-1990"))
            {
                dtp_FechaEtapa.Value = DateTime.Now;
            }
        }
        private void dtp_Demanda_Enter(object sender, EventArgs e)
        {
          /*  if( dtp_Demanda.Value== DateTime.Parse("01-01-1990"))
            {
                dtp_Demanda.Value = DateTime.Now;
            }*/
        }
        private void dtp_Inscripcion_Enter(object sender, EventArgs e)
        {
            if( dtp_Inscripcion.Value== DateTime.Parse("01-01-1990"))
            {
                dtp_Inscripcion.Value = DateTime.Now;
            }
        }
        private void dtp_MedidaCautelar_Enter(object sender, EventArgs e)
        {
            if( dtp_MedidaCautelar.Value == DateTime.Parse("01-01-1990"))
            {
                dtp_MedidaCautelar.Value = DateTime.Now;
            }
        }
        private void dtp_ActuadoCautelar_Enter(object sender, EventArgs e)
        {
            if( dtp_ActuadoCautelar.Value== DateTime.Parse("01-01-1990"))
            {
                dtp_ActuadoCautelar.Value = DateTime.Now;
            }
        }
        private void dtp_FechaMandato_Enter(object sender, EventArgs e)
        {
            if(dtp_FechaMandato.Value == DateTime.Parse("01-01-1990"))
            {
                dtp_FechaMandato.Value = DateTime.Now;
            }
        }
        private void dtp_Contradiccion_Enter(object sender, EventArgs e)
        {
            if( dtp_Contradiccion.Value == DateTime.Parse("01-01-1990"))
            {
                dtp_Contradiccion.Value = DateTime.Now;
            }
        }
        private void dtp_fechaOrden_Enter(object sender, EventArgs e)
        {
            if( dtp_fechaOrden.Value== DateTime.Parse("01-01-1990"))
            {
                dtp_fechaOrden.Value = DateTime.Now;
            }
        }
        private void dtp_RemateCaptura_Enter(object sender, EventArgs e)
        {
            if( dtp_RemateCaptura.Value== DateTime.Parse("01-01-1990"))
            {
                dtp_RemateCaptura.Value = DateTime.Now;
            }
        }
        private void dtp_AdjuCaptura_Enter(object sender, EventArgs e)
        {
            if( dtp_AdjuCaptura.Value== DateTime.Parse("01-01-1990"))
            {
                dtp_AdjuCaptura.Value = DateTime.Now;
            }
        }
        private void dtp_Tasacion_Enter(object sender, EventArgs e)
        {
            if( dtp_Tasacion.Value == DateTime.Parse("01-01-1990"))
            {
                dtp_Tasacion.Value = DateTime.Now;
            }
        }
        private void dtp_Fecha_Procesal_Enter(object sender, EventArgs e)
        {
            if( dtp_Fecha_Procesal.Value== DateTime.Parse("01-01-1990"))
            {
                dtp_Fecha_Procesal.Value = DateTime.Now;
            }
        }
        private void dtp_Tarea_Administrativa_Enter(object sender, EventArgs e)
        {
            if( dtp_Tarea_Administrativa.Value== DateTime.Parse("01-01-1990"))
            {
                dtp_Tarea_Administrativa.Value = DateTime.Now;
            }
        }
        private void dtp_Pagos_Enter(object sender, EventArgs e)
        {
            if( dtp_Pagos.Value== DateTime.Parse("01-01-1990"))
            {
                dtp_Pagos.Value = DateTime.Now;
            }
        }
        private void dtp_Fecha_Visita_Enter(object sender, EventArgs e)
        {
            if( dtp_Fecha_Visita.Value== DateTime.Parse("01-01-1990"))
            {
                dtp_Fecha_Visita.Value = DateTime.Now;
            }
        }
        private void dtp_Fecha_Pago_Enter(object sender, EventArgs e)
        {
            if( dtp_Fecha_Pago.Value== DateTime.Parse("01-01-1990"))
            {
                dtp_Fecha_Pago.Value = DateTime.Now;
            }
        }
        private void dtp_Pago_Enter(object sender, EventArgs e)
        {
            if(dtp_Pago.Value == DateTime.Parse("01-01-1990"))
            {
                dtp_Pago.Value = DateTime.Now;
            }
        }
        private void dtp_Gestion_Campo_Enter(object sender, EventArgs e)
        {
            if( dtp_Gestion_Campo.Value== DateTime.Parse("01-01-1990"))
            {
                dtp_Gestion_Campo.Value = DateTime.Now;
            }
        }
        private void dtp_FechaEstimada_Enter_1(object sender, EventArgs e)
        {
            if (dtp_FechaEstimada.Value == DateTime.Parse("01-01-1990"))
            {
                dtp_FechaEstimada.Value = DateTime.Now;
            }

        }
        private void dtp_FechaDemanda_Enter(object sender, EventArgs e)
        {
            if (dtp_FechaDemanda.Value == DateTime.Parse("01-01-1990"))
            {
                dtp_FechaDemanda.Value = DateTime.Now;
            }
        }
        private void dtp_FechaAutoFinal_Enter(object sender, EventArgs e)
        {
            if (dtp_FechaAutoFinal.Value == DateTime.Parse("01-01-1990"))
            {
                dtp_FechaAutoFinal.Value = DateTime.Now;
            }
        }
        private void dtp_Apelacion_Enter(object sender, EventArgs e)
        {
            if (dtp_Apelacion.Value == DateTime.Parse("01-01-1990"))
            {
                dtp_Apelacion.Value = DateTime.Now;
            }
        }

        private void CrearModificar_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btn_Exportar_Click(object sender, EventArgs e)
        {
            Documentos doc = new Documentos(txt_CuentaBT.Text);
            doc.Show();
        }

        private void tableLayoutPanel127_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel42_Paint(object sender, PaintEventArgs e)
        {

        }







   }
}


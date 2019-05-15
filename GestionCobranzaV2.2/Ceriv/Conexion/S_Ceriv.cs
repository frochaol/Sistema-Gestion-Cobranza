using System;
using Npgsql;
using NpgsqlTypes;
using Ceriv.Conexion;
using Ceriv.Clases;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Ceriv.Conexion
{
    class S_Ceriv : I_Ceriv
    {
         //string cadenaConexion = "Server=192.168.1.97; port = 5432 ;User Id=postgres;Password=root;Database=Ceriv";
         string cadenaConexion = "Server=localhost; port = 5432 ;User Id=postgres;Password=root;Database=Ceriv";

       /*FUNCION DE CLASES*/
        public bool BienHipotecado(int accion, C_BienHipotecado objetoBienHipotecado)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("spr_bienHipotecado ", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NOMBRE", objetoBienHipotecado.Nombre);
                cmd.Parameters.AddWithValue("_codigo", objetoBienHipotecado.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool EstadoProcesal(int accion, C_EstadoProcesal objetoBienHipotecado)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("spr_estadoprocesal", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NOMBRE", objetoBienHipotecado.Nombre);
                cmd.Parameters.AddWithValue("_codigo", objetoBienHipotecado.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool Trabajador(int accion, C_Trabajador objetoTrabajador)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_TRABAJADOR ", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_DNI_TRABAJADOR", objetoTrabajador.DniTrabajador);
                cmd.Parameters.AddWithValue("_CODIGO_TIPO_TRABAJADOR", objetoTrabajador.CodigoTipoTrabajador);
                cmd.Parameters.AddWithValue("_NOMBRE", objetoTrabajador.NombreTrabajador);
                cmd.Parameters.AddWithValue("_APELLIDO_PATERNO", objetoTrabajador.ApellidoPaterno);
                cmd.Parameters.AddWithValue("_APELLIDO_MATERNO", objetoTrabajador.ApellidoMaterno);
                cmd.Parameters.AddWithValue("_CONTRA", objetoTrabajador.Contra);
                cmd.Parameters.AddWithValue("_DNI_ABOGADO_NUEVO", objetoTrabajador.DniTrabajadorNuevo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool TrabajadorLogin(int dni, string password)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("spr_login ", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_dni", dni);
                cmd.Parameters.AddWithValue("_password", password);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool Expediente(int accion, C_Expediente objetoExpediente)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_EXPEDIENTE", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NUM_EXPEDIENTE", objetoExpediente.NumExpediente);
                cmd.Parameters.AddWithValue("_CODIGO_PROCESO", objetoExpediente.CodigoTipoProceso);
                cmd.Parameters.AddWithValue("_TRABAJADOR_ABOGADO", objetoExpediente.TrabajadorAbogado);
                cmd.Parameters.AddWithValue("_TRABAJADOR_RESPONSABLE", objetoExpediente.TrabajadoResponsable);
                cmd.Parameters.AddWithValue("_TRABAJADOR_SECRETARIO", objetoExpediente.TrabajadorSecretario);
                cmd.Parameters.AddWithValue("_NUM_EXPEDIENTE_22DIGITOS", objetoExpediente.NumExpediente22Digitos);
                cmd.Parameters.AddWithValue("_JUZGADO", objetoExpediente.Juzgado);
                cmd.Parameters.AddWithValue("_CODIGO_CAUTELAR", objetoExpediente.CodigoCautelar);
                cmd.Parameters.AddWithValue("_NUM_JUZGADO", objetoExpediente.NumJuzgado);
                cmd.Parameters.AddWithValue("_EXPEDIENTE_NUEVO", objetoExpediente.ExpedienteNuevo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool Distrito(int accion, C_Distrito objetoDistrito)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_DISTRITO ", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NOMBRE", objetoDistrito.NombreDistrito);
                cmd.Parameters.AddWithValue("_CODIGO_CARTERA", objetoDistrito.CodigoDistrito);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool Persona(int accion, C_Persona objetoPersona)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_PERSONA", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_DOI_CLIENTE", objetoPersona.Doi_cliente);
                cmd.Parameters.AddWithValue("_CODIGO_DISTRITO", objetoPersona.CodigoDistrito);
                cmd.Parameters.AddWithValue("_NOMBRE_COMPLETO", objetoPersona.NombreCompleto);
                cmd.Parameters.AddWithValue("_NOMBRE_CONYUGE",objetoPersona.NombreConyuge);
                cmd.Parameters.AddWithValue("_DOMICILIO_PERSONA",objetoPersona.DomicilioPersona);
                cmd.Parameters.AddWithValue("_DIRECCION_ALTERNA",objetoPersona.DireccionAlterna);
                cmd.Parameters.AddWithValue("_REPRESENTANTE", objetoPersona.Representante);
                cmd.Parameters.AddWithValue("_TELEFONO", objetoPersona.Numero);
                cmd.Parameters.AddWithValue("_CUENTA_BT", objetoPersona.Cuenta_bt);
                cmd.Parameters.AddWithValue("_CONVENIO", objetoPersona.Convenio);
                cmd.Parameters.AddWithValue("_doi_cliente_nuevo", objetoPersona.NuevoDoi);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
 
        }
        public bool Garante(int accion, C_Garante objetoGarante)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_GARANTE", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_OPERACION", objetoGarante.Operacion);
                cmd.Parameters.AddWithValue("_NOMBRE_COMPLETO", objetoGarante.NombreCompleto);
                cmd.Parameters.AddWithValue("_NOMBRE_CONYUGE", objetoGarante.NombreConyuge);
                cmd.Parameters.AddWithValue("_CODIGO_DISTRITO", objetoGarante.CodigoDistrito);
                cmd.Parameters.AddWithValue("_DOMICILIO_GARANTE", objetoGarante.DomicilioGarante);
                cmd.Parameters.AddWithValue("_CODIGO_GARANTE", objetoGarante.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        //
        public bool Liquidacion(int accion, C_Liquidaciones objetoLiquidaciones) 
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_LIQUIDACION", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_CODIGO_TIPOGASTO", objetoLiquidaciones.Codigo_tipogasto);
                cmd.Parameters.AddWithValue("_CODIGO_DETALLE", objetoLiquidaciones.Codigo_detalle);
                cmd.Parameters.AddWithValue("_OPERACION", objetoLiquidaciones.Operacion);
                cmd.Parameters.AddWithValue("_NUM_EXPEDIENTE", objetoLiquidaciones.Num_expediente);
                cmd.Parameters.AddWithValue("_NRO_RECIBO", objetoLiquidaciones.Nro_recibo);
                cmd.Parameters.AddWithValue("_CANTIDAD", objetoLiquidaciones.Cantidad);
                cmd.Parameters.AddWithValue("_MONTO", objetoLiquidaciones.Monto);
                cmd.Parameters.AddWithValue("_NOMBRE_CLIENTE", objetoLiquidaciones.Nombre_cliente);
                cmd.Parameters.AddWithValue("_FECHA_LIQUIDACION", objetoLiquidaciones.Fecha_liquidacion);
                cmd.Parameters.AddWithValue("_CUENTA_BT", objetoLiquidaciones.Cuenta_bt);
                cmd.Parameters.AddWithValue("_CODIGO_LIQUIDACION_DETALLE", objetoLiquidaciones.Codigo_Detalle_liquidacion);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }

        public bool Credito(int accion, C_Credito objetoCredito)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_CREDITO", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_OPERACION", objetoCredito.Operacion);
                cmd.Parameters.AddWithValue("_CUENTA_BT", objetoCredito.CuentaBT);
                cmd.Parameters.AddWithValue("_CODIGO_CARTERA", objetoCredito.CodigoCartera);
                cmd.Parameters.AddWithValue("_CODIGO_MONEDA", objetoCredito.CodigoMoneda);
                cmd.Parameters.AddWithValue("_CODIGO_CIUDAD", objetoCredito.CodigoCiudad);
                cmd.Parameters.AddWithValue("_CODIGO_ESTUDIO", objetoCredito.CodigoEstudio);
                cmd.Parameters.AddWithValue("_MODELO", objetoCredito.Modelo);
                cmd.Parameters.AddWithValue("_CODIGO_TRAMITE", objetoCredito.CodigoTramite);
                cmd.Parameters.AddWithValue("_CASTIGOS", objetoCredito.Castigos);
                cmd.Parameters.AddWithValue("_CDR", objetoCredito.Cdr);
                cmd.Parameters.AddWithValue("_CAPITAL", objetoCredito.Capital);
                cmd.Parameters.AddWithValue("_FECHA_PROTESTO", objetoCredito.FechaProtesto);
                cmd.Parameters.AddWithValue("_AGENCIA", objetoCredito.Agencia);
                cmd.Parameters.AddWithValue("_FECHA_ASIGNACION", objetoCredito.FechaAsignacion);
                cmd.Parameters.AddWithValue("_MONTO_ADMITIDO", objetoCredito.MontoAdmitido);
                cmd.Parameters.AddWithValue("_PRODUCTO_MODULO", objetoCredito.ProductoModulo);
                cmd.Parameters.AddWithValue("_OBSERVACION_TRAMITE", objetoCredito.ObservacionTramite);
                cmd.Parameters.AddWithValue("_FECHA_TRAMITE", objetoCredito.FechaTramite);
                cmd.Parameters.AddWithValue("_EJECUTIVO", objetoCredito.Ejecutivo);
                cmd.Parameters.AddWithValue("_cuenta_bt_nueva", objetoCredito.CuentabtNueva);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;

        }
        public bool Proceso(int accion, C_TipoProceso objetoProceso)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_PROCESO ", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NOMBRE_PROCESO", objetoProceso.NombreProceso);
                cmd.Parameters.AddWithValue("_CODIGO_PROCESO", objetoProceso.CodigoProceso);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;

        }
        public bool Cartera(int accion, C_Cartera objetoCartera)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_CARTERA ", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NOMBRE", objetoCartera.NombreCartera);
                cmd.Parameters.AddWithValue("_CODIGO_CARTERA", objetoCartera.CodigoCartera);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool Ciudad(int accion, C_Ciudad objetoCiudad)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_CIUDAD ", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NOMBRE", objetoCiudad.NombreCiudad);
                cmd.Parameters.AddWithValue("_CODIGO_CIUDAD", objetoCiudad.CodigoCiudad);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool Estudio(int accion, C_Estudio objetoEstudio)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_ESTUDIO ", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NOMBRE", objetoEstudio.NombreEstudio);
                cmd.Parameters.AddWithValue("_CODIGO_ESTUDIO", objetoEstudio.CodigoEstudio);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool Juzgado(int accion, C_Juzgado objetoJuzgado)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_JUZGADO ", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NOMBRE", objetoJuzgado.NombreJuzgado);
                cmd.Parameters.AddWithValue("_CODIGO_JUZGADO", objetoJuzgado.CodigoJuzgado);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool FormaMedidaCautelar(int accion, C_FormaMedidaCautelar objetoFormaMedidaCautelar)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("spr_FormaMedidaCautelar", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NOMBRE", objetoFormaMedidaCautelar.Nombre);
                cmd.Parameters.AddWithValue("_codigo", objetoFormaMedidaCautelar.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool RangoHipotecado(int accion, C_RangoHipotecado objetoRangoHipotecado)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_RANGOHIPOTECA", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NOMBRE", objetoRangoHipotecado.NombreRangoHipotecado);
                cmd.Parameters.AddWithValue("_CODIGO_RANGO_HIPOTECA", objetoRangoHipotecado.CodigoRangoHipotecado);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool BienEmbargado(int accion, C_BienEmbargado objetoBienEmbargado)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_BIENEMBARGADO", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NOMBRE", objetoBienEmbargado.Nombre);
                cmd.Parameters.AddWithValue("_CODIGO_BIENEMBARGADO", objetoBienEmbargado.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;

 
        }
        public bool SeguimientoProceso(int accion, C_SeguimientoProceso objetoSeguimientoProceso)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("spr_seguimientoProceso", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_estadoProcesal", objetoSeguimientoProceso.EstadoProcesal);
                cmd.Parameters.AddWithValue("_fechaestadoProcesal", objetoSeguimientoProceso.FechaEstadoProcesal);
                cmd.Parameters.AddWithValue("_tareaJudicial", objetoSeguimientoProceso.TareaJudicial);
                cmd.Parameters.AddWithValue("_fechatareaadminitrativa", objetoSeguimientoProceso.FechaTareaAdministrativa);
                cmd.Parameters.AddWithValue("_tareaadminitrativa", objetoSeguimientoProceso.TareaAdministrativa);
                cmd.Parameters.AddWithValue("estadotareajudicial", objetoSeguimientoProceso.EstadoTareaJudicial);
                cmd.Parameters.AddWithValue("_estadotareaadministrativa", objetoSeguimientoProceso.EstadoTareaAdministrativa);
                cmd.Parameters.AddWithValue("_convenio", objetoSeguimientoProceso.Convenio);
                cmd.Parameters.AddWithValue("_incidencia", objetoSeguimientoProceso.Incidencia);
                cmd.Parameters.AddWithValue("_detalle_incidencia", objetoSeguimientoProceso.DetalleIncidencia);
                cmd.Parameters.AddWithValue("_num_expediente", objetoSeguimientoProceso.Num_expediente);
                cmd.Parameters.AddWithValue("_detalle_convenio", objetoSeguimientoProceso.DetalleConvenio);
                cmd.Parameters.AddWithValue("_codigo", objetoSeguimientoProceso.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool DetalleMCHipoteca(int accion, C_Detalle_MC_Hipoteca objetoDetalleMCHipoteca)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_CANCELACION_PAGOS", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_CUENTA_BT", objetoDetalleMCHipoteca.CuentaBT);
                cmd.Parameters.AddWithValue("_MONTO_DEVOLUCION", objetoDetalleMCHipoteca.MontoDevolucion);
                cmd.Parameters.AddWithValue("_MOTIVO_DEVOLUCION", objetoDetalleMCHipoteca.MotivoDevolucion);
                cmd.Parameters.AddWithValue("_DESCRIPCION_INMUEBLE", objetoDetalleMCHipoteca.Descripcion);
                cmd.Parameters.AddWithValue("_CODIGO_CANCELACION",objetoDetalleMCHipoteca.CodigoCancelacion);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool GestionCampo(int accion, C_GestionCampo objetoGestionCampo)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_GESTIONCAMPO", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NUM_EXPEDIENTE", objetoGestionCampo.Num_expediente);
                cmd.Parameters.AddWithValue("_GESTION_CAMPO", objetoGestionCampo.GestionCampo);
                cmd.Parameters.AddWithValue("_CONTACTO_PARIENTE", objetoGestionCampo.ContactoPariente);
                cmd.Parameters.AddWithValue("_NOMBRE_PARIENTE", objetoGestionCampo.NombrePariente);
                cmd.Parameters.AddWithValue("_NUEVO_DOM_TELE", objetoGestionCampo.NuevoDomTele);
                cmd.Parameters.AddWithValue("_DETALLE", objetoGestionCampo.Detalle);
                cmd.Parameters.AddWithValue("_FECHA_PAGO", objetoGestionCampo.FechaPago.Date);
                cmd.Parameters.AddWithValue("_MONTO_PAGO", objetoGestionCampo.MontoPago);
                cmd.Parameters.AddWithValue("_FECHA_GESTION", objetoGestionCampo.FechaGestion);
                cmd.Parameters.AddWithValue("_NIEGA_PAGO", objetoGestionCampo.NiegaPago);
                cmd.Parameters.AddWithValue("_HORA_LLAMADA", objetoGestionCampo.HoraGestion);
                cmd.Parameters.AddWithValue("_DNI_TRABAJADOR", objetoGestionCampo.DniTrabajador);
                cmd.Parameters.AddWithValue("_DETALLE_RESULTADO", objetoGestionCampo.DetalleResultado);
                cmd.Parameters.AddWithValue("_INUBICABLE", objetoGestionCampo.Inubicable);
                cmd.Parameters.AddWithValue("_NUM_GESTION", objetoGestionCampo.NumGestion);
                cmd.Parameters.AddWithValue("_DESCRIPCION_INMUEBLE", objetoGestionCampo.DescripcionInmueble);
                cmd.Parameters.AddWithValue("_DUENO_BIEN", objetoGestionCampo.DuenoBien);
                cmd.Parameters.AddWithValue("_TIPO_SOLUCION", objetoGestionCampo.TipoSolucion);
                cmd.Parameters.AddWithValue("_REPORTE", objetoGestionCampo.Reporte);
                cmd.Parameters.AddWithValue("_CODIGO_GESTION", objetoGestionCampo.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool Auditoria(int accion, C_AuditoriaCeriv objetoAuditoria)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_AUDITORIA_CERIV", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_DNI_TRABAJADOR", objetoAuditoria.DniTrabajador);
                cmd.Parameters.AddWithValue("_OBSERVACION", objetoAuditoria.Observacion);
                cmd.Parameters.AddWithValue("_CAMPO", objetoAuditoria.Campo);
                cmd.Parameters.AddWithValue("_CUENTA_BT", objetoAuditoria.CuentaBT);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
  
        }
        public bool ProcesoPrincipal(int accion, C_Proceso objetoProceso)
       {
           bool res = false;
           NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
           try
           {
               cnn.Open();
               NpgsqlCommand cmd = new NpgsqlCommand("SPR_PROCESOPRINCIPAL", cnn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Clear();
               cmd.Parameters.AddWithValue("_ACCION", accion);
               cmd.Parameters.AddWithValue("_NUM_EXPEDIENTE", objetoProceso.Num_expediente);
               cmd.Parameters.AddWithValue("_CODIGO_MACRO",objetoProceso.CodigoMacro);
               cmd.Parameters.AddWithValue("_CODIGO_MICRO", objetoProceso.CodigoMicro);
               //cmd.Parameters.AddWithValue("_CODIGO_ETAPA",objetoProceso.CodigoEtapa);
               cmd.Parameters.AddWithValue("_CODIGO_MEDIDA",objetoProceso.CodigoMedida);
               cmd.Parameters.AddWithValue("_TIEMPO",objetoProceso.Tiempo);
               cmd.Parameters.AddWithValue("_FECHA_ETAPA",objetoProceso.FechaEtapa);
               cmd.Parameters.AddWithValue("_FECHA_INSCRIPCION",objetoProceso.FechaInscripcion);
               cmd.Parameters.AddWithValue("_ESTADO_CAUTELAR",objetoProceso.EstadoCautelar);
               cmd.Parameters.AddWithValue("_FECHA_MEDIDA_CAUTELAR",objetoProceso.FechaMedidaCautelar);
               cmd.Parameters.AddWithValue("_VIGENCIA_MC",objetoProceso.VigenciaMC);
               cmd.Parameters.AddWithValue("_FECHA_ACTUADO_CAUTELAR",objetoProceso.FechaActuadoCautelar);
               cmd.Parameters.AddWithValue("_DEVOLUCION_CEDULA", objetoProceso.DevolucionCedula);
               cmd.Parameters.AddWithValue("_CODIGO_PROCESO",objetoProceso.Funcion);
               cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
               cmd.ExecuteNonQuery();
               res = (bool)cmd.Parameters[":resultado"].Value;
           }
           catch (Exception ex)
           {
               return false;
           }
           finally
           {
               cnn.Close();
           }
           return res;
       }
        public bool Bien(int accion, C_Bien objetoBien)
       {
           bool res = false;
           NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
           try
           {
               cnn.Open();
               NpgsqlCommand cmd = new NpgsqlCommand("SPR_BIEN", cnn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Clear();
               cmd.Parameters.AddWithValue("_ACCION", accion);
               cmd.Parameters.AddWithValue("_CODIGO_TIPOBIEN",objetoBien.TipoBien);
               cmd.Parameters.AddWithValue("_CODIGO_RANGO",objetoBien.CodigoRango);
               cmd.Parameters.AddWithValue("_NOMBRE_BIEN",objetoBien.NombreBien);
               cmd.Parameters.AddWithValue("_MONTO_GARANTIA",objetoBien.MontoGarantia);
               cmd.Parameters.AddWithValue("_MONTO_TASACION",objetoBien.MontoTasacion);
               cmd.Parameters.AddWithValue("_FECHA_TASACION",objetoBien.FechaTasacion);
               cmd.Parameters.AddWithValue("_PARTIDA_PLACA",objetoBien.PartidaPlaca);
               cmd.Parameters.AddWithValue("_PORCENTAJE_DERECHOS",objetoBien.PorcentajeDerechos);
               cmd.Parameters.AddWithValue("_DESCRIPCION",objetoBien.Descripcion);
               cmd.Parameters.AddWithValue("_VALOR_COMERCIAL", objetoBien.ValorComercial);
               cmd.Parameters.AddWithValue("_CODIGO_CIUDAD", objetoBien.Codigo_ciudad);
               cmd.Parameters.AddWithValue("_CODIGO_DISTRITO", objetoBien.Codigo_distrito);
               cmd.Parameters.AddWithValue("_NUM_EXPEDIENTE", objetoBien.Num_expediente);
               cmd.Parameters.AddWithValue("_MARCA", objetoBien.Marca);
               cmd.Parameters.AddWithValue("_MODELO", objetoBien.Modelo);
               cmd.Parameters.AddWithValue("_CODIGO_BIEN",objetoBien.Codigo);
               cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
               cmd.ExecuteNonQuery();
               res = (bool)cmd.Parameters[":resultado"].Value;
           }
           catch (Exception ex)
           {
               return false;
           }
           finally
           {
               cnn.Close();
           }
           return res;
       }
        public bool OtrasCargas(int accion, C_OtrasCargas objetoOtrasCargas)
       {
           bool res = false;
           NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
           try
           {
               cnn.Open();
               NpgsqlCommand cmd = new NpgsqlCommand("SPR_OTRASCARGAS", cnn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Clear();
               cmd.Parameters.AddWithValue("_ACCION", accion);
               cmd.Parameters.AddWithValue("_CODIGO_BIEN", objetoOtrasCargas.CodigoBien);
               cmd.Parameters.AddWithValue("_DESCRIPCION_BIEN",objetoOtrasCargas.DescripcionBien);
               cmd.Parameters.AddWithValue("_ACREEDOR",objetoOtrasCargas.Acreedor);
               cmd.Parameters.AddWithValue("_RANGO",objetoOtrasCargas.Rango);
               cmd.Parameters.AddWithValue("_MONTO_GARANTIA", objetoOtrasCargas.MontoGarantia);
               cmd.Parameters.AddWithValue("_MONTO_ADEUDADO",objetoOtrasCargas.MontoAdeudado);
               cmd.Parameters.AddWithValue("_CODIGO",objetoOtrasCargas.Codigo);
               cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
               cmd.ExecuteNonQuery();
               res = (bool)cmd.Parameters[":resultado"].Value;
           }
           catch (Exception ex)
           {
               return false;
           }
           finally
           {
               cnn.Close();
           }
           return res;
 
       }
        public bool Pagos(int accion, C_Pagos objetoPagos)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_PAGOS", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_TIPO_SOLUCION",objetoPagos.TipoSolucion);
                cmd.Parameters.AddWithValue("_PAGO", objetoPagos.Pago);
                cmd.Parameters.AddWithValue("_COMISION",objetoPagos.Comision);
                cmd.Parameters.AddWithValue("_FECHA_PAGO",objetoPagos.FechaPago);
                cmd.Parameters.AddWithValue("_NUM_EXPEDIENTE", objetoPagos.Num_expediente);
                cmd.Parameters.AddWithValue("_CODIGO", objetoPagos.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
 
        }
        public bool GestionLlamada(int accion, C_GestionLlamadas objetoGestionLlamada)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_GESTIONLLAMADA", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NUM_EXPEDIENTE", objetoGestionLlamada.Num_expediente);
                cmd.Parameters.AddWithValue("_TELEFONO_CONTACTO", objetoGestionLlamada.TelefonoContacto);
                cmd.Parameters.AddWithValue("_CONTACTO_CLIENTE", objetoGestionLlamada.ContactoCliente);
                cmd.Parameters.AddWithValue("_CONTACTO_PARIENTE", objetoGestionLlamada.ContactoPariente);
                cmd.Parameters.AddWithValue("_NOMBRE_PARIENTE", objetoGestionLlamada.NombrePariente);
                cmd.Parameters.AddWithValue("_TELEFONO_NO_CORRESPONDE", objetoGestionLlamada.TelefonoNoCorresponde);
                cmd.Parameters.AddWithValue("_FECHA_VISITA_ESTUDIO", objetoGestionLlamada.FechaVisitaEstudio.Date);
                cmd.Parameters.AddWithValue("_FECHA_PAGO", objetoGestionLlamada.FechaPago.Date);
                cmd.Parameters.AddWithValue("_MONTO_PAGO", objetoGestionLlamada.MontoPago);
                cmd.Parameters.AddWithValue("_DUENO_BIEN", objetoGestionLlamada.DuenoBien);
                cmd.Parameters.AddWithValue("_NIEGA_PAGO", objetoGestionLlamada.NiegaPago);
                cmd.Parameters.AddWithValue("_DNI_TRABAJADOR", objetoGestionLlamada.DniTrabajador);
                cmd.Parameters.AddWithValue("_HORA_LLAMADA", objetoGestionLlamada.HoraLlamada);
                cmd.Parameters.AddWithValue("_DETALLE_RESULTADO", objetoGestionLlamada.DetalleResultado);
                cmd.Parameters.AddWithValue("_NUM_GESTION", objetoGestionLlamada.NumGestion);
                cmd.Parameters.AddWithValue("_TIPO_SOLUCION", objetoGestionLlamada.TipoSolucion);
                cmd.Parameters.AddWithValue("_REPORTE", objetoGestionLlamada.Reporte);
                cmd.Parameters.AddWithValue("_CODIGO_GESTION", objetoGestionLlamada.CodigoGestionLlamada);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool Fechas(int accion, C_Fechas objetoFechas)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_FECHA", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_FECHA_MANDATO",objetoFechas.FechaMando.Date);
                cmd.Parameters.AddWithValue("_FECHA_CONTRADICCION",objetoFechas.FechaContradiccion.Date);
                cmd.Parameters.AddWithValue("_FECHA_ORDEN",objetoFechas.FechaOrden.Date);
                cmd.Parameters.AddWithValue("_FECHA_REMATECAPTURA",objetoFechas.FechaRematecaptura.Date);
                cmd.Parameters.AddWithValue("_FECHA_ADJUCAPTURA", objetoFechas.FechaAdjucaptura.Date);
                cmd.Parameters.AddWithValue("_FECHA_DEMANDA", objetoFechas.FechaDemanda.Date);
                cmd.Parameters.AddWithValue("_FECHA_AUTO_FINAL", objetoFechas.FechaAutoFinal.Date);
                cmd.Parameters.AddWithValue("_NUM_EXPEDIENTE", objetoFechas.Num_Expediente);
                cmd.Parameters.AddWithValue("_FECHA_APELACION", objetoFechas.FechaApelacion);
                cmd.Parameters.AddWithValue("_CODIGO_FECHAS", objetoFechas.Funcion);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool BH(int accion, C_BH objetoBH)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_BIENH", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_CUENTA_BT", objetoBH.CuentaBT);
                cmd.Parameters.AddWithValue("_CODIGO_HIPOTECADO", objetoBH.CodigoHipotecado);
                cmd.Parameters.AddWithValue("_MONTO_HIPOTECADO", objetoBH.MontoHipotecado);
                cmd.Parameters.AddWithValue("_MONTO_DEMANDADO", objetoBH.MontoDemandado);
                cmd.Parameters.AddWithValue("_FECHA_DEMANDA", objetoBH.FechaDemanda);
                cmd.Parameters.AddWithValue("_CODIGO_FORMAMEDIDACAUTELAR", objetoBH.CodigoFMC);
                cmd.Parameters.AddWithValue("_FECHA_PRES_MC", objetoBH.FechaPRESMC);
                cmd.Parameters.AddWithValue("_CODIGO_BIENHIPOTECADO", objetoBH.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool BE(int accion, C_BE objetoBE)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_BIENE", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_CUENTA_BT", objetoBE.CuentaBT);
                cmd.Parameters.AddWithValue("_CODIGO_EMBARGADO", objetoBE.CodigoEmbargado);
                cmd.Parameters.AddWithValue("_FECHA_EMBARGO", objetoBE.FechaEmbargo);
                cmd.Parameters.AddWithValue("_PARTIDA_PLACA",objetoBE.PartidaPlaca);
                cmd.Parameters.AddWithValue("_UBICACION_BIEN", objetoBE.UbicacionBien);
                cmd.Parameters.AddWithValue("_CODIGO_RANGO_HIPOTECA", objetoBE.CodigoRangoHipoteca);
                cmd.Parameters.AddWithValue("_MONTO_EMBARGADO",objetoBE.MontoEmbargado);
                cmd.Parameters.AddWithValue("_CODIGO_BIENEMBARGADO", objetoBE.CodigoE);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool Proyeccion(int accion, C_Proyeccion objetoProyeccion)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_PROYECCION", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NUM_EXPEDIENTE", objetoProyeccion.Expediente);
                cmd.Parameters.AddWithValue("_FECHA_ESTIMADA", objetoProyeccion.FechaEstimada);
                cmd.Parameters.AddWithValue("_DEVUELTO", objetoProyeccion.Devuelto);
                cmd.Parameters.AddWithValue("_MOTIVO_DEVOLUCION", objetoProyeccion.MotivoDevolucion);
                cmd.Parameters.AddWithValue("_TELEFONO", objetoProyeccion.Telefono);
                cmd.Parameters.AddWithValue("_CODIGO", objetoProyeccion.Funcion);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool Historico(int accion,C_Historico objetoHistorico)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_HISTORICO", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_accion", accion);
                cmd.Parameters.AddWithValue("_NUM_EXPEDIENTE", objetoHistorico.Expediente);
                cmd.Parameters.AddWithValue("_TEXTO", objetoHistorico.Texto);
                cmd.Parameters.AddWithValue("_LLAMADA", objetoHistorico.Llamada);
                cmd.Parameters.AddWithValue("_CAMPO", objetoHistorico.Campo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool Ubicacion(int accion, C_Ubicacion objetoUbicacion)
        {
            bool res = true;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                if (objetoUbicacion.Codigo != 0)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("UPDATE ubicacion SET Imagen = (:Imagen1) , ubicacion = (:Ubicacion1), id_ubicacion = (:idUbicacion), visita_activa = (:visita) WHERE codigo =(:Codigo1);", cnn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();

                    NpgsqlParameter param1 = new NpgsqlParameter("Imagen1", NpgsqlDbType.Bytea);
                    param1.Value = objetoUbicacion.Imagen;
                    cmd.Parameters.Add(param1);
                    NpgsqlParameter param2 = new NpgsqlParameter("Ubicacion1", NpgsqlDbType.Varchar);
                    param2.Value = objetoUbicacion.Url;
                    cmd.Parameters.Add(param2);
                    NpgsqlParameter param3 = new NpgsqlParameter("Codigo1", NpgsqlDbType.Integer);
                    param3.Value = objetoUbicacion.Codigo;
                    cmd.Parameters.Add(param3);
                    NpgsqlParameter param4 = new NpgsqlParameter("idUbicacion", NpgsqlDbType.Integer);
                    param4.Value = objetoUbicacion.Id_tipoUbicacion;
                    cmd.Parameters.Add(param4);
                    NpgsqlParameter param5 = new NpgsqlParameter("visita", NpgsqlDbType.Integer);
                    param5.Value = objetoUbicacion.Visita;
                    cmd.Parameters.Add(param5);
                   /* NpgsqlParameter param3 = new NpgsqlParameter("Num_expediente1", NpgsqlDbType.Varchar);
                    param3.Value = objetoUbicacion.NumExpediente;
                    cmd.Parameters.Add(param3);*/
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                else
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into  ubicacion (num_expediente,ubicacion,imagen,id_ubicacion, visita_activa) values (:num_expediente1,:ubicacion1,:Imagen1,:TipoUibcacion,:visita) ;", cnn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();

                    NpgsqlParameter param1 = new NpgsqlParameter("num_expediente1", NpgsqlDbType.Varchar);
                    param1.Value = objetoUbicacion.NumExpediente;
                    cmd.Parameters.Add(param1);
                    NpgsqlParameter param2 = new NpgsqlParameter("Ubicacion1", NpgsqlDbType.Varchar);
                    param2.Value = objetoUbicacion.Url;
                    cmd.Parameters.Add(param2);
                    NpgsqlParameter param3 = new NpgsqlParameter("Imagen1", NpgsqlDbType.Bytea);
                    param3.Value = objetoUbicacion.Imagen;
                    cmd.Parameters.Add(param3);
                    NpgsqlParameter param4 = new NpgsqlParameter("TipoUibcacion", NpgsqlDbType.Integer);
                    param4.Value = objetoUbicacion.Id_tipoUbicacion;
                    cmd.Parameters.Add(param4);
                    NpgsqlParameter param5 = new NpgsqlParameter("visita", NpgsqlDbType.Integer);
                    param5.Value = objetoUbicacion.Visita;
                    cmd.Parameters.Add(param5);

                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }

        public bool CuentaBT(int accion, C_Credito objetoCredito)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_CUENTABT", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_accion", accion);
                cmd.Parameters.AddWithValue("_CUENTA_BT", objetoCredito.CuentaBT);
                cmd.Parameters.AddWithValue("_CUENTA_BT_NUEVA", objetoCredito.CuentabtNueva);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool ExpedienteCredito(int accion, C_Expediente objetoExpediente)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_DETALLE_EXPEDIENTE_CREDITO", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_accion", accion);
                cmd.Parameters.AddWithValue("_NUM_EXPEDIENTE", objetoExpediente.NumExpediente);
                cmd.Parameters.AddWithValue("_OPERACION",  objetoExpediente.Operacion);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }

        public bool F_Seguimiento(int accion, C_SeguimientoProceso objetoSeguimiento)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_ACTUALIZAR_MACRO_MICRO", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_accion", accion);
                cmd.Parameters.AddWithValue("_CODIGO_MACRO", objetoSeguimiento.CodigoMacro);
                cmd.Parameters.AddWithValue("_CODIGO_MICRO", objetoSeguimiento.CodigoMicro);
                cmd.Parameters.AddWithValue("_NUM_EXPEDIENTE", objetoSeguimiento.Num_expediente);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool ReporteSeguimiento(int accion, C_ReporteSeguimiento objetoReporteSeguimiento)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_REPORTE_SEGUIMIENTO", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_accion", accion);
                cmd.Parameters.AddWithValue("_NUM_EXPEDIENTE", objetoReporteSeguimiento.Num_Expediente1);
                cmd.Parameters.AddWithValue("_ESTADO_PROCESAL", objetoReporteSeguimiento.EstadoProcesal);
                cmd.Parameters.AddWithValue("_FECHA_ESTADO_PROCESAL", objetoReporteSeguimiento.Fecha_EstadoProcesal);
                cmd.Parameters.AddWithValue("_TAREA_JUDICIAL", objetoReporteSeguimiento.Tarea_Judicial);
                cmd.Parameters.AddWithValue("_FECHA_TAREA_ADMINISTRATIVA", objetoReporteSeguimiento.Fecha_TarejaAdministrativa);
                cmd.Parameters.AddWithValue("_TAREA_ADMINISTRATIVA", objetoReporteSeguimiento.TareaAdministrativa);
                cmd.Parameters.AddWithValue("_INCIDENCIA", objetoReporteSeguimiento.Incidencia);
                cmd.Parameters.AddWithValue("_DETALLE_INCIDENCIA", objetoReporteSeguimiento.DetalleIncidencia);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }

        public bool MacroEtapa(int accion, C_Macro objetoMacroEtapa) {

            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("spr_macroEtapa", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NOMBRE", objetoMacroEtapa.Nombre);
                cmd.Parameters.AddWithValue("_codigo", objetoMacroEtapa.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool MicroEtapa(int accion, C_Micro objetoMicroEtapa) {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("spr_microEtapa", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NOMBRE", objetoMicroEtapa.Nombre);
                cmd.Parameters.AddWithValue("_codigo", objetoMicroEtapa.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }

        public bool MicroEstado(int accion, C_Micro objetoMicroEtapa) {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("spr_MICROESTADO", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_CODIGOESTADO", objetoMicroEtapa.CodigoEstado);
                cmd.Parameters.AddWithValue("_codigo", objetoMicroEtapa.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }

        public bool MacroEstado(int accion, C_Macro objetoMacroEtapa) {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("spr_MACROESTADO", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_CODIGOESTADO", objetoMacroEtapa.CodigoEstadoMacro);
                cmd.Parameters.AddWithValue("_codigo", objetoMacroEtapa.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }

        public bool Liquidaciones(C_Liquidaciones objLiquidaciones) 
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("INSERT INTO LIQUIDACION_DETALLE (nro_recibo, cantidad, monto, nombre_cliente, fecha_liquidacion, operacion, num_expediente, codigo_tipogasto, codigo_detalle, cuenta_bt, flag) VALUES ('" + objLiquidaciones.Nro_recibo + "','" + objLiquidaciones.Cantidad + "','" + objLiquidaciones.Monto + "','" + objLiquidaciones.Nombre_cliente + "','" + objLiquidaciones.Fecha_liquidacion + "','" + objLiquidaciones.Operacion + "','" + objLiquidaciones.Num_expediente + "'," + objLiquidaciones.Codigo_tipogasto + "," + objLiquidaciones.Codigo_detalle + ",'"+objLiquidaciones.Cuenta_bt+"',"+objLiquidaciones.Flag+");", cnn);
                npgsqlCommand.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
                res = true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally 
            {
                cnn.Close();
            }
            return res;
            
        }

        public bool LiquidacionesEliminar(C_Liquidaciones objLiquidaciones) 
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("UPDATE LIQUIDACION_DETALLE SET FLAG = 0 WHERE CODIGO_LIQUIDACION_DETALLE = "+objLiquidaciones.Codigo_Detalle_liquidacion+";", cnn);
                npgsqlCommand.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
                res = true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }

        public bool LiquidacionesModificar(C_Liquidaciones objLiquidaciones) 
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("UPDATE LIQUIDACION_DETALLE SET NRO_RECIBO = '"+objLiquidaciones.Nro_recibo+"', CANTIDAD = '"+objLiquidaciones.Cantidad+"', MONTO = '"+objLiquidaciones.Monto+"', FECHA_LIQUIDACION = '"+objLiquidaciones.Fecha_liquidacion+"', CODIGO_TIPOGASTO = "+objLiquidaciones.Codigo_tipogasto+", CODIGO_DETALLE = "+objLiquidaciones.Codigo_detalle+" WHERE CODIGO_LIQUIDACION_DETALLE = " + objLiquidaciones.Codigo_Detalle_liquidacion + ";", cnn);
                npgsqlCommand.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
                res = true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }

        //MEDIDA CAUTELAR HIPOTECA
        public bool MedidaCautelarHipoteca(int accion, C_MedidaCautelarHipoteca objetoMedidaCautelarHipoteca)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_MEDIDACAUTELAR_HIPOTECA", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_CODIGO_BIENHIPOTECADO", objetoMedidaCautelarHipoteca.CodigoBienHipotecado);
                cmd.Parameters.AddWithValue("_CODIGO_BIENEMBARGADO", objetoMedidaCautelarHipoteca.CodigoBienEmbargado);
                cmd.Parameters.AddWithValue("_MONTO_TASACION", objetoMedidaCautelarHipoteca.MontoTasacion);
                cmd.Parameters.AddWithValue("_FECHA_ULTASACION", objetoMedidaCautelarHipoteca.FechaUltTasacion.Date);
                cmd.Parameters.AddWithValue("_VALOR_COMERCIAL", objetoMedidaCautelarHipoteca.ValorComercial);
                cmd.Parameters.AddWithValue("_ESTADO_CAUTELAR", objetoMedidaCautelarHipoteca.EstadoCautelar);
                cmd.Parameters.AddWithValue("_FECHA_ULTACTCAUTELAR", objetoMedidaCautelarHipoteca.FechaUltActCautelar.Date);
                cmd.Parameters.AddWithValue("_OTROS_EMBARGOS", objetoMedidaCautelarHipoteca.OtrosEmbargos);
                cmd.Parameters.AddWithValue("_MONTO_OTROS_EMBARGOS", objetoMedidaCautelarHipoteca.MontoOtrosEmbargos);
                cmd.Parameters.AddWithValue("_PORCENTAJE_EMBARGO", objetoMedidaCautelarHipoteca.PorcentajeEmbargo);
                cmd.Parameters.AddWithValue("_VIGENCIA_MC", objetoMedidaCautelarHipoteca.VigenciaMC);
                cmd.Parameters.AddWithValue("_CODIGO_MCHIPOTECA", objetoMedidaCautelarHipoteca.CodigoMCH);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }


        /* FUNCION MOSTRAR / CARGAR COMBOBOX*/

        public List<C_Trabajador> TrabajadorMostrar()
        {
            List<C_Trabajador> lista = new List<C_Trabajador>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select dni_trabajador, nombre, apellido_paterno, apellido_materno, contra, codigo_tipo_trabajador from trabajador where flag = 1 order by NOMBRE", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Trabajador
                        {
                            DniTrabajador = rd.GetInt32(0),
                            NombreTrabajador = rd.GetString(1),
                            ApellidoPaterno = rd.GetString(2),
                            ApellidoMaterno = rd.GetString(3),
                            Contra = rd.GetString(4),
                            CodigoTipoTrabajador = rd.GetInt32(5)

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_TipoTrabajador> TipoTrabajadorMostrar()
        {
            List<C_TipoTrabajador> lista = new List<C_TipoTrabajador>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_tipo_trabajador, nombre from tipo_trabajador where flag = 1 order by nombre", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_TipoTrabajador
                        {
                            CodigoTipoTrabajador = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Distrito> DistritoMostrar()
        {
            List<C_Distrito> lista = new List<C_Distrito>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_distrito, nombre from distrito where flag = 1 ORDER BY NOMBRE", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Distrito
                        {
                            CodigoDistrito = rd.GetInt32(0),
                            NombreDistrito = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Moneda> MonedaMostrar()
        {
            List<C_Moneda> lista = new List<C_Moneda>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_moneda, nombre from moneda where codigo_moneda is not null order by nombre", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Moneda
                        {
                            CodigoMoneda = rd.GetInt32(0),
                            NombreMoneda = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;

        }
        

        public List<C_Trabajador> AbogadoMostrar()
        {
            List<C_Trabajador> lista = new List<C_Trabajador>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select dni_trabajador, nombre, apellido_paterno, apellido_materno from trabajador where flag = 1 ORDER BY NOMBRE;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Trabajador
                        {
                            DniTrabajador = rd.GetInt32(0),
                            NombreTrabajador = rd.GetString(1),
                            ApellidoPaterno = rd.GetString(2),
                            ApellidoMaterno = rd.GetString(3)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;

        }
        public List<C_Expediente> ExpedienteMostrar()
        {
            List<C_Expediente> lista = new List<C_Expediente>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT num_expediente FROM expediente where flag = 1 order by num_expediente desc;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Expediente

                        {
                            NumExpediente = rd.GetString(0)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }

            return lista;
        }
        public List<C_Trabajador> ResponsableMostrar()
        {
            List<C_Trabajador> lista = new List<C_Trabajador>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select dni_trabajador, nombre, apellido_paterno, apellido_materno from trabajador where flag = 1 order by nombre", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Trabajador
                        {
                            DniTrabajador = rd.GetInt32(0),
                            NombreTrabajador = rd.GetString(1),
                            ApellidoPaterno = rd.GetString(2),
                            ApellidoMaterno = rd.GetString(3)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }

            return lista;

        }
        public List<C_Credito> OperacionMostrar(string codigo)
        {
            List<C_Credito> lista = new List<C_Credito>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT OPERACION FROM CREDITO_DETALLE WHERE CUENTA_BT ='"+ codigo + "' AND FLAG = 1 ORDER BY OPERACION ASC", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Credito
                        {
                            Operacion = rd.GetString(0)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Credito> OperacionTodoMostrar()
        {
            List<C_Credito> lista = new List<C_Credito>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT OPERACION FROM CREDITO_DETALLE ORDER BY OPERACION ASC", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Credito
                        {
                            Operacion = rd.GetString(0)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }

        public List<C_TipoUbicacion> TipoUbicacionMostrar() {

            List<C_TipoUbicacion> lista = new List<C_TipoUbicacion>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT ID_UBICACION, NOMBRE_UBICACION FROM TIPO_UBICACION WHERE FLAG = 1 ORDER BY NOMBRE_UBICACION ASC", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_TipoUbicacion
                        {
                            IdTipoUbicacion = rd.GetInt32(0),
                            NombreTipoUbicacion = rd.GetString(1)
                           
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;       
        
        }


        //ACA ESTA CHIBOLO

      /*  public List<C_Proceso> Procesito(string codigo)
        {
            List<C_Proceso> lista = new List<C_Proceso>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO_PROCESO,NOMBRE_PROCESO FROM VW_PROCESOLMAO WHERE CUENTA_BT = '" + codigo + "' order by NOMBRE_PROCESO ;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Proceso
                        {
                            CodigoEtapa = rd.GetInt32(0),
                            Nombre_proceso = rd.GetString(1)

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }*/
        public List<C_TipoProceso> ProcesoMostrar()
        {
            List<C_TipoProceso> lista = new List<C_TipoProceso>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_proceso, nombre_proceso from tipo_proceso where flag = 1 order by nombre_proceso", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_TipoProceso
                        {
                            CodigoProceso = rd.GetInt32(0),
                            NombreProceso = rd.GetString(1)

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Credito> TramiteMostrar() 
        {
            List<C_Credito> lista = new List<C_Credito>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_tramite, nombre_tramite from tramite", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Credito
                        {
                            CodigoTramite = rd.GetInt32(0),
                            NombreTramite = rd.GetString(1)

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Cartera> CarteraMostrar()
        {
            List<C_Cartera> lista = new List<C_Cartera>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_cartera, nombre from cartera where flag = 1 order by nombre", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Cartera
                        {
                            CodigoCartera = rd.GetInt32(0),
                            NombreCartera = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_CarteraPersona> CarteraPersonaMostrar()
        {
            List<C_CarteraPersona> lista = new List<C_CarteraPersona>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_cartera, doi_cliente, nombre_completo from vw_credito_detalle order by nombre_completo", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_CarteraPersona
                        {
                            CodigoCartera = rd.GetInt32(0),
                            Dni = rd.GetString(1),
                            NombrePersona = rd.GetString(2)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Ciudad> CiudadMostrar()
        {
            List<C_Ciudad> lista = new List<C_Ciudad>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_ciudad, nombre from ciudad where flag = 1", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Ciudad
                        {
                            CodigoCiudad = rd.GetInt32(0),
                            NombreCiudad = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Estudio> EstudioMostrar()
        {
            List<C_Estudio> lista = new List<C_Estudio>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_estudio, nombre from estudio where flag = 1 order by nombre", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Estudio
                        {
                            CodigoEstudio = rd.GetInt32(0),
                            NombreEstudio = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Juzgado> JuzgadoMostrar()
        {
            List<C_Juzgado> lista = new List<C_Juzgado>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_juzgado, nombre from juzgado where flag = 1", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Juzgado
                        {
                            CodigoJuzgado = rd.GetInt32(0),
                            NombreJuzgado = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_BienHipotecado> BienHipotecadoMostrar()
        {
            List<C_BienHipotecado> lista = new List<C_BienHipotecado>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
               
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo, nombre from bienHipotecado where flag = 1", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_BienHipotecado
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_FormaMedidaCautelar> FormaMedidaCautelarMostrar()
        {
            List<C_FormaMedidaCautelar> lista = new List<C_FormaMedidaCautelar>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo, nombre from FormaMedidaCautelar where flag = 1", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_FormaMedidaCautelar
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_RangoHipotecado> RangoHipotecadoMostrar()
        {
            List<C_RangoHipotecado> lista = new List<C_RangoHipotecado>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_rango_hipoteca, nombre from rango_hipoteca where flag = 1 order by nombre", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_RangoHipotecado
                        {
                            CodigoRangoHipotecado = rd.GetInt32(0),
                            NombreRangoHipotecado = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_BienEmbargado> BienEmbargadoMostrar()
        {
            List<C_BienEmbargado> lista = new List<C_BienEmbargado>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_bienembargado, nombre from bienembargado where flag = 1", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_BienEmbargado
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        
        public List<C_TipoBien> TipoBienMostrar()
        {
            List<C_TipoBien> lista = new List<C_TipoBien>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo, nombre from tipo_bien where flag = 1 ORDER by nombre;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_TipoBien
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        
        public List<C_Bien> BienMostrar(string expediente)
        {
            List<C_Bien> lista = new List<C_Bien>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_bien,nombre_bien from bien WHERE NUM_EXPEDIENTE = '" + expediente + "' and flag = 1;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Bien
                        {
                            Codigo = rd.GetInt32(0),
                            NombreBien = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista; 
        }    

        public List<C_SeguimientoProceso> SeguimientoProcesoMostrarFechaProcesal(string expediente)
        {
            List<C_SeguimientoProceso> lista = new List<C_SeguimientoProceso>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo, estadoprocesal, fechaestadoprocesal, tareajudicial, fechatareaadministrativa, tareaadministrativa, nombre_ESTADOPROCESAL, etj, eta, convenio, incidencia, detalle_incidencia, detalle_convenio, estadotareajudicial,estadotareaadministrativa from vw_seguimientoproceso WHERE NUM_EXPEDIENTE = '" + expediente + "' order by fechaestadoprocesal desc;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                C_SeguimientoProceso objetoSeguimiento = new C_SeguimientoProceso();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        // FECHA ESTADO PROCESAL - EN STRING
                        if (rd.GetDateTime(2) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSeguimiento.FechaSiguienteString1 = " ";
                        }
                        else if (rd[2] != DBNull.Value)
                        {
                            objetoSeguimiento.FechaSiguienteString1 = "" + rd.GetDateTime(2).ToShortDateString();
                        }
                        else
                        {
                            objetoSeguimiento.FechaSiguienteString1 = " ";
                        }
                        // FECHA EN DATE TIME
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSeguimiento.FechaEstadoProcesal = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSeguimiento.FechaEstadoProcesal = rd.GetDateTime(2);
                        }
                        // FECHA TAREA ADMINISTRATIVA EN DATE TIME
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSeguimiento.FechaTareaAdministrativa = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSeguimiento.FechaTareaAdministrativa = rd.GetDateTime(4);
                        }
                        // FECHA TAREA ADMINISTRATIVA EN STRING
                        if (rd.GetDateTime(4) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSeguimiento.FechaAdministrativaString = " ";
                        }
                        else if (rd[4] != DBNull.Value)
                        {
                            objetoSeguimiento.FechaAdministrativaString = "" + rd.GetDateTime(4).ToShortDateString();
                        }
                        else
                        {
                            objetoSeguimiento.FechaAdministrativaString = " ";
                        }
                        //
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSeguimiento.Convenio = " ";
                        }
                        else
                        {
                            objetoSeguimiento.Convenio = rd.GetString(9);
                        }
                        //
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSeguimiento.Incidencia = " ";
                        }
                        else
                        {
                            objetoSeguimiento.Incidencia = rd.GetString(10);
                        }
                        //
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSeguimiento.DetalleIncidencia = " ";
                        }
                        else
                        {
                            objetoSeguimiento.DetalleIncidencia = rd.GetString(11);
                        }
                        //
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSeguimiento.DetalleConvenio = " ";
                        }
                        else
                        {
                            objetoSeguimiento.DetalleConvenio = rd.GetString(12);
                        }
                        //
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSeguimiento.EstadoTareaJudicial = 1;
                        }
                        else
                        {
                            objetoSeguimiento.EstadoTareaJudicial = rd.GetInt32(13);
                        }
                        //
                        if(rd[14] == DBNull.Value)
                        {
                            objetoSeguimiento.EstadoTareaAdministrativa = 1;
                        }
                        else
                        {
                            objetoSeguimiento.EstadoTareaAdministrativa = rd.GetInt32(14);
                        }
                        //

                        lista.Add(new C_SeguimientoProceso
                        {
                            Codigo = rd.GetInt32(0),
                            EstadoProcesal = rd.GetInt32(1),
                            FechaSiguienteString1 = objetoSeguimiento.FechaSiguienteString1,
                            TareaJudicial = rd.GetString(3),
                            FechaAdministrativaString = objetoSeguimiento.FechaAdministrativaString,
                            TareaAdministrativa = rd.GetString(5),
                            NombreEstadoProcesal = rd.GetString(6),
                            Etj = rd.GetString(7),
                            Eta = rd.GetString(8),
                            FechaEstadoProcesal = objetoSeguimiento.FechaEstadoProcesal,
                            FechaTareaAdministrativa = objetoSeguimiento.FechaTareaAdministrativa,
                            Convenio = objetoSeguimiento.Convenio,
                            Incidencia = objetoSeguimiento.Incidencia,
                            DetalleIncidencia = objetoSeguimiento.DetalleIncidencia ,
                            DetalleConvenio = objetoSeguimiento.DetalleConvenio,
                            EstadoTareaJudicial = objetoSeguimiento.EstadoTareaJudicial,
                            EstadoTareaAdministrativa = objetoSeguimiento.EstadoTareaAdministrativa

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_SeguimientoProceso> SeguimientoProcesoMostrar(string order = " order by fechaestadoprocesal asc;")
        {
            List<C_SeguimientoProceso> lista = new List<C_SeguimientoProceso>();
            C_SeguimientoProceso objetoSeguimientoProceso = new C_SeguimientoProceso();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO_SEGUIMIENTO, ESTADOPROCESAL, FECHAESTADOPROCESAL, TAREAJUDICIAL, FECHATAREAADMINISTRATIVA, TAREAADMINISTRATIVA, NOMBRE_ESTADO_PROCESAL, CUENTA_BT, ETJ,ETA,NOMBRE_RESPONSABLE, OPERACION, NUM_EXPEDIENTE from vw_seguimientoprocesoTodosCreditos " + order, cnn);
                //NpgsqlCommand cmd = new NpgsqlCommand("select codigo, estadoprocesal, fechaestadoprocesal, tareajudicial, fechatareaadministrativa, tareaadministrativa, nombre, cuenta_bt, etj, eta from vw_seguimientoprocesoTodosCreditos  order by fechaestadoprocesal asc", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if(rd[0] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.Codigo = 0;
                        }
                        else
                        {
                            objetoSeguimientoProceso.Codigo = rd.GetInt32(0);
                        }
                        //
                        if(rd[1] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.EstadoProcesal = 0;
                        }
                        else
                        {
                            objetoSeguimientoProceso.EstadoProcesal = rd.GetInt32(1);
                        }
                        //
                        if (rd.GetDateTime(2) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSeguimientoProceso.FechaEstadoProcesal = DateTime.Now;
                            objetoSeguimientoProceso.FechaSiguienteString1 = " ";
                        }
                        else if(rd[2] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.FechaEstadoProcesal = DateTime.Now;
                            objetoSeguimientoProceso.FechaSiguienteString1 = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.FechaEstadoProcesal = rd.GetDateTime(2);
                            objetoSeguimientoProceso.FechaSiguienteString1 = rd.GetDateTime(2).ToShortDateString() + " ";
                        }
                        //
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.TareaJudicial = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.TareaJudicial = rd.GetString(3);
                        }
                        //
                        if (rd.GetDateTime(4) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSeguimientoProceso.FechaAdministrativaString = " ";
                        }
                        else if (rd[4] != DBNull.Value)
                        {
                            objetoSeguimientoProceso.FechaAdministrativaString = "" + rd.GetDateTime(4).ToShortDateString();
                        }
                        else
                        {
                            objetoSeguimientoProceso.FechaAdministrativaString = " ";
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.FechaTareaAdministrativa = DateTime.Now;
                        }
                        else
                        {
                            objetoSeguimientoProceso.FechaTareaAdministrativa = rd.GetDateTime(4);
                        }
                        //
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.TareaAdministrativa = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.TareaAdministrativa = rd.GetString(5);
                        }
                        //
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.NombreEstadoProcesal = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.NombreEstadoProcesal = rd.GetString(6);
                        }
                        //
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.CuentaBT = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.CuentaBT = rd.GetString(7);
                        }
                        //
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.Etj = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.Etj = rd.GetString(8);
                        }
                        //
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.Eta = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.Eta = rd.GetString(9);
                        }
                        //
                        if(rd[10] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.NombreResponsable = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.NombreResponsable = rd.GetString(10);
                        }
                        //

                        lista.Add(new C_SeguimientoProceso
                        {
                            Codigo = objetoSeguimientoProceso.Codigo,
                            EstadoProcesal = objetoSeguimientoProceso.EstadoProcesal,
                            FechaEstadoProcesal = objetoSeguimientoProceso.FechaEstadoProcesal,
                            FechaSiguienteString1 = objetoSeguimientoProceso.FechaSiguienteString1,
                            TareaJudicial = objetoSeguimientoProceso.TareaJudicial,
                            FechaAdministrativaString = objetoSeguimientoProceso.FechaAdministrativaString,
                            TareaAdministrativa = objetoSeguimientoProceso.TareaAdministrativa,
                            NombreEstadoProcesal = objetoSeguimientoProceso.NombreEstadoProcesal,
                            CuentaBT = objetoSeguimientoProceso.CuentaBT,
                            Etj = objetoSeguimientoProceso.Etj,
                            Eta = objetoSeguimientoProceso.Eta,
                            FechaTareaAdministrativa = objetoSeguimientoProceso.FechaTareaAdministrativa,
                            NombreResponsable = objetoSeguimientoProceso.NombreResponsable,
                            Operacion = rd.GetString(11),
                            Num_expediente = rd.GetString(12)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_SeguimientoProceso> SeguimientoProcesoMostrarCBT(string codigo)
        {
            List<C_SeguimientoProceso> lista = new List<C_SeguimientoProceso>();
            C_SeguimientoProceso objetoSeguimientoProceso = new C_SeguimientoProceso();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo, estadoprocesal, fechaestadoprocesal, tareajudicial, fechatareaadministrativa, tareaadministrativa, nombre, cuenta_bt, etj, eta from vw_seguimientoprocesoTodosCreditos where cuenta_bt = '" + codigo + "' and flag = 1 and codigo_tramite = 4 and (estadotareajudicial != 1 or estadotareaadministrativa != 1 ) ", cnn);
                //NpgsqlCommand cmd = new NpgsqlCommand("select codigo, estadoprocesal, fechaestadoprocesal, tareajudicial, fechatareaadministrativa, tareaadministrativa, nombre, cuenta_bt, etj, eta from vw_seguimientoprocesoTodosCreditos  order by fechaestadoprocesal asc", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if(rd[0] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.Codigo = 0;
                        }
                        else
                        {
                            objetoSeguimientoProceso.Codigo = rd.GetInt32(0);
                        }
                        if(rd[1] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.EstadoProcesal = 0;
                        }
                        else
                        {
                            objetoSeguimientoProceso.EstadoProcesal = rd.GetInt32(1);
                        }
                        if (rd.GetDateTime(2) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSeguimientoProceso.FechaEstadoProcesal = DateTime.Now;
                            objetoSeguimientoProceso.FechaSiguienteString1 = " ";
                        }
                        else if(rd[2] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.FechaEstadoProcesal = DateTime.Now;
                            objetoSeguimientoProceso.FechaSiguienteString1 = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.FechaEstadoProcesal = rd.GetDateTime(2);
                            objetoSeguimientoProceso.FechaSiguienteString1 = rd.GetDateTime(2).ToShortDateString() + " ";
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.TareaJudicial = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.TareaJudicial = rd.GetString(3);
                        }
                        //
                        if (rd.GetDateTime(4) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSeguimientoProceso.FechaAdministrativaString = " ";
                        }
                        else if (rd[4] != DBNull.Value)
                        {
                            objetoSeguimientoProceso.FechaAdministrativaString = "" + rd.GetDateTime(4).ToShortDateString();
                        }
                        else
                        {
                            objetoSeguimientoProceso.FechaAdministrativaString = " ";
                        }
                        //
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.FechaTareaAdministrativa = DateTime.Now;
                        }
                        else
                        {
                            objetoSeguimientoProceso.FechaTareaAdministrativa = rd.GetDateTime(4);
                        }
                        //
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.TareaAdministrativa = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.TareaAdministrativa = rd.GetString(5);
                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.NombreEstadoProcesal = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.NombreEstadoProcesal = rd.GetString(6);
                        }
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.CuentaBT = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.CuentaBT = rd.GetString(7);
                        }
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.Etj = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.Etj = rd.GetString(8);
                        }
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.Eta = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.Eta = rd.GetString(9);
                        }
                        lista.Add(new C_SeguimientoProceso
                        {
                            Codigo = objetoSeguimientoProceso.Codigo,
                            EstadoProcesal = objetoSeguimientoProceso.EstadoProcesal,
                            FechaEstadoProcesal = objetoSeguimientoProceso.FechaEstadoProcesal,
                            FechaSiguienteString1 = objetoSeguimientoProceso.FechaSiguienteString1,
                            TareaJudicial = objetoSeguimientoProceso.TareaJudicial,
                            FechaAdministrativaString = objetoSeguimientoProceso.FechaAdministrativaString,
                            TareaAdministrativa = objetoSeguimientoProceso.TareaAdministrativa,
                            NombreEstadoProcesal = objetoSeguimientoProceso.NombreEstadoProcesal,
                            CuentaBT = objetoSeguimientoProceso.CuentaBT,
                            Etj = objetoSeguimientoProceso.Etj,
                            Eta = objetoSeguimientoProceso.Eta,
                            FechaTareaAdministrativa = objetoSeguimientoProceso.FechaTareaAdministrativa
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_SeguimientoProceso> SeguimientoProcesoInicioDNI(int codigo)
        {
            List<C_SeguimientoProceso> lista = new List<C_SeguimientoProceso>();
            C_SeguimientoProceso objetoSeguimientoProceso = new C_SeguimientoProceso();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO_SEGUIMIENTO, ESTADOPROCESAL, FECHAESTADOPROCESAL, TAREAJUDICIAL, FECHATAREAADMINISTRATIVA, TAREAADMINISTRATIVA, NOMBRE_ESTADO_PROCESAL, CUENTA_BT, ETJ,ETA,NOMBRE_RESPONSABLE, OPERACION, NUM_EXPEDIENTE from vw_seguimientoprocesoTodosCreditos where dni_trabajador = " + codigo +" and flag = 1 and codigo_tramite = 4 and (estadotareajudicial != 1 or estadotareaadministrativa != 1 ) order by  fechaestadoprocesal asc", cnn);
                //NpgsqlCommand cmd = new NpgsqlCommand("select codigo, estadoprocesal, fechaestadoprocesal, tareajudicial, fechatareaadministrativa, tareaadministrativa, nombre, cuenta_bt, etj, eta from vw_seguimientoprocesoTodosCreditos  order by fechaestadoprocesal asc", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.Codigo = 0;
                        }
                        else
                        {
                            objetoSeguimientoProceso.Codigo = rd.GetInt32(0);
                        }
                        //
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.EstadoProcesal = 0;
                        }
                        else
                        {
                            objetoSeguimientoProceso.EstadoProcesal = rd.GetInt32(1);
                        }
                        //
                        if (rd.GetDateTime(2) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSeguimientoProceso.FechaEstadoProcesal = DateTime.Now;
                            objetoSeguimientoProceso.FechaSiguienteString1 = " ";
                        }
                        else if (rd[2] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.FechaEstadoProcesal = DateTime.Now;
                            objetoSeguimientoProceso.FechaSiguienteString1 = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.FechaEstadoProcesal = rd.GetDateTime(2);
                            objetoSeguimientoProceso.FechaSiguienteString1 = rd.GetDateTime(2).ToShortDateString() + " ";
                        }
                        //
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.TareaJudicial = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.TareaJudicial = rd.GetString(3);
                        }
                        //
                        if (rd.GetDateTime(4) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSeguimientoProceso.FechaAdministrativaString = " ";
                        }
                        else if (rd[4] != DBNull.Value)
                        {
                            objetoSeguimientoProceso.FechaAdministrativaString = "" + rd.GetDateTime(4).ToShortDateString();
                        }
                        else
                        {
                            objetoSeguimientoProceso.FechaAdministrativaString = " ";
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.FechaTareaAdministrativa = DateTime.Now;
                        }
                        else
                        {
                            objetoSeguimientoProceso.FechaTareaAdministrativa = rd.GetDateTime(4);
                        }
                        //
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.TareaAdministrativa = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.TareaAdministrativa = rd.GetString(5);
                        }
                        //
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.NombreEstadoProcesal = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.NombreEstadoProcesal = rd.GetString(6);
                        }
                        //
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.CuentaBT = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.CuentaBT = rd.GetString(7);
                        }
                        //
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.Etj = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.Etj = rd.GetString(8);
                        }
                        //
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.Eta = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.Eta = rd.GetString(9);
                        }
                        //
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.NombreResponsable = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.NombreResponsable = rd.GetString(10);
                        }
                        //

                        lista.Add(new C_SeguimientoProceso
                        {
                            Codigo = objetoSeguimientoProceso.Codigo,
                            EstadoProcesal = objetoSeguimientoProceso.EstadoProcesal,
                            FechaEstadoProcesal = objetoSeguimientoProceso.FechaEstadoProcesal,
                            FechaSiguienteString1 = objetoSeguimientoProceso.FechaSiguienteString1,
                            TareaJudicial = objetoSeguimientoProceso.TareaJudicial,
                            FechaAdministrativaString = objetoSeguimientoProceso.FechaAdministrativaString,
                            TareaAdministrativa = objetoSeguimientoProceso.TareaAdministrativa,
                            NombreEstadoProcesal = objetoSeguimientoProceso.NombreEstadoProcesal,
                            CuentaBT = objetoSeguimientoProceso.CuentaBT,
                            Etj = objetoSeguimientoProceso.Etj,
                            Eta = objetoSeguimientoProceso.Eta,
                            FechaTareaAdministrativa = objetoSeguimientoProceso.FechaTareaAdministrativa,
                            NombreResponsable = objetoSeguimientoProceso.NombreResponsable,
                            Operacion = rd.GetString(11),
                            Num_expediente = rd.GetString(12)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }

        public List<C_SeguimientoProceso> SeguimientoProcesoInicioDNIDesc(int codigo)
        {
            List<C_SeguimientoProceso> lista = new List<C_SeguimientoProceso>();
            C_SeguimientoProceso objetoSeguimientoProceso = new C_SeguimientoProceso();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO_SEGUIMIENTO, ESTADOPROCESAL, FECHAESTADOPROCESAL, TAREAJUDICIAL, FECHATAREAADMINISTRATIVA, TAREAADMINISTRATIVA, NOMBRE_ESTADO_PROCESAL, CUENTA_BT, ETJ,ETA,NOMBRE_RESPONSABLE, OPERACION, NUM_EXPEDIENTE from vw_seguimientoprocesoTodosCreditos where dni_trabajador = " + codigo + " and flag = 1 and codigo_tramite = 4 and (estadotareajudicial != 1 or estadotareaadministrativa != 1 ) order by  FECHATAREAADMINISTRATIVA desc", cnn);
                //NpgsqlCommand cmd = new NpgsqlCommand("select codigo, estadoprocesal, fechaestadoprocesal, tareajudicial, fechatareaadministrativa, tareaadministrativa, nombre, cuenta_bt, etj, eta from vw_seguimientoprocesoTodosCreditos  order by fechaestadoprocesal asc", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.Codigo = 0;
                        }
                        else
                        {
                            objetoSeguimientoProceso.Codigo = rd.GetInt32(0);
                        }
                        //
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.EstadoProcesal = 0;
                        }
                        else
                        {
                            objetoSeguimientoProceso.EstadoProcesal = rd.GetInt32(1);
                        }
                        //
                        if (rd.GetDateTime(2) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSeguimientoProceso.FechaEstadoProcesal = DateTime.Now;
                            objetoSeguimientoProceso.FechaSiguienteString1 = " ";
                        }
                        else if (rd[2] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.FechaEstadoProcesal = DateTime.Now;
                            objetoSeguimientoProceso.FechaSiguienteString1 = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.FechaEstadoProcesal = rd.GetDateTime(2);
                            objetoSeguimientoProceso.FechaSiguienteString1 = rd.GetDateTime(2).ToShortDateString() + " ";
                        }
                        //
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.TareaJudicial = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.TareaJudicial = rd.GetString(3);
                        }
                        //
                        if (rd.GetDateTime(4) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSeguimientoProceso.FechaAdministrativaString = " ";
                        }
                        else if (rd[4] != DBNull.Value)
                        {
                            objetoSeguimientoProceso.FechaAdministrativaString = "" + rd.GetDateTime(4).ToShortDateString();
                        }
                        else
                        {
                            objetoSeguimientoProceso.FechaAdministrativaString = " ";
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.FechaTareaAdministrativa = DateTime.Now;
                        }
                        else
                        {
                            objetoSeguimientoProceso.FechaTareaAdministrativa = rd.GetDateTime(4);
                        }
                        //
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.TareaAdministrativa = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.TareaAdministrativa = rd.GetString(5);
                        }
                        //
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.NombreEstadoProcesal = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.NombreEstadoProcesal = rd.GetString(6);
                        }
                        //
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.CuentaBT = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.CuentaBT = rd.GetString(7);
                        }
                        //
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.Etj = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.Etj = rd.GetString(8);
                        }
                        //
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.Eta = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.Eta = rd.GetString(9);
                        }
                        //
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.NombreResponsable = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.NombreResponsable = rd.GetString(10);
                        }
                        //

                        lista.Add(new C_SeguimientoProceso
                        {
                            Codigo = objetoSeguimientoProceso.Codigo,
                            EstadoProcesal = objetoSeguimientoProceso.EstadoProcesal,
                            FechaEstadoProcesal = objetoSeguimientoProceso.FechaEstadoProcesal,
                            FechaSiguienteString1 = objetoSeguimientoProceso.FechaSiguienteString1,
                            TareaJudicial = objetoSeguimientoProceso.TareaJudicial,
                            FechaAdministrativaString = objetoSeguimientoProceso.FechaAdministrativaString,
                            TareaAdministrativa = objetoSeguimientoProceso.TareaAdministrativa,
                            NombreEstadoProcesal = objetoSeguimientoProceso.NombreEstadoProcesal,
                            CuentaBT = objetoSeguimientoProceso.CuentaBT,
                            Etj = objetoSeguimientoProceso.Etj,
                            Eta = objetoSeguimientoProceso.Eta,
                            FechaTareaAdministrativa = objetoSeguimientoProceso.FechaTareaAdministrativa,
                            NombreResponsable = objetoSeguimientoProceso.NombreResponsable,
                            Operacion = rd.GetString(11),
                            Num_expediente = rd.GetString(12)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }

        public List<C_SeguimientoProceso> SeguimientoProcesoMostrarTareasCumplidas()
        {
            List<C_SeguimientoProceso> lista = new List<C_SeguimientoProceso>();
            C_SeguimientoProceso objetoSeguimientoProceso = new C_SeguimientoProceso();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select distinct on (cuenta_bt) cuenta_bt ,codigo, estadoprocesal, fechaestadoprocesal, tareajudicial, fechatareaadministrativa, tareaadministrativa, nombre,  etj, eta from vw_seguimientoprocesotodoscreditos where flag = 1 and  codigo_tramite = 4 and eta = 'Si' and etj = 'Si'; ", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.Codigo = 0;
                        }
                        else
                        {
                            objetoSeguimientoProceso.Codigo = rd.GetInt32(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.EstadoProcesal = 0;
                        }
                        else
                        {
                            objetoSeguimientoProceso.EstadoProcesal = rd.GetInt32(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.FechaEstadoProcesal = DateTime.Now;
                        }
                        else
                        {
                            objetoSeguimientoProceso.FechaEstadoProcesal = rd.GetDateTime(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.TareaJudicial = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.TareaJudicial = rd.GetString(4);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.FechaTareaAdministrativa = DateTime.Now;
                        }
                        else
                        {
                            objetoSeguimientoProceso.FechaTareaAdministrativa = rd.GetDateTime(5);
                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.TareaAdministrativa = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.TareaAdministrativa = rd.GetString(6);
                        }
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.NombreEstadoProcesal = " ";
                        }
                        else
                        {
                            objetoSeguimientoProceso.NombreEstadoProcesal = rd.GetString(7);
                        }
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.CuentaBT = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.CuentaBT = rd.GetString(0);
                        }
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.Etj = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.Etj = rd.GetString(8);
                        }
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSeguimientoProceso.Eta = "";
                        }
                        else
                        {
                            objetoSeguimientoProceso.Eta = rd.GetString(9);
                        }
                        lista.Add(new C_SeguimientoProceso
                        {
                            Codigo = objetoSeguimientoProceso.Codigo,
                            EstadoProcesal = objetoSeguimientoProceso.EstadoProcesal,
                            FechaEstadoProcesal = objetoSeguimientoProceso.FechaEstadoProcesal,
                            TareaJudicial = objetoSeguimientoProceso.TareaJudicial,
                            FechaTareaAdministrativa = objetoSeguimientoProceso.FechaTareaAdministrativa,
                            TareaAdministrativa = objetoSeguimientoProceso.TareaAdministrativa,
                            NombreEstadoProcesal = objetoSeguimientoProceso.NombreEstadoProcesal,
                            CuentaBT = objetoSeguimientoProceso.CuentaBT,
                            Etj = objetoSeguimientoProceso.Etj,
                            Eta = objetoSeguimientoProceso.Eta
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_TipoProceso> TipoProcesoMostrar() {

            List<C_TipoProceso> lista = new List<C_TipoProceso>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_proceso, nombre_proceso from tipo_proceso where flag = 1 ORDER BY NOMBRE_PROCESO", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_TipoProceso
                        {
                            CodigoProceso = rd.GetInt32(0),
                            NombreProceso = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        
        }

        public List<C_EstadoProcesal> EstadoProcesalMostarComoMicro(string num_expediente) 
        {
            List<C_EstadoProcesal> lista = new List<C_EstadoProcesal>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO_MICROETAPA, NOMBRE FROM VW_CODIGOMICROETAPA WHERE NUM_EXPEDIENTE = '"+ num_expediente +"'", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_EstadoProcesal
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_EstadoProcesal> EstadoProcesalMostrar()
        {
            List<C_EstadoProcesal> lista = new List<C_EstadoProcesal>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo, nombre from Estado_Procesal where flag = 1 ORDER BY CODIGO", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_EstadoProcesal
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Macro> MacroEtapaMostrar() {


            List<C_Macro> lista = new List<C_Macro>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo, nombre from MacroEtapa where flag = 1", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Macro
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Macro> MacroEtapaMostrarTipoProceso(int codigoProceso)
        {
            List<C_Macro> lista = new List<C_Macro>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT M.codigo, M.nombre FROM tipo_proceso_macroetapa TPM INNER JOIN macroetapa M ON M.codigo = TPM.codigo WHERE TPM.codigo_proceso = " + codigoProceso + " AND M.flag = 1 AND TPM.flag = 1;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Macro
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Micro> MicroEtapaMostrar() {
            List<C_Micro> lista = new List<C_Micro>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_microetapa, nombre from MicroEtapa where flag = 1", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Micro
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }

        // ANTES DE ACTUALIZAR 
        public List<C_TipoSolucion> TipoSolucionMostrar()
        {
            List<C_TipoSolucion> lista = new List<C_TipoSolucion>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_tipo_solucion, nombre from tipo_solucion where flag = 1", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_TipoSolucion
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_Detalle_MC_Hipoteca> DetalleMedidaCautelarHipoteca(string codigo)
        {
            List<C_Detalle_MC_Hipoteca> lista = new List<C_Detalle_MC_Hipoteca>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select monto_devolucion, motivo_devolucion, descripcion_inmueble from cancelacion_pagos where cuenta_bt =" + "'"+ codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Detalle_MC_Hipoteca
                        {
                            MontoDevolucion = rd.GetString(0),
                            MotivoDevolucion = rd.GetString(1),
                            Descripcion = rd.GetString(2)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;

        }
        public List<C_Credito> ClienteMostrarCredito(string codigo)
        {
            List<C_Credito> lista = new List<C_Credito>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, NOMBRE_COMPLETO, DOI_CLIENTE FROM VW_DOIBUSCAR WHERE DOI_CLIENTE = '" + codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Credito
                        {                         
                            CuentaBT = rd.GetString(0),
                            NombreCompleto = rd.GetString(1),
                            DoiCliente = rd.GetString(2)
                            
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Persona> PersonaMostrar()
        {
            List<C_Persona> lista = new List<C_Persona>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select doi_cliente , nombre_completo from persona where flag = 1 ;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Persona
                        {
                            Doi_cliente = rd.GetString(0),
                            NombreCompleto = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }


    
        public List<C_Persona> PersonaMostrarCreditoNombre(string codigo)
        {
            List<C_Persona> lista = new List<C_Persona>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_Persona objetoPersona = new C_Persona();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, NOMBRE_COMPLETO, DOI_CLIENTE FROM PERSONA WHERE DOI_CLIENTE = '" + codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                            objetoPersona.Cuenta_bt = " ";
                        else
                        {
                            objetoPersona.Cuenta_bt = rd.GetString(0);
                        }
                        lista.Add(new C_Persona
                        {
                            Cuenta_bt = objetoPersona.Cuenta_bt,
                            NombreCompleto = rd.GetString(1),
                            Doi_cliente = rd.GetString(2)

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Persona> PersonaMostrarTitular(string nombre)
        {
            List<C_Persona> lista = new List<C_Persona>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_Persona objetoPersona = new C_Persona();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, NOMBRE_COMPLETO, DOI_CLIENTE FROM VW_BUSCARTITULAR WHERE NOMBRE_COMPLETO = '"+ nombre+"' AND FLAG = 1;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                            objetoPersona.Cuenta_bt = " ";
                        lista.Add(new C_Persona
                        {
                            Cuenta_bt = objetoPersona.Cuenta_bt,
                            NombreCompleto = rd.GetString(1),
                            Doi_cliente = rd.GetString(2)

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_GestionLlamadas> GestionLlamadaMostrar( string expediente, string operacion)
        {
            List<C_GestionLlamadas> lista = new List<C_GestionLlamadas>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_GestionLlamadas objetoGestionLlamadas = new C_GestionLlamadas();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT TELEFONO_CONTACTO, CONTACTO_CLIENTE, CONTACTO_PARIENTE, NOMBRE_PARIENTE, TELEFONO_NO_CORRESPONDE, FECHA_VISITA_ESTUDIO, FECHA_PAGO, MONTO_PAGO, DUENO_BIEN, NIEGA_PAGO, HORA_LLAMADA, DETALLE_RESULTADO, NUM_GESTION, TIPO_SOLUCION, CODIGO_GESTION, DNI_TRABAJADOR, REPORTE, NOMBRE_PERSONA, FECHA_GESTION FROM VW_GESTIONLLAMADADGV WHERE NUM_EXPEDIENTE = '" + expediente +"' AND OPERACION = '"+operacion +"' AND flag = 1 order by fecha_gestion DESC;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //
                        if (rd[0] == DBNull.Value)
                            objetoGestionLlamadas.TelefonoContacto = " ";
                        else
                            objetoGestionLlamadas.TelefonoContacto = rd.GetString(0);
                        //
                        if (rd[1] == DBNull.Value)
                            objetoGestionLlamadas.ContactoCliente = " ";
                        else
                            objetoGestionLlamadas.ContactoCliente = rd.GetString(1);
                        //
                        if (rd[2] == DBNull.Value)
                            objetoGestionLlamadas.ContactoPariente = " ";
                        else
                            objetoGestionLlamadas.ContactoPariente = rd.GetString(2);
                        //
                        if (rd[3] == DBNull.Value)
                            objetoGestionLlamadas.NombrePariente = " ";
                        else
                            objetoGestionLlamadas.NombrePariente = rd.GetString(3);
                        //
                        if (rd[4] == DBNull.Value)
                            objetoGestionLlamadas.TelefonoNoCorresponde = " ";
                        else
                            objetoGestionLlamadas.TelefonoNoCorresponde = rd.GetString(4);
                        //
                        if (rd.GetDateTime(5) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionLlamadas.FechaVisitaEstudioString = " ";
                        }
                        else if (rd[5] != DBNull.Value)
                        {
                            objetoGestionLlamadas.FechaVisitaEstudioString = "" + rd.GetDateTime(5).ToShortDateString();
                        }
                        else 
                        {
                            objetoGestionLlamadas.FechaVisitaEstudioString = " ";
                        }
                        //
                        if (rd.GetDateTime(6) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionLlamadas.FechaPagoString = " ";
                        }
                        else if (rd[6] != DBNull.Value)
                        {
                            objetoGestionLlamadas.FechaPagoString = "" + rd.GetDateTime(6).ToShortDateString() ;
                        }
                        else
                        {
                            objetoGestionLlamadas.FechaPagoString = " ";
                        }
                        //
                        if (rd[7] == DBNull.Value)
                            objetoGestionLlamadas.MontoPago = " ";
                        else
                            objetoGestionLlamadas.MontoPago = rd.GetString(7);
                        //
                        if (rd[8] == DBNull.Value)
                            objetoGestionLlamadas.DuenoBien = " ";
                        else
                            objetoGestionLlamadas.DuenoBien = rd.GetString(8);
                        //
                        if (rd[9] == DBNull.Value)
                            objetoGestionLlamadas.NiegaPago = " ";
                        else
                            objetoGestionLlamadas.NiegaPago = rd.GetString(9);
                        //
                        if (rd[10] == DBNull.Value)
                            objetoGestionLlamadas.HoraLlamada = " ";
                        else
                            objetoGestionLlamadas.HoraLlamada = rd.GetString(10);
                        //
                        if (rd[11] == DBNull.Value)
                            objetoGestionLlamadas.DetalleResultado = " ";
                        else
                            objetoGestionLlamadas.DetalleResultado = rd.GetString(11);
                        //
                        if (rd[12] == DBNull.Value)
                            objetoGestionLlamadas.NumGestion = " ";
                        else
                            objetoGestionLlamadas.NumGestion = rd.GetString(12);
                        //
                        if (rd[13] == DBNull.Value)
                            objetoGestionLlamadas.TipoSolucion = " ";
                        else
                            objetoGestionLlamadas.TipoSolucion = rd.GetString(13);
                        //
                        if (rd[5] == DBNull.Value)
                        {
                            objetoGestionLlamadas.FechaVisitaEstudio = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoGestionLlamadas.FechaVisitaEstudio = rd.GetDateTime(5);
                        }
                        //
                        if (rd[6] == DBNull.Value)
                        {
                            objetoGestionLlamadas.FechaPago = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoGestionLlamadas.FechaPago = rd.GetDateTime(6);
                        }
                        //
                        if (rd[16] == DBNull.Value)
                            objetoGestionLlamadas.Reporte = " ";
                        else
                            objetoGestionLlamadas.Reporte = rd.GetString(16);
                        //
                        if (rd[17] == DBNull.Value)
                            objetoGestionLlamadas.NombreTrabajador = " ";
                        else
                            objetoGestionLlamadas.NombreTrabajador = rd.GetString(17);
                        //
                        lista.Add(new C_GestionLlamadas
                        {
                            TelefonoContacto = objetoGestionLlamadas.TelefonoContacto,
                            ContactoCliente = objetoGestionLlamadas.ContactoCliente,
                            ContactoPariente = objetoGestionLlamadas.ContactoPariente,
                            NombrePariente = objetoGestionLlamadas.NombrePariente,
                            TelefonoNoCorresponde = objetoGestionLlamadas.TelefonoNoCorresponde,
                            FechaVisitaEstudioString = objetoGestionLlamadas.FechaVisitaEstudioString,
                            FechaPagoString = objetoGestionLlamadas.FechaPagoString,
                            MontoPago = objetoGestionLlamadas.MontoPago,
                            DuenoBien = objetoGestionLlamadas.DuenoBien,
                            NiegaPago = objetoGestionLlamadas.NiegaPago,
                            NombreTrabajador = objetoGestionLlamadas.NombreTrabajador,
                            HoraLlamada = objetoGestionLlamadas.HoraLlamada,
                            DetalleResultado = objetoGestionLlamadas.DetalleResultado,
                            NumGestion = objetoGestionLlamadas.NumGestion,
                            TipoSolucion = objetoGestionLlamadas.TipoSolucion,
                            CodigoGestionLlamada = rd.GetInt32(14),
                            DniTrabajador = rd.GetInt32(15),
                            FechaVisitaEstudio = objetoGestionLlamadas.FechaVisitaEstudio,
                            FechaPago = objetoGestionLlamadas.FechaPago,
                            Reporte = objetoGestionLlamadas.Reporte,
                            FechaGestionCall = rd.GetDateTime(18)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_GestionCampo> GestionCampoMostrar(string expediente, string Operacion)
        {
            List<C_GestionCampo> lista = new List<C_GestionCampo>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_GestionCampo objetoGestionCampo = new C_GestionCampo();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT GESTION_CAMPO,CONTACTO_PARIENTE,NOMBRE_PARIENTE,NUEVO_DOM_TELE,DETALLE,FECHA_PAGO,MONTO_PAGO,FECHA_GESTION,DNI_TRABAJADOR,NOMBRE,DETALLE_RESULTADO,INUBICABLE,NUM_GESTION,DESCRIPCION_INMUEBLE,DUENO_BIEN,NIEGA_PAGO,HORA_LLAMADA,TIPO_SOLUCION,CODIGO_GESTION,REPORTE FROM VW_GESTIONCAMPODGV WHERE NUM_EXPEDIENTE = '" + expediente +"'and  OPERACION = '"+ Operacion+"' AND flag = 2 ORDER BY fecha_Gestion DESC;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //
                        if (rd[0] == DBNull.Value)
                            objetoGestionCampo.GestionCampo = " ";
                        else
                            objetoGestionCampo.GestionCampo = rd.GetString(0);
                        //
                        if (rd[1] == DBNull.Value)
                            objetoGestionCampo.ContactoPariente = " ";
                        else
                            objetoGestionCampo.ContactoPariente = rd.GetString(1);
                        //
                        if (rd[2] == DBNull.Value)
                            objetoGestionCampo.NombrePariente = " ";
                        else
                            objetoGestionCampo.NombrePariente = rd.GetString(2);
                        //
                        if (rd[3] == DBNull.Value)
                            objetoGestionCampo.NuevoDomTele = " ";
                        else
                            objetoGestionCampo.NuevoDomTele = rd.GetString(3);
                        //
                        if (rd[4] == DBNull.Value)
                            objetoGestionCampo.Detalle = " ";
                        else
                            objetoGestionCampo.Detalle = rd.GetString(4);
                        //
                        if (rd.GetDateTime(5) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionCampo.FechaPagoString = " ";
                        }
                        else if (rd[5] != DBNull.Value)
                        {
                            objetoGestionCampo.FechaPagoString = "" + rd.GetDateTime(5).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionCampo.FechaPagoString = " ";
                        }
                        //
                        if (rd[6] == DBNull.Value)
                            objetoGestionCampo.MontoPago = " ";
                        else
                            objetoGestionCampo.MontoPago = rd.GetString(6);
                        //
                        if (rd.GetDateTime(7) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionCampo.FechaGestionString = " ";
                        }
                        else if (rd[7] != DBNull.Value)
                        {
                            objetoGestionCampo.FechaGestionString = "" + rd.GetDateTime(7).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionCampo.FechaGestionString = " ";
                        }
                        //
                        if(rd[9] == DBNull.Value)
                            objetoGestionCampo.NombreTrabajador = " ";
                        else
                            objetoGestionCampo.NombreTrabajador = rd.GetString(9);
                        //
                        if (rd[10] == DBNull.Value)
                            objetoGestionCampo.DetalleResultado = " ";
                        else
                            objetoGestionCampo.DetalleResultado = rd.GetString(10);
                        //
                        if (rd[11] == DBNull.Value)
                            objetoGestionCampo.Inubicable = " ";
                        else
                            objetoGestionCampo.Inubicable = rd.GetString(11);
                        //
                        if (rd[12] == DBNull.Value)
                            objetoGestionCampo.NumGestion = " ";
                        else
                            objetoGestionCampo.NumGestion = rd.GetString(12);
                        //
                        if(rd[13] == DBNull.Value)
                            objetoGestionCampo.DescripcionInmueble = " ";
                        else
                            objetoGestionCampo.DescripcionInmueble = rd.GetString(13);
                        //
                        if (rd[14] == DBNull.Value)
                            objetoGestionCampo.DuenoBien = " ";
                        else
                            objetoGestionCampo.DuenoBien = rd.GetString(14);
                        //
                        if (rd[15] == DBNull.Value)
                            objetoGestionCampo.NiegaPago = " ";
                        else
                            objetoGestionCampo.NiegaPago = rd.GetString(15);
                        //
                        if(rd[16] == DBNull.Value)
                            objetoGestionCampo.HoraGestion = " ";
                        else
                            objetoGestionCampo.HoraGestion = rd.GetString(16);
                        //
                        if(rd[17] == DBNull.Value)
                            objetoGestionCampo.TipoSolucion = " ";
                        else
                            objetoGestionCampo.TipoSolucion = rd.GetString(17);
                        //
                        if (rd[5] == DBNull.Value)
                        {
                            objetoGestionCampo.FechaPago = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoGestionCampo.FechaPago = rd.GetDateTime(5);
                        }
                        //
                        if (rd[7] == DBNull.Value)
                        {
                            objetoGestionCampo.FechaGestion = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoGestionCampo.FechaGestion = rd.GetDateTime(7);
                        }
                        //
                        if (rd[19] == DBNull.Value)
                            objetoGestionCampo.Reporte = " ";
                        else
                            objetoGestionCampo.Reporte = rd.GetString(19);
                        //
                        lista.Add(new C_GestionCampo
                        {
                            GestionCampo = objetoGestionCampo.GestionCampo,
                            ContactoPariente = objetoGestionCampo.ContactoPariente,
                            NombrePariente = objetoGestionCampo.NombrePariente,
                            NuevoDomTele = objetoGestionCampo.NuevoDomTele,
                            Detalle = objetoGestionCampo.Detalle,
                            FechaPagoString = objetoGestionCampo.FechaPagoString,
                            MontoPago = objetoGestionCampo.MontoPago,
                            FechaGestionString = objetoGestionCampo.FechaGestionString,
                            DniTrabajador = rd.GetInt32(8),
                            NombreTrabajador = objetoGestionCampo.NombreTrabajador,
                            DetalleResultado = objetoGestionCampo.DetalleResultado,
                            Inubicable = objetoGestionCampo.Inubicable,
                            NumGestion = objetoGestionCampo.NumGestion,
                            DescripcionInmueble = objetoGestionCampo.DescripcionInmueble,
                            DuenoBien = objetoGestionCampo.DuenoBien,
                            NiegaPago = objetoGestionCampo.NiegaPago,
                            HoraGestion = objetoGestionCampo.HoraGestion ,
                            TipoSolucion = objetoGestionCampo.NiegaPago,
                            Codigo = rd.GetInt32(18),
                            FechaPago = objetoGestionCampo.FechaPago,
                            FechaGestion = objetoGestionCampo.FechaGestion,
                            Reporte = objetoGestionCampo.Reporte
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_AuditoriaCeriv> AuditoriaMostrar()
        {
            List<C_AuditoriaCeriv> lista = new List<C_AuditoriaCeriv>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, DNI_TRABAJADOR, OBSERVACION,FECHA_MODIFICACION , CAMPO FROM AUDITORIA_CERIV ORDER BY FECHA_MODIFICACION DESC;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_AuditoriaCeriv
                        {
                           CuentaBT = rd.GetString(0),
                           DniTrabajador = rd.GetInt32(1),
                           Observacion = rd.GetString(2),
                           FechaModificacion = rd.GetTimeStamp(3),
                           Campo = rd.GetString(4)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
            
        }
        public List<C_AuditoriaCeriv> AuditoriaMostrarExpediente(string codigo)
        {
            List<C_AuditoriaCeriv> lista = new List<C_AuditoriaCeriv>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, DNI_TRABAJADOR, OBSERVACION,FECHA_MODIFICACION , CAMPO FROM AUDITORIA_CERIV WHERE CUENTA_BT = '" + codigo +"' " + " ORDER BY FECHA_MODIFICACION;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_AuditoriaCeriv
                        {
                            CuentaBT = rd.GetString(0),
                            DniTrabajador = rd.GetInt32(1),
                            Observacion = rd.GetString(2),
                            FechaModificacion = rd.GetTimeStamp(3),
                            Campo = rd.GetString(4)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_AuditoriaCeriv> AuditoriaMostrarTrabajador(int codigo)
        {
            List<C_AuditoriaCeriv> lista = new List<C_AuditoriaCeriv>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, DNI_TRABAJADOR, OBSERVACION,FECHA_MODIFICACION , CAMPO FROM AUDITORIA_CERIV WHERE DNI_TRABAJADOR =" + codigo +  " ORDER BY FECHA_MODIFICACION;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_AuditoriaCeriv
                        {
                            CuentaBT = rd.GetString(0),
                            DniTrabajador = rd.GetInt32(1),
                            Observacion = rd.GetString(2),
                            FechaModificacion = rd.GetTimeStamp(3),
                            Campo = rd.GetString(4)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_GestionCampo> GestionCampoMostrarTodo()
        {
            List<C_GestionCampo> lista = new List<C_GestionCampo>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_GestionCampo objetoGestionCampo = new C_GestionCampo();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select gestion_campo, contacto_pariente, nombre_pariente, nuevo_dom_tele, fecha_pago, monto_pago, niega_pago, fecha_gestion, detalle_resultado, descripcion_inmueble, num_gestion from gestion where gestion_campo != '' ;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoGestionCampo.GestionCampo = " ";
                        }
                        else
                        {
                            objetoGestionCampo.GestionCampo = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoGestionCampo.ContactoPariente = " ";
                        }
                        else
                        {
                            objetoGestionCampo.ContactoPariente = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoGestionCampo.NombrePariente = " ";
                        }
                        else
                        {
                            objetoGestionCampo.NombrePariente = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoGestionCampo.NuevoDomTele = " ";
                        }
                        else
                        {
                            objetoGestionCampo.NuevoDomTele = rd.GetString(3);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoGestionCampo.MontoPago = " ";
                        }
                        else
                        {
                            objetoGestionCampo.MontoPago = rd.GetString(5);
                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoGestionCampo.NiegaPago = " ";
                        }
                        else
                        {
                            objetoGestionCampo.NiegaPago = rd.GetString(6);
                        }
                        if (rd[8] == DBNull.Value)
                        {
                            objetoGestionCampo.DetalleResultado = " ";
                        }
                        else
                        {
                            objetoGestionCampo.DetalleResultado = rd.GetString(8);
                        }
                        if(rd[9] == DBNull.Value)
                        {
                            objetoGestionCampo.DescripcionInmueble = " ";
                        }
                        else
                        {
                            objetoGestionCampo.DescripcionInmueble = rd.GetString(9);
                        }
                        if(rd[10] == DBNull.Value)
                        {
                            objetoGestionCampo.NumGestion = " ";
                        }
                        else
                        {
                            objetoGestionCampo.NumGestion = rd.GetString(10);
                        }

                       
                        lista.Add(new C_GestionCampo
                        {
                            GestionCampo = objetoGestionCampo.GestionCampo,
                            ContactoPariente = objetoGestionCampo.ContactoPariente,
                            NombrePariente = objetoGestionCampo.NombrePariente,
                            NuevoDomTele = objetoGestionCampo.NuevoDomTele,
                            FechaPago = rd.GetDateTime(4),
                            MontoPago = rd.GetString(5),
                            NiegaPago = rd.GetString(6),
                            FechaGestion = rd.GetDateTime(7),
                            DetalleResultado = rd.GetString(8),
                            DescripcionInmueble = rd.GetString(9),
                            NumGestion = rd.GetString(10)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
            
        }
        public List<C_GestionLlamadas> GestionLlamadaMostrarTodo()
        {
            List<C_GestionLlamadas> lista = new List<C_GestionLlamadas>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select telefono_contacto, contacto_cliente, contacto_pariente, nombre_pariente, telefono_no_corresponde, fecha_visita_estudio, fecha_pago, monto_pago, niega_pago, detalle_resultado, num_gestion from gestion where contacto_cliente != '';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_GestionLlamadas
                        {
                            TelefonoContacto = rd.GetString(0),
                            ContactoCliente = rd.GetString(1),
                            ContactoPariente = rd.GetString(2),
                            NombrePariente = rd.GetString(3),
                            TelefonoNoCorresponde = rd.GetString(4),
                            FechaVisitaEstudio = rd.GetDateTime(5),
                            FechaPago = rd.GetDateTime(6),
                            MontoPago = rd.GetString(7),
                            NiegaPago = rd.GetString(8),
                            DetalleResultado = rd.GetString(9),
                            NumGestion = rd.GetString(10)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        //
        public List<C_Macro> MacroEjecucionGarantia()
        {
            List<C_Macro> lista = new List<C_Macro>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO, NOMBRE FROM MACROETAPA WHERE CODIGO = 1 or CODIGO = 2 or CODIGO = 3 or CODIGO = 4 or CODIGO = 5 or CODIGO = 6 and flag = 1 order by nombre;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Macro
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Macro> MacroIncautacion()
        {
            List<C_Macro> lista = new List<C_Macro>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO, NOMBRE FROM MACROETAPA WHERE CODIGO = 1 or CODIGO = 2 or CODIGO = 7 and flag = 1 order by nombre;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Macro
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Macro> MacroODSDMasivo()
        {
            List<C_Macro> lista = new List<C_Macro>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO, NOMBRE FROM MACROETAPA WHERE CODIGO = 1 or CODIGO = 8 or CODIGO = 9 or CODIGO = 3 or CODIGO = 4 and flag = 1 order by nombre;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Macro
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Micro> MicroEjecucionGarantia()
        {
            List<C_Micro> lista = new List<C_Micro>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO_MICROETAPA, NOMBRE FROM MICROETAPA WHERE CODIGO_MICROETAPA = 1 OR CODIGO_MICROETAPA = 2 OR CODIGO_MICROETAPA = 3 OR CODIGO_MICROETAPA = 4 OR CODIGO_MICROETAPA = 5 OR CODIGO_MICROETAPA = 6 OR CODIGO_MICROETAPA = 7 OR CODIGO_MICROETAPA = 8 OR CODIGO_MICROETAPA = 9 OR CODIGO_MICROETAPA = 10 OR CODIGO_MICROETAPA = 11 OR CODIGO_MICROETAPA = 12 OR CODIGO_MICROETAPA = 13 OR CODIGO_MICROETAPA = 14 OR CODIGO_MICROETAPA = 15 OR CODIGO_MICROETAPA = 16 OR CODIGO_MICROETAPA = 17 OR CODIGO_MICROETAPA = 18 OR CODIGO_MICROETAPA = 19 OR CODIGO_MICROETAPA = 20 OR CODIGO_MICROETAPA = 21 OR CODIGO_MICROETAPA = 22 OR CODIGO_MICROETAPA = 23 OR CODIGO_MICROETAPA = 24 OR CODIGO_MICROETAPA = 25 OR CODIGO_MICROETAPA = 26 OR CODIGO_MICROETAPA = 27 OR CODIGO_MICROETAPA = 28 and flag = 1 order by nombre;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Micro
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Micro> MicroODSDSelectiva()
        {
            List<C_Micro> lista = new List<C_Micro>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO_MICROETAPA, NOMBRE FROM MICROETAPA WHERE CODIGO_MICROETAPA = 1 OR CODIGO_MICROETAPA = 2 OR CODIGO_MICROETAPA = 3 OR CODIGO_MICROETAPA = 29 OR CODIGO_MICROETAPA = 30 OR CODIGO_MICROETAPA = 31 OR CODIGO_MICROETAPA = 4 OR CODIGO_MICROETAPA = 5 OR CODIGO_MICROETAPA = 6 OR CODIGO_MICROETAPA = 32 OR CODIGO_MICROETAPA = 8 OR CODIGO_MICROETAPA = 9 OR CODIGO_MICROETAPA = 10 OR CODIGO_MICROETAPA = 11 OR CODIGO_MICROETAPA = 12 OR CODIGO_MICROETAPA = 13 OR CODIGO_MICROETAPA = 14 OR CODIGO_MICROETAPA = 15 OR CODIGO_MICROETAPA = 16 OR CODIGO_MICROETAPA = 17 OR CODIGO_MICROETAPA = 18 OR CODIGO_MICROETAPA = 19 OR CODIGO_MICROETAPA = 20 OR CODIGO_MICROETAPA = 21 OR CODIGO_MICROETAPA = 33 OR CODIGO_MICROETAPA = 23 OR CODIGO_MICROETAPA = 24 OR CODIGO_MICROETAPA = 25 OR CODIGO_MICROETAPA = 26 OR CODIGO_MICROETAPA = 40 OR CODIGO_MICROETAPA = 28 and flag = 1 order by nombre;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Micro
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Micro> MicroIncautacion()
        {
            List<C_Micro> lista = new List<C_Micro>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO_MICROETAPA, NOMBRE FROM MICROETAPA WHERE CODIGO_MICROETAPA = 1 OR CODIGO_MICROETAPA = 2 OR CODIGO_MICROETAPA = 3 OR CODIGO_MICROETAPA = 4 OR CODIGO_MICROETAPA = 34 OR CODIGO_MICROETAPA = 35 OR CODIGO_MICROETAPA = 36 OR CODIGO_MICROETAPA = 37 and flag = 1 order by nombre;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Micro
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Micro> MicroODSDMasivo()
        {
            List<C_Micro> lista = new List<C_Micro>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO_MICROETAPA, NOMBRE FROM MICROETAPA WHERE CODIGO_MICROETAPA = 1 OR CODIGO_MICROETAPA = 2 OR CODIGO_MICROETAPA = 3 OR CODIGO_MICROETAPA = 4 OR CODIGO_MICROETAPA = 5 OR CODIGO_MICROETAPA = 6 OR CODIGO_MICROETAPA = 32 OR CODIGO_MICROETAPA = 8 OR CODIGO_MICROETAPA = 38 and flag = 1 order by nombre;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Micro
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        //
        public List<C_Macro> MacroMostrar()
        {
            List<C_Macro> lista = new List<C_Macro>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo, nombre from macroetapa where flag = 1 order by nombre;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Macro
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_Micro> MicroMostrar()
        {
            List<C_Micro> lista = new List<C_Micro>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_microetapa, nombre from microetapa where flag = 1 order by nombre;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Micro
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_Micro> MicroMostrarByMacro(int codigoMacro)
        {
            List<C_Micro> lista = new List<C_Micro>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT ME.codigo_microetapa, ME.nombre FROM macroetapa_microetapa MA INNER JOIN microetapa ME ON ME.codigo_microetapa = MA.codigo_microetapa WHERE ME.flag = 1 AND  MA.codigo = " + codigoMacro + " AND MA.flag = 1  order by ME.nombre;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Micro
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;

        }
        public List<C_EtapaProcesal> EtapaMostrar()
        {
            List<C_EtapaProcesal> lista = new List<C_EtapaProcesal>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo, nombre from etapaprocesal where flag = 1 order by nombre;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_EtapaProcesal
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_Liquidaciones> LiquidacionesMostrar(string operacion, string num_expediente, string nombre, string cuenta_bt) 
        {
            List<C_Liquidaciones> lista = new List<C_Liquidaciones>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_Liquidaciones objliquida = new C_Liquidaciones();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT AGENCIA, NOMBRE_PROCESO,NOMBRE_CLIENTE,OPERACION,NOMBRE, NOMBRE_DETALLE, FECHA_LIQUIDACION, NRO_RECIBO, CANTIDAD, MONTO, CODIGO_LIQUIDACION_DETALLE, CODIGO_TIPOGASTO, CODIGO_DETALLE,FECHA_LIQUIDACION FROM VW_LIQUIDACION WHERE OPERACION = '|" + operacion + "' AND NUM_EXPEDIENTE = '" + num_expediente + "' AND NOMBRE_CLIENTE = '" + nombre + "' AND CUENTA_BT = '" + cuenta_bt + "' ;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {

                        objliquida.Fecha_liquidacionString = "" + rd.GetDateTime(6).ToShortDateString();
                        lista.Add(new C_Liquidaciones
                        {
                            Agencia = rd.GetString(0),
                            Nombre_proceso = rd.GetString(1),
                            Nombre_cliente = rd.GetString(2),
                            Operacion = rd.GetString(3),
                            Nombre_gasto = rd.GetString(4),
                            Nombre_detalle = rd.GetString(5),
                            Fecha_liquidacionString = objliquida.Fecha_liquidacionString,
                            Nro_recibo = rd.GetString(7),
                            Cantidad = rd.GetString(8),
                            Monto = rd.GetString(9),
                            Codigo_Detalle_liquidacion = rd.GetInt32(10),
                            Codigo_tipogasto = rd.GetInt32(11),
                            Codigo_detalle = rd.GetInt32(12),
                            Fecha_liquidacion = rd.GetDateTime(13)


                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;

        }
        public List<C_Liquidaciones> LiquidacionesReporte() 
        {
            List<C_Liquidaciones> lista = new List<C_Liquidaciones>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_Liquidaciones objliquida = new C_Liquidaciones();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT AGENCIA, NOMBRE_PROCESO,NOMBRE_CLIENTE,OPERACION,NOMBRE, NOMBRE_DETALLE, FECHA_LIQUIDACION, NRO_RECIBO, CANTIDAD, MONTO, CODIGO_LIQUIDACION_DETALLE, CODIGO_TIPOGASTO, CODIGO_DETALLE,FECHA_LIQUIDACION FROM VW_LIQUIDACION ;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {

                        objliquida.Fecha_liquidacionString = "" + rd.GetDateTime(6).ToShortDateString();
                        lista.Add(new C_Liquidaciones
                        {
                            Agencia = rd.GetString(0),
                            Nombre_proceso = rd.GetString(1),
                            Nombre_cliente = rd.GetString(2),
                            Operacion = rd.GetString(3),
                            Nombre_gasto = rd.GetString(4),
                            Nombre_detalle = rd.GetString(5),
                            Fecha_liquidacionString = objliquida.Fecha_liquidacionString,
                            Nro_recibo = rd.GetString(7),
                            Cantidad = rd.GetString(8),
                            Monto = rd.GetString(9),
                            Codigo_Detalle_liquidacion = rd.GetInt32(10),
                            Codigo_tipogasto = rd.GetInt32(11),
                            Codigo_detalle = rd.GetInt32(12),
                            Fecha_liquidacion = rd.GetDateTime(13)


                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Liquidaciones> LiquidacionesReporteCartera(int codigo_cartera)
        {
            List<C_Liquidaciones> lista = new List<C_Liquidaciones>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_Liquidaciones objliquida = new C_Liquidaciones();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT AGENCIA, NOMBRE_PROCESO,NOMBRE_CLIENTE,OPERACION,NOMBRE, NOMBRE_DETALLE, FECHA_LIQUIDACION, NRO_RECIBO, CANTIDAD, MONTO, CODIGO_LIQUIDACION_DETALLE, CODIGO_TIPOGASTO, CODIGO_DETALLE,FECHA_LIQUIDACION FROM VW_LIQUIDACION WHERE CODIGO_CARTERA = '"+codigo_cartera+"';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {

                        objliquida.Fecha_liquidacionString = "" + rd.GetDateTime(6).ToShortDateString();
                        lista.Add(new C_Liquidaciones
                        {
                            Agencia = rd.GetString(0),
                            Nombre_proceso = rd.GetString(1),
                            Nombre_cliente = rd.GetString(2),
                            Operacion = rd.GetString(3),
                            Nombre_gasto = rd.GetString(4),
                            Nombre_detalle = rd.GetString(5),
                            Fecha_liquidacionString = objliquida.Fecha_liquidacionString,
                            Nro_recibo = rd.GetString(7),
                            Cantidad = rd.GetString(8),
                            Monto = rd.GetString(9),
                            Codigo_Detalle_liquidacion = rd.GetInt32(10),
                            Codigo_tipogasto = rd.GetInt32(11),
                            Codigo_detalle = rd.GetInt32(12),
                            Fecha_liquidacion = rd.GetDateTime(13)


                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        
        
        public List<C_Garante> GaranteMostrar(string operacion) 
        {
            List<C_Garante> lista = new List<C_Garante>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_distrito,codigo_garante,nombre_completo,nombre_conyuge,nombre_distrito,domicilio_garante from vw_garantemostrar where OPERACION ='" + operacion+ "' AND flag != 0;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Garante
                        {
                            CodigoDistrito = rd.GetInt32(0),
                            Codigo = rd.GetInt32(1),
                            NombreCompleto = rd.GetString(2),
                            NombreConyuge = rd.GetString(3),
                            NombreDistrito = rd.GetString(4),
                            DomicilioGarante = rd.GetString(5)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Modelo> ModeloMostrar()
        {
            List<C_Modelo> lista = new List<C_Modelo>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo, nombre from modelo order by nombre;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Modelo
                        {
                            Codigo = rd.GetInt32(0),
                            Nombre = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_BH> BienH(string codigo)
        {
            List<C_BH> lista = new List<C_BH>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT NOMBRE, MONTO_HIPOTECADO, MONTO_DEMANDADO, FECHA_DEMANDA, NOMBREFMC, FECHA_PRES_MC FROM VW_BIENHIPOTECADO WHERE CUENTA_BT = '" + codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_BH
                        {
                            NombreHipotecado = rd.GetString(0),
                            MontoHipotecado = rd.GetString(1),
                            MontoDemandado = rd.GetString(2),
                            FechaDemanda = rd.GetDateTime(3),
                            NombreCodigoFMC = rd.GetString(4),
                            FechaPRESMC = rd.GetDateTime(5)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_BE> BienE(string codigo)
        {
            List<C_BE> lista = new List<C_BE>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT FECHA_EMBARGO,NOMBRE,PARTIDA_PLACA,UBICACION_BIEN,NOMBRERANGO,MONTO_EMBARGADO FROM VW_BIENEMBARGADO WHERE CUENTA_BT = '" + codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_BE
                        {
                            FechaEmbargo = rd.GetDateTime(0),
                            NombreEmbargado = rd.GetString(1),
                            PartidaPlaca = rd.GetString(2),
                            UbicacionBien = rd.GetString(3),
                            NombreRangoHipoteca = rd.GetString(4),
                            MontoEmbargado = rd.GetString(5)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista; 
        }
        public List<C_BH> BienesHipotecadoMostrar(string codigo)
        {
            List<C_BH> lista = new List<C_BH>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO_BIENHIPOTECADO, NOMBRE FROM VW_BIENHIPOTECADO WHERE CUENTA_BT ='" + codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_BH
                        {
                            Codigo = rd.GetInt32(0),
                            NombreHipotecado = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_BE> BienesEmbargadosMostrar(string codigo)
        {
            List<C_BE> lista = new List<C_BE>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO_BIENEMBARGADO, NOMBRE FROM VW_BIENEMBARGADO WHERE CUENTA_BT = '" + codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_BE
                        {
                            
                            CodigoE= rd.GetInt32(0),
                            NombreEmbargado = rd.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_MedidaCautelarHipoteca> PrimeroBH(int codigo)
        {
            List<C_MedidaCautelarHipoteca> lista = new List<C_MedidaCautelarHipoteca>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT MONTO_TASACION,FECHA_ULTASACION,VALOR_COMERCIAL,ESTADO_CAUTELAR,FECHA_ULTACTCAUTELAR FROM VW_BIENHIPOTECADOMC WHERE CODIGO_BIENHIPOTECADO = " + codigo + ";", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_MedidaCautelarHipoteca
                        {
                            MontoTasacion = rd.GetString(0),
                            FechaUltTasacion = rd.GetDateTime(1),
                            ValorComercial = rd.GetString(2),
                            EstadoCautelar = rd.GetString(3),
                            FechaUltActCautelar = rd.GetDateTime(4)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_MedidaCautelarHipoteca> SegundoBH(int codigo)
        {
            List<C_MedidaCautelarHipoteca> lista = new List<C_MedidaCautelarHipoteca>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT OTROS_EMBARGOS,MONTO_OTROS_EMBARGOS,PORCENTAJE_EMBARGO,VIGENCIA_MC FROM VW_BIENHIPOTECADOMC WHERE CODIGO_BIENHIPOTECADO =" + codigo + ";", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_MedidaCautelarHipoteca
                        {
                            OtrosEmbargos = rd.GetString(0),
                            MontoOtrosEmbargos = rd.GetString(1),
                            PorcentajeEmbargo = rd.GetString(2),
                            VigenciaMC = rd.GetString(3)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_MedidaCautelarHipoteca> PrimeroBE(int codigo)
        {
            List<C_MedidaCautelarHipoteca> lista = new List<C_MedidaCautelarHipoteca>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT MONTO_TASACION,FECHA_ULTASACION,VALOR_COMERCIAL,ESTADO_CAUTELAR,FECHA_ULTACTCAUTELAR FROM VW_BIENEMBARGADOMC WHERE CODIGO_BIENEMBARGADO =" + codigo + ";", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_MedidaCautelarHipoteca
                        {
                            MontoTasacion = rd.GetString(0),
                            FechaUltTasacion = rd.GetDateTime(1),
                            ValorComercial = rd.GetString(2),
                            EstadoCautelar = rd.GetString(3),
                            FechaUltActCautelar = rd.GetDateTime(4)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_MedidaCautelarHipoteca> SegundoBE(int codigo)
        {
            List<C_MedidaCautelarHipoteca> lista = new List<C_MedidaCautelarHipoteca>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT OTROS_EMBARGOS,MONTO_OTROS_EMBARGOS,PORCENTAJE_EMBARGO,VIGENCIA_MC FROM VW_BIENEMBARGADOMC WHERE CODIGO_BIENEMBARGADO =" + codigo + ";", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_MedidaCautelarHipoteca
                        {
                            OtrosEmbargos = rd.GetString(0),
                            MontoOtrosEmbargos = rd.GetString(1),
                            PorcentajeEmbargo = rd.GetString(2),
                            VigenciaMC = rd.GetString(3)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_Bien> BienDGV(string expediente)
        {
            List<C_Bien> lista = new List<C_Bien>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_Bien objetoBien = new C_Bien();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_tipobien,codigo_rango,codigo_bien, nombre_tipobien,nombre_bien,monto_garantia,monto_tasacion, fecha_tasacion, partida_placa, nombre_rango, porcentaje_derechos, descripcion,fecha_tasacion,valor_comercial, nombre_ciudad, nombre_distrito, marca,modelo  from vw_biendgv where num_expediente = '"+ expediente +"' and flag = 1;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {                    
                        if (rd[3] == DBNull.Value)
                            objetoBien.NombreTipoBien= " ";
                        else
                            objetoBien.NombreTipoBien = rd.GetString(3);
                        //
                        if (rd[4] == DBNull.Value)
                            objetoBien.NombreBien = " ";
                        else
                            objetoBien.NombreBien = rd.GetString(4);
                        //
                        if (rd[5] == DBNull.Value)
                            objetoBien.MontoGarantia = " ";
                        else
                            objetoBien.MontoGarantia = rd.GetString(5);
                        //
                        if (rd[6] == DBNull.Value)
                            objetoBien.MontoTasacion = " ";
                        else
                            objetoBien.MontoTasacion = rd.GetString(6);
                        //
                        if (rd.GetDateTime(7) == DateTime.Parse("01-01-1990"))
                        {
                            objetoBien.FechaTasacionString = " ";
                        }
                        else if (rd[7] != DBNull.Value)
                        {
                            objetoBien.FechaTasacionString = " " + rd.GetDateTime(7).ToShortDateString();
                        }
                        else
                        {
                            objetoBien.FechaTasacionString = " ";
                        }
                        //
                        if (rd[8] == DBNull.Value)
                            objetoBien.PartidaPlaca = " ";
                        else
                            objetoBien.PartidaPlaca = rd.GetString(8);
                        //
                        if (rd[9] == DBNull.Value)
                            objetoBien.NombreRango = " ";
                        else
                            objetoBien.NombreRango = rd.GetString(9);
                        //
                        if (rd[10] == DBNull.Value)
                            objetoBien.PorcentajeDerechos = " ";
                        else
                            objetoBien.PorcentajeDerechos = rd.GetString(10);
                        //
                        if (rd[11] == DBNull.Value)
                            objetoBien.Descripcion = " ";
                        else
                            objetoBien.Descripcion = rd.GetString(11);
                        //
                        if (rd[12] == DBNull.Value)
                        {
                            objetoBien.FechaTasacion = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoBien.FechaTasacion = rd.GetDateTime(12);
                        }
                        //
                        if (rd[13] == DBNull.Value)
                        {
                            objetoBien.ValorComercial = " ";
                        }
                        else
                        {
                            objetoBien.ValorComercial = rd.GetString(13);
                        }
                        //
                        if (rd[14] == DBNull.Value)
                        {
                            objetoBien.Ciudad = " ";
                        }
                        else
                        {
                            objetoBien.Ciudad = rd.GetString(14);
                        }
                        //
                        if (rd[15] == DBNull.Value)
                        {
                            objetoBien.Distrito = " ";
                        }
                        else
                        {
                            objetoBien.Distrito = rd.GetString(15);
                        }
                        //
                        if (rd[16] == DBNull.Value)
                        {
                            objetoBien.Marca = " ";
                        }
                        else
                        {
                            objetoBien.Marca = rd.GetString(16);
                        }
                        //
                        if (rd[17] == DBNull.Value)
                        {
                            objetoBien.Modelo = " ";
                        }
                        else
                        {
                            objetoBien.Modelo = rd.GetString(17);
                        }
                        lista.Add(new C_Bien
                        {
                            CodigoTipoBien = rd.GetInt32(0),
                            CodigoRango = rd.GetInt32(1),
                            Codigo = rd.GetInt32(2),
                            NombreTipoBien = objetoBien.NombreTipoBien,
                            NombreBien = objetoBien.NombreBien,
                            MontoGarantia = objetoBien.MontoGarantia,
                            MontoTasacion = objetoBien.MontoTasacion,
                            FechaTasacionString = objetoBien.FechaTasacionString,
                            PartidaPlaca = objetoBien.PartidaPlaca,
                            NombreRango = objetoBien.NombreRango,
                            PorcentajeDerechos = objetoBien.PorcentajeDerechos,
                            Descripcion = objetoBien.Descripcion,
                            FechaTasacion = objetoBien.FechaTasacion,
                            ValorComercial = objetoBien.ValorComercial,
                            Ciudad = objetoBien.Ciudad,
                            Distrito = objetoBien.Distrito,
                            Marca = objetoBien.Marca,
                            Modelo = objetoBien.Modelo
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_OtrasCargas> OtrasCargasDGV(int codigo)
        {
            List<C_OtrasCargas> lista = new List<C_OtrasCargas>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_OtrasCargas objetoOtrasCargas = new C_OtrasCargas();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO_BIEN,DESCRIPCION, CODIGO,ACREEDOR,RANGO,MONTO_GARANTIA,MONTO_ADEUDADO FROM VW_OTRASCARGAS WHERE CODIGO_BIEN = " + codigo + " AND FLAG != 0 ;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                            objetoOtrasCargas.CodigoBien = -1;
                        else
                            objetoOtrasCargas.CodigoBien = rd.GetInt32(0);
                        if (rd[1] == DBNull.Value)
                            objetoOtrasCargas.DescripcionBien = " ";
                        else
                            objetoOtrasCargas.DescripcionBien = rd.GetString(1);
                        if(rd[3] == DBNull.Value)
                            objetoOtrasCargas.Acreedor = " ";
                        else
                            objetoOtrasCargas.Acreedor = rd.GetString(3);
                        if (rd[4] == DBNull.Value)
                            objetoOtrasCargas.Rango = " ";
                        else
                            objetoOtrasCargas.Rango = rd.GetString(4);
                        if(rd[5] == DBNull.Value)
                            objetoOtrasCargas.MontoGarantia = " ";
                        else
                            objetoOtrasCargas.MontoGarantia = rd.GetString(5);
                        if (rd[6] == DBNull.Value)
                            objetoOtrasCargas.MontoAdeudado = " ";
                        else
                            objetoOtrasCargas.MontoAdeudado = rd.GetString(6);
                            
                        lista.Add(new C_OtrasCargas
                        {
                            CodigoBien = objetoOtrasCargas.CodigoBien,
                            DescripcionBien = objetoOtrasCargas.DescripcionBien,
                            Codigo = rd.GetInt32(2),
                            Acreedor = objetoOtrasCargas.Acreedor,
                            Rango = objetoOtrasCargas.Rango,
                            MontoGarantia = objetoOtrasCargas.MontoGarantia,
                            MontoAdeudado = objetoOtrasCargas.MontoAdeudado
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_Pagos> PagosDGV(string expediente)
        {
            List<C_Pagos> lista = new List<C_Pagos>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT NOMBRE_COMPLETO,NOMBRE_MONEDA,NOMBRE_CARTERA,CODIGO,TIPO_SOLUCION,PAGO,COMISION,FECHA_PAGO FROM VW_PAGODGV WHERE num_expediente = '" + expediente + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                C_Pagos objetoPagos = new C_Pagos();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd.GetDateTime(7) == DateTime.Parse("01-01-1990"))
                        {
                            objetoPagos.FechaPagoStrin = " ";
                        }
                        else if (rd[7] != DBNull.Value)
                        {
                            objetoPagos.FechaPagoStrin = "" + rd.GetDateTime(7).ToShortDateString();
                        }
                        else
                        {
                            objetoPagos.FechaPagoStrin = " ";
                        }
                        //
                        if (rd[7] == DBNull.Value)
                        {
                            objetoPagos.FechaPago = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoPagos.FechaPago = rd.GetDateTime(7);
                        }
                        lista.Add(new C_Pagos
                        {

                            NombrePersona = rd.GetString(0),
                            NombreMoneda = rd.GetString(1),
                            NombreCartera = rd.GetString(2),
                            Codigo = rd.GetInt32(3),
                            TipoSolucion = rd.GetString(4),
                            Pago = rd.GetString(5),
                            Comision = rd.GetString(6),
                            FechaPagoStrin = objetoPagos.FechaPagoStrin,
                            FechaPago = objetoPagos.FechaPago
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_CreditoDetalle> CreditoDetalleMostrar(string codigo)
        {
            List<C_CreditoDetalle> lista = new List<C_CreditoDetalle>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT OPERACION FROM CREDITO_DETALLE WHERE CUENTA_BT = '" + codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_CreditoDetalle
                        {
                            Codigo = rd.GetString(0)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;

        }
        public List<C_Expediente> ExpedienteCreditoMostrar(string operacion)
        {
            List<C_Expediente> lista = new List<C_Expediente>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT NUM_EXPEDIENTE FROM DETALLE_EXPEDIENTE_CREDITO WHERE OPERACION =  '" + operacion + "' ORDER BY NUM_EXPEDIENTE ASC;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Expediente
                        {
                             NumExpediente = rd.GetString(0)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_TipoGasto> TipoGastoMostrar() 
        {
            List<C_TipoGasto> lista = new List<C_TipoGasto>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT NOMBRE, CODIGO FROM TIPO_GASTO ORDER BY NOMBRE ASC", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_TipoGasto
                        {
                            Nombre = rd.GetString(0),
                            Codigo = rd.GetInt32(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_DetalleTipoGasto> DetalleTipoGastoMostrar(int codigo) 
        {
            List<C_DetalleTipoGasto> lista = new List<C_DetalleTipoGasto>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO_DETALLE, NOMBRE_DETALLE FROM DETALLE_TIPO_GASTO WHERE CODIGO_TIPOGASTO = "+codigo +" ORDER BY NOMBRE_DETALLE ASC", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_DetalleTipoGasto
                        {
                            Codigo_detalle = rd.GetInt32(0),
                            Nombre_detalle = rd.GetString(1),

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Expediente> ExpedienteTodoMostrar()
        {
            List<C_Expediente> lista = new List<C_Expediente>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT NUM_EXPEDIENTE FROM DETALLE_EXPEDIENTE_CREDITO ORDER BY NUM_EXPEDIENTE ASC", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Expediente
                        {
                            NumExpediente = rd.GetString(0)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }

        public List<C_Micro> MicroEstadoMostrar(int codigo)
        {
            List<C_Micro> lista = new List<C_Micro>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT NOMBRE,  CODIGO_MICROETAPA,CODIGO FROM VW_MACROETAPA_MICROETAPA WHERE CODIGO = '" + codigo + "' AND FLAG = 1", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Micro
                        {
                            Nombre = rd.GetString(0),
                            Codigo = rd.GetInt32(1),
                            CodigoEstado = rd.GetInt32(2)
                            
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }


        public List<C_Macro> MacroEstadoMostrar(int codigo) {
            List<C_Macro> lista = new List<C_Macro>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT NOMBRE, CODIGO, CODIGO_PROCESO FROM VW_TIPO_PROCESO_MACROETAPA WHERE CODIGO_PROCESO = '" + codigo + "' AND FLAGTPM = 1", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Add(new C_Macro
                        {
                            Nombre = rd.GetString(0),
                            Codigo = rd.GetInt32(1),
                            CodigoEstadoMacro = rd.GetInt32(2)

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }

        /*FUNCION MOSTRAR 1 / CARGAR TEXTBOX*/

        public C_Trabajador TrabajadorMostrar1(int dniTrabajador)
        {
            C_Trabajador lista = new C_Trabajador();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select dni_trabajador, nombre, apellido_paterno, apellido_materno, contra, codigo_tipo_trabajador from trabajador where flag = 1 and dni_trabajador = " + dniTrabajador, cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.DniTrabajador = rd.GetInt32(0);
                        lista.NombreTrabajador = rd.GetString(1);
                        lista.ApellidoPaterno = rd.GetString(2);
                        lista.ApellidoMaterno = rd.GetString(3);
                        lista.Contra = rd.GetString(4);
                        lista.CodigoTipoTrabajador = rd.GetInt32(5);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        /*--public C_Persona DOIMostrar1(int codigo)
        {
            C_Persona lista = new C_Persona();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_persona, codigo_distrito, doi_cliente, nombre_persona, apellido_paterno, apellido_materno,nombre_conyuge, apellido_paterno_conyuge, apellido_materno_conyuge, representante,domicilio_persona,direccion_alterna from persona where flag = 1 and codigo_persona = " + codigo + ";", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.CodigoPersona1 = rd.GetInt32(0);
                        lista.CodigoDistrito = rd.GetInt32(1);
                        lista.DoiCliente = rd.GetInt32(2);
                        lista.NombrePersona = rd.GetString(3);
                        lista.ApellidoPaterno = rd.GetString(4);
                        lista.ApellidoMaterno = rd.GetString(5);
                        lista.NombreConyuge = rd.GetString(6);
                        lista.ApellidoPaternoConyuge = rd.GetString(7);
                        lista.ApellidoMaternoConyuge = rd.GetString(8);
                        lista.Representante = rd.GetString(9);
                        lista.DomicilioPersona = rd.GetString(10);
                        lista.DireccionAlterna = rd.GetString(11);

                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista; 
        }*/
        public C_TipoProceso ProcesoMostrar1(int codigo)
        {
            C_TipoProceso lista = new C_TipoProceso();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_proceso, nombre_proceso from tipo_proceso where flag = 1 and codigo_proceso = " + codigo, cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.CodigoProceso = rd.GetInt32(0);
                        lista.NombreProceso = rd.GetString(1);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista; 
        }
        public C_Cartera CarteraMostrar1(int codigo)
        {
            C_Cartera lista = new C_Cartera();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_cartera, nombre from cartera where flag = 1 and codigo_cartera = " + codigo, cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.CodigoCartera = rd.GetInt32(0);
                        lista.NombreCartera = rd.GetString(1);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista; 
        }
        public C_Moneda MonedaMostrar1(int codigo) 
        {
            C_Moneda lista = new C_Moneda();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_moneda, nombre from moneda where codigo_moneda = " + codigo, cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.CodigoMoneda = rd.GetInt32(0);
                        lista.NombreMoneda = rd.GetString(1);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista; 
        }
        public C_Ciudad CiudadMostrar1(int codigo)
        {
            C_Ciudad lista = new C_Ciudad();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_ciudad, nombre from ciudad where flag = 1 and codigo_ciudad = " + codigo, cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.CodigoCiudad = rd.GetInt32(0);
                        lista.NombreCiudad = rd.GetString(1);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;  
        }
        public C_Estudio EstudioMostrar1(int codigo)
        {
            C_Estudio lista = new C_Estudio();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_estudio, nombre from estudio where flag = 1 and codigo_estudio = " + codigo, cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.CodigoEstudio = rd.GetInt32(0);
                        lista.NombreEstudio= rd.GetString(1);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;  
 
        }
        public C_Juzgado JuzgadoMostrar1(int codigo)
        {
            C_Juzgado lista = new C_Juzgado();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_juzgado, nombre from juzgado where flag = 1 and codigo_juzgado = " + codigo, cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.CodigoJuzgado = rd.GetInt32(0);
                        lista.NombreJuzgado = rd.GetString(1);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;  
        }
        public C_TipoTrabajador TipoTrabajadorMostrar1(int codigo)
        {
            C_TipoTrabajador tipoTrabajador = new C_TipoTrabajador();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_tipo_trabajador, nombre from tipo_trabajador where flag = 1 and codigo_tipo_trabajador = " + codigo, cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        tipoTrabajador.CodigoTipoTrabajador = rd.GetInt32(0);
                        tipoTrabajador.Nombre = rd.GetString(1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return tipoTrabajador;
        }
        public C_FormaMedidaCautelar FormaMedidaCautelarMostrar1(int codigo)
        {
            C_FormaMedidaCautelar lista = new C_FormaMedidaCautelar();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo, nombre from FormaMedidaCautelar where flag = 1 and codigo = " + codigo + " order by nombre;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Codigo = rd.GetInt32(0);
                        lista.Nombre = rd.GetString(1);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public C_BienHipotecado BienHipotecadoMostrar1(int codigo)
        {
            C_BienHipotecado lista = new C_BienHipotecado();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo, nombre from bienHipotecado where flag = 1 and codigo = " + codigo, cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Codigo = rd.GetInt32(0);
                        lista.Nombre = rd.GetString(1);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public C_RangoHipotecado RangoHipotecadoMostrar1(int codigo)
        {
            C_RangoHipotecado lista = new C_RangoHipotecado();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_rango_hipoteca, nombre from rango_hipoteca where flag = 1 and codigo_rango_hipoteca = " + codigo, cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.CodigoRangoHipotecado = rd.GetInt32(0);
                        lista.NombreRangoHipotecado = rd.GetString(1);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public C_BienEmbargado BienEmbargadoMostrar1(int codigo)
        {
            C_BienEmbargado lista = new C_BienEmbargado();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_bienembargado, nombre from bienembargado where flag = 1 and codigo_bienembargado = " + codigo, cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Codigo= rd.GetInt32(0);
                        lista.Nombre = rd.GetString(1);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public C_EstadoProcesal EstadoProcesalMostrar1(int codigo)
        {
            C_EstadoProcesal lista = new C_EstadoProcesal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo, nombre from Estado_Procesal where flag = 1 and codigo = " + codigo + " order by nombre", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Codigo = rd.GetInt32(0);
                        lista.Nombre = rd.GetString(1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public C_Distrito DistritoMostrar1(int codigo)
        {
            C_Distrito lista = new C_Distrito();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_distrito, nombre from distrito where flag = 1 and codigo_distrito = " + codigo + " ORDER BY NOMBRE", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.CodigoDistrito = rd.GetInt32(0);
                        lista.NombreDistrito = rd.GetString(1);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista; 
        }
        public C_OtrasCargas OtrasCargasMostrar1(int codigo)
        {
            C_OtrasCargas lista = new C_OtrasCargas();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo_bien, descripcion from bien where codigo_bien = " + codigo, cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.CodigoBien = rd.GetInt32(0);
                        lista.DescripcionBien = rd.GetString(1);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista; 
 
        }
        public C_Pagos PagosMotrar1(string operacion)
        {
            C_Pagos lista = new C_Pagos();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT NOMBRE_COMPLETO , NOMBRE_MONEDA, NOMBRE_CARTERA FROM VW_PAGOMOSTRAR WHERE OPERACION = '" + operacion+ "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.NombrePersona = rd.GetString(0);
                        lista.NombreMoneda = rd.GetString(1);
                        lista.NombreCartera = rd.GetString(2);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista; 
        }
        public C_Historico HistoricoMostrar1(string num_expediente)
        {
            C_Historico lista = new C_Historico();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT TEXTO_PROCESO,TEXTO_LLAMADA,TEXTO_CAMPO FROM HISTORICO WHERE NUM_EXPEDIENTE = '"+ num_expediente+"' ;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Texto = rd.GetString(0);
                        lista.Llamada = rd.GetString(1);
                        lista.Campo = rd.GetString(2);
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista; 
 
        }
        public int CodigoSeguimientoProceso(C_SeguimientoProceso objetoSeguimientoProceso)
        {
            int codigo = 0;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo from seguimientoproceso where num_expediente = '" + objetoSeguimientoProceso.Num_expediente +"'  and estadoprocesal = "+ objetoSeguimientoProceso.EstadoProcesal + " and fechaestadoprocesal = '"+ objetoSeguimientoProceso.FechaEstadoProcesal.ToShortDateString() + "' and fechatareaadministrativa = '"+ objetoSeguimientoProceso.FechaTareaAdministrativa.ToShortDateString() +"' ;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            codigo = 0;
                        }
                        else
                        {
                            codigo = rd.GetInt32(0);
                        }
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return codigo;
        }

        /* VALIDAR BUSQUEDAS */

        public bool CuentaBTExiste(string cuentaBT)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("spr_cuentabtexiste", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_CUENTA_BT", cuentaBT);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;

        }
        public bool DoiExiste(string doiCliente)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("spr_doiexiste ", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_DOI_CLIENTE", doiCliente);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }

        /* CARGAR TODO EL FORMULARIO */

            // CARGAR TITULAR
        public C_Persona PersonaMostrar1(string codigo)
        {
            C_Persona lista = new C_Persona();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT DOI_CLIENTE, CODIGO_DISTRITO, NOMBRE_COMPLETO, NOMBRE_CONYUGE, DOMICILIO_PERSONA, DIRECCION_ALTERNA, REPRESENTANTE, NUMERO, CUENTA_BT,CONVENIO_PERSONA FROM PERSONA WHERE CUENTA_BT = '" + codigo + "' AND FLAG = 1;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Doi_cliente = rd.GetString(0);
                        lista.CodigoDistrito = rd.GetInt32(1);
                        lista.NombreCompleto = rd.GetString(2);
                        lista.NombreConyuge = rd.GetString(3);
                        lista.DomicilioPersona = rd.GetString(4);
                        lista.DireccionAlterna = rd.GetString(5);
                        lista.Representante = rd.GetString(6);
                        lista.Numero = rd.GetString(7);
                        lista.Cuenta_bt = rd.GetString(8);
                        lista.Convenio = rd.GetString(9);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public C_Persona PersonaMostrar1PorDoi(string doi)
        {
            C_Persona lista = new C_Persona();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT DOI_CLIENTE, CODIGO_DISTRITO, NOMBRE_COMPLETO, NOMBRE_CONYUGE, DOMICILIO_PERSONA, DIRECCION_ALTERNA, REPRESENTANTE, NUMERO, CUENTA_BT,CONVENIO_PERSONA FROM PERSONA WHERE DOI_CLIENTE = '" + doi + "' AND FLAG = 1;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Doi_cliente = rd.GetString(0);
                        lista.CodigoDistrito = rd.GetInt32(1);
                        lista.NombreCompleto = rd.GetString(2);
                        lista.NombreConyuge = rd.GetString(3);
                        lista.DomicilioPersona = rd.GetString(4);
                        lista.DireccionAlterna = rd.GetString(5);
                        lista.Representante = rd.GetString(6);
                        lista.Numero = rd.GetString(7);
                        lista.Cuenta_bt = rd.GetString(8);
                        lista.Convenio = rd.GetString(9);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public C_Persona PersonaMostrarSolo(string codigo)
        {
            C_Persona lista = new C_Persona();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_Persona objetoPersona = new C_Persona();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, NOMBRE_COMPLETO, NOMBRE_CONYUGE, DOI_CLIENTE , DOMICILIO_PERSONA, DIRECCION_ALTERNA, REPRESENTANTE, CODIGO_DISTRITO, NUMERO FROM VW_CARGARTITULAR WHERE DOI_CLIENTE = '" + codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoPersona.Cuenta_bt ="";
                        }
                        lista.Cuenta_bt = objetoPersona.Cuenta_bt;
                        lista.NombreCompleto = rd.GetString(1);
                        lista.NombreConyuge = rd.GetString(2);
                        lista.Doi_cliente = rd.GetString(3);
                        lista.DomicilioPersona = rd.GetString(4);
                        lista.DireccionAlterna = rd.GetString(5);
                        lista.Representante = rd.GetString(6);
                        lista.CodigoDistrito = rd.GetInt32(7);
                        lista.Numero = rd.GetString(8);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
            // CARGAR CREDITO
        public C_Credito CreditoMostrar1(string codigo)
        {
            C_Credito lista = new C_Credito();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT OPERACION, CODIGO_CARTERA,CODIGO_MONEDA, CODIGO_CIUDAD, CODIGO_eSTUDIO, CODIGO_TRAMITE, MODELO, CASTIGOS, CDR,CAPITAL,FECHA_PROTESTO, OBSERVACION_TRAMITE, FECHA_TRAMITE, AGENCIA,FECHA_ASIGNACION, MONTO_ADMITIDO, PRODUCTO_MODULO, EJECUTIVO FROM CREDITO_DETALLE WHERE OPERACION = '" + codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Operacion = rd.GetString(0);
                        lista.CodigoCartera = rd.GetInt32(1);
                        lista.CodigoMoneda = rd.GetInt32(2);
                        lista.CodigoCiudad = rd.GetInt32(3);
                        lista.CodigoEstudio = rd.GetInt32(4);
                        lista.CodigoTramite = rd.GetInt32(5);
                        lista.Modelo = rd.GetInt32(6);
                        lista.Castigos = rd.GetString(7);
                        lista.Cdr = rd.GetString(8);
                        lista.Capital = rd.GetString(9);
                        lista.FechaProtesto = rd.GetDateTime(10);
                        lista.ObservacionTramite = rd.GetString(11);
                        lista.FechaTramite = rd.GetDateTime(12);
                        lista.Agencia = rd.GetString(13);
                        lista.FechaAsignacion = rd.GetDateTime(14);
                        lista.MontoAdmitido = rd.GetString(15);
                        lista.ProductoModulo = rd.GetString(16);
                        lista.Ejecutivo = rd.GetString(17);                    
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public C_Credito CreditoMostrarModelo(string codigo)
        {
            C_Credito lista = new C_Credito();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select nombre from vw_mostrarmodelo where OPERACION = '" + codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.NombreModelo = rd.GetString(0);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
            //CARGAR GARANTE
        public C_Garante CargarDatosGaranteEscritos(string operacion) 
        {
            C_Garante lista = new C_Garante();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT nombre_completo, nombre_conyuge, codigo_distrito, domicilio_garante FROM GARANTE where flag = 1 and operacion = '"+operacion+"';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.NombreCompleto = rd.GetString(0);
                        lista.NombreConyuge = rd.GetString(1);
                        lista.CodigoDistrito = rd.GetInt32(2);
                        lista.DomicilioGarante = rd.GetString(3);                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
            //CARGAR MONTO BIEN
        public C_Bien CargarMontoAdmitido(string codigo)
        {
            C_Bien lista = new C_Bien();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT MONTO_ADMITIDO FROM CREDITO_DETALLE WHERE OPERACION = '" + codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.MontoDemandado = rd.GetString(0);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public C_Bien CargarDatosEscritos(string num_expediente) 
        {
            C_Bien lista = new C_Bien();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select descripcion, partida_placa, monto_garantia, valor_comercial, codigo_ciudad from bien WHERE NUM_EXPEDIENTE =  '"+ num_expediente + "' ;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Descripcion = rd.GetString(0);
                        lista.PartidaPlaca = rd.GetString(1);
                        lista.MontoGarantia = rd.GetString(2);
                        lista.ValorComercial = rd.GetString(3);
                        lista.Codigo_ciudad = rd.GetInt32(4);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
            //CARGAR TIPO PROCESO EN SEGUIMIENTO
        public C_SeguimientoProceso CargarFSeguimiento(string codigo)
        {
            C_SeguimientoProceso lista = new C_SeguimientoProceso();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT NOMBRE_PROCESO,CODIGO_MACRO,CODIGO_MICRO, CODIGO_PROCESO FROM VW_NOMBRE_TIPO_PROCESO WHERE NUM_EXPEDIENTE = '" + codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if(rd[0] != DBNull.Value)
                            lista.NombreEstadoProcesal = rd.GetString(0);
                        if (rd[1] != DBNull.Value)
                            lista.CodigoMacro = rd.GetInt32(1);
                        if (rd[2] != DBNull.Value)
                            lista.CodigoMicro = rd.GetInt32(2);
                        if (rd[3] != DBNull.Value)
                            lista.Codigo = rd.GetInt32(3);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
            //CARGAR EL NOMBRE DE TIPO PROCESO A PROCESO
        public C_Expediente CargarTipoProcesoAProceso(string codigo)
        {
            C_Expediente lista = new C_Expediente();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT codigo_proceso, NOMBRE_PROCESO FROM VW_NOMBRE_TIPO_PROCESO WHERE NUM_EXPEDIENTE = '" + codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.CodigoTipoProceso = rd.GetInt32(0);
                        lista.NombreTipoProceso = rd.GetString(1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
            
            // CARGAR PROCESO

        public C_Proceso ProcesoMostrar1(string codigo)
        {
            C_Proceso lista = new C_Proceso();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_Proceso objetoProceso = new C_Proceso();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CODIGO_MACRO, CODIGO_MICRO, TIEMPO, CODIGO_MEDIDA, FECHA_ETAPA,  FECHA_INSCRIPCION, ESTADO_CAUTELAR, FECHA_MEDIDA_CAUTELAR, VIGENCIA_MC, FECHA_ACTUADO_CAUTELAR, DEVOLUCION_CEDULA FROM PROCESO WHERE NUM_EXPEDIENTE = '"+ codigo +"';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                            objetoProceso.CodigoMacro = -1;
                        else
                            objetoProceso.CodigoMacro = rd.GetInt32(0);
                        //
                        if (rd[1] == DBNull.Value)
                            objetoProceso.CodigoMicro = -1;
                        else
                            objetoProceso.CodigoMicro = rd.GetInt32(1);
                        /*
                        if (rd[2] == DBNull.Value)
                            objetoProceso.CodigoEtapa = -1;
                        else
                            objetoProceso.CodigoEtapa = rd.GetInt32(2);*/
                        if (rd[2] == DBNull.Value)
                            objetoProceso.Tiempo = " ";
                        else
                            objetoProceso.Tiempo = rd.GetString(2);
                        if (rd[6] == DBNull.Value)
                            objetoProceso.EstadoCautelar = " ";
                        else
                            objetoProceso.EstadoCautelar = rd.GetString(6);
                        if (rd[8] == DBNull.Value)
                            objetoProceso.VigenciaMC = " ";
                        else
                            objetoProceso.VigenciaMC = rd.GetString(8);
                        if (rd[10] == DBNull.Value)
                            objetoProceso.DevolucionCedula = " ";
                        else
                            objetoProceso.DevolucionCedula = rd.GetString(10);

                        lista.CodigoMacro = objetoProceso.CodigoMacro;
                        lista.CodigoMicro = objetoProceso.CodigoMicro;
                        lista.Tiempo = objetoProceso.Tiempo;
                        lista.CodigoMedida = rd.GetInt32(3);
                        lista.FechaEtapa = rd.GetDateTime(4);
                        lista.FechaInscripcion = rd.GetDateTime(5);
                        lista.EstadoCautelar = objetoProceso.EstadoCautelar;
                        lista.FechaMedidaCautelar = rd.GetDateTime(7);
                        lista.VigenciaMC = objetoProceso.VigenciaMC;
                        lista.FechaActuadoCautelar = rd.GetDateTime(9);
                        lista.DevolucionCedula = objetoProceso.DevolucionCedula;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;      
        }
            // CARGAR EXPEDIENTE
        public C_Expediente ExpedienteMostrar1(string numExpediente)
        {
            C_Expediente lista = new C_Expediente();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_Expediente objetoExpediente = new C_Expediente();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select num_expediente, num_expediente_22digitos, trabajador_responsable, trabajador_abogado, trabajador_secretario, codigo_proceso, juzgado, codigo_cautelar, num_juzgado from expediente where num_expediente = '" + numExpediente+"';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[8] == DBNull.Value)
                            objetoExpediente.NumJuzgado = " ";
                        else
                            objetoExpediente.NumJuzgado = rd.GetString(8);
                        //
                        lista.NumExpediente = rd.GetString(0);
                        lista.NumExpediente22Digitos = rd.GetString(1);
                        lista.TrabajadoResponsable = rd.GetInt32(2);
                        lista.TrabajadorAbogado = rd.GetInt32(3);
                        lista.TrabajadorSecretario = rd.GetString(4);
                        lista.CodigoTipoProceso = rd.GetInt32(5);
                        lista.Juzgado = rd.GetString(6);
                        lista.CodigoCautelar = rd.GetString(7);
                        lista.NumJuzgado = objetoExpediente.NumJuzgado;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
            // CARGAR PROCESO FECHAS
        public C_Fechas FechasMostrar1(string codigo)
        {
            C_Fechas lista = new C_Fechas();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select fecha_mandato,fecha_contradiccion,fecha_orden,fecha_rematecaptura,fecha_adjucaptura, fecha_demanda, fecha_auto_final, fecha_apelacion from fechas where num_expediente = '" + codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.FechaMando = rd.GetDateTime(0);
                        lista.FechaContradiccion = rd.GetDateTime(1);
                        lista.FechaOrden = rd.GetDateTime(2);
                        lista.FechaRematecaptura = rd.GetDateTime(3);
                        lista.FechaAdjucaptura = rd.GetDateTime(4);
                        lista.FechaDemanda = rd.GetDateTime(5);
                        lista.FechaAutoFinal = rd.GetDateTime(6);
                        lista.FechaApelacion = rd.GetDateTime(7);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista; 
        }
            // CARGAR Proyeccion
        public C_Proyeccion ProyeccionMostrar1(string codigo)
        {
            C_Proyeccion lista = new C_Proyeccion();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select fecha_estimada,devuelto,motivo_devolucion,telefono from proyeccion where num_expediente = '" + codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.FechaEstimada = rd.GetDateTime(0);
                        lista.Devuelto = rd.GetString(1);
                        lista.MotivoDevolucion = rd.GetString(2);
                        lista.Telefono = rd.GetString(3);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista; 
 
        }
                
        public C_Ubicacion UbicacionMostrar1(string codigo)
        {
            C_Ubicacion lista = new C_Ubicacion();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo, num_expediente, ubicacion, imagen, id_ubicacion from ubicacion where num_expediente = '" + codigo + "';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Codigo = rd.GetInt32(0);
                        lista.NumExpediente = rd.GetString(1);
                        lista.Url = rd.GetString(2);
                        lista.Imagen = (byte[])rd[3];
                        lista.Id_tipoUbicacion = rd.GetInt32(4);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }

        public C_Ubicacion UbicacionMostrar2(string expediente, int id_ubicacion) {

            C_Ubicacion lista = new C_Ubicacion();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select codigo, num_expediente, ubicacion, imagen, id_ubicacion, visita_activa from ubicacion where num_expediente = '" + expediente + "' AND ID_UBICACION ="+ id_ubicacion +" ORDER BY CODIGO ASC LIMIT 1;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lista.Codigo = rd.GetInt32(0);
                        lista.NumExpediente = rd.GetString(1);
                        lista.Url = rd.GetString(2);
                        if(rd[3] != DBNull.Value)
                            lista.Imagen = (byte[])rd[3];
                        lista.Id_tipoUbicacion = rd.GetInt32(4);
                        if(rd[5] !=  DBNull.Value)
                            lista.Visita = rd.GetInt32(5);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }



            //CARGAR CREDITO 

        // ELIMINAR
            //ELIMINAR CREDITO

        public bool CreditoEliminar(int accion, C_Credito objetoCredito)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_ELIMINARCREDITO", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_OPERACION", objetoCredito.Operacion);
               // cmd.Parameters.AddWithValue("_CUENTA_BT", objetoCredito.CuentaBT);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
            //ELIMINAR GARANTE
        public bool GaranteEliminar(int accion, C_Garante objetoGarante)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("spr_elinminargarante", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_CODIGO_GARANTE", objetoGarante.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        public bool LiquidacionEliminar(int accion, C_Liquidaciones objetoLiquidaciones) 
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_ELIMINARLIQUIDACION", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_CODIGO_DETALLE_LIQUIDACION", objetoLiquidaciones.Codigo_Detalle_liquidacion);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
            //ELIMINAR BIEN
        public bool BienEliminar(int accion, C_Bien objetoBien)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_ELIMINARBIEN", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_CODIGO_BIEN", objetoBien.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
 
        }
            //ELIMINAR OTRAS CARGAS
        public bool OtrasCargasEliminar(int accion, C_OtrasCargas objetoOtrasCargas)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_ELIMINAROTRASCARGAS", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_CODIGO", objetoOtrasCargas.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
            //ELIMINAR EXPEDIENTE -  CREDITO EN LA TABLA DETALLE_EXPEDIENTE_CREDITO
        public bool ExpedienteCreditoEliminar(int accion, C_Expediente objetoExpediente)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_ELIMINAREXPEDIENTECREDITO", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_NUM_EXPEDIENTE", objetoExpediente.NumExpediente);
                cmd.Parameters.AddWithValue("_OPERACION", objetoExpediente.Operacion);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }
        // ELIMINAR SEGUIMIENTO PROCESO
        public bool SeguimientoProcesoEliminar(int accion, C_SeguimientoProceso objetoSeguimiento)
        {
            bool res = false;
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SPR_ELIMINARSEGUIMIENTO", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("_ACCION", accion);
                cmd.Parameters.AddWithValue("_CODIGO", objetoSeguimiento.Codigo);
                cmd.Parameters.Add(new NpgsqlParameter(":resultado", NpgsqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                res = (bool)cmd.Parameters[":resultado"].Value;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
            return res;
        }

        /*Reportes */

        public List<C_CambioModelo> ReporteCambioModelo(string codigo)
        {
            List<C_CambioModelo> lista = new List<C_CambioModelo>();
            C_CambioModelo objetoCambioModeo = new C_CambioModelo();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT NOMBRE_COMPLETO,DOI_CLIENTE, CUENTA_BT, OPERACION, NOMBRE_CARTERA, NOMBRE_ESTUDIO, '' as TIPO_SOLUCION,  OBSERVACION_TRAMITE FROM VW_REPORTECAMBIOMODELO WHERE CUENTA_BT = '"+codigo + "' AND CODIGO_TRAMITE = 3 AND FLAG_CREDITO = 1 ;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoCambioModeo.NombreCompleto = " ";
                        }
                        else
                        {
                            objetoCambioModeo.NombreCompleto = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoCambioModeo.DoiCliente = " ";
                        }
                        else
                        {
                            objetoCambioModeo.DoiCliente = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoCambioModeo.CuentaBT = " ";
                        }
                        else
                        {
                            objetoCambioModeo.CuentaBT = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoCambioModeo.Operacion = " ";
                        }
                        else
                        {
                            objetoCambioModeo.Operacion = rd.GetString(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoCambioModeo.NombreCartera = " ";
                        }
                        else
                        {
                            objetoCambioModeo.NombreCartera = rd.GetString(4);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoCambioModeo.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoCambioModeo.NombreEstudio = rd.GetString(5);
                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoCambioModeo.TipoSolucion = " ";
                        }
                        else
                        {
                            objetoCambioModeo.TipoSolucion = rd.GetString(6);
                        }
                        if (rd[7] == DBNull.Value)
                        {
                            objetoCambioModeo.ObservacionTramite = " ";
                        }
                        else
                        {
                            objetoCambioModeo.ObservacionTramite = rd.GetString(7);
                        }

                        lista.Add(new C_CambioModelo
                        {
                            NombreCompleto = objetoCambioModeo.NombreCompleto,
                            DoiCliente = objetoCambioModeo.DoiCliente,
                            CuentaBT = objetoCambioModeo.CuentaBT,
                            Operacion = objetoCambioModeo.Operacion,
                            NombreCartera = objetoCambioModeo.NombreCartera,
                            NombreEstudio = objetoCambioModeo.NombreEstudio,
                            TipoSolucion = objetoCambioModeo.TipoSolucion,
                            ObservacionTramite = objetoCambioModeo.ObservacionTramite
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_CambioModelo> ReporteCambioModeloTodo()
        {
            List<C_CambioModelo> lista = new List<C_CambioModelo>();
            C_CambioModelo objetoCambioModeo = new C_CambioModelo();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT NOMBRE_COMPLETO,DOI_CLIENTE, CUENTA_BT, OPERACION, NOMBRE_CARTERA, NOMBRE_ESTUDIO, '' as TIPO_SOLUCION,  OBSERVACION_TRAMITE FROM VW_REPORTECAMBIOMODELO WHERE  CODIGO_TRAMITE = 3 AND FLAG_CREDITO = 1 ;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoCambioModeo.NombreCompleto = " ";
                        }
                        else
                        {
                            objetoCambioModeo.NombreCompleto = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoCambioModeo.DoiCliente = " ";
                        }
                        else
                        {
                            objetoCambioModeo.DoiCliente = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoCambioModeo.CuentaBT = " ";
                        }
                        else
                        {
                            objetoCambioModeo.CuentaBT = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoCambioModeo.Operacion = " ";
                        }
                        else
                        {
                            objetoCambioModeo.Operacion = rd.GetString(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoCambioModeo.NombreCartera = " ";
                        }
                        else
                        {
                            objetoCambioModeo.NombreCartera = rd.GetString(4);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoCambioModeo.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoCambioModeo.NombreEstudio = rd.GetString(5);
                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoCambioModeo.TipoSolucion = " ";
                        }
                        else
                        {
                            objetoCambioModeo.TipoSolucion = rd.GetString(6);
                        }
                        if (rd[7] == DBNull.Value)
                        {
                            objetoCambioModeo.ObservacionTramite = " ";
                        }
                        else
                        {
                            objetoCambioModeo.ObservacionTramite = rd.GetString(7);
                        }
                        
                        lista.Add(new C_CambioModelo
                        {
                            NombreCompleto = objetoCambioModeo.NombreCompleto,
                            DoiCliente = objetoCambioModeo.DoiCliente,
                            CuentaBT = objetoCambioModeo.CuentaBT,
                            Operacion = objetoCambioModeo.Operacion,
                            NombreCartera = objetoCambioModeo.NombreCartera,
                            NombreEstudio = objetoCambioModeo.NombreEstudio,
                            TipoSolucion = objetoCambioModeo.TipoSolucion,
                            ObservacionTramite = objetoCambioModeo.ObservacionTramite
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }


        
        public List<C_Credito> ReporteCreditoEliminado(string codigo)
        {
            List<C_Credito> lista = new List<C_Credito>();
            C_Credito objetoCredito = new C_Credito();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, FECHA_TRAMITE, NOMBRE_COMPLETO FROM VW_REPORTECREDITOELIMINADO WHERE CUENTA_BT = '" + codigo + "' AND FLAG = 0;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoCredito.CuentaBT = " ";
                        }
                        else
                        {
                            objetoCredito.CuentaBT = rd.GetString(0);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoCredito.NombreCompleto = " ";
                        }
                        else
                        {
                            objetoCredito.NombreCompleto = rd.GetString(1);
                        }
                        lista.Add(new C_Credito
                        {
                            CuentaBT = objetoCredito.CuentaBT,
                            FechaTramite = rd.GetDateTime(1),
                            NombreCompleto = objetoCredito.NombreCompleto
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;

        }
        public List<C_Credito> ReporteCreditoElimnadoTodo()
        {
            List<C_Credito> lista = new List<C_Credito>();
            C_Credito objetoCredito = new C_Credito();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, FECHA_TRAMITE, NOMBRE_COMPLETO FROM VW_REPORTECREDITOELIMINADO WHERE FLAG = 0;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoCredito.CuentaBT = " ";
                        }
                        else
                        {
                            objetoCredito.CuentaBT = rd.GetString(0);
                        }                        
                        if (rd[2] == DBNull.Value)
                        {
                            objetoCredito.NombreCompleto = " ";
                        }
                        else
                        {
                            objetoCredito.NombreCompleto = rd.GetString(2);
                        }
                        lista.Add(new C_Credito
                        {
                            CuentaBT = objetoCredito.CuentaBT,
                            FechaTramite = rd.GetDateTime(1),
                            NombreCompleto = objetoCredito.NombreCompleto
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }

        public List<C_SBPFinal> ReporteSBPepitoTodo()
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, DOI_CLIENTE, NOMBRE_CLIENTE, DEMANDADO, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, NOMBRE_CIUDAD, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE, OPERACION, NOMBRE_MONEDA, MONTO_DEMANDADO, RESUMEN_PROCESO, FECHA_MEDIDA_CAUTELAR, FECHA_DEMANDA, FECHA_MANDATO, FECHA_CONTRADICCION, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA,STRING_AGG(CASE WHEN FECHA_GESTION::TEXT='1990-01-01' THEN ' '::TEXT ELSE  FECHA_GESTION::TEXT END, '/') AS FECHA_LLAMADA, STRING_AGG(TELEFONO_CONTACTO , '/')AS TELEFONO, STRING_AGG(CONTACTO_CLIENTE, '/') AS DETALLE, STRING_AGG(DETALLE_RESULTADO, '/') AS RESULTADO, STRING_AGG(CASE WHEN FECHA_GESTION::TEXT='1990-01-01' THEN ' '::TEXT ELSE  FECHA_GESTION::TEXT END, '/') AS FECHA_CAMPO, STRING_AGG(DETALLE,'/') AS DIRECCION,STRING_AGG(CONTACTO_PARIENTE,'/') AS DETALLE_CAMPO,STRING_AGG(DETALLE_RESULTADO, '/') AS RESULTADO_CAMPO FROM VW_REPORTESBP GROUP BY CUENTA_BT, DOI_CLIENTE, NOMBRE_CLIENTE, DEMANDADO, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, NOMBRE_CIUDAD, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE, OPERACION, NOMBRE_MONEDA, MONTO_DEMANDADO, RESUMEN_PROCESO, FECHA_MEDIDA_CAUTELAR, FECHA_DEMANDA, FECHA_MANDATO, FECHA_CONTRADICCION, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Doi_cliente = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Demandado = " ";
                        }
                        else
                        {
                            objetoSbp.Demandado = rd.GetString(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.NombreCartera = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCartera = rd.GetString(4);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.NombreModelo = " ";
                        }
                        else
                        {
                            objetoSbp.NombreModelo = rd.GetString(5);
                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Sectorista = " ";
                        }
                        else
                        {
                            objetoSbp.Sectorista = rd.GetString(6);
                        }
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreEstudio = rd.GetString(7);
                        }
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.Region = " ";
                        }
                        else
                        {
                            objetoSbp.Region = rd.GetString(8);
                        }
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.NombreCiudad = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCiudad = rd.GetString(9);
                        }
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(10);
                        }
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(11);
                        }
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(12);
                        }
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(13);
                        }
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(14);
                        }
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.MontoDemandado = " ";
                        }
                        else
                        {
                            objetoSbp.MontoDemandado = rd.GetString(15);
                        }
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.ResumenProceso = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenProceso = rd.GetString(16);
                        }
                        //FECHA MC
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.FechaMC = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaMC = rd.GetDateTime(17);
                        }
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else if (rd.GetDateTime(17) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMCString = "" + rd.GetDateTime(17).ToShortDateString();
                        }
                        // FECHA DEMANDA
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.FechaDemanda = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaDemanda = rd.GetDateTime(18);
                        }
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(18) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(18).ToShortDateString();
                        }
                        // FECHA MANDATO
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.FechaMandato = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaMandato = rd.GetDateTime(19);
                        }
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else if (rd.GetDateTime(19) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMandatoString = "" + rd.GetDateTime(19).ToShortDateString();
                        }
                        // FECHA CONTRADICCION
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccion = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaContradiccion = rd.GetDateTime(20);
                        }
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else if (rd.GetDateTime(20) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaContradiccionString = "" + rd.GetDateTime(20).ToShortDateString();
                        }
                        // FECHA ORDEN
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.FechaOrden = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaOrden = rd.GetDateTime(21);
                        }
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else if (rd.GetDateTime(21) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaOrdenString = "" + rd.GetDateTime(21).ToShortDateString();
                        }
                        // FECHA ORDEN CAPTURA
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateCaptura = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaRemateCaptura = rd.GetDateTime(22);
                        }
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else if (rd.GetDateTime(22) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaRemateCapturaString = "" + rd.GetDateTime(22).ToShortDateString();
                        }
                        // FECHA CAPTURA
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucaptura = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaAdjucaptura = rd.GetDateTime(23);
                        }
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else if (rd.GetDateTime(23) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAdjucapturaString = "" + rd.GetDateTime(23).ToShortDateString();
                        }
                        // FECHA LLAMADA
                        /*if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaLlamada = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaLlamada = rd.GetDateTime(24);
                        }*/
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaLlamadaString = " ";
                        }
                        else if (rd.GetString(24) == "01-01-1990")
                        {
                            objetoSbp.FechaLlamadaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaLlamadaString = rd.GetString(24);
                        }
                        //
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.TelefonoLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.TelefonoLlamada = rd.GetString(25);
                        }
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.DetalleLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.DetalleLlamada = rd.GetString(26);
                        }
                        if (rd[27] == DBNull.Value)
                        {
                            objetoSbp.ResumenLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenLlamada = rd.GetString(27);
                        }
                        // FECHA CAMPO
                        /*if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.FechaCampo = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaCampo = rd.GetDateTime(28);
                        }*/
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.FechaCampoString = " ";
                        }
                        else if (rd.GetString(28) == ("01-01-1990"))
                        {
                            objetoSbp.FechaCampoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaCampoString = rd.GetString(28);
                        }
                        //
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.DescripcionCampo = " ";
                        }
                        else
                        {
                            objetoSbp.DescripcionCampo = rd.GetString(29);
                        }
                        if (rd[30] == DBNull.Value)
                        {
                            objetoSbp.DetalleCampo = " ";
                        }
                        else
                        {
                            objetoSbp.DetalleCampo = rd.GetString(30);
                        }
                        if (rd[31] == DBNull.Value)
                        {
                            objetoSbp.ResumenCampo = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenCampo = rd.GetString(31);
                        }
                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Doi_cliente = objetoSbp.Doi_cliente,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            Demandado = objetoSbp.Demandado,
                            NombreCartera = objetoSbp.NombreCartera,
                            NombreModelo = objetoSbp.NombreModelo,
                            Sectorista = objetoSbp.Sectorista,
                            NombreEstudio = objetoSbp.NombreEstudio,
                            Region = objetoSbp.Region,
                            NombreCiudad = objetoSbp.NombreCiudad,
                            NombreProceso = objetoSbp.NombreProceso,
                            Juzgado = objetoSbp.Juzgado,
                            NumExpediente = objetoSbp.NumExpediente,
                            Operacion = objetoSbp.Operacion,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            MontoDemandado = objetoSbp.MontoDemandado,
                            ResumenProceso = objetoSbp.ResumenProceso,
                            FechaMC = objetoSbp.FechaMC,
                            FechaMCString = objetoSbp.FechaMCString,
                            FechaDemanda = objetoSbp.FechaDemanda,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            FechaMandato = objetoSbp.FechaMandato,
                            FechaMandatoString = objetoSbp.FechaMandatoString,
                            FechaContradiccion = objetoSbp.FechaContradiccion,
                            FechaContradiccionString = objetoSbp.FechaContradiccionString,
                            FechaOrden = objetoSbp.FechaOrden,
                            FechaOrdenString = objetoSbp.FechaOrdenString,
                            FechaRemateCaptura = objetoSbp.FechaRemateCaptura,
                            FechaRemateCapturaString = objetoSbp.FechaRemateCapturaString,
                            FechaAdjucaptura = objetoSbp.FechaAdjucaptura,
                            FechaAdjucapturaString = objetoSbp.FechaAdjucapturaString,
                           // FechaLlamada = objetoSbp.FechaLlamada,
                            FechaLlamadaString = objetoSbp.FechaLlamadaString,
                            TelefonoLlamada = objetoSbp.TelefonoLlamada,
                            DetalleLlamada = objetoSbp.DetalleLlamada,
                            ResumenLlamada = objetoSbp.ResumenLlamada,
                           // FechaCampo = objetoSbp.FechaCampo,
                            FechaCampoString = objetoSbp.FechaCampoString,
                            DescripcionCampo = objetoSbp.DescripcionCampo,
                            DetalleCampo = objetoSbp.DetalleCampo,
                            ResumenCampo = objetoSbp.ResumenCampo

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;       
        }
        public List<C_SBPFinal> ReporteSBPepito(string codigo)
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, DOI_CLIENTE, NOMBRE_CLIENTE, DEMANDADO, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, NOMBRE_CIUDAD, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE, OPERACION, NOMBRE_MONEDA, MONTO_DEMANDADO, RESUMEN_PROCESO, FECHA_MEDIDA_CAUTELAR, FECHA_DEMANDA, FECHA_MANDATO, FECHA_CONTRADICCION, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA,STRING_AGG(CASE WHEN FECHA_GESTION::TEXT='1990-01-01' THEN ' '::TEXT ELSE  FECHA_GESTION::TEXT END, '/') AS FECHA_LLAMADA, STRING_AGG(TELEFONO_CONTACTO , '/')AS TELEFONO, STRING_AGG(CONTACTO_CLIENTE, '/') AS DETALLE, STRING_AGG(DETALLE_RESULTADO, '/') AS RESULTADO, STRING_AGG(CASE WHEN FECHA_GESTION::TEXT='1990-01-01' THEN ' '::TEXT ELSE  FECHA_GESTION::TEXT END, '/') AS FECHA_CAMPO, STRING_AGG(DETALLE,'/') AS DIRECCION,STRING_AGG(CONTACTO_PARIENTE,'/') AS DETALLE_CAMPO,STRING_AGG(DETALLE_RESULTADO, '/') AS RESULTADO_CAMPO FROM VW_REPORTESBP WHERE CUENTA_BT = '"+ codigo +"' GROUP BY CUENTA_BT, DOI_CLIENTE, NOMBRE_CLIENTE, DEMANDADO, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, NOMBRE_CIUDAD, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE, OPERACION, NOMBRE_MONEDA, MONTO_DEMANDADO, RESUMEN_PROCESO, FECHA_MEDIDA_CAUTELAR, FECHA_DEMANDA, FECHA_MANDATO, FECHA_CONTRADICCION, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Doi_cliente = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Demandado = " ";
                        }
                        else
                        {
                            objetoSbp.Demandado = rd.GetString(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.NombreCartera = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCartera = rd.GetString(4);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.NombreModelo = " ";
                        }
                        else
                        {
                            objetoSbp.NombreModelo = rd.GetString(5);
                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Sectorista = " ";
                        }
                        else
                        {
                            objetoSbp.Sectorista = rd.GetString(6);
                        }
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreEstudio = rd.GetString(7);
                        }
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.Region = " ";
                        }
                        else
                        {
                            objetoSbp.Region = rd.GetString(8);
                        }
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.NombreCiudad = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCiudad = rd.GetString(9);
                        }
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(10);
                        }
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(11);
                        }
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(12);
                        }
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(13);
                        }
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(14);
                        }
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.MontoDemandado = " ";
                        }
                        else
                        {
                            objetoSbp.MontoDemandado = rd.GetString(15);
                        }
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.ResumenProceso = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenProceso = rd.GetString(16);
                        }
                        //FECHA MC
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.FechaMC = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaMC = rd.GetDateTime(17);
                        }
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else if (rd.GetDateTime(17) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMCString = "" + rd.GetDateTime(17).ToShortDateString();
                        }
                        // FECHA DEMANDA
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.FechaDemanda = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaDemanda = rd.GetDateTime(18);
                        }
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(18) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(18).ToShortDateString();
                        }
                        // FECHA MANDATO
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.FechaMandato = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaMandato = rd.GetDateTime(19);
                        }
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else if (rd.GetDateTime(19) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMandatoString = "" + rd.GetDateTime(19).ToShortDateString();
                        }
                        // FECHA CONTRADICCION
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccion = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaContradiccion = rd.GetDateTime(20);
                        }
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else if (rd.GetDateTime(20) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaContradiccionString = "" + rd.GetDateTime(20).ToShortDateString();
                        }
                        // FECHA ORDEN
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.FechaOrden = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaOrden = rd.GetDateTime(21);
                        }
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else if (rd.GetDateTime(21) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaOrdenString = "" + rd.GetDateTime(21).ToShortDateString();
                        }
                        // FECHA ORDEN CAPTURA
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateCaptura = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaRemateCaptura = rd.GetDateTime(22);
                        }
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else if (rd.GetDateTime(22) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaRemateCapturaString = "" + rd.GetDateTime(22).ToShortDateString();
                        }
                        // FECHA CAPTURA
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucaptura = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaAdjucaptura = rd.GetDateTime(23);
                        }
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else if (rd.GetDateTime(23) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAdjucapturaString = "" + rd.GetDateTime(23).ToShortDateString();
                        }
                        // FECHA LLAMADA
                        /*if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaLlamada = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaLlamada = rd.GetDateTime(24);
                        }*/
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaLlamadaString = " ";
                        }
                        else if (rd.GetString(24) == "01-01-1990")
                        {
                            objetoSbp.FechaLlamadaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaLlamadaString = rd.GetString(24);
                        }
                        //
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.TelefonoLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.TelefonoLlamada = rd.GetString(25);
                        }
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.DetalleLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.DetalleLlamada = rd.GetString(26);
                        }
                        if (rd[27] == DBNull.Value)
                        {
                            objetoSbp.ResumenLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenLlamada = rd.GetString(27);
                        }
                        // FECHA CAMPO
                        /*if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.FechaCampo = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaCampo = rd.GetDateTime(28);
                        }*/
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.FechaCampoString = " ";
                        }
                        else if (rd.GetString(28) == ("01-01-1990"))
                        {
                            objetoSbp.FechaCampoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaCampoString = rd.GetString(28);
                        }
                        //
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.DescripcionCampo = " ";
                        }
                        else
                        {
                            objetoSbp.DescripcionCampo = rd.GetString(29);
                        }
                        if (rd[30] == DBNull.Value)
                        {
                            objetoSbp.DetalleCampo = " ";
                        }
                        else
                        {
                            objetoSbp.DetalleCampo = rd.GetString(30);
                        }
                        if (rd[31] == DBNull.Value)
                        {
                            objetoSbp.ResumenCampo = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenCampo = rd.GetString(31);
                        }
                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Doi_cliente = objetoSbp.Doi_cliente,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            Demandado = objetoSbp.Demandado,
                            NombreCartera = objetoSbp.NombreCartera,
                            NombreModelo = objetoSbp.NombreModelo,
                            Sectorista = objetoSbp.Sectorista,
                            NombreEstudio = objetoSbp.NombreEstudio,
                            Region = objetoSbp.Region,
                            NombreCiudad = objetoSbp.NombreCiudad,
                            NombreProceso = objetoSbp.NombreProceso,
                            Juzgado = objetoSbp.Juzgado,
                            NumExpediente = objetoSbp.NumExpediente,
                            Operacion = objetoSbp.Operacion,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            MontoDemandado = objetoSbp.MontoDemandado,
                            ResumenProceso = objetoSbp.ResumenProceso,
                            FechaMC = objetoSbp.FechaMC,
                            FechaMCString = objetoSbp.FechaMCString,
                            FechaDemanda = objetoSbp.FechaDemanda,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            FechaMandato = objetoSbp.FechaMandato,
                            FechaMandatoString = objetoSbp.FechaMandatoString,
                            FechaContradiccion = objetoSbp.FechaContradiccion,
                            FechaContradiccionString = objetoSbp.FechaContradiccionString,
                            FechaOrden = objetoSbp.FechaOrden,
                            FechaOrdenString = objetoSbp.FechaOrdenString,
                            FechaRemateCaptura = objetoSbp.FechaRemateCaptura,
                            FechaRemateCapturaString = objetoSbp.FechaRemateCapturaString,
                            FechaAdjucaptura = objetoSbp.FechaAdjucaptura,
                            FechaAdjucapturaString = objetoSbp.FechaAdjucapturaString,
                            // FechaLlamada = objetoSbp.FechaLlamada,
                            FechaLlamadaString = objetoSbp.FechaLlamadaString,
                            TelefonoLlamada = objetoSbp.TelefonoLlamada,
                            DetalleLlamada = objetoSbp.DetalleLlamada,
                            ResumenLlamada = objetoSbp.ResumenLlamada,
                            // FechaCampo = objetoSbp.FechaCampo,
                            FechaCampoString = objetoSbp.FechaCampoString,
                            DescripcionCampo = objetoSbp.DescripcionCampo,
                            DetalleCampo = objetoSbp.DetalleCampo,
                            ResumenCampo = objetoSbp.ResumenCampo

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_SBPFinal> ReporteSBPFechas(DateTime fecha1, DateTime fecha2)
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, DOI_CLIENTE, NOMBRE_CLIENTE, DEMANDADO, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, NOMBRE_CIUDAD, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE, OPERACION, NOMBRE_MONEDA, MONTO_DEMANDADO, RESUMEN_PROCESO, FECHA_MEDIDA_CAUTELAR, FECHA_DEMANDA, FECHA_MANDATO, FECHA_CONTRADICCION, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA,STRING_AGG(CASE WHEN FECHA_VISITA_ESTUDIO::TEXT='1990-01-01' THEN ' '::TEXT ELSE  FECHA_VISITA_ESTUDIO::TEXT END, '/') AS FECHA_LLAMADA, STRING_AGG(TELEFONO_CONTACTO , '/')AS TELEFONO, STRING_AGG(CONTACTO_CLIENTE, '/') AS DETALLE, STRING_AGG(DETALLE_RESULTADO, '/') AS RESULTADO, STRING_AGG(CASE WHEN FECHA_GESTION::TEXT='1990-01-01' THEN ' '::TEXT ELSE  FECHA_GESTION::TEXT END, '/') AS FECHA_CAMPO, STRING_AGG(DETALLE,'/') AS DIRECCION,STRING_AGG(CONTACTO_PARIENTE,'/') AS DETALLE_CAMPO,STRING_AGG(DETALLE_RESULTADO, '/') AS RESULTADO_CAMPO FROM VW_REPORTESBP WHERE FECHA_VISITA_ESTUDIO BETWEEN  '" + fecha1.ToShortDateString()+"' AND '" +fecha2.ToShortDateString() +"' AND FECHA_GESTION BETWEEN '" + fecha1.ToShortDateString()+"' AND '" +fecha2.ToShortDateString() +"'  GROUP BY CUENTA_BT, DOI_CLIENTE, NOMBRE_CLIENTE, DEMANDADO, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, NOMBRE_CIUDAD, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE, OPERACION, NOMBRE_MONEDA, MONTO_DEMANDADO, RESUMEN_PROCESO, FECHA_MEDIDA_CAUTELAR, FECHA_DEMANDA, FECHA_MANDATO, FECHA_CONTRADICCION, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Doi_cliente = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Demandado = " ";
                        }
                        else
                        {
                            objetoSbp.Demandado = rd.GetString(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.NombreCartera = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCartera = rd.GetString(4);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.NombreModelo = " ";
                        }
                        else
                        {
                            objetoSbp.NombreModelo = rd.GetString(5);
                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Sectorista = " ";
                        }
                        else
                        {
                            objetoSbp.Sectorista = rd.GetString(6);
                        }
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreEstudio = rd.GetString(7);
                        }
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.Region = " ";
                        }
                        else
                        {
                            objetoSbp.Region = rd.GetString(8);
                        }
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.NombreCiudad = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCiudad = rd.GetString(9);
                        }
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(10);
                        }
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(11);
                        }
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(12);
                        }
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(13);
                        }
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(14);
                        }
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.MontoDemandado = " ";
                        }
                        else
                        {
                            objetoSbp.MontoDemandado = rd.GetString(15);
                        }
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.ResumenProceso = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenProceso = rd.GetString(16);
                        }
                        //FECHA MC
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.FechaMC = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaMC = rd.GetDateTime(17);
                        }
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else if (rd.GetDateTime(17) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMCString = "" + rd.GetDateTime(17).ToShortDateString();
                        }
                        // FECHA DEMANDA
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.FechaDemanda = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaDemanda = rd.GetDateTime(18);
                        }
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(18) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(18).ToShortDateString();
                        }
                        // FECHA MANDATO
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.FechaMandato = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaMandato = rd.GetDateTime(19);
                        }
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else if (rd.GetDateTime(19) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMandatoString = "" + rd.GetDateTime(19).ToShortDateString();
                        }
                        // FECHA CONTRADICCION
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccion = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaContradiccion = rd.GetDateTime(20);
                        }
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else if (rd.GetDateTime(20) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaContradiccionString = "" + rd.GetDateTime(20).ToShortDateString();
                        }
                        // FECHA ORDEN
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.FechaOrden = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaOrden = rd.GetDateTime(21);
                        }
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else if (rd.GetDateTime(21) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaOrdenString = "" + rd.GetDateTime(21).ToShortDateString();
                        }
                        // FECHA ORDEN CAPTURA
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateCaptura = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaRemateCaptura = rd.GetDateTime(22);
                        }
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else if (rd.GetDateTime(22) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaRemateCapturaString = "" + rd.GetDateTime(22).ToShortDateString();
                        }
                        // FECHA CAPTURA
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucaptura = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaAdjucaptura = rd.GetDateTime(23);
                        }
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else if (rd.GetDateTime(23) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAdjucapturaString = "" + rd.GetDateTime(23).ToShortDateString();
                        }
                        // FECHA LLAMADA
                        /*if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaLlamada = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaLlamada = rd.GetDateTime(24);
                        }*/
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaLlamadaString = " ";
                        }
                        else if (rd.GetString(24) == "01-01-1990")
                        {
                            objetoSbp.FechaLlamadaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaLlamadaString = rd.GetString(24);
                        }
                        //
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.TelefonoLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.TelefonoLlamada = rd.GetString(25);
                        }
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.DetalleLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.DetalleLlamada = rd.GetString(26);
                        }
                        if (rd[27] == DBNull.Value)
                        {
                            objetoSbp.ResumenLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenLlamada = rd.GetString(27);
                        }
                        // FECHA CAMPO
                        /*if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.FechaCampo = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaCampo = rd.GetDateTime(28);
                        }*/
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.FechaCampoString = " ";
                        }
                        else if (rd.GetString(28) == ("01-01-1990"))
                        {
                            objetoSbp.FechaCampoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaCampoString = rd.GetString(28);
                        }
                        //
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.DescripcionCampo = " ";
                        }
                        else
                        {
                            objetoSbp.DescripcionCampo = rd.GetString(29);
                        }
                        if (rd[30] == DBNull.Value)
                        {
                            objetoSbp.DetalleCampo = " ";
                        }
                        else
                        {
                            objetoSbp.DetalleCampo = rd.GetString(30);
                        }
                        if (rd[31] == DBNull.Value)
                        {
                            objetoSbp.ResumenCampo = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenCampo = rd.GetString(31);
                        }
                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Doi_cliente = objetoSbp.Doi_cliente,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            Demandado = objetoSbp.Demandado,
                            NombreCartera = objetoSbp.NombreCartera,
                            NombreModelo = objetoSbp.NombreModelo,
                            Sectorista = objetoSbp.Sectorista,
                            NombreEstudio = objetoSbp.NombreEstudio,
                            Region = objetoSbp.Region,
                            NombreCiudad = objetoSbp.NombreCiudad,
                            NombreProceso = objetoSbp.NombreProceso,
                            Juzgado = objetoSbp.Juzgado,
                            NumExpediente = objetoSbp.NumExpediente,
                            Operacion = objetoSbp.Operacion,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            MontoDemandado = objetoSbp.MontoDemandado,
                            ResumenProceso = objetoSbp.ResumenProceso,
                            FechaMC = objetoSbp.FechaMC,
                            FechaMCString = objetoSbp.FechaMCString,
                            FechaDemanda = objetoSbp.FechaDemanda,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            FechaMandato = objetoSbp.FechaMandato,
                            FechaMandatoString = objetoSbp.FechaMandatoString,
                            FechaContradiccion = objetoSbp.FechaContradiccion,
                            FechaContradiccionString = objetoSbp.FechaContradiccionString,
                            FechaOrden = objetoSbp.FechaOrden,
                            FechaOrdenString = objetoSbp.FechaOrdenString,
                            FechaRemateCaptura = objetoSbp.FechaRemateCaptura,
                            FechaRemateCapturaString = objetoSbp.FechaRemateCapturaString,
                            FechaAdjucaptura = objetoSbp.FechaAdjucaptura,
                            FechaAdjucapturaString = objetoSbp.FechaAdjucapturaString,
                            // FechaLlamada = objetoSbp.FechaLlamada,
                            FechaLlamadaString = objetoSbp.FechaLlamadaString,
                            TelefonoLlamada = objetoSbp.TelefonoLlamada,
                            DetalleLlamada = objetoSbp.DetalleLlamada,
                            ResumenLlamada = objetoSbp.ResumenLlamada,
                            // FechaCampo = objetoSbp.FechaCampo,
                            FechaCampoString = objetoSbp.FechaCampoString,
                            DescripcionCampo = objetoSbp.DescripcionCampo,
                            DetalleCampo = objetoSbp.DetalleCampo,
                            ResumenCampo = objetoSbp.ResumenCampo

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_SBPFinal> ReporteSBPFechasCampo(DateTime fecha1, DateTime fecha2)
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, DOI_CLIENTE, NOMBRE_CLIENTE, DEMANDADO, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, NOMBRE_CIUDAD, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE, OPERACION, NOMBRE_MONEDA, MONTO_DEMANDADO, RESUMEN_PROCESO, FECHA_MEDIDA_CAUTELAR, FECHA_DEMANDA, FECHA_MANDATO, FECHA_CONTRADICCION, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA,STRING_AGG(CASE WHEN FECHA_VISITA_ESTUDIO::TEXT='1990-01-01' THEN ' '::TEXT ELSE  FECHA_VISITA_ESTUDIO::TEXT END, '/') AS FECHA_LLAMADA, STRING_AGG(TELEFONO_CONTACTO , '/')AS TELEFONO, STRING_AGG(CONTACTO_CLIENTE, '/') AS DETALLE, STRING_AGG(DETALLE_RESULTADO, '/') AS RESULTADO, STRING_AGG(CASE WHEN FECHA_GESTION::TEXT='1990-01-01' THEN ' '::TEXT ELSE  FECHA_GESTION::TEXT END, '/') AS FECHA_CAMPO, STRING_AGG(DETALLE,'/') AS DIRECCION,STRING_AGG(CONTACTO_PARIENTE,'/') AS DETALLE_CAMPO,STRING_AGG(DETALLE_RESULTADO, '/') AS RESULTADO_CAMPO FROM VW_REPORTESBP WHERE FECHA_GESTION BETWEEN '" + fecha1.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "'  GROUP BY CUENTA_BT, DOI_CLIENTE, NOMBRE_CLIENTE, DEMANDADO, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, NOMBRE_CIUDAD, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE, OPERACION, NOMBRE_MONEDA, MONTO_DEMANDADO, RESUMEN_PROCESO, FECHA_MEDIDA_CAUTELAR, FECHA_DEMANDA, FECHA_MANDATO, FECHA_CONTRADICCION, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Doi_cliente = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Demandado = " ";
                        }
                        else
                        {
                            objetoSbp.Demandado = rd.GetString(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.NombreCartera = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCartera = rd.GetString(4);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.NombreModelo = " ";
                        }
                        else
                        {
                            objetoSbp.NombreModelo = rd.GetString(5);
                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Sectorista = " ";
                        }
                        else
                        {
                            objetoSbp.Sectorista = rd.GetString(6);
                        }
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreEstudio = rd.GetString(7);
                        }
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.Region = " ";
                        }
                        else
                        {
                            objetoSbp.Region = rd.GetString(8);
                        }
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.NombreCiudad = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCiudad = rd.GetString(9);
                        }
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(10);
                        }
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(11);
                        }
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(12);
                        }
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(13);
                        }
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(14);
                        }
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.MontoDemandado = " ";
                        }
                        else
                        {
                            objetoSbp.MontoDemandado = rd.GetString(15);
                        }
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.ResumenProceso = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenProceso = rd.GetString(16);
                        }
                        //FECHA MC
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.FechaMC = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaMC = rd.GetDateTime(17);
                        }
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else if (rd.GetDateTime(17) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMCString = "" + rd.GetDateTime(17).ToShortDateString();
                        }
                        // FECHA DEMANDA
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.FechaDemanda = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaDemanda = rd.GetDateTime(18);
                        }
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(18) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(18).ToShortDateString();
                        }
                        // FECHA MANDATO
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.FechaMandato = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaMandato = rd.GetDateTime(19);
                        }
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else if (rd.GetDateTime(19) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMandatoString = "" + rd.GetDateTime(19).ToShortDateString();
                        }
                        // FECHA CONTRADICCION
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccion = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaContradiccion = rd.GetDateTime(20);
                        }
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else if (rd.GetDateTime(20) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaContradiccionString = "" + rd.GetDateTime(20).ToShortDateString();
                        }
                        // FECHA ORDEN
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.FechaOrden = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaOrden = rd.GetDateTime(21);
                        }
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else if (rd.GetDateTime(21) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaOrdenString = "" + rd.GetDateTime(21).ToShortDateString();
                        }
                        // FECHA ORDEN CAPTURA
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateCaptura = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaRemateCaptura = rd.GetDateTime(22);
                        }
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else if (rd.GetDateTime(22) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaRemateCapturaString = "" + rd.GetDateTime(22).ToShortDateString();
                        }
                        // FECHA CAPTURA
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucaptura = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaAdjucaptura = rd.GetDateTime(23);
                        }
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else if (rd.GetDateTime(23) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAdjucapturaString = "" + rd.GetDateTime(23).ToShortDateString();
                        }
                        // FECHA LLAMADA
                        /*if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaLlamada = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaLlamada = rd.GetDateTime(24);
                        }*/
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaLlamadaString = " ";
                        }
                        else if (rd.GetString(24) == "01-01-1990")
                        {
                            objetoSbp.FechaLlamadaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaLlamadaString = rd.GetString(24);
                        }
                        //
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.TelefonoLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.TelefonoLlamada = rd.GetString(25);
                        }
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.DetalleLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.DetalleLlamada = rd.GetString(26);
                        }
                        if (rd[27] == DBNull.Value)
                        {
                            objetoSbp.ResumenLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenLlamada = rd.GetString(27);
                        }
                        // FECHA CAMPO
                        /*if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.FechaCampo = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaCampo = rd.GetDateTime(28);
                        }*/
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.FechaCampoString = " ";
                        }
                        else if (rd.GetString(28) == ("01-01-1990"))
                        {
                            objetoSbp.FechaCampoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaCampoString = rd.GetString(28);
                        }
                        //
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.DescripcionCampo = " ";
                        }
                        else
                        {
                            objetoSbp.DescripcionCampo = rd.GetString(29);
                        }
                        if (rd[30] == DBNull.Value)
                        {
                            objetoSbp.DetalleCampo = " ";
                        }
                        else
                        {
                            objetoSbp.DetalleCampo = rd.GetString(30);
                        }
                        if (rd[31] == DBNull.Value)
                        {
                            objetoSbp.ResumenCampo = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenCampo = rd.GetString(31);
                        }
                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Doi_cliente = objetoSbp.Doi_cliente,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            Demandado = objetoSbp.Demandado,
                            NombreCartera = objetoSbp.NombreCartera,
                            NombreModelo = objetoSbp.NombreModelo,
                            Sectorista = objetoSbp.Sectorista,
                            NombreEstudio = objetoSbp.NombreEstudio,
                            Region = objetoSbp.Region,
                            NombreCiudad = objetoSbp.NombreCiudad,
                            NombreProceso = objetoSbp.NombreProceso,
                            Juzgado = objetoSbp.Juzgado,
                            NumExpediente = objetoSbp.NumExpediente,
                            Operacion = objetoSbp.Operacion,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            MontoDemandado = objetoSbp.MontoDemandado,
                            ResumenProceso = objetoSbp.ResumenProceso,
                            FechaMC = objetoSbp.FechaMC,
                            FechaMCString = objetoSbp.FechaMCString,
                            FechaDemanda = objetoSbp.FechaDemanda,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            FechaMandato = objetoSbp.FechaMandato,
                            FechaMandatoString = objetoSbp.FechaMandatoString,
                            FechaContradiccion = objetoSbp.FechaContradiccion,
                            FechaContradiccionString = objetoSbp.FechaContradiccionString,
                            FechaOrden = objetoSbp.FechaOrden,
                            FechaOrdenString = objetoSbp.FechaOrdenString,
                            FechaRemateCaptura = objetoSbp.FechaRemateCaptura,
                            FechaRemateCapturaString = objetoSbp.FechaRemateCapturaString,
                            FechaAdjucaptura = objetoSbp.FechaAdjucaptura,
                            FechaAdjucapturaString = objetoSbp.FechaAdjucapturaString,
                            // FechaLlamada = objetoSbp.FechaLlamada,
                            FechaLlamadaString = objetoSbp.FechaLlamadaString,
                            TelefonoLlamada = objetoSbp.TelefonoLlamada,
                            DetalleLlamada = objetoSbp.DetalleLlamada,
                            ResumenLlamada = objetoSbp.ResumenLlamada,
                            // FechaCampo = objetoSbp.FechaCampo,
                            FechaCampoString = objetoSbp.FechaCampoString,
                            DescripcionCampo = objetoSbp.DescripcionCampo,
                            DetalleCampo = objetoSbp.DetalleCampo,
                            ResumenCampo = objetoSbp.ResumenCampo

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_SBPFinal> ReporteSBPFechasLlamada(DateTime fecha1, DateTime fecha2)
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, DOI_CLIENTE, NOMBRE_CLIENTE, DEMANDADO, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, NOMBRE_CIUDAD, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE, OPERACION, NOMBRE_MONEDA, MONTO_DEMANDADO, RESUMEN_PROCESO, FECHA_MEDIDA_CAUTELAR, FECHA_DEMANDA, FECHA_MANDATO, FECHA_CONTRADICCION, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA,STRING_AGG(CASE WHEN FECHA_VISITA_ESTUDIO::TEXT='1990-01-01' THEN ' '::TEXT ELSE  FECHA_VISITA_ESTUDIO::TEXT END, '/') AS FECHA_LLAMADA, STRING_AGG(TELEFONO_CONTACTO , '/')AS TELEFONO, STRING_AGG(CONTACTO_CLIENTE, '/') AS DETALLE, STRING_AGG(DETALLE_RESULTADO, '/') AS RESULTADO, STRING_AGG(CASE WHEN FECHA_GESTION::TEXT='1990-01-01' THEN ' '::TEXT ELSE  FECHA_GESTION::TEXT END, '/') AS FECHA_CAMPO, STRING_AGG(DETALLE,'/') AS DIRECCION,STRING_AGG(CONTACTO_PARIENTE,'/') AS DETALLE_CAMPO,STRING_AGG(DETALLE_RESULTADO, '/') AS RESULTADO_CAMPO FROM VW_REPORTESBP WHERE FECHA_VISITA_ESTUDIO BETWEEN  '" + fecha1.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "' GROUP BY CUENTA_BT, DOI_CLIENTE, NOMBRE_CLIENTE, DEMANDADO, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, NOMBRE_CIUDAD, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE, OPERACION, NOMBRE_MONEDA, MONTO_DEMANDADO, RESUMEN_PROCESO, FECHA_MEDIDA_CAUTELAR, FECHA_DEMANDA, FECHA_MANDATO, FECHA_CONTRADICCION, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Doi_cliente = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Demandado = " ";
                        }
                        else
                        {
                            objetoSbp.Demandado = rd.GetString(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.NombreCartera = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCartera = rd.GetString(4);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.NombreModelo = " ";
                        }
                        else
                        {
                            objetoSbp.NombreModelo = rd.GetString(5);
                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Sectorista = " ";
                        }
                        else
                        {
                            objetoSbp.Sectorista = rd.GetString(6);
                        }
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreEstudio = rd.GetString(7);
                        }
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.Region = " ";
                        }
                        else
                        {
                            objetoSbp.Region = rd.GetString(8);
                        }
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.NombreCiudad = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCiudad = rd.GetString(9);
                        }
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(10);
                        }
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(11);
                        }
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(12);
                        }
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(13);
                        }
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(14);
                        }
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.MontoDemandado = " ";
                        }
                        else
                        {
                            objetoSbp.MontoDemandado = rd.GetString(15);
                        }
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.ResumenProceso = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenProceso = rd.GetString(16);
                        }
                        //FECHA MC
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.FechaMC = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaMC = rd.GetDateTime(17);
                        }
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else if (rd.GetDateTime(17) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMCString = "" + rd.GetDateTime(17).ToShortDateString();
                        }
                        // FECHA DEMANDA
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.FechaDemanda = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaDemanda = rd.GetDateTime(18);
                        }
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(18) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(18).ToShortDateString();
                        }
                        // FECHA MANDATO
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.FechaMandato = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaMandato = rd.GetDateTime(19);
                        }
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else if (rd.GetDateTime(19) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMandatoString = "" + rd.GetDateTime(19).ToShortDateString();
                        }
                        // FECHA CONTRADICCION
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccion = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaContradiccion = rd.GetDateTime(20);
                        }
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else if (rd.GetDateTime(20) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaContradiccionString = "" + rd.GetDateTime(20).ToShortDateString();
                        }
                        // FECHA ORDEN
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.FechaOrden = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaOrden = rd.GetDateTime(21);
                        }
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else if (rd.GetDateTime(21) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaOrdenString = "" + rd.GetDateTime(21).ToShortDateString();
                        }
                        // FECHA ORDEN CAPTURA
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateCaptura = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaRemateCaptura = rd.GetDateTime(22);
                        }
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else if (rd.GetDateTime(22) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaRemateCapturaString = "" + rd.GetDateTime(22).ToShortDateString();
                        }
                        // FECHA CAPTURA
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucaptura = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaAdjucaptura = rd.GetDateTime(23);
                        }
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else if (rd.GetDateTime(23) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAdjucapturaString = "" + rd.GetDateTime(23).ToShortDateString();
                        }
                        // FECHA LLAMADA
                        /*if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaLlamada = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaLlamada = rd.GetDateTime(24);
                        }*/
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaLlamadaString = " ";
                        }
                        else if (rd.GetString(24) == "01-01-1990")
                        {
                            objetoSbp.FechaLlamadaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaLlamadaString = rd.GetString(24);
                        }
                        //
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.TelefonoLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.TelefonoLlamada = rd.GetString(25);
                        }
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.DetalleLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.DetalleLlamada = rd.GetString(26);
                        }
                        if (rd[27] == DBNull.Value)
                        {
                            objetoSbp.ResumenLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenLlamada = rd.GetString(27);
                        }
                        // FECHA CAMPO
                        /*if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.FechaCampo = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaCampo = rd.GetDateTime(28);
                        }*/
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.FechaCampoString = " ";
                        }
                        else if (rd.GetString(28) == ("01-01-1990"))
                        {
                            objetoSbp.FechaCampoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaCampoString = rd.GetString(28);
                        }
                        //
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.DescripcionCampo = " ";
                        }
                        else
                        {
                            objetoSbp.DescripcionCampo = rd.GetString(29);
                        }
                        if (rd[30] == DBNull.Value)
                        {
                            objetoSbp.DetalleCampo = " ";
                        }
                        else
                        {
                            objetoSbp.DetalleCampo = rd.GetString(30);
                        }
                        if (rd[31] == DBNull.Value)
                        {
                            objetoSbp.ResumenCampo = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenCampo = rd.GetString(31);
                        }
                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Doi_cliente = objetoSbp.Doi_cliente,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            Demandado = objetoSbp.Demandado,
                            NombreCartera = objetoSbp.NombreCartera,
                            NombreModelo = objetoSbp.NombreModelo,
                            Sectorista = objetoSbp.Sectorista,
                            NombreEstudio = objetoSbp.NombreEstudio,
                            Region = objetoSbp.Region,
                            NombreCiudad = objetoSbp.NombreCiudad,
                            NombreProceso = objetoSbp.NombreProceso,
                            Juzgado = objetoSbp.Juzgado,
                            NumExpediente = objetoSbp.NumExpediente,
                            Operacion = objetoSbp.Operacion,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            MontoDemandado = objetoSbp.MontoDemandado,
                            ResumenProceso = objetoSbp.ResumenProceso,
                            FechaMC = objetoSbp.FechaMC,
                            FechaMCString = objetoSbp.FechaMCString,
                            FechaDemanda = objetoSbp.FechaDemanda,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            FechaMandato = objetoSbp.FechaMandato,
                            FechaMandatoString = objetoSbp.FechaMandatoString,
                            FechaContradiccion = objetoSbp.FechaContradiccion,
                            FechaContradiccionString = objetoSbp.FechaContradiccionString,
                            FechaOrden = objetoSbp.FechaOrden,
                            FechaOrdenString = objetoSbp.FechaOrdenString,
                            FechaRemateCaptura = objetoSbp.FechaRemateCaptura,
                            FechaRemateCapturaString = objetoSbp.FechaRemateCapturaString,
                            FechaAdjucaptura = objetoSbp.FechaAdjucaptura,
                            FechaAdjucapturaString = objetoSbp.FechaAdjucapturaString,
                            // FechaLlamada = objetoSbp.FechaLlamada,
                            FechaLlamadaString = objetoSbp.FechaLlamadaString,
                            TelefonoLlamada = objetoSbp.TelefonoLlamada,
                            DetalleLlamada = objetoSbp.DetalleLlamada,
                            ResumenLlamada = objetoSbp.ResumenLlamada,
                            // FechaCampo = objetoSbp.FechaCampo,
                            FechaCampoString = objetoSbp.FechaCampoString,
                            DescripcionCampo = objetoSbp.DescripcionCampo,
                            DetalleCampo = objetoSbp.DetalleCampo,
                            ResumenCampo = objetoSbp.ResumenCampo

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }

        //ULTIMOS REPORTES
        public List<C_SBPFinal> ReporteSCIModeloA()
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, DOI_CLIENTE, NOMBRE_COMPLETO, NOMBRE_GARANTE, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, AGENCIA, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE,OPERACION, NOMBRE_MONEDA, MONTO_ADMITIDO, TEXTO_PROCESO, DESCRIPCION_BIEN, NOMBRE_DISTRITO, NOMBRE_CIUDAD, NOMBRE_MONEDA_BIEN, MONTO_GARANTIA_EMBARGO, VALORCOMERCIAL,MONTOTASACION,FECHA_MEDIDA_CAUTELAR, FECHA_DEMANDA, FECHA_MANDATO, FECHA_CONTRADICCION_APELACION, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA, ESTADO_PROCESAL, FECHA_eSTADO_PROCESAL, TAREA_JUDICIAL FROM VW_SCI_MODELO_A WHERE CODIGO_CARTERA != 1 AND CODIGO_CARTERA !=17 AND CODIGO_MODELO = 1 AND CODIGO_TRAMITE = 4 AND CODIGO_ESTUDIO = 1", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        //
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Doi_cliente = rd.GetString(1);
                        }
                        //
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(2);
                        }
                        //
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Demandado = " ";
                        }
                        else
                        {
                            objetoSbp.Demandado = rd.GetString(3);
                        }
                        //
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.NombreCartera = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCartera = rd.GetString(4);
                        }
                        //
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.NombreModelo = " ";
                        }
                        else
                        {
                            objetoSbp.NombreModelo = rd.GetString(5);
                        }
                        //
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Sectorista = " ";
                        }
                        else
                        {
                            objetoSbp.Sectorista = rd.GetString(6);
                        }
                        //
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreEstudio = rd.GetString(7);
                        }
                        //
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.Region = " ";
                        }
                        else
                        {
                            objetoSbp.Region = rd.GetString(8);
                        }
                        //AGENCIA
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.Agencia= " ";
                        }
                        else
                        {
                            objetoSbp.Agencia = rd.GetString(9);
                        }
                        //
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(10);
                        }
                        //
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(11);
                        }
                        //
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(12);
                        }
                        //
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(13);
                        }
                        //
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(14);
                        }
                        //
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.MontoAdmitido = " ";
                        }
                        else
                        {
                            objetoSbp.MontoAdmitido = rd.GetString(15);
                        }
                        //
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.ResumenProceso = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenProceso = rd.GetString(16);
                        }
                        //DESCRIPCION BIEN
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.DescripcionBien = " ";
                        }
                        else
                        {
                            objetoSbp.DescripcionBien = rd.GetString(17);
                        }
                        //NOMBRE DISTRITO BIEN
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.NombreDistrito = " ";
                        }
                        else
                        {
                            objetoSbp.NombreDistrito = rd.GetString(18);
                        }
                        //NOMBRE CIUDAD BIEN
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.NombreCiudad = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCiudad = rd.GetString(19);
                        }
                        //NOMBRE MONEDA BIEN
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.NombreMonedaBien = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMonedaBien = rd.GetString(20);
                        }
                        //MONTO GARANTIA
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.MontoGarantia = " ";
                        }
                        else
                        {
                            objetoSbp.MontoGarantia = rd.GetString(21);
                        }
                        //VALOR COMERCIAL
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.ValorComercial = " ";
                        }
                        else
                        {
                            objetoSbp.ValorComercial = rd.GetString(22);
                        }
                        //MONTO TASACION
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.MontoTasacion = " ";
                        }
                        else
                        {
                            objetoSbp.MontoTasacion = rd.GetString(23);
                        }
                        //

                        //
                        //FECHA MC
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaMC = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaMC = rd.GetDateTime(24);
                        }
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else if (rd.GetDateTime(24) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMCString = "" + rd.GetDateTime(24).ToShortDateString();
                        }
                        // FECHA DEMANDA
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.FechaDemanda = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaDemanda = rd.GetDateTime(25);
                        }
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(25) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(25).ToShortDateString();
                        }
                        // FECHA MANDATO
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.FechaMandato = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaMandato = rd.GetDateTime(26);
                        }
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else if (rd.GetDateTime(26) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMandatoString = "" + rd.GetDateTime(26).ToShortDateString();
                        }
                        // FECHA CONTRADICCION
                        if (rd[27] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccionApelacion = " ";
                        }
                        else
                        {
                            objetoSbp.FechaContradiccionApelacion = rd.GetString(27);
                        }
                        // FECHA ORDEN
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.FechaOrden = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaOrden = rd.GetDateTime(28);
                        }
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else if (rd.GetDateTime(28) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaOrdenString = "" + rd.GetDateTime(28).ToShortDateString();
                        }
                        // FECHA ORDEN CAPTURA
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateCaptura = DateTime.Parse("01-01-1990");
                        }
                        else 
                        {
                            objetoSbp.FechaRemateCaptura = rd.GetDateTime(29);

                        }
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else if (rd.GetDateTime(29) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaRemateCapturaString = " " + rd.GetDateTime(29).ToShortDateString();
                        }
                        // FECHA CAPTURA
                        if (rd[30] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucaptura = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaAdjucaptura = rd.GetDateTime(30);
                        }
                        if (rd[30] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else if (rd.GetDateTime(30) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAdjucapturaString = "" + rd.GetDateTime(30).ToShortDateString();
                        }
                        // ESTADO PROCESAL
                        if (rd[31] == DBNull.Value)
                        {
                            objetoSbp.EstadoProcesal = " ";
                        }
                        else
                        {
                            objetoSbp.EstadoProcesal = rd.GetString(31);
                        }
                        //FECHA_ESTADO_PROCESAL
                        if (rd[32] == DBNull.Value)
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else if (rd.GetDateTime(32) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEstadoProcesalString = "" + rd.GetDateTime(32).ToShortDateString();
                        }
                        //TAREA JUDICIAL
                        if (rd[33] == DBNull.Value)
                        {
                            objetoSbp.TareaJudicial = " ";
                        }
                        else
                        {
                            objetoSbp.TareaJudicial = rd.GetString(33);
                        }
                        //
                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Doi_cliente = objetoSbp.Doi_cliente,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            Demandado = objetoSbp.Demandado,
                            NombreCartera = objetoSbp.NombreCartera,
                            NombreModelo = objetoSbp.NombreModelo,
                            Sectorista = objetoSbp.Sectorista,
                            NombreEstudio = objetoSbp.NombreEstudio,
                            Region = objetoSbp.Region,
                            Agencia = objetoSbp.Agencia,
                            NombreProceso = objetoSbp.NombreProceso,
                            Juzgado = objetoSbp.Juzgado,
                            NumExpediente = objetoSbp.NumExpediente,
                            Operacion = objetoSbp.Operacion,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            MontoAdmitido = objetoSbp.MontoAdmitido,
                            ResumenProceso = objetoSbp.ResumenProceso,
                            DescripcionBien = objetoSbp.DescripcionBien,
                            NombreDistrito = objetoSbp.NombreDistrito,
                            NombreCiudad = objetoSbp.NombreCiudad,
                            NombreMonedaBien = objetoSbp.NombreMonedaBien,
                            MontoGarantia = objetoSbp.MontoGarantia,
                            ValorComercial = objetoSbp.ValorComercial,
                            MontoTasacion = objetoSbp.MontoTasacion,
                            //
                            FechaMC = objetoSbp.FechaMC,
                            FechaMCString = objetoSbp.FechaMCString,
                            //
                            FechaDemanda = objetoSbp.FechaDemanda,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            //
                            FechaMandato = objetoSbp.FechaMandato,
                            FechaMandatoString = objetoSbp.FechaMandatoString,
                            //
                            //FechaContradiccion = objetoSbp.FechaContradiccion,
                            FechaContradiccionString = objetoSbp.FechaContradiccionApelacion,
                            //
                            FechaOrden = objetoSbp.FechaOrden,
                            FechaOrdenString = objetoSbp.FechaOrdenString,
                            //

                            FechaRemateCaptura = objetoSbp.FechaRemateCaptura,
                            FechaRemateCapturaString = objetoSbp.FechaRemateCapturaString,
                            //
                            FechaAdjucaptura = objetoSbp.FechaAdjucaptura,
                            FechaAdjucapturaString = objetoSbp.FechaAdjucapturaString,
                            //
                            EstadoProcesal = objetoSbp.EstadoProcesal,
                            FechaEstadoProcesalString = objetoSbp.FechaEstadoProcesalString,
                            TareaJudicial = objetoSbp.TareaJudicial
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;   
        }
        public List<C_SBPFinal> ReporteSCIModeloACuentaBT(string cuentaBT)
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, DOI_CLIENTE, NOMBRE_COMPLETO, NOMBRE_GARANTE, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, AGENCIA, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE,OPERACION, NOMBRE_MONEDA, MONTO_ADMITIDO, TEXTO_PROCESO, DESCRIPCION_BIEN, NOMBRE_DISTRITO, NOMBRE_CIUDAD, NOMBRE_MONEDA_BIEN, MONTO_GARANTIA_EMBARGO, VALORCOMERCIAL,MONTOTASACION,FECHA_MEDIDA_CAUTELAR, FECHA_DEMANDA, FECHA_MANDATO, FECHA_CONTRADICCION_APELACION, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA, ESTADO_PROCESAL, FECHA_eSTADO_PROCESAL, TAREA_JUDICIAL FROM VW_SCI_MODELO_A WHERE MODELOA = '" + cuentaBT + "' AND CODIGO_CARTERA != 1 AND CODIGO_CARTERA !=17 AND CODIGO_MODELO = 1 AND CODIGO_TRAMITE = 4 AND CODIGO_ESTUDIO = 1;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        //
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Doi_cliente = rd.GetString(1);
                        }
                        //
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(2);
                        }
                        //
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Demandado = " ";
                        }
                        else
                        {
                            objetoSbp.Demandado = rd.GetString(3);
                        }
                        //
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.NombreCartera = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCartera = rd.GetString(4);
                        }
                        //
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.NombreModelo = " ";
                        }
                        else
                        {
                            objetoSbp.NombreModelo = rd.GetString(5);
                        }
                        //
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Sectorista = " ";
                        }
                        else
                        {
                            objetoSbp.Sectorista = rd.GetString(6);
                        }
                        //
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreEstudio = rd.GetString(7);
                        }
                        //
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.Region = " ";
                        }
                        else
                        {
                            objetoSbp.Region = rd.GetString(8);
                        }
                        //AGENCIA
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.Agencia = " ";
                        }
                        else
                        {
                            objetoSbp.Agencia = rd.GetString(9);
                        }
                        //
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(10);
                        }
                        //
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(11);
                        }
                        //
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(12);
                        }
                        //
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(13);
                        }
                        //
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(14);
                        }
                        //
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.MontoAdmitido = " ";
                        }
                        else
                        {
                            objetoSbp.MontoAdmitido = rd.GetString(15);
                        }
                        //
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.ResumenProceso = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenProceso = rd.GetString(16);
                        }
                        //DESCRIPCION BIEN
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.DescripcionBien = " ";
                        }
                        else
                        {
                            objetoSbp.DescripcionBien = rd.GetString(17);
                        }
                        //NOMBRE DISTRITO BIEN
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.NombreDistrito = " ";
                        }
                        else
                        {
                            objetoSbp.NombreDistrito = rd.GetString(18);
                        }
                        //NOMBRE CIUDAD BIEN
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.NombreCiudad = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCiudad = rd.GetString(19);
                        }
                        //NOMBRE MONEDA BIEN
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.NombreMonedaBien = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMonedaBien = rd.GetString(20);
                        }
                        //MONTO GARANTIA
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.MontoGarantia = " ";
                        }
                        else
                        {
                            objetoSbp.MontoGarantia = rd.GetString(21);
                        }
                        //VALOR COMERCIAL
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.ValorComercial = " ";
                        }
                        else
                        {
                            objetoSbp.ValorComercial = rd.GetString(22);
                        }
                        //MONTO TASACION
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.MontoTasacion = " ";
                        }
                        else
                        {
                            objetoSbp.MontoTasacion = rd.GetString(23);
                        }
                        //

                        //
                        //FECHA MC
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaMC = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaMC = rd.GetDateTime(24);
                        }
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else if (rd.GetDateTime(24) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMCString = "" + rd.GetDateTime(24).ToShortDateString();
                        }
                        // FECHA DEMANDA
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.FechaDemanda = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaDemanda = rd.GetDateTime(25);
                        }
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(25) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(25).ToShortDateString();
                        }
                        // FECHA MANDATO
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.FechaMandato = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaMandato = rd.GetDateTime(26);
                        }
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else if (rd.GetDateTime(26) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMandatoString = "" + rd.GetDateTime(26).ToShortDateString();
                        }
                        // FECHA CONTRADICCION
                        if (rd[27] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccionApelacion = " ";
                        }
                        else
                        {
                            objetoSbp.FechaContradiccionApelacion = rd.GetString(27);
                        }
                        // FECHA ORDEN
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.FechaOrden = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaOrden = rd.GetDateTime(28);
                        }
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else if (rd.GetDateTime(28) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaOrdenString = "" + rd.GetDateTime(28).ToShortDateString();
                        }
                        // FECHA ORDEN CAPTURA
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateCaptura = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaRemateCaptura = rd.GetDateTime(29);

                        }
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else if (rd.GetDateTime(29) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaRemateCapturaString = " " + rd.GetDateTime(29).ToShortDateString();
                        }
                        // FECHA CAPTURA
                        if (rd[30] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucaptura = DateTime.Parse("01-01-1990");
                        }
                        else
                        {
                            objetoSbp.FechaAdjucaptura = rd.GetDateTime(30);
                        }
                        if (rd[30] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else if (rd.GetDateTime(30) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAdjucapturaString = "" + rd.GetDateTime(30).ToShortDateString();
                        }
                        // ESTADO PROCESAL
                        if (rd[31] == DBNull.Value)
                        {
                            objetoSbp.EstadoProcesal = " ";
                        }
                        else
                        {
                            objetoSbp.EstadoProcesal = rd.GetString(31);
                        }
                        //FECHA_ESTADO_PROCESAL
                        if (rd[32] == DBNull.Value)
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else if (rd.GetDateTime(32) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEstadoProcesalString = "" + rd.GetDateTime(32).ToShortDateString();
                        }
                        //TAREA JUDICIAL
                        if (rd[33] == DBNull.Value)
                        {
                            objetoSbp.TareaJudicial = " ";
                        }
                        else
                        {
                            objetoSbp.TareaJudicial = rd.GetString(33);
                        }
                        //
                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Doi_cliente = objetoSbp.Doi_cliente,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            Demandado = objetoSbp.Demandado,
                            NombreCartera = objetoSbp.NombreCartera,
                            NombreModelo = objetoSbp.NombreModelo,
                            Sectorista = objetoSbp.Sectorista,
                            NombreEstudio = objetoSbp.NombreEstudio,
                            Region = objetoSbp.Region,
                            Agencia = objetoSbp.Agencia,
                            NombreProceso = objetoSbp.NombreProceso,
                            Juzgado = objetoSbp.Juzgado,
                            NumExpediente = objetoSbp.NumExpediente,
                            Operacion = objetoSbp.Operacion,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            MontoAdmitido = objetoSbp.MontoAdmitido,
                            ResumenProceso = objetoSbp.ResumenProceso,
                            DescripcionBien = objetoSbp.DescripcionBien,
                            NombreDistrito = objetoSbp.NombreDistrito,
                            NombreCiudad = objetoSbp.NombreCiudad,
                            NombreMonedaBien = objetoSbp.NombreMonedaBien,
                            MontoGarantia = objetoSbp.MontoGarantia,
                            ValorComercial = objetoSbp.ValorComercial,
                            MontoTasacion = objetoSbp.MontoTasacion,
                            //
                            FechaMC = objetoSbp.FechaMC,
                            FechaMCString = objetoSbp.FechaMCString,
                            //
                            FechaDemanda = objetoSbp.FechaDemanda,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            //
                            FechaMandato = objetoSbp.FechaMandato,
                            FechaMandatoString = objetoSbp.FechaMandatoString,
                            //
                            //FechaContradiccion = objetoSbp.FechaContradiccion,
                            FechaContradiccionString = objetoSbp.FechaContradiccionApelacion,
                            //
                            FechaOrden = objetoSbp.FechaOrden,
                            FechaOrdenString = objetoSbp.FechaOrdenString,
                            //

                            FechaRemateCaptura = objetoSbp.FechaRemateCaptura,
                            FechaRemateCapturaString = objetoSbp.FechaRemateCapturaString,
                            //
                            FechaAdjucaptura = objetoSbp.FechaAdjucaptura,
                            FechaAdjucapturaString = objetoSbp.FechaAdjucapturaString,
                            //
                            EstadoProcesal = objetoSbp.EstadoProcesal,
                            FechaEstadoProcesalString = objetoSbp.FechaEstadoProcesalString,
                            TareaJudicial = objetoSbp.TareaJudicial
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;  
        }

        public List<C_SBPFinal> RerporteProempresa()
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, OPERACION, NOMBRE_COMPLETO, NOMBRE_MONEDA, SALDO_CAPITAL, SALDO_CUOTA, CODIGO_MONEDA, CAPITAL, TOTAL_SOLES, NOMBRE_ESTUDIO, EJECUTIVO, CASTIGOS, AGENCIA, NOMBRE_MONEDA2, DIAS_MORA, IND_PRELACION,NOMBRE_PROCESO, ODSD_EGH, FECHA_MEDIDA_CAUTELAR, FECHA_ODSD_EGH, FECHA_INSCRIPCION, FECHA_DEMANDA, FECHA_AUTO_FINAL, NUM_JUZGADO, JUZGADO, NUM_EXPEDIENTE,CODIGO_CAUTELAR, NOMBRE_RESPONSABLE, TEXTO_PROCESO, NOMBRE_RANGO, CONVENIO_PERSONA, OBSERVACION, BIEN_NOMBRE FROM VW_REPORTE_PROEMPRESA", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Doi_cliente = rd.GetString(0);
                        }
                        //
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(1);
                        }
                        //
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(2);
                        }
                        //
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(3);
                        }
                        //
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.MontoAdmitido = " ";
                        }
                        else
                        {
                            objetoSbp.MontoAdmitido = rd.GetString(4);
                        }
                        //
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.Cuota = " ";
                        }
                        else
                        {
                            objetoSbp.Cuota = rd.GetString(5);
                        }
                        //CODIGO MONEDA
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.CodigoMoneda = 0;
                        }
                        else
                        {
                            objetoSbp.CodigoMoneda = rd.GetInt32(6);
                        }
                        //CAPITAL
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.Capital = " ";
                        }
                        else
                        {
                            objetoSbp.Capital = rd.GetString(7);
                        }
                        //TOTAL SOLES
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.TotalSoles = " ";
                        }
                        else
                        {
                            objetoSbp.TotalSoles = rd.GetString(8);
                        }
                        //ESTUDIO
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreEstudio = rd.GetString(9);
                        }
                        //EJECUTIVO
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.Ejecutivo = " ";
                        }
                        else
                        {
                            objetoSbp.Ejecutivo = rd.GetString(10);
                        }
                        //CASTIGOS
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.Castigos = " ";
                        }
                        else
                        {
                            objetoSbp.Castigos = rd.GetString(11);
                        }
                        //AGENCIA
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.Agencia = " ";
                        }
                        else
                        {
                            objetoSbp.Agencia = rd.GetString(12);
                        }
                        //NOMBRE MONEDA 2
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda2 = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda2 = rd.GetString(13);
                        }
                        //DIAS MORA 
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.DiasMora = " ";
                        }
                        else
                        {
                            objetoSbp.DiasMora = rd.GetString(14);
                        }
                        //IND PRELACION
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.Prelacion = " ";
                        }
                        else
                        {
                            objetoSbp.Prelacion = rd.GetString(15);
                        }
                        //NOMBRE PROCESO
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(16);
                        }
                        //ODSD- EGH
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.Odsd_eghString = " ";
                        }
                        else if (rd.GetDateTime(17) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.Odsd_eghString = " ";
                        }
                        else
                        {
                            objetoSbp.Odsd_eghString = "" + rd.GetDateTime(17).ToShortDateString();
                        }
                        //FECHA MEDIDA CAUTELAR
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else if (rd.GetDateTime(18) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMCString = "" + rd.GetDateTime(18).ToShortDateString();
                        }
                        //FECHA ODSD EGH
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.Fecha_odsd_egh = " ";
                        }
                        else
                        {
                            objetoSbp.Fecha_odsd_egh = rd.GetString(19);
                        }
                        //FECHA INSCRIPCION
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaInscripcionString = " ";
                        }
                        else if (rd.GetDateTime(20) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaInscripcionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaInscripcionString = "" + rd.GetDateTime(20).ToShortDateString();
                        }
                        //FECHA DEMANDA
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(21) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(21).ToShortDateString();
                        }
                        //FECHA AUTO FINAL
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.FechaAutoFinalString = " ";
                        }
                        else if (rd.GetDateTime(22) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAutoFinalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAutoFinalString = "" + rd.GetDateTime(22).ToShortDateString();
                        }
                        //NUM  JUGADO
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.NumJuzgado = " ";
                        }
                        else
                        {
                            objetoSbp.NumJuzgado = rd.GetString(23);
                        }
                        //NOMBRE JUZGADO
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(24);
                        }
                        // NUM EXPEDIENTE
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(25);
                        }
                        // CODIGO CAUTELAR
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.CodigoCautelar = " ";
                        }
                        else
                        {
                            objetoSbp.CodigoCautelar = rd.GetString(26);
                        }
                        // NOMBRE RESPONSABLE
                        if (rd[27] == DBNull.Value)
                        {
                            objetoSbp.Responsable = " ";
                        }
                        else
                        {
                            objetoSbp.Responsable = rd.GetString(27);
                        }
                        // TEXTO PROCESO
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.ResumenProceso = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenProceso = rd.GetString(28);
                        }
                        // RANGO
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.Rango = " ";
                        }
                        else
                        {
                            objetoSbp.Rango = rd.GetString(29);
                        }
                        //CONVENIO
                        if (rd[30] == DBNull.Value)
                        {
                            objetoSbp.Convenio = " ";
                        }
                        else
                        {
                            objetoSbp.Convenio = rd.GetString(30);
                        }
                        //OBSERVACION
                        if (rd[31] == DBNull.Value)
                        {
                            objetoSbp.Observacion = " ";
                        }
                        else
                        {
                            objetoSbp.Observacion = rd.GetString(31);
                        }
                        //NOMBRE BIEN
                        if (rd[32] == DBNull.Value)
                        {
                            objetoSbp.NombreBien = " ";
                        }
                        else
                        {
                            objetoSbp.NombreBien = rd.GetString(32);
                        }
                        lista.Add(new C_SBPFinal
                        {
                            Doi_cliente = objetoSbp.Doi_cliente,
                            Operacion = objetoSbp.Operacion,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            MontoAdmitido = objetoSbp.MontoAdmitido,
                            Cuota = objetoSbp.Cuota,
                            CodigoMoneda = objetoSbp.CodigoMoneda,
                            Capital = objetoSbp.Capital,
                            TotalSoles = objetoSbp.TotalSoles,
                            NombreEstudio = objetoSbp.NombreEstudio,
                            Ejecutivo = objetoSbp.Ejecutivo,
                            Castigos = objetoSbp.Castigos,
                            Agencia = objetoSbp.Agencia,
                            NombreMoneda2 = objetoSbp.NombreMoneda2,
                            DiasMora = objetoSbp.DiasMora,
                            Prelacion = objetoSbp.Prelacion,
                            NombreProceso = objetoSbp.NombreProceso,
                            Odsd_eghString = objetoSbp.Odsd_eghString,
                            FechaMCString = objetoSbp.FechaMCString,
                            Fecha_odsd_egh = objetoSbp.Fecha_odsd_egh,
                            FechaInscripcionString = objetoSbp.FechaInscripcionString,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            FechaAutoFinalString = objetoSbp.FechaAutoFinalString,
                            NumJuzgado = objetoSbp.NumJuzgado,
                            Juzgado = objetoSbp.Juzgado,
                            NumExpediente = objetoSbp.NumExpediente,
                            CodigoCautelar = objetoSbp.CodigoCautelar,
                            Responsable = objetoSbp.Responsable,
                            ResumenProceso = objetoSbp.ResumenProceso,
                            Rango = objetoSbp.Rango,
                            Convenio = objetoSbp.Convenio,
                            Observacion = objetoSbp.Observacion,
                            NombreBien = objetoSbp.NombreBien

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;   
        }
        public List<C_SBPFinal> ReporteProempresaCuentaBT(string cuentaBT)
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, OPERACION, NOMBRE_COMPLETO, NOMBRE_MONEDA, SALDO_CAPITAL, SALDO_CUOTA, CODIGO_MONEDA, CAPITAL, TOTAL_SOLES, NOMBRE_ESTUDIO, EJECUTIVO, CASTIGOS, AGENCIA, NOMBRE_MONEDA2, DIAS_MORA, IND_PRELACION,NOMBRE_PROCESO, ODSD_EGH, FECHA_MEDIDA_CAUTELAR, FECHA_ODSD_EGH, FECHA_INSCRIPCION, FECHA_DEMANDA, FECHA_AUTO_FINAL, NUM_JUZGADO, JUZGADO, NUM_EXPEDIENTE,CODIGO_CAUTELAR, NOMBRE_RESPONSABLE, TEXTO_PROCESO, NOMBRE_RANGO, CONVENIO_PERSONA, OBSERVACION, BIEN_NOMBRE FROM VW_REPORTE_PROEMPRESA WHERE PROEMPRESA = '"+cuentaBT +"' ;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Doi_cliente = rd.GetString(0);
                        }
                        //
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(1);
                        }
                        //
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(2);
                        }
                        //
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(3);
                        }
                        //
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.MontoAdmitido = " ";
                        }
                        else
                        {
                            objetoSbp.MontoAdmitido = rd.GetString(4);
                        }
                        //
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.Cuota = " ";
                        }
                        else
                        {
                            objetoSbp.Cuota = rd.GetString(5);
                        }
                        //CODIGO MONEDA
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.CodigoMoneda = 0;
                        }
                        else
                        {
                            objetoSbp.CodigoMoneda = rd.GetInt32(6);
                        }
                        //CAPITAL
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.Capital = " ";
                        }
                        else
                        {
                            objetoSbp.Capital = rd.GetString(7);
                        }
                        //TOTAL SOLES
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.TotalSoles = " ";
                        }
                        else
                        {
                            objetoSbp.TotalSoles = rd.GetString(8);
                        }
                        //ESTUDIO
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreEstudio = rd.GetString(9);
                        }
                        //EJECUTIVO
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.Ejecutivo = " ";
                        }
                        else
                        {
                            objetoSbp.Ejecutivo = rd.GetString(10);
                        }
                        //CASTIGOS
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.Castigos = " ";
                        }
                        else
                        {
                            objetoSbp.Castigos = rd.GetString(11);
                        }
                        //AGENCIA
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.Agencia = " ";
                        }
                        else
                        {
                            objetoSbp.Agencia = rd.GetString(12);
                        }
                        //NOMBRE MONEDA 2
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda2 = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda2 = rd.GetString(13);
                        }
                        //DIAS MORA 
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.DiasMora = " ";
                        }
                        else
                        {
                            objetoSbp.DiasMora = rd.GetString(14);
                        }
                        //IND PRELACION
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.Prelacion = " ";
                        }
                        else
                        {
                            objetoSbp.Prelacion = rd.GetString(15);
                        }
                        //NOMBRE PROCESO
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(16);
                        }
                        //ODSD- EGH
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.Odsd_eghString = " ";
                        }
                        else if (rd.GetDateTime(17) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.Odsd_eghString = " ";
                        }
                        else
                        {
                            objetoSbp.Odsd_eghString = "" + rd.GetDateTime(17).ToShortDateString();
                        }
                        //FECHA MEDIDA CAUTELAR
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else if (rd.GetDateTime(18) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMCString = "" + rd.GetDateTime(18).ToShortDateString();
                        }
                        //FECHA ODSD EGH
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.Fecha_odsd_egh = " ";
                        }
                        else
                        {
                            objetoSbp.Fecha_odsd_egh = rd.GetString(19);
                        }
                        //FECHA INSCRIPCION
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaInscripcionString = " ";
                        }
                        else if (rd.GetDateTime(20) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaInscripcionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaInscripcionString = "" + rd.GetDateTime(20).ToShortDateString();
                        }
                        //FECHA DEMANDA
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(21) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(21).ToShortDateString();
                        }
                        //FECHA AUTO FINAL
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.FechaAutoFinalString = " ";
                        }
                        else if (rd.GetDateTime(22) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAutoFinalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAutoFinalString = "" + rd.GetDateTime(22).ToShortDateString();
                        }
                        //NUM  JUGADO
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.NumJuzgado = " ";
                        }
                        else
                        {
                            objetoSbp.NumJuzgado = rd.GetString(23);
                        }
                        //NOMBRE JUZGADO
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(24);
                        }
                        // NUM EXPEDIENTE
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(25);
                        }
                        // CODIGO CAUTELAR
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.CodigoCautelar = " ";
                        }
                        else
                        {
                            objetoSbp.CodigoCautelar = rd.GetString(26);
                        }
                        // NOMBRE RESPONSABLE
                        if (rd[27] == DBNull.Value)
                        {
                            objetoSbp.Responsable = " ";
                        }
                        else
                        {
                            objetoSbp.Responsable = rd.GetString(27);
                        }
                        // TEXTO PROCESO
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.ResumenProceso = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenProceso = rd.GetString(28);
                        }
                        // RANGO
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.Rango = " ";
                        }
                        else
                        {
                            objetoSbp.Rango = rd.GetString(29);
                        }
                        //CONVENIO
                        if (rd[30] == DBNull.Value)
                        {
                            objetoSbp.Convenio = " ";
                        }
                        else
                        {
                            objetoSbp.Convenio = rd.GetString(30);
                        }
                        //OBSERVACION
                        if (rd[31] == DBNull.Value)
                        {
                            objetoSbp.Observacion = " ";
                        }
                        else
                        {
                            objetoSbp.Observacion = rd.GetString(31);
                        }
                        //NOMBRE BIEN
                        if (rd[32] == DBNull.Value)
                        {
                            objetoSbp.NombreBien = " ";
                        }
                        else
                        {
                            objetoSbp.NombreBien = rd.GetString(32);
                        }
                        lista.Add(new C_SBPFinal
                        {
                            Doi_cliente = objetoSbp.Doi_cliente,
                            Operacion = objetoSbp.Operacion,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            MontoAdmitido = objetoSbp.MontoAdmitido,
                            Cuota = objetoSbp.Cuota,
                            CodigoMoneda = objetoSbp.CodigoMoneda,
                            Capital = objetoSbp.Capital,
                            TotalSoles = objetoSbp.TotalSoles,
                            NombreEstudio = objetoSbp.NombreEstudio,
                            Ejecutivo = objetoSbp.Ejecutivo,
                            Castigos = objetoSbp.Castigos,
                            Agencia = objetoSbp.Agencia,
                            NombreMoneda2 = objetoSbp.NombreMoneda2,
                            DiasMora = objetoSbp.DiasMora,
                            Prelacion = objetoSbp.Prelacion,
                            NombreProceso = objetoSbp.NombreProceso,
                            Odsd_eghString = objetoSbp.Odsd_eghString,
                            FechaMCString = objetoSbp.FechaMCString,
                            Fecha_odsd_egh = objetoSbp.Fecha_odsd_egh,
                            FechaInscripcionString = objetoSbp.FechaInscripcionString,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            FechaAutoFinalString = objetoSbp.FechaAutoFinalString,
                            NumJuzgado = objetoSbp.NumJuzgado,
                            Juzgado = objetoSbp.Juzgado,
                            NumExpediente = objetoSbp.NumExpediente,
                            CodigoCautelar = objetoSbp.CodigoCautelar,
                            Responsable = objetoSbp.Responsable,
                            ResumenProceso = objetoSbp.ResumenProceso,
                            Rango = objetoSbp.Rango,
                            Convenio = objetoSbp.Convenio,
                            Observacion = objetoSbp.Observacion,
                            NombreBien = objetoSbp.NombreBien

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;   
        }

        public List<C_SBPFinal> ReporteSCIModeloB()
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, DOI_CLIENTE, NOMBRE_COMPLETO, NOMBRE_GARANTE, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, AGENCIA, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE, OPERACION, NOMBRE_MONEDA, MONTO_ADMITIDO, TEXTO_PROCESO, FECHA_DEMANDA, FECHA_MANDATO, FECHA_CONTRADICCION, FECHA_AUTO_FINAL, FECHA_ORDEN, ESTADO_PROCESAL, FECHA_ESTADO_PROCESAL, TAREA_JUDICIAL FROM VW_SCI_MODELO_B WHERE CODIGO_CARTERA !=1 AND CODIGO_CARTERA != 17 AND CODIGO_MODELO = 2 AND CODIGO_TRAMITE = 4 AND CODIGO_ESTUDIO = 1", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        //
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Doi_cliente = rd.GetString(1);
                        }
                        //
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(2);
                        }
                        //
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Demandado = " ";
                        }
                        else
                        {
                            objetoSbp.Demandado = rd.GetString(3);
                        }
                        //
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.NombreCartera = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCartera = rd.GetString(4);
                        }
                        //
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.NombreModelo = " ";
                        }
                        else
                        {
                            objetoSbp.NombreModelo = rd.GetString(5);
                        }
                        //
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Sectorista = " ";
                        }
                        else
                        {
                            objetoSbp.Sectorista = rd.GetString(6);
                        }
                        //
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreEstudio = rd.GetString(7);
                        }
                        //
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.Region = " ";
                        }
                        else
                        {
                            objetoSbp.Region = rd.GetString(8);
                        }
                        //AGENCIA
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.Agencia = " ";
                        }
                        else
                        {
                            objetoSbp.Agencia = rd.GetString(9);
                        }
                        //
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(10);
                        }
                        //
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(11);
                        }
                        //
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(12);
                        }
                        //
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(13);
                        }
                        //
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(14);
                        }
                        //
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.MontoAdmitido = " ";
                        }
                        else
                        {
                            objetoSbp.MontoAdmitido = rd.GetString(15);
                        }
                        //
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.ResumenProceso = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenProceso = rd.GetString(16);
                        }
                        // FECHA DEMANDA
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(17) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(17).ToShortDateString();
                        }
                        // FECHA MANDATO
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.FechaMandatoString= " ";
                        }
                        else if (rd.GetDateTime(18) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMandatoString = "" + rd.GetDateTime(18).ToShortDateString();
                        }
                        // FECHA CONTRADICCION
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else if (rd.GetDateTime(19) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaContradiccionString = "" + rd.GetDateTime(19).ToShortDateString();
                        }
                        // FECHA AUTO FINAL
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaAutoFinalString = " ";
                        }
                        else if (rd.GetDateTime(20) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAutoFinalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAutoFinalString = "" + rd.GetDateTime(20).ToShortDateString();
                        }
                        // FECHA ORDEN CAPTURA
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else if (rd.GetDateTime(21) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaOrdenString = "" + rd.GetDateTime(21).ToShortDateString();
                        }
                        //ESTADO PROCESAL
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.EstadoProcesal = " ";
                        }
                        else
                        {
                            objetoSbp.EstadoProcesal = rd.GetString(22);
                        }
                        //FECHA ESTADO PROCESAL
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else if (rd.GetDateTime(23) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEstadoProcesalString = "" + rd.GetDateTime(23).ToShortDateString();
                        }
                        //TAREA JUDICIAL
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.TareaJudicial = " ";
                        }
                        else
                        {
                            objetoSbp.TareaJudicial = rd.GetString(24);
                        }
                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Doi_cliente = objetoSbp.Doi_cliente,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            Demandado = objetoSbp.Demandado,
                            NombreCartera = objetoSbp.NombreCartera,
                            NombreModelo = objetoSbp.NombreModelo,
                            Sectorista = objetoSbp.Sectorista,
                            NombreEstudio = objetoSbp.NombreEstudio,
                            Region = objetoSbp.Region,
                            Agencia = objetoSbp.Agencia,
                            NombreProceso = objetoSbp.NombreProceso,
                            Juzgado = objetoSbp.Juzgado,
                            NumExpediente = objetoSbp.NumExpediente,
                            Operacion = objetoSbp.Operacion,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            MontoAdmitido = objetoSbp.MontoAdmitido,
                            ResumenProceso = objetoSbp.ResumenProceso,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            FechaMandatoString = objetoSbp.FechaMandatoString,
                            FechaContradiccionString = objetoSbp.FechaContradiccionString,
                            FechaAutoFinalString = objetoSbp.FechaAutoFinalString,
                            FechaOrdenString = objetoSbp.FechaOrdenString,
                            EstadoProcesal = objetoSbp.EstadoProcesal,
                            FechaEstadoProcesalString = objetoSbp.FechaEstadoProcesalString,
                            TareaJudicial = objetoSbp.TareaJudicial

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;   
        }
        public List<C_SBPFinal> ReporteSCIModeloBCuentaBT(string cuentaBT)
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, DOI_CLIENTE, NOMBRE_COMPLETO, NOMBRE_GARANTE, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, AGENCIA, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE, OPERACION, NOMBRE_MONEDA, MONTO_ADMITIDO, TEXTO_PROCESO, FECHA_DEMANDA, FECHA_MANDATO, FECHA_CONTRADICCION, FECHA_AUTO_FINAL, FECHA_ORDEN, ESTADO_PROCESAL, FECHA_ESTADO_PROCESAL, TAREA_JUDICIAL FROM VW_SCI_MODELO_B WHERE MODELOB = '" + cuentaBT + "' AND CODIGO_CARTERA !=1 AND CODIGO_CARTERA != 17 AND CODIGO_MODELO = 2 AND CODIGO_TRAMITE = 4 AND CODIGO_ESTUDIO = 1;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        //
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Doi_cliente = rd.GetString(1);
                        }
                        //
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(2);
                        }
                        //
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Demandado = " ";
                        }
                        else
                        {
                            objetoSbp.Demandado = rd.GetString(3);
                        }
                        //
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.NombreCartera = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCartera = rd.GetString(4);
                        }
                        //
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.NombreModelo = " ";
                        }
                        else
                        {
                            objetoSbp.NombreModelo = rd.GetString(5);
                        }
                        //
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Sectorista = " ";
                        }
                        else
                        {
                            objetoSbp.Sectorista = rd.GetString(6);
                        }
                        //
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreEstudio = rd.GetString(7);
                        }
                        //
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.Region = " ";
                        }
                        else
                        {
                            objetoSbp.Region = rd.GetString(8);
                        }
                        //AGENCIA
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.Agencia = " ";
                        }
                        else
                        {
                            objetoSbp.Agencia = rd.GetString(9);
                        }
                        //
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(10);
                        }
                        //
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(11);
                        }
                        //
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(12);
                        }
                        //
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(13);
                        }
                        //
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(14);
                        }
                        //
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.MontoAdmitido = " ";
                        }
                        else
                        {
                            objetoSbp.MontoAdmitido = rd.GetString(15);
                        }
                        //
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.ResumenProceso = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenProceso = rd.GetString(16);
                        }
                        // FECHA DEMANDA
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(17) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(17).ToShortDateString();
                        }
                        // FECHA MANDATO
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else if (rd.GetDateTime(18) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMandatoString = "" + rd.GetDateTime(18).ToShortDateString();
                        }
                        // FECHA CONTRADICCION
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else if (rd.GetDateTime(19) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaContradiccionString = "" + rd.GetDateTime(19).ToShortDateString();
                        }
                        // FECHA AUTO FINAL
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaAutoFinalString = " ";
                        }
                        else if (rd.GetDateTime(20) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAutoFinalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAutoFinalString = "" + rd.GetDateTime(20).ToShortDateString();
                        }
                        // FECHA ORDEN CAPTURA
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else if (rd.GetDateTime(21) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaOrdenString = "" + rd.GetDateTime(21).ToShortDateString();
                        }
                        //ESTADO PROCESAL
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.EstadoProcesal = " ";
                        }
                        else
                        {
                            objetoSbp.EstadoProcesal = rd.GetString(22);
                        }
                        //FECHA ESTADO PROCESAL
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else if (rd.GetDateTime(23) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEstadoProcesalString = "" + rd.GetDateTime(23).ToShortDateString();
                        }
                        //TAREA JUDICIAL
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.TareaJudicial = " ";
                        }
                        else
                        {
                            objetoSbp.TareaJudicial = rd.GetString(24);
                        }

                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Doi_cliente = objetoSbp.Doi_cliente,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            Demandado = objetoSbp.Demandado,
                            NombreCartera = objetoSbp.NombreCartera,
                            NombreModelo = objetoSbp.NombreModelo,
                            Sectorista = objetoSbp.Sectorista,
                            NombreEstudio = objetoSbp.NombreEstudio,
                            Region = objetoSbp.Region,
                            Agencia = objetoSbp.Agencia,
                            NombreProceso = objetoSbp.NombreProceso,
                            Juzgado = objetoSbp.Juzgado,
                            NumExpediente = objetoSbp.NumExpediente,
                            Operacion = objetoSbp.Operacion,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            MontoAdmitido = objetoSbp.MontoAdmitido,
                            ResumenProceso = objetoSbp.ResumenProceso,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            FechaMandatoString = objetoSbp.FechaMandatoString,
                            FechaContradiccionString = objetoSbp.FechaContradiccionString,
                            FechaAutoFinalString = objetoSbp.FechaAutoFinalString,
                            FechaOrdenString = objetoSbp.FechaOrdenString,
                            EstadoProcesal = objetoSbp.EstadoProcesal,
                            FechaEstadoProcesalString = objetoSbp.FechaEstadoProcesalString,
                            TareaJudicial = objetoSbp.TareaJudicial

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;   
        }

        public List<C_SBPFinal> ReporteSCIModeloC()
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, DOI_CLIENTE, NOMBRE_COMPLETO, NOMBRE_GARANTE, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, AGENCIA, NOMBRE_PROCESO, JUZGADO,NUM_EXPEDIENTE, OPERACION, NOMBRE_MONEDA, MONTO_ADMITIDO, TEXTO_PROCESO,MARCA_BIEN, MODELO_BIEN, PARTIDA_BIEN, NOMBRE_MONEDA_BIEN, GARANTIA_BIEN, TASACION_BIEN,FECHA_DEMANDA, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA, ESTADO_PROCESAL, FECHA_ESTADO_PROCESAL, TAREA_JUDICIAL FROM VW_SCI_MODELO_C WHERE CODIGO_CARTERA != 1 AND CODIGO_CARTERA != 17   AND CODIGO_TRAMITE = 4 AND CODIGO_ESTUDIO = 1 AND CODIGO_MODELO = 3 OR CODIGO_MODELO = 6;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        //
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Doi_cliente = rd.GetString(1);
                        }
                        //
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(2);
                        }
                        //
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Demandado = " ";
                        }
                        else
                        {
                            objetoSbp.Demandado = rd.GetString(3);
                        }
                        //
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.NombreCartera = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCartera = rd.GetString(4);
                        }
                        //
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.NombreModelo = " ";
                        }
                        else
                        {
                            objetoSbp.NombreModelo = rd.GetString(5);
                        }
                        //
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Sectorista = " ";
                        }
                        else
                        {
                            objetoSbp.Sectorista = rd.GetString(6);
                        }
                        //
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreEstudio = rd.GetString(7);
                        }
                        //
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.Region = " ";
                        }
                        else
                        {
                            objetoSbp.Region = rd.GetString(8);
                        }
                        //AGENCIA
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.Agencia = " ";
                        }
                        else
                        {
                            objetoSbp.Agencia = rd.GetString(9);
                        }
                        //
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(10);
                        }
                        //
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(11);
                        }
                        //
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(12);
                        }
                        //
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(13);
                        }
                        //
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(14);
                        }
                        //
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.MontoAdmitido = " ";
                        }
                        else
                        {
                            objetoSbp.MontoAdmitido = rd.GetString(15);
                        }
                        //
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.ResumenProceso = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenProceso = rd.GetString(16);
                        }
                        //MARCA BIEN
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.MarcaBien = " ";
                        }
                        else
                        {
                            objetoSbp.MarcaBien = rd.GetString(17);
                        }
                        //MODELO BIEN
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.ModeloBien = " ";
                        }
                        else
                        {
                            objetoSbp.ModeloBien = rd.GetString(18);
                        }
                        //PARTIDA BIEN
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.PartidaBien = " ";
                        }
                        else
                        {
                            objetoSbp.PartidaBien = rd.GetString(19);
                        }
                        //MONEDA BIEN
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.NombreMonedaBien = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMonedaBien = rd.GetString(20);
                        }
                        //GARANTIA BIEN
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.MontoGarantia = " ";
                        }
                        else
                        {
                            objetoSbp.MontoGarantia = rd.GetString(21);
                        }
                        //tasacion bien
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.MontoTasacion = " ";
                        }
                        else
                        {
                            objetoSbp.MontoTasacion = rd.GetString(22);
                        }
                        // FECHA DEMANDA
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(23) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(23).ToShortDateString();
                        }
                        // FECHA ORDEN CAPTURA
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else if (rd.GetDateTime(24) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaOrdenString = "" + rd.GetDateTime(24).ToShortDateString();
                        }
                        // FECHA REMATE CAPTURA
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else if (rd.GetDateTime(25) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaRemateCapturaString = "" + rd.GetDateTime(25).ToShortDateString();
                        }
                        // FECHA ADJUCAPTURA
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else if (rd.GetDateTime(26) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAdjucapturaString = "" + rd.GetDateTime(26).ToShortDateString();
                        }
                        //ESTADO PROCESAL
                        if (rd[27] == DBNull.Value)
                        {
                            objetoSbp.EstadoProcesal = " ";
                        }
                        else
                        {
                            objetoSbp.EstadoProcesal = rd.GetString(27);
                        }
                        //FECHA ESTADO PROCESAL
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else if (rd.GetDateTime(28) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEstadoProcesalString = "" + rd.GetDateTime(28).ToShortDateString();
                        }
                        //TAREA JUDICIAL
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.TareaJudicial = " ";
                        }
                        else
                        {
                            objetoSbp.TareaJudicial = rd.GetString(29);
                        }


                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Doi_cliente = objetoSbp.Doi_cliente,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            Demandado = objetoSbp.Demandado,
                            NombreCartera = objetoSbp.NombreCartera,
                            NombreModelo = objetoSbp.NombreModelo,
                            Sectorista = objetoSbp.Sectorista,
                            NombreEstudio = objetoSbp.NombreEstudio,
                            Region = objetoSbp.Region,
                            Agencia = objetoSbp.Agencia,
                            NombreProceso = objetoSbp.NombreProceso,
                            Juzgado = objetoSbp.Juzgado,
                            NumExpediente = objetoSbp.NumExpediente,
                            Operacion = objetoSbp.Operacion,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            MontoAdmitido = objetoSbp.MontoAdmitido,
                            ResumenProceso = objetoSbp.ResumenProceso,
                            MarcaBien = objetoSbp.MarcaBien,
                            ModeloBien = objetoSbp.ModeloBien,
                            PartidaBien = objetoSbp.PartidaBien,
                            NombreMonedaBien = objetoSbp.NombreMonedaBien,
                            MontoGarantia = objetoSbp.MontoGarantia,
                            MontoTasacion = objetoSbp.MontoTasacion,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            FechaOrdenString = objetoSbp.FechaOrdenString,
                            FechaRemateCapturaString = objetoSbp.FechaRemateCapturaString,
                            FechaAdjucapturaString = objetoSbp.FechaAdjucapturaString,
                            EstadoProcesal = objetoSbp.EstadoProcesal,
                            FechaEstadoProcesalString =objetoSbp.FechaEstadoProcesalString,
                            TareaJudicial = objetoSbp.TareaJudicial
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;   
        }
        public List<C_SBPFinal> ReporteSCIModeloCCuentaBT(string cuentaBT)
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, DOI_CLIENTE, NOMBRE_COMPLETO, NOMBRE_GARANTE, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, AGENCIA, NOMBRE_PROCESO, JUZGADO,NUM_EXPEDIENTE, OPERACION, NOMBRE_MONEDA, MONTO_ADMITIDO, TEXTO_PROCESO,MARCA_BIEN, MODELO_BIEN, PARTIDA_BIEN, NOMBRE_MONEDA_BIEN, GARANTIA_BIEN, TASACION_BIEN,FECHA_DEMANDA, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA, ESTADO_PROCESAL, FECHA_ESTADO_PROCESAL, TAREA_JUDICIAL FROM VW_SCI_MODELO_C WHERE MODELOC = '"+ cuentaBT +"' AND CODIGO_CARTERA != 1 AND CODIGO_CARTERA != 17   AND CODIGO_TRAMITE = 4 AND CODIGO_ESTUDIO = 1;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        //
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Doi_cliente = rd.GetString(1);
                        }
                        //
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(2);
                        }
                        //
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Demandado = " ";
                        }
                        else
                        {
                            objetoSbp.Demandado = rd.GetString(3);
                        }
                        //
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.NombreCartera = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCartera = rd.GetString(4);
                        }
                        //
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.NombreModelo = " ";
                        }
                        else
                        {
                            objetoSbp.NombreModelo = rd.GetString(5);
                        }
                        //
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Sectorista = " ";
                        }
                        else
                        {
                            objetoSbp.Sectorista = rd.GetString(6);
                        }
                        //
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreEstudio = rd.GetString(7);
                        }
                        //
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.Region = " ";
                        }
                        else
                        {
                            objetoSbp.Region = rd.GetString(8);
                        }
                        //AGENCIA
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.Agencia = " ";
                        }
                        else
                        {
                            objetoSbp.Agencia = rd.GetString(9);
                        }
                        //
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(10);
                        }
                        //
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(11);
                        }
                        //
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(12);
                        }
                        //
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(13);
                        }
                        //
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(14);
                        }
                        //
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.MontoAdmitido = " ";
                        }
                        else
                        {
                            objetoSbp.MontoAdmitido = rd.GetString(15);
                        }
                        //
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.ResumenProceso = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenProceso = rd.GetString(16);
                        }
                        //MARCA BIEN
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.MarcaBien = " ";
                        }
                        else
                        {
                            objetoSbp.MarcaBien = rd.GetString(17);
                        }
                        //MODELO BIEN
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.ModeloBien = " ";
                        }
                        else
                        {
                            objetoSbp.ModeloBien = rd.GetString(18);
                        }
                        //PARTIDA BIEN
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.PartidaBien = " ";
                        }
                        else
                        {
                            objetoSbp.PartidaBien = rd.GetString(19);
                        }
                        //MONEDA BIEN
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.NombreMonedaBien = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMonedaBien = rd.GetString(20);
                        }
                        //GARANTIA BIEN
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.MontoGarantia = " ";
                        }
                        else
                        {
                            objetoSbp.MontoGarantia = rd.GetString(21);
                        }
                        //tasacion bien
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.MontoTasacion = " ";
                        }
                        else
                        {
                            objetoSbp.MontoTasacion = rd.GetString(22);
                        }
                        // FECHA DEMANDA
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(23) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(23).ToShortDateString();
                        }
                        // FECHA ORDEN CAPTURA
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else if (rd.GetDateTime(24) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaOrdenString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaOrdenString = "" + rd.GetDateTime(24).ToShortDateString();
                        }
                        // FECHA REMATE CAPTURA
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else if (rd.GetDateTime(25) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaRemateCapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaRemateCapturaString = "" + rd.GetDateTime(25).ToShortDateString();
                        }
                        // FECHA ADJUCAPTURA
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else if (rd.GetDateTime(26) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAdjucapturaString = "" + rd.GetDateTime(26).ToShortDateString();
                        }
                                                //ESTADO PROCESAL
                        if (rd[27] == DBNull.Value)
                        {
                            objetoSbp.EstadoProcesal = " ";
                        }
                        else
                        {
                            objetoSbp.EstadoProcesal = rd.GetString(27);
                        }
                        //FECHA ESTADO PROCESAL
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else if (rd.GetDateTime(28) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEstadoProcesalString = "" + rd.GetDateTime(28).ToShortDateString();
                        }
                        //TAREA JUDICIAL
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.TareaJudicial = " ";
                        }
                        else
                        {
                            objetoSbp.TareaJudicial = rd.GetString(29);
                        }                   

                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Doi_cliente = objetoSbp.Doi_cliente,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            Demandado = objetoSbp.Demandado,
                            NombreCartera = objetoSbp.NombreCartera,
                            NombreModelo = objetoSbp.NombreModelo,
                            Sectorista = objetoSbp.Sectorista,
                            NombreEstudio = objetoSbp.NombreEstudio,
                            Region = objetoSbp.Region,
                            Agencia = objetoSbp.Agencia,
                            NombreProceso = objetoSbp.NombreProceso,
                            Juzgado = objetoSbp.Juzgado,
                            NumExpediente = objetoSbp.NumExpediente,
                            Operacion = objetoSbp.Operacion,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            MontoAdmitido = objetoSbp.MontoAdmitido,
                            ResumenProceso = objetoSbp.ResumenProceso,
                            MarcaBien = objetoSbp.MarcaBien,
                            ModeloBien = objetoSbp.ModeloBien,
                            PartidaBien = objetoSbp.PartidaBien,
                            NombreMonedaBien = objetoSbp.NombreMonedaBien,
                            MontoGarantia = objetoSbp.MontoGarantia,
                            MontoTasacion = objetoSbp.MontoTasacion,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            FechaOrdenString = objetoSbp.FechaOrdenString,
                            FechaRemateCapturaString = objetoSbp.FechaRemateCapturaString,
                            FechaAdjucapturaString = objetoSbp.FechaAdjucapturaString,
                            EstadoProcesal = objetoSbp.EstadoProcesal,
                            FechaEstadoProcesalString = objetoSbp.FechaEstadoProcesalString,
                            TareaJudicial = objetoSbp.TareaJudicial
                            
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;  
        }

        public List<C_SBPFinal> ReporteSullana()
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT OUT, SZC, AGENCIA, CODIGO_CREDITO_ABANKS, COD_CRED_SAFI, CASTIGOS, NOMBRE_COMPLETO, NOMBRE_GARANTE, NOMBRE_MONEDA, OPERACION, SALDO_CAPITAL, SALDO_CAPITAL_SOLARIZADO,SALDO_TOTAL_DEUDA, SALDO_TOTAL_DEUDA_SOLARIZADO, FECHA_ASIGNACION, NOMBRE_FORMA, DESCRIPCION_BIEN, FECHA_INICIO_PROCESO, MONTO_ADMITIDO, NUM_EXPEDIENTE, NUM_JUZGADO, JUZGADO,DISTRITO_JUDICIAL, TIPO_JUICIO, NOMBRE_PROCESO, FECHA_ESTADO_PROCESAL, ETAPA_PROCESO, DETALLE_INCIDENCIA, INCIDENCIA, FECHA_DETALLE_PROX_REMATE, OPINION, MONTO_PROBABLE,JUICIOS_TERMINADOS, FECHA_MEDIDA_CAUTELAR, FECHA_DEMANDA, TIEMPO, tarea_judicial FROM VW_REPORTE_SULLANA ", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //OUTS
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Outs = " ";
                        }
                        else
                        {
                            objetoSbp.Outs = rd.GetString(0);
                        }
                        //SZC
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Szc = " ";
                        }
                        else
                        {
                            objetoSbp.Szc = rd.GetString(1);
                        }
                        //AGENCIA
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Agencia = " ";
                        }
                        else
                        {
                            objetoSbp.Agencia = rd.GetString(2);
                        }
                        //BANKZ
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Bankz = " ";
                        }
                        else
                        {
                            objetoSbp.Bankz = rd.GetString(3);
                        }
                        //SAFI
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.Safi = " ";
                        }
                        else
                        {
                            objetoSbp.Safi = rd.GetString(4);
                        }
                        //CASTIGOS
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.Castigos = " ";
                        }
                        else
                        {
                            objetoSbp.Castigos = rd.GetString(5);
                        }
                        //NOMBRE COMPLETO
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(6);
                        }
                        //NOMBRE GARANTE
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.Demandado = " ";
                        }
                        else
                        {
                            objetoSbp.Demandado = rd.GetString(7);
                        }
                        //NOMBRE MONEDA
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(8);
                        }
                        //OPERACION
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(9);
                        }
                        //SALDO CAPIAL
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.Capital = " ";
                        }
                        else
                        {
                            objetoSbp.Capital = rd.GetString(10);
                        }
                        //CAPITAL SOLIRADIZADO
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.CapSolidarizado = " ";
                        }
                        else
                        {
                            objetoSbp.CapSolidarizado = rd.GetString(11);
                        }
                        //SALTO TOTAL DEUDA
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.TotalDeuda = " ";
                        }
                        else
                        {
                            objetoSbp.TotalDeuda = rd.GetString(12);
                        }
                        //TOTAL DEUDA SOLIRADIZADO
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.TotalDeudaSoli = " ";
                        }
                        else
                        {
                            objetoSbp.TotalDeudaSoli = rd.GetString(13);
                        }
                        //FECHA ASIGNACION
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.FechaAsignacionString = " ";
                        }
                        else if (rd.GetDateTime(14)== DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAsignacionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAsignacionString = "" + rd.GetDateTime(14).ToShortDateString();
                        }
                        //NOMBRE FORMA
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(15);
                        }
                        //DESCRIPCION BIEN
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.DescripcionBien = " ";
                        }
                        else
                        {
                            objetoSbp.DescripcionBien = rd.GetString(16);
                        }
                        //FECHA INCIO PROCESO
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.FechaInicio = " ";
                        }
                        else
                        {
                            objetoSbp.FechaInicio = rd.GetString(17);
                        }
                        //MONTO ADMITIDO
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.MontoAdmitido = " ";
                        }
                        else
                        {
                            objetoSbp.MontoAdmitido = rd.GetString(18);
                        }
                        //num expediente
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(19);
                        }
                        //NUM JUZGADO
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.NumJuzgado = " ";
                        }
                        else
                        {
                            objetoSbp.NumJuzgado = rd.GetString(20);
                        }
                        //JUZGADO
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(21);
                        }
                        //DISTRITO JDICIAL
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.DistritoJudicial = " ";
                        }
                        else
                        {
                            objetoSbp.DistritoJudicial = rd.GetString(22);
                        }
                        // TIPO JUICIO
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.TipoJudicial = " ";
                        }
                        else
                        {
                            objetoSbp.TipoJudicial = rd.GetString(23);
                        }
                        // NOMBRE PROCESO
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.Proceso = " ";
                        }
                        else
                        {
                            objetoSbp.Proceso = rd.GetString(24);
                        }
                        // FECHA ESTADO PROCESAL
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else if (rd.GetDateTime(25) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEstadoProcesalString = "" + rd.GetDateTime(25).ToShortDateString();
                        }
                        // ETAPA PROCESO
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.EtapaProceso = " ";
                        }
                        else
                        {
                            objetoSbp.EtapaProceso = rd.GetString(26);
                        }
                        //DETALLE INCIDENCIA
                        if (rd[27] == DBNull.Value)
                        {
                            objetoSbp.DetalleIncidencia = " ";
                        }
                        else
                        {
                            objetoSbp.DetalleIncidencia = rd.GetString(27);
                        }
                        //INCIDENCIA
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.Incidencia = " ";
                        }
                        else
                        {
                            objetoSbp.Incidencia = rd.GetString(28);
                        }
                        //FECHA DETALLE PROX REMATE
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.FechaDetalleProxRemateString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDetalleProxRemateString = rd.GetString(29);
                        }
                        //OPINION
                        if (rd[30] == DBNull.Value)
                        {
                            objetoSbp.Opinion = " ";
                        }
                        else
                        {
                            objetoSbp.Opinion = rd.GetString(30);
                        }
                        //MONTO PROBABLE
                        if (rd[31] == DBNull.Value)
                        {
                            objetoSbp.MontoProbable = " ";
                        }
                        else
                        {
                            objetoSbp.MontoProbable = rd.GetString(31);
                        }
                        //JUICIOS TERMINADOS
                        if (rd[32] == DBNull.Value)
                        {
                            objetoSbp.JuiciosTerminados = " ";
                        }
                        else
                        {
                            objetoSbp.JuiciosTerminados = rd.GetString(32);
                        }
                        //FECHA MEDIDA CAUTELAR
                        if (rd[33] == DBNull.Value)
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else if (rd.GetDateTime(33) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMCString = "" + rd.GetDateTime(33).ToShortDateString();
                        }
                        //FECHA DEMANDA
                        if (rd[34] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(34) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(34).ToShortDateString();
                        }
                        //TIEMPO = INCIDENCIA
                        if (rd[35] == DBNull.Value)
                        {
                            objetoSbp.TiempoIncidencia = " ";
                        }
                        else
                        {
                            objetoSbp.TiempoIncidencia = rd.GetString(35);
                        }
                        //TAREA JUDICIAL
                        if (rd[36] == DBNull.Value)
                        {
                            objetoSbp.TareaJudicial = " ";
                        }
                        else
                        {
                            objetoSbp.TareaJudicial = rd.GetString(36);
                        }
                        lista.Add(new C_SBPFinal
                        {
                            Outs = objetoSbp.Outs,
                            Szc = objetoSbp.Szc,
                            Agencia = objetoSbp.Agencia,
                            Bankz = objetoSbp.Bankz,
                            Safi = objetoSbp.Safi,
                            Castigos = objetoSbp.Castigos,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            Demandado = objetoSbp.Demandado,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            Operacion = objetoSbp.Operacion,
                            Capital = objetoSbp.Capital,
                            CapSolidarizado = objetoSbp.CapSolidarizado,
                            TotalDeuda = objetoSbp.TotalDeuda,
                            TotalDeudaSoli = objetoSbp.TotalDeudaSoli,
                            FechaAsignacionString = objetoSbp.FechaAsignacionString,
                            NombreProceso = objetoSbp.NombreProceso,
                            DescripcionBien = objetoSbp.DescripcionBien,
                            FechaInicio = objetoSbp.FechaInicio,
                            MontoAdmitido = objetoSbp.MontoAdmitido,
                            NumExpediente = objetoSbp.NumExpediente,
                            NumJuzgado = objetoSbp.NumJuzgado,
                            Juzgado = objetoSbp.Juzgado,
                            DistritoJudicial = objetoSbp.DistritoJudicial,
                            TipoJudicial = objetoSbp.TipoJudicial,
                            Proceso = objetoSbp.Proceso,
                            FechaEstadoProcesalString = objetoSbp.FechaEstadoProcesalString,
                            EtapaProceso = objetoSbp.EtapaProceso,
                            DetalleIncidencia = objetoSbp.DetalleIncidencia,
                            Incidencia = objetoSbp.Incidencia,
                            FechaDetalleProxRemateString = objetoSbp.FechaDetalleProxRemateString,
                            Opinion = objetoSbp.Opinion,
                            MontoProbable = objetoSbp.MontoProbable,
                            JuiciosTerminados = objetoSbp.JuiciosTerminados,
                            FechaMCString = objetoSbp.FechaMCString,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            TiempoIncidencia = objetoSbp.TiempoIncidencia,
                            TareaJudicial = objetoSbp.TareaJudicial
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;   
        }
        public List<C_SBPFinal> ReporteSullanaCuentaBT(string cuentaBT)
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT OUT, SZC, AGENCIA, CODIGO_CREDITO_ABANKS, COD_CRED_SAFI, CASTIGOS, NOMBRE_COMPLETO, NOMBRE_GARANTE, NOMBRE_MONEDA, OPERACION, SALDO_CAPITAL, SALDO_CAPITAL_SOLARIZADO,SALDO_TOTAL_DEUDA, SALDO_TOTAL_DEUDA_SOLARIZADO, FECHA_ASIGNACION, NOMBRE_FORMA, DESCRIPCION_BIEN, FECHA_INICIO_PROCESO, MONTO_ADMITIDO, NUM_EXPEDIENTE, NUM_JUZGADO, JUZGADO,DISTRITO_JUDICIAL, TIPO_JUICIO, NOMBRE_PROCESO, FECHA_ESTADO_PROCESAL, ETAPA_PROCESO, DETALLE_INCIDENCIA, INCIDENCIA, FECHA_DETALLE_PROX_REMATE, OPINION, MONTO_PROBABLE,JUICIOS_TERMINADOS, FECHA_MEDIDA_CAUTELAR, FECHA_DEMANDA, TIEMPO, tarea_judicial FROM VW_REPORTE_SULLANA WHERE SULLANA = '"+cuentaBT + "'; ", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Outs = " ";
                        }
                        else
                        {
                            objetoSbp.Outs = rd.GetString(0);
                        }
                        //
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Szc = " ";
                        }
                        else
                        {
                            objetoSbp.Szc = rd.GetString(1);
                        }
                        //AGENCIA
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Agencia = " ";
                        }
                        else
                        {
                            objetoSbp.Agencia = rd.GetString(2);
                        }
                        //BANKZ
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Bankz = " ";
                        }
                        else
                        {
                            objetoSbp.Bankz = rd.GetString(3);
                        }
                        //SAFI
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.Safi = " ";
                        }
                        else
                        {
                            objetoSbp.Safi = rd.GetString(4);
                        }
                        //CASTIGOS
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.Castigos = " ";
                        }
                        else
                        {
                            objetoSbp.Castigos = rd.GetString(5);
                        }
                        //NOMBRE COMPLETO
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(6);
                        }
                        //NOMBRE GARANTE
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.Demandado = " ";
                        }
                        else
                        {
                            objetoSbp.Demandado = rd.GetString(7);
                        }
                        //NOMBRE MONEDA
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(8);
                        }
                        //OPERACION
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(9);
                        }
                        //SALDO CAPIAL
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.Capital = " ";
                        }
                        else
                        {
                            objetoSbp.Capital = rd.GetString(10);
                        }
                        //CAPITAL SOLIRADIZADO
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.CapSolidarizado = " ";
                        }
                        else
                        {
                            objetoSbp.CapSolidarizado = rd.GetString(11);
                        }
                        //SALTO TOTAL DEUDA
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.TotalDeuda = " ";
                        }
                        else
                        {
                            objetoSbp.TotalDeuda = rd.GetString(12);
                        }
                        //TOTAL DEUDA SOLIRADIZADO
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.TotalDeudaSoli = " ";
                        }
                        else
                        {
                            objetoSbp.TotalDeudaSoli = rd.GetString(13);
                        }
                        //FECHA ASIGNACION
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.FechaAsignacionString = " ";
                        }
                        else if (rd.GetDateTime(14) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAsignacionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAsignacionString = "" + rd.GetDateTime(14).ToShortDateString();
                        }
                        //NOMBRE FORMA
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(15);
                        }
                        //DESCRIPCION BIEN
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.DescripcionBien = " ";
                        }
                        else
                        {
                            objetoSbp.DescripcionBien = rd.GetString(16);
                        }
                        //FECHA INCIO PROCESO
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.FechaInicio = " ";
                        }
                        else
                        {
                            objetoSbp.FechaInicio = rd.GetString(17);
                        }
                        //MONTO ADMITIDO
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.MontoAdmitido = " ";
                        }
                        else
                        {
                            objetoSbp.MontoAdmitido = rd.GetString(18);
                        }
                        //num expediente
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(19);
                        }
                        //NUM JUZGADO
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.NumJuzgado = " ";
                        }
                        else
                        {
                            objetoSbp.NumJuzgado = rd.GetString(20);
                        }
                        //JUZGADO
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(21);
                        }
                        //DISTRITO JDICIAL
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.DistritoJudicial = " ";
                        }
                        else
                        {
                            objetoSbp.DistritoJudicial = rd.GetString(22);
                        }
                        // TIPO JUICIO
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.TipoJudicial = " ";
                        }
                        else
                        {
                            objetoSbp.TipoJudicial = rd.GetString(23);
                        }
                        // NOMBRE PROCESO
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.Proceso = " ";
                        }
                        else
                        {
                            objetoSbp.Proceso = rd.GetString(24);
                        }
                        // FECHA ESTADO PROCESAL
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else if (rd.GetDateTime(25) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEstadoProcesalString = "" + rd.GetDateTime(25).ToShortDateString();
                        }
                        // ETAPA PROCESO
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.EtapaProceso = " ";
                        }
                        else
                        {
                            objetoSbp.EtapaProceso = rd.GetString(26);
                        }
                        //DETALLE INCIDENCIA
                        if (rd[27] == DBNull.Value)
                        {
                            objetoSbp.DetalleIncidencia = " ";
                        }
                        else
                        {
                            objetoSbp.DetalleIncidencia = rd.GetString(27);
                        }
                        //INCIDENCIA
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.Incidencia = " ";
                        }
                        else
                        {
                            objetoSbp.Incidencia = rd.GetString(28);
                        }
                        //FECHA DETALLE PROX REMATE
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.FechaDetalleProxRemateString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDetalleProxRemateString = rd.GetString(29);
                        }
                        //OPINION
                        if (rd[30] == DBNull.Value)
                        {
                            objetoSbp.Opinion = " ";
                        }
                        else
                        {
                            objetoSbp.Opinion = rd.GetString(30);
                        }
                        //MONTO PROBABLE
                        if (rd[31] == DBNull.Value)
                        {
                            objetoSbp.MontoProbable = " ";
                        }
                        else
                        {
                            objetoSbp.MontoProbable = rd.GetString(31);
                        }
                        //JUICIOS TERMINADOS
                        if (rd[32] == DBNull.Value)
                        {
                            objetoSbp.JuiciosTerminados = " ";
                        }
                        else
                        {
                            objetoSbp.JuiciosTerminados = rd.GetString(32);
                        }
                        //FECHA MEDIDA CAUTELAR
                        if (rd[33] == DBNull.Value)
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else if (rd.GetDateTime(33) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMCString = "" + rd.GetDateTime(3).ToShortDateString();
                        }
                        //FECHA DEMANDA
                        if (rd[34] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(34) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(34).ToShortDateString();
                        }
                        //TIEMPO = INCIDENCIA
                        if (rd[35] == DBNull.Value)
                        {
                            objetoSbp.TiempoIncidencia = " ";
                        }
                        else
                        {
                            objetoSbp.TiempoIncidencia = rd.GetString(35);
                        }
                        //TAREA JUDICIAL
                        if (rd[36] == DBNull.Value)
                        {
                            objetoSbp.TareaJudicial = " ";
                        }
                        else
                        {
                            objetoSbp.TareaJudicial = rd.GetString(36);
                        }
                        lista.Add(new C_SBPFinal
                        {
                            Outs = objetoSbp.Outs,
                            Szc = objetoSbp.Szc,
                            Agencia = objetoSbp.Agencia,
                            Bankz = objetoSbp.Bankz,
                            Safi = objetoSbp.Safi,
                            Castigos = objetoSbp.Castigos,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            Demandado = objetoSbp.Demandado,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            Operacion = objetoSbp.Operacion,
                            Capital = objetoSbp.Capital,
                            CapSolidarizado = objetoSbp.CapSolidarizado,
                            TotalDeuda = objetoSbp.TotalDeuda,
                            TotalDeudaSoli = objetoSbp.TotalDeudaSoli,
                            FechaAsignacionString = objetoSbp.FechaAsignacionString,
                            NombreProceso = objetoSbp.NombreProceso,
                            DescripcionBien = objetoSbp.DescripcionBien,
                            FechaInicio = objetoSbp.FechaInicio,
                            MontoAdmitido = objetoSbp.MontoAdmitido,
                            NumExpediente = objetoSbp.NumExpediente,
                            NumJuzgado = objetoSbp.NumJuzgado,
                            Juzgado = objetoSbp.Juzgado,
                            DistritoJudicial = objetoSbp.DistritoJudicial,
                            TipoJudicial = objetoSbp.TipoJudicial,
                            Proceso = objetoSbp.Proceso,
                            FechaEstadoProcesalString = objetoSbp.FechaEstadoProcesalString,
                            EtapaProceso = objetoSbp.EtapaProceso,
                            DetalleIncidencia = objetoSbp.DetalleIncidencia,
                            Incidencia = objetoSbp.Incidencia,
                            FechaDetalleProxRemateString = objetoSbp.FechaDetalleProxRemateString,
                            Opinion = objetoSbp.Opinion,
                            MontoProbable = objetoSbp.MontoProbable,
                            JuiciosTerminados = objetoSbp.JuiciosTerminados,
                            FechaMCString = objetoSbp.FechaMCString,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            TiempoIncidencia = objetoSbp.TiempoIncidencia,
                            TareaJudicial = objetoSbp.TareaJudicial
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }

        public List<C_SBPFinal> ReporteLlamada()
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT NUM_EXPEDIENTE, OPERACION, FECHA_GESTION, NOMBRE_COMPLETO, TELEFONO_CONTACTO, NUMERO, FECHA_VISITA_ESTUDIO, TIPO_SOLUCION, FECHA_PAGO, NIEGA_PAGO FROM VW_LLAMADA", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //NUM EXPEDIENTE
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(0);
                        }
                        //OPERACION
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(1);
                        }
                        //FECHA GESTION 
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.FechaGestionString = " ";
                        }
                        else if (rd.GetDateTime(2) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaGestionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaGestionString = "" + rd.GetDateTime(2).ToShortDateString();
                        }
                        //NOMBRE COMPLETO
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(3);
                        }
                        //TELEFONO DE LLAMADA
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.TelefonoLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.TelefonoLlamada = rd.GetString(4);
                        }
                        //TELEFONO DE CLIENTE
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.TelefonoPersona = " ";
                        }
                        else
                        {
                            objetoSbp.TelefonoPersona = rd.GetString(5);
                        }
                        //FECHA DE PROX LLAMADA
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.FechaProxLlamadaString = " ";
                        }
                        else if (rd.GetDateTime(6) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaProxLlamadaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaProxLlamadaString = "" + rd.GetDateTime(6).ToShortDateString();
                        }
                        //TIPO SOLUCION
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.TipoSolucion = " ";
                        }
                        else
                        {
                            objetoSbp.TipoSolucion = rd.GetString(7);
                        }
                        //FECHA DE PAGO
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.FechaPagoString = " ";
                        }
                        else if (rd.GetDateTime(8) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaPagoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaPagoString = "" + rd.GetDateTime(8).ToShortDateString();
                        }
                        //NIEGA PAGO
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.NiegaPago = " ";
                        }
                        else
                        {
                            objetoSbp.NiegaPago = rd.GetString(9);
                        }
                        //
                        lista.Add(new C_SBPFinal
                        {
                            NumExpediente = objetoSbp.NumExpediente,
                            Operacion = objetoSbp.Operacion,
                            FechaGestionString = objetoSbp.FechaGestionString,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            TelefonoLlamada = objetoSbp.TelefonoLlamada,
                            TelefonoPersona = objetoSbp.TelefonoPersona,
                            FechaProxLlamadaString = objetoSbp.FechaProxLlamadaString,
                            TipoSolucion = objetoSbp.TipoSolucion,
                            FechaPagoString = objetoSbp.FechaPagoString,
                            NiegaPago = objetoSbp.NiegaPago
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;   
        }

        public List<C_SBPFinal> ReporteMensualLlamada()
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, OPERACION, NUM_EXPEDIENTE, TELEFONO, RESULTADO, MAX || '|' || MIN as FECHAS ,HISTORICO,MOTIVO_NO_PAGO FROM VW_REPORTE_LLAMADA", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //CUENTA BT
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        //OPERACION
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(1);
                        }
                        //NUM EXPEDIENTE
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(2);
                        }
                        //TELEFONO
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.TelefonoLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.TelefonoLlamada = rd.GetString(3);
                        }
                        //RESULTADO
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.ResultadoLlamda = " ";
                        }
                        else
                        {
                            objetoSbp.ResultadoLlamda = rd.GetString(4);
                        }
                        //FECHA REPORTE LLAMADA 
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.FechaReporteLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.FechaReporteLlamada = rd.GetString(5);
                        }
                        //FECHA DE PROX LLAMADA
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.ResumenLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenLlamada = rd.GetString(6);
                        }
                        //TIPO SOLUCION
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.MotivoNoPago = " ";
                        }
                        else
                        {
                            objetoSbp.MotivoNoPago = rd.GetString(7);
                        }
                       
                        //
                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Operacion = objetoSbp.Operacion,
                            NumExpediente = objetoSbp.NumExpediente,
                            TelefonoLlamada = objetoSbp.TelefonoLlamada,
                            ResultadoLlamda = objetoSbp.ResultadoLlamda,
                            FechaReporteLlamada = objetoSbp.FechaReporteLlamada,
                            ResumenLlamada = objetoSbp.ResumenLlamada,
                            MotivoNoPago = objetoSbp.MotivoNoPago
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;  
        }
        public List<C_SBPFinal> ReporteMensualLlamadaCuentaBT(string codigo)
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, OPERACION, NUM_EXPEDIENTE, TELEFONO, RESULTADO, MAX || '|' || MIN as FECHAS ,HISTORICO,MOTIVO_NO_PAGO FROM VW_REPORTE_LLAMADA WHERE llamada = '" +codigo +"';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //CUENTA BT
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        //OPERACION
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(1);
                        }
                        //NUM EXPEDIENTE
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(2);
                        }
                        //TELEFONO
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.TelefonoLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.TelefonoLlamada = rd.GetString(3);
                        }
                        //RESULTADO
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.ResultadoLlamda = " ";
                        }
                        else
                        {
                            objetoSbp.ResultadoLlamda = rd.GetString(4);
                        }
                        //FECHA REPORTE LLAMADA 
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.FechaReporteLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.FechaReporteLlamada = rd.GetString(5);
                        }
                        //FECHA DE PROX LLAMADA
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.ResumenLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenLlamada = rd.GetString(6);
                        }
                        //TIPO SOLUCION
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.MotivoNoPago = " ";
                        }
                        else
                        {
                            objetoSbp.MotivoNoPago = rd.GetString(7);
                        }

                        //
                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Operacion = objetoSbp.Operacion,
                            NumExpediente = objetoSbp.NumExpediente,
                            TelefonoLlamada = objetoSbp.TelefonoLlamada,
                            ResultadoLlamda = objetoSbp.ResultadoLlamda,
                            FechaReporteLlamada = objetoSbp.FechaReporteLlamada,
                            ResumenLlamada = objetoSbp.ResumenLlamada,
                            MotivoNoPago = objetoSbp.MotivoNoPago
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;  
        }

        public List<C_SBPFinal> ReporteMensualCampo()
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, OPERACION,NUM_EXPEDIENTE, DIRECCION,RESULTADO, MAX || '|'|| MIN AS FECHAS, HISTORICO, MOTIVO_NO_PAGO FROM VW_REPORTE_CAMPO", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //CUENTA BT
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        //OPERACION
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(1);
                        }
                        //NUM EXPEDIENTE
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(2);
                        }
                        //DIRECCION
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Direccion = " ";
                        }
                        else
                        {
                            objetoSbp.Direccion = rd.GetString(3);
                        }
                        //RESULTADO
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.ResultadoCampo = " ";
                        }
                        else
                        {
                            objetoSbp.ResultadoCampo = rd.GetString(4);
                        }
                        //FECHA REPORTE CAMPO
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.FechaReporteCampo = " ";
                        }
                        else
                        {
                            objetoSbp.FechaReporteCampo = rd.GetString(5);
                        }
                        //HISTORICO CAMPO
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.ResumenCampo = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenCampo = rd.GetString(6);
                        }
                        //TIPO SOLUCION
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.MotivoNoPago = " ";
                        }
                        else
                        {
                            objetoSbp.MotivoNoPago = rd.GetString(7);
                        }

                        //
                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Operacion = objetoSbp.Operacion,
                            NumExpediente = objetoSbp.NumExpediente,
                            Direccion = objetoSbp.Direccion,
                            ResultadoCampo = objetoSbp.ResultadoCampo,
                            FechaReporteCampo = objetoSbp.FechaReporteCampo,
                            ResumenCampo = objetoSbp.ResumenCampo,
                            MotivoNoPago = objetoSbp.MotivoNoPago
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;  
        }
        public List<C_SBPFinal> ReporteMensualCampoCuentaBT(string codigo)
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, OPERACION,NUM_EXPEDIENTE, DIRECCION,RESULTADO, MAX || '|'|| MIN AS FECHAS, HISTORICO, MOTIVO_NO_PAGO FROM VW_REPORTE_CAMPO WHERE CAMPO = '"+ codigo +"';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //CUENTA BT
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        //OPERACION
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(1);
                        }
                        //NUM EXPEDIENTE
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(2);
                        }
                        //DIRECCION
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Direccion = " ";
                        }
                        else
                        {
                            objetoSbp.Direccion = rd.GetString(3);
                        }
                        //RESULTADO
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.ResultadoCampo = " ";
                        }
                        else
                        {
                            objetoSbp.ResultadoCampo = rd.GetString(4);
                        }
                        //FECHA REPORTE CAMPO
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.FechaReporteCampo = " ";
                        }
                        else
                        {
                            objetoSbp.FechaReporteCampo = rd.GetString(5);
                        }
                        //HISTORICO CAMPO
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.ResumenCampo = " ";
                        }
                        else
                        {
                            objetoSbp.ResumenCampo = rd.GetString(6);
                        }
                        //TIPO SOLUCION
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.MotivoNoPago = " ";
                        }
                        else
                        {
                            objetoSbp.MotivoNoPago = rd.GetString(7);
                        }

                        //
                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Operacion = objetoSbp.Operacion,
                            NumExpediente = objetoSbp.NumExpediente,
                            Direccion = objetoSbp.Direccion,
                            ResultadoCampo = objetoSbp.ResultadoCampo,
                            FechaReporteCampo = objetoSbp.FechaReporteCampo,
                            ResumenCampo = objetoSbp.ResumenCampo,
                            MotivoNoPago = objetoSbp.MotivoNoPago
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;  
 
        }

        public List<C_SBPFinal> ReporteCartas()
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, NOMBRE_COMPLETO, NOMBRE_CONYUGE, REPRESENTANTE, NOMBRE_CARTERA, NOMBRE_ABOGADO, DIRECCION_ALTERNA, DOMICILIO_PERSONA, NOMBRE_DISTRITO, NOMBRE_PROCESO, INUBICABLE_GESTION FROM VW_REPORTE_CARTAS", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //CUENTA BT
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        //NOMBRE COMPLETO
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(1);
                        }
                        //NOMBRE CONYUGE
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.NombreConyuge = " ";
                        }
                        else
                        {
                            objetoSbp.NombreConyuge = rd.GetString(2);
                        }
                        //REPRESENTANTE
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Representante = " ";
                        }
                        else
                        {
                            objetoSbp.Representante = rd.GetString(3);
                        }
                        //CARTERA
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.NombreCartera = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCartera = rd.GetString(4);
                        }
                        //ABOGADO
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.Abogado = " ";
                        }
                        else
                        {
                            objetoSbp.Abogado = rd.GetString(5);
                        }
                        //DIRECCION ALTERNA
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.DireccionAlterna = " ";
                        }
                        else
                        {
                            objetoSbp.DireccionAlterna = rd.GetString(6);
                        }
                        //DOMICILIO PERSONA
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.Domicilio = " ";
                        }
                        else
                        {
                            objetoSbp.Domicilio = rd.GetString(7);
                        }
                        //DISTRITO
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.NombreDistrito = " ";
                        }
                        else
                        {
                            objetoSbp.NombreDistrito = rd.GetString(8);
                        }
                        //NOMBRE PROCESO
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(9);
                        }
                        //INUBICABLE
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.Inubicable = " ";
                        }
                        else
                        {
                            objetoSbp.Inubicable = rd.GetString(10);
                        }
                        //
                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            NombreConyuge = objetoSbp.NombreConyuge,
                            Representante = objetoSbp.Representante,
                            NombreCartera = objetoSbp.NombreCartera,
                            Abogado = objetoSbp.Abogado,
                            DireccionAlterna = objetoSbp.DireccionAlterna,
                            Domicilio = objetoSbp.Domicilio,
                            NombreDistrito = objetoSbp.NombreDistrito,
                            NombreProceso = objetoSbp.NombreProceso,
                            Inubicable = objetoSbp.Inubicable
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;  
        }
        public List<C_SBPFinal> ReporteCartasCuentaBT(string codigo)
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, NOMBRE_COMPLETO, NOMBRE_CONYUGE, REPRESENTANTE, NOMBRE_CARTERA, NOMBRE_ABOGADO, DIRECCION_ALTERNA, DOMICILIO_PERSONA, NOMBRE_DISTRITO, NOMBRE_PROCESO, INUBICABLE_GESTION FROM VW_REPORTE_CARTAS   WHERE carta ='"+codigo+"';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //CUENTA BT
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(0);
                        }
                        //NOMBRE COMPLETO
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(1);
                        }
                        //NOMBRE CONYUGE
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.NombreConyuge = " ";
                        }
                        else
                        {
                            objetoSbp.NombreConyuge = rd.GetString(2);
                        }
                        //REPRESENTANTE
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Representante = " ";
                        }
                        else
                        {
                            objetoSbp.Representante = rd.GetString(3);
                        }
                        //CARTERA
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.NombreCartera = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCartera = rd.GetString(4);
                        }
                        //ABOGADO
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.Abogado = " ";
                        }
                        else
                        {
                            objetoSbp.Abogado = rd.GetString(5);
                        }
                        //DIRECCION ALTERNA
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.DireccionAlterna = " ";
                        }
                        else
                        {
                            objetoSbp.DireccionAlterna = rd.GetString(6);
                        }
                        //DOMICILIO PERSONA
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.Domicilio = " ";
                        }
                        else
                        {
                            objetoSbp.Domicilio = rd.GetString(7);
                        }
                        //DISTRITO
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.NombreDistrito = " ";
                        }
                        else
                        {
                            objetoSbp.NombreDistrito = rd.GetString(8);
                        }
                        //NOMBRE PROCESO
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(9);
                        }
                        //INUBICABLE
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.Inubicable = " ";
                        }
                        else
                        {
                            objetoSbp.Inubicable = rd.GetString(10);
                        }
                        //
                        lista.Add(new C_SBPFinal
                        {
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            NombreConyuge = objetoSbp.NombreConyuge,
                            Representante = objetoSbp.Representante,
                            NombreCartera = objetoSbp.NombreCartera,
                            Abogado = objetoSbp.Abogado,
                            DireccionAlterna = objetoSbp.DireccionAlterna,
                            Domicilio = objetoSbp.Domicilio,
                            NombreDistrito = objetoSbp.NombreDistrito,
                            NombreProceso = objetoSbp.NombreProceso,
                            Inubicable = objetoSbp.Inubicable
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;  
        }

        public List<C_SBPFinal> ReporteCompletoAbogados()
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT 	NOMBRE_DISTRITO, '|' || DOI_CLIENTE as DOI_CLIENTE, NOMBRE_COMPLETO, NOMBRE_CONYUGE, DOMICILIO_PERSONA, DIRECCION_ALTERNA, REPRESENTANTE, NUMERO, CONVENIO_PERSONA, '|' || CUENTA_BT AS CUENTA_BT, '|' || OPERACION AS OPERACION,NOMBRE_CARTERA, NOMBRE_MONEDA, NOMBRE_CIUDAD,NOMBRE_ESTUDIO,NOMBRE_TRAMITE, NOMBRE_MODELO, CASTIGOS, CDR, CAPITAL, FECHA_PROTESTO, OBSERVACION_TRAMITE, FECHA_TRAMITE, AGENCIA, FECHA_ASIGNACION, MONTO_ADMITIDO, PRODUCTO_MODULO, EJECUTIVO, NOMBRE_GARANTE, CONYUGE_GARANTE, DISTRITO, DOMICILIO,NUM_EXPEDIENTE, NOMBRE_PROCESO,NOMBRE_ABOGADO,NOMBRE_RESPONSABLE, TRABAJADOR_SECRETARIO, NUM_EXPEDIENTE_22DIGITOS, JUZGADO, CODIGO_CAUTELAR, NUM_JUZGADO, NOMBRE_MACROETAPA,NOMBRE_MICROETAPA,NOMBRE_MEDIDACAUTELAR, TIEMPO, FECHA_ETAPA, FECHA_INSCRIPCION, ESTADO_CAUTELAR, FECHA_MEDIDA_CAUTELAR, VIGENCIA_MC, FECHA_ACTUADO_CAUTELAR, DEVOLUCION_CEDULA, FECHA_MANDATO, FECHA_CONTRADICCION, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA, FECHA_DEMANDA, FECHA_AUTO_FINAL, FECHA_APELACION, NOMBRE_RANGO, BIEN_NOMBRE, MONTO_GARANTIA_BIEN, MONTO_TASACION_BIEN, FECHA_tASACION_BIEN, PARTIDA_BIEN, PORCENTAJE_BIEN, DESCRIPCION_BIEN, TIPO_BIEN, VALOR_BIEN, BIEN_CIUDAD, BIEN_DISTRITO, MARCA_BIEN, MODELO_BIEN, ESTADO_PROCESAL, FECHA_eSTADO_PROCESAL, TAREA_JUDICIAL, FECHA_TAREA_ADMINISTRATIVA, INCIDENCIA, DETALLE_INCIDENCIA, TAREA_ADMINISTRATIVA,SOLUCION, SALDO_PAGO, COMISIONES, FECHA,FECHA_ESTIMADA, DEVUELTO, MOTIVO_DEVOLUCION,TELEFONO,	TEXTO_PROCESO, TEXTO_LLAMADA, TEXTO_CAMPO, INUBICABLE_CAMPO FROM VW_REPORTE_COMPLETO", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        // TITULAR
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //DISTRITO - TITULAR
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.DistritoTitular = " ";
                        }
                        else
                        {
                            objetoSbp.DistritoTitular = rd.GetString(0);
                        }
                        //DOI - TITULAR
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Doi_cliente = rd.GetString(1);
                        }
                        //NOMBRE - TITULAR
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(2);
                        }
                        //CONYUGE - TITULAR
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.NombreConyuge = " ";
                        }
                        else
                        {
                            objetoSbp.NombreConyuge = rd.GetString(3);
                        }
                        //DOMICILIO - TITULAR
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.DomicilioTitular = " ";
                        }
                        else
                        {
                            objetoSbp.DomicilioTitular = rd.GetString(4);
                        }

                        //DIRECCION ALTERNA - TITULAR
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.DireccionAlterna = " ";
                        }
                        else
                        {
                            objetoSbp.DireccionAlterna = rd.GetString(5);
                        }
                        //REPRESENTANTE - TITULAR
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Representante = " ";
                        }
                        else
                        {
                            objetoSbp.Representante = rd.GetString(6);
                        }
                        //TELEFONO - TITULAR
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.TelefonoPersona = " ";
                        }
                        else
                        {
                            objetoSbp.TelefonoPersona = rd.GetString(7);
                        }
                        //CONVENIO - TITULAR
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.ConvenioTitular = " ";
                        }
                        else
                        {
                            objetoSbp.ConvenioTitular = rd.GetString(8);
                        }
                        //CUENTA BT - TITULAR
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(9);
                        }
                       
                        
                        // CRÉDITO
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //OPERACION - CREDITO
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(10);
                        }
                        //CARTERA - CREDITO
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.NombreCartera = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCartera = rd.GetString(11);
                        }
                        //MONEDA - CREDITO
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(12);
                        }
                        //CIUDAD - CREDITO
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.NombreCiudadEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCiudadEstudio = rd.GetString(13);
                        }
                        //ESTUDIO - CREDITO
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreEstudio = rd.GetString(14);
                        }
                        //TRAMITE - CREDITO
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.NombreTramite = " ";
                        }
                        else
                        {
                            objetoSbp.NombreTramite = rd.GetString(15);
                        }
                        //MODELO - CREDITO
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.NombreModelo = " ";
                        }
                        else
                        {
                            objetoSbp.NombreModelo = rd.GetString(16);
                        }
                        //CASTIGOS - CREDITO
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.Castigos = " ";
                        }
                        else
                        {
                            objetoSbp.Castigos = rd.GetString(17);
                        }
                        //CDR - CREDITO
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.Cdr = " ";
                        }
                        else
                        {
                            objetoSbp.Cdr = rd.GetString(18);
                        }
                        //CAPITAL - CREDITO
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.Capital = " ";
                        }
                        else
                        {
                            objetoSbp.Capital = rd.GetString(19);
                        }
                        //FECHA PROTESTO - CREDITO
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaProtestoString = " ";
                        }
                        else if (rd.GetDateTime(20) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaProtestoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaProtestoString = "" + rd.GetDateTime(20).ToShortDateString();
                        }
                        //OBSERVACION TRAMITE - CREDITO
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.Observacion = " ";
                        }
                        else
                        {
                            objetoSbp.Observacion = rd.GetString(21);
                        }
                        //FECHA TRAMITE - CREDITO
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.FechaTramiteString = " ";
                        }
                        else if (rd.GetDateTime(22) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaTramiteString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaTramiteString = "" + rd.GetDateTime(22).ToShortDateString();
                        }
                        //AGENCIA - CREDITO
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.Agencia = " ";
                        }
                        else
                        {
                            objetoSbp.Agencia = rd.GetString(23);
                        }
                        //FECHA ASIGNACION - CREDITO
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaAsignacionString = " ";
                        }
                        else if (rd.GetDateTime(24) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAsignacionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAsignacionString = "" + rd.GetDateTime(24).ToShortDateString();
                        }
                        //MONTO ADMITIDO - CREDITO
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.MontoAdmitido = " ";
                        }
                        else
                        {
                            objetoSbp.MontoAdmitido = rd.GetString(25);
                        }
                        //PRODUCTO O MODULO - CREDITO
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.ProductoModulo = " ";
                        }
                        else
                        {
                            objetoSbp.ProductoModulo = rd.GetString(26);
                        }
                        //EJECUTIVO - CREDITO
                        if (rd[27] == DBNull.Value)
                        {
                            objetoSbp.Ejecutivo = " ";
                        }
                        else
                        {
                            objetoSbp.Ejecutivo = rd.GetString(27);
                        }


                        // GARANTE
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //NOMBRE - GARANTE
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp .NombreGarante = " ";
                        }
                        else
                        {
                            objetoSbp.NombreGarante = rd.GetString(28);
                        }
                        //CONYUGE - GARANTE
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.ConyugeGarante = " ";
                        }
                        else
                        {
                            objetoSbp.ConyugeGarante = rd.GetString(29);
                        }
                        //DISTRITO - GARANTE
                        if (rd[30] == DBNull.Value)
                        {
                            objetoSbp.DistritoGarante = " ";
                        }
                        else
                        {
                            objetoSbp.DistritoGarante = rd.GetString(30);
                        }
                        //DOMICILIO - GARANTE
                        if (rd[31] == DBNull.Value)
                        {
                            objetoSbp.DomicilioGarante = " ";
                        }
                        else
                        {
                            objetoSbp.DomicilioGarante = rd.GetString(31);
                        }
                        
                        // EXPEDIENTE
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //NUM EXPEDIENTE - EXPEDIENTE
                        if (rd[32] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(32);
                        }
                        //NOMBRE PROCESO - EXPEDIENTE
                        if (rd[33] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(33);
                        }
                        //ABOGADO - EXPEDIENTE
                        if (rd[34] == DBNull.Value)
                        {
                            objetoSbp.Abogado = " ";
                        }
                        else
                        {
                            objetoSbp.Abogado = rd.GetString(34);
                        }
                        //RESPONSABLE - EXPEDIENTE
                        if (rd[35] == DBNull.Value)
                        {
                            objetoSbp.Responsable = " ";
                        }
                        else
                        {
                            objetoSbp.Responsable = rd.GetString(35);
                        }
                        //SECRETARIO - EXPEDIENTE
                        if (rd[36] == DBNull.Value)
                        {
                            objetoSbp.Secretario = " ";
                        }
                        else
                        {
                            objetoSbp.Secretario = rd.GetString(36);
                        }
                        //NUM EXPEDIENTE 22 DIGITOS - EXPEDIENTE
                        if (rd[37] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente22 = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente22 = rd.GetString(37);
                        }
                        //JUZGADO - EXPEDIENTE
                        if (rd[38] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(38);
                        }
                        //CODIGO CAUTELAR - EXPEDIENTE
                        if (rd[39] == DBNull.Value)
                        {
                            objetoSbp.CodigoCautelar = " ";
                        }
                        else
                        {
                            objetoSbp.CodigoCautelar = rd.GetString(39);
                        }
                        //NUM JUZGADO - EXPEDIENTE
                        if (rd[40] == DBNull.Value)
                        {
                            objetoSbp.NumJuzgado = " ";
                        }
                        else
                        {
                            objetoSbp.NumJuzgado = rd.GetString(40);
                        }

                        
                        // PROCESO
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //MACRO ETAPA - PROCESO
                        if (rd[41] == DBNull.Value)
                        {
                            objetoSbp.Macroetapa = " ";
                        }
                        else
                        {
                            objetoSbp.Macroetapa = rd.GetString(41);
                        }
                        //MICRO ETAPA - PROCESO
                        if (rd[42] == DBNull.Value)
                        {
                            objetoSbp.Microetapa = " ";
                        }
                        else
                        {
                            objetoSbp.Microetapa = rd.GetString(42);
                        }
                        //MEDIDA CAUTELAR - PROCESO
                        if (rd[43] == DBNull.Value)
                        {
                            objetoSbp.MedidaCautelar = " ";
                        }
                        else
                        {
                            objetoSbp.MedidaCautelar = rd.GetString(43);
                        }
                        //INCIDENCIA SULLANA - PROCESO
                        if (rd[44] == DBNull.Value)
                        {
                            objetoSbp.IncidenciaSullana = " ";
                        }
                        else
                        {
                            objetoSbp.IncidenciaSullana = rd.GetString(44);
                        }
                        //FECHA ETAPA - PROCESO
                        if (rd[45] == DBNull.Value)
                        {
                            objetoSbp.FechaEtapaProcesoString = " ";
                        }
                        else if (rd.GetDateTime(45) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEtapaProcesoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEtapaProcesoString = "" + rd.GetDateTime(45).ToShortDateString();
                        }
                        //FECHA INSCRIPCION - PROCESO
                        if (rd[46] == DBNull.Value)
                        {
                            objetoSbp.FechaInscripcionString = " ";
                        }
                        else if (rd.GetDateTime(46) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaInscripcionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaInscripcionString = "" + rd.GetDateTime(46).ToShortDateString();
                        }
                        //ESTADO CAUTELAR - PROCESO
                        if (rd[47] == DBNull.Value)
                        {
                            objetoSbp.EstadoCautelar = " ";
                        }
                        else
                        {
                            objetoSbp.EstadoCautelar = rd.GetString(47);
                        }
                        //FECHA MEDIDA CAUTELAR - PROCESO
                        if (rd[48] == DBNull.Value)
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else if (rd.GetDateTime(48) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMCString = "" + rd.GetDateTime(48).ToShortDateString();
                        }
                        //VIGENCIA MC - PROCESO
                        if (rd[49] == DBNull.Value)
                        {
                            objetoSbp.VigenciaMC = " ";
                        }
                        else
                        {
                            objetoSbp.VigenciaMC = rd.GetString(49);
                        }
                        //FECHA ACTUADO CAUTELAR - PROCESO
                        if (rd[50] == DBNull.Value)
                        {
                            objetoSbp.FechaActuadoCautelarString = " ";
                        }
                        else if (rd.GetDateTime(50) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaActuadoCautelarString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaActuadoCautelarString = "" + rd.GetDateTime(50).ToShortDateString();
                        }
                        //DEVOLUCION DE CEDULA - PROCESO
                        if (rd[51] == DBNull.Value)
                        {
                            objetoSbp.Devolucion = " ";
                        }
                        else
                        {
                            objetoSbp.Devolucion = rd.GetString(51);
                        }
                        
                        // FECHAS
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //FECHA MANDATO - FECHAS
                        if (rd[52] == DBNull.Value)
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else if (rd.GetDateTime(52) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMandatoString = "" + rd.GetDateTime(52).ToShortDateString();
                        }
                        //FECHA CONTRADICCION - FECHAS
                        if (rd[53] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else if (rd.GetDateTime(53) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaContradiccionString = "" + rd.GetDateTime(53).ToShortDateString();
                        }
                        //FECHA ORDEN - FECHAS
                        if (rd[54] == DBNull.Value)
                        {
                            objetoSbp.FechaOrdenRemateIncautacion = " ";
                        }
                        else if (rd.GetDateTime(54) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaOrdenRemateIncautacion = " ";
                        }
                        else
                        {
                            objetoSbp.FechaOrdenRemateIncautacion = "" + rd.GetDateTime(54).ToShortDateString();
                        }
                        //FECHA REMATE CAPTURA - FECHAS
                        if (rd[55] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateOrdenCaptura = " ";
                        }
                        else if (rd.GetDateTime(55) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaRemateOrdenCaptura = " ";
                        }
                        else
                        {
                            objetoSbp.FechaRemateOrdenCaptura = "" + rd.GetDateTime(55).ToShortDateString();
                        }
                        //FECHA ADJU CAPTURA - FECHAS
                        if (rd[56] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else if (rd.GetDateTime(56) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAdjucapturaString = "" + rd.GetDateTime(56).ToShortDateString();
                        }
                        //FECHA DEMANDA - FECHAS
                        if (rd[57] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(57) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(57).ToShortDateString();
                        }
                        //FECHA AUTO FINAL - FECHAS
                        if (rd[58] == DBNull.Value)
                        {
                            objetoSbp.FechaAutoFinalString = " ";
                        }
                        else if (rd.GetDateTime(58) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAutoFinalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAutoFinalString = "" + rd.GetDateTime(58).ToShortDateString();
                        }
                        //FECHA APELACION - FECHAS
                        if (rd[59] == DBNull.Value)
                        {
                            objetoSbp.FechaApelacionString = " ";
                        }
                        else if (rd.GetDateTime(59) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaApelacionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaApelacionString = "" + rd.GetDateTime(59).ToShortDateString();
                        }

                        
                        // BIEN
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //NOMBRE RANGO - BIEN
                        if (rd[60] == DBNull.Value)
                        {
                            objetoSbp.Rango = " ";
                        }
                        else
                        {
                            objetoSbp.Rango = rd.GetString(60);
                        }
                        //NOMBRE BIEN - BIEN
                        if (rd[61] == DBNull.Value)
                        {
                            objetoSbp.NombreBien = " ";
                        }
                        else
                        {
                            objetoSbp.NombreBien = rd.GetString(61);
                        }
                        //MONTO GARANTIA - BIEN
                        if (rd[62] == DBNull.Value)
                        {
                            objetoSbp.MontoGarantia = " ";
                        }
                        else
                        {
                            objetoSbp.MontoGarantia = rd.GetString(62);
                        }        
                        //MONTO TASACION - BIEN
                        if (rd[63] == DBNull.Value)
                        {
                            objetoSbp.MontoTasacion = " ";
                        }
                        else
                        {
                            objetoSbp.MontoTasacion = rd.GetString(63);
                        }
                        //FECHA TASACION - BIEN
                        if (rd[64] == DBNull.Value)
                        {
                            objetoSbp.FechaTasacionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaTasacionString = rd.GetString(64);
                        }
                        //PARTIDA PLACA - BIEN
                        if (rd[65] == DBNull.Value)
                        {
                            objetoSbp.PartidaBien = " ";
                        }
                        else
                        {
                            objetoSbp.PartidaBien = rd.GetString(65);
                        }
                        //PORCENTAJE - BIEN
                        if (rd[66] == DBNull.Value)
                        {
                            objetoSbp.PorcentajeBien = " ";
                        }
                        else
                        {
                            objetoSbp.PorcentajeBien = rd.GetString(66);
                        }
                        //DESCRIPCION - BIEN
                        if (rd[67] == DBNull.Value)
                        {
                            objetoSbp.DescripcionBien = " ";
                        }
                        else
                        {
                            objetoSbp.DescripcionBien = rd.GetString(67);
                        }
                        //TIPO BIEN - BIEN
                        if (rd[68] == DBNull.Value)
                        {
                            objetoSbp.TipoBien = " ";
                        }
                        else
                        {
                            objetoSbp.TipoBien = rd.GetString(68);
                        }
                        //VALOR COMERCIAL - BIEN
                        if (rd[69] == DBNull.Value)
                        {
                            objetoSbp.ValorComercial = " ";
                        }
                        else
                        {
                            objetoSbp.ValorComercial = rd.GetString(69);
                        }
                        //CIUDAD - BIEN
                        if (rd[70] == DBNull.Value)
                        {
                            objetoSbp.CiudadBien = " ";
                        }
                        else
                        {
                            objetoSbp.CiudadBien = rd.GetString(70);
                        }
                        //DISTRITO - BIEN
                        if (rd[71] == DBNull.Value)
                        {
                            objetoSbp.DistritoBien = " ";
                        }
                        else
                        {
                            objetoSbp.DistritoBien = rd.GetString(71);
                        }
                        //MARCA - BIEN
                        if (rd[72] == DBNull.Value)
                        {
                            objetoSbp.MarcaBien = " ";
                        }
                        else
                        {
                            objetoSbp.MarcaBien = rd.GetString(72);
                        }
                        //MODELO - BIEN
                        if (rd[73] == DBNull.Value)
                        {
                            objetoSbp.ModeloBien = " ";
                        }
                        else
                        {
                            objetoSbp.ModeloBien = rd.GetString(73);
                        }
                        
                        // SEGUIMIENTO
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //ESTADO PROCESAL - SEGUIMIENTO
                        if (rd[74] == DBNull.Value)
                        {
                            objetoSbp.EstadoProcesal = " ";
                        }
                        else
                        {
                            objetoSbp.EstadoProcesal = rd.GetString(74);
                        }
                        //FECHA ESTADO PROCESAL - SEGUIMIENTO
                        if (rd[75] == DBNull.Value)
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else if (rd.GetDateTime(75) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEstadoProcesalString = "" + rd.GetDateTime(75).ToShortDateString();
                        }
                        //TAREA JUDICIAL - SEGUIMIENTO
                        if (rd[76] == DBNull.Value)
                        {
                            objetoSbp.TareaJudicial = " ";
                        }
                        else
                        {
                            objetoSbp.TareaJudicial = rd.GetString(76);
                        }
                        //FECHA TAREA ADMINISTRATIVA - SEGUIMIENTO
                        if (rd[77] == DBNull.Value)
                        {
                            objetoSbp.FechaTareaAdministrativaString = " ";
                        }
                        else if (rd.GetDateTime(77) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaTareaAdministrativaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaTareaAdministrativaString = "" + rd.GetDateTime(77).ToShortDateString();
                        }
                        //INCIDENCIA - SEGUIMIENTO
                        if (rd[78] == DBNull.Value)
                        {
                            objetoSbp.Incidencia = " ";
                        }
                        else
                        {
                            objetoSbp.Incidencia = rd.GetString(78);
                        }
                        //DETALLE INCIDENCIA - SEGUIMIENTO
                        if (rd[79] == DBNull.Value)
                        {
                            objetoSbp.DetalleIncidencia = " ";
                        }
                        else
                        {
                            objetoSbp.DetalleIncidencia = rd.GetString(79);
                        }
                        //TAREA ADMINISTRATIVA - SEGUIMIENTO
                        if (rd[80] == DBNull.Value)
                        {
                            objetoSbp.TareaAdministrativa = " ";
                        }
                        else
                        {
                            objetoSbp.TareaAdministrativa = rd.GetString(80);
                        }
                        
                        // PAGOS
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //SOLUCION - PAGOS
                        if (rd[81] == DBNull.Value)
                        {
                            objetoSbp.TipoSolucionPagos = " ";
                        }
                        else
                        {
                            objetoSbp.TipoSolucionPagos = rd.GetString(81);
                        }
                        //SALDO - PAGOS
                        if (rd[82] == DBNull.Value)
                        {
                            objetoSbp.SaldoPagos = " ";
                        }
                        else
                        {
                            objetoSbp.SaldoPagos = rd.GetString(82);
                        }
                        //COMISION - PAGOS
                        if (rd[83] == DBNull.Value)
                        {
                            objetoSbp.ComisionesPagos = " ";
                        }
                        else
                        {
                            objetoSbp.ComisionesPagos = rd.GetString(83);
                        }
                        //FECHA PAGOS - PAGOS
                        if (rd[84] == DBNull.Value)
                        {
                            objetoSbp.FechaPagoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaPagoString = rd.GetString(84);
                        }
                        
                        
                        // PROYECCION
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //FECHA ESTIMADA - PROYECCION
                        if (rd[85] == DBNull.Value)
                        {
                            objetoSbp.FechaEstimadaString = " ";
                        }
                        else if (rd.GetDateTime(85) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEstimadaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEstimadaString = "" + rd.GetDateTime(85).ToShortDateString();
                        }
                        //DEVUELTO - PROYECCION
                        if (rd[86] == DBNull.Value)
                        {
                            objetoSbp.Devuelto = " ";
                        }
                        else
                        {
                            objetoSbp.Devuelto = rd.GetString(86);
                        }
                        //MOTIVO DEVOLUCION - PROYECCION
                        if (rd[87] == DBNull.Value)
                        {
                            objetoSbp.MotivoDevolucion = " ";
                        }
                        else
                        {
                            objetoSbp.MotivoDevolucion = rd.GetString(87);
                        }
                        //TELEFONO - PROYECCION
                        if (rd[88] == DBNull.Value)
                        {
                            objetoSbp.TelefonoProyeccion = " ";
                        }
                        else
                        {
                            objetoSbp.TelefonoProyeccion = rd.GetString(88);
                        }
                        // HISTORICO
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //PROCESO - HISTORICO
                        if (rd[89] == DBNull.Value)
                        {
                            objetoSbp.HistoricoProceso = " ";
                        }
                        else
                        {
                            objetoSbp.HistoricoProceso = rd.GetString(89);
                        }
                        //LLAMADA - HISTORICO
                        if (rd[90] == DBNull.Value)
                        {
                            objetoSbp.HistoricoLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.HistoricoLlamada = rd.GetString(90);
                        }
                        //CAMPO - HISTORICO
                        if (rd[91] == DBNull.Value)
                        {
                            objetoSbp.HistoricoCampo = " ";
                        }
                        else
                        {
                            objetoSbp.HistoricoCampo = rd.GetString(91);
                        }
                        //  GESTION CAMPO
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //INUBICABLE - GESTION CAMPO
                        if (rd[92] == DBNull.Value)
                        {
                            objetoSbp.Inubicable = " ";
                        }
                        else
                        {
                            objetoSbp.Inubicable = rd.GetString(92);
                        }
                        
                        lista.Add(new C_SBPFinal
                        {
                            DistritoTitular = objetoSbp.DistritoTitular,
                            Doi_cliente = objetoSbp.Doi_cliente,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            NombreConyuge = objetoSbp.NombreConyuge,
                            DomicilioTitular = objetoSbp.DomicilioTitular,
                            DireccionAlterna = objetoSbp.DireccionAlterna,
                            Representante = objetoSbp.Representante,
                            TelefonoPersona = objetoSbp.TelefonoPersona,
                            ConvenioTitular = objetoSbp.ConvenioTitular,
                            Cuenta_bt = objetoSbp.Cuenta_bt,

                            Operacion = objetoSbp.Operacion,
                            NombreCartera = objetoSbp.NombreCartera,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            NombreCiudadEstudio = objetoSbp.NombreCiudadEstudio,
                            NombreEstudio = objetoSbp.NombreEstudio,
                            NombreTramite = objetoSbp.NombreTramite,
                            NombreModelo = objetoSbp.NombreModelo,
                            Castigos = objetoSbp.Castigos,
                            Cdr = objetoSbp.Cdr,
                            Capital = objetoSbp.Capital,
                            FechaProtestoString = objetoSbp.FechaProtestoString,
                            Observacion = objetoSbp.Observacion,
                            FechaTramiteString = objetoSbp.FechaTramiteString,
                            Agencia = objetoSbp.Agencia,
                            FechaAsignacionString = objetoSbp.FechaAsignacionString,
                            MontoAdmitido = objetoSbp.MontoAdmitido,
                            ProductoModulo = objetoSbp.ProductoModulo,
                            Ejecutivo = objetoSbp.Ejecutivo,

                            NombreGarante = objetoSbp.NombreGarante,
                            ConyugeGarante = objetoSbp.ConyugeGarante,
                            DistritoGarante = objetoSbp.DistritoGarante,
                            DomicilioGarante = objetoSbp.DomicilioGarante,

                            NumExpediente = objetoSbp.NumExpediente,
                            NombreProceso = objetoSbp.NombreProceso,
                            Abogado = objetoSbp.Abogado,
                            Responsable = objetoSbp.Responsable,
                            Secretario = objetoSbp.Secretario,
                            NumExpediente22 = objetoSbp.NumExpediente22,
                            Juzgado = objetoSbp.Juzgado,
                            CodigoCautelar = objetoSbp.CodigoCautelar,
                            NumJuzgado = objetoSbp.NumJuzgado,
                            
                            Macroetapa = objetoSbp.Macroetapa,
                            Microetapa = objetoSbp.Microetapa,
                            MedidaCautelar = objetoSbp.MedidaCautelar,
                            IncidenciaSullana = objetoSbp.IncidenciaSullana,
                            FechaEtapaProcesoString = objetoSbp.FechaEtapaProcesoString,
                            FechaInscripcionString = objetoSbp.FechaInscripcionString,
                            EstadoCautelar = objetoSbp.EstadoCautelar,
                            FechaMCString = objetoSbp.FechaMCString,
                            VigenciaMC = objetoSbp.VigenciaMC,
                            FechaActuadoCautelarString = objetoSbp.FechaActuadoCautelarString,
                            Devolucion = objetoSbp.Devolucion,
                            
                            FechaMandatoString = objetoSbp.FechaMandatoString,
                            FechaContradiccionString = objetoSbp.FechaContradiccionString,
                            FechaOrdenRemateIncautacion = objetoSbp.FechaOrdenRemateIncautacion,
                            FechaRemateOrdenCaptura = objetoSbp.FechaRemateOrdenCaptura,
                            FechaAdjucapturaString = objetoSbp.FechaAdjucapturaString,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            FechaAutoFinalString = objetoSbp.FechaAutoFinalString,
                            FechaApelacionString = objetoSbp.FechaApelacionString,
                            
                            Rango = objetoSbp.Rango,
                            NombreBien = objetoSbp.NombreBien,
                            MontoGarantia = objetoSbp.MontoGarantia,
                            MontoTasacion = objetoSbp.MontoTasacion,
                            FechaTasacionString = objetoSbp.FechaTasacionString,
                            PartidaBien = objetoSbp.PartidaBien,
                            PorcentajeBien = objetoSbp.PorcentajeBien,
                            DescripcionBien = objetoSbp.DescripcionBien,
                            TipoBien =objetoSbp.TipoBien,
                            ValorComercial = objetoSbp.ValorComercial,
                            CiudadBien = objetoSbp.CiudadBien,
                            DistritoBien = objetoSbp.DistritoBien,
                            MarcaBien = objetoSbp.MarcaBien,
                            ModeloBien = objetoSbp.ModeloBien,
                            
                            EstadoProcesal = objetoSbp.EstadoProcesal,
                            FechaEstadoProcesalString = objetoSbp.FechaEstadoProcesalString,
                            TareaJudicial = objetoSbp.TareaJudicial,
                            FechaTareaAdministrativaString = objetoSbp.FechaTareaAdministrativaString,
                            Incidencia = objetoSbp.Incidencia,
                            DetalleIncidencia = objetoSbp.DetalleIncidencia,
                            TareaAdministrativa = objetoSbp.TareaAdministrativa,
                            
                            TipoSolucionPagos = objetoSbp.TipoSolucionPagos,
                            SaldoPagos = objetoSbp.SaldoPagos,
                            ComisionesPagos = objetoSbp.ComisionesPagos,
                            FechaPagoString = objetoSbp.FechaPagoString,
                            
                            FechaEstimadaString = objetoSbp.FechaEstimadaString,
                            Devuelto = objetoSbp.Devuelto,
                            MotivoDevolucion = objetoSbp.MotivoDevolucion,
                            TelefonoProyeccion = objetoSbp.TelefonoProyeccion,
                            HistoricoProceso = objetoSbp.HistoricoProceso,
                            HistoricoLlamada = objetoSbp.HistoricoLlamada,
                            HistoricoCampo = objetoSbp.HistoricoCampo,
                            Inubicable = objetoSbp.Inubicable


                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;   
        }
        public List<C_SBPFinal> ReporteCompletoAbogadosCuentaBT(string codigo)
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT 	NOMBRE_DISTRITO, '|' || DOI_CLIENTE as DOI_CLIENTE, NOMBRE_COMPLETO, NOMBRE_CONYUGE, DOMICILIO_PERSONA, DIRECCION_ALTERNA, REPRESENTANTE, NUMERO, CONVENIO_PERSONA, '|' || CUENTA_BT AS CUENTA_BT, '|' || OPERACION AS OPERACION,NOMBRE_CARTERA, NOMBRE_MONEDA, NOMBRE_CIUDAD,NOMBRE_ESTUDIO,NOMBRE_TRAMITE, NOMBRE_MODELO, CASTIGOS, CDR, CAPITAL, FECHA_PROTESTO, OBSERVACION_TRAMITE, FECHA_TRAMITE, AGENCIA, FECHA_ASIGNACION, MONTO_ADMITIDO, PRODUCTO_MODULO, EJECUTIVO, NOMBRE_GARANTE, CONYUGE_GARANTE, DISTRITO, DOMICILIO,NUM_EXPEDIENTE, NOMBRE_PROCESO,NOMBRE_ABOGADO,NOMBRE_RESPONSABLE, TRABAJADOR_SECRETARIO, NUM_EXPEDIENTE_22DIGITOS, JUZGADO, CODIGO_CAUTELAR, NUM_JUZGADO, NOMBRE_MACROETAPA,NOMBRE_MICROETAPA,NOMBRE_MEDIDACAUTELAR, TIEMPO, FECHA_ETAPA, FECHA_INSCRIPCION, ESTADO_CAUTELAR, FECHA_MEDIDA_CAUTELAR, VIGENCIA_MC, FECHA_ACTUADO_CAUTELAR, DEVOLUCION_CEDULA, FECHA_MANDATO, FECHA_CONTRADICCION, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA, FECHA_DEMANDA, FECHA_AUTO_FINAL, FECHA_APELACION, NOMBRE_RANGO, BIEN_NOMBRE, MONTO_GARANTIA_BIEN, MONTO_TASACION_BIEN, FECHA_tASACION_BIEN, PARTIDA_BIEN, PORCENTAJE_BIEN, DESCRIPCION_BIEN, TIPO_BIEN, VALOR_BIEN, BIEN_CIUDAD, BIEN_DISTRITO, MARCA_BIEN, MODELO_BIEN, ESTADO_PROCESAL, FECHA_eSTADO_PROCESAL, TAREA_JUDICIAL, FECHA_TAREA_ADMINISTRATIVA, INCIDENCIA, DETALLE_INCIDENCIA, TAREA_ADMINISTRATIVA,SOLUCION, SALDO_PAGO, COMISIONES, FECHA,FECHA_ESTIMADA, DEVUELTO, MOTIVO_DEVOLUCION,TELEFONO,	TEXTO_PROCESO, TEXTO_LLAMADA, TEXTO_CAMPO, INUBICABLE_CAMPO FROM VW_REPORTE_COMPLETO WHERE CUENTA_BT ='" +codigo +"';", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        // TITULAR
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //DISTRITO - TITULAR
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.DistritoTitular = " ";
                        }
                        else
                        {
                            objetoSbp.DistritoTitular = rd.GetString(0);
                        }
                        //DOI - TITULAR
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Doi_cliente = rd.GetString(1);
                        }
                        //NOMBRE - TITULAR
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(2);
                        }
                        //CONYUGE - TITULAR
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.NombreConyuge = " ";
                        }
                        else
                        {
                            objetoSbp.NombreConyuge = rd.GetString(3);
                        }
                        //DOMICILIO - TITULAR
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.DomicilioTitular = " ";
                        }
                        else
                        {
                            objetoSbp.DomicilioTitular = rd.GetString(4);
                        }

                        //DIRECCION ALTERNA - TITULAR
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.DireccionAlterna = " ";
                        }
                        else
                        {
                            objetoSbp.DireccionAlterna = rd.GetString(5);
                        }
                        //REPRESENTANTE - TITULAR
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Representante = " ";
                        }
                        else
                        {
                            objetoSbp.Representante = rd.GetString(6);
                        }
                        //TELEFONO - TITULAR
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.TelefonoPersona = " ";
                        }
                        else
                        {
                            objetoSbp.TelefonoPersona = rd.GetString(7);
                        }
                        //CONVENIO - TITULAR
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.ConvenioTitular = " ";
                        }
                        else
                        {
                            objetoSbp.ConvenioTitular = rd.GetString(8);
                        }
                        //CUENTA BT - TITULAR
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(9);
                        }


                        // CRÉDITO
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //OPERACION - CREDITO
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(10);
                        }
                        //CARTERA - CREDITO
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.NombreCartera = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCartera = rd.GetString(11);
                        }
                        //MONEDA - CREDITO
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(12);
                        }
                        //CIUDAD - CREDITO
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.NombreCiudadEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCiudadEstudio = rd.GetString(13);
                        }
                        //ESTUDIO - CREDITO
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreEstudio = rd.GetString(14);
                        }
                        //TRAMITE - CREDITO
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.NombreTramite = " ";
                        }
                        else
                        {
                            objetoSbp.NombreTramite = rd.GetString(15);
                        }
                        //MODELO - CREDITO
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.NombreModelo = " ";
                        }
                        else
                        {
                            objetoSbp.NombreModelo = rd.GetString(16);
                        }
                        //CASTIGOS - CREDITO
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.Castigos = " ";
                        }
                        else
                        {
                            objetoSbp.Castigos = rd.GetString(17);
                        }
                        //CDR - CREDITO
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.Cdr = " ";
                        }
                        else
                        {
                            objetoSbp.Cdr = rd.GetString(18);
                        }
                        //CAPITAL - CREDITO
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.Capital = " ";
                        }
                        else
                        {
                            objetoSbp.Capital = rd.GetString(19);
                        }
                        //FECHA PROTESTO - CREDITO
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaProtestoString = " ";
                        }
                        else if (rd.GetDateTime(20) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaProtestoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaProtestoString = "" + rd.GetDateTime(20).ToShortDateString();
                        }
                        //OBSERVACION TRAMITE - CREDITO
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.Observacion = " ";
                        }
                        else
                        {
                            objetoSbp.Observacion = rd.GetString(21);
                        }
                        //FECHA TRAMITE - CREDITO
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.FechaTramiteString = " ";
                        }
                        else if (rd.GetDateTime(22) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaTramiteString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaTramiteString = "" + rd.GetDateTime(22).ToShortDateString();
                        }
                        //AGENCIA - CREDITO
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.Agencia = " ";
                        }
                        else
                        {
                            objetoSbp.Agencia = rd.GetString(23);
                        }
                        //FECHA ASIGNACION - CREDITO
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaAsignacionString = " ";
                        }
                        else if (rd.GetDateTime(24) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAsignacionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAsignacionString = "" + rd.GetDateTime(24).ToShortDateString();
                        }
                        //MONTO ADMITIDO - CREDITO
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.MontoAdmitido = " ";
                        }
                        else
                        {
                            objetoSbp.MontoAdmitido = rd.GetString(25);
                        }
                        //PRODUCTO O MODULO - CREDITO
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.ProductoModulo = " ";
                        }
                        else
                        {
                            objetoSbp.ProductoModulo = rd.GetString(26);
                        }
                        //EJECUTIVO - CREDITO
                        if (rd[27] == DBNull.Value)
                        {
                            objetoSbp.Ejecutivo = " ";
                        }
                        else
                        {
                            objetoSbp.Ejecutivo = rd.GetString(27);
                        }


                        // GARANTE
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //NOMBRE - GARANTE
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.NombreGarante = " ";
                        }
                        else
                        {
                            objetoSbp.NombreGarante = rd.GetString(28);
                        }
                        //CONYUGE - GARANTE
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.ConyugeGarante = " ";
                        }
                        else
                        {
                            objetoSbp.ConyugeGarante = rd.GetString(29);
                        }
                        //DISTRITO - GARANTE
                        if (rd[30] == DBNull.Value)
                        {
                            objetoSbp.DistritoGarante = " ";
                        }
                        else
                        {
                            objetoSbp.DistritoGarante = rd.GetString(30);
                        }
                        //DOMICILIO - GARANTE
                        if (rd[31] == DBNull.Value)
                        {
                            objetoSbp.DomicilioGarante = " ";
                        }
                        else
                        {
                            objetoSbp.DomicilioGarante = rd.GetString(31);
                        }

                        // EXPEDIENTE
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //NUM EXPEDIENTE - EXPEDIENTE
                        if (rd[32] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(32);
                        }
                        //NOMBRE PROCESO - EXPEDIENTE
                        if (rd[33] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(33);
                        }
                        //ABOGADO - EXPEDIENTE
                        if (rd[34] == DBNull.Value)
                        {
                            objetoSbp.Abogado = " ";
                        }
                        else
                        {
                            objetoSbp.Abogado = rd.GetString(34);
                        }
                        //RESPONSABLE - EXPEDIENTE
                        if (rd[35] == DBNull.Value)
                        {
                            objetoSbp.Responsable = " ";
                        }
                        else
                        {
                            objetoSbp.Responsable = rd.GetString(35);
                        }
                        //SECRETARIO - EXPEDIENTE
                        if (rd[36] == DBNull.Value)
                        {
                            objetoSbp.Secretario = " ";
                        }
                        else
                        {
                            objetoSbp.Secretario = rd.GetString(36);
                        }
                        //NUM EXPEDIENTE 22 DIGITOS - EXPEDIENTE
                        if (rd[37] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente22 = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente22 = rd.GetString(37);
                        }
                        //JUZGADO - EXPEDIENTE
                        if (rd[38] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(38);
                        }
                        //CODIGO CAUTELAR - EXPEDIENTE
                        if (rd[39] == DBNull.Value)
                        {
                            objetoSbp.CodigoCautelar = " ";
                        }
                        else
                        {
                            objetoSbp.CodigoCautelar = rd.GetString(39);
                        }
                        //NUM JUZGADO - EXPEDIENTE
                        if (rd[40] == DBNull.Value)
                        {
                            objetoSbp.NumJuzgado = " ";
                        }
                        else
                        {
                            objetoSbp.NumJuzgado = rd.GetString(40);
                        }


                        // PROCESO
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //MACRO ETAPA - PROCESO
                        if (rd[41] == DBNull.Value)
                        {
                            objetoSbp.Macroetapa = " ";
                        }
                        else
                        {
                            objetoSbp.Macroetapa = rd.GetString(41);
                        }
                        //MICRO ETAPA - PROCESO
                        if (rd[42] == DBNull.Value)
                        {
                            objetoSbp.Microetapa = " ";
                        }
                        else
                        {
                            objetoSbp.Microetapa = rd.GetString(42);
                        }
                        //MEDIDA CAUTELAR - PROCESO
                        if (rd[43] == DBNull.Value)
                        {
                            objetoSbp.MedidaCautelar = " ";
                        }
                        else
                        {
                            objetoSbp.MedidaCautelar = rd.GetString(43);
                        }
                        //INCIDENCIA SULLANA - PROCESO
                        if (rd[44] == DBNull.Value)
                        {
                            objetoSbp.IncidenciaSullana = " ";
                        }
                        else
                        {
                            objetoSbp.IncidenciaSullana = rd.GetString(44);
                        }
                        //FECHA ETAPA - PROCESO
                        if (rd[45] == DBNull.Value)
                        {
                            objetoSbp.FechaEtapaProcesoString = " ";
                        }
                        else if (rd.GetDateTime(45) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEtapaProcesoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEtapaProcesoString = "" + rd.GetDateTime(45).ToShortDateString();
                        }
                        //FECHA INSCRIPCION - PROCESO
                        if (rd[46] == DBNull.Value)
                        {
                            objetoSbp.FechaInscripcionString = " ";
                        }
                        else if (rd.GetDateTime(46) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaInscripcionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaInscripcionString = "" + rd.GetDateTime(46).ToShortDateString();
                        }
                        //ESTADO CAUTELAR - PROCESO
                        if (rd[47] == DBNull.Value)
                        {
                            objetoSbp.EstadoCautelar = " ";
                        }
                        else
                        {
                            objetoSbp.EstadoCautelar = rd.GetString(47);
                        }
                        //FECHA MEDIDA CAUTELAR - PROCESO
                        if (rd[48] == DBNull.Value)
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else if (rd.GetDateTime(48) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMCString = "" + rd.GetDateTime(48).ToShortDateString();
                        }
                        //VIGENCIA MC - PROCESO
                        if (rd[49] == DBNull.Value)
                        {
                            objetoSbp.VigenciaMC = " ";
                        }
                        else
                        {
                            objetoSbp.VigenciaMC = rd.GetString(49);
                        }
                        //FECHA ACTUADO CAUTELAR - PROCESO
                        if (rd[50] == DBNull.Value)
                        {
                            objetoSbp.FechaActuadoCautelarString = " ";
                        }
                        else if (rd.GetDateTime(50) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaActuadoCautelarString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaActuadoCautelarString = "" + rd.GetDateTime(50).ToShortDateString();
                        }
                        //DEVOLUCION DE CEDULA - PROCESO
                        if (rd[51] == DBNull.Value)
                        {
                            objetoSbp.Devolucion = " ";
                        }
                        else
                        {
                            objetoSbp.Devolucion = rd.GetString(51);
                        }

                        // FECHAS
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //FECHA MANDATO - FECHAS
                        if (rd[52] == DBNull.Value)
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else if (rd.GetDateTime(52) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMandatoString = "" + rd.GetDateTime(52).ToShortDateString();
                        }
                        //FECHA CONTRADICCION - FECHAS
                        if (rd[53] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else if (rd.GetDateTime(53) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaContradiccionString = "" + rd.GetDateTime(53).ToShortDateString();
                        }
                        //FECHA ORDEN - FECHAS
                        if (rd[54] == DBNull.Value)
                        {
                            objetoSbp.FechaOrdenRemateIncautacion = " ";
                        }
                        else if (rd.GetDateTime(54) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaOrdenRemateIncautacion = " ";
                        }
                        else
                        {
                            objetoSbp.FechaOrdenRemateIncautacion = "" + rd.GetDateTime(54).ToShortDateString();
                        }
                        //FECHA REMATE CAPTURA - FECHAS
                        if (rd[55] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateOrdenCaptura = " ";
                        }
                        else if (rd.GetDateTime(55) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaRemateOrdenCaptura = " ";
                        }
                        else
                        {
                            objetoSbp.FechaRemateOrdenCaptura = "" + rd.GetDateTime(55).ToShortDateString();
                        }
                        //FECHA ADJU CAPTURA - FECHAS
                        if (rd[56] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else if (rd.GetDateTime(56) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAdjucapturaString = "" + rd.GetDateTime(56).ToShortDateString();
                        }
                        //FECHA DEMANDA - FECHAS
                        if (rd[57] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(57) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(57).ToShortDateString();
                        }
                        //FECHA AUTO FINAL - FECHAS
                        if (rd[58] == DBNull.Value)
                        {
                            objetoSbp.FechaAutoFinalString = " ";
                        }
                        else if (rd.GetDateTime(58) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAutoFinalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAutoFinalString = "" + rd.GetDateTime(58).ToShortDateString();
                        }
                        //FECHA APELACION - FECHAS
                        if (rd[59] == DBNull.Value)
                        {
                            objetoSbp.FechaApelacionString = " ";
                        }
                        else if (rd.GetDateTime(59) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaApelacionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaApelacionString = "" + rd.GetDateTime(59).ToShortDateString();
                        }


                        // BIEN
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //NOMBRE RANGO - BIEN
                        if (rd[60] == DBNull.Value)
                        {
                            objetoSbp.Rango = " ";
                        }
                        else
                        {
                            objetoSbp.Rango = rd.GetString(60);
                        }
                        //NOMBRE BIEN - BIEN
                        if (rd[61] == DBNull.Value)
                        {
                            objetoSbp.NombreBien = " ";
                        }
                        else
                        {
                            objetoSbp.NombreBien = rd.GetString(61);
                        }
                        //MONTO GARANTIA - BIEN
                        if (rd[62] == DBNull.Value)
                        {
                            objetoSbp.MontoGarantia = " ";
                        }
                        else
                        {
                            objetoSbp.MontoGarantia = rd.GetString(62);
                        }
                        //MONTO TASACION - BIEN
                        if (rd[63] == DBNull.Value)
                        {
                            objetoSbp.MontoTasacion = " ";
                        }
                        else
                        {
                            objetoSbp.MontoTasacion = rd.GetString(63);
                        }
                        //FECHA TASACION - BIEN
                        if (rd[64] == DBNull.Value)
                        {
                            objetoSbp.FechaTasacionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaTasacionString = rd.GetString(64);
                        }
                        //PARTIDA PLACA - BIEN
                        if (rd[65] == DBNull.Value)
                        {
                            objetoSbp.PartidaBien = " ";
                        }
                        else
                        {
                            objetoSbp.PartidaBien = rd.GetString(65);
                        }
                        //PORCENTAJE - BIEN
                        if (rd[66] == DBNull.Value)
                        {
                            objetoSbp.PorcentajeBien = " ";
                        }
                        else
                        {
                            objetoSbp.PorcentajeBien = rd.GetString(66);
                        }
                        //DESCRIPCION - BIEN
                        if (rd[67] == DBNull.Value)
                        {
                            objetoSbp.DescripcionBien = " ";
                        }
                        else
                        {
                            objetoSbp.DescripcionBien = rd.GetString(67);
                        }
                        //TIPO BIEN - BIEN
                        if (rd[68] == DBNull.Value)
                        {
                            objetoSbp.TipoBien = " ";
                        }
                        else
                        {
                            objetoSbp.TipoBien = rd.GetString(68);
                        }
                        //VALOR COMERCIAL - BIEN
                        if (rd[69] == DBNull.Value)
                        {
                            objetoSbp.ValorComercial = " ";
                        }
                        else
                        {
                            objetoSbp.ValorComercial = rd.GetString(69);
                        }
                        //CIUDAD - BIEN
                        if (rd[70] == DBNull.Value)
                        {
                            objetoSbp.CiudadBien = " ";
                        }
                        else
                        {
                            objetoSbp.CiudadBien = rd.GetString(70);
                        }
                        //DISTRITO - BIEN
                        if (rd[71] == DBNull.Value)
                        {
                            objetoSbp.DistritoBien = " ";
                        }
                        else
                        {
                            objetoSbp.DistritoBien = rd.GetString(71);
                        }
                        //MARCA - BIEN
                        if (rd[72] == DBNull.Value)
                        {
                            objetoSbp.MarcaBien = " ";
                        }
                        else
                        {
                            objetoSbp.MarcaBien = rd.GetString(72);
                        }
                        //MODELO - BIEN
                        if (rd[73] == DBNull.Value)
                        {
                            objetoSbp.ModeloBien = " ";
                        }
                        else
                        {
                            objetoSbp.ModeloBien = rd.GetString(73);
                        }

                        // SEGUIMIENTO
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //ESTADO PROCESAL - SEGUIMIENTO
                        if (rd[74] == DBNull.Value)
                        {
                            objetoSbp.EstadoProcesal = " ";
                        }
                        else
                        {
                            objetoSbp.EstadoProcesal = rd.GetString(74);
                        }
                        //FECHA ESTADO PROCESAL - SEGUIMIENTO
                        if (rd[75] == DBNull.Value)
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else if (rd.GetDateTime(75) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEstadoProcesalString = "" + rd.GetDateTime(75).ToShortDateString();
                        }
                        //TAREA JUDICIAL - SEGUIMIENTO
                        if (rd[76] == DBNull.Value)
                        {
                            objetoSbp.TareaJudicial = " ";
                        }
                        else
                        {
                            objetoSbp.TareaJudicial = rd.GetString(76);
                        }
                        //FECHA TAREA ADMINISTRATIVA - SEGUIMIENTO
                        if (rd[77] == DBNull.Value)
                        {
                            objetoSbp.FechaTareaAdministrativaString = " ";
                        }
                        else if (rd.GetDateTime(77) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaTareaAdministrativaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaTareaAdministrativaString = "" + rd.GetDateTime(77).ToShortDateString();
                        }
                        //INCIDENCIA - SEGUIMIENTO
                        if (rd[78] == DBNull.Value)
                        {
                            objetoSbp.Incidencia = " ";
                        }
                        else
                        {
                            objetoSbp.Incidencia = rd.GetString(78);
                        }
                        //DETALLE INCIDENCIA - SEGUIMIENTO
                        if (rd[79] == DBNull.Value)
                        {
                            objetoSbp.DetalleIncidencia = " ";
                        }
                        else
                        {
                            objetoSbp.DetalleIncidencia = rd.GetString(79);
                        }
                        //TAREA ADMINISTRATIVA - SEGUIMIENTO
                        if (rd[80] == DBNull.Value)
                        {
                            objetoSbp.TareaAdministrativa = " ";
                        }
                        else
                        {
                            objetoSbp.TareaAdministrativa = rd.GetString(80);
                        }

                        // PAGOS
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //SOLUCION - PAGOS
                        if (rd[81] == DBNull.Value)
                        {
                            objetoSbp.TipoSolucionPagos = " ";
                        }
                        else
                        {
                            objetoSbp.TipoSolucionPagos = rd.GetString(81);
                        }
                        //SALDO - PAGOS
                        if (rd[82] == DBNull.Value)
                        {
                            objetoSbp.SaldoPagos = " ";
                        }
                        else
                        {
                            objetoSbp.SaldoPagos = rd.GetString(82);
                        }
                        //COMISION - PAGOS
                        if (rd[83] == DBNull.Value)
                        {
                            objetoSbp.ComisionesPagos = " ";
                        }
                        else
                        {
                            objetoSbp.ComisionesPagos = rd.GetString(83);
                        }
                        //FECHA PAGOS - PAGOS
                        if (rd[84] == DBNull.Value)
                        {
                            objetoSbp.FechaPagoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaPagoString = rd.GetString(84);
                        }


                        // PROYECCION
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //FECHA ESTIMADA - PROYECCION
                        if (rd[85] == DBNull.Value)
                        {
                            objetoSbp.FechaEstimadaString = " ";
                        }
                        else if (rd.GetDateTime(85) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEstimadaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEstimadaString = "" + rd.GetDateTime(85).ToShortDateString();
                        }
                        //DEVUELTO - PROYECCION
                        if (rd[86] == DBNull.Value)
                        {
                            objetoSbp.Devuelto = " ";
                        }
                        else
                        {
                            objetoSbp.Devuelto = rd.GetString(86);
                        }
                        //MOTIVO DEVOLUCION - PROYECCION
                        if (rd[87] == DBNull.Value)
                        {
                            objetoSbp.MotivoDevolucion = " ";
                        }
                        else
                        {
                            objetoSbp.MotivoDevolucion = rd.GetString(87);
                        }
                        //TELEFONO - PROYECCION
                        if (rd[88] == DBNull.Value)
                        {
                            objetoSbp.TelefonoProyeccion = " ";
                        }
                        else
                        {
                            objetoSbp.TelefonoProyeccion = rd.GetString(88);
                        }
                        // HISTORICO
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //PROCESO - HISTORICO
                        if (rd[89] == DBNull.Value)
                        {
                            objetoSbp.HistoricoProceso = " ";
                        }
                        else
                        {
                            objetoSbp.HistoricoProceso = rd.GetString(89);
                        }
                        //LLAMADA - HISTORICO
                        if (rd[90] == DBNull.Value)
                        {
                            objetoSbp.HistoricoLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.HistoricoLlamada = rd.GetString(90);
                        }
                        //CAMPO - HISTORICO
                        if (rd[91] == DBNull.Value)
                        {
                            objetoSbp.HistoricoCampo = " ";
                        }
                        else
                        {
                            objetoSbp.HistoricoCampo = rd.GetString(91);
                        }
                        //  GESTION CAMPO
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //INUBICABLE - GESTION CAMPO
                        if (rd[92] == DBNull.Value)
                        {
                            objetoSbp.Inubicable = " ";
                        }
                        else
                        {
                            objetoSbp.Inubicable = rd.GetString(92);
                        }

                        lista.Add(new C_SBPFinal
                        {
                            DistritoTitular = objetoSbp.DistritoTitular,
                            Doi_cliente = objetoSbp.Doi_cliente,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            NombreConyuge = objetoSbp.NombreConyuge,
                            DomicilioTitular = objetoSbp.DomicilioTitular,
                            DireccionAlterna = objetoSbp.DireccionAlterna,
                            Representante = objetoSbp.Representante,
                            TelefonoPersona = objetoSbp.TelefonoPersona,
                            ConvenioTitular = objetoSbp.ConvenioTitular,
                            Cuenta_bt = objetoSbp.Cuenta_bt,

                            Operacion = objetoSbp.Operacion,
                            NombreCartera = objetoSbp.NombreCartera,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            NombreCiudadEstudio = objetoSbp.NombreCiudadEstudio,
                            NombreEstudio = objetoSbp.NombreEstudio,
                            NombreTramite = objetoSbp.NombreTramite,
                            NombreModelo = objetoSbp.NombreModelo,
                            Castigos = objetoSbp.Castigos,
                            Cdr = objetoSbp.Cdr,
                            Capital = objetoSbp.Capital,
                            FechaProtestoString = objetoSbp.FechaProtestoString,
                            Observacion = objetoSbp.Observacion,
                            FechaTramiteString = objetoSbp.FechaTramiteString,
                            Agencia = objetoSbp.Agencia,
                            FechaAsignacionString = objetoSbp.FechaAsignacionString,
                            MontoAdmitido = objetoSbp.MontoAdmitido,
                            ProductoModulo = objetoSbp.ProductoModulo,
                            Ejecutivo = objetoSbp.Ejecutivo,

                            NombreGarante = objetoSbp.NombreGarante,
                            ConyugeGarante = objetoSbp.ConyugeGarante,
                            DistritoGarante = objetoSbp.DistritoGarante,
                            DomicilioGarante = objetoSbp.DomicilioGarante,

                            NumExpediente = objetoSbp.NumExpediente,
                            NombreProceso = objetoSbp.NombreProceso,
                            Abogado = objetoSbp.Abogado,
                            Responsable = objetoSbp.Responsable,
                            Secretario = objetoSbp.Secretario,
                            NumExpediente22 = objetoSbp.NumExpediente22,
                            Juzgado = objetoSbp.Juzgado,
                            CodigoCautelar = objetoSbp.CodigoCautelar,
                            NumJuzgado = objetoSbp.NumJuzgado,

                            Macroetapa = objetoSbp.Macroetapa,
                            Microetapa = objetoSbp.Microetapa,
                            MedidaCautelar = objetoSbp.MedidaCautelar,
                            IncidenciaSullana = objetoSbp.IncidenciaSullana,
                            FechaEtapaProcesoString = objetoSbp.FechaEtapaProcesoString,
                            FechaInscripcionString = objetoSbp.FechaInscripcionString,
                            EstadoCautelar = objetoSbp.EstadoCautelar,
                            FechaMCString = objetoSbp.FechaMCString,
                            VigenciaMC = objetoSbp.VigenciaMC,
                            FechaActuadoCautelarString = objetoSbp.FechaActuadoCautelarString,
                            Devolucion = objetoSbp.Devolucion,

                            FechaMandatoString = objetoSbp.FechaMandatoString,
                            FechaContradiccionString = objetoSbp.FechaContradiccionString,
                            FechaOrdenRemateIncautacion = objetoSbp.FechaOrdenRemateIncautacion,
                            FechaRemateOrdenCaptura = objetoSbp.FechaRemateOrdenCaptura,
                            FechaAdjucapturaString = objetoSbp.FechaAdjucapturaString,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            FechaAutoFinalString = objetoSbp.FechaAutoFinalString,
                            FechaApelacionString = objetoSbp.FechaApelacionString,

                            Rango = objetoSbp.Rango,
                            NombreBien = objetoSbp.NombreBien,
                            MontoGarantia = objetoSbp.MontoGarantia,
                            MontoTasacion = objetoSbp.MontoTasacion,
                            FechaTasacionString = objetoSbp.FechaTasacionString,
                            PartidaBien = objetoSbp.PartidaBien,
                            PorcentajeBien = objetoSbp.PorcentajeBien,
                            DescripcionBien = objetoSbp.DescripcionBien,
                            TipoBien = objetoSbp.TipoBien,
                            ValorComercial = objetoSbp.ValorComercial,
                            CiudadBien = objetoSbp.CiudadBien,
                            DistritoBien = objetoSbp.DistritoBien,
                            MarcaBien = objetoSbp.MarcaBien,
                            ModeloBien = objetoSbp.ModeloBien,

                            EstadoProcesal = objetoSbp.EstadoProcesal,
                            FechaEstadoProcesalString = objetoSbp.FechaEstadoProcesalString,
                            TareaJudicial = objetoSbp.TareaJudicial,
                            FechaTareaAdministrativaString = objetoSbp.FechaTareaAdministrativaString,
                            Incidencia = objetoSbp.Incidencia,
                            DetalleIncidencia = objetoSbp.DetalleIncidencia,
                            TareaAdministrativa = objetoSbp.TareaAdministrativa,

                            TipoSolucionPagos = objetoSbp.TipoSolucionPagos,
                            SaldoPagos = objetoSbp.SaldoPagos,
                            ComisionesPagos = objetoSbp.ComisionesPagos,
                            FechaPagoString = objetoSbp.FechaPagoString,

                            FechaEstimadaString = objetoSbp.FechaEstimadaString,
                            Devuelto = objetoSbp.Devuelto,
                            MotivoDevolucion = objetoSbp.MotivoDevolucion,
                            TelefonoProyeccion = objetoSbp.TelefonoProyeccion,
                            HistoricoProceso = objetoSbp.HistoricoProceso,
                            HistoricoLlamada = objetoSbp.HistoricoLlamada,
                            HistoricoCampo = objetoSbp.HistoricoCampo,
                            Inubicable = objetoSbp.Inubicable


                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_SBPFinal> ReporteCompletoAbogadosTramiteCartera(int codigoCartera, int codigoTramite) 
        {
            List<C_SBPFinal> lista = new List<C_SBPFinal>();
            C_SBPFinal objetoSbp = new C_SBPFinal();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT 	NOMBRE_DISTRITO, '|' || DOI_CLIENTE as DOI_CLIENTE, NOMBRE_COMPLETO, NOMBRE_CONYUGE, DOMICILIO_PERSONA, DIRECCION_ALTERNA, REPRESENTANTE, NUMERO, CONVENIO_PERSONA, '|' || CUENTA_BT AS CUENTA_BT, '|' || OPERACION AS OPERACION,NOMBRE_CARTERA, NOMBRE_MONEDA, NOMBRE_CIUDAD,NOMBRE_ESTUDIO,NOMBRE_TRAMITE, NOMBRE_MODELO, CASTIGOS, CDR, CAPITAL, FECHA_PROTESTO, OBSERVACION_TRAMITE, FECHA_TRAMITE, AGENCIA, FECHA_ASIGNACION, MONTO_ADMITIDO, PRODUCTO_MODULO, EJECUTIVO, NOMBRE_GARANTE, CONYUGE_GARANTE, DISTRITO, DOMICILIO,NUM_EXPEDIENTE, NOMBRE_PROCESO,NOMBRE_ABOGADO,NOMBRE_RESPONSABLE, TRABAJADOR_SECRETARIO, NUM_EXPEDIENTE_22DIGITOS, JUZGADO, CODIGO_CAUTELAR, NUM_JUZGADO, NOMBRE_MACROETAPA,NOMBRE_MICROETAPA,NOMBRE_MEDIDACAUTELAR, TIEMPO, FECHA_ETAPA, FECHA_INSCRIPCION, ESTADO_CAUTELAR, FECHA_MEDIDA_CAUTELAR, VIGENCIA_MC, FECHA_ACTUADO_CAUTELAR, DEVOLUCION_CEDULA, FECHA_MANDATO, FECHA_CONTRADICCION, FECHA_ORDEN, FECHA_REMATECAPTURA, FECHA_ADJUCAPTURA, FECHA_DEMANDA, FECHA_AUTO_FINAL, FECHA_APELACION, NOMBRE_RANGO, BIEN_NOMBRE, MONTO_GARANTIA_BIEN, MONTO_TASACION_BIEN, FECHA_tASACION_BIEN, PARTIDA_BIEN, PORCENTAJE_BIEN, DESCRIPCION_BIEN, TIPO_BIEN, VALOR_BIEN, BIEN_CIUDAD, BIEN_DISTRITO, MARCA_BIEN, MODELO_BIEN, ESTADO_PROCESAL, FECHA_eSTADO_PROCESAL, TAREA_JUDICIAL, FECHA_TAREA_ADMINISTRATIVA, INCIDENCIA, DETALLE_INCIDENCIA, TAREA_ADMINISTRATIVA,SOLUCION, SALDO_PAGO, COMISIONES, FECHA,FECHA_ESTIMADA, DEVUELTO, MOTIVO_DEVOLUCION,TELEFONO,	TEXTO_PROCESO, TEXTO_LLAMADA, TEXTO_CAMPO, INUBICABLE_CAMPO FROM VW_REPORTE_COMPLETO WHERE CODIGO_TRAMITE = "+codigoTramite+" AND CODIGO_CARTERA = "+codigoCartera+ ";", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        // TITULAR
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //DISTRITO - TITULAR
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.DistritoTitular = " ";
                        }
                        else
                        {
                            objetoSbp.DistritoTitular = rd.GetString(0);
                        }
                        //DOI - TITULAR
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Doi_cliente = rd.GetString(1);
                        }
                        //NOMBRE - TITULAR
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Nombre_cliente = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_cliente = rd.GetString(2);
                        }
                        //CONYUGE - TITULAR
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.NombreConyuge = " ";
                        }
                        else
                        {
                            objetoSbp.NombreConyuge = rd.GetString(3);
                        }
                        //DOMICILIO - TITULAR
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.DomicilioTitular = " ";
                        }
                        else
                        {
                            objetoSbp.DomicilioTitular = rd.GetString(4);
                        }

                        //DIRECCION ALTERNA - TITULAR
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.DireccionAlterna = " ";
                        }
                        else
                        {
                            objetoSbp.DireccionAlterna = rd.GetString(5);
                        }
                        //REPRESENTANTE - TITULAR
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Representante = " ";
                        }
                        else
                        {
                            objetoSbp.Representante = rd.GetString(6);
                        }
                        //TELEFONO - TITULAR
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.TelefonoPersona = " ";
                        }
                        else
                        {
                            objetoSbp.TelefonoPersona = rd.GetString(7);
                        }
                        //CONVENIO - TITULAR
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSbp.ConvenioTitular = " ";
                        }
                        else
                        {
                            objetoSbp.ConvenioTitular = rd.GetString(8);
                        }
                        //CUENTA BT - TITULAR
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(9);
                        }


                        // CRÉDITO
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //OPERACION - CREDITO
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.Operacion = " ";
                        }
                        else
                        {
                            objetoSbp.Operacion = rd.GetString(10);
                        }
                        //CARTERA - CREDITO
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.NombreCartera = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCartera = rd.GetString(11);
                        }
                        //MONEDA - CREDITO
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSbp.NombreMoneda = " ";
                        }
                        else
                        {
                            objetoSbp.NombreMoneda = rd.GetString(12);
                        }
                        //CIUDAD - CREDITO
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.NombreCiudadEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreCiudadEstudio = rd.GetString(13);
                        }
                        //ESTUDIO - CREDITO
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.NombreEstudio = " ";
                        }
                        else
                        {
                            objetoSbp.NombreEstudio = rd.GetString(14);
                        }
                        //TRAMITE - CREDITO
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.NombreTramite = " ";
                        }
                        else
                        {
                            objetoSbp.NombreTramite = rd.GetString(15);
                        }
                        //MODELO - CREDITO
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.NombreModelo = " ";
                        }
                        else
                        {
                            objetoSbp.NombreModelo = rd.GetString(16);
                        }
                        //CASTIGOS - CREDITO
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.Castigos = " ";
                        }
                        else
                        {
                            objetoSbp.Castigos = rd.GetString(17);
                        }
                        //CDR - CREDITO
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.Cdr = " ";
                        }
                        else
                        {
                            objetoSbp.Cdr = rd.GetString(18);
                        }
                        //CAPITAL - CREDITO
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.Capital = " ";
                        }
                        else
                        {
                            objetoSbp.Capital = rd.GetString(19);
                        }
                        //FECHA PROTESTO - CREDITO
                        if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.FechaProtestoString = " ";
                        }
                        else if (rd.GetDateTime(20) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaProtestoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaProtestoString = "" + rd.GetDateTime(20).ToShortDateString();
                        }
                        //OBSERVACION TRAMITE - CREDITO
                        if (rd[21] == DBNull.Value)
                        {
                            objetoSbp.Observacion = " ";
                        }
                        else
                        {
                            objetoSbp.Observacion = rd.GetString(21);
                        }
                        //FECHA TRAMITE - CREDITO
                        if (rd[22] == DBNull.Value)
                        {
                            objetoSbp.FechaTramiteString = " ";
                        }
                        else if (rd.GetDateTime(22) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaTramiteString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaTramiteString = "" + rd.GetDateTime(22).ToShortDateString();
                        }
                        //AGENCIA - CREDITO
                        if (rd[23] == DBNull.Value)
                        {
                            objetoSbp.Agencia = " ";
                        }
                        else
                        {
                            objetoSbp.Agencia = rd.GetString(23);
                        }
                        //FECHA ASIGNACION - CREDITO
                        if (rd[24] == DBNull.Value)
                        {
                            objetoSbp.FechaAsignacionString = " ";
                        }
                        else if (rd.GetDateTime(24) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAsignacionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAsignacionString = "" + rd.GetDateTime(24).ToShortDateString();
                        }
                        //MONTO ADMITIDO - CREDITO
                        if (rd[25] == DBNull.Value)
                        {
                            objetoSbp.MontoAdmitido = " ";
                        }
                        else
                        {
                            objetoSbp.MontoAdmitido = rd.GetString(25);
                        }
                        //PRODUCTO O MODULO - CREDITO
                        if (rd[26] == DBNull.Value)
                        {
                            objetoSbp.ProductoModulo = " ";
                        }
                        else
                        {
                            objetoSbp.ProductoModulo = rd.GetString(26);
                        }
                        //EJECUTIVO - CREDITO
                        if (rd[27] == DBNull.Value)
                        {
                            objetoSbp.Ejecutivo = " ";
                        }
                        else
                        {
                            objetoSbp.Ejecutivo = rd.GetString(27);
                        }


                        // GARANTE
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //NOMBRE - GARANTE
                        if (rd[28] == DBNull.Value)
                        {
                            objetoSbp.NombreGarante = " ";
                        }
                        else
                        {
                            objetoSbp.NombreGarante = rd.GetString(28);
                        }
                        //CONYUGE - GARANTE
                        if (rd[29] == DBNull.Value)
                        {
                            objetoSbp.ConyugeGarante = " ";
                        }
                        else
                        {
                            objetoSbp.ConyugeGarante = rd.GetString(29);
                        }
                        //DISTRITO - GARANTE
                        if (rd[30] == DBNull.Value)
                        {
                            objetoSbp.DistritoGarante = " ";
                        }
                        else
                        {
                            objetoSbp.DistritoGarante = rd.GetString(30);
                        }
                        //DOMICILIO - GARANTE
                        if (rd[31] == DBNull.Value)
                        {
                            objetoSbp.DomicilioGarante = " ";
                        }
                        else
                        {
                            objetoSbp.DomicilioGarante = rd.GetString(31);
                        }

                        // EXPEDIENTE
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //NUM EXPEDIENTE - EXPEDIENTE
                        if (rd[32] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente = rd.GetString(32);
                        }
                        //NOMBRE PROCESO - EXPEDIENTE
                        if (rd[33] == DBNull.Value)
                        {
                            objetoSbp.NombreProceso = " ";
                        }
                        else
                        {
                            objetoSbp.NombreProceso = rd.GetString(33);
                        }
                        //ABOGADO - EXPEDIENTE
                        if (rd[34] == DBNull.Value)
                        {
                            objetoSbp.Abogado = " ";
                        }
                        else
                        {
                            objetoSbp.Abogado = rd.GetString(34);
                        }
                        //RESPONSABLE - EXPEDIENTE
                        if (rd[35] == DBNull.Value)
                        {
                            objetoSbp.Responsable = " ";
                        }
                        else
                        {
                            objetoSbp.Responsable = rd.GetString(35);
                        }
                        //SECRETARIO - EXPEDIENTE
                        if (rd[36] == DBNull.Value)
                        {
                            objetoSbp.Secretario = " ";
                        }
                        else
                        {
                            objetoSbp.Secretario = rd.GetString(36);
                        }
                        //NUM EXPEDIENTE 22 DIGITOS - EXPEDIENTE
                        if (rd[37] == DBNull.Value)
                        {
                            objetoSbp.NumExpediente22 = " ";
                        }
                        else
                        {
                            objetoSbp.NumExpediente22 = rd.GetString(37);
                        }
                        //JUZGADO - EXPEDIENTE
                        if (rd[38] == DBNull.Value)
                        {
                            objetoSbp.Juzgado = " ";
                        }
                        else
                        {
                            objetoSbp.Juzgado = rd.GetString(38);
                        }
                        //CODIGO CAUTELAR - EXPEDIENTE
                        if (rd[39] == DBNull.Value)
                        {
                            objetoSbp.CodigoCautelar = " ";
                        }
                        else
                        {
                            objetoSbp.CodigoCautelar = rd.GetString(39);
                        }
                        //NUM JUZGADO - EXPEDIENTE
                        if (rd[40] == DBNull.Value)
                        {
                            objetoSbp.NumJuzgado = " ";
                        }
                        else
                        {
                            objetoSbp.NumJuzgado = rd.GetString(40);
                        }


                        // PROCESO
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //MACRO ETAPA - PROCESO
                        if (rd[41] == DBNull.Value)
                        {
                            objetoSbp.Macroetapa = " ";
                        }
                        else
                        {
                            objetoSbp.Macroetapa = rd.GetString(41);
                        }
                        //MICRO ETAPA - PROCESO
                        if (rd[42] == DBNull.Value)
                        {
                            objetoSbp.Microetapa = " ";
                        }
                        else
                        {
                            objetoSbp.Microetapa = rd.GetString(42);
                        }
                        //MEDIDA CAUTELAR - PROCESO
                        if (rd[43] == DBNull.Value)
                        {
                            objetoSbp.MedidaCautelar = " ";
                        }
                        else
                        {
                            objetoSbp.MedidaCautelar = rd.GetString(43);
                        }
                        //INCIDENCIA SULLANA - PROCESO
                        if (rd[44] == DBNull.Value)
                        {
                            objetoSbp.IncidenciaSullana = " ";
                        }
                        else
                        {
                            objetoSbp.IncidenciaSullana = rd.GetString(44);
                        }
                        //FECHA ETAPA - PROCESO
                        if (rd[45] == DBNull.Value)
                        {
                            objetoSbp.FechaEtapaProcesoString = " ";
                        }
                        else if (rd.GetDateTime(45) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEtapaProcesoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEtapaProcesoString = "" + rd.GetDateTime(45).ToShortDateString();
                        }
                        //FECHA INSCRIPCION - PROCESO
                        if (rd[46] == DBNull.Value)
                        {
                            objetoSbp.FechaInscripcionString = " ";
                        }
                        else if (rd.GetDateTime(46) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaInscripcionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaInscripcionString = "" + rd.GetDateTime(46).ToShortDateString();
                        }
                        //ESTADO CAUTELAR - PROCESO
                        if (rd[47] == DBNull.Value)
                        {
                            objetoSbp.EstadoCautelar = " ";
                        }
                        else
                        {
                            objetoSbp.EstadoCautelar = rd.GetString(47);
                        }
                        //FECHA MEDIDA CAUTELAR - PROCESO
                        if (rd[48] == DBNull.Value)
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else if (rd.GetDateTime(48) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMCString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMCString = "" + rd.GetDateTime(48).ToShortDateString();
                        }
                        //VIGENCIA MC - PROCESO
                        if (rd[49] == DBNull.Value)
                        {
                            objetoSbp.VigenciaMC = " ";
                        }
                        else
                        {
                            objetoSbp.VigenciaMC = rd.GetString(49);
                        }
                        //FECHA ACTUADO CAUTELAR - PROCESO
                        if (rd[50] == DBNull.Value)
                        {
                            objetoSbp.FechaActuadoCautelarString = " ";
                        }
                        else if (rd.GetDateTime(50) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaActuadoCautelarString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaActuadoCautelarString = "" + rd.GetDateTime(50).ToShortDateString();
                        }
                        //DEVOLUCION DE CEDULA - PROCESO
                        if (rd[51] == DBNull.Value)
                        {
                            objetoSbp.Devolucion = " ";
                        }
                        else
                        {
                            objetoSbp.Devolucion = rd.GetString(51);
                        }

                        // FECHAS
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //FECHA MANDATO - FECHAS
                        if (rd[52] == DBNull.Value)
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else if (rd.GetDateTime(52) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaMandatoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaMandatoString = "" + rd.GetDateTime(52).ToShortDateString();
                        }
                        //FECHA CONTRADICCION - FECHAS
                        if (rd[53] == DBNull.Value)
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else if (rd.GetDateTime(53) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaContradiccionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaContradiccionString = "" + rd.GetDateTime(53).ToShortDateString();
                        }
                        //FECHA ORDEN - FECHAS
                        if (rd[54] == DBNull.Value)
                        {
                            objetoSbp.FechaOrdenRemateIncautacion = " ";
                        }
                        else if (rd.GetDateTime(54) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaOrdenRemateIncautacion = " ";
                        }
                        else
                        {
                            objetoSbp.FechaOrdenRemateIncautacion = "" + rd.GetDateTime(54).ToShortDateString();
                        }
                        //FECHA REMATE CAPTURA - FECHAS
                        if (rd[55] == DBNull.Value)
                        {
                            objetoSbp.FechaRemateOrdenCaptura = " ";
                        }
                        else if (rd.GetDateTime(55) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaRemateOrdenCaptura = " ";
                        }
                        else
                        {
                            objetoSbp.FechaRemateOrdenCaptura = "" + rd.GetDateTime(55).ToShortDateString();
                        }
                        //FECHA ADJU CAPTURA - FECHAS
                        if (rd[56] == DBNull.Value)
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else if (rd.GetDateTime(56) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAdjucapturaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAdjucapturaString = "" + rd.GetDateTime(56).ToShortDateString();
                        }
                        //FECHA DEMANDA - FECHAS
                        if (rd[57] == DBNull.Value)
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else if (rd.GetDateTime(57) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaDemandaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaDemandaString = "" + rd.GetDateTime(57).ToShortDateString();
                        }
                        //FECHA AUTO FINAL - FECHAS
                        if (rd[58] == DBNull.Value)
                        {
                            objetoSbp.FechaAutoFinalString = " ";
                        }
                        else if (rd.GetDateTime(58) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaAutoFinalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaAutoFinalString = "" + rd.GetDateTime(58).ToShortDateString();
                        }
                        //FECHA APELACION - FECHAS
                        if (rd[59] == DBNull.Value)
                        {
                            objetoSbp.FechaApelacionString = " ";
                        }
                        else if (rd.GetDateTime(59) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaApelacionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaApelacionString = "" + rd.GetDateTime(59).ToShortDateString();
                        }


                        // BIEN
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //NOMBRE RANGO - BIEN
                        if (rd[60] == DBNull.Value)
                        {
                            objetoSbp.Rango = " ";
                        }
                        else
                        {
                            objetoSbp.Rango = rd.GetString(60);
                        }
                        //NOMBRE BIEN - BIEN
                        if (rd[61] == DBNull.Value)
                        {
                            objetoSbp.NombreBien = " ";
                        }
                        else
                        {
                            objetoSbp.NombreBien = rd.GetString(61);
                        }
                        //MONTO GARANTIA - BIEN
                        if (rd[62] == DBNull.Value)
                        {
                            objetoSbp.MontoGarantia = " ";
                        }
                        else
                        {
                            objetoSbp.MontoGarantia = rd.GetString(62);
                        }
                        //MONTO TASACION - BIEN
                        if (rd[63] == DBNull.Value)
                        {
                            objetoSbp.MontoTasacion = " ";
                        }
                        else
                        {
                            objetoSbp.MontoTasacion = rd.GetString(63);
                        }
                        //FECHA TASACION - BIEN
                        if (rd[64] == DBNull.Value)
                        {
                            objetoSbp.FechaTasacionString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaTasacionString = rd.GetString(64);
                        }
                        //PARTIDA PLACA - BIEN
                        if (rd[65] == DBNull.Value)
                        {
                            objetoSbp.PartidaBien = " ";
                        }
                        else
                        {
                            objetoSbp.PartidaBien = rd.GetString(65);
                        }
                        //PORCENTAJE - BIEN
                        if (rd[66] == DBNull.Value)
                        {
                            objetoSbp.PorcentajeBien = " ";
                        }
                        else
                        {
                            objetoSbp.PorcentajeBien = rd.GetString(66);
                        }
                        //DESCRIPCION - BIEN
                        if (rd[67] == DBNull.Value)
                        {
                            objetoSbp.DescripcionBien = " ";
                        }
                        else
                        {
                            objetoSbp.DescripcionBien = rd.GetString(67);
                        }
                        //TIPO BIEN - BIEN
                        if (rd[68] == DBNull.Value)
                        {
                            objetoSbp.TipoBien = " ";
                        }
                        else
                        {
                            objetoSbp.TipoBien = rd.GetString(68);
                        }
                        //VALOR COMERCIAL - BIEN
                        if (rd[69] == DBNull.Value)
                        {
                            objetoSbp.ValorComercial = " ";
                        }
                        else
                        {
                            objetoSbp.ValorComercial = rd.GetString(69);
                        }
                        //CIUDAD - BIEN
                        if (rd[70] == DBNull.Value)
                        {
                            objetoSbp.CiudadBien = " ";
                        }
                        else
                        {
                            objetoSbp.CiudadBien = rd.GetString(70);
                        }
                        //DISTRITO - BIEN
                        if (rd[71] == DBNull.Value)
                        {
                            objetoSbp.DistritoBien = " ";
                        }
                        else
                        {
                            objetoSbp.DistritoBien = rd.GetString(71);
                        }
                        //MARCA - BIEN
                        if (rd[72] == DBNull.Value)
                        {
                            objetoSbp.MarcaBien = " ";
                        }
                        else
                        {
                            objetoSbp.MarcaBien = rd.GetString(72);
                        }
                        //MODELO - BIEN
                        if (rd[73] == DBNull.Value)
                        {
                            objetoSbp.ModeloBien = " ";
                        }
                        else
                        {
                            objetoSbp.ModeloBien = rd.GetString(73);
                        }

                        // SEGUIMIENTO
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //ESTADO PROCESAL - SEGUIMIENTO
                        if (rd[74] == DBNull.Value)
                        {
                            objetoSbp.EstadoProcesal = " ";
                        }
                        else
                        {
                            objetoSbp.EstadoProcesal = rd.GetString(74);
                        }
                        //FECHA ESTADO PROCESAL - SEGUIMIENTO
                        if (rd[75] == DBNull.Value)
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else if (rd.GetDateTime(75) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEstadoProcesalString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEstadoProcesalString = "" + rd.GetDateTime(75).ToShortDateString();
                        }
                        //TAREA JUDICIAL - SEGUIMIENTO
                        if (rd[76] == DBNull.Value)
                        {
                            objetoSbp.TareaJudicial = " ";
                        }
                        else
                        {
                            objetoSbp.TareaJudicial = rd.GetString(76);
                        }
                        //FECHA TAREA ADMINISTRATIVA - SEGUIMIENTO
                        if (rd[77] == DBNull.Value)
                        {
                            objetoSbp.FechaTareaAdministrativaString = " ";
                        }
                        else if (rd.GetDateTime(77) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaTareaAdministrativaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaTareaAdministrativaString = "" + rd.GetDateTime(77).ToShortDateString();
                        }
                        //INCIDENCIA - SEGUIMIENTO
                        if (rd[78] == DBNull.Value)
                        {
                            objetoSbp.Incidencia = " ";
                        }
                        else
                        {
                            objetoSbp.Incidencia = rd.GetString(78);
                        }
                        //DETALLE INCIDENCIA - SEGUIMIENTO
                        if (rd[79] == DBNull.Value)
                        {
                            objetoSbp.DetalleIncidencia = " ";
                        }
                        else
                        {
                            objetoSbp.DetalleIncidencia = rd.GetString(79);
                        }
                        //TAREA ADMINISTRATIVA - SEGUIMIENTO
                        if (rd[80] == DBNull.Value)
                        {
                            objetoSbp.TareaAdministrativa = " ";
                        }
                        else
                        {
                            objetoSbp.TareaAdministrativa = rd.GetString(80);
                        }

                        // PAGOS
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //SOLUCION - PAGOS
                        if (rd[81] == DBNull.Value)
                        {
                            objetoSbp.TipoSolucionPagos = " ";
                        }
                        else
                        {
                            objetoSbp.TipoSolucionPagos = rd.GetString(81);
                        }
                        //SALDO - PAGOS
                        if (rd[82] == DBNull.Value)
                        {
                            objetoSbp.SaldoPagos = " ";
                        }
                        else
                        {
                            objetoSbp.SaldoPagos = rd.GetString(82);
                        }
                        //COMISION - PAGOS
                        if (rd[83] == DBNull.Value)
                        {
                            objetoSbp.ComisionesPagos = " ";
                        }
                        else
                        {
                            objetoSbp.ComisionesPagos = rd.GetString(83);
                        }
                        //FECHA PAGOS - PAGOS
                        if (rd[84] == DBNull.Value)
                        {
                            objetoSbp.FechaPagoString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaPagoString = rd.GetString(84);
                        }


                        // PROYECCION
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //FECHA ESTIMADA - PROYECCION
                        if (rd[85] == DBNull.Value)
                        {
                            objetoSbp.FechaEstimadaString = " ";
                        }
                        else if (rd.GetDateTime(85) == DateTime.Parse("01-01-1990"))
                        {
                            objetoSbp.FechaEstimadaString = " ";
                        }
                        else
                        {
                            objetoSbp.FechaEstimadaString = "" + rd.GetDateTime(85).ToShortDateString();
                        }
                        //DEVUELTO - PROYECCION
                        if (rd[86] == DBNull.Value)
                        {
                            objetoSbp.Devuelto = " ";
                        }
                        else
                        {
                            objetoSbp.Devuelto = rd.GetString(86);
                        }
                        //MOTIVO DEVOLUCION - PROYECCION
                        if (rd[87] == DBNull.Value)
                        {
                            objetoSbp.MotivoDevolucion = " ";
                        }
                        else
                        {
                            objetoSbp.MotivoDevolucion = rd.GetString(87);
                        }
                        //TELEFONO - PROYECCION
                        if (rd[88] == DBNull.Value)
                        {
                            objetoSbp.TelefonoProyeccion = " ";
                        }
                        else
                        {
                            objetoSbp.TelefonoProyeccion = rd.GetString(88);
                        }
                        // HISTORICO
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //PROCESO - HISTORICO
                        if (rd[89] == DBNull.Value)
                        {
                            objetoSbp.HistoricoProceso = " ";
                        }
                        else
                        {
                            objetoSbp.HistoricoProceso = rd.GetString(89);
                        }
                        //LLAMADA - HISTORICO
                        if (rd[90] == DBNull.Value)
                        {
                            objetoSbp.HistoricoLlamada = " ";
                        }
                        else
                        {
                            objetoSbp.HistoricoLlamada = rd.GetString(90);
                        }
                        //CAMPO - HISTORICO
                        if (rd[91] == DBNull.Value)
                        {
                            objetoSbp.HistoricoCampo = " ";
                        }
                        else
                        {
                            objetoSbp.HistoricoCampo = rd.GetString(91);
                        }
                        //  GESTION CAMPO
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //INUBICABLE - GESTION CAMPO
                        if (rd[92] == DBNull.Value)
                        {
                            objetoSbp.Inubicable = " ";
                        }
                        else
                        {
                            objetoSbp.Inubicable = rd.GetString(92);
                        }

                        lista.Add(new C_SBPFinal
                        {
                            DistritoTitular = objetoSbp.DistritoTitular,
                            Doi_cliente = objetoSbp.Doi_cliente,
                            Nombre_cliente = objetoSbp.Nombre_cliente,
                            NombreConyuge = objetoSbp.NombreConyuge,
                            DomicilioTitular = objetoSbp.DomicilioTitular,
                            DireccionAlterna = objetoSbp.DireccionAlterna,
                            Representante = objetoSbp.Representante,
                            TelefonoPersona = objetoSbp.TelefonoPersona,
                            ConvenioTitular = objetoSbp.ConvenioTitular,
                            Cuenta_bt = objetoSbp.Cuenta_bt,

                            Operacion = objetoSbp.Operacion,
                            NombreCartera = objetoSbp.NombreCartera,
                            NombreMoneda = objetoSbp.NombreMoneda,
                            NombreCiudadEstudio = objetoSbp.NombreCiudadEstudio,
                            NombreEstudio = objetoSbp.NombreEstudio,
                            NombreTramite = objetoSbp.NombreTramite,
                            NombreModelo = objetoSbp.NombreModelo,
                            Castigos = objetoSbp.Castigos,
                            Cdr = objetoSbp.Cdr,
                            Capital = objetoSbp.Capital,
                            FechaProtestoString = objetoSbp.FechaProtestoString,
                            Observacion = objetoSbp.Observacion,
                            FechaTramiteString = objetoSbp.FechaTramiteString,
                            Agencia = objetoSbp.Agencia,
                            FechaAsignacionString = objetoSbp.FechaAsignacionString,
                            MontoAdmitido = objetoSbp.MontoAdmitido,
                            ProductoModulo = objetoSbp.ProductoModulo,
                            Ejecutivo = objetoSbp.Ejecutivo,

                            NombreGarante = objetoSbp.NombreGarante,
                            ConyugeGarante = objetoSbp.ConyugeGarante,
                            DistritoGarante = objetoSbp.DistritoGarante,
                            DomicilioGarante = objetoSbp.DomicilioGarante,

                            NumExpediente = objetoSbp.NumExpediente,
                            NombreProceso = objetoSbp.NombreProceso,
                            Abogado = objetoSbp.Abogado,
                            Responsable = objetoSbp.Responsable,
                            Secretario = objetoSbp.Secretario,
                            NumExpediente22 = objetoSbp.NumExpediente22,
                            Juzgado = objetoSbp.Juzgado,
                            CodigoCautelar = objetoSbp.CodigoCautelar,
                            NumJuzgado = objetoSbp.NumJuzgado,

                            Macroetapa = objetoSbp.Macroetapa,
                            Microetapa = objetoSbp.Microetapa,
                            MedidaCautelar = objetoSbp.MedidaCautelar,
                            IncidenciaSullana = objetoSbp.IncidenciaSullana,
                            FechaEtapaProcesoString = objetoSbp.FechaEtapaProcesoString,
                            FechaInscripcionString = objetoSbp.FechaInscripcionString,
                            EstadoCautelar = objetoSbp.EstadoCautelar,
                            FechaMCString = objetoSbp.FechaMCString,
                            VigenciaMC = objetoSbp.VigenciaMC,
                            FechaActuadoCautelarString = objetoSbp.FechaActuadoCautelarString,
                            Devolucion = objetoSbp.Devolucion,

                            FechaMandatoString = objetoSbp.FechaMandatoString,
                            FechaContradiccionString = objetoSbp.FechaContradiccionString,
                            FechaOrdenRemateIncautacion = objetoSbp.FechaOrdenRemateIncautacion,
                            FechaRemateOrdenCaptura = objetoSbp.FechaRemateOrdenCaptura,
                            FechaAdjucapturaString = objetoSbp.FechaAdjucapturaString,
                            FechaDemandaString = objetoSbp.FechaDemandaString,
                            FechaAutoFinalString = objetoSbp.FechaAutoFinalString,
                            FechaApelacionString = objetoSbp.FechaApelacionString,

                            Rango = objetoSbp.Rango,
                            NombreBien = objetoSbp.NombreBien,
                            MontoGarantia = objetoSbp.MontoGarantia,
                            MontoTasacion = objetoSbp.MontoTasacion,
                            FechaTasacionString = objetoSbp.FechaTasacionString,
                            PartidaBien = objetoSbp.PartidaBien,
                            PorcentajeBien = objetoSbp.PorcentajeBien,
                            DescripcionBien = objetoSbp.DescripcionBien,
                            TipoBien = objetoSbp.TipoBien,
                            ValorComercial = objetoSbp.ValorComercial,
                            CiudadBien = objetoSbp.CiudadBien,
                            DistritoBien = objetoSbp.DistritoBien,
                            MarcaBien = objetoSbp.MarcaBien,
                            ModeloBien = objetoSbp.ModeloBien,

                            EstadoProcesal = objetoSbp.EstadoProcesal,
                            FechaEstadoProcesalString = objetoSbp.FechaEstadoProcesalString,
                            TareaJudicial = objetoSbp.TareaJudicial,
                            FechaTareaAdministrativaString = objetoSbp.FechaTareaAdministrativaString,
                            Incidencia = objetoSbp.Incidencia,
                            DetalleIncidencia = objetoSbp.DetalleIncidencia,
                            TareaAdministrativa = objetoSbp.TareaAdministrativa,

                            TipoSolucionPagos = objetoSbp.TipoSolucionPagos,
                            SaldoPagos = objetoSbp.SaldoPagos,
                            ComisionesPagos = objetoSbp.ComisionesPagos,
                            FechaPagoString = objetoSbp.FechaPagoString,

                            FechaEstimadaString = objetoSbp.FechaEstimadaString,
                            Devuelto = objetoSbp.Devuelto,
                            MotivoDevolucion = objetoSbp.MotivoDevolucion,
                            TelefonoProyeccion = objetoSbp.TelefonoProyeccion,
                            HistoricoProceso = objetoSbp.HistoricoProceso,
                            HistoricoLlamada = objetoSbp.HistoricoLlamada,
                            HistoricoCampo = objetoSbp.HistoricoCampo,
                            Inubicable = objetoSbp.Inubicable


                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }



        /*public List<C_Sbp> ReporteSBP(string condicion = " ")
        {
            List<C_Sbp> lista = new List<C_Sbp>();
            C_Sbp objetoSbp = new C_Sbp();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT NOMBRE_CLIENTE, CUENTA_BT, CDR, NOMBRE_CARTERA, REGION, NOMBRE_CIUDAD, NOMBRE_MODELO, FECHA_ASIGNACION, TIPO_BIEN, DESCRIPCION, NOMBRE_PROCESO, RANGO, porcentaje_derechos,  acreedor, NOMBRE_MONEDA, MONTO_DEMANDADO, DEVOLUCION_CEDULA, NOMBRE_MACROETAPA, NOMBRE_MICROETAPA, FECHA_ETAPA, TIEMPO FROM VW_REPORTESBP where codigo_tramite = 4 and flag = 1 " + condicion + " ;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSbp.Nombre = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSbp.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoSbp.Cuenta_bt = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSbp.Cdr = " ";
                        }
                        else
                        {
                            objetoSbp.Cdr = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSbp.Nombrecartera = " ";
                        }
                        else
                        {
                            objetoSbp.Nombrecartera = rd.GetString(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSbp.Region = " ";
                        }
                        else
                        {
                            objetoSbp.Region = rd.GetString(4);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSbp.Nombreciudad = " ";
                        }
                        else
                        {
                            objetoSbp.Nombreciudad = rd.GetString(5);
                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSbp.Modelo = " ";
                        }
                        else
                        {
                            objetoSbp.Modelo = rd.GetString(6);
                        }
                        //
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSbp.FechaAsignacion = " ";
                        }
                        else
                        {
                            if (rd.GetDateTime(7) == DateTime.Parse("01-01-1990"))
                            {
                                objetoSbp.FechaAsignacion = " ";
                            }
                            else if (rd[7] != DBNull.Value)
                            {
                                objetoSbp.FechaAsignacion = "" + rd.GetDateTime(7).ToShortDateString();
                            }
                            else
                            {
                                objetoSbp.FechaAsignacion = " ";
                            }
                        }
                        //
                        if (rd[8] == DBNull.Value)
                        {
                            //tipo de bien
                            objetoSbp.Nombrebienhipotecado = " ";
                        }
                        else
                        {
                            objetoSbp.Nombrebienhipotecado = "" + rd.GetString(8);
                        }
                        if (rd[9] == DBNull.Value)
                        {
                            //descripcion bien
                            objetoSbp.Descripcion_inmueble = " ";
                        }
                        else
                        {
                            objetoSbp.Descripcion_inmueble = rd.GetString(9);
                        }
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSbp.Nombre_proceso = " ";
                        }
                        else
                        {
                            objetoSbp.Nombre_proceso = rd.GetString(10);
                        }
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSbp.Nombrerangohipotecado = " ";
                        }
                        else
                        {
                            objetoSbp.Nombrerangohipotecado = rd.GetString(11);
                        }
                        if (rd[12] == DBNull.Value)
                        {
                            //acciones
                            objetoSbp.Porcentaje_embargo = " ";
                        }
                        else
                        {
                            objetoSbp.Porcentaje_embargo = rd.GetString(12);
                        }
                        if (rd[13] == DBNull.Value)
                        {
                            objetoSbp.Otros_embargos = " ";
                        }
                        else
                        {
                            objetoSbp.Otros_embargos = rd.GetString(13);
                        }
                        if (rd[14] == DBNull.Value)
                        {
                            objetoSbp.Nombremoneda = " ";
                        }
                        else
                        {
                            objetoSbp.Nombremoneda = rd.GetString(14);
                        }
                        if (rd[15] == DBNull.Value)
                        {
                            objetoSbp.Monto_demandado = " ";
                        }
                        else
                        {
                            objetoSbp.Monto_demandado = rd.GetString(15);
                        }
                        if (rd[16] == DBNull.Value)
                        {
                            objetoSbp.Devolucioncedula = " ";
                        }
                        else
                        {
                            objetoSbp.Devolucioncedula = rd.GetString(16);
                        }
                        if (rd[17] == DBNull.Value)
                        {
                            objetoSbp.Ultimoestadoprocesal = " ";
                        }
                        else
                        {
                            objetoSbp.Ultimoestadoprocesal = rd.GetString(17);
                        }
                        if (rd[18] == DBNull.Value)
                        {
                            objetoSbp.Ultimatareaprocesal = " ";
                        }
                        else
                        {
                            objetoSbp.Ultimatareaprocesal = rd.GetString(18);
                        }
                        //
                        if (rd[19] == DBNull.Value)
                        {
                            objetoSbp.Ultimafechaprocesal = " ";
                        }
                        else
                        {
                            if (rd.GetDateTime(19) == DateTime.Parse("01-01-1990"))
                            {
                                objetoSbp.Ultimafechaprocesal = " ";
                            }
                            else if (rd[19] != DBNull.Value)
                            {
                                objetoSbp.Ultimafechaprocesal = "" + rd.GetDateTime(19).ToShortDateString();
                            }
                            else
                            {
                                objetoSbp.Ultimafechaprocesal = " ";
                            }
                        }
                        
                       
                            //
                        /*if (rd[20] == DBNull.Value)
                        {
                            objetoSbp.Siguientefechaprocesal = " ";
                        }
                        else
                        {
                            if (rd.GetDateTime(20) == DateTime.Parse("01-01-1990"))
                            {
                                objetoSbp.Siguientefechaprocesal = " ";
                            }
                            else if (rd[20] != DBNull.Value)
                            {
                                objetoSbp.Siguientefechaprocesal = " " + rd.GetDateTime(20);
                            }
                            else
                            {
                                objetoSbp.Siguientefechaprocesal = " ";
                            }
                        }*/
                       
                        //
                        /*lista.Add(new C_Sbp
                        {
                            Nombre = objetoSbp.Nombre,
                            Cuenta_bt = objetoSbp.Cuenta_bt,
                            Cdr = objetoSbp.Cdr,
                            Nombrecartera = objetoSbp.Nombrecartera,
                            Region = objetoSbp.Region,
                            Nombreciudad = objetoSbp.Nombreciudad,
                            Modelo = objetoSbp.Modelo,
                            FechaAsignacion = objetoSbp.FechaAsignacion,
                            Nombrebienhipotecado = objetoSbp.Nombrebienhipotecado,
                            Descripcion_inmueble = objetoSbp.Descripcion_inmueble,
                            Nombre_proceso = objetoSbp.Nombre_proceso,
                            Nombrerangohipotecado = objetoSbp.Nombrerangohipotecado,
                            Porcentaje_embargo = objetoSbp.Porcentaje_embargo,
                            Otros_embargos = objetoSbp.Otros_embargos,
                            Nombremoneda = objetoSbp.Nombremoneda,
                            Monto_demandado = objetoSbp.Monto_demandado,
                            Devolucioncedula = objetoSbp.Devolucioncedula,
                            Ultimoestadoprocesal = objetoSbp.Ultimoestadoprocesal,
                            Ultimatareaprocesal = objetoSbp.Ultimatareaprocesal,
                            Ultimafechaprocesal = objetoSbp.Ultimafechaprocesal,
                            //Siguientefechaprocesal = objetoSbp.Siguientefechaprocesal
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }*/

        public List<C_Liquidacion> ReporteLiquidacion(string codigo)
        {
            List<C_Liquidacion> lista = new List<C_Liquidacion>();
            C_Liquidacion objetoLiquidacion = new C_Liquidacion();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT DOI_CLIENTE, NOMBRE_COMPLETO, NOMBRE_MONEDA, NOMBRE_CARTERA, CUENTA_BT, CDR FROM VW_REPORTELIQUIDACION WHERE CUENTA_BT = '" +codigo + "' AND FLAG = 1;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoLiquidacion.DoiCliente = " ";
                        }
                        else
                        {
                            objetoLiquidacion.DoiCliente = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoLiquidacion.NombreCliente = " ";
                        }
                        else
                        {
                            objetoLiquidacion.NombreCliente = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoLiquidacion.NombreModelo= " ";
                        }
                        else
                        {
                            objetoLiquidacion.NombreModelo = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoLiquidacion.Nombrecartera = " ";
                        }
                        else
                        {
                            objetoLiquidacion.Nombrecartera = rd.GetString(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoLiquidacion.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoLiquidacion.Cuenta_bt = rd.GetString(4);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoLiquidacion.Cdr = " ";
                        }
                        else
                        {
                            objetoLiquidacion.Cdr= rd.GetString(5);
                        }
                        lista.Add(new C_Liquidacion
                        {
                            DoiCliente = objetoLiquidacion.DoiCliente,
                            NombreCliente = objetoLiquidacion.NombreCliente,
                            NombreModelo = objetoLiquidacion.NombreModelo,
                            Nombrecartera = objetoLiquidacion.Nombrecartera,
                            Cuenta_bt =objetoLiquidacion.Cuenta_bt,
                            Cdr = objetoLiquidacion.Cdr
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_Liquidacion> ReporteLiquidacionTodo()
        {
            List<C_Liquidacion> lista = new List<C_Liquidacion>();
            C_Liquidacion objetoLiquidacion = new C_Liquidacion();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT DOI_CLIENTE, NOMBRE_COMPLETO, NOMBRE_MONEDA, NOMBRE_CARTERA, CUENTA_BT, CDR FROM VW_REPORTELIQUIDACION WHERE FLAG = 1 AND CODIGO_TRAMITE = 4;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoLiquidacion.DoiCliente = " ";
                        }
                        else
                        {
                            objetoLiquidacion.DoiCliente = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoLiquidacion.NombreCliente = " ";
                        }
                        else
                        {
                            objetoLiquidacion.NombreCliente = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoLiquidacion.NombreModelo = " ";
                        }
                        else
                        {
                            objetoLiquidacion.NombreModelo = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoLiquidacion.Nombrecartera = " ";
                        }
                        else
                        {
                            objetoLiquidacion.Nombrecartera = rd.GetString(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoLiquidacion.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoLiquidacion.Cuenta_bt = rd.GetString(4);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoLiquidacion.Cdr = " ";
                        }
                        else
                        {
                            objetoLiquidacion.Cdr = rd.GetString(5);
                        }
                        lista.Add(new C_Liquidacion
                        {
                            DoiCliente = objetoLiquidacion.DoiCliente,
                            NombreCliente = objetoLiquidacion.NombreCliente,
                            NombreModelo = objetoLiquidacion.NombreModelo,
                            Nombrecartera = objetoLiquidacion.Nombrecartera,
                            Cuenta_bt = objetoLiquidacion.Cuenta_bt,
                            Cdr = objetoLiquidacion.Cdr
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }

        public List<C_PaseTransito> ReportePaseTransito(string codigo)
        {
            List<C_PaseTransito> lista = new List<C_PaseTransito>();
            C_PaseTransito objetoPaseTransito = new C_PaseTransito();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT NOMBRE_COMPLETO, CUENTA_BT, '' AS NUM_CAJA, RESPONSABLE, FECHA_TRAMITE, OBSERVACION_TRAMITE, CUENTA_BT, NOMBRE_CARTERA FROM VW_REPORTEPASEATRANSITO WHERE CUENTA_BT = '" + codigo + "' AND CODIGO_TRAMITE = 1 AND FLAG = 1;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoPaseTransito.NombreCliente = " ";
                        }
                        else
                        {
                            objetoPaseTransito.NombreCliente = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoPaseTransito.CuentaBT = " ";
                        }
                        else
                        {
                            objetoPaseTransito.CuentaBT = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoPaseTransito.NumCaja = " ";
                        }
                        else
                        {
                            objetoPaseTransito.NumCaja = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoPaseTransito.NombreRes = " ";
                        }
                        else
                        {
                            objetoPaseTransito.NombreRes = rd.GetString(3);
                        }
                        if (rd.GetDateTime(4) == DateTime.Parse("01-01-1990"))
                        {
                            objetoPaseTransito.FechaTramiteString = " ";
                        }
                        else if (rd[4] != DBNull.Value)
                        {
                            objetoPaseTransito.FechaTramiteString = "" + rd.GetDateTime(4).ToShortDateString();
                        }
                        else
                        {
                            objetoPaseTransito.FechaTramiteString = " ";
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoPaseTransito.Observacion = " ";
                        }
                        else
                        {
                            objetoPaseTransito.Observacion = rd.GetString(5);
                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoPaseTransito.Cuentabt2 = " ";
                        }
                        else
                        {
                            objetoPaseTransito.Cuentabt2 = rd.GetString(6);
                        }
                        if (rd[7] == DBNull.Value)
                        {
                            objetoPaseTransito.NombreCartera = " ";
                        }
                        else
                        {
                            objetoPaseTransito.NombreCartera = rd.GetString(7);
                        }
                        lista.Add(new C_PaseTransito
                        {
                            NombreCliente = objetoPaseTransito.NombreCliente,
                            CuentaBT = objetoPaseTransito.CuentaBT,
                            NumCaja = objetoPaseTransito.NumCaja,
                            NombreRes = objetoPaseTransito.NombreRes,
                            FechaTramite = rd.GetDateTime(4),
                            Observacion = objetoPaseTransito.Observacion,
                            Cuentabt2 = objetoPaseTransito.Cuentabt2,
                            NombreCartera = objetoPaseTransito.NombreCartera,
                            FechaTramiteString = objetoPaseTransito.FechaTramiteString
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_PaseTransito> ReportePaseTranistoTodo()
        {
            List<C_PaseTransito> lista = new List<C_PaseTransito>();
            C_PaseTransito objetoPaseTransito = new C_PaseTransito();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT NOMBRE_COMPLETO, CUENTA_BT, '' AS NUM_CAJA, RESPONSABLE, FECHA_TRAMITE, OBSERVACION_TRAMITE, CUENTA_BT, NOMBRE_CARTERA FROM VW_REPORTEPASEATRANSITO WHERE CODIGO_TRAMITE = 1 AND FLAG = 1;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoPaseTransito.NombreCliente = " ";
                        }
                        else
                        {
                            objetoPaseTransito.NombreCliente = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoPaseTransito.CuentaBT = " ";
                        }
                        else
                        {
                            objetoPaseTransito.CuentaBT = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoPaseTransito.NumCaja = " ";
                        }
                        else
                        {
                            objetoPaseTransito.NumCaja = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoPaseTransito.NombreRes = " ";
                        }
                        else
                        {
                            objetoPaseTransito.NombreRes = rd.GetString(3);
                        }
                        //
                        if (rd.GetDateTime(4) == DateTime.Parse("01-01-1990"))
                        {
                            objetoPaseTransito.FechaTramiteString = " ";
                        }
                        else if (rd[4] != DBNull.Value)
                        {
                            objetoPaseTransito.FechaTramiteString = "" + rd.GetDateTime(4).ToShortDateString() ;
                        }
                        else
                        {
                            objetoPaseTransito.FechaTramiteString = " ";
                        }
                        //
                        if (rd[5] == DBNull.Value)
                        {
                            objetoPaseTransito.Observacion = " ";
                        }
                        else
                        {
                            objetoPaseTransito.Observacion = rd.GetString(5);
                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoPaseTransito.Cuentabt2 = " ";
                        }
                        else
                        {
                            objetoPaseTransito.Cuentabt2 = rd.GetString(6);
                        }
                        if (rd[7] == DBNull.Value)
                        {
                            objetoPaseTransito.NombreCartera = " ";
                        }
                        else
                        {
                            objetoPaseTransito.NombreCartera = rd.GetString(7);
                        }
                        
                        //
                        lista.Add(new C_PaseTransito
                        {
                            NombreCliente = objetoPaseTransito.NombreCliente,
                            CuentaBT = objetoPaseTransito.CuentaBT,
                            NumCaja = objetoPaseTransito.NumCaja,
                            NombreRes = objetoPaseTransito.NombreRes,
                            FechaTramite = rd.GetDateTime(4),
                            Observacion = objetoPaseTransito.Observacion,
                            Cuentabt2 = objetoPaseTransito.Cuentabt2,
                            NombreCartera = objetoPaseTransito.NombreCartera,
                            FechaTramiteString = objetoPaseTransito.FechaTramiteString
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }

        public List<C_GestionLlamadas> ReporteLlamada(string codigo)
        {
            List<C_GestionLlamadas> lista = new List<C_GestionLlamadas>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_GestionLlamadas objetoGestionLlamadas = new C_GestionLlamadas();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT TELEFONO_CONTACTO, CONTACTO_CLIENTE, CONTACTO_PARIENTE, NOMBRE_PARIENTE, TELEFONO_NO_CORRESPONDE, FECHA_VISITA_ESTUDIO, FECHA_PAGO, MONTO_PAGO, DUENO_BIEN, NIEGA_PAGO, NOMBRE, HORA_LLAMADA, DETALLE_RESULTADO, NUM_GESTION, TIPO_SOLUCION, CODIGO_GESTION, DNI_TRABAJADOR,CUENTA_BT FROM VW_GESTIONLLAMADADGV WHERE CUENTA_BT = '" + codigo + "' and flag = 1 and codigo_tramite = 4;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //
                        if (rd[0] == DBNull.Value)
                            objetoGestionLlamadas.TelefonoContacto = " ";
                        else
                            objetoGestionLlamadas.TelefonoContacto = rd.GetString(0);
                        //
                        if (rd[1] == DBNull.Value)
                            objetoGestionLlamadas.ContactoCliente = " ";
                        else
                            objetoGestionLlamadas.ContactoCliente = rd.GetString(1);
                        //
                        if (rd[2] == DBNull.Value)
                            objetoGestionLlamadas.ContactoPariente = " ";
                        else
                            objetoGestionLlamadas.ContactoPariente = rd.GetString(2);
                        //
                        if (rd[3] == DBNull.Value)
                            objetoGestionLlamadas.NombrePariente = " ";
                        else
                            objetoGestionLlamadas.NombrePariente = rd.GetString(3);
                        //
                        if (rd[4] == DBNull.Value)
                            objetoGestionLlamadas.TelefonoNoCorresponde = " ";
                        else
                            objetoGestionLlamadas.TelefonoNoCorresponde = rd.GetString(4);
                        //
                        if (rd.GetDateTime(5) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionLlamadas.FechaVisitaEstudioString = " ";
                        }
                        else if (rd[5] != DBNull.Value)
                        {
                            objetoGestionLlamadas.FechaVisitaEstudioString = "" + rd.GetDateTime(5).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionLlamadas.FechaVisitaEstudioString = " ";
                        }
                        //
                        if (rd.GetDateTime(6) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionLlamadas.FechaPagoString = " ";
                        }
                        else if (rd[6] != DBNull.Value)
                        {
                            objetoGestionLlamadas.FechaPagoString = "" + rd.GetDateTime(6).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionLlamadas.FechaPagoString = " ";
                        }
                        //
                        if (rd[7] == DBNull.Value)
                            objetoGestionLlamadas.MontoPago = " ";
                        else
                            objetoGestionLlamadas.MontoPago = rd.GetString(7);
                        //
                        if (rd[8] == DBNull.Value)
                            objetoGestionLlamadas.DuenoBien = " ";
                        else
                            objetoGestionLlamadas.DuenoBien = rd.GetString(8);
                        //
                        if (rd[9] == DBNull.Value)
                            objetoGestionLlamadas.NiegaPago = " ";
                        else
                            objetoGestionLlamadas.NiegaPago = rd.GetString(9);
                        //
                        if (rd[10] == DBNull.Value)
                            objetoGestionLlamadas.NombreTrabajador = " ";
                        else
                            objetoGestionLlamadas.NombreTrabajador = rd.GetString(10);
                        //
                        if (rd[11] == DBNull.Value)
                            objetoGestionLlamadas.HoraLlamada = " ";
                        else
                            objetoGestionLlamadas.HoraLlamada = rd.GetString(11);
                        //
                        if (rd[12] == DBNull.Value)
                            objetoGestionLlamadas.DetalleResultado = " ";
                        else
                            objetoGestionLlamadas.DetalleResultado = rd.GetString(12);
                        //
                        if (rd[13] == DBNull.Value)
                            objetoGestionLlamadas.NumGestion = " ";
                        else
                            objetoGestionLlamadas.NumGestion = rd.GetString(13);
                        //
                        if (rd[14] == DBNull.Value)
                            objetoGestionLlamadas.TipoSolucion = " ";
                        else
                            objetoGestionLlamadas.TipoSolucion = rd.GetString(14);
                        //
                        lista.Add(new C_GestionLlamadas
                        {
                            TelefonoContacto = objetoGestionLlamadas.TelefonoContacto,
                            ContactoCliente = objetoGestionLlamadas.ContactoCliente,
                            ContactoPariente = objetoGestionLlamadas.ContactoPariente,
                            NombrePariente = objetoGestionLlamadas.NombrePariente,
                            TelefonoNoCorresponde = objetoGestionLlamadas.TelefonoNoCorresponde,
                            FechaVisitaEstudio = rd.GetDateTime(5),
                            FechaPago = rd.GetDateTime(6),
                            MontoPago = objetoGestionLlamadas.MontoPago,
                            DuenoBien = objetoGestionLlamadas.DuenoBien,
                            NiegaPago = objetoGestionLlamadas.NiegaPago,
                            NombreTrabajador = objetoGestionLlamadas.NombreTrabajador,
                            HoraLlamada = objetoGestionLlamadas.HoraLlamada,
                            DetalleResultado = objetoGestionLlamadas.DetalleResultado,
                            NumGestion = objetoGestionLlamadas.NumGestion,
                            TipoSolucion = objetoGestionLlamadas.TipoSolucion,
                            CodigoGestionLlamada = rd.GetInt32(15),
                            DniTrabajador = rd.GetInt32(16),
                            CuentaBT = rd.GetString(17),
                            FechaVisitaEstudioString = objetoGestionLlamadas.FechaVisitaEstudioString,
                            FechaPagoString = objetoGestionLlamadas.FechaPagoString
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_GestionLlamadas> ReporteLlamadaTodo()
        {
            List<C_GestionLlamadas> lista = new List<C_GestionLlamadas>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_GestionLlamadas objetoGestionLlamadas = new C_GestionLlamadas();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT TELEFONO_CONTACTO, CONTACTO_CLIENTE, CONTACTO_PARIENTE, NOMBRE_PARIENTE, TELEFONO_NO_CORRESPONDE, FECHA_VISITA_ESTUDIO, FECHA_PAGO, MONTO_PAGO, DUENO_BIEN, NIEGA_PAGO, NOMBRE_PERSONA, HORA_LLAMADA, DETALLE_RESULTADO, NUM_GESTION, TIPO_SOLUCION, CODIGO_GESTION, DNI_TRABAJADOR,CUENTA_BT, NOMBRE_COMPLETO FROM VW_GESTIONLLAMADADGV WHERE flag = 1 and codigo_tramite = 4;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //
                        if (rd[0] == DBNull.Value)
                            objetoGestionLlamadas.TelefonoContacto = " ";
                        else
                            objetoGestionLlamadas.TelefonoContacto = rd.GetString(0);
                        //
                        if (rd[1] == DBNull.Value)
                            objetoGestionLlamadas.ContactoCliente = " ";
                        else
                            objetoGestionLlamadas.ContactoCliente = rd.GetString(1);
                        //
                        if (rd[2] == DBNull.Value)
                            objetoGestionLlamadas.ContactoPariente = " ";
                        else
                            objetoGestionLlamadas.ContactoPariente = rd.GetString(2);
                        //
                        if (rd[3] == DBNull.Value)
                            objetoGestionLlamadas.NombrePariente = " ";
                        else
                            objetoGestionLlamadas.NombrePariente = rd.GetString(3);
                        //
                        if (rd[4] == DBNull.Value)
                            objetoGestionLlamadas.TelefonoNoCorresponde = " ";
                        else
                            objetoGestionLlamadas.TelefonoNoCorresponde = rd.GetString(4);
                        //
                        if (rd.GetDateTime(5) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionLlamadas.FechaVisitaEstudioString = " ";
                        }
                        else if (rd[5] != DBNull.Value)
                        {
                            objetoGestionLlamadas.FechaVisitaEstudioString = "" + rd.GetDateTime(5).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionLlamadas.FechaVisitaEstudioString = " ";
                        }
                        //
                        if (rd.GetDateTime(6) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionLlamadas.FechaPagoString = " ";
                        }
                        else if (rd[6] != DBNull.Value)
                        {
                            objetoGestionLlamadas.FechaPagoString = "" + rd.GetDateTime(6).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionLlamadas.FechaPagoString = " ";
                        }
                        //
                        if (rd[7] == DBNull.Value)
                            objetoGestionLlamadas.MontoPago = " ";
                        else
                            objetoGestionLlamadas.MontoPago = rd.GetString(7);
                        //
                        if (rd[8] == DBNull.Value)
                            objetoGestionLlamadas.DuenoBien = " ";
                        else
                            objetoGestionLlamadas.DuenoBien = rd.GetString(8);
                        //
                        if (rd[9] == DBNull.Value)
                            objetoGestionLlamadas.NiegaPago = " ";
                        else
                            objetoGestionLlamadas.NiegaPago = rd.GetString(9);
                        //
                        if (rd[10] == DBNull.Value)
                            objetoGestionLlamadas.NombreTrabajador = " ";
                        else
                            objetoGestionLlamadas.NombreTrabajador = rd.GetString(10);
                        //
                        if (rd[11] == DBNull.Value)
                            objetoGestionLlamadas.HoraLlamada = " ";
                        else
                            objetoGestionLlamadas.HoraLlamada = rd.GetString(11);
                        //
                        if (rd[12] == DBNull.Value)
                            objetoGestionLlamadas.DetalleResultado = " ";
                        else
                            objetoGestionLlamadas.DetalleResultado = rd.GetString(12);
                        //
                        if (rd[13] == DBNull.Value)
                            objetoGestionLlamadas.NumGestion = " ";
                        else
                            objetoGestionLlamadas.NumGestion = rd.GetString(13);
                        //
                        if (rd[14] == DBNull.Value)
                            objetoGestionLlamadas.TipoSolucion = " ";
                        else
                            objetoGestionLlamadas.TipoSolucion = rd.GetString(14);
                        //
                        if (rd[18] == DBNull.Value)
                        {
                            objetoGestionLlamadas.NombrePersona = " ";
                        }
                        else
                        {
                            objetoGestionLlamadas.NombrePersona = rd.GetString(18);
                        }
                        lista.Add(new C_GestionLlamadas
                        {
                            TelefonoContacto = objetoGestionLlamadas.TelefonoContacto,
                            ContactoCliente = objetoGestionLlamadas.ContactoCliente,
                            ContactoPariente = objetoGestionLlamadas.ContactoPariente,
                            NombrePariente = objetoGestionLlamadas.NombrePariente,
                            TelefonoNoCorresponde = objetoGestionLlamadas.TelefonoNoCorresponde,
                           // FechaVisitaEstudio = rd.GetDateTime(5),
                            //FechaPago = rd.GetDateTime(6),
                            MontoPago = objetoGestionLlamadas.MontoPago,
                            DuenoBien = objetoGestionLlamadas.DuenoBien,
                            NiegaPago = objetoGestionLlamadas.NiegaPago,
                            NombreTrabajador = objetoGestionLlamadas.NombreTrabajador,
                            HoraLlamada = objetoGestionLlamadas.HoraLlamada,
                            DetalleResultado = objetoGestionLlamadas.DetalleResultado,
                            NumGestion = objetoGestionLlamadas.NumGestion,
                            TipoSolucion = objetoGestionLlamadas.TipoSolucion,
                            CodigoGestionLlamada = rd.GetInt32(15),
                            DniTrabajador = rd.GetInt32(16),
                            CuentaBT = rd.GetString(17),
                            FechaVisitaEstudioString = objetoGestionLlamadas.FechaVisitaEstudioString,
                            FechaPagoString = objetoGestionLlamadas.FechaPagoString,
                            NombrePersona = objetoGestionLlamadas.NombrePersona
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_GestionLlamadas> ReporteLlamadita(int codigo)
        {
            List<C_GestionLlamadas> lista = new List<C_GestionLlamadas>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_GestionLlamadas objetoGestionLlamadas = new C_GestionLlamadas();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT TELEFONO_CONTACTO, CONTACTO_CLIENTE, CONTACTO_PARIENTE, NOMBRE_PARIENTE, TELEFONO_NO_CORRESPONDE, FECHA_VISITA_ESTUDIO, FECHA_PAGO, MONTO_PAGO, DUENO_BIEN, NIEGA_PAGO, NOMBRE, HORA_LLAMADA, DETALLE_RESULTADO, NUM_GESTION, TIPO_SOLUCION, CODIGO_GESTION, DNI_TRABAJADOR,CUENTA_BT FROM VW_GESTIONLLAMADADGV WHERE DNI_TRABAJADOR = " + codigo + " and flag = 1 and codigo_tramite = 4;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //
                        if (rd[0] == DBNull.Value)
                            objetoGestionLlamadas.TelefonoContacto = " ";
                        else
                            objetoGestionLlamadas.TelefonoContacto = rd.GetString(0);
                        //
                        if (rd[1] == DBNull.Value)
                            objetoGestionLlamadas.ContactoCliente = " ";
                        else
                            objetoGestionLlamadas.ContactoCliente = rd.GetString(1);
                        //
                        if (rd[2] == DBNull.Value)
                            objetoGestionLlamadas.ContactoPariente = " ";
                        else
                            objetoGestionLlamadas.ContactoPariente = rd.GetString(2);
                        //
                        if (rd[3] == DBNull.Value)
                            objetoGestionLlamadas.NombrePariente = " ";
                        else
                            objetoGestionLlamadas.NombrePariente = rd.GetString(3);
                        //
                        if (rd[4] == DBNull.Value)
                            objetoGestionLlamadas.TelefonoNoCorresponde = " ";
                        else
                            objetoGestionLlamadas.TelefonoNoCorresponde = rd.GetString(4);
                        //
                        if (rd.GetDateTime(5) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionLlamadas.FechaVisitaEstudioString = " ";
                        }
                        else if (rd[5] != DBNull.Value)
                        {
                            objetoGestionLlamadas.FechaVisitaEstudioString = "" + rd.GetDateTime(5).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionLlamadas.FechaVisitaEstudioString = " ";
                        }
                        //
                        if (rd.GetDateTime(6) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionLlamadas.FechaPagoString = " ";
                        }
                        else if (rd[6] != DBNull.Value)
                        {
                            objetoGestionLlamadas.FechaPagoString = "" + rd.GetDateTime(6).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionLlamadas.FechaPagoString = " ";
                        }
                        //
                        if (rd[7] == DBNull.Value)
                            objetoGestionLlamadas.MontoPago = " ";
                        else
                            objetoGestionLlamadas.MontoPago = rd.GetString(7);
                        //
                        if (rd[8] == DBNull.Value)
                            objetoGestionLlamadas.DuenoBien = " ";
                        else
                            objetoGestionLlamadas.DuenoBien = rd.GetString(8);
                        //
                        if (rd[9] == DBNull.Value)
                            objetoGestionLlamadas.NiegaPago = " ";
                        else
                            objetoGestionLlamadas.NiegaPago = rd.GetString(9);
                        //
                        //if (rd[10] == DBNull.Value)
                        //    objetoGestionLlamadas.NombreTrabajador = " ";
                        //else
                        //    objetoGestionLlamadas.NombreTrabajador = rd.GetString(10);
                        //
                        if (rd[11] == DBNull.Value)
                            objetoGestionLlamadas.HoraLlamada = " ";
                        else
                            objetoGestionLlamadas.HoraLlamada = rd.GetString(11);
                        //
                        if (rd[12] == DBNull.Value)
                            objetoGestionLlamadas.DetalleResultado = " ";
                        else
                            objetoGestionLlamadas.DetalleResultado = rd.GetString(12);
                        //
                        if (rd[13] == DBNull.Value)
                            objetoGestionLlamadas.NumGestion = " ";
                        else
                            objetoGestionLlamadas.NumGestion = rd.GetString(13);
                        //
                        if (rd[14] == DBNull.Value)
                            objetoGestionLlamadas.TipoSolucion = " ";
                        else
                            objetoGestionLlamadas.TipoSolucion = rd.GetString(14);
                        //
                        lista.Add(new C_GestionLlamadas
                        {
                            TelefonoContacto = objetoGestionLlamadas.TelefonoContacto,
                            ContactoCliente = objetoGestionLlamadas.ContactoCliente,
                            ContactoPariente = objetoGestionLlamadas.ContactoPariente,
                            NombrePariente = objetoGestionLlamadas.NombrePariente,
                            TelefonoNoCorresponde = objetoGestionLlamadas.TelefonoNoCorresponde,
                            FechaVisitaEstudio = rd.GetDateTime(5),
                            FechaPago = rd.GetDateTime(6),
                            MontoPago = objetoGestionLlamadas.MontoPago,
                            DuenoBien = objetoGestionLlamadas.DuenoBien,
                            NiegaPago = objetoGestionLlamadas.NiegaPago,
                            NombreTrabajador = rd.GetString(10),
                            HoraLlamada = objetoGestionLlamadas.HoraLlamada,
                            DetalleResultado = objetoGestionLlamadas.DetalleResultado,
                            NumGestion = objetoGestionLlamadas.NumGestion,
                            TipoSolucion = objetoGestionLlamadas.TipoSolucion,
                            CodigoGestionLlamada = rd.GetInt32(15),
                            DniTrabajador = rd.GetInt32(16),
                            CuentaBT = rd.GetString(17),
                            FechaVisitaEstudioString = objetoGestionLlamadas.FechaVisitaEstudioString,
                            FechaPagoString = objetoGestionLlamadas.FechaPagoString
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_GestionLlamadas> ReporteLamadaFechas(int codigo, DateTime fecha1, DateTime fecha2)
        {
            List<C_GestionLlamadas> lista = new List<C_GestionLlamadas>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_GestionLlamadas objetoGestionLlamadas = new C_GestionLlamadas();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT TELEFONO_CONTACTO, CONTACTO_CLIENTE, CONTACTO_PARIENTE, NOMBRE_PARIENTE, TELEFONO_NO_CORRESPONDE, FECHA_VISITA_ESTUDIO, FECHA_PAGO, MONTO_PAGO, DUENO_BIEN, NIEGA_PAGO, NOMBRE, HORA_LLAMADA, DETALLE_RESULTADO, NUM_GESTION, TIPO_SOLUCION, CODIGO_GESTION, DNI_TRABAJADOR,CUENTA_BT FROM VW_GESTIONLLAMADADGV WHERE DNI_TRABAJADOR = " + codigo + " and flag = 1 and codigo_tramite = 4 and FECHA_VISITA_ESTUDIO between '" + fecha1.ToShortDateString() + "' and '" + fecha2.ToShortDateString() + "' order by FECHA_VISITA_ESTUDIO asc;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //
                        if (rd[0] == DBNull.Value)
                            objetoGestionLlamadas.TelefonoContacto = " ";
                        else
                            objetoGestionLlamadas.TelefonoContacto = rd.GetString(0);
                        //
                        if (rd[1] == DBNull.Value)
                            objetoGestionLlamadas.ContactoCliente = " ";
                        else
                            objetoGestionLlamadas.ContactoCliente = rd.GetString(1);
                        //
                        if (rd[2] == DBNull.Value)
                            objetoGestionLlamadas.ContactoPariente = " ";
                        else
                            objetoGestionLlamadas.ContactoPariente = rd.GetString(2);
                        //
                        if (rd[3] == DBNull.Value)
                            objetoGestionLlamadas.NombrePariente = " ";
                        else
                            objetoGestionLlamadas.NombrePariente = rd.GetString(3);
                        //
                        if (rd[4] == DBNull.Value)
                            objetoGestionLlamadas.TelefonoNoCorresponde = " ";
                        else
                            objetoGestionLlamadas.TelefonoNoCorresponde = rd.GetString(4);
                        //
                        if (rd.GetDateTime(5) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionLlamadas.FechaVisitaEstudioString = " ";
                        }
                        else if (rd[5] != DBNull.Value)
                        {
                            objetoGestionLlamadas.FechaVisitaEstudioString = "" + rd.GetDateTime(5).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionLlamadas.FechaVisitaEstudioString = " ";
                        }
                        //
                        if (rd.GetDateTime(6) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionLlamadas.FechaPagoString = " ";
                        }
                        else if (rd[6] != DBNull.Value)
                        {
                            objetoGestionLlamadas.FechaPagoString = "" + rd.GetDateTime(6).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionLlamadas.FechaPagoString = " ";
                        }
                        //
                        if (rd[7] == DBNull.Value)
                            objetoGestionLlamadas.MontoPago = " ";
                        else
                            objetoGestionLlamadas.MontoPago = rd.GetString(7);
                        //
                        if (rd[8] == DBNull.Value)
                            objetoGestionLlamadas.DuenoBien = " ";
                        else
                            objetoGestionLlamadas.DuenoBien = rd.GetString(8);
                        //
                        if (rd[9] == DBNull.Value)
                            objetoGestionLlamadas.NiegaPago = " ";
                        else
                            objetoGestionLlamadas.NiegaPago = rd.GetString(9);
                        //
                        if (rd[10] == DBNull.Value)
                            objetoGestionLlamadas.NombreTrabajador = " ";
                        else
                            objetoGestionLlamadas.NombreTrabajador = rd.GetString(10);
                        //
                        if (rd[11] == DBNull.Value)
                            objetoGestionLlamadas.HoraLlamada = " ";
                        else
                            objetoGestionLlamadas.HoraLlamada = rd.GetString(11);
                        //
                        if (rd[12] == DBNull.Value)
                            objetoGestionLlamadas.DetalleResultado = " ";
                        else
                            objetoGestionLlamadas.DetalleResultado = rd.GetString(12);
                        //
                        if (rd[13] == DBNull.Value)
                            objetoGestionLlamadas.NumGestion = " ";
                        else
                            objetoGestionLlamadas.NumGestion = rd.GetString(13);
                        //
                        if (rd[14] == DBNull.Value)
                            objetoGestionLlamadas.TipoSolucion = " ";
                        else
                            objetoGestionLlamadas.TipoSolucion = rd.GetString(14);
                        //
                        lista.Add(new C_GestionLlamadas
                        {
                            TelefonoContacto = objetoGestionLlamadas.TelefonoContacto,
                            ContactoCliente = objetoGestionLlamadas.ContactoCliente,
                            ContactoPariente = objetoGestionLlamadas.ContactoPariente,
                            NombrePariente = objetoGestionLlamadas.NombrePariente,
                            TelefonoNoCorresponde = objetoGestionLlamadas.TelefonoNoCorresponde,
                            FechaVisitaEstudio = rd.GetDateTime(5),
                            FechaPago = rd.GetDateTime(6),
                            MontoPago = objetoGestionLlamadas.MontoPago,
                            DuenoBien = objetoGestionLlamadas.DuenoBien,
                            NiegaPago = objetoGestionLlamadas.NiegaPago,
                            NombreTrabajador = objetoGestionLlamadas.NombreTrabajador,
                            HoraLlamada = objetoGestionLlamadas.HoraLlamada,
                            DetalleResultado = objetoGestionLlamadas.DetalleResultado,
                            NumGestion = objetoGestionLlamadas.NumGestion,
                            TipoSolucion = objetoGestionLlamadas.TipoSolucion,
                            CodigoGestionLlamada = rd.GetInt32(15),
                            DniTrabajador = rd.GetInt32(16),
                            CuentaBT = rd.GetString(17),
                            FechaVisitaEstudioString = objetoGestionLlamadas.FechaVisitaEstudioString,
                            FechaPagoString = objetoGestionLlamadas.FechaPagoString
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
           
        }
        
        public List<C_GestionCampo> ReporteCampo(string codigo)
        {
            List<C_GestionCampo> lista = new List<C_GestionCampo>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_GestionCampo objetoGestionCampo = new C_GestionCampo();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT GESTION_CAMPO,CONTACTO_PARIENTE,NOMBRE_PARIENTE,NUEVO_DOM_TELE,DETALLE,FECHA_PAGO,MONTO_PAGO,FECHA_GESTION,DNI_TRABAJADOR,NOMBRE_PERSONA,DETALLE_RESULTADO,INUBICABLE,NUM_GESTION,DESCRIPCION_INMUEBLE,DUENO_BIEN,NIEGA_PAGO,HORA_LLAMADA,TIPO_SOLUCION,CODIGO_GESTION, CUENTA_BT FROM VW_GESTIONCAMPODGV WHERE CUENTA_BT = '" + codigo + "' and flag = 2 and codigo_tramite = 4;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //
                        if (rd[0] == DBNull.Value)
                            objetoGestionCampo.GestionCampo = " ";
                        else
                            objetoGestionCampo.GestionCampo = rd.GetString(0);
                        //
                        if (rd[1] == DBNull.Value)
                            objetoGestionCampo.ContactoPariente = " ";
                        else
                            objetoGestionCampo.ContactoPariente = rd.GetString(1);
                        //
                        if (rd[2] == DBNull.Value)
                            objetoGestionCampo.NombrePariente = " ";
                        else
                            objetoGestionCampo.NombrePariente = rd.GetString(2);
                        //
                        if (rd[3] == DBNull.Value)
                            objetoGestionCampo.NuevoDomTele = " ";
                        else
                            objetoGestionCampo.NuevoDomTele = rd.GetString(3);
                        //
                        if (rd[4] == DBNull.Value)
                            objetoGestionCampo.Detalle = " ";
                        else
                            objetoGestionCampo.Detalle = rd.GetString(4);
                        //
                        if (rd.GetDateTime(5) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionCampo.FechaPagoString = " ";
                        }
                        else if (rd[5] != DBNull.Value)
                        {
                            objetoGestionCampo.FechaPagoString = "" + rd.GetDateTime(5).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionCampo.FechaPagoString = " ";
                        }
                        //
                        if (rd[6] == DBNull.Value)
                            objetoGestionCampo.MontoPago = " ";
                        else
                            objetoGestionCampo.MontoPago = rd.GetString(6);
                        //
                        if (rd.GetDateTime(7) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionCampo.FechaGestionString = " ";
                        }
                        else if (rd[7] != DBNull.Value)
                        {
                            objetoGestionCampo.FechaGestionString = "" + rd.GetDateTime(7).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionCampo.FechaGestionString = " ";
                        }
                        //
                        if (rd[9] == DBNull.Value)
                            objetoGestionCampo.NombreTrabajador = " ";
                        else
                            objetoGestionCampo.NombreTrabajador = rd.GetString(9);
                        //
                        if (rd[10] == DBNull.Value)
                            objetoGestionCampo.DetalleResultado = " ";
                        else
                            objetoGestionCampo.DetalleResultado = rd.GetString(10);
                        //
                        if (rd[11] == DBNull.Value)
                            objetoGestionCampo.Inubicable = " ";
                        else
                            objetoGestionCampo.Inubicable = rd.GetString(11);
                        //
                        if (rd[12] == DBNull.Value)
                            objetoGestionCampo.NumGestion = " ";
                        else
                            objetoGestionCampo.NumGestion = rd.GetString(12);
                        //
                        if (rd[13] == DBNull.Value)
                            objetoGestionCampo.DescripcionInmueble = " ";
                        else
                            objetoGestionCampo.DescripcionInmueble = rd.GetString(13);
                        //
                        if (rd[14] == DBNull.Value)
                            objetoGestionCampo.DuenoBien = " ";
                        else
                            objetoGestionCampo.DuenoBien = rd.GetString(14);
                        //
                        if (rd[15] == DBNull.Value)
                            objetoGestionCampo.NiegaPago = " ";
                        else
                            objetoGestionCampo.NiegaPago = rd.GetString(15);
                        //
                        if (rd[16] == DBNull.Value)
                            objetoGestionCampo.HoraGestion = " ";
                        else
                            objetoGestionCampo.HoraGestion = rd.GetString(16);
                        //
                        if (rd[17] == DBNull.Value)
                            objetoGestionCampo.TipoSolucion = " ";
                        else
                            objetoGestionCampo.TipoSolucion = rd.GetString(17);
                        //
                        lista.Add(new C_GestionCampo
                        {
                            GestionCampo = objetoGestionCampo.GestionCampo,
                            ContactoPariente = objetoGestionCampo.ContactoPariente,
                            NombrePariente = objetoGestionCampo.NombrePariente,
                            NuevoDomTele = objetoGestionCampo.NuevoDomTele,
                            Detalle = objetoGestionCampo.Detalle,
                            FechaPago = rd.GetDateTime(5),
                            MontoPago = objetoGestionCampo.MontoPago,
                            FechaGestion = rd.GetDateTime(7),
                            DniTrabajador = rd.GetInt32(8),
                            NombreTrabajador = objetoGestionCampo.NombreTrabajador,
                            DetalleResultado = objetoGestionCampo.DetalleResultado,
                            Inubicable = objetoGestionCampo.Inubicable,
                            NumGestion = objetoGestionCampo.NumGestion,
                            DescripcionInmueble = objetoGestionCampo.DescripcionInmueble,
                            DuenoBien = objetoGestionCampo.DuenoBien,
                            NiegaPago = objetoGestionCampo.NiegaPago,
                            HoraGestion = objetoGestionCampo.HoraGestion,
                            TipoSolucion = objetoGestionCampo.NiegaPago,
                            Codigo = rd.GetInt32(18),
                            CuentaBT = rd.GetString(19),
                            FechaPagoString = objetoGestionCampo.FechaPagoString,
                            FechaGestionString = objetoGestionCampo.FechaGestionString
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_GestionCampo> ReporteCampoTodo()
        {
            List<C_GestionCampo> lista = new List<C_GestionCampo>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_GestionCampo objetoGestionCampo = new C_GestionCampo();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT GESTION_CAMPO,CONTACTO_PARIENTE,NOMBRE_PARIENTE,NUEVO_DOM_TELE,DETALLE,FECHA_PAGO,MONTO_PAGO,FECHA_GESTION,DNI_TRABAJADOR,NOMBRE_PERSONA,DETALLE_RESULTADO,INUBICABLE,NUM_GESTION,DESCRIPCION_INMUEBLE,DUENO_BIEN,NIEGA_PAGO,HORA_LLAMADA,TIPO_SOLUCION,CODIGO_GESTION, CUENTA_BT FROM VW_GESTIONCAMPODGV WHERE  flag = 2 and codigo_tramite = 4;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //
                        if (rd[0] == DBNull.Value)
                            objetoGestionCampo.GestionCampo = " ";
                        else
                            objetoGestionCampo.GestionCampo = rd.GetString(0);
                        //
                        if (rd[1] == DBNull.Value)
                            objetoGestionCampo.ContactoPariente = " ";
                        else
                            objetoGestionCampo.ContactoPariente = rd.GetString(1);
                        //
                        if (rd[2] == DBNull.Value)
                            objetoGestionCampo.NombrePariente = " ";
                        else
                            objetoGestionCampo.NombrePariente = rd.GetString(2);
                        //
                        if (rd[3] == DBNull.Value)
                            objetoGestionCampo.NuevoDomTele = " ";
                        else
                            objetoGestionCampo.NuevoDomTele = rd.GetString(3);
                        //
                        if (rd[4] == DBNull.Value)
                            objetoGestionCampo.Detalle = " ";
                        else
                            objetoGestionCampo.Detalle = rd.GetString(4);
                        //
                        if (rd.GetDateTime(5) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionCampo.FechaPagoString = " ";
                        }
                        else if (rd[5] != DBNull.Value)
                        {
                            objetoGestionCampo.FechaPagoString = "" + rd.GetDateTime(5).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionCampo.FechaPagoString = " ";
                        }
                        //
                        if (rd[6] == DBNull.Value)
                            objetoGestionCampo.MontoPago = " ";
                        else
                            objetoGestionCampo.MontoPago = rd.GetString(6);
                        //
                        if (rd.GetDateTime(7) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionCampo.FechaGestionString = " ";
                        }
                        else if (rd[7] != DBNull.Value)
                        {
                            objetoGestionCampo.FechaGestionString = "" + rd.GetDateTime(7).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionCampo.FechaGestionString = " ";
                        }
                        //
                        if (rd[9] == DBNull.Value)
                            objetoGestionCampo.NombreTrabajador = " ";
                        else
                            objetoGestionCampo.NombreTrabajador = rd.GetString(9);
                        //
                        if (rd[10] == DBNull.Value)
                            objetoGestionCampo.DetalleResultado = " ";
                        else
                            objetoGestionCampo.DetalleResultado = rd.GetString(10);
                        //
                        if (rd[11] == DBNull.Value)
                            objetoGestionCampo.Inubicable = " ";
                        else
                            objetoGestionCampo.Inubicable = rd.GetString(11);
                        //
                        if (rd[12] == DBNull.Value)
                            objetoGestionCampo.NumGestion = " ";
                        else
                            objetoGestionCampo.NumGestion = rd.GetString(12);
                        //
                        if (rd[13] == DBNull.Value)
                            objetoGestionCampo.DescripcionInmueble = " ";
                        else
                            objetoGestionCampo.DescripcionInmueble = rd.GetString(13);
                        //
                        if (rd[14] == DBNull.Value)
                            objetoGestionCampo.DuenoBien = " ";
                        else
                            objetoGestionCampo.DuenoBien = rd.GetString(14);
                        //
                        if (rd[15] == DBNull.Value)
                            objetoGestionCampo.NiegaPago = " ";
                        else
                            objetoGestionCampo.NiegaPago = rd.GetString(15);
                        //
                        if (rd[16] == DBNull.Value)
                            objetoGestionCampo.HoraGestion = " ";
                        else
                            objetoGestionCampo.HoraGestion = rd.GetString(16);
                        //
                        if (rd[17] == DBNull.Value)
                            objetoGestionCampo.TipoSolucion = " ";
                        else
                            objetoGestionCampo.TipoSolucion = rd.GetString(17);
                        //
                        lista.Add(new C_GestionCampo
                        {
                            GestionCampo = objetoGestionCampo.GestionCampo,
                            ContactoPariente = objetoGestionCampo.ContactoPariente,
                            NombrePariente = objetoGestionCampo.NombrePariente,
                            NuevoDomTele = objetoGestionCampo.NuevoDomTele,
                            Detalle = objetoGestionCampo.Detalle,
                            FechaPago = rd.GetDateTime(5),
                            MontoPago = objetoGestionCampo.MontoPago,
                            FechaGestion = rd.GetDateTime(7),
                            DniTrabajador = rd.GetInt32(8),
                            NombreTrabajador = objetoGestionCampo.NombreTrabajador,
                            DetalleResultado = objetoGestionCampo.DetalleResultado,
                            Inubicable = objetoGestionCampo.Inubicable,
                            NumGestion = objetoGestionCampo.NumGestion,
                            DescripcionInmueble = objetoGestionCampo.DescripcionInmueble,
                            DuenoBien = objetoGestionCampo.DuenoBien,
                            NiegaPago = objetoGestionCampo.NiegaPago,
                            HoraGestion = objetoGestionCampo.HoraGestion,
                            TipoSolucion = objetoGestionCampo.TipoSolucion,
                            Codigo = rd.GetInt32(18),
                            CuentaBT = rd.GetString(19),
                            FechaPagoString = objetoGestionCampo.FechaPagoString,
                            FechaGestionString = objetoGestionCampo.FechaGestionString

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_GestionCampo> ReporteCampito(int codigo)
        {
            List<C_GestionCampo> lista = new List<C_GestionCampo>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_GestionCampo objetoGestionCampo = new C_GestionCampo();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT GESTION_CAMPO,CONTACTO_PARIENTE,NOMBRE_PARIENTE,NUEVO_DOM_TELE,DETALLE,FECHA_PAGO,MONTO_PAGO,FECHA_GESTION,DNI_TRABAJADOR,NOMBRE_PERSONA,DETALLE_RESULTADO,INUBICABLE,NUM_GESTION,DESCRIPCION_INMUEBLE,DUENO_BIEN,NIEGA_PAGO,HORA_LLAMADA,TIPO_SOLUCION,CODIGO_GESTION, CUENTA_BT FROM VW_GESTIONCAMPODGV WHERE DNI_TRABAJADOR = " + codigo + " and flag = 2 and codigo_tramite = 4;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //
                        if (rd[0] == DBNull.Value)
                            objetoGestionCampo.GestionCampo = " ";
                        else
                            objetoGestionCampo.GestionCampo = rd.GetString(0);
                        //
                        if (rd[1] == DBNull.Value)
                            objetoGestionCampo.ContactoPariente = " ";
                        else
                            objetoGestionCampo.ContactoPariente = rd.GetString(1);
                        //
                        if (rd[2] == DBNull.Value)
                            objetoGestionCampo.NombrePariente = " ";
                        else
                            objetoGestionCampo.NombrePariente = rd.GetString(2);
                        //
                        if (rd[3] == DBNull.Value)
                            objetoGestionCampo.NuevoDomTele = " ";
                        else
                            objetoGestionCampo.NuevoDomTele = rd.GetString(3);
                        //
                        if (rd[4] == DBNull.Value)
                            objetoGestionCampo.Detalle = " ";
                        else
                            objetoGestionCampo.Detalle = rd.GetString(4);
                        //
                        if (rd.GetDateTime(5) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionCampo.FechaPagoString = " ";
                        }
                        else if (rd[5] != DBNull.Value)
                        {
                            objetoGestionCampo.FechaPagoString = "" + rd.GetDateTime(5).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionCampo.FechaPagoString = " ";
                        }
                        //
                        if (rd[6] == DBNull.Value)
                            objetoGestionCampo.MontoPago = " ";
                        else
                            objetoGestionCampo.MontoPago = rd.GetString(6);
                        //
                        if (rd.GetDateTime(7) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionCampo.FechaGestionString = " ";
                        }
                        else if (rd[7] != DBNull.Value)
                        {
                            objetoGestionCampo.FechaGestionString = "" + rd.GetDateTime(7).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionCampo.FechaGestionString = " ";
                        }
                        //
                        if (rd[9] == DBNull.Value)
                            objetoGestionCampo.NombreTrabajador = " ";
                        else
                            objetoGestionCampo.NombreTrabajador = rd.GetString(9);
                        //
                        if (rd[10] == DBNull.Value)
                            objetoGestionCampo.DetalleResultado = " ";
                        else
                            objetoGestionCampo.DetalleResultado = rd.GetString(10);
                        //
                        if (rd[11] == DBNull.Value)
                            objetoGestionCampo.Inubicable = " ";
                        else
                            objetoGestionCampo.Inubicable = rd.GetString(11);
                        //
                        if (rd[12] == DBNull.Value)
                            objetoGestionCampo.NumGestion = " ";
                        else
                            objetoGestionCampo.NumGestion = rd.GetString(12);
                        //
                        if (rd[13] == DBNull.Value)
                            objetoGestionCampo.DescripcionInmueble = " ";
                        else
                            objetoGestionCampo.DescripcionInmueble = rd.GetString(13);
                        //
                        if (rd[14] == DBNull.Value)
                            objetoGestionCampo.DuenoBien = " ";
                        else
                            objetoGestionCampo.DuenoBien = rd.GetString(14);
                        //
                        if (rd[15] == DBNull.Value)
                            objetoGestionCampo.NiegaPago = " ";
                        else
                            objetoGestionCampo.NiegaPago = rd.GetString(15);
                        //
                        if (rd[16] == DBNull.Value)
                            objetoGestionCampo.HoraGestion = " ";
                        else
                            objetoGestionCampo.HoraGestion = rd.GetString(16);
                        //
                        if (rd[17] == DBNull.Value)
                            objetoGestionCampo.TipoSolucion = " ";
                        else
                            objetoGestionCampo.TipoSolucion = rd.GetString(17);
                        //
                        lista.Add(new C_GestionCampo
                        {
                            GestionCampo = objetoGestionCampo.GestionCampo,
                            ContactoPariente = objetoGestionCampo.ContactoPariente,
                            NombrePariente = objetoGestionCampo.NombrePariente,
                            NuevoDomTele = objetoGestionCampo.NuevoDomTele,
                            Detalle = objetoGestionCampo.Detalle,
                            FechaPago = rd.GetDateTime(5),
                            MontoPago = objetoGestionCampo.MontoPago,
                            FechaGestion = rd.GetDateTime(7),
                            DniTrabajador = rd.GetInt32(8),
                            NombreTrabajador = objetoGestionCampo.NombreTrabajador,
                            DetalleResultado = objetoGestionCampo.DetalleResultado,
                            Inubicable = objetoGestionCampo.Inubicable,
                            NumGestion = objetoGestionCampo.NumGestion,
                            DescripcionInmueble = objetoGestionCampo.DescripcionInmueble,
                            DuenoBien = objetoGestionCampo.DuenoBien,
                            NiegaPago = objetoGestionCampo.NiegaPago,
                            HoraGestion = objetoGestionCampo.HoraGestion,
                            TipoSolucion = objetoGestionCampo.NiegaPago,
                            Codigo = rd.GetInt32(18),
                            CuentaBT = rd.GetString(19),
                            FechaPagoString = objetoGestionCampo.FechaPagoString,
                            FechaGestionString = objetoGestionCampo.FechaGestionString
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_GestionCampo> ReporteCampoFechas(int codigo, DateTime fecha1, DateTime fecha2)
        {
            List<C_GestionCampo> lista = new List<C_GestionCampo>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_GestionCampo objetoGestionCampo = new C_GestionCampo();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT GESTION_CAMPO,CONTACTO_PARIENTE,NOMBRE_PARIENTE,NUEVO_DOM_TELE,DETALLE,FECHA_PAGO,MONTO_PAGO,FECHA_GESTION,DNI_TRABAJADOR,NOMBRE_PERSONA,DETALLE_RESULTADO,INUBICABLE,NUM_GESTION,DESCRIPCION_INMUEBLE,DUENO_BIEN,NIEGA_PAGO,HORA_LLAMADA,TIPO_SOLUCION,CODIGO_GESTION, CUENTA_BT FROM VW_GESTIONCAMPODGV WHERE DNI_TRABAJADOR = " + codigo + " and flag = 2 and codigo_tramite = 4 and FECHA_GESTION between '" + fecha1.ToShortDateString() + "' and '" + fecha2.ToShortDateString() + "' order by fecha_gestion asc;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //
                        if (rd[0] == DBNull.Value)
                            objetoGestionCampo.GestionCampo = " ";
                        else
                            objetoGestionCampo.GestionCampo = rd.GetString(0);
                        //
                        if (rd[1] == DBNull.Value)
                            objetoGestionCampo.ContactoPariente = " ";
                        else
                            objetoGestionCampo.ContactoPariente = rd.GetString(1);
                        //
                        if (rd[2] == DBNull.Value)
                            objetoGestionCampo.NombrePariente = " ";
                        else
                            objetoGestionCampo.NombrePariente = rd.GetString(2);
                        //
                        if (rd[3] == DBNull.Value)
                            objetoGestionCampo.NuevoDomTele = " ";
                        else
                            objetoGestionCampo.NuevoDomTele = rd.GetString(3);
                        //
                        if (rd[4] == DBNull.Value)
                            objetoGestionCampo.Detalle = " ";
                        else
                            objetoGestionCampo.Detalle = rd.GetString(4);
                        //
                        if (rd.GetDateTime(5) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionCampo.FechaPagoString = " ";
                        }
                        else if (rd[5] != DBNull.Value)
                        {
                            objetoGestionCampo.FechaPagoString = "" + rd.GetDateTime(5).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionCampo.FechaPagoString = " ";
                        }
                        //
                        if (rd[6] == DBNull.Value)
                            objetoGestionCampo.MontoPago = " ";
                        else
                            objetoGestionCampo.MontoPago = rd.GetString(6);
                        //
                        if (rd.GetDateTime(7) == DateTime.Parse("01-01-1990"))
                        {
                            objetoGestionCampo.FechaGestionString = " ";
                        }
                        else if (rd[7] != DBNull.Value)
                        {
                            objetoGestionCampo.FechaGestionString = "" + rd.GetDateTime(7).ToShortDateString();
                        }
                        else
                        {
                            objetoGestionCampo.FechaGestionString = " ";
                        }
                        //
                        if (rd[9] == DBNull.Value)
                            objetoGestionCampo.NombreTrabajador = " ";
                        else
                            objetoGestionCampo.NombreTrabajador = rd.GetString(9);
                        //
                        if (rd[10] == DBNull.Value)
                            objetoGestionCampo.DetalleResultado = " ";
                        else
                            objetoGestionCampo.DetalleResultado = rd.GetString(10);
                        //
                        if (rd[11] == DBNull.Value)
                            objetoGestionCampo.Inubicable = " ";
                        else
                            objetoGestionCampo.Inubicable = rd.GetString(11);
                        //
                        if (rd[12] == DBNull.Value)
                            objetoGestionCampo.NumGestion = " ";
                        else
                            objetoGestionCampo.NumGestion = rd.GetString(12);
                        //
                        if (rd[13] == DBNull.Value)
                            objetoGestionCampo.DescripcionInmueble = " ";
                        else
                            objetoGestionCampo.DescripcionInmueble = rd.GetString(13);
                        //
                        if (rd[14] == DBNull.Value)
                            objetoGestionCampo.DuenoBien = " ";
                        else
                            objetoGestionCampo.DuenoBien = rd.GetString(14);
                        //
                        if (rd[15] == DBNull.Value)
                            objetoGestionCampo.NiegaPago = " ";
                        else
                            objetoGestionCampo.NiegaPago = rd.GetString(15);
                        //
                        if (rd[16] == DBNull.Value)
                            objetoGestionCampo.HoraGestion = " ";
                        else
                            objetoGestionCampo.HoraGestion = rd.GetString(16);
                        //
                        if (rd[17] == DBNull.Value)
                            objetoGestionCampo.TipoSolucion = " ";
                        else
                            objetoGestionCampo.TipoSolucion = rd.GetString(17);
                        //
                        lista.Add(new C_GestionCampo
                        {
                            GestionCampo = objetoGestionCampo.GestionCampo,
                            ContactoPariente = objetoGestionCampo.ContactoPariente,
                            NombrePariente = objetoGestionCampo.NombrePariente,
                            NuevoDomTele = objetoGestionCampo.NuevoDomTele,
                            Detalle = objetoGestionCampo.Detalle,
                            FechaPago = rd.GetDateTime(5),
                            MontoPago = objetoGestionCampo.MontoPago,
                            FechaGestion = rd.GetDateTime(7),
                            DniTrabajador = rd.GetInt32(8),
                            NombreTrabajador = objetoGestionCampo.NombreTrabajador,
                            DetalleResultado = objetoGestionCampo.DetalleResultado,
                            Inubicable = objetoGestionCampo.Inubicable,
                            NumGestion = objetoGestionCampo.NumGestion,
                            DescripcionInmueble = objetoGestionCampo.DescripcionInmueble,
                            DuenoBien = objetoGestionCampo.DuenoBien,
                            NiegaPago = objetoGestionCampo.NiegaPago,
                            HoraGestion = objetoGestionCampo.HoraGestion,
                            TipoSolucion = objetoGestionCampo.NiegaPago,
                            Codigo = rd.GetInt32(18),
                            CuentaBT = rd.GetString(19),
                            FechaPagoString = objetoGestionCampo.FechaPagoString,
                            FechaGestionString = objetoGestionCampo.FechaGestionString
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista; 
        }        

        public List<C_InformeJudicial> ReporteInformeJudicial(string codigo)
        {
            List<C_InformeJudicial> lista = new List<C_InformeJudicial>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_InformeJudicial objetoInformeJudicial = new C_InformeJudicial() ;
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT NOMBRE_COMPLETO, DOI_CLIENTE, NUM_EXPEDIENTE, JUZGADO, DESCRIPCION, NOMBRE_PROCESO, CUENTA_BT,FECHA_PROTESTO FROM VW_REPORTEINFORMEJUDICIAL WHERE CUENTA_BT = '"+codigo+"' AND FLAG = 1 AND CODIGO_TRAMITE = 4;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //
                        if (rd[0] == DBNull.Value)
                            objetoInformeJudicial.NombreTitular = " ";
                        else
                            objetoInformeJudicial.NombreTitular = rd.GetString(0);
                        //
                        if (rd[1] == DBNull.Value)
                            objetoInformeJudicial.Doi = " ";
                        else
                            objetoInformeJudicial.Doi = rd.GetString(1);
                        //
                        if (rd[2] == DBNull.Value)
                            objetoInformeJudicial.NumExpediente = " ";
                        else
                            objetoInformeJudicial.NumExpediente = rd.GetString(2);
                        //
                        if (rd[3] == DBNull.Value)
                            objetoInformeJudicial.Juzgado = " ";
                        else
                            objetoInformeJudicial.Juzgado = rd.GetString(3);
                        //
                        if (rd[4] == DBNull.Value)
                            objetoInformeJudicial.Descripcion = " ";
                        else
                            objetoInformeJudicial.Descripcion = rd.GetString(4);
                        //
                        if (rd[5] == DBNull.Value)
                            objetoInformeJudicial.NombreProceso = " ";
                        else
                            objetoInformeJudicial.NombreProceso = rd.GetString(5);
                        //
                        if (rd[6] == DBNull.Value)
                            objetoInformeJudicial.CuentaBT = " ";
                        else
                            objetoInformeJudicial.CuentaBT = rd.GetString(6);
                        if (rd.GetDateTime(7) == DateTime.Parse("01-01-1990"))
                        {
                            objetoInformeJudicial.FechaProtestoString = " ";
                        }
                        else if (rd[7] != DBNull.Value)
                        {
                            objetoInformeJudicial.FechaProtestoString = "" + rd.GetDateTime(7).ToShortDateString();
                        }
                        else
                        {
                            objetoInformeJudicial.FechaProtestoString = " ";
                        }
                        lista.Add(new C_InformeJudicial
                        {
                            NombreTitular = objetoInformeJudicial.NombreTitular,
                            Doi = objetoInformeJudicial.Doi,
                            NumExpediente = objetoInformeJudicial.NumExpediente,
                            Juzgado = objetoInformeJudicial.Juzgado,
                            Descripcion = objetoInformeJudicial.Descripcion,
                            NombreProceso = objetoInformeJudicial.NombreProceso,
                            CuentaBT = objetoInformeJudicial.CuentaBT,
                            FechaProtesto = rd.GetDateTime(7),
                            FechaProtestoString = objetoInformeJudicial.FechaProtestoString
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
        }
        public List<C_InformeJudicial> ReporteInformeJudicialTodo()
        {
            List<C_InformeJudicial> lista = new List<C_InformeJudicial>();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            C_InformeJudicial objetoInformeJudicial = new C_InformeJudicial();
            try
            {

                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT NOMBRE_COMPLETO, DOI_CLIENTE, NUM_EXPEDIENTE, JUZGADO, DESCRIPCION, NOMBRE_PROCESO, CUENTA_BT, FECHA_PROTESTO FROM VW_REPORTEINFORMEJUDICIAL WHERE  FLAG = 1 AND CODIGO_TRAMITE = 4;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        //
                        if (rd[0] == DBNull.Value)
                            objetoInformeJudicial.NombreTitular = " ";
                        else
                            objetoInformeJudicial.NombreTitular = rd.GetString(0);
                        //
                        if (rd[1] == DBNull.Value)
                            objetoInformeJudicial.Doi = " ";
                        else
                            objetoInformeJudicial.Doi = rd.GetString(1);
                        //
                        if (rd[2] == DBNull.Value)
                            objetoInformeJudicial.NumExpediente = " ";
                        else
                            objetoInformeJudicial.NumExpediente = rd.GetString(2);
                        //
                        if (rd[3] == DBNull.Value)
                            objetoInformeJudicial.Juzgado = " ";
                        else
                            objetoInformeJudicial.Juzgado = rd.GetString(3);
                        //
                        if (rd[4] == DBNull.Value)
                            objetoInformeJudicial.Descripcion = " ";
                        else
                            objetoInformeJudicial.Descripcion = rd.GetString(4);
                        //
                        if (rd[5] == DBNull.Value)
                            objetoInformeJudicial.NombreProceso = " ";
                        else
                            objetoInformeJudicial.NombreProceso = rd.GetString(5);
                        //
                        if (rd[6] == DBNull.Value)
                            objetoInformeJudicial.CuentaBT = " ";
                        else
                            objetoInformeJudicial.CuentaBT = rd.GetString(6);
                        //
                        if (rd.GetDateTime(7) == DateTime.Parse("01-01-1990"))
                        {
                            objetoInformeJudicial.FechaProtestoString = " ";
                        }
                        else if (rd[7] != DBNull.Value)
                        {
                            objetoInformeJudicial.FechaProtestoString = "" + rd.GetDateTime(7).ToShortDateString();
                        }
                        else
                        {
                            objetoInformeJudicial.FechaProtestoString = " ";
                        }
                        lista.Add(new C_InformeJudicial
                        {
                            NombreTitular = objetoInformeJudicial.NombreTitular,
                            Doi = objetoInformeJudicial.Doi,
                            NumExpediente = objetoInformeJudicial.NumExpediente,
                            Juzgado = objetoInformeJudicial.Juzgado,
                            Descripcion = objetoInformeJudicial.Descripcion,
                            NombreProceso = objetoInformeJudicial.NombreProceso,
                            CuentaBT = objetoInformeJudicial.CuentaBT,
                            FechaProtesto = rd.GetDateTime(7),
                            FechaProtestoString = objetoInformeJudicial.FechaProtestoString
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
 
 
        }

        public List<C_SolicitudAdelanto> ReporteSolicitudAdelanto(string codigo)
        {
            List<C_SolicitudAdelanto> lista = new List<C_SolicitudAdelanto>();
            C_SolicitudAdelanto objetoSolicitudAdelanto = new C_SolicitudAdelanto();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT ESTUDIO, CIUDAD, NOMBRE_COMPLETO, DOI_CLIENTE, '' AS MONTO, '' AS PROVEEDOR, NUM_EXPEDIENTE, CARTERA, '' AS DEMANDANTE, '' AS DEMANDADO, JUZGADO, '' AS MOTIVO,'' AS CONCEPTO FROM VW_INFORMESOLICITUDADELANTO WHERE CUENTA_BT ='"+codigo+"' AND FLAG = 1 AND CODIGO_TRAMITE = 4;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Nombreestudio = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Nombreestudio = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Nombreciudad = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Nombreciudad = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.NombreCompleto = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.NombreCompleto = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Doi_cliente = rd.GetString(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Monto_demandado = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Monto_demandado = rd.GetString(4);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Proveedor = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Proveedor = rd.GetString(5);
                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Num_expediente = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Num_expediente = rd.GetString(6);
                        }
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Nombrecartera = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Nombrecartera = rd.GetString(7);
                        }
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Demandante = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Demandante = rd.GetString(8);
                        }
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Demandado = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Demandado = rd.GetString(9);
                        }
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Num_juzgado = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Num_juzgado = rd.GetString(10);
                        }
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Motivojuicio = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Motivojuicio = rd.GetString(11);
                        }
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Concepto = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Concepto = rd.GetString(12);
                        }
                        lista.Add(new C_SolicitudAdelanto
                        {
                            Nombreestudio = objetoSolicitudAdelanto.Nombreestudio,
                            Nombreciudad = objetoSolicitudAdelanto.Nombreciudad,
                            NombreCompleto = objetoSolicitudAdelanto.NombreCompleto,
                            Doi_cliente = objetoSolicitudAdelanto.Doi_cliente,
                            Monto_demandado = objetoSolicitudAdelanto.Monto_demandado,
                            Proveedor = objetoSolicitudAdelanto.Proveedor,
                            Num_expediente = objetoSolicitudAdelanto.Num_expediente,
                            Nombrecartera = objetoSolicitudAdelanto.Nombrecartera,
                            Demandante = objetoSolicitudAdelanto.Demandante,
                            Demandado = objetoSolicitudAdelanto.Demandado,
                            Num_juzgado = objetoSolicitudAdelanto.Num_juzgado,
                            Motivojuicio = objetoSolicitudAdelanto.Motivojuicio,
                            Concepto = objetoSolicitudAdelanto.Concepto
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_SolicitudAdelanto> ReporteSolicitudAdelantoTodo()
        {
            List<C_SolicitudAdelanto> lista = new List<C_SolicitudAdelanto>();
            C_SolicitudAdelanto objetoSolicitudAdelanto = new C_SolicitudAdelanto();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT ESTUDIO, CIUDAD, NOMBRE_COMPLETO, DOI_CLIENTE, '' AS MONTO, '' AS PROVEEDOR, NUM_EXPEDIENTE, CARTERA, '' AS DEMANDANTE, '' AS DEMANDADO, JUZGADO, '' AS MOTIVO,'' AS CONCEPTO FROM VW_INFORMESOLICITUDADELANTO WHERE FLAG = 1 AND CODIGO_TRAMITE = 4;" , cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Nombreestudio = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Nombreestudio = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Nombreciudad = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Nombreciudad = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.NombreCompleto = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.NombreCompleto = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Doi_cliente = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Doi_cliente = rd.GetString(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Monto_demandado = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Monto_demandado = rd.GetString(4);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Proveedor = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Proveedor = rd.GetString(5);
                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Num_expediente = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Num_expediente = rd.GetString(6);
                        }
                        if (rd[7] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Nombrecartera = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Nombrecartera = rd.GetString(7);
                        }
                        if (rd[8] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Demandante = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Demandante = rd.GetString(8);
                        }
                        if (rd[9] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Demandado = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Demandado = rd.GetString(9);
                        }
                        if (rd[10] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Num_juzgado = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Num_juzgado = rd.GetString(10);
                        }
                        if (rd[11] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Motivojuicio = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Motivojuicio = rd.GetString(11);
                        }
                        if (rd[12] == DBNull.Value)
                        {
                            objetoSolicitudAdelanto.Concepto = " ";
                        }
                        else
                        {
                            objetoSolicitudAdelanto.Concepto = rd.GetString(12);
                        }
                        lista.Add(new C_SolicitudAdelanto
                        {
                            Nombreestudio = objetoSolicitudAdelanto.Nombreestudio,
                            Nombreciudad = objetoSolicitudAdelanto.Nombreciudad,
                            NombreCompleto = objetoSolicitudAdelanto.NombreCompleto,
                            Doi_cliente = objetoSolicitudAdelanto.Doi_cliente,
                            Monto_demandado = objetoSolicitudAdelanto.Monto_demandado,
                            Proveedor = objetoSolicitudAdelanto.Proveedor,
                            Num_expediente = objetoSolicitudAdelanto.Num_expediente,
                            Nombrecartera = objetoSolicitudAdelanto.Nombrecartera,
                            Demandante = objetoSolicitudAdelanto.Demandante,
                            Demandado = objetoSolicitudAdelanto.Demandado,
                            Num_juzgado = objetoSolicitudAdelanto.Num_juzgado,
                            Motivojuicio = objetoSolicitudAdelanto.Motivojuicio,
                            Concepto = objetoSolicitudAdelanto.Concepto
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }

        public List<C_InformeSSI> ReporteInformeSSI(string codigo)
        {
            List<C_InformeSSI> lista = new List<C_InformeSSI>();
            C_InformeSSI objetoInforme = new C_InformeSSI();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT DOI_CLIENTE, NOMBRE_COMPLETO, NOMBRE_GARANTE,  NOMBRE_CARTERA, NOMBRE_MODELO, '' AS SECTORISTA, NOMBRE_ESTUDIO, 'SUR' AS REGION, NOMBRE_CIUDAD, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE, NOMBRE_MONEDA, MONTO_DEMANDADO, RESUMEN_PROCESO FROM VW_REPORTEINFORMESSI WHERE CUENTA_BT = '" +codigo + "' AND CODIGO_TRAMITE = 4 AND FLAG = 1;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoInforme.Doi = " ";
                        }
                        else
                        {
                            objetoInforme.Doi = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoInforme.NombreCliente = " ";
                        }
                        else
                        {
                            objetoInforme.NombreCliente = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoInforme.NombreGarante = " ";
                        }
                        else
                        {
                            objetoInforme.NombreGarante = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoInforme.Cartera = " ";
                        }
                        else
                        {
                            objetoInforme.Cartera = rd.GetString(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoInforme.Modelo = " ";
                        }
                        else
                        {
                            objetoInforme.Modelo = rd.GetString(4);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoInforme.Sectorista = " ";
                        }
                        else
                        {
                            objetoInforme.Sectorista = rd.GetString(5);

                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoInforme.Estudio = " ";
                        }
                        else
                        {
                            objetoInforme.Estudio = rd.GetString(6);
                        }

                        if (rd[7] == DBNull.Value)
                        {
                            objetoInforme.Region = " ";
                        }
                        else
                        {
                            objetoInforme.Region = rd.GetString(7);

                        }
                        if (rd[8] == DBNull.Value)
                        {
                            objetoInforme.Ciudad = " ";
                        }
                        else
                        {
                            objetoInforme.Ciudad = rd.GetString(8);

                        }
                        if (rd[9] == DBNull.Value)
                        {
                            objetoInforme.TipoProceso = " ";
                        }
                        else
                        {
                            objetoInforme.TipoProceso = rd.GetString(9);

                        }
                        if (rd[10] == DBNull.Value)
                        {
                            objetoInforme.Juzgado = " ";
                        }
                        else
                        {
                            objetoInforme.Juzgado = rd.GetString(10);
                        }
                        if (rd[11] == DBNull.Value)
                        {
                            objetoInforme.NumJuzgado = " ";
                        }
                        else
                        {
                            objetoInforme.NumJuzgado = rd.GetString(11);
                        }
                        if (rd[12] == DBNull.Value)
                        {
                            objetoInforme.Moneda = " ";
                        }
                        else
                        {
                            objetoInforme.Moneda = rd.GetString(12);
                        }
                        if (rd[13] == DBNull.Value)
                        {
                            objetoInforme.MontoAdmitido = " ";
                        }
                        else
                        {
                            objetoInforme.MontoAdmitido = rd.GetString(13);
                        }
                        if (rd[14] == DBNull.Value)
                        {
                            objetoInforme.Resumen = " ";
                        }
                        else
                        {
                            objetoInforme.Resumen = rd.GetString(14);
                        }

                        lista.Add(new C_InformeSSI
                        {
                            Doi = objetoInforme.Doi,
                            NombreCliente = objetoInforme.NombreCliente,
                            NombreGarante = objetoInforme.NombreGarante,
                            Cartera = objetoInforme.Cartera,
                            Modelo = objetoInforme.Modelo,
                            Sectorista = objetoInforme.Sectorista,
                            Estudio = objetoInforme.Estudio,
                            Region = objetoInforme.Region,
                            Ciudad = objetoInforme.Ciudad,
                            TipoProceso = objetoInforme.TipoProceso,
                            Juzgado = objetoInforme.Juzgado,
                            NumJuzgado = objetoInforme.NumJuzgado,
                            Moneda = objetoInforme.Moneda,
                            MontoAdmitido = objetoInforme.MontoAdmitido,
                            Resumen = objetoInforme.Resumen
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }
        public List<C_InformeSSI> ReporteInformeSSITodo()
        {
            List<C_InformeSSI> lista = new List<C_InformeSSI>();
            C_InformeSSI objetoInforme = new C_InformeSSI();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT DOI_CLIENTE, NOMBRE_COMPLETO, NOMBRE_GARANTE,  NOMBRE_CARTERA, NOMBRE_MODELO, '' AS SECTORISTA, NOMBRE_ESTUDIO, 'SUR' AS REGION, NOMBRE_CIUDAD, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE, NOMBRE_MONEDA, MONTO_DEMANDADO, RESUMEN_PROCESO FROM VW_REPORTEINFORMESSI WHERE CODIGO_TRAMITE = 4 AND FLAG = 1;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoInforme.Doi = " ";
                        }
                        else
                        {
                           objetoInforme.Doi = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                           objetoInforme.NombreCliente = " ";
                        }
                        else
                        {
                            objetoInforme.NombreCliente = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoInforme.NombreGarante = " ";
                        }
                        else
                        {
                            objetoInforme.NombreGarante = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoInforme.Cartera = " ";
                        }
                        else
                        {
                            objetoInforme.Cartera = rd.GetString(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoInforme.Modelo = " ";
                        }
                        else
                        {
                            objetoInforme.Modelo = rd.GetString(4);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoInforme.Sectorista = " ";
                        }
                        else
                        {
                            objetoInforme.Sectorista = rd.GetString(5);

                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoInforme.Estudio = " ";
                        }
                        else
                        {
                            objetoInforme.Estudio = rd.GetString(6);
                        }

                        if (rd[7] == DBNull.Value)
                        {
                            objetoInforme.Region = " ";
                        }
                        else
                        {
                            objetoInforme.Region = rd.GetString(7);

                        }
                        if (rd[8] == DBNull.Value)
                        {
                            objetoInforme.Ciudad = " ";
                        }
                        else
                        {
                            objetoInforme.Ciudad = rd.GetString(8);

                        }
                        if (rd[9] == DBNull.Value)
                        {
                            objetoInforme.TipoProceso = " ";
                        }
                        else
                        {
                            objetoInforme.TipoProceso = rd.GetString(9);

                        }
                        if (rd[10] == DBNull.Value)
                        {
                            objetoInforme.Juzgado = " ";
                        }
                        else
                        {
                            objetoInforme.Juzgado = rd.GetString(10);
                        }
                        if (rd[11] == DBNull.Value)
                        {
                            objetoInforme.NumJuzgado = " ";
                        }
                        else
                        {
                            objetoInforme.NumJuzgado = rd.GetString(11);
                        }
                        if (rd[12] == DBNull.Value)
                        {
                            objetoInforme.Moneda = " ";
                        }
                        else 
                        {
                            objetoInforme.Moneda = rd.GetString(12);
                        }
                        if (rd[13] == DBNull.Value)
                        {
                            objetoInforme.MontoAdmitido = " ";
                        }
                        else
                        {
                            objetoInforme.MontoAdmitido = rd.GetString(13);
                        }
                        if (rd[14] == DBNull.Value)
                        {
                            objetoInforme.Resumen = " ";
                        }
                        else
                        {
                            objetoInforme.Resumen = rd.GetString(14);
                        }

                        lista.Add(new C_InformeSSI
                        {
                            Doi = objetoInforme.Doi,
                            NombreCliente = objetoInforme.NombreCliente,
                            NombreGarante = objetoInforme.NombreGarante,
                            Cartera = objetoInforme.Cartera,
                            Modelo = objetoInforme.Modelo,
                            Sectorista = objetoInforme.Sectorista,
                            Estudio = objetoInforme.Estudio,
                            Region = objetoInforme.Region,
                            Ciudad = objetoInforme.Ciudad,
                            TipoProceso = objetoInforme.TipoProceso,
                            Juzgado = objetoInforme.Juzgado,
                            NumJuzgado = objetoInforme.NumJuzgado,
                            Moneda = objetoInforme.Moneda,
                            MontoAdmitido = objetoInforme.MontoAdmitido,
                            Resumen = objetoInforme.Resumen
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista; 
        }

        //Reportes para Perú Abogados

        public List<C_InformeSSI> ReporteModeloB()
        {
            List<C_InformeSSI> lista = new List<C_InformeSSI>();
            C_InformeSSI objetoInforme = new C_InformeSSI();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT CUENTA_BT, DOI_CLIENTE, NOMBRE_COMPLETO, NOMBRE_GARANTE, NOMBRE_CARTERA, NOMBRE_MODELO, SECTORISTA, NOMBRE_ESTUDIO, REGION, NOMBRE_CIUDAD, NOMBRE_PROCESO, JUZGADO, NUM_EXPEDIENTE_22DIGITOS, OPERACION, NOMBRE_MONEDA, MONTO_ADMITIDO, TEXTO_PROCESO, FECHA_DEMANDA, FECHA_MANDATO, FECHA_CONTRADICCION, FECHA_DE_SENTENCIA, FECHA_DE_APELACION FROM VW_MODELO_B WHERE CODIGO_TRAMITE = 4", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoInforme.Cuenta_bt = " ";
                        }
                        else
                        {
                            objetoInforme.Cuenta_bt = rd.GetString(0);
                        }
                        if (rd[1] == DBNull.Value)
                        {
                            objetoInforme.Doi = " ";
                        }
                        else
                        {
                            objetoInforme.Doi = rd.GetString(1);
                        }
                        if (rd[2] == DBNull.Value)
                        {
                            objetoInforme.NombreCliente = " ";
                        }
                        else
                        {
                            objetoInforme.NombreCliente = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoInforme.NombreGarante = " ";
                        }
                        else
                        {
                            objetoInforme.NombreGarante = rd.GetString(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoInforme.Cartera = " ";
                        }
                        else
                        {
                            objetoInforme.Cartera = rd.GetString(4);
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoInforme.Modelo = " ";
                        }
                        else
                        {
                            objetoInforme.Modelo = rd.GetString(5);

                        }
                        if (rd[6] == DBNull.Value)
                        {
                            objetoInforme.Sectorista = " ";
                        }
                        else
                        {
                            objetoInforme.Sectorista = rd.GetString(6);
                        }

                        if (rd[7] == DBNull.Value)
                        {
                            objetoInforme.Estudio = " ";
                        }
                        else
                        {
                            objetoInforme.Estudio = rd.GetString(7);

                        }
                        if (rd[8] == DBNull.Value)
                        {
                            objetoInforme.Region = " ";
                        }
                        else
                        {
                            objetoInforme.Region = rd.GetString(8);

                        }
                        if (rd[9] == DBNull.Value)
                        {
                            objetoInforme.Ciudad = " ";
                        }
                        else
                        {
                            objetoInforme.Ciudad = rd.GetString(9);

                        }
                        if (rd[10] == DBNull.Value)
                        {
                            objetoInforme.TipoProceso = " ";
                        }
                        else
                        {
                            objetoInforme.TipoProceso = rd.GetString(10);
                        }
                        if (rd[11] == DBNull.Value)
                        {
                            objetoInforme.Juzgado = " ";
                        }
                        else
                        {
                            objetoInforme.Juzgado = rd.GetString(11);
                        }
                        if (rd[12] == DBNull.Value)
                        {
                            objetoInforme.NumJuzgado = " ";
                        }
                        else
                        {
                            objetoInforme.NumJuzgado = rd.GetString(12);
                        }
                        if (rd[13] == DBNull.Value)
                        {
                            objetoInforme.Moneda = " ";
                        }
                        else
                        {
                            objetoInforme.Moneda = rd.GetString(13);
                        }
                        if (rd[14] == DBNull.Value)
                        {
                            objetoInforme.MontoAdmitido = " ";
                        }
                        else
                        {
                            objetoInforme.MontoAdmitido = rd.GetString(14);
                        }
                        if (rd[15] == DBNull.Value)
                        {
                            objetoInforme.Resumen = " ";
                        }
                        else
                        {
                            objetoInforme.Resumen = rd.GetString(15);
                        }
                        //
                        if (rd.GetDateTime(16) == DateTime.Parse("01-01-1990"))
                        {
                            objetoInforme.FechaDemanda = " ";
                        }
                        else if (rd[16] != DBNull.Value)
                        {
                            objetoInforme.FechaDemanda = "" + rd.GetDateTime(16).ToShortDateString();
                        }
                        else
                        {
                            objetoInforme.FechaDemanda = " ";
                        }
                        //
                        if (rd.GetDateTime(17) == DateTime.Parse("01-01-1990"))
                        {
                            objetoInforme.FechaMandato = " ";
                        }
                        else if (rd[17] != DBNull.Value)
                        {
                            objetoInforme.FechaMandato = "" + rd.GetDateTime(17).ToShortDateString();
                        }
                        else 
                        {
                            objetoInforme.FechaMandato = " ";
                        }
                        //
                        if (rd.GetDateTime(18) == DateTime.Parse("01-01-1990"))
                        {
                            objetoInforme.FechaContradiccion = " ";
                        }
                        else if (rd[18] != DBNull.Value)
                        {
                            objetoInforme.FechaContradiccion = "" + rd.GetDateTime(18).ToShortDateString();
                        }
                        else
                        {
                            objetoInforme.FechaContradiccion = " ";
                        }
                        //
                        if (rd[19] != DBNull.Value)
                        {
                            objetoInforme.FechaSentencia = " ";
                        }
                        else
                        {
                            objetoInforme.FechaSentencia = rd.GetString(19);
                        }
                        //
                        if (rd[20] != DBNull.Value)
                        {
                            objetoInforme.FechaApelacion = " ";
                        }
                        else
                        {
                            objetoInforme.FechaApelacion = rd.GetString(20);
                        }
                        lista.Add(new C_InformeSSI
                        {
                            Doi = objetoInforme.Doi,
                            NombreCliente = objetoInforme.NombreCliente,
                            NombreGarante = objetoInforme.NombreGarante,
                            Cartera = objetoInforme.Cartera,
                            Modelo = objetoInforme.Modelo,
                            Sectorista = objetoInforme.Sectorista,
                            Estudio = objetoInforme.Estudio,
                            Region = objetoInforme.Region,
                            Ciudad = objetoInforme.Ciudad,
                            TipoProceso = objetoInforme.TipoProceso,
                            Juzgado = objetoInforme.Juzgado,
                            NumJuzgado = objetoInforme.NumJuzgado,
                            Moneda = objetoInforme.Moneda,
                            MontoAdmitido = objetoInforme.MontoAdmitido,
                            Resumen = objetoInforme.Resumen
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista; 
 
        }

        public List<C_Proyeccion> ReportePrueba()
        {
            List<C_Proyeccion> lista = new List<C_Proyeccion>();
            C_Proyeccion objetoProyeccion = new C_Proyeccion();
            NpgsqlConnection cnn = new NpgsqlConnection(cadenaConexion);
            try
            {
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT TEXTO_PROCESO, FLAG, TEXTO_LLAMADA,TEXTO_CAMPO,NUM_EXPEDIENTE,CUENTA_BT FROM VW_VISTA_HISTORICO;", cnn);
                cmd.CommandType = System.Data.CommandType.Text;
                NpgsqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0] == DBNull.Value)
                        {
                            objetoProyeccion.Proceso = " ";
                        }
                        else
                        {
                            objetoProyeccion.Proceso = rd.GetString(0);
                        }

                        if (rd[2] == DBNull.Value)
                        {
                            objetoProyeccion.Llamada = " ";
                        }
                        else
                        {
                            objetoProyeccion.Llamada = rd.GetString(2);
                        }
                        if (rd[3] == DBNull.Value)
                        {
                            objetoProyeccion.Campo = " ";
                        }
                        else
                        {
                            objetoProyeccion.Campo = rd.GetString(3);
                        }
                        if (rd[4] == DBNull.Value)
                        {
                            objetoProyeccion.NumExpediente = " ";
                        }
                        else
                        {
                            objetoProyeccion.NumExpediente = rd.GetString(4);
                            
                        }
                        if (rd[5] == DBNull.Value)
                        {
                            objetoProyeccion.CuentaBT = " ";
                            
                        }
                        else
                        {
                            objetoProyeccion.CuentaBT = rd.GetString(5);
                            
                        }
                        lista.Add(new C_Proyeccion
                        {
                            Proceso = objetoProyeccion.Proceso,
                            Flag = rd.GetInt32(1),
                            Llamada = objetoProyeccion.Llamada,
                            Campo = objetoProyeccion.Campo,
                            CuentaBT = objetoProyeccion.CuentaBT,
                            NumExpediente = objetoProyeccion.NumExpediente
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar", ex);
            }
            finally
            {
                cnn.Close();
            }
            return lista;
        }

    }

}

  
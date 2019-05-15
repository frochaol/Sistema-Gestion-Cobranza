using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_gestion")]
    [Table("gestion")]
    class Gestion
    {
        [Column("codigo_gestion", PrimaryKey = true)]
        private int codigoGestion;

        [Column("dni_trabajador", ManyToOne="dni_trabajador")]
        private int dniTrabajador;

        [Column("num_expediente", ManyToOne = "num_expediente")]
        private string numExpediente;

        [Column("telefono_contacto")]
        private string telefonoContacto;

        [Column("contacto_cliente")]
        private string ContactoCliente;

        [Column("contacto_pariente")]
        private string ContactoPariente;

        [Column("telefono_no_corresponde")]
        private string telefonoNoCorresponde;

        [Column("fecha_visita_estudio")]
        private DateTime fechaVisitaEstudio;

        [Column("fecha_pago")]
        private DateTime fechaPago;

        [Column("monto_pago")]
        private string montoPago;

        [Column("detalle_resultado")]
        private string detalleResultado;

        [Column("num_gestion")]
        private string numGestion;

        [Column("gestion_campo")]
        private string gestionCampo;

        [Column("nombre_pariente")]
        private string nombrePariente;

        [Column("nuevo_dom_tele")]
        private string nuevoDomicilioTelefono;

        [Column("detalle")]
        private string detalle;

        [Column("fecha_gestion")]
        private DateTime fechaGestion;

        [Column("descripcion_inmueble")]
        private string descripcionInmueble;

        [Column("inubicable")]
        private string inubicable;

        [Column("flag")]
        private int flag;

        [Column("dueno_bien")]
        private string duenioBien;

        [Column("tipo_solucion")]
        private string tipoSolucion;

        [Column("hora_llamda")]
        private string horaLlamada;

        [Column("reporte")]
        private string reporte;




    }
}

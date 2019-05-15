using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_proceso")]
    [Table("proceso")]
    class Proceso
    {
        [Column("codigo_proceso", PrimaryKey = true)]
        private int codigoProceso;

        [Column("codigo_macro", ManyToOne="codigo_macro")]
        private int codigoMacroEtapa;

        [Column("codigo_micro", ManyToOne = "codigo_micro")]
        private int codigoMicroEtapa;

        [Column("codigo_medida", ManyToOne = "codigo_medida")]
        private int codigoMedidaCautelar;

        [Column("num_expediente", ManyToOne = "num_expediente")]
        private string numExpediente;

        [Column("tiempo")]
        private string tiempo;

        [Column("fecha_etapa")]
        private DateTime fechaEtapa;

        [Column("fecha_inscripcion")]
        private DateTime fechaInscripcion;

        [Column("estadoCautelar")]
        private string estadoCautelar;

        [Column("fecha_medida_cautelar")]
        private DateTime fechaMedidaCautelar;

        [Column("vigencia_mc")]
        private string vigenciaMc;

        [Column("fecha_actuado_cautelar")]
        private DateTime fechaActuadoCautelar;

        [Column("devolucion_cedula")]
        private string devolucionCedula;


    }
}

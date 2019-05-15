using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_fechas")]
    [Table("fechas")]
    class Fechas
    {
        [Column("codigo_fechas", PrimaryKey = true)]
        private int codigoFechas;

        [Column("num_expediente", ManyToOne="num_expediente" )]
        private string numExpediente;

        [Column("fecha_mandato")]
        private DateTime fechaMandato;

        [Column("fecha_contradiccion")]
        private DateTime fechaContradiccion;

        [Column("fecha_orden")]
        private DateTime fechaOrden;

        [Column("fecha_rematecaptura")]
        private DateTime fechaRemateCaptura;

        [Column("fecha_adjucaptura")]
        private DateTime fechaAdjuCaptura;

        [Column("fecha_demanda")]
        private DateTime fechaDemanda;

        [Column("fecha_auto_final")]
        private DateTime fechaAutoFinal;

        [Column("fecha_apelacion")]
        private DateTime fechaApelacion;
    }
}

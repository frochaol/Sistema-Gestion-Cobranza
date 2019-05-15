using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_pagos")]
    [Table("pagos")]
    class Pagos
    {
        [Column("codigo", PrimaryKey = true)]
        private int codigoPagos;

        [Column("num_expediente", ManyToOne="num_expediente")]
        private string numExpediente;

        [Column("tipo_solucion")]
        private string tipoSolucion;

        [Column("pago")]
        private string pago;

        [Column("comision")]
        private string comision;

        [Column("fecha_pago")]
        private DateTime fechaPago;


    }
}

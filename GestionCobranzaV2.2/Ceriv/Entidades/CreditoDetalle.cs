using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_creditoDetalle")]
    [Table("credito_detalle")]
    class CreditoDetalle
    {
        [Column("operacion", PrimaryKey = true)]
        private string operacion;

        [Column("cuenta_bt", ManyToOne = "cuenta_bt" )]
        private string cuentaBt;

        [Column("codigo_cartera", ManyToOne = "codigo_cartera")]
        private int codigoCartera;

        [Column("codigo_moneda", ManyToOne = "codigo_moneda")]
        private int codigoMoneda;

        [Column("codigo_ciudad", ManyToOne = "codigo_ciudad")]
        private int codigoCiudad;

        [Column("codigo_estudio", ManyToOne = "codigo_estudio")]
        private int codigoEstudio;

        [Column("codigo_tramite", ManyToOne = "codigo_tramite")]
        private int codigoTramite;

        [Column("modelo", ManyToOne = "codigo")]
        private int codigoModelo;

        [Column("castigos")]
        private string castigos;

        [Column("cdr")]
        private string cdr;

        [Column("capital")]
        private string capital;

        [Column("fecha_protesto")]
        private DateTime fechaProtesto;

        [Column("observacion_tramite")]
        private string observacionTramite;

        [Column("fecha_tramite")]
        private DateTime fechaTramite;

        [Column("flag")]
        private int flag;

        [Column("agencia")]
        private string agencia;

        [Column("fecha_asignacion")]
        private DateTime fechaAsignacion;

        [Column("monto_admitido")]
        private string montoAdmitido;

        [Column("producto_modulo")]
        private string productoModulo;

        [Column("ejecutivo")]
        private string ejecutivo;

        [Column("fecha_emision_pagare")]
        private DateTime fechaEmisionPagare;

        [Column("fecha_vencimiento")]
        private DateTime fechaVencimiento;

    }
}

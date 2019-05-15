using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//importar la siguiente libreria
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_cancelacion_pagos")]
    [Table("cancelacion_pagos")]
    class CancelacionPagos
    {
        [Column("cuenta_bt", PrimaryKey = true)]
        private int codigoCancelacion;

        [Column("cuenta_bt", ManyToOne="cuenta_bt")]
        private string cuentaBt;
        
        [Column("monto_devolucion")]
        private string montoDevolucion;

        [Column("motivo_devolucion")]
        private string motivo_devolucion;

        [Column("descripcion_inmueble")]
        private string descripcion_inmueble;

        public int CodigoCancelacion
        {
            get { return codigoCancelacion; }
            set { codigoCancelacion = value; }
        }

        public string CuentaBt
        {
            get { return cuentaBt; }
            set { cuentaBt = value; }
        }

        public string MontoDevolucion
        {
            get { return montoDevolucion; }
            set { montoDevolucion = value; }
        }

        public string Motivo_devolucion
        {
            get { return motivo_devolucion; }
            set { motivo_devolucion = value; }
        }

        public string Descripcion_inmueble
        {
            get { return descripcion_inmueble; }
            set { descripcion_inmueble = value; }
        }
    }
}

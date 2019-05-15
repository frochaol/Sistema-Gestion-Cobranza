using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_detalleExpedienteCredito")]
    [Table("detalle_expediente_credito")]
    class DetalleExpedienteCredito
    {

        [Column("num_expediente", ManyToOne = "num_expediente")]
        private string numExpediente;

        [Column("operacion", ManyToOne = "operacion")]
        private string operacion;

    }
}

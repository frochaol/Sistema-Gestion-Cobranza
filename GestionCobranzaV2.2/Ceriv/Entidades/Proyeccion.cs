using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_proyeccion")]
    [Table("proyeccion")]
    class Proyeccion
    {
        [Column("codigo", PrimaryKey = true)]
        private int codigoProyeccion;

        [Column("num_expediente", ManyToOne="num_expediente")]
        private string numExpediente;

        [Column("fecha_estimada")]
        private DateTime fechaEstimada;

        [Column("devuelto")]
        private string devuelto;

        [Column("motivo_devolucion")]
        private string motivoDevolucion;

        [Column("telefono")]
        private string telefono;



    }
}

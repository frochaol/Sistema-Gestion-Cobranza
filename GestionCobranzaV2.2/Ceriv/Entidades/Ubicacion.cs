using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;
namespace Ceriv.Entidades
{
    [Entity("spr_ubicacion")]
    [Table("ubicacion")]
    class Ubicacion
    {
        [Column("codigo", PrimaryKey = true)]
        private int codigo;

        [Column("num_expediente", ManyToOne="num_expediente")]
        private string numExpediente;

        [Column("ubicacion")]
        private string ubicacion;

        [Column("imagen")]
        private Byte imagen;


    }
}

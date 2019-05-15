using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_estudio")]
    [Table("estudio")]
    class Estudio
    {
        [Column("codigo_estudio", PrimaryKey = true)]
        private int codigoEstudio;

        [Column("nombre")]
        private string nombreEstudio;

        [Column("flag")]
        private int flag;
    }
}

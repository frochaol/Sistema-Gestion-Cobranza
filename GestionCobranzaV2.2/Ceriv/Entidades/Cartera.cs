using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_cartera")]
    [Table("cartera")]
    class Cartera
    {
        [Column("codigo_cartera", PrimaryKey = true)]
        private int codigoCartera;

        [Column("nombre")]
        private string nombreCartera;

        [Column("flag")]
        private int flag;

    }
}

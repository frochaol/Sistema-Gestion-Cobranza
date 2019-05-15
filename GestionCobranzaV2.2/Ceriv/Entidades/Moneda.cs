using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_moneda")]
    [Table("moneda")]
    class Moneda
    {
        [Column("codigo_moneda", PrimaryKey = true)]
        private int codigoMoneda;

        [Column("nombre")]
        private string nombreMoneda;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_modelo")]
    [Table("modelo")]
    class Modelo
    {
        [Column("codigo", PrimaryKey = true)]
        private int codigoModelo;

    }
}

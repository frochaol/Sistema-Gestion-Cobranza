using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_ciudad")]
    [Table("ciudad")]
    class Ciudad
    {
        [Column("codigo_ciudad", PrimaryKey = true)]
        private int codigoCiudad;

        [Column("nombre")]
        private string nombreCiudad;

        [Column("flag")]
        private int flag;
    }
}

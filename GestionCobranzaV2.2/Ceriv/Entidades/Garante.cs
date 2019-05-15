using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_garante")]
    [Table("garante")]
    class Garante
    {
        [Column("codigo_garante", PrimaryKey = true)]
        private int codigoGarante;

        [Column("codigo_distrito", ManyToOne="codigo_distrito")]
        private int codigoDistrito;

        [Column("operacion", ManyToOne = "operacion")]
        private string operacion;

        [Column("nombre_completo")]
        private string nombreCompleto;

        [Column("nombre_conyuge")]
        private string nombreConyuge;

        [Column("domicilio_garante")]
        private string domicilioGarante;

        [Column("flag")]
        private int flag;
    }
}

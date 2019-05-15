using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_otrasCargas")]
    [Table("otras_cargas")]
    class OtrasCargas
    {
        [Column("codigo", PrimaryKey = true)]
        private int codigoOtrasCargas;

        [Column("codigo_bien", ManyToOne="codigo_bien")]
        private int codigoBien;

        [Column("descripcion_bien")]
        private string descripcionBien;

        [Column("acreedor")]
        private string acreedor;

        [Column("rango")]
        private string rango;

        [Column("monto_garantia")]
        private string montoGarantia;

        [Column("monto_adeudado")]
        private string montoAdeudado;

        [Column("flag")]
        private int flag;
    }
}

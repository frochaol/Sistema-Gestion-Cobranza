using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_etapaProcesal")]
    [Table("etapaprocesal")]
    class EtapaProcesal
    {
        [Column("codigo", PrimaryKey = true)]
        private int codigoEtapaProcesal;

        [Column("nombre")]
        private string nombreEtapaProcesal;

        [Column("flag")]
        private int flag;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_expediente")]
    [Table("expediente")]
    class Expediente
    {
        [Column("num_expediente", PrimaryKey = true)]
        private string numExpediente;

        [Column("codigo_proceso", ManyToOne="codigo_proceso")]
        private int codigoProceso;

        [Column("trabajador_abogado")]
        private int trabajadorAbogado;

        [Column("trabajador_responsable")]
        private int trabajadorResponsable;

        [Column("trabajador_secretario")]
        private string trabajadorSecretario;


        [Column("num_expediente_22digitos")]
        private string num_expediente_22digitos;

        [Column("juzgado")]
        private string juzgado;

        [Column("codigo_cautelar")]
        private string codigoCautelar;

        [Column("flag")]
        private int flag;

        [Column("num_juzgado")]
        private string numJuzgado;
    }
}

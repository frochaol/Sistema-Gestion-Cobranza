using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_trabajador")]
    [Table("trabajador")]
    class Trabajador
    {
        [Column("dni_trabajador", PrimaryKey = true)]
        private int dniTrabajador;

        [Column("codigo_tipo_trabajador", ManyToOne="codigo_tipo_trabajador")]
        private int codigoTipoTrabajador;

        [Column("codigo_bien", PrimaryKey = true)]
        private int codigoBien;

        [Column("nombre")]
        private string nombreTrabajador;

        [Column("apellido_paterno")]
        private string apellidoPaterno;

        [Column("apellido_materno")]
        private string apellidoMaterno;

        [Column("contra")]
        private string contra;

        [Column("flag")]
        private int flag;
    }
}

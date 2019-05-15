using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;

namespace Ceriv.Entidades
{
    [Entity("spr_auditoriaCeriv")]
    [Table("AuditoriaCeriv")]
    class AuditoriaCeriv
    {
        [Column("codigo_auditoria", PrimaryKey = true)]
        private int idAuditoria;

        [Column("cuenta_bt", ManyToOne="cuenta_bt")]
        private string cuentaBt;

        [Column("dni_trabajador", ManyToOne="dni_trabajador")]
        private int dniTrabajador;

        [Column("observacion")]
        private string observacion;

        [Column("fecha_modificacion")]
        private DateTime fechaModificacion;

        [Column("campo")]
        private string campo;


        public int IdAuditoria
        {
            get { return idAuditoria; }
            set { idAuditoria = value; }
        }

        public string CuentaBT
        {
            get { return cuentaBt; }
            set { cuentaBt = value; }
        }

        public int DniTrabajador 
        {
            get { return dniTrabajador; }
            set { dniTrabajador = value; }
        }

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }

        public DateTime FechaModificacion
        {
            get { return fechaModificacion; }
            set { fechaModificacion = value; }
        }

        public string Campo
        {
            get { return campo; }
            set { campo = value; }
        }
    }

}

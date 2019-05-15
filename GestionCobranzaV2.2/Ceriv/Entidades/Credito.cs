using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Ceriv.Atributos;
namespace Ceriv.Entidades
{
    [Entity("spr_credito")]
    [Table("Credito")]
    class Credito
    {
        [Column("cuenta_bt",PrimaryKey=true)]
        private string cuentaBt;
        public string CuentaBt
        {
            get { return cuentaBt; }
            set { cuentaBt = value; }
        }

        [Column("flag")]
        private int flag;

        public int Flag
        {
            get { return flag; }
            set { flag = value; }
        }


    }
}

using System;
using Ceriv.Conexion;
using Ceriv.Clases;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ceriv.Formularios
{
    public partial class E_DoiCliente : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        string doi;
        string _cuentaBT;

        public string CuentaBT2
        {
            get { return _cuentaBT; }
            set { _cuentaBT = value; }
        }
        public string Doi
        {
            get { return doi; }
            set { doi = value; }
        }

        public E_DoiCliente()
        {
            InitializeComponent();
        }
        public E_DoiCliente(string codigo)
        {
            InitializeComponent();
            CargarDataGridView(codigo);
        }

        public void CargarDataGridView(string codigo)
        {
            dgv_ExpedienteCliente.AutoGenerateColumns = false;
            dgv_ExpedienteCliente.DataSource = _ceriv.ClienteMostrarCredito(codigo);
        }
       private void dgv_ExpedienteCliente_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
       {
           
       }

       private void dgv_ExpedienteCliente_CellClick(object sender, DataGridViewCellEventArgs e)
       {
           foreach (DataGridViewRow row in dgv_ExpedienteCliente.Rows)
           {
               if (row.Index > -1)
               {
                   if (row.Selected)
                   {
                       _cuentaBT = row.Cells["CuentaBT"].Value.ToString();
                       this.Hide();
                       break;
                   }
               }

           }
       }
    }
}

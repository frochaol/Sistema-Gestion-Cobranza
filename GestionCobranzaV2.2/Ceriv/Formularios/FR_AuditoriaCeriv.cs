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
    public partial class FR_AuditoriaCeriv : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public FR_AuditoriaCeriv()
        {
            InitializeComponent();
            CargarDataGridView();
            Atajo();
        }
        public void Atajo()
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(this.CrearModificar_KeyDown);
        }
        private void CrearModificar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.B)
            {
                AbrirBuscarClienteNombre();
            }
        }
        public void AbrirBuscarClienteNombre()
        {
            E_NombreTitular obj1 = new E_NombreTitular();
            obj1.ShowDialog();
        }
        public void CargarDataGridView()
        {
            dgv_AuditoriaCeriv.AutoGenerateColumns = false;
            dgv_AuditoriaCeriv.DataSource = _ceriv.AuditoriaMostrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dgv_AuditoriaCeriv.DataSource = _ceriv.AuditoriaMostrarExpediente(txt_CuentaBT.Text);
            E_NombreTitular obj1 = new E_NombreTitular();
            obj1.ShowDialog();
            txt_CuentaBT.Text = obj1.Nuevo;
            CargarDataGridView();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dgv_AuditoriaCeriv.DataSource = _ceriv.AuditoriaMostrarTrabajador(Int32.Parse(txt_Trabajador.Text));
        }

        private void dgv_AuditoriaCeriv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                MessageBox.Show(dgv_AuditoriaCeriv.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
        }



    }
}

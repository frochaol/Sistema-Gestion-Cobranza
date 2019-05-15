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
    public partial class E_NombreTitular : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        string _nuevo;
        string _doiClienteCargar;

        public string Nuevo
        {
            get { return _nuevo; }
            set { _nuevo = value; }
        }

        public string DoiClienteCargar
        {
            get { return _doiClienteCargar; }
            set { _doiClienteCargar = value; }
        }

        public E_NombreTitular()
        {
            InitializeComponent();
            CargarComboBoxNombre();
        }
        public void CargarComboBoxNombre()
        {
            cmb_NombrePersona.DisplayMember = "NombreCompleto";
            cmb_NombrePersona.ValueMember = "Doi_cliente";
            cmb_NombrePersona.DataSource = _ceriv.PersonaMostrar();
            cmb_NombrePersona.SelectedIndex = -1;
            dgv_NombreTitular.DataSource = null;
        }

        public void CargarDataGridView(string codigo)
        {
            dgv_NombreTitular.AutoGenerateColumns = false;
            dgv_NombreTitular.DataSource = _ceriv.PersonaMostrarCreditoNombre(codigo);
        }
        public void CargarDataGridViewPersona(string nombre)
        {/*
            dgv_NombreTitular.AutoGenerateColumns = false;
            dgv_NombreTitular.DataSource = _ceriv.PersonaMostrarTitular(cmb_NombrePersona.Text);*/

        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            MostrarCuentaBT();
        }

        private void cmb_NombrePersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_NombrePersona.SelectedIndex > -1)
            {
                CargarDataGridView(cmb_NombrePersona.SelectedValue.ToString());
            }
        }

        private void dgv_NombreTitular_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarCuentaBT();
        }


        public void MostrarPersona()
        {
            foreach (DataGridViewRow row in dgv_NombreTitular.Rows)
            {
                    if (row.Selected)
                    {
                        DoiClienteCargar = row.Cells["DOICLIENTE"].Value.ToString();
                        this.Hide();
                        break;
                    }
            }
        }
        public void MostrarCuentaBT()
        {
            foreach (DataGridViewRow row in dgv_NombreTitular.Rows)
            {
                if (row.Index > -1)
                {
                    if (row.Selected)
                    {
                        Nuevo = row.Cells["cuenta_bt"].Value.ToString();
                        this.Hide();
                        break;
                    }
                }

            }
        }

        private void E_NombreTitular_Load(object sender, EventArgs e)
        {
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
        }

        private void E_NombreTitular_FormClosed(object sender, FormClosedEventArgs e)
        {
            MostrarCuentaBT();
        }

      

    }
}

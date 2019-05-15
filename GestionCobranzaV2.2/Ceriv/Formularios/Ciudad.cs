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
    public partial class Ciudad : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public Ciudad()
        {
            InitializeComponent();
            CargarComboBox();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarCiudad();
        }
        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ActualizarCiudad();
        }
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            GuardarCiudad();
        }

        public void CargarComboBox()
        {
            CargarComboBoxModificar();
            CargarComboBoxEliminar();            
        }
        public void CargarComboBoxModificar()
        {
            cmb_M_Ciudad.DisplayMember = "NombreCiudad";
            cmb_M_Ciudad.ValueMember = "CodigoCiudad";
            cmb_M_Ciudad.DataSource = _ceriv.CiudadMostrar();
        }
        public void CargarComboBoxEliminar()
        {
            cmb_E_Ciudad.DisplayMember = "NombreCiudad";
            cmb_E_Ciudad.ValueMember = "CodigoCiudad";
            cmb_E_Ciudad.DataSource = _ceriv.CiudadMostrar();
        }


        private void GuardarCiudad()
        {
            C_Ciudad objetoCiudad = new C_Ciudad();
            objetoCiudad.NombreCiudad = txt_I_Ciudad.Text;
            if (_ceriv.Ciudad(1, objetoCiudad))
            {
                MessageBox.Show("Ingreso Correctamente la Ciudad");
                CargarComboBox();
                txt_I_Ciudad.Clear();
            }
            else
            {
                MessageBox.Show("Revise el Nombre");
            } 
        }
        private void EliminarCiudad()
        {
            C_Ciudad objetoCiudad = new C_Ciudad();
            objetoCiudad.NombreCiudad = " ";
            objetoCiudad.CodigoCiudad = Int32.Parse(cmb_M_Ciudad.SelectedValue.ToString());
            if (_ceriv.Ciudad(3, objetoCiudad))
            {
                MessageBox.Show("Se Elimino Correctamente la Ciudad");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("Revise el Nombre");
            } 
        }
        private void ActualizarCiudad()
        {
            C_Ciudad objetoCiudad = new C_Ciudad();
            objetoCiudad.NombreCiudad = txt_M_Ciudad.Text;
            objetoCiudad.CodigoCiudad = Int32.Parse(cmb_M_Ciudad.SelectedValue.ToString());
            if (_ceriv.Ciudad(2, objetoCiudad))
            {
                MessageBox.Show("Se Actualizo Correctamente la Ciudad");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("Revise el Nombre");
            }
        }

        private void cmb_M_Ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            C_Ciudad obj = _ceriv.CiudadMostrar1(Int32.Parse(cmb_M_Ciudad.SelectedValue.ToString()));
            txt_M_Ciudad.Text = obj.NombreCiudad;
        }

    }
}

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
    public partial class Cartera : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public Cartera()
        {
            InitializeComponent();
            CargarComboBox();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            GuardarCartera();
        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarCartera();
        }
        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ActualizarCartera();
        }

        public void CargarComboBox()
        {
            CargarComboBoxModificar();
            CargarComboBoxEliminar();
        }
        public void CargarComboBoxEliminar()
        {
            cmb_E_Cartera.DisplayMember = "NombreCartera";
            cmb_E_Cartera.ValueMember = "CodigoCartera";
            cmb_E_Cartera.DataSource = _ceriv.CarteraMostrar();
        }
        public void CargarComboBoxModificar()
        {
            cmb_M_Cartera.DisplayMember = "NombreCartera";
            cmb_M_Cartera.ValueMember = "CodigoCartera";
            cmb_M_Cartera.DataSource = _ceriv.CarteraMostrar();
        }
        
        private void cmb_M_Cartera_SelectedIndexChanged(object sender, EventArgs e)
        {
            C_Cartera obj = _ceriv.CarteraMostrar1(Int32.Parse(cmb_M_Cartera.SelectedValue.ToString()));
            txt_M_Nombre.Text = obj.NombreCartera;
        }

        private void GuardarCartera()
        {
            C_Cartera objetoCartera = new C_Cartera();
            objetoCartera.NombreCartera = txt_I_Cartera.Text;
            if (_ceriv.Cartera(1, objetoCartera))
            {
                MessageBox.Show("Ingreso Correctamente Cartera");
                CargarComboBox();
                txt_I_Cartera.Clear();
            }
            else
            {
                MessageBox.Show("Revise el Nombre");
            }
        }
        private void EliminarCartera()
        {
            C_Cartera objetoCartera = new C_Cartera();
            objetoCartera.NombreCartera = " ";
            objetoCartera.CodigoCartera = Int32.Parse(cmb_E_Cartera.SelectedValue.ToString());
            if (_ceriv.Cartera(3, objetoCartera))
            {
                MessageBox.Show("Se Elimino Correctamente la Cartera");
                CargarComboBox();
                txt_I_Cartera.Clear();
            }
            else
            {
                MessageBox.Show("No se puedo Eliminar");
            }
        }
        private void ActualizarCartera()
        {
            C_Cartera objetoCartera = new C_Cartera();
            objetoCartera.NombreCartera = txt_M_Nombre.Text;
            objetoCartera.CodigoCartera = Int32.Parse(cmb_M_Cartera.SelectedValue.ToString());
            if (_ceriv.Cartera(2, objetoCartera))
            {
                MessageBox.Show("Actualizo Correctamente Cartera");
                CargarComboBox();
                txt_I_Cartera.Clear();
            }
            else
            {
                MessageBox.Show("Revise el Nombre");
            }            
        }





    }
}

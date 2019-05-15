using System;
using Ceriv.Clases;
using Ceriv.Conexion;
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
    public partial class F_Distrito : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public F_Distrito()
        {
            InitializeComponent();
            CargarComboBox();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            GuardarDistrito();
        }
        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ModificarDistrito();
        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarDistrito();
        }

        public void CargarComboBox()
        {
            CargarDistritoModificar();
            CargarDistritoEliminar();
        }
        public void CargarDistritoModificar()
        {
            cmb_M_Distrito.DisplayMember = "NombreDistrito";
            cmb_M_Distrito.ValueMember = "CodigoDistrito";
            cmb_M_Distrito.DataSource = _ceriv.DistritoMostrar();
        }
        public void CargarDistritoEliminar()
        {
            cmb_E_Distrito.DisplayMember = "NombreDistrito";
            cmb_E_Distrito.ValueMember = "CodigoDistrito";
            cmb_E_Distrito.DataSource = _ceriv.DistritoMostrar();
        }

        public void GuardarDistrito()
        {
            C_Distrito objetoDistrito = new C_Distrito();
            objetoDistrito.NombreDistrito = txt_I_Distrito.Text;
            if (_ceriv.Distrito(1, objetoDistrito))
            {
                MessageBox.Show("Se ingreso Distrito Correctamente");
                CargarComboBox();
                txt_I_Distrito.Clear();
            }
            else
            {
                MessageBox.Show("Revise el Nombre");
            }
        }
        public void ModificarDistrito()
        {
            C_Distrito objetoDistrito = new C_Distrito();
            objetoDistrito.NombreDistrito = txt_M_Distrito.Text;
            objetoDistrito.CodigoDistrito = Int32.Parse(cmb_M_Distrito.SelectedValue.ToString());
            if (_ceriv.Distrito(2, objetoDistrito))
            {
                MessageBox.Show("Se modifico Correctamente el Distrito");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("Revise los Datos");
            }
        }
        public void EliminarDistrito()
        {
            C_Distrito objetoDistrito = new C_Distrito();
            objetoDistrito.NombreDistrito = " ";
            objetoDistrito.CodigoDistrito = Int32.Parse(cmb_E_Distrito.SelectedValue.ToString());
            if (_ceriv.Distrito(3, objetoDistrito))
            {
                MessageBox.Show("Se elimino correctamente el Distrito");
                CargarComboBox();

            }
            else
            {
                MessageBox.Show("No se pudo Eliminar");
            }
        }

        private void cmb_M_Distrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            C_Distrito obj = _ceriv.DistritoMostrar1(Int32.Parse(cmb_M_Distrito.SelectedValue.ToString()));
            txt_M_Distrito.Text = obj.NombreDistrito;
        }


    }
}

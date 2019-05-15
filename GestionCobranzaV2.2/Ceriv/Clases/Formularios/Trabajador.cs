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
    public partial class Trabajador : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public Trabajador()
        {
            InitializeComponent();
            CargarComboBox();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            GuardarTrabajador();

        }
        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ActualizarTrabajador();
        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarTrabajador();
        }  

        public void CargarComboBox()
        {
            CargarComboBoxModificarTrabajador();
            CargarComboBoxEliminarTrabajador();
            CargarComboBoxTipoTrabajador();
        }
        public void CargarComboBoxModificarTrabajador()
        {
            cmb_M_Trabajador.DisplayMember = "NombreCompleto";
            cmb_M_Trabajador.ValueMember = "DniTrabajador";
            cmb_M_Trabajador.DataSource = _ceriv.TrabajadorMostrar();
        }
        public void CargarComboBoxEliminarTrabajador()
        {
            cmb_E_Trabajador.DisplayMember = "NombreCompleto";
            cmb_E_Trabajador.ValueMember = "DniTrabajador";
            cmb_E_Trabajador.DataSource = _ceriv.TrabajadorMostrar();
        }
        public void CargarComboBoxTipoTrabajador()
        {
            cmb_I_TipoTrabajador.DisplayMember = "Nombre";
            cmb_I_TipoTrabajador.ValueMember = "CodigoTipoTrabajador";
            cmb_I_TipoTrabajador.DataSource = _ceriv.TipoTrabajadorMostrar();

            cmb_M_TipoTrabajador.DisplayMember = "Nombre";
            cmb_M_TipoTrabajador.ValueMember = "CodigoTipoTrabajador";
            cmb_M_TipoTrabajador.DataSource = _ceriv.TipoTrabajadorMostrar();

        }

        private void GuardarTrabajador()
        {
            C_Trabajador objetoTrabajador = new C_Trabajador();
            objetoTrabajador.NombreTrabajador = txt_I_Nombre.Text;
            objetoTrabajador.ApellidoPaterno = txt_I_APaterno.Text;
            objetoTrabajador.ApellidoMaterno = txt_I_AMaterno.Text;
            objetoTrabajador.DniTrabajador = Int32.Parse(txt_I_Dni.Text);
            objetoTrabajador.Contra = txt_I_Password.Text;
            objetoTrabajador.CodigoTipoTrabajador = Int32.Parse(cmb_I_TipoTrabajador.SelectedValue.ToString());
            if (_ceriv.Trabajador(1, objetoTrabajador))
            {
                MessageBox.Show("Se ingreso Correctamente al Trabajador");
                CargarComboBox();
                txt_I_Nombre.Clear();
                txt_I_APaterno.Clear();
                txt_I_AMaterno.Clear();
                txt_I_Dni.Clear();
                txt_I_Password.Clear();
            }
            else
            {
                MessageBox.Show("Revise los Datos");
            }

        }
        private void ActualizarTrabajador()
        {
            C_Trabajador objetoTrabajador = new C_Trabajador();
            objetoTrabajador.DniTrabajador = Int32.Parse(cmb_M_Trabajador.SelectedValue.ToString());
            objetoTrabajador.NombreTrabajador = txt_M_Nombre.Text;
            objetoTrabajador.ApellidoPaterno = txt_M_APaterno.Text;
            objetoTrabajador.ApellidoMaterno = txt_M_AMaterno.Text;
            objetoTrabajador.DniTrabajadorNuevo = Int32.Parse(txt_M_Dni.Text);
            objetoTrabajador.Contra = txt_M_Password.Text;
            objetoTrabajador.CodigoTipoTrabajador = Int32.Parse(cmb_M_TipoTrabajador.SelectedValue.ToString());
            if (_ceriv.Trabajador(2, objetoTrabajador))
            {
                MessageBox.Show("Se modifico correctamente al Trabajador");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("No se pudo modificar al trabajador");
            }
        }
        private void EliminarTrabajador()
        {
            C_Trabajador objetoTrabajador = new C_Trabajador();
            objetoTrabajador.DniTrabajador = Int32.Parse(cmb_E_Trabajador.SelectedValue.ToString());
            if (_ceriv.Trabajador(3, objetoTrabajador))
            {
                MessageBox.Show("Se elimino Trabajador Correctamente");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("No existe el Trabajador");
            }

 
        }

        private void cmb_M_Trabajador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_M_Trabajador.SelectedIndex > -1)
            {
                C_Trabajador obj = _ceriv.TrabajadorMostrar1(Int32.Parse(cmb_M_Trabajador.SelectedValue.ToString()));
                txt_M_Nombre.Text = obj.NombreTrabajador;
                txt_M_APaterno.Text = obj.ApellidoPaterno;
                txt_M_AMaterno.Text = obj.ApellidoMaterno;
                txt_M_Dni.Text = "" + obj.DniTrabajador;
                txt_M_Password.Text = obj.Contra;
                cmb_M_TipoTrabajador.SelectedValue = obj.CodigoTipoTrabajador;
            }
        }

    }
}

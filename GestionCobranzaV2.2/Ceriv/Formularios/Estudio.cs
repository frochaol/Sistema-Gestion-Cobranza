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
    public partial class Estudio : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public Estudio()
        {
            InitializeComponent();
            CargarComboBox();
        }
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            GuardarEstudio();
        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarEstudio();
        }
        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ActualizarEstudio();
        }

        public void CargarComboBox()
        {
            CargarComboBoxModificar();
            CargarComboBoxEliminar();
            
        }
        public void CargarComboBoxModificar()
        {
            cmb_M_Estudio.DisplayMember = "NombreEstudio";
            cmb_M_Estudio.ValueMember = "CodigoEstudio";
            cmb_M_Estudio.DataSource = _ceriv.EstudioMostrar();
        }
        public void CargarComboBoxEliminar()
        {
            cmb_E_Estudio.DisplayMember = "NombreEstudio";
            cmb_E_Estudio.ValueMember = "CodigoEstudio";
            cmb_E_Estudio.DataSource = _ceriv.EstudioMostrar();
        }

        private void cmb_M_Estudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            C_Estudio obj = _ceriv.EstudioMostrar1(Int32.Parse(cmb_M_Estudio.SelectedValue.ToString()));
            txt_M_Estudio.Text = obj.NombreEstudio;
        }

        private void GuardarEstudio()
        {
            C_Estudio objetoEstudio = new C_Estudio();
            objetoEstudio.NombreEstudio = txt_I_Estudio.Text;
            if (_ceriv.Estudio(1, objetoEstudio))
            {
                MessageBox.Show("Ingreso Correctamente");
                CargarComboBox();
                txt_I_Estudio.Clear();
            }
 
        }    
        private void ActualizarEstudio()
        {
            C_Estudio objetoEstudio = new C_Estudio();
            objetoEstudio.NombreEstudio = txt_M_Estudio.Text;
            objetoEstudio.CodigoEstudio = Int32.Parse(cmb_M_Estudio.SelectedValue.ToString());
            if (_ceriv.Estudio(2, objetoEstudio))
            {
                MessageBox.Show("Actualizo el Estudio Correctamente");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("No se actualizo Correctamente"); 
            }
 
        }
        private void EliminarEstudio()
        {
            C_Estudio objetoEstudio = new C_Estudio();
            objetoEstudio.NombreEstudio = " ";
            objetoEstudio.CodigoEstudio = Int32.Parse(cmb_E_Estudio.SelectedValue.ToString());
            if (_ceriv.Estudio(3, objetoEstudio))
            {
                MessageBox.Show("Actualizo el Estudio Correctamente");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("No se actualizo Correctamente");
            }
 
        }


    }
}

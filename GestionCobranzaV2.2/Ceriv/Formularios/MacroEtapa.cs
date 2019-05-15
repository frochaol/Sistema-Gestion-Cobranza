using Ceriv.Clases;
using Ceriv.Conexion;
using System;
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
    public partial class MacroEtapa : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public MacroEtapa()
        {
            InitializeComponent();
            CargarComboBox();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            GuardarMacroEtapa();
        }
        public void GuardarMacroEtapa() {

            C_Macro objetoMacroEtapa = new C_Macro();
            if (txt_I_Nombre.Text == String.Empty)
            {
                MessageBox.Show("Ingrese una Macro Etapa");
                return;
            }
            objetoMacroEtapa.Nombre = txt_I_Nombre.Text;
            if (_ceriv.MacroEtapa(1, objetoMacroEtapa))
            {
                MessageBox.Show("Ingreso Correctamente la Macro Etapa");
                CargarComboBox();
                txt_I_Nombre.Clear();
            }
            else
            {
                MessageBox.Show("Revisar los datos del Nombre Por Favor");
            }

        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ModificarMacroEtapa();
        }
        public void ModificarMacroEtapa() {

            C_Macro objetoMacro = new C_Macro();
            if (txt_M_Nombre.Text == String.Empty)
            {
                MessageBox.Show("Ingrese una forma de Macro Etapa");
                return;
            }
            objetoMacro.Nombre = txt_M_Nombre.Text;
            objetoMacro.Codigo = Int32.Parse(cmb_M_Nombre.SelectedValue.ToString());
            if (_ceriv.MacroEtapa(2, objetoMacro))
            {
                MessageBox.Show("Modifico Correctamente la Macro Etapa");
                CargarComboBox();
                txt_M_Nombre.Clear();
            }
            else
            {
                MessageBox.Show("Revise el Nombre");
            }
        
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarMacroEtapa();
        }
        public void EliminarMacroEtapa() {

            C_Macro objetoMacroEtapa = new C_Macro();
            objetoMacroEtapa.Nombre = " ";
            objetoMacroEtapa.Codigo = Int32.Parse(cmb_E_Nombre.SelectedValue.ToString());
            if (_ceriv.MacroEtapa(3, objetoMacroEtapa))
            {
                MessageBox.Show("Elimino Correctamente la Macro Etapa");
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("Error al eliminar");
            }
        
        }

        public void CargarComboBox()
        {
            CargarComboBoxModificar();
            CargarComboBoxEliminar();
        }

        public void CargarComboBoxModificar() {
            cmb_M_Nombre.DisplayMember = "Nombre";
            cmb_M_Nombre.ValueMember = "Codigo";
            cmb_M_Nombre.DataSource = _ceriv.MacroEtapaMostrar();
        }
        public void CargarComboBoxEliminar() {
            cmb_E_Nombre.DisplayMember = "Nombre";
            cmb_E_Nombre.ValueMember = "Codigo";
            cmb_E_Nombre.DataSource = _ceriv.MacroEtapaMostrar();
        }

    }
}

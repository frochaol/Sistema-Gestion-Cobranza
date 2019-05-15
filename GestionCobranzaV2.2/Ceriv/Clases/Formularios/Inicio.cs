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
    public partial class Inicio : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        public Inicio()
        {
            InitializeComponent();
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void txt_contraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Login();
            }
        }

        private void Login()
        {
            int dni;
            Principal objetoPrincipal;
            C_Trabajador objetoTrabajador;
            C_TipoTrabajador objetoTipoTrabajador;
            dni = Int32.Parse(txt_codigo.Text);
            if (_ceriv.TrabajadorLogin(dni, txt_contraseña.Text))
            {
                objetoTrabajador = _ceriv.TrabajadorMostrar1(dni);
                objetoTipoTrabajador = _ceriv.TipoTrabajadorMostrar1(objetoTrabajador.CodigoTipoTrabajador);
                MessageBox.Show("Ingreso correctamente como " + objetoTipoTrabajador.Nombre);
                objetoPrincipal = new Principal();
                this.Hide();
                objetoPrincipal.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class SeleccionEstudio : Form
    {
        int _dniTrabajador;
        string[] _array;
        public SeleccionEstudio(int dniTrabajador,string[] array)
        {
            InitializeComponent();
            _dniTrabajador = dniTrabajador;
            _array = array;
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            int estudio;
            if (rdb_Ceriv.Checked)
            {
                estudio = 1;
            }
            else
            {
                estudio = 2;
            }
            CrearModificar objetoCrearModificar = new CrearModificar(_dniTrabajador, _array, estudio);
            objetoCrearModificar.ShowDialog();
            this.Hide();
        }
    }
}

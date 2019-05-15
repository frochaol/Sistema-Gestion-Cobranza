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
    public partial class EliminarCuentaBT : Form
    {
        S_Ceriv _ceriv = new S_Ceriv();
        int _dniTrabajador;
        public EliminarCuentaBT(int dni)
        {
            InitializeComponent();
            _dniTrabajador = dni;

        }
        public void eliminarCuenta()
        {
            C_Credito objetoCredito = new C_Credito();
            if (txt_CuentaBT.Text == string.Empty)
            {
                MessageBox.Show("Ingrese una Cuenta BT a Eliminar");
                return;
            }
            else
            {
                objetoCredito.CuentaBT = txt_CuentaBT.Text;
            }
            if (_ceriv.CuentaBTExiste(txt_CuentaBT.Text))
            {
                if (_ceriv.CreditoEliminar(1, objetoCredito))
                {
                    
                    C_AuditoriaCeriv objetoAuditoria = new C_AuditoriaCeriv();
                    objetoAuditoria.CuentaBT = txt_CuentaBT.Text;
                    objetoAuditoria.DniTrabajador = _dniTrabajador;
                    objetoAuditoria.Campo = "Eliminar Credito";
                    objetoAuditoria.Observacion = "\n Cuenta BT =" + txt_CuentaBT.Text + "\n DniTrabajador =" + _dniTrabajador;
                    if (_ceriv.Auditoria(1, objetoAuditoria))
                    { 
                    }
                    MessageBox.Show("   *Se Elimino Correctamente el Credito");
                    txt_CuentaBT.Clear();

                }
            }
            else
            {
                MessageBox.Show("   *La Cuenta BT no Existe. Ingrese una CuentaBT Existente por favor");
                return;
            }
        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            eliminarCuenta();

        }
        public void AuditoriaEliminar()
        {
 
        }
    }
}

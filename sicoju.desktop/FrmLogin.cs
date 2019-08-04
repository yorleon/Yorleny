using sicoju.desktop.WSJudicial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sicoju.desktop
{
    public partial class FrmLogin : Form
    {
        private Usuario vUsuario;
        private ServicioJudicialClient vServicioJudicial;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void lnkRestablecer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtUsuario.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe ingresar la identificación del usuario.", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.vUsuario = new Usuario()
            {
                Identificacion = txtUsuario.Text.Trim(),
                Clave = txtClave.Text
            };


            using (vServicioJudicial = new ServicioJudicialClient())
            {
                if (vServicioJudicial.GetUsuario(vUsuario, false) != null)
                {
                    var vForm = new FrmRestablecer(this.vUsuario);
                    vForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("El usuario no existe.", "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                var vMensaje = string.Empty;
                this.vUsuario = new Usuario()
                {
                    Identificacion = txtUsuario.Text.Trim(),
                    Clave = txtClave.Text
                };

                using (vServicioJudicial = new ServicioJudicialClient())
                {
                    string vRespuesta = vServicioJudicial.ValidarUsuario(vUsuario);

                    switch (vRespuesta)
                    {
                        case "S":
                            var vFormPrincipal = new FrmPrincipal();
                            vFormPrincipal.vUsuario = vUsuario;
                            vFormPrincipal.ShowDialog();
                            break;
                        case "C":
                            vMensaje = "Clave o usuario incorrectos";
                            break;
                        case "N":
                            vMensaje = "El usuario no existe";
                            break;
                        case "I":
                            vMensaje = "El usuario se encuentra inactivo";
                            break;
                        default:
                            vMensaje = "Error inesperado a la hora de validar el usuario";
                            break;
                    }

                    if (!string.IsNullOrWhiteSpace(vMensaje))
                        MessageBox.Show(vMensaje, "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.ToString(), "Inicio Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

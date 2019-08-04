using sicoju.desktop.WSJudicial;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace sicoju.desktop
{
    public partial class FrmPrincipal : Form
    {
        public Usuario vUsuario { get; set; }
        private ServicioJudicialClient vServicioJudicial = new ServicioJudicialClient();

        public FrmPrincipal()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.ToString(), "Formulario Principal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                this.vUsuario = vServicioJudicial.GetUsuario(vUsuario, true);
                this.ObtenerFormularios();

                if (this.vUsuario != null && this.vUsuario.Restablecer.HasValue && this.vUsuario.Restablecer.Value == true)
                    this.RestablecerClave();

                lblUsuarioLogin.Text = string.Format("Bienvenido {0} {1} {2}", vUsuario.Nombre, vUsuario.PrimerApellido, vUsuario.SegundoApellido);
                lblFechaSistema.Text = string.Format("Fecha del Sistema: {0}", DateTime.Now.ToShortDateString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.ToString(), "Formulario Principal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RestablecerClave()
        {
            this.MenuHabilitado(false);
            var vForm = new Seguridad.FrmClave(this.vUsuario);
            vForm.MdiParent = this;
            vForm.Show();
        }
        private void ObtenerFormularios()
        {
            try
            {
                if (this.vUsuario.UsuarioPerfil.Count == 0)
                {
                    MessageBox.Show("Su usuario no cuenta con módulos asociados.", "Formulario Principal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var vContador = 1;
                var vSeguridad = false;
                var vFormulariosExistentes = new List<Formulario>();

                foreach (var vUsuarioPerfil in this.vUsuario.UsuarioPerfil)
                {
                    foreach (var vFormulario in vUsuarioPerfil.Perfil.FormularioPerfil)
                    {
                        if (!string.IsNullOrWhiteSpace(vFormulario.Formulario.Ruta) && vFormulario.Formulario.Activo)
                        {

                            if (!vFormulariosExistentes.Exists(f => f.FormularioID == vFormulario.Formulario.FormularioID))
                            {
                                var vItem = new ToolStripMenuItem()
                                {
                                    Name = "ToolStripMenuItem_" + (vContador++).ToString(),
                                    Tag = vFormulario.Formulario.Ruta,
                                    Text = vFormulario.Formulario.Descripcion
                                };

                                vItem.Click += new EventHandler(AbrirFormulario);

                                if (vFormulario.Formulario.Ruta.StartsWith("SICI.Seguridad"))
                                {
                                    mantenimientosToolStripMenuItem.DropDownItems.Add(vItem);
                                    vSeguridad = true;
                                }
                                else
                                    mStripPrincipal.Items.Add(vItem);

                                vFormulariosExistentes.Add(vFormulario.Formulario);
                            }
                        }
                    }
                }

                if (!vSeguridad)
                    mantenimientosToolStripMenuItem.Visible = false;
                else
                    mantenimientosToolStripMenuItem.Visible = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void AbrirFormulario(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                var vForm = Activator.CreateInstance(Type.GetType(item.Tag.ToString())) as Form;
                vForm.MdiParent = this;
                vForm.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void MenuHabilitado(bool pBloquear)
        {
            this.mStripPrincipal.Enabled = pBloquear;
        }

    }
}

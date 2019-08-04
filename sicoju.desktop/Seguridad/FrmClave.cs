using sicoju.desktop;
using sicoju.desktop.WSJudicial;
using System;
using System.Windows.Forms;

namespace sicoju.Seguridad
{
    public partial class FrmClave : Form
    {
        #region Variables
        private Usuario vUsuario { get; set; }
        private ServicioJudicialClient vServicioJudicial = new ServicioJudicialClient();
        #endregion

        #region Constructor
        public FrmClave(Usuario pUsuario)
        {
            vUsuario = pUsuario;
            InitializeComponent();
        }
        #endregion

        #region Metodos
        private void ValidarClave()
        {
            try
            {
                if (!txtClave.Text.Equals(txtConfirmar.Text))
                    MessageBox.Show("Las claves deben coincidir, por favor verifiqué los datos ingresados.", "Restablecer Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                {
                    this.vUsuario.Clave = txtClave.Text;
                    vUsuario.Restablecer = false;
                    vServicioJudicial.CambiarClave(vUsuario);
                    MessageBox.Show("Su clave ha sido actualizada satisfactoriamente.", "Restablecer Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ((FrmPrincipal)this.MdiParent).MenuHabilitado(true);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Eventos
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ValidarClave();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}

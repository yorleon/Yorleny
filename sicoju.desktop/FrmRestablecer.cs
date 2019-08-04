using sicoju.desktop.WSJudicial;
using System;
using System.Threading;
using System.Windows.Forms;

namespace sicoju.desktop
{
    public partial class FrmRestablecer : Form
    {
        private Usuario vUsuario { get; set; }
        private ServicioJudicialClient vServicioJudicial = new ServicioJudicialClient();

        public FrmRestablecer(Usuario pUsuario)
        {
            InitializeComponent();
            vUsuario = pUsuario;
        }

        private void RestablecerClave()
        {
            try
            {
                var vClaveTemporal = this.GenerarClave(8, false);
                vUsuario.Clave = vClaveTemporal;
                vUsuario.Restablecer = true;
                vServicioJudicial.CambiarClave(vUsuario);
                this.txtNuevaClave.Text = vClaveTemporal;
                this.txtNuevaClave.Focus();
            }
            catch (Exception ex) { throw ex; }
        }

        private string GenerarClave(int pLength, bool pSafe)
        {
            Random Random = new Random();
            int seed = Random.Next(1, int.MaxValue);
            const string vCaracteres = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            const string vEspeciales = @"!#$%&'()*+,-./:;<=>?@[\]_";

            var chars = new char[pLength];
            var rd = new Random(seed);

            for (var i = 0; i < pLength; i++)
            {
                if (pSafe && i % Random.Next(3, pLength) == 0)
                {
                    chars[i] = vEspeciales[rd.Next(0, vEspeciales.Length)];
                }
                else
                {
                    chars[i] = vCaracteres[rd.Next(0, vCaracteres.Length)];
                }
            }

            return new string(chars);
        }

        private void FrmRestablecer_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            Thread.Sleep(2000);
            RestablecerClave();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

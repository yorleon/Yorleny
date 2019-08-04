using sicoju.desktop.WSJudicial;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace sicoju.Seguridad
{
    public partial class FrmMantUsuarios : Form
    {

        #region Variables
        private Usuario vUsuarioFiltro, vUsuarioMantenimiento;
        private ServicioJudicialClient vServicioJudicial = new ServicioJudicialClient();
        #endregion

        #region Constructor
        public FrmMantUsuarios()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        private void ConsultarUsuarios()
        {
            this.SetFiltros();
            var vListaUsuarios = vServicioJudicial.GetUsuariosFiltro(this.vUsuarioFiltro,false);
            this.SetDataSource(vListaUsuarios);
        }
        private void SetFiltros()
        {
            this.vUsuarioFiltro = new Usuario()
            {
                Nombre = txtNombre.Text.Trim(),
                PrimerApellido = txtApellidos.Text.Trim(),
                UsuarioID = string.IsNullOrWhiteSpace(txtID.Text) ? 0 : Convert.ToInt32(txtID.Text),
                Identificacion = txtIdentificacion.Text.Trim(),
                CorreoElectronico = txtCorreo.Text.Trim(),
                Activo = chkActivo.Checked
            };
        }
        private void SetDataSource(List<Usuario> pListaUsuarios)
        {
            try
            {
                dgvUsuarios.DataSource = pListaUsuarios;

                DataGridViewButtonColumn vDeleteButton = new DataGridViewButtonColumn
                {
                    Name = "btnDelete",
                    Text = "Eliminar",
                    HeaderText = "",
                    UseColumnTextForButtonValue = true
                };

                var vColumIndex = dgvUsuarios.Columns.Count;
                if (dgvUsuarios.Columns["btnDelete"] == null)
                {
                    dgvUsuarios.Columns.Insert(vColumIndex, vDeleteButton);
                }

                DataGridViewButtonColumn vEdit = new DataGridViewButtonColumn
                {
                    Name = "btnEdit",
                    Text = "Editar",
                    HeaderText = "",
                    UseColumnTextForButtonValue = true
                };

                if (dgvUsuarios.Columns["btnEdit"] == null)
                {
                    dgvUsuarios.Columns.Insert(vColumIndex + 1, vEdit);
                }


                DataGridViewButtonColumn vPerfil = new DataGridViewButtonColumn
                {
                    Name = "btnPerfil",
                    Text = "Perfiles",
                    HeaderText = "",
                    UseColumnTextForButtonValue = true
                };

                if (dgvUsuarios.Columns["btnPerfil"] == null)
                {
                    dgvUsuarios.Columns.Insert(vColumIndex + 2, vPerfil);
                }

                this.dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.dgvUsuarios.AutoResizeColumns();
                this.dgvUsuarios.Refresh();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void SetUsuario()
        {
            try
            {
                this.vUsuarioMantenimiento = new Usuario()
                {
                    UsuarioID = string.IsNullOrWhiteSpace(txtUsuarioID.Text) ? 0 : Convert.ToInt32(txtUsuarioID.Text),
                    Identificacion = txtUsuarioIdentificacion.Text,
                    Nombre = txtUsuarioNombre.Text,
                    PrimerApellido = txtUsuarioPrimerApellido.Text,
                    SegundoApellido = txtUsuarioSegundoApellido.Text,
                    CorreoElectronico = txtUsuarioCorreo.Text,
                    Clave = txtUsuarioClave.Text,
                    Activo = chkUsuarioActivo.Checked
                };
            }
            catch (Exception ex) { throw ex; }
        }
        private void ClearForm()
        {
            txtUsuarioID.Text = string.Empty;
            txtUsuarioIdentificacion.Text = string.Empty;
            txtUsuarioNombre.Text = string.Empty;
            txtUsuarioPrimerApellido.Text = string.Empty;
            txtUsuarioSegundoApellido.Text = string.Empty;
            txtUsuarioCorreo.Text = string.Empty;
            txtUsuarioClave.Text = string.Empty;
            chkUsuarioActivo.Checked = true;
        }
        #endregion

        #region Eventos
        private void FrmMantUsuarios_Load(object sender, EventArgs e)
        {
            this.ConsultarUsuarios();

            dgvUsuarios.Columns["Clave"].Visible = false;
            dgvUsuarios.Columns["Restablecer"].Visible = false;
            dgvUsuarios.Columns["UsuarioPerfil"].Visible = false;
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearForm();
                this.ConsultarUsuarios();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var vSelectedRow = dgvUsuarios.Rows[e.RowIndex];

            if (e.ColumnIndex == dgvUsuarios.Columns["btnDelete"].Index)
            {
                vServicioJudicial.DeleteUsuario(Convert.ToInt32(vSelectedRow.Cells[2].Value.ToString()));
                this.ConsultarUsuarios();
                MessageBox.Show("Usuario eliminado correctamente.", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (e.ColumnIndex == dgvUsuarios.Columns["btnEdit"].Index)
            {

                txtUsuarioID.Text = vSelectedRow.Cells["UsuarioID"].Value.ToString();
                txtUsuarioIdentificacion.Text = vSelectedRow.Cells["Identificacion"].Value.ToString();
                txtUsuarioNombre.Text = vSelectedRow.Cells["Nombre"].Value.ToString();
                txtUsuarioPrimerApellido.Text = vSelectedRow.Cells["PrimerApellido"].Value.ToString();
                txtUsuarioSegundoApellido.Text = vSelectedRow.Cells["SegundoApellido"].Value.ToString();
                txtUsuarioCorreo.Text = vSelectedRow.Cells["CorreoElectronico"].Value.ToString();
                txtUsuarioClave.Text = vSelectedRow.Cells["Clave"].Value.ToString();
                chkUsuarioActivo.Checked = Convert.ToBoolean(vSelectedRow.Cells["Activo"].Value);
            }

            if (e.ColumnIndex == dgvUsuarios.Columns["btnPerfil"].Index)
            {
                var vForm = new FrmMantUsuariosPerfiles
                {
                    vUsuario = new Usuario()
                    {
                        UsuarioID = Convert.ToInt32(vSelectedRow.Cells["UsuarioID"].Value.ToString()),
                        Nombre = vSelectedRow.Cells["Nombre"].Value.ToString()
                    }
                };

                vForm.Show();
            }

        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            this.SetUsuario();
            this.vUsuarioMantenimiento = vServicioJudicial.SaveUsuario(this.vUsuarioMantenimiento);
            txtUsuarioID.Text = this.vUsuarioMantenimiento.UsuarioID.ToString();
            this.ClearForm();
            this.ConsultarUsuarios();
            MessageBox.Show("Cambios efectuados correctamente.", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion


    }
}

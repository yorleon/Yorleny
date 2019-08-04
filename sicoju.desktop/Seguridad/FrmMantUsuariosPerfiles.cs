using sicoju.desktop.WSJudicial;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace sicoju.Seguridad
{
    public partial class FrmMantUsuariosPerfiles : Form
    {
        #region Variables
        public Usuario vUsuario { get; set; }
        private List<PerfilReporte> vListaPerfiles;
        private ServicioJudicialClient vServicioJudicial = new ServicioJudicialClient();
        #endregion

        public FrmMantUsuariosPerfiles()
        {
            InitializeComponent();
        }

        #region Metodos
        private void SetUsuario()
        {
            try
            {
                this.Text = string.Format("Perfiles asociados a - {0}", this.vUsuario.Nombre);
            }
            catch (Exception ex) { throw ex; }
        }
        private void SetPerfiles()
        {
            try
            {
                var vDisponibles = new List<Perfil>();
                var vPerfiles = vServicioJudicial.GetPerfiles();

                foreach (var vPerfil in vPerfiles)
                {
                    if (!this.vListaPerfiles.Exists(p => p.Perfil == vPerfil.Descripcion))
                        vDisponibles.Add(vPerfil);
                }

                cmbPerfiles.DataSource = vDisponibles;
                cmbPerfiles.ValueMember = "PerfilID";
                cmbPerfiles.DisplayMember = "Descripcion";
                cmbPerfiles.Refresh();
            }
            catch (Exception ex) { throw ex; }
        }
        private void SetDataSource()
        {
            try
            {

                dgvUsuariosPerfil.DataSource = this.vListaPerfiles;

                DataGridViewButtonColumn vDeleteButton = new DataGridViewButtonColumn
                {
                    Name = "btnDelete",
                    Text = "Eliminar",
                    HeaderText = "",
                    UseColumnTextForButtonValue = true
                };

                var vColumIndex = dgvUsuariosPerfil.Columns.Count;
                if (dgvUsuariosPerfil.Columns["btnDelete"] == null)
                {
                    dgvUsuariosPerfil.Columns.Insert(vColumIndex, vDeleteButton);
                }

                this.dgvUsuariosPerfil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.dgvUsuariosPerfil.AutoResizeColumns();
                dgvUsuariosPerfil.Refresh();

            }
            catch (Exception ex) { throw ex; }

        }
        private void GetPerfiles()
        {
            vListaPerfiles = vServicioJudicial.GetPerfilesUsuario(this.vUsuario.UsuarioID);
            this.SetDataSource();
        }
        #endregion

        private void FrmMantUsuariosPerfiles_Load(object sender, EventArgs e)
        {
            this.SetUsuario();
            this.GetPerfiles();
            this.SetPerfiles();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var vFormulario = new UsuarioPerfil()
                {
                    UsuarioID = this.vUsuario.UsuarioID,
                    PerfilID = Convert.ToInt32(cmbPerfiles.SelectedValue.ToString())
                };

                vServicioJudicial.SaveUsuarioPerfil(vFormulario);
                MessageBox.Show("Perfil asociado correctamente.", "Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.GetPerfiles();
                this.SetPerfiles();
            }
            catch (Exception ex) { throw ex; }
        }

        private void dgvUsuariosPerfil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvUsuariosPerfil.Columns["btnDelete"].Index)
            {
                var vSelectedRow = dgvUsuariosPerfil.Rows[e.RowIndex];
                vServicioJudicial.DeleteUsuarioPerfil(Convert.ToInt32(vSelectedRow.Cells["ID"].Value.ToString()));
                this.GetPerfiles();
                this.SetPerfiles();
                MessageBox.Show("Perfil eliminado correctamente.", "Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

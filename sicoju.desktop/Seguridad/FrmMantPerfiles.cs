using sicoju.desktop.WSJudicial;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace sicoju.Seguridad
{
    public partial class FrmMantPerfiles : Form
    {

        #region Variables
        private Perfil vPerfilFiltro, vPerfilMantenimiento;
        private ServicioJudicialClient vServicioJudicial = new ServicioJudicialClient();
        #endregion

        #region Constructor
        public FrmMantPerfiles()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        private void ConsultarPerfiles()
        {
            this.SetFiltros();
            var vListaPerfiles = vServicioJudicial.GetPerfilesFiltro(this.vPerfilFiltro);
            this.SetDataSource(vListaPerfiles);
        }
        private void SetFiltros()
        {
            this.vPerfilFiltro = new Perfil()
            {
                PerfilID = string.IsNullOrWhiteSpace(txtID.Text) ? 0 : Convert.ToInt32(txtID.Text),
                Descripcion = txtDescripcion.Text.Trim(),
                Activo = chkActivo.Checked
            };
        }
        private void SetDataSource(List<Perfil> pListaPerfiles)
        {
            try
            {
                dgvPerfiles.DataSource = pListaPerfiles;

                DataGridViewButtonColumn vDeleteButton = new DataGridViewButtonColumn
                {
                    Name = "btnDelete",
                    Text = "Eliminar",
                    HeaderText = "",
                    UseColumnTextForButtonValue = true
                };

                var vColumIndex = dgvPerfiles.Columns.Count;
                if (dgvPerfiles.Columns["btnDelete"] == null)
                {
                    dgvPerfiles.Columns.Insert(vColumIndex, vDeleteButton);
                }

                DataGridViewButtonColumn vEdit = new DataGridViewButtonColumn
                {
                    Name = "btnEdit",
                    Text = "Editar",
                    HeaderText = "",
                    UseColumnTextForButtonValue = true
                };

                if (dgvPerfiles.Columns["btnEdit"] == null)
                {
                    dgvPerfiles.Columns.Insert(vColumIndex + 1, vEdit);
                }


                DataGridViewButtonColumn vFormulario = new DataGridViewButtonColumn
                {
                    Name = "btnFormularios",
                    Text = "Formularios",
                    HeaderText = "",
                    UseColumnTextForButtonValue = true
                };

                if (dgvPerfiles.Columns["btnFormularios"] == null)
                {
                    dgvPerfiles.Columns.Insert(vColumIndex + 2, vFormulario);
                }

                this.dgvPerfiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.dgvPerfiles.AutoResizeColumns();
                this.dgvPerfiles.Refresh();



            }
            catch (Exception ex) {
                throw ex;
            }

        }
        private void SetPerfil()
        {
            try
            {
                this.vPerfilMantenimiento = new Perfil()
                {
                    PerfilID = string.IsNullOrWhiteSpace(txtPerfilID.Text) ? 0 : Convert.ToInt32(txtPerfilID.Text),
                    Descripcion = txtPerfilDescripcion.Text.Trim(),
                    Activo = chkPerfilActivo.Checked
                };
            }
            catch (Exception ex) { throw ex; }
        }
        private void ClearForm()
        {
            txtPerfilID.Text = string.Empty;
            txtPerfilDescripcion.Text = string.Empty;
            chkPerfilActivo.Checked = true;
        }
        #endregion

        #region Eventos
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearForm();
                this.ConsultarPerfiles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            this.SetPerfil();
            this.vPerfilMantenimiento = vServicioJudicial.SavePerfil(this.vPerfilMantenimiento);
            txtPerfilID.Text = this.vPerfilMantenimiento.PerfilID.ToString();
            this.ClearForm();
            this.ConsultarPerfiles();
            MessageBox.Show("Cambios efectuados correctamente.", "Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void dgvPerfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var vSelectedRow = dgvPerfiles.Rows[e.RowIndex];

            if (e.ColumnIndex == dgvPerfiles.Columns["btnDelete"].Index)
            {
                vServicioJudicial.DeletePerfil(Convert.ToInt32(vSelectedRow.Cells["PerfilID"].Value.ToString()));
                this.ConsultarPerfiles();
                MessageBox.Show("Perfil eliminado correctamente.", "Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Information);          
            }

            if (e.ColumnIndex == dgvPerfiles.Columns["btnEdit"].Index)
            {

                txtPerfilID.Text = vSelectedRow.Cells["PerfilID"].Value.ToString();
                txtPerfilDescripcion.Text = vSelectedRow.Cells["Descripcion"].Value.ToString();
                chkPerfilActivo.Checked = Convert.ToBoolean(vSelectedRow.Cells["Activo"].Value);
            }

            if (e.ColumnIndex == dgvPerfiles.Columns["btnFormularios"].Index)
            {
                var vForm = new FrmMantFormulariosPerfiles
                {
                    vPerfil = new Perfil()
                    {
                        PerfilID = Convert.ToInt32(vSelectedRow.Cells["PerfilID"].Value.ToString()),
                        Descripcion = vSelectedRow.Cells["Descripcion"].Value.ToString()
                    }
                };

                vForm.Show();
            }
        }
        private void FrmMantPerfiles_Load(object sender, EventArgs e)
        {
            this.ConsultarPerfiles();
            dgvPerfiles.Columns["FormularioPerfil"].Visible = false;
            dgvPerfiles.Columns["UsuarioPerfil"].Visible = false;
        }
        #endregion

        private void dgvPerfiles_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvPerfiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvPerfiles.AutoResizeColumns();
        }

    }
}

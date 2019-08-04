using sicoju.desktop.WSJudicial;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace sicoju.Seguridad
{
    public partial class FrmMantFormularios : Form
    {
        #region Variables
        private Formulario vFormularioFiltro, vFormularioMantenimiento;
        private ServicioJudicialClient vServicioJudicial = new ServicioJudicialClient();
        #endregion

        #region Constructor
        public FrmMantFormularios()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        private void ConsultarFormularios()
        {
            this.SetFiltros();
            var vListaFormularios = vServicioJudicial.GetFormulariosFiltro(this.vFormularioFiltro);
            this.SetDataSource(vListaFormularios);
        }
        private void SetFiltros()
        {
            this.vFormularioFiltro = new Formulario()
            {
                Descripcion = txtDescripcion.Text.Trim(),
                FormularioID = string.IsNullOrWhiteSpace(txtID.Text) ? 0 : Convert.ToInt32(txtID.Text),
                Activo = chkActivo.Checked
            };
        }
        private void SetDataSource(List<Formulario> pListaFormularios)
        {
            try
            {

                dgvFormularios.DataSource = pListaFormularios;

                DataGridViewButtonColumn vDeleteButton = new DataGridViewButtonColumn();
                vDeleteButton.Name = "btnDelete";
                vDeleteButton.Text = "Eliminar";
                vDeleteButton.HeaderText = "";
                vDeleteButton.UseColumnTextForButtonValue = true;

                var vColumIndex = dgvFormularios.Columns.Count;
                if (dgvFormularios.Columns["btnDelete"] == null)
                {
                    dgvFormularios.Columns.Insert(vColumIndex, vDeleteButton);
                }

                DataGridViewButtonColumn vEdit = new DataGridViewButtonColumn();
                vEdit.Name = "btnEdit";
                vEdit.Text = "Editar";
                vEdit.HeaderText = "";
                vEdit.UseColumnTextForButtonValue = true;

                if (dgvFormularios.Columns["btnEdit"] == null)
                {
                    dgvFormularios.Columns.Insert(vColumIndex + 1, vEdit);
                }

                this.dgvFormularios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.dgvFormularios.AutoResizeColumns();
                this.dgvFormularios.Refresh();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void SetFormulario()
        {
            try
            {
                this.vFormularioMantenimiento = new Formulario()
                {
                    FormularioID = string.IsNullOrWhiteSpace(txtFormularioID.Text) ? 0 : Convert.ToInt32(txtFormularioID.Text),
                    Descripcion = txtFormularioDescripcion.Text.Trim(),
                    Ruta = txtFormularioRuta.Text.Trim(),
                    Activo = chkFormularioActivo.Checked
                };
            }
            catch (Exception ex) { throw ex; }
        }
        private void ClearForm()
        {
            txtFormularioID.Text = string.Empty;
            txtFormularioDescripcion.Text = string.Empty;
            txtFormularioRuta.Text = string.Empty;
            chkFormularioActivo.Checked = true;
        }
        #endregion

        #region Eventos
        private void FrmMantFormularios_Load(object sender, EventArgs e)
        {
            this.ConsultarFormularios();
            dgvFormularios.Columns["FormularioPerfil"].Visible = false;
        }
        private void dgvFormularios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var vSelectedRow = dgvFormularios.Rows[e.RowIndex];

            if (e.ColumnIndex == dgvFormularios.Columns["btnDelete"].Index)
            {
                vServicioJudicial.DeleteFormulario(Convert.ToInt32(vSelectedRow.Cells["FormularioID"].Value.ToString()));
                this.ConsultarFormularios();
                MessageBox.Show("Formulario eliminado correctamente.", "Formularios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (e.ColumnIndex == dgvFormularios.Columns["btnEdit"].Index)
            {

                txtFormularioID.Text = vSelectedRow.Cells["FormularioID"].Value.ToString();
                txtFormularioDescripcion.Text = vSelectedRow.Cells["Descripcion"].Value.ToString();
                txtFormularioRuta.Text = vSelectedRow.Cells["Ruta"].Value.ToString();
                chkFormularioActivo.Checked = Convert.ToBoolean(vSelectedRow.Cells["Activo"].Value);
            }
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearForm();
                this.ConsultarFormularios();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private void pbSave_Click(object sender, EventArgs e)
        {
            this.SetFormulario();
            this.vFormularioMantenimiento = vServicioJudicial.SaveFormulario(this.vFormularioMantenimiento);
            txtFormularioID.Text = this.vFormularioMantenimiento.FormularioID.ToString();
            this.ClearForm();
            this.ConsultarFormularios();
            MessageBox.Show("Cambios efectuados correctamente.", "Formularios", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        #endregion

    }
}

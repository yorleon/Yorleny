using sicoju.desktop.WSJudicial;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace sicoju.Seguridad
{
    public partial class FrmMantFormulariosPerfiles : Form
    {
        #region Variables
        public Perfil vPerfil { get; set; }
        private List<FormularioReporte> vListaFormularios;
        private ServicioJudicialClient vServicioJudicial = new ServicioJudicialClient();
        #endregion

        #region Constructor
        public FrmMantFormulariosPerfiles()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        private void SetPerfil()
        {
            try
            {
                this.Text = string.Format("Formularios asociados al perfil {0}", this.vPerfil.Descripcion);
            }
            catch (Exception ex) { throw ex; }
        }
        private void SetFormularios()
        {
            try
            {
                var vDisponibles = new List<Formulario>();
                var vFormularios = vServicioJudicial.GetFormularios();

                foreach (var vFormulario in vFormularios)
                {
                    if (!this.vListaFormularios.Exists(p => p.Formulario == vFormulario.Descripcion))
                        vDisponibles.Add(vFormulario);
                }

                cmbFormularios.DataSource = vDisponibles;
                cmbFormularios.ValueMember = "FormularioID";
                cmbFormularios.DisplayMember = "Descripcion";
                cmbFormularios.Refresh();
            }
            catch (Exception ex) { throw ex; }
        }
        private void SetDataSource()
        {
            try
            {
                dgvFormulariosPerfil.DataSource = this.vListaFormularios;

                DataGridViewButtonColumn vDeleteButton = new DataGridViewButtonColumn
                {
                    Name = "btnDelete",
                    Text = "Eliminar",
                    HeaderText = "",
                    UseColumnTextForButtonValue = true
                };

                var vColumIndex = dgvFormulariosPerfil.Columns.Count;
                if (dgvFormulariosPerfil.Columns["btnDelete"] == null)
                {
                    dgvFormulariosPerfil.Columns.Insert(vColumIndex, vDeleteButton);
                }

                this.dgvFormulariosPerfil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.dgvFormulariosPerfil.AutoResizeColumns();
                dgvFormulariosPerfil.Refresh();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void GetFormularios()
        {
            vListaFormularios = vServicioJudicial.GetFormulariosPerfil(this.vPerfil.PerfilID);
            this.SetDataSource();
        }
        #endregion

        #region Eventos
        private void FrmMantFormulariosPerfiles_Load(object sender, EventArgs e)
        {
            this.SetPerfil();
            this.GetFormularios();
            this.SetFormularios();
        }

        private void dgvFormulariosPerfil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvFormulariosPerfil.Columns["btnDelete"].Index)
            {
                var vSelectedRow = dgvFormulariosPerfil.Rows[e.RowIndex];
                vServicioJudicial.DeleteFormularioPerfil(Convert.ToInt32(vSelectedRow.Cells["ID"].Value.ToString()));
                this.GetFormularios();
                this.SetFormularios();
                MessageBox.Show("Formulario eliminado correctamente.", "Formularios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var vFormulario = new FormularioPerfil()
                {
                    PerfilID = this.vPerfil.PerfilID,
                    FormularioID = Convert.ToInt32(cmbFormularios.SelectedValue.ToString())
                };

                vServicioJudicial.SaveFormularioPerfil(vFormulario);
                MessageBox.Show("Formulario asociado correctamente.", "Formularios", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
                this.GetFormularios();
                this.SetFormularios();
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}

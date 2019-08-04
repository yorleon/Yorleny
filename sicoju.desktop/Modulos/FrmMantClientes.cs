using BL;
using EL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sicoju.Modulos
{
    public partial class FrmMantClientes : Form
    {

        #region Variables
        private Involucrado vClienteFiltro, vClienteMantenimiento;
        #endregion

        #region Constructor
        public FrmMantClientes()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        private void ConsultarClientes()
        {
            this.SetFiltros();
            var vLista = ClienteBL.GetClientesFiltro(this.vClienteFiltro);
            this.SetDataSource(vLista);
        }
        private void SetFiltros()
        {
            this.vClienteFiltro = new Involucrado()
            {
                Nombre = txtNombre.Text.Trim(),
                PrimerApellido = txtApellidos.Text.Trim(),
                ClienteID = string.IsNullOrWhiteSpace(txtID.Text) ? 0 : Convert.ToInt32(txtID.Text),
                Identificacion = txtIdentificacion.Text.Trim(),
                CorreoElectronico = txtCorreo.Text.Trim(),
                Activo = chkActivo.Checked
            };
        }
        private void SetDataSource(List<Involucrado> pListaClientes)
        {
            try
            {
                dgvClientes.DataSource = pListaClientes;

                DataGridViewButtonColumn vDeleteButton = new DataGridViewButtonColumn();
                vDeleteButton.Name = "btnDelete";
                vDeleteButton.Text = "Eliminar";
                vDeleteButton.HeaderText = "";
                vDeleteButton.UseColumnTextForButtonValue = true;

                var vColumIndex = dgvClientes.Columns.Count;
                if (dgvClientes.Columns["btnDelete"] == null)
                {
                    dgvClientes.Columns.Insert(vColumIndex, vDeleteButton);
                }

                DataGridViewButtonColumn vEdit = new DataGridViewButtonColumn();
                vEdit.Name = "btnEdit";
                vEdit.Text = "Editar";
                vEdit.HeaderText = "";
                vEdit.UseColumnTextForButtonValue = true;

                if (dgvClientes.Columns["btnEdit"] == null)
                {
                    dgvClientes.Columns.Insert(vColumIndex + 1, vEdit);
                }


                DataGridViewButtonColumn vPedido = new DataGridViewButtonColumn();
                vPedido.Name = "btnPedidos";
                vPedido.Text = "Pedidos";
                vPedido.HeaderText = "";
                vPedido.UseColumnTextForButtonValue = true;

                if (dgvClientes.Columns["btnPerfil"] == null)
                {
                    dgvClientes.Columns.Insert(vColumIndex + 2, vPedido);
                }

                this.dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.dgvClientes.AutoResizeColumns();
                this.dgvClientes.Refresh();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void SetCliente()
        {
            try
            {
                this.vClienteMantenimiento = new Involucrado()
                {
                    ClienteID = string.IsNullOrWhiteSpace(txtClienteID.Text) ? 0 : Convert.ToInt32(txtClienteID.Text),
                    Identificacion = txtClienteIdentificacion.Text,
                    Nombre = txtClienteNombre.Text,
                    PrimerApellido = txtClientePrimerApellido.Text,
                    SegundoApellido = txtClienteSegundoApellido.Text,
                    CorreoElectronico = txtClienteCorreo.Text,
                    Telefono = txtClienteTelefono.Text,
                    Activo = chkClienteActivo.Checked
                };
            }
            catch (Exception ex) { throw ex; }
        }
        private void ClearForm()
        {
            txtClienteID.Text = string.Empty;
            txtClienteIdentificacion.Text = string.Empty;
            txtClienteNombre.Text = string.Empty;
            txtClientePrimerApellido.Text = string.Empty;
            txtClienteSegundoApellido.Text = string.Empty;
            txtClienteCorreo.Text = string.Empty;
            txtClienteTelefono.Text = string.Empty;
            chkClienteActivo.Checked = true;
        }

        #endregion

        #region Eventos
        private void pbSave_Click(object sender, EventArgs e)
        {
            this.SetCliente();
            this.vClienteMantenimiento = ClienteBL.SaveCliente(this.vClienteMantenimiento);
            txtClienteID.Text = this.vClienteMantenimiento.ClienteID.ToString();
            this.ClearForm();
            this.ConsultarClientes();
            MessageBox.Show("Cambios efectuados correctamente.", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmMantClientes_Load(object sender, EventArgs e)
        {
            this.ConsultarClientes();
            this.dgvClientes.Columns["Pedido"].Visible = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearForm();
                this.ConsultarClientes();
            }
            catch (Exception ex) { throw ex; }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var vSelectedRow = dgvClientes.Rows[e.RowIndex];

            if (e.ColumnIndex == dgvClientes.Columns["btnDelete"].Index)
            {
                ClienteBL.DeleteCliente(Convert.ToInt32(vSelectedRow.Cells[2].Value.ToString()));
                this.ConsultarClientes();
                MessageBox.Show("Involucrado eliminado correctamente.", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            if (e.ColumnIndex == dgvClientes.Columns["btnEdit"].Index)
            {

                txtClienteID.Text = vSelectedRow.Cells["ClienteID"].Value.ToString();
                txtClienteIdentificacion.Text = vSelectedRow.Cells["Identificacion"].Value.ToString();
                txtClienteNombre.Text = vSelectedRow.Cells["Nombre"].Value.ToString();
                txtClientePrimerApellido.Text = vSelectedRow.Cells["PrimerApellido"].Value.ToString();
                txtClienteSegundoApellido.Text = vSelectedRow.Cells["SegundoApellido"].Value.ToString();
                txtClienteCorreo.Text = vSelectedRow.Cells["CorreoElectronico"].Value.ToString();
                txtClienteTelefono.Text = vSelectedRow.Cells["Telefono"].Value.ToString();
                chkClienteActivo.Checked = Convert.ToBoolean(vSelectedRow.Cells["Activo"].Value);
            }

            if (e.ColumnIndex == dgvClientes.Columns["btnPedidos"].Index)
            {
                var vForm = new FrmMantPedidos();
                vForm.setCliente(vSelectedRow.Cells["Identificacion"].Value.ToString());
                vForm.Show();
            }
        }
        #endregion

        private void txtClienteIdentificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }
    }
}

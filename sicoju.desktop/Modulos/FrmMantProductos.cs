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
    public partial class FrmMantProductos : Form
    {

        #region Variables
        private Producto vProductoFiltro, vProductoMantenimiento;
        #endregion

        public FrmMantProductos()
        {
            InitializeComponent();
        }


        #region Metodos
        private void ConsultarProductos()
        {
            this.SetFiltros();
            var vLista = ProductoBL.GetProductosFiltro(this.vProductoFiltro);
            this.SetDataSource(vLista);
            this.SetDataSourceDisponibles(ProductoBL.GetDisponibilidad(this.vProductoFiltro));
        }
        private void SetFiltros()
        {
            this.vProductoFiltro = new Producto()
            {
                ProductoID = string.IsNullOrWhiteSpace(txtID.Text) ? 0 : Convert.ToInt32(txtID.Text),
                Descripcion = txtDescripcion.Text.Trim(),
            };
        }
        private void SetDataSource(List<Producto> pListaProductos)
        {
            try
            {
                dgvProductos.DataSource = pListaProductos;

                DataGridViewButtonColumn vDeleteButton = new DataGridViewButtonColumn();
                vDeleteButton.Name = "btnDelete";
                vDeleteButton.Text = "Eliminar";
                vDeleteButton.HeaderText = "";
                vDeleteButton.UseColumnTextForButtonValue = true;

                var vColumIndex = dgvProductos.Columns.Count;
                if (dgvProductos.Columns["btnDelete"] == null)
                {
                    dgvProductos.Columns.Insert(vColumIndex, vDeleteButton);
                }

                DataGridViewButtonColumn vEdit = new DataGridViewButtonColumn();
                vEdit.Name = "btnEdit";
                vEdit.Text = "Editar";
                vEdit.HeaderText = "";
                vEdit.UseColumnTextForButtonValue = true;

                if (dgvProductos.Columns["btnEdit"] == null)
                {
                    dgvProductos.Columns.Insert(vColumIndex + 1, vEdit);
                }

                this.dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.dgvProductos.AutoResizeColumns();
                this.dgvProductos.Refresh();

            }
            catch (Exception ex) { }

        }
        private void SetProducto()
        {
            try
            {
                this.vProductoMantenimiento = new Producto()
                {
                    ProductoID = string.IsNullOrWhiteSpace(txtProductoID.Text) ? 0 : Convert.ToInt32(txtProductoID.Text),
                    Descripcion = txtProductoDescripcion.Text,
                    Peso = string.IsNullOrWhiteSpace(txtProductoPeso.Text) ? 0 : Convert.ToDecimal(txtProductoPeso.Text),
                    Stock = string.IsNullOrWhiteSpace(txtProductoStock.Text) ? 0 : Convert.ToInt32(txtProductoStock.Text),
                    IVA = string.IsNullOrWhiteSpace(txtProductoIVA.Text) ? 0 : Convert.ToDecimal(txtProductoIVA.Text),
                    Precio = string.IsNullOrWhiteSpace(txtProductoPrecio.Text) ? 0 : Convert.ToDecimal(txtProductoPrecio.Text),
                };
            }
            catch (Exception ex) { throw ex; }
        }
        private void ClearForm()
        {
            txtProductoID.Text = string.Empty;
            txtProductoDescripcion.Text = string.Empty;
            txtProductoPeso.Text = string.Empty;
            txtProductoStock.Text = string.Empty;
            txtProductoIVA.Text = string.Empty;
            txtProductoPrecio.Text = string.Empty;
        }
        private void SetDataSourceDisponibles(List<vProductosDisponibles> pListaProductos)
        {
            try
            {
                this.dgvDisponible.DataSource = pListaProductos;
                this.dgvDisponible.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.dgvDisponible.AutoResizeColumns();
                this.dgvDisponible.Refresh();

            }
            catch (Exception ex) { }

        }
        #endregion

        #region Eventos
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearForm();
                this.ConsultarProductos();
            }
            catch (Exception ex) { throw ex; }
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            this.SetProducto();
            this.vProductoMantenimiento = ProductoBL.SaveProducto(this.vProductoMantenimiento);
            txtProductoID.Text = this.vProductoMantenimiento.ProductoID.ToString();
            this.ClearForm();
            this.ConsultarProductos();
            MessageBox.Show("Cambios efectuados correctamente.", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var vSelectedRow = dgvProductos.Rows[e.RowIndex];

            if (e.ColumnIndex == dgvProductos.Columns["btnDelete"].Index)
            {
                ProductoBL.DeleteProducto(Convert.ToInt32(vSelectedRow.Cells[2].Value.ToString()));
                this.ConsultarProductos();
                MessageBox.Show("Producto eliminado correctamente.", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }

            if (e.ColumnIndex == dgvProductos.Columns["btnEdit"].Index)
            {

                txtProductoID.Text = vSelectedRow.Cells["ProductoID"].Value.ToString();
                txtProductoDescripcion.Text = vSelectedRow.Cells["Descripcion"].Value.ToString();
                txtProductoPeso.Text = vSelectedRow.Cells["Peso"].Value.ToString();
                txtProductoPrecio.Text = vSelectedRow.Cells["Precio"].Value.ToString();
                txtProductoStock.Text = vSelectedRow.Cells["Stock"].Value.ToString();
                txtProductoIVA.Text = vSelectedRow.Cells["IVA"].Value.ToString();
            }
        }

        private void FrmMantProductos_Load(object sender, EventArgs e)
        {
            this.ConsultarProductos();
            this.dgvProductos.Columns["DetallePedido"].Visible = false;
        }
        #endregion
    }
}

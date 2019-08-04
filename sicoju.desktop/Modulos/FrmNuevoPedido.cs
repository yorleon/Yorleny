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
    public partial class FrmNuevoPedido : Form
    {
        #region Variables
        private List<Producto> vListaProductos;
        private List<vProductosDisponibles> vDisponibles;
        private List<Involucrado> vListaClientes;
        private Pedido vPedido = new Pedido();
        private Dictionary<int, int> vProductosAgregados = new Dictionary<int, int>();
        #endregion

        #region Constructor
        public FrmNuevoPedido()
        {
            InitializeComponent();
        }

        public FrmNuevoPedido(int pPedidoID)
        {
            InitializeComponent();
            this.vPedido = PedidoBL.GetPedido(pPedidoID);
            this.Text = string.Format("Pedido # {0}", pPedidoID);
        }
        #endregion

        #region Metodos
        private void ObtenerRegiones()
        {
            try
            {
                this.cbPedidoRegion.ValueMember = "RegionID";
                this.cbPedidoRegion.DisplayMember = "Descripcion";
                this.cbPedidoRegion.DataSource = PedidoBL.GetRegiones();
            }
            catch (Exception ex) { throw ex; }
        }
        private void ObtenerClientes()
        {
            try
            {
                this.vListaClientes = PedidoBL.GetClientes();
                this.cbPedidoCliente.ValueMember = "ClienteID";
                this.cbPedidoCliente.DataSource = vListaClientes;
            }
            catch (Exception ex) { throw ex; }
        }
        private void ObtenerProductos()
        {
            try
            {
                this.vListaProductos = PedidoBL.GetProductos();
                this.cbPedidoProducto.ValueMember = "ProductoID";
                this.cbPedidoProducto.DisplayMember = "Descripcion";
                this.cbPedidoProducto.DataSource = vListaProductos;
            }
            catch (Exception ex) { throw ex; }
        }
        private void ObtenerDisponibles()
        {
            try
            {
                this.vDisponibles = ProductoBL.GetDisponibilidad(new Producto());
            }
            catch (Exception ex) { throw ex; }
        }
        private void SetDataSource()
        {
            try
            {

                if (vPedido != null && vPedido.PedidoID > 0)
                {
                    txtPedidoID.Text = vPedido.PedidoID.ToString();
                    txtPedidoDireccion.Text = vPedido.Direcciones;
                    cbPedidoCliente.SelectedValue = vPedido.ClienteID.Value;
                    cbPedidoRegion.SelectedValue = vPedido.RegionID.Value;

                    if (vPedido.FechaEntrega.HasValue)
                        dtFechaEntrega.Value = vPedido.FechaEntrega.Value;
                }

                if (vPedido.DetallePedido == null)
                    vPedido.DetallePedido = new List<DetallePedido>();

                this.dgvDetallePedido.AutoGenerateColumns = false;
                this.dgvDetallePedido.DataSource = new BindingList<DetallePedido>(vPedido.DetallePedido.ToList());
                this.dgvDetallePedido.AutoGenerateColumns = true;

                var vColumIndex = dgvDetallePedido.Columns.Count;
                DataGridViewTextBoxColumn vPrecio = new DataGridViewTextBoxColumn();
                vPrecio.HeaderText = "Precio";
                vPrecio.Name = "Precio";
                vPrecio.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                DataGridViewTextBoxColumn vImpuesto = new DataGridViewTextBoxColumn();
                vImpuesto.HeaderText = "I.V.A";
                vImpuesto.Name = "IVA";
                vImpuesto.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                DataGridViewTextBoxColumn vSubTotal = new DataGridViewTextBoxColumn();
                vSubTotal.HeaderText = "Sub-Total";
                vSubTotal.Name = "SubTotal";
                vSubTotal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                DataGridViewButtonColumn vDeleteButton = new DataGridViewButtonColumn();
                vDeleteButton.Name = "btnDelete";
                vDeleteButton.Text = "Eliminar";
                vDeleteButton.HeaderText = "";
                vDeleteButton.UseColumnTextForButtonValue = true;

                if (this.dgvDetallePedido.Columns["btnDelete"] == null)
                {
                    this.dgvDetallePedido.Columns.Insert(vColumIndex, vDeleteButton);
                }

                if (this.dgvDetallePedido.Columns["Precio"] == null)
                {
                    this.dgvDetallePedido.Columns.Insert(vColumIndex++, vPrecio);
                }

                if (this.dgvDetallePedido.Columns["IVA"] == null)
                {
                    this.dgvDetallePedido.Columns.Insert(vColumIndex++, vImpuesto);
                }

                if (this.dgvDetallePedido.Columns["SubTotal"] == null)
                {
                    this.dgvDetallePedido.Columns.Insert(vColumIndex++, vSubTotal);
                }

                this.dgvDetallePedido.Columns["Pedido"].Visible = false;
                this.dgvDetallePedido.Columns["PedidoID"].Visible = false;
                this.dgvDetallePedido.Columns["DetallePedidoID"].HeaderText = "# Línea";
                this.dgvDetallePedido.Columns["ProductoID"].HeaderText = "ID Producto";
                this.dgvDetallePedido.Columns["Cantidad"].DisplayIndex = 5;
                this.dgvDetallePedido.Columns["Precio"].DisplayIndex = 6;

                this.dgvDetallePedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.dgvDetallePedido.AutoResizeColumns();
                this.dgvDetallePedido.Refresh();
            }
            catch (Exception ex) { throw ex; }
        }
        private void CalcularDisponibilidad()
        {
            try
            {
                var vProducto = ((Producto)cbPedidoProducto.SelectedItem);
                var vDisponible = this.vDisponibles.FirstOrDefault(p => p.ProductoID == vProducto.ProductoID);
                var vAgregado = this.vProductosAgregados.FirstOrDefault(p => p.Key == vProducto.ProductoID);
                var vCantidadAgregada = 0;

                if (vAgregado.Key != 0)
                    vCantidadAgregada = vAgregado.Value;

                lblDisponible.Text = string.Format("Disponible: {0}", vDisponible.Disponible.Value - vCantidadAgregada);
                txtCantidadProducto.Maximum = vDisponible.Disponible.Value - vCantidadAgregada;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Eventos
        private void FrmNuevoPedido_Load(object sender, EventArgs e)
        {
            this.ObtenerRegiones();
            this.ObtenerClientes();
            this.ObtenerDisponibles();
            this.ObtenerProductos();
            this.SetDataSource();


            this.dtFechaEntrega.Format = DateTimePickerFormat.Custom;
            this.dtFechaEntrega.CustomFormat = "dd/MM/yyyy h:mm:ss tt";
        }

        private void cbPedidoCliente_Format(object sender, ListControlConvertEventArgs e)
        {
            var vCliente = ((Involucrado)e.ListItem);
            e.Value = string.Format("{0} {1} {2}", vCliente.Nombre, vCliente.PrimerApellido, vCliente.SegundoApellido);
        }

        private void cbPedidoProducto_TextUpdate(object sender, EventArgs e)
        {
            string vFilter = cbPedidoProducto.Text.ToString().ToUpper();
            var vFiltro = vListaProductos.FindAll(x => x.Descripcion.ToUpper().Contains(vFilter));

            cbPedidoProducto.DataSource = vFiltro;

            if (String.IsNullOrWhiteSpace(vFilter))
                cbPedidoProducto.DataSource = vListaProductos;

            cbPedidoProducto.DroppedDown = true;
            cbPedidoProducto.IntegralHeight = true;
            cbPedidoProducto.SelectedIndex = -1;
            cbPedidoProducto.Text = vFilter;
            cbPedidoProducto.SelectionStart = vFilter.Length;
            cbPedidoProducto.SelectionLength = 0;
        }

        private void cbPedidoCliente_TextUpdate(object sender, EventArgs e)
        {
            string vFilter = cbPedidoCliente.Text.ToString().ToUpper();
            var vFiltro = vListaClientes.FindAll(x => x.Nombre.ToUpper().Contains(vFilter) || x.PrimerApellido.ToUpper().Contains(vFilter) || x.SegundoApellido.ToUpper().Contains(vFilter));

            cbPedidoCliente.DataSource = vFiltro;

            if (String.IsNullOrWhiteSpace(vFilter))
                cbPedidoCliente.DataSource = vListaClientes;

            cbPedidoCliente.DroppedDown = true;
            cbPedidoCliente.IntegralHeight = true;
            cbPedidoCliente.SelectedIndex = -1;
            cbPedidoCliente.Text = vFilter;
            cbPedidoCliente.SelectionStart = vFilter.Length;
            cbPedidoCliente.SelectionLength = 0;
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            var vPedidoID = string.IsNullOrWhiteSpace(txtPedidoID.Text) ? 0 : Convert.ToInt32(txtPedidoID.Text);
            var vRespuesta = MessageBox.Show("Desea registrar el pedido?", "Pedidos", MessageBoxButtons.YesNo);
            if (vRespuesta == System.Windows.Forms.DialogResult.No)
                return;

            this.vPedido.ClienteID = (int)cbPedidoCliente.SelectedValue;
            this.vPedido.Direcciones = txtPedidoDireccion.Text.ToUpper();
            this.vPedido.RegionID = (int)cbPedidoRegion.SelectedValue;
            this.vPedido.Fecha = DateTime.Now;
            this.vPedido.FechaEntrega = dtFechaEntrega.Value;

            if (vPedidoID == 0)
            {
                this.vPedido.Trazabilidad = new List<Trazabilidad>();
                this.vPedido.Trazabilidad.Add(new Trazabilidad() { PedidoID = vPedidoID, EstadoID = (int)Constantes.Estados.PreAdminision, Fecha = DateTime.Now });
            }

            this.vPedido = PedidoBL.SavePedido(this.vPedido);
            txtPedidoID.Text = this.vPedido.PedidoID.ToString();
            this.SetDataSource();
            this.ObtenerDisponibles();
            this.vProductosAgregados.Clear();
            MessageBox.Show("Cambios efectuados correctamente.", "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pbAgregar_Click(object sender, EventArgs e)
        {
            var vPedidoID = string.IsNullOrWhiteSpace(txtPedidoID.Text) ? 0 : Convert.ToInt32(txtPedidoID.Text);
            var vProducto = ((Producto)cbPedidoProducto.SelectedItem);
            var vExistente = this.vPedido.DetallePedido.FirstOrDefault(p => p.ProductoID == vProducto.ProductoID);
            var vAcumular = false;

            if (vExistente != null)
            {
                var vRespuesta = MessageBox.Show("Este producto ya se encuentra registrado, desea ingresarlo de todos modos?", "Pedidos", MessageBoxButtons.YesNo);
                if (vRespuesta == System.Windows.Forms.DialogResult.No)
                    return;

                vAcumular = true;
            }

            if (vAcumular)
                vExistente.Cantidad += (int)txtCantidadProducto.Value;
            else
            {
                this.vPedido.DetallePedido.Add(new DetallePedido()
                {
                    PedidoID = vPedidoID,
                    ProductoID = vProducto.ProductoID,
                    Cantidad = (int)txtCantidadProducto.Value,
                });
            }

            var vAgregado = this.vProductosAgregados.FirstOrDefault(p => p.Key == vProducto.ProductoID);

            if (vAgregado.Key == 0)
            {
                this.vProductosAgregados.Add(vProducto.ProductoID, (int)txtCantidadProducto.Value);
            }
            else
            {
                this.vProductosAgregados[vAgregado.Key] = vAgregado.Value + (int)txtCantidadProducto.Value;
            }

            this.SetDataSource();
            this.CalcularDisponibilidad();

        }

        private void dgvDetallePedido_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            var vDetalle = this.dgvDetallePedido.Rows[e.RowIndex].DataBoundItem as DetallePedido;
            var vProducto = this.vListaProductos.FirstOrDefault(p => p.ProductoID == vDetalle.ProductoID);

            if (e.ColumnIndex == dgvDetallePedido.Columns["DetallePedidoID"].Index)
            {
                if (vDetalle != null)
                {
                    e.Value = string.Format("{0}", e.RowIndex + 1);
                    e.FormattingApplied = true;
                }

            }

            if (e.ColumnIndex == dgvDetallePedido.Columns["Producto"].Index)
            {
                if (vDetalle != null && vProducto != null)
                {
                    e.Value = string.Format("{0}", vProducto.Descripcion);
                    e.FormattingApplied = true;
                }

            }

            if (dgvDetallePedido.Columns["Precio"] != null && e.ColumnIndex == dgvDetallePedido.Columns["Precio"].Index)
            {
                if (vDetalle != null && vProducto != null)
                {
                    e.Value = string.Format("{0}", vProducto.Precio.ToString());
                    e.FormattingApplied = true;
                }
            }

            if (dgvDetallePedido.Columns["IVA"] != null && e.ColumnIndex == dgvDetallePedido.Columns["IVA"].Index)
            {
                if (vDetalle != null && vProducto != null)
                {
                    e.Value = string.Format("{0}%", vProducto.IVA.ToString());
                    e.FormattingApplied = true;
                }

            }

            if (dgvDetallePedido.Columns["SubTotal"] != null && e.ColumnIndex == dgvDetallePedido.Columns["SubTotal"].Index)
            {
                if (vDetalle != null && vProducto != null)
                {
                    var vValor = vProducto.Precio * vDetalle.Cantidad;
                    e.Value = Convert.ToDouble((vValor + (vValor * (vProducto.IVA) / 100))).ToString("N2");
                    e.FormattingApplied = true;
                }

            }

        }

        private void dgvDetallePedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var vDetallePedido = dgvDetallePedido.Rows[e.RowIndex].DataBoundItem as DetallePedido;

            #region Estado
            if (e.ColumnIndex == dgvDetallePedido.Columns["btnDelete"].Index)
            {
                if (vDetallePedido.DetallePedidoID > 0)
                    PedidoBL.DeleteDetallePedido(vDetallePedido.DetallePedidoID);

                this.vPedido.DetallePedido.Remove(vDetallePedido);

                var vAgregado = this.vProductosAgregados.FirstOrDefault(p => p.Key == vDetallePedido.ProductoID.Value);
                if (vAgregado.Key != 0)
                    this.vProductosAgregados.Remove(vDetallePedido.ProductoID.Value);

                this.ObtenerDisponibles();
                this.SetDataSource();
                this.CalcularDisponibilidad();
            }
            #endregion
        }

        private void cbPedidoProducto_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidadProducto_ValueChanged(object sender, EventArgs e)
        {
            pbAgregar.Enabled = true;
            pbAgregar.Enabled = (int)txtCantidadProducto.Value > 0;

            if (txtCantidadProducto.Value > txtCantidadProducto.Maximum)
            {
                pbAgregar.Enabled = false;
                MessageBox.Show("La cantidad disponible de este producto es: " + txtCantidadProducto.Maximum.ToString(), "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cbPedidoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CalcularDisponibilidad();
        }

        #endregion

    }
}

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
    public partial class FrmMantPedidos : Form
    {
        private List<Pedido> vPedidos;
        private Pedido vPedidoFiltro, vPedidoMantenimiento;

        public FrmMantPedidos()
        {
            InitializeComponent();
        }

        #region Metodos
        private void ObtenerPedidos()
        {

            this.SetFiltros();
            this.vPedidos = PedidoBL.GetPedidosFiltro(vPedidoFiltro);

            if (vPedidos == null || vPedidos.Count == 0)
                MessageBox.Show("No existen pedidos que coincidan con los filtros de búsqueda.", "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.SetDataSource();
        }
        private void SetDataSource()
        {
            try
            {
                dgvPedidos.AutoGenerateColumns = false;
                dgvPedidos.DataSource = this.vPedidos;
                dgvPedidos.AutoGenerateColumns = true;

                DataGridViewButtonColumn vDeleteButton = new DataGridViewButtonColumn();
                vDeleteButton.Name = "btnDelete";
                vDeleteButton.Text = "Cancelar";
                vDeleteButton.HeaderText = "";
                vDeleteButton.UseColumnTextForButtonValue = true;

                var vColumIndex = dgvPedidos.Columns.Count;
                if (dgvPedidos.Columns["btnDelete"] == null)
                {
                    dgvPedidos.Columns.Insert(vColumIndex, vDeleteButton);
                }

                DataGridViewButtonColumn vDetailsButton = new DataGridViewButtonColumn();
                vDetailsButton.Name = "btnDetalle";
                vDetailsButton.Text = "Detalle";
                vDetailsButton.HeaderText = "";
                vDetailsButton.UseColumnTextForButtonValue = true;

                if (dgvPedidos.Columns["btnDetalle"] == null)
                {
                    dgvPedidos.Columns.Insert(vColumIndex + 1, vDetailsButton);
                }

                DataGridViewButtonColumn vHistoryButton = new DataGridViewButtonColumn();
                vHistoryButton.Name = "btnHistory";
                vHistoryButton.Text = "Trazabilidad";
                vHistoryButton.HeaderText = "";
                vHistoryButton.UseColumnTextForButtonValue = true;

                if (dgvPedidos.Columns["btnHistory"] == null)
                {
                    dgvPedidos.Columns.Insert(vColumIndex + 2, vHistoryButton);
                }

                DataGridViewButtonColumn vEditButton = new DataGridViewButtonColumn();
                vEditButton.Name = "btnEdit";
                vEditButton.Text = "Editar";
                vEditButton.HeaderText = "";
                vEditButton.UseColumnTextForButtonValue = true;

                if (dgvPedidos.Columns["btnEdit"] == null)
                {
                    dgvPedidos.Columns.Insert(vColumIndex + 3, vEditButton);
                }


                this.dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.dgvPedidos.AutoResizeColumns();
                this.dgvPedidos.Refresh();

            }
            catch (Exception ex) {
                throw ex;
            }

        }
        private void SetFiltros()
        {
            this.vPedidoFiltro = new Pedido()
            {
                PedidoID = string.IsNullOrWhiteSpace(txtID.Text) ? 0 : Convert.ToInt32(txtID.Text),
                Involucrado = new Involucrado() { Identificacion = txtIdentificacion.Text.Trim() }
            };

            if (chkAplicarFechas.Checked)
            {
                this.vPedidoFiltro.Fecha = dtDesde.Value;
                this.vPedidoFiltro.FechaEntrega = dtHasta.Value;
            }
        }
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
        public void setCliente(string pIdentificacion)
        {
            this.txtIdentificacion.Text = pIdentificacion;
        }
        #endregion

        #region Eventos
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ObtenerPedidos();
            }
            catch (Exception ex) { throw ex; }
        }

        private void FrmMantPedidos_Load(object sender, EventArgs e)
        {
            //if (txtIdentificacion.Text != null && txtIdentificacion.Text.Trim().Length > 0)
            //{
            this.SetFiltros();
            this.ObtenerPedidos();
            //}

            dgvPedidos.Columns["RegionID"].Visible = false;
            dgvPedidos.Columns["ClienteID"].Visible = false;
            dgvPedidos.Columns["Fecha"].Visible = false;

            dgvPedidos.Columns["Trazabilidad"].HeaderText = "Estado Actual";
            dgvPedidos.Columns["Direcciones"].HeaderText = "Dirección";
            dgvPedidos.Columns["DetallePedido"].HeaderText = "# Productos";
            dgvPedidos.Columns["DetallePedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dtDesde.Format = DateTimePickerFormat.Custom;
            this.dtDesde.CustomFormat = "dd/MM/yyyy";
            this.dtHasta.Format = DateTimePickerFormat.Custom;
            this.dtHasta.CustomFormat = "dd/MM/yyyy";

            this.ObtenerRegiones();
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var vPedido = dgvPedidos.Rows[e.RowIndex].DataBoundItem as Pedido;
            var vPedidos = new BindingList<DetallePedido>(vPedido.DetallePedido.ToList());
            var vHistorial = new BindingList<Trazabilidad>(vPedido.Trazabilidad.ToList());
            this.vPedidoMantenimiento = vPedido;

            this.cbPedidoRegion.SelectedValue = vPedido.RegionID.Value;
            this.txtPedidoID.Text = vPedido.PedidoID.ToString();
            this.txtPedidoDireccion.Text = vPedido.Direcciones;

            #region Detalle
            if (e.ColumnIndex == dgvPedidos.Columns["btnDetalle"].Index)
            {
                this.dgvDetallePedido.AutoGenerateColumns = false;
                this.dgvDetallePedido.DataSource = vPedidos;
                this.dgvDetallePedido.AutoGenerateColumns = true;

                DataGridViewTextBoxColumn vPrecio = new DataGridViewTextBoxColumn();
                vPrecio.HeaderText = "Precio";
                vPrecio.Name = "Precio";
                vPrecio.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                var vColumIndex = dgvDetallePedido.Columns.Count;
                if (this.dgvDetallePedido.Columns["Precio"] == null)
                {
                    this.dgvDetallePedido.Columns.Insert(vColumIndex, vPrecio);
                }

                DataGridViewTextBoxColumn vImpuesto = new DataGridViewTextBoxColumn();
                vImpuesto.HeaderText = "I.V.A";
                vImpuesto.Name = "IVA";
                vImpuesto.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                if (this.dgvDetallePedido.Columns["IVA"] == null)
                {
                    this.dgvDetallePedido.Columns.Insert(vColumIndex++, vImpuesto);
                }

                DataGridViewTextBoxColumn vSubTotal = new DataGridViewTextBoxColumn();
                vSubTotal.HeaderText = "Sub-Total";
                vSubTotal.Name = "SubTotal";
                vSubTotal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

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
                this.dgvDetallePedido.Columns["SubTotal"].DisplayIndex = 7;

                this.dgvDetallePedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.dgvDetallePedido.AutoResizeColumns();
                this.dgvDetallePedido.Refresh();

                var Total = 0M;
                foreach (var vDetalle in vPedidos)
                {
                    var vValor = vDetalle.Producto.Precio * vDetalle.Cantidad;
                    var vIVA = vDetalle.Producto.IVA.HasValue ? vDetalle.Producto.IVA.Value : 0M;
                    Total += Convert.ToDecimal((vValor + (vValor * (vIVA) / 100)));
                }

                lblTotal.Text = "Total: " + Total.ToString("N2");
                this.pnDetalle.Show();

            }
            #endregion

            #region Estado
            if (e.ColumnIndex == dgvPedidos.Columns["btnDelete"].Index)
            {

                if (vPedido.Trazabilidad.LastOrDefault().EstadoID == (int)Constantes.Estados.Completado) 
                {
                    MessageBox.Show("No se puede actualizar el estado de un pedido completado.", "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                PedidoBL.UpdateEstadoPedido(vPedido);
                this.ObtenerPedidos();

            }
            #endregion

            #region Trazabilidad
            if (e.ColumnIndex == dgvPedidos.Columns["btnHistory"].Index)
            {
                var vRastreo = new FrmRastrear(vPedido.Trazabilidad.ToList());
                vRastreo.Show();
            }
            #endregion

            #region Editar
            if (e.ColumnIndex == dgvPedidos.Columns["btnEdit"].Index)
            {
                var vFormEdit = new FrmNuevoPedido(vPedido.PedidoID);
                vFormEdit.ShowDialog();
            }
            #endregion
        }

        private void dgvPedidos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var vPedido = dgvPedidos.Rows[e.RowIndex].DataBoundItem as Pedido;

            if (e.ColumnIndex == dgvPedidos.Columns["Involucrado"].Index)
            {
                if (vPedido != null && vPedido.Involucrado != null && vPedido.Involucrado.ClienteID != 0)
                {
                    e.Value = string.Format("{0} {1} {2}", vPedido.Involucrado.Nombre, vPedido.Involucrado.PrimerApellido, vPedido.Involucrado.SegundoApellido);
                    e.FormattingApplied = true;
                }

            }

            if (e.ColumnIndex == dgvPedidos.Columns["Region"].Index)
            {
                if (vPedido != null && vPedido.Region != null && vPedido.Region.RegionID != 0)
                {
                    e.Value = vPedido.Region.Descripcion;
                    e.FormattingApplied = true;
                }

            }

            if (e.ColumnIndex == dgvPedidos.Columns["DetallePedido"].Index)
            {
                if (vPedido != null && vPedido.DetallePedido != null)
                {
                    e.Value = vPedido.DetallePedido.Count().ToString();
                    e.FormattingApplied = true;
                }

            }

            if (e.ColumnIndex == dgvPedidos.Columns["Trazabilidad"].Index)
            {
                if (vPedido != null && vPedido.Trazabilidad != null && vPedido.Trazabilidad.Count > 0)
                {
                    e.Value = vPedido.Trazabilidad.LastOrDefault().Estado.Descripcion;
                    e.FormattingApplied = true;
                }

            }

            if (dgvPedidos.Columns["btnDelete"] != null)
            {
                if (e.ColumnIndex == dgvPedidos.Columns["btnDelete"].Index)
                {
                    if (vPedido != null && vPedido.Trazabilidad != null && vPedido.Trazabilidad.Count > 0)
                    {
                        var vEstadoActual = vPedido.Trazabilidad.LastOrDefault().Estado.EstadoID;
                        var vTexto = string.Empty;

                        switch (vEstadoActual)
                        {
                            case (int)Constantes.Estados.Cancelado:
                                vTexto = "Reanudar";
                                break;

                            case (int)Constantes.Estados.Completado:
                                vTexto = "Completado";
                                break;

                            default:
                                vTexto = "Cancelar";
                                break;
                        }

                        e.Value = vTexto;
                        e.FormattingApplied = true;
                    }
                }
            }
        }
        private void dgvDetallePedido_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var vDetalle = this.dgvDetallePedido.Rows[e.RowIndex].DataBoundItem as DetallePedido;

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
                if (vDetalle != null && vDetalle.Producto != null)
                {
                    e.Value = string.Format("{0}", vDetalle.Producto.Descripcion);
                    e.FormattingApplied = true;
                }

            }

            if (dgvDetallePedido.Columns["Precio"] != null && e.ColumnIndex == dgvDetallePedido.Columns["Precio"].Index)
            {
                if (vDetalle != null && vDetalle.Producto != null)
                {
                    e.Value = string.Format("{0}", vDetalle.Producto.Precio.ToString());
                    e.FormattingApplied = true;
                }
            }

            if (dgvDetallePedido.Columns["IVA"] != null && e.ColumnIndex == dgvDetallePedido.Columns["IVA"].Index)
            {
                if (vDetalle != null && vDetalle.Producto != null)
                {
                    e.Value = string.Format("{0}%", vDetalle.Producto.IVA.ToString());
                    e.FormattingApplied = true;
                }

            }

            if (dgvDetallePedido.Columns["SubTotal"] != null && e.ColumnIndex == dgvDetallePedido.Columns["SubTotal"].Index)
            {
                if (vDetalle != null && vDetalle.Producto != null)
                {
                    var vValor = vDetalle.Producto.Precio * vDetalle.Cantidad;
                    e.Value = Convert.ToDouble((vValor + (vValor * (vDetalle.Producto.IVA) / 100))).ToString("N2");
                    e.FormattingApplied = true;
                }

            }
        }

        private void pbRegresar_Click(object sender, EventArgs e)
        {
            this.pnDetalle.Hide();
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            if (vPedidoMantenimiento == null || vPedidoMantenimiento.PedidoID == 0)
            {
                MessageBox.Show("Debe seleccionar un pedido, antes de poder continuar.", "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.vPedidoMantenimiento.RegionID = Convert.ToInt32(this.cbPedidoRegion.SelectedValue);
            this.vPedidoMantenimiento.Direcciones = txtPedidoDireccion.Text;
            PedidoBL.SavePedido(this.vPedidoMantenimiento);
            this.ObtenerPedidos();

            MessageBox.Show("Cambios efectuados correctamente.", "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion



    }
}

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
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        #region Variables
        private Usuario vUsuarioFiltro;
        private Involucrado vClienteFiltro;
        private Producto vProductoFiltro;
        private Pedido vPedidoFiltro;
        #endregion

        #region Metodos

        #region Usuarios
        private void ConsultarUsuarios()
        {
            this.SetFiltrosUsuario();
            var vListaUsuarios = UsuarioBL.GetUsuariosFiltro(this.vUsuarioFiltro, true);
            this.SetDataSourceUsuarios(vListaUsuarios);
        }
        private void SetFiltrosUsuario()
        {
            this.vUsuarioFiltro = new Usuario()
            {
                Nombre = txtNombre.Text.Trim(),
                PrimerApellido = txtApellidos.Text.Trim(),
                UsuarioID = string.IsNullOrWhiteSpace(txtID.Text) ? 0 : Convert.ToInt32(txtID.Text),
                Identificacion = txtIdentificacion.Text.Trim(),
                CorreoElectronico = txtCorreo.Text.Trim()
            };
        }
        private void SetDataSourceUsuarios(List<Usuario> pListaUsuarios)
        {
            try
            {
                var vLinked = new BindingList<Usuario>(pListaUsuarios);

                this.dgvUsuariosActivos.DataSource = vLinked.Where(u => u.Activo == true).ToList();
                this.dgvUsuariosActivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                DataGridViewTextBoxColumn vPerfiles = new DataGridViewTextBoxColumn();
                vPerfiles.HeaderText = "Perfiles";
                vPerfiles.Name = "Perfiles";
                vPerfiles.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                var vColumIndex = this.dgvUsuariosActivos.Columns.Count;

                this.dgvUsuariosInactivos.DataSource = vLinked.Where(u => u.Activo == false).ToList();
                this.dgvUsuariosInactivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                if (this.dgvUsuariosActivos.Columns["Perfiles"] == null)
                {
                    this.dgvUsuariosActivos.Columns.Insert(vColumIndex, vPerfiles);
                }


                DataGridViewTextBoxColumn vPerfilesInactivos = new DataGridViewTextBoxColumn();
                vPerfilesInactivos.HeaderText = "Perfiles";
                vPerfilesInactivos.Name = "Perfiles";
                vPerfilesInactivos.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (this.dgvUsuariosInactivos.Columns["Perfiles"] == null)
                {
                    this.dgvUsuariosInactivos.Columns.Insert(vColumIndex, vPerfilesInactivos);
                }

                this.dgvUsuariosActivos.Columns["Clave"].Visible = false;
                this.dgvUsuariosActivos.Columns["Restablecer"].Visible = false;
                this.dgvUsuariosActivos.Columns["UsuarioPerfil"].Visible = false;

                this.dgvUsuariosInactivos.Columns["Clave"].Visible = false;
                this.dgvUsuariosInactivos.Columns["Restablecer"].Visible = false;
                this.dgvUsuariosInactivos.Columns["UsuarioPerfil"].Visible = false;

                this.dgvUsuariosActivos.AutoResizeColumns();
                this.dgvUsuariosActivos.Refresh();
                this.dgvUsuariosInactivos.AutoResizeColumns();
                this.dgvUsuariosInactivos.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Clientes
        private void ConsultarClientes()
        {
            this.SetFiltrosClientes();
            var vLista = ClienteBL.GetClientesFiltro(this.vClienteFiltro);
            this.SetDataSourceClientes(vLista);
        }
        private void SetFiltrosClientes()
        {
            this.vClienteFiltro = new Involucrado()
            {
                Nombre = txtNombreCliente.Text.Trim(),
                PrimerApellido = txtApellidosCliente.Text.Trim(),
                ClienteID = string.IsNullOrWhiteSpace(txtIDCliente.Text) ? 0 : Convert.ToInt32(txtIDCliente.Text),
                Identificacion = txtIdentificacionCliente.Text.Trim(),
                CorreoElectronico = txtCorreoCliente.Text.Trim(),
                Activo = chkEstadoCliente.Checked
            };
        }
        private void SetDataSourceClientes(List<Involucrado> pListaClientes)
        {
            try
            {
                this.dgvClientes.DataSource = pListaClientes;
                this.dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.dgvClientes.AutoResizeColumns();
                this.dgvClientes.Refresh();

                this.dgvClientes.Columns["Pedido"].Visible = false;

            }
            catch (Exception ex) { }

        }
        #endregion

        #region Productos
        private void ConsultarProductos()
        {
            this.SetFiltros();
            var vLista = ProductoBL.GetProductosFiltro(this.vProductoFiltro);
            this.SetDataSourceDisponibles(ProductoBL.GetDisponibilidad(this.vProductoFiltro));
        }
        private void SetFiltros()
        {
            this.vProductoFiltro = new Producto()
            {
                ProductoID = string.IsNullOrWhiteSpace(txtIDPedido.Text) ? 0 : Convert.ToInt32(txtIDPedido.Text)
            };
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

        #region Pedidos
        private void ConsultarPedidos()
        {
            this.SetFiltrosPedidos();
            var vPedidos = PedidoBL.GetPedidosFiltro(vPedidoFiltro);
            this.SetDataSource(vPedidos);
        }
        private void SetDataSource(List<Pedido> pListaPedidos)
        {
            try
            {
                this.dgvPedidos.AutoGenerateColumns = false;
                this.dgvPedidos.DataSource = pListaPedidos;
                this.dgvPedidos.AutoGenerateColumns = true;

                this.dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.dgvPedidos.AutoResizeColumns();
                this.dgvPedidos.Refresh();


                this.dgvPedidos.Columns["RegionID"].Visible = false;
                this.dgvPedidos.Columns["ClienteID"].Visible = false;
                this.dgvPedidos.Columns["Fecha"].Visible = false;

                this.dgvPedidos.Columns["Trazabilidad"].Visible = false;
                this.dgvPedidos.Columns["Region"].Visible = false;

                this.dgvPedidos.Columns["Direcciones"].HeaderText = "Dirección";
                this.dgvPedidos.Columns["DetallePedido"].HeaderText = "Monto Total";
                this.dgvPedidos.Columns["DetallePedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex) { }

        }
        private void SetFiltrosPedidos()
        {
            this.vPedidoFiltro = new Pedido()
            {
                PedidoID = string.IsNullOrWhiteSpace(txtIDPedido.Text) ? 0 : Convert.ToInt32(txtIDPedido.Text)
            };

            if (chkAplicarFechas.Checked)
            {
                this.vPedidoFiltro.Fecha = dtDesde.Value;
                this.vPedidoFiltro.FechaEntrega = dtHasta.Value;
            }
        }
        #endregion

        #endregion

        #region Eventos
        private void btnConsultarUsuarios_Click(object sender, EventArgs e)
        {
            this.ConsultarUsuarios();
        }
        private void btnConsultarClientes_Click(object sender, EventArgs e)
        {
            this.ConsultarClientes();
        }
        private void btnConsultarProductos_Click(object sender, EventArgs e)
        {
            this.ConsultarPedidos();
            this.ConsultarProductos();
        }
        private void dgvUsuariosActivos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var vUsuario = this.dgvUsuariosActivos.Rows[e.RowIndex].DataBoundItem as Usuario;

            if (this.dgvUsuariosActivos.Columns["Perfiles"] != null && e.ColumnIndex == this.dgvUsuariosActivos.Columns["Perfiles"].Index)
            {
                if (vUsuario != null && vUsuario.UsuarioPerfil != null && vUsuario.UsuarioPerfil.Count > 0)
                {
                    var vListaPerfiles = new StringBuilder();

                    foreach (var vPerfil in vUsuario.UsuarioPerfil)
                    {
                        if (vListaPerfiles.Length == 0)
                            vListaPerfiles.AppendFormat("{0}", vPerfil.Perfil.Descripcion);
                        else
                            vListaPerfiles.AppendFormat(",{0}", vPerfil.Perfil.Descripcion);
                    }

                    e.Value = vListaPerfiles.ToString();
                    e.FormattingApplied = true;
                }

            }

        }
        private void dgvUsuariosInactivos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var vUsuario = this.dgvUsuariosInactivos.Rows[e.RowIndex].DataBoundItem as Usuario;

            if (this.dgvUsuariosInactivos.Columns["Perfiles"] != null && e.ColumnIndex == this.dgvUsuariosInactivos.Columns["Perfiles"].Index)
            {
                if (vUsuario != null && vUsuario.UsuarioPerfil != null && vUsuario.UsuarioPerfil.Count > 0)
                {
                    var vListaPerfiles = new StringBuilder();

                    foreach (var vPerfil in vUsuario.UsuarioPerfil)
                    {
                        if (vListaPerfiles.Length == 0)
                            vListaPerfiles.AppendFormat("{0}", vPerfil.Perfil.Descripcion);
                        else
                            vListaPerfiles.AppendFormat(",{0}", vPerfil.Perfil.Descripcion);
                    }

                    e.Value = vListaPerfiles.ToString();
                    e.FormattingApplied = true;
                }

            }
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

            if (e.ColumnIndex == dgvPedidos.Columns["DetallePedido"].Index)
            {
                if (vPedido != null && vPedido.DetallePedido != null)
                {
                   
                    var vSum = 0D;

                    foreach (var vDetalle in vPedido.DetallePedido)
                    {
                        if (vDetalle != null && vDetalle.Producto != null)
                        {
                            var vValor = Convert.ToDecimal(vDetalle.Producto.Precio * vDetalle.Cantidad);
                            vSum += Convert.ToDouble((vValor + (vValor * (vDetalle.Producto.IVA) / 100)));
                        }
                    }

                    e.Value = vSum.ToString("N2");
                    e.FormattingApplied = true;
                }
            }
        }
        #endregion
    }
}

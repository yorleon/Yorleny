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
    public partial class FrmRastrear : Form
    {
        #region Variables
        private List<Trazabilidad> vListaTrazabilidad;
        #endregion

        #region Constructor
        public FrmRastrear()
        {
            InitializeComponent();
        }
        public FrmRastrear(List<Trazabilidad> pTrazabilidad)
        {
            InitializeComponent();
            var TT = new ToolTip();
            TT.SetToolTip(this.pbPreAdmision, "Pedido Recibido");
            vListaTrazabilidad = pTrazabilidad;
            this.MostrarLineaTrazabilidad();
            this.MostrarDetalleTrazabilidad();            
        }
        #endregion

        #region Metodos
        private void MostrarLineaTrazabilidad()
        {

            var vIconos = new List<PictureBox> { pbPreparando, pbEnCamino, pbEntregado, pbCompletado, pbCancelado };

            foreach (var vIcono in vIconos)
            {
                vIcono.Visible = false;
            }

            var vLocationX = 100;
            int vIndex = 0;

            foreach (var vEstado in this.vListaTrazabilidad.OrderBy(p => p.EstadoID).ToList())
            {
                if (vEstado.EstadoID != (int)Constantes.Estados.PreAdminision)
                {
                    var vIcono = vIconos.FirstOrDefault(p => p.Tag.ToString() == vEstado.EstadoID.Value.ToString());
                    vIcono.Location = new Point() { X = vLocationX, Y = 15 };
                    vIcono.Visible = true;
                    var vToolTip = new ToolTip();
                    vToolTip.SetToolTip(vIcono, vEstado.Estado.Descripcion);

                    vLocationX += 88;
                    vIndex++;
                }
            }

        }
        private void MostrarDetalleTrazabilidad()
        {
            this.dgvTrazabilidad.AutoGenerateColumns = false;
            this.dgvTrazabilidad.DataSource = this.vListaTrazabilidad;
            this.dgvTrazabilidad.AutoGenerateColumns = true;

            this.dgvTrazabilidad.Columns["Pedido"].Visible = false;
            this.dgvTrazabilidad.Columns["PedidoID"].Visible = false;
            this.dgvTrazabilidad.Columns["EstadoID"].Visible = false;
            this.dgvTrazabilidad.Columns["TrazabilidadID"].HeaderText = "ID";

            this.dgvTrazabilidad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTrazabilidad.AutoResizeColumns();
            this.dgvTrazabilidad.Refresh();
        }
        #endregion

        #region Eventos
        private void dgvTrazabilidad_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                var vEstado = this.dgvTrazabilidad.Rows[e.RowIndex].DataBoundItem as Trazabilidad;

                if (dgvTrazabilidad.Columns["TrazabilidadID"] != null && e.ColumnIndex == dgvTrazabilidad.Columns["TrazabilidadID"].Index)
                {
                    if (vEstado != null)
                    {
                        e.Value = string.Format("{0}", e.RowIndex + 1);
                        e.FormattingApplied = true;
                    }
                }

                if (dgvTrazabilidad.Columns["Estado"] != null && e.ColumnIndex == dgvTrazabilidad.Columns["Estado"].Index)
                {
                    if (vEstado != null && vEstado.Estado != null)
                    {
                        e.Value = string.Format("{0}", vEstado.Estado.Descripcion);
                        e.FormattingApplied = true;
                    }
                }

                if (dgvTrazabilidad.Columns["Fecha"] != null && e.ColumnIndex == dgvTrazabilidad.Columns["Fecha"].Index)
                {
                    if (vEstado != null)
                    {
                        e.Value = string.Format("{0}", vEstado.Fecha.Value.ToString("dd/MM/yyyy h:mm:ss tt"));
                        e.FormattingApplied = true;
                    }
                }

            }
            catch (Exception ex) { throw ex; }

        }
        private void dgvTrazabilidad_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvTrazabilidad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTrazabilidad.AutoResizeColumns();
        }
        #endregion
    }
}

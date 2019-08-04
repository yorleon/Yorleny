using BL;
using EL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace sicoju.Modulos
{
    public partial class FrmTrazabilidad : Form
    {

        #region Variables
        private List<vPedidosRegion> vListaPedidos;
        private List<Estado> vEstados;
        private Boolean vEjecutando = false;
        CancellationTokenSource cts;
        #endregion

        public FrmTrazabilidad()
        {
            InitializeComponent();
            AsignarEventos();
            Label.CheckForIllegalCrossThreadCalls = false;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            BackGroundTimer();
        }

        #region Metodos
        private void BackGroundTimer()
        {
            var tPedidos = new System.Timers.Timer(500);
            tPedidos.AutoReset = true;
            tPedidos.Elapsed += new ElapsedEventHandler(GetPedidosEvent);
            tPedidos.Start();

            var tEstados = new System.Timers.Timer(1000);
            tEstados.AutoReset = true;
            tEstados.Elapsed += new ElapsedEventHandler(SimulateEvent);
            tEstados.Start();
        }
        private async void GetPedidosEvent(Object source, ElapsedEventArgs e)
        {
            try
            {
                await Task.Run<int>(() =>
                {
                    ObtenerPedidos();

                    try
                    {
                        lblContadorAlajuela.Text = vListaPedidos.FirstOrDefault(x => x.RegionID == 1).TotalPedidos.ToString();
                        lblContadorCartago.Text = vListaPedidos.FirstOrDefault(x => x.RegionID == 2).TotalPedidos.ToString();
                        lblContadorGuanacaste.Text = vListaPedidos.FirstOrDefault(x => x.RegionID == 3).TotalPedidos.ToString();
                        lblContadorHeredia.Text = vListaPedidos.FirstOrDefault(x => x.RegionID == 4).TotalPedidos.ToString();
                        lblContadorLimon.Text = vListaPedidos.FirstOrDefault(x => x.RegionID == 5).TotalPedidos.ToString();
                        lblContadorPuntarenas.Text = vListaPedidos.FirstOrDefault(x => x.RegionID == 6).TotalPedidos.ToString();
                        lblContadorSanJose.Text = vListaPedidos.FirstOrDefault(x => x.RegionID == 7).TotalPedidos.ToString();

                        lblUltimaActualizacion.Text = string.Format("Ultima actualización: {0}", DateTime.Now.ToString("h:mm:ss tt"));

                        return 0;
                    }
                    catch (Exception ex) { return 0; }
                });
            }
            catch (Exception ex) { throw ex; }
        }
        private async void SimulateEvent(Object source, ElapsedEventArgs e)
        {
            try
            {

                if (!vEjecutando)
                {
                    await Task.Run<int>(() =>
                     {
                         try
                         {

                             if (chkSimularEntregas.Checked)
                             {
                                 this.vEjecutando = true;
                                 if (vEstados == null || vEstados.Count == 0)
                                     vEstados = PedidoBL.GetEstados();

                                 var vPedidos = new List<Pedido>();
                                 vPedidos = PedidoBL.GetPedidosFiltro(new Pedido());

                                 foreach (var vPedido in vPedidos)
                                 {
                                     var vEstado = vPedido.Trazabilidad.LastOrDefault();
                                     var vSiguienteEstado = vEstados.FirstOrDefault(est => est.EstadoID == vEstado.Estado.Siguiente);

                                     if (vSiguienteEstado != null)
                                     {

                                         var vRandom = new Random();
                                         DateTime start = DateTime.Now;

                                         var vTrazabilidad = new Trazabilidad()
                                                 {
                                                     EstadoID = vSiguienteEstado.EstadoID,
                                                     PedidoID = vPedido.PedidoID,
                                                     Fecha = vEstado.Fecha.Value.AddHours(vRandom.Next(50))
                                                 };

                                         PedidoBL.InsertarEstado(vTrazabilidad);
                                     }
                                 }

                                 vEjecutando = false;
                             }
                             else
                             {
                                 vEjecutando = false;
                             }

                             return 0;
                         }
                         catch (Exception ex) { return 0; }
                     });

                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void ObtenerPedidos()
        {
            vListaPedidos = VistaBL.GetPedidosRegion();
        }
        private void AbrirRegion(object sender, EventArgs e)
        {
            try
            {
                PictureBox item = (PictureBox)sender;
                var vRegionID = Convert.ToInt32(item.Tag.ToString());
                var vForm = new FrmPedidosRegion(vRegionID);
                vForm.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void AsignarEventos()
        {
            try
            {
                pbGuanacaste.Click += new EventHandler(this.AbrirRegion);
                pbAlajuela.Click += new EventHandler(this.AbrirRegion);
                pbCartago.Click += new EventHandler(this.AbrirRegion);
                pbLimon.Click += new EventHandler(this.AbrirRegion);
                pbHeredia.Click += new EventHandler(this.AbrirRegion);
                pbSanJose.Click += new EventHandler(this.AbrirRegion);
                pbPuntarenas.Click += new EventHandler(this.AbrirRegion);
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Eventos
        private void FrmTrazabilidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }

            this.BeginInvoke(new MethodInvoker(Close));
        }
        #endregion

    }
}

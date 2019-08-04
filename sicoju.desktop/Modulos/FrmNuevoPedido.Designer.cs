namespace sicoju.Modulos
{
    partial class FrmNuevoPedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevoPedido));
            this.gbMantenimiento = new System.Windows.Forms.GroupBox();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.dtFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.pbAgregar = new System.Windows.Forms.PictureBox();
            this.txtCantidadProducto = new System.Windows.Forms.NumericUpDown();
            this.cbPedidoProducto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDetallePedido = new System.Windows.Forms.DataGridView();
            this.cbPedidoCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPedidoRegion = new System.Windows.Forms.ComboBox();
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPedidoID = new System.Windows.Forms.TextBox();
            this.txtPedidoDireccion = new System.Windows.Forms.TextBox();
            this.gbMantenimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMantenimiento
            // 
            this.gbMantenimiento.Controls.Add(this.lblDisponible);
            this.gbMantenimiento.Controls.Add(this.dtFechaEntrega);
            this.gbMantenimiento.Controls.Add(this.label3);
            this.gbMantenimiento.Controls.Add(this.pbAgregar);
            this.gbMantenimiento.Controls.Add(this.txtCantidadProducto);
            this.gbMantenimiento.Controls.Add(this.cbPedidoProducto);
            this.gbMantenimiento.Controls.Add(this.label2);
            this.gbMantenimiento.Controls.Add(this.dgvDetallePedido);
            this.gbMantenimiento.Controls.Add(this.cbPedidoCliente);
            this.gbMantenimiento.Controls.Add(this.label1);
            this.gbMantenimiento.Controls.Add(this.cbPedidoRegion);
            this.gbMantenimiento.Controls.Add(this.pbSave);
            this.gbMantenimiento.Controls.Add(this.label8);
            this.gbMantenimiento.Controls.Add(this.label7);
            this.gbMantenimiento.Controls.Add(this.label6);
            this.gbMantenimiento.Controls.Add(this.txtPedidoID);
            this.gbMantenimiento.Controls.Add(this.txtPedidoDireccion);
            this.gbMantenimiento.Location = new System.Drawing.Point(12, 12);
            this.gbMantenimiento.Name = "gbMantenimiento";
            this.gbMantenimiento.Size = new System.Drawing.Size(824, 432);
            this.gbMantenimiento.TabIndex = 7;
            this.gbMantenimiento.TabStop = false;
            this.gbMantenimiento.Text = "Pedido";
            // 
            // lblDisponible
            // 
            this.lblDisponible.AutoSize = true;
            this.lblDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponible.Location = new System.Drawing.Point(578, 102);
            this.lblDisponible.Name = "lblDisponible";
            this.lblDisponible.Size = new System.Drawing.Size(0, 13);
            this.lblDisponible.TabIndex = 34;
            // 
            // dtFechaEntrega
            // 
            this.dtFechaEntrega.Location = new System.Drawing.Point(66, 73);
            this.dtFechaEntrega.Name = "dtFechaEntrega";
            this.dtFechaEntrega.Size = new System.Drawing.Size(200, 20);
            this.dtFechaEntrega.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Entrega:";
            // 
            // pbAgregar
            // 
            this.pbAgregar.Image = ((System.Drawing.Image)(resources.GetObject("pbAgregar.Image")));
            this.pbAgregar.Location = new System.Drawing.Point(796, 102);
            this.pbAgregar.Name = "pbAgregar";
            this.pbAgregar.Size = new System.Drawing.Size(22, 22);
            this.pbAgregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAgregar.TabIndex = 31;
            this.pbAgregar.TabStop = false;
            this.pbAgregar.Click += new System.EventHandler(this.pbAgregar_Click);
            // 
            // txtCantidadProducto
            // 
            this.txtCantidadProducto.Location = new System.Drawing.Point(451, 99);
            this.txtCantidadProducto.Name = "txtCantidadProducto";
            this.txtCantidadProducto.Size = new System.Drawing.Size(120, 20);
            this.txtCantidadProducto.TabIndex = 30;
            this.txtCantidadProducto.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCantidadProducto.ValueChanged += new System.EventHandler(this.txtCantidadProducto_ValueChanged);
            // 
            // cbPedidoProducto
            // 
            this.cbPedidoProducto.FormattingEnabled = true;
            this.cbPedidoProducto.Location = new System.Drawing.Point(66, 99);
            this.cbPedidoProducto.Name = "cbPedidoProducto";
            this.cbPedidoProducto.Size = new System.Drawing.Size(379, 21);
            this.cbPedidoProducto.TabIndex = 29;
            this.cbPedidoProducto.SelectedIndexChanged += new System.EventHandler(this.cbPedidoProducto_SelectedIndexChanged);
            this.cbPedidoProducto.TextUpdate += new System.EventHandler(this.cbPedidoProducto_TextUpdate);
            this.cbPedidoProducto.SelectedValueChanged += new System.EventHandler(this.cbPedidoProducto_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Producto:";
            // 
            // dgvDetallePedido
            // 
            this.dgvDetallePedido.AllowUserToAddRows = false;
            this.dgvDetallePedido.AllowUserToDeleteRows = false;
            this.dgvDetallePedido.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetallePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallePedido.Location = new System.Drawing.Point(8, 128);
            this.dgvDetallePedido.Name = "dgvDetallePedido";
            this.dgvDetallePedido.Size = new System.Drawing.Size(810, 260);
            this.dgvDetallePedido.TabIndex = 27;
            this.dgvDetallePedido.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetallePedido_CellClick);
            this.dgvDetallePedido.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetallePedido_CellFormatting);
            // 
            // cbPedidoCliente
            // 
            this.cbPedidoCliente.FormattingEnabled = true;
            this.cbPedidoCliente.Location = new System.Drawing.Point(439, 21);
            this.cbPedidoCliente.Name = "cbPedidoCliente";
            this.cbPedidoCliente.Size = new System.Drawing.Size(379, 21);
            this.cbPedidoCliente.TabIndex = 26;
            this.cbPedidoCliente.TextUpdate += new System.EventHandler(this.cbPedidoCliente_TextUpdate);
            this.cbPedidoCliente.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbPedidoCliente_Format);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(389, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Involucrado:";
            // 
            // cbPedidoRegion
            // 
            this.cbPedidoRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPedidoRegion.FormattingEnabled = true;
            this.cbPedidoRegion.Location = new System.Drawing.Point(243, 21);
            this.cbPedidoRegion.Name = "cbPedidoRegion";
            this.cbPedidoRegion.Size = new System.Drawing.Size(121, 21);
            this.cbPedidoRegion.TabIndex = 24;
            // 
            // pbSave
            // 
            this.pbSave.Image = ((System.Drawing.Image)(resources.GetObject("pbSave.Image")));
            this.pbSave.Location = new System.Drawing.Point(782, 394);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(36, 32);
            this.pbSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSave.TabIndex = 23;
            this.pbSave.TabStop = false;
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Dirección:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(193, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Región:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "ID:";
            // 
            // txtPedidoID
            // 
            this.txtPedidoID.Location = new System.Drawing.Point(66, 21);
            this.txtPedidoID.Name = "txtPedidoID";
            this.txtPedidoID.ReadOnly = true;
            this.txtPedidoID.Size = new System.Drawing.Size(121, 20);
            this.txtPedidoID.TabIndex = 11;
            // 
            // txtPedidoDireccion
            // 
            this.txtPedidoDireccion.Location = new System.Drawing.Point(66, 48);
            this.txtPedidoDireccion.Name = "txtPedidoDireccion";
            this.txtPedidoDireccion.Size = new System.Drawing.Size(752, 20);
            this.txtPedidoDireccion.TabIndex = 7;
            // 
            // FrmNuevoPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 456);
            this.Controls.Add(this.gbMantenimiento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNuevoPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo Pedido";
            this.Load += new System.EventHandler(this.FrmNuevoPedido_Load);
            this.gbMantenimiento.ResumeLayout(false);
            this.gbMantenimiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMantenimiento;
        private System.Windows.Forms.ComboBox cbPedidoRegion;
        private System.Windows.Forms.PictureBox pbSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPedidoID;
        private System.Windows.Forms.TextBox txtPedidoDireccion;
        private System.Windows.Forms.PictureBox pbAgregar;
        private System.Windows.Forms.NumericUpDown txtCantidadProducto;
        private System.Windows.Forms.ComboBox cbPedidoProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDetallePedido;
        private System.Windows.Forms.ComboBox cbPedidoCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFechaEntrega;
        private System.Windows.Forms.Label lblDisponible;
    }
}
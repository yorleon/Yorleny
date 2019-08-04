namespace sicoju.Modulos
{
    partial class FrmRastrear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRastrear));
            this.pbPreAdmision = new System.Windows.Forms.PictureBox();
            this.pbPreparando = new System.Windows.Forms.PictureBox();
            this.pbEnCamino = new System.Windows.Forms.PictureBox();
            this.pbEntregado = new System.Windows.Forms.PictureBox();
            this.pbCompletado = new System.Windows.Forms.PictureBox();
            this.pbCancelado = new System.Windows.Forms.PictureBox();
            this.dgvTrazabilidad = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreAdmision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreparando)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnCamino)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEntregado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompletado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancelado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrazabilidad)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPreAdmision
            // 
            this.pbPreAdmision.Image = ((System.Drawing.Image)(resources.GetObject("pbPreAdmision.Image")));
            this.pbPreAdmision.Location = new System.Drawing.Point(12, 15);
            this.pbPreAdmision.Name = "pbPreAdmision";
            this.pbPreAdmision.Size = new System.Drawing.Size(65, 60);
            this.pbPreAdmision.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreAdmision.TabIndex = 0;
            this.pbPreAdmision.TabStop = false;
            this.pbPreAdmision.Tag = "2";
            // 
            // pbPreparando
            // 
            this.pbPreparando.Image = ((System.Drawing.Image)(resources.GetObject("pbPreparando.Image")));
            this.pbPreparando.Location = new System.Drawing.Point(100, 15);
            this.pbPreparando.Name = "pbPreparando";
            this.pbPreparando.Size = new System.Drawing.Size(65, 60);
            this.pbPreparando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreparando.TabIndex = 1;
            this.pbPreparando.TabStop = false;
            this.pbPreparando.Tag = "3";
            // 
            // pbEnCamino
            // 
            this.pbEnCamino.Image = ((System.Drawing.Image)(resources.GetObject("pbEnCamino.Image")));
            this.pbEnCamino.Location = new System.Drawing.Point(188, 15);
            this.pbEnCamino.Name = "pbEnCamino";
            this.pbEnCamino.Size = new System.Drawing.Size(65, 60);
            this.pbEnCamino.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEnCamino.TabIndex = 2;
            this.pbEnCamino.TabStop = false;
            this.pbEnCamino.Tag = "4";
            // 
            // pbEntregado
            // 
            this.pbEntregado.Image = ((System.Drawing.Image)(resources.GetObject("pbEntregado.Image")));
            this.pbEntregado.Location = new System.Drawing.Point(276, 15);
            this.pbEntregado.Name = "pbEntregado";
            this.pbEntregado.Size = new System.Drawing.Size(65, 60);
            this.pbEntregado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEntregado.TabIndex = 3;
            this.pbEntregado.TabStop = false;
            this.pbEntregado.Tag = "5";
            // 
            // pbCompletado
            // 
            this.pbCompletado.Image = ((System.Drawing.Image)(resources.GetObject("pbCompletado.Image")));
            this.pbCompletado.Location = new System.Drawing.Point(364, 15);
            this.pbCompletado.Name = "pbCompletado";
            this.pbCompletado.Size = new System.Drawing.Size(65, 60);
            this.pbCompletado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCompletado.TabIndex = 4;
            this.pbCompletado.TabStop = false;
            this.pbCompletado.Tag = "6";
            // 
            // pbCancelado
            // 
            this.pbCancelado.Image = ((System.Drawing.Image)(resources.GetObject("pbCancelado.Image")));
            this.pbCancelado.Location = new System.Drawing.Point(452, 15);
            this.pbCancelado.Name = "pbCancelado";
            this.pbCancelado.Size = new System.Drawing.Size(65, 60);
            this.pbCancelado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCancelado.TabIndex = 5;
            this.pbCancelado.TabStop = false;
            this.pbCancelado.Tag = "7";
            this.pbCancelado.Visible = false;
            // 
            // dgvTrazabilidad
            // 
            this.dgvTrazabilidad.AllowUserToAddRows = false;
            this.dgvTrazabilidad.AllowUserToDeleteRows = false;
            this.dgvTrazabilidad.AllowUserToOrderColumns = true;
            this.dgvTrazabilidad.BackgroundColor = System.Drawing.Color.White;
            this.dgvTrazabilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrazabilidad.Location = new System.Drawing.Point(12, 103);
            this.dgvTrazabilidad.MultiSelect = false;
            this.dgvTrazabilidad.Name = "dgvTrazabilidad";
            this.dgvTrazabilidad.ReadOnly = true;
            this.dgvTrazabilidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrazabilidad.Size = new System.Drawing.Size(505, 181);
            this.dgvTrazabilidad.TabIndex = 27;
            this.dgvTrazabilidad.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTrazabilidad_CellFormatting);
            this.dgvTrazabilidad.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTrazabilidad_DataBindingComplete);
            // 
            // FrmRastrear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 304);
            this.Controls.Add(this.dgvTrazabilidad);
            this.Controls.Add(this.pbCancelado);
            this.Controls.Add(this.pbCompletado);
            this.Controls.Add(this.pbEntregado);
            this.Controls.Add(this.pbEnCamino);
            this.Controls.Add(this.pbPreparando);
            this.Controls.Add(this.pbPreAdmision);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRastrear";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rastrear Pedido";
            ((System.ComponentModel.ISupportInitialize)(this.pbPreAdmision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreparando)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnCamino)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEntregado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompletado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancelado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrazabilidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPreAdmision;
        private System.Windows.Forms.PictureBox pbPreparando;
        private System.Windows.Forms.PictureBox pbEnCamino;
        private System.Windows.Forms.PictureBox pbEntregado;
        private System.Windows.Forms.PictureBox pbCompletado;
        private System.Windows.Forms.PictureBox pbCancelado;
        private System.Windows.Forms.DataGridView dgvTrazabilidad;
    }
}
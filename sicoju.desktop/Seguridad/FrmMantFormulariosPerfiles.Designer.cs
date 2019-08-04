namespace sicoju.Seguridad
{
    partial class FrmMantFormulariosPerfiles
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
            this.cmbFormularios = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvFormulariosPerfil = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormulariosPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbFormularios
            // 
            this.cmbFormularios.FormattingEnabled = true;
            this.cmbFormularios.Location = new System.Drawing.Point(82, 12);
            this.cmbFormularios.Name = "cmbFormularios";
            this.cmbFormularios.Size = new System.Drawing.Size(256, 21);
            this.cmbFormularios.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Formularios:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(344, 10);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvFormulariosPerfil
            // 
            this.dgvFormulariosPerfil.BackgroundColor = System.Drawing.Color.White;
            this.dgvFormulariosPerfil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormulariosPerfil.Location = new System.Drawing.Point(16, 39);
            this.dgvFormulariosPerfil.Name = "dgvFormulariosPerfil";
            this.dgvFormulariosPerfil.Size = new System.Drawing.Size(403, 229);
            this.dgvFormulariosPerfil.TabIndex = 3;
            this.dgvFormulariosPerfil.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulariosPerfil_CellClick);
            // 
            // FrmMantFormulariosPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 283);
            this.Controls.Add(this.dgvFormulariosPerfil);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFormularios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMantFormulariosPerfiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Formularios por Perfil";
            this.Load += new System.EventHandler(this.FrmMantFormulariosPerfiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormulariosPerfil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFormularios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvFormulariosPerfil;
    }
}
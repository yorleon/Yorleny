namespace sicoju.Seguridad
{
    partial class FrmMantFormularios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMantFormularios));
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.gbMantenimiento = new System.Windows.Forms.GroupBox();
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.chkFormularioActivo = new System.Windows.Forms.CheckBox();
            this.txtFormularioDescripcion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFormularioID = new System.Windows.Forms.TextBox();
            this.txtFormularioRuta = new System.Windows.Forms.TextBox();
            this.dgvFormularios = new System.Windows.Forms.DataGridView();
            this.gbInfo.SuspendLayout();
            this.gbMantenimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormularios)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Controls.Add(this.txtID);
            this.gbInfo.Controls.Add(this.chkActivo);
            this.gbInfo.Controls.Add(this.btnConsultar);
            this.gbInfo.Controls.Add(this.txtDescripcion);
            this.gbInfo.Location = new System.Drawing.Point(12, 12);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(785, 65);
            this.gbInfo.TabIndex = 3;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Filtros";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(6, 36);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(90, 20);
            this.txtID.TabIndex = 6;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Location = new System.Drawing.Point(339, 37);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 5;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(704, 34);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(105, 37);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(219, 20);
            this.txtDescripcion.TabIndex = 0;
            // 
            // gbMantenimiento
            // 
            this.gbMantenimiento.Controls.Add(this.pbSave);
            this.gbMantenimiento.Controls.Add(this.chkFormularioActivo);
            this.gbMantenimiento.Controls.Add(this.txtFormularioDescripcion);
            this.gbMantenimiento.Controls.Add(this.label9);
            this.gbMantenimiento.Controls.Add(this.label7);
            this.gbMantenimiento.Controls.Add(this.label6);
            this.gbMantenimiento.Controls.Add(this.txtFormularioID);
            this.gbMantenimiento.Controls.Add(this.txtFormularioRuta);
            this.gbMantenimiento.Location = new System.Drawing.Point(12, 83);
            this.gbMantenimiento.Name = "gbMantenimiento";
            this.gbMantenimiento.Size = new System.Drawing.Size(785, 77);
            this.gbMantenimiento.TabIndex = 6;
            this.gbMantenimiento.TabStop = false;
            this.gbMantenimiento.Text = "Formulario";
            // 
            // pbSave
            // 
            this.pbSave.Image = ((System.Drawing.Image)(resources.GetObject("pbSave.Image")));
            this.pbSave.Location = new System.Drawing.Point(743, 35);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(36, 32);
            this.pbSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSave.TabIndex = 22;
            this.pbSave.TabStop = false;
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // chkFormularioActivo
            // 
            this.chkFormularioActivo.AutoSize = true;
            this.chkFormularioActivo.Checked = true;
            this.chkFormularioActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFormularioActivo.Location = new System.Drawing.Point(683, 23);
            this.chkFormularioActivo.Name = "chkFormularioActivo";
            this.chkFormularioActivo.Size = new System.Drawing.Size(56, 17);
            this.chkFormularioActivo.TabIndex = 19;
            this.chkFormularioActivo.Text = "Activo";
            this.chkFormularioActivo.UseVisualStyleBackColor = true;
            // 
            // txtFormularioDescripcion
            // 
            this.txtFormularioDescripcion.Location = new System.Drawing.Point(75, 47);
            this.txtFormularioDescripcion.Name = "txtFormularioDescripcion";
            this.txtFormularioDescripcion.Size = new System.Drawing.Size(602, 20);
            this.txtFormularioDescripcion.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Descripción:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Ruta:";
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
            // txtFormularioID
            // 
            this.txtFormularioID.Location = new System.Drawing.Point(75, 21);
            this.txtFormularioID.Name = "txtFormularioID";
            this.txtFormularioID.ReadOnly = true;
            this.txtFormularioID.Size = new System.Drawing.Size(93, 20);
            this.txtFormularioID.TabIndex = 11;
            // 
            // txtFormularioRuta
            // 
            this.txtFormularioRuta.Location = new System.Drawing.Point(222, 21);
            this.txtFormularioRuta.Name = "txtFormularioRuta";
            this.txtFormularioRuta.Size = new System.Drawing.Size(455, 20);
            this.txtFormularioRuta.TabIndex = 10;
            // 
            // dgvFormularios
            // 
            this.dgvFormularios.AllowUserToAddRows = false;
            this.dgvFormularios.AllowUserToDeleteRows = false;
            this.dgvFormularios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvFormularios.BackgroundColor = System.Drawing.Color.White;
            this.dgvFormularios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormularios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvFormularios.Location = new System.Drawing.Point(12, 166);
            this.dgvFormularios.MultiSelect = false;
            this.dgvFormularios.Name = "dgvFormularios";
            this.dgvFormularios.ReadOnly = true;
            this.dgvFormularios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFormularios.Size = new System.Drawing.Size(785, 261);
            this.dgvFormularios.TabIndex = 7;
            this.dgvFormularios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormularios_CellClick);
            // 
            // FrmMantFormularios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 443);
            this.Controls.Add(this.dgvFormularios);
            this.Controls.Add(this.gbMantenimiento);
            this.Controls.Add(this.gbInfo);
            this.Name = "FrmMantFormularios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Formularios";
            this.Load += new System.EventHandler(this.FrmMantFormularios_Load);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.gbMantenimiento.ResumeLayout(false);
            this.gbMantenimiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormularios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.GroupBox gbMantenimiento;
        private System.Windows.Forms.PictureBox pbSave;
        private System.Windows.Forms.CheckBox chkFormularioActivo;
        private System.Windows.Forms.TextBox txtFormularioDescripcion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFormularioID;
        private System.Windows.Forms.TextBox txtFormularioRuta;
        private System.Windows.Forms.DataGridView dgvFormularios;

    }
}
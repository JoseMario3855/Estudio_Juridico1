namespace Vista
{
    partial class frmAgregarPropietarioscs
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
            this.lblCausaActo = new System.Windows.Forms.Label();
            this.cmbCausaActo = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblNotaria = new System.Windows.Forms.Label();
            this.TxtNotaria = new System.Windows.Forms.TextBox();
            this.lblFechaEscritura = new System.Windows.Forms.Label();
            this.dtpFechaEscritura = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDeRegistro = new System.Windows.Forms.Label();
            this.dtpFechaRegistro = new System.Windows.Forms.DateTimePicker();
            this.lblArea = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.lbllVendedorAnterior = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblPropietarios = new System.Windows.Forms.Label();
            this.txtPropietarios = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCausaActo
            // 
            this.lblCausaActo.AutoSize = true;
            this.lblCausaActo.Location = new System.Drawing.Point(30, 29);
            this.lblCausaActo.Name = "lblCausaActo";
            this.lblCausaActo.Size = new System.Drawing.Size(65, 13);
            this.lblCausaActo.TabIndex = 0;
            this.lblCausaActo.Text = "Causa Acto:";
            // 
            // cmbCausaActo
            // 
            this.cmbCausaActo.FormattingEnabled = true;
            this.cmbCausaActo.Location = new System.Drawing.Point(131, 21);
            this.cmbCausaActo.Name = "cmbCausaActo";
            this.cmbCausaActo.Size = new System.Drawing.Size(121, 21);
            this.cmbCausaActo.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(30, 118);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(36, 13);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Titulo:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(131, 111);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(121, 20);
            this.txtTitulo.TabIndex = 3;
            // 
            // lblNotaria
            // 
            this.lblNotaria.AutoSize = true;
            this.lblNotaria.Location = new System.Drawing.Point(30, 156);
            this.lblNotaria.Name = "lblNotaria";
            this.lblNotaria.Size = new System.Drawing.Size(44, 13);
            this.lblNotaria.TabIndex = 4;
            this.lblNotaria.Text = "Notaria:";
            // 
            // TxtNotaria
            // 
            this.TxtNotaria.Location = new System.Drawing.Point(131, 149);
            this.TxtNotaria.Name = "TxtNotaria";
            this.TxtNotaria.Size = new System.Drawing.Size(121, 20);
            this.TxtNotaria.TabIndex = 5;
            // 
            // lblFechaEscritura
            // 
            this.lblFechaEscritura.AutoSize = true;
            this.lblFechaEscritura.Location = new System.Drawing.Point(30, 193);
            this.lblFechaEscritura.Name = "lblFechaEscritura";
            this.lblFechaEscritura.Size = new System.Drawing.Size(84, 13);
            this.lblFechaEscritura.TabIndex = 6;
            this.lblFechaEscritura.Text = "Fecha Escritura:";
            // 
            // dtpFechaEscritura
            // 
            this.dtpFechaEscritura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEscritura.Location = new System.Drawing.Point(131, 186);
            this.dtpFechaEscritura.Name = "dtpFechaEscritura";
            this.dtpFechaEscritura.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaEscritura.TabIndex = 7;
            // 
            // lblFechaDeRegistro
            // 
            this.lblFechaDeRegistro.AutoSize = true;
            this.lblFechaDeRegistro.Location = new System.Drawing.Point(30, 233);
            this.lblFechaDeRegistro.Name = "lblFechaDeRegistro";
            this.lblFechaDeRegistro.Size = new System.Drawing.Size(95, 13);
            this.lblFechaDeRegistro.TabIndex = 8;
            this.lblFechaDeRegistro.Text = "Fecha de registro: ";
            // 
            // dtpFechaRegistro
            // 
            this.dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRegistro.Location = new System.Drawing.Point(131, 226);
            this.dtpFechaRegistro.Name = "dtpFechaRegistro";
            this.dtpFechaRegistro.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaRegistro.TabIndex = 9;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(30, 277);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(32, 13);
            this.lblArea.TabIndex = 10;
            this.lblArea.Text = "Area:";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(131, 270);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(95, 20);
            this.txtArea.TabIndex = 11;
            // 
            // txtVendedor
            // 
            this.txtVendedor.Location = new System.Drawing.Point(131, 306);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(311, 20);
            this.txtVendedor.TabIndex = 12;
            // 
            // lbllVendedorAnterior
            // 
            this.lbllVendedorAnterior.AutoSize = true;
            this.lbllVendedorAnterior.Location = new System.Drawing.Point(30, 313);
            this.lbllVendedorAnterior.Name = "lbllVendedorAnterior";
            this.lbllVendedorAnterior.Size = new System.Drawing.Size(95, 13);
            this.lbllVendedorAnterior.TabIndex = 13;
            this.lbllVendedorAnterior.Text = "Vendedor Anterior:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(238, 346);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(331, 346);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblPropietarios
            // 
            this.lblPropietarios.AutoSize = true;
            this.lblPropietarios.Location = new System.Drawing.Point(33, 68);
            this.lblPropietarios.Name = "lblPropietarios";
            this.lblPropietarios.Size = new System.Drawing.Size(65, 13);
            this.lblPropietarios.TabIndex = 16;
            this.lblPropietarios.Text = "Propietarios:";
            // 
            // txtPropietarios
            // 
            this.txtPropietarios.Location = new System.Drawing.Point(131, 68);
            this.txtPropietarios.Name = "txtPropietarios";
            this.txtPropietarios.Size = new System.Drawing.Size(311, 20);
            this.txtPropietarios.TabIndex = 17;
            // 
            // frmAgregarPropietarioscs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 387);
            this.Controls.Add(this.txtPropietarios);
            this.Controls.Add(this.lblPropietarios);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lbllVendedorAnterior);
            this.Controls.Add(this.txtVendedor);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.dtpFechaRegistro);
            this.Controls.Add(this.lblFechaDeRegistro);
            this.Controls.Add(this.dtpFechaEscritura);
            this.Controls.Add(this.lblFechaEscritura);
            this.Controls.Add(this.TxtNotaria);
            this.Controls.Add(this.lblNotaria);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.cmbCausaActo);
            this.Controls.Add(this.lblCausaActo);
            this.Name = "frmAgregarPropietarioscs";
            this.Text = "Agregar Propietarios ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCausaActo;
        private System.Windows.Forms.ComboBox cmbCausaActo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblNotaria;
        private System.Windows.Forms.TextBox TxtNotaria;
        private System.Windows.Forms.Label lblFechaEscritura;
        private System.Windows.Forms.DateTimePicker dtpFechaEscritura;
        private System.Windows.Forms.Label lblFechaDeRegistro;
        private System.Windows.Forms.DateTimePicker dtpFechaRegistro;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.Label lbllVendedorAnterior;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblPropietarios;
        private System.Windows.Forms.TextBox txtPropietarios;
    }
}
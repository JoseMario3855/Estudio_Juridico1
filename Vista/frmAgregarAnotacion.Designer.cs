namespace Vista
{
    partial class frmAgregarAnotacion
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
            this.lblAnotacion = new System.Windows.Forms.Label();
            this.txtAnotacion = new System.Windows.Forms.TextBox();
            this.lblPropietario = new System.Windows.Forms.Label();
            this.txtPropietario = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblDerecho = new System.Windows.Forms.Label();
            this.txtDerecho = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblCausaActo = new System.Windows.Forms.Label();
            this.txtCausaActo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblAnotacion
            // 
            this.lblAnotacion.AutoSize = true;
            this.lblAnotacion.Location = new System.Drawing.Point(23, 13);
            this.lblAnotacion.Name = "lblAnotacion";
            this.lblAnotacion.Size = new System.Drawing.Size(58, 13);
            this.lblAnotacion.TabIndex = 0;
            this.lblAnotacion.Text = "Anotacion:";
            // 
            // txtAnotacion
            // 
            this.txtAnotacion.Location = new System.Drawing.Point(92, 10);
            this.txtAnotacion.Name = "txtAnotacion";
            this.txtAnotacion.Size = new System.Drawing.Size(100, 20);
            this.txtAnotacion.TabIndex = 1;
            // 
            // lblPropietario
            // 
            this.lblPropietario.AutoSize = true;
            this.lblPropietario.Location = new System.Drawing.Point(23, 44);
            this.lblPropietario.Name = "lblPropietario";
            this.lblPropietario.Size = new System.Drawing.Size(60, 13);
            this.lblPropietario.TabIndex = 2;
            this.lblPropietario.Text = "Propietario:";
            // 
            // txtPropietario
            // 
            this.txtPropietario.Enabled = false;
            this.txtPropietario.Location = new System.Drawing.Point(92, 41);
            this.txtPropietario.Multiline = true;
            this.txtPropietario.Name = "txtPropietario";
            this.txtPropietario.Size = new System.Drawing.Size(349, 20);
            this.txtPropietario.TabIndex = 3;
            // 
            // txtCedula
            // 
            this.txtCedula.Enabled = false;
            this.txtCedula.Location = new System.Drawing.Point(92, 77);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(100, 20);
            this.txtCedula.TabIndex = 4;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Location = new System.Drawing.Point(23, 84);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(43, 13);
            this.lblCedula.TabIndex = 5;
            this.lblCedula.Text = "Cedula:";
            // 
            // lblDerecho
            // 
            this.lblDerecho.AutoSize = true;
            this.lblDerecho.Location = new System.Drawing.Point(26, 119);
            this.lblDerecho.Name = "lblDerecho";
            this.lblDerecho.Size = new System.Drawing.Size(51, 13);
            this.lblDerecho.TabIndex = 6;
            this.lblDerecho.Text = "Derecho:";
            // 
            // txtDerecho
            // 
            this.txtDerecho.Enabled = false;
            this.txtDerecho.Location = new System.Drawing.Point(92, 119);
            this.txtDerecho.Name = "txtDerecho";
            this.txtDerecho.Size = new System.Drawing.Size(100, 20);
            this.txtDerecho.TabIndex = 7;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Gray;
            this.btnAgregar.Location = new System.Drawing.Point(216, 221);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 22);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Gray;
            this.btnSalir.Location = new System.Drawing.Point(319, 220);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblCausaActo
            // 
            this.lblCausaActo.AutoSize = true;
            this.lblCausaActo.Location = new System.Drawing.Point(26, 161);
            this.lblCausaActo.Name = "lblCausaActo";
            this.lblCausaActo.Size = new System.Drawing.Size(65, 13);
            this.lblCausaActo.TabIndex = 10;
            this.lblCausaActo.Text = "Causa Acto:";
            // 
            // txtCausaActo
            // 
            this.txtCausaActo.Location = new System.Drawing.Point(92, 158);
            this.txtCausaActo.Name = "txtCausaActo";
            this.txtCausaActo.Size = new System.Drawing.Size(100, 20);
            this.txtCausaActo.TabIndex = 11;
            // 
            // frmAgregarAnotacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(441, 255);
            this.Controls.Add(this.txtCausaActo);
            this.Controls.Add(this.lblCausaActo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtDerecho);
            this.Controls.Add(this.lblDerecho);
            this.Controls.Add(this.lblCedula);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.txtPropietario);
            this.Controls.Add(this.lblPropietario);
            this.Controls.Add(this.txtAnotacion);
            this.Controls.Add(this.lblAnotacion);
            this.Name = "frmAgregarAnotacion";
            this.Text = "Agregar Anotacion";
            this.Load += new System.EventHandler(this.frmAgregarAnotacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAnotacion;
        private System.Windows.Forms.TextBox txtAnotacion;
        private System.Windows.Forms.Label lblPropietario;
        private System.Windows.Forms.TextBox txtPropietario;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.Label lblDerecho;
        private System.Windows.Forms.TextBox txtDerecho;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblCausaActo;
        private System.Windows.Forms.TextBox txtCausaActo;
    }
}
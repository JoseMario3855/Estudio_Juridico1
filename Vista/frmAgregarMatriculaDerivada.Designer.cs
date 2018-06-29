namespace Vista
{
    partial class frmAgregarMatriculaDerivada
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
            this.lblMatricula = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lbPkPredio = new System.Windows.Forms.Label();
            this.txtPkPredio = new System.Windows.Forms.TextBox();
            this.lblUbicar = new System.Windows.Forms.Label();
            this.txtUbicar = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.checkEstado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Location = new System.Drawing.Point(13, 13);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(53, 13);
            this.lblMatricula.TabIndex = 0;
            this.lblMatricula.Text = "Matricula:";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(84, 10);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(112, 20);
            this.txtMatricula.TabIndex = 1;
            this.txtMatricula.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(16, 51);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Estado:";
            // 
            // lbPkPredio
            // 
            this.lbPkPredio.AutoSize = true;
            this.lbPkPredio.Location = new System.Drawing.Point(16, 83);
            this.lbPkPredio.Name = "lbPkPredio";
            this.lbPkPredio.Size = new System.Drawing.Size(59, 13);
            this.lbPkPredio.TabIndex = 6;
            this.lbPkPredio.Text = "Pk_Predio:";
            // 
            // txtPkPredio
            // 
            this.txtPkPredio.Location = new System.Drawing.Point(84, 83);
            this.txtPkPredio.Name = "txtPkPredio";
            this.txtPkPredio.Size = new System.Drawing.Size(240, 20);
            this.txtPkPredio.TabIndex = 7;
            // 
            // lblUbicar
            // 
            this.lblUbicar.AutoSize = true;
            this.lblUbicar.Location = new System.Drawing.Point(16, 119);
            this.lblUbicar.Name = "lblUbicar";
            this.lblUbicar.Size = new System.Drawing.Size(41, 13);
            this.lblUbicar.TabIndex = 8;
            this.lblUbicar.Text = "Ubicar:";
            // 
            // txtUbicar
            // 
            this.txtUbicar.Location = new System.Drawing.Point(84, 119);
            this.txtUbicar.Multiline = true;
            this.txtUbicar.Name = "txtUbicar";
            this.txtUbicar.Size = new System.Drawing.Size(337, 45);
            this.txtUbicar.TabIndex = 9;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Gray;
            this.btnGuardar.Location = new System.Drawing.Point(242, 184);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Gray;
            this.btnSalir.Location = new System.Drawing.Point(346, 184);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // checkEstado
            // 
            this.checkEstado.AutoSize = true;
            this.checkEstado.Location = new System.Drawing.Point(84, 51);
            this.checkEstado.Name = "checkEstado";
            this.checkEstado.Size = new System.Drawing.Size(59, 17);
            this.checkEstado.TabIndex = 12;
            this.checkEstado.Text = "Estado";
            this.checkEstado.UseVisualStyleBackColor = true;
            // 
            // frmAgregarMatriculaDerivada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(433, 222);
            this.Controls.Add(this.checkEstado);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtUbicar);
            this.Controls.Add(this.lblUbicar);
            this.Controls.Add(this.txtPkPredio);
            this.Controls.Add(this.lbPkPredio);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.lblMatricula);
            this.Name = "frmAgregarMatriculaDerivada";
            this.Text = "Agregar Matricula Derivada";
            this.Load += new System.EventHandler(this.frmAgregarMatriculaDerivada_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lbPkPredio;
        private System.Windows.Forms.TextBox txtPkPredio;
        private System.Windows.Forms.Label lblUbicar;
        private System.Windows.Forms.TextBox txtUbicar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.CheckBox checkEstado;
    }
}
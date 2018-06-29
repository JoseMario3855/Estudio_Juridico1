using Datos.EstudioJuridico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmAgregarMatriculaDerivada : Form
    {
        frmFichaPredial objFromFichaPredial;
        public frmAgregarMatriculaDerivada(frmFichaPredial objFromFichaPredial)
        {
            InitializeComponent();
            this.objFromFichaPredial = objFromFichaPredial;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }
        private void limpiar()
        {
            txtMatricula.Text = string.Empty;
            txtPkPredio.Text = string.Empty;
            txtUbicar.Text = string.Empty;
        }

        private void frmAgregarMatriculaDerivada_Load(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMatricula.Text))
            {
                MessageBox.Show("ingrese la matricula", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(txtPkPredio.Text))
            {
                MessageBox.Show("ingrese el Pk_Predio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if (String.IsNullOrEmpty(txtUbicar.Text))
            {
                MessageBox.Show("ingrese un dato en el campo de ubicar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                spMatriculaDerivadasconsultar_Result objMatricula = new spMatriculaDerivadasconsultar_Result();
                objMatricula.matricula = txtMatricula.Text;
                objMatricula.pk_predio = txtPkPredio.Text;
                objMatricula.estado = checkEstado.Checked;
                objMatricula.ubicar = txtUbicar.Text;
                List<spMatriculaDerivadasconsultar_Result> lst;
                if (objFromFichaPredial.dgvMatriculaDerivadas.DataSource == null)
                {
                    lst = new List<spMatriculaDerivadasconsultar_Result>();
                    lst.Add(objMatricula);
                }
                else
                {
                    lst = (List<spMatriculaDerivadasconsultar_Result>)objFromFichaPredial.dgvMatriculaDerivadas.DataSource;
                    lst.Add(objMatricula);
                }
                objFromFichaPredial.dgvMatriculaDerivadas.DataSource = null;
                objFromFichaPredial.dgvMatriculaDerivadas.DataSource = lst;
                Close();
            }
            
           


        }
       
      
    }
}

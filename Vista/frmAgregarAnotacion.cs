using Datos.Sicafi.Listas;
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
    public partial class frmAgregarAnotacion : Form
    {
        frmFichaPredial objfrmFichaPredial;
        public frmAgregarAnotacion(frmFichaPredial objfrmFichaPredial)
        {
            InitializeComponent();
            this.objfrmFichaPredial = objfrmFichaPredial;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtAnotacion.Text != string.Empty)
            {
                Consultar_Propietario_Result objConsultarPropietario = (Consultar_Propietario_Result)
                objfrmFichaPredial.dgvPropietarios.SelectedRows[0].DataBoundItem;
                objConsultarPropietario.anotacion = txtAnotacion.Text;
                objfrmFichaPredial.dgvPropietarios.SelectedRows[0].Cells["dgvPropietariosAnotacion"].Value = txtAnotacion.Text;
               // objfrmFichaPredial.dgvPropietarios.SelectedRows[0].Cells["dgvPropietariosCausaActo"].Value = txtCausaActo.Text 
                objfrmFichaPredial.dgvPropietarios.Refresh();
                Close();
            }
            else
            {
                MessageBox.Show("Ingrese un valor en el campo de anotación", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void limpiar()
        {
            txtAnotacion.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtPropietario.Text = string.Empty;
            txtDerecho.Text = string.Empty;
            txtCausaActo.Text = string.Empty;
        }

        private void frmAgregarAnotacion_Load(object sender, EventArgs e)
        {
            limpiar();
            Consultar_Propietario_Result objConsultar_Propietario_Result = (Consultar_Propietario_Result)objfrmFichaPredial.dgvPropietarios.SelectedRows[0].DataBoundItem;
            txtPropietario.Text = objConsultar_Propietario_Result.strNombreApellido;
            txtCedula.Text = objConsultar_Propietario_Result.strDocumento;
            txtDerecho.Text = objConsultar_Propietario_Result.strDerecho;
            if(objfrmFichaPredial.dgvPropietarios.SelectedRows[0].Cells["dgvPropietariosAnotacion"].Value != null)
            {
                txtAnotacion.Text = objfrmFichaPredial.dgvPropietarios.SelectedRows[0].Cells["dgvPropietariosAnotacion"].Value.ToString();
                //txtCausaActo.Text = objfrmFichaPredial.dgvPropietarios.SelectedRows[0].Cells["dgvPropietariosCausaActo"].Value.ToString();
            }
            
        }
    }
}

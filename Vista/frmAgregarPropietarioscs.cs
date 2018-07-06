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
    public partial class frmAgregarPropietarioscs : Form
    {
        frmFichaPredial objfrmFichaPredial;
        public object dgvPropietariosFolios;

        public frmAgregarPropietarioscs(frmFichaPredial objfrmFichaPredial)
        {
            InitializeComponent();
            this.objfrmFichaPredial = objfrmFichaPredial;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvPropietariosFolios != string.Empty)
            {
               
                objfrmFichaPredial.dgvPropietariosFolios.SelectedRows[0].DataBoundItem;
                objfrmFichaPredial.Propietario = txtPropietarios.Text;
                objfrmFichaPredial.dgvPropietariosFolios.SelectedRows[0].Cells["dgvPropietariosFolios"].Value = txtPropietarios.Text;
                // objfrmFichaPredial.dgvPropietarios.SelectedRows[0].Cells["dgvPropietariosCausaActo"].Value = txtCausaActo.Text 
                objfrmFichaPredial.dgvPropietariosFolios.Refresh();
                Close();
            }
            else
            {
                MessageBox.Show("Ingrese un valor en el campo de anotación", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    }
}

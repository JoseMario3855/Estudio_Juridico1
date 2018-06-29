using Datos.Sicafi.Listas;
using Negocio;
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
    public partial class frmConsultarFicha : Form
    {
        frmFichaPredial objfrmFichaPredial;
        public frmConsultarFicha(frmFichaPredial objfrmFichaPredial)
        {
            this.objfrmFichaPredial = objfrmFichaPredial;
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            objfrmFichaPredial.objConsultarPredio = null;
            this.Close();
        }

        

        private void frmConsultarFicha_Load(object sender, EventArgs e)
        {
            dtvResultados.AutoGenerateColumns = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            
            FichaPredialSicafi fichaPredialSicafi = new FichaPredialSicafi(
                @"172.16.50.2\SQLEXPRESS"
                , "SICAFI"
                , "sa"
                , "conestudiosfame"
                );
            List<Consultar_Predio_Result> lstFicha = fichaPredialSicafi.consultarFichaPredial(
                txtMunicipio.Text
                , txtSector.Text
                , txtCorregimiento.Text
                , txtBarrio.Text
                , txtManzana.Text
                , txtPredio.Text
                , txtEdificio.Text
                , txtUnidadPredial.Text
                , txtFicha.Text
                );
            if (lstFicha.Count < 1)
            {
                MessageBox.Show("El predio no esta en la base de datos ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtvResultados.DataSource = null;
            }
            else
            {
                dtvResultados.DataSource = lstFicha;
            }
            
            //this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtvResultados.SelectedRows.Count > 0)
            {
                objfrmFichaPredial.objConsultarPredio = (Consultar_Predio_Result)dtvResultados.SelectedRows[0].DataBoundItem;
                Close();
            }
            else
            {
                MessageBox.Show("Seleccione un predio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

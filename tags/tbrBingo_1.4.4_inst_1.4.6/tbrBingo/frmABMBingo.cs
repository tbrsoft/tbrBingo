using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLBingo;

namespace tbrBingo
{
    public partial class frmABMBingo : Form
    {
        public frmABMBingo()
        {
            InitializeComponent();
        }
        private SorteoManager sM=null;
        

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                foreach (Control  c in this.Controls)
                {
                    c.Enabled = false;
                }
                this.ControlBox = false;
                pBar.Enabled = true;
                pBar.Visible = true;
                pBar.Maximum = int.Parse(txtCartones.Text)+1;

                Bingo b = new Bingo();
                //b.CantidadBolillas = int.Parse(txtCantidadBolillas.Text);
                b.CantidadSorteos = int.Parse(txtCantidadSorteos.Text);
                b.EstadoBingo = eEstadoBingo.NoIniciado;
                b.Fecha = DateTime.Now;
                b.Nombre = txtNombre.Text;
                b.Observaciones = txtObservaciones.Text;
                b.Precio = decimal.Parse(txtPrecio.Text);
                b.TipoBingo =( eTipoBingo) cmbExtraccionBolillas.SelectedIndex ;
                b.CartonesBingo = new CartonBingoManager();

                //asocio el escuchador de progreso
                b.CartonesBingo.Progressing += new ProgressEventHandler(CartonesBingo_Progressing); 
                
                b.CartonesBingo.GetRandom(int.Parse(txtCartones.Text));
                b.Sorteos = sM;
                b.Save();
                this.Close();
            }
            
        }

        void CartonesBingo_Progressing(int pProgress)
        {
            try
            {
                pBar.Value = pProgress;
                Application.DoEvents();
            }
            catch { }
        }
        
        private bool Validar()
        {            
            int aux;
            decimal auxD;
            string str = "";
            
            if (sM==null)
            {
                str = "Falta definir los premios.\n\r";
            }
            if (!int.TryParse(txtCantidadSorteos.Text, out aux))
            {
                str += "El valor ingresado en 'Cantidad de Sorteos' no es un número.\n\r";
            }
            if (!decimal.TryParse(txtPrecio.Text, out auxD))
            {
                str += "El valor ingresado en 'Precio' no es un número.\n\r";
            }
            if (!int.TryParse(txtCartones.Text, out aux))
            {
                str += "El valor ingresado en 'Cantidad de Cartones' no es un número.\n\r";
            }
            else
            {
                if (!Common.CheckLicence() && aux>50)
                {
                    str += "El modo 'DEMO' solo permite generar hasta 50 cartones por bingo.\n\r";
                }
            }        
            if (txtNombre.Text.Length<4)
            {
                str += "El nombre del bingo debe contener por lo menos cuatro letras y/o numeros.\n\r";
            }
#warning si escribe 1.2 en precio retorna 12, con la coma funciona, controlar.
            bool ret=true;
            if (str!="")
            {
                MessageBox.Show("Los siguientes datos faltan o son incorrectos:\n\r"+str,"Datos faltantes.",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ret=false;
            }
            return ret;           
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmABMBingo_Load(object sender, EventArgs e)
        {
            this.Icon = Common.Icono;
            cmbExtraccionBolillas.Items.Add("Automatico");
            cmbExtraccionBolillas.Items.Add("Manual");
            cmbExtraccionBolillas.SelectedIndex = 0;
        }

        private void cmdDefinirPremios_Click(object sender, EventArgs e)
        {
            int cantSorteos;
            if (int.TryParse(txtCantidadSorteos.Text, out cantSorteos))
            {
                frmPremiosPorSorteo frm = new frmPremiosPorSorteo(cantSorteos,sM);
                frm.PremiosAsignados += new tbrItemActionEventHandler<SorteoManager>(frm_PremiosAsignados);
                frm.Show(this);
            }
            else
            {
                MessageBox.Show("La cantidad ingresada no es un número.");
            }

        }

        void frm_PremiosAsignados(SorteoManager Item)
        {
            sM = Item;
        }



    }
}
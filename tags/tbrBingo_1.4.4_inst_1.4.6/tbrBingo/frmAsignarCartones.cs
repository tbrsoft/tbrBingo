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
    public partial class frmAsignarCartones : Form
    {
        public frmAsignarCartones()
        {
            InitializeComponent();
        }

        private void frmAsignarCartones_Load(object sender, EventArgs e)
        {
            this.Icon = Common.Icono;
            VendedorManager vM = VendedorManager.FindAll();
            cmbVendedores.DataSource = vM;
            cmbVendedores.ValueMember = "id";
            cmbVendedores.DisplayMember = "NombreFormal";
            cmbVendedores.SelectedIndex = -1;
        }

        private void cmdAsignar_Click(object sender, EventArgs e)
        {
            bool overRide = false;
            bool asignar = true;
            CartonBingoManager cBM = new CartonBingoManager();
            cBM.LoadByRango(Common.BingoActual, long.Parse(txtDesde.Text), long.Parse(txtHasta.Text));
            foreach (CartonBingo var in cBM)
            {
                if (var.Vendedor != null && var.Vendedor.Id != (long)cmbVendedores.SelectedValue)
                {
                    overRide = true;
                }

            }

            if (overRide)
            {
                if (MessageBox.Show("Algun o algunos de los cartones ya estan asignados a un vendedor. ¿Desea Asignarlos de todas formas?", "Aviso", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                {
                    asignar = false;
                }
            }
            if (asignar)
            {
                cBM.AsignarVendedor((long)cmbVendedores.SelectedValue);
                MessageBox.Show("Los cartones se asignaron correctamente","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtDesde.Text = "";
                txtHasta.Text = "";
                //para que refresque los cartones porq no tienen referencia a los del bingo...
                Common.BingoActual.CartonesBingo = null;
            }
            cmbVendedores.SelectedIndex = -1;
        }
    }
}
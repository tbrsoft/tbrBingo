using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeneradorLicencias
{
    public partial class frmGenerador : Form
    {
        public frmGenerador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFD.ShowDialog();
            if (dr == DialogResult.OK)
            {
                bool res=LicenciaBasica.LicenciaBasica.HabilitarLicencia(openFD.FileName);
                if (res)
                {
                    MessageBox.Show("La licencia se generó en la misma carpeta del original con extensión .tli.");
                }
                else
                {
                    MessageBox.Show("La licencia no se pudo generar."); 
                }               

            } 
        }
    }
}
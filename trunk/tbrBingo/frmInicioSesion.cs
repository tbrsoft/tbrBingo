using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using tbrBingo.Properties;

namespace tbrBingo
{
    public partial class frmInicioSesion : Form
    {
        public delegate void SessionEventHandler(bool automatic);
        public event SessionEventHandler SesionIniciada;

        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (Settings.Default["pass"].ToString() == Encriptador.encryptPass(txtPass.Text))
            {
                this.Close();
                SesionIniciada(false);
            }
            else
            {
                MessageBox.Show("La contraseña introducida es incorrecta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmInicioSesion_Shown(object sender, EventArgs e)
        {
            if (Settings.Default["pass"].ToString() == Encriptador.encryptPass("demo"))
            {
                this.Close();
                SesionIniciada(true);

            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmInicioSesion_Load(object sender, EventArgs e)
        {

        }
    }
}
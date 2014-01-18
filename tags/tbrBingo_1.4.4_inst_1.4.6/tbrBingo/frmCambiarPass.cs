using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using tbrBingo.Properties;

namespace tbrBingo
{
    public partial class frmCambiarPass : Form
    {
        public frmCambiarPass()
        {
            InitializeComponent();
        }

        private void frmCambiarPass_Load(object sender, EventArgs e)
        {
            this.Icon = ((MDI)this.MdiParent).Icon;
            //si es demo no muestro el campo contrase�a actual
            if (Encriptador.encryptPass("demo") == Settings.Default["pass"].ToString())
            {
                txtActual.Visible = false;
                lblContrase�aActual.Visible = false;
                this.Text = "Cambiar contrase�a";
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            string actual = Settings.Default["pass"].ToString();

            if (txtNueva.Text == txtNueva.Text)
            {
                if (txtActual.Visible)
                {
                    if (actual == Encriptador.encryptPass(txtActual.Text))
                    {
                        GuardarPass();
                    }
                    else
                    {
                        MessageBox.Show("La contrase�a actual es incorrecta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    GuardarPass();
                }
            }
            else
            {
                MessageBox.Show("La nueva contrase�a debe coincidir con la repetici�n de la misma.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void GuardarPass()
        {
            Settings.Default["pass"] = Encriptador.encryptPass(txtNueva.Text);
            Settings.Default.Save();
            MessageBox.Show("La contrase�a se estableci� con �xito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
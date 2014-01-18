using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace tbrBingo
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
               
        void svWS_GetLastVersionCompleted(object sender, tbrBingo.SoftwareVersion.GetLastVersionCompletedEventArgs e)
        {
            if (e.Error == null)//no hubo errores...
            {
                lblUltimaVersion.Text = e.Result;                
            }
            else
            {
                lblUltimaVersion.Text = "No disponible.";
            }
            picWait.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.tbrSoft.com");
        }

        private void frmAbout_Shown(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            lblLicencia.Text = Common.CheckLicence() ? "Licencia: Habilitado." : "Licencia: Sin licencia."; 
            lblVersion.Text = Application.ProductVersion;
            try
            {
                SoftwareVersion.tbrSoftwareVersionWS svWS = new tbrBingo.SoftwareVersion.tbrSoftwareVersionWS();
                svWS.GetLastVersionCompleted += new tbrBingo.SoftwareVersion.GetLastVersionCompletedEventHandler(svWS_GetLastVersionCompleted);
                svWS.GetLastVersionAsync("tbrBingo");
            }
            catch
            {
                picWait.Visible = false;
                lblUltimaVersion.Text = "No disponible.";
            }       
        }

        private void cmdGenerar_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderD.ShowDialog();
            if (dr == DialogResult.OK)
            {
                bool res = LicenciaBasica.LicenciaBasica.GenerarInformacionLicencia(folderD.SelectedPath + "\\bingo.lic");
                if (res)
                {
                    MessageBox.Show("El archivo se generó exitosamente.","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El archivo no se pudo generar, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cmdInsertar_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFD.ShowDialog();
            if (dr == DialogResult.OK)
            {
                System.IO.File.Copy(openFD.FileName, Common.PathLicencia,true);
                bool habilitado=Common.CheckLicence();
                lblLicencia.Text = habilitado  ? "Licencia: Habilitado." : "Licencia: Sin licencia";
                if (habilitado)
                {
                    MessageBox.Show("La licencia se habilitó exitosamente.","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    ((MDI)MdiParent).Habilitar(true);
                }
                else
                {
                    MessageBox.Show("La licencia no es correcta, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void frmAbout_Load(object sender, EventArgs e)
        {

        }
    }
}
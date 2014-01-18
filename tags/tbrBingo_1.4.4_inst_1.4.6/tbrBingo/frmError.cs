using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tbrBingo
{
    public partial class frmError : Form
    {
        string contents = "";
        public frmError()
        {
            InitializeComponent();
        }

        internal void ShowError(Exception ex)
        {
            try
            {
                Log.PublicLog.Write("Fecha - Hora:" + DateTime.Now.ToString() + "\r\nError en tbrBingo.");
                Log.PublicLog.Write("Error global.", ex);

                contents = "Fecha - Hora:" + DateTime.Now.ToString();
                contents += "\r\nError en tbrBingo";
                contents += "\r\nMessage: " + ex.Message;
                contents += "\r\nSource: " + ex.Source;
                contents += "\r\nStackTrace: " + ex.StackTrace;
                contents += "\r\nTargetSite: " + (ex.TargetSite != null ? ex.TargetSite.Name : "Sin datos");
                contents += "\r\nInnerException: " + (ex.InnerException != null ? ex.InnerException.Message : "Sin datos");
            }
            catch { contents = "No se pudo confeccionar el informe de error."; } 
               
            txtError.Text = contents;
            this.ShowDialog();
            this.Icon = Common.Icono; 
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorService.tbrErrorServiceWS ErrorServiceWS = new tbrBingo.ErrorService.tbrErrorServiceWS();
                ErrorServiceWS.NotificateErrorCompleted += new tbrBingo.ErrorService.NotificateErrorCompletedEventHandler(ErrorServiceWS_NotificateErrorCompleted);
                ErrorServiceWS.NotificateErrorAsync(contents + "\r\nInformación Extra: " + txtInfo.Text);
            }
            catch { }; 
        }

        void ErrorServiceWS_NotificateErrorCompleted(object sender, tbrBingo.ErrorService.NotificateErrorCompletedEventArgs e)
        {
            MessageBox.Show("El informe de error se entregó con éxito. Muchas gracias por su colaboración.","Muchas Gracias",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }
    }
}
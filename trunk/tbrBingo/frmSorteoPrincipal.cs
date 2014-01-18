using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLBingo;
using System.Diagnostics;
using System.IO;

namespace tbrBingo
{
    public partial class frmSorteoPrincipal : Form
    {
        Bingo mBingo;
        frmSorteoExt mFrmSorteo;

        public frmSorteoPrincipal()
        {
            InitializeComponent();
            lvw.ItemDataBound += new tbrItemDataBoundEventHandler(lvw_ItemDataBound);
        }

        void lvw_ItemDataBound(ListViewItem lvwItem, object Item)
        {
            Sorteo s = (Sorteo)Item;
            if (s.EstadoSorteo == eEstadoSorteo.Finalizado)
            {
                lvwItem.SubItems[0].Text = s.Numeros.Serialize(" - ");
                lvwItem.SubItems[3].Text = s.Ganadores.Count.ToString();
            }
        }

        private void cmdSiguienteSorteo_Click(object sender, EventArgs e)
        {
            // NOSIRVE mBingo = Common.BingoActual;//agregado por andres tratando de que se sincronize los sorteos realizados
            Sorteo sAux = mBingo.Sorteos.GetNext();
            if (sAux != null)
            {
                frmRealizarSorteo frm = new frmRealizarSorteo();
                frm.SorteoRealizado += new tbrItemActionEventHandler<Sorteo>(frm_SorteoRealizado);
                frm.MdiParent = this.MdiParent;
                mFrmSorteo = new frmSorteoExt();
                mFrmSorteo.Left = Screen.PrimaryScreen.Bounds.Width;

                mFrmSorteo.Show();                
                frm.Sortear(mFrmSorteo, sAux);
            }            
           
        }
        //andresv el sorteo se pasa por valor!!
        void frm_SorteoRealizado(Sorteo Item)            
        {
            //mBingo.Sorteos.Add(Item);                        
            // NOSIRVE mBingo = Common.BingoActual;//agregado por andres tratando de que se sincronize los sorteos realizados

            mBingo.Sorteos.GetById(Item.Id).EstadoSorteo = eEstadoSorteo.Finalizado; //NO QUEDA GRABADO!?!!?!? TODO                       
            
            //mientras las cantidades sean distintas sigo sorteando
            bool continuarSorteo=(mBingo.Sorteos.GetByEstado(eEstadoSorteo.NoIniciado).Count!=0);
            cmdSiguienteSorteo.Enabled = continuarSorteo; 
            cmdImprimir.Enabled = !cmdSiguienteSorteo.Enabled;
            if (continuarSorteo)//si se realizo algun sorteo...
                {mBingo.EstadoBingo = eEstadoBingo.EnJuego;}
            else
                {mBingo.EstadoBingo = eEstadoBingo.Finalizado;} 

            mBingo.SaveSorteo();
            lvw.DataSource = mBingo.Sorteos; 
        }

        internal void Sortear()
        {
            mBingo = Common.BingoActual;
            this.Text = "Sorteo del bingo '" + mBingo.Nombre + "'";
            //lblCantidadBolillas.Text = mBingo.CantidadBolillas.ToString();
            lblCantidadCartones.Text = mBingo.CartonesBingo.GetByEstado(eEstadoCarton.Vendido).Count.ToString();   
            lblCantidadSorteos.Text = mBingo.CantidadSorteos.ToString();
            bool continuarSorteo = (mBingo.Sorteos.GetByEstado(eEstadoSorteo.NoIniciado).Count != 0);
            cmdSiguienteSorteo.Enabled = continuarSorteo;
            cmdImprimir.Enabled = !cmdSiguienteSorteo.Enabled;
#warning ver si hay propiedades faltantes
            this.Show();
            this.Icon = Common.Icono;
            lvw.DataSource = mBingo.Sorteos; 
        }


        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            ExportarResultados();
        }

        private void frmSorteoPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(mFrmSorteo!=null ) mFrmSorteo.Close();
        }

        private void lvw_ItemActivate(object sender, EventArgs e)
        {
           
        }

        private void lvw_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sorteo s = (Sorteo)lvw.SelectedItem;
            if (s != null)
            {
                lvwGanadores.DataSource = s.Ganadores;
            }
        }

        private void ExportarResultados()
        {
            bool alt = false;
            string bordes = "";// "border-right: #cccccc 1px solid; border-top: #cccccc 1px solid; border-left: #cccccc 1px solid; border-bottom: #cccccc 1px solid;";
            string html = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">";
            html += "<html xmlns=\"http://www.w3.org/1999/xhtml\" >";
            html += "<head><title>Resultados del Bingo</title></head>";
            html += "<body><table style=\"width: 100%;\" Cellpadding=0 cellspacing=0>";
            html += "<tr><td colspan=\"2\" style=\"width: 100%;\">";
            html += "<h2 style=" + bordes + "text-align: center\">";
            html += "Resultados - " + Common.BingoActual.Nombre + "</h2></td></tr>";
            foreach (Sorteo s in Common.BingoActual.Sorteos)
            {
                alt = false;//el primero nunca es alternativo
                html += "<tr style=\"BACKGROUND-COLOR: gray\"><td style=\"width: 50%; text-align: right\">";
                html += "<span style=\"font-size: 14pt\">Premio:</span>&nbsp;";
                html += "</td><td style=\"width: 50%\">";
                html += "<strong style=\"" + bordes + ";font-size: 14pt\">" + s.Premio + "</strong></td></tr>";
                foreach (CartonBingo cb in s.Ganadores)
                {
                    html += "<tr " + (alt ? "style=\"BACKGROUND-COLOR: rgb(10, 167, 225);\"" : "") + "><td style=\"width: 50%; text-align: right;\">";
                    html += "<span style=\"font-size: 14pt\">Carton Ganador Nro:</span>&nbsp;</td>";
                    html += "<td style=\"width: 50%\"><strong style=\"" + bordes + ";font-size: 14pt;\">" + cb.NroCarton + "</strong></td></tr>";
                    html += "<tr " + (alt ? "style=\"BACKGROUND-COLOR: rgb(10, 167, 225);\"" : "") + "><td style=\"width: 50%; text-align: right;\"><span style=\"font-size: 14pt\">Ganador:</span>&nbsp;</td>";
                    html += "<td style=\"width: 50%\"><strong style=\"" + bordes + ";font-size: 14pt;\">" + cb.Comprador.NombreFormal + "</strong></td></tr>";
                    html += "<tr " + (alt ? "style=\"BACKGROUND-COLOR: rgb(10, 167, 225);\"" : "") + "><td style=\"width: 50%; text-align: right;\">&nbsp;<span style=\"font-size: 14pt\">Numeros:</span>&nbsp;</td>";
                    html += "<td style=\"width: 50%\"><strong style=\"" + bordes + ";font-size: 14pt;\">" + cb.Carton.Numeros.Serialize(" - ") +"</strong></td></tr>";
                    alt = !alt;
                }               
            }
            
            html += "</table></body></html>";
            if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "Temp"))
            {
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "Temp");
            }
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "Temp\\ResTemp" + DateTime.Now.ToString("MM-dd-yyyy HH-mm") + ".htm";
            FileUtility.WriteFile(path, html); 
            Process.Start(path);
        }

        private void frmSorteoPrincipal_Load(object sender, EventArgs e)
        {

        }        
       
    }
}
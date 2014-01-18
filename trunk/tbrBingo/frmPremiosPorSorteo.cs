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
    public partial class frmPremiosPorSorteo : Form
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCantSorteos"></param>
    
        
        public event tbrItemActionEventHandler<SorteoManager> PremiosAsignados;
        
        
        public frmPremiosPorSorteo(int pCantSorteos, SorteoManager pSorteos)
        {
            this.Icon = Common.Icono;
            TextBox txt=null;
            Label lbl;
            InitializeComponent();
            for (int i = 0; i < pCantSorteos ; i++)
            {
                txt = new TextBox();
                lbl = new Label();
                lbl.Text = "Premio Sorteo " + ((int)(i + 1)).ToString() + ": ";
                txt.Left = lbl.Left + lbl.Width + 5;
                txt.Width = txt.Width * 2;
                lbl.Top = (i * 30)+20;
                txt.Top = lbl.Top-3;
                lbl.Name = "lbl" + i.ToString();
                txt.Name="txt"+i.ToString();
                if (pSorteos != null)
                {
                    if (i < pSorteos.Count)
                    {
                        txt.Text = pSorteos[i].Premio; 
                    }
                } 
                panel.Controls.Add(lbl);
                panel.Controls.Add(txt);                
            }
            panel.Height= txt.Top + txt.Height + 20;
            cmdAceptar.Top = panel.Height+20; 
            cmdCancelar.Top = cmdAceptar.Top;

            this.Height = cmdAceptar.Top + cmdAceptar.Height + 30; 
        }

        private void frmPremiosPorSorteo_Load(object sender, EventArgs e)
        {

        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {

        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAceptar_Click_1(object sender, EventArgs e)
        {
#warning Falta validar

            SorteoManager sM = new SorteoManager();
            Sorteo s;
            foreach (Control var in panel.Controls)
            {
                if (var.Name.StartsWith("txt"))
                {
                    s = new Sorteo();
                    s.Premio = var.Text;
                    s.EstadoSorteo = eEstadoSorteo.NoIniciado; 
                    sM.Add(s);
                }
            }
            //Seguramente hay una mejor forma de hacer esto.
            PremiosAsignados(sM);

            this.Close();
        }

    }
}
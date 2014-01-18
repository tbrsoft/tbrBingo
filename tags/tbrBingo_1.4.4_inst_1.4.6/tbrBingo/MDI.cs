
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
    public partial class MDI : Form
    {
        public ToolStripProgressBar ProgressBar
        {
            get { return pBar; }            
        }
	
        public MDI()
        {
            InitializeComponent();
        }

        private void frmTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTest f = new frmTest();
            f.Show();
        }

        private void realizarSorteoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRealizarSorteo frm = new frmRealizarSorteo();
            frm.MdiParent = this;
            frm.Show();
        }    

        private void abrirBingoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaBingos frm = new frmConsultaBingos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void diseñoImpresionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiseñoImpresion frm = new frmDiseñoImpresion();
            frm.MdiParent = this;
            frm.Show();

        }
        
        //----------------------------------Codigo definitivo----------------------------------

        private void MDI_Load(object sender, EventArgs e)
        {
            bingoToolStripMenuItem.Enabled = false;//hasta q no habra un bingo no lo habilito
            SetBackGroundImage();
            Common.Icono = this.Icon;
            Habilitar(true);
            #if DEBUG                
                archivoToolStripMenuItem.Visible = true;           
            #endif

            archivoToolStripMenuItem1.Enabled = false;
        }

        private void MDI_Shown(object sender, EventArgs e)
        {
            frmInicioSesion frm = new frmInicioSesion();
            frm.MdiParent = this;
            frm.SesionIniciada += new tbrBingo.frmInicioSesion.SessionEventHandler(frm_SesionIniciada);             
            frm.Show();
            
        }

        void frm_SesionIniciada(bool automatic)
        {
            if (!automatic)
            {
                iniciarSesionToolStripMenuItem.Text = "Cambiar contraseña";
            }
            archivoToolStripMenuItem1.Enabled = true;
            
        }

        /// <summary>
        /// LLamar esta funcion para habilitar despues de insertar una licencia correcta.
        /// </summary>
        public void Habilitar(bool value)
        {
            if (value)
            {
                consultaBingosToolStripMenuItem.Enabled = true;
            }
            else
            {
                consultaBingosToolStripMenuItem.Enabled = false;
                consultaBingosToolStripMenuItem.ToolTipText = "Para utilizar el software necesita licencia. (Menu Ayuda->Acerca de... para más información)";
            }
        }
        
       
        private void vendedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaVendedores frm = new frmConsultaVendedores();
            frm.MdiParent = this;
            frm.MostrarVendedores(VendedorManager.FindAll(),eTipoConsulta.eSinRetorno);
            //frm.MostrarVendedores(Testing.GetVendedores(), eTipoConsulta.eSinRetorno);
        }

        private void bingosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaBingos frm = new frmConsultaBingos();
            frm.MdiParent = this;            
            frm.BingoAbierto += new tbrItemActionEventHandler<Bingo>(frm_BingoAbierto);
            frm.Show();
        }

        void frm_BingoAbierto(Bingo Item)
        {
            sblblBingo.Text = "Bingo Abierto: " + Common.BingoActual.Nombre;
            realizarSorteoToolStripMenuItem.Text = Item.EstadoBingo == eEstadoBingo.Finalizado ? "Consultar Resultados Sorteo" : "Realizar Sorteo";  
            ActualizarMenues();
        }

        private void ActualizarMenues()
        {
            if (Common.BingoActual != null)
            {
                //si abrio un bingo habilito el menu
                bingoToolStripMenuItem.Enabled = true;
            }
        }                   

        private void asignarCartonesAVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsignarCartones frm = new frmAsignarCartones();
            frm.MdiParent = this;
            frm.Show();
        }

        private void realizarSorteoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSorteoPrincipal frm = new frmSorteoPrincipal();
            frm.MdiParent = this;
            frm.Sortear();
        }

        private void listadoDeCartonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaCartonBingo frm = new frmConsultaCartonBingo();
            frm.MdiParent = this;
            frm.ConsultarCartones(Common.BingoActual.CartonesBingo,eTipoConsulta.eSinRetorno);
        }

        private void SetBackGroundImage()
        {
#if DEBUG
            string imagepath = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Graphics\\BackGround.jpg";
#else
            string imagepath = AppDomain.CurrentDomain.BaseDirectory + @"Graphics\BackGround.jpg";
#endif
            System.IO.FileStream fs;
            // MDI Form image background layout change here
            //(Remember control imagebakground layout take default form background layount )
            this.BackgroundImageLayout = ImageLayout.Stretch;
            // Checking File exists if yes go --->
            if (System.IO.File.Exists(imagepath))
            {
                // Read Image file
                fs = System.IO.File.OpenRead(imagepath);
                fs.Position = 0;
                // Change MDI From back ground picture
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is MdiClient)
                    {
                        //ctl.BackColor = Color.AntiqueWhite;
                        ctl.BackgroundImage = System.Drawing.Image.FromStream(fs);
                        break;
                    }
                }
            }
        }

        private void diseñoDeCartónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiseñoImpresion frm = new frmDiseñoImpresion();
            frm.MdiParent = this;
            frm.AbrirDiseño(Common.BingoActual);  
        }

        private void impresiónDeCartonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImpresionCartones frm = new frmImpresionCartones();
            frm.MdiParent = this;
            frm.ImprimirCartones(Common.BingoActual);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();  
        }

        private void contenidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = this.ActiveMdiChild;
            if (form != null)
            {
                switch (form.Name)
                {
                    case "frmABMBingo":
                        ShowHelp("nuevoBingo.htm");
                        break;
                    case "frmABMVendedores":
                        ShowHelp("vendedores.htm");
                        break;
                    case "frmAsignarCartones":
                        ShowHelp("asignarcartones.htm");
                        break;
                    case "frmConsultaBingos":
                        ShowHelp("consultaBingos.htm");
                        break;
                    case "frmConsultaCartonBingo":
                        ShowHelp("consultarcartones.htm");
                        break;
                    case "frmConsultaVendedores":
                        ShowHelp("vendedores.htm");
                        break;
                    case "frmDiseñoImpresion":
                        ShowHelp("DiseñoImpresion.htm");
                        break;
                    case "frmImpresionCartones":
                        ShowHelp("ImprimirCartones.htm");
                        break;
                    case "frmPremiosporSorteos":
                        ShowHelp("NuevoBingo.htm");
                        break;
                    case "frmRealizarSorteo":
                        ShowHelp("realizarsorteo.htm");
                        break;
                    case "frmRegistrarVenta":
                        ShowHelp("RegistrarVentaCartones.htm");
                        break;
                    case "frmSorteoExt":
                        ShowHelp("RealizarSorteo.htm");
                        break;
                    case "frmSorteoPrincipal":
                        ShowHelp("RealizarSorteo.htm");
                        break;
                    case "frmAbout":
                        ShowHelp("Activacion.htm");
                        break;
                    default:
                        ShowHelp("");
                        break;
                }
            }
            else
            {
                ShowHelp("");
            }           
            
        }

        public void ShowHelp(string context)
        { 
            Help.ShowHelp(this, AppDomain.CurrentDomain.BaseDirectory + "Ayuda.chm",context);  
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.MdiParent = this;
            frm.Show();
        }

        private void iniciarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCambiarPass frm = new frmCambiarPass();
            frm.MdiParent = this;
            frm.Show();
        }       
               
    }
}
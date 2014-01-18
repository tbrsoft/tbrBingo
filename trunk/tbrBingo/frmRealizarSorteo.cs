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
    public partial class frmRealizarSorteo : Form
    {
        public event tbrItemActionEventHandler<Sorteo> SorteoRealizado;
        Bingo m_Bingo;
        Sorteo m_Sorteo;
        Bolillero m_Bolillero;
        CartonBingoManager m_CartonesVendidos;
        //frmSorteoExt mFrmSorteo;
        frmSorteoExt frmExt;

        /// <summary>
        /// Recibe un Bingo
        /// </summary>
        /// 
        public frmRealizarSorteo()
        {
            InitializeComponent();
        }


        private void frmNewSorteo_Load(object sender, EventArgs e)
        {
            //m_Bingo.m_CartonesBingo = CartonBingoManager.FindByBingo(m_Bingo.Id);

            this.Icon = Common.Icono;

        }

        private void cmdNewNumber_Click(object sender, EventArgs e)
        {
            cmdNewNumber.Enabled = false;
            CartonGanadorManager cGanadores = null;
            int aux = 0;
            if (m_Bingo.TipoBingo == eTipoBingo.Automatico)
            {
                int n = m_Bolillero.GetNumber();
                if (n == -1)
                {
                    MessageBox.Show("Se termino de sortear los numeros");
                }
                else
                {
                    txtNum.Text = n < 10 ? "0" + n.ToString() : n.ToString();
                    txtNumeros.Text = txtNum.Text + "\r\n" + txtNumeros.Text;
                    tBingo1.newNumber(int.Parse(txtNum.Text));
                    frmExt.AgregarNumero(n);
                    aux = n;
                }

            }
            else
            {
#warning falta validar rango

                if (!int.TryParse(txtNum.Text, out aux))
                {
                    MessageBox.Show("El valor ingresado no es un número");
                }
                else
                {
                    if (chkConfirmacion.Checked)
                    {
                        if (MessageBox.Show("Esta seguro que desea ingresar el siguiente número?:\n Nº: " + txtNum.Text, "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            SortearNumeroManual(aux);
                        }
                    }
                    else
                    {
                        SortearNumeroManual(aux);
                    }
                    txtNum.Text = "";

                    if (chkExtenderPantalla.Checked)
                    {
                        if (frmExt != null)
                        {
                            frmExt.AgregarNumero(aux);
                        }
                    }
                    txtNum.Refresh();
                    txtNumeros.Refresh();
                }
            }

            lblCantBolillas.Text = m_Bolillero.ExtractedNumbers.Count.ToString();
            cGanadores = m_Sorteo.ObtenerGanadores(m_CartonesVendidos);

            //lo habilito despues de buscar los ganadores
            cmdNewNumber.Enabled = true;

            if (cGanadores.Count > 0)
            {
                //Hay ganadores.
                lvwGanadores.DataSource = cGanadores;
                lvwGanadores.Refresh();
                m_Sorteo.Ganadores = new CartonBingoManager();
                foreach (CartonGanador cg in cGanadores)
                {
                    m_Sorteo.Ganadores.Add(cg.Carton);
                }
                SorteoRealizado(m_Sorteo);//marca el sorteo como finalizado y lo graba
                //de todas formas por algun motivo cuando se pide un juego nuevo no toma a este
                //como finalizado y lo repite !!


                //MessageBox.Show("Carton Ganador: Nº= "+ cGanadores[0].Carton.NroCarton  + " Numeros:"+cGanadores[0].Carton.Carton.Numeros.Serialize());                
                cmdNewNumber.Enabled = false;
                cmdCerrar.Enabled = true;

                frmExt.NewWinner(cGanadores);
            }
        }

        private void SortearNumeroManual(int aux)
        {
            if (m_Bolillero.InsertNumber(aux))
            {
                txtNumeros.Text = txtNum.Text + "\r\n" + txtNumeros.Text;
                tBingo1.newNumber(int.Parse(txtNum.Text));
                frmExt.AgregarNumero(aux);
            }
            else
            {
                MessageBox.Show("El numero ingresado ya esta dentro de los numeros extraidos");
            }
        }
        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkExtenderPantalla_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExtenderPantalla.Checked)
            {
                if (frmExt != null)//nunca deberia ser null
                {
                    frmExt.Visible = true;
                }
                //frmExt = new frmSorteoExt();
                //frmExt.SetHead("1º Premio: "+m_Sorteo.Premio );
                //frmExt.Show();
            }
            else
            {
                if (frmExt != null)
                {
                    frmExt.Visible = false;
                }
            }
        }

        internal void Sortear(frmSorteoExt pFrmSorteo, Sorteo pSorteo)
        {
            m_Bingo = Common.BingoActual;

#warning el tipo strategy depende de algo y los parametros de bolillero tambien..

            m_Bolillero = new Bolillero(1, 90);
            pSorteo.setStrategy(new StrategyA());
            m_Sorteo = pSorteo;
            m_Sorteo.Numeros = m_Bolillero.ExtractedNumbers;

            m_Sorteo.EstadoSorteo = eEstadoSorteo.EnJuego;

            if (m_Bingo.TipoBingo == eTipoBingo.Automatico)
            {
                txtNum.Enabled = false;
            }
            m_CartonesVendidos = m_Bingo.CartonesBingo.GetByEstado(eEstadoCarton.Vendido);
            this.Show();

            //aca traigo el form secundario
            frmExt = pFrmSorteo;
            frmExt.Clear();
            frmExt.SetHead(m_Sorteo.Premio);//TODO: ERROR, siempre muetsra el primero !!!

            if (Common.BingoActual.TipoBingo == eTipoBingo.Automatico)
            { chkConfirmacion.Visible = false; }

            txtNum.Focus();

        }

        private void tBingo1_Load(object sender, EventArgs e)
        {

        }

        private void frmRealizarSorteo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (m_Sorteo.EstadoSorteo == eEstadoSorteo.Finalizado)
                { 
                    //salir nomas, acaba de terminar uno
                    if (frmExt != null)
                        {frmExt.Close();}
                }
                else //si no esta finalizado
                {
                String s="";
                if (m_Sorteo.EstadoSorteo == eEstadoSorteo.EnJuego)
                    {s="Está seguro que desea cancelar el desarrollo del actual sorteo? \n(Puede realizarlo en otro momento, pero no se guardan las bolillas que se sortearon hasta el momento)\n\n Aceptar para cerrar el formulario, Cancelar para continuar el sorteo";}

                if (m_Sorteo.EstadoSorteo == eEstadoSorteo.NoIniciado)
                    {s="Está seguro que desea cancelar el inicio del sorteo?";}
                if (MessageBox.Show(s, "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                    //SOLO SI ESTA EN JUEGO MARCARLO COMO 
                    if (m_Sorteo.EstadoSorteo != eEstadoSorteo.Finalizado)
                        {m_Sorteo.EstadoSorteo = eEstadoSorteo.NoIniciado;}
                    if (frmExt != null)
                        {frmExt.Close();}
                    }                    
                else
                    {e.Cancel = true;}

                }
            }//fin de saber si el usuario cerro la conexion
            else //usuario cierra conexion
            {
                if (frmExt != null)
                    {frmExt.Close();}
            }
            
        

        


    }//fin del evento cerrar
    }//fin del partial class
}//fin del namespace

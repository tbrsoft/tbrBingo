using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tbrBingo
{
    public partial class frmSorteoSecundario : Form
    {
        public frmSorteoSecundario()
        {
            InitializeComponent();
        }
        /// <summary>
        /// El  reset de la pantalla.
        /// </summary>
        internal void Clear()
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
        }
        /// <summary>
        /// la llamo cuando se ingresa un numero
        /// </summary>
        /// <param name="n"></param>
        internal void NewNumber(int n)
        {
            label2.Text += " - " + n;
        }
        /// <summary>
        /// esta se llama una sola  vez cuando hay un ganador
        /// </summary>
        /// <param name="pCartonGanador"></param>
        internal void NewWinner(BLBingo.CartonGanador pCartonGanador)
        {
            //aca te viene el nombre del ganador
            label3.Text = pCartonGanador.Carton.Comprador.NombreFormal;
        }
        /// <summary>
        /// Aca te mando el premio.
        /// </summary>
        /// <param name="pPremio"></param>
        internal void NewPremio(string pPremio)
        {
            label1.Text = pPremio;
        }
    }
}
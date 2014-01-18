using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BLBingo;

namespace tbrBingo
{
    public partial class ctrlGanadores : UserControl
    {
        public ctrlGanadores()
        {
            InitializeComponent();
        }
        public ctrlGanadores(CartonGanador cG)
        {
            InitializeComponent();
            lblApellido.Text = cG.Carton.Comprador.Apellido;
            lblCarton.Text = cG.Carton.Carton.Numeros.Serialize(" | ");
            lblNombre.Text = cG.Carton.Comprador.Nombre;
            lblNroCarton.Text = cG.Carton.NroCarton.ToString();
        }
    }
}

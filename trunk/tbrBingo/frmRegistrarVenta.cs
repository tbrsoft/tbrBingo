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
    public partial class frmRegistrarVenta : Form
    {
        CartonBingo mCartonBingo;
        CartonBingoManager mCartonesBingo=new CartonBingoManager();//hecho por andresV para marcar como que un tipo compro varios cartones
        Comprador mComprador;

        public frmRegistrarVenta()
        {
            InitializeComponent();
        }

        private void cmdVendedores_Click(object sender, EventArgs e)
        {
            frmConsultaVendedores frm = new frmConsultaVendedores();
            frm.MdiParent = this.MdiParent;            
        }
        /// <summary>
        /// Llamar desde el MDI.
        /// </summary>
        public void RegistrarVenta()
        {
            lvw.ItemDblClick +=new tbrSelectedItemEventHandler<object>(lvw_ItemSelected); 
            this.Show();
            this.Icon = Common.Icono;
        }

        
        /// <summary>
        /// Llamar cuando conozco el carton.
        /// </summary>
        /// <param name="pCartonBingo"></param>
        public void RegistrarVenta(CartonBingo pCartonBingo)
        {
            lvw.ItemDblClick  += new tbrSelectedItemEventHandler<object>(lvw_ItemSelected); 
            MostrarCarton(pCartonBingo);
            this.Show();
            this.Icon = Common.Icono;
        }
        //andresv agrega para poder marcar que un tipo compro varios
        public void RegistrarVenta(CartonBingoManager pCartonesBingo)
        {
            mCartonesBingo = pCartonesBingo;
            lvw.ItemDblClick += new tbrSelectedItemEventHandler<object>(lvw_ItemSelected);
            //controlar que todos tengan asignado vendedor primero
            txtCarton.Text = "";//negrada de andres v para saber si se estan cargando todos!!
            lblNumeros.Text = "";
            lblVendedor.Text = "";
            foreach (CartonBingo cb in pCartonesBingo)
                {MostrarCarton(cb);}//aqui escribe y controla
            
            this.Show();
            this.Icon = Common.Icono;
        }

        void lvw_ItemSelected(object Item)
        {
            mComprador = (Comprador)Item;
            txtApellido.Text = mComprador.Apellido;
            txtDireccion.Text = mComprador.Direccion;
            txtDNI.Text = mComprador.DNI;
            txtMail.Text = mComprador.Mail;
            txtNombre.Text = mComprador.Nombre;
            txtTelefono.Text = mComprador.Telefono;
        }

        private void MostrarCarton(CartonBingo pCartonBingo)
        {
            mCartonBingo = pCartonBingo;
            
            txtCarton.Text += mCartonBingo.NroCarton.ToString();
            lblNumeros.Text += " [" + mCartonBingo.Carton.Numeros.Serialize(" - ")+"] ";
            //TODO si vendedor viene null habria q mostrar un combo y dejarlo elegir

            if (mCartonBingo.Vendedor == null)
            {
                MessageBox.Show("Debe asignar el carton a un Vendedor antes de registrar la venta.","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                lblVendedor.Text += mCartonBingo.Vendedor.NombreFormal; 
            }
            
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void txtCarton_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    BuscarCarton();
                    break;
                default:
                    break;
            }
        }

        private void BuscarCarton()
        {
            long idCartonBingo;
            if (!long.TryParse(txtCarton.Text, out idCartonBingo))
            {
            }
            else
            {
                CartonBingo aux = CartonBingoManager.FindByIdByBingo(idCartonBingo, Common.BingoActual);
                if (aux != null)
                {
                    mCartonBingo = aux;
                    MostrarCarton(mCartonBingo);
                }
                else
                {
                    MessageBox.Show("No se encontró el carton solicitado.","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }
                
        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (DatosCorrectos())
            {
                if (mComprador == null)
                {
                    mComprador = new Comprador();
                    mComprador.Apellido = txtApellido.Text;
                    mComprador.Direccion = txtDireccion.Text;
                    mComprador.DNI = txtDNI.Text;
                    mComprador.Mail = txtMail.Text;
                    mComprador.Nombre = txtNombre.Text;
                    mComprador.Telefono = txtTelefono.Text;
                    mComprador.Save();
                }

                //si es uno multiple ir a la coleccion!
                if (mCartonesBingo.Count > 0)
                {
                    foreach (CartonBingo cb in mCartonesBingo)
                    {
                        cb.Comprador = mComprador;
                        cb.Estado = eEstadoCarton.Vendido;
                        #warning ver el tema de la fecha de venta
                        cb.Save();
                    }
                }
                else
                    {
                    mCartonBingo.Comprador = mComprador;
                    mCartonBingo.Estado = eEstadoCarton.Vendido;
                    #warning ver el tema de la fecha de venta
                    mCartonBingo.Save();
                    }
                this.Close();
            }
        }

        private bool DatosCorrectos()
        {
            string msj = "";

            if (mCartonBingo == null)
            {
                msj += "Debe seleccionar o buscar un Carton.\n";
            }
            if (mComprador == null)
            {
                msj += (txtApellido.Text == "" ? "Debe ingresar el apellido del Comprador." : "");
                msj += (txtNombre.Text == "" ? "Debe ingresar el nombre del Comprador." : "");
            }

            if (msj != "")
            {
                MessageBox.Show("Faltan los siguientes datos:\n","Faltan datos...",MessageBoxButtons.OK,MessageBoxIcon.Information);  
            }

            return (msj == ""); 
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            CompradorManager compradores = CompradorManager.FindByFilters(txtNombre.Text);
            lvw.DataSource = compradores; 
        }

        private void frmRegistrarVenta_Load(object sender, EventArgs e)
        {

        }
    }
}
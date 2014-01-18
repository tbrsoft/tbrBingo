using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLBingo;
using System.Diagnostics;

namespace tbrBingo
{
    public partial class frmABMVendedores : Form
    {
        public event tbrItemActionEventHandler<Vendedor> NewItem;
        public event tbrItemActionEventHandler<Vendedor> ModifiedItem;

        eTipoABM mTipoABM;
        Vendedor mVendedor;


        public frmABMVendedores()
        {
            InitializeComponent();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (DatosCompletos())
            {
                switch (mTipoABM)
                {
                    case eTipoABM.eAlta:
                        mVendedor = new Vendedor();
                        FillVendedor();
                        mVendedor.Save();
                        if (NewItem != null)
                        {
                            NewItem(mVendedor);
                        }
                        this.Close();
                        break;
                    case eTipoABM.eModificacion:
                        FillVendedor();
                        mVendedor.Save();
                        if (ModifiedItem != null)
                        {
                            ModifiedItem(mVendedor);
                        }
                        this.Close();
                        break;
                    default:
                        break;
                }                
            }            
        }

        private bool DatosCompletos()
        {
            string msg="";
            if (txtNombre.Text == "") msg = "Debe ingresar el nombre del vendedor.\n";
            if (txtApellido.Text == "") msg = "Debe ingresar el apellido del vendedor.\n";

            if (msg != "")
            {
                MessageBox.Show("Falta ingresar los siguientes datos:\n"+msg);
                return false;
            }
            return true;
        }

        private void FillVendedor()
        {
            mVendedor.Apellido = txtApellido.Text;
            mVendedor.Direccion = txtDireccion.Text;
            mVendedor.DNI = txtDNI.Text;
            mVendedor.Mail = txtMail.Text;
            mVendedor.Nombre = txtNombre.Text;
            mVendedor.Telefono = txtTelefono.Text;
            mVendedor.Observaciones = txtObservaciones.Text;
        }

        public void NuevoVendedor()
        {
            mTipoABM = eTipoABM.eAlta;
            this.Text = "Nuevo Vendedor";
            this.Show();
            this.Icon = Common.Icono;
        }

        public void ModificarVendedor(Vendedor pVendedor)
        {
            mTipoABM = eTipoABM.eModificacion;
            mVendedor = pVendedor;
            txtApellido.Text=pVendedor.Apellido;
            txtDireccion.Text = pVendedor.Direccion;
            txtDNI.Text = pVendedor.DNI;
            txtMail.Text = pVendedor.Mail;
            txtNombre.Text = pVendedor.Nombre;
            txtTelefono.Text = pVendedor.Telefono;
            txtObservaciones.Text = pVendedor.Observaciones;
            this.Text = "Modificar Vendedor";
            this.Show();
            this.Icon = Common.Icono;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
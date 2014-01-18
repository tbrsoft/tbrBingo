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
    public partial class frmConsultaVendedores : Form
    {
        eTipoConsulta mTipoConsulta;
        VendedorManager mVendedores;

        public frmConsultaVendedores()
        {
            InitializeComponent();
        }

        public void MostrarVendedores(VendedorManager pVendedores, eTipoConsulta pTipoConsulta)
        {
            this.Icon = Common.Icono;
            this.Show();
            mVendedores = pVendedores;
            lvwVendedores.DataSource = mVendedores;
            mTipoConsulta = pTipoConsulta;
        }

        #region Menu
        
        private void nuevoToolStripButton_Click(object sender, EventArgs e)
        {
            frmABMVendedores frm = new frmABMVendedores();
            frm.MdiParent = this.MdiParent;
            //pongo a escuchar el evento new item, asi cuando se cierra el abm refresco la lista
            frm.NewItem += new tbrItemActionEventHandler<BLBingo.Vendedor>(frm_NewItem);
            frm.NuevoVendedor();
        }

        private void editarToolStripButton_Click(object sender, EventArgs e)
        {
            if(lvwVendedores.SelectedItem!=null)
            {
                frmABMVendedores frm = new frmABMVendedores();
                frm.MdiParent = this.MdiParent;
                //pongo a escuchar el evento modified item, pero hago lo mismo que en el new. 
                frm.ModifiedItem += new tbrItemActionEventHandler<BLBingo.Vendedor>(frm_NewItem);
                frm.ModificarVendedor((Vendedor)lvwVendedores.SelectedItem);
            }            
        }

        #endregion

        void frm_NewItem(BLBingo.Vendedor Item)
        {
            mVendedores.Add(Item);
            lvwVendedores.DataSource = mVendedores;
            lvwVendedores.SelectedItem = Item;
            lvwVendedores.Refresh();
        }

        private void ayudaToolStripButton_Click(object sender, EventArgs e)
        {
            ((MDI)(MdiParent)).ShowHelp("Vendedores.htm");  
        }               
                
    }
}
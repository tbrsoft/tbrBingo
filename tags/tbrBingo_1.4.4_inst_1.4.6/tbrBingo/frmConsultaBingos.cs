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
    public partial class frmConsultaBingos : Form
    {
        public event tbrItemActionEventHandler<Bingo>BingoAbierto;

        public frmConsultaBingos()
        {
            InitializeComponent();
        }
                
        private void frmConsultaBingos_Load(object sender, EventArgs e)
        {
            this.Icon = Common.Icono;
            BingoManager bM = new BingoManager();
            lvw.DataSource = bM.LoadAll();            
            lvw.ItemDblClick += new tbrSelectedItemEventHandler<object>(lvw_ItemDblClick);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = lvw.SelectedItems.Count == 0;
        }
        
        private void tbrListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbrListView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(lvw,e.Location);
            }
        }            

        // Aca abro el bingo para q este accesible desde todo el proyecto.
        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            AbrirBingo();
        }

        void lvw_ItemDblClick(object Item)
        {
            AbrirBingo();
        }

        private void AbrirBingo()
        {
            if (lvw.SelectedItem != null)
            {
                Common.BingoActual = (Bingo)lvw.SelectedItem;
                MessageBox.Show("Se estableció " + Common.BingoActual.Nombre + " como Bingo Actual.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (BingoAbierto != null)
                {
                    BingoAbierto(Common.BingoActual);
                }
                this.Close();

            }
        }

        private void nuevoToolStripButton_Click(object sender, EventArgs e)
        {
            frmABMBingo frm = new frmABMBingo();
            frm.MdiParent = this.MdiParent ;
            frm.Show();
            this.Dispose();
        }

        private void lvw_ItemDataBound(ListViewItem lvwItem, object Item)
        {
            lvwItem.SubItems[0].Text = ((Bingo)Item).Fecha.ToShortDateString(); 
            lvwItem.SubItems[4].Text=FormularioCarton.ExisteFormulario((Bingo)Item)?"Si":"No"; 
        }

        private void ayudaToolStripButton_Click(object sender, EventArgs e)
        {
            ((MDI)(MdiParent)).ShowHelp("ConsultaBingos.htm");  
        }

                
        //ver porque esta esto, seguro quedo de las preubas iniciales
        private void nuevoSorteoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bingo b = (Bingo)lvw.SelectedItem;
            if (b.CantidadSorteos > b.Sorteos.Count)
            {

                frmRealizarSorteo frmSorteo = new frmRealizarSorteo();
                frmSorteo.MdiParent = this.MdiParent;
                frmSorteo.Show();
            }
            else
            {//TODO Seria interesante no mostrar el menu en este caso....
                MessageBox.Show("Este bingo no Admite mas sorteos");
            }
        }

        private void lvw_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvw_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
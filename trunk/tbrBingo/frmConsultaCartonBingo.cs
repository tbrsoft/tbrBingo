using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLBingo;
using ExcelInterface;


namespace tbrBingo
{
    public partial class frmConsultaCartonBingo : Form
    {
        eTipoConsulta mTipoConsulta;
        CartonBingoManager mCartones;
        Vendedor mVendedor;

        public frmConsultaCartonBingo()
        {
            InitializeComponent();
            lvw.Activation = ItemActivation.OneClick;
            lvw.ItemActivate += new EventHandler(lvw_ItemActivate);
            
            dropVendedor.Items.Add("-Todos-");
            foreach (Vendedor v in VendedorManager.FindAll())
            {
                dropVendedor.Items.Add(v);
            }

        }

        void lvw_ItemActivate(object sender, EventArgs e)
        { 
            CartonBingo cb = (CartonBingo)lvw.SelectedItem;
            if (cb != null)
            {
                cmdVender.Enabled = cb.Vendedor != null && (cb.Estado == eEstadoCarton.AsignadoAVendedor ||cb.Estado == eEstadoCarton.Devuelto);
                cmdCancelarVenta.Enabled = cb.Comprador != null;
            }
            else
            {
                cmdCancelarVenta.Enabled = false;
                cmdVender.Enabled = false;
            }      
        }

        //-------------------toolbar---------------------------

        private void cmdVender_Click(object sender, EventArgs e)
        {
            if (lvw.SelectedItem != null)
            {
                frmRegistrarVenta frm = new frmRegistrarVenta();
                frm.MdiParent = this.MdiParent;
                //TODO andresv. no se fija si son varios elegidos
                //solo mnanda uno a regisdtra vendido
                //puedo necesitar varios al mismo tiempo
                if (lvw.SelectedItems.Count > 0)
                {
                    CartonBingoManager cbm=new CartonBingoManager();
                    ListViewItem lastLvi= new ListViewItem();
                    //toda esta negrada por que usa un tbrListView que no permite multiple seleccion
                    foreach (ListViewItem lvi2 in lvw.SelectedItems)
                    {
                        lvi2.Selected = true;
                        if (lastLvi.Selected)                                                    
                            { lastLvi.Selected = false; }//desmarcar el anterior para que internamente se pueda iterar sobre estos!
                        CartonBingo cc = ((CartonBingo)lvw.SelectedItem );
                        cbm.Add(cc);    
                        lastLvi=lvi2;
                    }
                    frm.RegistrarVenta(cbm);
                }
                else
                { frm.RegistrarVenta((CartonBingo)lvw.SelectedItem); }

                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed); 
            }             
        }

        //me avisa cuando se cerro el form de venta, actualizo la lista
        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LlenarLista(mCartones);
        }

        public void ConsultarCartones(CartonBingoManager pCartones, eTipoConsulta pTipoConsulta)
        {
            this.Show();
            mCartones = pCartones;
            
            lvw.Progressing += new tbrProgressEventHandler(lvw_Progressing);
            
            LlenarLista(mCartones);

            mTipoConsulta = pTipoConsulta;
            lvw.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent); 
        }

        void lvw_Progressing(int pProgress)
        {
            ToolStripProgressBar pb = ((MDI)this.MdiParent).ProgressBar;
            pb.Value = pProgress;
        }


        private void dropVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropVendedor.SelectedIndex == 0)
            {
                LlenarLista(mCartones);
                mVendedor = null;
            }
            else
            {
                mVendedor = (Vendedor)dropVendedor.SelectedItem;
                LlenarLista(mCartones.GetByVendedor(mVendedor));
            }
        }

        private void LlenarLista(CartonBingoManager pCartones)
        {
            ToolStripProgressBar pb = ((MDI)this.MdiParent).ProgressBar;
            pb.Maximum = pCartones.Count + 2;//+2 para q no se pase de vueltas 
            pb.Visible = true;
            lvw.DataSource = pCartones;
            pb.Visible = false;
        }

        private void cmdExportar_Click(object sender, EventArgs e)
        {
            Exportar("xml");            
        }

        private void cmdExportarExcel_Click(object sender, EventArgs e)
        {
            Exportar("excel");
        }

        private void Exportar(string where)
        {
            if (mVendedor != null)
            {
                DataRow dr;
                DataSet ds = new DataSet("CartonesBingo");
                DataTable dt = CartonBingoManager.FindByVendedorByBingo(mVendedor, Common.BingoActual);
                dt.TableName = "Cartones";
                //parche horrible para q no elimine las columnas vacias
                dr = dt.NewRow();
                dr["nombre"] = "-";
                dr["apellido"] = "-";
                dr["dni"] = "-";
                dr["direccion"] = "-";
                dr["mail"] = "-";
                dr["observaciones"] = "-";
                dr["telefono"] = "-";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);

                //dt.WriteXml(cdSave.FileName);
                switch (where)
                {
                    case "excel":
                        ExcelInterface.ExcelInterface.Exportar(AppDomain.CurrentDomain.BaseDirectory + "Template.xls", dt);
                        break;
                    case "xml":
                        cdSave.FileName = mVendedor + " (" + Common.BingoActual.Fecha.ToString("dd-MM-yyyy") + ").tbrb";

                        DialogResult dgr = cdSave.ShowDialog();
                        if (dgr == DialogResult.OK)
                        {
                            ds.WriteXml(cdSave.FileName);
                        }
                        break;
                    default:
                        break;
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un vendedor para poder exportar la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmdImportar_Click(object sender, EventArgs e)
        {
            DialogResult dr = cdOpen.ShowDialog();
            if (dr == DialogResult.OK)
            {
                DataSet ds = new DataSet();
                try
                {
                    if (cdOpen.FileName.EndsWith(".xls"))
                    {
                        ImportarDatos(ExcelReader.GetData(cdOpen.FileName));
                    }
                    else
                    {
                        ds.ReadXml(cdOpen.FileName);
                        ImportarDatos(ds.Tables[0]);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error al abrir el archivo: "+ex.Message);                   
                }
                
            }            
           
        }

        private void ImportarDatos(DataTable dt)
        { 
            //muestro la barra
            ToolStripProgressBar pb = ((MDI)this.MdiParent).ProgressBar;
            pb.Maximum = dt.Rows.Count + 2;//+2 para q no se pase de vueltas 
            pb.Visible = true;
            int i=0;

            CartonBingo cb;
            Comprador comp;
            foreach (DataRow dr in dt.Rows)
            {
                //aviso q hay progreso
                lvw_Progressing(i++);
 
                if (dr["NroCarton"].ToString() != "")
                {
                    cb = mCartones.GetByNroCarton(long.Parse(dr["NroCarton"].ToString()));
                    if (cb != null)
                    {
                        if (dr["nombre"].ToString() != "")//asumo que esta vendido
                        {
                            comp = CrearComprador(dr);

                            cb.Comprador = comp;
                            cb.Estado = eEstadoCarton.Vendido;
#warning ver el tema de la fecha de venta
                            cb.Save();
                        }
                    }
                }

            }

            //oculto la barra
            pb.Visible = false;
            //obligo a recargar los cartones
            Common.BingoActual.CartonesBingo = null;
            mCartones = Common.BingoActual.CartonesBingo;
            LlenarLista(mCartones);
        }

        private Comprador CrearComprador(DataRow dr)
        {
            Comprador comp = new Comprador();
            comp.Apellido = dr["Apellido"].ToString();
            comp.Direccion = dr["Direccion"].ToString(); 
            comp.DNI = dr["DNI"].ToString();
            comp.Mail =dr["Mail"].ToString() ;
            comp.Nombre = dr["Nombre"].ToString();
            comp.Telefono = dr["Telefono"].ToString();
            comp.Save();
            return comp;
        }

        private void frmConsultaCartonBingo_Load(object sender, EventArgs e)
        {
            this.Icon = Common.Icono;
        }

        private void cmdCancelarVenta_Click(object sender, EventArgs e)
        {
            CartonBingo cBAux;
            if (lvw.SelectedItem != null)
            {
                if (MessageBox.Show("¿Está seguro que desea anular la venta?", "Anular Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cBAux = (CartonBingo)lvw.SelectedItem;
                    cBAux.Estado = eEstadoCarton.Devuelto;
                    cBAux.Save();
                    LlenarLista(mCartones);
                }
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            mCartones = Common.BingoActual.CartonesBingo;
            LlenarLista(mCartones);
        }
                  
    }
}
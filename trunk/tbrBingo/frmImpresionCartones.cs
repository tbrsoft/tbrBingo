using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLBingo;
using System.IO;

namespace tbrBingo
{
    public partial class frmImpresionCartones : Form
    {
        Queue<CartonBingo> cartones;
        FormularioCarton formulario;
        CartonBingoManager mCartonesForm;            

        public frmImpresionCartones()
        {
            InitializeComponent();
        }

        private void cmdPlay_Click(object sender, EventArgs e)
        {
            if (cmdPlay.Text == "Pausar")
            {
                timeImpresion.Stop();
                cmdPlay.Text = "Continuar";
            }
            else
            { 
                timeImpresion.Start();
                cmdPlay.Text = "Pausar";
            }
        }

        public void ImprimirCartones(Bingo pBingo)
        {
            this.Icon = Common.Icono;
            this.Show();
            //progreso
            ToolStripProgressBar pb = ((MDI)this.MdiParent).ProgressBar;
            pb.Maximum = pBingo.CartonesBingo.Count + 2;//+2 para q no se pase de vueltas 
            pb.Visible = true;
            //tLvw.Progressing += new tbrProgressEventHandler(tLvw_Progressing);
            tLvw.Progressing += delegate(int p)
            {                
                pb.Value = p;
            }; 
            //abro el diseño del bingo
            formulario = new FormularioCarton();
            if (formulario.Load(pBingo))//si lo pudi abrir
            {
                cartones = new Queue<CartonBingo>(pBingo.CartonesBingo);
                tLvw.ItemDataBound += delegate(ListViewItem lvwItem, object Item) 
                {
                    lvwItem.SubItems[2].Text = "Pendiente..."; 
                };
                tLvw.DataSource = pBingo.CartonesBingo;
                formulario.Campos.Sort(new Comparison <CamposCarton>(delegate (CamposCarton c1, CamposCarton c2){return (int)c1.Top-c2.Top;}));
            }
            else
            {
                MessageBox.Show("El bingo seleccionado no tiene un diseño de cartón. Ingrese a la opción 'Diseño de Cartón' antes de utilizar la impresión de Cartones.","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            pb.Visible = false;
            
        }        

        private void timeImpresion_Tick(object sender, EventArgs e)
        {            
            CartonBingoManager cartonesForm = new CartonBingoManager();
            if (cartones.Count != 0)
            {
                for (int i = 0; i < formulario.Campos.Count; i++)
                {
                    cartonesForm.Add(cartones.Dequeue()); 
                }
                ImprimirCartones(cartonesForm);   
            }
        }

        private void ImprimirCartones(CartonBingoManager cartonesForm)
        {
            lblMensaje.Text = "Imprimiendo Cartones...";

            mCartonesForm = cartonesForm;
            tLvw.SelectedItems.Clear();
            foreach (CartonBingo cb in cartonesForm)
            {
                foreach (ListViewItem lvi in tLvw.Items)
                {
                    if (((CartonBingo)lvi.Tag).Id == cb.Id)
                    {
                        lvi.SubItems[2].Text = "Impreso";
                        lvi.Selected = true;
                        lvi.EnsureVisible();
                    }
                }
                
            }
            printDoc.Print();
           
        }

        private void ImprimirTablas(CartonBingoManager cartonesForm)
        {
        

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(cmdPlay.Text=="Pausar")cmdPlay_Click(cmdPlay, new EventArgs());//es porq esta imprimiendo 
            if (MessageBox.Show("¿Está seguro de que desea cancelar la impresión?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }            
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Brush strBrush = (formulario.FontColor == 0) ? Brushes.Black : new SolidBrush(Color.FromArgb(formulario.FontColor));
            Font nFont;
           
            e.Graphics.Clear(Color.White);

           
            if (chkImprimirImagen.Checked)
            {
#warning Sacar de aca
                MemoryStream ms = new MemoryStream();
                ms.Write(formulario.Imagen, 0, formulario.Imagen.GetUpperBound(0) + 1);
                e.Graphics.DrawImage(Image.FromStream(ms), new Rectangle(0, 0, Image.FromStream(ms).Width, Image.FromStream(ms).Height));
                ms = null;
            }

            int i = 0;

            foreach (CamposCarton var in formulario.Campos)
            {
                

                float interval = var.Height /(Common.BingoActual.CantidadSorteos + 1);
                StringFormat sF = new StringFormat();
                float fSize = var.Width * 2 / (mCartonesForm[i].Carton.Numeros.Serialize("  ").Length);

                FontStyle fStyle = (formulario.FontBold) ? FontStyle.Bold : FontStyle.Regular;
                string fName = (formulario.FontName == null) ? "Microsoft Sans Serif" : formulario.FontName;
                //strFont = new Font(fName, var.Width * 2 / (cb.Carton.Numeros.Serialize("  ").Length), fStyle, GraphicsUnit.Pixel);

                Font strFont = new Font(fName, fSize, fStyle, GraphicsUnit.Pixel);
                nFont = new Font(fName, fSize - 2, fStyle, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Nº: " + mCartonesForm[i].NroCarton.ToString(), nFont, strBrush, new RectangleF(var.Left + var.Width - 4 * nFont.Size, var.Top - 20, 4 * nFont.Size, 20));  
                // e.Graphics.DrawString(mCartonesForm[i].Carton.Numeros.Serialize(" "), strFont, strBrush, new Point(var.Left, var.Top));//new RectangleF(var.Left ,var.Top,var.Width ,interval));   
                for (int k = 0; k < 10; k++)
                {
                  float tab= (float )(var.Width * 0.1);
                  e.Graphics.DrawString(mCartonesForm[i].Carton.Numeros.GetNumberStr(k), strFont, strBrush, new RectangleF(var.Left + (int)(k* tab )+5, var.Top , var.Width, var.Height ));  
                }
                //strFont = new Font(FontFamily.GenericSansSerif, var.Width * 3 / (mCartonesForm[i].Carton.Numeros.Serialize("  ").Length), GraphicsUnit.Pixel);


                //e.Graphics.DrawString(mCartonesForm[i].Carton.Numeros.Serialize("  "), strFont, strBrush, new RectangleF(var.Left, var.Top, var.Width, interval), sF);
                //for (int j = 1; j <= Common.BingoActual.CantidadSorteos; j++)
                //{
                //    e.Graphics.DrawString(j.ToString(), strFont, strBrush, new RectangleF (var.Left, (var.Top + (j * interval)),strFont.Size*3,interval ));
                //}
                i++;
            }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cartonSeleccionado = (int)((CartonBingo)tLvw.SelectedItem).NroCarton;
            int cantidadCartones = formulario.Campos.Count;
            int cartonInicial = cartonSeleccionado - ((cartonSeleccionado - 1) % cantidadCartones);

            CartonBingoManager cartonesForm = new CartonBingoManager();
            if (Common.BingoActual.CartonesBingo.Count != 0)
            {
                for (int i = 0; i < cantidadCartones; i++)
                {
                    cartonesForm.Add(Common.BingoActual.CartonesBingo.GetByNroCarton(cartonInicial+i));
                }
                ImprimirCartones(cartonesForm);
            }

        }          
       

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;//para los shapes
using System.Text;
using System.Windows.Forms;
using BLBingo;

namespace tbrBingo
{
    public partial class frmSorteoExt : Form
    {

        //------------------------------------------------------------------------------
        List<Label> elementoTabla = new List<Label>();
        List<Label> elementoTablaSombra = new List<Label>();
        List<Label> elementoBolillaLbl = new List<Label>();
        List<PictureBox> elementoBolillaPic = new List<PictureBox>();
        
        Color ColorElementoTabla;
        Color ColorElementoTablaSeleccionado;
        Color ColorFuenteTabla;
        Color ColorFuenteTablaSeleccionado;

        int cTimer = 0;

        int TablaMaximoNumero;
        int CuantasBolillasEntran;
        
        int BolillasMostradas;
        int BolillasElegidas; //andresV para mostrar el total
        //------------------------------------------------------------------------------

        public frmSorteoExt()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------
        //TABLA
        //------------------------------------------------------------------------------
        
        private void CrearTabla(int tablaX, int tablaY, int tablaWidth, int tablaHeight)
        {
            int elementoX;
            int elementoY;
            int contador2;

            picTabla.BackColor = Color.White;// Color.Transparent;//era white
            picTabla.Left = tablaX;
            picTabla.Top = tablaY;
            picTabla.Width = tablaWidth;
            picTabla.Height = tablaHeight;            

            elementoX = 0;
            elementoY = 0;
            contador2 = 0;

            Label elementoAux;

            for (int i = 1; i <= TablaMaximoNumero; i++)
            {
                elementoAux = new Label();
                elementoAux.Left = elementoX;
                elementoAux.Top = elementoY;

                elementoAux.Visible = true;
                elementoAux.BorderStyle = BorderStyle.None;
                //elementoAux.BorderStyle = BorderStyle.FixedSingle;//parace que no agarra la transparencia asi
                
                elementoAux.Text = i.ToString();
                elementoAux.Name = "nn" + i.ToString();
                elementoAux.Height = (picTabla.Height / 10);
                elementoAux.Width = (picTabla.Width / 10);
                elementoAux.Font = new Font("Dirty Headline", 36, FontStyle.Bold);
                elementoAux.BackColor = ColorElementoTabla;
                elementoAux.ForeColor = ColorFuenteTabla;
                elementoAux.TextAlign = ContentAlignment.MiddleCenter;
                elementoAux.BorderStyle = BorderStyle.FixedSingle;

                elementoTabla.Add(elementoAux);

                picTabla.Controls.Add(elementoAux);

                elementoX += elementoAux.Width;
                contador2++;
                if (contador2 > 9) { contador2 = 0; }
                if (contador2 == 0)
                {
                    elementoY += elementoAux.Height;
                    elementoX = 0;
                }

            }//fin del for por todos los labels
            //r = new System.Drawing.Rectangle(2, 2, 50, 50);
            //System.Drawing.Graphics g2 = borderLabel1.CreateGraphics();
            //g2.DrawRectangle(lapiz, r);
            //g2.Dispose();
            //lapiz.Dispose();
            
        }

        private void SeleccionarElementoTabla(int IndexElemento)
        {
            elementoTabla[IndexElemento - 1].BorderStyle = BorderStyle.None;
            elementoTabla[IndexElemento - 1].BackColor = ColorElementoTablaSeleccionado;
            elementoTabla[IndexElemento - 1].ForeColor = ColorFuenteTablaSeleccionado;            
            elementoTabla[IndexElemento - 1].Font = new Font("Dirty Headline", 36, FontStyle.Bold);
            elementoTabla[IndexElemento - 1].Refresh();//SIN ESTO NO ANDA!!!!
            
            //SolidBrush sb = new SolidBrush(Color.Red);
            Pen p = new Pen(Color.Red, 7);
            Graphics g2 = elementoTabla[IndexElemento - 1].CreateGraphics();
            //g2.FillRectangle(sb, new Rectangle(2, 2, 66, 66));
            int wiRect = (elementoTabla[IndexElemento - 1].Width) - (int)p.Width;
            int heRect = (elementoTabla[IndexElemento - 1].Height ) - (int)p.Width;
            //g2.DrawRectangle(p, new Rectangle(1, 1, wiRect, heRect));
            int rad = 4;
            DrawRoundRect(g2, p, 1, 1, wiRect+rad, heRect+rad, rad);

        }

        public void DrawRoundRect(Graphics g, Pen p, float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner
            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2)); // Line
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner
            gp.AddLine(x, y + height - (radius * 2), x, y + radius); // Line
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner
            gp.CloseFigure();

            g.DrawPath(p, gp);
            gp.Dispose();
        }

        //------------------------------------------------------------------------------
        //BOLILLAS
        //------------------------------------------------------------------------------
        private void CrearBolillas(int tablaX, int tablaY, int tablaWidth, int tablaHeight)
        {
            int elementoX;
            int elementoY;
            
            int AnchoBolilla;
            int AltoBolilla;

            AnchoBolilla=picBolilla1.Width;
            AltoBolilla=picBolilla1.Height;
            elementoX = 0;
            elementoY = 0;

            picBolillas.BackColor = Color.Transparent ;//era white!
            picBolillas.Left = tablaX;
            picBolillas.Top = tablaY;
            picBolillas.Width = tablaWidth;
            picBolillas.Height = tablaHeight;

            CuantasBolillasEntran = (tablaWidth / AnchoBolilla);


            Label elementoAux;
            PictureBox elementoPicAux;

            for (int i = 1; i <= CuantasBolillasEntran; i++)
            {
                //Picture
                elementoPicAux = new PictureBox();

                elementoPicAux.Visible = false;
                elementoPicAux.BorderStyle = BorderStyle.None;
                elementoPicAux.Name = "nnPic" + i.ToString();
                elementoPicAux.Height = AnchoBolilla;
                elementoPicAux.Width = AltoBolilla;
                elementoPicAux.Image = picBolilla1.Image;

                elementoPicAux.Left = elementoX;
                elementoPicAux.Top = elementoY;

                elementoBolillaPic.Add(elementoPicAux);
                picBolillas.Controls.Add(elementoPicAux);

                elementoX += AnchoBolilla;
                
                //Label
                elementoAux = new Label();

                elementoAux.Visible = true;
                elementoAux.BringToFront();
                elementoAux.BorderStyle = BorderStyle.None;
                elementoAux.BackColor = Color.Transparent;//andresv para que se vea mejor
                elementoAux.Text = "";
                elementoAux.Name = "nn" + i.ToString();
                elementoAux.Height = (AnchoBolilla);
                elementoAux.Width = (AltoBolilla );
                elementoAux.Font = new Font("Dirty Headline", 39,FontStyle.Bold);
                //elementoAux.BackColor = Color.White;
                elementoAux.ForeColor = Color.Black;
                elementoAux.TextAlign = ContentAlignment.MiddleCenter;

                elementoAux.Left = ((AnchoBolilla / 2)-(elementoAux.Width / 2));
                elementoAux.Top = ((AltoBolilla / 2)-(elementoAux.Height / 2));
                
                elementoBolillaLbl.Add(elementoAux);
                elementoPicAux.Controls.Add(elementoAux);
            }
        }

        private void AgregarBolilla(int NumeroBolilla)
        {
            //int IndexBolillaActual;
            //andresv achica las imagenes
            //esto deberia ir en el diseño pero no estoy seguro de como hacerlo, aqui anda ...
            elementoBolillaPic[0].Width = picBolilla2.Width;
            elementoBolillaPic[0].Height  = picBolilla2.Height ;
            elementoBolillaPic[0].SizeMode = picBolilla2.SizeMode;

            for (int i = BolillasMostradas; i > 0; i--)
            {
                elementoBolillaLbl[i].Text = elementoBolillaLbl[i - 1].Text;
                elementoBolillaPic[i].Visible = true;                
                elementoBolillaPic[i].Image = picBolilla2.Image;
                elementoBolillaPic[i].Width=elementoBolillaPic[0].Width;
                elementoBolillaPic[i].Height = elementoBolillaPic[0].Height;
                elementoBolillaPic[i].SizeMode = elementoBolillaPic[0].SizeMode;
            }

            BolillasMostradas++;
            if (BolillasMostradas >= CuantasBolillasEntran) { BolillasMostradas = CuantasBolillasEntran - 1; }
            
            elementoBolillaLbl[0].Text = Convert.ToString(NumeroBolilla);
            elementoBolillaPic[0].Visible = true;
            BolillasElegidas++;            
            lblBOLS.Text = "Bolillas: " + BolillasElegidas.ToString();

        }

        //------------------------------------------------------------------------------
        //------------------------------------------------------------------------------
        private void RestearBolillas()
        {
            BolillasMostradas = 0;
            BolillasElegidas = 0;//andresV para mostrar el total
            for (int i = 0; i < TablaMaximoNumero; i++)
            {
                elementoTabla[i].BackColor = ColorElementoTabla;
                elementoTabla[i].ForeColor = ColorFuenteTabla;
            }
            for (int i = 0; i < CuantasBolillasEntran; i++)
            {
                elementoBolillaPic[i].Visible = false;
            }


        }
        public void AgregarNumero(int pNumeroBolilla)
        {
            AgregarBolilla(pNumeroBolilla);
            SeleccionarElementoTabla(pNumeroBolilla);
        }

        private void SaleNumero(int NumeroBolilla)
        {
            AgregarBolilla(NumeroBolilla);
            SeleccionarElementoTabla(NumeroBolilla);
        }
        //------------------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            BolillasMostradas = 0;
            TablaMaximoNumero = 90;
            BolillasElegidas = 0;//andresV para mostrar el total

            ColorElementoTabla = Color.DarkGray;
            ColorFuenteTabla = Color.Gray;
            ColorElementoTablaSeleccionado = Color.GreenYellow ;
            ColorFuenteTablaSeleccionado = Color.Black;
            //Original CrearBolillas(5, 50, Convert.ToInt32(this.Width * .9), Convert.ToInt32(this.Width * .18));
            //Original CrearTabla(5, 270, Convert.ToInt32(this.Width * .8), Convert.ToInt32(this.Width * .5));
            CrearBolillas(5, lblHead.Height+70, Convert.ToInt32(this.Width * .9), 160);
            int CorY = picBolilla1.Top + picBolilla1.Height + 90;
            CrearTabla(25, CorY, Convert.ToInt32(this.Width * .95),this.Height - CorY+40);
            //andresV tratando de colocar un nuevo control!
            //lblBOLS.Top = 0;
            lblBOLS.Left = this.Width - lblBOLS.Width - 15;
            lblBOLS.Visible = true;
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd_num = new Random();

            SaleNumero(rnd_num.Next(1,90));
        }

        
        public void SetHead(string pStr)
        {
            lblHead.Text ="Premio: "+ pStr;
        }

        internal void Clear()
        {
            RestearBolillas();            
        }

        internal void NewWinner(BLBingo.CartonGanadorManager cGM)
        {
          //  throw new Exception("The method or operation is not implemented.");
            ctrlGanadores ctrlWinner;
            int c = 0;
            foreach (Control var in this.Controls )
            {
                var.Visible = false;                
            }
            //timer1.Enabled = true;
            //lblBingo.Visible = true;
            picBackGround.Dock = DockStyle.Fill;
            #if DEBUG
                string imagepath = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Graphics\\BackGroundGanador.gif";
            #else
                string imagepath = AppDomain.CurrentDomain.BaseDirectory + @"Graphics\BackGroundGanador.gif";
            #endif
                picBackGround.SizeMode = PictureBoxSizeMode.StretchImage;
                this.BackgroundImageLayout = ImageLayout.Stretch;
           if (System.IO.File.Exists(imagepath))
           {
               picBackGround.Image = Image.FromFile(imagepath);
               this.BackgroundImage = Image.FromFile(imagepath);
           }
           picBackGround.Visible = true;
           picBackGround.SendToBack();
            if (cGM.Count > 1)
            {
                lblGanador.Text = "Ganadores:";
            }
            lblGanador.Visible = true;
            foreach (CartonGanador  var in cGM )
            {
                
                ctrlWinner= new ctrlGanadores(var);
                ctrlWinner.BackColor = Color.Transparent;
                ctrlWinner.Left = lblGanador.Left;
                ctrlWinner.Top= ctrlWinner.Height * c +20 +lblGanador.Top+lblGanador.Height  ;                
                this.Controls.Add(ctrlWinner);
                ctrlWinner.BringToFront();
                c++;
            }
            lblBOLS.Visible = true;//no tengo ni idea por que se va!!!            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (cTimer < 20)
            //{
            //    Font strFont = new Font(FontFamily.GenericSansSerif, 60, GraphicsUnit.Pixel);
            //    Graphics gr = this.CreateGraphics();
            //    Brush strBrush;
            //    if (Math.IEEERemainder(cTimer, 2) == 1)
            //    {
            //        strBrush = Brushes.DarkBlue;
            //    }
            //    else
            //    {
            //        strBrush = Brushes.Red;
            //    }

            //    gr.DrawString("BINGO", strFont, strBrush, new PointF((float)(this.Width * 0.2), (float)(this.Height * 0.3)));
            //    gr.Flush();
            //    cTimer++;
            //}
            //else
            //{
            //    timer1.Enabled = false;
            //    cTimer = 0;
            //}            

        }

        private void picBolillas_Click(object sender, EventArgs e)
        {

        }
    }
}
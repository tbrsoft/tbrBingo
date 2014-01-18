using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BLBingo;
using System.Runtime.InteropServices;

namespace tbrBingo
{
    public partial class frmDiseñoImpresion : Form
    {
        int DY, DX;
        //
        //' Declaraciones del API para 32 bits
        [DllImport("user32.DLL", EntryPoint = "GetWindowLong")]
        static extern int GetWindowLong(
            int hWnd,	// handle to window
            int nIndex	// offset of value to retrieve
        );
        [DllImport("user32.DLL", EntryPoint = "SetWindowLong")]
        static extern int SetWindowLong(
            int hWnd,		// handle to window
            int nIndex,     // offset of value to set
            int dwNewLong	// new value
        );
        [DllImport("user32.DLL", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
            int hWnd,				// handle to window
            int hWndInsertAfter,	// placement-order handle
            int X,					// horizontal position
            int Y,					// vertical position
            int cx,					// width
            int cy,					// height
            uint uFlags				// window-positioning options
        );
        //'
        //' Constantes para usar con el API
        const int GWL_STYLE = (-16);
        const int WS_THICKFRAME = 0x40000; //' Con borde redimensionable
        //'
        const int SWP_DRAWFRAME = 0x20;
        const int SWP_NOMOVE = 0x2;
        const int SWP_NOSIZE = 0x1;
        const int SWP_NOZORDER = 0x4;




        private List<PictureBox > m_Labels = new List<PictureBox >();
        Point pInicial;
        bool dibujando = false;
        int index = 0;
        PictureBox  SelectedLabel = null;
        Bingo mBingo;
        string mImagepath = "";
        FormularioCarton formActual=null;
        
        int n1, n2; //el n es de negrada

        public frmDiseñoImpresion()
        {
            InitializeComponent();
        }

        
        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            //mientars depuro
            //bin = Application.StartupPath  
            //bin/release = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            String fol = Application.StartupPath  + "fondosCartones";

            openFileDialog1.Title = "Buscar una imagen de fondo del carton";
            openFileDialog1.FileName = "elegir una imagen";
            openFileDialog1.InitialDirectory = fol;            
            openFileDialog1.ShowDialog();
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //TODO Verificar que sea una imagen..

            try
            {
                panel.BackgroundImageLayout = ImageLayout.None;
                panel.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                mImagepath = openFileDialog1.FileName;
            }
            catch (Exception)
            {

                MessageBox.Show("El archivo seleccionado no es una imagen valida");
            }
        }

       

        private void cmdAgregarCarton_Click(object sender, EventArgs e)
        {

        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
        }  
        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pInicial = e.Location;
                dibujando = true;
            }
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (dibujando)
            {
                //Graphics g= panel.CreateGraphics();
                //g.Clear(panel.BackColor);
                //g.DrawRectangle(Pens.Blue,new Rectangle(pInicial.X ,pInicial.Y,e.Location.X-pInicial.X ,e.Location.Y-pInicial.Y));
                AgregarCampo(pInicial.X, pInicial.Y, e.Location.X - pInicial.X, e.Location.Y - pInicial.Y);
                dibujando = false;
            }
        }

        private void AgregarCampo(int pLeft, int pTop, int pWidth, int pHeigth)
        {

            if (pWidth > 30 && pHeigth > 20)
            {
                PictureBox L = new PictureBox();

                //asocio los eventos
                //L.MouseDown += new MouseEventHandler(L_MouseDown);
                //L.MouseMove += new MouseEventHandler(L_MouseMove);
                L.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
                L.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
                L.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
                L.SizeChanged += new EventHandler(L_SizeChanged);
                // L.Resize += new EventHandler(L_Resize);
                //propiedades
                L.Tag = index++;
                L.Height = pHeigth < 20 ? 20 : pHeigth;
                L.Width = pWidth < 50 ? 50 : pWidth;
                L.Top = pTop;
                L.Left = pLeft;
                L.BackColor = Color.Transparent;
                L.Visible = true;
                AsignarImagen(L);

                //  L.TextAlign = ContentAlignment.MiddleCenter;
                //  L.Font = this.Font;
                //  L.Text = "Carton";
                panel.Controls.Add(L);
            }
            
            
        }

        void L_SizeChanged(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            if (pic.Height < 20)
            {
                pic.Height = 20;
            }
            if (pic.Width  < 30)
            {
                pic.Height = 30;
            }
            DeseleccionarTodos();
            AsignarImagen(pic,true);
        }

        void L_Resize(object sender, EventArgs e)
        {
            AsignarImagen((PictureBox )sender);
        }

        private void AsignarImagen(PictureBox L)
        {
           AsignarImagen(L, Color.FromArgb(128, 0, 0, 255));
        }
        private void AsignarImagen(PictureBox L,bool Selected)
        {
            if (Selected)
            {
                AsignarImagen(L, Color.FromArgb(128, 0, 255, 0));
            }
            else
            {
                AsignarImagen(L, Color.FromArgb(128, 0, 0, 255));
            }
            
        }
        private void AsignarImagen(PictureBox L,Color cSemiTrans)
        {
            CartonBingo cb= new CartonBingo();
            cb.Carton = new Carton(1, "05;10;20;30;40;50;60;70;80;90");

            Font strFont;
            Bitmap bitmap = new Bitmap(L.Width ,L.Height );
            bitmap.SetResolution(100,100);
            
           // Brush strBrush = B;
           
            Graphics gr = Graphics.FromImage(bitmap);
            gr.Clear(Color.Transparent);
            Pen semiTransPen = new Pen(cSemiTrans, L.Height);
            gr.DrawRectangle(semiTransPen,new Rectangle(0,0,L.Width-1,L.Height-2));
            
            
            
            //strFont = new Font(FontFamily.GenericSansSerif, L.Width * 2 / (cb.Carton.Numeros.Serialize("  ").Length), GraphicsUnit.Pixel);
            Brush strBrush = (formActual.FontColor == 0) ? Brushes.Black : new SolidBrush(Color.FromArgb(formActual.FontColor));
            FontStyle fStyle = (fontDialog1.Font.Bold) ? FontStyle.Bold : FontStyle.Regular;
            string fName = (formActual.FontName == null) ? "Microsoft Sans Serif" : formActual.FontName;
            strFont = new Font(fName, L.Width * 2 / (cb.Carton.Numeros.Serialize("  ").Length), fStyle, GraphicsUnit.Pixel);
              
            
            for (int k = 0; k < 10; k++)
            {
                float tab = (float)(L.Width * 0.1);
                gr.DrawString(cb.Carton.Numeros.GetNumberStr(k), strFont, strBrush, new RectangleF((k * tab) + 5,0, L.Width, L.Height ));
            }
            gr.Dispose();

            L.Image = bitmap;
            
        }
      

        void L_MouseMove(object sender, MouseEventArgs e)
        {
            if ((PictureBox )sender == SelectedLabel)
            {
                Cursor = Cursors.SizeAll;
            }
            else
            {
                Cursor = Cursors.Default;
            }
            if (e.Button == MouseButtons.Left)
            {
                pInicial = e.Location;
                n1 = e.X ;
                n2 = e.Y ;
                ((Label)sender).DoDragDrop(((Label)sender).Tag, DragDropEffects.Move);
            }            
        }

        void L_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SelectedLabel = (PictureBox )sender;
                DeseleccionarTodos();
                SelectedLabel.BackColor = Color.Green;
            }
        }

        private void DeseleccionarTodos()
        {
            foreach (Control c in panel.Controls)
            {
            //    c.BackColor = Color.Gray;
                AsignarImagen((PictureBox )c, false);
            }

        }

        private void panel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void panel_DragDrop(object sender, DragEventArgs e)
        {
            int index = (int)e.Data.GetData(typeof(int));
            Label L = null;
            foreach (Control c in panel.Controls)
            {
                if (((int)c.Tag) == index)
                {
                    L = (Label)c;
                    break;
                }
            }
            //
            L.Left = e.X -n1- panel.PointToScreen(panel.Location).X + panel.Parent.Padding.Left;
            L.Top = e.Y -n2- panel.PointToScreen(panel.Location).Y + toolStrip1.Height + panel.Parent.Padding.Top;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (SelectedLabel != null)
            {
                panel.Controls.Remove(SelectedLabel);
            }
        }

        private void guardarToolStripButton_Click(object sender, EventArgs e)
        {


            //manu-------------------------------
            //formActual = new FormularioCarton();
            //mBingo = pBingo;
            //-----------------------------------
            if (mImagepath != "")
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] abImagen = new byte[fs.Length];
                br.Read(abImagen, 0, (int)fs.Length);
                br.Close();
                fs.Close();
                formActual.Imagen = abImagen;
            }

            formActual.FontName = fontDialog1.Font.Name;
            formActual.FontSize = fontDialog1.Font.Size;
            formActual.FontColor = fontDialog1.Color.ToArgb();
            formActual.FontBold = fontDialog1.Font.Bold;

            formActual.Campos = GetCampos();
            formActual.Save(mBingo);//TODO estaria buieno que se pueda grabar como archivo al disco para poder reutilizar en otros bingos
            
        }

        private List<CamposCarton> GetCampos()
        {
            List<CamposCarton> campos = new List<CamposCarton>();
            CamposCarton cc;
            foreach (Control c in panel.Controls)
            {
                cc = new CamposCarton();
                cc.Height = c.Height;
                cc.Left = c.Left;
                cc.Top = c.Top;
                cc.Width = c.Width;
                campos.Add(cc);
            }
            return campos; 
        }

        public void AbrirDiseño(Bingo pBingo)
        {
            this.Icon = Common.Icono;
            formActual = new FormularioCarton();
            mBingo = pBingo;
            this.Show();
            if (formActual.Load(pBingo))//si se pudo abrir
            {
                if (formActual.Imagen != null)
                {
                    //cargo la imagen
                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        ms.Write(formActual.Imagen, 0, formActual.Imagen.GetUpperBound(0) + 1);

                        panel.BackgroundImageLayout = ImageLayout.None;                        
                        panel.BackgroundImage = System.Drawing.Image.FromStream(ms);
                      //  ms.Close();
                        ms = null;
                    }
                    catch
                    {
                        
                    }
                    
                    if(formActual.FontName!=""){

                    }
                }

                CrearCampos(formActual.Campos);
            }
            
            
        }

        private void CrearCampos(List<CamposCarton> list)
        {
            foreach (CamposCarton  cc in list)
            {
                AgregarCampo(cc.Left, cc.Top, cc.Width, cc.Height);   
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDiseñoImpresion_KeyUp(object sender, KeyEventArgs e)
        {
            if (SelectedLabel != null)
            {


                if (e.KeyCode == Keys.Delete)
                {
                    panel.Controls.Remove(SelectedLabel);

                }else if (e.KeyCode == Keys.Left)
                {
                    SelectedLabel.Left -= 1;
                }else if (e.KeyCode == Keys.Right)
                {
                    SelectedLabel.Left+=1;
                }else if (e.KeyCode == Keys.Up)
                {
                    SelectedLabel.Top-=1;
                }else if (e.KeyCode == Keys.Down )
                {
                    SelectedLabel.Top +=1;
                }
                else if (e.KeyCode == Keys.Subtract)
                {
                    SelectedLabel.Width -=1;
                    SelectedLabel.Height -= 1;
                }
                else if (e.KeyCode == Keys.Add)
                {
                    SelectedLabel.Width += 1;
                    SelectedLabel.Height += 1;
                }
            }
        }

        private void frmDiseñoImpresion_Load(object sender, EventArgs e)
        {
            formActual = new FormularioCarton();
        }

        private void ayudaToolStripButton_Click(object sender, EventArgs e)
        {
            ((MDI)(MdiParent)).ShowHelp("diseñoimpresion.htm");
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            CartonBingo cb = new CartonBingo();
            cb.Carton=new Carton(1,"05;10;20;30;40;50;60;70;80;90");

            Font strFont;

           // Brush strBrush = new SolidBrush(Color.FromArgb(formActual.FontColor ));//Brushes.Black ;
          
            e.Graphics.Clear(Color.White);
            Brush strBrush = (formActual.FontColor == 0) ? Brushes.Black : new SolidBrush(Color.FromArgb(formActual.FontColor));
            if(panel.BackgroundImage!=null)e.Graphics.DrawImage(panel.BackgroundImage, new Rectangle(0, 0, panel.BackgroundImage.Width, panel.BackgroundImage.Height));
            
            foreach (CamposCarton var in GetCampos())
            {
                int i = 0;

                float interval = var.Height / (Common.BingoActual.CantidadSorteos + 1);
                StringFormat sF = new StringFormat();
                float fSize = var.Width * 2 / (cb.Carton.Numeros.Serialize("  ").Length);
                FontStyle fStyle = (fontDialog1.Font.Bold) ? FontStyle.Bold : FontStyle.Regular;
                string fName = (formActual.FontName == null) ? "Microsoft Sans Serif" : formActual.FontName;
                strFont = new Font(fName , fSize ,fStyle, GraphicsUnit.Pixel);
              
                //  strFont = new Font(FontFamily.GenericSansSerif, var.Width * 2 / (cb.Carton.Numeros.Serialize("  ").Length), GraphicsUnit.Pixel);
              
               Font  nFont = new Font(fName, fSize - 2, fStyle, GraphicsUnit.Pixel);
                
                e.Graphics.DrawString("Nº: " + "1234", nFont, strBrush, new RectangleF(var.Left + var.Width - 4 * nFont.Size, var.Top - 20, 4 * nFont.Size, 20));  
                for (int k = 0; k < 10; k++)
                {
                    float tab = (float)(var.Width * 0.1);
                    e.Graphics.DrawString(cb.Carton.Numeros.GetNumberStr(k), strFont,strBrush, new RectangleF(var.Left + (int)(k * tab) + 5, var.Top, var.Width, var.Height ));                    
                }

                //for (int j = 1; j <= Common.BingoActual.CantidadSorteos; j++)
                //{
                //    e.Graphics.DrawString(j.ToString(), strFont, strBrush, new RectangleF(var.Left, (var.Top + (j * interval)), strFont.Size * 3, interval));
                //}
                //i++;
            }
        }

        private void imprimirToolStripButton_Click(object sender, EventArgs e)
        {
            printDoc.PrintPage+=new System.Drawing.Printing.PrintPageEventHandler(printDoc_PrintPage);
           

            printPreview.ShowDialog();
        }

        void CambiarEstilo(Control aControl)
        {
            //' Hacer este control redimensionable, usando el API
            //' Pone o quita el estilo dimensionable
            int Style;
            //'
            //' Si se produce un error, no hacer nada...
            try
            {
                Style = GetWindowLong(aControl.Handle.ToInt32(), GWL_STYLE);
                if ((Style & WS_THICKFRAME) == WS_THICKFRAME) // & = And
                {
                    //' Si ya lo tiene, lo quita
                    Style = Style ^ WS_THICKFRAME; // ^ = Xor
                }
                else
                {
                    //' Si no lo tiene, lo pone
                    Style = Style | WS_THICKFRAME; // | = Or
                }
                SetWindowLong(aControl.Handle.ToInt32(), GWL_STYLE, Style);
                SetWindowPos(aControl.Handle.ToInt32(), this.Handle.ToInt32(), 0, 0, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_NOMOVE | SWP_DRAWFRAME);
            }
            catch //(Exception e)
            {
                //MessageBox.Show(e.Message ); 
                //MessageBox.Show("El control " + aControl.Name + " no permite que se redimensione","",MessageBoxButtons.OK ,MessageBoxIcon.Warning  );
            }
        }
        private void Control_MouseDown(
                object sender,
                System.Windows.Forms.MouseEventArgs e)
        {
            //' Cuando se pulsa con el ratón
            DX = e.X;
            DY = e.Y;
            //' Al pulsar con el botón derecho, 
            //' cambiar el estilo entre redimensionable y normal
            Control elControl = (Control)sender;
            //lblStatus.Text = "Control: " + elControl.Name ;
            if (e.Button == MouseButtons.Right)
            {
                CambiarEstilo(elControl);
            }
            else
            {
                //' Cuando se pulsa en un control, posicionarlo encima del resto
                SelectedLabel = (PictureBox)sender;
                DeseleccionarTodos();
                AsignarImagen(SelectedLabel, true);
                elControl.BringToFront();
            }
        }

        private void Control_MouseMove(
                object sender,
                System.Windows.Forms.MouseEventArgs e)
        {
            //' Cuando se mueve el ratón... mover el control
            if (e.Button == MouseButtons.Left)
            {
                Control elControl = (Control)sender;
                elControl.Left = e.X + elControl.Left - DX;
                elControl.Top = e.Y + elControl.Top - DY;
            }
        }

        private void Control_MouseEnter(
                object sender,
                System.EventArgs e)
        {
            Control elControl = (Control)sender;
           // lblStatus.Text = "Control: " + elControl.Name;
        }

    

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
            fontDialog1.ShowColor = true;
            
            fontDialog1.ShowDialog();
            formActual.FontName = fontDialog1.Font.Name;
            formActual.FontSize = fontDialog1.Font.SizeInPoints;
            formActual.FontColor = fontDialog1.Color.ToArgb();
            formActual.FontBold = fontDialog1.Font.Bold;
            DeseleccionarTodos();
            
          
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            formActual.FontName = fontDialog1.Font.Name;
            formActual.FontSize = fontDialog1.Font.SizeInPoints;
            formActual.FontColor = fontDialog1.Color.ToArgb();
            formActual.FontBold = fontDialog1.Font.Bold;
        }

               
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication5
{
    public partial class tBingo : UserControl
    {
        public tBingo()
        {
            InitializeComponent();
        }
        Font fSelected;
        Font fNormal;
        public void newNumber(int n)
        {
            foreach (Control var in this.Controls )
            {
                if ((int)var.Tag == n)
                {
                    var.BackColor = Color.DarkBlue;
                    var.Font = fSelected;
                    var.ForeColor = Color.LightGray;
                }
            }
        }
        List<Control> cList;
        private void tBingo_Load(object sender, EventArgs e)
        {
            
            cList= new List<Control>();
            for (int i = 0; i < 9; i++)
            {
                Label l;
                for (int j = 0; j < 10; j++)
                {
                    int aux = i * 10 + j + 1;
                    l = new Label();
                   

                    l.Tag = aux;
                    l.Text = aux.ToString().Length < 2 ? "0" + aux.ToString() : aux.ToString();
                    l.TextAlign = ContentAlignment.MiddleCenter;
                    l.BorderStyle = BorderStyle.Fixed3D;
                    
                    this.Controls.Add(l);
                    cList.Add(l);

                }
            }
            DistribuirControles();

        }

        private void DistribuirControles()
        {
            if (cList != null)
            {
                
                int h = (this.Height / 9);

                int w = (this.Width / 10);
                fSelected = new Font(FontFamily.GenericSansSerif, w*2 /5 , FontStyle.Bold, GraphicsUnit.Pixel);
                fNormal = new Font(FontFamily.GenericSansSerif, w*2/5,FontStyle.Bold, GraphicsUnit.Pixel);


                

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        int aux = i * 10 + j + 1;

                        cList[aux - 1].Height = h;
                        cList[aux - 1].Width = w;
                        cList[aux - 1].Top = i * h;
                        cList[aux - 1].Left = j * w;
                        cList[aux - 1].Font = fNormal;
                    }
                }

            }
        }

        private void tBingo_Resize(object sender, EventArgs e)
        {
            DistribuirControles();
        }
    }
}

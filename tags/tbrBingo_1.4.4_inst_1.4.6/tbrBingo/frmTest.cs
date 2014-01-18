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
    //public partial class frmTest : Form
    //{
    //    public frmTest()
    //    {
    //        InitializeComponent();
    //    } 


       
    
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }
        Bolillero b = null;

        private void pantGanador()
        {
            frmSorteoExt frm = new frmSorteoExt();
            frm.Show();
            CartonGanador cG = new CartonGanador();
            cG.Carton = Common.BingoActual.CartonesBingo[0];
            CartonGanadorManager c = new CartonGanadorManager();
            c.Add(cG);
            cG = new CartonGanador();
            cG.Carton = Common.BingoActual.CartonesBingo[1];
            c.Add(cG);
            
            frm.NewWinner(c);
            //DataTable dt = CartonBingoManager.GetDatatable();
            //dt.TableName = "Cartones";
            //dt.WriteXml(@"E:\tbrsoft\prueba.xml");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            generate10000();
           // LicenciaBasica.LicenciaBasica.HabilitarLicencia("I:\\bingo.lic"); 

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //string aux =b.ExtractedNumbers.Serialize();
            //tList t = new tList();
            //t.Load(aux);
            //textBox2.Text = t.Serialize();

            StringBuilder str = new StringBuilder();
            for (int i = 0; i < 30000; i++)
            {
                str.Append("a" + i.ToString());
            }

           // textBox2.Text = str.ToString();
        }

        private void generate10000()
        {
            CartonManager cm = new CartonManager();
            cm = cm.Generate(50000);
            cm.Save();

            //  foreach (Carton c in cm)
            //  {
            //      textBox1.Text += c.Numeros.Serialize() + "\n\t";
            //      textBox1.Refresh();
            //  }

            //  //ver la distribucion de numeros
            ////  List<int> dist = new List<int>(91);
            //  int[] dist = new int[91];
            //  foreach (Carton c in cm)
            //  {
            //      foreach (int s in c.Numeros)
            //      {
            //          dist[s]++;
            //      }

            //  }

            //  for (int i=1; i <= 90; i++ )
            //      {
            //          textBox1.Text += i.ToString() + "= " + dist[i].ToString() + "\n\t";                
            //      }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pantGanador();
        }
    }




}
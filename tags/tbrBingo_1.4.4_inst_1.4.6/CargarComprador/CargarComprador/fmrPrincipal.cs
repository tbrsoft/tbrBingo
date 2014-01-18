using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using CargarComprador.Properties;
using System.IO;


namespace CargarComprador
{
    public partial class fmrPrincipal : Form
    {
        public fmrPrincipal()
        {
            InitializeComponent();
        }

        DataSet ds;

        private void Form1_Load(object sender, EventArgs e)
        {   
            ResizeDGrid();
           
            if (Settings.Default.xmlFileName != "")
            {
                llenarDGrid();
            }
             // dt.ReadXml();
            //dGridView.DataSource ;

        }

        private void ResizeDGrid()
        {
            foreach (DataGridViewColumn  var in dGridView.Columns  )
            {
                var.Width = (int) Settings.Default[var.Name];
                
            } 
            
        }

        private void SaveDGridColumsWidth()
        {
            foreach (DataGridViewColumn var in dGridView.Columns)
            {
                if (var.Name != "idBingo" && var.Name != "idvendedor")
	            {
                    Settings.Default[var.Name] = var.Width;
                }
        
            }
            Settings.Default.Save();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDGridColumsWidth();

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string  xmlFile = openFileDialog1.FileName;
            Settings.Default.xmlFileName = xmlFile;
            llenarDGrid(); 
        }

        private void llenarDGrid()
        {
            ds = new DataSet();
            ds.ReadXml(Settings.Default.xmlFileName);

            ds.Tables[0].Rows[ds.Tables[0].Rows.Count-1].Delete();

            dGridView.DataSource = ds.Tables[0];
            foreach (DataGridViewColumn var in dGridView.Columns)
            {
                if (var.Name == "idBingo" || var.Name == "idvendedor")
                {
                    var.Visible = false;
                }
            }
          

        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            saveFileDialog1.FileName = Settings.Default.xmlFileName;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (Guardar())
            {
                File.Copy(Settings.Default.xmlFileName, saveFileDialog1.FileName, true);
                dGridView.SelectAll();
                dGridView.ClearSelection();
                llenarDGrid();
                Settings.Default.xmlFileName = "";
            }            
        }

        private void dGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private bool Guardar()
        {
            bool ret = false;
            if (Settings.Default.xmlFileName == "")
            {
                MessageBox.Show("No tiene abierto ningun archivo");
            }
            else
            {
                ret = true;
                //DataTable dt =(DataTable) dGridView.DataSource;
                DataRow dr = ds.Tables[0].NewRow();
                dr["nombre"] = "-";
                dr["apellido"]="-";
                dr["observaciones"]="-";
                dr["mail"]="-";
                dr["direccion"]="-";
                dr["telefono"] = "-";
                dr["dni"] = "-";
                ds.Tables[0].Rows.Add(dr);
                ds.WriteXml(Settings.Default.xmlFileName);
            }
            return ret;
        }

        private void dGridView_Leave(object sender, EventArgs e)
        {
            dGridView.Refresh();
        }

        private void contenidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelp frm = new frmHelp();
            frm.Show();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.Show();
        }
    }
}
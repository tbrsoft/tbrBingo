using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using BLBingo;

namespace tbrBingo
{
    public delegate void tbrProgressEventHandler(int pProgress);
    public delegate void tbrItemDataBoundEventHandler(ListViewItem lvwItem, object Item);

    public partial class tbrListView : ListView 
    {
        private bool  m_ColumnAutoResize;

        public bool ColumnAutoResize
        {
            get { return m_ColumnAutoResize; }
            set { m_ColumnAutoResize = value; AutoResizeColumns();}
        }

        //public event tbrSelectedItemEventHandler<object> ItemSelected;
        public event tbrSelectedItemEventHandler<object> ItemDblClick;
        public event tbrItemDataBoundEventHandler ItemDataBound;
        public event tbrProgressEventHandler Progressing;

        public tbrListView()
        {
            InitializeComponent();
            this.View = View.Details;
            this.FullRowSelect = true;
            
            //dobleclick en un item
            this.ItemActivate += new EventHandler(tbrListView_DblClick);
            this.Resize += new EventHandler(tbrListView_Resize);
        }

        void tbrListView_Resize(object sender, EventArgs e)
        {
            AutoResizeColumns();
        }

        private void AutoResizeColumns()
        {
            if (ColumnAutoResize)
            {
#warning hacer el autoresize
            }
        }

        private object m_DataSource;

        public object DataSource
        {
            get { return m_DataSource; }
            set { m_DataSource = value; DataBind(); }
        }
        /// <summary>
        /// Devuelve el item seleccionado del tipo de dato de la coleccion.
        /// </summary>
        public object SelectedItem
        {
            get
            {
                if (SelectedItems.Count > 0)
                {
                    return SelectedItems[0].Tag;
                }
                else return null;
            }
            set
            {                
                foreach (ListViewItem lvi in this.Items)
                {
                    if (lvi.Tag.Equals(value))
                    {
                        this.SelectedItems.Clear();
                        lvi.Selected = true;
                    }
                }
            }
        }


        void tbrListView_DblClick(object sender, EventArgs e)
        {
            if (ItemDblClick != null)
            {
                 ItemDblClick(this.SelectedItems[0].Tag);
            }
        }       

        private void DataBind()
        {
            bool first = true;
            ListViewItem lvi=null;
            int i = 0;
            if (m_DataSource is IList)
            {
                this.Items.Clear();
                foreach (object v in ((IList)m_DataSource))
                {
                    first = true;
                    foreach (ColumnHeader ch in this.Columns)
                    {
                        if (first)
                        {
                            lvi=this.Items.Add(GetValue(v,ch.Tag));
                                                       
                            lvi.Tag = v;
                            first = false;
                        }
                        else
                        {
                            lvi.SubItems.Add(GetValue(v, ch.Tag));
                        }
                    }
                    //cuando llene los items, llamo a este evento por si quieren cambiar el valor
                    if (ItemDataBound != null)
                    {
                        ItemDataBound(lvi, v);
                    }
                    //indico que hay progreso...
                    if(Progressing!=null)
                    {
                        Progressing(i++);
                    }
                }
            }            
        }

        private string GetValue(object obj, object prop)
        {
            string val="";
            object valObj;
            if (prop==null)
	        {
                val = "";
            }
            else
            {
                Type t = obj.GetType();
                PropertyInfo pi;
                pi = t.GetProperty(prop.ToString());
                if (pi != null)
                {
                    valObj = pi.GetGetMethod().Invoke(obj, null);
                    if (valObj == null)
                    {
                        val = "";
                    }
                    else
                    {
                        val = valObj.ToString();
                    }
                }
                else
                {
                    if (obj is IListable)
                    {
                        val=((IListable)obj).GetProperty(prop.ToString()); 
                    } 
                }
            }            
#warning ver que hacer si no encuentra la propiedad
            return val;
        }

    }
}

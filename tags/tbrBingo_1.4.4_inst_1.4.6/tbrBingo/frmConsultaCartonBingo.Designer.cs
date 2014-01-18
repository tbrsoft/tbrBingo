namespace tbrBingo
{
    partial class frmConsultaCartonBingo
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaCartonBingo));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdVender = new System.Windows.Forms.ToolStripButton();
            this.cmdCancelarVenta = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdImportar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dropVendedor = new System.Windows.Forms.ToolStripComboBox();
            this.cmdExportar = new System.Windows.Forms.ToolStripButton();
            this.cmdExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cdSave = new System.Windows.Forms.SaveFileDialog();
            this.cdOpen = new System.Windows.Forms.OpenFileDialog();
            this.lvw = new tbrBingo.tbrListView();
            this.chNroCarton = new System.Windows.Forms.ColumnHeader();
            this.chNumeros = new System.Windows.Forms.ColumnHeader();
            this.chVendedor = new System.Windows.Forms.ColumnHeader();
            this.chComprador = new System.Windows.Forms.ColumnHeader();
            this.chEstado = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdVender,
            this.cmdCancelarVenta,
            this.toolStripSeparator1,
            this.cmdRefresh,
            this.toolStripSeparator3,
            this.cmdImportar,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.dropVendedor,
            this.cmdExportar,
            this.cmdExportarExcel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(646, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";            
            // 
            // cmdVender
            // 
            this.cmdVender.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdVender.Image = ((System.Drawing.Image)(resources.GetObject("cmdVender.Image")));
            this.cmdVender.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdVender.Name = "cmdVender";
            this.cmdVender.Size = new System.Drawing.Size(23, 22);
            this.cmdVender.Text = "toolStripButton1";
            this.cmdVender.ToolTipText = "Registrar Venta";
            this.cmdVender.Click += new System.EventHandler(this.cmdVender_Click);
            // 
            // cmdCancelarVenta
            // 
            this.cmdCancelarVenta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdCancelarVenta.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelarVenta.Image")));
            this.cmdCancelarVenta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCancelarVenta.Name = "cmdCancelarVenta";
            this.cmdCancelarVenta.Size = new System.Drawing.Size(23, 22);
            this.cmdCancelarVenta.Text = "Anular Venta";
            this.cmdCancelarVenta.ToolTipText = "Cancelar Venta de Carton";
            this.cmdCancelarVenta.Click += new System.EventHandler(this.cmdCancelarVenta_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdRefresh.Image = ((System.Drawing.Image)(resources.GetObject("cmdRefresh.Image")));
            this.cmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(23, 22);
            this.cmdRefresh.Text = "toolStripButton1";
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // cmdImportar
            // 
            this.cmdImportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdImportar.Image = ((System.Drawing.Image)(resources.GetObject("cmdImportar.Image")));
            this.cmdImportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdImportar.Name = "cmdImportar";
            this.cmdImportar.Size = new System.Drawing.Size(23, 22);
            this.cmdImportar.Text = "toolStripButton1";
            this.cmdImportar.ToolTipText = "Importar datos de Ventas";
            this.cmdImportar.Click += new System.EventHandler(this.cmdImportar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(57, 22);
            this.toolStripLabel1.Text = "Vendedor:";
            // 
            // dropVendedor
            // 
            this.dropVendedor.Name = "dropVendedor";
            this.dropVendedor.Size = new System.Drawing.Size(121, 25);
            this.dropVendedor.SelectedIndexChanged += new System.EventHandler(this.dropVendedor_SelectedIndexChanged);
            // 
            // cmdExportar
            // 
            this.cmdExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdExportar.Image = ((System.Drawing.Image)(resources.GetObject("cmdExportar.Image")));
            this.cmdExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdExportar.Name = "cmdExportar";
            this.cmdExportar.Size = new System.Drawing.Size(23, 22);
            this.cmdExportar.Text = "toolStripButton2";
            this.cmdExportar.ToolTipText = "Exportar datos de Ventas";
            this.cmdExportar.Click += new System.EventHandler(this.cmdExportar_Click);
            // 
            // cmdExportarExcel
            // 
            this.cmdExportarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("cmdExportarExcel.Image")));
            this.cmdExportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdExportarExcel.Name = "cmdExportarExcel";
            this.cmdExportarExcel.Size = new System.Drawing.Size(23, 22);
            this.cmdExportarExcel.Text = "Exportar Cartones a Excel";
            this.cmdExportarExcel.Click += new System.EventHandler(this.cmdExportarExcel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvw);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 289);
            this.panel1.TabIndex = 2;
            // 
            // cdSave
            // 
            this.cdSave.DefaultExt = "tbrb";
            this.cdSave.Filter = "Archivo de bingo (*.tbrb)|*.tbrb";
            // 
            // cdOpen
            // 
            this.cdOpen.DefaultExt = "tbrb";
            this.cdOpen.Filter = "Archivo de bingo (*.tbrb)|*.tbrb|Archivo Excel (*.xls)|*.xls";
            // 
            // lvw
            // 
            this.lvw.ColumnAutoResize = false;
            this.lvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNroCarton,
            this.chNumeros,
            this.chVendedor,
            this.chComprador,
            this.chEstado});
            this.lvw.DataSource = null;
            this.lvw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvw.FullRowSelect = true;
            this.lvw.Location = new System.Drawing.Point(0, 0);
            this.lvw.Name = "lvw";
            this.lvw.SelectedItem = null;
            this.lvw.Size = new System.Drawing.Size(646, 289);
            this.lvw.TabIndex = 0;
            this.lvw.UseCompatibleStateImageBehavior = false;
            this.lvw.View = System.Windows.Forms.View.Details;
            // 
            // chNroCarton
            // 
            this.chNroCarton.Tag = "NroCarton";
            this.chNroCarton.Text = "Nº Carton";
            // 
            // chNumeros
            // 
            this.chNumeros.Tag = "CartonNumeros";
            this.chNumeros.Text = "Numeros del Carton";
            this.chNumeros.Width = 113;
            // 
            // chVendedor
            // 
            this.chVendedor.Tag = "gpVendedor";
            this.chVendedor.Text = "Vendedor";
            this.chVendedor.Width = 130;
            // 
            // chComprador
            // 
            this.chComprador.Tag = "gpComprador";
            this.chComprador.Text = "Comprador";
            this.chComprador.Width = 133;
            // 
            // chEstado
            // 
            this.chEstado.Tag = "Estado";
            this.chEstado.Text = "Estado";
            this.chEstado.Width = 67;
            // 
            // frmConsultaCartonBingo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 314);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmConsultaCartonBingo";
            this.Text = "Listado de Cartones";
            this.Load += new System.EventHandler(this.frmConsultaCartonBingo_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private tbrListView lvw;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ColumnHeader chNroCarton;
        private System.Windows.Forms.ColumnHeader chNumeros;
        private System.Windows.Forms.ColumnHeader chVendedor;
        private System.Windows.Forms.ColumnHeader chComprador;
        private System.Windows.Forms.ColumnHeader chEstado;
        private System.Windows.Forms.ToolStripButton cmdVender;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton cmdImportar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox dropVendedor;
        private System.Windows.Forms.ToolStripButton cmdExportar;
        private System.Windows.Forms.SaveFileDialog cdSave;
        private System.Windows.Forms.OpenFileDialog cdOpen;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton cmdCancelarVenta;
        private System.Windows.Forms.ToolStripButton cmdRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton cmdExportarExcel;        
    }
}
namespace tbrBingo
{
    partial class frmConsultaBingos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaBingos));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nuevoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.abrirToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ayudaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoSorteoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvw = new tbrBingo.tbrListView();
            this.chFecha = new System.Windows.Forms.ColumnHeader();
            this.chNombre = new System.Windows.Forms.ColumnHeader();
            this.chCantidadSorteos = new System.Windows.Forms.ColumnHeader();
            this.chEstado = new System.Windows.Forms.ColumnHeader();
            this.chForm = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripButton,
            this.abrirToolStripButton,
            this.toolStripSeparator,
            this.ayudaToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(615, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuevoToolStripButton
            // 
            this.nuevoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nuevoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripButton.Image")));
            this.nuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuevoToolStripButton.Name = "nuevoToolStripButton";
            this.nuevoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.nuevoToolStripButton.Text = "&Nuevo";
            this.nuevoToolStripButton.ToolTipText = "Nuevo Bingo";
            this.nuevoToolStripButton.Click += new System.EventHandler(this.nuevoToolStripButton_Click);
            // 
            // abrirToolStripButton
            // 
            this.abrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.abrirToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripButton.Image")));
            this.abrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abrirToolStripButton.Name = "abrirToolStripButton";
            this.abrirToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.abrirToolStripButton.Text = "&Abrir";
            this.abrirToolStripButton.ToolTipText = "Abrir Bingo";
            this.abrirToolStripButton.Click += new System.EventHandler(this.abrirToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // ayudaToolStripButton
            // 
            this.ayudaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ayudaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ayudaToolStripButton.Image")));
            this.ayudaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ayudaToolStripButton.Name = "ayudaToolStripButton";
            this.ayudaToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ayudaToolStripButton.Text = "Ay&uda";
            this.ayudaToolStripButton.Click += new System.EventHandler(this.ayudaToolStripButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoSorteoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 26);
            // 
            // nuevoSorteoToolStripMenuItem
            // 
            this.nuevoSorteoToolStripMenuItem.Name = "nuevoSorteoToolStripMenuItem";
            this.nuevoSorteoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.nuevoSorteoToolStripMenuItem.Text = "Nuevo Sorteo...";
            this.nuevoSorteoToolStripMenuItem.Click += new System.EventHandler(this.nuevoSorteoToolStripMenuItem_Click);
            // 
            // lvw
            // 
            this.lvw.AllowColumnReorder = true;
            this.lvw.ColumnAutoResize = false;
            this.lvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFecha,
            this.chNombre,
            this.chCantidadSorteos,
            this.chEstado,
            this.chForm});
            this.lvw.DataSource = null;
            this.lvw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvw.FullRowSelect = true;
            this.lvw.Location = new System.Drawing.Point(0, 25);
            this.lvw.Name = "lvw";
            this.lvw.SelectedItem = null;
            this.lvw.Size = new System.Drawing.Size(615, 388);
            this.lvw.TabIndex = 3;
            this.lvw.UseCompatibleStateImageBehavior = false;
            this.lvw.View = System.Windows.Forms.View.Details;
            this.lvw.ItemDataBound += new tbrBingo.tbrItemDataBoundEventHandler(this.lvw_ItemDataBound);
            this.lvw.SelectedIndexChanged += new System.EventHandler(this.lvw_SelectedIndexChanged_1);
            // 
            // chFecha
            // 
            this.chFecha.Tag = "";
            this.chFecha.Text = "Fecha";
            this.chFecha.Width = 84;
            // 
            // chNombre
            // 
            this.chNombre.Tag = "Nombre";
            this.chNombre.Text = "Nombre";
            this.chNombre.Width = 203;
            // 
            // chCantidadSorteos
            // 
            this.chCantidadSorteos.Tag = "CantidadSorteos";
            this.chCantidadSorteos.Text = "Cantidad Sorteos";
            this.chCantidadSorteos.Width = 100;
            // 
            // chEstado
            // 
            this.chEstado.Tag = "EstadoBingo";
            this.chEstado.Text = "Estado";
            this.chEstado.Width = 100;
            // 
            // chForm
            // 
            this.chForm.Text = "Diseñado";
            // 
            // frmConsultaBingos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 413);
            this.Controls.Add(this.lvw);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmConsultaBingos";
            this.Text = "Consulta de Bingos";
            this.Load += new System.EventHandler(this.frmConsultaBingos_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton nuevoToolStripButton;
        private System.Windows.Forms.ToolStripButton abrirToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton ayudaToolStripButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoSorteoToolStripMenuItem;
        private tbrListView lvw;
        private System.Windows.Forms.ColumnHeader chFecha;
        private System.Windows.Forms.ColumnHeader chNombre;
        private System.Windows.Forms.ColumnHeader chCantidadSorteos;
        private System.Windows.Forms.ColumnHeader chForm;
        private System.Windows.Forms.ColumnHeader chEstado;
    }
}
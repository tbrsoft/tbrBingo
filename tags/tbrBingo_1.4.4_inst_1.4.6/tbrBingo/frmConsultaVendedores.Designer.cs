namespace tbrBingo
{
    partial class frmConsultaVendedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaVendedores));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nuevoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ayudaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.lvwVendedores = new tbrBingo.tbrListView();
            this.chNombre = new System.Windows.Forms.ColumnHeader();
            this.chApellido = new System.Windows.Forms.ColumnHeader();
            this.chDireccion = new System.Windows.Forms.ColumnHeader();
            this.chMail = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripButton,
            this.editarToolStripButton,
            this.toolStripSeparator,
            this.ayudaToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(558, 25);
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
            this.nuevoToolStripButton.ToolTipText = "Nuevo Vendedor";
            this.nuevoToolStripButton.Click += new System.EventHandler(this.nuevoToolStripButton_Click);
            // 
            // editarToolStripButton
            // 
            this.editarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("editarToolStripButton.Image")));
            this.editarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editarToolStripButton.Name = "editarToolStripButton";
            this.editarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.editarToolStripButton.Text = "&Abrir";
            this.editarToolStripButton.ToolTipText = "Modificar Vendedor";
            this.editarToolStripButton.Click += new System.EventHandler(this.editarToolStripButton_Click);
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
            // lvwVendedores
            // 
            this.lvwVendedores.ColumnAutoResize = false;
            this.lvwVendedores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNombre,
            this.chApellido,
            this.chDireccion,
            this.chMail});
            this.lvwVendedores.DataSource = null;
            this.lvwVendedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwVendedores.FullRowSelect = true;
            this.lvwVendedores.Location = new System.Drawing.Point(0, 25);
            this.lvwVendedores.Name = "lvwVendedores";
            this.lvwVendedores.SelectedItem = null;
            this.lvwVendedores.Size = new System.Drawing.Size(558, 434);
            this.lvwVendedores.TabIndex = 2;
            this.lvwVendedores.UseCompatibleStateImageBehavior = false;
            this.lvwVendedores.View = System.Windows.Forms.View.Details;
            // 
            // chNombre
            // 
            this.chNombre.Tag = "Nombre";
            this.chNombre.Text = "Nombre";
            this.chNombre.Width = 114;
            // 
            // chApellido
            // 
            this.chApellido.Tag = "Apellido";
            this.chApellido.Text = "Apellido";
            this.chApellido.Width = 128;
            // 
            // chDireccion
            // 
            this.chDireccion.Tag = "Direccion";
            this.chDireccion.Text = "Direccion";
            this.chDireccion.Width = 132;
            // 
            // chMail
            // 
            this.chMail.Tag = "Mail";
            this.chMail.Text = "Mail";
            this.chMail.Width = 166;
            // 
            // frmConsultaVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 459);
            this.Controls.Add(this.lvwVendedores);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmConsultaVendedores";
            this.Text = "Consulta de Vendedores";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton nuevoToolStripButton;
        private System.Windows.Forms.ToolStripButton editarToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton ayudaToolStripButton;
        private tbrListView lvwVendedores;
        private System.Windows.Forms.ColumnHeader chNombre;
        private System.Windows.Forms.ColumnHeader chApellido;
        private System.Windows.Forms.ColumnHeader chDireccion;
        private System.Windows.Forms.ColumnHeader chMail;
    }
}
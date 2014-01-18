namespace tbrBingo
{
    partial class frmImpresionCartones
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
            this.cmdPlay = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.timeImpresion = new System.Windows.Forms.Timer(this.components);
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.tLvw = new tbrBingo.tbrListView();
            this.chNro = new System.Windows.Forms.ColumnHeader();
            this.chnumeros = new System.Windows.Forms.ColumnHeader();
            this.chEstado = new System.Windows.Forms.ColumnHeader();
            this.chkImprimirImagen = new System.Windows.Forms.CheckBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdPlay
            // 
            this.cmdPlay.Location = new System.Drawing.Point(0, 12);
            this.cmdPlay.Name = "cmdPlay";
            this.cmdPlay.Size = new System.Drawing.Size(75, 23);
            this.cmdPlay.TabIndex = 1;
            this.cmdPlay.Text = "Imprimir";
            this.cmdPlay.UseVisualStyleBackColor = true;
            this.cmdPlay.Click += new System.EventHandler(this.cmdPlay_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(371, 22);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(117, 13);
            this.lblMensaje.TabIndex = 3;
            this.lblMensaje.Text = "Preparado para imprimir";
            // 
            // timeImpresion
            // 
            this.timeImpresion.Interval = 2500;
            this.timeImpresion.Tick += new System.EventHandler(this.timeImpresion_Tick);
            // 
            // printDoc
            // 
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            // 
            // tLvw
            // 
            this.tLvw.ColumnAutoResize = false;
            this.tLvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNro,
            this.chnumeros,
            this.chEstado});
            this.tLvw.ContextMenuStrip = this.contextMenu;
            this.tLvw.DataSource = null;
            this.tLvw.FullRowSelect = true;
            this.tLvw.HideSelection = false;
            this.tLvw.Location = new System.Drawing.Point(0, 46);
            this.tLvw.Name = "tLvw";
            this.tLvw.SelectedItem = null;
            this.tLvw.Size = new System.Drawing.Size(526, 270);
            this.tLvw.TabIndex = 0;
            this.tLvw.UseCompatibleStateImageBehavior = false;
            this.tLvw.View = System.Windows.Forms.View.Details;
            // 
            // chNro
            // 
            this.chNro.Tag = "NroCarton";
            this.chNro.Text = "NroCarton";
            this.chNro.Width = 91;
            // 
            // chnumeros
            // 
            this.chnumeros.Tag = "cartonnumeros";
            this.chnumeros.Text = "Numeros";
            this.chnumeros.Width = 297;
            // 
            // chEstado
            // 
            this.chEstado.Text = "Estado";
            this.chEstado.Width = 121;
            // 
            // chkImprimirImagen
            // 
            this.chkImprimirImagen.AutoSize = true;
            this.chkImprimirImagen.Location = new System.Drawing.Point(181, 18);
            this.chkImprimirImagen.Name = "chkImprimirImagen";
            this.chkImprimirImagen.Size = new System.Drawing.Size(164, 17);
            this.chkImprimirImagen.TabIndex = 4;
            this.chkImprimirImagen.Text = "Incluir imagen en la impresión";
            this.chkImprimirImagen.UseVisualStyleBackColor = true;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(124, 26);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // frmImpresionCartones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 317);
            this.ControlBox = false;
            this.Controls.Add(this.chkImprimirImagen);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdPlay);
            this.Controls.Add(this.tLvw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImpresionCartones";
            this.Text = "Impresion de Cartones";
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private tbrListView tLvw;
        private System.Windows.Forms.ColumnHeader chNro;
        private System.Windows.Forms.ColumnHeader chnumeros;
        private System.Windows.Forms.ColumnHeader chEstado;
        private System.Windows.Forms.Button cmdPlay;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Timer timeImpresion;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.CheckBox chkImprimirImagen;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
    }
}
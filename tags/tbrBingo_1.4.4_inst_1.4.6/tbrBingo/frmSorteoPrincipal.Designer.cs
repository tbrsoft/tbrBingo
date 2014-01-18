namespace tbrBingo
{
    partial class frmSorteoPrincipal
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblCantidadSorteos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCantidadCartones = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdSiguienteSorteo = new System.Windows.Forms.Button();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lvwGanadores = new tbrBingo.tbrListView();
            this.chNroCarton = new System.Windows.Forms.ColumnHeader();
            this.chComprador = new System.Windows.Forms.ColumnHeader();
            this.lvw = new tbrBingo.tbrListView();
            this.chNumeros = new System.Windows.Forms.ColumnHeader();
            this.chPremio = new System.Windows.Forms.ColumnHeader();
            this.chEstado = new System.Windows.Forms.ColumnHeader();
            this.chGanador = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cantidad de Sorteos:";
            // 
            // lblCantidadSorteos
            // 
            this.lblCantidadSorteos.AutoSize = true;
            this.lblCantidadSorteos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadSorteos.Location = new System.Drawing.Point(156, 20);
            this.lblCantidadSorteos.Name = "lblCantidadSorteos";
            this.lblCantidadSorteos.Size = new System.Drawing.Size(41, 13);
            this.lblCantidadSorteos.TabIndex = 2;
            this.lblCantidadSorteos.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cantidad Cartones:";
            // 
            // lblCantidadCartones
            // 
            this.lblCantidadCartones.AutoSize = true;
            this.lblCantidadCartones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadCartones.Location = new System.Drawing.Point(156, 37);
            this.lblCantidadCartones.Name = "lblCantidadCartones";
            this.lblCantidadCartones.Size = new System.Drawing.Size(41, 13);
            this.lblCantidadCartones.TabIndex = 4;
            this.lblCantidadCartones.Text = "label3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCantidadCartones);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblCantidadSorteos);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 58);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bingo";
            // 
            // cmdSiguienteSorteo
            // 
            this.cmdSiguienteSorteo.Location = new System.Drawing.Point(373, 12);
            this.cmdSiguienteSorteo.Name = "cmdSiguienteSorteo";
            this.cmdSiguienteSorteo.Size = new System.Drawing.Size(200, 23);
            this.cmdSiguienteSorteo.TabIndex = 6;
            this.cmdSiguienteSorteo.Text = "Realizar Siguiente Sorteo";
            this.cmdSiguienteSorteo.UseVisualStyleBackColor = true;
            this.cmdSiguienteSorteo.Click += new System.EventHandler(this.cmdSiguienteSorteo_Click);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Enabled = false;
            this.cmdImprimir.Location = new System.Drawing.Point(373, 44);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(200, 23);
            this.cmdImprimir.TabIndex = 7;
            this.cmdImprimir.Text = "Imprimir Resultados";
            this.cmdImprimir.UseVisualStyleBackColor = true;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ganadores: (Seleccione un sorteo en la lista superior)";
            // 
            // lvwGanadores
            // 
            this.lvwGanadores.ColumnAutoResize = false;
            this.lvwGanadores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNroCarton,
            this.chComprador});
            this.lvwGanadores.DataSource = null;
            this.lvwGanadores.FullRowSelect = true;
            this.lvwGanadores.Location = new System.Drawing.Point(12, 299);
            this.lvwGanadores.Name = "lvwGanadores";
            this.lvwGanadores.SelectedItem = null;
            this.lvwGanadores.Size = new System.Drawing.Size(561, 106);
            this.lvwGanadores.TabIndex = 8;
            this.lvwGanadores.UseCompatibleStateImageBehavior = false;
            this.lvwGanadores.View = System.Windows.Forms.View.Details;
            // 
            // chNroCarton
            // 
            this.chNroCarton.Tag = "NroCarton";
            this.chNroCarton.Text = "Nro Cartón";
            this.chNroCarton.Width = 110;
            // 
            // chComprador
            // 
            this.chComprador.Tag = "gpcomprador";
            this.chComprador.Text = "Ganador";
            this.chComprador.Width = 434;
            // 
            // lvw
            // 
            this.lvw.ColumnAutoResize = false;
            this.lvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNumeros,
            this.chPremio,
            this.chEstado,
            this.chGanador});
            this.lvw.DataSource = null;
            this.lvw.FullRowSelect = true;
            this.lvw.Location = new System.Drawing.Point(12, 71);
            this.lvw.Name = "lvw";
            this.lvw.SelectedItem = null;
            this.lvw.Size = new System.Drawing.Size(561, 201);
            this.lvw.TabIndex = 0;
            this.lvw.UseCompatibleStateImageBehavior = false;
            this.lvw.View = System.Windows.Forms.View.Details;
            this.lvw.ItemActivate += new System.EventHandler(this.lvw_ItemActivate);
            this.lvw.SelectedIndexChanged += new System.EventHandler(this.lvw_SelectedIndexChanged);
            // 
            // chNumeros
            // 
            this.chNumeros.Tag = "";
            this.chNumeros.Text = "Numeros";
            this.chNumeros.Width = 219;
            // 
            // chPremio
            // 
            this.chPremio.Tag = "Premio";
            this.chPremio.Text = "Premio";
            this.chPremio.Width = 127;
            // 
            // chEstado
            // 
            this.chEstado.Tag = "EstadoSorteo";
            this.chEstado.Text = "Estado";
            this.chEstado.Width = 74;
            // 
            // chGanador
            // 
            this.chGanador.Text = "Cant. Ganadores";
            this.chGanador.Width = 131;
            // 
            // frmSorteoPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 411);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvwGanadores);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.cmdSiguienteSorteo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSorteoPrincipal";
            this.Text = "Sorteo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSorteoPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.frmSorteoPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private tbrListView lvw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCantidadSorteos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCantidadCartones;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdSiguienteSorteo;
        private System.Windows.Forms.ColumnHeader chNumeros;
        private System.Windows.Forms.ColumnHeader chPremio;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.ColumnHeader chEstado;
        private System.Windows.Forms.ColumnHeader chGanador;
        private tbrListView lvwGanadores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader chNroCarton;
        private System.Windows.Forms.ColumnHeader chComprador;



    }
}
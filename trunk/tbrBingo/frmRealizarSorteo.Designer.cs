namespace tbrBingo
{
    partial class frmRealizarSorteo
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
            this.cmdNewNumber = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvwGanadores = new tbrBingo.tbrListView();
            this.chCarton = new System.Windows.Forms.ColumnHeader();
            this.chNumeros = new System.Windows.Forms.ColumnHeader();
            this.chComprador = new System.Windows.Forms.ColumnHeader();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tBingo1 = new WindowsApplication5.tBingo();
            this.txtNumeros = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chkConfirmacion = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCantBolillas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkExtenderPantalla = new System.Windows.Forms.CheckBox();
            this.cmdCerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdNewNumber
            // 
            this.cmdNewNumber.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewNumber.Location = new System.Drawing.Point(67, 9);
            this.cmdNewNumber.Name = "cmdNewNumber";
            this.cmdNewNumber.Size = new System.Drawing.Size(123, 31);
            this.cmdNewNumber.TabIndex = 0;
            this.cmdNewNumber.Text = "Nuevo Numero";
            this.cmdNewNumber.UseVisualStyleBackColor = true;
            this.cmdNewNumber.Click += new System.EventHandler(this.cmdNewNumber_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvwGanadores);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 270);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ganadores";
            // 
            // lvwGanadores
            // 
            this.lvwGanadores.ColumnAutoResize = false;
            this.lvwGanadores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCarton,
            this.chNumeros,
            this.chComprador});
            this.lvwGanadores.DataSource = null;
            this.lvwGanadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwGanadores.FullRowSelect = true;
            this.lvwGanadores.Location = new System.Drawing.Point(3, 16);
            this.lvwGanadores.Name = "lvwGanadores";
            this.lvwGanadores.SelectedItem = null;
            this.lvwGanadores.Size = new System.Drawing.Size(365, 251);
            this.lvwGanadores.TabIndex = 0;
            this.lvwGanadores.UseCompatibleStateImageBehavior = false;
            this.lvwGanadores.View = System.Windows.Forms.View.Details;
            // 
            // chCarton
            // 
            this.chCarton.Tag = "NroCarton";
            this.chCarton.Text = "Carton";
            this.chCarton.Width = 62;
            // 
            // chNumeros
            // 
            this.chNumeros.DisplayIndex = 2;
            this.chNumeros.Tag = "NumerosCarton";
            this.chNumeros.Text = "Numeros";
            this.chNumeros.Width = 190;
            // 
            // chComprador
            // 
            this.chComprador.DisplayIndex = 1;
            this.chComprador.Tag = "Comprador";
            this.chComprador.Text = "Comprador";
            this.chComprador.Width = 107;
            // 
            // txtNum
            // 
            this.txtNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNum.Location = new System.Drawing.Point(12, 9);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(49, 31);
            this.txtNum.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(755, 270);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tBingo1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.txtNumeros);
            this.splitContainer3.Size = new System.Drawing.Size(380, 270);
            this.splitContainer3.SplitterDistance = 318;
            this.splitContainer3.TabIndex = 7;
            // 
            // tBingo1
            // 
            this.tBingo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBingo1.Location = new System.Drawing.Point(0, 0);
            this.tBingo1.Name = "tBingo1";
            this.tBingo1.Size = new System.Drawing.Size(318, 270);
            this.tBingo1.TabIndex = 7;
            // 
            // txtNumeros
            // 
            this.txtNumeros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNumeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeros.Location = new System.Drawing.Point(0, 0);
            this.txtNumeros.Multiline = true;
            this.txtNumeros.Name = "txtNumeros";
            this.txtNumeros.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNumeros.Size = new System.Drawing.Size(58, 270);
            this.txtNumeros.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.MinimumSize = new System.Drawing.Size(526, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chkConfirmacion);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel1.Controls.Add(this.chkExtenderPantalla);
            this.splitContainer2.Panel1.Controls.Add(this.cmdCerrar);
            this.splitContainer2.Panel1.Controls.Add(this.txtNum);
            this.splitContainer2.Panel1.Controls.Add(this.cmdNewNumber);            
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(755, 324);
            this.splitContainer2.TabIndex = 7;
            // 
            // chkConfirmacion
            // 
            this.chkConfirmacion.AutoSize = true;
            this.chkConfirmacion.Checked = true;
            this.chkConfirmacion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConfirmacion.Location = new System.Drawing.Point(541, 30);
            this.chkConfirmacion.Name = "chkConfirmacion";
            this.chkConfirmacion.Size = new System.Drawing.Size(120, 17);
            this.chkConfirmacion.TabIndex = 8;
            this.chkConfirmacion.Text = "Solicitar verificación";
            this.chkConfirmacion.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCantBolillas);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(196, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 37);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // lblCantBolillas
            // 
            this.lblCantBolillas.AutoSize = true;
            this.lblCantBolillas.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantBolillas.Location = new System.Drawing.Point(167, 13);
            this.lblCantBolillas.Name = "lblCantBolillas";
            this.lblCantBolillas.Size = new System.Drawing.Size(17, 16);
            this.lblCantBolillas.TabIndex = 1;
            this.lblCantBolillas.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bolillas Extraidas:";
            // 
            // chkExtenderPantalla
            // 
            this.chkExtenderPantalla.AutoSize = true;
            this.chkExtenderPantalla.Checked = true;
            this.chkExtenderPantalla.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExtenderPantalla.Location = new System.Drawing.Point(541, 9);
            this.chkExtenderPantalla.Name = "chkExtenderPantalla";
            this.chkExtenderPantalla.Size = new System.Drawing.Size(109, 17);
            this.chkExtenderPantalla.TabIndex = 6;
            this.chkExtenderPantalla.Text = "Extender Pantalla";
            this.chkExtenderPantalla.UseVisualStyleBackColor = true;
            this.chkExtenderPantalla.CheckedChanged += new System.EventHandler(this.chkExtenderPantalla_CheckedChanged);
            // 
            // cmdCerrar
            // 
            this.cmdCerrar.Enabled = false;
            this.cmdCerrar.Location = new System.Drawing.Point(430, 12);
            this.cmdCerrar.Name = "cmdCerrar";
            this.cmdCerrar.Size = new System.Drawing.Size(93, 23);
            this.cmdCerrar.TabIndex = 5;
            this.cmdCerrar.Text = "Cerrar";
            this.cmdCerrar.UseVisualStyleBackColor = true;
            this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
            // 
            // frmRealizarSorteo
            // 
            this.AcceptButton = this.cmdNewNumber;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 324);
            this.Controls.Add(this.splitContainer2);
            this.Name = "frmRealizarSorteo";
            this.Text = "Sorteo Nº:";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRealizarSorteo_FormClosing);
            this.Load += new System.EventHandler(this.frmNewSorteo_Load);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdNewNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private tbrListView lvwGanadores;
        private System.Windows.Forms.ColumnHeader chCarton;
        private System.Windows.Forms.ColumnHeader chComprador;
        private System.Windows.Forms.ColumnHeader chNumeros;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button cmdCerrar;
        private System.Windows.Forms.CheckBox chkExtenderPantalla;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private WindowsApplication5.tBingo tBingo1;
        private System.Windows.Forms.TextBox txtNumeros;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCantBolillas;
        private System.Windows.Forms.CheckBox chkConfirmacion;
    }
}
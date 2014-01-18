namespace tbrBingo
{
    partial class frmSorteoExt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSorteoExt));
            this.picBolilla2 = new System.Windows.Forms.PictureBox();
            this.picTabla = new System.Windows.Forms.PictureBox();
            this.picBolillas = new System.Windows.Forms.PictureBox();
            this.picBolilla1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblHead = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblBingo = new System.Windows.Forms.Label();
            this.lblGanador = new System.Windows.Forms.Label();
            this.picBackGround = new System.Windows.Forms.PictureBox();
            this.lblBOLS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBolilla2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBolillas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBolilla1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackGround)).BeginInit();
            this.SuspendLayout();
            // 
            // picBolilla2
            // 
            this.picBolilla2.BackColor = System.Drawing.Color.Transparent;
            this.picBolilla2.Image = ((System.Drawing.Image)(resources.GetObject("picBolilla2.Image")));
            this.picBolilla2.Location = new System.Drawing.Point(9, 63);
            this.picBolilla2.Name = "picBolilla2";
            this.picBolilla2.Size = new System.Drawing.Size(157, 143);
            this.picBolilla2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBolilla2.TabIndex = 3;
            this.picBolilla2.TabStop = false;
            this.picBolilla2.Visible = false;
            // 
            // picTabla
            // 
            this.picTabla.BackColor = System.Drawing.Color.LightSteelBlue;
            this.picTabla.Location = new System.Drawing.Point(66, 13);
            this.picTabla.Name = "picTabla";
            this.picTabla.Size = new System.Drawing.Size(48, 44);
            this.picTabla.TabIndex = 4;
            this.picTabla.TabStop = false;
            // 
            // picBolillas
            // 
            this.picBolillas.BackColor = System.Drawing.Color.LightCoral;
            this.picBolillas.Location = new System.Drawing.Point(12, 12);
            this.picBolillas.Name = "picBolillas";
            this.picBolillas.Size = new System.Drawing.Size(48, 45);
            this.picBolillas.TabIndex = 5;
            this.picBolillas.TabStop = false;
            this.picBolillas.Click += new System.EventHandler(this.picBolillas_Click);
            // 
            // picBolilla1
            // 
            this.picBolilla1.BackColor = System.Drawing.Color.Transparent;
            this.picBolilla1.Image = ((System.Drawing.Image)(resources.GetObject("picBolilla1.Image")));
            this.picBolilla1.Location = new System.Drawing.Point(172, 63);
            this.picBolilla1.Name = "picBolilla1";
            this.picBolilla1.Size = new System.Drawing.Size(157, 143);
            this.picBolilla1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBolilla1.TabIndex = 7;
            this.picBolilla1.TabStop = false;
            this.picBolilla1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 25);
            this.button1.TabIndex = 8;
            this.button1.Text = "Agegar Numero";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.BackColor = System.Drawing.Color.Transparent;
            this.lblHead.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblHead.Location = new System.Drawing.Point(25, 13);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(0, 59);
            this.lblHead.TabIndex = 10;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblBingo
            // 
            this.lblBingo.AutoSize = true;
            this.lblBingo.BackColor = System.Drawing.Color.Transparent;
            this.lblBingo.Font = new System.Drawing.Font("DejaVu Sans Condensed", 113.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBingo.Location = new System.Drawing.Point(48, 177);
            this.lblBingo.Name = "lblBingo";
            this.lblBingo.Size = new System.Drawing.Size(803, 176);
            this.lblBingo.TabIndex = 11;
            this.lblBingo.Text = "BINGO !!!";
            this.lblBingo.Visible = false;
            // 
            // lblGanador
            // 
            this.lblGanador.AutoSize = true;
            this.lblGanador.BackColor = System.Drawing.Color.Transparent;
            this.lblGanador.Font = new System.Drawing.Font("DejaVu Sans", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanador.Location = new System.Drawing.Point(5, 209);
            this.lblGanador.Name = "lblGanador";
            this.lblGanador.Size = new System.Drawing.Size(153, 31);
            this.lblGanador.TabIndex = 12;
            this.lblGanador.Text = "Ganador:";
            this.lblGanador.Visible = false;
            // 
            // picBackGround
            // 
            this.picBackGround.BackColor = System.Drawing.Color.Transparent;
            this.picBackGround.Location = new System.Drawing.Point(212, 410);
            this.picBackGround.Name = "picBackGround";
            this.picBackGround.Size = new System.Drawing.Size(100, 50);
            this.picBackGround.TabIndex = 13;
            this.picBackGround.TabStop = false;
            this.picBackGround.Visible = false;
            // 
            // lblBOLS
            // 
            this.lblBOLS.AutoSize = true;
            this.lblBOLS.BackColor = System.Drawing.Color.Transparent;
            this.lblBOLS.Font = new System.Drawing.Font("DejaVu Sans", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBOLS.ForeColor = System.Drawing.Color.Black;
            this.lblBOLS.Location = new System.Drawing.Point(597, 30);
            this.lblBOLS.Name = "lblBOLS";
            this.lblBOLS.Size = new System.Drawing.Size(235, 40);
            this.lblBOLS.TabIndex = 14;
            this.lblBOLS.Text = "Bolillas: 00";
            this.lblBOLS.Visible = false;
            // 
            // frmSorteoExt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(821, 543);
            this.Controls.Add(this.lblBOLS);
            this.Controls.Add(this.picBackGround);
            this.Controls.Add(this.lblGanador);
            this.Controls.Add(this.lblBingo);
            this.Controls.Add(this.lblHead);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picBolillas);
            this.Controls.Add(this.picBolilla1);
            this.Controls.Add(this.picTabla);
            this.Controls.Add(this.picBolilla2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSorteoExt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Click += new System.EventHandler(this.Form1_Click);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBolilla2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBolillas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBolilla1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackGround)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBolilla2;
        private System.Windows.Forms.PictureBox picTabla;
        private System.Windows.Forms.PictureBox picBolillas;
        private System.Windows.Forms.PictureBox picBolilla1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblBingo;
        private System.Windows.Forms.Label lblGanador;
        private System.Windows.Forms.PictureBox picBackGround;
        private System.Windows.Forms.Label lblBOLS;

    }
}


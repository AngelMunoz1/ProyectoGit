namespace ProyectoGit
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCrud = new System.Windows.Forms.Button();
            this.btnPuntoDeVenta = new System.Windows.Forms.Button();
            this.btnChecador = new System.Windows.Forms.Button();
            this.btnVerificador = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(89, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(601, 104);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnCrud
            // 
            this.btnCrud.Location = new System.Drawing.Point(107, 388);
            this.btnCrud.Name = "btnCrud";
            this.btnCrud.Size = new System.Drawing.Size(127, 59);
            this.btnCrud.TabIndex = 1;
            this.btnCrud.Text = "CRUD";
            this.btnCrud.UseVisualStyleBackColor = true;
            this.btnCrud.Click += new System.EventHandler(this.btnCrud_Click);
            // 
            // btnPuntoDeVenta
            // 
            this.btnPuntoDeVenta.Location = new System.Drawing.Point(240, 388);
            this.btnPuntoDeVenta.Name = "btnPuntoDeVenta";
            this.btnPuntoDeVenta.Size = new System.Drawing.Size(127, 59);
            this.btnPuntoDeVenta.TabIndex = 2;
            this.btnPuntoDeVenta.Text = "PUNTO DE VENTA";
            this.btnPuntoDeVenta.UseVisualStyleBackColor = true;
            this.btnPuntoDeVenta.Click += new System.EventHandler(this.btnPuntoDeVenta_Click);
            // 
            // btnChecador
            // 
            this.btnChecador.Location = new System.Drawing.Point(373, 388);
            this.btnChecador.Name = "btnChecador";
            this.btnChecador.Size = new System.Drawing.Size(127, 59);
            this.btnChecador.TabIndex = 3;
            this.btnChecador.Text = "CHECADOR";
            this.btnChecador.UseVisualStyleBackColor = true;
            this.btnChecador.Click += new System.EventHandler(this.btnChecador_Click);
            // 
            // btnVerificador
            // 
            this.btnVerificador.Location = new System.Drawing.Point(506, 388);
            this.btnVerificador.Name = "btnVerificador";
            this.btnVerificador.Size = new System.Drawing.Size(127, 59);
            this.btnVerificador.TabIndex = 4;
            this.btnVerificador.Text = "VERIFICADOR";
            this.btnVerificador.UseVisualStyleBackColor = true;
            this.btnVerificador.Click += new System.EventHandler(this.btnVerificador_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(789, 480);
            this.Controls.Add(this.btnVerificador);
            this.Controls.Add(this.btnChecador);
            this.Controls.Add(this.btnPuntoDeVenta);
            this.Controls.Add(this.btnCrud);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCrud;
        private System.Windows.Forms.Button btnPuntoDeVenta;
        private System.Windows.Forms.Button btnChecador;
        private System.Windows.Forms.Button btnVerificador;
    }
}
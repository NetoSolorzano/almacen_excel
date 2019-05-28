namespace almacen_excel
{
    partial class login
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Tx_pwd = new System.Windows.Forms.TextBox();
            this.Tx_user = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.titulo = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tx_newcon = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.titulo2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Tx_pwd);
            this.groupBox1.Controls.Add(this.Tx_user);
            this.groupBox1.Controls.Add(this.Label3);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Location = new System.Drawing.Point(88, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 79);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, -23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Usuario";
            // 
            // Tx_pwd
            // 
            this.Tx_pwd.Location = new System.Drawing.Point(117, 47);
            this.Tx_pwd.Name = "Tx_pwd";
            this.Tx_pwd.Size = new System.Drawing.Size(134, 20);
            this.Tx_pwd.TabIndex = 17;
            this.Tx_pwd.UseSystemPasswordChar = true;
            this.Tx_pwd.TextChanged += new System.EventHandler(this.Tx_pwd_TextChanged);
            // 
            // Tx_user
            // 
            this.Tx_user.Location = new System.Drawing.Point(117, 18);
            this.Tx_user.Name = "Tx_user";
            this.Tx_user.Size = new System.Drawing.Size(134, 20);
            this.Tx_user.TabIndex = 16;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(37, 50);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(77, 16);
            this.Label3.TabIndex = 15;
            this.Label3.Text = "Contraseña";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(37, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(55, 16);
            this.Label1.TabIndex = 14;
            this.Label1.Text = "Usuario";
            // 
            // titulo
            // 
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.ForeColor = System.Drawing.Color.LightGreen;
            this.titulo.Location = new System.Drawing.Point(147, 10);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(292, 51);
            this.titulo.TabIndex = 22;
            this.titulo.Text = "GESTION DE ALMACEN\r\nESTILO EXCEL\r\n\r\n";
            this.titulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(28, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(117, 17);
            this.checkBox1.TabIndex = 28;
            this.checkBox1.Text = "Cambia contraseña";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tx_newcon
            // 
            this.tx_newcon.Location = new System.Drawing.Point(147, 3);
            this.tx_newcon.Name = "tx_newcon";
            this.tx_newcon.Size = new System.Drawing.Size(134, 20);
            this.tx_newcon.TabIndex = 18;
            this.tx_newcon.UseSystemPasswordChar = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tx_newcon);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Location = new System.Drawing.Point(88, 294);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 26);
            this.panel1.TabIndex = 29;
            // 
            // ComboBox1
            // 
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(192, 182);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(180, 21);
            this.ComboBox1.TabIndex = 30;
            this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(91, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "Base de Datos";
            // 
            // Button2
            // 
            this.Button2.Image = global::almacen_excel.Properties.Resources.exit48;
            this.Button2.Location = new System.Drawing.Point(105, 354);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(53, 52);
            this.Button2.TabIndex = 26;
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button1
            // 
            this.Button1.Image = global::almacen_excel.Properties.Resources.ok;
            this.Button1.Location = new System.Drawing.Point(304, 354);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(53, 52);
            this.Button1.TabIndex = 25;
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // logo
            // 
            this.logo.Image = global::almacen_excel.Properties.Resources.Artesanos_Don_Bosco;
            this.logo.Location = new System.Drawing.Point(1, 1);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(106, 111);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 21;
            this.logo.TabStop = false;
            // 
            // titulo2
            // 
            this.titulo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo2.ForeColor = System.Drawing.Color.LightGreen;
            this.titulo2.Location = new System.Drawing.Point(147, 70);
            this.titulo2.Name = "titulo2";
            this.titulo2.Size = new System.Drawing.Size(292, 88);
            this.titulo2.TabIndex = 32;
            this.titulo2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.titulo2.Click += new System.EventHandler(this.titulo2_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(448, 441);
            this.Controls.Add(this.titulo2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acceso al Sistema";
            this.Load += new System.EventHandler(this.login_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox Tx_pwd;
        internal System.Windows.Forms.TextBox Tx_user;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Label titulo;
        internal System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.CheckBox checkBox1;
        internal System.Windows.Forms.TextBox tx_newcon;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label titulo2;
    }
}


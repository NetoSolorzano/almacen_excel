namespace almacen_excel
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pan_lateral = new System.Windows.Forms.Panel();
            this.bt_salir = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bt_op2 = new System.Windows.Forms.Button();
            this.bt_op1 = new System.Windows.Forms.Button();
            this.bt_ini = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_close = new System.Windows.Forms.Button();
            this.bt_max = new System.Windows.Forms.Button();
            this.bt_min = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bt_face = new System.Windows.Forms.Button();
            this.bt_web = new System.Windows.Forms.Button();
            this.bt_control = new System.Windows.Forms.Button();
            this.pan_op11 = new almacen_excel.pan_op1();
            this.pan_inicio1 = new almacen_excel.pan_inicio();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.pan_lateral);
            this.panel1.Controls.Add(this.bt_salir);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.bt_op2);
            this.panel1.Controls.Add(this.bt_op1);
            this.panel1.Controls.Add(this.bt_ini);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 574);
            this.panel1.TabIndex = 0;
            // 
            // pan_lateral
            // 
            this.pan_lateral.BackColor = System.Drawing.Color.Crimson;
            this.pan_lateral.Location = new System.Drawing.Point(1, 127);
            this.pan_lateral.Name = "pan_lateral";
            this.pan_lateral.Size = new System.Drawing.Size(15, 48);
            this.pan_lateral.TabIndex = 2;
            // 
            // bt_salir
            // 
            this.bt_salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_salir.FlatAppearance.BorderSize = 0;
            this.bt_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_salir.ForeColor = System.Drawing.Color.White;
            this.bt_salir.Image = global::almacen_excel.Properties.Resources.stop;
            this.bt_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_salir.Location = new System.Drawing.Point(16, 521);
            this.bt_salir.Name = "bt_salir";
            this.bt_salir.Size = new System.Drawing.Size(172, 48);
            this.bt_salir.TabIndex = 8;
            this.bt_salir.Text = "Salir";
            this.bt_salir.UseVisualStyleBackColor = true;
            this.bt_salir.Click += new System.EventHandler(this.bt_salir_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Crimson;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(192, 123);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(42, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "Desarrollo y \r\nConsultoría";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::almacen_excel.Properties.Resources.logo_solorsoft;
            this.pictureBox1.Location = new System.Drawing.Point(4, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // bt_op2
            // 
            this.bt_op2.FlatAppearance.BorderSize = 0;
            this.bt_op2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_op2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_op2.ForeColor = System.Drawing.Color.White;
            this.bt_op2.Image = global::almacen_excel.Properties.Resources.add_notes;
            this.bt_op2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_op2.Location = new System.Drawing.Point(15, 239);
            this.bt_op2.Name = "bt_op2";
            this.bt_op2.Size = new System.Drawing.Size(172, 48);
            this.bt_op2.TabIndex = 5;
            this.bt_op2.Text = "Libre";
            this.bt_op2.UseVisualStyleBackColor = true;
            this.bt_op2.Click += new System.EventHandler(this.bt_op2_Click);
            // 
            // bt_op1
            // 
            this.bt_op1.FlatAppearance.BorderSize = 0;
            this.bt_op1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_op1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_op1.ForeColor = System.Drawing.Color.White;
            this.bt_op1.Image = global::almacen_excel.Properties.Resources.wireless;
            this.bt_op1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_op1.Location = new System.Drawing.Point(15, 183);
            this.bt_op1.Name = "bt_op1";
            this.bt_op1.Size = new System.Drawing.Size(172, 48);
            this.bt_op1.TabIndex = 4;
            this.bt_op1.Text = "Mov. Físicos";
            this.bt_op1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_op1.UseVisualStyleBackColor = true;
            this.bt_op1.Click += new System.EventHandler(this.bt_op1_Click);
            // 
            // bt_ini
            // 
            this.bt_ini.FlatAppearance.BorderSize = 0;
            this.bt_ini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ini.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ini.ForeColor = System.Drawing.Color.White;
            this.bt_ini.Image = global::almacen_excel.Properties.Resources.peru_24;
            this.bt_ini.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_ini.Location = new System.Drawing.Point(15, 127);
            this.bt_ini.Name = "bt_ini";
            this.bt_ini.Size = new System.Drawing.Size(172, 48);
            this.bt_ini.TabIndex = 3;
            this.bt_ini.Text = "Gestión Alm. ";
            this.bt_ini.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_ini.UseVisualStyleBackColor = true;
            this.bt_ini.Click += new System.EventHandler(this.bt_ini_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Crimson;
            this.panel2.Controls.Add(this.bt_close);
            this.panel2.Controls.Add(this.bt_max);
            this.panel2.Controls.Add(this.bt_min);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(192, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1003, 17);
            this.panel2.TabIndex = 1;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // bt_close
            // 
            this.bt_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_close.FlatAppearance.BorderSize = 0;
            this.bt_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_close.ForeColor = System.Drawing.Color.White;
            this.bt_close.Image = global::almacen_excel.Properties.Resources.close_square;
            this.bt_close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_close.Location = new System.Drawing.Point(978, 1);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(23, 15);
            this.bt_close.TabIndex = 12;
            this.toolTip1.SetToolTip(this.bt_close, "Panel de Control");
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_sale_Click);
            // 
            // bt_max
            // 
            this.bt_max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_max.FlatAppearance.BorderSize = 0;
            this.bt_max.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_max.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_max.ForeColor = System.Drawing.Color.White;
            this.bt_max.Image = global::almacen_excel.Properties.Resources.maximize_square;
            this.bt_max.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_max.Location = new System.Drawing.Point(958, 1);
            this.bt_max.Name = "bt_max";
            this.bt_max.Size = new System.Drawing.Size(23, 15);
            this.bt_max.TabIndex = 11;
            this.toolTip1.SetToolTip(this.bt_max, "Panel de Control");
            this.bt_max.UseVisualStyleBackColor = true;
            this.bt_max.Click += new System.EventHandler(this.bt_max_Click);
            // 
            // bt_min
            // 
            this.bt_min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_min.FlatAppearance.BorderSize = 0;
            this.bt_min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_min.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_min.ForeColor = System.Drawing.Color.White;
            this.bt_min.Image = global::almacen_excel.Properties.Resources.minimize_square;
            this.bt_min.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_min.Location = new System.Drawing.Point(937, 1);
            this.bt_min.Name = "bt_min";
            this.bt_min.Size = new System.Drawing.Size(23, 15);
            this.bt_min.TabIndex = 10;
            this.toolTip1.SetToolTip(this.bt_min, "Panel de Control");
            this.bt_min.UseVisualStyleBackColor = true;
            this.bt_min.Click += new System.EventHandler(this.bt_min_Click);
            // 
            // bt_face
            // 
            this.bt_face.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_face.FlatAppearance.BorderSize = 0;
            this.bt_face.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_face.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_face.ForeColor = System.Drawing.Color.White;
            this.bt_face.Image = global::almacen_excel.Properties.Resources.linkedin_32;
            this.bt_face.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_face.Location = new System.Drawing.Point(1093, 18);
            this.bt_face.Name = "bt_face";
            this.bt_face.Size = new System.Drawing.Size(41, 41);
            this.bt_face.TabIndex = 11;
            this.toolTip1.SetToolTip(this.bt_face, "Salir del programa");
            this.bt_face.UseVisualStyleBackColor = true;
            this.bt_face.Click += new System.EventHandler(this.bt_face_Click);
            // 
            // bt_web
            // 
            this.bt_web.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_web.FlatAppearance.BorderSize = 0;
            this.bt_web.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_web.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_web.ForeColor = System.Drawing.Color.White;
            this.bt_web.Image = global::almacen_excel.Properties.Resources.cloud;
            this.bt_web.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_web.Location = new System.Drawing.Point(1036, 18);
            this.bt_web.Name = "bt_web";
            this.bt_web.Size = new System.Drawing.Size(41, 41);
            this.bt_web.TabIndex = 10;
            this.toolTip1.SetToolTip(this.bt_web, "Acceso al sitio web");
            this.bt_web.UseVisualStyleBackColor = true;
            this.bt_web.Click += new System.EventHandler(this.bt_web_Click);
            // 
            // bt_control
            // 
            this.bt_control.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_control.FlatAppearance.BorderSize = 0;
            this.bt_control.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_control.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_control.ForeColor = System.Drawing.Color.White;
            this.bt_control.Image = global::almacen_excel.Properties.Resources.gears;
            this.bt_control.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_control.Location = new System.Drawing.Point(989, 18);
            this.bt_control.Name = "bt_control";
            this.bt_control.Size = new System.Drawing.Size(41, 41);
            this.bt_control.TabIndex = 9;
            this.toolTip1.SetToolTip(this.bt_control, "Panel de Control");
            this.bt_control.UseVisualStyleBackColor = true;
            // 
            // pan_op11
            // 
            this.pan_op11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_op11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pan_op11.Location = new System.Drawing.Point(193, 63);
            this.pan_op11.Name = "pan_op11";
            this.pan_op11.Size = new System.Drawing.Size(1002, 510);
            this.pan_op11.TabIndex = 13;
            this.pan_op11.Load += new System.EventHandler(this.pan_op11_Load);
            // 
            // pan_inicio1
            // 
            this.pan_inicio1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_inicio1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pan_inicio1.Location = new System.Drawing.Point(193, 63);
            this.pan_inicio1.Name = "pan_inicio1";
            this.pan_inicio1.Size = new System.Drawing.Size(1002, 510);
            this.pan_inicio1.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1195, 574);
            this.Controls.Add(this.pan_op11);
            this.Controls.Add(this.pan_inicio1);
            this.Controls.Add(this.bt_face);
            this.Controls.Add(this.bt_web);
            this.Controls.Add(this.bt_control);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button bt_ini;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bt_op2;
        private System.Windows.Forms.Button bt_op1;
        private System.Windows.Forms.Button bt_salir;
        private System.Windows.Forms.Panel pan_lateral;
        private System.Windows.Forms.Button bt_control;
        private System.Windows.Forms.Button bt_web;
        private System.Windows.Forms.Button bt_face;
        private pan_inicio pan_inicio1;
        private pan_op1 pan_op11;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button bt_min;
        private System.Windows.Forms.Button bt_max;
        private System.Windows.Forms.Button bt_close;
    }
}


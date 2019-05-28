namespace almacen_excel
{
    partial class pan_op1
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.advancedDataGridView1 = new ADGV.AdvancedDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_todos = new System.Windows.Forms.RadioButton();
            this.rb_redu = new System.Windows.Forms.RadioButton();
            this.rb_estan = new System.Windows.Forms.RadioButton();
            this.lb_col = new System.Windows.Forms.Label();
            this.bt_borra = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tx_tarti = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_titulo = new System.Windows.Forms.Label();
            this.bt_reversa = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pan_ico = new System.Windows.Forms.Panel();
            this.bt_print = new System.Windows.Forms.Button();
            this.bt_expex = new System.Windows.Forms.Button();
            this.tx_totprec = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedDataGridView1.AutoGenerateContextFilters = true;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.DateWithTime = false;
            this.advancedDataGridView1.Location = new System.Drawing.Point(1, 80);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.Size = new System.Drawing.Size(1000, 399);
            this.advancedDataGridView1.TabIndex = 39;
            this.advancedDataGridView1.TimeFilter = false;
            this.advancedDataGridView1.SortStringChanged += new System.EventHandler(this.advancedDataGridView1_SortStringChanged);
            this.advancedDataGridView1.FilterStringChanged += new System.EventHandler(this.advancedDataGridView1_FilterStringChanged);
            this.advancedDataGridView1.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.advancedDataGridView1_ColumnWidthChanged);
            this.advancedDataGridView1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.advancedDataGridView1_Scroll);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rb_todos);
            this.panel1.Controls.Add(this.rb_redu);
            this.panel1.Controls.Add(this.rb_estan);
            this.panel1.Controls.Add(this.lb_col);
            this.panel1.Location = new System.Drawing.Point(1, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 25);
            this.panel1.TabIndex = 38;
            this.panel1.Visible = false;
            // 
            // rb_todos
            // 
            this.rb_todos.AutoSize = true;
            this.rb_todos.Location = new System.Drawing.Point(283, 3);
            this.rb_todos.Name = "rb_todos";
            this.rb_todos.Size = new System.Drawing.Size(55, 17);
            this.rb_todos.TabIndex = 4;
            this.rb_todos.TabStop = true;
            this.rb_todos.Text = "Todos";
            this.rb_todos.UseVisualStyleBackColor = true;
            // 
            // rb_redu
            // 
            this.rb_redu.AutoSize = true;
            this.rb_redu.Location = new System.Drawing.Point(183, 3);
            this.rb_redu.Name = "rb_redu";
            this.rb_redu.Size = new System.Drawing.Size(71, 17);
            this.rb_redu.TabIndex = 2;
            this.rb_redu.TabStop = true;
            this.rb_redu.Text = "Reducido";
            this.rb_redu.UseVisualStyleBackColor = true;
            // 
            // rb_estan
            // 
            this.rb_estan.AutoSize = true;
            this.rb_estan.Location = new System.Drawing.Point(87, 3);
            this.rb_estan.Name = "rb_estan";
            this.rb_estan.Size = new System.Drawing.Size(67, 17);
            this.rb_estan.TabIndex = 1;
            this.rb_estan.TabStop = true;
            this.rb_estan.Text = "Estandar";
            this.rb_estan.UseVisualStyleBackColor = true;
            // 
            // lb_col
            // 
            this.lb_col.AutoSize = true;
            this.lb_col.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_col.Location = new System.Drawing.Point(3, 4);
            this.lb_col.Name = "lb_col";
            this.lb_col.Size = new System.Drawing.Size(61, 13);
            this.lb_col.TabIndex = 0;
            this.lb_col.Text = "Columnas";
            // 
            // bt_borra
            // 
            this.bt_borra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_borra.Location = new System.Drawing.Point(748, 20);
            this.bt_borra.Name = "bt_borra";
            this.bt_borra.Size = new System.Drawing.Size(95, 25);
            this.bt_borra.TabIndex = 37;
            this.bt_borra.Text = "REINICIA TODO";
            this.bt_borra.UseVisualStyleBackColor = true;
            this.bt_borra.Click += new System.EventHandler(this.bt_borra_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1, 53);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView2.Size = new System.Drawing.Size(1000, 26);
            this.dataGridView2.TabIndex = 36;
            this.dataGridView2.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellLeave);
            // 
            // tx_tarti
            // 
            this.tx_tarti.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tx_tarti.Location = new System.Drawing.Point(512, 485);
            this.tx_tarti.Name = "tx_tarti";
            this.tx_tarti.ReadOnly = true;
            this.tx_tarti.Size = new System.Drawing.Size(42, 20);
            this.tx_tarti.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(421, 489);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Total artículos";
            // 
            // lb_titulo
            // 
            this.lb_titulo.AutoSize = true;
            this.lb_titulo.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titulo.Location = new System.Drawing.Point(341, 1);
            this.lb_titulo.Name = "lb_titulo";
            this.lb_titulo.Size = new System.Drawing.Size(379, 28);
            this.lb_titulo.TabIndex = 33;
            this.lb_titulo.Text = "HISTORICO DE MUEBLES VENDIDOS";
            // 
            // bt_reversa
            // 
            this.bt_reversa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_reversa.BackColor = System.Drawing.Color.Red;
            this.bt_reversa.Location = new System.Drawing.Point(880, 11);
            this.bt_reversa.Name = "bt_reversa";
            this.bt_reversa.Size = new System.Drawing.Size(95, 37);
            this.bt_reversa.TabIndex = 41;
            this.bt_reversa.Text = "REVIERTE LA VENTA";
            this.bt_reversa.UseVisualStyleBackColor = false;
            this.bt_reversa.Click += new System.EventHandler(this.button1_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // pan_ico
            // 
            this.pan_ico.BackgroundImage = global::almacen_excel.Properties.Resources.movimfisico32;
            this.pan_ico.Location = new System.Drawing.Point(702, 3);
            this.pan_ico.Name = "pan_ico";
            this.pan_ico.Size = new System.Drawing.Size(36, 35);
            this.pan_ico.TabIndex = 43;
            this.pan_ico.Visible = false;
            // 
            // bt_print
            // 
            this.bt_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_print.Image = global::almacen_excel.Properties.Resources.print_red;
            this.bt_print.Location = new System.Drawing.Point(48, 479);
            this.bt_print.Name = "bt_print";
            this.bt_print.Size = new System.Drawing.Size(32, 31);
            this.bt_print.TabIndex = 42;
            this.bt_print.UseVisualStyleBackColor = true;
            this.bt_print.Click += new System.EventHandler(this.bt_print_Click);
            // 
            // bt_expex
            // 
            this.bt_expex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_expex.Image = global::almacen_excel.Properties.Resources.excel32;
            this.bt_expex.Location = new System.Drawing.Point(10, 479);
            this.bt_expex.Name = "bt_expex";
            this.bt_expex.Size = new System.Drawing.Size(32, 31);
            this.bt_expex.TabIndex = 40;
            this.bt_expex.UseVisualStyleBackColor = true;
            // 
            // tx_totprec
            // 
            this.tx_totprec.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tx_totprec.Location = new System.Drawing.Point(663, 485);
            this.tx_totprec.Name = "tx_totprec";
            this.tx_totprec.ReadOnly = true;
            this.tx_totprec.Size = new System.Drawing.Size(85, 20);
            this.tx_totprec.TabIndex = 45;
            this.tx_totprec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(584, 489);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Total Precio";
            // 
            // pan_op1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.tx_totprec);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pan_ico);
            this.Controls.Add(this.bt_print);
            this.Controls.Add(this.bt_reversa);
            this.Controls.Add(this.bt_expex);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bt_borra);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.tx_tarti);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_titulo);
            this.Name = "pan_op1";
            this.Size = new System.Drawing.Size(1002, 510);
            this.Load += new System.EventHandler(this.pan_op1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pan_op2_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_expex;
        private ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rb_todos;
        private System.Windows.Forms.RadioButton rb_redu;
        private System.Windows.Forms.RadioButton rb_estan;
        private System.Windows.Forms.Label lb_col;
        private System.Windows.Forms.Button bt_borra;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox tx_tarti;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_titulo;
        private System.Windows.Forms.Button bt_reversa;
        private System.Windows.Forms.Button bt_print;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Panel pan_ico;
        private System.Windows.Forms.TextBox tx_totprec;
        private System.Windows.Forms.Label label4;

    }
}

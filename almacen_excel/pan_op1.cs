using System;                   // ok
using System.Data;              // ok
using System.Collections.Generic;   // ok
using System.Drawing;           // ok
using System.Windows.Forms;     // ok
using MySql.Data.MySqlClient;   // ok
using System.Configuration;     // ok
using ClosedXML.Excel;          // ok
using System.Collections;       // ok

namespace almacen_excel
{
    public partial class pan_op1 : UserControl
    {
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        string valant = "";
        string valnue = "";
        List<bool> marcas = new List<bool>();
        // conexion a la base de datos
        static string serv = ConfigurationManager.AppSettings["serv"].ToString();
        static string port = ConfigurationManager.AppSettings["port"].ToString();
        static string usua = ConfigurationManager.AppSettings["user"].ToString();
        static string cont = ConfigurationManager.AppSettings["pass"].ToString();
        static string data = ConfigurationManager.AppSettings["data"].ToString();
        static string ctl = ConfigurationManager.AppSettings["ConnectionLifeTime"].ToString();
        string DB_CONN_STR = "server=" + serv + ";uid=" + usua + ";pwd=" + cont + ";database=" + data + ";ConnectionLifeTime=" + ctl + ";";
        //
        // para la impresion
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        int totcolv = 0;        // total columnas visibles

        public pan_op1()
        {
            InitializeComponent();
        }

        private void pan_op1_Load(object sender, EventArgs e)
        {
            jaladat();
            advancedDataGridView1.DataSource = dt;
            grilla();
            init();
            cellsum(0);
            rb_estan.Checked = true;
        }
        private void pan_op2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void jaladat()
        {
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
            cn.Open();
            try
            {
                string sqlCmd = "select ida,codalm,fechop,tipop,codig,capit,model,mader,tipol,deta1,acaba,talle,deta2,deta3,juego,nombr," +
                    "marca as chkreserva,reserva,contrat,salida,medid,soles2018,id " +
                    "from vendalm a order by capit,model";
                MySqlCommand micon = new MySqlCommand(sqlCmd, cn);
                micon.CommandTimeout = 300;
                //MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
                MySqlDataAdapter adr = new MySqlDataAdapter(micon);
                adr.SelectCommand.CommandType = CommandType.Text;
                adr.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en jaladat");
                cn.Dispose(); // return connection to pool
                cn.Close();
                Application.Exit();
            }
            cn.Close();
            //cn.Dispose(); // return connection to pool
        }
        private void grilla()                       // arma la grilla1
        {
            DataGridViewCheckBoxColumn checkmarca = new DataGridViewCheckBoxColumn();
            advancedDataGridView1.AllowUserToAddRows = false;
            advancedDataGridView1.ReadOnly = false;
            // 
            checkmarca.Name = "marca";
            checkmarca.HeaderText = "marca";
            checkmarca.Width = 30;
            checkmarca.ReadOnly = false;
            checkmarca.FillWeight = 10;
            advancedDataGridView1.Columns.Insert(0, checkmarca);
            for (int i = 0; i <= dt.Columns.Count - 1; i++)
            {
                if (i == 0)
                {
                    advancedDataGridView1.Columns[i].ReadOnly = false;
                }
                if (i == 1) // id almacen
                {
                    advancedDataGridView1.Columns[i].Width = 40;
                    advancedDataGridView1.Columns[i].ReadOnly = true;
                }
                if (i == 2) // codigo del almac
                {
                    advancedDataGridView1.Columns[i].Width = 100;
                    advancedDataGridView1.Columns[i].ReadOnly = true;
                }
                if (i == 3)
                {
                    advancedDataGridView1.Columns[i].Visible = true;
                    advancedDataGridView1.Columns[i].ReadOnly = true;
                }
                if (i == 4)
                {
                    advancedDataGridView1.Columns[i].Visible = false;
                    advancedDataGridView1.Columns[i].ReadOnly = true;
                }
                if (i == 5)
                {
                    advancedDataGridView1.Columns[i].Width = 150;
                    advancedDataGridView1.Columns[i].ReadOnly = true;
                }
                if (i >= 6 && i <= 15)
                {
                    advancedDataGridView1.Columns[i].Width = 40;
                    advancedDataGridView1.Columns[i].ReadOnly = true;
                }
                if (i == 16)    // nombre del mueble
                {
                    advancedDataGridView1.Columns[i].Width = 200;
                    advancedDataGridView1.Columns[i].ReadOnly = true;
                }
                if (i > 16)
                {
                    advancedDataGridView1.Columns[i].Width = 60;
                    advancedDataGridView1.Columns[i].ReadOnly = true;
                }
            }
            advancedDataGridView1.Columns["id"].Visible = false;
        }
        private void init()                         // inicializa ancho de columnas grilla de filtros
        {
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ColumnCount = (advancedDataGridView1.Rows.Count > 0) ? advancedDataGridView1.Rows[0].Cells.Count : advancedDataGridView1.ColumnCount;
            dataGridView2.ColumnHeadersVisible = false;
            dataGridView2.Rows.Add();
            for (int i = 0; i < ((advancedDataGridView1.Rows.Count > 0) ? advancedDataGridView1.Rows[0].Cells.Count : advancedDataGridView1.Columns.Count); i++)
            {
                dataGridView2.Columns[i].Width = advancedDataGridView1.Columns[i].Width;
                dataGridView2.Columns[i].Name = advancedDataGridView1.Columns[i].Name;
                //
                if (advancedDataGridView1.Columns[i].Visible == false)
                {
                    dataGridView2.Columns[i].Visible = false;
                }
            }
            dataGridView2.Columns["ida"].ReadOnly = true;
        }
        private void cellsum(int ind)               // suma la columna especificada
        {  
            tx_tarti.Text = (advancedDataGridView1.Rows.Count).ToString();
            decimal toti = 0;
            foreach(DataGridViewRow row in advancedDataGridView1.Rows){
                toti += Convert.ToDecimal(row.Cells["soles2018"].Value);
            }
            tx_totprec.Text = toti.ToString();
        }
        private void restauramar()  // restaura las visualizaciones segun la marca
        {
            // no se va a usar esto
        }
        private void selec()        // pone color de seleccion si esta con check
        {
            for (int i = 0; i < advancedDataGridView1.Rows.Count - 1; i++)
            {
                //if (advancedDataGridView1.Rows[i].Cells[advancedDataGridView1.Columns["marca"].Index].Value.ToString() == "True")
                //{
                //    advancedDataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                //}
            }
        }
        private void filtros(string expres)             // filtros de nivel superior
        {   
            dv = new DataView(dt);
            dv.RowFilter = expres;
            dt = dv.ToTable();
            advancedDataGridView1.DataSource = null;
            advancedDataGridView1.Columns.Remove("marca");
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.DataSource = dt;
            grilla();
            //init();
            cellsum(0);
            //rb_redu_CheckedChanged(null, null);
            //rb_todos_CheckedChanged(null, null);
        }
        private void grabacam(int idm)    // graba la operacion de restitucion, osea:
        {                                                                   // borra de la tabla vendalm
            string DB_CONN_STR1 = DB_CONN_STR;                              // inserta en la tabla almloc
            MySqlConnection cn0 = new MySqlConnection(DB_CONN_STR1);        // anula la salida en salidash y salidasd
            cn0.Open();                                                     // actualiza el estado del contrato
            try
            {
                // insertamos en almloc
                string inserta = "insert into almloc (id,codalm,fechop,tipop,codig,capit,model,mader,tipol,deta1,acaba,talle,deta2,deta3,nombr,reserva,contrat,salida,medid,soles2018) " +
                    "select ida,codalm,fechop,tipop,codig,capit,model,mader,tipol,deta1,acaba,talle,deta2,deta3,nombr,reserva,contrat,salida,medid,soles2018 " +
                    "from vendalm where ida=@ida";
                MySqlCommand micon = new MySqlCommand(inserta, cn0);
                micon.Parameters.AddWithValue("@ida", idm);
                micon.ExecuteNonQuery();
                // anulamos la salidah
                string anula = "update salidash set status='ANULADO' where idsalidash=(select salida from vendalm where ida=@ida)";
                micon = new MySqlCommand(anula, cn0);
                micon.Parameters.AddWithValue("@ida", idm);
                micon.ExecuteNonQuery();
                // restamos en salidasd
                string resta = "update salidasd set cant=cant-@can where salidash=(select salida from vendalm where ida=@ida)";
                micon = new MySqlCommand(resta, cn0);
                micon.Parameters.AddWithValue("@ida", idm);
                micon.Parameters.AddWithValue("@can", 1);
                micon.ExecuteNonQuery();
                // falta actualizar el estado del contrato
                acciones acc = new acciones();
                acc.act_cont(advancedDataGridView1.CurrentRow.Cells["contrat"].Value.ToString(), "RESERVA");
                // borramos de vendalm
                string borra = "delete from vendalm where ida=@idm";
                micon = new MySqlCommand(borra, cn0);
                micon.Parameters.AddWithValue("@idm", idm);
                micon.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en grabacam");
                cn0.Close();
                cn0.Dispose(); // return connection to pool
                Application.Exit();
            }
            cn0.Close();
            cn0.Dispose(); // return connection to pool
        }

        #region radiobutton
        private void rb_estan_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_estan.Checked == true)
            {
                for (int i = 0; i < advancedDataGridView1.Rows[0].Cells.Count; i++)
                {
                    advancedDataGridView1.Columns[i].Visible = false;
                    dataGridView2.Columns[i].Visible = false;
                }
                advancedDataGridView1.Columns["marca"].Visible = true;
                dataGridView2.Columns["marca"].Visible = true;
                advancedDataGridView1.Columns["id"].Visible = true;
                dataGridView2.Columns["id"].Visible = true;
                advancedDataGridView1.Columns["codalm"].Visible = true;
                dataGridView2.Columns["codalm"].Visible = true;
                advancedDataGridView1.Columns["codig"].Visible = true;
                dataGridView2.Columns["codig"].Visible = true;
                advancedDataGridView1.Columns["capit"].Visible = true;
                dataGridView2.Columns["capit"].Visible = true;
                advancedDataGridView1.Columns["model"].Visible = true;
                dataGridView2.Columns["model"].Visible = true;
                advancedDataGridView1.Columns["mader"].Visible = true;
                dataGridView2.Columns["mader"].Visible = true;
                advancedDataGridView1.Columns["tipol"].Visible = true;
                dataGridView2.Columns["tipol"].Visible = true;
                advancedDataGridView1.Columns["deta1"].Visible = true;
                dataGridView2.Columns["deta1"].Visible = true;
                advancedDataGridView1.Columns["acaba"].Visible = true;
                dataGridView2.Columns["acaba"].Visible = true;
                advancedDataGridView1.Columns["talle"].Visible = true;
                dataGridView2.Columns["talle"].Visible = true;
                advancedDataGridView1.Columns["deta2"].Visible = true;
                dataGridView2.Columns["deta2"].Visible = true;
                advancedDataGridView1.Columns["deta3"].Visible = true;
                dataGridView2.Columns["deta3"].Visible = true;
                advancedDataGridView1.Columns["nombr"].Visible = true;
                dataGridView2.Columns["nombr"].Visible = true;
                advancedDataGridView1.Columns["chkreserva"].Visible = true;
                dataGridView2.Columns["chkreserva"].Visible = true;
                advancedDataGridView1.Columns["reserva"].Visible = true;
                dataGridView2.Columns["reserva"].Visible = true;
                advancedDataGridView1.Columns["contrat"].Visible = true;
                dataGridView2.Columns["contrat"].Visible = true;
                advancedDataGridView1.Columns["chksalida"].Visible = true;
                dataGridView2.Columns["chksalida"].Visible = true;
                advancedDataGridView1.Columns["salida"].Visible = true;
                dataGridView2.Columns["salida"].Visible = true;
                advancedDataGridView1.Columns["evento"].Visible = true;
                dataGridView2.Columns["evento"].Visible = true;
                advancedDataGridView1.Columns["almdes"].Visible = true;
                dataGridView2.Columns["almdes"].Visible = true;
            }
        }
        private void rb_redu_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_redu.Checked == true)
            {
                for (int i = 0; i < advancedDataGridView1.Rows[0].Cells.Count; i++)
                {
                    advancedDataGridView1.Columns[i].Visible = false;
                    dataGridView2.Columns[i].Visible = false;
                }
                advancedDataGridView1.Columns["codalm"].Visible = true;
                dataGridView2.Columns["codalm"].Visible = true;
                advancedDataGridView1.Columns["codig"].Visible = true;
                dataGridView2.Columns["codig"].Visible = true;
                advancedDataGridView1.Columns["nombr"].Visible = true;
                dataGridView2.Columns["nombr"].Visible = true;
            }
        }
        private void rb_todos_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region botones
        private void bt_borra_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            dataGridView2.Rows.Clear();
            dt.DefaultView.RowFilter = "";
            advancedDataGridView1.DataSource = null;
            advancedDataGridView1.Columns.Remove("marca");
            advancedDataGridView1.Rows.Clear();
            jaladat();
            advancedDataGridView1.DataSource = dt;
            grilla();
            init();
            cellsum(0);
            //rb_estan_CheckedChanged(null, null);
            //rb_redu_CheckedChanged(null, null);
            //rb_todos_CheckedChanged(null, null);
            restauramar();
            selec();
        }
        private void bt_expex_Click(object sender, EventArgs e)
        {
            string nombre = "historico_vendalm.xlsx";
            var aa = MessageBox.Show("Confirma que desea generar la hoja de calculo?",
            "Archivo: " + nombre, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (aa == DialogResult.Yes)
            {
                var wb = new XLWorkbook();
                DataTable datexc = (DataTable)(advancedDataGridView1.DataSource);
                wb.Worksheets.Add(datexc, "Inventario");
                wb.SaveAs(nombre);
                MessageBox.Show("Archivo generado con exito!");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // valida que solamente haya una marca
            int vidm = 0;
            int fi = 0;
            for (int i = 0; i < advancedDataGridView1.Rows.Count; i++)
            {
                if (advancedDataGridView1.Rows[i].Cells["marca"].FormattedValue.ToString() == "True")
                {
                    fi = fi + 1;
                    vidm = int.Parse(advancedDataGridView1.Rows[i].Cells["ida"].Value.ToString());
                }
            }
            if (fi > 1)
            {
                MessageBox.Show("Solamente debe seleccionar un mueble", "Atención - Corrija", 
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (fi == 1)
            {
                var aa = MessageBox.Show("Confirma que desea retornar el mueble al stock" + Environment.NewLine +
                    "con sus marcas de reserva y/o salida?", "Confirme por favor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (aa == DialogResult.Yes)
                {
                    grabacam(vidm);
                    for (int i = 0; i < advancedDataGridView1.Rows.Count; i++)
                    {
                        if (advancedDataGridView1.Rows[i].Cells["marca"].FormattedValue.ToString() == "True")
                        {
                            advancedDataGridView1.Rows.RemoveAt(advancedDataGridView1.Rows[i].Index);
                        }
                    }
                }
                else
                {
                    // debe desmarcar
                    for (int i = 0; i < advancedDataGridView1.Rows.Count; i++)
                    {
                        if (advancedDataGridView1.Rows[i].Cells["marca"].FormattedValue.ToString() == "True")
                        {
                            advancedDataGridView1.Rows[i].Cells["marca"].Value = false;
                        }
                    }
                }
            }
        }
        #endregion

        private void advancedDataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (dataGridView2.Columns.Count > 0)
            {
                string colnom = e.Column.Name;
                dataGridView2.Columns[colnom].Width = e.Column.Width;
            }
        }
        private void advancedDataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            dataGridView2.HorizontalScrollingOffset = e.NewValue;
        }

        private void bt_print_Click(object sender, EventArgs e)
        {
            /*
            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
            }
             */
            /*
            Note: In case you want to show the Print Preview Dialog instead of 
            Print Dialog then comment the above code and uncomment the following code
            */
            //Open the print preview dialog
            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            pg.Margins.Top = 50;
            pg.Margins.Bottom = 0;
            pg.Margins.Left = 50;
            pg.Margins.Right = 0;
            pg.Landscape = true;
            printDocument1.DefaultPageSettings = pg;

            iRow = 0; // a ver a ver
            PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            objPPdialog.Document = printDocument1;
            objPPdialog.ShowDialog();
        }
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                //iCount = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                totcolv = 0;
                foreach (DataGridViewColumn dgvGridCol in advancedDataGridView1.Columns)
                {
                    if (dgvGridCol.Visible == true && dgvGridCol.IsDataBound == true)
                    {
                        iTotalWidth += dgvGridCol.Width;
                        totcolv += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;
                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in advancedDataGridView1.Columns)
                    {
                        if (GridCol.Visible == true && GridCol.IsDataBound == true)
                        {
                            iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                (double)iTotalWidth * (double)iTotalWidth *
                                ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                            iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                            // Save width and height of headers
                            arrColumnLefts.Add(iLeftMargin);
                            arrColumnWidths.Add(iTmpWidth);
                            iLeftMargin += iTmpWidth;
                        }
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= advancedDataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = advancedDataGridView1.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height - 10;       // + 5              ********************************************
                    int iCount = 0;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        Font titulo = new Font("Arial", 7);// para el titulo de columnas y dentro de la grilla
                        Font normal = new Font("Arial", 6);// para el titulo de columnas y dentro de la grilla
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString(lb_titulo.Text,
                                new Font(advancedDataGridView1.Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left,
                                e.MarginBounds.Top - e.Graphics.MeasureString(lb_titulo.Text,
                                new Font(advancedDataGridView1.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " +
                                DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate,
                                new Font(advancedDataGridView1.Font, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left +
                                (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                new Font(advancedDataGridView1.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Width),
                                e.MarginBounds.Top - e.Graphics.MeasureString(lb_titulo.Text,
                                new Font(new Font(advancedDataGridView1.Font, FontStyle.Bold),
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in advancedDataGridView1.Columns)
                            {
                                if (GridCol.Visible == true && GridCol.IsDataBound == true)
                                {
                                    e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                        new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                        (int)arrColumnWidths[iCount], iHeaderHeight));

                                    e.Graphics.DrawRectangle(Pens.Black,
                                        new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                        (int)arrColumnWidths[iCount], iHeaderHeight));

                                    e.Graphics.DrawString(GridCol.Name.ToString(),
                                        titulo,
                                        new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                        new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                        (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);   // HeaderText
                                    iCount++;
                                }
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null && Cel.Visible == true)
                            {
                                if (Cel.Value.GetType().ToString() == "System.DateTime")   //Cel.ValueType.ToString() == "System.DateTime"
                                {   // 
                                    e.Graphics.DrawString(Cel.Value.ToString().Substring(0, 10),
                                    normal,
                                    new SolidBrush(Cel.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount],
                                    (float)iTopMargin,
                                    (int)arrColumnWidths[iCount], (float)iCellHeight)
                                    );
                                }
                                else
                                {
                                    e.Graphics.DrawString(Cel.Value.ToString(),
                                    normal,
                                    new SolidBrush(Cel.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount],
                                    (float)iTopMargin,
                                    (int)arrColumnWidths[iCount], (float)iCellHeight),
                                    strFormat);
                                }
                                //Drawing Cells Borders 
                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iCellHeight));
                                iCount++;
                            }
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                    if (iTopMargin <= e.PageBounds.Height)
                    {
                        e.HasMorePages = false;
                    }
                    else
                    {
                        e.HasMorePages = true;
                    }
                }
                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
                return;     // lo acabo de poner 08-03-2018 
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            bFirstPage = true;
            bNewPage = true;
            iRow = 0; 
        }

        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = advancedDataGridView1.FilterString;
            cellsum(7);
        }

        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            dt.DefaultView.Sort = advancedDataGridView1.SortString;
        }

        private void dataGridView2_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentCell.Value != null)
            {
                string frase = dataGridView2.Columns[e.ColumnIndex].Name.ToString() + " like '" + dataGridView2.CurrentCell.Value.ToString() + "*'";
                filtros(frase);
            }
        }

    }
}

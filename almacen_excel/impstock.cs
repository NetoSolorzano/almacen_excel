using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace almacen_excel
{
    public partial class impstock : Form
    {
        static string nomform = "impstock";                      // nombre del formulario
        static string nomtabl = "almloc";
        // conexion a la base de datos
        static string serv = ConfigurationManager.AppSettings["serv"].ToString();
        static string port = ConfigurationManager.AppSettings["port"].ToString();
        static string usua = ConfigurationManager.AppSettings["user"].ToString();
        static string cont = ConfigurationManager.AppSettings["pass"].ToString();
        static string data = ConfigurationManager.AppSettings["data"].ToString();
        static string ctl = ConfigurationManager.AppSettings["ConnectionLifeTime"].ToString();
        //string DB_CONN_STR = "server=" + serv + ";uid=" + usua + ";pwd=" + cont + ";database=" + data + ";";
        string DB_CONN_STR = "server=" + serv + ";uid=" + usua + ";pwd=" + cont + ";database=" + data + ";ConnectionLifeTime=" + ctl + ";";

        public impstock()
        {
            InitializeComponent();
        }

        private void impstock_Load(object sender, EventArgs e)
        {
            //
        }
        public DataTable ConvertToDataTable(string filePath, int numberOfColumns)
        {
            DataTable tbl = new DataTable();
            for (int col = 0; col < numberOfColumns; col++)
                tbl.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));
            string[] lines = System.IO.File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                var cols = line.Split(',');
                DataRow dr = tbl.NewRow();
                for (int cIndex = 0; cIndex < numberOfColumns; cIndex++)
                {
                    dr[cIndex] = cols[cIndex];
                }
                tbl.Rows.Add(dr);
            }
            return tbl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Archivos |*.csv";
            openFileDialog1.Title = "Seleccione el archivo que contiene los datos";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileData = openFileDialog1.FileName;
                textBox1.Text = fileData;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = ConvertToDataTable(textBox1.Text.Trim(), 14);
            DataColumn nombr = dt.Columns.Add("nombr", typeof(string));
            DataColumn medid = dt.Columns.Add("medid", typeof(string));
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
            cn.Open();
            tx_proc.Text = "0";
            try
            {
                MessageBox.Show(" .... Jalando los datos de la maestra ....", "Conversion hecha. Filas " + dt.Rows.Count.ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    string consulta = "select ifnull(nombr,''),ifnull(medid,'') from items where capit=@cap and model=@mod and tipol=@tip and deta1=@det1 and acaba=@aca and deta2=@det2";
                    MySqlCommand micon = new MySqlCommand(consulta, cn);
                    micon.Parameters.AddWithValue("@cap", row[5].ToString());
                    micon.Parameters.AddWithValue("@mod", row[6].ToString());
                    micon.Parameters.AddWithValue("@tip", row[8].ToString());
                    micon.Parameters.AddWithValue("@det1", row[9].ToString());
                    micon.Parameters.AddWithValue("@aca", row[10].ToString());
                    micon.Parameters.AddWithValue("@det2", row[12].ToString());
                    MySqlDataReader dr = micon.ExecuteReader();
                    if (dr.Read())
                    {
                        //row.ItemArray[15] = dr.GetString(0);
                        row["nombr"] = dr.GetString(0);
                        row["medid"] = dr.GetString(1);
                    }
                    dr.Close();
                    tx_proc.Text = i.ToString();
                }
                dataGridView1.DataSource = dt;
                dataGridView1.AutoGenerateColumns = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error de comunicación");
                Application.Exit();
                return;
            }
            cn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var zz = MessageBox.Show("Confirma que desea importar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (zz == DialogResult.Yes)
            {
                MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
                cn.Open();
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        string consulta = "insert into almloc (" +
                            "id,codalm,fechop,tipop,codig,capit,model,mader,tipol,deta1,acaba,talle,deta2,deta3,nombr,medid) values (" +
                            "@id,@alm,@fec,@top,@cod,@cap,@mod,@mad,@tip,@det1,@aca,@tal,@det2,@det3,@nom,@med)";
                        MySqlCommand micon = new MySqlCommand(consulta, cn);
                        micon.Parameters.AddWithValue("@id", dataGridView1.Rows[i].Cells[0].Value.ToString());
                        micon.Parameters.AddWithValue("@alm", dataGridView1.Rows[i].Cells[1].Value.ToString());
                        micon.Parameters.AddWithValue("@fec", dataGridView1.Rows[i].Cells[2].Value.ToString());
                        micon.Parameters.AddWithValue("@top", dataGridView1.Rows[i].Cells[3].Value.ToString());
                        micon.Parameters.AddWithValue("@cod", dataGridView1.Rows[i].Cells[4].Value.ToString());
                        micon.Parameters.AddWithValue("@cap", dataGridView1.Rows[i].Cells[5].Value.ToString());
                        micon.Parameters.AddWithValue("@mod", dataGridView1.Rows[i].Cells[6].Value.ToString());
                        micon.Parameters.AddWithValue("@mad", dataGridView1.Rows[i].Cells[7].Value.ToString());
                        micon.Parameters.AddWithValue("@tip", dataGridView1.Rows[i].Cells[8].Value.ToString());
                        micon.Parameters.AddWithValue("@det1", dataGridView1.Rows[i].Cells[9].Value.ToString());
                        micon.Parameters.AddWithValue("@aca", dataGridView1.Rows[i].Cells[10].Value.ToString());
                        micon.Parameters.AddWithValue("@tal", dataGridView1.Rows[i].Cells[11].Value.ToString());
                        micon.Parameters.AddWithValue("@det2", dataGridView1.Rows[i].Cells[12].Value.ToString());
                        micon.Parameters.AddWithValue("@det3", dataGridView1.Rows[i].Cells[13].Value.ToString());
                        micon.Parameters.AddWithValue("@nom", dataGridView1.Rows[i].Cells[14].Value.ToString());
                        micon.Parameters.AddWithValue("@med", dataGridView1.Rows[i].Cells[15].Value.ToString());
                        try
                        {
                            micon.ExecuteNonQuery();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message, "Error en insertar cliente");
                            Application.Exit();
                            return;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                cn.Close();
            }
            MessageBox.Show("Proceso finalizado");
            this.Close();
        }
    }
}

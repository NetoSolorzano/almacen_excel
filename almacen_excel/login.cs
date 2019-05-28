using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Text;

namespace almacen_excel
{
    public partial class login : Form
    {
        // conexion a la base de datos
        static string serv = ConfigurationManager.AppSettings["serv"].ToString();
        static string port = ConfigurationManager.AppSettings["port"].ToString();
        static string usua = ConfigurationManager.AppSettings["user"].ToString();
        static string cont = ConfigurationManager.AppSettings["pass"].ToString();
        static string data = ConfigurationManager.AppSettings["data"].ToString();
        //static string ctl = ConfigurationManager.AppSettings["ConnectionLifeTime"].ToString();
        string DB_CONN_STR = "server=" + serv + ";uid=" + usua + ";pwd=" + cont + ";database=" + data + ";";
        //string DB_CONN_STR = "server=" + serv + ";uid=" + usua + ";pwd=" + cont + ";database=" + data + ";ConnectionLifeTime=" + ctl + ";";
        //
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + "- Versión " + System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
            init();
            loadcombos();   // datos de los combos
        }

        private void init()
        {
            checkBox1.Visible = false;
            tx_newcon.Visible = false;
            tx_newcon.MaxLength = 10;
        }

        public void loadcombos()    // DATOS DE LOS COMBOS
        {
            ComboBox1.Items.Clear();
            ComboItem citem_dbs = new ComboItem();
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
            try
            {
                cn.Open();
                string consulta = "SELECT `SCHEMA_NAME`,space(2) " +
                    "from INFORMATION_SCHEMA.`SCHEMATA` " +
                    "WHERE `SCHEMA_NAME` IN ('coop2018')";    //'mysql','information_schema','performance_schema'
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    citem_dbs.Text = row.ItemArray[0].ToString();
                    citem_dbs.Value = row.ItemArray[1].ToString();
                    ComboBox1.Items.Add(citem_dbs);
                    ComboBox1.ValueMember = citem_dbs.Value.ToString();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error de conexión");
                Application.Exit();
                return;
            }
            cn.Close();
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            almacen_excel.Program.bd = ComboBox1.Text.Trim();
            valope();       // valida modulo de cambio de passw. y LUEGO JALA NOMBRE DEL CLIENTE Y LOGO
        }
        private string desencrip(string entrada)
        {
            string retorno="";
            string xAcu="";
            for(int c=0;c<entrada.Trim().Length;c++)    //FOR c=1 TO LEN(ALLTRIM(vaen2))
            {
                //xAcu=ALLTRIM(xAcu)+CHR(ASC(SUBSTR(vaen2,c,1))-41)
                //xAcu = xAcu.Trim() + Convert.ToChar(Convert.ToInt32(entrada.Substring(c, 1))-41);
                //char[] mc = entrada.Substring(c, 1).ToCharArray();
                //xAcu = xAcu.Trim() + (mc[0]-41).ToString();
                int ca = Encoding.ASCII.GetBytes(entrada.Substring(c, 1))[0] - 41;
                xAcu = xAcu.Trim() + (char)ca;
            }
            retorno = xAcu;
            MessageBox.Show(retorno);
            return retorno;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            // validamos los campos
            string usuari = this.Tx_user.Text;     // usuario
            string contra = this.Tx_pwd.Text;      // passw
            if (usuari == "")
            {
                MessageBox.Show("Por favor, ingrese el usuario", "Atención");
                return;
            }
            if (contra == "")
            {
                MessageBox.Show("Por favor, ingrese la contraseña", "Atención");
                return;
            }
            //desencrip(contra); no funca
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
            cn.Open();
            try
            {
                //validamos que el usuario y passw son los correctos
                string query = "select a.bloqueado,a.local,trim(a.mod1),trim(a.mod2),trim(a.mod3) " +
                    "from usuarios a " +
                    "where a.nom_user=@usuario and a.pwd_user=@contra";
                MySqlCommand mycomand = new MySqlCommand(query, cn);
                mycomand.Parameters.AddWithValue("@usuario", this.Tx_user.Text);
                mycomand.Parameters.AddWithValue("@contra", this.Tx_pwd.Text);

                MySqlDataReader dr = mycomand.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        if (dr.GetString(0) == "0")
                        {
                            almacen_excel.Program.vg_user = Tx_user.Text;
                            almacen_excel.Program.almuser = dr.GetString(1);
                            if (dr.GetString(2) == "M0" || dr.GetString(3) == "M0" || dr.GetString(4) == "M0")
                            {
                                almacen_excel.Program.m70 = "M0";
                            }
                            else
                            {
                                if (dr.GetString(2) == "M70" || dr.GetString(3) == "M70" || dr.GetString(4) == "M70")
                                {
                                    almacen_excel.Program.m70 = "M70";
                                }
                            }
                            dr.Close();
                            // cambiamos la contraseña si fue hecha
                            cambiacont();
                            // nos vamos al form principal
                            almacen_excel.Program.vg_user = this.Tx_user.Text;
                            // obtenemos la configuración de los colores
                            jalacolor();
                            // llamamos al form principal
                            //MainWindow frm2 = new MainWindow();
                            Form1 main = new Form1();
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            dr.Close();
                            MessageBox.Show("El usuario esta Bloqueado!");
                            return;
                        }
                    }
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Usuario y/o Contraseña erronea", " Atención ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "No se tiene conexión con el servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            cn.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            const string mensaje = "Deseas salir del sistema?";
            const string titulo = "Confirma por favor";
            var result = MessageBox.Show(mensaje, titulo,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            { Close(); }
        }

        private void Tx_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Tx_pwd.Focus();
            }
        }

        private void Tx_pwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Button1.PerformClick();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                tx_newcon.Visible = true;
                tx_newcon.Focus();
            }
            else
            {
                tx_newcon.Text = "";
                tx_newcon.Visible = false;
            }
        }

        private void Tx_pwd_TextChanged(object sender, EventArgs e)
        {
            if (this.panel1.Visible == true)
            {
                if (Tx_pwd.Text != "")
                {
                    checkBox1.Visible = true;
                    checkBox1.Checked = false;
                }
                else
                {
                    checkBox1.Visible = false;
                    checkBox1.Checked = false;
                }
            }
        }

        private void cambiacont()
        {
            if (checkBox1.Checked == true && tx_newcon.Text != "")
            {
                MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
                cn.Open();
                try
                {
                    string consulta = "update usuarios set pwd_user=@npa where nom_user=@nus";
                    MySqlCommand micon = new MySqlCommand(consulta, cn);
                    micon.Parameters.AddWithValue("@npa", tx_newcon.Text);
                    micon.Parameters.AddWithValue("@nus", Tx_user.Text);
                    try
                    {
                        micon.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Error en actualización del password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                        return;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error en conexión");
                    Application.Exit();
                    return;
                }
                cn.Close();
            }
        }

        private void valope()
        {
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
            cn.Open();
            try
            {
                // user's change your own passwords?
                string consulta = "select value from confmod where param='chpwd'";
                MySqlCommand micon = new MySqlCommand(consulta, cn);
                try
                {
                    MySqlDataReader dr = micon.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            if (dr.GetString(0) == "yes")
                            {
                                this.panel1.Visible = true;
                            }
                            else this.panel1.Visible = false;
                        }
                    }
                    dr.Close();
                    jalaclie();         // jala datos de cliente y logo
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "Esta en la base de datos correcta?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Application.Exit();
                    return;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error en conexión");
                Application.Exit();
                return;
            }
            cn.Close();
        }

        private void jalacolor()
        {
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
            cn.Open();
            try
            {
                string consulta = "select param,value from confmod where param like 'color%'";
                MySqlCommand micon = new MySqlCommand(consulta, cn);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(micon);
                try
                {
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];
                        if (row[0].ToString() == "colorback")
                        {
                            almacen_excel.Program.colbac = row[1].ToString();
                        }
                        if (row[0].ToString() == "colorpgfr")
                        {
                            almacen_excel.Program.colpag = row[1].ToString();
                        }
                        if (row[0].ToString() == "colorgrid")
                        {
                            almacen_excel.Program.colgri = row[1].ToString();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "No fue posible obtener colores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error en conexión");
                Application.Exit();
                return;
            }
            cn.Close();
        }

        private void jalaclie()
        {
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
            cn.Open();
            try
            {
                string consulta = "select cliente,igv from baseconf limit 1";
                MySqlCommand micon = new MySqlCommand(consulta, cn);
                try
                {
                    MySqlDataReader dr = micon.ExecuteReader();
                    if (dr.Read())
                    {
                        almacen_excel.Program.cliente = dr.GetString(0);
                        titulo2.Text = dr.GetString(0).Trim();
                        //almacen_excel.Program.igv = dr.GetString(1);
                    }
                    dr.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    Application.Exit();
                    return;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error en conexión");
                Application.Exit();
                return;
            }
            cn.Close();
        }

        private void titulo2_Click(object sender, EventArgs e)
        {

        }
    }
}

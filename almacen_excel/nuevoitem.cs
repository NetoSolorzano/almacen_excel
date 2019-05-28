using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace almacen_excel
{
    public partial class nuevoitem : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public bool retorno;
        string para1, para2, para3;
        // conexion a la base de datos
        static string serv = ConfigurationManager.AppSettings["serv"].ToString();
        static string port = ConfigurationManager.AppSettings["port"].ToString();
        static string usua = ConfigurationManager.AppSettings["user"].ToString();
        static string cont = ConfigurationManager.AppSettings["pass"].ToString();
        static string data = ConfigurationManager.AppSettings["data"].ToString();
        static string ctl = ConfigurationManager.AppSettings["ConnectionLifeTime"].ToString();
        string DB_CONN_STR = "server=" + serv + ";uid=" + usua + ";pwd=" + cont + ";database=" + data + ";ConnectionLifeTime=" + ctl + ";";
        
        public nuevoitem()
        {   
            InitializeComponent();
            lb_titulo.Text = "CREACIÓN DE NUEVO ITEM";
            this.KeyPreview = true; // habilitando la posibilidad de pasar el tab con el enter
        }
        private void nuevoitem_Load(object sender, EventArgs e)
        {
            combos("todos");
            cmb_aca.DropDownWidth = 150;
            cmb_cap.DropDownWidth = 150;
            cmb_det1.DropDownWidth = 200;
            cmb_det2.DropDownWidth = 200;
            cmb_det3.DropDownWidth = 200;
            cmb_mad.DropDownWidth = 150;
            cmb_mod.DropDownWidth = 150;
            cmb_tal.DropDownWidth = 150;
            cmb_tip.DropDownWidth = 150;
            tx_precio.Text = "0";
        }
        private void nuevoitem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void bt_close_Click(object sender, EventArgs e)
        {
            retorno = false;    // false = no se hizo nada
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (tx_dat_cap.Text == "")
            {
                MessageBox.Show("Seleccione el Capitulo", "Error en Código", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmb_cap.Focus();
                return;
            }
            if (tx_dat_mod.Text == "")
            {
                MessageBox.Show("Seleccione el Modelo", "Error en Código", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmb_mod.Focus();
                return;
            }
            if (tx_dat_mad.Text == "")
            {
                MessageBox.Show("Seleccione la Madera", "Error en Código", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmb_mad.Focus();
                return;
            }
            if (tx_dat_tip.Text == "")
            {
                MessageBox.Show("Seleccione la Tipología", "Error en Código", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmb_tip.Focus();
                return;
            }
            if (tx_dat_det1.Text == "")
            {
                MessageBox.Show("Seleccione el Detalle 1", "Error en Código", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmb_det1.Focus();
                return;
            }
            if (tx_dat_aca.Text == "")
            {
                MessageBox.Show("Seleccione el Acabado", "Error en Código", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmb_aca.Focus();
                return;
            }
            if (tx_dat_det2.Text == "")
            {
                MessageBox.Show("Seleccione el Detalle 2", "Error en Código", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmb_det2.Focus();
                return;
            }
            if (tx_dat_det3.Text == "")
            {
                MessageBox.Show("Seleccione el Detalle 3", "Error en Código", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmb_det3.Focus();
                return;
            }
            if (tx_nombre.Text == "")
            {
                MessageBox.Show("Ingrese el nombre del mueble", "Nombre para inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tx_nombre.Focus();
                return;
            }
            if (tx_medidas.Text == "")
            {
                MessageBox.Show("Ingrese las medidas del mueble", "Faltan las medidas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tx_medidas.Focus();
                return;
            }
            if (tx_precio.Text == "0")
            {
                MessageBox.Show("Ingrese el precio del mueble", "Falta el precio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tx_precio.Focus();
                return;
            }
            //
            var aa = MessageBox.Show("Confirma que desea grabar la operación?", "Confirme por favor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (aa == DialogResult.Yes)
            {
                if (entreda() == true)
                {
                    retorno = true; // true = se efectuo la operacion
                    this.Close();
                }
            }
        }
        //
        private bool entreda()
        {
            bool bien = false;
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
            cn.Open();
            try
            {
                string codi = tx_dat_cap.Text.Trim() + tx_dat_mod.Text.Trim() + tx_dat_mad.Text.Trim() +
                    tx_dat_tip.Text.Trim() + tx_dat_det1.Text.Trim() + tx_dat_aca.Text.Trim() +
                    tx_dat_tal.Text.Trim() + tx_dat_det2.Text.Trim() + tx_dat_det3.Text.Trim() + "N000";
                string inserta = "insert into items (" +
                    "codig,capit,model,mader,tipol,deta1,acaba,talle,deta2,deta3,juego,nombr,medid,umed,soles2018) values (" +
                    "@codi,@capi,@mode,@made,@tipo,@det1,@acab,@tall,@det2,@det3,@jgo,@nomb,@medi,@umed,@prec)";
                MySqlCommand micon = new MySqlCommand(inserta, cn);
                micon.Parameters.AddWithValue("@codi", codi);
                micon.Parameters.AddWithValue("@capi", tx_dat_cap.Text.Trim());
                micon.Parameters.AddWithValue("@mode", tx_dat_mod.Text.Trim());
                micon.Parameters.AddWithValue("@made", tx_dat_mad.Text.Trim());
                micon.Parameters.AddWithValue("@tipo", tx_dat_tip.Text.Trim());
                micon.Parameters.AddWithValue("@det1", tx_dat_det1.Text.Trim());
                micon.Parameters.AddWithValue("@acab", tx_dat_aca.Text.Trim());
                micon.Parameters.AddWithValue("@tall", tx_dat_tal.Text.Trim());
                micon.Parameters.AddWithValue("@det2", tx_dat_det2.Text.Trim());
                micon.Parameters.AddWithValue("@det3", tx_dat_det3.Text.Trim());
                micon.Parameters.AddWithValue("@jgo", "N000");
                micon.Parameters.AddWithValue("@nomb", tx_nombre.Text.Trim());
                micon.Parameters.AddWithValue("@medi", tx_medidas.Text.Trim());
                micon.Parameters.AddWithValue("@umed", "C.U.");
                micon.Parameters.AddWithValue("@prec", tx_precio.Text);
                micon.ExecuteNonQuery();
                //
                bien = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error en conexión");
                Application.Exit();
            }
            return bien;
        }
        #region combos y selected index
        private void combos(string quien)
        {
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
            cn.Open();
            try
            {
                if (quien == "capit")
                {
                    cmb_tip.Items.Clear();
                    //tx_dat_tip.Text = "";
                    const string contip = "select b.descrizione,a.tipol from items a " +
                        "left join desc_tip b on b.idcodice=a.tipol " +
                        "where a.capit=@des group by a.tipol";
                    MySqlCommand cmdtip = new MySqlCommand(contip, cn);
                    cmdtip.Parameters.AddWithValue("@des", tx_dat_cap.Text.Trim());
                    DataTable dttip = new DataTable();
                    MySqlDataAdapter datip = new MySqlDataAdapter(cmdtip);
                    datip.Fill(dttip);
                    foreach (DataRow row in dttip.Rows)
                    {
                        cmb_tip.Items.Add(row.ItemArray[1].ToString());
                        cmb_tip.ValueMember = row.ItemArray[1].ToString();
                    }
                }
                if (quien == "todos")
                {
                    // seleccion de capitulo
                    cmb_cap.Items.Clear();
                    tx_dat_cap.Text = "";
                    const string concap = "select descrizionerid,idcodice from desc_gru " +
                        "where numero=1";
                    MySqlCommand cmdcap = new MySqlCommand(concap, cn);
                    DataTable dtcap = new DataTable();
                    MySqlDataAdapter dacap = new MySqlDataAdapter(cmdcap);
                    dacap.Fill(dtcap);
                    foreach (DataRow row in dtcap.Rows)
                    {
                        this.cmb_cap.Items.Add(row.ItemArray[1].ToString().Trim() + "  -  " + row.ItemArray[0].ToString());  // citem_cap
                        this.cmb_cap.ValueMember = row.ItemArray[1].ToString(); //citem_cap.Value.ToString();
                    }
                    // seleccion de modelo
                    const string conmod = "select descrizionerid,idcodice from desc_mod " +
                                           "where numero=1 order by idcodice";
                    MySqlCommand cmdmod = new MySqlCommand(conmod, cn);
                    DataTable dtmod = new DataTable();
                    MySqlDataAdapter damod = new MySqlDataAdapter(cmdmod);
                    damod.Fill(dtmod);
                    foreach (DataRow row in dtmod.Rows)
                    {
                        cmb_mod.Items.Add(row.ItemArray[0].ToString());
                        cmb_mod.ValueMember = row.ItemArray[0].ToString();
                    }
                    // seleccion de madera
                    cmb_mad.Items.Clear();
                    tx_dat_mad.Text = "";
                    const string conmad = "select descrizionerid,idcodice from desc_mad " +
                        "where numero=1";
                    MySqlCommand cmdmad = new MySqlCommand(conmad, cn);
                    DataTable dtmad = new DataTable();
                    MySqlDataAdapter damad = new MySqlDataAdapter(cmdmad);
                    damad.Fill(dtmad);
                    foreach (DataRow row in dtmad.Rows)
                    {
                        this.cmb_mad.Items.Add(row.ItemArray[1].ToString().Trim() + "  -  " + row.ItemArray[0].ToString());   // citem_mad
                        this.cmb_mad.ValueMember = row.ItemArray[1].ToString(); //citem_mad.Value.ToString();
                    }
                    // seleccion de detalle1
                    this.cmb_det1.Items.Clear();
                    tx_dat_det1.Text = "";
                    const string condt1 = "select descrizionerid,idcodice from desc_dt1 " +
                        "where numero=1";
                    MySqlCommand cmddt1 = new MySqlCommand(condt1, cn);
                    DataTable dtdt1 = new DataTable();
                    MySqlDataAdapter dadt1 = new MySqlDataAdapter(cmddt1);
                    dadt1.Fill(dtdt1);
                    foreach (DataRow row in dtdt1.Rows)
                    {
                        this.cmb_det1.Items.Add(row.ItemArray[1].ToString() + "  -  " + row.ItemArray[0].ToString());  // citem_dt1
                        this.cmb_det1.ValueMember = row.ItemArray[1].ToString();    // citem_dt1.Value.ToString();
                    }
                    // seleccion de acabado (pulido, lacado, etc)
                    this.cmb_aca.Items.Clear();
                    tx_dat_aca.Text = "";
                    const string conaca = "select descrizionerid,idcodice from desc_est " +
                        "where numero=1";
                    MySqlCommand cmdaca = new MySqlCommand(conaca, cn);
                    DataTable dtaca = new DataTable();
                    MySqlDataAdapter daaca = new MySqlDataAdapter(cmdaca);
                    daaca.Fill(dtaca);
                    foreach (DataRow row in dtaca.Rows)
                    {
                        this.cmb_aca.Items.Add(row.ItemArray[1].ToString() + "  -  " + row.ItemArray[0].ToString());   // citem_aca
                        this.cmb_aca.ValueMember = row.ItemArray[1].ToString(); //citem_aca.Value.ToString();
                    }
                    // seleccion de taller
                    this.cmb_tal.Items.Clear();
                    tx_dat_tal.Text = "";
                    const string contal = "select descrizionerid,codigo from desc_loc " +
                        "where numero=1";
                    MySqlCommand cmdtal = new MySqlCommand(contal, cn);
                    DataTable dttal = new DataTable();
                    MySqlDataAdapter datal = new MySqlDataAdapter(cmdtal);
                    datal.Fill(dttal);
                    foreach (DataRow row in dttal.Rows)
                    {
                        this.cmb_tal.Items.Add(row.ItemArray[1].ToString() + "  -  " + row.ItemArray[0].ToString());   // citem_tal
                        this.cmb_tal.ValueMember = row.ItemArray[1].ToString(); // citem_tal.Value.ToString();
                    }
                    // seleccion de detalle 2 (tallado, marqueteado, etc)
                    this.cmb_det2.Items.Clear();
                    tx_dat_det2.Text = "";
                    const string condt2 = "select descrizione,idcodice from desc_dt2 " +
                        "where numero=1";
                    MySqlCommand cmddt2 = new MySqlCommand(condt2, cn);
                    DataTable dtdt2 = new DataTable();
                    MySqlDataAdapter dadt2 = new MySqlDataAdapter(cmddt2);
                    dadt2.Fill(dtdt2);
                    foreach (DataRow row in dtdt2.Rows)
                    {
                        this.cmb_det2.Items.Add(row.ItemArray[1].ToString() + "  -  " + row.ItemArray[0].ToString());  // citem_dt2
                        this.cmb_det2.ValueMember = row.ItemArray[1].ToString();     //citem_dt2.Value.ToString();
                    }
                    // seleccion de detalle 3
                    cmb_det3.Items.Clear();
                    tx_dat_det3.Text = "";
                    const string condt3 = "select descrizione,idcodice from desc_dt3 where numero=1";
                    MySqlCommand cmddt3 = new MySqlCommand(condt3, cn);
                    DataTable dtdt3 = new DataTable();
                    MySqlDataAdapter dadt3 = new MySqlDataAdapter(cmddt3);
                    dadt3.Fill(dtdt3);
                    foreach (DataRow row in dtdt3.Rows)
                    {
                        this.cmb_det3.Items.Add(row.ItemArray[1].ToString() + "  -  " + row.ItemArray[0].ToString());  // citem_dt3
                        this.cmb_det3.ValueMember = row.ItemArray[1].ToString();    //citem_dt3.Value.ToString();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message,"No se puede conectar al servidor");
                Application.Exit();
                return;
            }
            cn.Close();
        }

        private void cmb_cap_SelectedIndexChanged(object sender, EventArgs e)
        {
            tx_dat_cap.Text = cmb_cap.SelectedItem.ToString().Substring(0, 1);
            combos("capit");
        }
        private void cmb_mod_SelectedIndexChanged(object sender, EventArgs e)
        {
            tx_dat_mod.Text = cmb_mod.SelectedItem.ToString().Substring(0, 3);
        }
        private void cmb_mad_SelectedIndexChanged(object sender, EventArgs e)
        {
            tx_dat_mad.Text = cmb_mad.SelectedItem.ToString().Substring(0, 1);
        }
        private void cmb_tip_SelectedIndexChanged(object sender, EventArgs e)
        {
            tx_dat_tip.Text = cmb_tip.SelectedItem.ToString().Substring(0, 2);
        }
        private void cmb_det1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tx_dat_det1.Text = cmb_det1.SelectedItem.ToString().Substring(0, 2);
        }
        private void cmb_aca_SelectedIndexChanged(object sender, EventArgs e)
        {
            tx_dat_aca.Text = cmb_aca.SelectedItem.ToString().Substring(0, 1);
        }
        private void cmb_tal_SelectedIndexChanged(object sender, EventArgs e)
        {
            tx_dat_tal.Text = cmb_tal.SelectedItem.ToString().Substring(0, 2);
        }
        private void cmb_det2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tx_dat_det2.Text = cmb_det2.SelectedItem.ToString().Substring(0, 3);
        }
        private void cmb_det3_SelectedIndexChanged(object sender, EventArgs e)
        {
            tx_dat_det3.Text = cmb_det3.SelectedItem.ToString().Substring(0, 3);
        }
        #endregion combos
    }
}

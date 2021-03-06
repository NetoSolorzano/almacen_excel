﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace almacen_excel
{
    public partial class movim : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public bool retorno;
        public string retval1;  // id reserva que retorna al form llamante / id de salida NO HAY PORQUE AUN NO SALE, ESTO ES AUTORIZ.
        public string retval2;  // contrato que retorna al form llamante   / evento de salida autorizado
        public string retval3;  // en reservas no se usa este campo        / almacen hacia donde llegara el mueble
        string para1, para2, para3, para4;
        // conexion a la base de datos
        static string serv = ConfigurationManager.AppSettings["serv"].ToString();
        static string port = ConfigurationManager.AppSettings["port"].ToString();
        static string usua = ConfigurationManager.AppSettings["user"].ToString();
        static string cont = ConfigurationManager.AppSettings["pass"].ToString();
        static string data = ConfigurationManager.AppSettings["data"].ToString();
        static string ctl = ConfigurationManager.AppSettings["ConnectionLifeTime"].ToString();
        //string DB_CONN_STR = "server=" + serv + ";uid=" + usua + ";pwd=" + cont + ";database=" + data + ";";
        string DB_CONN_STR = "server=" + serv + ";uid=" + usua + ";pwd=" + cont + ";database=" + data + ";ConnectionLifeTime=" + ctl + ";";

        public movim(string parm1,string parm2,string parm3,string parm4)    // parm1 = modo = reserva o salida
        {                                                       // parm2 = id del mueble
            InitializeComponent();                              // parm3 = codigo del mueble
            lb_titulo.Text = parm1.ToUpper(); // modo del movimiento
            para1 = parm1;  // modo
            para2 = parm2;  // id almacen del mueble
            para3 = parm3;  // codig mueble
            para4 = parm4;  // almacen de donde se reserva
            if (parm1 == "reserva")
            {
                panel3.Visible = true;
                panel3.Left = 7;
                panel3.Top = 30;
                panel4.Visible = false;
            }
            if (parm1 == "salida")
            {
                panel4.Visible = true;
                panel4.Left = 7;
                panel4.Top = 30;
                panel3.Visible = false;
                rb_mov.Checked = true;
                combos();
            }
        }
        private void movim_Load(object sender, EventArgs e)
        {
            combos();
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
            var aa = MessageBox.Show("Confirma que desea grabar la operación?", "Confirme por favor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (aa == DialogResult.Yes)
            {
                if (lb_titulo.Text.ToLower() == "reserva")
                {
                    if (reserva() == true)
                    {
                        // retornamos los datos de id reserva y contrato
                        retval1 = tx_idr.Text;
                        retval2 = tx_contra.Text;
                        retorno = true; // true = se efectuo la operacion
                    }
                }
                if (lb_titulo.Text == "SALIDA")
                {
                    if (tx_dat_dest.Text == "" && rb_mov.Checked == true)
                    {
                        MessageBox.Show("Seleccione el almacen de destino", "Atención", MessageBoxButtons.OK);
                        cmb_dest.Focus();
                        return;
                    }
                    if (salida() == true)
                    {
                        // retornamos el evento y almacen destino ...SIEMPRE Y CUANDO SEA SALIDA POR MOVIMIENTO
                        // si es salida por AJUSTE el id=0
                        retval1 = (rb_ajuste.Checked == true) ? "0" : "";
                        retval2 = tx_evento.Text;
                        retval3 = tx_dat_dest.Text;
                        retorno = true; // true = se efectuo la operacion
                    }
                }
                this.Close();
            }
        }
        //
        private bool reserva()
        {
            bool bien = false;
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
            cn.Open();
            try
            {
                // inserta la reserva en maestra de reservas
                string texto = "insert into reservh (fecha,contrato,evento,coment,user,dia,almacen) " +
                    "values (@ptxfec,@ptxcon,@ptxt03,@ptxcom,@vg_us,now(),@ptxalm)";
                MySqlCommand micon = new MySqlCommand(texto, cn);
                micon.Parameters.AddWithValue("@ptxfec", DateTime.Now.ToString("yyyy-MM-dd"));
                micon.Parameters.AddWithValue("@ptxcon", tx_contra.Text);
                micon.Parameters.AddWithValue("@ptxt03", tx_evento.Text);
                micon.Parameters.AddWithValue("@ptxcom", tx_comres.Text);
                micon.Parameters.AddWithValue("@vg_us", almacen_excel.Program.vg_user);
                micon.Parameters.AddWithValue("@ptxalm", para4);    // almacen
                micon.ExecuteNonQuery();
                //
                texto = "select last_insert_id() as idreservh";
                micon = new MySqlCommand(texto, cn);
                MySqlDataReader dr = micon.ExecuteReader();
                if (dr.Read())
                {
                    tx_idr.Text = dr.GetString(0);
                }
                dr.Close();
                // y el detalle de la reserva
                texto = "insert into reservd (reservh,item,cant,user,dia,almacen,idalm) " +
                    "values (@ptxidr,@ptxite,@ptxcan,@asd,now(),@ptxalm,@ida)";
                micon = new MySqlCommand(texto, cn);
                micon.Parameters.AddWithValue("@ptxidr", tx_idr.Text);
                micon.Parameters.AddWithValue("@ptxite", para3); // codigo del mueble
                micon.Parameters.AddWithValue("@ptxcan", "1");
                micon.Parameters.AddWithValue("@asd", almacen_excel.Program.vg_user);
                micon.Parameters.AddWithValue("@ptxalm", para4);
                micon.Parameters.AddWithValue("@ida", para2);
                micon.ExecuteNonQuery();
                // actualiza saldo en detalle del contrato
                texto = "UPDATE detacon SET saldo=saldo-@can " +
                    "where contratoh=@ptxcon and item=@ptxi";
                micon = new MySqlCommand(texto, cn);
                micon.Parameters.AddWithValue("@ptxcon", tx_contra.Text);
                micon.Parameters.AddWithValue("@ptxi", para3);
                micon.Parameters.AddWithValue("@can", 1);
                micon.ExecuteNonQuery();
                // algo hará en estado de contratos
                acciones acc = new acciones();
                acc.act_cont(tx_contra.Text, "RESERVA");
                // actualizamos el temporal
                texto = "update tempo set idres=@idr,contrat=@cont where ida=@ida";
                micon = new MySqlCommand(texto, cn);
                micon.Parameters.AddWithValue("@idr", tx_idr.Text);
                micon.Parameters.AddWithValue("@cont", tx_contra.Text);
                micon.Parameters.AddWithValue("@ida", para2);
                micon.ExecuteNonQuery();
                // actualizamos almloc
                texto = "update almloc set reserva=@res,contrat=@con,marca=0 where id=@ida";
                micon = new MySqlCommand(texto, cn);
                micon.Parameters.AddWithValue("@res", tx_idr.Text);
                micon.Parameters.AddWithValue("@con", tx_contra.Text);
                micon.Parameters.AddWithValue("@ida", para2);
                micon.ExecuteNonQuery();
                //advancedDataGridView1.Rows[i].Cells["marca"].Value = 0;
                bien = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error en conexión");
                Application.Exit();
            }
            cn.Close();
            return bien;
        }
        private bool salida()
        {
            bool bien = false;
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
            cn.Open();
            try
            {

                if (rb_mov.Checked == true)
                {
                    // actualizamos la tabla almloc
                    string actua = "update almloc set evento=@even,almdes=@alm where id=@idr";
                    MySqlCommand micon = new MySqlCommand(actua, cn);
                    micon.Parameters.AddWithValue("@even", tx_evento.Text);
                    micon.Parameters.AddWithValue("@alm", tx_dat_dest.Text);
                    micon.Parameters.AddWithValue("@idr", para2);
                    micon.ExecuteNonQuery();
                    //
                    bien = true;
                }
                else
                {   // salida por ajuste 
                    // graba la salida en cabecera y detalle
                    string texto = "insert into salidash " +
                        "(fecha,pedido,reserva,evento,coment,user,dia,llegada,partida,tipomov,contrato) " +
                        "values " +
                        "(@ptxfec,@ptxped,@ptxcon,@ptxt03,@ptxcom,@vg_us,now(),@ptxlle,@ptxpar,@ptxtmo,@ptxctr)";
                    MySqlCommand micon = new MySqlCommand(texto, cn);
                    micon.Parameters.AddWithValue("@ptxfec", dtp_fsal.Value.ToString("yyyy-MM-dd"));
                    micon.Parameters.AddWithValue("@ptxped", "");
                    micon.Parameters.AddWithValue("@ptxcon", "");
                    micon.Parameters.AddWithValue("@ptxt03", tx_evento.Text);
                    micon.Parameters.AddWithValue("@ptxcom", tx_comsal.Text);
                    micon.Parameters.AddWithValue("@vg_us", "Lorenzo");
                    micon.Parameters.AddWithValue("@ptxlle", "");
                    micon.Parameters.AddWithValue("@ptxpar", para4);
                    micon.Parameters.AddWithValue("@ptxtmo", "1");
                    micon.Parameters.AddWithValue("@ptxctr", "");
                    micon.ExecuteNonQuery();
                    //
                    texto = "select MAX(idsalidash) as idreg from salidash";
                    micon = new MySqlCommand(texto, cn);
                    MySqlDataReader dr = micon.ExecuteReader();
                    if (dr.Read())
                    {
                        tx_idr.Text = dr.GetString(0);
                    }
                    dr.Close();
                    //
                    texto = "insert into salidasd " +
                        "(salidash,item,cant,user,dia) " +
                        "values " +
                        "(@v_id,@nar,@can,@vg_us,now())";
                    micon = new MySqlCommand(texto, cn);
                    micon.Parameters.AddWithValue("@v_id", tx_idr.Text);
                    micon.Parameters.AddWithValue("@nar", para3);
                    micon.Parameters.AddWithValue("@can", "1");
                    micon.Parameters.AddWithValue("@vg_us", "Lorenzo");
                    micon.ExecuteNonQuery();
                    // borra en almloc
                    string borra = "delete from almloc where id=@idr";
                    micon = new MySqlCommand(borra, cn);
                    micon.Parameters.AddWithValue("@idr", para2);
                    micon.ExecuteNonQuery();
                    //
                    bien = true;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error en conexión al servidor");
                Application.Exit();
            }
            cn.Close();
            return bien;
        }
        // RESERVAS **********************
        private void tx_contra_Leave(object sender, EventArgs e)
        {
            if (tx_contra.Text == "")
            {
                button1.Focus();
                return;
            }
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
            cn.Open();
            try
            {
                DataTable dt = new DataTable();
                string consulta = "select a.fecha,a.tipoes,a.coment,a.status,b.RazonSocial,trim(c.item),c.cant,trim(c.nombre) " +
                    "from contrat a " +
                    "left join anag_cli b on b.idanagrafica=a.cliente " +
                    "left join detacon c on c.contratoh=a.contrato " +
                    "where a.contrato=@cont and a.status<>'ENTREG'";
                try
                {
                    MySqlCommand micon = new MySqlCommand(consulta, cn);
                    micon.Parameters.AddWithValue("@cont", tx_contra.Text);
                    MySqlDataAdapter da = new MySqlDataAdapter(micon);
                    da.Fill(dt);
                    if (dt.Rows.Count < 1)
                    {
                        cn.Close();
                        MessageBox.Show("No existe el contrato ingresado", "Atención - Verifique", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        tx_contra.Text = "";
                        tx_contra.Focus();
                        return;
                    }
                    else
                    {
                        tx_fecon.Text = dt.Rows[0].ItemArray[0].ToString().Substring(0,10);
                        tx_tienda.Text = dt.Rows[0].ItemArray[1].ToString();
                        tx_comres.Text = dt.Rows[0].ItemArray[2].ToString();
                        tx_cliente.Text = dt.Rows[0].ItemArray[4].ToString();
                        tx_status.Text = dt.Rows[0].ItemArray[3].ToString();
                        dataGridView1.ColumnCount = 3;
                        dataGridView1.Columns[0].Width = 100;
                        dataGridView1.Columns[0].HeaderText = dt.Columns[5].Caption;
                        dataGridView1.Columns[1].Width = 30;
                        dataGridView1.Columns[1].HeaderText = dt.Columns[6].Caption;
                        dataGridView1.Columns[2].Width = 220;
                        dataGridView1.Columns[2].HeaderText = dt.Columns[7].Caption;
                        string sino = "no";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow row = dt.Rows[i];
                            dataGridView1.Rows.Add(row[5].ToString(), row[6].ToString(), row[7].ToString());
                            string parte1 = row[5].ToString().Trim(); // +row[5].ToString().Substring(11, 3);
                            string parte2 = para3.Trim();   //.Substring(0, 10)+para3.Substring(13, 3); ;
                            if (parte1 == parte2) sino = "si";    // aca debemos validar por columnas ACA ACA ACA ACA
                            // cap 1, mod 3, mad 1, tip 2, det1 2, aca 1, tal 2, det2 3, det 3
                        }
                        if (sino == "no")
                        {
                            MessageBox.Show("Este contrato NO CONTIENE el mueble seleccionado", "Atención Revise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            bt_close_Click(null, null);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, "No se puede ejecutar la consulta");
                    Application.Exit();
                    return;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message,"No se puede conectar con el servidor");
                Application.Exit();
                return;
            }
            cn.Close();
        }
        private void combos()
        {
            this.panel4.Focus();
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
            cn.Open();
            try
            {
                // seleccion de los almacenes de destino
                this.cmb_dest.Items.Clear();
                tx_dat_dest.Text = "";
                ComboItem citem_dest = new ComboItem();
                const string condest = "select descrizionerid,idcodice from desc_alm " +
                    "where numero=1";
                MySqlCommand cmd2 = new MySqlCommand(condest, cn);
                DataTable dt2 = new DataTable();
                MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
                da2.Fill(dt2);
                foreach (DataRow row in dt2.Rows)
                {
                    citem_dest.Text = row.ItemArray[0].ToString();
                    citem_dest.Value = row.ItemArray[1].ToString();
                    this.cmb_dest.Items.Add(citem_dest);
                    this.cmb_dest.ValueMember = citem_dest.Value.ToString();
                }
                cn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message,"No se puede conectar al servidor");
                Application.Exit();
                return;
            }
        }
        private void cmb_dest_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
            cn.Open();
            try
            {
                //int aq = Int16.Parse(this.cmb_dest.SelectedIndex.ToString());
                string consulta = "select idcodice from desc_alm where descrizionerid=@des and numero=1";
                MySqlCommand micon = new MySqlCommand(consulta, cn);
                micon.Parameters.AddWithValue("@des", cmb_dest.Text.ToString());
                MySqlDataReader midr = micon.ExecuteReader();
                if (midr.Read())
                {
                    this.tx_dat_dest.Text = midr["idcodice"].ToString();
                }
                midr.Close();
                cn.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message,"No se pudo conectar con el servidor");
                Application.Exit();
                return;
            }
        }
        private void rb_ajuste_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_ajuste.Checked == true)
            {
                tx_dat_dest.Text = "";
                cmb_dest.SelectedIndex = -1;
                cmb_dest.Enabled = false;
                tx_evento.Text = "";
                tx_evento.Enabled = false;
            }
        }
        private void rb_mov_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_mov.Checked == true)
            {
                cmb_dest.Enabled = true;
                tx_evento.Enabled = true;
            }
        }

    }
    public class ComboItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}

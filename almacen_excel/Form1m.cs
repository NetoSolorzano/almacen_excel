using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace almacen_excel
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        //float ancho_form, alto_form;
        public Form1()
        {
            InitializeComponent();
            pan_lateral.Height = bt_ini.Height;
            pan_lateral.Top = bt_ini.Top; ;
            pan_inicio1.BringToFront();
            bt_op2.Visible = false;
        }

        private void bt_ini_Click(object sender, EventArgs e)
        {
            pan_lateral.Height = bt_ini.Height;
            pan_lateral.Top = bt_ini.Top;
            pan_inicio1.BringToFront();
        }

        private void bt_op2_Click(object sender, EventArgs e)
        {
            // nada
        }

        private void bt_op1_Click(object sender, EventArgs e)
        {
            pan_lateral.Height = bt_op1.Height;
            pan_lateral.Top = bt_op1.Top;
            pan_op11.BringToFront();
            pan_op11.Top = pan_inicio1.Top;
        }

        private void bt_sale_Click(object sender, EventArgs e)
        {
            pan_lateral.Height = bt_salir.Height;
            pan_lateral.Top = bt_salir.Top;
            bt_salir.PerformClick();
        }

        private void bt_salir_Click(object sender, EventArgs e)
        {
            pan_lateral.Height = bt_salir.Height;
            pan_lateral.Top = bt_salir.Top;
            var aaa = MessageBox.Show("Realmente desea salir del programa?", "Confirme por favor",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (aaa == DialogResult.Yes)
            {
                Application.Exit();
                return;
            }
        }

        private void bt_min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bt_max_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pan_op11_Load(object sender, EventArgs e)
        {

        }

        private void bt_web_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.solorsoft.com");
        }

        private void bt_face_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("https://www.linkedin.com/in/lucio-sol%C3%B3rzano-659b8416/");
            impstock skt1 = new impstock();
            skt1.Show();
        }

    }
}

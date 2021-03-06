﻿//******************* actualizacion del estado de los contratos ***********************
//PROCEDURE act_cont
//PARAMETERS vpcont,formu && contrato
//LOCAL texto,asd,cantit,cantrs
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;
namespace almacen_excel
{
    class acciones
    {
        // conexion a la base de datos
        static string serv = ConfigurationManager.AppSettings["serv"].ToString();
        static string port = ConfigurationManager.AppSettings["port"].ToString();
        static string usua = ConfigurationManager.AppSettings["user"].ToString();
        static string cont = ConfigurationManager.AppSettings["pass"].ToString();
        static string data = ConfigurationManager.AppSettings["data"].ToString();
        static string ctl = ConfigurationManager.AppSettings["ConnectionLifeTime"].ToString();
        //string DB_CONN_STR = "server=" + serv + ";uid=" + usua + ";pwd=" + cont + ";database=" + data + ";";
        string DB_CONN_STR = "server=" + serv + ";uid=" + usua + ";pwd=" + cont + ";database=" + data + ";ConnectionLifeTime=" + ctl + ";";

        //
        public void act_cont(string numcon,string tipo)
        {
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
            cn.Open();
            try
            {
                int cantit = 0;
                int cantne = 0;
                int cantes = 0;
                int cantrs = 0;
                int canped = 0;
                int canten = 0;
                int cansal = 0;
                //******************************************** calculamos la cantidad de articulos del contrato vpcont='012601'
                string texto="select ifnull(SUM(a.cant),0) as cant,a.contratoh " +
                "from detacon a " +
                "left join items b on UPPER(TRIM(a.item))=UPPER(TRIM(b.codig)) " +
                "where TRIM(a.contratoh)=@vpcont";
                MySqlCommand micon = new MySqlCommand(texto,cn);
                micon.Parameters.AddWithValue("@vpcont", numcon);
                MySqlDataReader dr = micon.ExecuteReader();
                if(dr.Read())
                {
                    cantit = dr.GetInt16(0); // cantidad de articulos del contrato
                }
                dr.Close();
                //*************************** calculamos la cantidad de articulos que tienen pedido  ***  vpcont='012601'
                texto="select ifnull(sum(a.cant),0) as cant from pedidos a " +
                    "left join contrat c on c.contrato=a.contrato " +
                    "where c.contrato=@vpcont";
                micon = new MySqlCommand(texto,cn);
                micon.Parameters.AddWithValue("@vpcont", numcon);
                dr = micon.ExecuteReader();
                if(dr.Read())
                {
                    canped = dr.GetInt16(0); // cantidad de articulos pedidos
                }
                dr.Close();
                //******************************* calculamos la cantidad de articulos reservados de ese contrato vpcont='012601'
                texto="select ifnull(SUM(a.cant),0) as cant from reservd a " +
                    "left join reservh b on a.reservh=b.idreservh " +
                    "where TRIM(b.contrato)=@vpcont and b.status not in('SALIDAS','ANULADO')";
                micon = new MySqlCommand(texto,cn);
                micon.Parameters.AddWithValue("@vpcont", numcon);
                dr = micon.ExecuteReader();
                if(dr.Read())
                {
                    cantrs = dr.GetInt16(0); // cantidad de articulos reservados del contrato
                }
                dr.Close();
                //****************************** calculamos la cantidad de articulos ya entregados de ese contrato
                // salidas por ventas en clientes movimientos
                // salidas por ventas en almacen a partir de una reserva  vpcont='012601'
                texto="select ifnull(sum(a.cant),0) as cant from movim a left join pedidos b on a.pedido=b.codped " +
                    "where TRIM(b.contrato)=@vpcont and a.fventa is not null";
                micon = new MySqlCommand(texto,cn);
                micon.Parameters.AddWithValue("@vpcont", numcon);
                dr = micon.ExecuteReader();
                if(dr.Read())
                {
                    canten = dr.GetInt16(0);
                }
                dr.Close();
                texto="select ifnull(SUM(a.cant),0) as cant from salidasd a " +
                    "left join salidash b on a.salidash=b.idsalidash " +
                    "where b.tipomov=2 and TRIM(b.contrato)=@vpcont and b.status<>'ANULADO'";
                micon = new MySqlCommand(texto,cn);
                micon.Parameters.AddWithValue("@vpcont", numcon);
                dr = micon.ExecuteReader();
                if(dr.Read())
                {
                    cansal = dr.GetInt16(0);     // cantidad de articulos salidos del contrato
                }
                dr.Close();
                cantes = canten + cansal;    // cantidad de articulos ya entregados del contrato
                //********************************** calculamos la cantidad de articulos no entregados del contrato  vpcont='012601'
                texto="select ifnull(sum(a.cant),0) as cant from movim a " +
                    "left join pedidos b on a.pedido=b.codped " +
                    "where TRIM(b.contrato)=@vpcont and a.fventa is null";
                micon = new MySqlCommand(texto,cn);
                micon.Parameters.AddWithValue("@vpcont", numcon);
                dr = micon.ExecuteReader();
                if(dr.Read())
                {
                    cantne = dr.GetInt16(0);    // cantidad de articulos no entregagos
                }
                dr.Close();
                //
                // sumas y restas y actualizaciones
                /*
                MessageBox.Show("cantit: "+cantit.ToString() + Environment.NewLine +
                    "cantne: "+cantne.ToString() + Environment.NewLine +
                    "cantes: " + cantes.ToString() + Environment.NewLine +
                    "cantrs: " + cantrs.ToString() + Environment.NewLine +
                    "canped: " + canped.ToString() + Environment.NewLine +
                    "canten: " + canten.ToString() + Environment.NewLine +
                    "cansal: " + cansal.ToString());*/
                texto="update contrat set status='------' where TRIM(contrato)=@vpcont";
                if(canped + cantrs == cantit && cantne == 0) texto="update contrat set status='PORLLE', codped=' ' where TRIM(contrato)=@vpcont";
                if(cantne + cantrs < cantit && cantne + cantrs != 0 && canten + cansal == 0 && cantne != 0) texto="update contrat set status='LLEPAR', codped=' ' where TRIM(contrato)=@vpcont";
                if(cantne + cantrs >= cantit) texto="update contrat set status='PORENT',codped=' ' where TRIM(contrato)=@vpcont";
                if(canten + cansal < cantit && canten + cansal != 0) texto="update contrat set status='ENTPAR', codped='parcia' where TRIM(contrato)=@vpcont";
                if(canped + cantrs + cansal < cantit) texto="update contrat set status='PEDPAR', codped=' ' where TRIM(contrato)=@vpcont";
                if(canped + cantrs + cansal == 0) texto="update contrat set status='PENDIE', codped=' ' where TRIM(contrato)=@vpcont";
                if(canten + cansal == cantit) texto="update contrat set status='ENTREG', codped='total' where TRIM(contrato)=@vpcont";
                micon = new MySqlCommand(texto,cn);
                micon.Parameters.AddWithValue("@vpcont", numcon);
                micon.ExecuteNonQuery();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message,"Error");
                Application.Exit();
            }
        }
    }
}

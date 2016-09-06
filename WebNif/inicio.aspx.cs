using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataLib;
using System.Web.UI.DataVisualization.Charting;
using System.Net;
using System.Net.Mail;
using System.Web.Security;

namespace WebNif
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }

            graficos_inicio();

            Page.MaintainScrollPositionOnPostBack = true;

        }

        protected void graficos_inicio()
        {
            // Grafico 1
            Conexion cn1 = new Conexion();
            string sql1 = "select periodo, interes from erp_plan_pagos where ERP_PRESTAMO_ID=128 order by periodo";
            DataTable dt1 = (DataTable)cn1.Query(sql1, Conexion.TipoDato.Table);

            string[] x1 = new string[dt1.Rows.Count];
            int[] y1 = new int[dt1.Rows.Count];

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                x1[i] = dt1.Rows[i][0].ToString();
                y1[i] = Convert.ToInt32(dt1.Rows[i][1]);
            }

            Chart1.Series[0].Points.DataBindXY(x1, y1);
            Chart1.Series[0].ChartType = SeriesChartType.Bar;
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart1.Titles[0].Text = "Grafico Interes";
            Chart1.Legends[0].Enabled = true;


            // Grafico 2
            Conexion cn2 = new Conexion();
            string sql2 = "select periodo, nuevocapital from erp_plan_pagos where ERP_PRESTAMO_ID=128 order by periodo";
            DataTable dt2 = (DataTable)cn2.Query(sql2, Conexion.TipoDato.Table);

            string[] x2 = new string[dt2.Rows.Count];
            int[] y2 = new int[dt2.Rows.Count];

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                x2[i] = dt2.Rows[i][0].ToString();
                y2[i] = Convert.ToInt32(dt2.Rows[i][1]);
            }

            Chart2.Series[0].Points.DataBindXY(x2, y2);
            Chart2.Series[0].ChartType = SeriesChartType.Column;
            Chart2.ChartAreas["ChartArea2"].Area3DStyle.Enable3D = true;
            Chart2.Legends[0].Enabled = true;


            // Grafico 3
            Conexion cn3 = new Conexion();
            string sql3 = "select periodo, sobretasa from erp_plan_pagos where ERP_PRESTAMO_ID=128 order by periodo";
            DataTable dt3 = (DataTable)cn3.Query(sql3, Conexion.TipoDato.Table);

            string[] x3 = new string[dt3.Rows.Count];
            int[] y3 = new int[dt3.Rows.Count];

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                x3[i] = dt3.Rows[i][0].ToString();
                y3[i] = Convert.ToInt32(dt3.Rows[i][1]);
            }

            Chart3.Series[0].Points.DataBindXY(x3, y3);
            Chart3.Series[0].ChartType = SeriesChartType.Pie;
            Chart3.ChartAreas["ChartArea3"].Area3DStyle.Enable3D = true;
            Chart3.Legends[0].Enabled = true;

            //// Grafico 4 - mi cuenta
            //Chart4.Series[0].Points.DataBindXY(x3, y3);
            //Chart4.Series[0].ChartType = SeriesChartType.Pie;
            //Chart4.ChartAreas["ChartArea4"].Area3DStyle.Enable3D = true;
            //Chart4.Legends[0].Enabled = true;

        }

        //protected void enviar_correo(object sender, EventArgs e)
        //{
        //    //Creamos un nuevo Objeto de mensaje
        //    System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

        //    //Direccion de correo electronico a la que queremos enviar el mensaje
        //    string destinatario = TextBox6.Text;
        //    mmsg.To.Add(destinatario); // To es una colección que permite enviar el mensaje a más de un destinatario

        //    //Asunto
        //    mmsg.Subject = TextBox7.Text;
        //    mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

        //    //Direccion de correo electronico que queremos que reciba una copia del mensaje
        //    mmsg.Bcc.Add("alexatrujillojimenez@gmail.com");

        //    //Cuerpo del Mensaje
        //    mmsg.Body = message.InnerText; // "mensaje de correo" textarea
        //    mmsg.BodyEncoding = System.Text.Encoding.UTF8;
        //    mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

        //    // Crear el archivo adjunto para el mensaje 
        //    Attachment adj = new Attachment("C:/Users/ALEXA TRUJILLO/Desktop/Gestion cobros/Web gescob/WebNif/adjuntos/pago.pdf");
        //    mmsg.Attachments.Add(adj);

        //    //Correo electronico desde el que enviamos el mensaje
        //    mmsg.From = new System.Net.Mail.MailAddress("alexatrujillojimenez@gmail.com");


        //    // CLIENTE DE CORREO
        //    //Creamos un objeto de cliente de correo
        //    System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
        //    //Hay que crear las credenciales del correo emisor
        //    cliente.Credentials = new System.Net.NetworkCredential("alexatrujillojimenez@gmail.com", "231992matj");
        //    //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail     
        //    cliente.Port = 587;
        //    cliente.EnableSsl = true;         

        //    cliente.Host = "smtp.gmail.com"; //"mail.servidordominio.com"; //Para Gmail "smtp.gmail.com";


        //    //-------------------------ENVIO DE CORREO----------------------*/
        //    try
        //    {
        //        //Enviamos el mensaje      
        //        cliente.Send(mmsg);
        //        Label8.Text = "Mensaje enviado!";
        //        Page.MaintainScrollPositionOnPostBack = true;
        //    }
        //    catch (System.Net.Mail.SmtpException ex)
        //    {
        //        Label8.Text = ex.ToString();
        //        //Response.Write(ex);
        //        Page.MaintainScrollPositionOnPostBack = true;
        //    }
        //}

        //#region Gestiones
        //protected void historial_gestiones(object sender, EventArgs e)
        //{
        //    string idFactura = TextBox5.Text;
        //    Response.Redirect("historial_gestiones.aspx?idFactura=" + idFactura.ToString());
        //}
        //#endregion

        public void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            //FormsAuthentication.RedirectToLoginPage();
            Response.Write("<script language=javascript>window.close();</script>");
        }

    }
}
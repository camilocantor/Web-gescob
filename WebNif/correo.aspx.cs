using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DataLib;
using System.Net;
using System.Net.Mail;
using System.Web.Security;

namespace WebNif
{
    public partial class correo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void enviar_correo(object sender, EventArgs e)
        {
            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            string destinatario = Email.Text;
            mmsg.To.Add(destinatario); // To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = Asunto.Text;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            mmsg.Bcc.Add("alexatrujillojimenez@gmail.com");

            //Cuerpo del Mensaje
            mmsg.Body = Mensaje.InnerText; // "mensaje de correo" textarea
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            // Crear el archivo adjunto para el mensaje 
            Attachment adj = new Attachment("C:/Users/ALEXA TRUJILLO/Desktop/Gestion cobros/Web gescob/WebNif/adjuntos/pago.pdf");
            mmsg.Attachments.Add(adj);

            //Correo electronico desde el que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("alexatrujillojimenez@gmail.com");


            // CLIENTE DE CORREO
            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            //Hay que crear las credenciales del correo emisor
            cliente.Credentials = new System.Net.NetworkCredential("alexatrujillojimenez@gmail.com", "231992matj");
            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail     
            cliente.Port = 587;
            cliente.EnableSsl = true;

            cliente.Host = "smtp.gmail.com"; //"mail.servidordominio.com"; //Para Gmail "smtp.gmail.com";


            //-------------------------ENVIO DE CORREO----------------------*/
            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
                Label8.Text = "Mensaje enviado!";
                Page.MaintainScrollPositionOnPostBack = true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Label8.Text = ex.ToString();
                //Response.Write(ex);
                Page.MaintainScrollPositionOnPostBack = true;
            }
        }

    }
}
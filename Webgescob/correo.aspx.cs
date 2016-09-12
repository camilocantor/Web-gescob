using System;
using System.Web.UI;
using System.Data;
using DataLib;
using System.Net.Mail;
using System.IO;

namespace WebNif
{
    public partial class correo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // drop cl
                Conexion cnc = new Conexion();
                string sqlc = "select nombre, email from gc_clientes order by idcliente";
                DataTable dtc = (DataTable)cnc.Query(sqlc, Conexion.TipoDato.Table);

                DropDownList1.DataSource = dtc;
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataValueField = "nombre";
                DropDownList1.DataBind();
            }

            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sc = DropDownList1.SelectedItem.ToString();

            Conexion cne = new Conexion();
            string sqle = "select email from gc_clientes where nombre='" + sc + "'";
            DataTable dte = (DataTable)cne.Query(sqle, Conexion.TipoDato.Table);

            Email.Text = dte.Rows[0][0].ToString();
        }

        // extension del adjunto
        private Boolean ValidaExtension(string sExtension)
        {
            Boolean rel = false;
            switch (sExtension)
            {
                case ".jpg":
                case ".docx":
                case ".pdf":
                    rel = true;
                    break;
                default:
                    rel = false;
                    break;

            }
            return rel;
        }

        protected void enviar_correo(object sender, EventArgs e)
        {
            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            string dest = Email.Text;
            mmsg.To.Add(dest); // To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = Asunto.Text;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            mmsg.Bcc.Add("alexatrujillojimenez@gmail.com");

            //Cuerpo del Mensaje
            mmsg.Body = Mensaje.InnerText; // textarea
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            #region adjunto

            string sExt = string.Empty;
            string sNom = string.Empty;

            if (adjunto.HasFile)
            {
                sNom = adjunto.FileName;
                sExt = Path.GetExtension(sNom);

                if (ValidaExtension(sExt))
                {
                    adjunto.SaveAs(MapPath("~/adjuntos/" + sNom));
                    Label_adj.Text = "Archivo cargado correctamente.";
                }
                else
                    Label_adj.Text = "Extensión del archivo invalida.";
            }
            else
                Label_adj.Text = "Seleccione el archivo que desea adjuntar";


            // Crear el archivo adjunto para el mensaje 
            Attachment adj = new Attachment(MapPath("~/adjuntos/" + sNom));
            mmsg.Attachments.Add(adj);

            #endregion

            //Correo electronico desde el que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("alexatrujillojimenez@gmail.com");

            // CLIENTE DE CORREO
            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            //Hay que crear las credenciales del correo emisor
            cliente.Credentials = new System.Net.NetworkCredential("alexatrujillojimenez@gmail.com", "CLAVE");
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
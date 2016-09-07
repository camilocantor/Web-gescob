using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebNif
{
    public partial class iniciarsesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void ingresar(object sender, EventArgs e)
        {
            // validar usuario y contraseña
            bool validar = true;
            int idUsuario = 1;
            //

            if (validar == true)
            {
                Response.Redirect("inicio.aspx?idusuario=" + idUsuario.ToString());
            }

        }
    }
}
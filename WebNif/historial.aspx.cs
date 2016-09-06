using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    public partial class historial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void periodicidad(object sender, EventArgs e)
        {
            string periodicidad = TextBox1.Text;

            Conexion cn = new Conexion();
            string sql = "select IDFACTURA, IDCLIENTE, FECHAFACTURA, MONTO, SALDO, TIPOPAGO, VENCIMIENTO, ESTADO, ADJUNTO from gc_facturas where periodicidad='"+ periodicidad +"' order by VENCIMIENTO";
            DataTable dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            Page.MaintainScrollPositionOnPostBack = true;

        }

    }
}
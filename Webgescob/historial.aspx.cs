using System;
using System.Web.UI;
using System.Data;
using DataLib;

namespace WebNif
{
    public partial class historial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Conexion cn = new Conexion();
                string sql = "select distinct to_char(periodicidad, 'dd/mm/yyyy') periodicidad from gc_facturas";
                DataTable dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);

                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "periodicidad";
                DropDownList1.DataValueField = "periodicidad";
                DropDownList1.DataBind();
            }

            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void periodicidad(object sender, EventArgs e)
        {
            DateTime per = Convert.ToDateTime(DropDownList1.SelectedItem.Text);
            string period = per.ToString("dd/MM/yyyy");

            Conexion cn = new Conexion();
            string sql = "select IDFACTURA, IDCLIENTE, FECHAFACTURA, MONTO, SALDO, TIPOPAGO, VENCIMIENTO, ESTADO, ADJUNTO from gc_facturas where periodicidad='"+ period + "' order by VENCIMIENTO";
            DataTable dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            Page.MaintainScrollPositionOnPostBack = true;

        }

    }
}
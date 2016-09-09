using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataLib;
using System.Web.UI.DataVisualization.Charting;

namespace WebNif
{
    public partial class historial_gestiones : System.Web.UI.Page
    {
        static DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int idFactura = Convert.ToInt32(Request["idFactura"]); // Obtiene obj

                Conexion cn0 = new Conexion();
                string sql0 = "select IDCLIENTE from gc_facturas where idfactura="+ idFactura;
                DataTable dt0 = (DataTable)cn0.Query(sql0, Conexion.TipoDato.Table);
                string idCliente = dt0.Rows[0][0].ToString();

                Conexion cn01 = new Conexion();
                string sql01 = "select nombre from gc_clientes where idCliente=" + idCliente;
                DataTable dt01 = (DataTable)cn01.Query(sql01, Conexion.TipoDato.Table);
                string nombre = dt01.Rows[0][0].ToString();

                Conexion cn1 = new Conexion();
                string sql1 = "select idfactura, idcliente, fechafactura, vencimiento, estado, monto, saldo from gc_facturas where idcliente=" + idCliente;
                DataTable dt1 = (DataTable)cn1.Query(sql1, Conexion.TipoDato.Table);

                Label1.Text = idFactura.ToString();
                Label2.Text = dt1.Rows[0][1].ToString() + " " + nombre;

                DateTime fechafac = Convert.ToDateTime(dt1.Rows[0][2].ToString());
                string fecha_fac = fechafac.ToString("dd/MM/yyyy");
                Label3.Text = fecha_fac;

                DateTime fechavenc = Convert.ToDateTime(dt1.Rows[0][3].ToString());
                string fecha_venc = fechafac.ToString("dd/MM/yyyy");
                Label4.Text = fecha_venc;

                Label5.Text = dt1.Rows[0][4].ToString(); 
                Label6.Text = dt1.Rows[0][5].ToString();
                Label7.Text = dt1.Rows[0][6].ToString(); 

                Conexion cn = new Conexion();
                string sql = "select idfactura, fechagestion, seguimiento, estado, adjunto, idusuario from gc_gestiones where idfactura=" + idFactura + " order by fechagestion";
                dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int pos = Convert.ToInt32(e.CommandArgument);
            string idFactura = dt.Rows[pos][0].ToString();

            if (e.CommandName == "adjunto")
            {
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-disposition", "attachment; filename=pago.pdf");
                Response.WriteFile("~/adjuntos/pago.pdf");
                Response.Flush();
                Response.Close();
            }

        }


    }
}
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
    public partial class historial_pagos : System.Web.UI.Page
    {
        static DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int idFactura = Convert.ToInt32(Request["idFactura"]); // Obtiene obj
                //Response.Write(idFactura);
                Label1.Text = idFactura.ToString();

                Label2.Text = "xxxxxxxxxxxxxxxxxxxxx";
                Label3.Text = "xx/xx/xxxx";
                Label4.Text = "xx/xx/xxxx";
                Label5.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
                Label6.Text = "$ xxxxxxxxxxxxxx";
                Label7.Text = "$ xxxxxxxxxxxx";

                Conexion cn = new Conexion();
                string sql = "select *from erp_plan_pagos where erp_prestamo_id=1 order by periodo";
                dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
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
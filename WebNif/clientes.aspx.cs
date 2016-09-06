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
    public partial class clientes : System.Web.UI.Page
    {
        static DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Grilla inicial clientes
                Conexion cnc = new Conexion();
                string sqlc = "select comcenum_csc_recaudo, PERIODO, FECHA_PAGO, SALDOCAPITAL, NUEVOCAPITAL, NUEVOCAPITALNIFF, SOBRETASA from erp_plan_pagos where ERP_PRESTAMO_ID=13 and comcenum_csc_recaudo is not null order by periodo";
                DataTable dtc = (DataTable)cnc.Query(sqlc, Conexion.TipoDato.Table);
                GridView3.DataSource = dtc;
                GridView3.DataBind();
            }
        }

        protected void cliente(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;

            Conexion cn = new Conexion();
            string sql = "select comcenum_csc_recaudo, PERIODO, FECHA_PAGO, SALDOCAPITAL, NUEVOCAPITAL, NUEVOCAPITALNIFF, SOBRETASA from erp_plan_pagos where ERP_PRESTAMO_ID=128 and comcenum_csc_recaudo is not null order by periodo";
            dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);
            GridView2.DataSource = dt;
            GridView2.DataBind();

            Page.MaintainScrollPositionOnPostBack = true;
        }

        // Historial de pagos de una factura seleccionada
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int pos = Convert.ToInt32(e.CommandArgument);
            string idFactura = dt.Rows[pos][0].ToString();

            if (e.CommandName == "historial_pagos")
            {
                Response.Redirect("historial_pagos.aspx?idFactura=" + idFactura.ToString());
            }

        }

    }
}
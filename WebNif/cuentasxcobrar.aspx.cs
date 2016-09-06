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
    public partial class cuentasxcobrar : System.Web.UI.Page
    {
        static DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Grilla inicial cuentas por cobrar
                Conexion cn = new Conexion();
                string sql = "select comcenum_csc_recaudo, PERIODO, FECHA_PAGO, SALDOCAPITAL, NUEVOCAPITAL, NUEVOCAPITALNIFF, SOBRETASA from erp_plan_pagos where ERP_PRESTAMO_ID=131 and comcenum_csc_recaudo is not null order by periodo";
                dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void buscar_factura(object sender, EventArgs e)
        {
            Conexion cn = new Conexion();
            string sql = "select comcenum_csc_recaudo, PERIODO, FECHA_PAGO, SALDOCAPITAL, NUEVOCAPITAL, NUEVOCAPITALNIFF, SOBRETASA from erp_plan_pagos where ERP_PRESTAMO_ID=128 and comcenum_csc_recaudo is not null order by periodo";
            dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void buscar_cliente(object sender, EventArgs e)
        {
            Conexion cn = new Conexion();
            string sql = "select comcenum_csc_recaudo, PERIODO, FECHA_PAGO, SALDOCAPITAL, NUEVOCAPITAL, NUEVOCAPITALNIFF, SOBRETASA from erp_plan_pagos where ERP_PRESTAMO_ID=1 and comcenum_csc_recaudo is not null order by periodo";
            dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void buscar_vencidas(object sender, EventArgs e)
        {
            Conexion cn = new Conexion();
            string sql = "select comcenum_csc_recaudo, PERIODO, FECHA_PAGO, SALDOCAPITAL, NUEVOCAPITAL, NUEVOCAPITALNIFF, SOBRETASA from erp_plan_pagos where ERP_PRESTAMO_ID=30 and comcenum_csc_recaudo is not null order by periodo";
            dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void buscar_todas(object sender, EventArgs e)
        {
            Conexion cn = new Conexion();
            string sql = "select comcenum_csc_recaudo, PERIODO, FECHA_PAGO, SALDOCAPITAL, NUEVOCAPITAL, NUEVOCAPITALNIFF, SOBRETASA from erp_plan_pagos where ERP_PRESTAMO_ID=13 and comcenum_csc_recaudo is not null order by periodo";
            dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            Page.MaintainScrollPositionOnPostBack = true;
        }

        // Historial de pagos de una factura seleccionada
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
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
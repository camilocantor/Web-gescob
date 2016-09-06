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
                string sql = "select IDFACTURA, IDCLIENTE, FECHAFACTURA, MONTO, SALDO, TIPOPAGO, VENCIMIENTO, ESTADO from gc_facturas order by vencimiento";
                dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            Page.MaintainScrollPositionOnPostBack = true;

        }

        protected void buscar_factura(object sender, EventArgs e)
        {
            string idfactura = TextBox1.Text;

            Conexion cn = new Conexion();
            string sql = "select IDFACTURA, IDCLIENTE, FECHAFACTURA, MONTO, SALDO, TIPOPAGO, VENCIMIENTO, ESTADO, ADJUNTO from gc_facturas where idfactura=" + idfactura;
            dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void buscar_cliente(object sender, EventArgs e)
        {
            string idcliente = TextBox2.Text;

            Conexion cn = new Conexion();
            string sql = "select IDFACTURA, IDCLIENTE, FECHAFACTURA, MONTO, SALDO, TIPOPAGO, VENCIMIENTO, ESTADO, ADJUNTO from gc_facturas where idcliente=" + idcliente + "order by idfactura";
            dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void buscar_vencidas(object sender, EventArgs e)
        {
            Conexion cn = new Conexion();
            string sql = "select IDFACTURA, IDCLIENTE, FECHAFACTURA, MONTO, SALDO, TIPOPAGO, VENCIMIENTO, ESTADO, ADJUNTO from gc_facturas where estado='DEUDA VENCIDA' order by VENCIMIENTO";
            dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void buscar_todas(object sender, EventArgs e)
        {
            Conexion cn = new Conexion();
            string sql = "select IDFACTURA, IDCLIENTE, FECHAFACTURA, MONTO, SALDO, TIPOPAGO, VENCIMIENTO, ESTADO, ADJUNTO from gc_facturas order by VENCIMIENTO";
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

            if (e.CommandName == "historial_gestiones")
            {
                Response.Redirect("historial_gestiones.aspx?idFactura=" + idFactura.ToString());
            }


        }

    }
}
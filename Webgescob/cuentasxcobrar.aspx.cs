using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataLib;

namespace WebNif
{
    public partial class cuentasxcobrar : System.Web.UI.Page
    {
        static DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Conexion cn = new Conexion();
                string sql = "select IDFACTURA, IDCLIENTE, FECHAFACTURA, MONTO, SALDO, TIPOPAGO, VENCIMIENTO, ESTADO from gc_facturas order by vencimiento";
                dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            Page.MaintainScrollPositionOnPostBack = true;

        }

        protected void bfac(object sender, EventArgs e)
        {
            string idfac = TextBox1.Text;

            if (idfac == "")
            {
                lblModalTitle.Text = "El campo IDFactura no puede estar vacío";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            }

            else
            {          
                Conexion cn = new Conexion();
                string sql = "select IDFACTURA, IDCLIENTE, FECHAFACTURA, MONTO, SALDO, TIPOPAGO, VENCIMIENTO, ESTADO, ADJUNTO from gc_facturas where idfactura=" + idfac;
                dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);

                if (dt.Rows.Count == 0)
                {
                    lblModalTitle.Text = "El campo IDFactura no existe";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                }

                else
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        
            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void bcl(object sender, EventArgs e)
        {
            string idcl = TextBox2.Text;

            if (idcl== "")
            {
                lblModalTitle.Text = "El campo IDCliente no puede estar vacío";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            }

            else
            {
                Conexion cn = new Conexion();
                string sql = "select IDFACTURA, IDCLIENTE, FECHAFACTURA, MONTO, SALDO, TIPOPAGO, VENCIMIENTO, ESTADO, ADJUNTO from gc_facturas where idcliente=" + idcl + "order by idfactura";
                dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);

                if (dt.Rows.Count == 0)
                {
                    lblModalTitle.Text = "El campo IDCliente no existe";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                }

                else
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void bvenc(object sender, EventArgs e)
        {
            Conexion cn = new Conexion();
            string sql = "select IDFACTURA, IDCLIENTE, FECHAFACTURA, MONTO, SALDO, TIPOPAGO, VENCIMIENTO, ESTADO, ADJUNTO from gc_facturas where estado='DEUDA VENCIDA' order by VENCIMIENTO";
            dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void bts(object sender, EventArgs e)
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
            string idFac = dt.Rows[pos][0].ToString();

            if (e.CommandName == "historial_pagos")
            {
                Response.Redirect("historial_pagos.aspx?idFactura=" + idFac.ToString());
            }

            if (e.CommandName == "historial_gestiones")
            {
                Response.Redirect("historial_gestiones.aspx?idFactura=" + idFac.ToString());
            }


        }

    }
}
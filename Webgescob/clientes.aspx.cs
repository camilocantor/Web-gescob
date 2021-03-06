﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataLib;

namespace WebNif
{
    public partial class clientes : System.Web.UI.Page
    {
        static DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Conexion cnc = new Conexion();
                string sqlc = "select idcliente, nombre, actividad, email, telefono, direccion, contacto from gc_clientes where idcliente > 0 order by idcliente";
                DataTable dtc = (DataTable)cnc.Query(sqlc, Conexion.TipoDato.Table);
                GridView3.DataSource = dtc;
                GridView3.DataBind();
            }

            Page.MaintainScrollPositionOnPostBack = true;

        }

        protected void cliente(object sender, EventArgs e)
        {
            string idcl = TextBox1.Text;

            if (idcl == "")
            {
                lblModalTitle.Text = "El campo ID Cliente no puede estar vacío";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            }

            else
            {
                Conexion cn = new Conexion();
                string sql = "select IDFACTURA, FECHAFACTURA, MONTO, SALDO, VENCIMIENTO, ESTADO from gc_facturas where idcliente=" + idcl;
                dt = (DataTable)cn.Query(sql, Conexion.TipoDato.Table);

                if (dt.Rows.Count == 0)
                {
                    lblModalTitle.Text = "El campo IDFactura no existe";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                }

                else
                {
                    MultiView1.ActiveViewIndex = 1;

                    GridView2.DataSource = dt;
                    GridView2.DataBind();

                    Conexion cn1 = new Conexion();
                    string sql1 = "select idcliente, nombre, actividad, email, telefono, direccion, contacto from gc_clientes where idcliente=" + idcl;
                    DataTable dt1 = (DataTable)cn1.Query(sql1, Conexion.TipoDato.Table);

                    Label1.Text = dt1.Rows[0][0].ToString();
                    Label2.Text = dt1.Rows[0][1].ToString();
                    Label3.Text = dt1.Rows[0][2].ToString();
                    Label4.Text = dt1.Rows[0][3].ToString();
                    Label5.Text = dt1.Rows[0][4].ToString();
                    Label6.Text = dt1.Rows[0][5].ToString();
                    Label7.Text = dt1.Rows[0][6].ToString();                  
                }
            }

            Page.MaintainScrollPositionOnPostBack = true;
        }

        // Historial de pagos de una factura seleccionada
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
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
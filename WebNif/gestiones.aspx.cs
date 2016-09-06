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
    public partial class gestiones : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // tareas pendientes
                llenar_grilla();
            }
        }

        private DataTable datos;

        private void llenar_grilla()
        {
            Conexion cn = new Conexion();
            string Sql = "select TIPOPRESTAMO, TIPO, CUENTA, CSC_INTERES, CSC_RECAUDO, CUENTA_NIFF, CSC_INTERES_NIFF, CSC_RECAUDO_NIFF, DEUDORESCOLGAP, DEUDORESNIIF, SOBRETASA, COSTOAMORTIZADO from cuentas_prestamo ";
            Sql = Sql + "order by tipoprestamo";
            datos = (DataTable)cn.Query(Sql, Conexion.TipoDato.Table);
            GridView4.DataSource = datos;
            GridView4.DataBind();
        }

        protected void GridView4_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView4.EditIndex = -1;
            llenar_grilla();

            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void GridView4_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView4.EditIndex = e.NewEditIndex;
            llenar_grilla();

            Page.MaintainScrollPositionOnPostBack = true;
        }

        // ACTUALIZAR
        protected void GridView4_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = GridView4.Rows[e.RowIndex];

            Label Label_tipoprestamo = fila.FindControl("tipoprestamo") as Label;
            Label Label_tipo = fila.FindControl("tipo") as Label;
            string s_tipoprestamo = Label_tipoprestamo.Text;
            string s_tipo = Label_tipo.Text;

            TextBox t_cuenta = fila.FindControl("CUENTA") as TextBox;
            TextBox t_csc_interes = fila.FindControl("CSC_INTERES") as TextBox;
            TextBox t_csc_recaudo = fila.FindControl("CSC_RECAUDO") as TextBox;
            TextBox t_cuenta_niff = fila.FindControl("CUENTA_NIFF") as TextBox;
            TextBox t_csc_interes_niff = fila.FindControl("CSC_INTERES_NIFF") as TextBox;
            TextBox t_csc_recaudo_niff = fila.FindControl("CSC_RECAUDO_NIFF") as TextBox;
            TextBox t_deudorescolgap = fila.FindControl("DEUDORESCOLGAP") as TextBox;
            TextBox t_deudoresniif = fila.FindControl("DEUDORESNIIF") as TextBox;
            TextBox t_sobretasa = fila.FindControl("SOBRETASA") as TextBox;
            TextBox t_costoamortizado = fila.FindControl("COSTOAMORTIZADO") as TextBox;

            string s_cuenta = t_cuenta.Text;
            string s_csc_interes = t_csc_interes.Text;
            string s_csc_recaudo = t_csc_recaudo.Text;
            string s_cuenta_niff = t_cuenta_niff.Text;
            string s_csc_interes_niff = t_csc_interes_niff.Text;
            string s_csc_recaudo_niff = t_csc_recaudo_niff.Text;
            string s_deudorescolgap = t_deudorescolgap.Text;
            string s_deudoresniif = t_deudoresniif.Text;
            string s_sobretasa = t_sobretasa.Text;
            string s_costoamortizado = t_costoamortizado.Text;

            if (s_cuenta == "")
                s_cuenta = "null";
            if (s_csc_interes == "")
                s_csc_interes = "null";
            if (s_csc_recaudo == "")
                s_csc_recaudo = "null";
            if (s_cuenta_niff == "")
                s_cuenta_niff = "null";
            if (s_csc_interes_niff == "")
                s_csc_interes_niff = "null";
            if (s_csc_recaudo_niff == "")
                s_csc_recaudo_niff = "null";
            if (s_deudorescolgap == "")
                s_deudorescolgap = "null";
            if (s_deudoresniif == "")
                s_deudoresniif = "null";
            if (s_sobretasa == "")
                s_sobretasa = "null";
            if (s_costoamortizado == "")
                s_costoamortizado = "null";


            Conexion cn = new Conexion();
            string sql = "update cuentas_prestamo set CUENTA=" + s_cuenta + ", CSC_INTERES=" + s_csc_interes + ", CSC_RECAUDO=" + s_csc_recaudo + ", CUENTA_NIFF=" + s_cuenta_niff + ", CSC_INTERES_NIFF=" + s_csc_interes_niff + ", CSC_RECAUDO_NIFF=" + s_csc_recaudo_niff + ", DEUDORESCOLGAP=" + s_deudorescolgap + ", DEUDORESNIIF=" + s_deudoresniif + ", SOBRETASA=" + s_sobretasa + ", COSTOAMORTIZADO=" + s_costoamortizado + " where TIPOPRESTAMO=" + s_tipoprestamo;
            cn.Query(sql);

            GridView4.EditIndex = -1;

            llenar_grilla();

            Page.MaintainScrollPositionOnPostBack = true;
        }

    }
}
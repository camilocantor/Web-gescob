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
            string Sql = "select IDFACTURA, CONTADOR, FECHAGESTION, SEGUIMIENTO, ESTADO, ADJUNTO, IDUSUARIO from gc_gestiones order by idfactura ";
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

            //IDFACTURA, CONTADOR, FECHAGESTION, SEGUIMIENTO, ESTADO, ADJUNTO, IDUSUARIO from gc_gestiones

            GridViewRow fila = GridView4.Rows[e.RowIndex];

            Label Label_IDUSUARIO = fila.FindControl("IDUSUARIO") as Label;
            Label Label_IDFACTURA = fila.FindControl("IDFACTURA") as Label;
            Label Label_CONTADOR = fila.FindControl("CONTADOR") as Label;
            string s_IDUSUARIO = Label_IDUSUARIO.Text;
            string s_IDFACTURA = Label_IDFACTURA.Text;
            string s_CONTADOR = Label_CONTADOR.Text;

            TextBox t_FECHAGESTION = fila.FindControl("FECHAGESTION") as TextBox;
            TextBox t_SEGUIMIENTO = fila.FindControl("SEGUIMIENTO") as TextBox;
            TextBox t_ESTADO = fila.FindControl("ESTADO") as TextBox;
            TextBox t_ADJUNTO = fila.FindControl("ADJUNTO") as TextBox;
            string s_FECHAGESTION = t_FECHAGESTION.Text;
            string s_SEGUIMIENTO = t_SEGUIMIENTO.Text;
            string s_ESTADO = t_ESTADO.Text;
            string s_ADJUNTO = t_ADJUNTO.Text;

            if (s_FECHAGESTION == "")
                s_FECHAGESTION = "null";
            if (s_SEGUIMIENTO == "")
                s_SEGUIMIENTO = "null";
            if (s_ESTADO == "")
                s_ESTADO = "null";
            if (s_ADJUNTO == "")
                s_ADJUNTO = "null";


            Conexion cn = new Conexion();
            string sql = "update gc_gestiones set FECHAGESTION=" + s_FECHAGESTION + ", SEGUIMIENTO=" + s_SEGUIMIENTO + ", ESTADO=" + s_ESTADO + ", ADJUNTO=" + s_ADJUNTO;
            cn.Query(sql);

            GridView4.EditIndex = -1;

            llenar_grilla();

            Page.MaintainScrollPositionOnPostBack = true;
        }


    }
}
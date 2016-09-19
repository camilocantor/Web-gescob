using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataLib;

namespace WebNif
{
    public partial class reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;

            if (!Page.IsPostBack)
            {
                Conexion cnc = new Conexion();
                string sqlc = "select max(to_char(periodicidad, 'dd/mm/yyyy')) periodicidad from gc_facturas";
                DataTable dtc = (DataTable)cnc.Query(sqlc, Conexion.TipoDato.Table);
                Label1.Text = dtc.Rows[0][0].ToString();
            }





            //select max(periodicidad)from gc_facturas

            //select sum(saldo) from gc_facturas where periodicidad = '01/01/2016'--19100000

            //select sum(saldo) from gc_facturas where periodicidad = '01/02/2016'--7600000


        }



    }
}
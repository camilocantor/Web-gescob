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
    public partial class nuevagestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void nuevo(object sender, EventArgs e)
        {
            int idfactura = Convert.ToInt32(TextBox1.Text);
            string fechagestion = TextBox2.Text;
            string seguimiento = TextBox3.Text;
            string estado = TextBox4.Text;
            string adjunto = TextBox5.Text;
            int idusuario = Convert.ToInt32(TextBox6.Text);

            Conexion cn = new Conexion();
            string sql = "insert INTO gc_gestiones (idfactura, fechagestion, seguimiento, estado, adjunto, idusuario) VALUES (" + idfactura  + ", '" + fechagestion +"', '"+ seguimiento +"', '"+ estado +"', '"+ adjunto +"', "+ idusuario+") ";
            cn.Query(sql);

            //para actualizar el grid
            Conexion cn1 = new Conexion();
            string sql1 = "select IDFACTURA, FECHAGESTION, SEGUIMIENTO, ESTADO, ADJUNTO, IDUSUARIO from gc_gestiones where idfactura="+ idfactura +" order by idfactura ";
            DataTable dt1 = (DataTable)cn1.Query(sql1, Conexion.TipoDato.Table);
            GridView1.DataSource = dt1;
            GridView1.DataBind();

            //Limpiamos los cuadros de texto
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
        }

       
    }
}
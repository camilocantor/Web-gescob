using System;
using System.Data;
using DataLib;
using System.Web.UI;

namespace WebNif
{
    public partial class iniciarsesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void ingresar(object sender, EventArgs e)
        {
            string u = usuario.Text;
            string co = contraseña.Text;

            if (u == "")
            {
                lblModalTitle.Text = "El campo Usuario no puede estar vacío. Ingrese su cuenta de correo";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            }

            else
            {
                if (co == "")
                {
                    lblModalTitle.Text = "El campo Contraseña no puede estar vacío. Ingrese su contraseña";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                }

                else
                {
                    Conexion cnc = new Conexion();
                    string sqlc = "select CNTRSNA, idusuario from gc_usuarios where email='" + u + "' ";
                    DataTable dtc = (DataTable)cnc.Query(sqlc, Conexion.TipoDato.Table);
                   
                    if (dtc.Rows.Count > 0)
                    {
                        string idus = dtc.Rows[0][1].ToString();
                        string cnt = dtc.Rows[0][0].ToString();
                        string c = GetStringSha256Hash(co);
                        int val = cnt.CompareTo(c);

                        if (val == 0)
                            Response.Redirect("inicio.aspx?idUsuario=" + idus);

                        else
                        {
                            lblModalTitle.Text = "usuario o contraseña incorrectos!";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                        }
                    }

                    else
                    {
                        lblModalTitle.Text = "usuario o contraseña incorrectos!";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    }

                }

            }

        }

        internal static string GetStringSha256Hash(string contraseña)
        {
            if (String.IsNullOrEmpty(contraseña))
                return String.Empty;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(contraseña);
                byte[] hash = sha.ComputeHash(textData);

                string n = BitConverter.ToString(hash).Replace("-", String.Empty);
                return n;

                //03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4 - 1234
            }
        }

        protected void registrar(object sender, EventArgs e)
        {
            string id = txtid.Text;
            string em = txtemail.Text;
            string nom = txtnom.Text;
            string tpo = txttpo.Text;
            string tel = txttel.Text;

            string c = txtcon.Text;
            string con = GetStringSha256Hash(c);

            Conexion cn = new Conexion();
            string sql = "insert INTO gc_usuarios (id, nombre, tipousuario, email, telefono, cntrsna) VALUES (" + id + ", '" + nom + "', '" + tpo + "', '" + em + "', '" + tel + "', '" + con + "') ";
            cn.Query(sql);

            lblModalTitle.Text = "Se registró el usuario con éxito!";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);

        }




    }
}
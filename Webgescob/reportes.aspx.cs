using System;
using System.Web.UI;

namespace WebNif
{
    public partial class reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
        }
    }
}
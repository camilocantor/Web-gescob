﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebNif
{
    public partial class _in : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void login(object sender, EventArgs e)
        {
            Response.Redirect("iniciarsesion.aspx");
        }
    }
}
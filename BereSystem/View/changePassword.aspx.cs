﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BereSystem.View
{
    public partial class changePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void ChangePassword1_CancelButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
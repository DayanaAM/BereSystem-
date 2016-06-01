using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BereSystem.View
{
    public partial class singIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cuwUsuarios_CreatedUser(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
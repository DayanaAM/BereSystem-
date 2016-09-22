using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BereSystem
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole("administrador"))
            {
                //LinkButton link = (LinkButton)LoginView1FindControl("lnkRegistros");
                //link.Visible = true;
                lnkRegistros.Visible = true;
               

            }
            else
            {
                lnkRegistros.Visible = false;

            }
        }
    }
}
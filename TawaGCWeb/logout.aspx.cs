using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace FormsAuth
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie1 = Request.Cookies[FormsAuthentication.FormsCookieName];
            cookie1.Expires = DateTime.Today.AddDays(-10);
            //cookie1.Domain = "tawawebqa:1020";
            Response.Cookies.Add(cookie1);

            Response.Redirect("login.aspx");
        }
    }
}
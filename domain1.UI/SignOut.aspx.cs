using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace domain1.UI
{
    public partial class SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();

            SessionStateSection sessionState = (SessionStateSection)ConfigurationManager.GetSection("system.web/sessionState");

            var cookie = HttpContext.Current.Request.Cookies[sessionState.CookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-3);
                Response.Cookies.Add(cookie);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace domain1.UI
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            //如果本地没有登录
            if (Session["UserId"] == null || string.IsNullOrEmpty(Session["UserId"].ToString()))
            {
                if (Request["hasLogin"] == "true")
                {
                    var userId = Request["userId"];
                    Session["UserId"] = userId;
                }
                else
                {
                    Response.Redirect("http://www.password.com/HasLogin.aspx?returnUrl=" + Request.Url.AbsoluteUri);
                }
            }
            base.OnLoad(e);
        }
    }
}
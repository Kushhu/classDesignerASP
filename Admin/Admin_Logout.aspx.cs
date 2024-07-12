using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin_login"] != null && Session["admin_login"].ToString() != "")
        {
            Session["admin_login"] = "";
            Session["admin_login"] = null;
            Session.Abandon();
            Session.Clear();
        }
        if (Request.Cookies["admin_login"] != null && Request.Cookies["admin_login"].ToString() != "")
        {
            HttpCookie adminLogin = new HttpCookie("admin_login");
            adminLogin.Expires = System.DateTime.Now.AddDays(-1);
            Response.Cookies.Add(adminLogin);
        }

            Response.Redirect("Admin_Login.aspx");
    }
}
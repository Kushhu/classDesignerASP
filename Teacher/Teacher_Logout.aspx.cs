using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teacher_Teacher_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["teacher_login"] != null && Session["teacher_login"].ToString() != "")
        {
            Session["teacher_login"] = "";
            Session["teacher_login"] = null;
            Session.Abandon();
            Session.Clear();
        }
        if (Request.Cookies["teacher_login"] != null && Request.Cookies["teacher_login"].ToString() != "")
        {
            HttpCookie teacherLogin = new HttpCookie("teacher_login");
            teacherLogin.Expires = System.DateTime.Now.AddDays(-1);
            Response.Cookies.Add(teacherLogin);
        }
        Response.Redirect("Teacher_Login.aspx");
    }
}
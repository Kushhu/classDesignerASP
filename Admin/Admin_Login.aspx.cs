using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
public partial class Admin_Admin_Login : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    MySqlDataAdapter da;
    DataSet ds;

    void mycon()
    {
        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["mydbcon"].ToString());
        con.Open();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
        }
    }

    protected void lnk_login_in_Click(object sender, EventArgs e)
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

        mycon();
        try
        {
            cmd = new MySqlCommand("select am_id from admin_master where am_ctn=@am_ctn", con);
            cmd.Parameters.AddWithValue("@am_ctn", txt_admin_ctn.Text);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmd = new MySqlCommand("select am_id from admin_master where am_ctn=@am_ctn and am_status=1", con);
                cmd.Parameters.AddWithValue("@am_ctn", txt_admin_ctn.Text);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmd = new MySqlCommand("select am_id from admin_master where am_ctn=@am_ctn and am_password=@am_password", con);
                    cmd.Parameters.AddWithValue("@am_ctn", txt_admin_ctn.Text);
                    cmd.Parameters.AddWithValue("@am_password", txt_admin_password.Text);
                    da = new MySqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        EncDec enc = new EncDec();
                        Session["admin_login"] = enc.Encrypt(ds.Tables[0].Rows[0]["am_id"].ToString());
                        HttpCookie adminLogin = new HttpCookie("admin_login");
                        adminLogin.Values.Add("adminLoginVal", enc.Encrypt(ds.Tables[0].Rows[0]["am_id"].ToString()));
                        adminLogin.Expires = System.DateTime.Now.AddDays(365);
                        Response.Cookies.Add(adminLogin);

                        Response.Redirect("A_Course_List.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('This Mobile Number OR Password Are Wrong');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('This Mobile Number is Tempory Disabled')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('You are Not Registred with this admin mobile number please try another mobile number')</script>");
            }
            con.Close();
            con.Dispose();
        }
        catch (Exception)
        {
            con.Close();
            con.Dispose();
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

public partial class Teacher_Teacher_Login : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    MySqlDataAdapter da;
    DataSet ds;
    date_time_conversion dtc = new date_time_conversion();
    string email = "";
    public void get_view_state()
    {
        ViewState["email"] = email;
    }
    public void set_view_state()
    {
        email = ViewState["email"].ToString();
    }
    void mycon()
    {
        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["mydbcon"].ToString());
        con.Open();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            get_view_state();
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
        }
        else
        {
            set_view_state();
        }
    }
    protected void lnk_sign_in_Click(object sender, EventArgs e)
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
        mycon();
        cmd = new MySqlCommand("select tm_id from teacher_master where tm_ctn=@tm_ctn", con);
        cmd.Parameters.AddWithValue("@tm_ctn", txt_teacher_ctn.Text);
        da = new MySqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            cmd = new MySqlCommand("select tm_id from teacher_master where tm_ctn=@tm_ctn and tm_status=1", con);
            cmd.Parameters.AddWithValue("@tm_ctn", txt_teacher_ctn.Text);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmd = new MySqlCommand("select tm_id from teacher_master where tm_ctn=@tm_ctn and tm_password=@tm_password", con);
                cmd.Parameters.AddWithValue("@tm_ctn", txt_teacher_ctn.Text);
                cmd.Parameters.AddWithValue("@tm_password", txt_teacher_password.Text);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    EncDec enc = new EncDec();
                    Session["teacher_login"] = enc.Encrypt(ds.Tables[0].Rows[0]["tm_id"].ToString());
                    HttpCookie teacherLogin = new HttpCookie("teacher_login");
                    teacherLogin.Values.Add("teacherLoginVal", enc.Encrypt(ds.Tables[0].Rows[0]["tm_id"].ToString()));
                    teacherLogin.Expires = System.DateTime.Now.AddDays(365);
                    Response.Cookies.Add(teacherLogin);
                    Response.Redirect("Teacher_Profile.aspx");
                }
                else
                {
                    Response.Write("<script>alert('This Mobile Number OR Password Are Wrong');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('This Mobile Number is Temporary Disabled')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('You are Not Registered with this Teacher mobile number please try another mobile number')</script>");
        }
    }
    protected void lnk_save_Click(object sender, EventArgs e)
    {
        if (lnk_save.Text == "Send OTP")
        {
            mycon();
            try
            {
                cmd = new MySqlCommand("select tm_id from teacher_master where tm_email=@tm_email", con);
                cmd.Parameters.AddWithValue("@tm_email", txt_teacher_email.Text);
                email = txt_teacher_email.Text;
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    EncDec enc = new EncDec();
                    string otp = enc.otpgenerate();
                    string msg = "Hello , Your Forget OTP is " + otp;
                    if (GmailSender.SendMail("educationsoni744@gmail.com", "MauliSoni123", txt_teacher_email.Text, "WelCome in Our institute", msg))
                    {
                        Response.Write("<script>alert('Verification OTP Send on EMail ID');</script>");
                    }
                    cmd = new MySqlCommand("update teacher_master set tm_password=@tm_password where tm_email=@tm_email", con);
                    cmd.Parameters.AddWithValue("@tm_password", otp);
                    cmd.Parameters.AddWithValue("@tm_email", email.ToString());
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Teacher Password Update Successfully');window.location.href='Teacher_Login.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('This E-Mail Address is not Registered');</script>");
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
}
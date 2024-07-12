using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.IO;
public partial class Teacher_Teacher_Change_Password : System.Web.UI.Page
{
    MySqlConnection con;
    MySqlCommand cmd;
    MySqlDataAdapter da;
    DataSet ds;
    date_time_conversion dtc = new date_time_conversion();
    void mycon()
    {
        con = new MySqlConnection(ConfigurationManager.ConnectionStrings["mydbcon"].ToString());
        con.Open();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["teacher_login"] != null && Request.Cookies["teacher_login"].ToString() != "")
        {
            if (!IsPostBack)
            {
                EncDec enc = new EncDec();
                Session["teacher_login"] = Convert.ToInt32(enc.Decrypt(Request.Cookies["teacher_login"].Values["teacherLoginVal"].ToString()));
            }
        }
        else
        {
            Response.Redirect("Teacher_Login.aspx");
        }
    }
    protected void lnk_change_password_Click(object sender, EventArgs e)
    {
        mycon();
        cmd = new MySqlCommand("select tm_password from teacher_master where tm_id=@tm_id and tm_password=@tm_password", con);
        cmd.Parameters.AddWithValue("@tm_password", txt_current_password.Text);
        cmd.Parameters.AddWithValue("@tm_id", Session["teacher_login"]);
        da = new MySqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            try
            {
                cmd = new MySqlCommand("update teacher_master set tm_password=@tm_password where tm_id=@tm_id", con);
                cmd.Parameters.AddWithValue("@tm_password", txt_new_password.Text);
                cmd.Parameters.AddWithValue("@tm_id", Session["teacher_login"]);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                Response.Write("<script>alert('Password Change Successfully'); window.location.href='Teacher_Profile.aspx';</script>");
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
        else
        {
            Response.Write("<script>alert('This is Not Correct Current Password')</script>");
        }
    }
}
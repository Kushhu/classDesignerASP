using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;


public partial class Teacher_Teacher_Master : System.Web.UI.MasterPage
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
                mycon();
                try
                {
                    cmd = new MySqlCommand("select tm_img from teacher_master where tm_id=@tm_id", con);
                    cmd.Parameters.AddWithValue("@tm_id", Session["teacher_login"].ToString());
                    string path = cmd.ExecuteScalar().ToString();
                    con.Close();
                    con.Dispose();
                    img_teacher_profile.ImageUrl = path.ToString();

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
        else
        {
            Response.Redirect("Teacher_Login.aspx");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
public partial class Teacher_Teacher_Attendance_List : System.Web.UI.Page
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
    void fill_attendance_details()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from get_attedance_details where atm_tm_id=@atm_tm_id group by aem_atm_id", con);
            cmd.Parameters.AddWithValue("@atm_tm_id", Session["teacher_login"].ToString());
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                rpt_attendance_list.DataSource = ds;
                rpt_attendance_list.DataBind();
            }
            else
            {
                rpt_attendance_list.DataSource = null;
                rpt_attendance_list.DataBind();
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["teacher_login"] != null && Request.Cookies["teacher_login"].ToString() != "")
        {
            if (!IsPostBack)
            {
                EncDec enc = new EncDec();
                Session["teacher_login"] = Convert.ToInt32(enc.Decrypt(Request.Cookies["teacher_login"].Values["teacherLoginVal"].ToString()));
                fill_attendance_details();
            }
        }
        else
        {
            Response.Redirect("Teacher_Login.aspx");
        }
    }
}
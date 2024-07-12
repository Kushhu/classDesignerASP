using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
public partial class Teacher_View_Taken_Attendance_Details : System.Web.UI.Page
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

    void Fill_Student_Wise_Attendance_Details()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from get_attdance_wise_details where aem_atm_id=@aem_atm_id", con);
            cmd.Parameters.AddWithValue("@aem_atm_id", Request.QueryString["aematmid"].ToString());
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rpt_attdance_list.DataSource = ds;
                rpt_attdance_list.DataBind();
            }
            else
            {
                rpt_attdance_list.DataSource = null;
                rpt_attdance_list.DataBind();
            }
            lbl_atm_day.Text = ds.Tables[0].Rows[0]["abm_day"].ToString();
            lbl_atm_abm_id.Text = ds.Tables[0].Rows[0]["atm_abm_id"].ToString();
            lbl_print_date.Text = DateTime.Now.ToString();
            lbl_atm_date.Text = ds.Tables[0].Rows[0]["atm_insdt"].ToString();
            lbl_teacher_name.Text = ds.Tables[0].Rows[0]["tm_name"].ToString();
            lbl_course_name.Text = ds.Tables[0].Rows[0]["cm_name"].ToString();
            lbl_sub_course_name.Text = ds.Tables[0].Rows[0]["scm_name"].ToString();
            lbl_subject_name.Text = ds.Tables[0].Rows[0]["subm_name"].ToString();
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
                if (Request.QueryString["aematmid"] != null && Request.QueryString["aematmid"] != "")
                {
                    Fill_Student_Wise_Attendance_Details();
                }
                else
                {
                    Response.Redirect("Teacher_Attendance_List.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("Teacher_Login.aspx");
        }
    }
}
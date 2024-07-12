using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

public partial class Client_Master : System.Web.UI.MasterPage
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

    void fill_course_for_rpt()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select cm_id,cm_name from course_master where cm_status=1", con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rpt_course_list.DataSource = ds;
                rpt_course_list.DataBind();
            }
            else
            {
                rpt_course_list.DataSource = null;
                rpt_course_list.DataBind();
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
        if (!IsPostBack)
        {
            fill_course_for_rpt();
        }
    }

    protected void rpt_course_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpt_sub_course = (Repeater)e.Item.FindControl("rpt_sub_course");
        HiddenField hf_course_id = (HiddenField)e.Item.FindControl("hf_course_id");
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from get_sub_course_details where cm_status=1 and scm_status=1 and scm_cm_id=@scm_cm_id", con);
            cmd.Parameters.AddWithValue("@scm_cm_id", hf_course_id.Value);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rpt_sub_course.DataSource = ds;
                rpt_sub_course.DataBind();
            }
            else
            {
                rpt_sub_course.DataSource = null;
                rpt_sub_course.DataBind();
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

    protected void lnk_login_Click(object sender, EventArgs e)
    {

        if (Session["student_login"] != null && Session["student_login"].ToString() != "")
        {
            Session["student_login"] = "";
            Session["student_login"] = null;
            Session.Abandon();
            Session.Clear();
        }
        if (Request.Cookies["student_login"] != null && Request.Cookies["student_login"].ToString() != "")
        {
            HttpCookie adminLogin = new HttpCookie("student_login");
            adminLogin.Expires = System.DateTime.Now.AddDays(-1);
            Response.Cookies.Add(adminLogin);
        }

        mycon();
        try
        {
            cmd = new MySqlCommand("select * from student_master where sm_email=@sm_email", con);
            cmd.Parameters.AddWithValue("@sm_email", txt_student_email.Text);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmd = new MySqlCommand("select * from student_master where sm_email=@sm_email and sm_status=1", con);
                cmd.Parameters.AddWithValue("@sm_email", txt_student_email.Text);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmd = new MySqlCommand("select * from student_master where sm_email=@sm_email and sm_password=@sm_password and sm_status=1", con);
                    cmd.Parameters.AddWithValue("@sm_email", txt_student_email.Text);
                    cmd.Parameters.AddWithValue("@sm_password", txt_student_password.Text);
                    da = new MySqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        EncDec enc = new EncDec();
                        Session["student_login"] = enc.Encrypt(ds.Tables[0].Rows[0]["sm_id"].ToString());
                        HttpCookie studentLogin = new HttpCookie("student_login");
                        studentLogin.Values.Add("adminLoginVal", enc.Encrypt(ds.Tables[0].Rows[0]["sm_id"].ToString()));
                        studentLogin.Expires = System.DateTime.Now.AddDays(365);
                        Response.Cookies.Add(studentLogin);
                        Response.Redirect("Student_Info.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('E-Mail ID or Password is wrong'); windown.location.href='index.aspx';</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('This Student is Temporary Blocked by Admin'); windown.location.href='index.aspx';</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('This Student is Registered with Class Designer'); windown.location.href='index.aspx';</script>");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
public partial class Teacher_Teacher_Take_Attendance : System.Web.UI.Page
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
    void fill_attendance_list()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from get_student_fees_payment_details where sm_scm_id=@sm_scm_id and sm_status=1", con);
            cmd.Parameters.AddWithValue("@sm_scm_id", Request.QueryString["amscmid"].ToString());
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rpt_take_attendance.DataSource = ds;
                rpt_take_attendance.DataBind();
            }
            else
            {
                rpt_take_attendance.DataSource = null;
                rpt_take_attendance.DataBind();
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
    void chk_already_attdance_already_taken()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select atm_id from attendance_master where atm_abm_id=@atm_abm_id and date(atm_insdt) = date(@atm_insdt)", con);
            cmd.Parameters.AddWithValue("@atm_abm_id", Request.QueryString["atmabmid"].ToString());
            DateTime atmdate = dtc.GetIndianDateTime();
            cmd.Parameters.AddWithValue("@atm_insdt", atmdate);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Write("<script>alert('Already Taken Attendance'); window.location.href='Teacher_Attendance_List.aspx'; </script>");
            }
            else
            {
                fill_attendance_list();
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

                if (Request.QueryString["atmabmid"] != null && Request.QueryString["atmabmid"] != "" && Request.QueryString["amscmid"] != null && Request.QueryString["amscmid"] != "")
                {
                    chk_already_attdance_already_taken();
                }
                else
                {
                    Response.Redirect("Teacher_Time_Table.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("Teacher_Login.aspx");
        }
    }
    protected void lnk_save_attendance_Click(object sender, EventArgs e)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert attendance_master values (NULL,@atm_abm_id,@atm_tm_id,@atm_insdt,@atm_insrid,@atm_logdt,@atm_logrid)", con);
            cmd.Parameters.AddWithValue("@atm_abm_id", Request.QueryString["atmabmid"].ToString());
            cmd.Parameters.AddWithValue("@atm_tm_id", Session["teacher_login"].ToString());
            cmd.Parameters.AddWithValue("@atm_insdt", dtc.GetIndianDateTime());
            cmd.Parameters.AddWithValue("@atm_insrid", Session["teacher_login"].ToString());
            cmd.Parameters.AddWithValue("@atm_logdt", dtc.GetIndianDateTime());
            cmd.Parameters.AddWithValue("@atm_logrid", Session["teacher_login"].ToString());
            cmd.ExecuteNonQuery();
            cmd = new MySqlCommand("select max(atm_id) from attendance_master", con);
            int maxatmid = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            foreach (RepeaterItem item in rpt_take_attendance.Items)
            {
                HiddenField hf_sm_id = (HiddenField)item.FindControl("hf_sm_id");
                CheckBox chk_attendance = (CheckBox)item.FindControl("chk_attendance");
                cmd = new MySqlCommand("insert into attendance_entry_master values (NULL,@aem_atm_id,@aem_sm_id,@aem_sm_status,@aem_insdt,@aem_insrid,@aem_logdt,@aem_logrid)", con);
                cmd.Parameters.AddWithValue("@aem_atm_id", maxatmid);
                cmd.Parameters.AddWithValue("@aem_sm_id", hf_sm_id.Value);
                if (chk_attendance.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@aem_sm_status", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@aem_sm_status", 0);
                }
                cmd.Parameters.AddWithValue("@aem_insdt", dtc.GetIndianDateTime());
                cmd.Parameters.AddWithValue("@aem_insrid", Session["teacher_login"].ToString());
                cmd.Parameters.AddWithValue("@aem_logdt", dtc.GetIndianDateTime());
                cmd.Parameters.AddWithValue("@aem_logrid", Session["teacher_login"].ToString());
                cmd.ExecuteNonQuery();
            }
            con.Close();
            con.Dispose();
            Response.Write("<script>alert('Attendance Added Successfully'); window.location.href='Teacher_Attendance_List.aspx'; </script>");
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
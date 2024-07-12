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

public partial class Teacher_Teacher_Time_Table : System.Web.UI.Page
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
    void Fill_Days_Row()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from day_master where dm_status=1", con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                rpt_day.DataSource = ds;
                rpt_day.DataBind();
            }
            else
            {
                rpt_day.DataSource = null;
                rpt_day.DataBind();
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
    void Fill_Time_Block()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from timing_master where tim_status=1", con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                rpt_time.DataSource = ds;
                rpt_time.DataBind();
            }
            else
            {
                rpt_time.DataSource = null;
                rpt_time.DataBind();
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
                Fill_Days_Row();
                Fill_Time_Block();
            }
        }
        else
        {
            Response.Redirect("Teacher_Login.aspx");
        }
    }

    public DataTable Fill_Time_Table(string TimingID)
    {
        DataTable dtData = new DataTable();
        dtData.Columns.Add("cm_name", typeof(string));
        dtData.Columns.Add("scm_name", typeof(string));
        dtData.Columns.Add("subm_name", typeof(string));
        dtData.Columns.Add("abm_day", typeof(string));
        dtData.Columns.Add("cm_id", typeof(string));
        dtData.Columns.Add("scm_id", typeof(string));
        dtData.Columns.Add("subm_id", typeof(string));
        dtData.Columns.Add("abm_id", typeof(string));
        DataRow dr;
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from day_master", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string teacher_login = Session["teacher_login"].ToString();
                string day = dt.Rows[i]["dm_day"].ToString();
                dr = dtData.NewRow();
                cmd = new MySqlCommand("Select * from get_assign_batch_details Where abm_day IN (select abm_day from assign_batch_master) and tim_id=@timid and tm_id=@tm_id and abm_day=@abm_day and cm_status=1 and scm_status=1 and subm_status=1", con);
                cmd.Parameters.AddWithValue("@timid", TimingID);
                cmd.Parameters.AddWithValue("@tm_id", teacher_login);
                cmd.Parameters.AddWithValue("@abm_day", day);
                da = new MySqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    dr["abm_id"] = dt1.Rows[0]["abm_id"].ToString();
                    dr["cm_name"] = dt1.Rows[0]["cm_name"].ToString() + "<b>|</b>";
                    dr["scm_name"] = dt1.Rows[0]["scm_name"].ToString();
                    dr["subm_name"] = "Subject :- " + dt1.Rows[0]["subm_name"].ToString();
                    dr["abm_day"] = day;
                    dr["cm_id"] = dt1.Rows[0]["cm_id"].ToString();
                    dr["scm_id"] = dt1.Rows[0]["scm_id"].ToString();
                    dr["subm_id"] = dt1.Rows[0]["subm_id"].ToString();
                }
                else
                {
                    dr["abm_id"] = "";
                    dr["cm_name"] = "||";
                    dr["scm_name"] = "|";
                    dr["subm_name"] = "// \\";
                    dr["abm_day"] = day;
                    dr["cm_id"] = "";
                    dr["scm_id"] = "";
                    dr["subm_id"] = "";
                }
                dtData.Rows.Add(dr);
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
        return dtData;
    }
    protected void rpt_time_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpt_time_table = (Repeater)e.Item.FindControl("rpt_time_table");
        HiddenField hf_tim_id = (HiddenField)e.Item.FindControl("hf_tim_id");
        mycon();
        rpt_time_table.DataSource = Fill_Time_Table(hf_tim_id.Value);
        rpt_time_table.DataBind();
        con.Close();
    }
    protected void rpt_time_table_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        string day = System.DateTime.Now.DayOfWeek.ToString();
        HiddenField hf_abm_id = (HiddenField)e.Item.FindControl("hf_abm_id");
        HiddenField hf_abm_day = (HiddenField)e.Item.FindControl("hf_abm_day");
        HyperLink hl_take_attendance = (HyperLink)e.Item.FindControl("hl_take_attendance");
        if (hf_abm_id.Value != null && hf_abm_id.Value.ToString() != "")
        {
            if (hf_abm_day.Value.Trim() == day.Trim())
            {
                hl_take_attendance.Visible = true;
            }
        }
    }
}
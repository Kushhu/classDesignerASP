using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
public partial class Admin_A_Assign_Batch_Form : System.Web.UI.Page
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
    void Fill_Course_Dropdown()
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
                dr_course_name.DataSource = ds;
                dr_course_name.DataTextField = "cm_name";
                dr_course_name.DataValueField = "cm_id";
                dr_course_name.DataBind();
                dr_course_name.Attributes.Add("style", "text-transform:capitalize");
                con.Close();
                con.Dispose();
                dr_course_name.Items.Insert(0, "-- Select Course --");
                dr_course_name.Items[0].Value = "0";
            }
            else
            {
                dr_course_name.Items.Clear();
                dr_course_name.Items.Insert(0, "-- Select Course  --");
                dr_course_name.Items[0].Value = "0";
            }
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
    void Fill_Sub_Course_Dropdown()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select scm_id,scm_name from get_sub_course_details where scm_status=1 and scm_cm_id=@scm_cm_id", con);
            cmd.Parameters.AddWithValue("@scm_cm_id", dr_course_name.SelectedItem.Value);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr_sub_course_name.DataSource = ds;
                dr_sub_course_name.DataTextField = "scm_name";
                dr_sub_course_name.DataValueField = "scm_id";
                dr_sub_course_name.DataBind();
                dr_sub_course_name.Attributes.Add("style", "text-transform:capitalize");
                con.Close();
                con.Dispose();
                dr_sub_course_name.Items.Insert(0, "-- Select Sub Course --");
                dr_sub_course_name.Items[0].Value = "0";
            }
            else
            {
                dr_sub_course_name.Items.Clear();
                dr_sub_course_name.Items.Insert(0, "-- Select Sub Course  --");
                dr_sub_course_name.Items[0].Value = "0";
            }
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
    void Fill_Subject_Dropdown()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from get_subject_details where subm_status=1 and subm_scm_id=@subm_scm_id", con);
            cmd.Parameters.AddWithValue("@subm_scm_id", dr_sub_course_name.SelectedItem.Value);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr_subject_name.DataSource = ds;
                dr_subject_name.DataTextField = "subm_name";
                dr_subject_name.DataValueField = "subm_id";
                dr_subject_name.DataBind();
                dr_subject_name.Items.Insert(0, "-- Select Subject Name --");
                dr_subject_name.Items[0].Value = "0";
            }
            else
            {
                dr_subject_name.Items.Clear();
                dr_subject_name.Items.Insert(0, "-- Select Subject Name --");
                dr_subject_name.Items[0].Value = "0";
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
    void Fill_Teacher_Dropdown()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select tm_id,tm_name from teacher_master where tm_status=1", con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr_teacher_name.DataSource = ds;
                dr_teacher_name.DataTextField = "tm_name";
                dr_teacher_name.DataValueField = "tm_id";
                dr_teacher_name.DataBind();

                dr_teacher_name.Items.Insert(0, "-- Select Teacher Name --");
                dr_teacher_name.Items[0].Value = "0";
            }
            else
            {
                dr_teacher_name.Items.Clear();
                dr_teacher_name.Items.Insert(0, "-- Select Teacher Name --");
                dr_teacher_name.Items[0].Value = "0";
            }
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

    void Fill_Day_Dropdown()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select dm_id,dm_day from day_master where dm_status=1", con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr_day_list.DataSource = ds;
                dr_day_list.DataTextField = "dm_day";
                dr_day_list.DataValueField = "dm_id";
                dr_day_list.DataBind();
                dr_day_list.Items.Insert(0, "-- Select Day --");
                dr_day_list.Items[0].Value = "0";
            }
            else
            {
                dr_day_list.Items.Clear();
                dr_day_list.Items.Insert(0, "-- Select Day --");
                dr_day_list.Items[0].Value = "0";
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
    void Fill_Time_Dropdown()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select concat(tim_start_time,' - ',tim_end_time) as TIME,tim_id from timing_master where tim_status=1", con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr_time_list.DataSource = ds;
                dr_time_list.DataTextField = "TIME";
                dr_time_list.DataValueField = "tim_id";
                dr_time_list.DataBind();

                dr_time_list.Items.Insert(0, "-- Select Time --");
                dr_time_list.Items[0].Value = "0";
            }
            else
            {
                dr_time_list.Items.Clear();
                dr_time_list.Items.Insert(0, "-- Select Time --");
                dr_time_list.Items[0].Value = "0";
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

    void Fill_Assign_Batch_For_Edit()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from get_assign_batch_details where abm_id=@abm_id", con);
            cmd.Parameters.AddWithValue("@abm_id", Request.QueryString["abmid"].ToString());
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr_teacher_name.Text = ds.Tables[0].Rows[0]["abm_tm_id"].ToString();
                string subcourseid = ds.Tables[0].Rows[0]["subm_scm_id"].ToString();
                string subjectid = ds.Tables[0].Rows[0]["abm_subm_id"].ToString();
                dr_course_name.Text = ds.Tables[0].Rows[0]["scm_cm_id"].ToString();
                dr_day_list.SelectedItem.Text = ds.Tables[0].Rows[0]["abm_day"].ToString();
                dr_time_list.Text = ds.Tables[0].Rows[0]["abm_tim_id"].ToString();
                if (ds.Tables[0].Rows[0]["abm_status"].ToString() == "1")
                {
                    rdo_active.Checked = true;
                }
                else if (ds.Tables[0].Rows[0]["abm_status"].ToString() == "0")
                {
                    rdo_deactive.Checked = true;
                }
                Fill_Sub_Course_Dropdown();
                dr_sub_course_name.Text = subcourseid.ToString();
                Fill_Subject_Dropdown();
                dr_subject_name.Text = subjectid.ToString();
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
        if (Request.Cookies["admin_login"] != null && Request.Cookies["admin_login"].ToString() != "")
        {
            if (!IsPostBack)
            {
                EncDec enc = new EncDec();
                Session["admin_login"] = Convert.ToInt32(enc.Decrypt(Request.Cookies["admin_login"].Values["adminLoginVal"].ToString()));
                Fill_Course_Dropdown();
                Fill_Day_Dropdown();
                Fill_Teacher_Dropdown();
                Fill_Time_Dropdown();
                dr_sub_course_name.Items.Insert(0, "-- Select Sub Course  --");
                dr_sub_course_name.Items[0].Value = "0";
                dr_subject_name.Items.Insert(0, "-- Select Subject --");
                dr_subject_name.Items[0].Value = "0";
                if (Request.QueryString["abmid"] != null && Request.QueryString["abmid"].ToString() != "")
                {
                    Fill_Assign_Batch_For_Edit();
                }
            }
        }
        else
        {
            Response.Redirect("Admin_Login.aspx");
        }
    }
    protected void lnk_save_Click(object sender, EventArgs e)
    {
        bool decision = true;
        mycon();
        cmd = new MySqlCommand("select abm_id from assign_batch_master where abm_id!=@abm_id and abm_tm_id=@abm_tm_id AND abm_scm_id=@abm_scm_id and abm_day=@abm_day AND abm_tim_id=@abm_tim_id", con);
        cmd.Parameters.AddWithValue("@abm_tm_id", dr_teacher_name.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@abm_scm_id", dr_sub_course_name.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@abm_day", dr_day_list.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@abm_tim_id", dr_time_list.SelectedItem.Value);
        if (Request.QueryString["abmid"] != null && Request.QueryString["abmid"].ToString() != "")
        {
            cmd.Parameters.AddWithValue("@abm_id", Request.QueryString["abmid"].ToString());
        }
        else
        {
            cmd.Parameters.AddWithValue("@abm_id", 0);
        }
        da = new MySqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            decision = false;
        }
        else
        {
            decision = true;
        }
        if (decision == true)
        {
            if (Request.QueryString["abmid"] != null && Request.QueryString["abmid"].ToString() != "")
            {
                mycon();
                try
                {
                    cmd = new MySqlCommand("update assign_batch_master set abm_tm_id=@abm_tm_id ,abm_scm_id=@abm_scm_id, abm_subm_id=@abm_subm_id ,abm_day=@abm_day, abm_tim_id=@abm_tim_id , abm_status=@abm_status, abm_logdt=@abm_logdt , abm_logrid=@abm_logrid where abm_id=@abm_id", con);
                    cmd.Parameters.AddWithValue("@abm_tm_id", dr_teacher_name.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@abm_scm_id", dr_sub_course_name.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@abm_subm_id", dr_subject_name.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@abm_day", dr_day_list.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@abm_tim_id", dr_time_list.SelectedItem.Value);
                    if (rdo_active.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@abm_status", 1);
                    }
                    else if (rdo_deactive.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@abm_status", 0);
                    }
                    cmd.Parameters.AddWithValue("@abm_logdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@abm_logrid", Session["admin_login"]);
                    cmd.Parameters.AddWithValue("@abm_id", Request.QueryString["abmid"].ToString());
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Assign Batch Update Successfully'); window.location.href='A_Assign_Batch_List.aspx';</script>");
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
                mycon();
                cmd = new MySqlCommand("insert into assign_batch_master values (NULL,@abm_tm_id,@abm_scm_id,@abm_subm_id,@abm_day,@abm_tim_id,@abm_status,@abm_insdt,@abm_insrid,@abm_logdt,@abm_logrid)", con);
                cmd.Parameters.AddWithValue("@abm_tm_id", dr_teacher_name.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@abm_scm_id", dr_sub_course_name.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@abm_subm_id", dr_subject_name.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@abm_day", dr_day_list.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@abm_tim_id", dr_time_list.SelectedItem.Value);
                if (rdo_active.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@abm_status", 1);
                }
                else if (rdo_deactive.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@abm_status", 0);
                }
                cmd.Parameters.AddWithValue("@abm_insdt", dtc.GetIndianDateTime());
                cmd.Parameters.AddWithValue("@abm_insrid", Session["admin_login"]);
                cmd.Parameters.AddWithValue("@abm_logdt", dtc.GetIndianDateTime());
                cmd.Parameters.AddWithValue("@abm_logrid", Session["admin_login"]);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Assign Batch Added Successfully'); window.location.href='A_Assign_Batch_List.aspx';</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('At Same Day Same Time This Teacher Already Added');</script>");
        }
    }
    protected void lnk_clear_Click(object sender, EventArgs e)
    {
        Server.Transfer("A_Assign_Batch_Form.aspx");
    }
    protected void dr_course_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_Sub_Course_Dropdown();
    }
    protected void dr_sub_course_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_Subject_Dropdown();
    }
}
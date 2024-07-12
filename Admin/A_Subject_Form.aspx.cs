using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
public partial class Admin_A_Subject_Form : System.Web.UI.Page
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
    void Fill_Course_For_Dropdown()
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
    void Fill_Subject_For_Edit()
    {
        mycon();
        try
        {
            lnk_save.Text = "<span class='feather icon-edit'>&nbsp;&nbsp;Update</span>";
            cmd = new MySqlCommand("select * from get_subject_details where subm_id=@subm_id", con);
            cmd.Parameters.AddWithValue("@subm_id", Request.QueryString["submid"].ToString());
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr_course_name.Text = ds.Tables[0].Rows[0]["scm_cm_id"].ToString();
                string scmid = ds.Tables[0].Rows[0]["subm_scm_id"].ToString();
                txt_subject_name.Text = ds.Tables[0].Rows[0]["subm_name"].ToString();
                if (ds.Tables[0].Rows[0]["subm_status"].ToString() == "1")
                {
                    rdo_active.Checked = true;
                }
                else if (ds.Tables[0].Rows[0]["subm_status"].ToString() == "0")
                {
                    rdo_deactive.Checked = true;
                }
                Fill_Sub_Course_Dropdown();
                dr_sub_course_name.Text = scmid.ToString();
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
                Fill_Course_For_Dropdown();
                dr_sub_course_name.Items.Insert(0, "-- Select Sub Course  --");
                dr_sub_course_name.Items[0].Value = "0";
                if (Request.QueryString["submid"] != null && Request.QueryString["submid"].ToString() != "")
                {
                    Fill_Subject_For_Edit();
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
        cmd = new MySqlCommand("select subm_id from subject_master where subm_name=@subm_name and subm_scm_id=@subm_scm_id and subm_id!=@subm_id ", con);
        cmd.Parameters.AddWithValue("@subm_scm_id", dr_sub_course_name.SelectedItem.Value);
        cmd.Parameters.AddWithValue("@subm_name", txt_subject_name.Text);
        if (Request.QueryString["submid"] != null && Request.QueryString["submid"].ToString() != "")
        {
            cmd.Parameters.AddWithValue("@subm_id", Request.QueryString["submid"]);
        }
        else
        {
            cmd.Parameters.AddWithValue("@subm_id", 0);
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
            if (Request.QueryString["submid"] != null && Request.QueryString["submid"].ToString() != "")
            {
                mycon();
                try
                {
                    cmd = new MySqlCommand("update subject_master set subm_scm_id=@subm_scm_id , subm_name=@subm_name ,subm_status=@subm_status , subm_logdt=@subm_logdt , subm_logrid=@subm_logrid where subm_id=@subm_id", con);
                    cmd.Parameters.AddWithValue("@subm_scm_id", dr_sub_course_name.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@subm_name", txt_subject_name.Text);
                    if (rdo_active.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@subm_status", 1);
                    }
                    else if (rdo_deactive.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@subm_status", 0);
                    }
                    cmd.Parameters.AddWithValue("@subm_logdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@subm_logrid", Session["admin_login"].ToString());
                    cmd.Parameters.AddWithValue("@subm_id", Request.QueryString["submid"].ToString());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    Response.Write("<script>alert('Subject Update Successfully'); window.location.href='A_Subject_List.aspx';</script>");
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
                try
                {
                    cmd = new MySqlCommand("insert into subject_master values(NULL,@subm_scm_id,@subm_name,@subm_status,@subm_insdt,@subm_insrid,@subm_logdt,@subm_logrid)", con);
                    cmd.Parameters.AddWithValue("@subm_scm_id", dr_sub_course_name.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@subm_name", txt_subject_name.Text);
                    if (rdo_active.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@subm_status", 1);
                    }
                    else if (rdo_deactive.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@subm_status", 0);
                    }
                    cmd.Parameters.AddWithValue("@subm_insdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@subm_insrid", Session["admin_login"]);
                    cmd.Parameters.AddWithValue("@subm_logdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@subm_logrid", Session["admin_login"]);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    Response.Write("<script>alert('Subject Added Successfully'); window.location.href='A_Subject_List.aspx';</script>");
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
            Response.Write("<script>alert('Subject is Already Added');</script>");
        }
        con.Close();
        con.Dispose();
    }
    protected void lnk_clear_Click(object sender, EventArgs e)
    {
        Server.Transfer("A_Subject_Form.aspx");
    }
    protected void dr_course_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_Sub_Course_Dropdown();
    }
}
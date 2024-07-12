using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
public partial class Admin_A_SubCourse_Form : System.Web.UI.Page
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

    void Fill_Sub_Course_For_Edit()
    {
        mycon();
        try
        {
            lnk_save.Text = "<span class='feather icon-edit'>&nbsp;&nbsp;Update</span>";
            cmd = new MySqlCommand("select * from get_sub_course_details where scm_id=@scm_id", con);
            cmd.Parameters.AddWithValue("@scm_id", Request.QueryString["scmid"].ToString());
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr_course_name.Text = ds.Tables[0].Rows[0]["scm_cm_id"].ToString();
                txt_sub_course_name.Text = ds.Tables[0].Rows[0]["scm_name"].ToString();
                if (ds.Tables[0].Rows[0]["scm_status"].ToString() == "1")
                {
                    rdo_active.Checked = true;
                }
                else if (ds.Tables[0].Rows[0]["scm_status"].ToString() == "0")
                {
                    rdo_deactive.Checked = true;
                }
            }
            else
            {
                Response.Write("<script>alert('No Sub Course Available'); window.location.href='A_Sub_Course_List.aspx';</script>");
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["admin_login"] != null && Request.Cookies["admin_login"].ToString() != "")
        {
            if (!IsPostBack)
            {
                EncDec enc = new EncDec();
                Session["admin_login"] = Convert.ToInt32(enc.Decrypt(Request.Cookies["admin_login"].Values["adminLoginVal"].ToString()));
                Fill_Course_For_Dropdown();
                if (Request.QueryString["scmid"] != null && Request.QueryString["scmid"].ToString() != "")
                {
                    Fill_Sub_Course_For_Edit();
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
        cmd = new MySqlCommand("select scm_id from sub_course_master where scm_name=@scm_name and scm_cm_id=@scm_cm_id and scm_id!=scm_id", con);
        cmd.Parameters.AddWithValue("@scm_name", txt_sub_course_name.Text);
        cmd.Parameters.AddWithValue("@scm_cm_id", dr_course_name.SelectedItem.Value);
        if (Request.QueryString["scmid"] != null && Request.QueryString["scmid"].ToString() != "")
        {
            cmd.Parameters.AddWithValue("@scm_id", Request.QueryString["scmid"].ToString());
        }
        else
        {
            cmd.Parameters.AddWithValue("@scm_id", 0);
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
            if (Request.QueryString["scmid"] != null && Request.QueryString["scmid"].ToString() != "")
            {
                mycon();
                try
                {
                    cmd = new MySqlCommand("update sub_course_master set scm_cm_id=@scm_cm_id,scm_name =@scm_name,scm_status=@scm_status,scm_logdt=@scm_logdt, scm_logrid=@scm_logrid where scm_id=@scm_id", con);
                    cmd.Parameters.AddWithValue("@scm_cm_id", dr_course_name.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@scm_name", txt_sub_course_name.Text);
                    if (rdo_active.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@scm_status", 1);
                    }
                    else if (rdo_deactive.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@scm_status", 0);
                    }
                    cmd.Parameters.AddWithValue("@scm_id", Request.QueryString["scmid"].ToString());
                    cmd.Parameters.AddWithValue("@scm_logdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@scm_logrid", Session["admin_login"]);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    Response.Write("<script>alert('Sub Cousre Update Sucessully'); window.location.href='A_Sub_Course_List.aspx';</script>");
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
                    cmd = new MySqlCommand("insert into sub_course_master values (NULL,@scm_cm_id,@scm_name,@scm_status,@scm_remark,@scm_insdt,@scm_insrid,@scm_logdt,@scm_logird)", con);
                    cmd.Parameters.AddWithValue("@scm_cm_id", dr_course_name.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@scm_name", txt_sub_course_name.Text);
                    if (rdo_active.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@scm_status", 1);
                    }
                    else if (rdo_deactive.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@scm_status", 0);
                    }
                    cmd.Parameters.AddWithValue("@scm_remark", "");
                    cmd.Parameters.AddWithValue("@scm_insdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@scm_insrid", Session["admin_login"]);
                    cmd.Parameters.AddWithValue("@scm_logdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@scm_logird", Session["admin_login"]);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    Response.Write("<script>alert('Sub Cousre Added Sucessully'); window.location.href='A_Sub_Course_List.aspx';</script>");
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
            Response.Write("<script>alert('This Sub Course is Already Added');</script>");
        }
    }

    protected void lnk_clear_Click(object sender, EventArgs e)
    {
        Server.Transfer("A_Sub_Course_Form.aspx");
    }
}
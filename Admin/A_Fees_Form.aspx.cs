using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
public partial class Admin_A_Fees_Form : System.Web.UI.Page
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
                con.Close();
                con.Dispose();
                dr_course_name.Items.Insert(0, "-- Select Course --");
                dr_course_name.Items[0].Value = "0";
                dr_course_name.Attributes.Add("style", "text-transform:capitalize");
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
            cmd = new MySqlCommand("select scm_id,scm_name from get_sub_course_details where cm_status=1 and scm_cm_id=@scm_cm_id", con);
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

                con.Close();
                con.Dispose();

                dr_sub_course_name.Items.Insert(0, "-- Select Sub Course  --");
                dr_sub_course_name.Items[0].Value = "0";
                dr_sub_course_name.Attributes.Add("style", "text-transform:capitalize");
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
    void Fill_Fees_For_Edit()
    {
        mycon();
        try
        {
            lnk_save.Text = "<span class='feather icon-edit'>&nbsp;&nbsp;Update</span>";
            cmd = new MySqlCommand("select * from get_fees_details where fm_id=@fm_id ", con);
            cmd.Parameters.AddWithValue("@fm_id", Request.QueryString["fmid"]);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr_course_name.Text = ds.Tables[0].Rows[0]["scm_cm_id"].ToString();
                string scmid = ds.Tables[0].Rows[0]["fm_scm_id"].ToString();
                txt_fees_amount.Text = ds.Tables[0].Rows[0]["fm_amount"].ToString();

                if (ds.Tables[0].Rows[0]["fm_status"].ToString() == "1")
                {
                    rdo_active.Checked = true;
                }
                else if (ds.Tables[0].Rows[0]["fm_status"].ToString() == "0")
                {
                    rdo_deactive.Checked = true;
                }
                Fill_Sub_Course_Dropdown();
                dr_sub_course_name.Text = scmid.ToString();
            }
            else
            {
                Response.Write("<script>alert('Not Data Available'); window.location.href='A_Fees_List.aspx';</script>");
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

                dr_sub_course_name.Items.Insert(0, "-- Select Sub Course --");
                dr_sub_course_name.Items[0].Value = "0";

                if (Request.QueryString["fmid"] != null && Request.QueryString["fmid"].ToString() != "")
                {
                    Fill_Fees_For_Edit();
                }
            }
        }
        else
        {
                Response.Redirect("Admin_Login.aspx");
        }
    }

    protected void dr_course_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_Sub_Course_Dropdown();
    }
    protected void lnk_save_Click(object sender, EventArgs e)
    {
        bool decision = true;
        mycon();
        cmd = new MySqlCommand("select fm_id from fees_master where fm_scm_id=@fm_scm_id and fm_id!=@fm_id", con);
        cmd.Parameters.AddWithValue("@fm_scm_id", dr_sub_course_name.SelectedItem.Value);
        if (Request.QueryString["fmid"] != null && Request.QueryString["fmid"].ToString() != "")
        {
            cmd.Parameters.AddWithValue("@fm_id", Request.QueryString["fmid"].ToString());
        }
        else
        {
            cmd.Parameters.AddWithValue("@fm_id", 0);
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
            if (Request.QueryString["fmid"] != null && Request.QueryString["fmid"].ToString() != "")
            {
                mycon();
                try
                {
                    cmd = new MySqlCommand("update fees_master set fm_scm_id=@fm_scm_id , fm_amount=@fm_amount ,fm_status=@fm_status, fm_logdt=@fm_logdt ,fm_logrid=@fm_logrid where fm_id=@fm_id", con);
                    cmd.Parameters.AddWithValue("@fm_scm_id", dr_sub_course_name.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@fm_amount", txt_fees_amount.Text);
                    cmd.Parameters.AddWithValue("@fm_logdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@fm_logrid", Session["admin_login"]);
                    if (rdo_active.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@fm_status", 1);
                    }
                    else if (rdo_deactive.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@fm_status", 0);
                    }
                    cmd.Parameters.AddWithValue("@fm_id", Request.QueryString["fmid"]);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    Response.Write("<script>alert('Fees Update Successfully'); window.location.href='A_Fees_List.aspx';</script>");
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
                    cmd = new MySqlCommand("insert into fees_master values(NULL,@fm_scm_id,@fm_amount,@fm_remark,@fm_status,@fm_insdt,@fm_insrid,@fm_logdt,@fm_logrid)", con);
                    cmd.Parameters.AddWithValue("@fm_scm_id", dr_sub_course_name.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@fm_amount", txt_fees_amount.Text);
                    cmd.Parameters.AddWithValue("@fm_remark", "");
                    if (rdo_active.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@fm_status", 1);
                    }
                    else if (rdo_deactive.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@fm_status", 0);
                    }
                    cmd.Parameters.AddWithValue("@fm_insdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@fm_insrid", Session["admin_login"]);
                    cmd.Parameters.AddWithValue("@fm_logdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@fm_logrid", Session["admin_login"]);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    Response.Write("<script>alert('Fees Create Successfully'); window.location.href='A_Fees_List.aspx';</script>");
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
            Response.Write("<script>alert('This Fees Already Added');</script>");
        }
    }
    protected void lnk_clear_Click(object sender, EventArgs e)
    {
        Server.Transfer("A_Fees_Form.aspx");
    }
}
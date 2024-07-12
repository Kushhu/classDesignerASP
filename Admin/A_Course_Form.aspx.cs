using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

public partial class Admin_A_CourseForm : System.Web.UI.Page
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
    void fill_course_for_edit()
    {
        mycon();
        try
        {
            lnk_save.Text = "<span class='feather icon-edit'>&nbsp;&nbsp;Update</span>";
            cmd = new MySqlCommand("select * from course_master where cm_id=@cm_id", con);
            cmd.Parameters.AddWithValue("@cm_id", Request.QueryString["cmid"].ToString());
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_course_name.Text = ds.Tables[0].Rows[0]["cm_name"].ToString();
                if (ds.Tables[0].Rows[0]["cm_status"].ToString() == "1")
                {
                    rdo_active.Checked = true;
                }
                else if (ds.Tables[0].Rows[0]["cm_status"].ToString() == "0")
                {
                    rdo_deactive.Checked = true;
                }
            }
            else
            {
                Response.Write("<script>alert('No Course Available'); window.location.href='A_Course_List.aspx';</script>");
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
                if (Request.QueryString["cmid"] != null && Request.QueryString["cmid"].ToString() != "")
                {
                    fill_course_for_edit();
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
        cmd = new MySqlCommand("select * from course_master where cm_name=@cm_name and cm_id!=@cm_id ", con);
        cmd.Parameters.AddWithValue("@cm_name", txt_course_name.Text);
        if (Request.QueryString["cmid"] != null && Request.QueryString["cmid"].ToString() != "")
        {
            cmd.Parameters.AddWithValue("@cm_id", Request.QueryString["cmid"].ToString());
        }
        else
        {
            cmd.Parameters.AddWithValue("@cm_id", 0);
        }
        da = new MySqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Dispose();
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
            if (Request.QueryString["cmid"] != null && Request.QueryString["cmid"].ToString() != "")
            {
                try
                {
                    mycon();
                    cmd = new MySqlCommand("update course_master set cm_name=@cm_name,cm_status= @cm_status ,cm_logdt=@cm_logdt,cm_logrid=@cm_logrid where cm_id=@cm_id", con);
                    cmd.Parameters.AddWithValue("@cm_name", txt_course_name.Text.ToLower());
                    if (rdo_active.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@cm_status", 1);

                    }
                    else if (rdo_deactive.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@cm_status", 0);
                    }
                    cmd.Parameters.AddWithValue("@cm_logdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@cm_logrid", Session["admin_login"]);
                    cmd.Parameters.AddWithValue("@cm_id", Request.QueryString["cmid"]);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    Response.Write("<script>alert('Course Update Sucesfully'); window.location.href='A_Course_List.aspx'</script>");

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
                try
                {
                    mycon();
                    cmd = new MySqlCommand("insert into course_master values (NULL,@cm_name,@cm_status,@cm_remark,@cm_insdt, @cm_insrid, @cm_logdt,@cm_logrid)", con);
                    cmd.Parameters.AddWithValue("@cm_name", txt_course_name.Text.ToLower());
                    if (rdo_active.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@cm_status", 1);
                    }
                    else if (rdo_deactive.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@cm_status", 0);
                    }
                    cmd.Parameters.AddWithValue("@cm_remark", "");
                    cmd.Parameters.AddWithValue("@cm_insdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@cm_insrid", Session["admin_login"]);
                    cmd.Parameters.AddWithValue("@cm_logdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@cm_logrid", Session["admin_login"]);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    Response.Write("<script>alert('Course Added Successfully'); window.location.href='A_Course_List.aspx'</script>");
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
            Response.Write("<script>alert('Course Already Added')</script>");
        }
    }
    protected void lnk_clear_Click(object sender, EventArgs e)
    {
        Server.Transfer("A_CourseForm.aspx");
    }
}
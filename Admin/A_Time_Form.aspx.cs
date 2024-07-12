using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
public partial class Admin_A_Time_Form : System.Web.UI.Page
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
    void Fill_Time_Edit()
    {
        mycon();
        try
        {
            lnk_save.Text = "<span class='feather icon-edit'>&nbsp;&nbsp;Update</span>";
            cmd = new MySqlCommand("select * from timing_master where tim_id=@tim_id", con);
            cmd.Parameters.AddWithValue("@tim_id", Request.QueryString["timid"].ToString());
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_time_title.Text = ds.Tables[0].Rows[0]["tim_title"].ToString();
                txt_starting_time.Text = ds.Tables[0].Rows[0]["tim_start_time"].ToString();
                txt_ending_time.Text = ds.Tables[0].Rows[0]["tim_end_time"].ToString();

                if (ds.Tables[0].Rows[0]["tim_status"].ToString() == "1")
                {
                    rdo_active.Checked = true;
                }
                else if (ds.Tables[0].Rows[0]["tim_status"].ToString() == "0")
                {
                    rdo_deactive.Checked = true;
                }
            }
            else
            {
                Response.Write("<script>alert('Not Data Available'); window.location.href='A_Time_List.aspx';</script>");
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
                if (Request.QueryString["timid"] != null && Request.QueryString["timid"].ToString() != "")
                {
                    Fill_Time_Edit();
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
        if (Convert.ToDateTime(txt_starting_time.Text) < Convert.ToDateTime(txt_ending_time.Text))
        {
            mycon();
            cmd = new MySqlCommand("select * from Timing_Master where (tim_start_time BETWEEN '" + txt_starting_time.Text + "' and '" + txt_ending_time.Text + "') AND (tim_end_time BETWEEN '" + txt_starting_time.Text + "' and '" + txt_ending_time.Text + "') and tim_id != @tim_id", con);
            if (Request.QueryString["timid"] != null && Request.QueryString["timid"].ToString() != "")
            {
                cmd.Parameters.AddWithValue("@tim_id", Request.QueryString["timid"].ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@tim_id", 0);
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
                if (Request.QueryString["timid"] != null && Request.QueryString["timid"].ToString() != "")
                {
                    mycon();
                    try
                    {
                        cmd = new MySqlCommand("update timing_master set tim_title=@tim_title ,tim_start_time=@tim_start_time, tim_end_time=@tim_end_time ,tim_status=@tim_status, tim_logdt=@tim_logdt, tim_logrid=@tim_logrid where tim_id=@tim_id", con);
                        cmd.Parameters.AddWithValue("@tim_title", txt_time_title.Text);
                        cmd.Parameters.AddWithValue("@tim_start_time", txt_starting_time.Text);
                        cmd.Parameters.AddWithValue("@tim_end_time", txt_ending_time.Text);
                        if (rdo_active.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@tim_status", 1);
                        }
                        else if (rdo_deactive.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@tim_status", 0);
                        }
                        cmd.Parameters.AddWithValue("@tim_logdt", dtc.GetIndianDateTime());
                        cmd.Parameters.AddWithValue("@tim_logrid", Session["admin_login"]);
                        cmd.Parameters.AddWithValue("@tim_id", Request.QueryString["timid"].ToString());
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                        Response.Write("<script>alert('Time Update Successfully'); window.location.href='A_Time_List.aspx'</script>");
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
                        cmd = new MySqlCommand("Insert into timing_master values (NULL,@tim_title,@tim_start_time, @tim_end_time,@tim_status,@tim_remark,@tim_insdt,@tim_insrid, @tim_logdt, @tim_logrid)", con);
                        cmd.Parameters.AddWithValue("@tim_title", txt_time_title.Text);
                        cmd.Parameters.AddWithValue("@tim_start_time", txt_starting_time.Text);
                        cmd.Parameters.AddWithValue("@tim_end_time", txt_ending_time.Text);
                        if (rdo_active.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@tim_status", 1);
                        }
                        else if (rdo_deactive.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@tim_status", 0);
                        }
                        cmd.Parameters.AddWithValue("@tim_remark", "");
                        cmd.Parameters.AddWithValue("@tim_insdt", dtc.GetIndianDateTime());
                        cmd.Parameters.AddWithValue("@tim_insrid", Session["admin_login"]);
                        cmd.Parameters.AddWithValue("@tim_logdt", dtc.GetIndianDateTime());
                        cmd.Parameters.AddWithValue("@tim_logrid", Session["admin_login"]);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                        Response.Write("<script>alert('Time Added Sucessfully'); window.location.href='A_Time_List.aspx'</script>");
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
                Response.Write("<script>alert('This Time is Already is Added')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Please Enter Time Greater then From Time');</script>");
        }
    }
    protected void lnk_clear_Click(object sender, EventArgs e)
    {
        Server.Transfer("A_Time_Form.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

public partial class Admin_A_Add_User : System.Web.UI.Page
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
    void Fill_User_Edit()
    {
        mycon();
        try
        {
            lnk_save.Text = "<span class='feather icon-edit'>&nbsp;&nbsp;Update</span>";
            cmd = new MySqlCommand("select * from admin_master where am_id=@am_id", con);
            cmd.Parameters.AddWithValue("@am_id", Request.QueryString["amid"].ToString());
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_user_name.Text = ds.Tables[0].Rows[0]["am_name"].ToString();
                txt_user_ctn.Text = ds.Tables[0].Rows[0]["am_ctn"].ToString();
                txt_user_email.Text = ds.Tables[0].Rows[0]["am_email"].ToString();
                txt_user_password.TextMode = TextBoxMode.SingleLine;
                txt_user_password.Text = ds.Tables[0].Rows[0]["am_password"].ToString();
                if (ds.Tables[0].Rows[0]["am_status"].ToString() == "1")
                {
                    rdo_active.Checked = true;
                }
                else if (ds.Tables[0].Rows[0]["am_status"].ToString() == "0")
                {
                    rdo_deactive.Checked = true;
                }
            }
            else
            {
                Response.Write("<script>alert('Not Data Available'); window.location.href='A_User_List.aspx';</script>");
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
                if (Request.QueryString["amid"] != null && Request.QueryString["amid"].ToString() != "")
                {
                    Fill_User_Edit();
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
        cmd = new MySqlCommand("select am_id from admin_master where am_id!=@am_id and(am_ctn=@am_ctn OR am_email=@am_email)", con);
        cmd.Parameters.AddWithValue("@am_ctn", txt_user_ctn.Text);
        cmd.Parameters.AddWithValue("@am_email", txt_user_email.Text);
        if (Request.QueryString["amid"] != null && Request.QueryString["amid"].ToString() != "")
        {
            cmd.Parameters.AddWithValue("@am_id", Request.QueryString["amid"]);
        }
        else
        {
            cmd.Parameters.AddWithValue("@am_id", 0);
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
            if (Request.QueryString["amid"] != null && Request.QueryString["amid"].ToString() != "")
            {
                cmd = new MySqlCommand("update admin_master set am_name=@am_name,am_ctn=@am_ctn,am_email=@am_email,am_password=@am_password,am_status=@am_status,am_logdt=@am_logdt,am_logrid=@am_logrid where am_id=@am_id", con);
                cmd.Parameters.AddWithValue("@am_name", txt_user_name.Text);
                cmd.Parameters.AddWithValue("@am_ctn", txt_user_ctn.Text);
                cmd.Parameters.AddWithValue("@am_email", txt_user_email.Text);
                cmd.Parameters.AddWithValue("@am_password", txt_user_password.Text);
                if (rdo_active.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@am_status", 1);
                }
                else if (rdo_deactive.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@am_status", 0);
                }
                cmd.Parameters.AddWithValue("@am_logdt", dtc.GetIndianDateTime());
                cmd.Parameters.AddWithValue("@am_logrid", Session["admin_login"]);
                cmd.Parameters.AddWithValue("@am_id", Request.QueryString["amid"]);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Admin Update or User Successfully'); window.location.href='A_User_List.aspx';</script>");
            }
            else
            {
                cmd = new MySqlCommand("insert into admin_master values(null,@am_name,@am_ctn,@am_email,@am_password,@am_status,@am_insdt,@am_insrid,@am_logdt,@am_logrid)", con);
                cmd.Parameters.AddWithValue("@am_name", txt_user_name.Text);
                cmd.Parameters.AddWithValue("@am_ctn", txt_user_ctn.Text);
                cmd.Parameters.AddWithValue("@am_email", txt_user_email.Text);
                cmd.Parameters.AddWithValue("@am_password", txt_user_password.Text);
                if (rdo_active.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@am_status", 1);
                }
                else if (rdo_deactive.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@am_status", 0);
                }
                cmd.Parameters.AddWithValue("@am_insdt", dtc.GetIndianDateTime());
                cmd.Parameters.AddWithValue("@am_insrid", Session["admin_login"]);
                cmd.Parameters.AddWithValue("@am_logdt", dtc.GetIndianDateTime());
                cmd.Parameters.AddWithValue("@am_logrid", Session["admin_login"]);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Admin Added or User Successfully'); window.location.href='A_User_List.aspx';</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('This User Already Added');<script>");
        }
        con.Close();
        con.Dispose();
    }
    protected void lnk_clear_Click(object sender, EventArgs e)
    {
        Server.Transfer("A_Add_User.aspx");
    }
}
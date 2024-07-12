using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
public partial class Admin_A_User_List : System.Web.UI.Page
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

    void fill_user_list()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from admin_master", con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            con.Dispose();
            if (ds.Tables[0].Rows.Count > 0)
            {
                rpt_user_list.DataSource = ds;
                rpt_user_list.DataBind();
            }
            else
            {
                rpt_user_list.DataSource = null;
                rpt_user_list.DataBind();
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
                fill_user_list();
            }
        }
        else
        {
                Response.Redirect("Admin_Login.aspx");
        }
    }


    protected void rpt_user_list_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "lnk_delete")
        {
            mycon();
            try
            {
                cmd = new MySqlCommand("delete from admin_master where am_id=@amid", con);
                cmd.Parameters.AddWithValue("@amid", e.CommandArgument.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                Response.Write("<script>alert('Teacher Deleted Successfully'); window.location.href='A_User_List.aspx'</script>");
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
}
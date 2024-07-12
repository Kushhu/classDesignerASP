using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

public partial class Admin_A_Assign_Batch_List : System.Web.UI.Page
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
    void fill_assign_batch_details()
    {
        mycon();
        cmd = new MySqlCommand("SELECT * FROM get_assign_batch_details where tm_status=1 and subm_status=1 and scm_status=1 and cm_status=1 and tim_status=1", con);
        da = new MySqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            rpt_assign_batch_list.DataSource = ds;
            rpt_assign_batch_list.DataBind();
        }
        else
        {
            rpt_assign_batch_list.DataSource = null;
            rpt_assign_batch_list.DataBind();
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
                fill_assign_batch_details();
            }
        }
        else
        {
                Response.Redirect("Admin_Login.aspx");
        }

    }

    protected void rpt_assign_batch_list_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "lnk_delete")
        {
            mycon();
            try
            {
                cmd = new MySqlCommand("Delete from assign_batch_master where abm_id=@abm_id", con);
                cmd.Parameters.AddWithValue("@abm_id", e.CommandArgument.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                Response.Write("<script>alert('Assign Batch Delete Successfully'); window.location.href='A_Assign_Batch_List.aspx';</script>");
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
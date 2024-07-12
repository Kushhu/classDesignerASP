using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

public partial class Admin_A_Fees_List : System.Web.UI.Page
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
    void Fill_Fees_Details()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from get_fees_details where scm_status=1 and cm_status=1", con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                rpt_fees_list.DataSource = ds;
                rpt_fees_list.DataBind();
            }
            else
            {
                rpt_fees_list.DataSource = null;
                rpt_fees_list.DataBind();
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
                Fill_Fees_Details();
            }
        }
        else
        {
                Response.Redirect("Admin_Login.aspx");
        }
    }
    protected void rpt_fees_list_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "lnk_delete")
        {
            mycon();
            try
            {
                cmd = new MySqlCommand("delete from fees_mater where fm_id=@fm_id", con);
                cmd.Parameters.AddWithValue("@fm_id", e.CommandArgument.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                Response.Write("<script>alert('Fees Delete Sucesfuly'); window.loaction.href='A_Fees_List.aspx'</script>");
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
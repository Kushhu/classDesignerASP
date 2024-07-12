using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.IO;
public partial class Admin_A_Material_List : System.Web.UI.Page
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
    void Fill_Materail_Rpt()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from get_materials_details", con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rpt_materail_list.DataSource = ds;
                rpt_materail_list.DataBind();
            }
            else
            {
                rpt_materail_list.DataSource = null;
                rpt_materail_list.DataBind();
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
                Fill_Materail_Rpt();
            }
        }
        else
        {
                Response.Redirect("Admin_Login.aspx");
        }
    }

    protected void rpt_materail_list_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "lnk_delete")
        {
            mycon();
            try
            {
                cmd = new MySqlCommand("Delete from materials_master where mm_id=@mm_id", con);
                cmd.Parameters.AddWithValue("@mm_id", e.CommandArgument.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                Response.Write("<script>alert('Material Delete Successfully'); window.location.href='A_Material_List.aspx';</script>");
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

    protected void rpt_materail_list_PreRender(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in rpt_materail_list.Items)
        {
            HiddenField hf_file_path = (HiddenField)item.FindControl("hf_file_path");
            HiddenField hf_url_link = (HiddenField)item.FindControl("hf_url_link");
            HyperLink hl_materail_file = (HyperLink)item.FindControl("hl_materail_file");
            HyperLink hl_url_link = (HyperLink)item.FindControl("hl_url_link");

            if (hf_file_path.Value != null && hf_file_path.Value.ToString() != "")
            {
                hl_materail_file.Visible = true;
            }
            else
            {
                hl_materail_file.Visible = false;
            }

            if (hf_url_link.Value != null && hf_url_link.Value.ToString() != "")
            {
                hl_url_link.Visible = true;
            }
            else
            {
                hl_url_link.Visible = false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.IO;


public partial class ContactUS : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert into client_inquiry_master values (NULL,@cim_name,@cim_ctn,@cim_subject,@cim_msg,@cim_insdt,@cim_insrid,@cim_logdt,@cim_logrid)", con);
            cmd.Parameters.AddWithValue("@cim_id", 0);
            cmd.Parameters.AddWithValue("@cim_name", txt_name.Text);
            cmd.Parameters.AddWithValue("@cim_ctn", txt_ctn.Text);
            cmd.Parameters.AddWithValue("@cim_subject", txt_subject.Text);
            cmd.Parameters.AddWithValue("@cim_msg", txt_msg.Text);
            cmd.Parameters.AddWithValue("@cim_insdt", dtc.GetIndianDateTime());
            cmd.Parameters.AddWithValue("@cim_insrid", 1);
            cmd.Parameters.AddWithValue("@cim_logdt", dtc.GetIndianDateTime());
            cmd.Parameters.AddWithValue("@cim_logrid", 1);
            cmd.ExecuteNonQuery();

            con.Close();
            con.Dispose();
            Response.Write("<script>alert('Your Inquiry Send Sucesfully'); window.location.href='ContactUS.aspx';</script>");
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
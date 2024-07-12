using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.IO;

public partial class Admin_A_Fee_Recepit : System.Web.UI.Page
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
    void fill_recepit_details()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from get_student_recevied_fees_details where fpm_id=@fpm_id and fpm_sm_id=@fpm_sm_id", con);
            cmd.Parameters.AddWithValue("@fpm_id", Request.QueryString["recepitid"].ToString());
            cmd.Parameters.AddWithValue("@fpm_sm_id", Request.QueryString["smid"].ToString());
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_student_name.Text = ds.Tables[0].Rows[0]["sm_name"].ToString();
                lbl_receipt_id.Text = Request.QueryString["recepitid"].ToString();
                lbl_innvoice_no.Text = Request.QueryString["recepitid"].ToString() + "-" + System.DateTime.Now.ToString();
                lbl_student_ctn.Text = ds.Tables[0].Rows[0]["sm_ctn"].ToString();
                lbl_student_email.Text = ds.Tables[0].Rows[0]["sm_email"].ToString();
                lbl_student_address.Text = ds.Tables[0].Rows[0]["sm_address"].ToString();
                lbl_short_date.Text = System.DateTime.Now.ToShortDateString();
                lbl_total_rupees.Text = ds.Tables[0].Rows[0]["fpm_total_fees"].ToString();
                lbl_total_paid.Text = ds.Tables[0].Rows[0]["Paid_Fees"].ToString();
                lbl_paid_fees.Text = ds.Tables[0].Rows[0]["fpm_paid_fees"].ToString();
                lbl_paid_fees.ForeColor = System.Drawing.Color.Green;
                lbl_remining_fees.Text = ds.Tables[0].Rows[0]["fpm_remaing_fees"].ToString();
                lbl_remining_fees.ForeColor = System.Drawing.Color.Red;
                p_details.InnerHtml = "<b> Course Name : </b>" + ds.Tables[0].Rows[0]["cm_name"].ToString() + "<br><b>Sub Course Name : </b>" + ds.Tables[0].Rows[0]["scm_name"].ToString();
            }
            else
            {
                Response.Redirect("A_Student_Pay_Fees.aspx");
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

                if (Request.QueryString["recepitid"] != null && Request.QueryString["recepitid"].ToString() != "" && Request.QueryString["smid"] != null && Request.QueryString["smid"].ToString() != "")
                {
                    fill_recepit_details();
                }
                else
                {
                    Response.Redirect("A_Student_Fess_List.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("Admin_Login.aspx");
        }
    }
}
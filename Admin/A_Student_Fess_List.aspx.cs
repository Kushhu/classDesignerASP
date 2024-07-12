using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
public partial class Admin_A_Student_Fess_List : System.Web.UI.Page
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
    void fill_student_wise_fees_list()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from get_student_fees_payment_details where sm_status=1", con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rpt_student_fees_list.DataSource = ds;
                rpt_student_fees_list.DataBind();
            }
            else
            {
                rpt_student_fees_list.DataSource = null;
                rpt_student_fees_list.DataBind();
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

                fill_student_wise_fees_list();

            }
        }
        else
        {
            Response.Redirect("Admin_Login.aspx");
        }
    }

    protected void rpt_student_fees_list_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "lnk_pay_fees")
        {
            Response.Redirect("A_Student_Pay_Fees.aspx?smid=" + e.CommandArgument.ToString());
        }
    }

    protected void rpt_student_fees_list_PreRender(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in rpt_student_fees_list.Items)
        {
            HiddenField hf_next_reaming_fess = (HiddenField)item.FindControl("hf_next_reaming_fess");
            Label lbl_paid_fees = (Label)item.FindControl("lbl_paid_fees");
            LinkButton lnk_pay_fees = (LinkButton)item.FindControl("lnk_pay_fees");

            if (hf_next_reaming_fess.Value == "0" && hf_next_reaming_fess.Value.ToString() == "0")
            {
                lnk_pay_fees.Visible = false;
                lbl_paid_fees.Visible = true;
            }
            else
            {
                lnk_pay_fees.Visible = true;
                lbl_paid_fees.Visible = false;
            }
        }
    }
}
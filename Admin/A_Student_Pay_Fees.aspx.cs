using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;

public partial class Admin_A_Student_Pay_Fees : System.Web.UI.Page
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
    void fill_student_details_for_pay_fees()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from get_student_fees_payment_details where sm_id=@sm_id", con);
            cmd.Parameters.AddWithValue("@sm_id", Request.QueryString["smid"].ToString());
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_student_name.Text = ds.Tables[0].Rows[0]["sm_name"].ToString();
                txt_sm_fees.Text = ds.Tables[0].Rows[0]["sm_fees"].ToString();
                txt_sm_fees.ForeColor = Color.Green;
                if (ds.Tables[0].Rows[0]["Next_Reaming_Fees"].ToString() != "")
                {
                    txt_reaming_fees.Text = ds.Tables[0].Rows[0]["Next_Reaming_Fees"].ToString();
                }
                else
                {
                    txt_reaming_fees.Text = "0";
                }
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

                if (Request.QueryString["smid"] != null && Request.QueryString["smid"] != "")
                {
                    fill_student_details_for_pay_fees();
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
    protected void lnk_pay_fees_Click(object sender, EventArgs e)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("insert into fees_payment_master values(NULL,@fpm_sm_id,@fpm_total_fees,@fpm_paid_fees,@fpm_remaing_fees,@fpm_payment_mode,@fpm_imgae_link,@fpm_insdt,@fpm_insrid,@fpm_logdt,@fpm_logrid)", con);
            cmd.Parameters.AddWithValue("@fpm_sm_id", Request.QueryString["smid"].ToString());
            cmd.Parameters.AddWithValue("@fpm_total_fees", txt_sm_fees.Text);
            cmd.Parameters.AddWithValue("@fpm_paid_fees", txt_pay_amount.Text);
            cmd.Parameters.AddWithValue("@fpm_remaing_fees", txt_remining_amount.Text);
            cmd.Parameters.AddWithValue("@fpm_payment_mode", dr_transtion_mode.Text);
            string transtion_path = "";
            if (dr_transtion_mode.SelectedIndex > 1)
            {
                if (fu_trastion_img.HasFile)
                {
                    if (img_trasntion_image.ImageUrl != "" && fu_trastion_img.HasFile && Request.QueryString["smid"].ToString() != "")
                    {
                        String FileToDelete = Server.MapPath(img_trasntion_image.ImageUrl);
                        File.Delete(FileToDelete);
                    }
                    Guid guidTrasntion = Guid.NewGuid();
                    hf_ext_profile.Value = System.IO.Path.GetExtension(fu_trastion_img.FileName);
                    hf_name_profile.Value = guidTrasntion.ToString() + hf_ext_profile.Value;
                    fu_trastion_img.SaveAs(Server.MapPath("~/Admin/Admin_Data/Fees_Transtion_Img/" + hf_name_profile.Value));
                    transtion_path = "~/Admin/Admin_Data/Fees_Transtion_Img/" + hf_name_profile.Value;
                }
                else if (Request.QueryString["smid"] != null && Request.QueryString["smid"].ToString() != "" && img_trasntion_image.ImageUrl.ToString() != "" && img_trasntion_image.ImageUrl != null)
                {
                    transtion_path = img_trasntion_image.ImageUrl;
                }
                else
                {
                    transtion_path = "~/Admin/Admin_Data/Fees_Transtion_Img/Ruppes_Img.jpg";
                }
                cmd.Parameters.AddWithValue("@fpm_imgae_link", transtion_path);
            }
            else
            {
                transtion_path = "~/Admin/Admin_Data/Fees_Transtion_Img/Ruppes_Img.jpg";
                cmd.Parameters.AddWithValue("@fpm_imgae_link", transtion_path);
            }
            cmd.Parameters.AddWithValue("@fpm_insdt", dtc.GetIndianDateTime());
            cmd.Parameters.AddWithValue("@fpm_insrid", Session["admin_login"].ToString());
            cmd.Parameters.AddWithValue("@fpm_logdt", dtc.GetIndianDateTime());
            cmd.Parameters.AddWithValue("@fpm_logrid", Session["admin_login"].ToString());
            cmd.ExecuteNonQuery();
            cmd = new MySqlCommand("select max(fpm_id) from fees_payment_master", con);
            string FeesPayId = cmd.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
            Response.Write("<script>window.open('A_Fee_Receipt.aspx?recepitid=" + FeesPayId.ToString() + "&smid=" + Request.QueryString["smid"].ToString() + "', '_blank'); alert('Successfully Payment Received !!'); window.location.href='A_Student_Pay_Fees.aspx';  </script>");
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
    protected void dr_transtion_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dr_transtion_mode.SelectedIndex > 1)
        {
            pnl_file_transtion.Visible = true;
        }
        else
        {
            pnl_file_transtion.Visible = false;
        }
    }
}
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
public partial class Admin_Teacher_Registration : System.Web.UI.Page
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
    void Fill_Teacher_Edit()
    {
        mycon();
        try
        {
            rf_fu_teacher_img.Enabled = false;
            lnk_save.Text = "<span class='feather icon-edit'>&nbsp;&nbsp;Update</span>";
            cmd = new MySqlCommand("select * from teacher_master where tm_id=@tm_id", con);
            cmd.Parameters.AddWithValue("@tm_id", Request.QueryString["tmid"].ToString());
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_teacher_name.Text = ds.Tables[0].Rows[0]["tm_name"].ToString();
                txt_teacher_ctn.Text = ds.Tables[0].Rows[0]["tm_ctn"].ToString();
                txt_teacher_email.Text = ds.Tables[0].Rows[0]["tm_email"].ToString();
                txt_teacher_edu.Text = ds.Tables[0].Rows[0]["tm_eduction"].ToString();
                img_teacher_profile.ImageUrl = ds.Tables[0].Rows[0]["tm_img"].ToString();
                txt_date_of_birth.Text = ds.Tables[0].Rows[0]["tm_dob"].ToString().Split(null)[0];

                if (ds.Tables[0].Rows[0]["tm_status"].ToString() == "1")
                {
                    rdo_active.Checked = true;
                }
                else
                if (ds.Tables[0].Rows[0]["tm_status"].ToString() == "0")
                {
                    rdo_deactive.Checked = true;
                }
            }
            else
            {
                Response.Write("<script>alert('Not Data Available'); window.location.href='A_Teacher_List.aspx';</script>");
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
                if (Request.QueryString["tmid"] != null && Request.QueryString["tmid"].ToString() != "")
                {
                    Fill_Teacher_Edit();
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
        bool desicion = true;
        mycon();
        cmd = new MySqlCommand("select tm_id from teacher_master where tm_ctn=@tm_ctn and tm_email=@tm_email and tm_id!=@tm_id", con);
        cmd.Parameters.AddWithValue("@tm_ctn", txt_teacher_ctn.Text);
        cmd.Parameters.AddWithValue("@tm_email", txt_teacher_email.Text);
        if (Request.QueryString["tmid"] != null && Request.QueryString["tmid"].ToString() != "")
        {
            cmd.Parameters.AddWithValue("@tm_id", Request.QueryString["tmid"].ToString());
        }
        else
        {
            cmd.Parameters.AddWithValue("@tm_id", 0);
        }
        da = new MySqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            desicion = false;
        }
        else
        {
            desicion = true;
        }
        if (desicion == true)
        {
            if (Request.QueryString["tmid"] != null && Request.QueryString["tmid"].ToString() != "")
            {
                mycon();
                try
                {
                    cmd = new MySqlCommand("update teacher_master set tm_name=@tm_name , tm_ctn=@tm_ctn , tm_email=@tm_email , tm_eduction=@tm_eduction,tm_img=@tm_img , tm_dob=@tm_dob ,tm_status=@tm_status  ,tm_logdt=@tm_logdt , tm_logrid=@tm_logrid where tm_id=@tm_id", con);
                    cmd.Parameters.AddWithValue("@tm_name", txt_teacher_name.Text);
                    cmd.Parameters.AddWithValue("@tm_ctn", txt_teacher_ctn.Text);
                    cmd.Parameters.AddWithValue("@tm_email", txt_teacher_email.Text);
                    cmd.Parameters.AddWithValue("@tm_eduction", txt_teacher_edu.Text);
                    string profile_path = "";
                    if (fu_teacher_img.HasFile)
                    {
                        if (img_teacher_profile.ImageUrl != "" && fu_teacher_img.HasFile && Request.QueryString["tmid"].ToString() != "")
                        {
                            String FileToDelete = Server.MapPath(img_teacher_profile.ImageUrl);
                            File.Delete(FileToDelete);
                        }
                        Guid guidProfile = Guid.NewGuid();
                        hf_ext_profile.Value = System.IO.Path.GetExtension(fu_teacher_img.FileName);
                        hf_name_profile.Value = guidProfile.ToString() + hf_ext_profile.Value;
                        fu_teacher_img.SaveAs(Server.MapPath("~/Admin/Admin_Data/Teacher_Img/" + hf_name_profile.Value));
                        profile_path = "~/Admin/Admin_Data/Teacher_Img/" + hf_name_profile.Value;
                    }
                    else if (Request.QueryString["tmid"].ToString() != "" && Request.QueryString["tmid"] != null && img_teacher_profile.ImageUrl.ToString() != "" && img_teacher_profile.ImageUrl != null)
                    {
                        profile_path = img_teacher_profile.ImageUrl;
                    }
                    else
                    {
                        profile_path = "~/Admin/Assets/images/logo-dark.png";
                    }

                    cmd.Parameters.AddWithValue("@tm_img", profile_path.ToString());
                    cmd.Parameters.AddWithValue("@tm_dob", txt_date_of_birth.Text);
                    if (rdo_active.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@tm_status", 1);
                    }
                    else if (rdo_deactive.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@tm_status", 0);
                    }
                    cmd.Parameters.AddWithValue("@tm_logrid", Session["admin_login"]);
                    cmd.Parameters.AddWithValue("@tm_logdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@tm_id", Request.QueryString["tmid"].ToString());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    Response.Write("<script>alert('Teacher Details Update Sucesfully'); window.location.href='A_Teacher_List.aspx'</script>");
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
                mycon();
                try
                {
                    cmd = new MySqlCommand("insert into teacher_master values(NULL,@tm_name,@tm_ctn,@tm_email,@tm_password,@tm_eduction,@tm_img,@tm_dob,@tm_status,@tm_insdt,@tm_insrid,@tm_logdt,@tm_logrid)", con);
                    cmd.Parameters.AddWithValue("@tm_name", txt_teacher_name.Text);
                    cmd.Parameters.AddWithValue("@tm_ctn", txt_teacher_ctn.Text);
                    cmd.Parameters.AddWithValue("@tm_email", txt_teacher_email.Text);
                    cmd.Parameters.AddWithValue("@tm_eduction", txt_teacher_edu.Text);
                    EncDec enc = new EncDec();
                    string otp = enc.otpgenerate();
                    string msg = "Hello , Wel Come to New School Dear Teacher" + txt_teacher_name.Text + "Your Login Password is -->" + otp.ToString();
                    cmd.Parameters.AddWithValue("@tm_password", otp.ToString());

                    string profile_path = "";
                    if (fu_teacher_img.HasFile)
                    {
                        if (img_teacher_profile.ImageUrl != "" && fu_teacher_img.HasFile && Request.QueryString["tmid"].ToString() != "")
                        {
                            String FileToDelete = Server.MapPath(img_teacher_profile.ImageUrl);
                            File.Delete(FileToDelete);
                        }
                        Guid guidProfile = Guid.NewGuid();
                        hf_ext_profile.Value = System.IO.Path.GetExtension(fu_teacher_img.FileName);
                        hf_name_profile.Value = guidProfile.ToString() + hf_ext_profile.Value;
                        fu_teacher_img.SaveAs(Server.MapPath("~/Admin/Admin_Data/Teacher_Img/" + hf_name_profile.Value));
                        profile_path = "~/Admin/Admin_Data/Teacher_Img/" + hf_name_profile.Value;
                    }
                    else if (Request.QueryString["tmid"].ToString() != "" && Request.QueryString["tmid"] != null && img_teacher_profile.ImageUrl.ToString() != "" && img_teacher_profile.ImageUrl != null)
                    {
                        profile_path = img_teacher_profile.ImageUrl;
                    }
                    else
                    {
                        profile_path = "~/Admin/Assets/images/logo-dark.png";
                    }
                    cmd.Parameters.AddWithValue("@tm_img", profile_path.ToString());
                    cmd.Parameters.AddWithValue("@tm_dob", txt_date_of_birth.Text);
                    if (rdo_active.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@tm_status", 1);
                    }
                    else if (rdo_deactive.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@tm_status", 0);
                    }
                    cmd.Parameters.AddWithValue("@tm_insrid", Session["admin_login"]);
                    cmd.Parameters.AddWithValue("@tm_insdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@tm_logrid", Session["admin_login"]);
                    cmd.Parameters.AddWithValue("@tm_logdt", dtc.GetIndianDateTime());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();

                    if (GmailSender.SendMail("educationsoni744@gmail.com", "MauliSoni123", txt_teacher_email.Text, "Wel Come Our School", msg))
                    {
                        Response.Write("<script>alert('Your Teacher Registration Sucessfully...Thanking You...');</script>");
                        Response.Write("<script>alert('Your Password As OTP Send On Email Address Thanking You...'); window.location.href='A_Teacher_List.aspx' </script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Sorry For Mail Not Send But Your Password is " + otp.ToString() + "'); window.location.href='A_Teacher_List.aspx' </script>");
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
        }
        else
        {
            Response.Write("<script>alert('This Mobile Number OR Email ID is Already Added Please Fill Another Email OR Contact Number');</script>");
        }
    }
    protected void lnk_clear_Click(object sender, EventArgs e)
    {
        Server.Transfer("A_Teacher_Registration.aspx");
    }
}
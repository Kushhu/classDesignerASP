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

public partial class Admin_A_Student_Form : System.Web.UI.Page
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
    void Fill_Course_For_Dropdown()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select cm_id,cm_name from get_fees_details where cm_status=1 group by scm_cm_id", con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr_course_name.DataSource = ds;
                dr_course_name.DataTextField = "cm_name";
                dr_course_name.DataValueField = "cm_id";
                dr_course_name.DataBind();
                con.Close();
                con.Dispose();
                dr_course_name.Items.Insert(0, "-- Select Course --");
                dr_course_name.Items[0].Value = "0";
                dr_course_name.Attributes.Add("style", "text-transform:capitalize");
            }
            else
            {
                dr_course_name.Items.Clear();
                dr_course_name.Items.Insert(0, "-- Select Course  --");
                dr_course_name.Items[0].Value = "0";
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
    void Fill_Sub_Course_Dropdown()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select scm_id,scm_name from get_fezes_details where cm_status=1 and scm_status=1 and scm_cm_id=@scm_cm_id", con);
            cmd.Parameters.AddWithValue("@scm_cm_id", dr_course_name.SelectedItem.Value);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dr_sub_course_name.DataSource = ds;
                dr_sub_course_name.DataTextField = "scm_name";
                dr_sub_course_name.DataValueField = "scm_id";
                dr_sub_course_name.DataBind();

                con.Close();
                con.Dispose();

                dr_sub_course_name.Items.Insert(0, "-- Select Sub Course  --");
                dr_sub_course_name.Items[0].Value = "0";
                dr_sub_course_name.Attributes.Add("style", "text-transform:capitalize");
            }
            else
            {
                dr_sub_course_name.Items.Clear();
                dr_sub_course_name.Items.Insert(0, "-- Select Sub Course  --");
                dr_sub_course_name.Items[0].Value = "0";
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
    void Fill_Student_For_Edit()
    {
        mycon();
        try
        {
            rf_fu_student_img.Visible = false;
            lnk_save.Text = "<span class='feather icon-edit'>&nbsp;&nbsp;Update</span>";
            cmd = new MySqlCommand("select * from get_student_details where sm_id=@sm_id", con);
            cmd.Parameters.AddWithValue("@sm_id", Request.QueryString["smid"].ToString());
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_student_name.Text = ds.Tables[0].Rows[0]["sm_name"].ToString();
                dr_course_name.Text = ds.Tables[0].Rows[0]["scm_cm_id"].ToString();
                string subcmid = ds.Tables[0].Rows[0]["sm_scm_id"].ToString();
                if (ds.Tables[0].Rows[0]["sm_gender"].ToString() == "Male")
                {
                    rdo_male.Checked = true;
                }
                else if (ds.Tables[0].Rows[0]["sm_gender"].ToString() == "Female")
                {
                    rdo_female.Checked = true;
                }
                txt_student_email.Text = ds.Tables[0].Rows[0]["sm_email"].ToString().Split(null)[0];
                txt_student_dob.Text = ds.Tables[0].Rows[0]["sm_dob"].ToString().Split(null)[0];
                txt_student_ctn.Text = ds.Tables[0].Rows[0]["sm_ctn"].ToString();
                img_student_profile.ImageUrl = ds.Tables[0].Rows[0]["sm_img"].ToString();
                txt_student_address.Text = ds.Tables[0].Rows[0]["sm_address"].ToString();
                hf_fees_amount.Value = ds.Tables[0].Rows[0]["sm_fees"].ToString().Split(null)[0];
                if (ds.Tables[0].Rows[0]["sm_status"].ToString() == "1")
                {
                    rdo_active.Checked = true;
                }
                else if (ds.Tables[0].Rows[0]["sm_status"].ToString() == "0")
                {
                    rdo_deactive.Checked = true;
                }
                Fill_Sub_Course_Dropdown();
                dr_sub_course_name.Text = subcmid.ToString();
                con.Close();
                con.Dispose();
            }
            else
            {
                Response.Write("<script>alert('No Data is Available');</script>");
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
                Fill_Course_For_Dropdown();
                dr_sub_course_name.Items.Insert(0, "-- Select Sub Course  --");
                dr_sub_course_name.Items[0].Value = "0";
                Fill_Course_For_Dropdown();
                if (Request.QueryString["smid"] != null && Request.QueryString["smid"].ToString() != "")
                {
                    Fill_Student_For_Edit();
                }
            }
        }
        else
        {
                Response.Redirect("Admin_Login.aspx");
        }
    }

    protected void dr_course_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_Sub_Course_Dropdown();
    }
    protected void lnk_save_Click(object sender, EventArgs e)
    {
        bool decision = true;

        mycon();
        cmd = new MySqlCommand("select sm_id from student_master where sm_ctn=@sm_ctn and sm_email=@sm_email and sm_id!=@sm_id", con);
        cmd.Parameters.AddWithValue("@sm_ctn", txt_student_ctn.Text);
        cmd.Parameters.AddWithValue("@sm_email", txt_student_email.Text);

        if (Request.QueryString["smid"] != null && Request.QueryString["smid"].ToString() != "")
        {
            cmd.Parameters.AddWithValue("@sm_id", Request.QueryString["smid"].ToString());
        }
        else
        {
            cmd.Parameters.AddWithValue("@sm_id", 0);
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
            if (Request.QueryString["smid"] != null && Request.QueryString["smid"].ToString() != "")
            {
                mycon();
                try
                {
                    cmd = new MySqlCommand("update student_master set sm_scm_id=@sm_scm_id ,sm_name=@sm_name , sm_gender=@sm_gender , sm_dob=@sm_dob, sm_email=@sm_email,sm_ctn=@sm_ctn ,  sm_fees=@sm_fees, sm_img=@sm_img,sm_address=@sm_address,sm_status=@sm_status , sm_logdt=@sm_logdt, sm_logrid=@sm_logrid where sm_id=@sm_id", con);
                    cmd.Parameters.AddWithValue("@sm_scm_id", dr_sub_course_name.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@sm_name", txt_student_name.Text);

                    if (rdo_male.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@sm_gender", rdo_male.Text);
                    }
                    else
                    if (rdo_female.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@sm_gender", rdo_female.Text);
                    }
                    cmd.Parameters.AddWithValue("@sm_dob", txt_student_dob.Text);
                    cmd.Parameters.AddWithValue("@sm_email", txt_student_email.Text);
                    cmd.Parameters.AddWithValue("@sm_ctn", txt_student_ctn.Text);
                    cmd.Parameters.AddWithValue("@sm_fees", hf_fees_amount.Value);
                    string profile_path = "";
                    if (fu_student_img.HasFile)
                    {
                        if (img_student_profile.ImageUrl != "" && fu_student_img.HasFile && Request.QueryString["smid"].ToString() != "")
                        {
                            String FileToDelete = Server.MapPath(img_student_profile.ImageUrl);
                            File.Delete(FileToDelete);
                        }
                        Guid guidProfile = Guid.NewGuid();
                        hf_ext_profile.Value = System.IO.Path.GetExtension(fu_student_img.FileName);
                        hf_name_profile.Value = guidProfile.ToString() + hf_ext_profile.Value;
                        fu_student_img.SaveAs(Server.MapPath("~/Admin/Admin_Data/Student_Img/" + hf_name_profile.Value));
                        profile_path = "~/Admin/Admin_Data/Student_Img/" + hf_name_profile.Value;
                    }
                    else if (Request.QueryString["smid"] != null && Request.QueryString["smid"].ToString() != "" && img_student_profile.ImageUrl.ToString() != "" && img_student_profile.ImageUrl != null)
                    {
                        profile_path = img_student_profile.ImageUrl;
                    }
                    else
                    {
                        profile_path = "~/Admin/Assets/images/logo-dark.png";
                    }
                    cmd.Parameters.AddWithValue("@sm_img", profile_path.ToString());
                    cmd.Parameters.AddWithValue("@sm_address", txt_student_address.Text);

                    if (rdo_active.Checked)
                    {
                        cmd.Parameters.AddWithValue("@sm_status", 1);
                    }
                    else if (rdo_deactive.Checked)
                    {
                        cmd.Parameters.AddWithValue("@sm_status", 0);
                    }
                    cmd.Parameters.AddWithValue("@sm_logdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@sm_logrid", Session["admin_login"].ToString());
                    cmd.Parameters.AddWithValue("@sm_id", Request.QueryString["smid"].ToString());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    Response.Write("<script>alert('Student Details Update Successfully...'); window.location.href='A_Student_List.aspx' </script>");

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
                    cmd = new MySqlCommand("insert into student_master values(NULL,@sm_scm_id,@sm_name,@sm_gender,@sm_dob,@sm_email,@sm_ctn,@sm_password,@sm_fees,@sm_img,@sm_address,@sm_status,@sm_insdt,@sm_insrid,@sm_logdt,@sm_logrid)", con);
                    cmd.Parameters.AddWithValue("@sm_scm_id", dr_sub_course_name.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@sm_name", txt_student_name.Text);
                    if (rdo_male.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@sm_gender", rdo_male.Text);
                    }
                    else if (rdo_female.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@sm_gender", rdo_female.Text);
                    }
                    cmd.Parameters.AddWithValue("@sm_dob", txt_student_dob.Text);
                    cmd.Parameters.AddWithValue("@sm_email", txt_student_email.Text);
                    cmd.Parameters.AddWithValue("@sm_ctn", txt_student_ctn.Text);

                    EncDec enc = new EncDec();
                    string otp = enc.otpgenerate();
                    string msg = "Hello , Wel Come to New School Dear Student " + txt_student_name.Text + "Your Login Password is -->" + otp.ToString();
                    cmd.Parameters.AddWithValue("@sm_password", otp.ToString());
                    cmd.Parameters.AddWithValue("@sm_fees", hf_fees_amount.Value);
                    string profile_path = "";
                    if (fu_student_img.HasFile)
                    {
                        if (img_student_profile.ImageUrl != "" && fu_student_img.HasFile && Request.QueryString["smid"].ToString() != "")
                        {
                            String FileToDelete = Server.MapPath(img_student_profile.ImageUrl);
                            File.Delete(FileToDelete);
                        }
                        Guid guidProfile = Guid.NewGuid();
                        hf_ext_profile.Value = System.IO.Path.GetExtension(fu_student_img.FileName);
                        hf_name_profile.Value = guidProfile.ToString() + hf_ext_profile.Value;
                        fu_student_img.SaveAs(Server.MapPath("~/Admin/Admin_Data/Student_Img/" + hf_name_profile.Value));
                        profile_path = "~/Admin/Admin_Data/Student_Img/" + hf_name_profile.Value;
                    }
                    else if (Request.QueryString["tmid"].ToString() != "" && Request.QueryString["tmid"] != null && img_student_profile.ImageUrl.ToString() != "" && img_student_profile.ImageUrl != null)
                    {
                        profile_path = img_student_profile.ImageUrl;
                    }
                    else
                    {
                        profile_path = "~/Admin/Assets/images/logo-dark.png";
                    }
                    cmd.Parameters.AddWithValue("@sm_img", profile_path.ToString());
                    cmd.Parameters.AddWithValue("@sm_address", txt_student_address.Text);

                    if (rdo_active.Checked)
                    {
                        cmd.Parameters.AddWithValue("@sm_status", 1);
                    }
                    else if (rdo_deactive.Checked)
                    {
                        cmd.Parameters.AddWithValue("@sm_status", 0);
                    }
                    cmd.Parameters.AddWithValue("@sm_insdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@sm_insrid", Session["admin_login"].ToString());
                    cmd.Parameters.AddWithValue("@sm_logdt", dtc.GetIndianDateTime());
                    cmd.Parameters.AddWithValue("@sm_logrid", Session["admin_login"].ToString());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    if (GmailSender.SendMail("educationsoni744@gmail.com", "MauliSoni123", txt_student_email.Text, "Wel Come Our School", msg))
                    {
                        Response.Write("<script>alert('Student Registration Sucessfully...Thanking You...'); </script>");
                        Response.Write("<script>alert('Your Password As OTP Send On Email Address Thanking You...'); window.location.href='A_Student_List.aspx' </script>");
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
            Response.Write("<script>alert('This Student is Already Added')</script>");
        }
    }
    protected void lnk_clear_Click(object sender, EventArgs e)
    {
        Server.Transfer("A_Student_Form.aspx");
    }
    protected void dr_sub_course_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select fm_amount from get_fees_details where fm_status=1 and fm_scm_id=@fm_scm_id", con);
            cmd.Parameters.AddWithValue("@fm_scm_id", dr_sub_course_name.SelectedItem.Value);
            if (cmd.ExecuteScalar().ToString() != "")
            {
                hf_fees_amount.Value = cmd.ExecuteScalar().ToString();
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
}
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

public partial class Teacher_Teacher_Profile : System.Web.UI.Page
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
    void fill_taecher_list()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from  teacher_master where  tm_id!=@tm_id and tm_status=1", con);
            cmd.Parameters.AddWithValue("@tm_id", Session["teacher_login"].ToString());
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rpt_teacher_list.DataSource = ds;
                rpt_teacher_list.DataBind();
            }
            else
            {

                rpt_teacher_list.DataSource = null;
                rpt_teacher_list.DataBind();
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
    void fill_teacher_details()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from  teacher_master where tm_id=@tm_id", con);
            cmd.Parameters.AddWithValue("@tm_id", Session["teacher_login"].ToString());
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                rf_fu_teacher_img.Visible = false;
                txt_teacher_name.Text = ds.Tables[0].Rows[0]["tm_name"].ToString();
                txt_teacher_ctn.Text = ds.Tables[0].Rows[0]["tm_ctn"].ToString();
                txt_teacher_email.Text = ds.Tables[0].Rows[0]["tm_email"].ToString();
                txt_teacher_edu.Text = ds.Tables[0].Rows[0]["tm_eduction"].ToString();
                txt_teacher_dob.Text = ds.Tables[0].Rows[0]["tm_dob"].ToString().Split(null)[0];
                img_teacher_profile.ImageUrl = ds.Tables[0].Rows[0]["tm_img"].ToString();
                if (ds.Tables[0].Rows[0]["tm_status"].ToString() == "1")
                {
                    rdo_active.Checked = true;
                }
                else
                {
                    rdo_deactive.Checked = true;
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
        if (Request.Cookies["teacher_login"] != null && Request.Cookies["teacher_login"].ToString() != "")
        {
            if (!IsPostBack)
            {
                EncDec enc = new EncDec();
                Session["teacher_login"] = Convert.ToInt32(enc.Decrypt(Request.Cookies["teacher_login"].Values["teacherLoginVal"].ToString()));
                fill_teacher_details();
                fill_taecher_list();
            }
        }
        else
        {
            Response.Redirect("Teacher_Login.aspx");
        }
    }

    protected void lnk_save_Click(object sender, EventArgs e)
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("update teacher_master set tm_name=@tm_name , tm_ctn=@tm_ctn , tm_email=@tm_email , tm_eduction=@tm_eduction,tm_img=@tm_img , tm_dob=@tm_dob ,tm_status=@tm_status ,tm_logdt=@tm_logdt , tm_logrid=@tm_logrid where tm_id=@tm_id", con);
            cmd.Parameters.AddWithValue("@tm_name", txt_teacher_name.Text);
            cmd.Parameters.AddWithValue("@tm_ctn", txt_teacher_ctn.Text);
            cmd.Parameters.AddWithValue("@tm_email", txt_teacher_email.Text);
            cmd.Parameters.AddWithValue("@tm_eduction", txt_teacher_edu.Text);
            string profile_path = "";
            if (fu_teacher_img.HasFile)
            {
                if (img_teacher_profile.ImageUrl != "" && fu_teacher_img.HasFile && Session["teacher_login"] != null && Session["teacher_login"].ToString() != "")
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
            else if (Session["teacher_login"] != null && Session["teacher_login"].ToString() != "" && img_teacher_profile.ImageUrl.ToString() != "" && img_teacher_profile.ImageUrl != null)
            {
                profile_path = img_teacher_profile.ImageUrl;
            }
            else
            {
                profile_path = "~/Admin/Assets/images/logo-dark.png";
            }

            cmd.Parameters.AddWithValue("@tm_img", profile_path.ToString());
            cmd.Parameters.AddWithValue("@tm_dob", txt_teacher_dob.Text);
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
            cmd.Parameters.AddWithValue("@tm_id", Session["teacher_login"]);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            Response.Write("<script>alert('Teacher Details Update Sucesfully'); window.location.href='Teacher_Profile.aspx'</script>");
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
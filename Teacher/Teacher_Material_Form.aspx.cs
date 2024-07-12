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
public partial class Teacher_Teacher_Material_Form : System.Web.UI.Page
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
    void Fill_Course_Dropdown()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select cm_id,cm_name from course_master where cm_status=1", con);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr_course_name.DataSource = ds;
                dr_course_name.DataTextField = "cm_name";
                dr_course_name.DataValueField = "cm_id";
                dr_course_name.DataBind();
                dr_course_name.Attributes.Add("style", "text-transform:capitalize");
                con.Close();
                con.Dispose();
                dr_course_name.Items.Insert(0, "-- Select Course --");
                dr_course_name.Items[0].Value = "0";
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
            cmd = new MySqlCommand("select scm_id,scm_name from get_sub_course_details where scm_status=1 and scm_cm_id=@scm_cm_id", con);
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
                dr_sub_course_name.Attributes.Add("style", "text-transform:capitalize");
                con.Close();
                con.Dispose();
                dr_sub_course_name.Items.Insert(0, "-- Select Sub Course --");
                dr_sub_course_name.Items[0].Value = "0";
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
    void Fill_Subject_Dropdown()
    {
        mycon();
        try
        {
            cmd = new MySqlCommand("select * from get_subject_details where subm_status=1 and subm_scm_id=@subm_scm_id", con);
            cmd.Parameters.AddWithValue("@subm_scm_id", dr_sub_course_name.SelectedItem.Value);
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr_subject_name.DataSource = ds;
                dr_subject_name.DataTextField = "subm_name";
                dr_subject_name.DataValueField = "subm_id";
                dr_subject_name.DataBind();
                dr_subject_name.Items.Insert(0, "-- Select Subject Name --");
                dr_subject_name.Items[0].Value = "0";
            }
            else
            {
                dr_subject_name.Items.Clear();
                dr_subject_name.Items.Insert(0, "-- Select Subject Name --");
                dr_subject_name.Items[0].Value = "0";
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
    void Fill_Materials_For_Edit()
    {
        mycon();
        try
        {
            lnk_save.Text = "<span class='feather icon-edit'>&nbsp;&nbsp;Update</span>";
            cmd = new MySqlCommand("select * from get_materials_details where mm_id=@mm_id", con);
            cmd.Parameters.AddWithValue("@mm_id", Request.QueryString["mmid"].ToString());
            da = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rf_fu_material_file.Visible = false;
                dr_course_name.Text = ds.Tables[0].Rows[0]["scm_cm_id"].ToString();
                string scmid = ds.Tables[0].Rows[0]["mm_scm_id"].ToString();
                string subjectid = ds.Tables[0].Rows[0]["mm_subm_id"].ToString();
                txt_material_title.Text = ds.Tables[0].Rows[0]["mm_title"].ToString();
                if (ds.Tables[0].Rows[0]["mm_file_status"].ToString() == "1" && ds.Tables[0].Rows[0]["mm_url_link_status"].ToString() == "1")
                {
                    chk_file.Checked = true;
                    chk_video.Checked = true;
                    pnl_img_path.Visible = true;
                    pnl_link_url.Visible = true;
                    txt_youtube_url.Text = ds.Tables[0].Rows[0]["mm_link_url"].ToString();
                    hl_material_file.NavigateUrl = ds.Tables[0].Rows[0]["mm_img_path"].ToString();
                }
                else if (ds.Tables[0].Rows[0]["mm_file_status"].ToString() == "1")
                {
                    chk_file.Checked = true;
                    pnl_img_path.Visible = true;
                    hl_material_file.NavigateUrl = ds.Tables[0].Rows[0]["mm_img_path"].ToString();
                }
                else if (ds.Tables[0].Rows[0]["mm_url_link_status"].ToString() == "1")
                {
                    chk_video.Checked = true;
                    pnl_link_url.Visible = true;
                    txt_youtube_url.Text = ds.Tables[0].Rows[0]["mm_link_url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["mm_status"].ToString() == "1")
                {
                    rdo_active.Checked = true;
                }
                else if (ds.Tables[0].Rows[0]["mm_status"].ToString() == "0")
                {
                    rdo_deactive.Checked = true;
                }
                Fill_Sub_Course_Dropdown();
                dr_sub_course_name.Text = scmid.ToString();
                Fill_Subject_Dropdown();
                dr_subject_name.Text = subjectid.ToString();
            }
            else
            {
                Response.Write("<script>alert('No Material Available'); window.location.href='Teacher_Material_List.aspx'</script>");
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
                Fill_Course_Dropdown();
                dr_sub_course_name.Items.Insert(0, "-- Select Sub Course  --");
                dr_sub_course_name.Items[0].Value = "0";
                dr_subject_name.Items.Insert(0, "-- Select Subject --");
                dr_subject_name.Items[0].Value = "0";

                if (Request.QueryString["mmid"] != null && Request.QueryString["mmid"].ToString() != "")
                {
                    Fill_Materials_For_Edit();
                }
            }
        }
    }
    protected void lnk_save_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["mmid"] != null && Request.QueryString["mmid"].ToString() != "")
        {
            mycon();
            try
            {
                cmd = new MySqlCommand("update materials_master set mm_scm_id=@mm_scm_id, mm_subm_id=@mm_subm_id ,mm_title=@mm_title ,mm_file_status=@mm_file_status,mm_url_link_status=@mm_url_link_status,mm_status=@mm_status,mm_link_url=@mm_link_url, mm_img_path=@mm_img_path,mm_status=@mm_status,mm_logdt=@mm_logdt ,mm_logrid=@mm_logrid where mm_id=@mm_id", con);
                cmd.Parameters.AddWithValue("@mm_scm_id", dr_sub_course_name.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@mm_subm_id", dr_subject_name.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@mm_title", txt_material_title.Text);
                if (rdo_active.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@mm_status", 1);
                }
                else if (rdo_deactive.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@mm_status", 0);
                }

                if (chk_file.Checked == true && chk_video.Checked == true)
                {
                    string material_path = "";
                    if (fu_material_file.HasFile)
                    {
                        if (hl_material_file.ImageUrl != "" && fu_material_file.HasFile && Request.QueryString["mmid"].ToString() != "")
                        {
                            String FileToDelete = Server.MapPath(hl_material_file.NavigateUrl);
                            File.Delete(FileToDelete);
                        }
                        Guid guidMaterailFile = Guid.NewGuid();
                        hf_ext_img.Value = System.IO.Path.GetExtension(fu_material_file.FileName);
                        hf_name_img.Value = guidMaterailFile.ToString() + hf_ext_img.Value;
                        fu_material_file.SaveAs(Server.MapPath("~/Admin/Admin_Data/Materails_Doc/" + hf_name_img.Value));
                        material_path = "~/Admin/Admin_Data/Materails_Doc/" + hf_name_img.Value;
                    }
                    else if (Request.QueryString["mmid"].ToString() != "" && Request.QueryString["mmid"] != null && hl_material_file.NavigateUrl.ToString() != "" && hl_material_file.ImageUrl != null)
                    {
                        material_path = hl_material_file.NavigateUrl;
                    }
                    else
                    {
                        material_path = "~/Admin/Assets/images/logo-dark.png";
                    }
                    cmd.Parameters.AddWithValue("@mm_img_path", material_path);
                    cmd.Parameters.AddWithValue("@mm_file_status", 1);
                    cmd.Parameters.AddWithValue("@mm_url_link_status", 1);
                    cmd.Parameters.AddWithValue("@mm_link_url", txt_youtube_url.Text);
                }

                else if (chk_file.Checked == true)
                {
                    string material_path = "";
                    if (fu_material_file.HasFile)
                    {
                        if (hl_material_file.ImageUrl != "" && fu_material_file.HasFile && Request.QueryString["mmid"].ToString() != "")
                        {
                            String FileToDelete = Server.MapPath(hl_material_file.NavigateUrl);
                            File.Delete(FileToDelete);
                        }
                        Guid guidMaterailFile = Guid.NewGuid();
                        hf_ext_img.Value = System.IO.Path.GetExtension(fu_material_file.FileName);
                        hf_name_img.Value = guidMaterailFile.ToString() + hf_ext_img.Value;
                        fu_material_file.SaveAs(Server.MapPath("~/Admin/Admin_Data/Materails_Doc/" + hf_name_img.Value));
                        material_path = "~/Admin/Admin_Data/Materails_Doc/" + hf_name_img.Value;
                    }
                    else if (Request.QueryString["tmid"].ToString() != "" && Request.QueryString["tmid"] != null && hl_material_file.NavigateUrl.ToString() != "" && hl_material_file.ImageUrl != null)
                    {
                        material_path = hl_material_file.NavigateUrl;
                    }
                    else
                    {
                        material_path = "~/Admin/Assets/images/logo-dark.png";
                    }
                    cmd.Parameters.AddWithValue("@mm_img_path", material_path);
                    cmd.Parameters.AddWithValue("@mm_file_status", 1);
                    cmd.Parameters.AddWithValue("@mm_url_link_status", 0);
                    cmd.Parameters.AddWithValue("@mm_link_url", "");
                }
                else if (chk_video.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@mm_file_status", 0);
                    cmd.Parameters.AddWithValue("@mm_url_link_status", 1);
                    cmd.Parameters.AddWithValue("@mm_link_url", txt_youtube_url.Text);
                    cmd.Parameters.AddWithValue("@mm_img_path", "");
                }
                cmd.Parameters.AddWithValue("@mm_logdt", dtc.GetIndianDateTime());
                cmd.Parameters.AddWithValue("@mm_logrid", Session["teacher_login"]);
                cmd.Parameters.AddWithValue("@mm_id", Request.QueryString["mmid"].ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                Response.Write("<script>alert('Material Update Successfully'); window.location.href='Teacher_Material_List.aspx'</script>");
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
                cmd = new MySqlCommand("insert into materials_master values(null,@mm_scm_id,@mm_subm_id,@mm_title,@mm_file_status,@mm_url_link_status,@mm_link_url,@mm_img_path,@mm_status,@mm_insdt,@mm_insrid,@mm_logdt,@mm_logrid) ", con);
                cmd.Parameters.AddWithValue("@mm_scm_id", dr_sub_course_name.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@mm_subm_id", dr_subject_name.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@mm_title", txt_material_title.Text);
                if (rdo_active.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@mm_status", 1);
                }
                else if (rdo_active.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@mm_status", 0);
                }

                if (chk_file.Checked == true && chk_video.Checked == true)
                {
                    string material_path = "";
                    if (fu_material_file.HasFile)
                    {
                        if (hl_material_file.ImageUrl != "" && fu_material_file.HasFile && Request.QueryString["mmid"].ToString() != "")
                        {
                            String FileToDelete = Server.MapPath(hl_material_file.NavigateUrl);
                            File.Delete(FileToDelete);
                        }
                        Guid guidMaterailFile = Guid.NewGuid();
                        hf_ext_img.Value = System.IO.Path.GetExtension(fu_material_file.FileName);
                        hf_name_img.Value = guidMaterailFile.ToString() + hf_ext_img.Value;
                        fu_material_file.SaveAs(Server.MapPath("~/Admin/Admin_Data/Materails_Doc/" + hf_name_img.Value));
                        material_path = "~/Admin/Admin_Data/Materails_Doc/" + hf_name_img.Value;
                    }
                    else if (Request.QueryString["tmid"].ToString() != "" && Request.QueryString["tmid"] != null && hl_material_file.NavigateUrl.ToString() != "" && hl_material_file.ImageUrl != null)
                    {
                        material_path = hl_material_file.NavigateUrl;
                    }
                    else
                    {
                        material_path = "~/Admin/Assets/images/logo-dark.png";
                    }

                    cmd.Parameters.AddWithValue("@mm_img_path", material_path);
                    cmd.Parameters.AddWithValue("@mm_file_status", 1);
                    cmd.Parameters.AddWithValue("@mm_url_link_status", 1);
                    cmd.Parameters.AddWithValue("@mm_link_url", txt_youtube_url.Text);
                }

                else if (chk_file.Checked == true)
                {
                    string material_path = "";
                    if (fu_material_file.HasFile)
                    {
                        if (hl_material_file.ImageUrl != "" && fu_material_file.HasFile && Request.QueryString["mmid"].ToString() != "")
                        {
                            String FileToDelete = Server.MapPath(hl_material_file.NavigateUrl);
                            File.Delete(FileToDelete);
                        }
                        Guid guidMaterailFile = Guid.NewGuid();
                        hf_ext_img.Value = System.IO.Path.GetExtension(fu_material_file.FileName);
                        hf_name_img.Value = guidMaterailFile.ToString() + hf_ext_img.Value;
                        fu_material_file.SaveAs(Server.MapPath("~/Admin/Admin_Data/Materails_Doc/" + hf_name_img.Value));
                        material_path = "~/Admin/Admin_Data/Materails_Doc/" + hf_name_img.Value;
                    }
                    else if (Request.QueryString["tmid"].ToString() != "" && Request.QueryString["tmid"] != null && hl_material_file.NavigateUrl.ToString() != "" && hl_material_file.ImageUrl != null)
                    {
                        material_path = hl_material_file.NavigateUrl;
                    }
                    else
                    {
                        material_path = "~/Admin/Assets/images/logo-dark.png";
                    }
                    cmd.Parameters.AddWithValue("@material_path", material_path);
                    cmd.Parameters.AddWithValue("@mm_file_status", 1);
                    cmd.Parameters.AddWithValue("@mm_url_link_status", 0);
                    cmd.Parameters.AddWithValue("@mm_link_url", "");
                }
                else if (chk_video.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@mm_file_status", 0);
                    cmd.Parameters.AddWithValue("@mm_url_link_status", 1);
                    cmd.Parameters.AddWithValue("@mm_link_url", txt_youtube_url.Text);
                    cmd.Parameters.AddWithValue("@mm_img_path", "");
                }
                cmd.Parameters.AddWithValue("@mm_insdt", dtc.GetIndianDateTime());
                cmd.Parameters.AddWithValue("@mm_insrid", Session["teacher_login"]);
                cmd.Parameters.AddWithValue("@mm_logdt", dtc.GetIndianDateTime());
                cmd.Parameters.AddWithValue("@mm_logrid", Session["teacher_login"]);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                Response.Write("<script>alert('Material Added Successfully'); window.location.href='Teacher_Material_List.aspx'</script>");
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
    protected void lnk_clear_Click(object sender, EventArgs e)
    {
        Server.Transfer("Teacher_Material_Form.aspx");
    }
    protected void dr_course_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_Sub_Course_Dropdown();
    }
    protected void dr_sub_course_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_Subject_Dropdown();
    }

    protected void chk_file_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_file.Checked == true)
        {
            pnl_img_path.Visible = true;
        }
        else
        {
            pnl_img_path.Visible = false;
        }
    }

    protected void chk_video_CheckedChanged(object sender, EventArgs e)
    {

        if (chk_video.Checked == true)
        {
            pnl_link_url.Visible = true;
        }
        else
        {
            pnl_link_url.Visible = false;
        }
    }

}
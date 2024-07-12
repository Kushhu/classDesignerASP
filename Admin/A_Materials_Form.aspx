<%@ Page Title="Material Form" Language="C#" ValidateRequest="false" EnableEventValidation="false" MasterPageFile="~/Admin/Admin_Master.master" AutoEventWireup="true" CodeFile="A_Materials_Form.aspx.cs" Inherits="Admin_A_Materials_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content_header" runat="Server">
    <style>
        .form-group label {
            margin-left: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_page" runat="Server">
    <div class="pcoded-content">
        <!-- [ breadcrumb ] start -->
        <div class="page-header">
            <div class="page-block">
                <div class="row align-items-center">
                    <div class="col-md-12">
                        <div class="page-header-title">
                            <h5 class="m-b-10">Add New Material</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="javascript:void(0)"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="#">Add Material</a></li>
                            <li class="breadcrumb-item float-right"><a href="A_Material_List.aspx"><i class="feather icon-skip-back mr-2"></i>Go to Material List</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ breadcrumb ] end -->
        <!-- [ Main Content ] start -->
        <div class="row">
            <!-- prject ,team member start -->
            <div class="col-xl-12 col-md-12">
                <div class="card">
                    <div class="card-header">
                        <h5>Material Management</h5>
                        <div class="card-header-right">
                            <div class="btn-group card-option">
                                <button type="button" class="btn dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <i class="feather icon-more-horizontal"></i>
                                </button>
                                <ul class="list-unstyled card-option dropdown-menu dropdown-menu-right">
                                    <li class="dropdown-item full-card"><a href="#!"><span><i class="feather icon-maximize"></i>maximize</span><span style="display: none"><i class="feather icon-minimize"></i> Restore</span></a></li>
                                    <li class="dropdown-item minimize-card"><a href="#!"><span><i class="feather icon-minus"></i>collapse</span><span style="display: none"><i class="feather icon-plus"></i> expand</span></a></li>
                                    <li class="dropdown-item reload-card"><a href="#!"><i class="feather icon-refresh-cw"></i>reload</a></li>
                                    <li class="dropdown-item close-card"><a href="#!"><i class="feather icon-trash"></i>remove</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="form-group">
                            <asp:DropDownList runat="server" AutoPostBack="true" OnSelectedIndexChanged="dr_course_name_SelectedIndexChanged" ID="dr_course_name" CssClass="js-example-data-array form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" InitialValue="0" ID="rf_dr_course_name" Display="Dynamic" ControlToValidate="dr_course_name" CssClass="mt-2" ErrorMessage="! Please Select Course Name" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList runat="server" AutoPostBack="true" OnSelectedIndexChanged="dr_sub_course_name_SelectedIndexChanged" ID="dr_sub_course_name" CssClass="js-example-data-array form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" ID="rf_dr_sub_course_name" InitialValue="0" Display="Dynamic" ControlToValidate="dr_sub_course_name" CssClass="mt-2" ErrorMessage="! Please Select Sub Course Name" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList runat="server" ID="dr_subject_name" CssClass="js-example-data-array form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" ID="rf_dr_subject_name" Display="Dynamic" ControlToValidate="dr_subject_name" InitialValue="0" CssClass="mt-2" ErrorMessage="! Please Select Subject Name" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label class="floating-label" for="txt_material_title">Enter Material Title</label>
                            <asp:TextBox ID="txt_material_title" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" ID="rf_txt_material_title" Display="Dynamic" ControlToValidate="txt_material_title" CssClass="mt-2" ErrorMessage="! Please Fill Material Title" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <asp:UpdatePanel runat="server" ID="up_pnl_materials_type">
                            <ContentTemplate>
                                <div class="form-group">
                                    <label class="font-weight-bold d-block">Type</label>
                                    <asp:CheckBox runat="server" ID="chk_video" AutoPostBack="true" Text="Video" OnCheckedChanged="chk_video_CheckedChanged" />
                                    <asp:CheckBox CssClass="ml-2" runat="server" AutoPostBack="true" ID="chk_file" Text="File" OnCheckedChanged="chk_file_CheckedChanged" />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="chk_file" />
                                <asp:PostBackTrigger ControlID="chk_video" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <div class="input-group mb-3" id="pnl_link_url" runat="server" visible="false">
                            <label for="basic-url" class="d-block mr-2">YouTube URL</label>

                            <div class="input-group-prepend">
                                <span class="input-group-text" id="basic-addon3">https://www.youtube.com/watch?v=</span>
                            </div>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_youtube_url" aria-describedby="basic-addon3"></asp:TextBox>
                        </div>

                        <div class="row" id="pnl_img_path" runat="server" visible="false">
                            <div class="col-sm-6 col-12">
                                <div class="form-group">
                                    <div class="input-group cust-file-button">
                                        <div class="custom-file">
                                            <asp:FileUpload ID="fu_material_file" onchange="showMaterialImage(this)" runat="server" CssClass="custom-file-input" />
                                            <label class="custom-file-label" for="fu_material_file">Choose Material File</label>
                                        </div>
                                    </div>
                                    <asp:HiddenField runat="server" ID="hf_ext_img" />
                                    <asp:HiddenField runat="server" ID="hf_name_img" />
                                    <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" ID="rf_fu_material_file" Display="Dynamic" ControlToValidate="fu_material_file" CssClass="mt-2" ErrorMessage="! Please Fill Materail File" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-sm-6 col-12">
                                <div class="form-group">
                                    <asp:HyperLink runat="server" ID="hl_material_file" Text="View Materials" CssClass="btn btn-info"></asp:HyperLink>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <b class="d-block">
                                <label>Status</label></b>
                            <asp:RadioButton Checked="true" CssClass="form-check-label" runat="server" ID="rdo_active" GroupName="status" Text="Active" />
                            <asp:RadioButton CssClass="form-check-label" runat="server" ID="rdo_deactive" Text="Deactive" GroupName="status" />
                        </div>
                    </div>
                    <div class="card-footer">
                        <div class="form-group">
                            <asp:LinkButton runat="server" ID="lnk_save" ValidationGroup="save" OnClick="lnk_save_Click" CssClass="btn btn-outline-success"><i class="feather icon-save mr-2"></i>Save</asp:LinkButton>
                            <asp:LinkButton runat="server" OnClick="lnk_clear_Click" ID="lnk_clear" CssClass="btn btn-outline-danger" CausesValidation="false"><i class="feather icon-x mr-2"></i>Clear</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_javascript" runat="Server">
</asp:Content>


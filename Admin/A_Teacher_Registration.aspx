<%@ Page Title="Teacher Registration" Language="C#" MasterPageFile="~/Admin/Admin_Master.master" AutoEventWireup="true" CodeFile="A_Teacher_Registration.aspx.cs" Inherits="Admin_Teacher_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_page" runat="Server">
    <div class="pcoded-content">
        <!-- [ breadcrumb ] start -->
        <div class="page-header">
            <div class="page-block">
                <div class="row align-items-center">
                    <div class="col-md-12">
                        <div class="page-header-title">
                            <h5 class="m-b-10">Add New Teacher</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="javascript:void(0)"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="#">Add Teacher</a></li>
                            <li class="breadcrumb-item float-right"><a href="A_Teacher_List.aspx"><i class="feather icon-skip-back mr-2"></i>Go to Teacher List</a></li>
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
                        <h5>Teacher Management</h5>
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
                        <div class="row">
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label class="floating-label" for="txt_course_name">Enter Teacher Name</label>
                                    <asp:TextBox ID="txt_teacher_name" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" ID="rf_txt_teacher_name" Display="Dynamic" ControlToValidate="txt_teacher_name" CssClass="mt-2" ErrorMessage="! Please Fill Teacher Name" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label class="floating-label" for="txt_teacher_ctn">Enter Contact Number</label>
                                    <asp:TextBox ID="txt_teacher_ctn" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" ID="rf_txt_teacher_ctn" Display="Dynamic" ControlToValidate="txt_teacher_ctn" CssClass="mt-2" ErrorMessage="! Please Fill Contact Number" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator SetFocusOnError="true" runat="server" ID="rex_txt_teacher_ctn" Display="Dynamic" ControlToValidate="txt_teacher_ctn" ForeColor="Red" Font-Bold="true" ValidationGroup="save" CssClass="mt-2" ErrorMessage="! Please Fill Mobile No. In Correct Format" ValidationExpression="^[0][1-9]\d{9}$|^[1-9]\d{9}$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label class="floating-label" for="txt_teacher_email">Enter Email Address</label>
                                    <asp:TextBox ID="txt_teacher_email" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" ID="rf_txt_teacher_email" Display="Dynamic" ControlToValidate="txt_teacher_email" CssClass="mt-2" ErrorMessage="! Please Fill Email ID" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator SetFocusOnError="true" runat="server" ID="rex_txt_teacher_email" Display="Dynamic" ControlToValidate="txt_teacher_email" ForeColor="Red" Font-Bold="true" ValidationGroup="save" CssClass="mt-2" ErrorMessage="! Please Fill Email In Correct Format" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label class="floating-label" for="txt_teacher_edu">Enter Education Qualification</label>
                                    <asp:TextBox ID="txt_teacher_edu" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" ID="rf_txt_teacher_edu" Display="Dynamic" ControlToValidate="txt_teacher_edu" CssClass="mt-2" ErrorMessage="! Please Fill Education Qualification" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-12">
                                <b class="mb-2 d-block">Date of Birth</b>
                                <div>
                                    <asp:TextBox runat="server" ID="txt_date_of_birth" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" ID="rf_txt_date_of_birth" Display="Dynamic" ControlToValidate="txt_date_of_birth" CssClass="mt-2" ErrorMessage="! Please Choose Date of Birth" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-12">
                                <div class="form-group">
                                    <b class="d-block mb-2">Status</b>
                                    <asp:RadioButton runat="server" ID="rdo_active" Checked="true" Text="Active" GroupName="status" />
                                    <asp:RadioButton runat="server" ID="rdo_deactive" Text="Deactive" GroupName="status" />
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="row">
                                    <div class="col-sm-12 col-12">
                                        <div class="form-group">
                                            <div class="input-group cust-file-button">
                                                <div class="custom-file">
                                                    <asp:FileUpload ID="fu_teacher_img" onchange="showTeacherImage(this)" runat="server" CssClass="custom-file-input" />
                                                    <label class="custom-file-label" for="fu_teacher_img">Choose Teacher Image</label>
                                                </div>
                                            </div>
                                            <asp:HiddenField runat="server" ID="hf_ext_profile" />
                                            <asp:HiddenField runat="server" ID="hf_name_profile" />
                                            <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" ID="rf_fu_teacher_img" Display="Dynamic" ControlToValidate="fu_teacher_img" CssClass="mt-2" ErrorMessage="! Please Fill Teacher Image" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-12">
                                        <div class="form-group">

                                            <asp:Image runat="server" CssClass="rounded-circle" ID="img_teacher_profile" Height="100" Width="100" />
                                        </div>
                                    </div>
                                </div>
                            </div>
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
    <script type="text/javascript">
        function showTeacherImage(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#content_page_img_teacher_profile').css('visibility', 'visible');
                    $('#content_page_img_teacher_profile').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }</script>
</asp:Content>


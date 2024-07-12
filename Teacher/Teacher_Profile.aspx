<%@ Page Title="Teacher Profile" Language="C#" MasterPageFile="~/Teacher/Teacher_Master.master" AutoEventWireup="true" CodeFile="Teacher_Profile.aspx.cs" Inherits="Teacher_Teacher_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_page" runat="Server">
    <!-- [ Main Content ] start -->
    <div class="pcoded-content">
        <!-- [ breadcrumb ] start -->
        <div class="page-header">
            <div class="page-block">
                <div class="row align-items-center">
                    <div class="col-md-12">
                        <div class="page-header-title">
                            <h5 class="m-b-10">Teacher Management</h5>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <!-- [ breadcrumb ] end -->
        <!-- [ Main Content ] start -->
        <div class="row">
            <!-- liveline-section start -->
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-body text-center">
                        <div class="row align-items-center m-l-0">
                            <div class="col-sm-6 text-left">
                                <h5>Teacher Details</h5>
                            </div>
                            <div class="col-sm-6 text-right">
                                <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#modal-report"><i class="feather icon-eye mr-2"></i>View Profile</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <asp:Repeater runat="server" ID="rpt_teacher_list">
                <ItemTemplate>
                    <div class="col-lg-4 col-md-6">
                        <div class="card user-card user-card-1 mt-4">
                            <div class="card-body pt-0">
                                <div class="user-about-block text-center">
                                    <div class="row align-items-end">
                                        <div class="col text-left pb-3">
                                        </div>
                                        <div class="col">
                                            <asp:Image runat="server" CssClass="img-radius img-fluid wid-80" ID="img_teacher_profile" ImageUrl='<%#Eval("tm_img") %>' alt="User image" />
                                        </div>
                                        <div class="col text-right pb-3">
                                        </div>
                                    </div>
                                </div>
                                <div class="text-center">
                                    <a href="#!" data-toggle="modal" data-target="#modal-report">
                                        <h4 class="mb-1 mt-3"><%#Eval("tm_name")%></h4>
                                    </a>
                                    <p class="mb-1"><b>Contact : </b><a href='tel:<%#Eval("tm_ctn")%>'><i class="feather icon-phone-call mr-2"></i><%#Eval("tm_ctn")%></a></p>

                                    <p class="mb-1"><b>Email : </b><a href='mailto:<%#Eval("tm_email")%>'><i class="feather icon-mail mr-2"></i><%#Eval("tm_email")%></a></p>

                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <!-- liveline-section end -->
        </div>
        <!-- [ Main Content ] end -->
    </div>

    <div class="modal fade" id="modal-report" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Edit Teacher</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="user-about-block text-center mb-2">
                        <div class="row align-items-end">
                            <div class="col text-left pb-3">
                            </div>
                            <div class="col">
                                <asp:Image runat="server" ID="img_teacher_profile" Height="100" Width="100" CssClass="img-radius img-fluid wid-80" alt="User image" />
                            </div>
                            <div class="col text-right pb-3">
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group mt-3">
                                <label class="floating-label" for="txt_teacher_name"><small class="text-danger">* </small>Your Name</label>
                                <asp:TextBox runat="server" ID="txt_teacher_name" CssClass="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="txt_teacher_dob"><small class="text-danger">* </small>Date of Birth</label>
                                <asp:TextBox runat="server" ID="txt_teacher_dob" CssClass="form-control" TextMode="Date" placeholder=""></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="floating-label" for="txt_teacher_ctn"><small class="text-danger">* </small>Contact Number</label>
                                <asp:TextBox ID="txt_teacher_ctn" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="floating-label" for="txt_teacher_email"><small class="text-danger">* </small>E-Mail Address</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_teacher_email" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="floating-label" for="txt_teacher_edu"><small class="text-danger">* </small>Teacher Education</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_teacher_edu" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12">
                            <div class="row">
                                <div class="col-sm-12 col-12">
                                    <div class="form-group">
                                        <div class="input-group cust-file-button">
                                            <div class="custom-file">
                                                <asp:FileUpload ID="fu_teacher_img" onchange="showTeacherImage(this)" runat="server" CssClass="custom-file-input" />
                                                <label class="custom-file-label" for="inputGroupFile04">Chosse Teacher Image</label>
                                            </div>
                                        </div>
                                        <asp:HiddenField runat="server" ID="hf_ext_profile" />
                                        <asp:HiddenField runat="server" ID="hf_name_profile" />
                                        <asp:RequiredFieldValidator SetFocusOnError="true"  runat="server" ID="rf_fu_teacher_img" Display="Dynamic" ControlToValidate="fu_teacher_img" CssClass="d-block mt-2" ErrorMessage="! Please Fill Teacher Name" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="col-md-3 col-sm-12">
                            <div class="form-group">
                                <b class="d-block mb-2">Status</b>
                                <asp:RadioButton runat="server" ID="rdo_active" Text="Active" GroupName="status" />
                                <asp:RadioButton runat="server" ID="rdo_deactive" Text="Deactive" GroupName="status" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" data-dismiss="modal"><i class="feather icon-x mr-2"></i>Close</button>
                    <asp:LinkButton runat="server" OnClick="lnk_save_Click" ID="lnk_save" ValidationGroup="save" class="btn btn-success"><i class="feather icon-edit mr-2"></i>Update</asp:LinkButton>

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


<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Teacher/Teacher_Master.master" AutoEventWireup="true" CodeFile="Teacher_Change_Password.aspx.cs" Inherits="Teacher_Teacher_Change_Password" %>

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
                            <h4 class="m-b-10 text-white">Authentication</h4>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="auth-content">
            <div class="card">
                <div class="row align-items-center">
                    <div class="col-md-12">
                        <div class="card-header">
                            <h5 class="f-w-600 text-success card-title">Change Your Password</h5>

                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label class="floating-label" for="txt_current_password">Current Password</label>
                                <asp:TextBox TextMode="Password" runat="server" CssClass="form-control" ID="txt_current_password" placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" ID="rf_txt_current_password" ErrorMessage="! Please Fill Current Password" ForeColor="Red" Font-Bold="true" Display="Dynamic" ControlToValidate="txt_current_password" ValidationGroup="save"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator SetFocusOnError="true" Display="Dynamic" ControlToValidate="txt_current_password" ForeColor="Red" Font-Bold="true" runat="server" ID="rex_txt_current_password" ErrorMessage="! Please Enter Password 6 to 8 length" ValidationGroup="save" ValidationExpression="^(?=.*\d).{6,8}$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label class="floating-label" for="txt_new_password">New Password</label>
                                <asp:TextBox TextMode="Password" runat="server" CssClass="form-control" ID="txt_new_password" placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" ID="rf_txt_new_password" ErrorMessage="! Please Fill New Password" ForeColor="Red" Font-Bold="true" Display="Dynamic" ControlToValidate="txt_new_password" ValidationGroup="save"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator SetFocusOnError="true" Display="Dynamic" ControlToValidate="txt_new_password" ForeColor="Red" Font-Bold="true" runat="server" ID="rex_txt_new_password" ErrorMessage="! Please Enter Password 6 to 8 length" ValidationGroup="save" ValidationExpression="^(?=.*\d).{6,8}$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label class="floating-label" for="txt_re_new_password">Re-Type New Password</label>
                                <asp:TextBox TextMode="Password" runat="server" CssClass="form-control" ID="txt_re_new_password" placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" ID="rf_txt_re_new_password" ErrorMessage="! Please Re Enter New Password" ForeColor="Red" Font-Bold="true" Display="Dynamic" ControlToValidate="txt_re_new_password" ValidationGroup="save"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator SetFocusOnError="true" Display="Dynamic" ControlToValidate="txt_re_new_password" ForeColor="Red" Font-Bold="true" runat="server" ID="rex_txt_re_new_password" ErrorMessage="! Please Enter Password 6 to 8 length" ValidationGroup="save" ValidationExpression="^(?=.*\d).{6,8}$"></asp:RegularExpressionValidator><br />
                                <asp:CompareValidator SetFocusOnError="true" runat="server" Display="Dynamic" ID="cv_txt_re_new_password" ControlToCompare="txt_new_password" ErrorMessage="! Please Provide Same to Same Password as New Password" ControlToValidate="txt_re_new_password" ValidationGroup="save" Font-Bold="true" ForeColor="red" Type="String" Operator="Equal"></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="card-footer">
                            <asp:LinkButton runat="server" CssClass="btn btn-outline-primary mb-4 has-ripple" ValidationGroup="save" OnClick="lnk_change_password_Click" ID="lnk_change_password"><i class="fas fa-key mr-2"></i>Change Password<span class="ripple ripple-animate" style="height: 284px; width: 284px; animation-duration: 1.0s; animation-timing-function: linear; background: rgb(255, 255, 255); opacity: 0.4; top: -135.2px; left: 77px;"></span></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_javascript" runat="Server">
</asp:Content>


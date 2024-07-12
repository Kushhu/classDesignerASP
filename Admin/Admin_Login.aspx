<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Login.aspx.cs" Inherits="Admin_Admin_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="description" content="" />
    <meta name="keywords" content="">
    <meta name="author" content="Phoenixcoded" />
    <!-- Favicon icon -->
    <link rel="icon" href="Assets/images/authentication_login.png" type="image/x-icon">
    <!-- vendor css -->
    <link rel="stylesheet" href="Assets/css/style.css">
    <!--Customize CSS -->
    <link href="Assets/css/customize.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- [ auth-signin ] start -->
        <div class="container p-4">
            <div class="card w-100 mt-5">
                <div class="row">
                    <div class="col-md-6 col-12 text-center">
                        <img src="Assets/images/authentication_login.png" alt="Logo" class="img-fluid ml-auto">
                    </div>
                    <div class="col-md-6 col-12 login_margin">
                        <div class="card-header text-center">
                            <h3 class="mb-3 f-w-400">Admin Login</h3>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label class="floating-label" for="txt_admin_ctn">Enter Moblie No...</label>
                                <asp:TextBox runat="server" class="form-control mb-2" MaxLength="10" ID="txt_admin_ctn" placeholder="" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" Display="Dynamic" runat="server" ID="rf_txt_admin_ctn" ErrorMessage="! Please Fill Mobile No." ForeColor="Red" Font-Bold="true" ControlToValidate="txt_admin_ctn" ValidationGroup="save"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator SetFocusOnError="true" runat="server" ID="re_txt_admin_ctn" Display="Dynamic" ControlToValidate="txt_admin_ctn" ForeColor="Red" Font-Bold="true" ValidationGroup="save" ErrorMessage="! Please Fill Mobile No. In Correct Format" ValidationExpression="^[0][1-9]\d{9}$|^[1-9]\d{9}$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label class="floating-label" for="txt_admin_password">Enter Password...</label>
                                <asp:TextBox TextMode="Password" runat="server" CssClass="form-control mb-2" ID="txt_admin_password" placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" Display="Dynamic" ID="rf_txt_admin_password" ErrorMessage="! Please Fill Password" ForeColor="Red" Font-Bold="true" ControlToValidate="txt_admin_password" ValidationGroup="save"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator SetFocusOnError="true" Display="Dynamic" ControlToValidate="txt_admin_password" ForeColor="Red" Font-Bold="true" runat="server" ID="re_txt_admin_password" ErrorMessage="! Please Enter Password 6 to 8 length" ValidationGroup="save" ValidationExpression="^(?=.*\d).{6,8}$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group text-left">
                                <asp:HyperLink runat="server" ID="hl_teacher_login" CssClass="float-right" Text="Teacher Login ?" NavigateUrl="~/Teacher/Teacher_Login.aspx"></asp:HyperLink>
                            </div>
                            <div class="form-gropu text-center">
                                <asp:Button runat="server" ID="lnk_login_in" ValidationGroup="save" OnClick="lnk_login_in_Click" CssClass="btn btn-outline-primary" Text="Login" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ auth-signin ] end -->
        <!-- Required Js -->
        <script src="Assets/js/vendor-all.min.js"></script>
        <script src="Assets/js/plugins/bootstrap.min.js"></script>
        <script src="Assets/js/ripple.js"></script>
        <script src="Assets/js/pcoded.min.js"></script>
        <script type="text/javascript">
            history.pushState(null, null, location.href); history.back(); history.forward(); window.onpopstate = function () { history.go(1); };
        </script>
    </form>
</body>
</html>

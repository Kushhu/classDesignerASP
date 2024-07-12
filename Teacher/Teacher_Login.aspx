<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teacher_Login.aspx.cs" Inherits="Teacher_Teacher_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teacher Login</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="description" content="" />
    <meta name="keywords" content="">
    <meta name="author" content="Phoenixcoded" />
    <!-- Favicon icon -->
    <link rel="icon" href="../Admin/Assets/images/teacher-login.png" type="image/x-icon">

    <!-- vendor css -->
    <link rel="stylesheet" href="../Admin/Assets/css/style.css">
    <!--Customize CSS -->
    <link href="../Admin/Assets/css/customize.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- [ auth-signin ] start -->

        <div class="container p-3">
            <div class="card w-100 mt-5">
                <div class="row">
                    <div class="col-md-6 col-12 text-center">

                        <img src="../Admin/Assets/images/teacher-login.png" alt="Logo" class="img-fluid ml-auto" >
                    </div>
                    <div class="col-md-6 col-12 login_margin">
                        <div class="card-header text-center">
                            <h3 class="mb-3 f-w-400">Teacher Login</h3>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label class="floating-label" for="Email">Enter Moblie No...</label>
                                <asp:TextBox runat="server" class="form-control mb-2" TextMode="Number" ID="txt_teacher_ctn" placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true"  runat="server" ID="rf_txt_teacher_ctn" ErrorMessage="! Please Fill Mobile No." ForeColor="Red" Font-Bold="true" Display="Dynamic" ControlToValidate="txt_teacher_ctn" ValidationGroup="save"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator SetFocusOnError="true"  runat="server" ID="rex_txt_teacher_ctn" Display="Dynamic" ControlToValidate="txt_teacher_ctn" ForeColor="Red" Font-Bold="true" ValidationGroup="save" ErrorMessage="! Please Fill Mobile No. In Correct Format" ValidationExpression="^[0][1-9]\d{9}$|^[1-9]\d{9}$"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group">
                                <label class="floating-label" for="Password">Enter Password...</label>
                                <asp:TextBox TextMode="Password" runat="server" CssClass="form-control mb-2" ID="txt_teacher_password" placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true"  runat="server" ID="rf_txt_teacher_password" ErrorMessage="! Please Fill Password" ForeColor="Red" Font-Bold="true" Display="Dynamic" ControlToValidate="txt_teacher_password" ValidationGroup="save"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator SetFocusOnError="true"  Display="Dynamic" ControlToValidate="txt_teacher_password" ForeColor="Red" Font-Bold="true" runat="server" ID="rex_txt_teacher_password" ErrorMessage="! Please Enter Password 6 to 8 length" ValidationGroup="save" ValidationExpression="^(?=.*\d).{6,8}$"></asp:RegularExpressionValidator>
                            </div>

                            <div class="form-group text-center">
                                <asp:Button runat="server" ID="lnk_sign_in" ValidationGroup="save" OnClick="lnk_sign_in_Click" CssClass="btn btn-outline-primary" Text="Login" />
                                <br />
                                <a class="has-ripple d-inline-block text-right mt-2 mr-auto" href="#" data-toggle="modal" data-target="#forget_password_Modal">Do You Want Forget Password ?</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ auth-signin ] end -->

        <div id="forget_password_Modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="exampleModalLiveLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLiveLabel">Forget Password</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    </div>
                    <div class="modal-body">
                        <asp:Panel runat="server" ID="pnl_email">

                            <div class="form-group">
                                <label class="floating-label" for="Email">Enter Your E-Mail Address...</label>
                                <asp:TextBox runat="server" class="form-control mb-2" ID="txt_teacher_email" placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true"  runat="server" ID="rf_txt_teacher_email" ErrorMessage="! Please Fill Email Address." ForeColor="Red" Font-Bold="true" Display="Dynamic" ControlToValidate="txt_teacher_email" ValidationGroup="forget"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator SetFocusOnError="true"  runat="server" ID="rex_txt_teacher_email" Display="Dynamic" ControlToValidate="txt_teacher_email" ForeColor="Red" Font-Bold="true" ValidationGroup="forget" ErrorMessage="! Please Fill E-Mail Address In Correct Format" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"></asp:RegularExpressionValidator>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnl_otp" Visible="false">
                            <div class="form-group">
                                <label class="floating-label" for="Password">Enter OTP...</label>
                                <asp:TextBox TextMode="Password" runat="server" CssClass="form-control mb-2" ID="txt_otp" placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true"  runat="server" ID="rf_txt_otp" ErrorMessage="! Please Fill OTP" ForeColor="Red" Font-Bold="true" Display="Dynamic" ControlToValidate="txt_otp" ValidationGroup="forget"></asp:RequiredFieldValidator>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <asp:LinkButton runat="server" ID="lnk_save" OnClick="lnk_save_Click" Text="Send OTP" ValidationGroup="forget" CssClass="btn btn-primary"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>


        <!-- Required Js -->
        <script src="../Admin/Assets/js/vendor-all.min.js"></script>
        <script src="../Admin/Assets/js/plugins/bootstrap.min.js"></script>
        <script src="../Admin/Assets/js/ripple.js"></script>
        <script src="../Admin/Assets/js/pcoded.min.js"></script>
        <script type="text/javascript">
            history.pushState(null, null, location.href); history.back(); history.forward(); window.onpopstate = function () { history.go(1); };
        </script>

    </form>
</body>
</html>

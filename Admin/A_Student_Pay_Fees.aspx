<%@ Page Title="Pay Student Fees" Language="C#" MasterPageFile="~/Admin/Admin_Master.master" AutoEventWireup="true" CodeFile="A_Student_Pay_Fees.aspx.cs" Inherits="Admin_A_Student_Pay_Fees" %>

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
                            <h5 class="m-b-10">Add Fees</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="javascript:void(0)"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="#">Receive Fees</a></li>
                            <li class="breadcrumb-item float-right"><a href="A_Student_Fess_List.aspx"><i class="feather icon-skip-back mr-2"></i>Go to Student Fees List</a></li>
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
                <!-- Page Heading -->
                <div class="card shadow p-2">
                    <div class="card-header">
                        <h5>Receive Fee</h5>
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
                            <b class="mb-2">You are Receiving Fees Of</b>
                            <asp:TextBox Enabled="false" CssClass="form-control pl-2" ID="lbl_student_name" Font-Bold="true" runat="server" Text=""></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <b class="mb-2">Fees Of Student</b>
                            <asp:TextBox ID="txt_sm_fees" Enabled="false" runat="server" CssClass="form-control pl-2"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <b class="mb-2">Reaming Fees</b>
                            <asp:TextBox ID="txt_reaming_fees" ForeColor="Red" Enabled="false" runat="server" CssClass="form-control pl-2"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="floating-label" for="txt_pay_amount">Enter Fees Amount</label>
                            <asp:TextBox ID="txt_pay_amount" TextMode="Number" runat="server" CssClass="form-control text-info"></asp:TextBox>
                            <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" ID="rf_txt_pay_amount" Display="Dynamic" ControlToValidate="txt_pay_amount" ErrorMessage="! Please Fill Fees Amount" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator SetFocusOnError="true" ID="rex_txt_pay_amount" Display="Dynamic" ControlToValidate="txt_pay_amount" Font-Bold="true" ForeColor="Red" ValidationGroup="save" ValidationExpression="\d+" ErrorMessage="! Please enter Fees Amount In Numeric Format" runat="server" />
                        </div>
                        <div class="form-group">
                            <b class="mb-2">Remaining Fee Will Be</b>
                            <asp:TextBox ID="txt_remining_amount" runat="server" CssClass="form-control pl-2"></asp:TextBox>
                        </div>
                        <%--   <asp:UpdatePanel runat="server" ID="up_pnl_transtion_mode">
                            <ContentTemplate>--%>
                        <div class="form-group">
                            <b>
                                <label>Fees Mode</label></b>
                            <asp:DropDownList ID="dr_transtion_mode" CssClass="js-example-data-array form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dr_transtion_mode_SelectedIndexChanged">
                                <asp:ListItem Value="">-- Select Payment Options --</asp:ListItem>
                                <asp:ListItem Value="Cash">Cash Payment</asp:ListItem>
                                <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                <asp:ListItem Value="Debit / Credit / Net Banking">Debit / Credit / Net Banking</asp:ListItem>
                                <asp:ListItem Value="PayPal">PayPal</asp:ListItem>
                                <asp:ListItem Value="Paytm">Paytm</asp:ListItem>
                                <asp:ListItem Value="GooglePay">GooglePay</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="rf_dr_transtion_mode" runat="server" ControlToValidate="dr_transtion_mode" ValidationGroup="save" ErrorMessage="! Please Select Payment Mode" Display="Dynamic" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>

                        <asp:Panel runat="server" ID="pnl_file_transtion" Visible="false">
                            <div class="row">
                                <div class="col-sm-6 col-12">
                                    <div class="form-group">
                                        <div class="input-group cust-file-button">
                                            <div class="custom-file">
                                                <asp:FileUpload ID="fu_trastion_img" onchange="showTranstionImage(this)" runat="server" CssClass="custom-file-input" />
                                                <label class="custom-file-label" for="fu_trastion_img">Choose Transition Image</label>
                                            </div>
                                        </div>
                                        <asp:HiddenField runat="server" ID="hf_ext_profile" />
                                        <asp:HiddenField runat="server" ID="hf_name_profile" />
                                        <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" ID="rf_fu_trastion_img" Display="Dynamic" ControlToValidate="fu_trastion_img" CssClass="mt-2" ErrorMessage="! Please Choose Student Image" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-12">
                                    <div class="form-group">
                                        <asp:Image runat="server" ID="img_trasntion_image" Height="100" Width="100" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <%--   </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="dr_transtion_mode" />
                                <asp:PostBackTrigger ControlID="lnk_pay_fees" />
                            </Triggers>
                        </asp:UpdatePanel>--%>
                    </div>
                    <div class="card-footer bg-white">
                        <asp:LinkButton runat="server" ValidationGroup="save" ID="lnk_pay_fees" CssClass="btn btn-primary py-2 px-4" OnClick="lnk_pay_fees_Click"><i class="fa fa-print mr-2"></i>Get Receipt</asp:LinkButton>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_javascript" runat="Server">
    <script type="text/javascript">
        $('#content_page_txt_pay_amount').keyup(function () {
            debugger;
            var reaming_fees = $('#content_page_txt_reaming_fees').val();
            var paid_fees = $('#content_page_txt_pay_amount').val();
            if (parseInt(reaming_fees) >= parseInt(paid_fees)) {
                var amount_reaming = reaming_fees - paid_fees;
                $('#content_page_txt_remining_amount').val(amount_reaming);
                $('#content_page_txt_remining_amount').css("color", "Green");

            } else {
                $('#content_page_txt_remining_amount').val('Invalid Amount');
                $('#content_page_txt_remining_amount').css("color", "Red");
            }
        });
        function showTranstionImage(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#content_page_img_trasntion_image').css('visibility', 'visible');
                    $('#content_page_img_trasntion_image').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>

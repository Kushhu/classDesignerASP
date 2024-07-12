<%@ Page Title="" Language="C#" MasterPageFile="~/Client_Master.master" AutoEventWireup="true" CodeFile="ContactUS.aspx.cs" Inherits="ContactUS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_slider" runat="Server">
    <input type="hidden" name="name" value="contact" id="hidMn" />
    <!-- ============================ Page Title Start================================== -->
    <section class="page-title">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 col-md-12">

                    <div class="breadcrumbs-wrap">
                        <h1 class="breadcrumb-title">Get in Touch</h1>
                        <nav aria-label="breadcrumb">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="index.aspx">Home</a></li>
                                <li class="breadcrumb-item active" aria-current="page">Contact</li>
                            </ol>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- ============================ Page Title End ================================== -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_page" runat="Server">
    <!-- ============================ Agency List Start ================================== -->
    <section class="bg-light">
        <div class="container">
            <!-- row Start -->
            <div class="row">
                <div class="col-lg-8 col-md-7">
                    <div class="prc_wrap">
                        <div class="prc_wrap_header">
                            <h4 class="property_block_title">Fillup The Form</h4>
                        </div>
                        <div class="prc_wrap-body">
                            <div class="row">
                                <div class="col-lg-6 col-md-12">
                                    <div class="form-group">
                                        <label>Name</label>
                                        <asp:TextBox runat="server" ID="txt_name" CssClass="form-control simple mb-2"></asp:TextBox>
                                        <asp:RequiredFieldValidator SetFocusOnError="true"  runat="server" Display="Dynamic" ControlToValidate="txt_name" ID="rf_txt_name" ForeColor="Red" Font-Bold="true" ErrorMessage="! Please Fill Name" ></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-12">
                                    <div class="form-group">
                                        <label>Contact</label>
                                        <asp:TextBox ID="txt_ctn" runat="server" CssClass="form-control simple mb-2" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator SetFocusOnError="true"  runat="server" Display="Dynamic" ID="rf_txt_ctn" ControlToValidate="txt_ctn" ForeColor="Red" Font-Bold="true" ErrorMessage="! Please Fill Conatct No." ></asp:RequiredFieldValidator>
                                        <%--<asp:RegularExpressionValidator SetFocusOnError="true"  runat="server" ID="rex_txt_ctn" Display="Dynamic" ControlToValidate="txt_ctn" ForeColor="Red" Font-Bold="true" ValidationGroup="save" ErrorMessage="! Please Fill Mobile No. In Correct Format" ValidationExpression="^[789]\d{9}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>Subject</label>
                                <asp:TextBox ID="txt_subject" runat="server" CssClass="form-control simple mb-2"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true"  runat="server" Display="Dynamic" ID="rf_txt_subject" ControlToValidate="txt_subject" ForeColor="Red" Font-Bold="true" ErrorMessage="! Please Fill Subject" ></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>Message</label>
                                <asp:TextBox ID="txt_msg" TextMode="MultiLine" runat="server" CssClass="form-control simple  mb-2"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true"  runat="server" Display="Dynamic" ID="rf_txt_msg" ControlToValidate="txt_msg" ForeColor="Red" Font-Bold="true" ErrorMessage="! Please Fill Meassge"></asp:RequiredFieldValidator>

                            </div>
                            <div class="form-group">
                                <asp:Button ID="btn_save" OnClick="btn_save_Click"  CssClass="btn btn-theme" runat="server" Text="Submit Request" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-5">
                    <div class="prc_wrap">
                        <div class="prc_wrap_header">
                            <h4 class="property_block_title">Reach Us</h4>
                        </div>
                        <div class="prc_wrap-body">
                            <div class="contact-info">
                                <h2>Get In Touch</h2>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do </p>
                                <div class="cn-info-detail">
                                    <div class="cn-info-icon">
                                        <i class="ti-home"></i>
                                    </div>
                                    <div class="cn-info-content">
                                        <h4 class="cn-info-title">Reach Us</h4>
                                        2512, New Market,<br>
                                        Eliza Road, Sincher 80 CA,<br>
                                        Canada, USA
                                    </div>
                                </div>
                                <div class="cn-info-detail">
                                    <div class="cn-info-icon">
                                        <i class="ti-email"></i>
                                    </div>
                                    <div class="cn-info-content">
                                        <h4 class="cn-info-title">Drop A Mail</h4>
                                        support@Rikada.com<br>
                                        Rikada@gmail.com
                                    </div>
                                </div>

                                <div class="cn-info-detail">
                                    <div class="cn-info-icon">
                                        <i class="ti-mobile"></i>
                                    </div>
                                    <div class="cn-info-content">
                                        <h4 class="cn-info-title">Call Us</h4>
                                        (41) 123 521 458<br>
                                        +91 235 548 7548
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /row -->
        </div>
    </section>
    <!-- ============================ Agency List End ================================== -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content_javascript" runat="Server">
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Client_Master.master" AutoEventWireup="true" CodeFile="Teacher_Details.aspx.cs" Inherits="Teacher_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content_header" runat="Server">
    <style>
        .tech-img {
            height: 200px;
            width: 200px;
        }

        .border-info {
            border: 1.5px #da0b4e solid !important;
            -webkit-box-shadow: 3px 3px 5px 6px #ccc; /* Safari 3-4, iOS 4.0.2 - 4.2, Android 2.3+ */
            -moz-box-shadow: 3px 3px 5px 6px #ccc; /* Firefox 3.5 - 3.6 */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_slider" runat="Server">
    <input type="hidden" name="name" value="teacher" id="hidMn" />
    <!-- ============================ Page Title Start================================== -->
    <section class="page-title">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <div class="breadcrumbs-wrap">
                        <h3 class="breadcrumb-title">Teacher List</h3>
                        <nav aria-label="breadcrumb">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="index.aspx">Home</a></li>
                                <li class="breadcrumb-item active" aria-current="page">Teacher Details</li>
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
    <section class="pt-0">
        <div class="container">
            <div class="row">
                <asp:Repeater runat="server" ID="rpt_teacher_details">
                    <ItemTemplate>
                        <!-- Single Article -->
                        <div class="col-lg-4 col-md-4 col-sm-12">
                            <div class="articles_grid_style border-info wow bounceInLeft" data-wow-duration="2s" data-wow-delay="3s">
                                <div class="articles_grid_thumb mt-3 text-center">
                                    <asp:Image ID="img_teacher_image" CssClass="img-fluid rounded-circle tech-img" ImageUrl='<%#Eval("tm_img") %>' runat="server" />
                                </div>
                                <div class="articles_grid_caption text-center">
                                    <h4 class="text-info"><%#Eval("tm_name") %></h4>
                                    <h6><%#Eval("tm_eduction") %></h6>
                                </div>
                            </div>
                        </div>
                        <!-- Single Article End-->
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content_javascript" runat="Server">
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Client_Master.master" AutoEventWireup="true" CodeFile="Student_Info.aspx.cs" Inherits="Student_Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_slider" runat="Server">
    <input type="hidden" name="name" value="student_info" id="hidMn" />
    <!-- ============================ Page Title Start================================== -->
    <section class="page-title">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <div class="breadcrumbs-wrap">
                        <h1 class="breadcrumb-title">Get in Touch</h1>
                        <nav aria-label="breadcrumb">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="index.aspx">Student Info</a></li>
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content_javascript" runat="Server">
</asp:Content>


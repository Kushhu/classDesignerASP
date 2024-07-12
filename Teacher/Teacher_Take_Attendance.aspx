<%@ Page Title="Take Attendance" Language="C#" MasterPageFile="~/Teacher/Teacher_Master.master" AutoEventWireup="true" CodeFile="Teacher_Take_Attendance.aspx.cs" Inherits="Teacher_Teacher_Take_Attendance" %>

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
                            <h5 class="m-b-10">Student Details</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="javascript:void(0)"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="javascript:void(0)">Take Attendance</a></li>
                            <%--<li class="breadcrumb-item float-right"><a href="A_Student_Registration.aspx"><i class="feather icon-plus-circle mr-2"></i>Add New Student</a></li>--%>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ Main Content ] start -->
        <div class="row">
            <!-- DOM/Jquery table start -->
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header">
                        <h5>Student List</h5>
                        <div class="card-header-right">
                            <div class="btn-group card-option">
                                <asp:LinkButton runat="server" ID="lnk_save_attendance" CssClass="btn btn-outline-info mr-3" OnClick="lnk_save_attendance_Click"><i class="feather icon-user-check mr-2"></i>Take Attendance<i class="feather icon-user-x m-2"></i></asp:LinkButton>

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
                        <div class="table-responsive dt-responsive">
                            <table id="dom-jqry" class="table table-striped table-bordered nowrap">
                                <thead>
                                    <tr>
                                        <th>Attendance</th>
                                        <th>Student Details</th>
                                        <th>Student Profile</th>
                                        <th>Total Fees </th>
                                        <th>Remaining Fees </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rpt_take_attendance" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chk_attendance" />
                                                    <asp:HiddenField runat="server" ID="hf_sm_id" Value='<%#Eval("sm_id") %>' />
                                                </td>
                                                <td><b>Name : - </b><%#Eval("sm_name") %>
                                                    <br />
                                                    <b>Contact No. :- </b><a href='tel:<%#Eval("sm_ctn") %>'><i class="feather icon-phone-call mr-2"></i><%#Eval("sm_ctn") %></a>
                                                    <br />
                                                    <b>E-Mail  ID. :- </b><a href='mailto:<%#Eval("sm_email") %>'><i class="feather icon-mail mr-2"></i><%#Eval("sm_email") %></a>
                                                    <br />

                                                </td>
                                                <td>
                                                    <asp:Image runat="server" ID="img_student_profile" ImageUrl='<%#Eval("sm_img")%>' Style="height: 100px; width: 100px; border-radius: 40%; border: 2px black solid" />
                                                </td>
                                                <td>
                                                    <i class="fas fa-rupee-sign mr-2"></i><%#Eval("sm_fees") %>
                                                </td>
                                                <td>
                                                    <strong class="text-danger bold">
                                                        <i class="fas fa-rupee-sign mr-1"></i><%#Eval("Next_Reaming_Fees") %></strong>
                                                </td>
                                            </tr>
                                        </ItemTemplate>

                                    </asp:Repeater>

                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <!-- DOM/Jquery table end -->
        </div>
        <!-- [ Main Content ] end -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_javascript" runat="Server">
</asp:Content>


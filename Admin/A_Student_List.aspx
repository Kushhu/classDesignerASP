<%@ Page Title="Student List" Language="C#" MasterPageFile="~/Admin/Admin_Master.master" AutoEventWireup="true" CodeFile="A_Student_List.aspx.cs" Inherits="Admin_A_Student_List" %>

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
                            <li class="breadcrumb-item"><a href="javascript void(0)">Student List</a></li>
                            <li class="breadcrumb-item float-right"><a href="A_Student_Registration.aspx"><i class="feather icon-plus-circle mr-2"></i>Add New Student</a></li>
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
                                        <th>Sr No</th>
                                        <th>Student Details</th>
                                        <th>Student Profile</th>
                                        <th>Status</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>

                                    <asp:Repeater ID="rpt_student_list" runat="server" OnItemCommand="rpt_student_list_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#(Container.ItemIndex+1)%></td>

                                                <td><b>Name : - </b><%#Eval("sm_name") %>
                                                    <br />
                                                    <b>Contact No. :- </b><a href='tel:<%#Eval("sm_ctn") %>'><i class="feather icon-phone-call mr-2"></i><%#Eval("sm_ctn") %></a>
                                                    <br />
                                                    <b>E-Mail  ID. :- </b><a href='mailto:<%#Eval("sm_email") %>'><i class="feather icon-mail mr-2"></i><%#Eval("sm_email") %></a>
                                                    <br />
                                                    <b>Date of Birth :- </b><%#Eval("sm_dob").ToString().Split(null)[0] %>
                                                    <br />
                                                    <b>Gender :- </b><%#Eval("sm_gender") %>
                                                </td>
                                                <td>
                                                    <asp:Image runat="server" ID="img_student_profile" ImageUrl='<%#Eval("sm_img")%>' Style="height: 100px; width: 100px; border-radius: 50%; border: thick" />
                                                </td>
                                                <td>
                                                    <%#Eval("sm_status").ToString()== "1" ?"Active":"Deactive" %>
                                                </td>
                                                <td>
                                                    <a href='A_Student_Registration.aspx?smid=<%#Eval("sm_id") %>' class="btn btn-outline-info mr-3"><i class="feather icon-edit mr-2"></i>Edit</a>
                                                    <asp:LinkButton ID="lnk_delete" runat="server" OnClientClick="return confirm('Are you want to sure delete ?')" CommandArgument='<%#Eval("sm_id")%>' CommandName="lnk_delete" CssClass="btn btn-outline-danger"><i class="feather icon-trash-2 mr-2"></i>Delete</asp:LinkButton>
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


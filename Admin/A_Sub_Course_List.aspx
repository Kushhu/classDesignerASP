<%@ Page Title="Sub Course List" Language="C#" MasterPageFile="~/Admin/Admin_Master.master" AutoEventWireup="true" CodeFile="A_Sub_Course_List.aspx.cs" Inherits="Admin_A_Sub_Course_List" %>

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
                            <h5 class="m-b-10">Sub Course Details</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="javascript:void(0)"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="javascript void(0)">Sub Course List</a></li>
                            <li class="breadcrumb-item float-right"><a href="A_Sub_Course_Form.aspx"><i class="feather icon-plus-circle mr-2"></i>Add New Sub Course </a></li>
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
                        <h5>Sub Course List</h5>
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
                                        <th>Course</th>
                                        <th>Sub Course</th>
                                        <th>Status</th>
                                        <th>Action</th>

                                    </tr>
                                </thead>
                                <tbody>

                                    <asp:Repeater ID="rpt_sub_course_list" runat="server" OnItemCommand="rpt_sub_course_list_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#(Container.ItemIndex+1)%></td>

                                                <td>
                                                    <p class="text-capitalize">
                                                        <%#Eval("cm_name") %>
                                                    </p>
                                                </td>
                                                <td>
                                                    <p class="text-capitalize">
                                                        <%#Eval("scm_name") %>
                                                    </p>
                                                </td>

                                                <td>
                                                    <%#Eval("scm_status").ToString()== "1" ?"Active":"Deactive" %>
                                                </td>
                                                <td>
                                                    <a href='A_Sub_Course_Form.aspx?scmid=<%#Eval("scm_id") %>' class="btn btn-outline-info mr-3"><i class="feather icon-edit mr-2"></i>Edit</a>
                                                    <asp:LinkButton ID="lnk_delete" runat="server" OnClientClick="return confirm('Are you want to sure delete this sub course ?')" CommandArgument='<%#Eval("scm_id")%>' CommandName="lnk_delete" CssClass="btn btn-outline-danger"><i class="feather icon-trash-2 mr-2"></i>Delete</asp:LinkButton>
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


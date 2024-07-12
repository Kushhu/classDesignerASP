<%@ Page Title="Student Paid List" Language="C#" MasterPageFile="~/Admin/Admin_Master.master" AutoEventWireup="true" CodeFile="A_Student_Fees_Paid_List.aspx.cs" Inherits="Admin_A_Student_Fees_Paid_List" %>

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
                            <h5 class="m-b-10">Student Fees Paid List</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="javascript:void(0)"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="javascript void(0)">Fees Paid List </a></li>
                            <li class="breadcrumb-item float-right"><a href="A_Student_Fess_List.aspx"><i class="feather icon-skip-back mr-2"></i>Back to Student wise Fees List</a></li>
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
                        <h5>Paid Fees List</h5>
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
                                        <th>Total Fees</th>
                                        <th>Paid Fees</th>
                                        <th>Reaming Fees</th>
                                        <th>Date</th>
                                        <%--<th>View Receipt </th>--%>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rpt_paid_fees_list" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#(Container.ItemIndex+1)%></td>
                                                <td><b>Name : - </b><%#Eval("sm_name") %>
                                                    <br />
                                                    <b>Course Name :- </b><%#Eval("cm_name") %>
                                                    <br />
                                                    <b>Sub Course Name :- </b><%#Eval("scm_name") %>
                                                    <br />
                                                    <b>Contact No. :- </b><a href='tel:<%#Eval("sm_ctn") %>'><i class="feather icon-phone-call mr-2"></i><%#Eval("sm_ctn") %></a>
                                                </td>

                                                <td>

                                                    <strong class="text-info"><i class="fas fa-rupee-sign mr-2"></i><%#Eval("fpm_total_fees") %></strong></td>
                                                </td>
                                                <td>
                                                    <strong class="text-success"><i class="fas fa-rupee-sign mr-2"></i><%#Eval("fpm_paid_fees") %></strong>
                                                </td>
                                                <td>
                                                    <strong class="text-danger"><i class="fas fa-rupee-sign mr-2"></i><%#Eval("fpm_remaing_fees") %></strong>
                                                </td>
                                                <td>
                                                    <strong class="text-info"><i class="feather icon-calendar mr-2"></i><%#Eval("fpm_insdt")%><i class="feather icon-clock ml-2"></i></strong>
                                                </td>
                                              <%--  <td>
                                                    <a target="_blank" href='A_Fee_Receipt.aspx?recepitid=<%#Eval("fpm_id") %>&smid=<%#Eval("sm_id")%>' class="btn btn-info"><i class="fa fa-print mr-2"></i>View Receipt</a>
                                                </td>--%>
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


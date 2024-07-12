<%@ Page Title="Attendance List" Language="C#" MasterPageFile="~/Teacher/Teacher_Master.master" AutoEventWireup="true" CodeFile="Teacher_Attendance_List.aspx.cs" Inherits="Teacher_Teacher_Attendance_List" %>

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
                            <h5 class="m-b-10">Attendance Details</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="javascript:void(0)"><i class="feather icon-home"></i></a></li>
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
                        <h5>Attendance List</h5>
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
                                        <th>Subject Details</th>
                                        <th>Date / Time</th>
                                        <th>Action</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rpt_attendance_list" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#(Container.ItemIndex+1)%></td>
                                                <td>

                                                    <b class="mr-2">Sub Course :-</b>  <%#Eval("scm_name") %>
                                                    <br />
                                                    <b class="mr-2">Subject :-</b>
                                                    <%#Eval("subm_name") %>
                                                    
                                                </td>
                                                <td>
                                                    <b class="mr-2">Date :-</b>  <%#Eval("atm_insdt")%>
                                                    <br />
                                                    <b class="mr-2">Day :- </b><%#Eval("abm_day")%>
                                                </td>
                                                <td>
                                                    <a href='View_Taken_Attendance_Details.aspx?aematmid=<%#Eval("aem_atm_id") %>' target="_blank" class="btn btn-outline-info mr-3"><i class="feather icon-eye mr-2"></i>View &nbsp;/&nbsp;<i class="feather icon-printer mr-2"></i>Print</a>
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


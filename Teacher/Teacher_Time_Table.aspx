<%@ Page Title="Time Table" Language="C#" MasterPageFile="~/Teacher/Teacher_Master.master" AutoEventWireup="true" CodeFile="Teacher_Time_Table.aspx.cs" Inherits="Teacher_Teacher_Time_Table" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content_header" runat="Server">
    <style type="text/css">
        table tbody tr td {
            height: 40px !important;
            width: 100px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_page" runat="Server">
    <!-- [ Main Content ] start -->
    <div class="pcoded-content">
        <!-- [ breadcrumb ] start -->
        <div class="page-header">
            <div class="page-block">
                <div class="row align-items-center">
                    <div class="col-md-12">
                        <div class="page-header-title">
                            <h4 class="text-white m-b-10"><i class="fas fa-book-reader mr-2"></i>Time Table <i class="fas fa-pencil-ruler ml-2"></i> </h4>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <!-- [ breadcrumb ] end -->
        <!-- [ Main Content ] start -->
        <div class="row">
            <!-- liveline-section start -->
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-header">
                        <h5>Time Table</h5>
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
                            <table class="table table-striped table-bordered nowrap">
                                <thead>
                                    <tr class="text-center">
                                        <th>Time / Days</th>
                                        <asp:Repeater runat="server" ID="rpt_day">
                                            <ItemTemplate>
                                                <td><strong><%#Eval("dm_day") %> </strong></td>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tr>

                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rpt_time" OnItemDataBound="rpt_time_ItemDataBound" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <strong><%#Eval("tim_start_time") %> <i class="text-info">To</i> <%#Eval("tim_end_time") %></strong>
                                                    <asp:HiddenField ID="hf_tim_id" runat="server" Value='<%#Eval("tim_id") %>' />
                                                </td>
                                                <asp:Repeater runat="server" ID="rpt_time_table" OnItemDataBound="rpt_time_table_ItemDataBound">
                                                    <ItemTemplate>
                                                        <td class="text-center">
                                                            <strong class="text-info font-weight-bold"><%#Eval("subm_name")%></strong>
                                                            <p class="text-capitalize">
                                                                <%#Eval("cm_name") %>  <%#Eval("scm_name") %>
                                                            </p>
                                                            <asp:HiddenField runat="server" ID="hf_abm_day" Value='<%#Eval("abm_day") %>' />
                                                            <asp:HiddenField ID="hf_abm_id" runat="server" Value='<%#Eval("abm_id")%>' />
                                                            <asp:HyperLink runat="server" ID="hl_take_attendance" Visible="false" CssClass="btn btn-outline-primary font-weight-bold" NavigateUrl='<%# "~/Teacher/Teacher_Take_Attendance.aspx?atmabmid="+Eval("abm_id").ToString()+"&amscmid="+Eval("scm_id").ToString()%>'><i class="feather icon-user-check mr-2"></i>Take Attendance<i class="feather icon-user-x m-2"></i></asp:HyperLink>
                                                        </td>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_javascript" runat="Server">
</asp:Content>


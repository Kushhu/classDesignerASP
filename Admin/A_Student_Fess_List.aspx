<%@ Page Title="Student Fee List" Language="C#" MasterPageFile="~/Admin/Admin_Master.master" AutoEventWireup="true" CodeFile="A_Student_Fess_List.aspx.cs" Inherits="Admin_A_Student_Fess_List" %>

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
                            <li class="breadcrumb-item float-right"><a href="A_Student_Fees_Paid_List.aspx"><i class="feather icon-skip-forward mr-2"></i>Go to Paid List</a></li>
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
                                        <th>Total Fees</th>
                                        <th>Paid Fees</th>
                                        <th>Reaming Fees</th>
                                        <th>Pay</th>
                                    </tr>
                                </thead>
                                <tbody>

                                    <asp:Repeater ID="rpt_student_fees_list" runat="server" OnItemCommand="rpt_student_fees_list_ItemCommand" OnPreRender="rpt_student_fees_list_PreRender">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#(Container.ItemIndex+1)%></td>

                                                <td><b class="mr-2">Name : - </b><%#Eval("sm_name") %>
                                                    <br />
                                                    <b class="mr-2">Course Name :-</b><%#Eval("cm_name") %>
                                                    <br />
                                                    <b class="mr-2">Sub Course Name :-</b><%#Eval("scm_name") %>
                                                    <br />
                                                    <b class="mr-2">Contact No. :- </b><a href='tel:<%#Eval("sm_ctn") %>'><i class="feather icon-phone-call mr-2"></i><%#Eval("sm_ctn") %></a>
                                                </td>
                                                <td><strong class="text-info"><i class="fas fa-rupee-sign mr-2"></i><%#Eval("sm_fees") %></strong></td>
                                                <td><strong class="text-success"><i class="fas fa-rupee-sign mr-2"></i><%#Eval("Paid_Fees")%></strong></td>
                                                <td>
                                                    <strong class="text-danger"><i class="fas fa-rupee-sign mr-2"></i><%#Eval("Next_Reaming_Fees") %></strong></td>
                                                <td>
                                                    <asp:HiddenField runat="server" ID="hf_next_reaming_fess" Value='<%#Eval("Next_Reaming_Fees") %>' />
                                                    <asp:Label runat="server" ID="lbl_paid_fees" Text="Paid" ForeColor="Green" Font-Bold="true" Visible="false" Font-Size="Large"></asp:Label>
                                                    <asp:LinkButton runat="server" ID="lnk_pay_fees" CommandName="lnk_pay_fees" CommandArgument='<%#Eval("sm_id") %>' CssClass="btn btn-primary"><i class="fa fa-rupee-sign mr-2"></i>Pay Fee</asp:LinkButton>
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


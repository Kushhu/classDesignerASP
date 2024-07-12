<%@ Page Title="Material List" Language="C#" MasterPageFile="~/Admin/Admin_Master.master" AutoEventWireup="true" CodeFile="A_Material_List.aspx.cs" Inherits="Admin_A_Material_List" %>

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
                            <h5 class="m-b-10">Material Details</h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="javascript:void(0)"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="javascript void(0)">Material List</a></li>
                            <li class="breadcrumb-item float-right"><a href="A_Materials_Form.aspx"><i class="feather icon-plus-circle mr-2"></i>Add New Material</a></li>
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
                        <h5>Material List</h5>
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
                                        <th>Material Title</th>
                                        <th>Sub Course Name</th>
                                        <th>Subject Name</th>
                                        <th>Material</th>
                                        <th>Material Status</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rpt_materail_list" runat="server" OnPreRender="rpt_materail_list_PreRender" OnItemCommand="rpt_materail_list_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#(Container.ItemIndex+1)%></td>
                                                <td>
                                                    <p class="text-capitalize">
                                                        <%#Eval("mm_title") %>
                                                    </p>
                                                </td>
                                                <td>
                                                    <%#Eval("scm_name") %>
                                                </td>
                                                <td>
                                                    <%#Eval("subm_name") %>
                                                </td>
                                                <td>
                                                    <asp:HiddenField runat="server" ID="hf_url_link" Value='<%#Eval("mm_link_url") %>' />
                                                    <asp:HiddenField runat="server" ID="hf_file_path" Value='<%#Eval("mm_img_path") %>' />
                                                    <asp:HyperLink Target="_blank" runat="server" ID="hl_materail_file" NavigateUrl='<%#Eval("mm_img_path") %>' CssClass="btn btn-info mb-2"><i class="fas fa-file-pdf mr-2"></i>View Material File</asp:HyperLink>
                                                    <br />
                                                    <asp:HyperLink runat="server" ID="hl_url_link" Target="_blank" NavigateUrl='<%# "https://www.youtube.com/watch?v="+Eval("mm_link_url")%>' CssClass="btn btn-danger"><i class="fab fa-youtube mr-2"></i>View on YouTube</asp:HyperLink>
                                                </td>
                                                <td>
                                                    <%#Eval("mm_status").ToString()== "1" ?"Active":"Deactive" %>
                                                </td>
                                                <td>
                                                    <a href='A_Materials_Form.aspx?mmid=<%#Eval("mm_id") %>' class="btn btn-outline-info mr-3"><i class="feather icon-edit mr-2"></i>Edit</a>
                                                    <asp:LinkButton ID="lnk_delete" runat="server" OnClientClick="return confirm('Are you want to sure delete ?')" CommandArgument='<%#Eval("mm_id")%>' CommandName="lnk_delete" CssClass="btn btn-outline-danger"><i class="feather icon-trash-2 mr-2"></i>Delete</asp:LinkButton>
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


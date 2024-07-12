<%@ Page Title="Assign Batch" Language="C#" ValidateRequest="false" EnableEventValidation="false" MasterPageFile="~/Admin/Admin_Master.master" AutoEventWireup="true" CodeFile="A_Assign_Batch_Form.aspx.cs" Inherits="Admin_A_Assign_Batch_Form" %>

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
                            <h5 class="m-b-10">Assign Batch </h5>
                        </div>
                        <ul class="breadcrumb">
                            <li class="breadcrumb-item"><a href="javascript:void(0)"><i class="feather icon-home"></i></a></li>
                            <li class="breadcrumb-item"><a href="#">Add Batch</a></li>
                            <li class="breadcrumb-item float-right"><a href="A_Assign_Batch_List.aspx"><i class="feather icon-skip-back mr-2"></i>Go to Assign Batch List</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ breadcrumb ] end -->
        <!-- [ Main Content ] start -->
        <div class="row">
            <!-- prject ,team member start -->
            <div class="col-xl-12 col-md-12">
                <div class="card">
                    <div class="card-header">
                        <h5>Assign Batch Management</h5>
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
                        <div class="form-group">
                            <asp:DropDownList runat="server" ID="dr_teacher_name" CssClass="js-example-data-array form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator SetFocusOnError="true"  runat="server" ID="rf_dr_teacher_name" Display="Dynamic" ControlToValidate="dr_teacher_name" InitialValue="0" CssClass="mt-2" ErrorMessage="! Please Select Teacher Name" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <asp:DropDownList runat="server" AutoPostBack="true" OnSelectedIndexChanged="dr_course_name_SelectedIndexChanged" ID="dr_course_name" CssClass="js-example-data-array form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator SetFocusOnError="true"  runat="server" InitialValue="0" ID="rf_dr_course_name" Display="Dynamic" ControlToValidate="dr_course_name" CssClass="mt-2" ErrorMessage="! Please Select Course Name" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList runat="server" AutoPostBack="true" OnSelectedIndexChanged="dr_sub_course_name_SelectedIndexChanged" ID="dr_sub_course_name" CssClass="js-example-data-array form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator SetFocusOnError="true"  runat="server" ID="rf_dr_sub_course_name" InitialValue="0" Display="Dynamic" ControlToValidate="dr_sub_course_name" CssClass="mt-2" ErrorMessage="! Please Select Sub Course Name" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList runat="server" ID="dr_subject_name" CssClass="js-example-data-array form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator SetFocusOnError="true"  runat="server" ID="rf_dr_subject_name" Display="Dynamic" ControlToValidate="dr_subject_name" InitialValue="0" CssClass="mt-2" ErrorMessage="! Please Select Subject Name" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList runat="server" ID="dr_day_list" CssClass="js-example-data-array form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator SetFocusOnError="true"  runat="server" ID="rf_dr_day_list" Display="Dynamic" ControlToValidate="dr_day_list" InitialValue="0" CssClass="mt-2" ErrorMessage="! Please Select Day" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>


                        <div class="form-group">
                            <asp:DropDownList runat="server" ID="dr_time_list" CssClass="js-example-data-array form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator SetFocusOnError="true"  runat="server" ID="rf_dr_time_list" Display="Dynamic" ControlToValidate="dr_time_list" InitialValue="0" CssClass="mt-2" ErrorMessage="! Please Select Time" ValidationGroup="save" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <b class="d-block">
                                <label>Status</label></b>
                            <asp:RadioButton Checked="true" CssClass="form-check-label" runat="server" ID="rdo_active" GroupName="status" Text="Active" />
                            <asp:RadioButton CssClass="form-check-label" runat="server" ID="rdo_deactive" Text="Deactive" GroupName="status" />
                        </div>
                    </div>
                    <div class="card-footer">
                        <div class="form-group">
                            <asp:LinkButton runat="server" ID="lnk_save" ValidationGroup="save" OnClick="lnk_save_Click" CssClass="btn btn-outline-success"><i class="feather icon-save mr-2"></i>Save</asp:LinkButton>
                            <asp:LinkButton runat="server" OnClick="lnk_clear_Click" ID="lnk_clear" CssClass="btn btn-outline-danger" CausesValidation="false"><i class="feather icon-x mr-2"></i>Clear</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_javascript" runat="Server">
</asp:Content>


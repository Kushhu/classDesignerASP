<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View_Taken_Attendance_Details.aspx.cs" Inherits="Teacher_View_Taken_Attendance_Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Attendance Details</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="description" content="" />
    <meta name="keywords" content="">
    <meta name="author" content="Phoenixcoded" />
    <!-- Favicon icon -->
    <link rel="icon" href="../Assets/images/admin_logo.png" type="image/x-icon">

    <!-- prism css -->
    <link rel="stylesheet" href="../Admin/Assets/css/plugins/prism-coy.css">
    <!-- data tables css -->
    <link rel="stylesheet" href="../Admin/Assets/css/plugins/dataTables.bootstrap4.min.css">
    <!-- vendor css -->
    <link href="../Admin/Assets/css/style.css" rel="stylesheet" />

    <style type="text/css">
        .img-logo {
            height: 200px;
            width: 250px;
        }

        @media print {
            .img-logo {
                height: 100px;
                width: 150px;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-2">

            <div class="card">
                <div class="card-header shadow text-center py-3">
                    <div class="row">
                        <div class="col-3">
                            <img src="../Client/Client_Assets/img/logo.png" style="height: 120px; width: 120px" class="img-fluid" />
                        </div>
                        <div class="col-9">
                            <div class="row text-left">
                                <div class="col-6">
                                    <div class="form-group">
                                        <b>
                                            <label class="d-inline-block">
                                                Course Name : 
                                            </label>
                                        </b>
                                        <asp:Label ID="lbl_course_name" CssClass="text-capitalize" runat="server"></asp:Label>
                                    </div>
                                    <div class="form-group">
                                        <b>
                                            <label class="d-inline-block">
                                                SubCurse Name : 
                                            </label>
                                        </b>
                                        <asp:Label ID="lbl_sub_course_name" CssClass="text-capitalize" runat="server" />
                                    </div>
                                    <div class="form-group">
                                        <b>
                                            <label class="d-inline-block">
                                                Subject Name :
                                            </label>
                                        </b>
                                        <asp:Label ID="lbl_subject_name" CssClass="text-capitalize" runat="server" />
                                    </div>
                                    <div class="form-group">
                                        <b>
                                            <label class="d-inline-block">
                                                Teacher Name :
                                            </label>
                                        </b>
                                        <asp:Label ID="lbl_teacher_name" runat="server" />
                                    </div>
                                </div>

                                <div class="col-6">
                                    <div class="form-group">
                                        <b>
                                            <label class="d-inline-block">
                                                Batch No : 
                                            </label>
                                        </b>
                                        <asp:Label ID="lbl_atm_abm_id" runat="server" />
                                    </div>
                                    <div class="form-group">
                                        <b>
                                            <label class="d-inline-block">
                                                Day : 
                                            </label>
                                        </b>
                                        <asp:Label ID="lbl_atm_day" runat="server" />
                                    </div>
                                    <div class="form-group">
                                        <b>
                                            <label class="d-inline-block">
                                                Date : 
                                            </label>
                                        </b>
                                        <asp:Label ID="lbl_atm_date" runat="server" />
                                    </div>

                                    <b>
                                        <label class="print">
                                            Printed Date : 
                                        </label>
                                    </b>
                                    <asp:Label ID="lbl_print_date" runat="server" CssClass="print" />
                                </div>
                            </div>
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
                                    <th>Status</th>

                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rpt_attdance_list">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%#Container.ItemIndex+1%></td>
                                            <td>
                                                <b>Name :-</b> <%#Eval("sm_name")%>
                                                <br />
                                                <b>Contact No :- </b><a href='tel:<%#Eval("sm_ctn") %>'><i class="feather icon-phone-call mr-2"></i><%#Eval("sm_ctn") %></a>
                                            </td>
                                            <td>
                                                <%#Eval("aem_sm_status").ToString()=="1"?"P":"A"%>
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
    </form>


    <!-- Required Js -->
    <script src="../Admin/Assets/js/vendor-all.min.js"></script>
    <script src="../Admin/Assets/js/plugins/bootstrap.min.js"></script>
    <script src="../Admin/Assets/js/ripple.js"></script>
    <script src="../Admin/Assets/js/pcoded.min.js"></script>
    <!-- prism Js -->
    <script src="../Admin/Assets/js/plugins/prism.js"></script>
    <!-- datatable Js -->
    <script src="../Admin/Assets/js/plugins/jquery.dataTables.min.js"></script>
    <script src="../Admin/Assets/js/plugins/dataTables.bootstrap4.min.js"></script>
    <script src="../Admin/Assets/js/pages/data-advance-custom.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //debugger;
            window.print();
        });
    </script>
</body>
</html>

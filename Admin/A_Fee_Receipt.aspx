<%@ Page Language="C#" AutoEventWireup="true" CodeFile="A_Fee_Receipt.aspx.cs" Inherits="Admin_A_Fee_Recepit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fees Receipt</title>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="description" content="" />
    <meta name="keywords" content="">
    <meta name="author" content="Phoenixcoded" />
    <!-- Favicon icon -->
     <link rel="icon" href="Assets/images/admin_logo.png" type="image/x-icon">
    <!-- vendor css -->
    <link rel="stylesheet" href="Assets/css/style.css">
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
        <!-- [ Main Content ] start -->
        <div class="container px-5">
            <div class="row">
                <!-- [ Invoice ] start -->
                <div class="card mt-4 w-100">
                    <div class="invoice-contact">
                        <div class="row w-100">
                            <div class="col-8">
                                <a href="javacript:void(0)" class="b-brand">
                                    <div class="p-3">
                                        <img class="img-logo" src="../Client/Client_Assets/img/logo.png" alt="Logo">
                                    </div>
                                </a>
                            </div>
                            <div class="col-4 mt-5 text-right">
                                <h5>Class Designer </h5>
                                2-Block V-Ken Classes Near Purnima Dairy, Mahavirnagar, Himmatangar.
                              <a class="text-secondary" href="mailto:vken@support.gmail.com" target="_top">vken@support.gmail.com</a>
                                <br />
                                <a href="tel:+919870044789">+91 9870044789</a>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row invoive-info">
                            <div class="col-4 invoice-client-info">
                                <h6>Student Information :</h6>
                                <strong class="m-0">
                                    <asp:Label runat="server" ID="lbl_student_name"></asp:Label></strong>
                                <p class="m-0 m-t-10">
                                    <asp:Label runat="server" ID="lbl_student_address"></asp:Label>
                                </p>
                                <p class="mb-0">
                                    <a class="text-secondary">
                                        <asp:Label runat="server" ID="lbl_student_ctn"></asp:Label></a>
                                </p>
                                <p>
                                    <a class="text-secondary">
                                        <asp:Label runat="server" ID="lbl_student_email"></asp:Label></a>
                                </p>
                            </div>
                            <div class="col-4">
                                <h6>Fee Receipt Information :</h6>
                                <table class="table table-responsive invoice-table invoice-order table-borderless">
                                    <tbody>
                                        <tr>
                                            <th>Date :</th>
                                            <td>
                                                <asp:Label runat="server" ID="lbl_short_date"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th>Status :</th>
                                            <td>
                                                <strong class="label text-success">Confirm</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Receipt ID :</th>
                                            <td>#<asp:Label runat="server" ID="lbl_receipt_id"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="col-4">
                                <h6 class="m-b-20">Invoice Number <span>#<asp:Label runat="server" ID="lbl_innvoice_no"></asp:Label></span></h6>
                                <h6 class="text-uppercase text-primary">Total Fees :
                                        <span><i class="fa fa-rupee-sign"></i>
                                            <asp:Label runat="server" ID="lbl_total_rupees"></asp:Label></span>
                                </h6>
                                <h6 class="text-success">Before Paid :
                                        <span><i class="fa fa-rupee-sign"></i>
                                            <asp:Label runat="server" ID="lbl_total_paid"></asp:Label></span>
                                </h6>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="table-responsive">
                                    <table class="table invoice-detail-table ">
                                        <thead>
                                            <tr class="thead-default">
                                                <th>Description</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <p class="m-0 text-capitalize" id="p_details" runat="server"></p>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <table class="table table-responsive invoice-table invoice-total pt-1">
                                    <tbody>
                                        <tr class="text-info">
                                            <td>
                                                <hr />
                                                <h5 class="text-danger m-r-10">Remaining Fees :</h5>
                                            </td>
                                            <td>
                                                <hr />
                                                <h5 class="text-primary">
                                                    <asp:Label runat="server" ID="lbl_remining_fees"></asp:Label></h5>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <hr />
                                                <h5 class="text-success m-r-10">Now Paid :</h5>
                                            </td>
                                            <td>
                                                <hr />
                                                <h5 class="text-success">
                                                    <asp:Label runat="server" ID="lbl_paid_fees"></asp:Label></h5>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- [ Main Content ] end -->

        <!--Extra -->
        <script src="Assets/js/vendor-all.min.js"></script>
        <script src="Assets/js/plugins/bootstrap.min.js"></script>
        <script src="Assets/js/ripple.js"></script>
        <script src="Assets/js/pcoded.min.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                //debugger;
                window.print();
            });
        </script>
    </form>
</body>
</html>

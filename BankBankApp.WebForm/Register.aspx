<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Register.aspx.vb" Inherits="BankBankApp.WebForm.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register | BankBank</title>
    <link href="/Startbootstrap/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet" />
    <link href="/Startbootstrap/css/sb-admin-2.min.css" rel="stylesheet" />
</head>
<body class="bg-gradient-dark">
    <form id="form1" runat="server">
        <div class="container">

            <div class="card o-hidden border-0 shadow-lg my-5">
                <div class="card-body p-0">
                    <!-- Nested Row within Card Body -->
                    <div class="row">
                        <div class="col-lg-5 d-none d-lg-block">
                            <img src="https://images.unsplash.com/photo-1593672715438-d88a70629abe?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" width="460" height="800" alt="Alternate Text" />
                        </div>
                        <div class="col-lg-7">
                            <div class="p-5">
                                <div class="text-center">
                                    <h1 class="h4 text-gray-900 mb-4">Create BankBank Account!</h1>
                                    <asp:Literal ID="ltMessage" runat="server" />
                                </div>

                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First Name" />
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Last Name" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username" />
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="Phone Number" TextMode="Phone" />
                                </div>
                                <div class="form-group">
                                    <label for="txtDateOfBirth">Date of Birth :</label>
                                    <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control" placeholder="Date of Birth" TextMode="Date" />
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" TextMode="Email" />
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" />
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtRepassword" runat="server" CssClass="form-control" placeholder="Repeat Password" TextMode="Password" />
                                    </div>
                                </div>
                                <asp:Button ID="btnRegistration" Text="Register" CssClass="btn btn-primary btn-user btn-block" runat="server" OnClick="btnRegistration_Click" />
                                <hr>
                                <a href="index.html" class="btn btn-google btn-user btn-block">
                                    <i class="fab fa-google fa-fw"></i>Register with Google
                                </a>
                                <a href="index.html" class="btn btn-facebook btn-user btn-block">
                                    <i class="fab fa-facebook-f fa-fw"></i>Register with Facebook
                                </a>

                                <hr>
                                <div class="text-center">
                                    <a class="small" href="forgot-password.html">Forgot Password?</a>
                                </div>
                                <div class="text-center">
                                    <a class="small" href="Login.aspx">Already have an account? Login!</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <!-- Bootstrap core JavaScript-->
        <script src="/Startbootstrap/vendor/jquery/jquery.min.js"></script>
        <script src="/Startbootstrap/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <!-- Core plugin JavaScript-->
        <script src="/Startbootstrap/vendor/jquery-easing/jquery.easing.min.js"></script>

        <!-- Custom scripts for all pages-->
        <script src="/Startbootstrap/js/sb-admin-2.min.js"></script>
    </form>
</body>
</html>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="BankBankApp.WebForm.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login | BankBank</title>
    <link href="/Startbootstrap/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet" />
    <link href="/Startbootstrap/css/sb-admin-2.min.css" rel="stylesheet" />
</head>
<body class="bg-gradient-primary">
    <form id="form1" runat="server">
        <div>
            <div class="container">

                <!-- Outer Row -->
                <div class="row justify-content-center">

                    <div class="col-xl-10 col-lg-12 col-md-9">

                        <div class="card o-hidden border-0 shadow-lg my-5">
                            <div class="card-body p-0">
                                <!-- Nested Row within Card Body -->
                                <div class="row">
                                    <div class="col-lg-6 d-none d-lg-block">
                                        <img src="https://images.unsplash.com/photo-1612812166620-a072f77ec45b?q=80&w=2010&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" width="460" alt="El Gato" />
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="p-5">
                                            <div class="text-center">
                                                <h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
                                            </div>

                                            <div class="form-group">
                                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username" />
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" />
                                            </div>
                                            <div class="form-group">
                                                <div class="custom-control custom-checkbox small">
                                                    <input type="checkbox" class="custom-control-input" id="customCheck">
                                                    <label class="custom-control-label" for="customCheck">
                                                        Remember
                                                    Me</label>
                                                </div>
                                            </div>
                                            <asp:Button ID="btnLogin" Text="Login" CssClass="btn btn-primary btn-user btn-block" runat="server" OnClick="btnLogin_Click" />
                                            <br />
                                            <asp:Literal ID="ltMessage" runat="server" />
                                            <hr>
                                            <a href="index.html" class="btn btn-google btn-user btn-block">
                                                <i class="fab fa-google fa-fw"></i>Login with Google
                                            </a>
                                            <a href="index.html" class="btn btn-facebook btn-user btn-block">
                                                <i class="fab fa-facebook-f fa-fw"></i>Login with Facebook
                                            </a>

                                            <hr>
                                            <div class="text-center">
                                                <a class="small" href="forgot-password.html">Forgot Password?</a>
                                            </div>
                                            <div class="text-center">
                                                <a class="small" href="Register.aspx">Create an Account!</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>

            </div>

            <!-- Bootstrap core JavaScript-->
            <script src="/Startbootstap/vendor/jquery/jquery.min.js"></script>
            <script src="/Startbootstap/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

            <!-- Core plugin JavaScript-->
            <script src="/Startbootstap/vendor/jquery-easing/jquery.easing.min.js"></script>

            <!-- Custom scripts for all pages-->
            <script src="/Startbootstap/js/sb-admin-2.min.js"></script>

        </div>
    </form>
</body>
</html>

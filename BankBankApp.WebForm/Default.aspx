<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="BankBankApp.WebForm._Default" Title="BankBank App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link type="image/png" sizes="16x16" rel="icon" href="/icons8-bank-16.png" />
    <link href="/Startbootstrap/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet" />

    <!-- Custom styles for this template-->
    <link href="/Startbootstrap/css/sb-admin-2.min.css" rel="stylesheet" />
</head>
<body class="bg-dark">

    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
        <div class="">
            <div class="o-hidden shadow-lg border-0">
                <div class="row">
                    <div class="col-md-6">
                        <asp:Image ID="HeroImage" Height="720" runat="server" ImageUrl="https://images.unsplash.com/photo-1607944023727-62f96d76b2d9?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" CssClass="jumbotron-fluid" />
                    </div>
                    <div class="col-md-6 p-5 text-light">
                        <h1 class="font-weight-bold">BankBank</h1>
                        <p class="my-3">
                            Introducing BankBank, the mobile banking app that puts you in control of your finances. Forget scrambling to the ATM or waiting in line at the bank. With BankBank, you can manage your money anytime, anywhere, right from your phone.
                        </p>
                        <a href="/Register.aspx" class="btn btn-outline-light me-2">Register</a>
                        <a href="/Login.aspx" class="btn btn-light">Login</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/Scripts/bootstrap.js") %>
        <%: Scripts.Render("~/Startbootstrap/vendor/jquery/jquery.min.js") %>
        <%: Scripts.Render("~/Startbootstrap/vendor/bootstrap/js/bootstrap.bundle.min.js") %>
        <%: Scripts.Render("~/Startbootstrap/vendor/jquery-easing/jquery.easing.min.js") %>
        <%: Scripts.Render("~/Startbootstrap/js/sb-admin-2.min.js") %>
    </asp:PlaceHolder>
</body>
</html>

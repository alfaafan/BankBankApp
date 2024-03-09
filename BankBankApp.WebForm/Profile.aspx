<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.vb" Inherits="BankBankApp.WebForm.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="fw-bold">Profile</h2>
        <div class="row">
            <div class="col-xl-7 col-lg-6">
                <div class="card border-left-success shadow mb-4">
                    <div class="card-body p-4">
                        <%--<div class="text-center">
                        <img class="img-fluid px-3 px-sm-4 mt-3 mb-4" style="width: 25rem;" src="/Startbootstrap/img/undraw_posting_photo.svg" alt="">
                    </div>--%>
                        <div class="row no-gutters align-items-center mb-4">
                            <div class="col">
                                <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                    Full Name
                                </div>
                                <div class="mb-0 font-weight-bold text-gray-800"><%= UCase(Session("firstName") + " " + Session("lastName")) %></div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-user fa-2x text-gray-300"></i>
                            </div>
                        </div>
                        <div class="row no-gutters align-items-center mb-4">
                            <div class="col">
                                <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                    Username
                                </div>
                                <div class="mb-0 font-weight-bold text-gray-800"><%= UCase(Session("Username")) %></div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-address-card fa-2x text-gray-300"></i>
                            </div>
                        </div>
                        <div class="row no-gutters align-items-center mb-4">
                            <div class="col">
                                <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                    Email
                                </div>
                                <div class="mb-0 font-weight-bold text-gray-800"><%= UCase(Session("Email")) %></div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-envelope fa-2x text-gray-300"></i>
                            </div>
                        </div>
                        <div class="row no-gutters align-items-center mb-4">
                            <div class="col">
                                <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                    Phone Number
                                </div>
                                <div class="mb-0 font-weight-bold text-gray-800"><%= UCase(Session("Phone")) %></div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-phone fa-2x text-gray-300"></i>
                            </div>
                        </div>
                        <div class="row no-gutters align-items-center mb-4">
                            <div class="col">
                                <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                    Date of Birth
                                </div>
                                <div class="mb-0 font-weight-bold text-gray-800"><%= UCase(Session("DateOfBirth")) %></div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-calendar fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-5 col-lg-6 ">
                <div class="mb-4">
                    <div class="card border-left-primary shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                        Account Info
                                    </div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800">IDR <%= Session("lastName")%></div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-wallet fa-2x text-blue-300"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="mb-4">
                    <div class="card border-left-danger shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                        Card Info
                                    </div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800"><%= Session("lastName")%></div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-credit-card fa-2x text-blue-300"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

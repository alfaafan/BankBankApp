<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="BankBankApp.WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h1 class="h3 ms-3 mb-4 text-gray-800 fw-bold">Dashboard</h1>
        <h5 class="ms-3 mb-4">Hello, <% If Session("firstName") IsNot Nothing Then %>
            <%= Session("firstName") %>
            <% Else %>
        Guest
    <% End If %>
        </h5>
        <div class="row">
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-primary shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                    Balance
                                </div>
                                <div class="h5 mb-0 font-weight-bold text-gray-800">IDR <%= Session("lastName")%></div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-coins fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-danger shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                    Account Number
                                </div>
                                <div class="h5 mb-0 font-weight-bold text-gray-800"><%= Session("lastName")%></div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-credit-card fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-info shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                                <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                    Card
                                </div>
                                <div class="h5 mb-0 font-weight-bold text-gray-800"><%= Session("lastName")%></div>
                            </div>
                            <div class="col-auto">
                                <i class="fas fa-credit-card fa-2x text-gray-300"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card shadow-lg">
            <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                <h5 class="m-0 font-weight-bold text-primary">Activity</h5>
            </div>
            <div class="card-body">
            </div>
        </div>
        <div class="row d-flex justify-content-center">
            <div class="">
            </div>

            <br />
            <asp:Literal ID="ltGreetings" runat="server" />
        </div>
    </main>

</asp:Content>

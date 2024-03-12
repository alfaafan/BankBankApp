<%@ Page Title="Transaction Category" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="TransactionCategoryPage.aspx.vb" Inherits="BankBankApp.WebForm.TransactionCategoryPage" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Transactions</h1>
        </div>
        <div class="col-lg-12">
            <asp:Literal ID="ltMessage" runat="server"/>
            <div class="card shadow mb-4 mt-3">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Transaction Categories</h6>
                </div>
                <div class="card-body">
                    <asp:ListView ID="lvTransactionCategories" DataKeyNames="TransactionCategoryID" runat="server" OnItemDeleting="lvTransactionCategories_ItemDeleting" OnSelectedIndexChanged="lvTransactionCategories_SelectedIndexChanged"
                        OnSelectedIndexChanging="lvTransactionCategories_SelectedIndexChanging">
                        <ItemTemplate>
                            <div class="container py-3">
                                <div class="row">
                                    <div class="col-lg-3 px-3 py-2">
                                        <%--<asp:Label ID="lblTransactionCategoryName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>--%>
                                        <asp:Label ID="lblTransactionCategoryName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                    </div>
                                    <div class="col-lg-3 px-3 py-2">
                                        <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" Text="Select" CssClass="btn btn-warning btn-sm"></asp:LinkButton>
                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-primary btn-sm"></asp:LinkButton>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-danger btn-sm"></asp:LinkButton>
                                    </div>

                                </div>
                            </div>
                            <br />
                        </ItemTemplate>
                    </asp:ListView>
                    <br />
                    <button type="button" class="btn btn-primary btn-sm" data-toggle="modal" data-target="#myModal">
                        Add Category
                    </button>
                </div>

                <!-- The Modal -->
                <div class="modal" id="myModal">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <!-- Modal Header -->
                            <div class="modal-header">
                                <h4 class="modal-title">Add Category</h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>

                            <!-- Modal body -->
                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="txtCategoryName">Category :</label>
                                    <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control" placeholder="Enter Category Name" />
                                </div>
                            </div>

                            <!-- Modal footer -->
                            <div class="modal-footer">
                                <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-primary btn-sm"
                                    OnClick="btnSubmit_Click" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

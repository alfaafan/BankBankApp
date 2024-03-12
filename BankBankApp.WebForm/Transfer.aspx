<%@ Page Title="Transfer" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Transfer.aspx.vb" Inherits="BankBankApp.WebForm.Transfer" EnableViewStateMac="true" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card shadow-lg">
        <div class="card-header">
            <h2 class="font-weight-bold m-0">Transfer</h2>
        </div>
        <div class="card-body p-5">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
            <p>Please fill in transaction details:</p>
            <asp:TextBox ID="txtReceiverAccountNumber" runat="server" CssClass="form-control" placeholder="Receiver Account Number"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" placeholder="Amount"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" placeholder="Description"></asp:TextBox>
            <asp:Button ID="btnTransfer" runat="server" Text="Transfer" CssClass="btn btn-primary btn-block mt-3" OnClick="btnTransfer_Click" />
            <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
        </div>

    </div>
</asp:Content>

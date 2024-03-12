<%@ Page Title="Bill Payment" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BillPayment.aspx.vb" Inherits="BankBankApp.WebForm.BillPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card shadow-lg">
        <div class="card-header">
            <h3 class="font-weight-bold m-0">Bill Payment</h3>
        </div>
        <div class="card-body p-5">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
            <p>Please fill in transaction details:</p>
            <asp:TextBox ID="txtBillNumber" runat="server" CssClass="form-control" placeholder="Bill Number"></asp:TextBox>
            <asp:Label ID="lblBillAmount" runat="server" CssClass=""></asp:Label>
            <asp:Button ID="btnPay" runat="server" CssClass="btn btn-primary mt-3" Text="Pay" OnClick="btnPay_Click" />
        </div>
    </div>
</asp:Content>

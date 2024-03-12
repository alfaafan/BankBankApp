<%@ Page Title="Transfer Confirmation" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="TransferConfirmation.aspx.vb" Inherits="BankBankApp.WebForm.TransferConfirmation" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card shadow-lg">
        <div class="card-header">
            <h3 class="font-weight-bold text-primary m-0">Transfer Confirmation</h3>
        </div>
        <div class="card-body p-5">
            <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
            <div>
                <label>Recipient Account Number:</label>
                <asp:Label ID="lblRecipientAccountNumber" runat="server" CssClass="font-weight-bold"></asp:Label>
            </div>
            <div>
                <label>Amount:</label>
                <asp:Label ID="lblAmount" runat="server" CssClass="font-weight-bold"></asp:Label>
            </div>
            <div>
                <label>Remarks:</label>
                <asp:Label ID="lblRemarks" runat="server" CssClass="font-weight-bold"></asp:Label>
            </div>
            <asp:Button ID="btnConfirm" Text="Confirm" OnClick="btnConfirm_Click" runat="server" CssClass="btn btn-primary btn-block mt-3" />
        </div>
    </div>
</asp:Content>

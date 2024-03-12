<%@ Page Title="Edit Profile" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="EditProfile.aspx.vb" Inherits="BankBankApp.WebForm.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <div class="card-header">
            <h4 class="m-0 text-primary font-weight-bold">Edit Profile</h4>
        </div>
        <div class="card-body p-5">
            <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First Name"></asp:TextBox>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control mt-3" placeholder="Last Name"></asp:TextBox>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control mt-3" placeholder="Username"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mt-3" placeholder="Email"></asp:TextBox>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control mt-3" placeholder="Phone"></asp:TextBox>
            <label for="txtDateOfBirth" class="mt-3">Date of Birth:</label>
            <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control mt-1" placeholder="Address" TextMode="Date"></asp:TextBox>
            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary mt-3" Text="Update" OnClick="btnUpdate_Click" />
        </div>
    </div>

</asp:Content>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SampleViewState.aspx.vb" Inherits="BankBank.WebFormApp.SampleViewState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewState</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblCounter" runat="server" Text="0"></asp:Label>
            <asp:Button ID="btnIncrement" runat="server" Text="Increment" OnClick="btnIncrement_Click"/>
            <asp:Button ID="btnDecrement" runat="server" Text="Decrement" OnClick="btnDecrement_Click" />
        </div>
    </form>
</body>
</html>

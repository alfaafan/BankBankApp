<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SimpleCalc.aspx.vb" Inherits="BankBank.WebFormApp.SimpleCalc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator App</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtNum1" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtNum2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="addButton" runat="server" Text="+" OnClick="Add_Click"/>
            <asp:Button ID="subtractButton" runat="server" Text="-" OnClick="Subtract_Click"/>
            <asp:Button ID="multiplyButton" runat="server" Text="*" OnClick="Multiply_Click"/>
            <asp:Button ID="divideButton" runat="server" Text="/" OnClick="Divide_Click"/>
            <br />
            <br />
            <asp:Label ID="lblResult" runat="server" Text="Result"></asp:Label>
            <button onclick={console.log('...')}>Tes</button>
        </div>
    </form>
</body>
</html>

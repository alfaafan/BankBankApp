<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="BankBank.WebFormApp._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BankBank App</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Hello From the ASP.NET Web View</h1>
            <h1>
                <asp:Image ID="Image1" runat="server" ImageUrl="https://ecs7.tokopedia.net/assets-tokopedia-lite/v2/zeus/production/e5b8438b.svg"/>
            </h1>
            <asp:Label ID="Label1" runat="server" Text="Daftar Tokopedia"></asp:Label>
            <br />
            <asp:TextBox ID="txtHello" runat="server" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Daftar" />
        </div>
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple">
                <asp:ListItem>Item 1</asp:ListItem>
                <asp:ListItem>Item 2</asp:ListItem>
                <asp:ListItem>Item 3</asp:ListItem>
        </asp:ListBox>
    </form>
</body>
</html>

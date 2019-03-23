<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmEmail.aspx.cs" Inherits="SlockItWeb.ConfirmEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h2> Terms of use and privacy policy </h2>
       
        <asp:TextBox ID="txtPoUsoPriv" runat="server" Height="350px" ReadOnly="True" TextMode="MultiLine" Width="95%" Font-Size="Large">Terms of use and privacy policy</asp:TextBox>

    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Yes, I accept the terms. Activate my user." Width="95%" Font-Bold="True" Font-Size="Large" Height="66px" />
    </form>
</body>
</html>
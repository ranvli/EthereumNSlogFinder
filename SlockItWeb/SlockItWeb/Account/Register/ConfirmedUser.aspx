<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmedUser.aspx.cs" Inherits="SlockItWeb.ConfirmedUser" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblStatus" runat="server" Text="Thanks for confirming your user!"></asp:Label>
        <a href="../Login.aspx" >Click here to login</a>
    </div>
    </form>
</body>
</html>


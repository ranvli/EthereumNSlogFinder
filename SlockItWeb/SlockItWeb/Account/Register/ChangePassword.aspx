<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="SlockItWeb.Account.Register.ChangePassword" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <div class="login-container animated fadeInDown">
        <div class="loginbox bg-white">
            <div class="loginbox-title">Change password</div>
            

            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <p class="text-danger">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
            </asp:PlaceHolder>

            <div class="registerbox-textbox">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="Enter Password"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
            <div class="registerbox-textbox">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" placeholder="Confirm Password"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>

            <div class="loginbox-submit">
                <asp:Button runat="server" OnClick="ChangePwd" Text="Change password" CssClass="btn btn-primary btn-block" />
            </div>
            <div class="loginbox-signup">
                <asp:HyperLink runat="server" ID="RegisterHyperLink" NavigateUrl="~/Account/Login.aspx" ViewStateMode="Disabled">Login</asp:HyperLink>
            </div>
        </div>
        <div class="logobox" style="text-align:center;">
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
        </div>
    </div>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="PageScriptContent" runat="server">
</asp:Content>

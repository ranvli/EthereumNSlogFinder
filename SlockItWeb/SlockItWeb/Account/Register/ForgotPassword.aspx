<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="SlockItWeb.Account.Register.ForgotPassword" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="login-container animated fadeInDown">
        <div class="loginbox bg-white">
            <div class="loginbox-title">Forgot password</div>
            
           

            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <p class="text-danger">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
            </asp:PlaceHolder>
            <div class="loginbox-textbox">
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" placeholder="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
            


            <div class="loginbox-submit">
                <asp:Button runat="server" OnClick="ResetPwd" Text="Reset password" CssClass="btn btn-primary btn-block" />

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
<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SlockItWeb.Login" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <div class="login-container animated fadeInDown">
        <div class="loginbox bg-white">
            <div class="loginbox-title">SIGN IN</div>

            <div class="loginbox-or">
                <div class="or-line"></div>
            </div>
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
            <div class="loginbox-textbox">
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
             
            <div class="loginbox-submit">
                <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-primary btn-block" />

            </div>
             
        </div>
        <div class="logobox" style="text-align: center;">
            <asp:Label ID="lblStatus" runat="server"></asp:Label>

        </div>
    </div>
</asp:Content>

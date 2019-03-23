<%@ Page Title="Register" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SlockItWeb.Register" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
     

     <div class="register-container animated fadeInDown" >
        <div class="registerbox bg-white" style="height: 570px !important;">
            <div class="registerbox-title">Register</div>

            <div class="registerbox-caption ">Please fill in your information</div>

            <hr class="wide" />
            <div class="registerbox-textbox">
                <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" placeholder="First Name" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName"
                    CssClass="text-danger" ErrorMessage="The first name field is required." />
            </div>
            <div class="registerbox-textbox">
                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" placeholder="Last Name" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastName"
                    CssClass="text-danger" ErrorMessage="The last name field is required." />
            </div>
            <div class="registerbox-textbox">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" placeholder="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Email" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>

            </div>
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
            <div class="registerbox-textbox">
                <div class="row">
                    
                </div>
            </div>
            <div class="registerbox-textbox no-padding-bottom">
                <div class="checkbox">
                    <label>
                        <input type="checkbox" class="" checked="checked">
                        <span class="text darkgray">I agree to the <a class="themeprimary">Terms of Service</a> </span>
                    </label>
                &nbsp;</div>
            </div>
            <div class="registerbox-submit">
                <asp:Button runat="server"  Text="Register DISABLED" CssClass="btn btn-primary pull-right" />
            </div>
        </div>
        <div class="logobox" style="text-align:center;width:100%;height:100%">
             
        </div>
    </div>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SlockItWeb.Default" EnableEventValidation="false" Async="true" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <style>
        .text-example {
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
            width: 100%;
            text-align: center;
            margin: 10% 0;
            min-height: 100px;
            background-color: azure;
            align-items: center;
        }
    </style>

    <div class="row">
        <div class="col-xs-12 col-md-6">
            <div class="well with-header with-footer" style="width: 1024px; height: 350px; background-color: azure">
                <div class="header">
                    Get latest activity of a given ethereum domain name
                </div>
                <div style="height: 200px;">
                    <label id="lblTxtEDN">Ethereum Domain Name OR hex address</label><br />
                    <asp:TextBox ID="txtEDN" runat="server" Width="500px"></asp:TextBox>
                    <br />

                    <div style="display: flex">
                        <div style="display: inline-block; margin: 15px;">
                            <label for="calFechaDesde">From</label><br />
                            <asp:Calendar ID="calFechaDesde" runat="server"></asp:Calendar>
                        </div>
                        <div style="display: inline-block; margin: 15px;">
                            <label>Until NOW</label><br />
                        </div>
                    </div>

                    <div style="float: right">
                        <asp:Button ID="btnExportarExcel" runat="server" Text="Export to excel" OnClick="btnExportarExcel_Click" />
                        <asp:Button ID="btnFiltrar" runat="server" Text="Filter now" Width="200" OnClick="btnFiltrar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="row">

        <div class="col-xs-12 col-md-6">
            <div class="well with-header with-footer" style="width: 1024px;">
                <div class="header bg-darkorange">
                    <label id="lblResultActivity" runat="server">Result of activity</label>
                </div>


                <asp:GridView
                    ID="gdvActivity" runat="server" CellPadding="3" CellSpacing="1" GridLines="None" Width="100%" DataKeyNames="BlockNumber"
                    AutoGenerateColumns="False" CssClass="table table-striped table-bordered bootstrap-datatable datatable"
                    AllowPaging="True" AllowSorting="True" PageSize="25" OnRowCommand="gdvActivity_RowCommand"  
                    OnPageIndexChanging="gdvActivity_PageIndexChanging" OnSorting="gdvActivity_Sorting">
                    <SelectedRowStyle BackColor="#ffffff" Font-Bold="True" ForeColor="#0484c2" />
                    <RowStyle CssClass="active" />
                    <AlternatingRowStyle CssClass="inactive" />
                    <Columns>

                        <asp:BoundField DataField="TimeStamp" HeaderText="TimeStamp" HeaderStyle-Width="200px" SortExpression="TimeStamp" />
                         
                        <asp:TemplateField HeaderText="# Transactions" HeaderStyle-Width="150px" SortExpression="NumberOfTransactions">
                            <ItemTemplate>
                                <asp:LinkButton Text='<%# Eval("NumberOfTransactions") %>' runat="server" CommandName="ViewTransactions" CommandArgument="<%# Container.DataItemIndex %>" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="BlockNumber" HeaderText="Block Number" HeaderStyle-Width="200px" SortExpression="BlockNumber" />
                        <asp:BoundField DataField="BlockHash" HeaderText="Block Hash" HeaderStyle-Width="200px" SortExpression="BlockHash" />

                    </Columns>
                </asp:GridView>

                <br />
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
            </div>

        </div>

    </div>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="PageScriptContent" runat="server">

    <script>
        $(document).ready(function () {
            $('#<%= txtEDN.ClientID %>').bind("input", callonchange);
        });

        function callonchange() {
            var val = $('#<%= txtEDN.ClientID %>').val();
            
            if (val.startsWith('0x')) {
                document.getElementById('lblTxtEDN').innerHTML = 'Ethereum address';
            }
            else if (val.endsWith('.eth')) {
                document.getElementById('lblTxtEDN').innerHTML = 'Ethereum Domain Name';
            }
            else
            {
                document.getElementById('lblTxtEDN').innerHTML = 'Ethereum Domain Name OR Ethereum Hex Address';
            }
        }
    </script>
</asp:Content>

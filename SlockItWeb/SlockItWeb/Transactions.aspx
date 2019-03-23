<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="SlockItWeb.Transactions" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <div class="row">

        <div class="col-xs-12 col-md-6">
            <div class="well with-header with-footer" style="width: 1024px;">
                <div class="header bg-darkorange">
                    <label id="lblResultActivity" runat="server">Transactions</label>
                </div>


                <asp:GridView
                    ID="gdvTransactions" runat="server" CellPadding="3" CellSpacing="1" GridLines="None" Width="100%" 
                    AutoGenerateColumns="False" CssClass="table table-striped table-bordered bootstrap-datatable datatable"
                    AllowPaging="True" AllowSorting="True" PageSize="25" 
                    OnPageIndexChanging="gdvActivity_PageIndexChanging" OnSorting="gdvActivity_Sorting">
                    <SelectedRowStyle BackColor="#ffffff" Font-Bold="True" ForeColor="#0484c2" />
                    <RowStyle CssClass="active" />
                    <AlternatingRowStyle CssClass="inactive" />
                    <Columns>

                        <asp:BoundField DataField="From" HeaderText="From" HeaderStyle-Width="200px" SortExpression="From" />
                        <asp:BoundField DataField="To" HeaderText="To" HeaderStyle-Width="200px" SortExpression="To" />
                        <asp:BoundField DataField="Value" HeaderText="Value" HeaderStyle-Width="150px" SortExpression="Value" />
                        <asp:BoundField DataField="TransactionHash" HeaderText="Transaction Hash" HeaderStyle-Width="200px" SortExpression="TransactionHash" />
                        <asp:BoundField DataField="TransactionIndex" HeaderText="Transaction index" HeaderStyle-Width="200px" SortExpression="TransactionIndex" />
                        <asp:BoundField DataField="Gas" HeaderText="Gas" HeaderStyle-Width="100px" SortExpression="Gas" />
                        <asp:BoundField DataField="GasPrice" HeaderText="Gas Price" HeaderStyle-Width="100px" SortExpression="GasPrice" />
                        <asp:BoundField DataField="Input" HeaderText="Input" HeaderStyle-Width="100px" SortExpression="Input" />
                          
                    </Columns>
                </asp:GridView>

                <br />
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
            </div>

        </div>

    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageScriptContent" runat="server">
</asp:Content>

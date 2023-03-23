<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="InvoiceList.aspx.cs" Inherits="Invoice_InvoiceList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <h1>Invoice Add</h1>
        <p>
            <asp:Label ID="InvoiceWarnLbl" runat="server" Text=""></asp:Label>
        </p>
        <br />
        <table class="tabletable">
            <tr>
                <td><asp:Label ID="InvoicePartyLbl" runat="server" Text="Party Name" CssClass="form-label"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="InVoicePartyTBox" runat="server" OnSelectedIndexChanged="InVoicePartyTBox_SelectedIndexChanged" AutoPostBack = "true" CssClass="form-control"></asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="ReqInvoiceParty" runat="server" ErrorMessage="Select Party" ControlToValidate="InVoicePartyTBox"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="InvoiceProductLbl" runat="server" Text="Product Name" CssClass="form-label"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="InVoiceProductTBox" runat="server" OnSelectedIndexChanged="InVoiceProductTBox_SelectedIndexChanged" AutoPostBack = "true" CssClass="form-control"></asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="ReqInvoiceProduct" runat="server" ErrorMessage="Select Product" ControlToValidate="InVoiceProductTBox"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="InvoiceRateLbl" runat="server" Text="Current Rate" CssClass="form-label"></asp:Label></td>
                <td>
                    <asp:TextBox ID="InvoiceRateTBox" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="ReqInvoiceRate" runat="server" ErrorMessage="Rate can not be empty" ControlToValidate="InvoiceRateTBox"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="InvoiceQuantityLbl" runat="server" Text="Quantity" CssClass="form-label"></asp:Label></td>
                <td>
                    <asp:TextBox ID="InvoiceQuantityTBox" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="ReqInvoiceQuantity" runat="server" ErrorMessage="Please add Quantity" ControlToValidate="InvoiceQuantityTBox"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="AddInvoicBtn" runat="server" Text="Add Invoice" OnClick="AddInvoicBtn_Click" />
        <asp:Button ID="ClearInvoicBtn" runat="server" Text="Clear" SkinID="cancelBtn" OnClick="ClearInvoicBtn_Click" CausesValidation="false" />
        <br />
        <br />
        <asp:GridView ID="InvoiceListTbl" runat="server" CssClass="table table-striped table-bordered table-hover" HorizontalAlign="Center">
            <EditRowStyle HorizontalAlign="Center" />
            <HeaderStyle HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
        <table>
            <tr>
                <td><asp:Label ID="GrandTotalLbl" runat="server" Text="Grand Total :- " CssClass="text-bold"></asp:Label>&nbsp;<asp:Label ID="GrandTotalTBox" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
    </div>
    </div>
</asp:Content>

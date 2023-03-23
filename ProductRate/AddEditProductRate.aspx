<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddEditProductRate.aspx.cs" Inherits="ProductRate_AddEditProductRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <h1>Add Product Rate</h1>
        <p>
            <asp:Label ID="RateWarnLbl" runat="server" Text=""></asp:Label>
        </p>
    </div>
    <table class="tabletable">
        <tr>
            <td>
                <asp:Label ID="rateProductNameLbl" runat="server" Text="Product Name" CssClass="form-label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="rateProductNameTbox" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </td>
                <asp:RequiredFieldValidator ID="ReqPartyName" runat="server" ErrorMessage="Select Product name" ControlToValidate="rateProductNameTbox"></asp:RequiredFieldValidator>
        </tr>
        <tr>
            <td>
                <asp:Label ID="rateCurrentLbl" runat="server" Text="Current Rate" CssClass="form-label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="rateCurrentTBox" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
                <asp:RequiredFieldValidator ID="ReqCurrentRate" runat="server" ErrorMessage="Rate can not be empty" ControlToValidate="rateCurrentTBox"></asp:RequiredFieldValidator>
        </tr>
        <tr>
            <td>
                <asp:Label ID="rateDateLbl" runat="server" Text="Date of Rate" CssClass="form-label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="rateDateTBox" runat="server" textmode="Date" CssClass="form-control" Enabled="false"></asp:TextBox>
            </td>
                <asp:RequiredFieldValidator ID="ReqRateDate" runat="server" ErrorMessage="Date can not be empty" ControlToValidate="rateDateTBox"></asp:RequiredFieldValidator>
        </tr>
    </table><br />
    <br />
    <asp:Button ID="addRateBtn" runat="server" Text="Add" OnClick="addRateBtn_Click" />
    &nbsp;<asp:Button ID="UpdateRateBtn" runat="server" Text="Update" Visible="false" OnClick="UpdateRateBtn_Click" />
    &nbsp;<asp:Button ID="rateBackBtn" runat="server" Text="Cancel" SkinID="cancelBtn" CausesValidation="false" OnClick="rateBackBtn_Click" />
</asp:Content>


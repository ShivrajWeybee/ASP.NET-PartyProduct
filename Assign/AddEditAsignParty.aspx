<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddEditAsignParty.aspx.cs" Inherits="Assign_AddEditAsignParty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <h1>Assign Party</h1>
        <p>
            <asp:Label ID="AssignPartyWarnLbl" runat="server" Text=""></asp:Label>
        </p>
        <br />
    </div>
    <table class="tabletable">
        <tr>
            <td>
                <asp:Label ID="assignPartyNameLbl" runat="server" Text="Party Name" CssClass="form-label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="assignPartyNameTbox" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </td>
            <asp:RequiredFieldValidator ID="ReqAssignPartyName" runat="server" ErrorMessage="Select Party" ControlToValidate="assignPartyNameTbox"></asp:RequiredFieldValidator>
        </tr>
        <tr>
            <td>
                <asp:Label ID="assignProductNameLbl" runat="server" Text="Product Name" CssClass="form-label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="assignProductNameTbox" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </td>
            <asp:RequiredFieldValidator ID="ReqAssignProductName" runat="server" ErrorMessage="Select Product" ControlToValidate="assignProductNameTbox"></asp:RequiredFieldValidator>
        </tr>
    </table>
    <br />
    <br />
    <asp:Button ID="AddAssignBtn" runat="server" Text="Add" OnClick="AddAssignBtn_Click" />
    &nbsp;<asp:Button ID="UpdateAssignBtn" runat="server" Text="Update" OnClick="UpdateAssignBtn_Click" Visible="false" />
    &nbsp;<asp:Button ID="AddAssignCancleBtn" runat="server" Text="Cancel" SkinID="cancelBtn" OnClick="AddAssignCancleBtn_Click" CausesValidation="false" />
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddEditParty.aspx.cs" Inherits="Party_AddEditParty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <h1>Add Party</h1>
        <p>
            <asp:Label ID="PartyWarnLbl" runat="server" Text=""></asp:Label>
        </p>
    </div>
    <table class="tabletable">
        <tr>
            <td>
                <asp:Label ID="partyNameLbl" runat="server" Text="Party Name" CssClass="form-label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="partyNameTbox" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:RequiredFieldValidator ID="ReqPartyName" runat="server" ErrorMessage="Name can not be empty" ControlToValidate="partyNameTbox"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button ID="AddPartyBtn" runat="server" Text="Add" OnClick="AddPartyBtn_Click" />
    &nbsp;<asp:Button ID="UpdatePartyBtn" runat="server" Text="Update" OnClick="UpdatePartyBtn_Click" Visible="false" />
    &nbsp;<asp:Button ID="PartyBackBtn" runat="server" Text="Cancel" SkinID="cancelBtn" OnClick="PartyBackBtn_Click" CausesValidation="false" />
</asp:Content>


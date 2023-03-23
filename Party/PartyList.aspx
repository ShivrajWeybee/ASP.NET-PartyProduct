<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="PartyList.aspx.cs" Inherits="PartyList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Party List</h1>
        <asp:Button ID="GoToAddPartyBtn" runat="server" Text="Add Party" OnClick="GoToAddPartyBtn_Click" />
        <br />
        <br />
        <asp:GridView ID="PartyListTbl" runat="server" CssClass="table table-striped table-bordered table-hover" HorizontalAlign="Center" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="PartyID" HeaderText="Party ID" />
                <asp:BoundField DataField="PartyName" HeaderText="Party Name" />
                <asp:TemplateField HeaderText="Actions" ShowHeader="False">
                    <ItemTemplate>
                        <div Cssclass="btn-group edit-delete-btn" role="group">
                            <asp:Button ID="EditParty" runat="server" Text="Edit" SkinID="editBtn" CommandName='<%# Eval("PartyName") %>' CommandArgument='<%# Eval("PartyID") %>' OnClick="EditPartyBtn_Click" />
                            <asp:Button ID="DeleteParty" runat="server" Text="Delete" SkinID="deleteBtn" CommandName='<%# Eval("PartyName") %>' CommandArgument='<%# Eval("PartyID") %>' OnClick="DeletePartyBtn_Click" OnClientClick="return confirm('Are you sure you want to delete this party?');" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle HorizontalAlign="Center" />
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
    </div>
</asp:Content>

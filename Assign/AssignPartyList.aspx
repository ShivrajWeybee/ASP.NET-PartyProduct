<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AssignPartyList.aspx.cs" Inherits="Assign_AssignPartyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <h1>Assign Party</h1>
        <asp:Button ID="GoToAssignPartyBtn" runat="server" Text="Assign" OnClick="GoToAssignPartyBtn_Click"/>
        <br />
        <br />
        <asp:GridView ID="AssignPartyListTbl" runat="server" CssClass="table table-striped table-bordered table-hover" HorizontalAlign="Center" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="PartyName" HeaderText="Party Name" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:TemplateField HeaderText="Actions" ShowHeader="False">
                    <ItemTemplate>
                        <div Cssclass="btn-group edit-delete-btn" role="group">
                            <asp:Button ID="EditAssign" runat="server" Text="Edit" SkinID="editBtn" CommandArgument='<%# Eval("ID") %>' OnClick="EditAssignBtn_Click" />
                            <asp:Button ID="DeleteAssign" runat="server" Text="Delete" SkinID="deleteBtn" CommandArgument='<%# Eval("ID") %>' OnClick="DeleteAssignBtn_Click" OnClientClick="return confirm('Are you sure you want to delete this Assigning?');" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle HorizontalAlign="Center" />
            <HeaderStyle HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
    </div>
</asp:Content>


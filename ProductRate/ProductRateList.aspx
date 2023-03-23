<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductRateList.aspx.cs" Inherits="ProductRateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <h1>Product Rate List</h1>
        <asp:Button ID="GoToAddRateBtn" runat="server" Text="Add Product Rate" OnClick="GoToAddRateBtn_Click" />
        <br />
        <br />
        <asp:GridView ID="ProductRateListTbl" runat="server" CssClass="table table-striped table-bordered table-hover" HorizontalAlign="Center" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="PrtID" HeaderText="ID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="Rate" HeaderText="Rate" />
                <asp:BoundField DataField="DateOfRate" HeaderText="DateOfRate" />
                <asp:TemplateField HeaderText="Actions" ShowHeader="False">
                    <ItemTemplate>
                        <div Cssclass="btn-group edit-delete-btn" role="group">
                            <asp:Button ID="EditRate" runat="server" Text="Edit" SkinID="editBtn" CommandArgument='<%# Eval("PrtID") %>' OnClick="EditRateBtn_Click" />
                            <asp:Button ID="DeleteRate" runat="server" Text="Delete" SkinID="deleteBtn" CommandArgument='<%# Eval("PrtID") %>' OnClick="DeleteRateBtn_Click" OnClientClick="return confirm('Are you sure you want to delete this product rate?');" />
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


<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="Product_ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <h1>Product List</h1>
        <asp:Button ID="GoToAddProductBtn" runat="server" Text="Add Product" OnClick="GoToAddProductBtn_Click" />
        <br />
        <br />
        <asp:GridView ID="ProductListTbl" runat="server" CssClass="table table-striped table-bordered table-hover" HorizontalAlign="Center" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="Rate" HeaderText="Current Rate" />
                <asp:TemplateField HeaderText="Actions" ShowHeader="False">
                    <ItemTemplate>
                        <div Cssclass="btn-group edit-delete-btn" role="group">
                            <asp:Button ID="EditProduct" runat="server" Text="Edit" SkinID="editBtn" CommandName='<%# Eval("ProductName") %>' CommandArgument='<%# Eval("ProductID") %>' OnClick="EditProductBtn_Click" />
                            <asp:Button ID="DeleteProduct" runat="server" Text="Delete" SkinID="deleteBtn" CommandName='<%# Eval("ProductName") %>' CommandArgument='<%# Eval("ProductID") %>' OnClick="DeleteProductBtn_Click" OnClientClick="return confirm('Are you sure you want to delete this product?');" />
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


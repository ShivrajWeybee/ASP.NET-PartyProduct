<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddEditProduct.aspx.cs" Inherits="Product_AddEditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <h1>Add Product</h1>
        <p>
            <asp:Label ID="ProductWarnLbl" runat="server" Text=""></asp:Label>
        </p>
    </div>
    <table class="tabletable">
        <tr>
            <td>
                <asp:Label ID="ProductNameLbl" runat="server" Text="Product Name" CssClass="form-label"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="ProductNameTbox" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:RequiredFieldValidator ID="ReqProductName" runat="server" ErrorMessage="Name can not be empty" ControlToValidate="ProductNameTbox"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button ID="AddProductBtn" runat="server" OnClick="AddProductBtn_Click" Text="Add" />
    &nbsp;<asp:Button ID="UpdateProductBtn" runat="server" Text="Update" OnClick="UpdateProductBtn_Click" Visible="false" />
    &nbsp;<asp:Button ID="CancelProductBtn" runat="server" SkinID="cancelBtn" OnClick="CancelProductBtn_Click" Text="Cancel" CausesValidation="false" />
</asp:Content>


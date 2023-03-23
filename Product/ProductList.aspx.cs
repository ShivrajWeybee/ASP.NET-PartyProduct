using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Product_ProductList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetProductList();
        }
    }
    protected void GetProductList()
    {
        try
        {
            Connection.GetDataList("spSelectProduct", ProductListTbl);
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void GoToAddProductBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Product/AddEditProduct.aspx");
    }
    protected void EditProductBtn_Click(object sender, EventArgs e)
    {
        Button btnEdit = (sender as Button);
        var id = btnEdit.CommandArgument;
        var name = btnEdit.CommandName;
        Response.Redirect($"~/Product/AddEditProduct.aspx?ProductId={id}&ProductName={name}");
    }
    protected void DeleteProductBtn_Click(object sender, EventArgs e)
    {
        SqlConnection con = null;
        try
        {
            Button btnDelete = (sender as Button);
            var id = Convert.ToInt32(btnDelete.CommandArgument);

            string query = $"spDeleteProduct {id}";
            con = new SqlConnection(Connection.GetConnStr);
            SqlCommand cm = new SqlCommand(query, con);
            con.Open();
            cm.ExecuteNonQuery();

            GetProductList();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
}
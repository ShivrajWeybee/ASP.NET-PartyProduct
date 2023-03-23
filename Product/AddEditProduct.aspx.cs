using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Product_AddEditProduct : System.Web.UI.Page
{
    SqlConnection con = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["ProductID"]) && !String.IsNullOrEmpty(Request.QueryString["ProductName"]))
            {
                AddProductBtn.Visible = false;
                UpdateProductBtn.Visible = true;
                ProductNameTbox.Text = Request.QueryString["ProductName"];
            }
        }
    }

    protected void AddProductBtn_Click(object sender, EventArgs e)
    {
        string inputProductName = ProductNameTbox.Text;
        if (inputProductName != null)
        {
            try
            {
                string query = $"spInsertIntoPartyOrProduct 'Product', 'ProductName', '{inputProductName}'";
                con = new SqlConnection(Connection.GetConnStr);
                SqlCommand cm = new SqlCommand(query, con);

                con.Open();
                cm.ExecuteNonQuery();

                ProductWarnLbl.Text = $"{inputProductName} added !";
                ProductNameTbox.Text = "";
            }
            catch (Exception ex)
            {
                ProductWarnLbl.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void UpdateProductBtn_Click(object sender, EventArgs e)
    {
        string textInput = ProductNameTbox.Text;
        if (textInput != null)
        {
            try
            {
                string query = $"spUpdateProduct '{textInput}', '{Convert.ToInt32(Request.QueryString["ProductID"])}'";
                con = new SqlConnection(Connection.GetConnStr);
                SqlCommand cm = new SqlCommand(query, con);

                con.Open();
                cm.ExecuteNonQuery();

                ProductWarnLbl.Text = $"{textInput} added !";
                ProductNameTbox.Text = "";
            }
            catch (Exception ex)
            {
                ProductWarnLbl.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void CancelProductBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Product/ProductList.aspx");
    }
}
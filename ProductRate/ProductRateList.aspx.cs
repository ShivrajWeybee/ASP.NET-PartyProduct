using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ProductRateList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetProductRateList();
        }
    }
    protected void GetProductRateList()
    {
        try
        {
            Connection.GetDataList("spSelectProductRate", ProductRateListTbl);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void GoToAddRateBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProductRate/AddEditProductRate.aspx");
    }
    protected void EditRateBtn_Click(object sender, EventArgs e)
    {
        Button btnEdit = (sender as Button);
        var id = btnEdit.CommandArgument;
        Response.Redirect($"~/ProductRate/AddEditProductRate.aspx?PrtId={id}");
    }
    protected void DeleteRateBtn_Click(object sender, EventArgs e)
    {
        SqlConnection con = null;
        try
        {
            Button btnDelete = (sender as Button);
            var id = Convert.ToInt32(btnDelete.CommandArgument);

            string query = $"spDeleteProductRate {id}";
            con = new SqlConnection(Connection.GetConnStr);
            SqlCommand cm = new SqlCommand(query, con);
            con.Open();
            cm.ExecuteNonQuery();

            GetProductRateList();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Assign_AssignPartyList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAssignPartyList();
        }
    }
    protected void GetAssignPartyList()
    {
        try
        {
            Connection.GetDataList("spSelectAssignList", AssignPartyListTbl);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void GoToAssignPartyBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Assign/AddEditAsignParty.aspx");
    }
    protected void EditAssignBtn_Click(object sender, EventArgs e)
    {
        Button btnEdit = (sender as Button);
        var id = btnEdit.CommandArgument;
        Response.Redirect($"~/Assign/AddEditAsignParty.aspx?AssignId={id}");
    }
    protected void DeleteAssignBtn_Click(object sender, EventArgs e)
    {
        SqlConnection con = null;
        try
        {
            Button btnDelete = (sender as Button);
            var id = Convert.ToInt32(btnDelete.CommandArgument);

            string query = $"spDeleteAssign {id}";
            con = new SqlConnection(Connection.GetConnStr);
            SqlCommand cm = new SqlCommand(query, con);
            con.Open();
            cm.ExecuteNonQuery();

            GetAssignPartyList();
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
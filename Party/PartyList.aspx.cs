using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

public partial class PartyList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetPartyList();
        }
    }
    protected void GetPartyList()
    {
        try
        {
            Connection.GetDataList("spSelectParty", PartyListTbl);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void GoToAddPartyBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Party/AddEditParty.aspx");
    }
    protected void EditPartyBtn_Click(object sender, EventArgs e)
    {
        Button btnEdit = (sender as Button);
        var id = btnEdit.CommandArgument;
        var name = btnEdit.CommandName;
        Response.Redirect($"~/Party/AddEditParty.aspx?PartyId={id}&PartyName={name}");
    }
    protected void DeletePartyBtn_Click(object sender, EventArgs e)
    {
        SqlConnection con = null;
        try
        {
            Button btnDelete = (sender as Button);
            var id = Convert.ToInt32(btnDelete.CommandArgument);

            string query = $"spDeleteParty {id}";
            con = new SqlConnection(Connection.GetConnStr);
            SqlCommand cm = new SqlCommand(query, con);
            con.Open();
            cm.ExecuteNonQuery();

            GetPartyList();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Party_AddEditParty : System.Web.UI.Page
{
    SqlConnection con = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Request.QueryString["PartyID"] != null && Request.QueryString["PartyName"] != null && Request.QueryString["PartyID"] != string.Empty)
            {
                AddPartyBtn.Visible = false;
                UpdatePartyBtn.Visible = true;
                partyNameTbox.Text = Request.QueryString["PartyName"];
            }
        }
    }
    protected void AddPartyBtn_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(partyNameTbox.Text))
        {
            try
            {
                string query = $"spInsertIntoPartyOrProduct 'Party', 'PartyName', '{partyNameTbox.Text}'";
                con = new SqlConnection(Connection.GetConnStr);
                SqlCommand cm = new SqlCommand(query, con);

                con.Open();
                cm.ExecuteNonQuery();

                PartyWarnLbl.Text = $"{partyNameTbox.Text} added !";
                partyNameTbox.Text = "";
            }
            catch (Exception ex)
            {
                PartyWarnLbl.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void PartyBackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Party/PartyList.aspx");
    }
    protected void UpdatePartyBtn_Click(object sender, EventArgs e)
    {
        string textInput = partyNameTbox.Text;
        if (textInput != null)
        {
            try
            {
                string query = $"spUpdateParty '{textInput}', '{Convert.ToInt32(Request.QueryString["PartyID"])}'";
                con = new SqlConnection(Connection.GetConnStr);
                SqlCommand cm = new SqlCommand(query, con);

                con.Open();
                cm.ExecuteNonQuery();

                PartyWarnLbl.Text = $"{textInput} added !";
                partyNameTbox.Text = "";
            }
            catch (Exception ex)
            {
                PartyWarnLbl.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
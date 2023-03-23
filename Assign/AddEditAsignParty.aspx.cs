using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Assign_AddEditAsignParty : System.Web.UI.Page
{
    SqlConnection con = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                con = new SqlConnection(Connection.GetConnStr);

                SqlDataAdapter sdParty = new SqlDataAdapter("spSelectParty", con);
                SqlDataAdapter sdProduct = new SqlDataAdapter("spSelectProduct", con);

                DataTable dtParty = new DataTable();
                DataTable dtProduct = new DataTable();

                sdParty.Fill(dtParty);
                sdProduct.Fill(dtProduct);

                assignPartyNameTbox.DataSource = dtParty;
                assignPartyNameTbox.DataValueField = "PartyID";
                assignPartyNameTbox.DataTextField = "PartyName";
                assignPartyNameTbox.DataBind();
                assignPartyNameTbox.Items.Insert(0, new ListItem("Select Party", "0"));
                assignPartyNameTbox.Items[0].Attributes.Add("disabled", "disabled");
                assignPartyNameTbox.Items[0].Attributes.Add("selected", "selected");

                assignProductNameTbox.DataSource = dtProduct;
                assignProductNameTbox.DataValueField = "ProductID";
                assignProductNameTbox.DataTextField = "ProductName";
                assignProductNameTbox.DataBind();
                assignProductNameTbox.Items.Insert(0, new ListItem("Select Product", "0"));
                assignProductNameTbox.Items[0].Attributes.Add("disabled", "disabled");
                assignProductNameTbox.Items[0].Attributes.Add("selected", "selected");
            }
            catch (Exception ex)
            {
                AssignPartyWarnLbl.Text = ex.Message;
            }
            if (!String.IsNullOrEmpty(Request.QueryString["AssignID"]))
            {
                AddAssignBtn.Visible = false;
                UpdateAssignBtn.Visible = true;
                GetSelectedParty();
                GetSelectedProduct();
            }
        }
    }
    protected void AddAssignBtn_Click(object sender, EventArgs e)
    {
        if (assignPartyNameTbox.SelectedIndex > 0 && assignProductNameTbox.SelectedIndex > 0)
        {
            try
            {
                string query = $"spInsertAssign '{Convert.ToInt32(assignPartyNameTbox.SelectedValue)}', '{Convert.ToInt32(assignProductNameTbox.SelectedValue)}'";
                con = new SqlConnection(Connection.GetConnStr);
                SqlCommand cm = new SqlCommand(query, con);

                con.Open();
                cm.ExecuteNonQuery();

                AssignPartyWarnLbl.Text = "Party assigned successfully !";
            }
            catch (Exception ex)
            {
                AssignPartyWarnLbl.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void AddAssignCancleBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Assign/AssignPartyList.aspx");
    }
    protected void UpdateAssignBtn_Click(object sender, EventArgs e)
    {
        string partyNameID = assignPartyNameTbox.SelectedItem.Value;
        string productNameID = assignProductNameTbox.SelectedItem.Value;

        if (partyNameID != null && productNameID != null)
        {
            try
            {
                string query = $"spUpdateAssign '{Convert.ToInt32(productNameID)}', '{Convert.ToInt32(partyNameID)}', '{Convert.ToInt32(Request.QueryString["AssignID"])}'";
                con = new SqlConnection(Connection.GetConnStr);
                SqlCommand cm = new SqlCommand(query, con);

                con.Open();
                cm.ExecuteNonQuery();

                AssignPartyWarnLbl.Text = "Assign Updated !";
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
    protected void GetSelectedParty()
    {
        try
        {
            con = new SqlConnection(Connection.GetConnStr);
            SqlCommand cmParty = new SqlCommand($"spGetSelectedPartyID {Convert.ToInt32(Request.QueryString["AssignID"])}", con);
            con.Open();
            SqlDataReader sdr1 = cmParty.ExecuteReader();
            sdr1.Read();

            var result = sdr1[0].ToString();
            assignPartyNameTbox.SelectedIndex = assignPartyNameTbox.Items.IndexOf(assignPartyNameTbox.Items.FindByValue(result));
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
    protected void GetSelectedProduct()
    {
        try
        {
            con = new SqlConnection(Connection.GetConnStr);
            SqlCommand cmParty = new SqlCommand($"spGetSelectedProductID {Convert.ToInt32(Request.QueryString["AssignID"])}", con);
            con.Open();
            SqlDataReader sdr1 = cmParty.ExecuteReader();
            sdr1.Read();

            var result = sdr1[0].ToString();
            assignProductNameTbox.SelectedIndex = assignProductNameTbox.Items.IndexOf(assignProductNameTbox.Items.FindByValue(result));
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
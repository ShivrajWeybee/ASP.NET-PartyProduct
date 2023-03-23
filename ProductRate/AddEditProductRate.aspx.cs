using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ProductRate_AddEditProductRate : System.Web.UI.Page
{
    SqlConnection con = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                con = new SqlConnection(Connection.GetConnStr);
                SqlDataAdapter sdProducts = new SqlDataAdapter("spSelectProduct", con);
                DataTable dtProducts = new DataTable();
                sdProducts.Fill(dtProducts);

                rateProductNameTbox.DataSource = dtProducts;
                rateProductNameTbox.DataValueField = "ProductID";
                rateProductNameTbox.DataTextField = "ProductName";
                rateProductNameTbox.DataBind();
                rateProductNameTbox.Items.Insert(0, new ListItem("Select Product", "0"));
                rateProductNameTbox.Items[0].Attributes.Add("disabled", "disabled");
                rateProductNameTbox.Items[0].Attributes.Add("selected", "selected");
            }
            catch (Exception ex)
            {
                RateWarnLbl.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
            if (!String.IsNullOrEmpty(Request.QueryString["PrtID"]))
            {
                addRateBtn.Visible = false;
                UpdateRateBtn.Visible = true;
                GetSelectedData();
            }
            rateDateTBox.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }
    }
    protected void addRateBtn_Click(object sender, EventArgs e)
    {
        try
        {
            var dateString = DateTime.Now.ToString("yyyy-MM-dd");
            string query = $"spInsertProductRate '{Convert.ToInt32(rateProductNameTbox.SelectedValue)}', '{Convert.ToInt32(rateCurrentTBox.Text)}', '{dateString}'";
            con = new SqlConnection(Connection.GetConnStr);
            SqlCommand cm = new SqlCommand(query, con);

            con.Open();
            cm.ExecuteNonQuery();

            RateWarnLbl.Text = "Data added successfully !";
        }
        catch (Exception ex)
        {
            RateWarnLbl.Text = ex.Message;
        }
        finally
        {
            con.Close();
        }
    }
    protected void rateBackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProductRate/ProductRateList.aspx");
    }
    protected void UpdateRateBtn_Click(object sender, EventArgs e)
    {
        int productNameID = Convert.ToInt32(rateProductNameTbox.SelectedItem.Value);
        string rateID = rateCurrentTBox.Text;
        string dateID = rateDateTBox.Text;

        try
        {
            string query = $"spUpdateProductRate '{productNameID}', '{rateID}', '{dateID.ToString()}', {Convert.ToInt32(Request.QueryString["PrtID"])}";
            con = new SqlConnection(Connection.GetConnStr);
            SqlCommand cm = new SqlCommand(query, con);

            con.Open();
            cm.ExecuteNonQuery();

            RateWarnLbl.Text = $"Rate Updated !";
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
    private void GetSelectedData()
    {
        try
        {
            con = new SqlConnection(Connection.GetConnStr);
            SqlCommand cmParty = new SqlCommand($"spGetSelectedProductFromRate {Convert.ToInt32(Request.QueryString["PrtID"])}", con);
            con.Open();
            SqlDataReader sdr1 = cmParty.ExecuteReader();
            sdr1.Read();

            var result = sdr1[0].ToString();
            rateProductNameTbox.SelectedIndex = rateProductNameTbox.Items.IndexOf(rateProductNameTbox.Items.FindByValue(result));
            rateCurrentTBox.Text = sdr1[1].ToString();

            DateTime dt = DateTime.Parse(sdr1[2].ToString());
            rateDateTBox.Text = dt.ToString("yyyy-MM-dd");
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
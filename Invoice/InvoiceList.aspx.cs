using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Invoice_InvoiceList : System.Web.UI.Page
{
    SqlConnection con = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InvoiceRateTBox.Enabled = false;
            try
            {
                con = new SqlConnection(Connection.GetConnStr);

                SqlDataAdapter sdParty = new SqlDataAdapter("spSelectParty", con);

                DataTable dtParty = new DataTable();
                
                sdParty.Fill(dtParty);

                InVoicePartyTBox.DataSource = dtParty;
                InVoicePartyTBox.DataValueField = "PartyID";
                InVoicePartyTBox.DataTextField = "PartyName";
                InVoicePartyTBox.DataBind();
                InVoicePartyTBox.Items.Insert(0, new ListItem("Select Party", "0"));
                InVoicePartyTBox.Items[0].Attributes.Add("disabled", "disabled");
                InVoicePartyTBox.Items[0].Attributes.Add("selected", "selected");
            }
            catch (Exception ex)
            {
                InvoiceWarnLbl.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
            GetInvoiceList();
            GetGrandTotal();
        }
    }
    protected void GetInvoiceList()
    {
        try
        {
            Connection.GetDataList("select * from GetAllInvoice", InvoiceListTbl);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void GetGrandTotal()
    {
        try
        {
            con = new SqlConnection(Connection.GetConnStr);
            SqlCommand cm = new SqlCommand("spGetGrandTotal", con);
            con.Open();

            SqlDataReader sdr1 = cm.ExecuteReader();
            sdr1.Read();

            GrandTotalTBox.Text = sdr1[0].ToString();
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

    protected void AddInvoicBtn_Click(object sender, EventArgs e)
    {
        try
        {
            decimal inRate = Convert.ToDecimal(InvoiceRateTBox.Text);
            int inQuantity = Convert.ToInt32(InvoiceQuantityTBox.Text);

            string query = $"spAddInvoice {Convert.ToInt32(InVoicePartyTBox.SelectedValue)}, {Convert.ToInt32(InVoiceProductTBox.SelectedValue)}, {inRate}, {inQuantity}, {Convert.ToDecimal(inRate*inQuantity)}";
            con = new SqlConnection(Connection.GetConnStr);
            SqlCommand cm = new SqlCommand(query, con);

            con.Open();
            cm.ExecuteNonQuery();

            InvoiceWarnLbl.Text = "Invoice added successfully !";

            GetInvoiceList();
            GetGrandTotal();

            InVoicePartyTBox.Items[0].Attributes.Add("selected", "selected");
            InVoiceProductTBox.Items[0].Attributes.Add("selected", "selected");
            InvoiceRateTBox.Text = "";
            InvoiceQuantityTBox.Text = "";
        }
        catch (Exception ex)
        {
            InvoiceWarnLbl.Text = ex.Message;
        }
    }

    protected void InVoicePartyTBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (InVoicePartyTBox.SelectedIndex > -1)
        {
            try
            {
                con = new SqlConnection(Connection.GetConnStr);

                SqlDataAdapter sdProduct = new SqlDataAdapter($"spGetProductFromParty {Convert.ToInt32(InVoicePartyTBox.SelectedValue)}", con);

                DataTable dtProduct = new DataTable();
                sdProduct.Fill(dtProduct);

                InVoiceProductTBox.DataSource = dtProduct;
                InVoiceProductTBox.DataValueField = "ProductID";
                InVoiceProductTBox.DataTextField = "ProductName";
                InVoiceProductTBox.DataBind();
                InVoiceProductTBox.Items.Insert(0, new ListItem("Select Product", "0"));
                InVoiceProductTBox.Items[0].Attributes.Add("disabled", "disabled");
                InVoiceProductTBox.Items[0].Attributes.Add("selected", "selected");
            }
            catch (Exception ex)
            {
                InvoiceWarnLbl.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void InVoiceProductTBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (InVoiceProductTBox.SelectedIndex > -1)
        {
            try
            {
                con = new SqlConnection(Connection.GetConnStr);

                SqlCommand sdProduct = new SqlCommand($"spGetProductRateFromProduct {Convert.ToInt32(InVoiceProductTBox.SelectedValue)}", con);
                con.Open();

                SqlDataReader sdr1 = sdProduct.ExecuteReader();
                sdr1.Read();

                InvoiceRateTBox.Text = sdr1[0].ToString();
            }
            catch (Exception ex)
            {
                InvoiceWarnLbl.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void ClearInvoicBtn_Click(object sender, EventArgs e)
    {
        if (InVoiceProductTBox.Items.Count > 0)
        {
            InVoicePartyTBox.Items[0].Attributes.Add("selected", "selected");
            InVoiceProductTBox.Items[0].Attributes.Add("selected", "selected");
            InvoiceRateTBox.Text = "";
            InvoiceQuantityTBox.Text = "";
        }
    }
}
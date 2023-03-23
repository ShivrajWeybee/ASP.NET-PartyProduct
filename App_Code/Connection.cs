using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public class Connection
{
    public static string GetConnStr
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        }
    }
    public static void GetDataList(string queryString, GridView gridViewParam)
    {
        using (SqlConnection  con = new SqlConnection(GetConnStr))
        {
            SqlDataAdapter sde = new SqlDataAdapter(queryString, con);
            DataSet ds = new DataSet();
            sde.Fill(ds);

            gridViewParam.DataSource = ds;
            gridViewParam.DataBind();
        }
    }
}
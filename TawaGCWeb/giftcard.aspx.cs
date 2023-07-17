using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace TawaGCWeb
{
    public partial class giftcard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (string.IsNullOrEmpty(Session["permision"] as string))
                 Response.Redirect(@"login.aspx");
            if ( (Session["permision"].ToString() != "HQ") && (Session["permision"].ToString() != "STORE") )
                 Response.Redirect(@"login.aspx");
            nameLabel.Text = Session["user"].ToString();
            ldtLabel.Text = Session["lastdt"].ToString();
         }

        void FillGrid()
        {
            try
            {
                string connectionStr = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionStr);
                connection.Open();
                SqlCommand command1 = new SqlCommand();
                command1.Connection = connection;
                if (Session["permision"].ToString() == "HQ")
                    command1.CommandText = "SELECT MerchantNumber,ChainCode,ROW_NUMBER() OVER(ORDER BY [date] DESC) AS Row# ,CONVERT (varchar(10), [Date], 101) as [Date],Store,Type,Amount from TawaGiftCard where cardnumber = '" + TextBox1.Text.Trim() + "' ";
                else command1.CommandText = "SELECT ROW_NUMBER() OVER(ORDER BY [date] DESC) AS Row# ,CONVERT (varchar(10), [Date], 101) as [Date],Store,Type,Amount from TawaGiftCard where cardnumber = '" + TextBox1.Text.Trim() + "' ";
                SqlDataAdapter da = new SqlDataAdapter(command1);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                connection.Close();
            }
            catch (Exception ex)
            {
            }


            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim().Length < 16)
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                return;
            }
            FillGrid();
            TextBox1.Focus();
        }
        public System.Data.SqlClient.SqlConnection connection;
    }
}
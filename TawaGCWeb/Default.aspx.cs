using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace TawaGCWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                validUser();
        }

        private void getLastModifyDT()
        {
            try
            {
                string connectionStr = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionStr);
                connection.Open();
                SqlCommand command1 = new SqlCommand();
                command1.Connection = connection;
                command1.CommandText = "select top 1 createtime from tawagiftcard order by id desc";
                SqlDataReader dr = command1.ExecuteReader();
                if (dr.Read())
                {
                    Session["lastdt"] = dr.GetDateTime(0).ToString("MM/dd/yyyy hh:mm tt");
                }
                else
                {
                    Session["lastdt"] = "unknown";
                }
                dr.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void validUser()
        {
            string link = "login.aspx";
            getLastModifyDT();
            try
            {
                string connectionStr = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
                System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionStr);
                connection.Open();
                SqlCommand command1 = new SqlCommand();
                command1.Connection = connection;
                command1.CommandText = "select role from TawaGiftCardUser where userid =  '" + Session["user"] + "' and status =1";
                SqlDataReader dr = command1.ExecuteReader();
                if (dr.Read())
                {
                    Session["permision"] =  dr.GetString(0);
                    link = @"giftcard.aspx";
                }
                else
                {
                   
                }
                dr.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            Response.Redirect(link);
        }

    }
}
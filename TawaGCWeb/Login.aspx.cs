using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using FormsAuth;
using System.Data.SqlClient;
using System.Configuration;

namespace TawaGCWeb
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            verLabel.Text = "Tawa Gift Card Activity Reporting Tool <font color=red>v1.0</font>";
        }

        private void writeLog()
        {
            string user_IP = "";
            if (Request.ServerVariables["HTTP_VIA "] != null)
            {
                user_IP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else
            {
                user_IP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            }

            try
            {
                string strConstring = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
                SqlConnection conn = new SqlConnection(strConstring);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into LogInfo(LoginAccount,tablename,Action,Timestamp) VALUES ('" + Session["user"] + "','GCARTLogin','" + user_IP + "',getdate())";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string txtDomain = "tawa9810";
            string adPath = "LDAP://" + txtDomain;
            LdapAuthentication adAuth = new LdapAuthentication(adPath);
            try
            {
                if (true == adAuth.IsAuthenticated(txtDomain, txtUsername.Text, txtPassword.Text))
                {
                    Session["user"] = txtUsername.Text;
                    writeLog();
                    string groups = adAuth.GetGroups();
                    //Create the ticket, and add the groups.
                    bool isCookiePersistent = chkPersist.Checked;
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,
                              txtUsername.Text, DateTime.Now, DateTime.Now.AddMinutes(60), isCookiePersistent, groups);

                    //Encrypt the ticket.
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                    //Create a cookie, and then add the encrypted ticket to the cookie as data.
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                    if (true == isCookiePersistent)
                        authCookie.Expires = authTicket.Expiration;

                    //Add the cookie to the outgoing cookies collection.
                    Response.Cookies.Add(authCookie);

                    //You can redirect now.
                    Response.Redirect("default.aspx");
                }
                else
                {
                    Session.RemoveAll();
                    errorLabel.Text = "Authentication did not succeed. Check user name and password.";
                }
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
            }
        }
    }
}
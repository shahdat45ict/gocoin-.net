using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoWebGoCoin
{
    public partial class GoCoinHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void GetToken(string client_id, string client_secret, string redirect_uri)
        {
            // This will redirect the user to dashbord for generating the token using different scopes as per Documentation.
           // Response.Redirect("https://dashboard.llamacoin.com/auth?response_type=code&client_id=" + client_id + "&redirect_uri=" + redirect_uri + "&scope=user_read_write merchant_read_write invoice_read_write&state=1234", false);
            Response.Redirect("https://dashboard.gocoin.com/auth?response_type=code&client_id=" + client_id + "&redirect_uri=" + redirect_uri + "&scope=user_read_write merchant_read_write invoice_read_write&state=1234", false);
        
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Session["Client_Id"] = txtClient_Id.Text;
            Session["Client_Secret"] = txtClient_Secret.Text;
            Session["Redirect_Url"] = txtRedirect_Url.Text;
           GetToken(txtClient_Id.Text, txtClient_Secret.Text, txtRedirect_Url.Text);
        }


    }
}
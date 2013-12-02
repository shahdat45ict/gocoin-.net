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
            if (!IsPostBack)
            {
                //txtClient_Id.Text = "895963850ade9e8f5652ecabc7e16b3d561ea22f8d8b4c4207e6784a0db3a01f";
                //txtClient_Secret.Text = "6b08be21178a7f76229d7cae91a33eed023b7bf5aede577f4cc7d73ec5bd6e3f";
                //txtRedirect_Url.Text = "http://119.226.189.186:8100/DemoWebGoCoin/GetGoCoinCalls.aspx";
                //txtClient_Id.Text = "";
                //txtClient_Secret.Text = "";
                //txtRedirect_Url.Text = "";
              
            }
        }
        protected void GetToken(string client_id, string client_secret, string redirect_uri)
        {

            Response.Redirect("https://dashboard.llamacoin.com/auth?response_type=code&client_id=" + client_id + "&redirect_uri=" + redirect_uri + "&scope=user_read_write merchant_read_write invoice_read_write&state=1234", false);
         
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
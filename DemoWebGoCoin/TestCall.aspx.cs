using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoCoinAPI;
using Newtonsoft.Json;
using Logger;

namespace DemoWebGoCoin
{
    public partial class TestCall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getauthorizeapi();
        }

        protected void getauthorizeapi()
        {
            Client client = new Client();
            client.client_id = "895963850ade9e8f5652ecabc7e16b3d561ea22f8d8b4c4207e6784a0db3a01f";
            client.client_secret = "6b08be21178a7f76229d7cae91a33eed023b7bf5aede577f4cc7d73ec5bd6e3f";
            client.scope = "user_read_write user_password_write merchant_read_write invoice_read_write oauth_read_write";
            client.redirect_uri = "http://119.226.189.186:8100/DemoWebGoCoin/";

            Boolean b_auth = client.authorize_api();
            if (b_auth)
            {
                GoCoinAPI.User currentuser = new GoCoinAPI.User();
                currentuser = client.api.user.self();
                Response.Write(" User Calls");
                Response.Write("</br>");
                Response.Write("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Response.Write("</br>");
                Response.Write("</br>");
                Response.Write(" User get");
                Response.Write("</br>");
                Response.Write(SerializeJson(client.api.user.get(currentuser.id)));
                Response.Write("</br>");
                Response.Write(" Merchants Calls");
                Response.Write("</br>");
                Response.Write("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Response.Write("</br>");
                Response.Write(" Merchants get");
                Response.Write("</br>");
                Response.Write(SerializeJson(client.api.merchants.get(currentuser.merchant_id)));
                Response.Write("</br>");
                Response.Write(" Invoices Calls");
                Response.Write("</br>");
                Response.Write("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Response.Write("</br>");
                Response.Write(" Invoices get");
                Response.Write("</br>");
                Response.Write(SerializeJson(client.api.invoices.get("b9b9ddfd-7977-4938-b8d1-4aec6da507bc")));
                Response.Write("</br>");
                Response.Write(" Accounts Calls");
                Response.Write("</br>");
                Response.Write("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Response.Write("</br>");
                Response.Write(" Account alist");
                Response.Write("</br>");
                Response.Write(SerializeJson(client.api.accounts.alist(currentuser.merchant_id)));
                Response.Write("</br>");
                //Response.Write(" Account get");
                //Response.Write("</br>");
                //Response.Write(SerializeJson(client.api.accounts.get("5cb16865-33d6-4494-8f0f-3d765f4dddb3")));
                Response.Write("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            }
            else
            {
                Response.Redirect("Error in getting the User Data", false);
            }
        }

        public string SerializeJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
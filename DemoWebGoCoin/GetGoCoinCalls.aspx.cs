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

    public partial class GetGoCoinCalls : System.Web.UI.Page
    {
        public  string rediredt_url_web = null;
        private ErrorManager _errLog = new ErrorManager("File");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Client_Id"] != null || Session["Client_Id"] != null || Session["Client_Id"] != null)
                {
                    txtClient_Id.Text = Session["Client_Id"].ToString().Trim();
                    txtClient_Secret.Text = Session["Client_Secret"].ToString().Trim();
                    txtRedirect_Url.Text = Session["Redirect_Url"].ToString().Trim();
                    rediredt_url_web = Session["Redirect_Url"].ToString().Trim();
                    txtToken_Code.Text = Request.QueryString["code"].ToString().Trim();
                }
            }
        }

        protected void GetCurrentGoCoinUser_Click(object sender, EventArgs e)
        {
            GetGoCoinAuthorizationCode(txtClient_Id.Text, txtClient_Secret.Text, txtRedirect_Url.Text, txtToken_Code.Text);
        }
        protected void GetGoCoinAuthorizationCode(string client_id, string client_secret, string redirect_uri, string token_code)
        {
            GoCoinAuthorizationCode code = new GoCoinAuthorizationCode();
            code.client_id = client_id;
            code.client_secret = client_secret;
            code.code = token_code;
            code.grant_type = "authorization_code";
            code.redirect_uri = redirect_uri;

            // Call For AccessToken and Api Services
            CallForClientServices(code);

        }
        protected void CallForClientServices(GoCoinAuthorizationCode objcgs)
        {
            GoCoinClientService GCcs = new GoCoinClientService(objcgs);

            Response.Write("<b> Coin User </b></hr><br />");
            Response.Write("<b>Call for GetCurrentGoCoinUser </b><br />");
            GoCoinUser user = GCcs.GetCurrentGoCoinUser();
            try
            {
                Response.Write(SerializeJson(GCcs.GetCurrentGoCoinUser()) + "<br />");
            }
            catch (Exception _ex)
            {

                _errLog.WebLogError("GetCurrentGoCoinUser", _ex);
            }

            
            Response.Write("<b>Call for ListGoCoinUser </b><br />");
            try
            {
                Response.Write(SerializeJson(GCcs.ListGoCoinUser()) + "<br />");
            }
            catch (Exception _ex)
            {

                _errLog.WebLogError("ListGoCoinUser", _ex);
            }


            Response.Write("<b>Call for GetGoCoinUserDetailByID </b><br />");

            try
            {
                Response.Write(SerializeJson(GCcs.GetGoCoinUserDetailByID(user.id)) + "<br />");
            }
            catch (Exception _ex)
            {

                _errLog.WebLogError("GetGoCoinUserDetailByID", _ex);
            }

            Response.Write("<b>Call for CreateGoCoinUser </b><br />");
           // Response.Write(SerializeJson(GCcs.CreateGoCoinUser(user))+ "<br />");

            Response.Write("<b>Call for EditGoCoinUser </b><br />");
            GoCoinUser user1 =new GoCoinUser();
            try
            {
                string userfname = user.first_name;
                string userlname = user.last_name;
                user1.first_name = userfname.Substring(0, 5) + DateTime.Now;
                user1.last_name = userlname.Substring(0, 5) + DateTime.Now;
                user1.email = user.email;
                user1.id = user.id;
                Response.Write(SerializeJson(GCcs.EditGoCoinUser(user1)) + "<br />");
            }
            catch (Exception _ex)
            {

                _errLog.WebLogError("EditGoCoinUser", _ex);
            }

            Response.Write("<b>Call for DeleteGoCoinUser </b><br />");
            //  Response.Write(SerializeJson(GCcs.DeleteGoCoinUser(user.id)) + "<br />");

            Response.Write("<b>GoCoin Merchant </b></hr><br />");

          //  Response.Write("<b>Call for GetGoCoinMerchantDetailByID </b><br />");
         
            // Response.Write(SerializeJson(GCcs.GetCurrentGoCoinUser()) + "<br />");

            Response.Write("<b>Call for ListGoCoinMerchant </b><br />");
            try
            {
                Response.Write(SerializeJson(GCcs.ListGoCoinMerchant()) + "<br />");
            }
            catch (Exception _ex)
            {

                _errLog.WebLogError("ListGoCoinMerchant", _ex);
            }

            Response.Write("<b>Call for GetGoCoinMerchantDetailByID </b><br />");
            GoCoinMerchant merchant = GCcs.GetGoCoinMerchantDetailByID(user.merchant_id);
            try
            {
                Response.Write(SerializeJson(GCcs.GetGoCoinMerchantDetailByID(merchant.id)) + "<br />");
            }
            catch (Exception _ex)
            {

                _errLog.WebLogError("GetGoCoinMerchantDetailByID", _ex);
            }

            Response.Write("<b>Call for GetGoCoinMerchantAccounturl </b><br />");
            try
            {
                Response.Write(SerializeJson(GCcs.GetGoCoinMerchantAccounturlbyMerchantid(merchant.id)) + "<br />");
            }
            catch (Exception _ex)
            {

                _errLog.WebLogError("GetGoCoinMerchantAccounturlbyMerchantid", _ex);
            }

            Response.Write("<b>Call for EditGoCoinMerchant </b><br />");
            try
            {
                GoCoinMerchant merchant1 = new GoCoinMerchant();
                merchant1.id= merchant.id;
                string merchantNM = merchant.name;
                merchant1.name = merchantNM.Substring(0, 16) + DateTime.Now;
                Response.Write(SerializeJson(GCcs.EditGoCoinMerchant(merchant1)) + "<br />");
            }
            catch (Exception _ex)
            {

                _errLog.WebLogError("EditGoCoinMerchant", _ex);
            }

            //Response.Write("<b>Call for GetGoCoinMerchantInvoiceurl </b><br />");
            //try
            //{
            //    Response.Write(SerializeJson(GCcs.GetGoCoinMerchantInvoiceurl(merchant.id)) + "<br />");
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            //Response.Write("<b>Call for GetGoCoinMerchantTransactionsurl </b><br />");
            //try
            //{
            //    Response.Write(SerializeJson(GCcs.GetGoCoinMerchantTransactionsurl(merchant.id)) + "<br />");
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            Response.Write("<b>Call for CreateGoCoinMerchant </b><br />");
            try
            {
                Response.Write(SerializeJson(GCcs.CreateGoCoinMerchant(merchant)) + "<br />");
            }
            catch (Exception _ex)
            {

                _errLog.WebLogError("CreateGoCoinMerchant", _ex);
            }

            Response.Write("<b>Call for DeleteGoCoinMerchant </b><br />");
            //  Response.Write(SerializeJson(GCcs.DeleteGoCoinMerchant(merchant.id)) + "<br />");

            Response.Write("<b> GoCoin Accounts </b></hr><br />");
            Response.Write("<b>Call for ListGoCoinAccountByMerchantId </b><br />");
            try
            {
                Response.Write(SerializeJson(GCcs.ListGoCoinAccountByMerchantId(merchant.id)) + "<br />");
            }
            catch (Exception _ex)
            {

                _errLog.WebLogError("ListGoCoinAccountByMerchantId", _ex);
            }


            Response.Write("<b> GoCoin Invoice </b></hr><br />");
            Response.Write("<b>Call for GetGoCoinInvoicesDetailByMerchantID </b><br />");
            GoCoinInvoices gcinvoice = new GoCoinInvoices();
            gcinvoice.price_currency = "BTC";
            gcinvoice.base_price = "134.00";
            gcinvoice.base_price_currency = "USD";
            gcinvoice.confirmations_required = 6;
            gcinvoice.notification_level = "all";
            gcinvoice.callback_url = "https://www.example.com/gocoin/callback";
            gcinvoice.redirect_url = rediredt_url_web;
            try
            {
                Response.Write(SerializeJson(GCcs.GetGoCoinInvoicesDetailByMerchantID(SerializeJson(gcinvoice), merchant.id)) + "<br />");
            }
            catch (Exception _ex)
            {

                _errLog.WebLogError("GetGoCoinInvoicesDetailByMerchantID", _ex);
            }

            Response.Write("<b>Call for GetGoCoinInvoicesDetailByID </b><br />");
            try
            {
                GoCoinInvoices gsInvoicebyid = GCcs.GetGoCoinInvoicesDetailByMerchantID(SerializeJson(gcinvoice), merchant.id);
                Response.Write(SerializeJson(GCcs.GetGoCoinInvoicesDetailByID(gsInvoicebyid.id)) + "<br />");
            }
            catch (Exception _ex)
            {

                _errLog.WebLogError("GetGoCoinInvoicesDetailByMerchantID", _ex);
            }
            

        }
        public string SerializeJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
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
    public partial class User_update : System.Web.UI.Page
    {
        public User _user;
        public Api _api;

        protected void Page_Load(object sender, EventArgs e)
        {
            getauthorizeapi();
        }

        protected void getauthorizeapi()
        {
            Client client = new Client();
            client.client_id = "895963850ade9e8f5652ecabc7e16b3d561ea22f8d8b4c4207e6784a0db3a01f";
            client.client_secret = "6b08be21178a7f76229d7cae91a33eed023b7bf5aede577f4cc7d73ec5bd6e3f";
            client.scope = "user_read_write";
            client.redirect_uri = "http://119.226.189.186:8100/DemoWebGoCoin/";

            Boolean b_auth = client.authorize_api();
            if (b_auth)
            {
                GoCoinAPI.User currentuser = new GoCoinAPI.User();
                currentuser = client.api.user.self();

                GoCoinAPI.User Updateduser = new GoCoinAPI.User();
                //string userfname = currentuser.first_name;
                //string userlname = currentuser.last_name;
                //Updateduser.first_name = "Anup";
                //Updateduser.last_name = "Warade";

                //string userfname = user.first_name;
                //string userlname = user.last_name;
                //user1.first_name = userfname.Substring(0, 5) + DateTime.Now;
                //user1.last_name = userlname.Substring(0, 5) + DateTime.Now;

                string userfname = currentuser.first_name;
                string userlname = currentuser.last_name;
                Updateduser.first_name = userfname.Substring(0, 4) + "  " + DateTime.Now; ;
                Updateduser.last_name = userlname.Substring(0,6) + "  " + DateTime.Now;


                Updateduser.id = currentuser.id;
                
                Litupdated_user.Text = SerializeJson(client.api.user.update(Updateduser));
                
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
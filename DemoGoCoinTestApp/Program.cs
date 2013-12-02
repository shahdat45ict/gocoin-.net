using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoCoinAPI;
using Newtonsoft.Json;

namespace DemoGoCoinTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create User
            Console.WriteLine("GoCoin New User");
            GoCoinAuthorizationCode code = new GoCoinAuthorizationCode();
            Console.WriteLine("Enter a Client ID.");
            string client_id1 = Console.ReadLine();
            code.client_id = client_id1;


            Console.WriteLine("Enter a Client Secret Key.");
            string client_secret1 = Console.ReadLine();
            code.client_secret = client_secret1;

            Console.WriteLine("Enter a RedirectUrl.");
            string RedirectUrl = Console.ReadLine();
            code.redirect_uri = RedirectUrl;

            Console.WriteLine("Enter a code.");
            string code1 = Console.ReadLine();
            code.code = code1;


            code.grant_type = "authorization_code";
          
            GoCoinClientService gs = new GoCoinClientService(code);

            GoCoinUser user = gs.GetCurrentGoCoinUser();
            string userdetail = SerializeJson(gs.GetCurrentGoCoinUser());

            Console.WriteLine("__________________________________________________________________________________________________");

            Console.WriteLine("Go Coin User");

            Console.WriteLine(userdetail);


            Console.WriteLine("__________________________________________________________________________________________________");
            Console.WriteLine("Go Coin Merchant");
            Console.WriteLine("__________________________________________________________________________________________________");
            GoCoinMerchant merchant = gs.GetGoCoinMerchantDetailByID(user.merchant_id);
            try
            {
                Console.WriteLine(SerializeJson(gs.GetGoCoinMerchantDetailByID(merchant.id)));
            }
            catch (Exception)
            {

                throw;
            }

            Console.WriteLine("__________________________________________________________________________________________________");
            Console.ReadLine();
        }
        public static string SerializeJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
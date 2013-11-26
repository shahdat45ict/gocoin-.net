using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoCoinAPI;

namespace DemoGoCoinTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create User
            Console.WriteLine("GoCoin New User");
            GoCoinAuthorizationCode code = new GoCoinAuthorizationCode();
            code.client_id = "895963850ade9e8f5652ecabc7e16b3d561ea22f8d8b4c4207e6784a0db3a01f";
            code.client_secret = "6b08be21178a7f76229d7cae91a33eed023b7bf5aede577f4cc7d73ec5bd6e3f";
            code.code = "d5d272d21edb1d3ba2afff3c9210d0efc6a3ab8bd03bf933b32a12c37abb1399";
            code.grant_type = "authorization_code";
            code.redirect_uri = "http://docs.gocoin.apiary.io/"; // application demo url
            GoCoinUserService gs = new GoCoinUserService(code);
            GoCoinUser newUser = new GoCoinUser();
            newUser.first_name = "Pratik";
            newUser.last_name = "Vinchure";
            newUser.email = "test@213.com";
            newUser.id = "12345678897";
            newUser = gs.GetCurrentGoCoinUser();
            Console.WriteLine(newUser.first_name + " " + newUser.last_name + " " + newUser.email);

            newUser = gs.GetGoCoinUserDetailByID(newUser.id);
            Console.WriteLine(newUser.first_name + " " + newUser.last_name + "\n");

            ////List All Users
            //Console.WriteLine("GoCoin List of users" + "\n");
            //List<GoCoinUser> listUser = gs.ListGoCoinUser();
            //foreach (var item in listUser)
            //{
            //    Console.Write(item.first_name + " " + item.last_name + "\n");
            //}

            ////Get User by ID
            //Console.Write("GoCoin User By ID" + "\n");
            //newUser = gs.GetGoCoinUserDetailByID("id");
            //Console.Write(newUser.first_name + " " + newUser.last_name + "\n");

            ////Edit User
            //Console.Write("GoCoin Edit User");
            //newUser = gs.EditGoCoinUser(newUser);
            //Console.Write(newUser.first_name + " " + newUser.last_name + "\n");

            ////Delete User
            //Console.Write("GoCoin Delete User" + "\n");
            //string strMSG = gs.DeleteGoCoinUser("id");
            //Console.Write(strMSG + "\n");

            ////Create Merchant
            //Console.WriteLine("GoCoin New Merchant" + "\n");
            //GoCoinMerchantService merchant = new GoCoinMerchantService();
            //GoCoinMerchant newMerchant = new GoCoinMerchant();
            //newMerchant.address_1 = "test address 1";
            //newMerchant.address_2 = "test address 2";
            //newMerchant.city = "NGP";
            //newMerchant.contact_name = "Pratik";
            //newMerchant.country_code = "91";
            //newMerchant.created_at = DateTime.Now.ToShortDateString();
            //newMerchant.description = "Test";
            //newMerchant.name = "Pratik";
            //newMerchant.phone = "123456789";
            //newMerchant.postal_code = "111111";
            //newMerchant.region = "ajks";
            //newMerchant.tax_id = "123456";
            //newMerchant.updated_at = DateTime.Now.ToShortDateString();
            //newMerchant.website = "www.google.com";
            //newMerchant = merchant.CreateGoCoinMerchant(newMerchant);
            //Console.Write(newMerchant.name + " " + newMerchant.description + "\n");

            ////List All Merchant
            //Console.WriteLine("GoCoin List of merchants" + "\n");
            //List<GoCoinMerchant> listMerchant = merchant.ListGoCoinMerchant();
            //foreach (var item in listMerchant)
            //{
            //    Console.Write(item.name + " " + item.description + "\n");
            //}

            ////Get User by Merchant
            //Console.Write("GoCoin Merchant By ID" + "\n");
            //newMerchant = merchant.GetGoCoinMerchantDetailByID("id");
            //Console.Write(newMerchant.name + " " + newMerchant.description + "\n");

            ////Edit Merchant
            //Console.Write("GoCoin Edit Merchant" + "\n");
            //newMerchant = merchant.EditGoCoinMerchant(newMerchant);
            //Console.Write(newMerchant.name + " " + newMerchant.description + "\n");

            ////Delete Merchant
            //Console.Write("GoCoin Delete Merchant");
            //strMSG = merchant.DeleteGoCoinMerchant("id");
            //Console.Write(strMSG + "\n");

            ////Invoice
            //Console.WriteLine("GoCoin Create New Invoice");
            //GoCoinInvoiceService invoice = new GoCoinInvoiceService();
            //GoCoinInvoices g = new GoCoinInvoices();
            //g.price_currency = "BTC";
            //g.base_price = 134;
            //g.base_price_currency = "USD";
            //g.confirmations_required = 6;
            //g.notification_level = "all";
            //g.callback_url = "https://www.example.com/gocoin/callback";
            //g.redirect_url = "https://www.example.com/redirect";
            //g = invoice.CreateGoCoinInvoices(g);
            //Console.WriteLine(g.price + " " + g.status + " " + g.updated_at + " " + g.created_at);
            //g = invoice.GetGoCoinInvoicesDetailByID("id");
            //Console.WriteLine("Get Invoice by ID: " + g.price + " " + g.price_currency);
            //Console.WriteLine("GoCoin Invoice Search:\n");
            //GoCoinInvoices gi = invoice.SearchGoCoinInvoices();
            //Console.WriteLine("Status: " + gi.status + " Page Info: Total " + gi.paging_info.total + " Page " + gi.paging_info.page + " Per_Page " + gi.paging_info.per_page + "\n");
            //List<GoCoinInvoices> lstInv = gi.invoices;
            //Console.WriteLine("GoCoin API Search Invoice List:\n");
            //for (int i = 0; i < lstInv.Count; i++)
            //{
            //    Console.Write(lstInv[i].base_price + " " + lstInv[i].callback_url + " " + lstInv[i].customer_city + "\n\n");
            //}

            ////Get All Account Listing.
            //GoCoinAccountService account = new GoCoinAccountService();
            //List<GoCoinAccount> accountListing = null;
            //accountListing = account.ListGoCoinAccounts();
            //Console.WriteLine("GoCoin Account Listing:\n");
            //for (int i = 0; i < accountListing.Count; i++)
            //{
            //    Console.Write(accountListing[i].id + " " + accountListing[i].currency_code + " " + accountListing[i].balance + "\n");
            //}

            Console.ReadLine();
        }
    }
}
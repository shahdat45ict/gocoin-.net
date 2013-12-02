using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoCoinAPI
{
    public interface IGoCoinClientService
    {
        // GoCoinUser
        List<GoCoinUser> ListGoCoinUser();
        GoCoinUser GetGoCoinUserDetailByID(string id);
        GoCoinUser GetCurrentGoCoinUser();
        GoCoinUser CreateGoCoinUser(GoCoinUser g);
        GoCoinUser EditGoCoinUser(GoCoinUser id);
        string DeleteGoCoinUser(string id);

        // GoCoinMerchant
        List<GoCoinMerchant> ListGoCoinMerchant();
        GoCoinMerchant GetGoCoinMerchantDetailByID(string id);
       List<GoCoinMerchant> GetGoCoinMerchantAccounturlbyMerchantid(string id);
        GoCoinMerchant GetGoCoinMerchantUserurl(string id);
        GoCoinMerchant GetGoCoinMerchantInvoiceurl(string id);
        GoCoinMerchant GetGoCoinMerchantTransactionsurl(string id);
        GoCoinMerchant CreateGoCoinMerchant(GoCoinMerchant merchant);
        GoCoinMerchant EditGoCoinMerchant(GoCoinMerchant merchant);
        string DeleteGoCoinMerchant(string id);

        // GoCoinInvoices
        List<GoCoinInvoices> ListGoCoinInvoices();
        GoCoinInvoices GetGoCoinInvoicesDetailByID(string id);
        GoCoinInvoices SearchGoCoinInvoices();
        GoCoinInvoices CreateGoCoinInvoices(GoCoinInvoices invoice);
        GoCoinInvoices EditGoCoinInvoices(GoCoinInvoices id);
        string DeleteGoCoinInvoices(string id);
        GoCoinInvoices GetGoCoinInvoicesDetailByMerchantID(string invoicedata, string id);

        //GoCoinApplications
        List<GoCoinApplications> ListGoCoinApplicationsByUserId(string id);

        //GoCoinaccounts
        List<GoCoinAccount> ListGoCoinAccountByMerchantId(string id);

    }
}

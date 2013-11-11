using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoCoinAPI
{
    public interface IGoCoinInvoiceServices
    {
        List<GoCoinInvoices> ListGoCoinInvoices();
        GoCoinInvoices GetGoCoinInvoicesDetailByID(string id);
        GoCoinInvoices SearchGoCoinInvoices();
        GoCoinInvoices CreateGoCoinInvoices(GoCoinInvoices invoice);
        GoCoinInvoices EditGoCoinInvoices(GoCoinInvoices id);
        string DeleteGoCoinInvoices(string id);
    }
}
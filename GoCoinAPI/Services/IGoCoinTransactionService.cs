using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoCoinAPI
{
    public interface IGoCoinTransactionService
    {
        string ListGoCoinTransactions();
        string GetGoCoinTransactionDetailByID(string id);
        string CreateGoCoinTransaction();
        string DeleteGoCoinMerchantUser(string id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoCoinAPI
{
    public interface IGoCoinMerchantService
    {
        List<GoCoinMerchant> ListGoCoinMerchant();
        GoCoinMerchant GetGoCoinMerchantDetailByID(string id);
        GoCoinMerchant CreateGoCoinMerchant(GoCoinMerchant merchant);
        GoCoinMerchant EditGoCoinMerchant(GoCoinMerchant merchant);
        string DeleteGoCoinMerchant(string id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoCoinAPI
{
    public interface IGoCoinMerchantUserService
    {
        string ListGoCoinMerchantUsers();
        string GetGoCoinMerchantUserDetailByID(string id);
        string CreateGoCoinMerchantUser();
        string EditGoCoinMerchantUser(string id);
        string DeleteGoCoinMerchantUser(string id);
    }
}
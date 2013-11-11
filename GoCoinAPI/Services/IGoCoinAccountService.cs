using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoCoinAPI
{
    public interface IGoCoinAccountService
    {
        List<GoCoinAccount> ListGoCoinAccounts();
        //string GetGoCoinAccountDetailByID(string id);
        //string CreateGoCoinAccount();
        //string EditGoCoinAccount(string id);
        //string DeleteGoCoinAccount(string id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GoCoinAPI
{
    public interface IGoCoinUserService
    {
        List<GoCoinUser> ListGoCoinUser();
        GoCoinUser GetGoCoinUserDetailByID(string id);
        GoCoinUser CreateGoCoinUser(GoCoinUser g);
        GoCoinUser EditGoCoinUser(GoCoinUser id);
        string DeleteGoCoinUser(string id);
    }
}
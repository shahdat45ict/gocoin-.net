using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoCoinAPI
{
     [Serializable]
    public class GoCoinApplications
    {
          public string id { get; set; }
          public string name { get; set; }
          public string secret { get; set; }
          public string redirect_uri { get; set; }
          public string created_at { get; set; }
          public string updated_at { get; set; }
          public string owner_id { get; set; }
          public string owner_type { get; set; }
          public string allow_grant_type_password { get; set; }
          public string allow_grant_type_authorization_code { get; set; }
    }
}

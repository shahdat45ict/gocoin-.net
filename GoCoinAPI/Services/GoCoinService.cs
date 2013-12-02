using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using GoCoinAPI;

namespace GoCoinAPI
{
    public class GoCoinService
    {
        public GoCoinService()
        {
            ObjectFactory.Initialize(
            x =>
            {
                x.For<IRepository<GoCoinUser>>().Use<Repository<GoCoinUser>>();
                x.For<IRepository<GoCoinMerchantUser>>().Use <Repository<GoCoinMerchantUser>>();
                x.For<IRepository<GoCoinMerchant>>().Use<Repository<GoCoinMerchant>>();
                x.For<IRepository<GoCoinInvoices>>().Use<Repository<GoCoinInvoices>>();
                x.For<IRepository<GoCoinAccount>>().Use<Repository<GoCoinAccount>>();
                x.For<IRepository<GoCoinDepositAddress>>().Use<Repository<GoCoinDepositAddress>>();
                x.For<IRepository<GoCoinClientService>>().Use<Repository<GoCoinClientService>>();
                x.For<IRepository<GoCoinApplications>>().Use<Repository<GoCoinApplications>>();
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepositoryManager.Repositories;

namespace RepositoryManager.Modals
{
    public class GoCoinFactory
    {
        public static IRepository<T> GetRepositoryInstance<T>() where T : class
        {
            return new Repository<T>();
        }
    }
}
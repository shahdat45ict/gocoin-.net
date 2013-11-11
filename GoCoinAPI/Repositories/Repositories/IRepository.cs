using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoCoinAPI
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get Type By ID
        /// <remarks>Type may refer Class</remarks>
        /// </summary>
        /// <param name="id">id for type T</param>
        /// <returns></returns>
        T GetById(string id, string callType);
        /// <summary>
        /// List search criteria data for specific Type.
        /// <remarks>Type may refer Class</remarks>
        /// </summary>
        /// <returns>Collection of Type</returns>
        T Search(string callType);
        /// <summary>
        /// List all data for specific Type.
        /// <remarks>Type may refer Class</remarks>
        /// </summary>
        /// <returns>Collection of Type</returns>
        List<T> GetAll(string callType);
        /// <summary>
        /// Create a new instance of Type.
        /// <remarks>Type may refer Class</remarks>
        /// </summary>
        /// <returns>New Created Type</returns>
        T Create(T user, string callType);
        /// <summary>
        /// Edit a Type.
        /// <remarks>Type may refer Class</remarks>
        /// </summary>
        /// <returns>Modified Type</returns>
        T Edit(T userID, string callType);
        /// <summary>
        /// Edit a Type.
        /// <remarks>Type may refer Class</remarks>
        /// </summary>
        /// <returns>Message</returns>
        string Delete(string ID, string callType);
    }
}
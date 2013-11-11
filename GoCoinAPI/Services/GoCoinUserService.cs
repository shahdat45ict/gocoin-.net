using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using GoCoinAPI;
using StructureMap;
using Logger;

namespace GoCoinAPI
{
    public class GoCoinUserService : IGoCoinUserService
    {
        #region Fields / Variables
        private ErrorManager _errLog = new ErrorManager("File");
        private GoCoinService _userObjInit;
        private IRepository<GoCoinUser> _userRepository;
        #endregion

        #region constructor
        /// <summary>
        /// Default constructor to initialize Repository layer
        /// </summary>
        public GoCoinUserService()
        {
            InitializeAppRepository();
        }
        #endregion

        #region IGoCoinUserService Members
        /// <summary>
        /// To initialize Repository layer
        /// </summary>
        public void InitializeAppRepository()
        {
            try
            {
                _userObjInit = new GoCoinService();
                _userRepository = ObjectFactory.GetInstance<IRepository<GoCoinUser>>();
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
                throw;
            }
        }
        #endregion

        public List<GoCoinUser> ListGoCoinUser()
        {
            List<GoCoinUser> _userListing = null;
            try
            {
                _userListing = _userRepository.GetAll("users");
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _userListing;
        }

        public GoCoinUser GetGoCoinUserDetailByID(string _id)
        {
            GoCoinUser _userByID = null;
            try
            {
                _userByID = _userRepository.GetById(_id, "users/:");
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _userByID;
        }

        public GoCoinUser CreateGoCoinUser(GoCoinUser _user)
        {
            GoCoinUser _newUser = null;
            try
            {
                _newUser = _userRepository.Create(_user, "users");
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _newUser;
        }

        public GoCoinUser EditGoCoinUser(GoCoinUser _editUser)
        {
            try
            {
                _editUser = _userRepository.Edit(_editUser, "users/:id");
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _editUser;
        }

        public string DeleteGoCoinUser(string _id)
        {
            string _strDeleteText = "";
            try
            {
                _strDeleteText = _userRepository.Delete(_id, "users/:");
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _strDeleteText;
        }
    }
}
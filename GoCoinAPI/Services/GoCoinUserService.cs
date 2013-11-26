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
        private GoCoinAccessTokenService _accessTokenRepository;
        private GoCoinAccessToken _accessToken;
        private GoCoinAuthorizationCode _authCode;
        #endregion

        #region constructor
        /// <summary>
        /// Default constructor to initialize Repository layer
        /// </summary>
        public GoCoinUserService()
        {
            InitializeAppRepository();
        }
        /// <summary>
        /// Parameterised constructor to initialize authorization code and repository layer
        /// </summary>
        public GoCoinUserService(GoCoinAuthorizationCode code)
        {
            _authCode = code;
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
                _accessTokenRepository = new GoCoinAccessTokenService();
                _accessToken = _accessTokenRepository.getAccessToken(_authCode);
                _userRepository = ObjectFactory.GetInstance<IRepository<GoCoinUser>>();
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
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

        public GoCoinUser GetCurrentGoCoinUser()
        {
            GoCoinUser _currentUser = null;
            try
            {
                _currentUser = _userRepository.GetById("user?access_token=" + _accessToken.access_token);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _currentUser;
        }

        public GoCoinUser GetGoCoinUserDetailByID(string _id)
        {
            GoCoinUser _userByID = null;
            try
            {
                _userByID = _userRepository.GetById( "users/{" + _id + "}/?access_token=" + _accessToken.access_token);
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
                _newUser = _userRepository.Create(_user, "users?access_token" + _accessToken.access_token);
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
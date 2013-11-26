using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logger;
using StructureMap;

namespace GoCoinAPI
{
    public class GoCoinAccountService : IGoCoinAccountService
    {
        #region Fields / Variables
        private ErrorManager _errLog = new ErrorManager("File");
        private GoCoinService _userObjInit;
        private IRepository<GoCoinAccount> _accountRepository;
        private GoCoinAccessTokenService _accessTokenRepository;
        private GoCoinAccessToken _accessToken;
        private GoCoinAuthorizationCode _authCode;
        #endregion

        #region constructor
        /// <summary>
        /// Default constructor to initialize Repository layer
        /// </summary>
        public GoCoinAccountService()
        {
            InitializeAppRepository();
        }
        ///
        public GoCoinAccountService(GoCoinAuthorizationCode code)
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
                _accountRepository = ObjectFactory.GetInstance<IRepository<GoCoinAccount>>();
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
                throw;
            }
        }
        #endregion

        public List<GoCoinAccount> ListGoCoinAccounts()
        {
            List<GoCoinAccount> _accountListing = null;
            _accountListing = _accountRepository.GetAll("merchants/:id/accounts");
            return _accountListing;
        }

        //public string GetGoCoinAccountDetailByID(string id)
        //{
        //    return "";
        //}

        //public string CreateGoCoinAccount()
        //{
        //    return "";
        //}

        //public string EditGoCoinAccount(string id)
        //{
        //    return "";
        //}

        //public string DeleteGoCoinAccount(string id)
        //{
        //    return "";
        //}
    }
}
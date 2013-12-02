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
    public class GoCoinClientService : IGoCoinClientService
    {
        #region Fields / Variables
        private ErrorManager _errLog = new ErrorManager("File");
        private GoCoinService _userObjInit;
        private GoCoinAccessTokenService _accessTokenRepository;
        private GoCoinAccessToken _accessToken;
        private GoCoinAuthorizationCode _authCode;

        private IRepository<GoCoinMerchant> _merchantRepository;
        private IRepository<GoCoinUser> _userRepository;
        private IRepository<GoCoinInvoices> _invoiceRepository;
        private IRepository<GoCoinApplications> _applicationsRepository;
        private IRepository<GoCoinAccount> _accountsRepository;
        private string accessToken { get; set; }

        #endregion

        #region constructor

        /// <summary>
        /// Default constructor to initialize Repository layer
        /// </summary>
        public GoCoinClientService()
        {
            InitializeAppRepository();
        }
        /// <summary>
        /// Parameterised constructor to initialize authorization code and repository layer
        /// </summary>
        public GoCoinClientService(GoCoinAuthorizationCode code)
        {
            _authCode = code;
            InitializeAppRepository();
        }

        #endregion

        #region IGoCoinClientService
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
                accessToken = _accessToken.access_token; 
                _userRepository = ObjectFactory.GetInstance<IRepository<GoCoinUser>>();
                _merchantRepository = ObjectFactory.GetInstance<IRepository<GoCoinMerchant>>();
                _invoiceRepository = ObjectFactory.GetInstance<IRepository<GoCoinInvoices>>();
                _applicationsRepository = ObjectFactory.GetInstance<IRepository<GoCoinApplications>>();
                _accountsRepository = ObjectFactory.GetInstance<IRepository<GoCoinAccount>>();
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
        }
        #endregion

        #region User Methods

        public List<GoCoinUser> ListGoCoinUser()
        {
            List<GoCoinUser> _userListing = null;
            try
            {
                _userListing = _userRepository.GetAll("users", accessToken);
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
                _currentUser = _userRepository.GetById("user", accessToken);
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
                _userByID = _userRepository.GetById("users/" + _id, accessToken);
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
                _newUser = _userRepository.Create(_user, "users", accessToken);
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
                _editUser = _userRepository.Edit(_editUser, "users/" + _editUser.id, accessToken);
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
                _strDeleteText = _userRepository.Delete(_id, "users/" + _id, accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _strDeleteText;
        }

        #endregion

        #region Merchant Methods

        public List<GoCoinMerchant> ListGoCoinMerchant()
        {
            List<GoCoinMerchant> _lstMerchant = null;
            try
            {
                _lstMerchant = _merchantRepository.GetAll("merchants", accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _lstMerchant;
        }

        //public GoCoinUser GetCurrentGoCoinMerchant(string _accessToken)
        //{
        //    GoCoinUser _currentUser = null;
        //    try
        //    {
        //        _currentUser = _userRepository.GetById("merchant",_accessToken);
        //    }
        //    catch (Exception _ex)
        //    {
        //        _errLog.LogError("GoCoinAPI", _ex);
        //    }
        //    return _currentUser;
        //}

        public GoCoinMerchant GetGoCoinMerchantDetailByID(string _id)
        {
            GoCoinMerchant _merchant = null;
            try
            {
                _merchant = _merchantRepository.GetById("merchants/" + _id, accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _merchant;
        }

        public List<GoCoinMerchant> GetGoCoinMerchantAccounturlbyMerchantid(string _id)
        {
            List<GoCoinMerchant> _merchant = null;
            try
            {
                _merchant = _merchantRepository.GetListById("merchants/" + _id + "/accounts", accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _merchant;
        }

        public GoCoinMerchant GetGoCoinMerchantUserurl(string _id)
        {
            GoCoinMerchant _merchant = null;
            try
            {
                _merchant = _merchantRepository.GetById("merchants/" + _id + "/users", accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _merchant;
        }

        public GoCoinMerchant GetGoCoinMerchantInvoiceurl(string _id)
        {
            GoCoinMerchant _merchant = null;
            try
            {
                _merchant = _merchantRepository.GetById("merchants/" + _id + "/invoices", accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _merchant;
        }

        public GoCoinMerchant GetGoCoinMerchantTransactionsurl(string _id)
        {
            GoCoinMerchant _merchant = null;
            try
            {
                _merchant = _merchantRepository.GetById("merchants/" + _id + "/transactions", accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _merchant;
        }



        public GoCoinMerchant CreateGoCoinMerchant(GoCoinMerchant _merchant)
        {
            GoCoinMerchant _newMerchant = null;
            try
            {
                _newMerchant = _merchantRepository.Create(_merchant, "merchants", accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _newMerchant;
        }

        public GoCoinMerchant EditGoCoinMerchant(GoCoinMerchant _editMerchant)
        {
            try
            {
                _editMerchant = _merchantRepository.Edit(_editMerchant, "merchants/" + _editMerchant.id, accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _editMerchant;
        }

        public string DeleteGoCoinMerchant(string _id)
        {
            string _strMSG = "";
            try
            {
                _strMSG = _merchantRepository.Delete(_id, "merchants/" + _id, accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _strMSG;
        }

        #endregion

        #region Invoices Methods

        public List<GoCoinInvoices> ListGoCoinInvoices()
        {
            List<GoCoinInvoices> _lstInvoices = null;
            try
            {
                _lstInvoices = _invoiceRepository.GetAll("invoices", accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _lstInvoices;
        }

        public GoCoinInvoices SearchGoCoinInvoices()
        {
            GoCoinInvoices _lstInvoices = null;
            _lstInvoices = _invoiceRepository.Search("invoices/search?merchant_id=:merchant_id&status=:status&start_time=:start_time&end_time=:end_time&page=:page_number&per_page=:per_page", accessToken);
            return _lstInvoices;
        }

        public GoCoinInvoices GetGoCoinInvoicesDetailByID(string _id)
        {
            GoCoinInvoices _invoiceDetail = null;
            try
            {
                _invoiceDetail = _invoiceRepository.GetById("invoices/" + _id, accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _invoiceDetail;
        }

        public GoCoinInvoices GetGoCoinInvoicesDetailByMerchantID(string _data, string _id)
        {
            GoCoinInvoices _invoiceDetail = null;
            try
            {

                _invoiceDetail = _invoiceRepository.GetByIdPostRequest("merchants/" + _id + "/invoices", _data , accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _invoiceDetail;
        
        }

        public GoCoinInvoices CreateGoCoinInvoices(GoCoinInvoices _invoice)
        {
            GoCoinInvoices _newInvoice = null;
            try
            {
                _newInvoice = _invoiceRepository.Create(_invoice, "merchants/" + _invoice.merchant_id + "/invoices", accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _newInvoice;
        }

        public GoCoinInvoices EditGoCoinInvoices(GoCoinInvoices _editInvoice)
        {
            try
            {
                _editInvoice = _invoiceRepository.Edit(_editInvoice, "invoices/" + _editInvoice.id, accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _editInvoice;
        }

        public string DeleteGoCoinInvoices(string _id)
        {
            string _strMSG = "";
            try
            {
                _strMSG = _invoiceRepository.Delete(_id, "invoices/", accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _strMSG;
        }

        #endregion

        #region Application Methods
        public List<GoCoinApplications> ListGoCoinApplicationsByUserId(string _id)
        {
            List<GoCoinApplications> _ApplicationListByID = null;
            try
            {
                _ApplicationListByID = _applicationsRepository.GetListById("users/" + _id + "/applications", accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _ApplicationListByID;
        }

        #endregion

        #region Accounts Methods
        public List<GoCoinAccount> ListGoCoinAccountByMerchantId(string _id)
        {
            List<GoCoinAccount> _ApplicationListByID = null;
            try
            {
                _ApplicationListByID = _accountsRepository.GetListById("merchants/" + _id + "/accounts", accessToken);
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _ApplicationListByID;
        }
        #endregion



        
    }
}

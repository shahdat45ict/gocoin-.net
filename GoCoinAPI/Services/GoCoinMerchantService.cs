using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logger;
using GoCoinAPI;
using StructureMap;

namespace GoCoinAPI
{
    public class GoCoinMerchantService : IGoCoinMerchantService
    {
        #region Fields / Variables
        private ErrorManager _errLog = new ErrorManager("File");
        private IRepository<GoCoinMerchant> _merchantRepository;
        #endregion

        #region constructor
        /// <summary>
        /// Default constructor to initialize Repository layer
        /// </summary>
        public GoCoinMerchantService()
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
                _merchantRepository = ObjectFactory.GetInstance<IRepository<GoCoinMerchant>>();
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
                throw;
            }
        }
        #endregion

        public List<GoCoinMerchant> ListGoCoinMerchant()
        {
            List<GoCoinMerchant> _lstMerchant = null;
            try
            {
                _lstMerchant = _merchantRepository.GetAll("merchants");
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _lstMerchant;
        }

        public GoCoinMerchant GetGoCoinMerchantDetailByID(string _id)
        {
            GoCoinMerchant _merchant = null;
            try
            {
                _merchant = _merchantRepository.GetById(_id, "merchants/:");
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
                _newMerchant = _merchantRepository.Create(_merchant, "merchants");
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
                _editMerchant = _merchantRepository.Edit(_editMerchant, "merchants/:id");
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
                _strMSG = _merchantRepository.Delete(_id, "merchants/:");
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
            }
            return _strMSG;
        }
    }
}
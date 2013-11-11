using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoCoinAPI;
using Logger;
using StructureMap;

namespace GoCoinAPI
{
    public class GoCoinInvoiceService : IGoCoinInvoiceServices
    {
        #region Fields / Variables
        private ErrorManager _errLog = new ErrorManager("File");
        private IRepository<GoCoinInvoices> _invoiceRepository;
        #endregion

        #region constructor
        /// <summary>
        /// Default constructor to initialize Repository layer
        /// </summary>
        public GoCoinInvoiceService()
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
                _invoiceRepository = ObjectFactory.GetInstance<IRepository<GoCoinInvoices>>();
            }
            catch (Exception _ex)
            {
                _errLog.LogError("GoCoinAPI", _ex);
                throw;
            }
        }
        #endregion

        public List<GoCoinInvoices> ListGoCoinInvoices()
        {
            List<GoCoinInvoices> _lstInvoices = null;
            try
            {
                _lstInvoices = _invoiceRepository.GetAll("invoices");
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
           _lstInvoices = _invoiceRepository.Search("invoices/search?merchant_id=:merchant_id&status=:status&start_time=:start_time&end_time=:end_time&page=:page_number&per_page=:per_page");
           return _lstInvoices;
       }

       public GoCoinInvoices GetGoCoinInvoicesDetailByID(string _id)
       {
           GoCoinInvoices _invoiceDetail = null;
           try
           {
               _invoiceDetail = _invoiceRepository.GetById(_id, "invoices/:");
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
               _newInvoice = _invoiceRepository.Create(_invoice, "merchants/:id/invoices");
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
               _editInvoice = _invoiceRepository.Edit(_editInvoice, "invoices/:id");
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
               _strMSG = _invoiceRepository.Delete(_id, "invoices/:");
           }
           catch (Exception _ex)
           {
               _errLog.LogError("GoCoinAPI", _ex);
           }
           return _strMSG;
       }
    }
}
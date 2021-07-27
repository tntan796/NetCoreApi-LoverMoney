using BLL.Intefaces;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FaqService : IFaqService
    {
        private readonly IFaqRepository _faqRepository;
        private readonly ILogger<FaqService> _logger;

        public FaqService(
            IFaqRepository faqRepository, ILogger<FaqService> logger)
        {
            _faqRepository = faqRepository;
            _logger = logger;
        }

        public Task<int> DeleteFaq(int id)
        {
            try
            {
                return this._faqRepository.DeleteFaq(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<Faq> GetFaqById(int id)
        {
            try
            {
                return this._faqRepository.GetFaqById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public ResponseList<IEnumerable<Faq>> GetFaqs(FilterBase filter)
        {
            try
            {
                return this._faqRepository.GetFaqs(filter);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public Task<int> SetFaq(Faq faq)
        {
            try
            {
                return this._faqRepository.SetFaq(faq);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}

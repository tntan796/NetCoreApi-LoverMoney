using Models;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IFaqService
    {
        ResponseList<IEnumerable<Faq>> GetFaqs(FilterBase filter);
        Task<Faq> GetFaqById(int id);
        Task<int> SetFaq(Faq faq);
        Task<int> DeleteFaq(int id);
    }
}

using Models;
using Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFaqRepository
    {
        ResponseList<IEnumerable<Faq>> GetFaqs(FilterBase filter);
        Task<Faq> GetFaqById(int id);
        Task<int> SetFaq(Faq faq);
        Task<int> DeleteFaq(int id);
    }
}

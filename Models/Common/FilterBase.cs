using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Models.Common
{
    public class FilterBase
    {
        public FilterBase()
        {
        }
        //[Required(ErrorMessage = "projectCd không được trống")]
        [FromQuery(Name = "filter")]
        [DefaultValue("")]
        public string filter { get; set; }
        [FromQuery(Name = "offSet")]
        [DefaultValue(0)]
        public int? offSet { get; set; }
        [FromQuery(Name = "pageSize")]
        [DefaultValue(0)]
        public int? pageSize { get; set; }
        public FilterBase(string filter = "", int? offSet = 0, int? pageSize = 10)
        {
            this.filter = filter;
            this.offSet = offSet;
            this.pageSize = pageSize;
        }
    }


    public class FilterBasePackage: FilterBase
    {
        public bool? IsIncome { get; set; } = null;
    }
}

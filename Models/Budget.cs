using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Budget
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string Note { set; get; }
        public decimal Amount { set; get; }
        public string CategoryId { set; get; }
        public string CurrencyCode { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
    }
}

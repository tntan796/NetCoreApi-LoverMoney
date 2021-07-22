using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Transaction
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public decimal Amount { set; get; }
        public DateTime CreateAt { set; get; }
        public bool ExportReport { set; get; }
        public string Note { set; get; }
        public bool Remind { set; get; }
        public string Image { set; get; }
        public string Campaign { set; get; }
        public int Latitude { set; get; }
        public int Longtitude { set; get; }
        public string AccountId { set; get; }
        public string UserName { set; get; }
        public string CategoryId { set; get; }
        public string CategoryName { set; get; }
        public string EditByUserId { set; get; }
        public string With { set; get; }
        public string Metadata { set; get; }
        public string WalletId { set; get; }
        public string WalletName { set; get; }

    }
}

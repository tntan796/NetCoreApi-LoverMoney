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
        public string PackageId { set; get; }
        public string EditByUserId { set; get; }
        public string With { set; get; }
        public string Metadata { set; get; }
        public string WalletId { set; get; }

    }

    public class TransactionResponse: Transaction
    {
        public string WalletName { set; get; }
        public string PackageName { set; get; }
        public string UserName { set; get; }
    }

    public class TransactionRangeDate
    {
        public string MonthName { set; get; }
        public string StartDay { set; get; }
        public string EndDay { set; get; }
        public string Month { set; get; }
        public string Year { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
    }
}

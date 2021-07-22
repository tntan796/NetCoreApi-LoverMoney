using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Bank
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string CountryCode { set; get; }
        public string Icon { set; get; }
        public string MetaSearch { set; get; }
        public bool Otp { set; get; }
        public bool IsFree { set; get; }
        public bool IsDebug { set; get; }
        public bool HasBalance { set; get; }
        public string Browser { set; get; }
    }
}

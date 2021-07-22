using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Wallet
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string UserId { set; get; }
        public decimal Amount { set; get; }
        public string Icon { set; get; }
    }
}

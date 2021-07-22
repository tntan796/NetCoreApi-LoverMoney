using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Account
    {
        public string Id { set; get; }
        public int StatusId { set; get; }
        public string UserId { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public DateTime CreatedDate { set; get; }
        public string CreateBy { set; get; }
        public string OldPassword { set; get; }
    }
}

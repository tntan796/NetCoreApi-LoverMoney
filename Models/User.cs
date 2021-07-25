using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Models
{
    public class User
    {
        public string Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string IdentityNo { set; get; }
        public int StatusId { set; get; }
    }
}

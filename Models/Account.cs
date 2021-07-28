using Models.Authen;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

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
        public bool IsVip { set; get; }
        public string RoleId { set; get; }
    }

    public class AccountReponse: Account
    {
        public string StatusName { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string IdentityNo { set; get; }
    }

    public class AccountLogin
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}

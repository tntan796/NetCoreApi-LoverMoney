using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Models.Authen
{
    public class AuthenticateResponse
    {
        public String Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }

        public AuthenticateResponse(Account account, string token, string refreshToken)
        {
            Id = account.Id;
            Username = account.UserName;
            Token = token;
            RefreshToken = refreshToken;
        }
    }
}

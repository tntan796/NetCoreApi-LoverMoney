using BLL.Intefaces;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.Authen;
using Models.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<Account> _logger;
        private readonly AppSettings _appSettings;
        private IConfiguration _configuration;
        public AccountService(
            IAccountRepository accountRepository,
            ILogger<Account> logger,
            IOptions<AppSettings> appSettings,
            IConfiguration configuration,
            IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _logger = logger;
            _appSettings = appSettings.Value;
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await this._accountRepository.GetAccountByUserNamePassword(model.Username, SecurityHelper.GetMD5Hash(model.Password));
            if (user == null)
            {
                throw new Exception("Tài khoản, mật khẩu không đúng!");
            }
            if (user.StatusId == (int)AccountStatus.Lock)
            {
                throw new Exception("Tài khoản, mật khẩu không đúng!");
            }
            if (user.StatusId == (int)AccountStatus.New)
            {
                throw new Exception("Tài khoản chưa xác thực");
            }
            var token = GenerateJwtToken(user);
            return new AuthenticateResponse(user, token, "");
        }

        public Task<string> DeleteAccount(string id)
        {
            try
            {
                return this._accountRepository.DeleteAccount(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public string GenerateJwtToken(AccountReponse account)
        {
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new[] { new Claim("id", account.Id), new Claim("UserName", account.UserName) }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //return tokenHandler.WriteToken(token);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Name, account.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
                _configuration["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public string GenerateToken()
        {
            var randomNumber = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public Task<AccountReponse> GetAccountById(string id)
        {
            try
            {
                return this._accountRepository.GetAccountById(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
        public ResponseList<IEnumerable<AccountReponse>> GetAccounts(FilterBase filter)
        {
            try
            {
                return this._accountRepository.GetAccounts(filter);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<string> SetAccount(AccountReponse account)
        {
            try
            {
                account.Password = SecurityHelper.GetMD5Hash(account.Password);
                string userId = await this._userRepository.SetUser(new User()
                {
                    Email = account.Email,
                    FirstName = account.FirstName,
                    Phone = account.Phone
                });
                account.UserId = userId;
                AccountReponse checkExistsAccount = await _accountRepository.GetAccountByUserName(account.UserName);
                if (checkExistsAccount != null)
                {
                    throw new Exception("Dupplicate Account");
                }
                return await this._accountRepository.SetAccount(account);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
        public async Task<string> SetAccountUser(AccountReponse account)
        {
            try
            {
                account.Password = SecurityHelper.GetMD5Hash(account.Password);
                AccountReponse checkExistsAccount = await _accountRepository.GetAccountByUserName(account.UserName);
                if (checkExistsAccount != null)
                {
                    throw new Exception("Dupplicate Account");
                }
                return await this._accountRepository.SetAccountUser(account);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}

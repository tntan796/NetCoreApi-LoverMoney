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
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<Account> _logger;
        private readonly AppSettings _appSettings;
        private IConfiguration _configuration;
        public AccountService(
            IAccountRepository accountRepository,
            ILogger<Account> logger,
            IOptions<AppSettings> appSettings,
            IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _logger = logger;
            _appSettings = appSettings.Value;
            _configuration = configuration;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await  this._accountRepository.GetAccountByUserNamePassword(model.Username, model.Password);
            if (user == null) {
                return null;
            }
            var token = GenerateJwtToken(user);
            return new AuthenticateResponse(user, token, "");
        }

        public Task<BaseValidate> DeleteAccount(string id)
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

        public string GenerateJwtToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", account.Id) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
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

        public string SetAccount(Account account)
        {
            try
            {
                return this._accountRepository.SetAccount(account);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.StackTrace);
                throw ex;
            }
        }
    }
}

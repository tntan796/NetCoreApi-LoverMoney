using BLL.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Authen;
using System;
using System.Threading.Tasks;

namespace LoverMoney.Controllers
{
    public class AuthenticationController : Controller
    {
        private IAccountService _accountService;

        public AuthenticationController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _accountService.Authenticate(model);
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        //[AllowAnonymous]
        //[HttpPost("refresh-token")]
        //public IActionResult RefreshToken()
        //{
        //    var refreshToken = Request.Cookies["refreshToken"];
        //    var response = _userService.RefreshToken(refreshToken, ipAddress());

        //    if (response == null)
        //        return Unauthorized(new { message = "Invalid token" });

        //    setTokenCookie(response.RefreshToken);

        //    return Ok(response);
        //}

        //[HttpPost("revoke-token")]
        //public IActionResult RevokeToken([FromBody] RevokeTokenRequest model)
        //{
        //    // accept token from request body or cookie
        //    var token = model.Token ?? Request.Cookies["refreshToken"];
        //    if (string.IsNullOrEmpty(token))
        //        return BadRequest(new { message = "Token is required" });
        //    var response = _userService.RevokeToken(token, ipAddress());

        //    if (!response)
        //        return NotFound(new { message = "Token not found" });

        //    return Ok(new { message = "Token revoked" });
        //}

        //private void setTokenCookie(string token)
        //{
        //    var cookieOptions = new CookieOptions
        //    {
        //        HttpOnly = true,
        //        Expires = DateTime.UtcNow.AddDays(7)
        //    };
        //    Response.Cookies.Append("refreshToken", token, cookieOptions);
        //}

        //private string ipAddress()
        //{
        //    if (Request.Headers.ContainsKey("X-Forwarded-For"))
        //        return Request.Headers["X-Forwarded-For"];
        //    else
        //        return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        //}
    }
}
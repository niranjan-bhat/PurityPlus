using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurityPlus.Server.Contracts;
using System.Data;
using System.Security.Claims;

namespace PurityPlus.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public IAccountService _accountService { get; }

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) {
                return BadRequest();
            }

            await _accountService.RegisterAsync(email, password);

            return Ok();
        }

        [Authorize(Roles="admin")]
        [HttpPost("RegisterUserWithRole")]
        public async Task<IActionResult> RegisterUser(string email, string password, string role)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                return BadRequest();
            }

            await _accountService.RegisterWithRolesAsync(email, password,role);

            return Ok();
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest();
            }

            var authenticatedUser = await _accountService.LoginAsync(email, password);
            var userRoles = await _accountService.GetUserRolesByUserEmail(email);

            var authToken = _tokenService.GenerateAccessToken(authenticatedUser, userRoles);
            var refreshToken = _tokenService.GenerateRefreshToken();
            return Ok(authToken);
        }

        //[HttpGet("RefreshToken")]
        //public async Task<IActionResult> RefreshToken(string authToken, string refreshToken)
        //{
        //    if (string.IsNullOrEmpty(authToken) || string.IsNullOrEmpty(refreshToken))
        //        return BadRequest();

        //    var claims = _tokenService.GetClaimsFromAccessToken(authToken);

        //    var newRefreshToken = _tokenService.GenerateRefreshToken();
            
        //    return Ok(newRefreshToken);
        //}
    }
}

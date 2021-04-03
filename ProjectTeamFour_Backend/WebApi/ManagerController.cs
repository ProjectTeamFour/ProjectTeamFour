using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProjectTeamFour_Backend.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ProjectTeamFour_Backend.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace ProjectTeamFour_Backend.WebApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly IBackendMemberService _backendMemberService;

        public ManagerController(IConfiguration config,ILogger<ManagerController> logger,IBackendMemberService backendMemberService)
        {
            _config = config;
            _logger = logger;
            _backendMemberService = backendMemberService;
        }

        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel loginVM)
        {
            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + " Token控制器POST方法被呼叫");

            IActionResult response = Unauthorized();
            var user = GetBackendAuthentication(loginVM);
            if(user.IsSuccess==true)
            {
                var tokenString = GenerateJsonWebToken(loginVM);
                response = Ok(new {token=tokenString});
                Response.Cookies.Append("R", user.Msg);

            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginVM.Username),
                    new Claim("FullName","test"),
                    new Claim(ClaimTypes.Role, "Administrator"),

                };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties()
            {
                IsPersistent = false, //瀏覽器關閉即刻登出

            };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return response;
        }


        private BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult> GetBackendAuthentication(LoginViewModel loginVM)
        {
            var manager = _backendMemberService.GetBackendAuthentication(loginVM);
           
            return manager;
          
        }


        private string GenerateJsonWebToken(LoginViewModel loginVM)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

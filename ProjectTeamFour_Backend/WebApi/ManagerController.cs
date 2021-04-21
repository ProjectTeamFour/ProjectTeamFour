using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

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

        private readonly IBackendMemberService _backendMemberService;

        public ManagerController(IConfiguration config, IBackendMemberService backendMemberService)
        {
            _config = config;
            _backendMemberService = backendMemberService;
        }


        /// <summary>
        /// 接收前端傳來之帳密驗證
        /// </summary>
        /// <param name="loginVM"></param>
        /// <returns></returns>

        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel loginVM)
        {
            IActionResult response = Unauthorized();
            var user = GetBackendAuthentication(loginVM);
            if (user.IsSuccess == true)
            {
                var tokenString = GenerateJsonWebToken(loginVM);
                response = Ok(new { token = tokenString });
                Response.Cookies.Append("adm", user.Msg);
                Response.Cookies.Append("UserEmail", loginVM.MemberRegEmail);
            }


            //建立 cookie 驗證
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginVM.MemberRegEmail),
                    new Claim(ClaimTypes.Role, "manager"),
                };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //建立cookie持有使用者資訊
            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
            // Cookie 是否為持續性
            var authProperties = new AuthenticationProperties()
            {
                IsPersistent = false,

            };
            // 建立加密的 cookie ，並將它新增至目前的回應
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            return response;
        }

        /// <summary>
        /// 登出目前使用者並刪除cookie
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        ///  //驗證使用者帳密
        /// </summary>
        /// <param name="loginVM"></param>
        /// <returns></returns>
        private BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult> GetBackendAuthentication(LoginViewModel loginVM)
        {
            var manager = _backendMemberService.GetBackendAuthentication(loginVM);
            return manager;

        }

        /// <summary>
        ///  產生 JWT Token
        /// </summary>
        /// <param name="loginVM"></param>
        /// <returns></returns>
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

            // - phil註解
            //var token2 = new JwtSecurityToken(

            //    new JwtHeader(
            //        new SigningCredentials(
            //            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])), 
            //            SecurityAlgorithms.HmacSha256)), 

            //    new JwtPayload( issuer: "CashUser",
            //                    audience: "CashAudience",
            //                    claims: null,
            //                    notBefore: DateTime.UtcNow,
            //                    expires: DateTime.UtcNow.AddMinutes(30))
            //    );

    }
}

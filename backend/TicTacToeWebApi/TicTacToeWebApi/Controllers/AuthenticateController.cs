using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Authorization;
using TicTacToeDTO;
using TicTacToeService;
using TicTacToeService.Impl;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using TicTacToeDomain;

namespace TicTacToeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticateController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AuthenticateController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginDTO model)
        {
            User user = _loginService.GetUsingCredentials(model);
            if (user == null) return Unauthorized();
            
            var authClaims = new List<Claim>
            {
                new (ClaimTypes.Name, user.Id.ToString()),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mykeyvegait21042022"));

            var token = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
            
        }

    }
}

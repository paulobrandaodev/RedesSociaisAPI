using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RedeSocial.Data;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace RedeSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly RedeSocialContext _context;

        public LoginController(RedeSocialContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Logar(string email, string senha)
        {
            var usuario = _context.Usuarios.Where(x => x.Email == email).FirstOrDefault();

            if (usuario == null)
                return NotFound();

            if(BCrypt.Net.BCrypt.Verify(senha, usuario.Senha))
            {

                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.GivenName, usuario.Nome),
                    new Claim(ClaimTypes.Role, "Admin"),

                    // armazena na Claim personalizada role o tipo de usuário que está logado
                    new Claim("RolePersonalizada", "Admin"),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("cripto-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                        issuer: "cripto.webAPI",
                        audience: "cripto.webAPI",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                );
                var token = new JwtSecurityTokenHandler().WriteToken(meuToken);

                return Ok(new {token = token });
            }

            return Unauthorized();
        }
    }
}

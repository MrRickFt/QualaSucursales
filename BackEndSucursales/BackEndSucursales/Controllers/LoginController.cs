using BackEndSucursales.Domain.IServices;
using BackEndSucursales.Domain.Models;
using BackEndSucursales.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndSucursales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _config;

        public LoginController(ILoginService loginService, IConfiguration config)
        {
            _loginService = loginService;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Usuario usuario)
        {
            try
            {
                usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
                var user = await _loginService.ValidateUser(usuario);
                if(user == null)
                {
                    return BadRequest(new { message = " Usuario o contraseña o rol incorrecto" });
                }
                string tokenString = JwtConfigurator.GetToken(user, _config);
                return Ok(new { token = tokenString });
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

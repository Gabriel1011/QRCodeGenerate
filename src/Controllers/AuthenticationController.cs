using Microsoft.AspNetCore.Mvc;
using QRCodeGenerate.Services;

namespace QRCodeGenerate.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly TokenService _tokenService;

        public AuthenticationController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("Token")]
        public IActionResult GenerateToken() => Ok(_tokenService.GenerateToken());
    }
}

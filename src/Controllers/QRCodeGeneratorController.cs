using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QRCodeGenerate.Services;
using QRCodeGenerator.Services;

namespace QRCodeGenerator.Controllers
{
    [Authorize]
    public class QRCodeGeneratorController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly QrCodeGeneratorService _qrCodeGeneratorService;

        public QRCodeGeneratorController(IConfiguration configuration, QrCodeGeneratorService qrCodeGeneratorService)
        {
            _configuration = configuration;
            _qrCodeGeneratorService = qrCodeGeneratorService;
        }

        [HttpGet("qrcode/{text}")]
        public IActionResult GetQrCode(string text)
        {
            var image = _qrCodeGeneratorService.GenerateByteArray(text);
            return File(image, "image/jpeg");
        }
    }
}

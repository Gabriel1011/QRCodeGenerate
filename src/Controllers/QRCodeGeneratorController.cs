using Microsoft.AspNetCore.Mvc;
using QRCodeGenerator.Services;

namespace QRCodeGenerator.Controllers
{
    public class QRCodeGeneratorController : Controller
    {
        [HttpGet("qrcode/{text}")]
        public IActionResult GetQrCode(string text)
        {
            var image = QrCodeGenerator.GenerateByteArray(text);
            return File(image, "image/jpeg");
        }
    }
}

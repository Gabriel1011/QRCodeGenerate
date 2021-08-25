using QRCoder;
using System.Drawing;
using System.IO;

namespace QRCodeGenerator.Services
{
    public class QrCodeGeneratorService
    {
        public Bitmap GenerateImage(string text)
        {
            var qrGenerator = new QRCoder.QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(text, QRCoder.QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }

        public byte[] GenerateByteArray(string text)
        {
            var image = GenerateImage(text);
            return ImageToByte(image);
        }

        private byte[] ImageToByte(Image img)
        {
            using var stream = new MemoryStream();
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }
    }
}

using QRCoder;
using System.Drawing;
using System.IO;

namespace QRCodeGenerator.Services
{
    public static class QrCodeGenerator
    {
        public static Bitmap GenerateImage(string text)
        {
            var qrGenerator = new QRCoder.QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(text, QRCoder.QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(10);
            return qrCodeImage;
        }

        public static byte[] GenerateByteArray(string url)
        {
            var image = GenerateImage(url);
            return ImageToByte(image);
        }

        private static byte[] ImageToByte(Image img)
        {
            using var stream = new MemoryStream();
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }
    }
}

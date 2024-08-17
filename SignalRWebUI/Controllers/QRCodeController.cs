using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string value)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = qrCodeGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap bitmap = qrCode.GetGraphic(10))
                {
                    bitmap.Save(memoryStream, ImageFormat.Png);
                    ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return View();
        }
    }
}

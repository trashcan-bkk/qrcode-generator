using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace qrcode_generator.Controllers
{
    public class QRCodeController : ControllerBase
    {

        [HttpPost("qr/generate/{requestData.QRCodeURL}")]
        public Bitmap GenerateQRCode(Data requestData)
        {
            var requestString = requestData.QRCodeURL;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(requestString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }

        public class Data 
        {
            public string QRCodeURL { get; set; }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace QR_Digital_Entry_Log.Controllers
{
    [Route("qr")]
    public class QrController : Controller
    {
        // GET /qr/1  → 1번 location에 대한 QR 코드 이미지 반환
        [HttpGet("{locationId}")]
        public IActionResult Generate(int locationId)
        {
            // QR 안에 넣을 URL (지금은 localhost 기준)
            // 실행 중인 포트 번호에 맞게 수정되도록 동적으로 생성
            var url = $"{Request.Scheme}://{Request.Host}/?locationId={locationId}";

            using var qrGenerator = new QRCodeGenerator();
            using QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);

            var qrCode = new PngByteQRCode(qrCodeData);
            byte[] bytes = qrCode.GetGraphic(20); // 20은 크기

            return File(bytes, "image/png");
        }
    }
}

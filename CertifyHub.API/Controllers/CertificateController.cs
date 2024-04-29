using CertifyHub.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace CertifyHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Cloudinary _cloudinary;

        public CertificateController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

            Account cloudinaryAccount = new Account(
                "dsmowyioy",
                "264385448398359",
                "66y0b2xzMkyfwImAMPKPENbUj5c"
            );

            _cloudinary = new Cloudinary(cloudinaryAccount);
        }

        [HttpPost("GenerateCertificate")]
        public async Task<IActionResult> GenerateCertificate([FromBody] CertificateDto certificateDto)
        {

            try
            {
                if (certificateDto.TOTAL_GRADE_SUM > 50)
                {
                    var relativeImagePath = certificateDto.QRCODEURL.TrimStart('/');
                    var imageFolderPath = "D:\\Training\\VisualStudioProjects\\CertifyHub.API\\CertifyHub.API"; //*************************
                    var imagePath = Path.Combine(imageFolderPath, relativeImagePath);

                    var uploadResult = await UploadToCloudinary(imagePath);

                    if (uploadResult.Error != null)
                    {
                        return BadRequest($"Error uploading photo to Cloudinary: {uploadResult.Error.Message}");
                    }

                    var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "CertificateTemplate.html");
                    var templateContent = System.IO.File.ReadAllText(templatePath);

                    templateContent = templateContent.Replace("{{FIRSTNAME}}", certificateDto.FIRSTNAME)
                                                     .Replace("{{LASTNAME}}", certificateDto.LASTNAME)
                                                     .Replace("{{CourseName}}", certificateDto.CourseName)
                                                     .Replace("{{TOTAL_GRADE_SUM}}", certificateDto.TOTAL_GRADE_SUM.ToString())
                                                     .Replace("{{DATE}}", DateTime.Now.ToString("dd MMM, yyyy"))
                                                     .Replace("{{QRCODEURL}}", uploadResult.SecureUrl.AbsoluteUri);

                    Console.WriteLine("HTML Content:");
                    Console.WriteLine(templateContent);

                    var httpClient = _httpClientFactory.CreateClient();

                    var apiUrl = "https://api.pdf.co/v1/pdf/convert/from/html";

                    var apiKey = "eslamalshqeirat1@gmail.com_9097D73CRM1ubt3Xlw4refK0SLSM179g9NrdTUzWaz9O5s51tL29HrwS8W0wY6NY3KZ9gR7xm8xdO9BZ00yu4OQ78AP0m0bE48g3D5sVFsKGp7c7l01MdKI31W7KoNxgFV53TN0V68X332Dg440hcbbA75"; // Replace with your PDF.co API key

                    var pdfCoData = new
                    {
                        name = "certificate.pdf",
                        html = templateContent,
                        inline = true,
                        xApiKey = apiKey,
                        pageSize = "A3"
                    };


                    var jsonData = JsonSerializer.Serialize(new { html = templateContent });

                    httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);

                    var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(apiUrl, jsonContent);

                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("API Response:");
                    Console.WriteLine(responseContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonSerializer.Deserialize<JsonDocument>(apiResponse);

                        var pdfUrl = responseObject.RootElement.GetProperty("url").GetString();

                        var pdfBytes = await httpClient.GetByteArrayAsync(pdfUrl);

                        Response.Headers.Add("Content-Type", "application/pdf");

                        return File(pdfBytes, "application/pdf", "certificate.pdf");
                    }
                    else
                    {
                        return BadRequest($"Error generating certificate. Status Code: {response.StatusCode}");
                    }

                }
                else
                {
                    return BadRequest("Student does not meet the criteria for certificate generation.");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
            
           
        }

        private async Task<ImageUploadResult> UploadToCloudinary(string imagePath)
        {
            byte[] imageBytes = await System.IO.File.ReadAllBytesAsync(imagePath);

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription("photo", ms)
                };

                return await _cloudinary.UploadAsync(uploadParams);
            }
        }



    }
}

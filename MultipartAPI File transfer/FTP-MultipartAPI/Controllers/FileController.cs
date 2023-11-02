using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Xml.Linq;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace FTP_MultipartAPI.Controllers
{

    [ApiController]
    [Route("/Multipart")]
    public class FileController : Controller
    {
        [HttpPost]
        [Route("/Upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            string name = file.FileName;
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Files", name);

            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok("");
        }
        [HttpGet]
        [Route("Download")]
        public async Task<IActionResult> DownloadFile(string filename, string location)
        {

            try
            {

            var resourcePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", filename);
                var downloadPath = Path.Combine(Directory.GetCurrentDirectory(), "Downloads",location) ;

                var loc = "";

                while (downloadPath.Contains("/"))
                {
                    downloadPath= downloadPath.Replace("/", "\\");
                }


                if (!Directory.Exists(downloadPath))
            {
                Directory.CreateDirectory(downloadPath);
            }

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filename, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = await System.IO.File.ReadAllBytesAsync(resourcePath);


                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddUserProfilePreference("download.default_directory", downloadPath);


                IWebDriver driver = new ChromeDriver(chromeOptions);
                driver.Navigate().GoToUrl("https://localhost:7134/Multipart/Download?filename="+ filename+ "&location="+ location);

                driver.Quit();


            //return Ok();

                return File(bytes, contentType, Path.GetFileName(resourcePath));


            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}

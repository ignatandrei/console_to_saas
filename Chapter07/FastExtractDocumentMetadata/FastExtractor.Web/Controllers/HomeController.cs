using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FastExtractor.Web.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using ContractExtractor.IO;
using ContractExtractor;

namespace FastExtractor.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _environment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            //exercise for the reader: add handling error
            if (file == null || file.Length == 0)
                return Content("file not selected");

            string name = Path.GetFileNameWithoutExtension(file.FileName);
            //exercise for the reader : for tenants ,where to store data to be returned ? 
            var fullPathFile = Path.Combine(
                      _environment.WebRootPath,
                      Path.GetFileName(file.FileName));
            if (System.IO.File.Exists(fullPathFile))
                System.IO.File.Delete(fullPathFile);

            using (var stream = new FileStream(fullPathFile, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var fileSystem = new ZipFileSystem(fullPathFile);
            var extractor = new WordContractExtractor(fileSystem);
            extractor.Start();
            //exercise for the reader : for tenants ,where to store data to be returned ? 
            return Content("upload success");
        }
    }
}

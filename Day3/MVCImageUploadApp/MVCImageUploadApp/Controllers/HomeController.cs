using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using MVCImageUploadApp.Models;
using System.Diagnostics;

namespace MVCImageUploadApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConfigModel _config;

        public HomeController(ILogger<HomeController> logger,ConfigModel config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UploadImage()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UploadImage(ImageUploadVM vm)
        {
            Stream image = vm.Image.OpenReadStream();
            BlobContainerClient containerClient = await GetCloudBlobContainer(_config.ContainerName);
            // string blobName = Guid.NewGuid().ToString().ToLower().Replace("-", String.Empty);
            string blobName = vm.Image.FileName;
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            BlobHttpHeaders blobHeaders = new BlobHttpHeaders
            {
                ContentType = "image/jpeg"
                //ContentType = "application/pdf"
            };
            await blobClient.UploadAsync(image, blobHeaders);

            return RedirectToAction("Index");

            
        }
        

            public async Task<IActionResult> DisplayImages()
         {
            BlobContainerClient containerClient = await GetCloudBlobContainer(_config.ContainerName);
            List<string> results = new List<string>();
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                results.Add(
                    Flurl.Url.Combine(containerClient.Uri.AbsoluteUri, blobItem.Name)
                );
            }

            ViewBag.ImageUrls = results;
            return View();
        }

        private async Task<BlobContainerClient> GetCloudBlobContainer(string containerName)
        {
            BlobServiceClient serviceClient = new BlobServiceClient(_config.StorageConnectionString);
            BlobContainerClient containerClient = serviceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync();
            return containerClient;
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
    }
}

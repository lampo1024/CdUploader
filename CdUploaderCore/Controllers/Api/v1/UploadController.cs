using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CdUploaderCore.Controllers.Api.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [DisableRequestSizeLimit]
    public class UploadController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public UploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("image")]
        [RequestSizeLimit(long.MaxValue)]
        public async Task<IActionResult> Image()
        {
            var folderName = "uploads";
            var webRootPath = _hostingEnvironment.WebRootPath;
            var newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            var files = Request.Form.Files;
            var size = files.Sum(f => f.Length);
            var fileName = "";
            var formFile = files[0];
            if (formFile.Length > 0)
            {
                var fileExt = Path.GetExtension(formFile.FileName);
                fileName = Guid.NewGuid() + fileExt;
                var filePath = Path.Combine(newPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }

            return Ok(new { count = files.Count, size, fileName });
        }
    }
}
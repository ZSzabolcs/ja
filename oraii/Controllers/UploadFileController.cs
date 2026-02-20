using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using oraii.Services.Interfaces;

namespace oraii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IUploadFile uploadFile;

        public UploadFileController(IUploadFile uploadFile)
        {
            this.uploadFile = uploadFile;
        }

        [HttpPost]
        public async Task<ActionResult> PostFile(IFormFile formFile)
        {
            var upload = await uploadFile.Upload(formFile);
            if (upload != null)
            {
                return Ok(upload);
            }
            return BadRequest(upload);
        }
    }
}

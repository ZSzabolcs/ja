using oraii.Models;
using oraii.Services.Interfaces;

namespace oraii.Services
{
    public class UploadFile : IUploadFile
    {
        private readonly FilestoreContext _context;

        public UploadFile(FilestoreContext context)
        {
            _context = context;
        }

        public Task<object> Download(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<object> Upload(IFormFile formFile)
        {
            try
            {
                if (formFile != null || formFile.Length != 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await formFile.CopyToAsync(memoryStream);
                        var file = new FileUpload
                        {
                            FileData = memoryStream.ToArray(),
                            FileName = formFile.FileName,
                            ContentType = formFile.ContentType
                        };
                        await _context.Files.AddAsync(file);
                        await _context.SaveChangesAsync();
                        return new { message = "Sikertelen tárolás" };
                    }
                }
            }
            catch (Exception ex)
            {
                return new { message = ex.Message };
            }
        }
    }
}

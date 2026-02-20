namespace oraii.Services.Interfaces
{
    public interface IUploadFile
    {
        Task<object> Upload(IFormFile formFile);
        Task<object> Download(int id);
    }
}

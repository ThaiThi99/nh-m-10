namespace NoiThatStore.Models
{
	public interface IFileUploadService
	{
		Task<string> UploadFileAsync(IFormFile file);
	}
}

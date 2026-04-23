namespace Application.Interfaces;

public interface IFileStorageService
{
    Task<string> UploadAsync(Stream file, string fileName, string folder);
    Task DeleteAsync(string filePath);
    string GetUrl(string filePath);
}
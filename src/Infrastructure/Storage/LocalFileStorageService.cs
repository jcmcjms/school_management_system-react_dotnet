using Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Storage;

public class LocalFileStorageService : IFileStorageService
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<LocalFileStorageService> _logger;

    public LocalFileStorageService(IWebHostEnvironment environment, ILogger<LocalFileStorageService> logger)
    {
        _environment = environment;
        _logger = logger;
    }

    public async Task<string> UploadAsync(Stream file, string fileName, string folder)
    {
        var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", folder);
        
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        _logger.LogInformation("File uploaded: {FilePath}", filePath);

        return $"/uploads/{folder}/{uniqueFileName}";
    }

    public Task DeleteAsync(string filePath)
    {
        var fullPath = Path.Combine(_environment.WebRootPath, filePath.TrimStart('/'));
        
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
            _logger.LogInformation("File deleted: {FilePath}", fullPath);
        }

        return Task.CompletedTask;
    }

    public string GetUrl(string filePath)
    {
        return filePath;
    }
}
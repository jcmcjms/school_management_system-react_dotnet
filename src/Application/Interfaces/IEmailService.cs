namespace Application.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body, bool isHtml = false);
    Task SendEmailAsync(string to, string subject, string body, List<AttachmentInfo>? attachments, bool isHtml = false);
}

public class AttachmentInfo
{
    public string FileName { get; set; } = string.Empty;
    public byte[] Content { get; set; } =  Array.Empty<byte>();
    public string ContentType { get; set; } = "application/octet-stream";
}
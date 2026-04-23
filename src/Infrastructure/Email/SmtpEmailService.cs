using Application.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Infrastructure.Email;

public class SmtpEmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<SmtpEmailService> _logger;

    public SmtpEmailService(IConfiguration configuration, ILogger<SmtpEmailService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task SendEmailAsync(string to, string subject, string body, bool isHtml = false)
    {
        await SendEmailAsync(to, subject, body, null, isHtml);
    }

    public async Task SendEmailAsync(string to, string subject, string body, List<AttachmentInfo>? attachments, bool isHtml = false)
    {
        var smtpSettings = _configuration.GetSection("Smtp");
        var host = smtpSettings["Host"] ?? "localhost";
        var port = int.Parse(smtpSettings["Port"] ?? "587");
        var username = smtpSettings["Username"];
        var password = smtpSettings["Password"];
        var from = smtpSettings["From"] ?? "noreply@school.com";
        var enableSsl = bool.Parse(smtpSettings["EnableSsl"] ?? "true");

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("School Management", from));
        message.To.Add(MailboxAddress.Parse(to));
        message.Subject = subject;

        var builder = new BodyBuilder();
        if (isHtml)
        {
            builder.HtmlBody = body;
        }
        else
        {
            builder.TextBody = body;
        }

        if (attachments != null)
        {
            foreach (var attachment in attachments)
            {
                builder.Attachments.Add(attachment.FileName, attachment.Content);
            }
        }

        message.Body = builder.ToMessageBody();

        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(host, port, enableSsl);
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                await client.AuthenticateAsync(username, password);
            }
            await client.SendAsync(message);
            _logger.LogInformation("Email sent successfully to {Recipient}", to);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send email to {Recipient}", to);
            throw;
        }
        finally
        {
            await client.DisconnectAsync(true);
        }
    }
}
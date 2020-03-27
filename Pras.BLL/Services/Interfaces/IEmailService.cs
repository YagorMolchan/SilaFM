using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Pras.BLL.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendFeedbackEmailAsync(string subject, string message, List<IFormFile> files = null);
        Task SendEmailAsync(string subject, string email, string message, List<IFormFile> files = null);
    }
}

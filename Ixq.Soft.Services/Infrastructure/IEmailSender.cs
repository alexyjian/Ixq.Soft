using System.Threading.Tasks;

namespace Ixq.Soft.Services.Infrastructure
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}

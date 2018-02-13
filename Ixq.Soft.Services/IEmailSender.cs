using System.Threading.Tasks;

namespace Ixq.Soft.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}

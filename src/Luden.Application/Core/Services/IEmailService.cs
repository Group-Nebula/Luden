using Luden.Application.Core.Models;

namespace Luden.Application.Core.Services
{
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}
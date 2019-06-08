
using Lopak.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Lopak.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}


using Lopak.Application.Interfaces;
using Lopak.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Lopak.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}

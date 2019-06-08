using Lopak.Domain.Entities.Common;
using Lopak.Domain.Entities.UserR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lopak.Application.Interfaces
{
    public interface IUserDataBox
    {
         string Username { get;  }
         string DisplayName { get; }
         ICollection<UserRole> Roles { get; }
         City City { get;  }
         Area Area { get; }

        Task Init(User user);

    }
}

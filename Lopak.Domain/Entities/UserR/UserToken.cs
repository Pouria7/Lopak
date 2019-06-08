using System;
using System.Collections.Generic;
using System.Text;

namespace Lopak.Domain.Entities.UserR
{
    public class UserToken
    {
        public int Id { get; set; }

        public string AccessTokenHash { get; set; }

        public DateTimeOffset AccessTokenExpiresDateTime { get; set; }

        public string RemoteIpAddress { get; set; }

      //  public bool IsActive { get; set; }


        public string RefreshTokenIdHash { get; set; }

        public DateTimeOffset RefreshTokenExpiresDateTime { get; set; }

        public string RefreshTokenIdHashSource { get; set; }

        public int UserId { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Lopak.Application.Actions.Users.Queries
{
    public class UserCallbackViewModel
    {
       public  UserCallbackViewModel()
        {
            Roles = new List<int>();
        }
        public string AccessToken { get; set; }
        public string DisplayName { get; set; }
        public List<int> Roles { get; set; }
    }
}

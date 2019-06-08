using Lopak.Domain.Entities.Commercial;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lopak.Domain.Entities.Base
{
    public class RegisterData
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdate { get; set; }

        public int? UserId { get; set; }

        public ActionType ActionType { get; set; }
    }

   public enum ActionType
    {
        Created = 10011,
        Edited  = 10012,
        Disable = 10013,
        Deleted = 10015
    }
}

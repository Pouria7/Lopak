using System;
using System.Collections.Generic;
using System.Text;

namespace Lopak.Domain.Entities.Commercial
{
   public  class ActivityTime
    {
        public ActivityTime()
        {
            Customers = new HashSet<Customer>();
            ReceivedTrash = new HashSet<ReceivedTrash>();
        }

        public int ActivityTimeId { get; set; }
        public string Title { get; set; }

        public string TitleFa { get; set; }

        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }

        public ICollection<Commercial.Customer> Customers { get; set; }
        public ICollection<Commercial.ReceivedTrash> ReceivedTrash { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Lopak.Domain.Entities.Commercial
{
   public class ActivityField 
    {
        public int ActivityFieldId { get; set; }
        public string Title { get; set; }
        public string TitleFa { get; set; }

        public ICollection<Commercial.Customer> Customers { get; set; }
    }
}

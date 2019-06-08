using System;
using System.Collections.Generic;
using System.Text;

namespace Lopak.Domain.Entities.Commercial
{
    public class CustomerTrashTypes
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        public int TrashTypeId { get; set; }
        public TrashType TrashType { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}

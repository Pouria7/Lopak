using System;
using System.Collections.Generic;
using System.Text;

namespace Lopak.Domain.Entities.Commercial
{
    public class ReceivedTrashTypes
    {
        public int ReceivedTrashId { get; set; }
        public ReceivedTrash ReceivedTrash { get; set; }
        
        public int TrashTypeId { get; set; }
        public TrashType TrashType { get; set; }

        public double UnitPrice { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public bool Rounded { get; set; }
    }
}

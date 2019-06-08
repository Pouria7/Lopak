using System;
using System.Collections.Generic;
using System.Text;

namespace Lopak.Domain.Entities.Commercial
{
    public class TrashType
    {
        public int TrashTypeId { get; set; }
        public string Title { get; set; }
        public string TitleFa { get; set; }
        public bool Enabled { get; set; }

        public IList<ReceivedTrashTypes> ReceivedTrashTypes { get; set; }
        public IList<CustomerTrashTypes> CustomerTrashTypes { get; set; }

    }
}

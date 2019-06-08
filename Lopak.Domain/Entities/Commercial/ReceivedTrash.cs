using System;
using System.Collections.Generic;
using System.Text;

namespace Lopak.Domain.Entities.Commercial
{
    public class ReceivedTrash: Base.RegisterData
    {
        public int ReceivedTrashId { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }

        public ActivityTime ActivityTime { get; set; }
        public int ActivityTimeId { get; set; }

        public IList<ReceivedTrashTypes> ReceivedTrashTypes { get; set; }

        //>> Add Driver, WizardMode(Time,Signed,Desc,...)

    }
}

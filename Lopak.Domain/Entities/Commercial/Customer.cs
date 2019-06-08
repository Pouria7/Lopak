using Lopak.Domain.Entities.Common;

using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;

namespace Lopak.Domain.Entities.Commercial
{
    public class Customer: Base.RegisterData
    {
        public Customer(){
            ReceivedTrashs = new HashSet<ReceivedTrash>();

     
        }

        private string _trashTypes = string.Empty;

        public int UserId { get; set; }

        public string CustomerId { get; set; }
        public string ContactTitle { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Point Location { get; set; }

        public int AreaId { get; set; }
        public Area Area { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }

        public string AccountHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ShebaNumber { get; set; }

        public int? ActivityTimeId { get; set; }
        public ActivityTime ActivityTime { get; set; }

        public int ActivityFieldId { get; set; }
        public ActivityField ActivityField { get; set; }

        public DateTime? ConfirmationDate { get; set; }




        public ICollection<ReceivedTrash> ReceivedTrashs { get; set; }

        public IList<CustomerTrashTypes> CustomerTrashTypes { get; set; }

    }
}

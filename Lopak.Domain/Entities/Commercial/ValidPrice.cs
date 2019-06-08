using Lopak.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lopak.Domain.Entities.Commercial
{
    public class ValidPrice
    {
        public int ValidPriceId { get; set; }
        public int? UniqueId { get; set; }


        public double Price { get; set; }
        public DateTime Date { get; set; }

        public TrashType TrashType { get; set; }
        public int TrashTypeId { get; set; }

        public City City { get; set; }
        public int CityId { get; set; }

    }
}

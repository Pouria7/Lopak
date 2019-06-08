using System;
using System.Collections.Generic;
using System.Text;

namespace Lopak.Domain.Entities.Common
{
    public class Area
    {
        public int AreaId { get; set; }
        public string Title { get; set; }
        public string TitleFa { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public ICollection<Commercial.Customer> Customers { get; set; }
    }
}

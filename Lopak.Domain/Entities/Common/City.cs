using System;
using System.Collections.Generic;
using System.Text;

namespace Lopak.Domain.Entities.Common
{
    public class City
    {
        public City()
        {
            Areas = new HashSet<Area>();
        }
        public int CityId { get; set; }
        public string Title { get; set; }
        public string TitleFa { get; set; }

        public ICollection<Area> Areas { get; private set; }
        public ICollection<Commercial.ValidPrice> ValidPrices { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Api.Models
{
    public class CityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Discription { get; set; }

        public int NumberOfPointOfInterest
        {
            get
            {
                return PointOfInterestDtos.Count();
            }
        }

        public ICollection<PointOfInterestDto> PointOfInterestDtos { get; set; } = new List<PointOfInterestDto>();
    }
}

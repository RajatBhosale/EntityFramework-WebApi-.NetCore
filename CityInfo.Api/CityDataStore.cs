using CityInfo.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Api
{
    public class CityDataStore
    {
        public static CityDataStore Current { get; } = new CityDataStore();
        public List<CityDto> Cities { get; set; }

        public CityDataStore()
        {
            Cities = new List<CityDto>
            {
                new CityDto
                {
                    Discription = "pune",
                    Id =  1,
                    Name = "Poona",
                    PointOfInterestDtos = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto
                        {
                            Discription = "nature of pune people",
                            Id = 1,
                            Name = "nice people"
                        }
                    }
                },
                new CityDto 
                { 
                    Discription = "Mumbai",
                    Name = "Bombay", 
                    Id = 2,
                    PointOfInterestDtos = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto
                        {
                            Discription = "beautiful Sea",
                            Id = 1,
                            Name = "sea"
                        }
                    }
                }
            };
        }
    }
}

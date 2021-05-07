using CityInfo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Api.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointofinterest")]
    public class PointsOfInterestController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetPointOfInterest(int cityid)
        {
            var cities = CityDataStore.Current.Cities.FirstOrDefault(f => f.Id == cityid);
            if (cities == null)
            {
                return NotFound();
            }
            return Ok(cities.NumberOfPointOfInterest);

        }

        [HttpPost]
        public IActionResult GetPointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            var cities = CityDataStore.Current.Cities.FirstOrDefault(f => f.Id == cityId);
            if (cities == null)
            {
                return NotFound();
            }

            var maxPointOfInterest = CityDataStore.Current.Cities.SelectMany(c => c.PointOfInterestDtos).Max(m => m.Id);

            var finalPointOfInterest = new PointOfInterestDto
            {
                Id = ++maxPointOfInterest,
                Discription = pointOfInterest.Discription,
                Name = pointOfInterest.Name
            };

            cities.PointOfInterestDtos.Add(finalPointOfInterest);

            return Ok();
        }
    }
}

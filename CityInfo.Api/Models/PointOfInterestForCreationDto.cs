using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Api.Models
{
    public class PointOfInterestForCreationDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength (200)]
        public string Discription { get; set; }
    }
}

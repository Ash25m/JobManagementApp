using Microsoft.AspNetCore.Mvc;
using TeknorixJobApi.DTOs;
using TeknorixJobApi.Service;

namespace TeknorixJobApi.Controllers
{
    [ApiController]
    [Route("api/v1/locations")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationDto location)
        {
            var createdLocation = await _locationService.CreateLocation(location);
            return Ok(createdLocation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] CreateLocationDto location)
        {
            var createdLocation = await _locationService.UpdateLocation(id, location);
            return Ok(createdLocation);
        }


        [HttpGet]

        public async Task<IActionResult> GetLocations()
        {
            var locations = await _locationService.GetLocations();
            return Ok(locations);
        }
    }
}

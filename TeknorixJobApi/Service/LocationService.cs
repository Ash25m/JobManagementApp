using TeknorixJobApi.Data;
using TeknorixJobApi.DTOs;
using TeknorixJobApi.Models;

namespace TeknorixJobApi.Service
{
    public class LocationService : ILocationService
    {
        private readonly DataContext _context;

        public LocationService(DataContext context)
        {
            _context = context;
        }
        public async Task<Location> CreateLocation(CreateLocationDto location)
        {
            var newLocation = new Location
            {
                Title = location.Title,
                City = location.City,
                State = location.State,
                Country = location.Country,
                Zip = location.Zip,
            };
            _context.Locations.Add(newLocation);
            await _context.SaveChangesAsync();

            return newLocation;
        }

        public async Task<List<Location>> GetLocations()
        {
            var locations = _context.Locations.ToList();
            return locations;
        }

        public async Task<Location> UpdateLocation(int id, CreateLocationDto updatedLocation)
        {
            var locationToUpdate = _context.Locations.FirstOrDefault(x => x.Id == id);
            if (locationToUpdate is null)
                return null;

            locationToUpdate.Title = updatedLocation.Title;
            locationToUpdate.City = updatedLocation.City;
            locationToUpdate.State = updatedLocation.State;
            locationToUpdate.Country = updatedLocation.Country;
            locationToUpdate.Zip = updatedLocation.Zip;
            await _context.SaveChangesAsync();
            return locationToUpdate;
        }
    }
}

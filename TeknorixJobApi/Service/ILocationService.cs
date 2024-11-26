using TeknorixJobApi.DTOs;
using TeknorixJobApi.Models;

namespace TeknorixJobApi.Service
{
    public interface ILocationService
    {
        Task<Location> CreateLocation(CreateLocationDto location);
        Task<Location> UpdateLocation(int id, CreateLocationDto location);
        Task<List<Location>> GetLocations();
    }
}

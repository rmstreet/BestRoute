
namespace BestRoute.Core.Repository
{
    using System.Collections.Generic;
    using Models;

    public interface IAirportRepository
    {
        IEnumerable<Airport> GetAll();
        IEnumerable<Airport> GetAllFromFile(string fileName);
    }
}
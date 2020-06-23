
namespace BestRoute.Core.Services.Impl
{
    using System.Collections.Generic;
    using System.Linq;
    using Business;
    using Exceptions;
    using Repository;
    using Models;

    public class BestRouteService : IBestRouteServices
    {
        private IList<Airport> _airports;
        private IRouteRepository _routeRepository;
        private IAirportRepository _airportRepository;
        private IShortestPathFinder _businessLogic;
        public BestRouteService(
            IRouteRepository routeRepository, 
            IAirportRepository airportRepository,
            IShortestPathFinder businessLogic)
        {
            _routeRepository = routeRepository;
            _airportRepository = airportRepository;
            _businessLogic = businessLogic;
            _airports = new List<Airport>();
        }

        public void AddRoute(Route route)
        {
            _routeRepository.Add(route);
        }

        public BestRouteInfo BestRouteFromFile(string fileName, string from, string to)
        {
            return BestRoute(from, to, fileName);
        }

        private BestRouteInfo BestRoute(string from, string to, string fileName = null)
        {
            var airports = string.IsNullOrEmpty(fileName) ? _airportRepository.GetAll() : _airportRepository.GetAllFromFile(fileName);
            var airportFrom = airports.SingleOrDefault(a => a.Name.Equals(from));
            var airportTo = airports.SingleOrDefault(a => a.Name.Equals(to));
            if (airportFrom == null || airportTo == null)
            {
                throw new AirportsFromOrToNotExist();
            }
            return _businessLogic.FindShortestPath(airportFrom, airportTo);
        }

        public BestRouteInfo BestRouteFromRepository(string from, string to)
        {
            return BestRoute(from, to);
        }

    }
}

namespace BestRoute.Core.Business.Impl.Algorithms
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    internal class FlightPlan
    {
        readonly List<Airport> _airportsVisiteds = new List<Airport>();

        readonly Dictionary<Airport, ScalePrice> _prices = new Dictionary<Airport, ScalePrice>();

        readonly List<Airport> _airportsScheduled = new List<Airport>();

        public void RegisterVisitTo(Airport airport)
        {
            if (!_airportsVisiteds.Contains(airport))
                _airportsVisiteds.Add(airport);
        }

        public bool WasVisited(Airport airport)
        {
            return _airportsVisiteds.Contains(airport);
        }

        public void UpdatePrice(Airport airport, ScalePrice scalePrice)
        {
            if (!_prices.ContainsKey(airport))
            {
                _prices.Add(airport, scalePrice);
            }
            else
            {
                _prices[airport] = scalePrice;
            }
        }

        public ScalePrice QueryPrice(Airport airport)
        {
            ScalePrice result;
            if (!_prices.ContainsKey(airport))
            {
                result = new ScalePrice(null, decimal.MaxValue);
                _prices.Add(airport, result);
            }
            else
            {
                result = _prices[airport];
            }
            return result;
        }

        public void ScheduleVisitTo(Airport airport)
        {
            _airportsScheduled.Add(airport);
        }

        public bool HasScheduledVisits => _airportsScheduled.Count > 0;

        public Airport GetAirportToVisit()
        {
            var orderedAirports = from n in _airportsScheduled
                            orderby QueryPrice(n).Price
                            select n;

            var result = orderedAirports.First();
            _airportsScheduled.Remove(result);
            return result;
        }

        public bool HasComputedPathToOrigin(Airport airport)
        {
            return QueryPrice(airport).From != null;
        }

        public IEnumerable<Airport> ComputedPathToOrigin(Airport airport)
        {
            var current = airport;
            while (current != null)
            {
                yield return current;
                current = QueryPrice(current).From;
            }
        }
    }

}
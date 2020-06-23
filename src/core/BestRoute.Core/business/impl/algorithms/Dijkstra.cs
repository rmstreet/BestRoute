
namespace BestRoute.Core.Business.Impl.Algorithms
{
    using System.Linq;
    using Models;

    public class Dijkstra : IShortestPathFinder
    {
        public BestRouteInfo FindShortestPath(Airport @from, Airport to)
        {
            var control = new FlightPlan();

            control.UpdatePrice(@from, new ScalePrice(null, 0));
            control.ScheduleVisitTo(@from);

            while (control.HasScheduledVisits)
            {
                var visitingNode = control.GetAirportToVisit();
                var visitingNodeWeight = control.QueryPrice(visitingNode);
                control.RegisterVisitTo(visitingNode);

                foreach (var neighborhoodInfo in visitingNode.Connections)
                {
                    if (!control.WasVisited(neighborhoodInfo.Scale))
                    {
                        control.ScheduleVisitTo(neighborhoodInfo.Scale);
                    }

                    var neighborWeight = control.QueryPrice(neighborhoodInfo.Scale);

                    var probableWeight = (visitingNodeWeight.Price + neighborhoodInfo.PriceToScale);
                    if (neighborWeight.Price > probableWeight)
                    {
                        control.UpdatePrice(neighborhoodInfo.Scale, new ScalePrice(visitingNode, probableWeight));
                    }
                }
            }

            if(control.HasComputedPathToOrigin(to)){
                return new BestRouteInfo(control.ComputedPathToOrigin(to).Reverse().ToList(), control.QueryPrice(to).Price);
            }

            return null;
        }
    }
}
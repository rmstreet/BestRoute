
namespace BestRoute.Core.Business
{
    using Models;
    
    public interface IShortestPathFinder
    {
        BestRouteInfo FindShortestPath(Airport from, Airport to);
    }
}
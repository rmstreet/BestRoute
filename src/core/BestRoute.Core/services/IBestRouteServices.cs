
namespace BestRoute.Core.Services{

    using System.Collections.Generic;
    using Models;

    interface IBestRouteServices
    {
        void AddRoute(Route route);
        BestRouteInfo BestRouteFromFile(string fileName, string @from, string to);
        BestRouteInfo BestRouteFromRepository(string @from, string to);        
    }

}

namespace BestRoute.Core.Models{
    using System.Collections.Generic;
    public class BestRouteInfo
    {
        public BestRouteInfo(IList<Airport> routes, decimal totalPrice)
        {
            this.routes = routes;
            TotalPrice = totalPrice;
        }

        public IList<Airport> routes { get; }
        public decimal TotalPrice { get; }
        
    }
}
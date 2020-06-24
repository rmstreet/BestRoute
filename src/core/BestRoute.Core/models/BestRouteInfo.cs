
namespace BestRoute.Core.Models{
    using System.Collections.Generic;
    public class BestRouteInfo
    {
        public BestRouteInfo(IList<Airport> routes, decimal totalPrice)
        {
            this.Routes = routes;
            TotalPrice = totalPrice;
        }

        public IList<Airport> Routes { get; }
        public decimal TotalPrice { get; }
        
    }
}
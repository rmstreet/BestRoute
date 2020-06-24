using BestRoute.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestRoute.OutputApi.ViewModels
{
    public class RouteInsertViewModel
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Price { get; set; }

        public Route ToRoute() => new Route(Price, new Airport(Origin), new Airport(Destination));
    }
}

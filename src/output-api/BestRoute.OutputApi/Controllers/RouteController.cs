using System.Linq;
using System.Net;
using BestRoute.Core.Models;
using BestRoute.Core.Services;
using BestRoute.OutputApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BestRoute.OutputApi.Controllers
{
    [ApiController]
    [Route("api/route")]
    public class RouteController : ControllerBase
    {        

        private readonly ILogger<RouteController> _logger;
        private readonly IBestRouteServices _services;

        public RouteController(ILogger<RouteController> logger, IBestRouteServices services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpGet("/bestroute")]
        public BestRouteViewModel GetBestRoute([FromQuery]string from, string to)
        {
            var bestRouteInfo = _services.BestRouteFromRepository(from, to);

            return new BestRouteViewModel() { Route = bestRouteInfo.Routes.Select(r => r.Name).ToList(), Price = bestRouteInfo.TotalPrice };
        }

        [HttpPost]
        public void InsertRoute([FromBody]RouteInsertViewModel route)
        {
            _services.AddRoute(route.ToRoute());
        }

    }
}
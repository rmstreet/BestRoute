
namespace BestRoute.OutputConsole
{
    using System;
    using BestRoute.Core.Business.Impl.Algorithms;
    using BestRoute.Core.Repository.Impl;
    using BestRoute.Core.Services.Impl;

    class Program
    {
        static void Main(string[] args)
        {
            var fileName = args[0];

            var qRepeat = 0;

            do{
                Console.Write("please enter the route:");

                var route = Console.ReadLine();
                var routes = route.Split('-');
                var @from = routes[0];
                var @to = routes[1];

                var service = new BestRouteService(new RouteRepository(), new AirportRepository(), new Dijkstra());
                var bestRouteInfo = service.BestRouteFromFile(fileName, @from, @to);

                Print(bestRouteInfo);
                qRepeat++;                
            }while(qRepeat == 1); // repeat 2x block above
        }

        private static void Print(Core.Models.BestRouteInfo bestRouteInfo)
        {
            Console.Write("best route: ");
            var length = bestRouteInfo.Routes.Count;

            for (int i = 0; i < length; i++)
            {
                var sufix = i == length - 1 ? " > " : " - ";
                Console.Write($"{bestRouteInfo.Routes[i].Name}{sufix}");
            }

            Console.Write($"${bestRouteInfo.TotalPrice}");
            Console.WriteLine();
        }
    }
}

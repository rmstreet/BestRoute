
namespace BestRoute.Core.Repository.Impl
{
    using System;
    using System.IO;
    using Models;

    public class RouteRepository : IRouteRepository
    {
        private string path = Directory.GetCurrentDirectory();
        private string fileName = "input-routes.csv";
        private string fullPath;
        public RouteRepository()
        {
            fullPath = $"{path}\\{fileName}";
        }

        public void Add(Route route)
        {
            try
            {                
                using (StreamWriter file = new StreamWriter(fullPath, true))
                {
                    file.WriteLine(route);
                }                
            }
            catch (System.Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("The File could not be write:");
                Console.WriteLine(e.Message);

                Console.ResetColor();
            }
        }

        
    }

}

namespace BestRoute.Core.Repository.Impl
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Models;

    public class AirportRepository : IAirportRepository
    {
        private string path = Directory.GetCurrentDirectory();
        private string fileName = "input-routes.csv";
        private string fullPath;

        public AirportRepository()
        {
            fullPath = $"{path}\\{fileName}";
        }

        public IEnumerable<Airport> GetAll()
        {
            return GetAllBy(fullPath);
        }
        
        public IEnumerable<Airport> GetAllFromFile(string fileName){
            var directorySeparatorChar = Path.DirectorySeparatorChar;
            return GetAllBy($@"{this.path}{directorySeparatorChar}{fileName}");
        }

        private IEnumerable<Airport> GetAllBy(string file)
        {
            var airports = new HashSet<Airport>();
            try
            {
                using (var sr = new StreamReader(file))
                {
                    string currentLine;
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(currentLine))
                        {
                            throw new InvalidCastException("Impossible cast lineFile to Airport class.");
                        }

                        var data = currentLine.Split(',');
                        var origin = new Airport(data[0]);
                        var destination = new Airport(data[1]);
                        var price = decimal.Parse(data[2]);

                        if(airports.Any(a => a.Name.Equals(origin.Name))){
                            origin = airports.Single(a => a.Name.Equals(origin.Name));
                        }

                        if(airports.Any(a => a.Name.Equals(destination.Name))){
                            destination = airports.Single(a => a.Name.Equals(destination.Name));
                        }

                        origin.ConnectTo(destination, price);

                        airports.Add(origin);
                        airports.Add(destination);
                    }
                }
            }
            catch (System.Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("The File could not be read:");
                Console.WriteLine(e.Message);

                Console.ResetColor();
            }

            return airports;
        }        
    }
}
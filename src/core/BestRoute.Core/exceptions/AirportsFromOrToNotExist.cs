using System;

namespace BestRoute.Core.Exceptions
{
    class AirportsFromOrToNotExist : ArgumentException
    {
        public AirportsFromOrToNotExist() : base("Airports From or To not exist!"){ }
    }    
}
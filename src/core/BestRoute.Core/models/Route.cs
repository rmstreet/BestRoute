
namespace BestRoute.Core.Models
{
    using System;
    public class Route
    {
        public decimal Price { get; }
        public Airport Origin { get; }
        public Airport Destination { get; }

        public Route(decimal price, Airport origin, Airport destination)
        {
            if (price <= 0)
            {
                throw new ArgumentException("Edge value needs to be positive.");
            }
            Price = price;
            Origin = origin;
            origin.Assign(this);
            Destination = destination;
            destination.Assign(this);
        }

        public static Route Create(decimal price, Airport origin, Airport destination)
        {
            return new Route(price, origin, destination);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            var compareTo = obj is Route ? (Route)obj : default;

            if (ReferenceEquals(this, compareTo)) return true;

            return Origin.Equals(compareTo.Origin) && 
            Destination.Equals(compareTo.Destination) && 
            Price.Equals(compareTo.Price);
        }

        public override int GetHashCode()
        {
            return Origin.GetHashCode() + Destination.GetHashCode() + Price.GetHashCode() + 3275;
        }

        public override string ToString(){
            return $"{Origin},{Destination},{Price}";
        }
    }
}
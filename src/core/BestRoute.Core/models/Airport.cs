
namespace BestRoute.Core.Models
{
    using System.Collections.Generic;
    using System.Linq;
    
    public class Airport
    {
        public string Name { get; }
        public Airport(string name)
        {
            Name = name;
        }

        readonly List<Route> _routes = new List<Route>();
        public IEnumerable<Route> Routes => _routes;

        public IEnumerable<ConnectionInfo> Connections =>
            from route in Routes
            select new ConnectionInfo(
                route.Origin == this ? route.Destination : route.Origin,
                route.Price
                );

        public void Assign(Route route)
        {
            _routes.Add(route);
        }

        public void ConnectTo(Airport connection, decimal connectionValue)
        {
            Route.Create(connectionValue, this, connection);
        }               

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            var compareTo = obj is Airport ? (Airport)obj : default;

            if (ReferenceEquals(this, compareTo)) return true;

            return Name.Equals(compareTo.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + 3473;
        }
    }
}
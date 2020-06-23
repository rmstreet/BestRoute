
namespace BestRoute.Core.Models
{
    public struct ConnectionInfo
    {
        public Airport Scale { get; }
        public decimal PriceToScale { get; }

        public ConnectionInfo(Airport scale, decimal priceToScale)
        {
            Scale = scale;
            PriceToScale = priceToScale;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            var compareTo = obj is ConnectionInfo ? (ConnectionInfo)obj : default;

            if (ReferenceEquals(this, compareTo)) return true;

            return Scale.Equals(compareTo.Scale) && 
            PriceToScale.Equals(compareTo.PriceToScale);
        }

        public override int GetHashCode()
        {
            return Scale.GetHashCode() + PriceToScale.GetHashCode() + 5437;
        }
    }     
}
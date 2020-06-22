
namespace BestRoute.Core.Business.Impl.Algorithms
{
    using Models;

    internal class ScalePrice
    {
        public Airport From { get; }
        public decimal Price { get; }

        public ScalePrice(Airport @from, decimal price)
        {
            From = @from;
            Price = price;
        }
    }
}
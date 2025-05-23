using TestProgi.Domain.Entities;

namespace TestProgi.Domain.Strategies
{
    public interface IFraisCalculationStrategy
    {
        FraisDetail CalculerFrais(decimal prixBase);
    }
}
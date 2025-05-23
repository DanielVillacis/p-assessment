using TestProgi.Domain.Entities;

namespace TestProgi.Domain.Strategies
{
    public interface IFraisSpeciauxStrategy
    {
        FraisDetail CalculerFraisSpeciaux(decimal prixBase);
    }
}
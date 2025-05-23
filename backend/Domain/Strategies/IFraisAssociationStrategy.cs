using TestProgi.Domain.Entities;

namespace TestProgi.Domain.Strategies
{
    public interface IFraisAssociationStrategy
    {
        FraisDetail CalculerFraisAssociation(decimal prix);
    }
}
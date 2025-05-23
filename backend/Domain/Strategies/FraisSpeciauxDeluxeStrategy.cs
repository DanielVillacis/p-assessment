using TestProgi.Domain.Entities;

namespace TestProgi.Domain.Strategies
{
    public class FraisSpeciauxDeluxeStrategy : IFraisSpeciauxStrategy
    {
        private const decimal TauxFraisSpeciaux = 0.04m;

        public FraisDetail CalculerFraisSpeciaux(decimal prixBase)
        {
            return new FraisDetail("Frais spéciaux du vendeur", prixBase * TauxFraisSpeciaux);
        }
    }
}
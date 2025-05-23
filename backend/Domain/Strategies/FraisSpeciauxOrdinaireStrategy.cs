using TestProgi.Domain.Entities;

namespace TestProgi.Domain.Strategies
{
    public class FraisSpeciauxOrdinaireStrategy : IFraisSpeciauxStrategy
    {
        private const decimal TauxFraisSpeciaux = 0.02m;

        public FraisDetail CalculerFraisSpeciaux(decimal prixBase)
        {
            return new FraisDetail("Frais spéciaux du vendeur", prixBase * TauxFraisSpeciaux);
        }
    }
}
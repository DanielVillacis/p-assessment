using TestProgi.Domain.Entities;

namespace TestProgi.Domain.Strategies
{
    public class FraisBaseDeluxeStrategy : IFraisCalculationStrategy
    {
        private const decimal TauxFraisBase = 0.10m;
        private const decimal FraisBaseMin = 25m;
        private const decimal FraisBaseMax = 200m;

        public FraisDetail CalculerFrais(decimal prixBase)
        {
            decimal fraisBase = prixBase * TauxFraisBase;
            fraisBase = Math.Min(Math.Max(fraisBase, FraisBaseMin), FraisBaseMax);
            return new FraisDetail("Frais de base de l'acheteur", fraisBase);
        }
    }
}
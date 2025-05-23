using TestProgi.Domain.Entities;

namespace TestProgi.Domain.Strategies
{
    public class FraisBaseOrdinaireStrategy : IFraisCalculationStrategy
    {
        private const decimal TauxFraisBase = 0.10m;
        private const decimal FraisBaseMin = 10m;
        private const decimal FraisBaseMax = 50m;

        public FraisDetail CalculerFrais(decimal prixBase)
        {
            decimal fraisBase = prixBase * TauxFraisBase;
            fraisBase = Math.Min(Math.Max(fraisBase, FraisBaseMin), FraisBaseMax);
            return new FraisDetail("Frais de base de l'acheteur", fraisBase);
        }
    }
}
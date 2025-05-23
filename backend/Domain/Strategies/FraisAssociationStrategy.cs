using TestProgi.Domain.Entities;

namespace TestProgi.Domain.Strategies
{
    public class FraisAssociationStrategy : IFraisAssociationStrategy
    {
        public FraisDetail CalculerFraisAssociation(decimal prix)
        {
            decimal montant;

            switch (prix)
            {
                case <= 0:
                    montant = 0m;
                    break;
                case <= 500m:
                    montant = 5m;
                    break;
                case <= 1000m:
                    montant = 10m;
                    break;
                case <= 3000m:
                    montant = 15m;
                    break;
                default:
                    montant = 20m;
                    break;
            }

            return new FraisDetail("Frais d'association", montant);
        }
    }
}
using TestProgi.Domain.Entities;
using TestProgi.Domain.Enums;
using TestProgi.Domain.Factories;
using TestProgi.Domain.Models;

namespace TestProgi.Services
{
    public class CalculateurDeFraisService
    {
        private const decimal FraisEntreposage = 100m;

        public CalculResultat CalculerFrais(decimal prixBase, TypeVehicule typeVehicule)
        {
            ValiderPrixBase(prixBase);

            return new CalculResultat
            {
                PrixBase = prixBase,
                DetailsFrais = CollectionnerTousLesFrais(prixBase, typeVehicule)
            };
        }

        private void ValiderPrixBase(decimal prixBase)
        {
            if (prixBase < 0) throw new ArgumentException("Le prix de base ne peut pas être négatif", nameof(prixBase));
        }

        private List<FraisDetail> CollectionnerTousLesFrais(decimal prixBase, TypeVehicule typeVehicule)
        {
            var fraisBaseStrategy = FraisCalculationFactory.CreateFraisBaseStrategy(typeVehicule);
            var fraisSpeciauxStrategy = FraisCalculationFactory.CreateFraisSpeciauxStrategy(typeVehicule);
            var fraisAssociationStrategy = FraisCalculationFactory.CreateFraisAssociationStrategy();

            var frais = new List<FraisDetail>
            {
                fraisBaseStrategy.CalculerFrais(prixBase),
                fraisSpeciauxStrategy.CalculerFraisSpeciaux(prixBase),
                fraisAssociationStrategy.CalculerFraisAssociation(prixBase),
                new FraisDetail("Frais d'entreposage", FraisEntreposage)
            };

            return frais;
        }
    }
}
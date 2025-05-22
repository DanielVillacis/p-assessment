////filepath: /Users/danielvillacis/RiderProjects/TEST/Application/Services/CalculateurDeFraisService.cs
using System.Linq;
using TestProgi.Domain.Entities;
using TestProgi.Domain.Enums;

namespace TestProgi.Application.Services
{
    public class CalculateurDeFraisService
    {
        public CalculResultat CalculerFrais(decimal prixBase, TypeVehicule typeVehicule) {
            if (prixBase < 0) throw new ArgumentException("Le prix de base ne peut pas être négatif", nameof(prixBase));

            var resultat = new CalculResultat
            {
                PrixBase = prixBase,
                DetailsFrais = new List<FraisDetail>()
            };

            decimal fraisBase = prixBase * 0.10m;

            if (typeVehicule == TypeVehicule.Ordinaire)
            {
                fraisBase = Math.Min(Math.Max(fraisBase, 10m), 50m);
            }
            else
            {
                fraisBase = Math.Min(Math.Max(fraisBase, 25m), 200m);
            }
            resultat.DetailsFrais.Add(new FraisDetail("Frais de base de l'acheteur", fraisBase));

            // frais speciaux du vendeur ( 2% ordianire, 4% deluxe)
            decimal tauxFraisSpeciaux = typeVehicule == TypeVehicule.Ordinaire ? 0.02m : 0.04m;
            decimal fraisSpeciaux = prixBase * tauxFraisSpeciaux;
            resultat.DetailsFrais.Add(new FraisDetail("Frais spéciaux du vendeur", fraisSpeciaux));

            // frais supplementaires d'association selon le prix
            decimal fraisAssociation = CalculerFraisAssociation(prixBase);
            resultat.DetailsFrais.Add(new FraisDetail("Frais d'association", fraisAssociation));

            // frais d'entreposage fixes 
            resultat.DetailsFrais.Add(new FraisDetail("Frais d'entreposage", 100m));

            return resultat;
        }

        private decimal CalculerFraisAssociation(decimal prix)
        {
            switch (prix)
            {
                case <= 0:
                    return 0m;
                case <= 500:
                    return 5m;
                case <= 1000m:
                    return 10m;
                case <= 3000m:
                    return 15m;
                default:
                    return 20m;
            }
        }


        // TODO: refactor this
        public class CalculResultat
        {
            public decimal PrixBase { get; set; }
            public required List<FraisDetail> DetailsFrais { get; set; }
            public decimal TotalFrais => CalculerTotalFrais();
            public decimal Total => PrixBase + TotalFrais;

            private decimal CalculerTotalFrais()
            {
                decimal total = 0;
                foreach (var frais in DetailsFrais)
                {
                    total += frais.Montant;
                }
                return total;
            }
        }

    }
}
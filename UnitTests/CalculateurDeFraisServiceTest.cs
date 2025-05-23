using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProgi.Domain.Enums;
using TestProgi.Services;

namespace UnitTests
{
    public class CalculateurDeFraisServiceTest
    {
        private CalculateurDeFraisService _service;
        private const decimal FraisEntreposage = 100m;
        private const string FraisBaseDescription = "Frais de base de l'acheteur";
        private const string FraisSpeciauxDescription = "Frais spéciaux du vendeur";
        private const string FraisAssociationDescription = "Frais d'association";
        private const string FraisEntreposageDescription = "Frais d'entreposage";

        [SetUp]
        public void Setup()
        {
            _service = new CalculateurDeFraisService();
        }

        [Test]
        public void When_PrixBaseIsNegative_Expect_ArgumentException()
        {
            // Arrange
            decimal prixBase = -1000m;
            TypeVehicule typeVehicule = TypeVehicule.Ordinaire;

            // Act & Assert
            Action action = () => _service.CalculerFrais(prixBase, typeVehicule);

            action.Should().Throw<ArgumentException>()
                .WithMessage("*Le prix de base ne peut pas être négatif*");
        }

        [Test]
        public void When_VehiculeIsOrdinaire_PrixBaseIs1000_Expect_CorrectFraisDetails()
        {
            // Arrange
            decimal prixBase = 1000m;
            TypeVehicule typeVehicule = TypeVehicule.Ordinaire;

            // Act
            var result = _service.CalculerFrais(prixBase, typeVehicule);

            // Assert
            result.Should().NotBeNull();
            result.PrixBase.Should().Be(prixBase);
            result.DetailsFrais.Should().HaveCount(4); // 4 frais

            // Frais de Base
            result.DetailsFrais[0].Description.Should().Be(FraisBaseDescription);
            result.DetailsFrais[0].Montant.Should().Be(50m);

            // Frais Spéciaux (2% pour Ordinaire)
            result.DetailsFrais[1].Description.Should().Be(FraisSpeciauxDescription);
            result.DetailsFrais[1].Montant.Should().Be(20m);

            // Frais Association
            result.DetailsFrais[2].Description.Should().Be(FraisAssociationDescription);
            result.DetailsFrais[2].Montant.Should().Be(10m);

            // Frais Entreposage
            result.DetailsFrais[3].Description.Should().Be(FraisEntreposageDescription);
            result.DetailsFrais[3].Montant.Should().Be(FraisEntreposage);

            // Total frais et Total global
            result.TotalFrais.Should().Be(180m); // 50 + 20 + 10 + 100 = 180
            result.Total.Should().Be(1180m); // 1000 + 180 = 1180
        }

        [Test]
        public void When_VehiculeIsOrdinaire_PrixBaseIs50_Expect_MinimumFraisBase()
        {
            // Arrange
            decimal prixBase = 50m;
            TypeVehicule typeVehicule = TypeVehicule.Ordinaire;

            // Act
            var result = _service.CalculerFrais(prixBase, typeVehicule);

            // Assert -> 10% devrait etre 5 mais le minimum est 10
            result.DetailsFrais[0].Montant.Should().Be(10m);
        }

        [Test]
        public void When_VehiculeIsDeluxe_PrixBaseIs50_Expect_MinimumFraisBaseApplied()
        {
            // Arrange
            decimal prixBase = 50m;
            TypeVehicule typeVehicule = TypeVehicule.Deluxe;

            // Act
            var result = _service.CalculerFrais(prixBase, typeVehicule);

            // Assert
            result.DetailsFrais[0].Montant.Should().Be(25m);
        }

        [Test]
        public void When_VehiculeIsOrdinaire_PrixBaseIs1000_Expect_MaximumFraisBaseApplied()
        {
            // Arrange
            decimal prixBase = 1000m;
            TypeVehicule typeVehicule = TypeVehicule.Ordinaire;

            // Act
            var result = _service.CalculerFrais(prixBase, typeVehicule);

            // Assert
            result.DetailsFrais[0].Montant.Should().Be(50m);
        }

        [Test]
        public void When_VehiculeIsDeluxe_PrixBaseIs3000_Expect_MaximumFraisBaseApplied()
        {
            // Arrange
            decimal prixBase = 3000m;
            TypeVehicule typeVehicule = TypeVehicule.Deluxe;

            // Act
            var result = _service.CalculerFrais(prixBase, typeVehicule);

            // Assert
            result.DetailsFrais[0].Montant.Should().Be(200m);
        }

        [Test]
        public void When_PrixBaseIsZero_Expect_NoCalculationErrors()
        {
            // Arrange
            decimal prixBase = 0m;
            TypeVehicule typeVehicule = TypeVehicule.Ordinaire;

            // Act
            var result = _service.CalculerFrais(prixBase, typeVehicule);

            // Assert
            result.Should().NotBeNull();
            result.PrixBase.Should().Be(0m);
            result.DetailsFrais.Should().HaveCount(4);

            // Frais de base sont minimum 10$ (obligatoire)
            result.DetailsFrais[0].Montant.Should().Be(10m);
            // Frais speciaux du vendeur 0
            result.DetailsFrais[1].Montant.Should().Be(0m);
            // Frais d'association 0
            result.DetailsFrais[2].Montant.Should().Be(0m);
            // Frais d'entreposage fixe (obligatoire)
            result.DetailsFrais[3].Montant.Should().Be(FraisEntreposage);

            result.TotalFrais.Should().Be(110m);
            result.Total.Should().Be(110m);
        }






    }
}

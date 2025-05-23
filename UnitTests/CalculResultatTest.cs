using FluentAssertions;
using TestProgi.Domain.Entities;
using TestProgi.Domain.Models;

namespace UnitTests
{
    public class CalculResultatTest
    {
        [Test]
        public void CalculResultat_WithEmptyDetailsFrais_ShouldCalculateOnlyPrixBase()
        {
            // Arrange
            var prixBase = 100m;
            var detailsFrais = new List<FraisDetail>();
            var calculResultat = new CalculResultat
            {
                PrixBase = 100m,
                DetailsFrais = new List<FraisDetail>()
            };

            // Assert
            calculResultat.TotalFrais.Should().Be(0m);
            calculResultat.Total.Should().Be(100m);
        }

        [Test]
        public void CalculResultat_WithDetailsFrais_ShouldCalculateSumOfAllAmounts()
        {
            // Arrange
            var calculResultat = new CalculResultat
            {
                PrixBase = 100.50m,
                DetailsFrais = new List<FraisDetail>
                {
                    new FraisDetail("Frais 1", 10.25m),
                    new FraisDetail("Frais 2", 20.75m),
                    new FraisDetail("Frais 3", 5.33m)
                }
            };

            // Assert
            calculResultat.TotalFrais.Should().Be(36.33m);
            calculResultat.Total.Should().Be(136.83m);
        }

        [Test]
        public void TotalFrais_WithChangingFraisDetail_ShouldReceiveChangesInDetailsFrais()
        {
            // Arrange
            var calculResultat = new CalculResultat
            {
                PrixBase = 100m,
                DetailsFrais = new List<FraisDetail>
                {
                    new FraisDetail("Frais 1", 50m)
                }
            };

            // Assert 1
            calculResultat.TotalFrais.Should().Be(50m);
            calculResultat.Total.Should().Be(150m);

            // Act
            calculResultat.DetailsFrais.Add(new FraisDetail("Frais 2", 25m));

            // Assert 2
            calculResultat.TotalFrais.Should().Be(75m);
            calculResultat.Total.Should().Be(175m);
        }
    }
}

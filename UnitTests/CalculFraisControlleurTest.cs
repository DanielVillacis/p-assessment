using TestProgi.Services;
using TestProgi.Controllers;
using TestProgi.Domain.Entities;
using TestProgi.Domain.Enums;
using TestProgi.Domain.Models;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests
{
    public class CalculFraisControlleurTest
    {
        private Mock<ICalculateurDeFraisService> _calculateurServiceMock;
        private CalculFraisController _controller;

        [SetUp]
        public void Setup()
        {
            _calculateurServiceMock = new Mock<ICalculateurDeFraisService>();
            _controller = new CalculFraisController(_calculateurServiceMock.Object);
        }

        [Test]
        public void When_CalculerWithOrdinaireVehicle_Expect_OkResultWithCalculResultat()
        {
            // Arrange
            var request = new CalculFraisRequest
            {
                PrixBase = 1000m,
                TypeVehicule = TypeVehicule.Ordinaire
            };

            var expectedResult = new CalculResultat{
                PrixBase = 1000m,
                DetailsFrais = new List<FraisDetail>
                {
                    new FraisDetail("Frais de base", 50m),
                    new FraisDetail("Frais spéciaux", 20m),
                    new FraisDetail("Frais d'association", 10m),
                    new FraisDetail("Frais d'entreposage", 100m)
                }
            };

            _calculateurServiceMock
                .Setup(s => s.CalculerFrais(request.PrixBase, request.TypeVehicule))
                .Returns(expectedResult);

            // Act
            var actionResult = _controller.Calculer(request);

            // Assert
            var result = actionResult.Result.Should().BeOfType<OkObjectResult>().Subject;
            var calculResultat = result.Value.Should().BeOfType<CalculResultat>().Subject;

            calculResultat.PrixBase.Should().Be(expectedResult.PrixBase);
            calculResultat.DetailsFrais.Should().BeEquivalentTo(expectedResult.DetailsFrais);
            calculResultat.TotalFrais.Should().Be(expectedResult.TotalFrais);
            calculResultat.Total.Should().Be(expectedResult.Total);
        }

        [Test]
        public void When_CalculerWithInvalidPrixBase_Expect_BadRequest()
        {
            // Arrange
            var request = new CalculFraisRequest
            {
                PrixBase = -1,
                TypeVehicule = TypeVehicule.Ordinaire
            };

            _controller.ModelState.AddModelError("PrixBase", "Le prix doit être supérieur à 0");

            // Act
            var result = _controller.Calculer(request);

            // Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }



        [Test]
        public void When_CalculerWithDeluxeVehicule_Expect_ServiceCalledWithCorrectType()
        {
            // Arrange
            var request = new CalculFraisRequest
            {
                PrixBase = 1000m,
                TypeVehicule = TypeVehicule.Deluxe
            };

            var mockResult = new CalculResultat
            {
                PrixBase = 1000m,
                DetailsFrais = new List<FraisDetail>
                {
                    new FraisDetail("Test", 100m)
                }
            };

            _calculateurServiceMock
                .Setup(s => s.CalculerFrais(request.PrixBase, request.TypeVehicule))
                .Returns(mockResult);

            // Act
            var action = _controller.Calculer(request);

            // Assert
            _calculateurServiceMock.Verify(s => s.CalculerFrais(request.PrixBase, TypeVehicule.Deluxe), Times.Once);
        }

    }
}

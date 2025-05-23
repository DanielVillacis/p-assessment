using FluentAssertions;
using TestProgi.Domain.Enums;

namespace UnitTests
{
    public class TypeVehiculeExtensionTest
    {
        [Test]
        public void GetAvailableTypes_ShouldReturnAllEnumValues()
        {
            // Arrange
            var expectedTypes = new List<string> { "Ordinaire", "Deluxe" };

            // Act
            var availableTypes = TypeVehiculeExtensions.GetAvailableTypes();

            // Assert
            availableTypes.Should().BeEquivalentTo(expectedTypes);
            availableTypes.Count().Should().Be(2);
        }

        [Test]
        public void GetAvailableTypes_ShouldReturnNonEmptyList()
        {
            // Act
            var availableTypes = TypeVehiculeExtensions.GetAvailableTypes();
            // Assert
            availableTypes.Should().NotBeEmpty();
        }

        [Test]
        public void GetAvailableTypes_ShouldReturnStringValues()
        {
            // Act
            var availableTypes = TypeVehiculeExtensions.GetAvailableTypes();
            
            // Assert
            availableTypes.Should().AllBeOfType<string>();
            availableTypes.Should().Contain("Ordinaire");
            availableTypes.Should().Contain("Deluxe");
        }

        [Test]
        public void GetAvailableTypes_ShouldBeInSameOrderAsDeclaration()
        {
            // Arrange
            var expectedOrder = new List<string> { "Ordinaire", "Deluxe" };
            
            // Act
            var availableTypes = TypeVehiculeExtensions.GetAvailableTypes();

            // Assert
            availableTypes[0].Should().Be(expectedOrder[0]);
            availableTypes[1].Should().Be(expectedOrder[1]);
            availableTypes.Should().BeEquivalentTo(expectedOrder);
        }
    }
}

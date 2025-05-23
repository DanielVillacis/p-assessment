using FluentAssertions;
using TestProgi.Domain.Enums;
using System.Text.Json;

namespace UnitTests
{
    public class TypeVehiculeTest
    {
        [Test]
        public void TypeVehicule_ShouldBeConvertibleToString()
        {
            // Arrange
            var ordinaireString = "Ordinaire";
            var deluxeString = "Deluxe";

            // Assert
            TypeVehicule.Ordinaire.ToString().Should().Be(ordinaireString);
            TypeVehicule.Deluxe.ToString().Should().Be(deluxeString);
        }

        [Test]
        public void TypeVehicule_ShouldBeConvertibleFromString()
        {
            // Arrange
            var ordinaireString = "Ordinaire";
            var deluxeString = "Deluxe";

            // Act
            TypeVehicule ordinaireType = (TypeVehicule)Enum.Parse(typeof(TypeVehicule), ordinaireString);
            TypeVehicule deluxeType = (TypeVehicule)Enum.Parse(typeof(TypeVehicule), deluxeString);

            // Assert
            ordinaireType.Should().Be(TypeVehicule.Ordinaire);
            deluxeType.Should().Be(TypeVehicule.Deluxe);
        }


        /*
         * Tests de serialisation et deserialisation JSON
         */
        [Test]
        public void TypeVehicule_ShouldSerializeToJson()
        {
            // Arrange
            var vehicule = TypeVehicule.Ordinaire;

            // Act
            var json = JsonSerializer.Serialize(vehicule);

            // Assert
            json.Should().Be("\"Ordinaire\"");
        }

        [Test]
        public void TypeVehicule_ShouldDeserializeFromJsonString()
        {
            // Arrange
            var json = "\"Ordinaire\"";

            // Act
            var vehicule = JsonSerializer.Deserialize<TypeVehicule>(json);

            // Assert
            vehicule.Should().Be(TypeVehicule.Ordinaire);
        }
    }
}

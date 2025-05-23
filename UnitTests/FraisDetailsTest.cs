using FluentAssertions;
using TestProgi.Domain.Entities;

namespace UnitTests
{
    public class FraisDetailsTest
    {
        [Test]
        public void FraisDetails_WithValidInputs_ShouldCreateInstance()
        {
            // Arrange et Act
            var fraisDetail = new FraisDetail("Description", 100m);

            // Assert
            fraisDetail.Description.Should().Be("Description");
            fraisDetail.Montant.Should().Be(100m);
        }

        [Test]
        public void FraisDetails_WithEmptyDescription_ShouldThrowArgumentException()
        {
            // Arrange et Act
            Action action = () => new FraisDetail("", 100m);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void FraisDetails_WithNullDescription_ShouldThrowArgumentException()
        {
            // Arrange et Act
            Action action = () => new FraisDetail(null, 100m);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void FraisDetails_WithNegativeMontant_ShouldThrowArgumentException()
        {
            // Arrange et Act
            Action action = () => new FraisDetail("Description", -1m);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

    }
}
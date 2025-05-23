using FluentAssertions;
using TestProgi.Domain.Entities;

namespace UnitTests;

public class UnitTest1
{
    [Fact]
    public void Constructor_WithValidInputs_ShouldCreateInstance()
    {
        // Arrange & Act
        var fraisDetail = new FraisDetail("Test Description", 100m);

        // Assert
        fraisDetail.Description.Should().Be("Test Description");
        fraisDetail.Montant.Should().Be(100m);
    }

    [Fact]
    public void Constructor_WithEmptyDescription_ShouldThrowArgumentException()
    {
        // Arrange & Act
        Action action = () => new FraisDetail("", 100m);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("La description ne peut pas etre vide*");
    }

    [Fact]
    public void Constructor_WithNullDescription_ShouldThrowArgumentException()
    {
        // Arrange & Act
        Action action = () => new FraisDetail(null, 100m);

        // Assert
        action.Should().Throw<ArgumentException>();
    }
}
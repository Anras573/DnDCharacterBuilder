using DnDCharacterBuilder.Domain.Dice;
using FluentAssertions;

namespace DnDCharacterBuilder.Domain.Tests.Dice;

[TestClass]
public class DieTests
{
    [TestMethod]
    [DataRow(-1)]
    [DataRow(0)]
    [DataRow(1)]
    public void CreateDie_WithInvalidSides_ThrowsException(int invalidSides)
    {
        // Arrange
        
        // Act
        Action act = () => Die.Create(invalidSides);
        
        // Assert
        act.Should().Throw<ArgumentException>();
    }
    
    [TestMethod]
    [DataRow(2)]
    [DataRow(4)]
    [DataRow(6)]
    [DataRow(8)]
    [DataRow(10)]
    [DataRow(12)]
    [DataRow(20)]
    [DataRow(100)]
    public void CreateDie_WithValidSides_ReturnsDie(int validSides)
    {
        // Arrange
        
        // Act
        var die = Die.Create(validSides);
        
        // Assert
        die.Sides.Should().Be(validSides);
    }
}
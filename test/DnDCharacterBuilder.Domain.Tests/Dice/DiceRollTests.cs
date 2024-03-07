using DnDCharacterBuilder.Domain.Dice;
using FluentAssertions;

namespace DnDCharacterBuilder.Domain.Tests.Dice;

[TestClass]
public class DiceRollTests
{
    [TestMethod]
    public void CantCreateDiceRollWithNoDie()
    {
        // Arrange
        List<Die> dice = null!;
        List<int> results = [1, 2, 3];
        
        // Act
        var act = () => DiceRoll.Create(dice, results);
        
        // Assert
        act.Should().Throw<ArgumentNullException>();
    }
    
    [TestMethod]
    public void CantCreateDiceRollWithNoResults()
    {
        // Arrange
        List<Die> dice = [Die.Create(6)];
        List<int> results = null!;
        
        // Act
        var act = () => DiceRoll.Create(dice, results);
        
        // Assert
        act.Should().Throw<ArgumentNullException>();
    }
    
    [TestMethod]
    public void CantCreateDiceRollWithDifferentNumberOfDiceAndResults()
    {
        // Arrange
        List<Die> dice = [Die.Create(6), Die.Create(6)];
        List<int> results = [1, 2, 3];
        
        // Act
        var act = () => DiceRoll.Create(dice, results);
        
        // Assert
        act.Should().Throw<ArgumentException>();
    }
    
    [TestMethod]
    public void CantCreateDiceRollWithResultsGreaterThanSumOfDiceSides()
    {
        // Arrange
        List<Die> dice = [Die.Create(6), Die.Create(6)];
        List<int> results = [6, 7];
        
        // Act
        var act = () => DiceRoll.Create(dice, results);
        
        // Assert
        act.Should().Throw<ArgumentException>();
    }
    
    [TestMethod]
    public void CanCreateDiceRollWithValidDiceAndResults()
    {
        // Arrange
        List<Die> dice = [Die.Create(6), Die.Create(6)];
        List<int> results = [1, 2];
        
        // Act
        var diceRoll = DiceRoll.Create(dice, results);
        
        // Assert
        diceRoll.RolledDice.Should().BeEquivalentTo(dice);
        diceRoll.Results.Should().BeEquivalentTo(results);
    }
    
    [TestMethod]
    public void CanGetTotalOfDiceRoll()
    {
        // Arrange
        List<Die> dice = [Die.Create(6), Die.Create(6)];
        List<int> results = [1, 2];
        
        // Act
        var diceRoll = DiceRoll.Create(dice, results);
        
        // Assert
        diceRoll.Total.Should().Be(3);
    }
}
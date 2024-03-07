using DnDCharacterBuilder.Application.Dice;
using DnDCharacterBuilder.Application.Tests.Fakes;
using DnDCharacterBuilder.Domain.Dice;
using FluentAssertions;

namespace DnDCharacterBuilder.Application.Tests.Dice;

[TestClass]
public class DieRollerTests
{
    [TestMethod]
    public void RollDie_ShouldReturnDieRoll()
    {
        // Arrange
        const int result = 4;
        const DieType dieType = DieType.D6;
        
        var random = new RandomFake(result);
        var dieRoller = new DieRoller(random);
        var die = Die.Create(6);
        
        // Act
        var actual = dieRoller.RollDie(dieType);
        
        // Assert
        Assert.AreEqual(die, actual.RolledDie);
        Assert.AreEqual(result, actual.Result);
    }
    
    [TestMethod]
    public void RollDice_ShouldReturnDiceRoll()
    {
        // Arrange
        const int result = 4;
        const DieType dieType = DieType.D6;
        const int numberOfDice = 3;
        
        var random = new RandomFake(result);
        var dieRoller = new DieRoller(random);
        
        // Act
        var actual = dieRoller.RollDice(numberOfDice, dieType);
        
        // Assert
        var dice = new List<Die> { Die.Create(6), Die.Create(6), Die.Create(6) };
        var results = new List<int> { result, result, result };
        actual.RolledDice.Should().BeEquivalentTo(dice);
        actual.Results.Should().BeEquivalentTo(results);
    }
    
    [TestMethod]
    public void RollDice_ShouldReturnDiceRoll_WhenGivenDiceExpression()
    {
        // Arrange
        const int result = 4;
        const string diceExpression = "3d6";
        
        var random = new RandomFake(result);
        var dieRoller = new DieRoller(random);
        
        // Act
        var actual = dieRoller.RollDice(diceExpression);
        
        // Assert
        var dice = new List<Die> { Die.Create(6), Die.Create(6), Die.Create(6) };
        var results = new List<int> { result, result, result };
        actual.RolledDice.Should().BeEquivalentTo(dice);
        actual.Results.Should().BeEquivalentTo(results);
    }
}
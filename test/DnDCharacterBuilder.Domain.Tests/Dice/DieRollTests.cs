using DnDCharacterBuilder.Domain.Dice;
using FluentAssertions;

namespace DnDCharacterBuilder.Domain.Tests.Dice;

[TestClass]
public class DieRollTests
{
    [TestMethod]
    public void CantCreateDieRollWithNoDie()
    {
        // Arrange
        Die die = null!;
        
        // Act
        var act = () => DieRoll.Create(die, 2);
        
        // Assert
        act.Should().Throw<ArgumentNullException>();
    }
    
    [TestMethod]
    [DataRow(7)]
    [DataRow(0)]
    [DataRow(-1)]
    public void CantCreateDieRollWithInvalidResult(int invalidResult)
    {
        // Arrange
        var die = Die.Create(6);
        
        // Act
        var act = () => DieRoll.Create(die, invalidResult);
        
        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
    
    [TestMethod]
    public void CanCreateDieRollWithValidDieAndResult()
    {
        // Arrange
        var die = Die.Create(6);
        
        // Act
        var dieRoll = DieRoll.Create(die, 2);
        
        // Assert
        dieRoll.RolledDie.Should().Be(die);
        dieRoll.Result.Should().Be(2);
    }
}
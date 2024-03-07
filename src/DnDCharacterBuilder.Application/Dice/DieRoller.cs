using DnDCharacterBuilder.Application.Random;
using DnDCharacterBuilder.Domain.Dice;

namespace DnDCharacterBuilder.Application.Dice;

public class DieRoller(IRandom random) : IDieRoller
{
    private static readonly Dictionary<DieType, Die> Dice = new()
    {
        { DieType.D2, Die.Create(2) },
        { DieType.D4, Die.Create(4) },
        { DieType.D6, Die.Create(6) },
        { DieType.D8, Die.Create(8) },
        { DieType.D10, Die.Create(10) },
        { DieType.D12, Die.Create(12) },
        { DieType.D20, Die.Create(20) },
        { DieType.D100, Die.Create(100) }
    };
    
    public DieRoll RollDie(DieType dieType)
    {
        var die = Dice[dieType];
        var result = random.NextInt(1, die.Sides);
        return DieRoll.Create(die, result);
    }

    public DiceRoll RollDice(int numberOfDice, DieType dieType)
    {
        var dice = new List<Die>();
        
        for (var i = 0; i < numberOfDice; i++)
        {
            dice.Add(Dice[dieType]);
        }

        var results = dice.Select(die => random.NextInt(1, die.Sides)).ToList();

        return DiceRoll.Create(dice, results);
    }

    public DiceRoll RollDice(string diceExpression)
    {
        var parts = diceExpression.Split('d');
        var numberOfDice = int.Parse(parts[0]);
        var dieType = (DieType)Enum.Parse(typeof(DieType), parts[1]);
        return RollDice(numberOfDice, dieType);
    }
}
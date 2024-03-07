namespace DnDCharacterBuilder.Domain.Dice;

public record DieRoll
{
    public static DieRoll Create(Die die, int result)
    {
        ArgumentNullException.ThrowIfNull(die);
        
        if (result < 1 || result > die.Sides)
        {
            throw new ArgumentOutOfRangeException(nameof(result), $"The result must be between 1 and {die.Sides}.");
        }

        return new DieRoll(die, result);
    }
    
    private DieRoll(Die die, int result)
    {
        RolledDie = die;
        Result = result;
    }

    public int Result { get; private set; }

    public Die RolledDie { get; private set; }
}
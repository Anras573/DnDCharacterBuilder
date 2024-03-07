namespace DnDCharacterBuilder.Domain.Dice;

public record DiceRoll
{
    public static DiceRoll Create(IReadOnlyCollection<Die> rolledDice, IReadOnlyCollection<int> results)
    {
        ArgumentNullException.ThrowIfNull(rolledDice);
        ArgumentNullException.ThrowIfNull(results);
        
        if (rolledDice.Count != results.Count)
        {
            throw new ArgumentException("The number of dice and the number of results must be the same.");
        }
        
        if (rolledDice.Sum(r => r.Sides) < results.Sum())
        {
            throw new ArgumentException("The sum of the results must be less than or equal to the sum of the sides of the dice.");
        }
        
        return new DiceRoll(rolledDice, results);
    }
    
    private DiceRoll(IReadOnlyCollection<Die> rolledDice, IReadOnlyCollection<int> results)
    {
        RolledDice = rolledDice;
        Results = results;
    }

    public IReadOnlyCollection<int> Results { get; private set; }

    public IReadOnlyCollection<Die> RolledDice { get; private set; }
    
    public int Total => Results.Sum();
}

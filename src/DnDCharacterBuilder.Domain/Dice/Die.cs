using System.Dynamic;

namespace DnDCharacterBuilder.Domain.Dice;

public record Die
{
    public static Die Create(int sides)
    {
        if (sides < 2)
        {
            throw new ArgumentOutOfRangeException(nameof(sides), "A die must have at least 2 sides.");
        }

        return new Die(sides);
    }
    
    private Die(int sides)
    {
        Sides = sides;
    }

    public int Sides { get; private set; }
}
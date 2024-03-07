using DnDCharacterBuilder.Domain.Dice;

namespace DnDCharacterBuilder.Application.Dice;

public interface IDieRoller
{
    DieRoll RollDie(DieType dieType);
    DiceRoll RollDice(int numberOfDice, DieType dieType);
    DiceRoll RollDice(string diceExpression);
}
namespace DnDCharacterBuilder.Application.Random;

public interface IRandom
{
    int NextInt(int minValueInclusive, int maxValueInclusive);
}
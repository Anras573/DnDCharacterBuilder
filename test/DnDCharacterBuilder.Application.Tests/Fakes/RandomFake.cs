using DnDCharacterBuilder.Application.Random;

namespace DnDCharacterBuilder.Application.Tests.Fakes;

public class RandomFake(int value) : IRandom
{
    public int NextInt(int minValueInclusive, int maxValueInclusive) => value;
}
using System.Security.Cryptography;

namespace DnDCharacterBuilder.Application.Random;

public class Random : IRandom
{
    public int NextInt(int minValue, int maxValue) => RandomNumberGenerator.GetInt32(minValue, maxValue + 1);
}
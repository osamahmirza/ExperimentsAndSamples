using FizzBuzzEnterprise;
using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz.Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var ruleSet = (FizzBuzzRuleSet)Enum.Parse(
                typeof(FizzBuzzRuleSet), Console.ReadLine());
            var number = int.Parse(Console.ReadLine());

            IFizzBuzzEngine engine = FizzBuzzEngineFactory.Create(ruleSet);
            var result = engine.GetString(number);

            //using (var writer = new StreamWriter(
            //    Environment.GetEnvironmentVariable("OUTPUT_PATH"), true))
            {
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }
    }
}

public static class FizzBuzzEngineFactory
{
    //creating dictionary of Game levels by using generic delegate. Loading all Games at once
    //Note: I could have used reflections here, but reflections are very expensive and could be very hard to debug

    public static Dictionary<FizzBuzzRuleSet, Func<IFizzBuzzEngine>> FizzBuzzEngineCreators =
        new Dictionary<FizzBuzzRuleSet, Func<IFizzBuzzEngine>>()
        {
            { FizzBuzzRuleSet.FizzBuzzBoomBangCrashDivisible, () => new FizzBuzzBoomBangCrashDivisibleLevel() },
            { FizzBuzzRuleSet.FizzBuzzDigits, () => new FizzBuzzDigitsLevel() },
            { FizzBuzzRuleSet.FizzBuzzDivisible, () => new FizzBuzzDivisibleLevel() },
            { FizzBuzzRuleSet.FizzBuzzDivisibleOrDigits, () => new FizzBuzzDivisibleOrDigitsLevel() }
        };

    //Simply taking the enum and finding the corresponding object in dictionay
    public static IFizzBuzzEngine Create(FizzBuzzRuleSet ruleSet)
    {
        return FizzBuzzEngineCreators[ruleSet]();
    }
}

//Abstract base class which is implementing the interface and providing a template for all Games
public abstract class FizzBuzzEngineBase : IFizzBuzzEngine
{
    //Enum to distinguish between divisible logic
    public enum SequenceType
    {
        Short,
        Long
    }
    //Interface implementation
    public abstract string GetString(int number);

    //Common logic between first two games: FizzBuzzDivisible & FizzBuzzBoomBangCrashDivisible
    public string FullStack(int number, SequenceType type)
    {
        StringBuilder scoop = new StringBuilder();
        {

            if (type == SequenceType.Short || type == SequenceType.Long)
            {
                if (number % 3 == 0)
                    scoop.Append("Fizz");
                if (number % 5 == 0)
                    scoop.Append("Buzz");
            }
            if (type == SequenceType.Long)
            {
                if (number % 7 == 0)
                    scoop.Append("Boom");
                if (number % 11 == 0)
                    scoop.Append("Bang");
                if (number % 13 == 0)
                    scoop.Append("Crash");
            }
        }

        return SpitSequence(scoop, number);
    }

    //Common logic between last two games: FizzBuzzDigits & FizzBuzzDivisibleOrDigits
    public string FullStackDigit(int number)
    {

        char[] characters = number.ToString().ToCharArray();
        StringBuilder scoop = new StringBuilder();

        foreach (var item in characters)
        {
            if (item.Equals('3'))
                scoop.Append("Fizz");
            if (item.Equals('5'))
                scoop.Append("Buzz");
        }

        return SpitSequence(scoop, number);

    }

    //Common logic among all games
    public string SpitSequence(StringBuilder scoop, int number)
    {
        if (scoop.Length < 1)
            scoop.Append(number.ToString());

        return scoop.ToString();
    }
}
//Game 1
public class FizzBuzzDivisibleLevel : FizzBuzzEngineBase
{
    public override string GetString(int number)
    {
        return base.FullStack(number, SequenceType.Short);
    }
}
//Game 2
public class FizzBuzzBoomBangCrashDivisibleLevel : FizzBuzzEngineBase
{
    public override string GetString(int number)
    {
        return base.FullStack(number, SequenceType.Long);
    }
}
//Game 3
public class FizzBuzzDigitsLevel : FizzBuzzEngineBase
{
    public override string GetString(int number)
    {

        return base.FullStackDigit(number);
    }
}
//Game 4
public class FizzBuzzDivisibleOrDigitsLevel : FizzBuzzEngineBase
{
    public override string GetString(int number)
    {
        string result = string.Empty;
        string fizzBuzzDivsible = base.FullStack(number, SequenceType.Short);
        string fizzBuzzDigit = base.FullStackDigit(number);
        string stringNum = number.ToString();

        if (fizzBuzzDivsible.Equals(stringNum) && fizzBuzzDigit.Equals(stringNum))
            return stringNum;
        else
            return fizzBuzzDivsible + fizzBuzzDigit;

    }
}

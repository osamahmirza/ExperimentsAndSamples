using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FizzBuzzEnterprise
{
    /// <summary>
    /// Defines the interface for playing a Fizz Buzz game.
    /// </summary>
    public interface IFizzBuzzEngine
    {
        /// <summary>
        /// Gets the output from a single round in a Fizz Buzz game.
        /// </summary>
        string GetString(int number);
    }

    /// <summary>
    /// Defines various rule sets for Fizz Buzz games.
    /// </summary>
    public enum FizzBuzzRuleSet
    {
        /// <summary>
        /// The standard game - based on the divisibility of a number.
        /// </summary>
        FizzBuzzDivisible,

        /// <summary>
        /// The standard game with additional substitutions for divisibility.
        /// </summary>
        FizzBuzzBoomBangCrashDivisible,

        /// <summary>
        /// A game based on the digits contained in a number.
        /// </summary>
        FizzBuzzDigits,

        /// <summary>
        /// A combination of FizzBuzzDivisible and FizzBuzzDigits.
        /// </summary>
        FizzBuzzDivisibleOrDigits
    }
}

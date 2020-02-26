using FizzBuzz.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    /// <summary>
    /// Starting point for the app
    /// </summary>
    public class FizzBuzzRunner
    {
        private readonly IFizzBuzzService fizzBuzzService;

        public FizzBuzzRunner(IFizzBuzzService fizzBuzzService)
        {
            this.fizzBuzzService = fizzBuzzService;
        }

        /// <summary>
        /// App starting
        /// </summary>
        public void Run()
        {
            // run program until user exits
            var yesToExit = "y";
            while (yesToExit.ToLower() == "y")
            {
                // get valid initial range value
                int rangeFromValue;
                do
                {
                    Console.WriteLine("Enter initial range value:");
                    var rangeFrom = Console.ReadLine();
                    if (!int.TryParse(rangeFrom, out rangeFromValue) || rangeFromValue <= 0)
                    {
                        ShowErrorMessage("Invalid input. Please enter valid number which is greater than zero");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                } while (rangeFromValue <= 0);

                // get valid end range value
                int rangeToValue;
                do
                {
                    Console.WriteLine("Enter end range value:");
                    var rangeTo = Console.ReadLine();
                    if (!int.TryParse(rangeTo, out rangeToValue) || rangeToValue <= rangeFromValue)
                    {
                        ShowErrorMessage("Invalid input. Please enter valid number which is greater than initial range value");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                } while (rangeToValue <= rangeFromValue);

                Console.WriteLine($"Results for the range {rangeFromValue}-{rangeToValue}:");

                var results = new List<string>();
                // loop through the range and print accordingly
                for (int i = rangeFromValue; i <= rangeToValue; i++)
                {
                    var output = this.fizzBuzzService.FizzBuzz(i);
                    results.Add(output);
                    Console.Write(output + (i == rangeToValue ? "" : " "));
                }
                var totalFizzCount = results.Count( x => x == CommonConstant.FIZZ);
                Console.Write($" {CommonConstant.FIZZ}: {totalFizzCount} ");
                var totalBuzzCount = results.Count(x => x == CommonConstant.BUZZ);
                Console.Write($"{CommonConstant.BUZZ}: {totalBuzzCount} ");
                var totalFizzBuzzCount = results.Count(x => x == CommonConstant.FIZZBUZZ);
                Console.Write($"{CommonConstant.FIZZBUZZ}: {totalFizzBuzzCount} ");
                var totalLuckyCount = results.Count(x => x == CommonConstant.LUCKY);
                Console.Write($"{CommonConstant.LUCKY}: {totalLuckyCount} ");
                var integerCount = results.Count() - totalFizzCount - totalBuzzCount - totalFizzBuzzCount - totalLuckyCount;
                Console.Write($"{CommonConstant.INTEGER}: {integerCount}");
                Console.WriteLine();
                // confirm user if it needs to be run again
                Console.WriteLine("Press Y to continue or any other key to exit the program.");
                yesToExit = Console.ReadLine();
            }
        }

        private static void ShowErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }
    }
}

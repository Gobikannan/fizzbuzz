using System;

namespace FizzBuzz.Services
{
    /// <summary>
    /// Process the number with fizzbuzz
    /// </summary>
    public class FizzBuzzService : IFizzBuzzService
    {
        /// <summary>
        /// Should return if the number is multiple of given number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        private bool IsMultiple(int number, int by)
        {
            return (number % by) == 0;
        }

        public string FizzBuzz(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException("Number should be greater than zero");
            }
            if (number.ToString().Contains("3")) {
                return CommonConstant.LUCKY;
            }
            var hasFizz = IsMultiple(number, 3);
            var hasBuzz = IsMultiple(number, 5);
            if (hasFizz && hasBuzz)
            {
                return CommonConstant.FIZZBUZZ;
            }
            else if (hasFizz)
            {
                return CommonConstant.FIZZ;
            }
            else if (hasBuzz)
            {
                return CommonConstant.BUZZ;
            }
            return number.ToString();
        }
    }
}

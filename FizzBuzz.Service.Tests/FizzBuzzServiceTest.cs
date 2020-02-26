using FizzBuzz.Services;
using System;
using Xunit;

namespace FizzBuzz.Service.Tests
{
    public class FizzBuzzServiceTest
    {
        private readonly FizzBuzzService fizzBuzzService;

        public FizzBuzzServiceTest()
        {
            this.fizzBuzzService = new FizzBuzzService();
        }

        [Theory]
        [InlineData(3)]
        [InlineData(13)]
        [InlineData(513)]
        [InlineData(37)]
        public void ShouldReturnLuckyIfNumberHasThree(int value)
        {
            var result = this.fizzBuzzService.FizzBuzz(value);
            Assert.Equal(CommonConstant.LUCKY, result);
        }

        [Theory]
        [InlineData(27)]
        [InlineData(6)]
        [InlineData(9)]
        public void ShouldReturnFizzForMultiplesOfThree(int value)
        {
            var result = this.fizzBuzzService.FizzBuzz(value);
            Assert.Equal(CommonConstant.FIZZ, result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(65)]
        [InlineData(100)]
        public void ShouldReturnBuzzForMultiplesOfFive(int value)
        {
            var result = this.fizzBuzzService.FizzBuzz(value);
            Assert.Equal(CommonConstant.BUZZ, result);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(45)]
        [InlineData(60)]
        public void ShouldReturnFizzBuzzForMultiplesOfThreeAndFive(int value)
        {
            var result = this.fizzBuzzService.FizzBuzz(value);
            Assert.Equal(CommonConstant.FIZZBUZZ, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(8)]
        [InlineData(52)]
        public void ShouldReturnNumberIfItIsNotMultiplesOfThreeOrFive(int value)
        {
            var result = this.fizzBuzzService.FizzBuzz(value);
            Assert.Equal(value.ToString(), result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-3)]
        public void ShouldThrowErroIfNumberIsNotGreaterThanZero(int value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.fizzBuzzService.FizzBuzz(value));
        }
    }
}

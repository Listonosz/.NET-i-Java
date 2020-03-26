using NUnit.Framework;
using System.Collections.Generic;
using FizzBuzz;

namespace FizzBuzz.NUnitTests
{
    [TestFixture]
    public class FizzBuzzerTests
    {
        [Test]
        public void NonSpecialNumberReturnItself()
        {
            List<int> numbers = new List<int>() { 1 };
            List<string> expectedResults = new List<string>() { "1" };
            List<string> actualResluts = FizzBuzzer.MillNumbers(numbers);
            Assert.AreEqual(expectedResults[0], actualResluts[0]);
        }
        [Test]
        public void IfDividedBy7ReturnBazzinga()
        {
            List<int> numbers = new List<int>() { 21 };
            List<string> expectedResults = new List<string>() { "Bazzinga" };
            List<string> actualResluts = FizzBuzzer.MillNumbers(numbers);
            Assert.AreEqual(expectedResults[0], actualResluts[0]);
        }
        [Test]
        public void IfDividedBy3and5ReturnFizzBuzz()
        {
            List<int> numbers = new List<int>() { 15 };
            List<string> expectedResults = new List<string>() { "FizzBuzz" };
            List<string> actualResluts = FizzBuzzer.MillNumbers(numbers);
            Assert.AreEqual(expectedResults[0], actualResluts[0]);
        }
        [Test]
        public void IfDividedBy3ReturnFizz()
        {
            List<int> numbers = new List<int>() { 3 };
            List<string> expectedResults = new List<string>() { "Fizz" };
            List<string> actualResluts = FizzBuzzer.MillNumbers(numbers);
            Assert.AreEqual(expectedResults[0], actualResluts[0]);
        }
        [Test]
        public void IfDividedBy5ReturnBuzz()
        {
            List<int> numbers = new List<int>() { 5 };
            List<string> expectedResults = new List<string>() { "Buzz" };
            List<string> actualResluts = FizzBuzzer.MillNumbers(numbers);
            Assert.AreEqual(expectedResults[0], actualResluts[0]);
        }
        [Test]
        public void If5and3InNumberReturnFizzBuzz()
        {
            List<int> numbers = new List<int>() { 3535 };
            List<string> expectedResults = new List<string>() { "FizzBuzz" };
            List<string> actualResluts = FizzBuzzer.MillNumbers(numbers);
            Assert.AreEqual(expectedResults[0], actualResluts[0]);
        }
        [Test]
        public void If5InNumberReturnBuzz()
        {
            List<int> numbers = new List<int>() { 57 };
            List<string> expectedResults = new List<string>() { "Buzz" };
            List<string> actualResluts = FizzBuzzer.MillNumbers(numbers);
            Assert.AreEqual(expectedResults[0], actualResluts[0]);
        }
        [Test]
        public void MoreRealisticTest()
        {
            List<int> numbers = new List<int>() {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                11, 12, 13, 14, 15, 16, 17, 18, 19, 20 ,354 };
            List<string> expectedResults = new List<string>() {
                "1","2","Fizz","4","Buzz","Fizz","Bazzinga","8","Fizz","Buzz",
                 "11","Fizz","13","Bazzinga","FizzBuzz","16","17","Fizz","19","Buzz","FizzBuzz"};
            var actualResluts = FizzBuzzer.MillNumbers(numbers);
            CollectionAssert.AreEqual(expectedResults, actualResluts);
        }
    }
}
using EndavaInternship.Liskov.Exemple1;
using NUnit.Framework;

namespace EndavaInternship.Liskov.UnitTests.Exemple1
{
    [TestFixture]
    public class AreaCalculatorTests
    {
        [TestCase(1, 2, 2)]
        [TestCase(2, 2, 4)]
        public void ShouldCalculateCorrectAreaFor(int lenght, int widht, int expectedResult)
        {
            var shape = new Square();
            shape.Lenght = lenght;
            shape.Width = widht;

            var actualResult = AreaCalculator.CalculateFor(shape);

            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
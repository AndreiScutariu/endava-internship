using System;
using EndavaInternship.Liskov.Exemple2;
using NUnit.Framework;

namespace EndavaInternship.Liskov.UnitTests.Exemple2
{
    [TestFixture]
    public class OldRectangleAreaUnitTests
    {
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        public void ShouldHaveInvalidPreconditionsFor(int lenght, int width)
        {
            Assert.Throws<Exception>(() =>
            {
                var shape = new OldAndStupidRectangle(lenght, width);

                ShapeAreaManager.CalculateArea(shape);
            });
        }

        [TestCase(2, 3, 6)]
        [TestCase(3, 3, 9)]
        [TestCase(3, 2, 6)]
        [TestCase(1, 2, 2)]
        public void ShouldCalculateCorectAreaFor(int lenght, int width, int expectedArea)
        {
            var shape = new OldAndStupidRectangle(lenght, width);

            var actualArea = ShapeAreaManager.CalculateArea(shape);
            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestCase(5, 0)]
        [TestCase(0, 5)]
        [TestCase(1, 1)]
        public void ShouldHaveInvalidPostconditionsFor(int lenght, int width)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var shape = new OldAndStupidRectangle(lenght, width);

                ShapeAreaManager.CalculateArea(shape);
            }, "Something is wrong!");
        }
    }
}
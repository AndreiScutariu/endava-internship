using System;
using NUnit.Framework;

namespace EndavaInternship.Liskov.UnitTests
{
    [TestFixture]
    public class NewRectangleAreaUnitTests
    {
        [TestCase(2.5, 3.5, 8.75)]
        public void ShouldCalculateCorectAreaFor(double lenght, double width, double expectedArea)
        {
            var shape = new NewAndSmartRectangle(lenght, width);

            var actualArea = ShapeAreaManager.CalculateArea(shape);
            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestCase(5, 0)]
        [TestCase(0, 5)]
        [TestCase(1, 1.25)]
        public void ShouldHaveInvalidPostconditionsFor(double lenght, double width)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var shape = new NewAndSmartRectangle(lenght, width);

                ShapeAreaManager.CalculateArea(shape);
            });
        }
    }
}
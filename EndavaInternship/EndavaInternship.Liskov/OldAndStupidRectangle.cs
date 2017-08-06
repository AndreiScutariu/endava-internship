using System;

namespace EndavaInternship.Liskov
{
    public class OldAndStupidRectangle
    {
        public int Lenght { get; set; }

        public int Width { get; set; }

        public int Area()
        {
            if (Lenght < 0)
                throw new Exception("Lenght is not valid!");

            if (Width < 0)
                throw new Exception("Width is not valid!");

            var area = CalculateArea();

            if (area == 0)
            {
                throw new InvalidOperationException("Something is wrong!");
            }

            return area;
        }

        private int CalculateArea()
        {
            var sum = 0;

            for (var i = 0; i < Width; i++)
            {
                sum += Lenght;
            }

            return sum;
        }
    }
}
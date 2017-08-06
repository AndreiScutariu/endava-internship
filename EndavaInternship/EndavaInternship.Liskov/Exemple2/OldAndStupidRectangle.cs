using System;

namespace EndavaInternship.Liskov.Exemple2
{
    public class OldAndStupidRectangle
    {
        public OldAndStupidRectangle(int lenght, int width)
        {
            Lenght = lenght;
            Width = width;
        }

        public int Lenght { get; set; }

        public int Width { get; set; }

        public virtual double Area()
        {
            if (Lenght < 0)
                throw new Exception("Lenght is not valid!");

            if (Width < 0)
                throw new Exception("Width is not valid!");

            var area = CalculateArea();

            if (area <= 1)
                throw new InvalidOperationException("Something is wrong!");

            return area;
        }

        private double CalculateArea()
        {
            var sum = 0d;

            for (var i = 0; i < Width; i++)
                sum += Lenght;

            return sum;
        }
    }
}
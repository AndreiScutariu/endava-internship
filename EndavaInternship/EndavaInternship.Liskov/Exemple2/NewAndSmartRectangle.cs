using System;

namespace EndavaInternship.Liskov.Exemple2
{
    public class NewAndSmartRectangle : OldAndStupidRectangle
    {
        public NewAndSmartRectangle(double lenght, double width) : base((int) lenght, (int) width)
        {
            Lenght = lenght;
            Width = width;
        }

        public new double Lenght { get; set; }

        public new double Width { get; set; }

        public override double Area()
        {
            if (Lenght < 0)
                throw new Exception("Lenght is not valid!");

            if (Width < 0)
                throw new Exception("Width is not valid!");

            if (Width == Lenght)
                throw new Exception("This is a Square!");

            var area = CalculateArea();

            if ((area > 1) && (area < 1.9d))
                throw new InvalidOperationException("Useless area!");

            if (area <= 1)
                throw new InvalidOperationException("Something is wrong!");

            return area;
        }

        private double CalculateArea()
        {
            return Width*Lenght;
        }
    }
}
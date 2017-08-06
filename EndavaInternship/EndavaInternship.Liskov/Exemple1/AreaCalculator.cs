namespace EndavaInternship.Liskov.Exemple1
{
    public class AreaCalculator
    {
        public static int CalculateFor(Rectangle shape)
        {
            return shape.Lenght*shape.Width;
        }
    }
}
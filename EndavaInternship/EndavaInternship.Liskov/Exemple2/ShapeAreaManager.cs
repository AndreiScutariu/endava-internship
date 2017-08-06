namespace EndavaInternship.Liskov.Exemple2
{
    public class ShapeAreaManager
    {
        public static double CalculateArea(OldAndStupidRectangle shape)
        {
            return shape.Area();
        }
    }
}
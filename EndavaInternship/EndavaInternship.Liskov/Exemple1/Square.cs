namespace EndavaInternship.Liskov.Exemple1
{
    public class Square : Rectangle
    {
        public override int Lenght
        {
            get { return LenghtInternalValue; }
            set
            {
                LenghtInternalValue = value;
                WidthInternalValue = value;
            }
        }

        public override int Width
        {
            get { return WidthInternalValue; }
            set
            {
                LenghtInternalValue = value;
                WidthInternalValue = value;
            }
        }
    }
}
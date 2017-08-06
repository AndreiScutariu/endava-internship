namespace EndavaInternship.Liskov.Exemple1
{
    public class Rectangle
    {
        protected int LenghtInternalValue;

        protected int WidthInternalValue;

        public virtual int Lenght
        {
            get { return LenghtInternalValue; }
            set { LenghtInternalValue = value; }
        }

        public virtual int Width
        {
            get { return WidthInternalValue; }
            set { WidthInternalValue = value; }
        }
    }
}
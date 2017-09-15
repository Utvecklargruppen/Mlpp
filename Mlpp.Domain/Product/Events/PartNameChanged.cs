namespace Mlpp.Domain.Product.Events
{
    public class PartNameChanged
    {
        public PartNameChanged(Part part)
        {
            Part = part;
        }

        public Part Part { get; }
    }
}

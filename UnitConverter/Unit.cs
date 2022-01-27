namespace Converter
{
    public class Unit
    {
        public decimal Amount { get; set; }

        public Prefix Prefix { get; set; }

        public UnitType UnitType { get; set; }

        public string StringUnit { get; set; }
    }
}

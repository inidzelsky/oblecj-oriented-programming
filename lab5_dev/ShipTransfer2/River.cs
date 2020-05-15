namespace ShipTransfer2
{
    public class River
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int MaxWidth { get; set; }
        public int Tributaries { get; set; }
        
        public override string ToString()
        {
            return $"{{ River name: {Name} | Length: {Length} | Max width: {MaxWidth} | Truburaries : {Tributaries}}}";
        }
    }
}
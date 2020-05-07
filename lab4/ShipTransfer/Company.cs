namespace ShipTransfer
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WaterId { get; set; }

        public override string ToString()
        {
            return $"Company name: {Name}";
        }
    }
}
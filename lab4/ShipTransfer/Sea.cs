namespace ShipTransfer
{
    public class Sea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Square { get; set; }

        public override string ToString()
        {
            return $"{{ Sea name: {Name} | Square: {Square} }}";
        }
    }
}
namespace ShipTransfer2
{
    public class Ship
    {
        public int Id { get; set; }

        public int Passengers { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public bool SeaType { get; set; }

        public override string ToString()
        {
            return $"{{ Ship name: {Name} | Built in: {Year} | Is sea: {SeaType} | Passengers: {Passengers} }}";
        }
    }
}
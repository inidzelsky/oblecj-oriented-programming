namespace CashBoxCards
{
    //Prototype abstract class
    public abstract class Card
    {
        public string Type { get; }
        public int Discount { get; }
        public Card(string type, int discount)
        {
            this.Type = type;
            this.Discount = discount;
        }

        public abstract Card copy();
    }

    //Prototypes inheriting abstract class
    public class CustomerCard : Card
    {
        public CustomerCard() : base("Customer", 0) { }
        private   CustomerCard(CustomerCard prototype) : base(prototype.Type, prototype.Discount) { }

        public override Card copy()
        {
            return new CustomerCard(this);
        }
    }
    public class BronzeCard : Card
    {
        public BronzeCard() : base("Bronze", 5) { }
        private BronzeCard(BronzeCard prototype) : base(prototype.Type, prototype.Discount) { }

        public override Card copy()
        {
            return new BronzeCard(this);
        }
    }
    public class SilverCard : Card
    {
        public SilverCard() : base("Silver", 10) { }
        private SilverCard(SilverCard prototype) : base(prototype.Type, prototype.Discount) { }

        public override Card copy()
        {
            return new SilverCard(this);
        }
    }
    public class GoldenCard : Card
    {
        public GoldenCard() : base("Golden", 15) { }
        private GoldenCard(GoldenCard prototype) : base(prototype.Type, prototype.Discount) { }

        public override Card copy()
        {
            return new GoldenCard(this);
        }
    }
}

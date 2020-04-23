namespace CashBoxCards
{
    public class Customer
    {
        public string PhoneNumber { get; }
        public string Name { get; }
        public string Surname { get; }
        public Card Card { get; set; }
        private int _balance;
        private int _bonuses;
        
        public int Bonuses
        {
            get { return _bonuses; }
            set { _bonuses += value; }
        }
        public int Balance
        {
            get  { return _balance; } 
            set { _balance += value; } 
        }

        public Customer(string name, string surname, string phoneNumber, Card card)
        {
            Name = name;
            Surname = surname;
            Card = card;
            PhoneNumber = phoneNumber;
            _balance = 0;
            _bonuses = 0;
        }

        public void SetCard(Card card)
        {
            Card = card;
        }
    }
}

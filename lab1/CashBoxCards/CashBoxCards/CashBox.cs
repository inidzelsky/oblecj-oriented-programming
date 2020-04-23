using System;
using System.Collections.Generic;

namespace CashBoxCards
{ 
    public class CashBox
    {
        public string CashBoxName { get; }
        private CashBoxCustomers CashBoxCustomers;
        private CashBoxCards CashBoxCards;

        public CashBox(string cashBoxName)
        {
            this.CashBoxName = cashBoxName;
            this.CashBoxCustomers = new CashBoxCustomers();
            this.CashBoxCards = new CashBoxCards();
        }

        //Creates new customer in CashBoxCustomers
        public Customer CreateCustomer(string name, string surname, string phoneNumber)
        {
            Customer customer = new Customer(name, surname, phoneNumber, CashBoxCards.GetCard("Customer"));
            CashBoxCustomers.CreateCustomer(phoneNumber, customer);
            return customer;
        }

        //Updates balance and bonuses fields of the customer
        public void MakePurchase(string phoneNumber, int amount)
        {
            try
            {
                Customer customer = CashBoxCustomers.GetCustomer(phoneNumber);

                if (customer.Balance >= amount)
                {
                    customer.Bonuses = amount;
                    customer.Balance = -(amount - amount * customer.Card.Discount / 100);
                } else
                {
                    Console.WriteLine("Not enough money on the balance. Please, replenish the account");
                    return;
                }

                if (customer.Card.Type != "Golden" && customer.Bonuses > 10000)
                {
                    customer.SetCard(CashBoxCards.GetCard("Golden"));
                    Console.WriteLine("Customer`s card was upgraded to golden");
                }
                else if (customer.Card.Type != "Silver" && customer.Bonuses > 5000)
                {
                    customer.SetCard(CashBoxCards.GetCard("Silver"));
                    Console.WriteLine("Customer`s card was upgraded to silver");
                }
                else if (customer.Card.Type != "Bronze" && customer.Bonuses > 2000)
                {
                    customer.SetCard(CashBoxCards.GetCard("Bronze"));
                    Console.WriteLine("Customer`s card was upgraded to bronze");
                }

                CashBoxCustomers.UpdateCustomer(phoneNumber, customer);
            } catch
            {
                Console.WriteLine("Customer was not found");
            }
        }

        //Replenishes balance of the customer
        public void ReplenishBalance(string phoneNumber, int amount)
        {
            try
            {
                Customer customer = CashBoxCustomers.GetCustomer(phoneNumber);
                customer.Balance = amount;
                CashBoxCustomers.UpdateCustomer(phoneNumber, customer);
            } catch
            {
                Console.WriteLine("Customer was not found");
            }

        }

        //Info about customer
        public void ShowInfo(string PhoneNumber)
        {
            try 
            {
                Customer customer = CashBoxCustomers.GetCustomer(PhoneNumber);
                Console.WriteLine(
                    $"Name: {customer.Name}\n" +
                    $"Surname: {customer.Surname}\n" +
                    $"Phone number: {customer.PhoneNumber}\n" +
                    $"Card: {customer.Card.Type} card\n" +
                    $"Balance: {customer.Balance}\n" +
                    $"Bonuses: {customer.Bonuses}\n"
                    );
            } catch
            {
                Console.WriteLine($"Customer with number {PhoneNumber} was not found");
            }
        }
    }

    //Provides storage and access to customers
    public class CashBoxCustomers
    {
        private Dictionary<string, Customer> _customers;

        public CashBoxCustomers()
        {
            _customers = new Dictionary<string, Customer>();
        }

        public void CreateCustomer(string phoneNumber, Customer customer)
        {
            _customers.Add(phoneNumber, customer);
        }

        public void UpdateCustomer(string phoneNumber, Customer customer)
        {
            _customers[phoneNumber] = customer;
        }

        public Customer GetCustomer(string phoneNumber)
        {
            return _customers[phoneNumber];
        }
    }

    //Gives Cards objects by the card type
    public class CashBoxCards
    {
        private Dictionary<string, Card> _cards;

        public CashBoxCards()
        {
            _cards = new Dictionary<string, Card>();
            _cards.Add("Customer", new CustomerCard());
            _cards.Add("Bronze", new BronzeCard());
            _cards.Add("Silver", new SilverCard());
            _cards.Add("Golden", new GoldenCard());
        }

        //Returns the chosen card
        public Card GetCard(string type)
        {
            return this._cards[type].copy();
        }

    }
}

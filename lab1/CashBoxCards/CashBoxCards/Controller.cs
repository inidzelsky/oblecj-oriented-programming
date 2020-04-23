using System;

namespace CashBoxCards
{
    //Provides menu logic and handles operations2
    public class Controller
    {
        public static CashBox CashBox { get; set; }
        private static string _key;

        private static void OnCreateCustomer()
        {
            string Name;
            Console.WriteLine("Please, enter customer`s name: ");
            Name = Console.ReadLine();

            string Surname;
            Console.WriteLine("Please, enter customer`s surname: ");
            Surname = Console.ReadLine();

            string PhoneNumber;
            Console.WriteLine("Please, enter customer`s phone number(like +38099999999): ");
            PhoneNumber = Console.ReadLine();

            CashBox.CreateCustomer(Name, Surname, PhoneNumber);
            Console.WriteLine($"Customer`s account with phone number {PhoneNumber} was successfully created");
        }

        private static void OnShowInfo()
        {
            string PhoneNumber;
            Console.WriteLine("Please, enter customer`s phone number: ");
            PhoneNumber = Console.ReadLine();
            Console.WriteLine();
            CashBox.ShowInfo(PhoneNumber);
        }

        private static void OnReplenish()
        {
            string PhoneNumber;
            int Amount;
            String Input;
            Console.WriteLine("Please, enter the phone number of the customer: ");
            PhoneNumber = Console.ReadLine();

            Console.WriteLine("Please, enter the replenishment sum: ");
            Input = Console.ReadLine();

            if (Int32.TryParse(Input, out Amount))
                CashBox.ReplenishBalance(PhoneNumber, Amount);
            else
                Console.WriteLine("Invalid input");
        }

        private static void OnPurchase()
        {
            string PhoneNumber;
            int Amount;
            String Input;
            Console.WriteLine("Please, enter the phone number of the customer: ");
            PhoneNumber = Console.ReadLine();

            Console.WriteLine("Please, enter the cost of purchase: ");
            Input = Console.ReadLine();

            if (Int32.TryParse(Input, out Amount))
                CashBox.MakePurchase(PhoneNumber, Amount);
             else
                Console.WriteLine("Invalid input");
        }
        public static void DisplayMenu()
        {
            Console.WriteLine("1 : Create new user\n2 : Watch customer`s info\n3 : Replenish balance\n4 : Make payment\n0 : Quit");
            Console.Write("Enter the number: ");
            _key = Console.ReadLine();

            switch (_key)
            {
                case "1":
                    Console.WriteLine();
                    OnCreateCustomer();
                    Console.WriteLine();
                    break;

                case "2":
                    Console.WriteLine();
                    OnShowInfo();
                    Console.WriteLine();
                    break;

                case "3":
                    Console.WriteLine();
                    OnReplenish();
                    Console.WriteLine();
                    break;

                case "4":
                    Console.WriteLine();
                    OnPurchase();
                    Console.WriteLine();
                    break;

                case "0":
                    Console.WriteLine("Session is finished");
                    return;

                default:
                    break;
            }

            DisplayMenu();
        }

    }

    }

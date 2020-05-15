using System;

namespace ShipTransfer2
{
    public class ConsoleController : IController
    {
        private Writer _writer;
        private TransferInfo _transferInfo;

        public ConsoleController(TransferInfo transferInfo, Writer writer)
        {
            _transferInfo = transferInfo;
            _writer = writer;
        }

        public bool AddShip()
        {
            int id, year, passengers;
            string name;
            bool seaType;

            try
            {
                Console.Write("Ship`s id: ");
                id = int.Parse(Console.ReadLine());

                Console.Write("Ship`s name: ");
                name = Console.ReadLine();

                Console.Write("Ship`s year: ");
                year = int.Parse(Console.ReadLine());

                Console.Write("Ship`s passengers amount: ");
                passengers = int.Parse(Console.ReadLine());

                Console.Write("Is ship of sea type? ");
                seaType = bool.Parse(Console.ReadLine());

                _writer.AddShip(id, name, year, passengers, seaType);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nInvalid argument, please try again\n");

                return false;
            }
        }

        public bool AddCompany()
        {
            int id, waterId;
            string name;

            try
            {
                Console.Write("Company`s id: ");
                id = int.Parse(Console.ReadLine());

                Console.Write("Company`s name: ");
                name = Console.ReadLine();

                Console.Write("Water`s id: ");
                waterId = int.Parse(Console.ReadLine());

                _writer.AddCompany(id, name, waterId);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nInvalid argument, please try again\n");
                return false;
            }
        }

        public bool AddSea()
        {
            int id, square;
            string name;

            try
            {
                Console.Write("Sea`s id: ");
                id = int.Parse(Console.ReadLine());

                Console.Write("Sea`s name: ");
                name = Console.ReadLine();

                Console.Write("Sea`s square: ");
                square = int.Parse(Console.ReadLine());

                _writer.AddSea(id, name, square);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nInvalid argument, please try again\n");
                return false;
            }
        }

        public bool AddRiver()
        {
            int id, length, maxWidth, tributaries;
            string name;

            try
            {
                Console.Write("River`s id: ");
                id = int.Parse(Console.ReadLine());

                Console.Write("River`s name: ");
                name = Console.ReadLine();

                Console.Write("River`s length: ");
                length = int.Parse(Console.ReadLine());

                Console.Write("River`s max width: ");
                maxWidth = int.Parse(Console.ReadLine());

                Console.Write("River`s tributaries: ");
                tributaries = int.Parse(Console.ReadLine());

                _writer.AddRiver(id, name, length, maxWidth, tributaries);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nInvalid argument, please try again\n");
                return false;
            }
        }

        public bool AddLink()
        {
            int shipId, companyId;

            try
            {
                Console.Write("Ship`s id: ");
                shipId = int.Parse(Console.ReadLine());

                Console.Write("Company`s id: ");
                companyId = int.Parse(Console.ReadLine());

                _writer.AddLink(shipId, companyId);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nInvalid argument, please try again\n");
                return false;
            }
        }

        public void ObjectSubMenu()
        {
            string input;
            while (true)
            {
                Console.WriteLine("\nObject submenu:\n" +
                                  "1 - Add a ship\n" +
                                  "2 - Add a company\n" +
                                  "3 - Add a link\n" +
                                  "4 - Add a river\n" +
                                  "5 - Add a sea\n" +
                                  "s - Save\n" +
                                  "b - Back\n");
                    
                Console.Write("Input: ");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        while (!AddShip())
                            Console.Write("");
                        break;

                    case "2":
                        while (!AddCompany())
                            Console.Write("");
                        break;

                    case "3":
                        while (!AddLink())
                            Console.Write("");
                        break;

                    case "4":
                        while (!AddRiver())
                            Console.Write("");
                        break;

                    case "5":
                        while (!AddSea())
                            Console.Write("");
                        break;

                    case "s":
                        _writer.Write();
                        Console.WriteLine("All data was saved!");
                        break;
                        
                    case "b":
                        return;
                        
                    default:
                        break;
                }
            }
        }

        public void SelectSubMenu()
        {
            string input;

            while (true)
            {
                Console.WriteLine("\nSelect submenu:\n" +
                                  "1 - Show all ships ordered by name\n" +
                                  "2 - Show ships and their companies\n" +
                                  "3 - Show all rivers and seas\n" +
                                  "4 - Show all companies and their sea (if exists)\n" +
                                  "5 - Show ships` average year\n" +
                                  "6 - Show all ships to \"Admiral Lunin\"\n" +
                                  "7 - Show grouped companies by the water id\n" +
                                  "8 - Show grouped ships by companies\n" +
                                  "9 - Show ships which names start at \'A\'\n" +
                                  "10 - Show whether all ships were built after the WW2\n" +
                                  "b - Back\n");
                    
                Console.Write("Input: ");
                input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                        _transferInfo.OrderedShips();
                        break;
                        
                    case "2":
                        _transferInfo.ShipsAndCompanies();
                        break;
                        
                    case "3":
                        _transferInfo.Waters();
                        break;
                        
                    case "4":
                        _transferInfo.CompaniesAndSeas();
                        break;
                        
                    case "5":
                        _transferInfo.AverageYear();
                        break;
                        
                    case "6":
                        _transferInfo.ShipsWhile();
                        break;
                        
                    case "7":
                        _transferInfo.GroupCompanies();
                        break;
                        
                    case "8":
                        _transferInfo.GroupJoinShips();
                        break;
                        
                    case "9":
                        _transferInfo.IntersectShips();
                        break;
                        
                    case "10":
                        _transferInfo.AllShips();
                        break;
                        
                    case "b":
                        return;
                        
                    default:
                        break;
                }
            }
        }

        public void StartMenu()
        {
            string input;
                
            while (true)
            {
                Console.WriteLine("\nMenu:\n" +
                                  "1 - Xml Menu\n" +
                                  "2 - Select Menu\n" +
                                  "3 - Print file\n" +
                                  "q - Exit\n");
                    
                Console.Write("Input: ");
                input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                        ObjectSubMenu();
                        break;
                        
                    case "3":
                        Console.WriteLine(_transferInfo.ReadXml());
                        break;
                        
                    case "2":
                        SelectSubMenu();
                        break;
                        
                    case "q":
                        return;
                        
                    default:
                        break;
                }
            }
        }
    }
}
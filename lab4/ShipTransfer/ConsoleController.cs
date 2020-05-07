using System;

namespace ShipTransfer
{
    public class ConsoleController : IController
    {
        private TransferInfo _transferInfo;

        public ConsoleController(TransferInfo transferInfo)
        {
            _transferInfo = transferInfo;
        }

        public void ShowMenu()
        {
            Console.WriteLine("Ship Transfer Menu:\n" +
                              "1 - Show all of the ships\n" +
                              "2 - Show long rivers\n" +
                              "3 - Show sorted companies\n" +
                              "4 - Show ship and whether it is passenger one\n" +
                              "5 - Show all the seas and rivers together\n" +
                              "6 - Show ships grouped by the year\n" +
                              "7 - Show only sea companies\n" +
                              "8 - Show all companies with (if exist) their ships\n" +
                              "9 - Show connected ships and companies\n" +
                              "10 - Show grouped ships by their company\n" +
                              "11 - Show ships which names start at \"A\" and \"L\"\n" +
                              "12 - Show average age of the ships\n" +
                              "13 - Show the largest sea in the base\n" +
                              "14 - Show whether all of the ships were build after The War 2\n" +
                              "15 - Show ships after \"Lev Tolstoy\" one\n" +
                              "q - Quit");
            
            while (true)
            {
                Console.WriteLine();
                string input = Console.ReadLine();
                Console.WriteLine();
                
                switch (input.ToLower())
                {
                    case "1":
                        _transferInfo.SelectShips();
                        break;

                    case "2":
                        _transferInfo.SelectLongRivers();
                        break;

                    case "3":
                        _transferInfo.SelectOrderedCompanies();
                        break;

                    case "4":
                        _transferInfo.SelectIsPassengerShip();
                        break;

                    case "5":
                        _transferInfo.SelectWater();
                        break;

                    case "6":
                        _transferInfo.SelectGroupShipsByYear();
                        break;

                    case "7":
                        _transferInfo.SelectSeaCompanies();
                        break;

                    case "8":
                        _transferInfo.SelectAllCompaniesWithShips();
                        break;

                    case "9":
                        _transferInfo.SelectShipOfCompany();
                        break;

                    case "10":
                        _transferInfo.SelectGroupShipsByCompanies();
                        break;

                    case "11":
                        _transferInfo.SelectShipsUnion();
                        break;

                    case "12":
                        _transferInfo.SelectAverageShipsAge();
                        break;

                    case "13":
                        _transferInfo.SelectLargestSea();
                        break;

                    case "14":
                        _transferInfo.SelectIfShipsAfterWar();
                        break;

                    case "15":
                        _transferInfo.SelectSkipTo();
                        break;

                    case "q":
                        return;

                    default:
                        ShowMenu();
                        break;
                }
            }
        }
    }
}
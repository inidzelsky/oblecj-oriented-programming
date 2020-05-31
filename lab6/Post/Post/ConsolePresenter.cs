using System;
using System.Data;
using Npgsql;

namespace Post
{
    public class ConsolePresenter : IPresenter
    {
        public void ShowInsertMenu()
        {
            Console.WriteLine("Insertion menu:\n" +
                              "Insert a district - 1\n" +
                              "Insert a street - 2\n" +
                              "Insert an address - 3\n" +
                              "Insert a subscriber - 4\n" +
                              "Insert a paper - 5\n" +
                              "Insert a subscription - 6\n" +
                              "Back - b");

            Console.Write("Input: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input.ToLower())
            {
                case "1":
                    Console.WriteLine("Enter the district name:");
                    string districtName = Console.ReadLine();

                    Console.WriteLine();

                    Console.WriteLine("Enter the postman:");
                    string postMan = Console.ReadLine();

                    Console.WriteLine();

                    CreateController.CreateDistrict(ConnectionHandler.GetInstance(), districtName, postMan);
                    break;

                case "2":
                    Console.WriteLine("Enter the district id:");
                    int districtId = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    Console.WriteLine("Enter the street name:");
                    string streetName = Console.ReadLine();

                    Console.WriteLine();

                    CreateController.CreateStreet(ConnectionHandler.GetInstance(), districtId, streetName);
                    break;

                case "3":
                    Console.WriteLine("Enter the street id:");
                    int streetId = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    Console.WriteLine("Enter the address number:");
                    string addressNumber = Console.ReadLine();

                    Console.WriteLine();

                    CreateController.CreateAddress(ConnectionHandler.GetInstance(), streetId, addressNumber);
                    break;

                case "4":
                    Console.WriteLine("Enter the address id:");
                    int addressId = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    Console.WriteLine("Enter the subscriber`s full name:");
                    string subscriberFullName = Console.ReadLine();

                    Console.WriteLine();

                    CreateController.CreateSubscriber(ConnectionHandler.GetInstance(), addressId, subscriberFullName);
                    break;

                case "5":
                    Console.WriteLine("Enter the paper cipher:");
                    string paperCipher = Console.ReadLine();

                    Console.WriteLine();

                    Console.WriteLine("Enter the paper`s name:");
                    string paperName = Console.ReadLine();

                    Console.WriteLine();

                    Console.WriteLine("Enter the paper`s cost:");
                    int cost = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    CreateController.CreatePaper(ConnectionHandler.GetInstance(), paperCipher, paperName, cost);
                    break;

                case "6":
                    Console.WriteLine("Enter the subscriber`s id:");
                    int subscriberIdForeign = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    Console.WriteLine("Enter the paper cipher:");
                    string paperCipherForeign = Console.ReadLine();

                    Console.WriteLine();

                    CreateController.CreateSubscription(ConnectionHandler.GetInstance(), paperCipherForeign, subscriberIdForeign);
                    break;

                case "b":
                    return;
            }

            Console.WriteLine("Values were successfully inserted\n");
            ShowInsertMenu();
        }

        public void ShowDeleteMenu()
        {
            Console.WriteLine("Deletion menu:\n" +
                              "Delete a district - 1\n" +
                              "Delete a street - 2\n" +
                              "Delete an address - 3\n" +
                              "Delete a subscriber - 4\n" +
                              "Delete a paper - 5\n" +
                              "Delete a subcription - 6\n" +
                              "Back - b");

            Console.Write("Input: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input.ToLower())
            {
                case "1":
                    Console.WriteLine("Enter the district id:");
                    int districtId = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    DeleteController.DeleteDistrict(ConnectionHandler.GetInstance(), districtId);
                    break;

                case "2":
                    Console.WriteLine("Enter the street id:");
                    int streetId = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    DeleteController.DeleteStreet(ConnectionHandler.GetInstance(), streetId);
                    break;

                case "3":
                    Console.WriteLine("Enter the address id:");
                    int addressId = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    DeleteController.DeleteAddress(ConnectionHandler.GetInstance(), addressId);
                    break;

                case "4":
                    Console.WriteLine("Enter the subscriber id:");
                    int subscriberId = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    DeleteController.DeleteSubscriber(ConnectionHandler.GetInstance(), subscriberId);
                    break;

                case "5":
                    Console.WriteLine("Enter the paper cipher:");
                    string paperCipher = Console.ReadLine();

                    Console.WriteLine();

                    DeleteController.DeletePaper(ConnectionHandler.GetInstance(), paperCipher);
                    break;

                case "6":
                    Console.WriteLine("Enter the subscriber`s id:");
                    int subscriberIdForeign = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    Console.WriteLine("Enter the paper cipher:");
                    string paperCipherForeign = Console.ReadLine();

                    Console.WriteLine();

                    DeleteController.DeleteSubscription(ConnectionHandler.GetInstance(), paperCipherForeign, subscriberIdForeign);
                    break;

                case "b":
                    return;
            }

            Console.WriteLine("Values were successfully deleted\n");
            ShowDeleteMenu();
        }

        public void ShowUpdateMenu()
        {
            Console.WriteLine("Updation menu:\n" +
                              "Update a district - 1\n" +
                              "Update a street - 2\n" +
                              "Update an address - 3\n" +
                              "Update a subscriber - 4\n" +
                              "Update a paper - 5\n" +
                              "Back - b");

            Console.Write("Input: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input.ToLower())
            {
                case "1":
                    Console.WriteLine("Enter the district id:");
                    int districtId = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    Console.WriteLine("Enter the new district name:");
                    string districtName = Console.ReadLine();

                    Console.WriteLine();

                    Console.WriteLine("Enter the new postman:");
                    string postman = Console.ReadLine();

                    Console.WriteLine();

                    UpdateController.UpdateDistrict(ConnectionHandler.GetInstance(), districtId, districtName, postman);
                    break;

                case "2":
                    Console.WriteLine("Enter the street id:");
                    int streetId = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    Console.WriteLine("Enter the new district id:");
                    int districtIdForeign = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    Console.WriteLine("Enter the new street name:");
                    string streetName = Console.ReadLine();

                    Console.WriteLine();

                    UpdateController.UpdateStreet(ConnectionHandler.GetInstance(), streetId, districtIdForeign, streetName);
                    break;

                case "3":
                    Console.WriteLine("Enter the address id:");
                    int addressId = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    Console.WriteLine("Enter the new street id:");
                    int streetIdForeign = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    Console.WriteLine("Enter the new address number:");
                    string addressNumber = Console.ReadLine();

                    Console.WriteLine();

                    UpdateController.UpdateAddress(ConnectionHandler.GetInstance(), addressId, streetIdForeign, addressNumber);
                    break;

                case "4":
                    Console.WriteLine("Enter the subscriber id:");
                    int subscriberId = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    Console.WriteLine("Enter the new subscriber`s address id:");
                    int addressIdForeign = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    Console.WriteLine("Enter the new subscriber`s full name:");
                    string subscriberFullName = Console.ReadLine();

                    UpdateController.UpdateSubscriber(ConnectionHandler.GetInstance(), subscriberId, addressIdForeign, subscriberFullName);
                    break;

                case "5":
                    Console.WriteLine("Enter the paper cipher:");
                    string paperCipher = Console.ReadLine();

                    Console.WriteLine();

                    Console.WriteLine("Enter the new paper`s name:");
                    string paperName = Console.ReadLine();

                    Console.WriteLine();

                    Console.WriteLine("Enter the new paper`s cost:");
                    int cost = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();

                    UpdateController.UpdatePaper(ConnectionHandler.GetInstance(), paperCipher, paperName, cost);
                    break;

                case "b":
                    return;
            }

            Console.WriteLine("Values were successfully updated\n");
            ShowUpdateMenu();
        }

        public void ShowQueryMenu()
        {
            Console.WriteLine("Query menu:\n" +
                              "\"Murzilka\" Subscribers - 1\n" +
                              "Districts count - 2\n" +
                              "Amount of streets in every district - 3\n" +
                              "Average papers cost - 4\n" +
                              "Subscriptions count of every subscriber - 5\n" +
                              "Subscriber and his postman - 6\n" +
                              "Papers and addresses for delivering - 7\n" +
                              "Subscriber`s bill - 8\n" +
                              "Paper`s subscribers - 9\n" +
                              "Increase the cost of every paper on 5$ - 10\n" +
                              "Back - b");

            Console.Write("Input: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input.ToLower())
            {
                case "1":
                    DataSet murzilkaSubs = QueriesController.MurzilkaSubscribers(ConnectionHandler.GetInstance());

                    Console.WriteLine("\"Murzilka\" Subscribers:");

                    foreach (DataColumn column in murzilkaSubs.Tables[0].Columns)
                    {
                        Console.Write($"\t{column.ColumnName}");
                    }

                    Console.WriteLine();

                    foreach (DataRow row in murzilkaSubs.Tables[0].Rows)
                    {
                        Console.WriteLine($"\t\t{row.ItemArray[0]}\t{row.ItemArray[1]}");
                    }

                    Console.WriteLine();

                    break;

                case "2":
                    int districtsCount = QueriesController.DistrictsCount(ConnectionHandler.GetInstance());

                    Console.WriteLine($"Amount of city districts: {districtsCount}\n");

                    break;

                case "3":
                    DataSet streetsInDistrict = QueriesController.StreetsInDistrict(ConnectionHandler.GetInstance());

                    Console.WriteLine("Amount of streets in every district:");

                    foreach (DataColumn column in streetsInDistrict.Tables[0].Columns)
                    {
                        Console.Write($"\t{column.ColumnName}");
                    }

                    Console.WriteLine();

                    foreach (DataRow row in streetsInDistrict.Tables[0].Rows)
                    {
                        Console.WriteLine($"\t{row.ItemArray[0]}\t\t{row.ItemArray[1]}");
                    }

                    Console.WriteLine();

                    break;

                case "4":
                    decimal avgCost = QueriesController.AvgCost(ConnectionHandler.GetInstance());

                    Console.WriteLine($"Average cost of papers: {avgCost}$\n");

                    break;

                case "5":
                    DataSet subscriptionsCount = QueriesController.SubscriptionsCount(ConnectionHandler.GetInstance());

                    Console.WriteLine("Subscriptions count of every subscriber:");

                    foreach (DataColumn column in subscriptionsCount.Tables[0].Columns)
                    {
                        Console.Write($"\t{column.ColumnName}\t\t");
                    }

                    Console.WriteLine();

                    foreach (DataRow row in subscriptionsCount.Tables[0].Rows)
                    {
                        Console.WriteLine($"\t{row.ItemArray[0]}\t\t{row.ItemArray[1]}");
                    }

                    Console.WriteLine();
                    break;

                case "6":
                    DataSet subscriberAndPostman = QueriesController.DistrictAndPostmen(ConnectionHandler.GetInstance());

                    Console.WriteLine("Subscribers and their postmen:");

                    foreach (DataColumn column in subscriberAndPostman.Tables[0].Columns)
                    {
                        Console.Write($"\t{column.ColumnName}\t\t\t");
                    }

                    Console.WriteLine();

                    foreach (DataRow row in subscriberAndPostman.Tables[0].Rows)
                    {
                        Console.WriteLine($"\t{row.ItemArray[0]}\t\t\t{row.ItemArray[1]}\t\t\t{row.ItemArray[2]}");
                    }

                    Console.WriteLine();
                    break;

                case "7":
                    DataSet addressesAndPapers = QueriesController.AddressesAndPapers(ConnectionHandler.GetInstance());

                    Console.WriteLine("Papers and addresses to deliver them:");

                    foreach (DataColumn column in addressesAndPapers.Tables[0].Columns)
                    {
                        Console.Write($"\t{column.ColumnName}\t\t");
                    }

                    Console.WriteLine();

                    foreach (DataRow row in addressesAndPapers.Tables[0].Rows)
                    {
                        Console.WriteLine($"\t{row.ItemArray[0]}\t\t{row.ItemArray[1]}");
                    }

                    Console.WriteLine();
                    break;

                case "8":
                    Console.WriteLine("Enter the subscriber id to get a bill: ");
                    int subscriberId = Int32.Parse(Console.ReadLine());

                    Console.ReadLine();

                    decimal bill = QueriesController.GetBill(ConnectionHandler.GetInstance(), subscriberId);
                    Console.WriteLine($"The bill of the subscriber with id \"{subscriberId}\" is: {bill}$\n");

                    break;

                case "9":
                    Console.Write("Enter the paper cipher to its subscribers: ");
                    string pCipher = Console.ReadLine();

                    Console.WriteLine();

                    DataSet subscribers = QueriesController.PaperSubscribers(ConnectionHandler.GetInstance(), pCipher);

                    Console.WriteLine($"The subscribers of the paper with the cipher \"{pCipher}\":");

                    foreach (DataColumn column in subscribers.Tables[0].Columns)
                    {
                        Console.Write($"\t{column.ColumnName}\t\t\t");
                    }

                    Console.WriteLine();

                    foreach (DataRow row in subscribers.Tables[0].Rows)
                    {
                        Console.WriteLine($"\t{row.ItemArray[0]}\t\t{row.ItemArray[1]}\t\t\t\t{row.ItemArray[2]}");
                    }

                    Console.WriteLine();
                    break;

                case "10":
                    DataSet papers = QueriesController.IncreaseCost(ConnectionHandler.GetInstance());

                    Console.WriteLine($"The updated cost of papers");

                    foreach (DataColumn column in papers.Tables[0].Columns)
                    {
                        Console.Write($"\t{column.ColumnName}\t\t");
                    }

                    Console.WriteLine();

                    foreach (DataRow row in papers.Tables[0].Rows)
                    {
                        Console.WriteLine($"\t{row.ItemArray[0]}\t\t\t{row.ItemArray[1]}\t\t\t{row.ItemArray[2]}");
                    }

                    Console.WriteLine();
                    break;

                case "q":
                    return;
            }
        }


        public void ShowMainMenu()
        {
            Console.WriteLine("Main menu:\n" +
                              "Insert values into table - 1\n" +
                              "Delete values from table - 2\n" +
                              "Update values in table - 3\n" +
                              "Execute query - 4\n" +
                              "Quit - q");

            Console.Write("Input: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input.ToLower())
            {
                case "1":
                    ShowInsertMenu();
                    break;

                case "2":
                    ShowDeleteMenu();
                    break;

                case "3":
                    ShowUpdateMenu();
                    break;

                case "4":
                    ShowQueryMenu();
                    break;

                case "q":
                    return;
            }

            ShowMainMenu();
        }
    }
}
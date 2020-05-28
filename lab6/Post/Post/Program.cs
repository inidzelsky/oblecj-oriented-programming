using System;
using Npgsql;

namespace Post
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = ConnectionHandler.GetInstance();
            DatabaseController dbcontroller = new DatabaseController(connection);
            dbcontroller.MurzilkaSubscribers();
            dbcontroller.DistrictsCount();
            dbcontroller.SubscriptionsCount();
            dbcontroller.DistrictAndPostmen();
            dbcontroller.AddressesAndPapers();
            dbcontroller.GetBill(3);
            dbcontroller.PaperSubscribers("AAA111");
            dbcontroller.IncreaseCost();
            dbcontroller.AvgCost();
            dbcontroller.StreetsInDistrict();
        }
    }
}
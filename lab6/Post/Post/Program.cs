using System;
using Npgsql;

namespace Post
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseController dbcontroller = new DatabaseController("Host=localhost;Database=post;Username=postgres;Password=123456;Port=5432");
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
using System;
using System.IO;
using System.Xml.Linq;

namespace ShipTransfer2
{
    class Program
    {
        static void Main(string[] args)
        {
            var transferInfo = new TransferInfo();
            transferInfo.Initialize();
            
            transferInfo.Select1();
            
            //Console.Write(File.ReadAllText("links.xml"));
        }
    }
}
using System.IO;
using System.Xml.Linq;

namespace ShipTransfer2
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = new Writer("transfers.xml");
            var transferInfo = new TransferInfo("transfers.xml");
            
            var consoleController = new ConsoleController(transferInfo, writer);
            consoleController.StartMenu();
        }
    }
}
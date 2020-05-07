using System.Net.NetworkInformation;

namespace ShipTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
            var transferInfo = new TransferInfo();
            IController controller = new ConsoleController(transferInfo);
            controller.ShowMenu();
        }
    }
}
using System;
using System.Collections.Generic;

namespace CashBoxCards
{
     class Program
    {
        static void Main(string[] args)
        {
            CashBox sportMaster = new CashBox("SportMaster");
            Controller.CashBox = sportMaster;
            Controller.DisplayMenu();
        }
    }

}


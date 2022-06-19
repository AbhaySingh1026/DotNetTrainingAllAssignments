using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEND__EMAIL_ON_BOOKING_ORDER
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AllTableFunctionalities allTableFunctionalitiesObj = new AllTableFunctionalities();
            TOP:
            Console.WriteLine("1. Item Master\n2. Customer Master\n3. Book Order\n4. Close Application");
            switch (Console.ReadLine())
            {
                case "1":
                    allTableFunctionalitiesObj.ItemMaster(print());
                    break;
                case "2":
                    allTableFunctionalitiesObj.CustomerMaster(print());
                    break;
                case "3":
                    allTableFunctionalitiesObj.BookItem();
                    break;
                case "4": return;
                default: Console.WriteLine("Oops.. Entered wrong option, PLease try again - ");
                    goto TOP;
            }
            goto TOP;
        }
        static string print()
        {
        TOP:
            Console.WriteLine("Which operation do u want to perform here -\n1. InsertOneRecord\n2. UpdateOneRecord\n3 .DeleteOneRecord\n4. ShowAllRecords");
            string input = Console.ReadLine(); 
            if(input == "1") return input;
            if (input == "2") return input;
            if(input == "3") return input;
            if(input == "4") return input;
            else goto TOP;
        }
    }
}

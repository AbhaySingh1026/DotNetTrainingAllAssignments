using SEND_EMAIL_ASS._THROUGH_ENTITYFRAMEWORK;
using SEND_EMAIL_ASS._THROUGH_ENTITYFRAMEWORK.Entities;

namespace RunDll
{
    internal class Program
    {
        static void Main(string[] args)
        {
        TOP:
            string getValue;
            AllMethods allMethodsObj = new AllMethods();
            Console.WriteLine("1. Item Master\n2. Customer Master\n3. Book Item\n4. Close Application");
            switch (Console.ReadLine())
            {
                case "1": getValue = Print();
                    if (getValue == "1") allMethodsObj.InsertItem();
                    if(getValue == "2") allMethodsObj.UpdateItem();
                    if(getValue =="3") allMethodsObj.DeleteItem();
                    if(getValue =="4") allMethodsObj.ShowOneItem();
                    if(getValue == "5") allMethodsObj.ShowAllItems();
                    break;
                case "2": getValue = Print();
                    if (getValue == "1") allMethodsObj.InsertCustomer();
                    if (getValue == "2") allMethodsObj.UpdateCustomer();
                    if (getValue == "3") allMethodsObj.DeleteCustomer();
                    if (getValue == "4") allMethodsObj.ShowOneCustomer();
                    if (getValue == "5") allMethodsObj.ShowAllCustomers();
                    break;
                case "3": allMethodsObj.Verify();
                    break;
                case "4": return;
                default: Console.WriteLine("Please Enter Correct Option - ");
                    goto TOP;
            }
            goto TOP;
        }
        static string Print()
        {
            TOP:
            Console.WriteLine("1. InsertOneRecord\n2. UpdateOneRecord\n3. DeleteOneRecord\n4. ShowOneRecord\n5. ShowAllRecords\n6. Go Back");
            string input = Console.ReadLine();
            if (input == "1") return input;
            if (input == "2") return input;
            if (input == "3") return input;
            if (input == "4") return input;
            if (input == "5") return input;
            if (input == "6") return null;
            else
            {
                Console.WriteLine("Please Enter Correct Option -");
                goto TOP;
            }
        }
    }
}
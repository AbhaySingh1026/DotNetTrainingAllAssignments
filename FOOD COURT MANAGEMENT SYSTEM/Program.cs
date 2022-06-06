using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FOOD_COURT_MANAGEMENT_SYSTEM
{
    internal class Program
    {
        static void Main(string[] args) {
            TOP:
            Console.Write("Close application ? ");
            if(Console.ReadLine() == "yes")
            {
                return;
            }
            TOP1:
            Console.Write("Enter your username - ");
            string username = Console.ReadLine();
            Console.Write("Enter your password - ");
            string password = Console.ReadLine();
            using(FileStream fileStreamObj = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\FOOD COURT MANAGEMENT SYSTEM\AdminLoginDetails.txt", FileMode.Open, FileAccess.Read))
            {
                StreamReader streamReaderObj = new StreamReader(fileStreamObj);
                string line = streamReaderObj.ReadLine();
                string[] splitLine = line.Split(' ');
                if (splitLine[0] == username && splitLine[1] == password)
                {
                    Login loginObj = new Login();
                }
                else
                {
                    Console.WriteLine("Either username/password is incorrect,Please try again....");
                    goto TOP1;
                }
            }
            goto TOP;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ONLINE_CINEMA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int check = 0;
            TOP:
            using (FileStream fileStreamObj = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\ONLINE CINEMA\AdminLoginDetails.txt", FileMode.Open))
            {
                using (FileStream fileStreamObj1 = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\ONLINE CINEMA\CustomerLoginDetails.txt", FileMode.Open))
                {
                    StreamReader streamReaderObj = new StreamReader(fileStreamObj);
                    StreamReader streamReaderObj1 = new StreamReader(fileStreamObj1);
                    Console.Write("Enter Username - ");
                    string username = Console.ReadLine();
                    while (streamReaderObj.Peek() > 0)
                    {
                        string read = streamReaderObj.ReadLine();
                        string[] split = read.Split(' ');
                        if (split[0] == username)
                        {
                            check = 1;
                            PASS:
                            Console.Write("Enter Password - ");
                            string password = Console.ReadLine();
                            if (split[1] == password)
                            {
                                Admin adminObj = new Admin();
                                adminObj.Module();
                            }
                            else
                            {
                                Console.WriteLine("Incorrect Password, Please try again - ");
                                goto PASS;
                            }
                        }
                    }
                    if(check == 0)
                    {
                        while (streamReaderObj1.Peek() > 0)
                        {
                            string read1 = streamReaderObj1.ReadLine();
                            string[] split1 = read1.Split(' ');
                            if (split1[0] == username)
                            {
                                check = 1;
                            PASS1:
                                Console.Write("Enter Password - ");
                                string password = Console.ReadLine();
                                if (split1[1] == password)
                                {
                                    Customer customerObj = new Customer();
                                    customerObj.Module(username);
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect Password, Please try again - ");
                                    goto PASS1;
                                }
                            }
                        }
                        if(check == 0)
                        {
                            Console.WriteLine("Enter Username Not Found, Please try again - ");
                            goto TOP;
                        }
                    }
                }
            }
            return;
        }
    }
}

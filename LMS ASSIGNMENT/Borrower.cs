using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LMS_ASSIGNMENT
{
    public class Borrower
    {
        public void BorrowerPortal(int bId)
        {
            if (File.Exists(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\IssuedBooksDetail.txt") == true)
            {
                int totalPriceDue = 0;
                string read;
                string[] splitread;
                FileStream fileStreamobj = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\IssuedBooksDetail.txt", FileMode.Open, FileAccess.Read);
                StreamReader streamReaderobj = new StreamReader(fileStreamobj);
                while (streamReaderobj.Peek() > 0)
                {
                    read = streamReaderobj.ReadLine();
                    splitread = read.Split(' ');
                    if (splitread[0] == bId.ToString())
                    {
                        var daysCalculate = Convert.ToDateTime(splitread[4]) - Convert.ToDateTime(splitread[3]);
                        totalPriceDue = totalPriceDue + daysCalculate.Days*30;
                    }
                }
                streamReaderobj.Close();
                fileStreamobj.Close();
                FileStream fileStreamobjtemp = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\IssuedBooksDetail.txt", FileMode.Open, FileAccess.Read);
                StreamReader streamReaderobjtemp = new StreamReader(fileStreamobjtemp);
                if (totalPriceDue == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("You haven't issued any books till now.");
                    Console.Write("Total Price Due - " + totalPriceDue);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("BookName Author DateIssued DateofReturn");
                    while (streamReaderobjtemp.Peek() > 0)
                    {
                        read = streamReaderobjtemp.ReadLine();
                        splitread = read.Split(' ');
                        if (splitread[0] == bId.ToString())
                        {
                            Console.WriteLine(splitread[1] + " " + splitread[2] + " " + splitread[3]+" " + splitread[4]);
                        }
                    }
                    Console.WriteLine();
                    Console.Write("Charge of 1book/day is 30,So ");
                    Console.Write("Total Price Due - " + totalPriceDue);
                }

            MID:
                Console.WriteLine();
                Console.Write("Please enter yes to Sign Out - ");
                if (Console.ReadLine() == "yes")
                {
                    return;
                }
                goto MID;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You haven't issued any books till now");
                Console.WriteLine("Total price due = 0");
                MID2:
                Console.Write("Please enter yes to Sign Out - ");
                if (Console.ReadLine() == "yes")
                {
                    return;
                }
                goto MID2;
            }
        }
    }
}

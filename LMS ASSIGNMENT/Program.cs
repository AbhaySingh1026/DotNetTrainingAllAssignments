using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LMS_ASSIGNMENT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TOP:
            Console.WriteLine("Choose your profile - ");
            Console.WriteLine("1. Librarian");
            Console.WriteLine("2. Borrower");
            Console.WriteLine("3. Close Application");
            int input1 = Convert.ToInt32(Console.ReadLine());
            switch (input1)
            {
                case 1:
                    string[] arr1 = new string[1];
                    int count = 0,count1 = 0;
                    TOP2:
                    FileStream fileStreamobj = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\Librarians.txt",FileMode.Open,FileAccess.Read);
                    StreamReader streamReaderobj = new StreamReader(fileStreamobj);
                    Console.Write("Enter your LId - ");
                    int input2 = Convert.ToInt32(Console.ReadLine());
                    streamReaderobj.ReadLine();
                    while (streamReaderobj.Peek() > 0)
                    {
                        string s1 = streamReaderobj.ReadLine();
                        string[] arr = s1.Split(' ');
                        arr1[0] = input2.ToString();
                        if (arr[0]== arr1[0]){
                            count++;
                            TOP3:
                            Console.Write("Enter your password - ");
                            if (s1.Contains(Console.ReadLine())){
                                Librarian obj = new Librarian();
                                obj.LibrarianPortal();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You entered wrong password,please try again");
                                count1++;
                                if (count1 == 5)
                                {
                                    Console.WriteLine("You exceeded limit of entering wrong password");
                                    break;
                                }
                                goto TOP3;
                            }
                        }
                    }
                    
                    if(count == 0)
                    {
                        Console.WriteLine("You entered wrong LId or you do not have Librarian account,please try again - ");
                        count1++;
                        if (count1 == 5)
                        {
                            Console.WriteLine("You exceeded limit of entering wrong LId");
                            break;
                        }
                        goto TOP2;
                    }
                    break;
                case 2:
                    string[] barr1 = new string[1];
                    int bcount = 0, bcount1 = 0;
                    bTOP2:
                    FileStream bfileStreamobj = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\Borrowers.txt", FileMode.Open, FileAccess.Read);
                    StreamReader bstreamReaderobj = new StreamReader(bfileStreamobj);
                    Console.Write("Enter your BId - ");
                    int binput2 = Convert.ToInt32(Console.ReadLine());
                    bstreamReaderobj.ReadLine();
                    while (bstreamReaderobj.Peek() > 0)
                    {
                        string bs1 = bstreamReaderobj.ReadLine();
                        string[] barr = bs1.Split(' ');
                        barr1[0] = binput2.ToString();
                        if (barr[0]== barr1[0])
                        {
                            bcount++;
                        bTOP3:
                            Console.Write("Enter your password - ");
                            if (bs1.Contains(Console.ReadLine())){
                                Borrower obj = new Borrower();
                                obj.BorrowerPortal(binput2);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You entered wrong password,please try again");
                                bcount1++;
                                if (bcount1 == 5)
                                {
                                    Console.WriteLine("You exceeded limit of entering wrong password");
                                    break;
                                }
                                goto bTOP3;
                            }
                        }
                    }
                    if (bcount == 0)
                    {
                        Console.WriteLine("You entered wrong BId or you do not have Borrowers account,please try again - ");
                        bcount1++;
                        if (bcount1 == 5)
                        {
                            Console.WriteLine("You exceeded limit of entering wrong BId");
                            break;
                        }
                        goto bTOP2;
                    }
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Entered wrong number, please try again -");
                    goto TOP;
            }
            goto TOP;
        }
    }
}

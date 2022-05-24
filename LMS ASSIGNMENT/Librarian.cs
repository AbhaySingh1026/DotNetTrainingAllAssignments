using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LMS_ASSIGNMENT
{
    public class Librarian
    {
        public void LibrarianPortal()
        {
        TOP:
            Console.WriteLine("1. All book isseued details");
            Console.WriteLine("2. Issue books");
            Console.WriteLine("3. Return books");
            Console.WriteLine("4. View/add Books available in library");
            Console.WriteLine("5. Log Out");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    if (File.Exists(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\IssuedBooksDetail.txt") == true)
                    {
                        FileStream fileStreamobj = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\IssuedBooksDetail.txt", FileMode.Open, FileAccess.Read);
                        StreamReader streamReaderobj = new StreamReader(fileStreamobj);
                        while (streamReaderobj.Peek() > 0)
                        {
                            Console.WriteLine(streamReaderobj.ReadLine());
                        }
                        streamReaderobj.Close();
                        fileStreamobj.Close();
                    }
                    else
                    {
                        Console.WriteLine("No books issued till now");
                    }
                    break;
                case 2:
                    if(File.Exists(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\Booksinlibrary.txt") == true)
                    {
                        TOP1:
                        int checkCount = 0;
                        Console.Write("Enter book name - ");
                        string readBookName = Console.ReadLine();
                        Console.Write("Enter author name - ");
                        string readAuthorName = Console.ReadLine();
                        FileStream forCheck = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\Booksinlibrary.txt", FileMode.Open, FileAccess.Read);
                        StreamReader callCheck = new StreamReader(forCheck);
                        while (callCheck.Peek() > 0)
                        {
                            string lineCheck = callCheck.ReadLine();
                            if ((lineCheck.Contains(readBookName)) && (lineCheck.Contains(readAuthorName)))
                            {
                                checkCount++;
                            }
                        }
                        callCheck.Close();
                        forCheck.Close();
                        if(checkCount == 0)
                        {
                            Console.WriteLine("Entered bookName with entered author is not present in library");
                        }
                        else
                        {
                            FileStream fileStreamobj1 = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\IssuedBooksDetail.txt", FileMode.Append, FileAccess.Write);
                            StreamWriter streamWriterobj = new StreamWriter(fileStreamobj1);
                            Console.Write("Enter bId - ");
                            streamWriterobj.Write(Console.ReadLine());
                            streamWriterobj.Write(" ");
                            streamWriterobj.Write(readBookName);
                            streamWriterobj.Write(" ");
                            streamWriterobj.Write(readAuthorName);
                            streamWriterobj.Write(" ");
                            Console.Write("Enter issuedDate(day/month/year) - ");
                            streamWriterobj.Write(Console.ReadLine());
                            streamWriterobj.Write(" ");
                            Console.Write("Enter returnDate(day/month/year) - ");
                            streamWriterobj.WriteLine(Console.ReadLine());
                            streamWriterobj.Close();
                            fileStreamobj1.Close();
                            Console.Write("Do you want to enter more details? enter(yes/no) - ");
                            if (Console.ReadLine() == "yes")
                            {
                                Console.WriteLine();
                                goto TOP1;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Their r no books in library, So you cannot issue books");
                    }
                    break;
                case 3:
                    if (File.Exists(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\IssuedBooksDetail.txt") == true)
                    {
                        string temp2;
                        FileStream fileStreamobj2 = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\IssuedBooksDetail.txt", FileMode.Open, FileAccess.Read);
                        StreamReader streamReaderobj2 = new StreamReader(fileStreamobj2);
                        Console.Write("Enter Bid - ");
                        string bId = Console.ReadLine();
                        Console.Write("Enter BookName - ");
                        string bookName = Console.ReadLine();
                        Console.Write("Enter author name - ");
                        string authorName = Console.ReadLine();
                        FileStream newobj = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\IssuedBooksDetail1.txt", FileMode.Create, FileAccess.Write);
                        StreamWriter newobj2 = new StreamWriter(newobj);
                        while (streamReaderobj2.Peek() > 0)
                        {
                            temp2 = streamReaderobj2.ReadLine();
                            string[] temp1 = temp2.Split(' ');
                            if ((temp1[0].Contains(bId)) && (temp1[1].Contains(bookName)) && (temp1[2].Contains(authorName)))
                            {
                                continue;
                            }
                            else
                            {
                                
                                newobj2.WriteLine(temp2);
                                
                            }
                        }streamReaderobj2.Dispose();
                        streamReaderobj2.Close();
                        fileStreamobj2.Close();
                        newobj2.Dispose();
                        newobj2.Close();
                        newobj.Close();
                        File.Delete(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\IssuedBooksDetail.txt");
                        File.Move(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\IssuedBooksDetail1.txt", @"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\IssuedBooksDetail.txt");
                    }
                    else
                    {
                        Console.WriteLine("No books issued till now");
                    }
                    break;
                case 4:
                    WRONGINPUT:
                    Console.WriteLine("1. View all books available in library");
                    Console.WriteLine("2. Add books to library");
                    int ansForThisCase = Convert.ToInt32(Console.ReadLine());
                    switch (ansForThisCase)
                    {
                        case 1:
                            if(File.Exists(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\Booksinlibrary.txt") == false)
                            {
                                Console.WriteLine("There are currently no books in library");
                            }
                            else
                            {
                                FileStream objForBookDetail = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\Booksinlibrary.txt",FileMode.Open,FileAccess.Read);
                                StreamReader objforcalling = new StreamReader(objForBookDetail);
                                while (objforcalling.Peek() > 0)
                                {
                                    Console.WriteLine(objforcalling.ReadLine());
                                }
                                objforcalling.Close();
                                objForBookDetail.Close();
                            }
                            break;
                        case 2:
                            FileStream objForBookDetail1 = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\LMS ASSIGNMENT\Booksinlibrary.txt",FileMode.Append,FileAccess.Write);
                            StreamWriter objforcalling1 = new StreamWriter(objForBookDetail1);
                            X:
                            Console.WriteLine("Please enter book details in following order");
                            Console.WriteLine("BookName Author Price");
                            objforcalling1.WriteLine(Console.ReadLine());
                            Console.Write("Do you wanr to enter more books? type(yes/no) - ");
                            if (Console.ReadLine() == "yes")
                            {
                                goto X;
                            }
                            objforcalling1.Close();
                            objForBookDetail1.Close();
                            break;
                        default:
                            Console.WriteLine("Entered wrong number please try again");
                            goto WRONGINPUT;
                    }
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Entered wrong number, please try again");
                    goto TOP;
            }
            goto TOP;
        }
    }
}

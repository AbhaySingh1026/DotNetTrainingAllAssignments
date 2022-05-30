using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ONLINE_CINEMA
{
    public class Customer
    {
        private int count = 0;
        public void Module(string username)
        {
            TOP:
            Console.WriteLine("1. Search/Book Movie");
            Console.WriteLine("2. Cancellation");
            Console.WriteLine("3. LogOut");
            switch (Console.ReadLine())
            {
                case "1":
                    if(File.Exists(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\ONLINE CINEMA\MovieDetails.txt"))
                    {
                        FileStream fileStreamObj = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\ONLINE CINEMA\MovieDetails.txt",FileMode.Open);
                        StreamReader streamReaderObj = new StreamReader(fileStreamObj);
                        while (streamReaderObj.Peek() > 0)
                        {
                            Console.WriteLine(streamReaderObj.ReadLine());
                        }
                        streamReaderObj.Dispose();
                        streamReaderObj.Close();
                        fileStreamObj.Close();
                        MID:
                        Console.WriteLine("1. Book Movie");
                        Console.WriteLine("2. Go Back");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                MNAME:
                                Console.Write("Enter movie name - ");
                                string movieName = Console.ReadLine();
                                FileStream fileStreamObj1 = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\ONLINE CINEMA\MovieDetails.txt", FileMode.Open);
                                StreamReader streamReaderObj1 = new StreamReader(fileStreamObj1);
                                FileStream fileStreamObj2 = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\ONLINE CINEMA\Bookings.txt", FileMode.Append, FileAccess.Write);
                                StreamWriter StreamWriterObj2 = new StreamWriter(fileStreamObj2);
                                while (streamReaderObj1.Peek() > 0)
                                {
                                    string read = streamReaderObj1.ReadLine();
                                    if (read.Contains(movieName))
                                    {
                                        count++;
                                        StreamWriterObj2.Write("Booking Id - "+DateTime.Now.ToString()+username+" ");
                                        StreamWriterObj2.WriteLine(read);
                                    }
                                }streamReaderObj1.Dispose();
                                streamReaderObj1.Close();
                                fileStreamObj1.Close();
                                StreamWriterObj2.Dispose();
                                StreamWriterObj2.Close();
                                fileStreamObj2.Close();
                                if (count == 0)
                                {
                                    Console.WriteLine("Entered movie doesn't exist please try again.");
                                    goto MNAME;
                                }
                                break;
                            case "2":
                                break;
                            default:
                                Console.WriteLine("Choose Correct Option");
                                goto MID;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry, No Movies Available");
                    }
                    break;
                case "2":
                    if(!File.Exists(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\ONLINE CINEMA\Bookings.txt"))
                    {
                        Console.WriteLine("You didn't booked any tickets till now.");
                    }
                    else
                    {
                        FileStream fileStreamObj3 = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\ONLINE CINEMA\Bookings.txt",FileMode.Open);
                        StreamReader StreamReaderObj3 = new StreamReader(fileStreamObj3);
                        while (StreamReaderObj3.Peek() > 0)
                        {
                            string line = StreamReaderObj3.ReadLine();
                            if (line.Contains(username))
                            {
                                Console.WriteLine(line+" "+"Status : Booked");
                            }
                        }
                        StreamReaderObj3.Close();
                        fileStreamObj3.Close();
                        Console.Write("Enter booking Id of which u want to cancel - ");
                        string ans = Console.ReadLine();
                        FileStream fileStreamObj4 = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\ONLINE CINEMA\Bookings.txt", FileMode.Open);
                        StreamReader StreamReaderObj4 = new StreamReader(fileStreamObj4);
                        FileStream fileStreamObj5 = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\ONLINE CINEMA\Bookings1.txt", FileMode.Create, FileAccess.Write);
                        StreamWriter streamWriterObj5 = new StreamWriter(fileStreamObj5);
                        while (StreamReaderObj4.Peek() > 0)
                        {
                            string line2 = StreamReaderObj4.ReadLine();
                            if (!line2.Contains(ans))
                            {
                                streamWriterObj5.WriteLine(line2);
                            }
                        }
                        StreamReaderObj4.Dispose();
                        StreamReaderObj4.Close();
                        fileStreamObj4.Close();
                        streamWriterObj5.Dispose();
                        streamWriterObj5.Close();
                        fileStreamObj5.Close();
                        File.Delete(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\ONLINE CINEMA\Bookings.txt");
                        File.Move(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\ONLINE CINEMA\Bookings1.txt", @"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\ONLINE CINEMA\Bookings.txt");
                    }
                    break;
                case "3":
                    return;
                default: Console.WriteLine("Choose correct option");
                    goto TOP;
            }
            goto TOP;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ONLINE_CINEMA
{
    public class Admin
    {
        public void Module()
        {
            try
            {
                if (!File.Exists(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\ONLINE CINEMA\Bookings.txt"))
                {
                    Console.WriteLine("No One has booked tickets till now");
                }
                else
                {
                    using (FileStream fileStreamObj = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\ONLINE CINEMA\Bookings.txt", FileMode.Open))
                    {
                        StreamReader streamReaderObj = new StreamReader(fileStreamObj);
                        while (streamReaderObj.Peek() > 0)
                        {
                            Console.WriteLine(streamReaderObj.ReadLine());
                        }
                    }
                }
                UP:
                Console.Write("Enter yes to LogOut - ");
                if (Console.ReadLine() == "yes")
                {
                    return;
                }
                goto UP;
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERROR 404");
                using (FileStream fileStreamObj2 = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\ONLINE CINEMA\Log.txt", FileMode.Append, FileAccess.Write))
                {
                    StreamWriter streamWriterObj = new StreamWriter(fileStreamObj2);
                    streamWriterObj.Write("Date : " + DateTime.Now.ToString() + " ");
                    streamWriterObj.Write("Message : " + ex.Message+" ");
                    streamWriterObj.WriteLine("StackTrace : "+ex.StackTrace+" ");
                }
            }
        }
    }
}

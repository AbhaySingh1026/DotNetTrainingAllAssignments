using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FOOD_COURT_MANAGEMENT_SYSTEM
{
    public class Reports
    {
        public Reports()
        {
            using(FileStream fileStreamObj = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\FOOD COURT MANAGEMENT SYSTEM\FoodItems.txt", FileMode.Open))
            {
                StreamReader reader = new StreamReader(fileStreamObj);
                while (reader.Peek() > 0)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
            using (FileStream fileStreamObj = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\FOOD COURT MANAGEMENT SYSTEM\FoodCategory.txt", FileMode.Open))
            {
                StreamReader reader = new StreamReader(fileStreamObj);
                while (reader.Peek() > 0)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
            using (FileStream fileStreamObj = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\FOOD COURT MANAGEMENT SYSTEM\Sales.txt", FileMode.Open))
            {
                StreamReader reader = new StreamReader(fileStreamObj);
                while (reader.Peek() > 0)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
        }
    }
}

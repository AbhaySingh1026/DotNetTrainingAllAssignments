using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FOOD_COURT_MANAGEMENT_SYSTEM
{
    public class FoodItems
    {
        public FoodItems()
        {
            FileStream fileStreamObj = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\FOOD COURT MANAGEMENT SYSTEM\FoodItems.txt", FileMode.Open);
        TOP:
            Console.WriteLine("1. Adding new food item");
            Console.WriteLine("2. Edit existing food item");
            Console.WriteLine("3. View details of food item");
            Console.WriteLine("4. Listing of all food item");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Add(fileStreamObj);
                    fileStreamObj.Close();
                    break;
                case 2:
                    Edit(fileStreamObj);
                    fileStreamObj.Close();
                    File.Delete(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\FOOD COURT MANAGEMENT SYSTEM\FoodItems.txt");
                    File.Move(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\FOOD COURT MANAGEMENT SYSTEM\FoodItems1.txt", @"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\FOOD COURT MANAGEMENT SYSTEM\FoodItems.txt");
                    break;
                case 3:
                    ShowOne(fileStreamObj);
                    fileStreamObj.Close();
                    break;
                case 4:
                    ShowAll(fileStreamObj);
                    fileStreamObj.Close();
                    break;
                default:
                    Console.WriteLine("Entered wrong option");
                    goto TOP;
            }
        }
        void Add(FileStream fileStreamObj)
        {
            StreamWriter streamWriterObj = new StreamWriter(fileStreamObj);
            Console.Write("Enter in this order(FoodItem Price) - ");
            streamWriterObj.WriteLine(Console.ReadLine());
            streamWriterObj.Close();
        }
        void Edit(FileStream fileStreamObj)
        {
            StreamReader streamReaderObj = new StreamReader(fileStreamObj);
            Console.Write("Existing Value - ");
            string existingvalue = Console.ReadLine();
            Console.Write("Replace it with - ");
            string currentValue = Console.ReadLine();
            string store = streamReaderObj.ReadToEnd();
            if (store.Contains(existingvalue))
            {
                store = store.Replace(existingvalue, currentValue);
            }
            using (FileStream fileStreamObj2 = new FileStream(@"E:\KelltonTech\.NET training kellton\Real Training Started\DotNetTrainingAllAssignments\FOOD COURT MANAGEMENT SYSTEM\FoodItems1.txt", FileMode.Create, FileAccess.Write))
            {
                StreamWriter streamWriterObj = new StreamWriter(fileStreamObj2);
                streamWriterObj.WriteLine(store);
            }
            streamReaderObj.Close();
        }
        void ShowOne(FileStream fileStreamObj)
        {
            Console.Write("Enter Food Item of which you want to see details - ");
            string ans = Console.ReadLine();
            StreamReader streamReaderObj = new StreamReader(fileStreamObj);
            while (streamReaderObj.Peek() > 0)
            {
                string value = streamReaderObj.ReadLine();
                if (value.Contains(ans))
                {
                    Console.WriteLine(value);
                }
            }
            streamReaderObj.Close();
        }
        void ShowAll(FileStream fileStreamObj)
        {
            StreamReader streamReaderObj = new StreamReader(fileStreamObj);
            while (streamReaderObj.Peek() > 0)
            {
                Console.WriteLine(streamReaderObj.ReadLine());
            }
        }
    }
}

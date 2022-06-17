using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EVENT_MANAGEMENT_BY_ADO.NET
{
    public class AllTables
    {
        public string connection = "Data Source=DESKTOP-I3CUF5I;Initial Catalog=BankDb;Integrated Security=True";
        public void SuperAdminDetails()
        {
            TOP:
            Console.WriteLine("1. Add Admin\n2. Remove Admin\n3. Log Out");
            int input = Convert.ToInt32(Console.ReadLine());
            SqlConnection sqlConnectionObj = new SqlConnection(connection);
            DataTable dataTableObj = new DataTable();
            switch (input)
            {
                case 1:
                    string[] columnNames = { "UserName - ", "Password - ", "Full Name - ", "City - ", "Mobile Number - " };
                    string[] columnInput = new string[5];
                    for(int i = 0; i < 5; i++)
                    {
                        Console.Write(columnNames[i]);
                        columnInput[i] = Console.ReadLine();
                    }
                    SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter("insert into ADMINDETAILS(USERNAME,LPASSWORD,FNAME,CITY,MNO) values('" + columnInput[0] +"','"+ columnInput[1] + "','"+ columnInput[2] + "','"+ columnInput[3] + "','"+ columnInput[4] + "')", sqlConnectionObj);
                    sqlDataAdapterObj.Fill(dataTableObj);
                    break;
                case 2:Console.Write("Enter admin Id of which u want to remove from admin - ");
                    int adminId = Convert.ToInt32(Console.ReadLine());
                    SqlDataAdapter sqlDataAdapterObj1 = new SqlDataAdapter("delete from ADMINDETAILS where ADMINID = " + adminId+"", sqlConnectionObj);
                    sqlDataAdapterObj1.Fill(dataTableObj);
                    break;
                case 3: return;
                default: Console.WriteLine("Please choose correct option");
                    goto TOP;
            }goto TOP;
        }
        public void AdminDetails(string username)
        {
            SqlConnection sqlConnectionObj = new SqlConnection(connection);
            DataTable dataTableObj = new DataTable();
        TOP:
            Console.WriteLine("1. Change Password\n2. Pending Requests\n3. Add Events\n4. Log Out");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Write("Enter you new password - ");
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("update ADMINDETAILS set LPASSWORD = '"+Console.ReadLine()+"' where USERNAME = '"+username+"'", sqlConnectionObj);
                    sqlDataAdapter.Fill(dataTableObj);
                    break;
                case 2: ApproveOrReject(sqlConnectionObj, dataTableObj);
                    break;
                case 3:
                    TOP1:
                    Console.WriteLine("1. Add new venue\n2. Add items in existing venue\n3. Remove Venue\n4. Remove any item from any particular venue\n5. Update venue details\n6. Update venue item name\n7. Goto main menu");
                    int secondInput = Convert.ToInt32(Console.ReadLine());
                    switch (secondInput)
                    {
                        case 1:
                            AddVenuw(sqlConnectionObj, dataTableObj);
                            break;
                        case 2:
                            int venueId = ShowAllVenue(sqlConnectionObj, dataTableObj);
                            UP:
                            Console.WriteLine("Which item u want to add? -\n1. Food Item\n2. Lights\n3. Flowers");
                            if (Console.ReadLine() == "1") AddFood(venueId, sqlConnectionObj, dataTableObj);
                            else if (Console.ReadLine() == "2") AddLight(venueId, sqlConnectionObj, dataTableObj);
                            else if (Console.ReadLine() == "3") AddFlower(venueId, sqlConnectionObj, dataTableObj);
                            else goto UP;
                            break;
                        case 3: int venueId1 = ShowAllVenue(sqlConnectionObj, dataTableObj);
                            RemoveVenue(venueId1, sqlConnectionObj, dataTableObj);
                            break;
                        case 4: int venueId2 = ShowAllVenue(sqlConnectionObj, dataTableObj);
                            UP1:
                            Console.WriteLine("Which item u want to delete? -\n1. Food Item\n2. Lights\n3. Flowers");
                            if (Console.ReadLine() == "1") RemoveFoodAtCondition(venueId2, sqlConnectionObj, dataTableObj);
                            else if (Console.ReadLine() == "2") RemoveLightAtCondition(venueId2, sqlConnectionObj, dataTableObj);
                            else if (Console.ReadLine() == "3") RemoveFlowerAtCondition(venueId2, sqlConnectionObj, dataTableObj);
                            else goto UP1;
                            break;
                        case 5:
                            int venueId3 = ShowAllVenue(sqlConnectionObj, dataTableObj);
                            UpdateVenue(venueId3, sqlConnectionObj, dataTableObj);
                            break;
                        case 6:
                            int venueId4 = ShowAllVenue(sqlConnectionObj, dataTableObj);
                            UP2:
                            Console.WriteLine("Which item u want to Update? -\n1. Food Item\n2. Lights\n3. Flowers");
                            if (Console.ReadLine() == "1") UpdateFood(venueId4, sqlConnectionObj, dataTableObj);
                            else if (Console.ReadLine() == "2") UpdateLight(venueId4, sqlConnectionObj, dataTableObj);
                            else if (Console.ReadLine() == "3") UpdateFlower(venueId4, sqlConnectionObj, dataTableObj);
                            else goto UP2;
                            break;
                        case 7: goto TOP;
                        default: Console.WriteLine("Please choose correct option");
                            goto TOP1;
                    }goto TOP1;
                case 4: return;
                default: Console.WriteLine("Please choose correct option");
                    goto TOP;
            }goto TOP;
        }
        public void CustomerDetails(string username)
        {
            SqlConnection sqlConnectionObj = new SqlConnection(connection);
            DataTable dataTableObj = new DataTable();
        TOP:
            Console.WriteLine("1. Status\n2. BooksVenue\n3. Log Out");
            switch (Console.ReadLine())
            {
                case "1":
                    ShowStatus(username, sqlConnectionObj, dataTableObj);
                    break;
                case "2": int id = ShowAllVenue(sqlConnectionObj, dataTableObj);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from food where FOODID = "+id+"", sqlConnectionObj);
                    sqlDataAdapter.Fill(dataTableObj);
                    Console.WriteLine("Available Food Items for this venue are - ");
                    for(int i=0;i<dataTableObj.Rows.Count;i++) Console.WriteLine(dataTableObj.Rows[i][1]);
                    SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("select * from LIGHTS where LIGHTID = " + id + "", sqlConnectionObj);
                    sqlDataAdapter1.Fill(dataTableObj);
                    Console.WriteLine("Available Lights for this venue are - ");
                    for (int i = 0; i < dataTableObj.Rows.Count; i++) Console.WriteLine(dataTableObj.Rows[i][1]);
                    SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("select * from FLOWERS where FLOWERID = " + id + "", sqlConnectionObj);
                    sqlDataAdapter2.Fill(dataTableObj);
                    Console.WriteLine("Available flowers for this venue are - ");
                    for (int i = 0; i < dataTableObj.Rows.Count; i++) Console.WriteLine(dataTableObj.Rows[i][1]);
                    Console.WriteLine("\n\n + 1. Book this venue\n2. Go Back");
                    if (Console.ReadLine() == "1") BookVenue(username,id,sqlConnectionObj,dataTableObj);
                    else goto TOP;
                    break;
                case "3": return;
                default: Console.WriteLine("Please choose correct option");
                    goto TOP;
            }goto TOP;
        }
        void AddVenuw(SqlConnection sqlConnectionObj,DataTable dataTableObj)
        {
            Console.Write("Enter venue name - ");
            string venueName = Console.ReadLine();
            Console.Write("Enter price per hour fkr this venue - ");
            int priceOfHour = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("insert into venue(VENUENAME,PRICEPERHOUR) values('"+venueName+"',"+priceOfHour+")", sqlConnectionObj);
            sqlDataAdapter.Fill(dataTableObj);
        }
        int ShowAllVenue(SqlConnection sqlConnectionObj, DataTable dataTableObj)
        {
            TOP:
            Console.WriteLine("For which venue - ");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from venue", sqlConnectionObj);
            sqlDataAdapter.Fill(dataTableObj);
            for(int i = 0; i < dataTableObj.Rows.Count; i++)
            {
                Console.WriteLine(Convert.ToString(i+1) + ". " + dataTableObj.Rows[i][1] + " " + dataTableObj.Rows[i][2]);
            }int input = Convert.ToInt32(Console.ReadLine());
            if (input > 0 && input <= dataTableObj.Rows.Count) return Convert.ToInt32(dataTableObj.Rows[input - 1][0]);
            else goto TOP;
        }
        void AddFood(int venueId, SqlConnection sqlConnectionObj, DataTable dataTableObj)
        {
            Console.Write("Enter food name - ");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("insert into food(FOODID,FOODNAME) values("+venueId+",'"+Console.ReadLine()+"')", sqlConnectionObj);
            sqlDataAdapter.Fill(dataTableObj);
        }
        void AddLight(int venueId, SqlConnection sqlConnectionObj, DataTable dataTableObj)
        {
            Console.Write("Enter light name - ");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("insert into LIGHTS(LIGHTID,LIGHTNAME) values(" + venueId + ",'" + Console.ReadLine() + "')", sqlConnectionObj);
            sqlDataAdapter.Fill(dataTableObj);
        }
        void AddFlower(int venueId, SqlConnection sqlConnectionObj, DataTable dataTableObj)
        {
            Console.Write("Enter flower name - ");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("insert into FLOWERS(FLOWERID,FLOWERNAME) values(" + venueId + ",'" + Console.ReadLine() + "')", sqlConnectionObj);
            sqlDataAdapter.Fill(dataTableObj);
        }
        void RemoveVenue(int venueId, SqlConnection sqlConnectionObj, DataTable dataTableObj)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("delete from FOOD where VENUEID = " + venueId + "", sqlConnectionObj);
            sqlDataAdapter.Fill(dataTableObj);
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("delete from LIGHTS where LIGHTID = " + venueId + "", sqlConnectionObj);
            sqlDataAdapter1.Fill(dataTableObj);
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("delete from FLOWERS where FLOWERID = " + venueId + "", sqlConnectionObj);
            sqlDataAdapter2.Fill(dataTableObj);
            SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter("delete from venue where VENUEID = "+venueId+"", sqlConnectionObj);
            sqlDataAdapter3.Fill(dataTableObj);
        }
        void RemoveFoodAtCondition(int venueId, SqlConnection sqlConnectionObj, DataTable dataTableObj)
        {
            Console.Write("Enter food name - ");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("delete from FOOD where VENUEID = " + venueId + " and FOODNAME = '"+Console.ReadLine()+"'", sqlConnectionObj);
            sqlDataAdapter.Fill(dataTableObj);
        }
        void RemoveLightAtCondition(int venueId, SqlConnection sqlConnectionObj, DataTable dataTableObj)
        {
            Console.Write("Enter light name - ");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("delete from LIGHTS where LIGHTID = " + venueId + " and LIGHTNAME = '"+Console.ReadLine()+"'", sqlConnectionObj);
            sqlDataAdapter.Fill(dataTableObj);
        }
        void RemoveFlowerAtCondition(int venueId, SqlConnection sqlConnectionObj, DataTable dataTableObj)
        {
            Console.Write("Enter flower name - "); 
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("delete from FLOWERS where FLOWERID = " + venueId + " and FLOWERNAME = '"+Console.ReadLine()+"'", sqlConnectionObj);
            sqlDataAdapter.Fill(dataTableObj);
        }
        void UpdateVenue(int venueId, SqlConnection sqlConnectionObj, DataTable dataTableObj)
        {
            LINE179:
            Console.WriteLine("What you want to update? -\n1. Venue name\n2. Price per hour");
            if (Console.ReadLine() == "1")
            {
                Console.Write("Enter new name - ");
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("update venue set VENUENAME = '"+Console.ReadLine()+ "' where  VENUEID = "+venueId+"", sqlConnectionObj);
                sqlDataAdapter.Fill(dataTableObj);
            }
            else if (Console.ReadLine() == "2")
            {
                Console.Write("Enter new price - ");
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("update venue set PRICEPERHOUR = " + Console.ReadLine() + " where VENUEID = " + venueId + "", sqlConnectionObj);
                sqlDataAdapter.Fill(dataTableObj);
            }
            else goto LINE179;
        }
        void UpdateFood(int venueId, SqlConnection sqlConnectionObj, DataTable dataTableObj)
        {
            Console.Write("Enter food name u want to update - ");
            string fname = Console.ReadLine();
            Console.Write("Enter new food name - ");
            string newF = Console.ReadLine();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("update FOOD set FOODNAME = '" + newF + "' where FOODID = " + venueId + " and FOODNAME = '"+fname+"'", sqlConnectionObj);
            sqlDataAdapter.Fill(dataTableObj);
        }
        void UpdateLight(int venueId, SqlConnection sqlConnectionObj, DataTable dataTableObj)
        {
            Console.Write("Enter light name u want to update - ");
            string lname = Console.ReadLine();
            Console.Write("Enter new light name - ");
            string newL = Console.ReadLine();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("update LIGHTS set LIGHTNAME = '" + newL + "' where LIGHTID = " + venueId + " and LIGHTNAME = '" + lname + "'", sqlConnectionObj);
            sqlDataAdapter.Fill(dataTableObj);
        }
        void UpdateFlower(int venueId, SqlConnection sqlConnectionObj, DataTable dataTableObj)
        {
            Console.Write("Enter flower name u want to update - ");
            string fname = Console.ReadLine();
            Console.Write("Enter new flower name - ");
            string newF = Console.ReadLine();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("update FLOWERS set FLOWERNAME = '" + newF + "' where FLOWERID = " + venueId + " and FLOWERNAME = '" + fname + "'", sqlConnectionObj);
            sqlDataAdapter.Fill(dataTableObj);
        }
        void BookVenue(string username,int id, SqlConnection sqlConnectionObj, DataTable dataTableObj)
        {
            TOP:
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select VENUENAME from venue where VENUEID = "+id+"", sqlConnectionObj);
                sqlDataAdapter.Fill(dataTableObj);
                string venueName = dataTableObj.Rows[0][1].ToString();
                Console.Write("Booking date(year-month-day) - ");
                string date = Console.ReadLine();
                Console.Write("From time - ");
                string fromTime = Console.ReadLine();
                Console.Write("To time - ");
                string toTIme = Console.ReadLine();
                Console.Write("For how many person u want to book - ");
                int person = Convert.ToInt32(Console.ReadLine());
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("insert into booking(username,VENUENAME,BOOKINGDATE,FROMTIME,TOTIME,FORPERSONS) values('" + username + "','" + venueName +"','"+date+"','"+fromTime+"','"+toTIme+"',"+person+")", sqlConnectionObj);
                sqlDataAdapter1.Fill(dataTableObj);
            }
            catch
            {
                Console.WriteLine("Oops.. slot is not available on selected date and time, Please try again");
                goto TOP;
            }
        }
        void ShowStatus(string username, SqlConnection sqlConnectionObj, DataTable dataTableObj)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from booking where username = '"+username+"'", sqlConnectionObj);
            sqlDataAdapter.Fill(dataTableObj);
        }
        void ApproveOrReject(SqlConnection sqlConnectionObj, DataTable dataTableObj)
        {
            string temp = "NEUTRAL";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"select * from booking where status = '"+temp+"'", sqlConnectionObj);
            sqlDataAdapter.Fill(dataTableObj);
            for(int i = 0; i < dataTableObj.Rows.Count; i++)
            {
                for(int j=0;j<dataTableObj.Columns.Count; j++)
                {
                    Console.Write(dataTableObj.Rows[i][j] + " ");
                }Console.WriteLine();
            }
            TOP:
            Console.Write("Enter username - ");
            string username = Console.ReadLine();
            Console.WriteLine("1. Approve\n2. Disapprove");
            if(Console.ReadLine() == "1")
            {
                temp = "Approve";
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("update booking set status = '"+temp+"' where username = '"+username+"'", sqlConnectionObj);
                sqlDataAdapter1.Fill(dataTableObj);
            }
            else if(Console.ReadLine() == "2")
            {
                temp = "Disapprove";
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("update booking set status = '"+temp+"' where username = '" + username + "'", sqlConnectionObj);
                sqlDataAdapter1.Fill(dataTableObj);
            }
            else goto TOP;
        }
    }
}

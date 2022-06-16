using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EVENT_MANAGEMENT_BY_ADO.NET
{
    internal class Program
    {
        static string connection = "Data Source=DESKTOP-I3CUF5I;Initial Catalog=BankDb;Integrated Security=True";
        static void Main(string[] args)
        {
            SqlConnection sc = new SqlConnection(connection);
            SqlDataAdapter sda = new SqlDataAdapter("select * from superadmindetails", sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count == 0)
            {
                string[] columnNames1 = { "username - ", "password - "};
                string[] columnInput1 = new string[2];
                for (int i = 0; i < 2; i++)
                {
                    Console.Write(columnNames1[i]);
                    columnInput1[i] = Console.ReadLine();
                }
                SqlDataAdapter sda1 = new SqlDataAdapter("insert into superadmindetails(username,lpassword) values('"+ columnInput1[0] + "','"+ columnInput1[1] + "')", sc);
                sda1.Fill(dt);
            }
        EXTREMETOP:
            Console.WriteLine("1. Login\n2. Sign Up(if new customer)\n3. Close Application");
            int mainInput = Convert.ToInt32(Console.ReadLine());
            switch (mainInput)
            {
                case 1:
                    TOP:
                    Console.Write("Username - ");
                    string username = Console.ReadLine();
                    Console.Write("Password - ");
                    string password = Console.ReadLine();
                    string tableName = LoginFunctionality(username,password);
                    if (tableName == null)
                    {
                        Console.WriteLine("Either Username or Password is incorrect, please try agaian.");
                        goto TOP;
                    }
                    else
                    {
                        AllTables allTables = new AllTables();
                        if (tableName == "SUPERADMINDETAILS") allTables.SuperAdminDetails();
                        else if(tableName == "ADMINDETAILS") allTables.AdminDetails(username);
                        else allTables.CustomerDetails(username);
                    }
                    break;
                case 2:
                    string[] columnNames = { "UserName - ", "Password - ", "Full Name - ", "City - ", "Mobile Number - " };
                    string[] columnInput = new string[5];
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write(columnNames[i]);
                        columnInput[i] = Console.ReadLine();
                    }
                    SqlConnection sqlConnectionObj = new SqlConnection(connection);
                    SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter("insert into CUSTOMERDETAILS(USERNAME,LPASSWORD,FNAME,CITY,MNO) values('"+ columnInput[0] + "','"+ columnInput[1] + "','"+ columnInput[2] + "','"+ columnInput[3] + "','"+ columnInput[4] + "')", sqlConnectionObj);
                    DataTable dataTableObj = new DataTable();
                    sqlDataAdapterObj.Fill(dataTableObj);
                    break;
                case 3: return;
                default:Console.WriteLine("------Please select correct option------");
                    goto EXTREMETOP;
            }goto EXTREMETOP;
        }
        static string LoginFunctionality(string username,string password)
        {
            string[] tableName = { "SUPERADMINDETAILS", "ADMINDETAILS", "CUSTOMERDETAILS" };
            for(int i = 0; i < tableName.Length; i++)
            {
                string result = Dowork(tableName[i],username,password);
                if (result != null) return result;
            }return null;
        }
        static string Dowork(string tablename,string username,string password)
        {
            SqlConnection sqlConnectionObj = new SqlConnection(connection);
            SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter($"select * from {tablename}", sqlConnectionObj);
            DataTable dataTableObj = new DataTable();
            sqlDataAdapterObj.Fill(dataTableObj);
            for(int i = 0; i < dataTableObj.Rows.Count; i++)
            {
                if ((dataTableObj.Rows[i][1].ToString() == username) && (dataTableObj.Rows[i][2].ToString() == password)) return tablename;  // MAIN LOGIC
            }return null;
        }
    }
}
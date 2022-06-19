using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace SEND__EMAIL_ON_BOOKING_ORDER
{
    public class AllOperationsOnTable
    {
        #region Properties
        static string itemName { get; set; }
        static double price { get; set; }
        static int quantity { get; set; }
        static string fName { get; set; }
        static string lName { get; set; }
        static long phone { get; set; }
        static string email { get; set; }
        #endregion

        #region Data Members
        static int count = 0;
        static string connection = "Data Source=DESKTOP-I3CUF5I;Initial Catalog=BankDb;Integrated Security=True";
        #endregion

        #region Methods
        public static void InsertItem()
        {
            SqlConnection sqlConnectionObj = new SqlConnection(connection);
            DataTable dataTableObj = new DataTable();
        TOP:
            try
            {
                Console.Write("Enter Item Name - ");
                itemName = Console.ReadLine();
                if (itemName == "")
                {
                    Console.WriteLine("You can't leave item name empty, please try again");
                    goto TOP;
                }
                Console.Write("Enter Price - ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter Quantity - ");
                quantity = Convert.ToInt32(Console.ReadLine());
                SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter("Exec INSERTITEM '" + itemName + "'," + price + "," + quantity + "", sqlConnectionObj);
                sqlDataAdapterObj.Fill(dataTableObj);
                Console.WriteLine("Record INSERTED");
            }
            catch(FormatException)
            {
                Console.WriteLine("Please enter values with correct datatypes - ");
                goto TOP;
            }
            catch(SqlException)
            {
                Console.WriteLine("Item table doesn't exist in database, first make table & try again Or this item name already exists");
                goto TOP;
            }
        }
        public static void UpdateItem()
        {
            SqlConnection sqlConnectionObj = new SqlConnection(connection);
            DataTable dataTableObj = new DataTable();
        TOP:
            try
            {
                Console.WriteLine("What you want to update -\n1. Item Name\n2. Item Rate\n3. Item Quantity");
                string chooseOption = Console.ReadLine();
                Console.Write("Enter Item Name - ");
                itemName = Console.ReadLine();
                if (itemName == "")
                {
                    Console.WriteLine("You can't leave item name empty, please try again");
                    goto TOP;
                }
                if (chooseOption == "1")
                {
                    Console.Write("Enter New Item Name - ");
                    string newItemName = Console.ReadLine();
                    SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter("Exec UPDATEITEMNAME '"+itemName+"','"+newItemName+"'", sqlConnectionObj);
                    sqlDataAdapterObj.Fill(dataTableObj);
                    Console.WriteLine("Record UPDATED");
                }
                if(chooseOption == "2")
                {
                    Console.Write("Enter Price - ");
                    price = Convert.ToDouble(Console.ReadLine());
                    SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter("Exec UPDATEITEMRATE '" + itemName + "'," + price + "", sqlConnectionObj);
                    sqlDataAdapterObj.Fill(dataTableObj);
                    Console.WriteLine("Record UPDATED");
                }
                if (chooseOption == "3")
                {
                    Console.Write("Enter Quantity - ");
                    quantity = Convert.ToInt32(Console.ReadLine());
                    SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter("Exec UPDATEITEMQUANTITY '" + itemName + "'," + quantity + "", sqlConnectionObj);
                    sqlDataAdapterObj.Fill(dataTableObj);
                    Console.WriteLine("Record UPDATED");
                }
                else goto TOP;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter values with correct datatypes - ");
                goto TOP;
            }
            catch (SqlException)
            {
                Console.WriteLine("Item table doesn't exist in database, first make table & try again Or this new item name already exists");
                goto TOP;
            }
        }
        public static void DeleteItem()
        {
            SqlConnection sqlConnectionObj = new SqlConnection(connection);
            DataTable dataTableObj = new DataTable();
        TOP:
            try
            {
                Console.Write("Enter Item Name - ");
                itemName = Console.ReadLine();
                if (itemName == "")
                {
                    Console.WriteLine("You can't leave item name empty, please try again");
                    goto TOP;
                }
                SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter("Exec DELETEITEM '" + itemName + "'", sqlConnectionObj);
                sqlDataAdapterObj.Fill(dataTableObj);
                Console.WriteLine("RECORD DELETED");
            }
            catch (SqlException)
            {
                Console.WriteLine("Item table doesn't exist in database, first make table & try again");
                return;
            }
        }
        public static void ShowAllItems()
        {
            SqlConnection sqlConnectionObj = new SqlConnection(connection);
            DataTable dataTableObj = new DataTable();
            try
            {
                SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter("Exec SHOWALLITEMS", sqlConnectionObj);
                sqlDataAdapterObj.Fill(dataTableObj);
                if(dataTableObj.Rows.Count == 0)
                {
                    Console.WriteLine("No data present to show, please 1st insert data - ");
                    return;
                }
                for(int i = 0; i < dataTableObj.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        for (int j = 0; j < dataTableObj.Columns.Count; j++)
                        {
                            Console.Write(dataTableObj.Columns[j].ColumnName + " ");
                        }
                        Console.WriteLine();
                    }
                    for(int j = 0; j < dataTableObj.Columns.Count; j++)
                    {
                        Console.Write(dataTableObj.Rows[i][j] + " ");
                    }Console.WriteLine();
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("Item table doesn't exist in database, first make table & try again");
                return;
            }
        }
        public static void InsertCustomer()
        {
           TOP:
            SqlConnection sqlConnectionObj = new SqlConnection(connection);
            try
            {
                Console.Write("Enter First Name - ");
                fName = Console.ReadLine();
                Console.Write("Enter Last Name - ");
                lName = Console.ReadLine();
                Console.Write("Enter Mobile Number - ");
                phone = Convert.ToInt64(Console.ReadLine());
                Console.Write("Enter Email Address - ");
                email = Console.ReadLine();
                if ((fName == "") || (lName == "")||(email == ""))
                {
                    Console.WriteLine("You can't leave fields empty, please try again");
                    goto TOP;
                }
                SqlCommand sqlCommandObj = new SqlCommand("Exec INSERTCUSTOMER '" + fName + "','" + lName + "'," + phone + ",'" + email + "'", sqlConnectionObj);
                sqlConnectionObj.Open();
                count = sqlCommandObj.ExecuteNonQuery();
                sqlConnectionObj.Close();
                if(count != 1)
                {
                    Console.WriteLine("Please enter a valid email format - ");
                    goto TOP;
                }count = 0;
                Console.WriteLine("RECORD INSERTED");
            }
            catch(SqlException)
            {
                Console.WriteLine("Customer table doesn't exist in database, first make table & try again OR you are entering duplicate phone number or email please try again -");
                goto TOP;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter values with correct datatypes - ");
                goto TOP;
            }
        }
        public static void UpdateCustomer()
        {
        TOP:
            SqlConnection sqlConnectionObj = new SqlConnection(connection);
            try
            {
                Console.WriteLine("Which field you want to update -\n1. First Name\n2. Last Name\n3. Phone Number\n4. Email");
                string chooseOption = Console.ReadLine();
                Console.Write("Enter Email - ");
                email = Console.ReadLine();
                if(chooseOption == "1")
                {
                    Console.Write("Enter First Name - ");
                    fName = Console.ReadLine();
                    if((email == "")||(fName == ""))
                    {
                        Console.WriteLine("You can't leave fields empty, please try again -");
                        goto TOP;
                    }
                    SqlCommand sqlCommandObj = new SqlCommand("Exec UPDATECUSTOMERFNAME '"+email+"','"+fName+"'", sqlConnectionObj);
                    sqlConnectionObj.Open();
                    count = sqlCommandObj.ExecuteNonQuery();
                    sqlConnectionObj.Close();
                    if(count != 1)
                    {
                        Console.WriteLine("Enter email doesn't exists, please try again and enter valid email - ");
                        goto TOP;
                    }count = 0;
                }
                if(chooseOption == "2")
                {
                    Console.Write("Enter Last Name - ");
                    lName = Console.ReadLine();
                    if ((email == "") || (lName == ""))
                    {
                        Console.WriteLine("You can't leave fields empty, please try again -");
                        goto TOP;
                    }
                    SqlCommand sqlCommandObj = new SqlCommand("Exec UPDATECUSTOMERLNAME '" + email + "','" + lName + "'", sqlConnectionObj);
                    sqlConnectionObj.Open();
                    count = sqlCommandObj.ExecuteNonQuery();
                    sqlConnectionObj.Close();
                    if (count != 1)
                    {
                        Console.WriteLine("Enter email doesn't exists, please try again and enter valid email - ");
                        goto TOP;
                    }count = 0;
                }
                if(chooseOption == "3")
                {
                    Console.Write("Enter Mobile Number - ");
                    phone = Convert.ToInt64(Console.ReadLine());
                    if (email == "")
                    {
                        Console.WriteLine("You can't leave fields empty, please try again -");
                        goto TOP;
                    }
                    SqlCommand sqlCommandObj = new SqlCommand("Exec UPDATECUSTOMERPHONE '" + email + "'," + phone + "", sqlConnectionObj);
                    sqlConnectionObj.Open();
                    count = sqlCommandObj.ExecuteNonQuery();
                    sqlConnectionObj.Close();
                    if (count != 1)
                    {
                        Console.WriteLine("Enter email doesn't exists, please try again and enter valid email - ");
                        goto TOP;
                    }count = 0;
                }
                if (chooseOption == "4")
                {
                    Console.Write("Enter New Email Address - ");
                    string newEmail = Console.ReadLine();
                    if ((email == "") || (newEmail == ""))
                    {
                        Console.WriteLine("You can't leave fields empty, please try again -");
                        goto TOP;
                    }
                    SqlCommand sqlCommandObj = new SqlCommand("Exec UPDATECUSTOMEREMAIL '"+email+"','"+newEmail+"'", sqlConnectionObj);
                    sqlConnectionObj.Open();
                    count = sqlCommandObj.ExecuteNonQuery();
                    sqlConnectionObj.Close();
                    if (count != 1)
                    {
                        Console.WriteLine("Either new Email format is incorrect or email you want to update doesn't exists, Please try again - ");
                        goto TOP;
                    }count = 0;
                }
                else goto TOP;
                Console.WriteLine("RECORD UPDATED");
            }
            catch (SqlException)
            {
                Console.WriteLine("Customer table doesn't exist in database, first make table & try again OR you are entering duplicate phone number or email please try again -");
                goto TOP;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter values with correct datatypes - ");
                goto TOP;
            }
        }
        public static void DeleteCustomer()
        {
        TOP:
            SqlConnection sqlConnectionObj = new SqlConnection(connection);
            try
            {
                Console.Write("Enter Email Address - ");
                email = Console.ReadLine();
                if (email == "")
                {
                    Console.WriteLine("You can't leave fields empty, please try again");
                    goto TOP;
                }
                SqlCommand sqlCommandObj = new SqlCommand("Exec DELETECUSTOMER '" + email + "'", sqlConnectionObj);
                sqlConnectionObj.Open();
                count = sqlCommandObj.ExecuteNonQuery();
                sqlConnectionObj.Close();
                if (count != 1)
                {
                    Console.WriteLine("Entered email doesn't exists, Please enter a valid email - ");
                    goto TOP;
                }count = 0;
                Console.WriteLine("RECORD DELETED");
            }
            catch (SqlException)
            {
                Console.WriteLine("Customer table doesn't exist in database, first make table & try again -");
                goto TOP;
            }
        }
        public static void ShowAllCustomers()
        {
            SqlConnection sqlConnectionObj = new SqlConnection(connection);
            DataTable dataTableObj = new DataTable();
            try
            {
                SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter("Exec SHOWALLCUSTOMERS", sqlConnectionObj);
                sqlDataAdapterObj.Fill(dataTableObj);
                if (dataTableObj.Rows.Count == 0)
                {
                    Console.WriteLine("No data present to show, please 1st insert data - ");
                    return;
                }
                for (int i = 0; i < dataTableObj.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        for (int j = 0; j < dataTableObj.Columns.Count; j++)
                        {
                            Console.Write(dataTableObj.Columns[j].ColumnName + " ");
                        }
                        Console.WriteLine();
                    }
                    for (int j = 0; j < dataTableObj.Columns.Count; j++)
                    {
                        Console.Write(dataTableObj.Rows[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("Customer table doesn't exist in database, first make table & try again -");
                return;
            }
        }
        public static void Verify()
        {
        TOP:
            try
            {
                Console.Write("Enter Your Email ID - ");
                email = Console.ReadLine();
                if (email == "")
                {
                    Console.WriteLine("You can't leave fields empty, Please try again - ");
                    goto TOP;
                }
                SqlConnection sqlConnectionObj = new SqlConnection(connection);
                DataTable dataTableObj = new DataTable();
                SqlDataAdapter sqlDataAdapterObj = new SqlDataAdapter("Exec SHOWALLCUSTOMERS", sqlConnectionObj);
                sqlDataAdapterObj.Fill(dataTableObj);
                int check = 0;
                for(int i = 0; i < dataTableObj.Rows.Count; i++)
                {
                    if(dataTableObj.Rows[i][3].ToString() == email)
                    {
                        fName = dataTableObj.Rows[i][0].ToString();
                        ShowAllItems();
                        check++;
                        break;
                    }
                }if(check == 0)
                {
                    Console.WriteLine("You are not a valid customer, First become a valid customer then only you can book items from us - ");
                    return;
                }MID:
                Console.WriteLine("1. Book Item\n2. Go Back");
                switch (Console.ReadLine())
                {
                    case "1": Console.Write("Enter Item Name you want to book - ");
                        itemName = Console.ReadLine();
                        SqlConnection sql = new SqlConnection(connection);
                        DataTable dt = new DataTable();
                        SqlDataAdapter sqlData = new SqlDataAdapter("EXEC SHOWALLITEMS", sql);
                        sqlData.Fill(dt);
                        check = 0;
                        for(int i = 0; i < dt.Rows.Count; i++)
                        {
                            if(dt.Rows[i][0].ToString() == itemName)
                            {
                                check++;
                                SendEmail(itemName,email,fName);
                                break;
                            }
                        }
                        if (check == 0)
                        {
                            Console.WriteLine("You entered wrong item name, please try again - ");
                            goto MID;
                        }
                        break;
                    case "2": return;
                    default: goto MID;
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("Customer table doesn't exist in database, first make table & try again -");
                return;
            }
        }
        static void SendEmail(string itemName,string email,string fName)
        {
            MailMessage mailMessageObj = new MailMessage("gourav7398@gmail.com",email);
            mailMessageObj.Subject = "Welcome";
            mailMessageObj.Body = $"Dear {fName}, Thanks for ordering item from us.";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com",587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "gourav7398@gmail.com", Password = "ufgeptlbdcjhpfcj"
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessageObj);
        }
        #endregion
    }
}

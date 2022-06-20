using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEND__EMAIL_ON_BOOKING_ORDER
{
    public class AllTableFunctionalities
    {
        public void ItemMaster(string input)
        {
            switch (input)
            {
                case "1": AllOperationsOnTable.InsertItem();
                    break;
                case "2": AllOperationsOnTable.UpdateItem();
                    break;
                case "3": AllOperationsOnTable.DeleteItem();
                    break;
                case "4": AllOperationsOnTable.ShowAllItems();
                    break;
            }
        }
        public void CustomerMaster(string input)
        {
            switch (input)
            {
                case "1":AllOperationsOnTable.InsertCustomer();
                    break;
                case "2":AllOperationsOnTable.UpdateCustomer();
                    break;
                case "3":AllOperationsOnTable.DeleteCustomer();
                    break;
                case "4":AllOperationsOnTable.ShowAllCustomers();
                    break;
            }
        }
        public void BookItem()
        {
            AllOperationsOnTable.Verify();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DBFirstDataBaseEntities context = new DBFirstDataBaseEntities();

            var query = from Customers in context.Customers select Customers;

            foreach (var customer in query)
            {
                Console.WriteLine(customer.Name);
                Console.WriteLine(customer.Telephone_Number);
            }

            Console.ReadLine();
        }
    }
}

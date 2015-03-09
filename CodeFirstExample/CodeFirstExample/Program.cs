using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var newCustomer = new Customer();
            var context = new CustomersAndOrdersContext();

            newCustomer.CustomerID = 1;
            newCustomer.Name = "Alex";

            context.Customers.Add(newCustomer);

            context.SaveChanges();

            var query = from customer in context.Customers select customer;
            foreach (var customer in query)
            {
                Console.WriteLine(customer.CustomerID);
                Console.WriteLine(customer.Name);
            }

            Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {

            var context = new CustomersAndOrdersContainer();
            var newCustomer = new Customer {Id = 1, Name = "Alex", Phone_Number = "0635221487"};


            context.CustomerSet.Add(newCustomer);

            context.SaveChanges();

            var query = from customer in context.CustomerSet select customer;

            foreach (var customer in query)
            {
                Console.WriteLine(customer.Name);
                Console.WriteLine(customer.Phone_Number);
            }

            Console.ReadLine();


        }
    }
}

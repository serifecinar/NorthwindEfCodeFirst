using NorthwindEfCodeFirst.Context;
using NorthwindEfCodeFirst.Entities;

namespace NorthwindEfCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //One();
            //Two();
            //Three();
            //Four();
            using (var northwindContext = new NorthwindContext())
            {
                Customer customer = northwindContext.Customers.Find("ENGİN");
                customer.Country = "Turkey";
                northwindContext.SaveChanges();
            }
                Console.ReadLine();
        }

        private static void Four()
        {
            using (var northwindContext = new NorthwindContext())
            {
                Order order = northwindContext.Orders.Find(1);
                northwindContext.Orders.Remove(order);
                northwindContext.SaveChanges();
            }
        }

        private static void Three()
        {
            using (var northwindContext = new NorthwindContext())
            {
                Customer customer = northwindContext.Customers.Find("ENGİN");
                customer.Orders.Add(new Order
                {
                    OrderID = 1,
                    OrderDate = DateTime.Now,
                    ShipCity = "Ankara",
                    ShipCountry = "Türkiye"
                });
                northwindContext.SaveChanges();
            }
        }

        private static void Two()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var customer = new Customer
                {
                    CustomerID = "ENGİN",
                    City = "Ankara",
                    CompanyName = "YazılımDevi.Com",
                    ContactName = "Engin Demiroğ",
                    Country = "Türkiye"
                };

                northwindContext.Customers.Add(customer);
                northwindContext.SaveChanges();
            }
        }

        private static void One()
        {
            using(NorthwindContext northwindContext=new NorthwindContext())            
            {
                foreach (var customer in northwindContext.Customers)
                {
                    Console.WriteLine("Customer Name : {0}", customer.ContactName);
                }
            }
        }
        

    }
}

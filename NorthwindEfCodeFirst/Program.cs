using NorthwindEfCodeFirst.Context;
using NorthwindEfCodeFirst.Entities;

namespace NorthwindEfCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            // One();
            //Two();
            //Three();
            //Four();
            //Five();

            //Six();
            //Seven();

            //Eight();


            //Nine();

            //Ten();

            using (var northwindContext = new NorthwindContext())
            {
                List<Customer> result = (from c in northwindContext.Customers
                                         orderby c.Country.Length descending, c.ContactName ascending
                                         select c).ToList();
                foreach (var customer in result)
                {
                    Console.WriteLine("{0},{1}",customer.Country ,customer.ContactName);
                }


            }

            Console.ReadLine();
        }

        private static void Ten()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             group c by new { c.Country, c.City }
                                         into g
                             select new
                             {
                                 Sehir = g.Key.City,
                                 Ulke = g.Key.Country,
                                 Adet = g.Count()
                             };
                foreach (var group in result)
                {
                    Console.WriteLine("Ülke: {0}, Şehir:{1},Adet:{2}", group.Ulke, group.Sehir, group.Adet);
                }
            }
        }

        private static void Nine()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             group c by c.Country
                                         into g
                             select g;
                foreach (var group in result)
                {
                    Console.WriteLine(group.Key);
                }
            }
        }

        private static void Eight()
        {
            using (var northwindContext = new NorthwindContext())
            {
                List<Customer> result = (from c in northwindContext.Customers
                                         where c.City == "Berlin" || c.Country == "UK"
                                         select c).ToList();
                foreach (var customer in result)
                {
                    Console.WriteLine("Contact Name: {0}, City: {1}", customer.ContactName, customer.City);
                }


            }
        }

        private static void Seven()
        {
            using (var northwindContext = new NorthwindContext())
            {
                var result = from c in northwindContext.Customers
                             select new Musteri { Ulke = c.Country, Sirket = c.CompanyName, Adi = c.ContactName };

                foreach (var musteri in result)
                {
                    Console.WriteLine(musteri.Sirket);
                }
            }
        }

        private static void Six()
        {
            using (var northwindContext = new NorthwindContext())
            {
                List<Customer> result = (from c in northwindContext.Customers
                                         select c).ToList();
                foreach (var customer in result)
                {
                    Console.WriteLine(customer.ContactName);
                }


            }
        }

        private static void Five()
        {
            using (var northwindContext = new NorthwindContext())
            {
                Customer customer = northwindContext.Customers.Find("ENGİN");
                customer.Country = "Turkey";
                northwindContext.SaveChanges();
            }
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

    internal class Musteri
    {
        public string Ulke { get; internal set; }
        public string Sirket { get; internal set; }
        public string Adi { get; internal set; }
    }
}

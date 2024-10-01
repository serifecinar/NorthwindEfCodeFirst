using NorthwindEfCodeFirst.Context;

namespace NorthwindEfCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using(NorthwindContext northwindContext=new NorthwindContext())            
            {
                foreach (var customer in northwindContext.Customers)
                {
                    Console.WriteLine("Customer Name : {0}", customer.ContactName);
                }
            }
            Console.ReadLine();
        }
    }
}

using System.Xml.Serialization;

namespace LinqQueryHW
{
    //DOV KIMMEL, T005770
    internal class Program
    {
        static void Main(string[] args)
        {
            Sale[] sales = new Sale[]
{           //dummy info for testing
            new Sale { Item = "Peppers", Customer = "Customer1", PricePerItem = 10.0, Quantity = 2, Address = "Address1", ExpeditedShipping = true },
            new Sale { Item = "pizza", Customer = "Customer2", PricePerItem = 15.0, Quantity = 3, Address = "Address2", ExpeditedShipping = false },
            new Sale { Item = "Apples", Customer = "Customer3", PricePerItem = 20.0, Quantity = 11, Address = "Address3", ExpeditedShipping = true },
            new Sale { Item = "Beef", Customer = "Customer4", PricePerItem = 8.0, Quantity = 5, Address = "Address4", ExpeditedShipping = false },
            new Sale { Item = "Nugget", Customer = "Customer5", PricePerItem = 12.0, Quantity = 8, Address = "Address5", ExpeditedShipping = true },
            new Sale { Item = "Pudding", Customer = "Customer6", PricePerItem = 25.0, Quantity = 2, Address = "Address6", ExpeditedShipping = false },
            new Sale { Item = "Tea", Customer = "Customer7", PricePerItem = 30.0, Quantity = 1, Address = "Address7", ExpeditedShipping = false},
            new Sale { Item = "Tea", Customer = "Customer8", PricePerItem = 110.0, Quantity = 1, Address = "Address8", ExpeditedShipping = true},
            new Sale { Item = "Beans LLC", Customer = "Customer9", PricePerItem = 11.0, Quantity = 3, Address = "Address9", ExpeditedShipping = true},
            new Sale { Item = "Potatoe llc", Customer = "Customer10", PricePerItem = 310.0, Quantity = 33, Address = "Address10", ExpeditedShipping = false}
        };


            //QUESTION ONE
            //var questionOne = sales.Where(sale => sale.PricePerItem > 10.0);
            var questionOne = from sale in sales
                              where sale.PricePerItem > 10.0
                              select sale;
            //Sale.printResults(questionOne);

            //QUESTION TWO
            //var questionTwo = sales.Where(sale => sale.Quantity == 1)
            //                 .OrderByDescending(sale => sale.PricePerItem);
            var questionTwo = from sale in sales
                              where sale.Quantity == 1
                              orderby sale.PricePerItem descending
                              select sale;
            //Sale.printResults(questionTwo);

            //QUESTION THREE
            //var questionThree = sales.Where(sale => sale.Item.Equals("Tea") && !sale.ExpeditedShipping);
            var questionThree = from sale in sales
                                where sale.Item.Equals("Tea") && !sale.ExpeditedShipping
                                select sale;
            //Sale.printResults(questionThree);

            //QUESTION FOUR
            //var questionFour = sales.Where(sale => (sale.PricePerItem * sale.Quantity) > 100);
            var questionFour = from sale in sales
                               where (sale.PricePerItem * sale.Quantity) > 100
                               select sale;
            //Sale.printResults(questionFour);

            //QUESTION FIVE
            var questionFive = from sale in sales
                               where sale.Item.Contains("LLC") || sale.Item.Contains("llc")
                               orderby (sale.Quantity * sale.PricePerItem)
                               select new
                               {
                                   item = sale.Item,
                                   totalPrice = (sale.PricePerItem * sale.Quantity),
                                   shipping = sale.Address + (sale.ExpeditedShipping ? " EXPIDATED" : "")
                               };

            //TEST FOR QUESTION 5
            //foreach (var sale in questionFive)
            //{
            //    Console.WriteLine($"Item: {sale.item}");
            //    Console.WriteLine($"Total Price: {sale.totalPrice}");
            //    Console.WriteLine($"Shipping: {sale.shipping}");
            //    Console.WriteLine();
            //}


        }
    }


    public class Sale
    {
        public String Item { get; set; }
        public String Customer { get; set; }
        public double PricePerItem { get; set; }
        public int Quantity { get; set; }
        public String Address { get; set; }
        public bool ExpeditedShipping { get; set; }

        public static void printResults(IEnumerable<Sale> query)
        {
            foreach (var sale in query)
            {
                Console.WriteLine(query.ToString());
                Console.WriteLine($"Item: {sale.Item}");
                Console.WriteLine($"Customer: {sale.Customer}");
                Console.WriteLine($"Price Per Item: {sale.PricePerItem}");
                Console.WriteLine($"Quantity: {sale.Quantity}");
                Console.WriteLine($"Address: {sale.Address}");
                Console.WriteLine($"Expedited Shipping: {sale.ExpeditedShipping}");
                Console.WriteLine();

            }
        }
    }

}
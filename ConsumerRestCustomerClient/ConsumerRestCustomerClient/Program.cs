using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerRestCustomerClient
{
    class Program
    {

        private static string customerURL = "http://localhost:52801/Service1.svc/customers/";
        static void Main(string[] args)
        {

            IList<Customer> customlist = GetCustomersAsync().Result;
            Console.WriteLine("list of customers");

            foreach (var customer in customlist)
            {
                Console.WriteLine(customer.FirstName);
            }
           

            Customer c1 = GetCustomerasync(1).Result;
            Console.WriteLine("Customers firstname");
            Console.WriteLine(c1.FirstName);

            Console.ReadLine();
        }
        
        private static async Task<IList<Customer>> GetCustomersAsync()

        {

            using (HttpClient client = new HttpClient())

            {
                string content = await client.GetStringAsync(customerURL);
                IList<Customer> cList = JsonConvert.DeserializeObject<IList<Customer>>(content);
                return cList;

            }
          
        }
        private static async Task<Customer>GetCustomerasync(int id)
        {
            string requestURL = customerURL + id;
            using (HttpClient client = new HttpClient())

            {
                string content = await client.GetStringAsync(requestURL);
                Customer customers = JsonConvert.DeserializeObject<Customer>(content);
                return customers;

            }

        }




       
    }
}

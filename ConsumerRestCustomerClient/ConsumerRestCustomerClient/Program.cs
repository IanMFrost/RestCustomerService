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
        static void Main(string[] args)
        {
            IList<Customer> customlist = GetCustomersAsync().Result;
            Console.WriteLine(GetCustomersAsync());
            Console.ReadLine();
        }
        private static async Task<IList<Customer>> GetCustomersAsync()

        {

            using (HttpClient client = new HttpClient())

            {
                string content = await client.GetStringAsync("/customers");

                IList<Customer> cList = JsonConvert.DeserializeObject<IList<Customer>>(content);

                return cList;

            }
        }
    }
}

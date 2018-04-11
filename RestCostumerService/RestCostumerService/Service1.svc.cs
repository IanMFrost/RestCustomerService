using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestCostumerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public static int nextId = 0;
        public string GetData()
        {
            return "Hej";
        }

        private static List<Customer> clist = new List<Customer>() // static betyder at man skaber kun én liste som clients kan tilgå. Objekterne anvender den samme liste 
        {
            new Customer (1,"Ian","Frost", 1995),
            new Customer (2, "Nikolaj", "Dyring", 1994)
        };
        

        public IList<Customer>GetCustomers()
        {
            return clist;
        }

        public Customer GetCustomer(string id)
        {
            
            foreach (var customer in clist)
            {
                if(customer.ID == Int32.Parse(id))
                {
                    return customer;
                }
            }
            return null;
        }
        
        public void DeleteCustomer(string id)
        {
            foreach (var customer in clist)
            {
                if(customer.ID == Int32.Parse(id))
                {
                    clist.Remove(customer);

                   
                }
                
            }
            
            
        }
        public void InsertCustomer(Customer customer)
        {
            customer.ID = Service1.nextId++;
            clist.Add(customer);
            
        }

        public Customer UpdateCustomer(Customer UpdateCustomer, string id)
        {
            foreach (var Customer in clist)
            {
                if(Customer.ID == Int32.Parse(id))
                {
                    
                }
            }
            
        }
        

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        
    }
}

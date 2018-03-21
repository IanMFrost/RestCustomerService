using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestCostumerService
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Year { get; set; }


        public Customer(int id, string first, string last, int year)
        {
            ID = id;
            FirstName = first;
            LastName = last;
            Year = year;
            
        }

        public Customer()
        {

        }



    }
}
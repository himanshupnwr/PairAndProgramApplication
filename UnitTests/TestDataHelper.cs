using AspNetBasicApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class TestDataHelper
    {
        public static List<Customer> GetFakeEmployeeList()
        {
            return new List<Customer>()
            {
                new Customer
                {
                    ID = 1,
                    Name = "John Doe",
                    EmailId = "J.D@gmail.com",
                    Address = "123-456-7890"
                },
                new Customer
                {
                    ID = 2,
                    Name = "Mark Luther",
                    EmailId = "M.L@gmail.com",
                    Address = "123-456-7890"
                }
            };
        }
    }
}

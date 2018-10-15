using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2;
using WebApplication2.Models;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
      

        [TestMethod]
        public void GetAllCustomers_ShouldReturnAllProducts()
        {
          //  var testcust = GetCustomers();
            var controller = new  WebApplication2.Controllers.CustomersController();

            var result = controller.GetCustomers() as List<Customer>;
            Assert.AreEqual(2, result.Count);
        }


        private List<Customer> GetCustomers()
        {
            WebApplication2.Models.CustomerContact cont = new WebApplication2.Models.CustomerContact()
            {
                email = "dd1@gmail.com",
                firstName = "first",
                lastName = "last 1"
                //  customer=cust

            };
            WebApplication2.Models.CustomerContact cont2 = new WebApplication2.Models.CustomerContact()
            {
                email = "dd2ff31@gmail.com",
                firstName = "first 2",
                lastName = "last 2"
            };

            var ll = new List<CustomerContact>();
            var ll2 = new List<CustomerContact>();

            ll.Add(cont);
            ll2.Add(cont2);

            var testCustomers = new System.Collections.Generic.List<Customer>();
            testCustomers.Add(new Customer
            {
                customerContact = ll,
                NumberOfEmployees = 45,
                Title = "IT department"
            });
            testCustomers.Add(new Customer
            {
                customerContact = ll2,
                NumberOfEmployees = 45,
                Title = "IT department"
            });
           
            return testCustomers;
        }
    }
}

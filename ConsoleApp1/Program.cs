using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Controllers;
using WebApplication2.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            string url = "http://localhost:49779/api/Customers";

            //client.BaseAddress = new Uri("http://localhost:49778/api/Customers");
            client.DefaultRequestHeaders.Clear();


            Console.WriteLine("choose your action: 1 ->GET ,");
            Console.WriteLine("                  : 2 ->POST ,");
            Console.WriteLine("                  : 3 ->PUT ,");
            Console.WriteLine("                  : 4 ->DELETE ");
            string choice = Console.ReadLine();

            WebApplication2.Models.CustomerContact cont = new WebApplication2.Models.CustomerContact()
            {
                email = "dd@gmail.com",
                firstName = "anna",
                lastName = "anna"
              //  customer=cust
             
            };
            WebApplication2.Models.CustomerContact cont2 = new WebApplication2.Models.CustomerContact()
            {
                email = "dd231@gmail.com",
                firstName = "nikos",
                lastName = "nikos"
            };


            var ll = new List<CustomerContact>();
          
            ll.Add(cont);
            ll.Add(cont2);

          //  cust.customerContact = ll;

            WebApplication2.Models.Customer cust = new WebApplication2.Models.Customer()
            {
                customerContact = ll,
                NumberOfEmployees = 33,
                Title = "president"
            };

            HttpResponseMessage response = new HttpResponseMessage();
            switch (int.Parse(choice))
            {
                case 1:
                    response = client.GetAsync(url).Result;
                    WebApplication2.Models.Customer[] data = JsonConvert.DeserializeObject<WebApplication2.Models.Customer[]>(response.Content.ReadAsStringAsync().Result);

                    break;
                case 2:
                     response = client.PostAsJsonAsync< WebApplication2.Models.Customer>(url,cust).Result;
                    Console.WriteLine(response.ToString());
                    break;
                case 3:
                     response = client.PostAsJsonAsync(url,cust).Result;
                    Console.WriteLine(response.ToString());
                    break;
                    //case 4:
                    // response = client.DeleteAsync()
            }

          





        }


      

    }
}

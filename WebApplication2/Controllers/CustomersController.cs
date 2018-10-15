using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustomersController : ApiController
    {
        private WebApplication2Context db = new WebApplication2Context();

       private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //public IEnumerable<Customer> GetAllCustomers()
        //{
        //    return db.Customers;
        //}



        // GET: api/Customers
        [HttpGet]
        public IQueryable<Customer> GetCustomers()
        {
            Log.Info("Get Customers requested");
            return db.Customers;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                Log.Error("Customer not found with id :" + id.ToString());

                return NotFound();
               // return  new CustomActionResult<Customer>("de brika",Request);

            }
            Log.Error("Customer  found with id :" + id.ToString());

            //return Ok();
            return new CustomActionResult<Customer>(" brika", Request,HttpStatusCode.OK);
         }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
                return new CustomActionResult<Customer>("Error", Request, HttpStatusCode.NotFound);

            }

            try
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            catch (Exception es)
            {
                Log.Error(es.Message.ToString());
            }

            return Ok();

            return new CustomActionResult<Customer>(" OK", Request, HttpStatusCode.OK);
              }


        //// PUT: api/Customers/5
        //[ResponseType(typeof(void))]
        //public void PutCustomer(int id, Customer customer)
        //{

        //    Log.Info("Put Customers requested");
        //    if (!ModelState.IsValid)
        //    {
        //        //  return new CustomActionResult<Customer>("", Request);

        //        //return new CustomActionResult<Customer>(Request, HttpStatusCode.NotAcceptable, customer);

        //    }

        //    if (id != customer.CustomerId)
        //    {
        //        // return new CustomActionResult<Customer>("", Request);

        //        //return new CustomActionResult<Customer>(Request, HttpStatusCode.NotAcceptable, customer);

        //    }

        //    db.Entry(customer).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerExists(id))
        //        {
        //            // return new CustomActionResult<Customer>("", Request);

        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    //    return new CustomActionResult<Customer>("", Request);

        //    // return new CustomActionResult<Customer>(Request, HttpStatusCode.OK, customer);

        //}


        //// DELETE: api/Customers/5
        //[ResponseType(typeof(CustomActionResult<Customer>))]
        //public CustomActionResult<Customer> DeleteCustomer(int id)
        //{
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return new CustomActionResult<Customer>("", Request);

        //    }

        //    db.Customers.Remove(customer);
        //    db.SaveChanges();

        //    return new CustomActionResult<Customer>("", Request);

        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.CustomerId == id) > 0;
        }
    }
}
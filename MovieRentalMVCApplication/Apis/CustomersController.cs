using MovieRentalMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRentalMVCApplication.Apis
{
    public class CustomersController : ApiController
    {
      private  ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //get     /api/customers
            public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        //GET /api/customers/id
        public Customer GetCustomerById(int ? id)
        {
            return _context.Customers.SingleOrDefault(c => c.Id == id);
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                BadRequest();
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }
        [HttpPut]
        public void UpdateCustomer(int id,Customer customer)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customerInDb.Name = customer.Name;
            customerInDb.DOB = customer.DOB;
            customerInDb.IsSuscribed = customer.IsSuscribed;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();
        }
      
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }


    }
}

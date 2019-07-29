using MovieRentalMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalMVCApplication.ViewModel;
using System.Net.Http;

namespace MovieRentalMVCApplication.Controllers
{
  //  [Authorize]
    public class CustomerController : Controller
    {

        ApplicationDbContext _context;


        public CustomerController()
        {
            _context = new ApplicationDbContext();

        }

        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

 
        public ActionResult Details(int ? id)
        {
            var customers = _context.Customers.Include(c =>c.membershipType).SingleOrDefault(c => c.Id == id);//eager loading
            if (customers == null)
                return HttpNotFound();

            return View(customers);
        }
      
        public ActionResult Edit(int?id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);//eager loading
            if (customers == null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel
            {
                Customer = customers,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("New", viewModel);
            //return View(obj);
        }
        //public ActionResult Index()
        //{
        //    var customers = _context.Customers.Include(c => c.membershipType).ToList();
        //    return View(customers);
        //}


        public ActionResult Index()
        {
            IEnumerable<Customer> customers = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53072/api/");
                var responseTask = client.GetAsync("customers");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Customer>>();
                    readTask.Wait();
                    customers = readTask.Result;
                }
                else
                {
                    customers = Enumerable.Empty<Customer>();
                    ModelState.AddModelError(string.Empty, "Servor error");

                
                }
            }
                return View(customers);
        }

        // GET: Customer
        [Authorize(Roles="admin")]
        public ActionResult New()
        {
            
            
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {                
                //Customer = customer,
                MembershipTypes = membershipTypes
            };


            return View(viewModel);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
        //    if (!ModelState.IsValid)
        //    {
        //        var viewModel = new NewCustomerViewModel
        //        {
        //            Customer =customer,
        //            MembershipTypes = _context.MembershipTypes.ToList()
        //    };
        //        return View("New", viewModel);
        //}



            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DOB = customer.DOB;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSuscribed = customer.IsSuscribed;
                
            }
            _context.SaveChanges();//link to entity
            return RedirectToAction("Index", "Customer");
        }


        public ActionResult Back()
        {
          
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Delete(int id)
        {
            Customer customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
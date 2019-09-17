using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;


namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        #region Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel customerFormViewModel)
        {
            //Add validation
            if (!ModelState.IsValid)
            {
                customerFormViewModel.MembershipTypes = _context.MembershipTypes.ToList();
                return View("CustomerForm", customerFormViewModel);
            }
            Customer customer = customerFormViewModel.Customer;
            customer.MembershipType = _context.MembershipTypes.ToList().FirstOrDefault(x => x.Id == customer.MembershipTypeId);

            if (!customer.Id.HasValue)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                Customer customerInDb = _context.Customers.Single(x => x.Id == customer.Id);
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.BirdtDate = customer.BirdtDate;
                customerInDb.IsSubscribedToNewslatter = customer.IsSubscribedToNewslatter;
                customerInDb.MembershipType = customer.MembershipType;
                customerInDb.Name = customer.Name;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Customers", "Customers");
        } 
        #endregion

        #region New
        public ActionResult New()
        {
            CustomerFormViewModel nevCustomerFormViewModel = new CustomerFormViewModel()
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", nevCustomerFormViewModel);
        } 
        #endregion

        #region Customers
        // GET: Customer
        public ActionResult Customers()
        {
            CustomersModel customersModel = new CustomersModel
            {
                Customers = _context.Customers.Include(c => c.MembershipType).ToList().OrderBy(x => x.Name)
            };

            return View(customersModel);
        } 
        #endregion

        #region Customer
        // GET: Customers
        [Route("customers/customer/{id}")]
        public ActionResult Customer(int? id)
        {
            CustomersModel customersModel = new CustomersModel
            {
                Customers = _context.Customers.Include(c => c.MembershipType).ToList()
            };

            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            Customer customer = customersModel.Customers.FirstOrDefault(x => x.Id == id);
            return View(customer);
        }
        #endregion


        #region Edit
        public ActionResult Edit(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return HttpNotFound();

            }

            CustomerFormViewModel customerFormViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", customerFormViewModel);
        } 
        #endregion
    }
}
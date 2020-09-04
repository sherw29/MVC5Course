using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Web.UI.WebControls;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




        // GET: Customer
        public ActionResult CreateOrEditCustomer()
        {
            var MembershipTypesList = _context.MembershipTypes.ToList();

            var viewModel = new NewCustomerViewModel {
                MembershipTypes = MembershipTypesList };

                return View("CreateOrEditCustomer",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdateCustomer(Customer customer)
        {
            ModelState.Remove("customer.Id");
            if (ModelState.IsValid)
            {
                if (customer.Id == 0)
                { 
                    _context.Customers.Add(customer);
                    _context.SaveChanges();
                    ModelState.Clear();
                    ViewBag.SuccessMessage = "Registeration Successful";
                    return RedirectToAction("CreateOrEditCustomer");

                }
                else
                {
                    
                    _context.Entry(customer).State = EntityState.Modified;
                    _context.SaveChanges();
                    ModelState.Clear();
                    ViewBag.SuccessMessage = "Details Updated Successfully";
                    return RedirectToAction("CustomerList");
                }
            }
                    return RedirectToAction("CreateOrEditCustomer");
            

        }
        public ActionResult CustomerList()
        {
            //var viewModel = new CustomerViewModel
            //{
            //    Customers = _context.Customers.ToList(),
            //    MembershipTypes=_context.MembershipTypes.ToList()
            //};
            return View(/*viewModel*/);
        }

        public ActionResult CustomerDetails(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult RemoveCustomer(int Id)
        {
           Customer customer = _context.Customers.Where(x => x.Id.Equals(Id)).First();
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");

        }

        public ActionResult EditCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList(),
            };
            return View("CreateOrEditCustomer",viewModel);
           

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using VOD.Models;
using VOD.ViewModels;
using System.Data.Entity.Infrastructure.MappingViews;

namespace VOD.Controllers
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
		// GET: Customers
		public ViewResult Index()
		{
			//var customers = GetCustomers();
			//var customers = _context.Customers.Include(c => c.MembershipType).ToList();

			//return View(customers);
			return View();
		}
		public ActionResult Details(int id)
		{
			var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}
		public ActionResult New()
		{
			var membershipTypes = _context.MembershipTypes.ToList();
			var viewModel = new NewCustomerViewModel
			{
				Customer = new Customer(),
				MembershipTypes = membershipTypes
			};
			return View("CustomerForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new NewCustomerViewModel
				{
					Customer = customer,
					MembershipTypes = _context.MembershipTypes.ToList()
				};
				return View("CustomerForm", viewModel);
			}
			if (customer.Id == 0)
				_context.Customers.Add(customer);
			else
			{
				var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

				customerInDb.Name = customer.Name;
				customerInDb.SubscribedToNewsletter = customer.SubscribedToNewsletter;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				customerInDb.Birthdate = customer.Birthdate;
			}
			_context.SaveChanges();

			return RedirectToAction("Index", "Customers");
		}

		public ActionResult Edit(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
			if (customer == null)
				return HttpNotFound();

			//Tutaj NewCustomerFormViewModel edycja customera nie tworzenie nowego!
			var viewModel = new NewCustomerViewModel
			{
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
			};

			return View("CustomerForm", viewModel);
		}


	}
}
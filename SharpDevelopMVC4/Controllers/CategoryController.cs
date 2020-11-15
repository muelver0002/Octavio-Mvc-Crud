using System;
using System.Web.Mvc;
using SharpDevelopMVC4.Models;
using System.Linq;


namespace SharpDevelopMVC4.Controllers
{
	
	public class CategoryController : Controller
	{
		SdMvc4DbContext _db = new SdMvc4DbContext();
		public ActionResult Index()
		{
			var categories =_db.Categories.ToList();		
			return View(categories);
		}
		
		
		[HttpGet]
		public ActionResult Cat()
		{
			return View();
		}
		
		[HttpPost]
		public ActionResult Cat(Category p)
		{

			_db.Categories.Add(p);
			_db.SaveChanges();
			
			return RedirectToAction("Index");
		
		}
		
		
	}
}
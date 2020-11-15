using System;
using System.Web.Mvc;

namespace SharpDevelopMVC4.Controllers
{
	/// <summary>
	/// Description of AccountController.
	/// </summary>
	public class AccountController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
		
		[HttpGet]
		public ActionResult Login()
		{
		    ViewBag.Authenticated = false;
			return View();
		}
		
		[HttpPost]
		public ActionResult Login(string name , string pass)
		{
		  string Username = "muelver";
		  string Pass = "pass123";
		  
		  if(Username == name &&  Pass == pass)
		  {
		   
		  	Session["user"] = name;
		  	HttpContext.Cache["lastuserlogin"] = DateTime.Now.ToString("hh:mm:ss tt");
		  	return RedirectToAction("Contact","Home");
		  }
		  
		  else
		  {
		  	ViewBag.message = "Invalid Username or Password!";
		  	ViewBag.Authenticated = false;
		  	return View();
		  }
		     
		   
		}
		   
		 
		}
	}

using System;
using System.Web.Mvc;

namespace SharpDevelopMVC4.Controllers
{
	/// <summary>
	/// Description of StudentController.
	/// </summary>
	public class StudentController : Controller
	{
		public ActionResult Calcu()
		{
			return View();
		}
	
		public ActionResult Register()
		{
			return View();
		}
		public ActionResult Save(string lastname, string firstname, string bday , string course , string gender)
		{
			ViewBag.LastName = lastname;
			ViewBag.FirstName = firstname;
			ViewBag.BirthDate = bday;
			ViewBag.Course = course;
			ViewBag.Gender = gender == "M" ? "Male" : "Female" ;
			
			return View();
		}
		
		public ActionResult Registered(string lastname, string firstname,string bday , string course , string gender){
			
		    ViewBag.LastName = lastname;
			ViewBag.FirstName = firstname;
			ViewBag.BirthDate = bday;
			ViewBag.Course = course;
			ViewBag.Gender = gender == "M" ? "Male" : "Female" ;
			
			return View();
		
		}
	}
}
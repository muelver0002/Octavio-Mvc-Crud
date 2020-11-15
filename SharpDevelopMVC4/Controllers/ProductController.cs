using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SharpDevelopMVC4.Models;
using System.Linq;

namespace SharpDevelopMVC4.Controllers
{
	
	public class ProductController : Controller
	{
		SdMvc4DbContext _db = new SdMvc4DbContext();


		public ActionResult Index()
		{
			var products = _db.Products.ToList();			
			return View(products);
		}
		
		public ActionResult Add()
		{
			var products = _db.Products.ToList();			
			return View(products);
		}
		
		
		
		
			public 	ActionResult Search(string key, string priceSort)
		{
		
			
			if(string.IsNullOrWhiteSpace(key))
			{
				 List<Product> searchResult = _db.Products.ToList();
				 ViewBag.Products = searchResult;
				
				if(priceSort == "low")
				{
					searchResult = searchResult.OrderBy(x => x.Price).ToList();
				}
				else if(priceSort == "high")
				{
					searchResult = searchResult.OrderByDescending(x => x.Price).ToList();
				}
				        						
				return View("Index", searchResult);
			
			}
			
			else
			{
				List<Product> searchResult = _db.Products
				.Where(x => x.Name.ToLower()
				       .Contains(key.ToLower()))
				.ToList();
				
				if(priceSort == "low")
				{
					searchResult = searchResult.OrderBy(x => x.Price).ToList();
				}
				else if(priceSort == "high")
				{
					searchResult = searchResult.OrderByDescending(x => x.Price).ToList();
				}
				
				return View("Index", searchResult);	
		
		}
			
		
		}
		
			
			
			public ActionResult Delete(int Id)
		{
			var p = _db.Products.Find(Id);
			
			if(p !=null)
			{
				_db.Products.Remove(p);
				_db.SaveChanges();
			}
		
			return RedirectToAction("Add");
		}
			
			
			
			
			public ActionResult Edit(int Id)
		  {
			var p = _db.Products.Find(Id);
		    if(p !=null)
			 {
		    	List<Category> categories = _db.Categories.ToList();
 			     ViewBag.Categories= categories;
 			     
 			     var category = _db.Categories.ToList();
 			     ViewBag.Category = category;
 			     
		    	 ViewBag.Product = p;
		    	
		    	  ViewBag.ID = Id;
		    	  var c = _db.Products.Find(Id);
		    	  ViewBag.Cat = c.CategoryID;

				   return View(p);
			
			 }
			
			else
			{
				return RedirectToAction("Add");
			}
		
		}
				
					
		[HttpPost]
		public ActionResult Edit(Product updatedProduct)
		{
			var p = _db.Products.Find(updatedProduct.Id);
			
			p.CategoryID = updatedProduct.CategoryID;
			p.Name = updatedProduct.Name;
			p.Price = updatedProduct.Price;
			p.Location = updatedProduct.Location;
			p.StockOnHand = updatedProduct.StockOnHand;
			
			_db.Entry(p).State = System.Data.Entity.EntityState.Modified;
			_db.SaveChanges();
			 
			return RedirectToAction("Add");
		}
			
		
		
		[HttpGet] 
		public ActionResult Create()
		{
			return View();
		}
		
		[HttpPost]
		public ActionResult Create(Product p)
		{

			_db.Products.Add(p);
			_db.SaveChanges();
			
			return RedirectToAction("Add");
		
		}
		
		public 	ActionResult SearchVet(string key, string priceSort)
		{
		
			
			if(string.IsNullOrWhiteSpace(key))
			{
				 List<Product> searchResult = _db.Products.ToList();
				 ViewBag.Products = searchResult;
				
				if(priceSort == "low")
				{
					searchResult = searchResult.OrderBy(x => x.Price).ToList();
				}
				else if(priceSort == "high")
				{
					searchResult = searchResult.OrderByDescending(x => x.Price).ToList();
				}
				        						
				return View("Add", searchResult);
			
			}
			
			else
			{
				List<Product> searchResult = _db.Products
				.Where(x => x.Name.ToLower()
				       .Contains(key.ToLower()))
				.ToList();
				
				if(priceSort == "low")
				{
					searchResult = searchResult.OrderBy(x => x.Price).ToList();
				}
				else if(priceSort == "high")
				{
					searchResult = searchResult.OrderByDescending(x => x.Price).ToList();
				}
				
				return View("Add", searchResult);	
		
		}
			
		
		}
		
			
			
			
			
//		  [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Creates(Product product)
//        {
//            if(ModelState.IsValid)
//            {
//            	var fileUpload = Request.Files[0];
//            	
//            	var folder = Server.MapPath("~/UploadedFiles/Products");
//            	
//                product.Picture = fileUpload.ToImageByteArray();
//                db.Products.Add(product);
//                db.SaveChanges();
//            }
//            return RedirectToAction("Index", "Products", new { area = "OrderFramework" });
//        }

		
		
	}
}
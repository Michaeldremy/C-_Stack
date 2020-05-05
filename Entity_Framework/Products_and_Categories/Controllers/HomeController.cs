using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products_and_Categories.Models;
using Microsoft.EntityFrameworkCore;


// THIS ASSIGNMENT WAS DONE USING WRAPPER MODELS! THIS WILL LOOK DIFFERENT COMPARED TO YOUR OTHER ASSIGNMENTS

namespace Products_and_Categories.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            ProdCatWrapper newWrapper = new ProdCatWrapper();
            newWrapper.Products = dbContext.Products.ToList();
            return View("Index", newWrapper);
        }
        // This is giving us the ability to look at one product based of the product ID amd make a list of all the categories
        [HttpGet("products/{productId}")]
        public IActionResult DisplayOneProduct(int productId)
        {

            ProdCatWrapper thisProduct = new ProdCatWrapper();
            Product thisProd = dbContext.Products
                .Include(c => c.CategoryAssociation)
                .ThenInclude(p => p.Category)
                .FirstOrDefault( c => c.ProductId == productId);
            List<Category> ExcludeThis = new List<Category>();
            thisProd.CategoryAssociation.ForEach(pa => ExcludeThis.Add(pa.Category));

            thisProduct.Product = dbContext.Products
                .Include(p => p.CategoryAssociation)
                .ThenInclude(p => p.Category)
                .FirstOrDefault(c => c.ProductId == productId);
            // This is including the category association but it is excluding the "ExcludeThis" List<Category> above.
            thisProduct.Categories = dbContext.Categories.Except(ExcludeThis).ToList();
            return View(thisProduct);
        }

        [HttpPost("createproduct")]
        public IActionResult CreateProduct(ProdCatWrapper fromForm)
        {
            dbContext.Add(fromForm.Product);
            dbContext.SaveChanges();
            return RedirectToAction("Index", fromForm);
        }

        // This is giving us the ability to look at one category based off of the category ID amd make a list of all the products
        [HttpGet("categories/{categoryId}")]
        public IActionResult DisplayOneCategory(int categoryId)
        {

            ProdCatWrapper thisCategory = new ProdCatWrapper();
            Category thisCat = dbContext.Categories
                .Include(c => c.ProductAssociation)
                .ThenInclude(p => p.Product)
                .FirstOrDefault( c => c.CategoryId == categoryId);
            List<Product> ExcludeThis = new List<Product>();
            thisCat.ProductAssociation.ForEach(pa => ExcludeThis.Add(pa.Product));

            thisCategory.Category = dbContext.Categories
                .Include(p => p.ProductAssociation)
                .ThenInclude(p => p.Product)
                .FirstOrDefault(c => c.CategoryId == categoryId);
                // This is including the product association but it is excluding the "ExcludeThis" List<Product> above.
            thisCategory.Products = dbContext.Products.Except(ExcludeThis).ToList();
            return View(thisCategory);
        }

        [HttpGet("categories")]
        public IActionResult ViewCategories()
        {
            ProdCatWrapper categoryWrapper = new ProdCatWrapper();
            categoryWrapper.Categories = dbContext.Categories.ToList();
            return View("ViewCategories", categoryWrapper);
        }

        [HttpPost("createcategory")]
        public IActionResult createcategory(ProdCatWrapper fromCategoryForm)
        {
            if (ModelState.IsValid)
            {
            dbContext.Add(fromCategoryForm.Category);
            dbContext.SaveChanges();
            return RedirectToAction("ViewCategories", fromCategoryForm);
            }
            else
            {
                return View("ViewCategories", fromCategoryForm);
            }
        }

        [HttpPost("addProdassociation/{productId}")]
        public IActionResult UpdateProdAssociation(int productId, ProdCatWrapper fromAssociationForm)
        {
            fromAssociationForm.Association.ProductId = productId;
            dbContext.Add(fromAssociationForm.Association);
            dbContext.SaveChanges();
            return RedirectToAction ("DisplayOneProduct");
        }

        [HttpPost("addCateassociation/{categoryId}")]
        public IActionResult UpdateCateAssociation(int categoryId, ProdCatWrapper fromCateAssociationForm)
        {
            fromCateAssociationForm.Association.CategoryId = categoryId;
            dbContext.Add(fromCateAssociationForm.Association);
            dbContext.SaveChanges();
            return RedirectToAction ("DisplayOneCategory");
        }

        // public IActionResult Privacy()
        // {
        //     return View();
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

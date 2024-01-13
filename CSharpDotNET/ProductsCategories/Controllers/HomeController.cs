using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsCategories.Models;

namespace ProductsCategories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger ,MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {  ViewBag.Products = _context.Products.Include(p => p.ProductAssociation).ToList();
        return View();
    }

     [HttpPost]
    public IActionResult CreateProduct(Product productFromForm)
    {
        if(ModelState.IsValid){
            _context.Add(productFromForm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.Products = _context.Products.Include(p => p.ProductAssociation).ToList();

        return View("Index");
    }
     [HttpPost]
    public IActionResult CreateCategory(Category categoryFromForm)
    {
        if(ModelState.IsValid)
        {
            _context.Add(categoryFromForm);
            _context.SaveChanges();
            return RedirectToAction("Category");
        }

        List<Category> Categories = _context.Categories.Include(c => c.CategoryAssociation).ToList();
        ViewBag.Category = _context.Categories.Include(c => c.CategoryAssociation).ToList();
        ViewBag.Category = _context.Categories.ToList();

        return View("Category",categoryFromForm);
    }
     [HttpGet("product/{id}")]
    public IActionResult Product(int id)
    {

        Product product = _context.Products.Include(p => p.ProductAssociation).ThenInclude(a => a.Category).FirstOrDefault(e => e.ProductId == id);

        ViewBag.ExistingCategories = product?.ProductAssociation.Select(a => a.Category).ToList() ?? new List<Category>();        
        List<Category> Categories = _context.Categories.ToList();
        ViewBag.CategoriesToInclude = Categories;

        return View(product);
    }

    [HttpGet("categories/{id}")]
    public IActionResult Categories(int id)
    {

        Category category = _context.Categories.Include(p => p.CategoryAssociation).ThenInclude(a => a.Product).FirstOrDefault(e => e.CategoryId == id);

        ViewBag.ExistingProducts = category.CategoryAssociation.Select(a => a.Product).ToList() ?? new List<Product>();


        List<Product> products = _context.Products.ToList();
        ViewBag.ProductsToInclude = products;

        return View("category");
    }

    [HttpPost]
    public IActionResult AddCategory(int productId, int categoryId) {
        if (ModelState.IsValid) {
            if (!_context.Associations.Any(a => a.ProductId == productId && a.CategoryId == categoryId)) {
                Association newAssociation = new Association {
                    ProductId = productId,
                    CategoryId = categoryId
                };

                _context.Associations.Add(newAssociation);
                _context.SaveChanges();
                
                }
            }
            return RedirectToAction("Product", new { id = productId });
    }

    [HttpPost]
    public IActionResult AddProduct(int productId, int categoryId) {
        if (ModelState.IsValid) {
            Console.WriteLine($"Attempting to add product {productId} to category {categoryId}");

            if (!_context.Associations.Any(a => a.CategoryId == categoryId && a.ProductId == productId)) {
                Association newAssociation = new Association {
                    ProductId = productId,
                    CategoryId = categoryId
                };

                _context.Associations.Add(newAssociation);
                _context.SaveChanges();
                
                }
            }
            Console.WriteLine("Product added to category successfully");

            return RedirectToAction("Categories", new { id = categoryId });
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

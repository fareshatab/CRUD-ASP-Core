using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using Shop.Models.ViewModel;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _db;
        private int id;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var products = _db.Products.Include(x => x.Category).Where(x => !x.IsDelete).ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.categoryList = new SelectList(_db.Categories.Where(x => !x.IsDelete).ToList(), "Id", "Name");
            return View();

        }
        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {


            var product = new Product();

            product.Name = model.Name;
            product.Describtion = model.Describtion;
            product.Price = model.Price;
            product.ImgURL = model.ImgURL;
            product.CategoryId = model.CategoryId;
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _db.Products.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            if (product == null)
            {
                return NotFound();
            }
            var model = new UpdateProductViewModel
            {
                Id = product.Id,
                Name = product.Name
            };
            ViewBag.categoryList = new SelectList(_db.Categories.Where(x => !x.IsDelete).ToList(), "Id", "Name");
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(UpdateProductViewModel input)
        {
            var product = _db.Products.SingleOrDefault(x => x.Id == input.Id && !x.IsDelete);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = input.Name;
            product.Describtion = input.Describtion;
            product.Price = input.Price;
            product.ImgURL = input.ImgURL;
            product.CategoryId = input.CategoryId;
            _db.Products.Update(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _db.Products.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            if (product == null)
            {
                return NotFound();
            }
            product.IsDelete = true;
            _db.Products.Update(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

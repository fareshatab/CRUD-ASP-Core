using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;
using Shop.Models.ViewModel;

namespace Shop.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var categories = _db.Categories.Where(x => !x.IsDelete).ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryViewModel input) {
            var category = new Category();
            category.Name = input.Name;
            category.CreatedAt = DateTime.Now;

            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == id && !x.IsDelete );
            if (category == null)
            {
                return NotFound();
            }
            var model = new UpdateCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(UpdateCategoryViewModel input)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == input.Id && !x.IsDelete);
            if (category == null)
            {
                return NotFound();
            }
            category.Name = input.Name;
            category.UpdatedAt = DateTime.Now;
            _db.Categories.Update(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _db.Categories.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            if (category == null)
            {
                return NotFound();
            }
            category.IsDelete = true;
            _db.Categories.Update(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

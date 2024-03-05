using Microsoft.AspNetCore.Mvc;
using TravelWeb.Data;
using TravelWeb.Models;

namespace TravelWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
          List<Category> category = _context.Categories.ToList();
            return View(category);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}

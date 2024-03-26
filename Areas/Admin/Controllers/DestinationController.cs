using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelWeb.Data;
using TravelWeb.Models;

namespace TravelWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {

        private readonly ApplicationDbContext _context;
        public DestinationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Destination> destination = _context.Destinations.ToList();
            
            return View(destination);
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> category = _context.Destinations
                .ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            ViewBag.CategoryList = category;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Destination obj)
        {
            if (ModelState.IsValid)
            {

                _context.Destinations.Add(obj);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Destination? destination = _context.Destinations.Find(id);

            if (destination == null)
            {
                return NotFound();
            }
            return View(destination);
        }

        [HttpPost]
        public IActionResult Edit(Destination obj)
        {
            if (ModelState.IsValid)
            {

                _context.Destinations.Update(obj);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Destination? destination = _context.Destinations.Find(id);

            if (destination == null)
            {
                return NotFound();
            }
            return View(destination);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            Destination obj = _context.Destinations.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Destinations.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}


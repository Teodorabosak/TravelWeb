using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelWeb.Models;
using TravelWeb.Repository;
using TravelWeb.Repository.IRepository;

namespace TravelWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {

        private readonly IUnit _unit;
        public DestinationController(IUnit unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            List<Destination> destination = _unit.Destination.GetAll().ToList();

            
            return View(destination);
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _unit.Category
               .GetAll().Select(u => new SelectListItem
               {
                   Text = u.Name,
                   Value = u.Id.ToString()

               });
            ViewBag.CategoryList = CategoryList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Destination obj)
        {
            if (ModelState.IsValid)
            {

                _unit.Destination.Add(obj);
                _unit.Save();

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

            Destination? destination = _unit.Destination.Get(u => u.Id == id);

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

                _unit.Destination.Update(obj);
                _unit.Save();

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

            Destination? destination = _unit.Destination.Get(u => u.Id == id);

            if (destination == null)
            {
                return NotFound();
            }
            return View(destination);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            Destination obj = _unit.Destination.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unit.Destination.Delete(obj);
            _unit.Save();
            return RedirectToAction("Index");

        }
    }
}


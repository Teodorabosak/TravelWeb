using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelWeb.Data;
using TravelWeb.Models;
using TravelWeb.Repository;
using TravelWeb.Repository.IRepository;
using TravelWeb.Utility;

namespace TravelWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_User_Admin)]
    public class CategoryController : Controller
    {

        private readonly IUnit _unit;
        public CategoryController(IUnit unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            List<Category> category = _unit.Category.GetAll().ToList();
            return View(category);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {

                _unit.Category.Add(obj);
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

            Category? category = _unit.Category.Get(u=>u.Id==id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {

                _unit.Category.Update(obj);
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

            Category? category = _unit.Category.Get(u => u.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            Category obj = _unit.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unit.Category.Delete(obj);
            _unit.Save();
            return RedirectToAction("Index");

        }
    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using TravelWeb.Models;
using TravelWeb.Models.ViewModels;
using TravelWeb.Repository.IRepository;
using static System.Net.Mime.MediaTypeNames;

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

                DestinationVM destinationVM = new()
            {
                CategoryList=_unit.Category
               .GetAll().Select(u => new SelectListItem
               {
                   Text = u.Name,
                   Value = u.Id.ToString()

               }),
            
                Destination = new Destination()
            };
            return View(destinationVM);
        }

        [HttpPost]
        public IActionResult Create(DestinationVM destinationVM)
        {
            
           if (ModelState.IsValid)
            {

                _unit.Destination.Add(destinationVM.Destination);
                _unit.Save();

                return RedirectToAction("Index");

            } else
            {
                destinationVM.CategoryList = _unit.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                   Value = u.Id.ToString()

                });

                return View(destinationVM);
            }

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


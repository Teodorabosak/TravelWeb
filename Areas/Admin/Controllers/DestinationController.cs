using Microsoft.AspNetCore.Mvc;
using TravelWeb.Models;
using TravelWeb.Repository.IRepository;

namespace TravelWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {

        private readonly IDestinationRepository _destinationRepo;
        public DestinationController(IDestinationRepository context)
        {
            _destinationRepo = context;
        }

        public IActionResult Index()
        {
            List<Destination> destination = _destinationRepo.GetAll().ToList();
            return View(destination);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Destination obj)
        {
            if (ModelState.IsValid)
            {

                _destinationRepo.Add(obj);
                _destinationRepo.Save();

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

            Destination? destination = _destinationRepo.Get(u => u.Id == id);

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

                _destinationRepo.Update(obj);
                _destinationRepo.Save();

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

            Destination? destination = _destinationRepo.Get(u => u.Id == id);

            if (destination == null)
            {
                return NotFound();
            }
            return View(destination);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            Destination obj = _destinationRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _destinationRepo.Delete(obj);
            _destinationRepo.Save();
            return RedirectToAction("Index");

        }
    }
}


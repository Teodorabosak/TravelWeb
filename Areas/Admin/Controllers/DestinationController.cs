using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelWeb.Models;
using TravelWeb.Models.ViewModels;
using TravelWeb.Repository.IRepository;
using TravelWeb.Utility;
using static System.Net.Mime.MediaTypeNames;

namespace TravelWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DestinationController : Controller
    {

        private readonly IUnit _unit;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DestinationController(IUnit unit, IWebHostEnvironment webHostEnvironment)
        {
            _unit = unit;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Destination> destination = _unit.Destination.GetAll().ToList();
            return View(destination);
        }
        public IActionResult Upsert(int? id)
        {

            DestinationVM destinationVM = new()
            {
                CategoryList = _unit.Category
           .GetAll().Select(u => new SelectListItem
           {
               Text = u.Name,
               Value = u.Id.ToString()

           }),

                Destination = new Destination()
            };
            if (id == null || id == 0)
            {

                return View(destinationVM);
            }
            else //update
            {
                destinationVM.Destination = _unit.Destination.GetFirstOrDefault(u => u.Id == id);
                return View(destinationVM);

            }
        }

        [HttpPost]
        public IActionResult Upsert(DestinationVM destinationVM, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\destination");
                    var extension = Path.GetExtension(file.FileName);

                    if (destinationVM.Destination.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, destinationVM.Destination.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    destinationVM.Destination.ImageUrl = @"\images\destination\" + fileName + extension;

                }

                if (destinationVM.Destination.Id == 0)
                {
                    _unit.Destination.Add(destinationVM.Destination);


                }
                else
                {
                    _unit.Destination.Update(destinationVM.Destination);

                }

                _unit.Save();

                return RedirectToAction("Index");

            }
            return View(destinationVM);
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Destination? destination = _unit.Destination.GetFirstOrDefault(u => u.Id == id);

            if (destination == null)
            {
                return NotFound();
            }
            return View(destination);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            Destination obj = _unit.Destination.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unit.Destination.Delete(obj);
            _unit.Save();
            return RedirectToAction("Index");

        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var destinationList = _unit.Destination.GetAll(includeProperties: "Category");
            return Json(new { data = destinationList });
        }
    }
}
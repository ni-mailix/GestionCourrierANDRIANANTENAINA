using Microsoft.AspNetCore.Mvc;
using MonNameSpaceGestionCourrier.Models;
using MonNameSpaceGestionCourrier.ViewModels;
using System;

namespace MonNameSpaceGestionCourrier.Controllers
{
    public class CourrierController : Controller
    {
        private readonly Data.GestionCourrierDbContext _dbContext;

        public CourrierController(Data.GestionCourrierDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Actions du contrôleur...

        public IActionResult CreateCourrier()
        {
            return View("CreateCourrier");
        }

        [HttpPost]
        public IActionResult CreateCourrier(CourrierViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Logique de création d'un courrier
Console.WriteLine("Hello, World!");
              //  return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}

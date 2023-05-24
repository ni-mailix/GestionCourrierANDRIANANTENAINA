using Microsoft.AspNetCore.Mvc;
using MonNameSpaceGestionCourrier.Models;
using MonNameSpaceGestionCourrier.ViewModels;
using System;

namespace MonNameSpaceGestionCourrier.Controllers
{
    public class MouvementController : Controller
    {
        private readonly Data.GestionCourrierDbContext _dbContext;

        public MouvementController(Data.GestionCourrierDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Actions du contrôleur...

        public IActionResult Create()
        {
            return View("CreateMouvement");
        }

        [HttpPost]
        public IActionResult Create(MouvementViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Logique de création d'un mouvement

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}

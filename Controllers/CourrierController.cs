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
            return View("~/Views/Courrier/CreateCourrier.cshtml");
        }


[HttpPost]
public IActionResult CreateCourrier(CourrierViewModel model)
{
    if (ModelState.IsValid)
    {
        // Logique de création d'un courrier

        // Retourner la vue de succès ou une autre action
        //return View("CreateCourrierSuccess");
        Console.WriteLine("vue affiché");
    }

    // Si le modèle n'est pas valide, afficher à nouveau la vue de création avec le modèle
    return View("CreateCourrier", model);
}

    }
}

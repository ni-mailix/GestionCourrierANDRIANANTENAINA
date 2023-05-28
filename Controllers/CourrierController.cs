using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonNameSpaceGestionCourrier.Data;
using MonNameSpaceGestionCourrier.Models;
using MonNameSpaceGestionCourrier.ViewModels;
using System;

namespace MonNameSpaceGestionCourrier.Controllers
{
    public class CourrierController : Controller
    {
        private readonly GestionCourrierDbContext _dbContext;
        private readonly ILogger<CourrierController> _logger;

        public CourrierController(GestionCourrierDbContext dbContext, ILogger<CourrierController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult CreateCourrier()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCourrier(CourrierViewModel model)
        {
            if (ModelState.IsValid)
            {
                var courrier = new Courrier
                {
                    Objet = model.Objet,
                    DateArrivee = model.DateArrivee,
                    Expediteur = model.Expediteur,
                    Destinataire = model.Destinataire,
                    Urgent_O_N = model.Urgent_O_N
                };

                try
                {
                    _dbContext.Courriers.Add(courrier);
                    _dbContext.SaveChanges();

                    _logger.LogInformation("Les données ont été insérées avec succès dans la base de données.");

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Une erreur s'est produite lors de l'insertion des données.");
                    ModelState.AddModelError("", "Une erreur s'est produite lors de l'insertion des données. Veuillez réessayer.");

                    return View(model);
                }
            }

            return View(model);
        }
    }
}

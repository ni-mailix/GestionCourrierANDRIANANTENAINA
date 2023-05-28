using Microsoft.AspNetCore.Mvc;
using MonNameSpaceGestionCourrier.Data;
using MonNameSpaceGestionCourrier.Models;
using MonNameSpaceGestionCourrier.ViewModels;

namespace MonNameSpaceGestionCourrier.Controllers
{
    public class CourrierController : Controller
    {
        private readonly GestionCourrierDbContext _dbContext;

        public CourrierController(GestionCourrierDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Actions du contrôleur...

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

                _dbContext.Courriers.Add(courrier);
                _dbContext.SaveChanges();

                // Redirigez vers une action appropriée (par exemple, Index)
                return RedirectToAction("Index", "Home");
            }

            // Si le modèle n'est pas valide, affichez à nouveau la vue avec les erreurs de validation
            return View(model);
        }
    }
}

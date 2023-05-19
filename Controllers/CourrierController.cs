using Microsoft.AspNetCore.Mvc;
using MonNameSpaceGestionCourrier.Data;
using MonNameSpaceGestionCourrier.ViewModels;
using System;

namespace MonNameSpaceGestionCourrier.Controllers
{
    public class CourrierController : Controller
    {
        private readonly GestionCourrierDbContext _dbContext;

        public CourrierController(GestionCourrierDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Autres actions du contrôleur...

        [HttpPost]
        public IActionResult CreateCourrier(Guid courrierId, MouvementViewModel model)
        {
            if (ModelState.IsValid)
            {
                var courrier = _dbContext.Courriers.Find(courrierId);

                if (courrier != null)
                {
                    var mouvement = new MouvementCourrier
                    {
                        Id = Guid.NewGuid(),
                        CourrierId = courrierId,
                        Statut = model.Statut,
                        Acteur = model.Acteur,
                        DateMouvement = model.DateMouvement,
                        Nom_depositaire = model.Nom_depositaire
                    };

                    // Enregistrez le mouvement dans la base de données
                    _dbContext.MouvementsCourriers.Add(mouvement);
                    _dbContext.SaveChanges();

                    // Mettez à jour la date de modification du courrier
                    courrier.DateModification = DateTime.Now;
                    _dbContext.SaveChanges();

                    // Redirigez vers la page de détails du courrier
                    return RedirectToAction("Details", "Courrier", new { id = courrierId });
                }
            }

            // Si le modèle n'est pas valide ou si le courrier n'est pas trouvé, retournez à la vue précédente avec les erreurs de validation
            return View(model);
        }
    }
}

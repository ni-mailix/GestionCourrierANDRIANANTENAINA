using Microsoft.AspNetCore.Mvc;
using MonNameSpaceGestionCourrier.ViewModels;

[HttpPost]
public IActionResult Create(CourrierViewModel model)
{
    if (ModelState.IsValid)
    {
        var courrier = new Courrier
        {
            Id = Guid.NewGuid(),
            Objet = model.Objet,
            DateArrivee = model.DateArrivee,
            Expediteur = model.Expediteur,
            Destinataire = model.Destinataire,
            Urgent_O_N = model.Urgent_O_N,
            DateCreation = DateTime.Now,
            DateModification = null
        };

        // Enregistrez le courrier dans la base de données
        _dbContext.Courriers.Add(courrier);
        _dbContext.SaveChanges();

        // Créez un mouvement initial associé à ce courrier
        var mouvement = new MonNameSpaceGestionCourrier.Data.MouvementCourrier
        {
            Id = Guid.NewGuid(),
            CourrierId = courrier.Id,
            Statut = "Reçu",
            Acteur = "Receptionniste",
            DateMouvement = model.DateArrivee,
            Nom_depositaire = "Receptionniste"
        };

        // Enregistrez le mouvement dans la base de données
        _dbContext.MouvementsCourriers.Add(mouvement);
        _dbContext.SaveChanges();

        // Redirigez vers la page de détails du courrier nouvellement créé
        return RedirectToAction("Details", new { id = courrier.Id });
    }

    // Si le modèle n'est pas valide, retournez à la vue de création avec les erreurs de validation
    return View(model);
}

using System;
using System.Collections.Generic;
using MonNameSpaceGestionCourrier.Models;

namespace MonNameSpaceGestionCourrier.ViewModels
{
    public class MouvementViewModel
    {
        public string? Statut { get; set; }
        public string? Acteur { get; set; }
        public DateTime? DateMouvement { get; set; }
        public string? Nom_depositaire { get; set; }

        public List<MouvementCourrier> Mouvements { get; set; }

        public MouvementViewModel()
        {
            Mouvements = new List<MouvementCourrier>();
        }
    }
}

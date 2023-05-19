using System;
using System.ComponentModel.DataAnnotations;

namespace MonNameSpaceGestionCourrier.ViewModels
{
    public class MouvementViewModel
    {
        [Required]
        public string Statut { get; set; }

        [Required]
        public string Acteur { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateMouvement { get; set; }

        public string Nom_depositaire { get; set; }
    }
}

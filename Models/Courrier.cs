using System;

namespace MonNameSpaceGestionCourrier.Models
{
    public class Courrier
    {
        public Guid Id { get; set; }
        public string Objet { get; set; }
        public DateTime DateArrivee { get; set; }
        public string Expediteur { get; set; }
        public string Destinataire { get; set; }
        public string Urgent_O_N { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
    }
}

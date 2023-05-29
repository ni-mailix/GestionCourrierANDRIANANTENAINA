using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MonNameSpaceGestionCourrier.Models
{
    [Table("Courrier")]
    public class Courrier
    {
        public Guid Id { get; set; }
        public string? Objet { get; set; }
        public DateTime? DateArrivee { get; set; }
        public string? Expediteur { get; set; }
        public string? Destinataire { get; set; }
        public string? Urgent_O_N { get; set; }
    }
}

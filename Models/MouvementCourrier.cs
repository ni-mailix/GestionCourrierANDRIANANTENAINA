namespace MonNameSpaceGestionCourrier.Data
{
    public class MouvementCourrier
    {
        
    public Guid Id { get; set; }
    public Guid CourrierId { get; set; }
    public string Statut { get; set; }
    public string Acteur { get; set; }
    public DateTime DateMouvement { get; set; }
    public string Nom_depositaire { get; set; }
    }
}
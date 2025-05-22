using System.Collections.Generic;

namespace TestProgi.Application.DTOs
{
    public class CalculResultDto    // TODO : utiliser les dto a la place de manipuler le domaine directement
    {
        public string? Marque { get; set; }
        public string? Modele { get; set; }
        public int Annee { get; set; }
        public string? Type { get; set; }
        public List<FraisDetailDto>? Frais { get; set; }
        public decimal FraisTotal { get; set; }
    }
}

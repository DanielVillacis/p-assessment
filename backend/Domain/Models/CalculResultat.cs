using TestProgi.Domain.Entities;

namespace TestProgi.Domain.Models
{
    public class CalculResultat
    {
        public decimal PrixBase { get; set; }
        public required List<FraisDetail> DetailsFrais { get; set; }
        public decimal TotalFrais => DetailsFrais.Sum(f => f.Montant);
        
        public decimal Total => PrixBase + TotalFrais;
    }
}
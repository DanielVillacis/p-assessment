using System;

namespace TestProgi.Domain.Entities
{
    public class FraisDetail
    {
        public string Description { get; private set; }
        public decimal Montant { get; private set; }

        public FraisDetail(string description, decimal montant)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("La description ne peut pas etre vide", nameof(description));
            }

            Description = description;
            Montant = montant;
        }
    }
}

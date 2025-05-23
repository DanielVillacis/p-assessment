using TestProgi.Domain.Enums;
using TestProgi.Domain.Models;

namespace TestProgi.Services
{
    public interface ICalculateurDeFraisService
    {
        CalculResultat CalculerFrais(decimal prixBase, TypeVehicule typeVehicule);
    }
}

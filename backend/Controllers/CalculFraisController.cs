using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestProgi.Domain.Enums;
using TestProgi.Domain.Models;
using TestProgi.Services;

namespace TestProgi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculFraisController : ControllerBase
    {
        private readonly CalculateurDeFraisService _calculateurService;
        public CalculFraisController(CalculateurDeFraisService calculateurService)
        {
            _calculateurService = calculateurService;
        }

        [HttpPost("calculer")]
        public ActionResult<CalculResultat> Calculer([FromBody] CalculFraisRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultat = _calculateurService.CalculerFrais(request.PrixBase, request.TypeVehicule);

            return Ok(resultat);
        }

        [HttpGet("types-vehicules")]
        public ActionResult<IEnumerable<string>> GetVehicleTypes()
        {
            return Ok(TypeVehiculeExtensions.GetAvailableTypes());
        }

    }

    public class CalculFraisRequest
    {
        [Required]
        [System.ComponentModel.DataAnnotations.Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être supérieur à 0")]
        public decimal PrixBase { get; set; }

        [Required]
        public TypeVehicule TypeVehicule { get; set; } = TypeVehicule.Ordinaire;
    }
}
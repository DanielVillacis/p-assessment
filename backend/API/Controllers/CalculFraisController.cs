////filepath: /Users/danielvillacis/RiderProjects/TEST/API/Controllers/CalculFraisController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using TestProgi.Application.Services;
using TestProgi.Domain.Enums;

namespace TestProgi.API.Controllers
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
        public ActionResult<CalculateurDeFraisService.CalculResultat> Calculer([FromBody] CalculFraisRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var typeVehicule = request.TypeVehicule.Equals("deluxe", StringComparison.OrdinalIgnoreCase) 
                ? TypeVehicule.Deluxe 
                : TypeVehicule.Ordinaire;
                
            var resultat = _calculateurService.CalculerFrais(request.PrixBase, typeVehicule);
            return Ok(resultat);
        }
    }

    public class CalculFraisRequest
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être supérieur à 0")]
        public decimal PrixBase { get; set; }
        
        [Required]
        public string TypeVehicule { get; set; } = "ordinaire";
    }
}
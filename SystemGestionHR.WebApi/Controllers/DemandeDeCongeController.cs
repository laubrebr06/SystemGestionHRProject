using Microsoft.AspNetCore.Mvc;
using SystemGestionHR.Services.Interfaces;
using SystemGestionHR.Data.DTO;
using SystemGestionHR.Services.UseCases;
using SystemGestionHR.Data.Models;
using SystemGestionHR.Data.Enum;

namespace SystemGestionHR.Controllers
{
    [ApiController]
    [Route("api/v1/demandesDeConge")]
    public class DemandeDeCongeController : ControllerBase
    {
        private readonly IDemandeDeCongeService _demandeDeCongeService;
        private readonly SoumettreDemandeDeCongeUseCase _soumettreDemandeDeCongeUseCase;
        private readonly GererDemandeDeCongeUseCase _gererDemandeDeCongeUseCase;

        public DemandeDeCongeController(IDemandeDeCongeService demandeDeCongeService)
        {
            _demandeDeCongeService = demandeDeCongeService;
            _soumettreDemandeDeCongeUseCase = new SoumettreDemandeDeCongeUseCase(_demandeDeCongeService);
            _gererDemandeDeCongeUseCase = new GererDemandeDeCongeUseCase(_demandeDeCongeService);
        }

        [HttpPost("/SoumettreDemandeDeConge")]
        public IActionResult SoumettreDemandeDeConge([FromBody] int employeId, string? employeNom, string? typeConge, DateTime dateDebut, DateTime dateFin, string? commentaireEmploye)
        {
            try
            {
                int demandeDeCongeId = 0;
                bool? status = null;
                TypeCongeEnum? type = (TypeCongeEnum)Enum.Parse(typeof(TypeCongeEnum), typeConge);
                int typeCongeId = (int)type;


                var demandeDeConge = _soumettreDemandeDeCongeUseCase.Executer(
                    demandeDeCongeId,
                    employeId,
                    typeCongeId,
                    status,
                    dateDebut,
                    dateFin,
                    typeConge,
                    employeNom,
                    commentaireEmploye
                );

                DemandeDeConge demande = new DemandeDeConge();
                return CreatedAtAction(nameof(ObtenirDemandeDeConge), new { id = demandeDeConge.DemandeDeCongeId}, demande);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{demandeDeCongeId}/ObtenirDemandeDeConge")]
        public IActionResult ObtenirDemandeDeConge(int demandeDeCongeId)
        {
            try
            {
                var demande = _demandeDeCongeService.ObtenirDemandeDeCongeParId(demandeDeCongeId);
                return Ok(demande);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{demandeDeCongeId}/approuver")]
        public IActionResult ApprouverDemande(int demandeDeCongeId, string? commentaireManager)
        {
            try
            {
                var success = _demandeDeCongeService.ApprouverDemandeDeConge(demandeDeCongeId, commentaireManager);
                return success
                    ? Ok(new { message = "Demande approuvée avec succès." })
                    : NotFound(new { message = "Demande introuvable." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{demandeDeCongeId}/rejeter")]
        public IActionResult RejeterDemande(int demandeDeCongeId, string? commentaireManager)
        {
            try
            {
                var success = _demandeDeCongeService.RejeterDemandeDeConge(demandeDeCongeId, commentaireManager);
                return success
                    ? Ok(new { message = "Demande rejetée avec succès." })
                    : NotFound(new { message = "Demande introuvable." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

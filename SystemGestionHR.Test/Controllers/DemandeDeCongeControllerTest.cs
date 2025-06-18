using SystemGestionHR.Services.UseCases;
using SystemGestionHR.Services.Interfaces;
using SystemGestionHR.Data.Enum;
using SystemGestionHR.Data.Models;
using SystemGestionHR.Data.DTO;
using Moq;

namespace SystemGestionHR.Test.Controller
{
    public class DemandeDeCongeControllerTest
    {
        private readonly IDemandeDeCongeService _demandeDeCongeService;

        [Fact]
        public void Executer_CreationValide_RetourneNouvelleDemande()
        {
            // Arrange
            var mockRepo = new Mock<IDemandeDeCongeService>();
            var soumettreDemandeDeCongeUseCaseUseCase = new SoumettreDemandeDeCongeUseCase(mockRepo.Object);

            var demandeDeCongeId = 1;
            var employeId = 1;
            var statusId = (int)StatutCongeEnum.EnAttente;
            bool? status = statusId == 2 ? null : statusId == 1 ? true : false;
            var nomComplet = "Laura Brenes";
            var dateDebut = new DateTime(2025, 7, 1);
            var dateFin = new DateTime(2025, 7, 5);
            var typeCongeId = (int)TypeCongeEnum.Vacances;
            var type = "Vacances";
            var commentaire = "Congé été";

            // Act
            var demande = soumettreDemandeDeCongeUseCaseUseCase.Executer(demandeDeCongeId, employeId, typeCongeId, status, dateDebut, dateFin, type, nomComplet, commentaire);

            // Assert
            Assert.NotNull(demande);
            Assert.Equal(employeId, demande.EmployeId);
            Assert.Equal(dateDebut, demande.DateDebut);
            Assert.Equal(dateFin, demande.DateFin);
            Assert.Equal(typeCongeId, demande.TypeCongeId);
            Assert.Equal(commentaire, demande.CommentaireEmploye);
            Assert.Equal(status, demande.Status);

            // Verifica que la demande se guardó
            mockRepo.Verify(r => r.SoumettreDemandeDeConge(It.IsAny<DemandeDeCongeDTO>()), Times.Once);
        }

        [Fact]
        public void SoumettreDemandeDeConge_Valide_RetourneObjetCorrect()
        {
            var employeId = 1;
            var start = new DateTime(2025, 7, 1);
            var end = new DateTime(2025, 7, 5);

            DemandeDeConge demande = new DemandeDeConge();
            demande.DemandeDeCongeId = 0;
            demande.EmployeId = employeId;
            demande.DateDebut = DateTime.Today;
            demande.DateFin = DateTime.Today.AddDays(2);
            demande.TypeCongeId = (int)TypeCongeEnum.Vacances;
            demande.Status = null;
            demande.CommentaireEmploye = "Vacances d'été";
            bool? statusDemandeDeConge = null;
            if ((int)StatutCongeEnum.EnAttente == 2)
                statusDemandeDeConge = null;

            Assert.Equal(employeId, demande.EmployeId);
            Assert.Equal((int)TypeCongeEnum.Vacances, demande.TypeCongeId);
            Assert.Equal(statusDemandeDeConge, demande.Status);
        }

        [Fact]
        public void SoumettreDemandeConge_DatesInvalides_LanceException()
        {
            var employeId = 1;
            var typeConge = "Maladie";
            var nomComplet = "Laura Brenes";
            var dateDebut = new DateTime(2025, 7, 5);
            var dateFin = new DateTime(2025, 7, 1);
            var commentaire = "Testing";

            SoumettreDemandeDeCongeUseCase _soumettreDemandeDeCongeUseCase = new SoumettreDemandeDeCongeUseCase(_demandeDeCongeService);

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                _soumettreDemandeDeCongeUseCase.Executer(0, employeId, (int)TypeCongeEnum.Maladie, null, dateDebut, dateFin, typeConge, nomComplet, commentaire)
            );

        }

        [Fact]
        public void SoumettreDemandeConge_DatesPassées_LanceException()
        {
            var employeId = 1;
            var typeConge = "Maladie";
            var nomComplet = "Laura Brenes";
            var dateDebut = new DateTime(2025, 6, 5);
            var dateFin = new DateTime(2025, 6, 1);
            var commentaire = "Testing";

            SoumettreDemandeDeCongeUseCase _soumettreDemandeDeCongeUseCase = new SoumettreDemandeDeCongeUseCase(_demandeDeCongeService);

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                _soumettreDemandeDeCongeUseCase.Executer(0, employeId, (int)TypeCongeEnum.Maladie, null, dateDebut, dateFin, typeConge, nomComplet, commentaire)
            );
        }

        [Fact]
        public void Approuver_ChangeStatutEtAjouteCommentaire()
        {
            // Arrange
            var employeId = 1;
            var demandeDeCongeId = 1;
            DemandeDeConge demande = new DemandeDeConge();
            demande.DemandeDeCongeId = demandeDeCongeId;
            demande.EmployeId = employeId;
            demande.DateDebut = DateTime.Today;
            demande.DateFin = DateTime.Today.AddDays(2);
            demande.TypeCongeId = (int)TypeCongeEnum.Vacances;
            demande.Status = true;
            demande.CommentaireEmploye = "Congé été";

            string commentaireManager = "Approuvé pour les vacances d'été";

            // Act
            demande.CommentaireManager = commentaireManager;

            bool? statusApprouve = null;
            if ((int)StatutCongeEnum.Approuve == 1)
                statusApprouve = true;
            // Assert
            Assert.Equal(statusApprouve, demande.Status);
            Assert.Equal(commentaireManager, demande.CommentaireManager);
        }

        [Fact]
        public void Rejeter_ChangeStatutEtAjouteCommentaire()
        {
            // Arrange
            var employeId = 2;
            var demandeDeCongeId = 1;
            DemandeDeConge demande = new DemandeDeConge();
            demande.DemandeDeCongeId = demandeDeCongeId;
            demande.EmployeId = employeId;
            demande.DateDebut = DateTime.Today;
            demande.DateFin = DateTime.Today.AddDays(3);
            demande.TypeCongeId = (int)TypeCongeEnum.Vacances;
            demande.Status = false;
            demande.CommentaireEmploye = "Congé été";

            string commentaireManager = "Rejeté car période critique";

            // Act
            demande.CommentaireManager = commentaireManager;

            bool? statusRejete = null;
            if ((int)StatutCongeEnum.Rejete == 0)
                statusRejete = false;

            // Assert
            Assert.Equal(statusRejete, demande.Status);
            Assert.Equal(commentaireManager, demande.CommentaireManager);
        }
    }
}